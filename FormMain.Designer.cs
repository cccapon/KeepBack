/*
    Copyright 2008,2009,2010,2011 Chris Capon.

    This file is part of KeepBack.

    KeepBack is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    KeepBack is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with KeepBack.  If not, see <http://www.gnu.org/licenses/>.

*/
namespace KeepBack
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
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
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
			this.buttonBackup = new System.Windows.Forms.Button();
			this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
			this.labelCurrentDirectory = new System.Windows.Forms.Label();
			this.labelCurrentFile = new System.Windows.Forms.Label();
			this.labelModified = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelCreated = new System.Windows.Forms.Label();
			this.labelDeleted = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelSkipped = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelStatus.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonBackup
			// 
			this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBackup.Location = new System.Drawing.Point(521, 28);
			this.buttonBackup.Name = "buttonBackup";
			this.buttonBackup.Size = new System.Drawing.Size(154, 23);
			this.buttonBackup.TabIndex = 12;
			this.buttonBackup.Text = "Begin Backup";
			this.buttonBackup.UseVisualStyleBackColor = true;
			this.buttonBackup.Click += new System.EventHandler(this.MenuBackup_Click);
			// 
			// richTextBoxInfo
			// 
			this.richTextBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxInfo.Location = new System.Drawing.Point(12, 218);
			this.richTextBoxInfo.Name = "richTextBoxInfo";
			this.richTextBoxInfo.ReadOnly = true;
			this.richTextBoxInfo.Size = new System.Drawing.Size(664, 236);
			this.richTextBoxInfo.TabIndex = 13;
			this.richTextBoxInfo.Text = "";
			this.richTextBoxInfo.WordWrap = false;
			// 
			// labelCurrentDirectory
			// 
			this.labelCurrentDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentDirectory.AutoEllipsis = true;
			this.labelCurrentDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCurrentDirectory.Location = new System.Drawing.Point(12, 58);
			this.labelCurrentDirectory.Name = "labelCurrentDirectory";
			this.labelCurrentDirectory.Size = new System.Drawing.Size(665, 23);
			this.labelCurrentDirectory.TabIndex = 1;
			this.labelCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCurrentFile
			// 
			this.labelCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentFile.AutoEllipsis = true;
			this.labelCurrentFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCurrentFile.Location = new System.Drawing.Point(12, 96);
			this.labelCurrentFile.Name = "labelCurrentFile";
			this.labelCurrentFile.Size = new System.Drawing.Size(665, 23);
			this.labelCurrentFile.TabIndex = 3;
			this.labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelModified
			// 
			this.labelModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelModified.Location = new System.Drawing.Point(131, 36);
			this.labelModified.Name = "labelModified";
			this.labelModified.Size = new System.Drawing.Size(64, 23);
			this.labelModified.TabIndex = 7;
			this.labelModified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Files";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(129, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Modified";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 45);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Currently scanning...";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 83);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(127, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Most recent changed file.";
			// 
			// labelCreated
			// 
			this.labelCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCreated.Location = new System.Drawing.Point(37, 36);
			this.labelCreated.Name = "labelCreated";
			this.labelCreated.Size = new System.Drawing.Size(64, 23);
			this.labelCreated.TabIndex = 5;
			this.labelCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelDeleted
			// 
			this.labelDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelDeleted.Location = new System.Drawing.Point(226, 36);
			this.labelDeleted.Name = "labelDeleted";
			this.labelDeleted.Size = new System.Drawing.Size(64, 23);
			this.labelDeleted.TabIndex = 11;
			this.labelDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(224, 23);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Deleted";
			// 
			// labelSkipped
			// 
			this.labelSkipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelSkipped.Location = new System.Drawing.Point(320, 36);
			this.labelSkipped.Name = "labelSkipped";
			this.labelSkipped.Size = new System.Drawing.Size(64, 23);
			this.labelSkipped.TabIndex = 3;
			this.labelSkipped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(318, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(46, 13);
			this.label11.TabIndex = 2;
			this.label11.Text = "Skipped";
			// 
			// panelStatus
			// 
			this.panelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelStatus.Controls.Add(this.label8);
			this.panelStatus.Controls.Add(this.label3);
			this.panelStatus.Controls.Add(this.label10);
			this.panelStatus.Controls.Add(this.label11);
			this.panelStatus.Controls.Add(this.labelSkipped);
			this.panelStatus.Controls.Add(this.labelDeleted);
			this.panelStatus.Controls.Add(this.labelCreated);
			this.panelStatus.Controls.Add(this.labelModified);
			this.panelStatus.Controls.Add(this.label2);
			this.panelStatus.Location = new System.Drawing.Point(131, 129);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(414, 82);
			this.panelStatus.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(34, 23);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Created";
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStripMain.Size = new System.Drawing.Size(692, 24);
			this.menuStripMain.TabIndex = 14;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuNew_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuOpen_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.MenuClose_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.backupToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Click);
			// 
			// exploreToolStripMenuItem
			// 
			this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
			this.exploreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.exploreToolStripMenuItem.Text = "E&xplore";
			this.exploreToolStripMenuItem.Click += new System.EventHandler(this.MenuExplore_Click);
			// 
			// mergeToolStripMenuItem
			// 
			this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
			this.mergeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.mergeToolStripMenuItem.Text = "&Merge";
			this.mergeToolStripMenuItem.Click += new System.EventHandler(this.MenuMerge_Click);
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.backupToolStripMenuItem.Text = "&Backup";
			this.backupToolStripMenuItem.Click += new System.EventHandler(this.MenuBackup_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus});
			this.statusStripMain.Location = new System.Drawing.Point(0, 456);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
			this.statusStripMain.Size = new System.Drawing.Size(692, 22);
			this.statusStripMain.TabIndex = 15;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// toolStripStatus
			// 
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new System.Drawing.Size(42, 17);
			this.toolStripStatus.Text = "Ready.";
			// 
			// FormMain
			// 
			this.AcceptButton = this.buttonBackup;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 478);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.panelStatus);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.labelCurrentFile);
			this.Controls.Add(this.labelCurrentDirectory);
			this.Controls.Add(this.richTextBoxInfo);
			this.Controls.Add(this.buttonBackup);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.MinimumSize = new System.Drawing.Size(699, 45);
			this.Name = "FormMain";
			this.Text = "Keep Back";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.panelStatus.ResumeLayout(false);
			this.panelStatus.PerformLayout();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.RichTextBox richTextBoxInfo;
		private System.Windows.Forms.Label labelCurrentDirectory;
		private System.Windows.Forms.Label labelCurrentFile;
		private System.Windows.Forms.Label labelModified;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelCreated;
		private System.Windows.Forms.Label labelDeleted;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label labelSkipped;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	}
}

