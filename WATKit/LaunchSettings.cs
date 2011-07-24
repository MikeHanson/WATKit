using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Windows.Automation;
using WATKit.Controls;
using System.Threading;

namespace WATKit
{
	/// <summary>
	/// Settings for launching the application under test
	/// </summary>
	public class LaunchSettings
	{
		/// <summary>
		/// Gets or sets the path of the application to launch
		/// </summary>
		/// <value>
		/// The application path.
		/// </value>
		public string ApplicationPath { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to wait for the window handle to be available.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the launch should not return until the handle of the main window is available; otherwise, <c>false</c>.
		/// </value>
		public bool WaitForWindowHandle { get; set; }

		/// <summary>
		/// Waits the until the main window is fully loaded.
		/// </summary>
		/// <returns>
		/// The original launch settings to support fluent usage
		/// </returns>
        public LaunchSettings WaitUntilMainWindowIsLoaded()
		{
			this.WaitForWindowHandle = true;
			return this;
		}

		/// <summary>
		/// Executes application launch with a strongly typed main window.
		/// </summary>
		/// <typeparam name="TMainWindow">The type of the main window.</typeparam>
		/// <returns>
		/// Application under test, ready for testing
		/// </returns>
		public ApplicationUnderTest<TMainWindow> WithMainWindowAs<TMainWindow>()
			where TMainWindow: Window, new()
		{
			if(String.IsNullOrEmpty(this.ApplicationPath) || !File.Exists(this.ApplicationPath))
			{
				throw new ArgumentException("The path is either missing or invalid", "applicationPath");
			}

			var process = Process.Start(new ProcessStartInfo(this.ApplicationPath));
			if(this.WaitForWindowHandle)
			{
				process.WaitForMainWindowHandle();
			}

			var window = AutomationElement
				.RootElement
				.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, process.MainWindowTitle))
				.As<TMainWindow>();

			return new ApplicationUnderTest<TMainWindow>
			{
				Desktop = new Desktop(),
				MainWindow = window,
				Name = process.MainWindowTitle,
				ProcessId = process.Id,
				IsRunning = true
			};
		}

		/// <summary>
		/// Executes application launch using the base window control for the main window
		/// </summary>
		/// <returns></returns>
		public ApplicationUnderTest<Window> WithDefaultMainWindow()
		{
			return WithMainWindowAs<Window>();
		}
	}
}
