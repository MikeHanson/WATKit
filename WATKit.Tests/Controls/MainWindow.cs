using System;
using System.Collections.Generic;
using System.Linq;
using WATKit.Build;
using WATKit.Controls;

namespace WATKit.Tests.Controls
{
    /// <summary>
    /// Custom Window representing main window of application
    /// </summary>
	[AutomationTypeMapping("WATKit.TestApp.MainWindow")]
	public class MainWindow : Window
    {
        /// <summary>
        /// Gets the button that is identified by a name
        /// </summary>
        public Button ButtonWithName { get { return this.FindControl().IncludeDescendants().WithId(Utility.ButtonWithName).As<Button>(); } }

		/// <summary>
		/// Gets the button with an automation id.
		/// </summary>
		public Button ButtonWithAutomationId { get { return this.FindControl().IncludeDescendants().WithId(Utility.ButtonWithAutomationId).As<Button>(); } }

		/// <summary>
		/// Gets the invisible button.
		/// </summary>
		public Button InvisibleButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.InvisibleButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that will make the invisible button visible
		/// </summary>
		public Button ShowInvisibleButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.ShowInvisibleButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the disabled button.
		/// </summary>
		public Button DisabledButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.DisabledButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that will enable the disabled button.
		/// </summary>
		public Button EnableDisabledButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.EnableDisabledButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that changes it's text content
		/// </summary>
		public Button IChangeMyNameButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.IChangeMyNameButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button button added dynamically.
		/// </summary>
		public Button DynamicButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.DynamicButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that adds new button dynamically.
		/// </summary>
		public Button AddDynamicButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.AddDynamicButtonId).As<Button>(); } }
	}
}
