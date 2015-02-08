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
			this.components = new System.ComponentModel.Container();
			this.buttonBackup = new System.Windows.Forms.Button();
			this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
			this.labelScanCurrent = new System.Windows.Forms.Label();
			this.labelUpdateCurrent = new System.Windows.Forms.Label();
			this.labelUpdateModified = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelUpdateCreated = new System.Windows.Forms.Label();
			this.labelUpdateDeleted = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelUpdateSkipped = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.label12 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelUpdatePending = new System.Windows.Forms.Label();
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
			this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStripMain = new System.Windows.Forms.StatusStrip();
			this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripBlank = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripElapsed = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelScanFolders = new System.Windows.Forms.Label();
			this.labelScanFiles = new System.Windows.Forms.Label();
			this.buttonTest = new System.Windows.Forms.Button();
			this.timerRefresh = new System.Windows.Forms.Timer(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.labelArchive = new System.Windows.Forms.Label();
			this.panelStatus.SuspendLayout();
			this.menuStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonBackup
			// 
			this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBackup.Location = new System.Drawing.Point(404, 32);
			this.buttonBackup.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBackup.Name = "buttonBackup";
			this.buttonBackup.Size = new System.Drawing.Size(205, 28);
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
			this.richTextBoxInfo.Location = new System.Drawing.Point(18, 299);
			this.richTextBoxInfo.Margin = new System.Windows.Forms.Padding(4);
			this.richTextBoxInfo.Name = "richTextBoxInfo";
			this.richTextBoxInfo.ReadOnly = true;
			this.richTextBoxInfo.Size = new System.Drawing.Size(593, 107);
			this.richTextBoxInfo.TabIndex = 13;
			this.richTextBoxInfo.Text = "";
			this.richTextBoxInfo.WordWrap = false;
			// 
			// labelScanCurrent
			// 
			this.labelScanCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelScanCurrent.AutoEllipsis = true;
			this.labelScanCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScanCurrent.Location = new System.Drawing.Point(17, 161);
			this.labelScanCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelScanCurrent.Name = "labelScanCurrent";
			this.labelScanCurrent.Size = new System.Drawing.Size(593, 25);
			this.labelScanCurrent.TabIndex = 1;
			this.labelScanCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelUpdateCurrent
			// 
			this.labelUpdateCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUpdateCurrent.AutoEllipsis = true;
			this.labelUpdateCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateCurrent.Location = new System.Drawing.Point(18, 261);
			this.labelUpdateCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdateCurrent.Name = "labelUpdateCurrent";
			this.labelUpdateCurrent.Size = new System.Drawing.Size(593, 25);
			this.labelUpdateCurrent.TabIndex = 3;
			this.labelUpdateCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelUpdateModified
			// 
			this.labelUpdateModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateModified.Location = new System.Drawing.Point(233, 22);
			this.labelUpdateModified.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdateModified.Name = "labelUpdateModified";
			this.labelUpdateModified.Size = new System.Drawing.Size(85, 28);
			this.labelUpdateModified.TabIndex = 7;
			this.labelUpdateModified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(230, 5);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Modified";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 130);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 17);
			this.label6.TabIndex = 0;
			this.label6.Text = "Scanning";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 225);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(54, 17);
			this.label7.TabIndex = 2;
			this.label7.Text = "Update";
			// 
			// labelUpdateCreated
			// 
			this.labelUpdateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateCreated.Location = new System.Drawing.Point(139, 22);
			this.labelUpdateCreated.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdateCreated.Name = "labelUpdateCreated";
			this.labelUpdateCreated.Size = new System.Drawing.Size(85, 28);
			this.labelUpdateCreated.TabIndex = 5;
			this.labelUpdateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelUpdateDeleted
			// 
			this.labelUpdateDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateDeleted.Location = new System.Drawing.Point(327, 22);
			this.labelUpdateDeleted.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdateDeleted.Name = "labelUpdateDeleted";
			this.labelUpdateDeleted.Size = new System.Drawing.Size(85, 28);
			this.labelUpdateDeleted.TabIndex = 11;
			this.labelUpdateDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(324, 5);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(57, 17);
			this.label10.TabIndex = 10;
			this.label10.Text = "Deleted";
			// 
			// labelUpdateSkipped
			// 
			this.labelUpdateSkipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateSkipped.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateSkipped.Location = new System.Drawing.Point(421, 22);
			this.labelUpdateSkipped.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdateSkipped.Name = "labelUpdateSkipped";
			this.labelUpdateSkipped.Size = new System.Drawing.Size(85, 28);
			this.labelUpdateSkipped.TabIndex = 3;
			this.labelUpdateSkipped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(418, 5);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 17);
			this.label11.TabIndex = 2;
			this.label11.Text = "Skipped";
			// 
			// panelStatus
			// 
			this.panelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelStatus.Controls.Add(this.label12);
			this.panelStatus.Controls.Add(this.label5);
			this.panelStatus.Controls.Add(this.labelUpdatePending);
			this.panelStatus.Controls.Add(this.label8);
			this.panelStatus.Controls.Add(this.label3);
			this.panelStatus.Controls.Add(this.label10);
			this.panelStatus.Controls.Add(this.label11);
			this.panelStatus.Controls.Add(this.labelUpdateSkipped);
			this.panelStatus.Controls.Add(this.labelUpdateDeleted);
			this.panelStatus.Controls.Add(this.labelUpdateCreated);
			this.panelStatus.Controls.Add(this.labelUpdateModified);
			this.panelStatus.Location = new System.Drawing.Point(76, 203);
			this.panelStatus.Margin = new System.Windows.Forms.Padding(4);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(513, 54);
			this.panelStatus.TabIndex = 6;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(98, 22);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(33, 17);
			this.label12.TabIndex = 14;
			this.label12.Text = ". . .";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(5, 5);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 17);
			this.label5.TabIndex = 12;
			this.label5.Text = "Pending";
			// 
			// labelUpdatePending
			// 
			this.labelUpdatePending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdatePending.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdatePending.Location = new System.Drawing.Point(8, 22);
			this.labelUpdatePending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelUpdatePending.Name = "labelUpdatePending";
			this.labelUpdatePending.Size = new System.Drawing.Size(85, 28);
			this.labelUpdatePending.TabIndex = 13;
			this.labelUpdatePending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(136, 5);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 17);
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
			this.menuStripMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
			this.menuStripMain.Size = new System.Drawing.Size(622, 28);
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
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.MenuNew_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.MenuOpen_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
			this.closeToolStripMenuItem.Text = "&Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.MenuClose_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.exploreToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.debugToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.MenuEdit_Click);
			// 
			// exploreToolStripMenuItem
			// 
			this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
			this.exploreToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.exploreToolStripMenuItem.Text = "E&xplore";
			this.exploreToolStripMenuItem.Click += new System.EventHandler(this.MenuExplore_Click);
			// 
			// logsToolStripMenuItem
			// 
			this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
			this.logsToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.logsToolStripMenuItem.Text = "&Logs";
			this.logsToolStripMenuItem.Click += new System.EventHandler(this.MenuLogs_Click);
			// 
			// mergeToolStripMenuItem
			// 
			this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
			this.mergeToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.mergeToolStripMenuItem.Text = "&Merge";
			this.mergeToolStripMenuItem.Click += new System.EventHandler(this.MenuMerge_Click);
			// 
			// backupToolStripMenuItem
			// 
			this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
			this.backupToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.backupToolStripMenuItem.Text = "&Backup";
			this.backupToolStripMenuItem.Click += new System.EventHandler(this.MenuBackup_Click);
			// 
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.CheckOnClick = true;
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
			this.debugToolStripMenuItem.Text = "&Debug";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuAbout_Click);
			// 
			// statusStripMain
			// 
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolStripBlank,
            this.toolStripElapsed});
			this.statusStripMain.Location = new System.Drawing.Point(0, 410);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
			this.statusStripMain.Size = new System.Drawing.Size(622, 25);
			this.statusStripMain.TabIndex = 15;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// toolStripStatus
			// 
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new System.Drawing.Size(53, 20);
			this.toolStripStatus.Text = "Ready.";
			this.toolStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripBlank
			// 
			this.toolStripBlank.AutoSize = false;
			this.toolStripBlank.Name = "toolStripBlank";
			this.toolStripBlank.Size = new System.Drawing.Size(504, 20);
			this.toolStripBlank.Spring = true;
			this.toolStripBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripElapsed
			// 
			this.toolStripElapsed.Name = "toolStripElapsed";
			this.toolStripElapsed.Size = new System.Drawing.Size(51, 20);
			this.toolStripElapsed.Text = "--:--:--";
			this.toolStripElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.labelScanFolders);
			this.panel1.Controls.Add(this.labelScanFiles);
			this.panel1.Location = new System.Drawing.Point(198, 103);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(226, 54);
			this.panel1.TabIndex = 16;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 17);
			this.label1.TabIndex = 4;
			this.label1.Text = "Folders";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(132, 5);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Files";
			// 
			// labelScanFolders
			// 
			this.labelScanFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScanFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScanFolders.Location = new System.Drawing.Point(9, 21);
			this.labelScanFolders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelScanFolders.Name = "labelScanFolders";
			this.labelScanFolders.Size = new System.Drawing.Size(85, 28);
			this.labelScanFolders.TabIndex = 5;
			this.labelScanFolders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelScanFiles
			// 
			this.labelScanFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScanFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScanFiles.Location = new System.Drawing.Point(135, 21);
			this.labelScanFiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelScanFiles.Name = "labelScanFiles";
			this.labelScanFiles.Size = new System.Drawing.Size(85, 28);
			this.labelScanFiles.TabIndex = 7;
			this.labelScanFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonTest
			// 
			this.buttonTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonTest.Location = new System.Drawing.Point(251, 32);
			this.buttonTest.Margin = new System.Windows.Forms.Padding(4);
			this.buttonTest.Name = "buttonTest";
			this.buttonTest.Size = new System.Drawing.Size(140, 28);
			this.buttonTest.TabIndex = 17;
			this.buttonTest.Text = "Test";
			this.buttonTest.UseVisualStyleBackColor = true;
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
			// 
			// timerRefresh
			// 
			this.timerRefresh.Interval = 1000;
			this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 51);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 17);
			this.label2.TabIndex = 18;
			this.label2.Text = "Archive";
			// 
			// labelArchive
			// 
			this.labelArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelArchive.AutoEllipsis = true;
			this.labelArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelArchive.Location = new System.Drawing.Point(16, 67);
			this.labelArchive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(593, 25);
			this.labelArchive.TabIndex = 19;
			this.labelArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(622, 435);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelArchive);
			this.Controls.Add(this.buttonTest);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.panelStatus);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.labelUpdateCurrent);
			this.Controls.Add(this.labelScanCurrent);
			this.Controls.Add(this.richTextBoxInfo);
			this.Controls.Add(this.buttonBackup);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(640, 45);
			this.Name = "FormMain";
			this.Text = "Keep Back";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.panelStatus.ResumeLayout(false);
			this.panelStatus.PerformLayout();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.RichTextBox richTextBoxInfo;
		private System.Windows.Forms.Label labelScanCurrent;
		private System.Windows.Forms.Label labelUpdateCurrent;
		private System.Windows.Forms.Label labelUpdateModified;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelUpdateCreated;
		private System.Windows.Forms.Label labelUpdateDeleted;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label labelUpdateSkipped;
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
		private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelUpdatePending;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelScanFolders;
		private System.Windows.Forms.Label labelScanFiles;
		private System.Windows.Forms.Button buttonTest;
		private System.Windows.Forms.Timer timerRefresh;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.ToolStripStatusLabel toolStripBlank;
		private System.Windows.Forms.ToolStripStatusLabel toolStripElapsed;
	}
}

