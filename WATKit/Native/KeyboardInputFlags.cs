using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit.Native
{
	[Flags]
	public enum KeyboardInputFlags
	{
		KeyDown = 0x0000,
		ExtendedKey = 0x0001,
		KeyUp = 0x0002,
		UnicodeKey = 0x0004,
		ScanCode = 0x0008
	}
}

