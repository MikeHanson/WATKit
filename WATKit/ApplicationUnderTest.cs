using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using WATKit.Controls;

namespace WATKit
{
	/// <summary>
	/// Represents the application being tested via automation
	/// </summary>
	public sealed class ApplicationUnderTest
	{
		/// <summary>
		/// Gets the desktop.
		/// </summary>
		public Desktop Desktop { get; internal set; }

		/// <summary>
		/// Gets or sets the main window.
		/// </summary>
		/// <value>
		/// The main window.
		/// </value>
		public Window MainWindow { get; internal set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; internal set; }

		/// <summary>
		/// Gets or sets the process id.
		/// </summary>
		/// <value>
		/// The process id.
		/// </value>
		public int ProcessId { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the running state is active.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the running state is active; otherwise, <c>false</c>.
		/// </value>
		public bool IsRunning { get; internal set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUnderTest"/> class.
		/// </summary>
		internal ApplicationUnderTest(){}

		/// <summary>
		/// Shuts down application under test.
		/// </summary>
		/// <param name="forceShutdown">if set to <c>true</c> kill the process if graceful shutdown does not succeed.</param>
		/// <returns>
		/// <c>true</c> if the process is succesfully shutdown, otherwise <c>false</c>
		/// </returns>
		public bool ShutDown(bool forceShutdown = false)
		{
			var process = Process.GetProcessById(this.ProcessId);

			// CloseMainWindow doesn't work until the MainWindowHandle is available
			WaitForMainWindowHandle(process);

			var success = process.CloseMainWindow();
			if(success)
			{
				process.Close();
				this.IsRunning = false;
			}
			else if(forceShutdown)
			{
				process.Kill();
				this.IsRunning = false;
			}

			return !this.IsRunning;
		}

		/// <summary>
		/// Launches the application under test.
		/// </summary>
		/// <param name="applicationPath">The application path.</param>
		/// <param name="waitUntilFullyLoaded">if set to <c>true</c> [wait until fully loaded].</param>
		/// <returns>
		///   <see cref="WATKit.ApplicationUnderTest"/> instance with  the target application
		/// </returns>
		public static ApplicationUnderTest Launch(string applicationPath, bool waitUntilFullyLoaded = false)
		{
			if(String.IsNullOrEmpty(applicationPath) || !File.Exists(applicationPath))
			{
				throw new ArgumentException("The path is either missing or invalid", "applicationPath");
			}

			var process = Process.Start(new ProcessStartInfo(applicationPath));
			if(waitUntilFullyLoaded)
			{
				WaitForMainWindowHandle(process);
			}

			var window = AutomationElement
				.RootElement
				.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, process.MainWindowTitle))
				.As<Window>();

			return new ApplicationUnderTest
			{
				Desktop = new Desktop(),
				MainWindow = window,
				Name = process.MainWindowTitle,
				ProcessId = process.Id,
				IsRunning = true
			};
		}

		/// <summary>
		/// Waits for main window handle.
		/// </summary>
		/// <param name="process">The process.</param>
		private static void WaitForMainWindowHandle(Process process)
		{
			var handle = IntPtr.Zero;
			SpinWait.SpinUntil(() =>
			{
				handle = process.MainWindowHandle;
				return handle != IntPtr.Zero;
			});
		}
	}
}
