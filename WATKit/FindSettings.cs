using System;
using WATKit.Controls;

namespace WATKit
{
	/// <summary>
	/// Settings for the last or next find operation on an automation control
	/// </summary>
	public class FindSettings
	{
		/// <summary>
		/// Gets or sets the control that was the root of the find operation.
		/// </summary>
		/// <value>
		/// The control that represents the root of the find operation.
		/// </value>
		internal AutomationControl SearchRoot { get; set; }

		/// <summary>
		/// Gets or sets the type of find operation to be executed.
		/// </summary>
		/// <value>
		/// The type of find operation to be executed.
		/// </value>
		public FindType FindType{ get; internal set; }
		
		/// <summary>
		/// Gets or sets the identifier of the target of the find operation.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Identifier{ get; internal set; }

		/// <summary>
		/// Gets or sets the scope of the find operation.
		/// </summary>
		/// <value>
		/// The find scope.
		/// </value>
		public FindScope FindScope{ get; internal set; }

		/// <summary>
		/// Gets or sets time to wait before executing the find.
		/// </summary>
		/// <value>
		/// The time to wait before executing the underlying find
		/// </value>
		public TimeSpan WaitTime{ get; internal set; }

		/// <summary>
		/// Gets or sets the time to retry find operations.
		/// </summary>
		/// <value>
		/// The time period to continue retrying the underlying find.
		/// </value>
		public TimeSpan RetryTime { get; internal set; }

		/// <summary>
		/// Gets a value indicating whether the owning element is a proxy to a control that was not found.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if the control was not found on the last find operation and a proxy was returned instead; otherwise, <c>false</c>.
		/// </value>
		/// <remarks>
		/// In Winforms setting the Visible property of a control to false effectively hides it from automation components. WATKit returns
		/// a proxy if the target is not found so that you can wait for the element to become available or visible
		/// </remarks>
		public bool IsOwnerProxy { get; internal set; }
	}
}