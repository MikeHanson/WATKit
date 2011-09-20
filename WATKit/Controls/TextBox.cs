using System;

namespace WATKit.Controls
{
	/// <summary>
	/// Wraps textbox for automation
	/// </summary>
	public class TextBox : EditBoxBase
	{
		/// <summary>
		/// Gets the text.
		/// </summary>
		public string Text { get { return this.ValueProvider.Current.Value; } }
	}
}
