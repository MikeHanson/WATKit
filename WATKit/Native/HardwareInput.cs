using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WATKit.Native
{
	/// <summary>
	/// Win32 HardwareInput structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HardwareInput
	{
		private int Message;
		private short ParamLow;
		private short ParamHigh;
	}
}

