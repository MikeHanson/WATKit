using System;

namespace System.Windows.Automation.Toolkit
{
	/// <summary>
	/// Interface to be implemented by automation control components
	/// </summary>
	public interface IAutomationControl
	{
		/// <summary>
		/// Gets the underlying <see cref="Windows.Automation.AutomationElement" />
		/// </summary>
		AutomationElement AutomationElement { get; }
	}
}
