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
		/// Gets or sets the parent.
		/// </summary>
		/// <value>
		/// The parent.
		/// </value>
		internal AutomationControl Parent { get; set; }


		/// <summary>
		/// Gets or sets the type of find operation to be executed.
		/// </summary>
		/// <value>
		/// The type of find operation to be executed.
		/// </value>
		public FindType FindType{ get; set; }


		/// <summary>
		/// Gets or sets the identifier of the target of the find operation.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		public string Identifier{ get; set; }

		/// <summary>
		/// Gets or sets the scope of the find operation.
		/// </summary>
		/// <value>
		/// The find scope.
		/// </value>
		public FindScope FindScope{ get; set; }

		/// <summary>
		/// Gets or sets time to wait before executing the find.
		/// </summary>
		/// <value>
		/// The time to wait before executing the underlying find
		/// </value>
		public TimeSpan WaitTime{ get; set; }

		/// <summary>
		/// Gets or sets the time to retry find operations.
		/// </summary>
		/// <value>
		/// The time period to continue retrying the underlying find.
		/// </value>
		public TimeSpan RetryTime { get; set; }
	}
}