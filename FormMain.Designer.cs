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
			this.labelTagModified = new System.Windows.Forms.Label();
			this.labelTagScan = new System.Windows.Forms.Label();
			this.labelTagUpdate = new System.Windows.Forms.Label();
			this.labelUpdateCreated = new System.Windows.Forms.Label();
			this.labelUpdateDeleted = new System.Windows.Forms.Label();
			this.labelTagDeleted = new System.Windows.Forms.Label();
			this.labelUpdateSkipped = new System.Windows.Forms.Label();
			this.labelTagSkipped = new System.Windows.Forms.Label();
			this.labelTagPending = new System.Windows.Forms.Label();
			this.labelUpdatePending = new System.Windows.Forms.Label();
			this.labelTagCreated = new System.Windows.Forms.Label();
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
			this.toolStripStatusLabelScanState = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelUpdateState = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabelLogs = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripElapsed = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelTagFolders = new System.Windows.Forms.Label();
			this.labelTagFiles = new System.Windows.Forms.Label();
			this.labelScanFolders = new System.Windows.Forms.Label();
			this.labelScanFiles = new System.Windows.Forms.Label();
			this.buttonMerge = new System.Windows.Forms.Button();
			this.timerRefresh = new System.Windows.Forms.Timer(this.components);
			this.labelTagArchive = new System.Windows.Forms.Label();
			this.labelArchive = new System.Windows.Forms.Label();
			this.panelUpdate = new System.Windows.Forms.Panel();
			this.panelScan = new System.Windows.Forms.Panel();
			this.pictureBoxUpdate = new System.Windows.Forms.PictureBox();
			this.pictureBoxScan = new System.Windows.Forms.PictureBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonPause = new System.Windows.Forms.Button();
			this.menuStripMain.SuspendLayout();
			this.statusStripMain.SuspendLayout();
			this.panelUpdate.SuspendLayout();
			this.panelScan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpdate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonBackup
			// 
			this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBackup.Location = new System.Drawing.Point(249, 25);
			this.buttonBackup.Name = "buttonBackup";
			this.buttonBackup.Size = new System.Drawing.Size(117, 23);
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
			this.richTextBoxInfo.BackColor = System.Drawing.SystemColors.Info;
			this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBoxInfo.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxInfo.Location = new System.Drawing.Point(10, 243);
			this.richTextBoxInfo.Name = "richTextBoxInfo";
			this.richTextBoxInfo.ReadOnly = true;
			this.richTextBoxInfo.Size = new System.Drawing.Size(602, 87);
			this.richTextBoxInfo.TabIndex = 13;
			this.richTextBoxInfo.TabStop = false;
			this.richTextBoxInfo.Text = "";
			this.richTextBoxInfo.WordWrap = false;
			// 
			// labelScanCurrent
			// 
			this.labelScanCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelScanCurrent.AutoEllipsis = true;
			this.labelScanCurrent.BackColor = System.Drawing.SystemColors.Info;
			this.labelScanCurrent.Location = new System.Drawing.Point(10, 131);
			this.labelScanCurrent.Name = "labelScanCurrent";
			this.labelScanCurrent.Size = new System.Drawing.Size(602, 20);
			this.labelScanCurrent.TabIndex = 1;
			this.labelScanCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelUpdateCurrent
			// 
			this.labelUpdateCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelUpdateCurrent.AutoEllipsis = true;
			this.labelUpdateCurrent.BackColor = System.Drawing.SystemColors.Info;
			this.labelUpdateCurrent.Location = new System.Drawing.Point(10, 212);
			this.labelUpdateCurrent.Name = "labelUpdateCurrent";
			this.labelUpdateCurrent.Size = new System.Drawing.Size(602, 20);
			this.labelUpdateCurrent.TabIndex = 3;
			this.labelUpdateCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelUpdateModified
			// 
			this.labelUpdateModified.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateModified.Location = new System.Drawing.Point(154, 18);
			this.labelUpdateModified.Name = "labelUpdateModified";
			this.labelUpdateModified.Size = new System.Drawing.Size(70, 19);
			this.labelUpdateModified.TabIndex = 7;
			this.labelUpdateModified.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTagModified
			// 
			this.labelTagModified.AutoSize = true;
			this.labelTagModified.Location = new System.Drawing.Point(166, 3);
			this.labelTagModified.Name = "labelTagModified";
			this.labelTagModified.Size = new System.Drawing.Size(47, 13);
			this.labelTagModified.TabIndex = 6;
			this.labelTagModified.Text = "Modified";
			// 
			// labelTagScan
			// 
			this.labelTagScan.AutoSize = true;
			this.labelTagScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTagScan.Location = new System.Drawing.Point(10, 100);
			this.labelTagScan.Name = "labelTagScan";
			this.labelTagScan.Size = new System.Drawing.Size(46, 20);
			this.labelTagScan.TabIndex = 0;
			this.labelTagScan.Text = "Scan";
			// 
			// labelTagUpdate
			// 
			this.labelTagUpdate.AutoSize = true;
			this.labelTagUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTagUpdate.Location = new System.Drawing.Point(10, 182);
			this.labelTagUpdate.Name = "labelTagUpdate";
			this.labelTagUpdate.Size = new System.Drawing.Size(62, 20);
			this.labelTagUpdate.TabIndex = 2;
			this.labelTagUpdate.Text = "Update";
			// 
			// labelUpdateCreated
			// 
			this.labelUpdateCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateCreated.Location = new System.Drawing.Point(82, 18);
			this.labelUpdateCreated.Name = "labelUpdateCreated";
			this.labelUpdateCreated.Size = new System.Drawing.Size(70, 19);
			this.labelUpdateCreated.TabIndex = 5;
			this.labelUpdateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelUpdateDeleted
			// 
			this.labelUpdateDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateDeleted.Location = new System.Drawing.Point(225, 18);
			this.labelUpdateDeleted.Name = "labelUpdateDeleted";
			this.labelUpdateDeleted.Size = new System.Drawing.Size(70, 19);
			this.labelUpdateDeleted.TabIndex = 11;
			this.labelUpdateDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTagDeleted
			// 
			this.labelTagDeleted.AutoSize = true;
			this.labelTagDeleted.Location = new System.Drawing.Point(238, 3);
			this.labelTagDeleted.Name = "labelTagDeleted";
			this.labelTagDeleted.Size = new System.Drawing.Size(44, 13);
			this.labelTagDeleted.TabIndex = 10;
			this.labelTagDeleted.Text = "Deleted";
			// 
			// labelUpdateSkipped
			// 
			this.labelUpdateSkipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdateSkipped.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdateSkipped.Location = new System.Drawing.Point(296, 18);
			this.labelUpdateSkipped.Name = "labelUpdateSkipped";
			this.labelUpdateSkipped.Size = new System.Drawing.Size(70, 19);
			this.labelUpdateSkipped.TabIndex = 3;
			this.labelUpdateSkipped.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTagSkipped
			// 
			this.labelTagSkipped.AutoSize = true;
			this.labelTagSkipped.Location = new System.Drawing.Point(309, 3);
			this.labelTagSkipped.Name = "labelTagSkipped";
			this.labelTagSkipped.Size = new System.Drawing.Size(46, 13);
			this.labelTagSkipped.TabIndex = 2;
			this.labelTagSkipped.Text = "Skipped";
			// 
			// labelTagPending
			// 
			this.labelTagPending.AutoSize = true;
			this.labelTagPending.Location = new System.Drawing.Point(13, 3);
			this.labelTagPending.Name = "labelTagPending";
			this.labelTagPending.Size = new System.Drawing.Size(46, 13);
			this.labelTagPending.TabIndex = 12;
			this.labelTagPending.Text = "Pending";
			// 
			// labelUpdatePending
			// 
			this.labelUpdatePending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelUpdatePending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelUpdatePending.Location = new System.Drawing.Point(1, 18);
			this.labelUpdatePending.Name = "labelUpdatePending";
			this.labelUpdatePending.Size = new System.Drawing.Size(70, 19);
			this.labelUpdatePending.TabIndex = 13;
			this.labelUpdatePending.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelTagCreated
			// 
			this.labelTagCreated.AutoSize = true;
			this.labelTagCreated.Location = new System.Drawing.Point(95, 3);
			this.labelTagCreated.Name = "labelTagCreated";
			this.labelTagCreated.Size = new System.Drawing.Size(44, 13);
			this.labelTagCreated.TabIndex = 4;
			this.labelTagCreated.Text = "Created";
			// 
			// menuStripMain
			// 
			this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStripMain.Size = new System.Drawing.Size(625, 24);
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
            this.logsToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.backupToolStripMenuItem,
            this.debugToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
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
			// logsToolStripMenuItem
			// 
			this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
			this.logsToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.logsToolStripMenuItem.Text = "&Logs";
			this.logsToolStripMenuItem.Click += new System.EventHandler(this.MenuLogs_Click);
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
			// debugToolStripMenuItem
			// 
			this.debugToolStripMenuItem.CheckOnClick = true;
			this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
			this.debugToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
			this.debugToolStripMenuItem.Text = "&Debug";
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
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuAbout_Click);
			// 
			// statusStripMain
			// 
			this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus,
            this.toolStripBlank,
            this.toolStripStatusLabelScanState,
            this.toolStripStatusLabelUpdateState,
            this.toolStripStatusLabelLogs,
            this.toolStripElapsed});
			this.statusStripMain.Location = new System.Drawing.Point(0, 328);
			this.statusStripMain.Name = "statusStripMain";
			this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
			this.statusStripMain.Size = new System.Drawing.Size(625, 25);
			this.statusStripMain.TabIndex = 15;
			this.statusStripMain.Text = "statusStrip1";
			// 
			// toolStripStatus
			// 
			this.toolStripStatus.Name = "toolStripStatus";
			this.toolStripStatus.Size = new System.Drawing.Size(42, 20);
			this.toolStripStatus.Text = "Ready.";
			this.toolStripStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripBlank
			// 
			this.toolStripBlank.AutoSize = false;
			this.toolStripBlank.Name = "toolStripBlank";
			this.toolStripBlank.Size = new System.Drawing.Size(144, 20);
			this.toolStripBlank.Spring = true;
			this.toolStripBlank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripStatusLabelScanState
			// 
			this.toolStripStatusLabelScanState.AutoSize = false;
			this.toolStripStatusLabelScanState.Name = "toolStripStatusLabelScanState";
			this.toolStripStatusLabelScanState.Size = new System.Drawing.Size(150, 20);
			this.toolStripStatusLabelScanState.Text = "Scan";
			// 
			// toolStripStatusLabelUpdateState
			// 
			this.toolStripStatusLabelUpdateState.AutoSize = false;
			this.toolStripStatusLabelUpdateState.Name = "toolStripStatusLabelUpdateState";
			this.toolStripStatusLabelUpdateState.Size = new System.Drawing.Size(150, 20);
			this.toolStripStatusLabelUpdateState.Text = "Update";
			// 
			// toolStripStatusLabelLogs
			// 
			this.toolStripStatusLabelLogs.AutoSize = false;
			this.toolStripStatusLabelLogs.Name = "toolStripStatusLabelLogs";
			this.toolStripStatusLabelLogs.Size = new System.Drawing.Size(85, 20);
			this.toolStripStatusLabelLogs.Text = "Logs";
			// 
			// toolStripElapsed
			// 
			this.toolStripElapsed.Name = "toolStripElapsed";
			this.toolStripElapsed.Size = new System.Drawing.Size(43, 15);
			this.toolStripElapsed.Text = "--:--:--";
			this.toolStripElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelTagFolders
			// 
			this.labelTagFolders.AutoSize = true;
			this.labelTagFolders.Location = new System.Drawing.Point(97, 3);
			this.labelTagFolders.Name = "labelTagFolders";
			this.labelTagFolders.Size = new System.Drawing.Size(41, 13);
			this.labelTagFolders.TabIndex = 4;
			this.labelTagFolders.Text = "Folders";
			// 
			// labelTagFiles
			// 
			this.labelTagFiles.AutoSize = true;
			this.labelTagFiles.Location = new System.Drawing.Point(175, 3);
			this.labelTagFiles.Name = "labelTagFiles";
			this.labelTagFiles.Size = new System.Drawing.Size(28, 13);
			this.labelTagFiles.TabIndex = 6;
			this.labelTagFiles.Text = "Files";
			// 
			// labelScanFolders
			// 
			this.labelScanFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScanFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScanFolders.Location = new System.Drawing.Point(82, 17);
			this.labelScanFolders.Name = "labelScanFolders";
			this.labelScanFolders.Size = new System.Drawing.Size(70, 19);
			this.labelScanFolders.TabIndex = 5;
			this.labelScanFolders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelScanFiles
			// 
			this.labelScanFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelScanFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelScanFiles.Location = new System.Drawing.Point(154, 17);
			this.labelScanFiles.Name = "labelScanFiles";
			this.labelScanFiles.Size = new System.Drawing.Size(70, 19);
			this.labelScanFiles.TabIndex = 7;
			this.labelScanFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonMerge
			// 
			this.buttonMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMerge.Location = new System.Drawing.Point(126, 25);
			this.buttonMerge.Name = "buttonMerge";
			this.buttonMerge.Size = new System.Drawing.Size(117, 23);
			this.buttonMerge.TabIndex = 17;
			this.buttonMerge.Text = "Merge History";
			this.buttonMerge.UseVisualStyleBackColor = true;
			this.buttonMerge.Click += new System.EventHandler(this.MenuMerge_Click);
			// 
			// timerRefresh
			// 
			this.timerRefresh.Interval = 1000;
			this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
			// 
			// labelTagArchive
			// 
			this.labelTagArchive.AutoSize = true;
			this.labelTagArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelTagArchive.Location = new System.Drawing.Point(10, 28);
			this.labelTagArchive.Name = "labelTagArchive";
			this.labelTagArchive.Size = new System.Drawing.Size(61, 20);
			this.labelTagArchive.TabIndex = 18;
			this.labelTagArchive.Text = "Archive";
			// 
			// labelArchive
			// 
			this.labelArchive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelArchive.AutoEllipsis = true;
			this.labelArchive.BackColor = System.Drawing.SystemColors.Info;
			this.labelArchive.Location = new System.Drawing.Point(10, 54);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(602, 20);
			this.labelArchive.TabIndex = 19;
			this.labelArchive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelUpdate
			// 
			this.panelUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelUpdate.Controls.Add(this.labelTagPending);
			this.panelUpdate.Controls.Add(this.labelUpdatePending);
			this.panelUpdate.Controls.Add(this.labelTagCreated);
			this.panelUpdate.Controls.Add(this.labelTagModified);
			this.panelUpdate.Controls.Add(this.labelTagDeleted);
			this.panelUpdate.Controls.Add(this.labelTagSkipped);
			this.panelUpdate.Controls.Add(this.labelUpdateSkipped);
			this.panelUpdate.Controls.Add(this.labelUpdateDeleted);
			this.panelUpdate.Controls.Add(this.labelUpdateCreated);
			this.panelUpdate.Controls.Add(this.labelUpdateModified);
			this.panelUpdate.Location = new System.Drawing.Point(169, 165);
			this.panelUpdate.Name = "panelUpdate";
			this.panelUpdate.Size = new System.Drawing.Size(366, 44);
			this.panelUpdate.TabIndex = 6;
			// 
			// panelScan
			// 
			this.panelScan.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelScan.Controls.Add(this.labelScanFolders);
			this.panelScan.Controls.Add(this.labelScanFiles);
			this.panelScan.Controls.Add(this.labelTagFolders);
			this.panelScan.Controls.Add(this.labelTagFiles);
			this.panelScan.Location = new System.Drawing.Point(169, 84);
			this.panelScan.Name = "panelScan";
			this.panelScan.Size = new System.Drawing.Size(366, 44);
			this.panelScan.TabIndex = 16;
			// 
			// pictureBoxUpdate
			// 
			this.pictureBoxUpdate.Image = global::KeepBack.Properties.Resources.Working;
			this.pictureBoxUpdate.Location = new System.Drawing.Point(71, 185);
			this.pictureBoxUpdate.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBoxUpdate.Name = "pictureBoxUpdate";
			this.pictureBoxUpdate.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxUpdate.TabIndex = 21;
			this.pictureBoxUpdate.TabStop = false;
			// 
			// pictureBoxScan
			// 
			this.pictureBoxScan.Image = global::KeepBack.Properties.Resources.Sleep;
			this.pictureBoxScan.Location = new System.Drawing.Point(74, 103);
			this.pictureBoxScan.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBoxScan.Name = "pictureBoxScan";
			this.pictureBoxScan.Size = new System.Drawing.Size(16, 16);
			this.pictureBoxScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxScan.TabIndex = 20;
			this.pictureBoxScan.TabStop = false;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(495, 25);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(117, 23);
			this.buttonCancel.TabIndex = 22;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonPause
			// 
			this.buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPause.Enabled = false;
			this.buttonPause.Location = new System.Drawing.Point(372, 25);
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new System.Drawing.Size(117, 23);
			this.buttonPause.TabIndex = 23;
			this.buttonPause.Text = "Pause";
			this.buttonPause.UseVisualStyleBackColor = true;
			this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(625, 353);
			this.Controls.Add(this.buttonPause);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.pictureBoxUpdate);
			this.Controls.Add(this.pictureBoxScan);
			this.Controls.Add(this.labelTagArchive);
			this.Controls.Add(this.labelArchive);
			this.Controls.Add(this.buttonMerge);
			this.Controls.Add(this.panelScan);
			this.Controls.Add(this.statusStripMain);
			this.Controls.Add(this.panelUpdate);
			this.Controls.Add(this.labelTagUpdate);
			this.Controls.Add(this.labelTagScan);
			this.Controls.Add(this.labelUpdateCurrent);
			this.Controls.Add(this.labelScanCurrent);
			this.Controls.Add(this.richTextBoxInfo);
			this.Controls.Add(this.buttonBackup);
			this.Controls.Add(this.menuStripMain);
			this.MainMenuStrip = this.menuStripMain;
			this.MinimumSize = new System.Drawing.Size(484, 45);
			this.Name = "FormMain";
			this.Text = "Keep Back";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.statusStripMain.ResumeLayout(false);
			this.statusStripMain.PerformLayout();
			this.panelUpdate.ResumeLayout(false);
			this.panelUpdate.PerformLayout();
			this.panelScan.ResumeLayout(false);
			this.panelScan.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxUpdate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxScan)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.RichTextBox richTextBoxInfo;
		private System.Windows.Forms.Label labelScanCurrent;
		private System.Windows.Forms.Label labelUpdateCurrent;
		private System.Windows.Forms.Label labelUpdateModified;
		private System.Windows.Forms.Label labelTagModified;
		private System.Windows.Forms.Label labelTagScan;
		private System.Windows.Forms.Label labelTagUpdate;
		private System.Windows.Forms.Label labelUpdateCreated;
		private System.Windows.Forms.Label labelUpdateDeleted;
		private System.Windows.Forms.Label labelTagDeleted;
		private System.Windows.Forms.Label labelUpdateSkipped;
		private System.Windows.Forms.Label labelTagSkipped;
		private System.Windows.Forms.Label labelTagCreated;
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
		private System.Windows.Forms.Label labelTagPending;
		private System.Windows.Forms.Label labelUpdatePending;
		private System.Windows.Forms.Label labelTagFolders;
		private System.Windows.Forms.Label labelTagFiles;
		private System.Windows.Forms.Label labelScanFolders;
		private System.Windows.Forms.Label labelScanFiles;
		private System.Windows.Forms.Button buttonMerge;
		private System.Windows.Forms.Timer timerRefresh;
		private System.Windows.Forms.Label labelTagArchive;
		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.ToolStripStatusLabel toolStripBlank;
		private System.Windows.Forms.ToolStripStatusLabel toolStripElapsed;
		private System.Windows.Forms.PictureBox pictureBoxScan;
		private System.Windows.Forms.PictureBox pictureBoxUpdate;
		private System.Windows.Forms.Panel panelUpdate;
		private System.Windows.Forms.Panel panelScan;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelScanState;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUpdateState;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLogs;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonPause;
	}
}

