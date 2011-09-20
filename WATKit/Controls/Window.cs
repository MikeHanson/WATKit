using System;
using System.Windows.Automation;
using WATKit.Build;

namespace WATKit.Controls
{
	/// <summary>
	/// Wraps a Window for automation
	/// </summary>
	public class Window : AutomationControl
	{
		private WindowPattern windowPattern = null;

		/// <summary>
		/// Gets the window pattern for the underlying automation element
		/// </summary>
		private WindowPattern WindowPattern { get { return windowPattern ?? (windowPattern = this.AutomationElement.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern); } }

		/// <summary>
		/// Gets a value indicating whether the window is modal.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the window is modal; otherwise, <c>false</c>.
		/// </value>
		[Ignore]
		public bool IsModal { get { return this.WindowPattern.Current.IsModal; } }

		/// <summary>
		/// Gets a value indicating whether the window is available for interaction.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the window is available for interaction; otherwise, <c>false</c>.
		/// </value>
		[Ignore]
		public bool IsAvailable { get { return this.WindowPattern.Current.WindowInteractionState == WindowInteractionState.ReadyForUserInteraction; } }

		/// <summary>
		/// Attempts to closes this window
		/// </summary>
		public void Close()
		{
			this.WindowPattern.Close();
		}

		/// <summary>
		/// Gets or sets the type of the control.
		/// </summary>
		/// <value>
		/// The type of the control.
		/// </value>
		[Ignore]
		protected internal override ControlType ControlType { get { return ControlType.Window; } }
	}
}
