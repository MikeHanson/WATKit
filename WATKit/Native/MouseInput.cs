using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace WATKit.Native
{
	/// <summary>
	/// Win32 MOUSEINPUT structure
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct MouseInput
	{
		private readonly int X;
		private readonly int Y;
		private readonly int Data;
		private readonly int Flags;
		private readonly int TimeStamp;
		private readonly IntPtr ExtraInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseInput"/> struct.
		/// </summary>
		/// <param name="flags">The flags.</param>
		/// <param name="extraInfo">The extra info.</param>
		public MouseInput(int flags, IntPtr extraInfo)
		{
			this.Flags = flags;
			this.ExtraInfo = extraInfo;
			X = 0;
			Y = 0;
			TimeStamp = 0;
			Data = 0;
		}
	}
}

