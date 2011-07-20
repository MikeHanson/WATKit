using System;

namespace WATKit.Tests
{
	internal class Utility
	{
		internal static readonly string ApplicationPath = @"C:\Users\Mike\Documents\Visual Studio 2010\Projects\WATKIt\WATKit.TestApp.WPF\bin\Debug\WATKit.TestApp.exe";
		internal static readonly string ApplicationPathWinForms = @"C:\Users\Mike\Documents\Visual Studio 2010\Projects\WATKit\WATKit.TestApp.WinForms\bin\Debug\WATKit.TestApp.exe";
		internal static readonly string ApplicationTitle = "WATKit Test Application";
		internal static readonly string ButtonWithName = "ButtonWithName";
		internal static readonly string ButtonWithNameContent = "Button With Name";
		internal static readonly string ButtonWithAutomationId = "ButtonWithAutomationId";
		internal static readonly string ButtonWithAutomationIdContent = "Button With Automation Id";
		internal static readonly string DisabledButtonId = "DisabledButton";
		internal static readonly string InvisibleButtonId = "InvisibleButton";
		internal static readonly string IChangeMyNameButtonId = "IChangeMyNameButton";
		internal static readonly string IChangeMyNameButtonNewName = "My Name Has Changed";
		internal static readonly string EnableDisabledButtonId = "EnableDisabledButton";
		internal static readonly string ShowInvisibleButtonId = "ShowInvisibleButton";

		/// <summary>
		/// Helper method to return the path of the application to test
		/// </summary>
		/// <returns>The path of the application all tests should be run against</returns>
		/// <remarks>
		/// The purpose of this method is so that you can change the application path in one
		/// place and have all tests run against that test application
		/// </remarks>
		internal static string GetApplicationPath()
		{
			return ApplicationPath;
		}
	}
}
