using System;
using System.Collections.Generic;
using System.Linq;
using WATKit.Controls;

namespace WATKit.Tests.Controls
{
    /// <summary>
    /// Custom Window representing main window of application
    /// </summary>
    internal class MainWindow : Window
    {
        /// <summary>
        /// Gets the button that is identified by a name
        /// </summary>
        internal Button ButtonWithName { get { return this.FindControl().IncludeDescendants().WithId(Utility.ButtonWithName).As<Button>(); } }

		/// <summary>
		/// Gets the button with an automation id.
		/// </summary>
		internal Button ButtonWithAutomationId { get { return this.FindControl().IncludeDescendants().WithId(Utility.ButtonWithAutomationId).As<Button>(); } }

		/// <summary>
		/// Gets the invisible button.
		/// </summary>
		internal Button InvisibleButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.InvisibleButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that will make the invisible button visible
		/// </summary>
		internal Button ShowInvisibleButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.ShowInvisibleButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the disabled button.
		/// </summary>
		internal Button DisabledButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.DisabledButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that will enable the disabled button.
		/// </summary>
		internal Button EnableDisabledButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.EnableDisabledButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that changes it's text content
		/// </summary>
		internal Button IChangeMyNameButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.IChangeMyNameButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button button added dynamically.
		/// </summary>
		internal Button DynamicButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.DynamicButtonId).As<Button>(); } }

		/// <summary>
		/// Gets the button that adds new button dynamically.
		/// </summary>
		internal Button AddDynamicButton { get { return this.FindControl().IncludeDescendants().WithId(Utility.AddDynamicButtonId).As<Button>(); } }
	}
}
