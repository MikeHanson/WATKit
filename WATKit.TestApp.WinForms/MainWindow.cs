using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WATKit.TestApp
{
	public partial class MainWindow: Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnEnableDisabledButtonClick(object sender, EventArgs e)
		{
			Thread.Sleep(2); // simulate some processing
			this.DisabledButton.Enabled = true;
		}

		private void OnIChangeMyNameButtonClick(object sender, EventArgs e)
		{
			this.IChangeMyNameButton.Text = "My Name Has Changed";
			Thread.Sleep(1); // give the change time to register

			//TODO: probably need a wait on property value change
		}

		private void ShowInvisibleButton_Click(object sender, EventArgs e)
		{
			Thread.Sleep(2); // simulate some processing
			this.InvisibleButton.Visible = true;
		}

		private void AddDynamicButton_Click(object sender, EventArgs e)
		{
			Thread.Sleep(2); // simulate some processing
			this.Controls.Add(new Button 
			{
				Name = "DynamicButton",
				Text = "Dynamic Button",
				Width = this.DisabledButton.Width
			});
		}

		private void OpenChildWindowButton_Click(object sender, EventArgs e)
		{
			new ChildWindow().ShowDialog(this);
		}
	}
}
