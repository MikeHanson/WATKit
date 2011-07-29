using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.Cecil;

namespace WATKit.Build
{
	public class WATKitBuildTask: Task
	{
		/// <summary>
		/// Gets or sets the test assembly path.
		/// </summary>
		/// <value>
		/// The test assembly path.
		/// </value>
		[Required]
		public string TestAssembly { get; set; }

		/// <summary>
		/// Gets or sets the source assemblies.
		/// </summary>
		/// <value>
		/// The source assemblies.
		/// </value>
		[Required]
		public string SourceAssemblies { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="WATKitBuildTask"/> class.
		/// </summary>
		public WATKitBuildTask()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WATKitBuildTask"/> class.
		/// </summary>
		/// <param name="taskResources">The task resources.</param>
		public WATKitBuildTask(ResourceManager taskResources)
			: base(taskResources)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="WATKitBuildTask"/> class.
		/// </summary>
		/// <param name="taskResources">The task resources.</param>
		/// <param name="helpKeywordPrefix">The prefix to append to string resources to create Help keywords.</param>
		public WATKitBuildTask(ResourceManager taskResources, string
		helpKeywordPrefix)
			: base(taskResources, helpKeywordPrefix)
		{

		}

		/// <summary>
		/// Executes the task to check custom automation controls are valid.
		/// </summary>
		/// <returns>
		/// true if the task successfully executed; otherwise, false.
		/// </returns>
		public override bool Execute()
		{
			var success = true;
			try
			{
				Log.LogMessage("Processing WATKitBuildTask");
				Log.LogMessage(String.Format("Loading test assembly: {0}", this.TestAssembly));

				var testAssembly = AssemblyDefinition.ReadAssembly(this.TestAssembly);

				var assemblyPaths = this.SourceAssemblies.Split(',');
				var sourceModules = new List<ModuleDefinition>();
				for(var i = 0; i < assemblyPaths.Length; i++)
				{
					Log.LogMessage(String.Format("Loading source assembly: {0}", assemblyPaths[i]));
					var assembly = AssemblyDefinition.ReadAssembly(assemblyPaths[i]);
					foreach(var module in assembly.Modules)
					{
						sourceModules[i] = module;
					}
				}

				foreach(var module in testAssembly.Modules)
				{
					foreach(var item in module.Types)
					{
						Log.LogMessage(MessageImportance.Normal, String.Format("Processing {0}", item.Name));
						Log.LogMessage(MessageImportance.Normal, String.Format("Checking {0} for mapping attributes", item.Name));
						
						var attributes = item.CustomAttributes;
						if(attributes == null || attributes.Length == 0)
						{
							continue;
						}

						var attribute = attributes[0] as AutomationTypeMappingAttribute;
						Log.LogMessage(MessageImportance.High, String.Format("Found type mapping to {0} on {1}, processing properties", attribute.TargetType, item.FullName));

						Type targetType = null;
						foreach(var assembly in sourceModules)
						{
							targetType = assembly.GetType(attribute.TargetType);
							if(targetType != null)
							{
								break;
							}
						}

						if(targetType == null)
						{
							Log.LogError(String.Format("Could not find mapped type {0} in any of the source assemblies specified", attribute.TargetType));
							success = false;
							break;
						}

						var properties = item.GetProperties().Where(p => p.GetCustomAttributes(typeof(IgnoreAttribute), false).Length == 0).ToList();
						foreach(var property in properties)
						{
							Log.LogMessage(MessageImportance.High, String.Format("Checking {0} has a matching element in {1}", property.Name, targetType.FullName));
							var targetElement = targetType.GetProperty(property.Name);
							if(targetElement != null)
							{
								Log.LogMessage(MessageImportance.High, "Element found");
								targetElement = null;
								continue;
							}

							Log.LogError(String.Format("No element found matching {0} on {1}", property.Name, targetType.FullName));
							success = false;
						}
					}
				}
			}
			catch(ReflectionTypeLoadException rtlex)
			{
				success = false;
				Array.ForEach(rtlex.LoaderExceptions, exception => Log.LogErrorFromException(exception,
																							 true,
																							 true,
																							 null));
			}
			catch(Exception ex)
			{
				success = false;
				Log.LogErrorFromException(ex, true, true, null);
			}

			return success;
		}

		/// <summary>
		/// Called when reflection needs to load a dependent assembly.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="args">The <see cref="System.ResolveEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		Assembly OnReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
		{
			return Assembly.ReflectionOnlyLoad(args.Name);
		}
	}
}
