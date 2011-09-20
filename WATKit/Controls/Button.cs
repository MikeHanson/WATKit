using System;
using System.Windows.Automation;

namespace WATKit.Controls
{
	/// <summary>
	/// Wraps button for automation
	/// </summary>
	public class Button: AutomationControl
	{
		/// <summary>
		/// Gets or sets the type of the control.
		/// </summary>
		/// <value>
		/// The type of the control.
		/// </value>
		protected internal override ControlType ControlType
		{
			get
			{
				return ControlType.Button;
			}
		}

		/// <summary>
		/// Invokes the Click event of the button.
		/// </summary>
		public void Click()
		{
			var invoker = this.AutomationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
			if (invoker != null)
			{
				invoker.Invoke();
			}            
		}
	}
}
