using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using WATKit.Exceptions;

namespace WATKit.Controls
{
	/// <summary>
	/// Wraps password for automation
	/// </summary>
	public class PasswordBox : EditBoxBase
	{
		/// <summary>
		/// Validates the element.
		/// </summary>
		/// <param name="element">The element.</param>
		protected override void ValidateElement(AutomationElement element)
		{
			if(!element.Current.IsPassword)
			{
				throw new IncompatibleElementException("The specified element was found but is not compatible with PasswordBox");
			}
		}
	}
}
