using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WATKit.Native
{
	/// <summary>
	/// Win32 INPUT structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Input
	{
		int Type;
		MouseInput MouseInput;
		KeyboardInput KeyboardInput;
		HardwareInput HardwareInput;
	}
}

