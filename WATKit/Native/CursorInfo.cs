using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace WATKit.Native
{
	/// <summary>
	/// Details of a windows cursor
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct CursorInfo
	{
		public uint size;
		public uint flags;
		public IntPtr handle;
		public Point point;

		/// <summary>
		/// Creates a new instance of CursorInfo.
		/// </summary>
		/// <returns>New instance of CursorInfo</returns>
		public static CursorInfo New()
		{
			var info = new CursorInfo
			           	{
			           		size = (uint)Marshal.SizeOf(typeof(CursorInfo))
			           	};
			return info;
		}
	}
}
