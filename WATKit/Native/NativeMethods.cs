using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;

namespace WATKit.Native
{

    /// <summary>
	/// Declares native Win32 API methods
	/// </summary>
	public class NativeMethods
	{
		[DllImport("user32", EntryPoint = "SendInput")]
		private static extern int SendInput(int numberOfInputs, ref Input input, int sizeOfInput);

		[DllImport("user32.dll")]
		private static extern IntPtr GetMessageExtraInfo();

		[DllImport("user32.dll")]
		private static extern bool GetCursorPos(ref Point cursorInfo);

		[DllImport("user32.dll")]
		private static extern bool SetCursorPos(Point cursorInfo);

		[DllImport("user32.dll")]
		private static extern bool GetCursorInfo(ref CursorInfo cursorInfo);

		[DllImport("user32.dll")]
		private static extern short GetDoubleClickTime();
	}
}
