using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Build.Framework;
using Microsoft.Build.Execution;

namespace WATKit.Build
{
	public static class BuildEngineExtensions
	{
		const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public;

		public static IEnumerable<string> GetEnvironmentVariable(this IBuildEngine buildEngine, string key, bool throwIfNotFound)
		{
			var projectInstance = GetProjectInstance(buildEngine);

			var items = projectInstance.Items
				.Where(x => string.Equals(x.ItemType, key, StringComparison.InvariantCultureIgnoreCase)).ToList();
			if(items.Count > 0)
			{
				return items.Select(x => x.EvaluatedInclude);
			}


			var properties = projectInstance.Properties
				.Where(x => string.Equals(x.Name, key, StringComparison.InvariantCultureIgnoreCase)).ToList();
			if(properties.Count > 0)
			{
				return properties.Select(x => x.EvaluatedValue);
			}

			if(throwIfNotFound)
			{
				throw new Exception(string.Format("Could not extract from '{0}' environmental variables.", key));
			}

			return Enumerable.Empty<string>();
		}

		static ProjectInstance GetProjectInstance(IBuildEngine buildEngine)
		{
			var buildEngineType = buildEngine.GetType();
			var targetBuilderCallbackField = buildEngineType.GetField("targetBuilderCallback", bindingFlags);
			if(targetBuilderCallbackField == null)
			{
				throw new Exception("Could not extract targetBuilderCallback from " + buildEngineType.FullName);
			}
			var targetBuilderCallback = targetBuilderCallbackField.GetValue(buildEngine);
			var targetCallbackType = targetBuilderCallback.GetType();
			var projectInstanceField = targetCallbackType.GetField("projectInstance", bindingFlags);
			if(projectInstanceField == null)
			{
				throw new Exception("Could not extract projectInstance from " + targetCallbackType.FullName);
			}
			return (ProjectInstance)projectInstanceField.GetValue(targetBuilderCallback);
		}
	}
}
