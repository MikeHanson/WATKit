using System;

namespace WATKit
{
	/// <summary>
	/// Types of wait operation supported
	/// </summary>
	public enum WaitType
	{
		NotSet = 0,
		Exists,
		NotExists,
		Visible,
		Hidden,
		Enabled,
		Disabled
	}
}
