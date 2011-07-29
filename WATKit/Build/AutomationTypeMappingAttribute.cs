using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit.Build
{
	/// <summary>
	/// Maps an automation wrapper to a type for build validation
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=false)]
	public class AutomationTypeMappingAttribute: Attribute
	{
		/// <summary>
		/// Gets or sets the target type
		/// </summary>
		/// <value>
		/// The target type that the attached automation control represents in the application.
		/// </value>
		public string TargetType { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AutomationTypeMappingAttribute"/> class.
		/// </summary>
		/// <param name="targetType">Type of the target.</param>
        public AutomationTypeMappingAttribute(string targetType)
		{
			this.TargetType = targetType;
		}
	}
}
