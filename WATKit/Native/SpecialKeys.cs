using System;
using System.Collections.Generic;
using System.Linq;

namespace WATKit.Native
{
	public enum SpecialKeys
	{
		//http://pinvoke.net/default.aspx/user32/SendInput.html, http://delphi.about.com/od/objectpascalide/l/blvkc.htm
		SHIFT = 0x10,
		CONTROL = 0x11,
		ALT = 0x12,
		LEFT_ALT = 0xA4,
		RIGHT_ALT = 0xA5,
		RETURN = 0x0D,
		RIGHT = 0x27,
		BACKSPACE = 0x08,
		LEFT = 0x25,
		ESCAPE = 0x1B,
		TAB = 0x09,
		HOME = 0x24,
		END = 0x23,
		UP = 0x26,
		DOWN = 0x28,
		INSERT = 0x2D,
		DELETE = 0x2E,
		CAPS = 0x14,
		F1 = 0x70,
		F2 = 0x71,
		F3 = 0x72,
		F4 = 0x73,
		F5 = 0x74,
		F6 = 0x75,
		F7 = 0x76,
		F8 = 0x77,
		F9 = 0x78,
		F10 = 0x79,
		F11 = 0x7A,
		F12 = 0x7B,
		F13 = 0x7C,
		F14 = 0x7D,
		F15 = 0x7E,
		F16 = 0x7F,
		F17 = 0x80,
		F18 = 0x81,
		F19 = 0x82,
		F20 = 0x83,
		F21 = 0x84,
		F22 = 0x85,
		F23 = 0x86,
		F24 = 0x87,
		PAGEUP = 0x21,
		PAGEDOWN = 0x22,
		PRINT = 0x2A,
		PRINTSCREEN = 0x2C,
		SPACE = 0x20,
		NUMLOCK = 0x90,
		SCROLL = 0x91,
		LWIN = 0x5B,
		RWIN = 0x5C,
	}
}

