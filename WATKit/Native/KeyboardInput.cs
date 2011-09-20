using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WATKit.Native
{
	/// <summary>
	/// Win32 KEYBOARDINPUT structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct KeyboardInput
	{
		private readonly short VirtualKeyCode;
		private readonly short ScanCode;
		private readonly KeyboardInputFlags Flags;
		private readonly int TimeStamp;
		private readonly IntPtr ExtraInfo;

		public KeyboardInput(short virtualKey, KeyboardInputFlags flags, IntPtr extraInfo)
		{
			this.VirtualKeyCode = virtualKey;
			this.ScanCode = 0;
			this.Flags = flags;
			this.TimeStamp = 0;
			this.ExtraInfo = extraInfo;
		}
	}
}

