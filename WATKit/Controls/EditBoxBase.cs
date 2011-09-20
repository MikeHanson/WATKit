using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WATKit.Controls
{
	/// <summary>
	/// Base for controls that wrap edit control
	/// </summary>
	public abstract class EditBoxBase: AutomationControl
	{
		/// <summary>
		/// Gets or sets the type of the control.
		/// </summary>
		/// <value>
		/// The type of the control.
		/// </value>
		protected internal override ControlType ControlType { get { return ControlType.Edit; } }

		/// <summary>
		/// Gets the value provider.
		/// </summary>
		protected ValuePattern ValueProvider
		{
			get { return this.AutomationElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern; }
		}

		/// <summary>
		/// Types the text.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="typeRateMilliseconds">Milliseconds to wait between each character.</param>
		public void TypeText(string text, int typeRateMilliseconds = 0)
		{
			if(String.IsNullOrEmpty(text))
			{
				return;
			}

			this.AutomationElement.SetFocus();
			SendKeys.SendWait("^{HOME}");
			SendKeys.SendWait("^+{END}");
			SendKeys.SendWait("{DEL}");

			if(typeRateMilliseconds == 0)
			{
				SendKeys.SendWait(text);
				return;
			}

			foreach(var character in text.ToCharArray())
			{
				SendKeys.SendWait(character.ToString());
				Thread.Sleep(typeRateMilliseconds);
			}
		}

		/// <summary>
		/// Sets the text.
		/// </summary>
		/// <param name="text">The text.</param>
		public void SetText(string text)
		{
			if(this.ValueProvider != null)
			{
				this.ValueProvider.SetValue(text);
			}
		}
	}
}
