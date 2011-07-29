using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit.Build
{
	/// <summary>
	/// Indicates the decorated members should be ignored
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=false)]
	public class IgnoreAttribute: Attribute
	{
		/// <summary>
		/// Gets or sets the reason.
		/// </summary>
		/// <value>
		/// Optional reason for ignoring the element
		/// </value>
		public string Reason { get; set; }
	}
}
