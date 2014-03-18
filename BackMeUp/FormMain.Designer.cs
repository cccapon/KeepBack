namespace BackMeUp
{
	partial class FormMain
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
			this.labelArchive = new System.Windows.Forms.Label();
			this.buttonBackup = new System.Windows.Forms.Button();
			this.labelCurrentPath = new System.Windows.Forms.Label();
			this.labelCurrent = new System.Windows.Forms.Label();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.labelFolder = new System.Windows.Forms.Label();
			this.labelFolderName = new System.Windows.Forms.Label();
			this.labelFolderPath = new System.Windows.Forms.Label();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.labelArchivePath = new System.Windows.Forms.Label();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelArchive
			// 
			this.labelArchive.AutoSize = true;
			this.labelArchive.Location = new System.Drawing.Point(12, 44);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(55, 17);
			this.labelArchive.TabIndex = 2;
			this.labelArchive.Text = "Archive";
			// 
			// buttonBackup
			// 
			this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBackup.Enabled = false;
			this.buttonBackup.Location = new System.Drawing.Point(820, 92);
			this.buttonBackup.Name = "buttonBackup";
			this.buttonBackup.Size = new System.Drawing.Size(152, 29);
			this.buttonBackup.TabIndex = 3;
			this.buttonBackup.Text = "Backup";
			this.buttonBackup.UseVisualStyleBackColor = true;
			this.buttonBackup.Click += new System.EventHandler(this.buttonExecute_Click);
			// 
			// labelCurrentPath
			// 
			this.labelCurrentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentPath.BackColor = System.Drawing.SystemColors.Info;
			this.labelCurrentPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCurrentPath.Location = new System.Drawing.Point(12, 212);
			this.labelCurrentPath.Name = "labelCurrentPath";
			this.labelCurrentPath.Size = new System.Drawing.Size(960, 23);
			this.labelCurrentPath.TabIndex = 4;
			this.labelCurrentPath.Visible = false;
			// 
			// labelCurrent
			// 
			this.labelCurrent.AutoSize = true;
			this.labelCurrent.Location = new System.Drawing.Point(12, 195);
			this.labelCurrent.Name = "labelCurrent";
			this.labelCurrent.Size = new System.Drawing.Size(55, 17);
			this.labelCurrent.TabIndex = 5;
			this.labelCurrent.Text = "Current";
			this.labelCurrent.Visible = false;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(984, 28);
			this.menuStripMain.TabIndex = 6;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// labelFolder
			// 
			this.labelFolder.AutoSize = true;
			this.labelFolder.Location = new System.Drawing.Point(12, 141);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(48, 17);
			this.labelFolder.TabIndex = 8;
			this.labelFolder.Text = "Folder";
			this.labelFolder.Visible = false;
			// 
			// labelFolderName
			// 
			this.labelFolderName.BackColor = System.Drawing.SystemColors.Info;
			this.labelFolderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelFolderName.Location = new System.Drawing.Point(12, 158);
			this.labelFolderName.Name = "labelFolderName";
			this.labelFolderName.Size = new System.Drawing.Size(181, 23);
			this.labelFolderName.TabIndex = 7;
			this.labelFolderName.Visible = false;
			// 
			// labelFolderPath
			// 
			this.labelFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFolderPath.BackColor = System.Drawing.SystemColors.Info;
			this.labelFolderPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelFolderPath.Location = new System.Drawing.Point(199, 158);
			this.labelFolderPath.Name = "labelFolderPath";
			this.labelFolderPath.Size = new System.Drawing.Size(773, 23);
			this.labelFolderPath.TabIndex = 9;
			this.labelFolderPath.Visible = false;
			// 
			// buttonEdit
			// 
			this.buttonEdit.Enabled = false;
			this.buttonEdit.Location = new System.Drawing.Point(12, 92);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(152, 29);
			this.buttonEdit.TabIndex = 10;
			this.buttonEdit.Text = "Edit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			// 
			// labelArchivePath
			// 
			this.labelArchivePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelArchivePath.BackColor = System.Drawing.SystemColors.Info;
			this.labelArchivePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelArchivePath.Location = new System.Drawing.Point(12, 61);
			this.labelArchivePath.Name = "labelArchivePath";
			this.labelArchivePath.Size = new System.Drawing.Size(960, 23);
			this.labelArchivePath.TabIndex = 11;
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(984, 259);
			this.Controls.Add(this.labelArchivePath);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.labelFolderPath);
			this.Controls.Add(this.labelFolder);
			this.Controls.Add(this.labelFolderName);
			this.Controls.Add(this.labelCurrent);
			this.Controls.Add(this.labelCurrentPath);
			this.Controls.Add(this.buttonBackup);
			this.Controls.Add(this.labelArchive);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "FormMain";
			this.Text = "Back Me Up";
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.Label labelCurrentPath;
		private System.Windows.Forms.Label labelCurrent;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.Label labelFolderName;
		private System.Windows.Forms.Label labelFolderPath;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Label labelArchivePath;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
	}
}

