using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace WATKit
{
	/// <summary>
	/// Provides extension methods for the Process type
	/// </summary>
	public static class ProcessExtensions
	{
		/// <summary>
		/// Waits for main window handle.
		/// </summary>
		/// <param name="process">The process.</param>
		public static void WaitForMainWindowHandle(this Process process)
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
