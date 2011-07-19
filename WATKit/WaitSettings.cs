using System;
using WATKit.Controls;

namespace WATKit
{
	/// <summary>
	/// Settings for the last or next wait operation on an automation control
	/// </summary>
	public class WaitSettings
	{
		/// <summary>
		/// Gets or sets the control that was the root of the wait operation.
		/// </summary>
		/// <value>
		/// The control that represents the root of the wait operation.
		/// </value>
		internal AutomationControl WaitRoot { get; set; }

		/// <summary>
		/// Gets or sets the type of wait operation to be executed.
		/// </summary>
		/// <value>
		/// The type of wait operation to be executed.
		/// </value>
		public WaitType WaitType{ get; internal set; }
		
		/// <summary>
		/// Gets or sets time to wait before executing the find.
		/// </summary>
		/// <value>
		/// The time to wait before executing the underlying find
		/// </value>
		public TimeSpan WaitTime{ get; internal set; }

		/// <summary>
		/// Gets or sets a value indicating whether the wait operation is running.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the operation is running; otherwise, <c>false</c>.
		/// </value>
		public bool IsWaiting { get; set; }
		
		/// <summary>
		/// Gets the actual time out to be used in executing wait operations
		/// </summary>
		internal int ActualTimeOut { get { return WaitTime == TimeSpan.Zero ? -1 : (int)WaitTime.TotalSeconds * 1000; } }
	}
}