using System;
using System.Windows.Automation;

namespace WATKit.Controls
{
	/// <summary>
	/// Wraps the windows desktop for automation
	/// </summary>
	public class Desktop
	{
		/// <summary>
		/// Gets the element wrapped by this control.
		/// </summary>
		internal AutomationElement Element
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Desktop"/> class.
		/// </summary>
		public Desktop()
		{
			this.Element = AutomationElement.RootElement;
		}

		/// <summary>
		/// Finds the window by title.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="secondsToRetry">The seconds to retry.</param>
		/// <returns>First window or child window with the specified title</returns>
		public TWindow FindWindowByTitle<TWindow>(string title, int secondsToRetry = 0)
			where TWindow: Window, new()
		{
			return this.Element.FindWindowByTitle(title, secondsToRetry).As<TWindow>();
		}

		/// <summary>
		/// Finds the window by automationId.
		/// </summary>
		/// <param name="automationId">The automationId.</param>
		/// <param name="secondsToRetry">The seconds to retry.</param>
		/// <returns>First window or child window with the specified automationId</returns>
		public TWindow FindWindowByAutomationId<TWindow>(string automationId, int secondsToRetry = 0)
			where TWindow: Window, new()
		{
			return this.Element.FindWindowByAutomationId(automationId, secondsToRetry).As<TWindow>();
		}
	}
}
