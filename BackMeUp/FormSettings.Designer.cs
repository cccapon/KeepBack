namespace BackMeUp
{
	partial class FormSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelRsyncExePath = new System.Windows.Forms.Label();
			this.buttonRsyncExePath = new System.Windows.Forms.Button();
			this.textBoxRsyncExePath = new System.Windows.Forms.TextBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.labelCygdrivePrefix = new System.Windows.Forms.Label();
			this.textBoxCygdrivePath = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// labelRsyncExePath
			// 
			this.labelRsyncExePath.AutoSize = true;
			this.labelRsyncExePath.Location = new System.Drawing.Point(12, 9);
			this.labelRsyncExePath.Name = "labelRsyncExePath";
			this.labelRsyncExePath.Size = new System.Drawing.Size(142, 17);
			this.labelRsyncExePath.TabIndex = 5;
			this.labelRsyncExePath.Text = "Location of rsync.exe";
			// 
			// buttonRsyncExePath
			// 
			this.buttonRsyncExePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRsyncExePath.Image = global::BackMeUp.Properties.Resources.FolderOpen;
			this.buttonRsyncExePath.Location = new System.Drawing.Point(590, 28);
			this.buttonRsyncExePath.Name = "buttonRsyncExePath";
			this.buttonRsyncExePath.Size = new System.Drawing.Size(29, 23);
			this.buttonRsyncExePath.TabIndex = 4;
			this.buttonRsyncExePath.UseVisualStyleBackColor = true;
			this.buttonRsyncExePath.Click += new System.EventHandler(this.buttonRsyncExePath_Click);
			// 
			// textBoxRsyncExePath
			// 
			this.textBoxRsyncExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxRsyncExePath.Location = new System.Drawing.Point(12, 29);
			this.textBoxRsyncExePath.Name = "textBoxRsyncExePath";
			this.textBoxRsyncExePath.Size = new System.Drawing.Size(572, 22);
			this.textBoxRsyncExePath.TabIndex = 3;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(544, 132);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 31);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOk
			// 
			this.buttonOk.Location = new System.Drawing.Point(463, 132);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(75, 31);
			this.buttonOk.TabIndex = 7;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			// 
			// labelCygdrivePrefix
			// 
			this.labelCygdrivePrefix.AutoSize = true;
			this.labelCygdrivePrefix.Location = new System.Drawing.Point(12, 66);
			this.labelCygdrivePrefix.Name = "labelCygdrivePrefix";
			this.labelCygdrivePrefix.Size = new System.Drawing.Size(316, 17);
			this.labelCygdrivePrefix.TabIndex = 9;
			this.labelCygdrivePrefix.Text = "Cygwin (Win32) cygdrive path - default: /cygdrive";
			// 
			// textBoxCygdrivePath
			// 
			this.textBoxCygdrivePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxCygdrivePath.Location = new System.Drawing.Point(12, 86);
			this.textBoxCygdrivePath.Name = "textBoxCygdrivePath";
			this.textBoxCygdrivePath.Size = new System.Drawing.Size(572, 22);
			this.textBoxCygdrivePath.TabIndex = 8;
			// 
			// FormSettings
			// 
			this.AcceptButton = this.buttonOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(631, 178);
			this.Controls.Add(this.labelCygdrivePrefix);
			this.Controls.Add(this.textBoxCygdrivePath);
			this.Controls.Add(this.buttonOk);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.labelRsyncExePath);
			this.Controls.Add(this.buttonRsyncExePath);
			this.Controls.Add(this.textBoxRsyncExePath);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSettings";
			this.Text = "Back Me Up - Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelRsyncExePath;
		private System.Windows.Forms.Button buttonRsyncExePath;
		private System.Windows.Forms.TextBox textBoxRsyncExePath;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.Label labelCygdrivePrefix;
		private System.Windows.Forms.TextBox textBoxCygdrivePath;

	}
}