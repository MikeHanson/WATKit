using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit.Build
{
	/// <summary>
	/// Maps a member of an automation control to an element of a control that is represented by the automation control
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=false)]
	public class AutomationMemberMappingAttribute: Attribute
	{
		/// <summary>
		/// Gets or sets the name of the element.
		/// </summary>
		/// <value>
		/// The name of the element the member represents on a mapped type
		/// </value>
		public string ElementName { get; set; }

        /// <summary>
		/// Initializes a new instance of the <see cref="AutomationMemberMappingAttribute"/> class.
		/// </summary>
		/// <param name="elementName">Name of the element represented by the member</param>
		public AutomationMemberMappingAttribute(string elementName)
		{
			this.ElementName = elementName;
		}
	}
}
