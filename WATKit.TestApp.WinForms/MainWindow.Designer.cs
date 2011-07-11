using System.Windows.Forms;

namespace WATKit.TestAppWinForms
{
	partial class MainWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonWithName = new System.Windows.Forms.Button();
			this.ButtonWithAutomationId = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ButtonWithName
			// 
			this.ButtonWithName.Location = new System.Drawing.Point(12, 12);
			this.ButtonWithName.Name = "ButtonWithName";
			this.ButtonWithName.Size = new System.Drawing.Size(435, 23);
			this.ButtonWithName.TabIndex = 0;
			this.ButtonWithName.Text = "Button With Name";
			this.ButtonWithName.UseVisualStyleBackColor = true;
			// 
			// ButtonWithAutomationId
			// 
			this.ButtonWithAutomationId.Location = new System.Drawing.Point(12, 41);
			this.ButtonWithAutomationId.Name = "ButtonWithAutomationId";
			this.ButtonWithAutomationId.Size = new System.Drawing.Size(435, 23);
			this.ButtonWithAutomationId.TabIndex = 1;
			this.ButtonWithAutomationId.Text = "Button With Automation Id";
			this.ButtonWithAutomationId.UseVisualStyleBackColor = true;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 381);
			this.Controls.Add(this.ButtonWithAutomationId);
			this.Controls.Add(this.ButtonWithName);
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "WATKit Test Application";
			this.ResumeLayout(false);

		}

		#endregion

		private Button ButtonWithName;
		private Button ButtonWithAutomationId;
	}
}

