using System;
using System.Windows.Automation;
using ControlType = System.Windows.Automation.ControlType;
using WATKit.Build;

namespace WATKit.Controls
{
	/// <summary>
	/// Default wrapper for automation elements
	/// </summary>
	public class AutomationControl
	{
		private AutomationElement automationElement;

		/// <summary>
		/// Gets the underlying automation element.
		/// </summary>
		[Ignore]
		public AutomationElement AutomationElement
		{
			get { return this.automationElement; }
			internal set
			{
				this.ValidateElement(value);
				this.automationElement = value;
			}
		}

		/// <summary>
		/// Gets or sets the type of the control.
		/// </summary>
		/// <value>
		/// The type of the control.
		/// </value>
		protected internal virtual ControlType ControlType { get { return ControlType.Custom; } }

		/// <summary>
		/// Gets the current criteria for find operations.
		/// </summary>
		[Ignore]
		public FindSettings FindSettings { get; internal set; }

		/// <summary>
		/// Gets the settings for the next or last wait operation.
		/// </summary>
		[Ignore]
		public WaitSettings WaitSettings { get; internal set; }

		/// <summary>
		/// Gets the name of the control if set
		/// </summary>
		[Ignore]
		public string Name { get { return this.AutomationElement.Current.Name; } }

		/// <summary>
		/// Gets a value indicating whether the control is enabled.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the control is enabled; otherwise, <c>false</c>.
		/// </value>
		[Ignore]
		public bool IsEnabled { get { return this.AutomationElement.Current.IsEnabled; } }

		/// <summary>
		/// Gets a value indicating the control is actually visible to automation.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the control is visible to automation and has actually been found; otherwise, <c>false</c> indicating what you are working with is a proxy rather than the real control.
		/// </value>
		[Ignore]
		public bool IsVisible { get { return !this.IsProxy && !this.AutomationElement.Current.IsOffscreen; } }

		/// <summary>
		/// Gets a value indicating whether this control is a proxy.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this control is a proxy for an element that could not be found; otherwise, <c>false</c>.
		/// </value>
		/// <remarks>
		/// In WinForms setting the Visible property to false effectively hides the control from the UI automation components, so WATKit provides a proxy that you can
		/// use later to find the real control or wait for it to become available.  For WPF applications the AutomationElement.IsOffScreenProperty returns true if the Visibility
		/// property of an element is set to Collapsed or Hidden.
		/// </remarks>
		[Ignore]
		public bool IsProxy { get { return this.AutomationElement == null; } }

		/// <summary>
		/// Validates the element.
		/// </summary>
		/// <param name="element">The element.</param>
		protected virtual void ValidateElement(AutomationElement element) { }
	}
}
