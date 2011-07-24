using System;
using System.Diagnostics;
using WATKit.Controls;

namespace WATKit
{
	/// <summary>
	/// Represents the application being tested via automation
	/// </summary>
	/// <typeparam name="TMainWindow">The type of the main window.</typeparam>
	public sealed class ApplicationUnderTest<TMainWindow>
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
		public TMainWindow MainWindow { get; internal set; }

		/// <summary>
		/// Gets or sets the native handle of the main window.
		/// </summary>
		/// <value>
		/// The native handle of the main window as indicated by the process.
		/// </value>
		public int MainWindowHandle { get; internal set; }

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
		/// <param name="forceShutdown">if set to <c>true</c> kill the process if graceful shut down does not succeed.</param>
		/// <returns>
		/// <c>true</c> if the process is successfully shut down, otherwise <c>false</c>
		/// </returns>
		public bool ShutDown(bool forceShutdown = false)
		{
			var process = Process.GetProcessById(this.ProcessId);

			// CloseMainWindow doesn't work until the MainWindowHandle is available
			process.WaitForMainWindowHandle();

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
	}
}
