﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WATKit.TestAppWinForms
{
	public partial class MainWindow: Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		
		private void OnEnableDisabledButtonClick(object sender, EventArgs e)
		{
			Thread.Sleep(2);
			this.DisabledButton.Enabled = true;
		}

		private void OnIChangeMyNameButtonClick(object sender, EventArgs e)
		{
			this.IChangeMyNameButton.Text = "My Name Has Changed";
		}

		private void ShowInvisibleButton_Click(object sender, EventArgs e)
		{
			this.InvisibleButton.Visible = true;
		}
	}
}
