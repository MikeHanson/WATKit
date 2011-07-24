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
			this.InvisibleButton = new System.Windows.Forms.Button();
			this.DisabledButton = new System.Windows.Forms.Button();
			this.EnableDisabledButton = new System.Windows.Forms.Button();
			this.IChangeMyNameButton = new System.Windows.Forms.Button();
			this.ShowInvisibleButton = new System.Windows.Forms.Button();
			this.AddDynamicButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ButtonWithName
			// 
			this.ButtonWithName.Location = new System.Drawing.Point(12, 12);
			this.ButtonWithName.Name = "ButtonWithName";
			this.ButtonWithName.Size = new System.Drawing.Size(132, 23);
			this.ButtonWithName.TabIndex = 0;
			this.ButtonWithName.Text = "Button With Name";
			this.ButtonWithName.UseVisualStyleBackColor = true;
			// 
			// ButtonWithAutomationId
			// 
			this.ButtonWithAutomationId.Location = new System.Drawing.Point(12, 36);
			this.ButtonWithAutomationId.Name = "ButtonWithAutomationId";
			this.ButtonWithAutomationId.Size = new System.Drawing.Size(132, 23);
			this.ButtonWithAutomationId.TabIndex = 1;
			this.ButtonWithAutomationId.Text = "Button With Automation Id";
			this.ButtonWithAutomationId.UseVisualStyleBackColor = true;
			// 
			// InvisibleButton
			// 
			this.InvisibleButton.Location = new System.Drawing.Point(12, 60);
			this.InvisibleButton.Name = "InvisibleButton";
			this.InvisibleButton.Size = new System.Drawing.Size(132, 23);
			this.InvisibleButton.TabIndex = 2;
			this.InvisibleButton.Text = "Invisible Button";
			this.InvisibleButton.UseVisualStyleBackColor = true;
			this.InvisibleButton.Visible = false;
			// 
			// DisabledButton
			// 
			this.DisabledButton.Enabled = false;
			this.DisabledButton.Location = new System.Drawing.Point(12, 108);
			this.DisabledButton.Name = "DisabledButton";
			this.DisabledButton.Size = new System.Drawing.Size(132, 23);
			this.DisabledButton.TabIndex = 3;
			this.DisabledButton.Text = "Disabled Button";
			this.DisabledButton.UseVisualStyleBackColor = true;
			// 
			// EnableDisabledButton
			// 
			this.EnableDisabledButton.Location = new System.Drawing.Point(12, 132);
			this.EnableDisabledButton.Name = "EnableDisabledButton";
			this.EnableDisabledButton.Size = new System.Drawing.Size(132, 23);
			this.EnableDisabledButton.TabIndex = 4;
			this.EnableDisabledButton.Text = "Enable Disabled Button";
			this.EnableDisabledButton.UseVisualStyleBackColor = true;
			this.EnableDisabledButton.Click += new System.EventHandler(this.OnEnableDisabledButtonClick);
			// 
			// IChangeMyNameButton
			// 
			this.IChangeMyNameButton.Location = new System.Drawing.Point(12, 156);
			this.IChangeMyNameButton.Name = "IChangeMyNameButton";
			this.IChangeMyNameButton.Size = new System.Drawing.Size(132, 23);
			this.IChangeMyNameButton.TabIndex = 5;
			this.IChangeMyNameButton.Text = "I Change My Name Button";
			this.IChangeMyNameButton.UseVisualStyleBackColor = true;
			this.IChangeMyNameButton.Click += new System.EventHandler(this.OnIChangeMyNameButtonClick);
			// 
			// ShowInvisibleButton
			// 
			this.ShowInvisibleButton.Location = new System.Drawing.Point(12, 84);
			this.ShowInvisibleButton.Name = "ShowInvisibleButton";
			this.ShowInvisibleButton.Size = new System.Drawing.Size(132, 23);
			this.ShowInvisibleButton.TabIndex = 6;
			this.ShowInvisibleButton.Text = "Show Invisible Button";
			this.ShowInvisibleButton.UseVisualStyleBackColor = true;
			this.ShowInvisibleButton.Click += new System.EventHandler(this.ShowInvisibleButton_Click);
			// 
			// AddDynamicButton
			// 
			this.AddDynamicButton.Location = new System.Drawing.Point(12, 185);
			this.AddDynamicButton.Name = "AddDynamicButton";
			this.AddDynamicButton.Size = new System.Drawing.Size(132, 23);
			this.AddDynamicButton.TabIndex = 7;
			this.AddDynamicButton.Text = "Add Dynamic Button";
			this.AddDynamicButton.UseVisualStyleBackColor = true;
			this.AddDynamicButton.Click += new System.EventHandler(this.AddDynamicButton_Click);
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 381);
			this.Controls.Add(this.AddDynamicButton);
			this.Controls.Add(this.ShowInvisibleButton);
			this.Controls.Add(this.IChangeMyNameButton);
			this.Controls.Add(this.EnableDisabledButton);
			this.Controls.Add(this.DisabledButton);
			this.Controls.Add(this.InvisibleButton);
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
		private Button InvisibleButton;
		private Button DisabledButton;
		private Button EnableDisabledButton;
		private Button IChangeMyNameButton;
		private Button ShowInvisibleButton;
		private Button AddDynamicButton;
	}
}

