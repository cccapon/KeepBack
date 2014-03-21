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
	partial class FormEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
			this.treeViewControl = new System.Windows.Forms.TreeView();
			this.imageListTree = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.panelPattern = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.labelPattern5Tag = new System.Windows.Forms.Label();
			this.labelPattern4Tag = new System.Windows.Forms.Label();
			this.labelPattern3Description = new System.Windows.Forms.Label();
			this.labelPattern3Tag = new System.Windows.Forms.Label();
			this.labelPattern2Description = new System.Windows.Forms.Label();
			this.labelPattern2Tag = new System.Windows.Forms.Label();
			this.labelPattern1Description = new System.Windows.Forms.Label();
			this.labelPattern1Tag = new System.Windows.Forms.Label();
			this.labelPattern5Description = new System.Windows.Forms.Label();
			this.labelPattern4Description = new System.Windows.Forms.Label();
			this.groupBoxCase = new System.Windows.Forms.GroupBox();
			this.radioButtonCaseSensitive = new System.Windows.Forms.RadioButton();
			this.radioButtonCaseIgnore = new System.Windows.Forms.RadioButton();
			this.checkBoxPatternDebug = new System.Windows.Forms.CheckBox();
			this.buttonPatternPrevious = new System.Windows.Forms.Button();
			this.groupBoxPatternMatch = new System.Windows.Forms.GroupBox();
			this.radioButtonMatchFolder = new System.Windows.Forms.RadioButton();
			this.radioButtonMatchFile = new System.Windows.Forms.RadioButton();
			this.groupBoxPatternApply = new System.Windows.Forms.GroupBox();
			this.radioButtonApplyAbsolute = new System.Windows.Forms.RadioButton();
			this.radioButtonApplyRelative = new System.Windows.Forms.RadioButton();
			this.textBoxPatternPattern = new System.Windows.Forms.TextBox();
			this.labelPatternPattern = new System.Windows.Forms.Label();
			this.labelPattern = new System.Windows.Forms.Label();
			this.panelFolder = new System.Windows.Forms.Panel();
			this.buttonFolderPrevious = new System.Windows.Forms.Button();
			this.buttonFolderPath = new System.Windows.Forms.Button();
			this.labelListHistory = new System.Windows.Forms.Label();
			this.buttonHistoryDelete = new System.Windows.Forms.Button();
			this.buttonHistoryAdd = new System.Windows.Forms.Button();
			this.listBoxHistory = new System.Windows.Forms.ListBox();
			this.labelListExclude = new System.Windows.Forms.Label();
			this.buttonExcludeDelete = new System.Windows.Forms.Button();
			this.buttonExcludeAdd = new System.Windows.Forms.Button();
			this.listBoxExclude = new System.Windows.Forms.ListBox();
			this.labelListInclude = new System.Windows.Forms.Label();
			this.buttonIncludeDelete = new System.Windows.Forms.Button();
			this.buttonIncludeAdd = new System.Windows.Forms.Button();
			this.listBoxInclude = new System.Windows.Forms.ListBox();
			this.textBoxFolderPath = new System.Windows.Forms.TextBox();
			this.labelFolderPath = new System.Windows.Forms.Label();
			this.textBoxFolderName = new System.Windows.Forms.TextBox();
			this.labelFolderName = new System.Windows.Forms.Label();
			this.labelFolder = new System.Windows.Forms.Label();
			this.panelArchive = new System.Windows.Forms.Panel();
			this.labelArchiveFullPath = new System.Windows.Forms.Label();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonFolderDelete = new System.Windows.Forms.Button();
			this.buttonFolderAdd = new System.Windows.Forms.Button();
			this.labelListFolders = new System.Windows.Forms.Label();
			this.listBoxFolders = new System.Windows.Forms.ListBox();
			this.textBoxArchiveMinute = new System.Windows.Forms.TextBox();
			this.labelArchiveMinute = new System.Windows.Forms.Label();
			this.textBoxArchiveHour = new System.Windows.Forms.TextBox();
			this.labelArchiveHour = new System.Windows.Forms.Label();
			this.textBoxArchiveDay = new System.Windows.Forms.TextBox();
			this.labelArchiveDay = new System.Windows.Forms.Label();
			this.labelArchiveHistory = new System.Windows.Forms.Label();
			this.textBoxArchiveMonth = new System.Windows.Forms.TextBox();
			this.labelArchiveMonth = new System.Windows.Forms.Label();
			this.labelArchivePath = new System.Windows.Forms.Label();
			this.labelArchive = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.panelPattern.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBoxCase.SuspendLayout();
			this.groupBoxPatternMatch.SuspendLayout();
			this.groupBoxPatternApply.SuspendLayout();
			this.panelFolder.SuspendLayout();
			this.panelArchive.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeViewControl
			// 
			this.treeViewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewControl.FullRowSelect = true;
			this.treeViewControl.HideSelection = false;
			this.treeViewControl.ImageIndex = 0;
			this.treeViewControl.ImageList = this.imageListTree;
			this.treeViewControl.Location = new System.Drawing.Point(0, 0);
			this.treeViewControl.Margin = new System.Windows.Forms.Padding(4);
			this.treeViewControl.Name = "treeViewControl";
			this.treeViewControl.SelectedImageIndex = 0;
			this.treeViewControl.Size = new System.Drawing.Size(352, 608);
			this.treeViewControl.TabIndex = 0;
			this.treeViewControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewControl_AfterSelect);
			// 
			// imageListTree
			// 
			this.imageListTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTree.ImageStream")));
			this.imageListTree.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListTree.Images.SetKeyName(0, "Archive.png");
			this.imageListTree.Images.SetKeyName(1, "FolderOpen.png");
			this.imageListTree.Images.SetKeyName(2, "IncludeFile.png");
			this.imageListTree.Images.SetKeyName(3, "IncludeFolder.png");
			this.imageListTree.Images.SetKeyName(4, "ExcludeFile.png");
			this.imageListTree.Images.SetKeyName(5, "ExcludeFolder.png");
			this.imageListTree.Images.SetKeyName(6, "HistoryFile.png");
			this.imageListTree.Images.SetKeyName(7, "HistoryFolder.png");
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.Location = new System.Drawing.Point(1, 2);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.treeViewControl);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.panelPattern);
			this.splitContainer.Panel2.Controls.Add(this.panelFolder);
			this.splitContainer.Panel2.Controls.Add(this.panelArchive);
			this.splitContainer.Size = new System.Drawing.Size(1073, 613);
			this.splitContainer.SplitterDistance = 357;
			this.splitContainer.SplitterWidth = 5;
			this.splitContainer.TabIndex = 1;
			// 
			// panelPattern
			// 
			this.panelPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelPattern.Controls.Add(this.tableLayoutPanel1);
			this.panelPattern.Controls.Add(this.groupBoxCase);
			this.panelPattern.Controls.Add(this.checkBoxPatternDebug);
			this.panelPattern.Controls.Add(this.buttonPatternPrevious);
			this.panelPattern.Controls.Add(this.groupBoxPatternMatch);
			this.panelPattern.Controls.Add(this.groupBoxPatternApply);
			this.panelPattern.Controls.Add(this.textBoxPatternPattern);
			this.panelPattern.Controls.Add(this.labelPatternPattern);
			this.panelPattern.Controls.Add(this.labelPattern);
			this.panelPattern.Location = new System.Drawing.Point(4, 432);
			this.panelPattern.Margin = new System.Windows.Forms.Padding(4);
			this.panelPattern.Name = "panelPattern";
			this.panelPattern.Size = new System.Drawing.Size(643, 390);
			this.panelPattern.TabIndex = 3;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.76423F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.23577F));
			this.tableLayoutPanel1.Controls.Add(this.labelPattern5Tag, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern4Tag, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern3Description, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern3Tag, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern2Description, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern2Tag, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern1Description, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern1Tag, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern5Description, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelPattern4Description, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(112, 222);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 134);
			this.tableLayoutPanel1.TabIndex = 42;
			// 
			// labelPattern5Tag
			// 
			this.labelPattern5Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern5Tag.Location = new System.Drawing.Point(4, 109);
			this.labelPattern5Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern5Tag.Name = "labelPattern5Tag";
			this.labelPattern5Tag.Size = new System.Drawing.Size(103, 25);
			this.labelPattern5Tag.TabIndex = 8;
			this.labelPattern5Tag.Text = "/.../";
			this.labelPattern5Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern4Tag
			// 
			this.labelPattern4Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern4Tag.Location = new System.Drawing.Point(4, 76);
			this.labelPattern4Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern4Tag.Name = "labelPattern4Tag";
			this.labelPattern4Tag.Size = new System.Drawing.Size(103, 28);
			this.labelPattern4Tag.TabIndex = 6;
			this.labelPattern4Tag.Text = "/";
			this.labelPattern4Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern3Description
			// 
			this.labelPattern3Description.Location = new System.Drawing.Point(116, 46);
			this.labelPattern3Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern3Description.Name = "labelPattern3Description";
			this.labelPattern3Description.Size = new System.Drawing.Size(372, 30);
			this.labelPattern3Description.TabIndex = 5;
			this.labelPattern3Description.Text = "matches a directory path character";
			this.labelPattern3Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern3Tag
			// 
			this.labelPattern3Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern3Tag.Location = new System.Drawing.Point(4, 46);
			this.labelPattern3Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern3Tag.Name = "labelPattern3Tag";
			this.labelPattern3Tag.Size = new System.Drawing.Size(103, 28);
			this.labelPattern3Tag.TabIndex = 4;
			this.labelPattern3Tag.Text = "\\";
			this.labelPattern3Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern2Description
			// 
			this.labelPattern2Description.Location = new System.Drawing.Point(116, 23);
			this.labelPattern2Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern2Description.Name = "labelPattern2Description";
			this.labelPattern2Description.Size = new System.Drawing.Size(372, 23);
			this.labelPattern2Description.TabIndex = 3;
			this.labelPattern2Description.Text = "matches zero or one character";
			this.labelPattern2Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern2Tag
			// 
			this.labelPattern2Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern2Tag.Location = new System.Drawing.Point(4, 23);
			this.labelPattern2Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern2Tag.Name = "labelPattern2Tag";
			this.labelPattern2Tag.Size = new System.Drawing.Size(103, 23);
			this.labelPattern2Tag.TabIndex = 2;
			this.labelPattern2Tag.Text = "?";
			this.labelPattern2Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern1Description
			// 
			this.labelPattern1Description.Location = new System.Drawing.Point(116, 0);
			this.labelPattern1Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern1Description.Name = "labelPattern1Description";
			this.labelPattern1Description.Size = new System.Drawing.Size(372, 23);
			this.labelPattern1Description.TabIndex = 1;
			this.labelPattern1Description.Text = "matches zero or more characters";
			this.labelPattern1Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern1Tag
			// 
			this.labelPattern1Tag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern1Tag.Location = new System.Drawing.Point(4, 0);
			this.labelPattern1Tag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern1Tag.Name = "labelPattern1Tag";
			this.labelPattern1Tag.Size = new System.Drawing.Size(103, 23);
			this.labelPattern1Tag.TabIndex = 0;
			this.labelPattern1Tag.Text = "*";
			this.labelPattern1Tag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelPattern5Description
			// 
			this.labelPattern5Description.Location = new System.Drawing.Point(116, 109);
			this.labelPattern5Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern5Description.Name = "labelPattern5Description";
			this.labelPattern5Description.Size = new System.Drawing.Size(372, 25);
			this.labelPattern5Description.TabIndex = 7;
			this.labelPattern5Description.Text = "match any number of intermediate directory levels";
			this.labelPattern5Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPattern4Description
			// 
			this.labelPattern4Description.Location = new System.Drawing.Point(116, 76);
			this.labelPattern4Description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern4Description.Name = "labelPattern4Description";
			this.labelPattern4Description.Size = new System.Drawing.Size(372, 33);
			this.labelPattern4Description.TabIndex = 9;
			this.labelPattern4Description.Text = "matches a directory path character";
			this.labelPattern4Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBoxCase
			// 
			this.groupBoxCase.Controls.Add(this.radioButtonCaseSensitive);
			this.groupBoxCase.Controls.Add(this.radioButtonCaseIgnore);
			this.groupBoxCase.Location = new System.Drawing.Point(457, 81);
			this.groupBoxCase.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxCase.Name = "groupBoxCase";
			this.groupBoxCase.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxCase.Size = new System.Drawing.Size(147, 84);
			this.groupBoxCase.TabIndex = 26;
			this.groupBoxCase.TabStop = false;
			this.groupBoxCase.Text = "Character Case";
			// 
			// radioButtonCaseSensitive
			// 
			this.radioButtonCaseSensitive.AutoSize = true;
			this.radioButtonCaseSensitive.Location = new System.Drawing.Point(8, 23);
			this.radioButtonCaseSensitive.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonCaseSensitive.Name = "radioButtonCaseSensitive";
			this.radioButtonCaseSensitive.Size = new System.Drawing.Size(86, 21);
			this.radioButtonCaseSensitive.TabIndex = 21;
			this.radioButtonCaseSensitive.TabStop = true;
			this.radioButtonCaseSensitive.Text = "Sensitive";
			this.radioButtonCaseSensitive.UseVisualStyleBackColor = true;
			// 
			// radioButtonCaseIgnore
			// 
			this.radioButtonCaseIgnore.AutoSize = true;
			this.radioButtonCaseIgnore.Location = new System.Drawing.Point(8, 52);
			this.radioButtonCaseIgnore.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonCaseIgnore.Name = "radioButtonCaseIgnore";
			this.radioButtonCaseIgnore.Size = new System.Drawing.Size(69, 21);
			this.radioButtonCaseIgnore.TabIndex = 22;
			this.radioButtonCaseIgnore.TabStop = true;
			this.radioButtonCaseIgnore.Text = "Ignore";
			this.radioButtonCaseIgnore.UseVisualStyleBackColor = true;
			// 
			// checkBoxPatternDebug
			// 
			this.checkBoxPatternDebug.AutoSize = true;
			this.checkBoxPatternDebug.Location = new System.Drawing.Point(120, 172);
			this.checkBoxPatternDebug.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxPatternDebug.Name = "checkBoxPatternDebug";
			this.checkBoxPatternDebug.Size = new System.Drawing.Size(417, 21);
			this.checkBoxPatternDebug.TabIndex = 41;
			this.checkBoxPatternDebug.Text = "Log all matches of this filter pattern (for diagnostic purposes).";
			this.checkBoxPatternDebug.UseVisualStyleBackColor = true;
			// 
			// buttonPatternPrevious
			// 
			this.buttonPatternPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPatternPrevious.AutoSize = true;
			this.buttonPatternPrevious.FlatAppearance.BorderSize = 0;
			this.buttonPatternPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPatternPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonPatternPrevious.Location = new System.Drawing.Point(604, 4);
			this.buttonPatternPrevious.Margin = new System.Windows.Forms.Padding(4);
			this.buttonPatternPrevious.Name = "buttonPatternPrevious";
			this.buttonPatternPrevious.Size = new System.Drawing.Size(32, 30);
			this.buttonPatternPrevious.TabIndex = 40;
			this.buttonPatternPrevious.UseVisualStyleBackColor = true;
			this.buttonPatternPrevious.Click += new System.EventHandler(this.buttonPatternPrevious_Click);
			// 
			// groupBoxPatternMatch
			// 
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFolder);
			this.groupBoxPatternMatch.Controls.Add(this.radioButtonMatchFile);
			this.groupBoxPatternMatch.Location = new System.Drawing.Point(296, 81);
			this.groupBoxPatternMatch.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternMatch.Name = "groupBoxPatternMatch";
			this.groupBoxPatternMatch.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternMatch.Size = new System.Drawing.Size(115, 84);
			this.groupBoxPatternMatch.TabIndex = 25;
			this.groupBoxPatternMatch.TabStop = false;
			this.groupBoxPatternMatch.Text = "Matches only";
			// 
			// radioButtonMatchFolder
			// 
			this.radioButtonMatchFolder.AutoSize = true;
			this.radioButtonMatchFolder.Location = new System.Drawing.Point(8, 23);
			this.radioButtonMatchFolder.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonMatchFolder.Name = "radioButtonMatchFolder";
			this.radioButtonMatchFolder.Size = new System.Drawing.Size(76, 21);
			this.radioButtonMatchFolder.TabIndex = 21;
			this.radioButtonMatchFolder.TabStop = true;
			this.radioButtonMatchFolder.Text = "Folders";
			this.radioButtonMatchFolder.UseVisualStyleBackColor = true;
			this.radioButtonMatchFolder.CheckedChanged += new System.EventHandler(this.radioButtonMatchFolder_CheckedChanged);
			// 
			// radioButtonMatchFile
			// 
			this.radioButtonMatchFile.AutoSize = true;
			this.radioButtonMatchFile.Location = new System.Drawing.Point(8, 52);
			this.radioButtonMatchFile.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonMatchFile.Name = "radioButtonMatchFile";
			this.radioButtonMatchFile.Size = new System.Drawing.Size(58, 21);
			this.radioButtonMatchFile.TabIndex = 22;
			this.radioButtonMatchFile.TabStop = true;
			this.radioButtonMatchFile.Text = "Files";
			this.radioButtonMatchFile.UseVisualStyleBackColor = true;
			this.radioButtonMatchFile.CheckedChanged += new System.EventHandler(this.radioButtonMatchFile_CheckedChanged);
			// 
			// groupBoxPatternApply
			// 
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyAbsolute);
			this.groupBoxPatternApply.Controls.Add(this.radioButtonApplyRelative);
			this.groupBoxPatternApply.Location = new System.Drawing.Point(112, 81);
			this.groupBoxPatternApply.Margin = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternApply.Name = "groupBoxPatternApply";
			this.groupBoxPatternApply.Padding = new System.Windows.Forms.Padding(4);
			this.groupBoxPatternApply.Size = new System.Drawing.Size(140, 84);
			this.groupBoxPatternApply.TabIndex = 24;
			this.groupBoxPatternApply.TabStop = false;
			this.groupBoxPatternApply.Text = "Applies only to";
			// 
			// radioButtonApplyAbsolute
			// 
			this.radioButtonApplyAbsolute.AutoSize = true;
			this.radioButtonApplyAbsolute.Location = new System.Drawing.Point(8, 23);
			this.radioButtonApplyAbsolute.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonApplyAbsolute.Name = "radioButtonApplyAbsolute";
			this.radioButtonApplyAbsolute.Size = new System.Drawing.Size(102, 21);
			this.radioButtonApplyAbsolute.TabIndex = 18;
			this.radioButtonApplyAbsolute.TabStop = true;
			this.radioButtonApplyAbsolute.Text = "Fixed Paths";
			this.radioButtonApplyAbsolute.UseVisualStyleBackColor = true;
			this.radioButtonApplyAbsolute.CheckedChanged += new System.EventHandler(this.radioButtonApplyAbsolute_CheckedChanged);
			// 
			// radioButtonApplyRelative
			// 
			this.radioButtonApplyRelative.AutoSize = true;
			this.radioButtonApplyRelative.Location = new System.Drawing.Point(8, 52);
			this.radioButtonApplyRelative.Margin = new System.Windows.Forms.Padding(4);
			this.radioButtonApplyRelative.Name = "radioButtonApplyRelative";
			this.radioButtonApplyRelative.Size = new System.Drawing.Size(120, 21);
			this.radioButtonApplyRelative.TabIndex = 19;
			this.radioButtonApplyRelative.TabStop = true;
			this.radioButtonApplyRelative.Text = "Relative Paths";
			this.radioButtonApplyRelative.UseVisualStyleBackColor = true;
			this.radioButtonApplyRelative.CheckedChanged += new System.EventHandler(this.radioButtonApplyRelative_CheckedChanged);
			// 
			// textBoxPatternPattern
			// 
			this.textBoxPatternPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxPatternPattern.Location = new System.Drawing.Point(112, 49);
			this.textBoxPatternPattern.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxPatternPattern.Name = "textBoxPatternPattern";
			this.textBoxPatternPattern.Size = new System.Drawing.Size(523, 22);
			this.textBoxPatternPattern.TabIndex = 17;
			this.textBoxPatternPattern.TextChanged += new System.EventHandler(this.textBoxPatternPattern_TextChanged);
			// 
			// labelPatternPattern
			// 
			this.labelPatternPattern.AutoSize = true;
			this.labelPatternPattern.Location = new System.Drawing.Point(5, 53);
			this.labelPatternPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPatternPattern.Name = "labelPatternPattern";
			this.labelPatternPattern.Size = new System.Drawing.Size(54, 17);
			this.labelPatternPattern.TabIndex = 16;
			this.labelPatternPattern.Text = "Pattern";
			// 
			// labelPattern
			// 
			this.labelPattern.AutoSize = true;
			this.labelPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelPattern.Location = new System.Drawing.Point(4, 4);
			this.labelPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelPattern.Name = "labelPattern";
			this.labelPattern.Size = new System.Drawing.Size(61, 17);
			this.labelPattern.TabIndex = 7;
			this.labelPattern.Text = "Pattern";
			// 
			// panelFolder
			// 
			this.panelFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelFolder.Controls.Add(this.buttonFolderPrevious);
			this.panelFolder.Controls.Add(this.buttonFolderPath);
			this.panelFolder.Controls.Add(this.labelListHistory);
			this.panelFolder.Controls.Add(this.buttonHistoryDelete);
			this.panelFolder.Controls.Add(this.buttonHistoryAdd);
			this.panelFolder.Controls.Add(this.listBoxHistory);
			this.panelFolder.Controls.Add(this.labelListExclude);
			this.panelFolder.Controls.Add(this.buttonExcludeDelete);
			this.panelFolder.Controls.Add(this.buttonExcludeAdd);
			this.panelFolder.Controls.Add(this.listBoxExclude);
			this.panelFolder.Controls.Add(this.labelListInclude);
			this.panelFolder.Controls.Add(this.buttonIncludeDelete);
			this.panelFolder.Controls.Add(this.buttonIncludeAdd);
			this.panelFolder.Controls.Add(this.listBoxInclude);
			this.panelFolder.Controls.Add(this.textBoxFolderPath);
			this.panelFolder.Controls.Add(this.labelFolderPath);
			this.panelFolder.Controls.Add(this.textBoxFolderName);
			this.panelFolder.Controls.Add(this.labelFolderName);
			this.panelFolder.Controls.Add(this.labelFolder);
			this.panelFolder.Location = new System.Drawing.Point(655, 360);
			this.panelFolder.Margin = new System.Windows.Forms.Padding(4);
			this.panelFolder.Name = "panelFolder";
			this.panelFolder.Size = new System.Drawing.Size(643, 420);
			this.panelFolder.TabIndex = 2;
			// 
			// buttonFolderPrevious
			// 
			this.buttonFolderPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderPrevious.AutoSize = true;
			this.buttonFolderPrevious.FlatAppearance.BorderSize = 0;
			this.buttonFolderPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonFolderPrevious.Location = new System.Drawing.Point(605, 4);
			this.buttonFolderPrevious.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderPrevious.Name = "buttonFolderPrevious";
			this.buttonFolderPrevious.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderPrevious.TabIndex = 39;
			this.buttonFolderPrevious.UseVisualStyleBackColor = true;
			this.buttonFolderPrevious.Click += new System.EventHandler(this.buttonFolderPrevious_Click);
			// 
			// buttonFolderPath
			// 
			this.buttonFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderPath.AutoSize = true;
			this.buttonFolderPath.FlatAppearance.BorderSize = 0;
			this.buttonFolderPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderPath.Image = global::KeepBack.Properties.Resources.FolderOpen;
			this.buttonFolderPath.Location = new System.Drawing.Point(607, 78);
			this.buttonFolderPath.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderPath.Name = "buttonFolderPath";
			this.buttonFolderPath.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderPath.TabIndex = 37;
			this.buttonFolderPath.UseVisualStyleBackColor = true;
			this.buttonFolderPath.Click += new System.EventHandler(this.buttonFolderPath_Click);
			// 
			// labelListHistory
			// 
			this.labelListHistory.AutoSize = true;
			this.labelListHistory.Location = new System.Drawing.Point(5, 214);
			this.labelListHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListHistory.Name = "labelListHistory";
			this.labelListHistory.Size = new System.Drawing.Size(416, 17);
			this.labelListHistory.TabIndex = 36;
			this.labelListHistory.Text = "Backup Once: File and Folder patterns (no History is maintained)";
			// 
			// buttonHistoryDelete
			// 
			this.buttonHistoryDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonHistoryDelete.AutoSize = true;
			this.buttonHistoryDelete.FlatAppearance.BorderSize = 0;
			this.buttonHistoryDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHistoryDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonHistoryDelete.Location = new System.Drawing.Point(607, 270);
			this.buttonHistoryDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonHistoryDelete.Name = "buttonHistoryDelete";
			this.buttonHistoryDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonHistoryDelete.TabIndex = 35;
			this.buttonHistoryDelete.Tag = "";
			this.buttonHistoryDelete.UseVisualStyleBackColor = true;
			this.buttonHistoryDelete.Click += new System.EventHandler(this.buttonHistoryDelete_Click);
			// 
			// buttonHistoryAdd
			// 
			this.buttonHistoryAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonHistoryAdd.AutoSize = true;
			this.buttonHistoryAdd.FlatAppearance.BorderSize = 0;
			this.buttonHistoryAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonHistoryAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonHistoryAdd.Location = new System.Drawing.Point(607, 234);
			this.buttonHistoryAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonHistoryAdd.Name = "buttonHistoryAdd";
			this.buttonHistoryAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonHistoryAdd.TabIndex = 34;
			this.buttonHistoryAdd.UseVisualStyleBackColor = true;
			this.buttonHistoryAdd.Click += new System.EventHandler(this.buttonHistoryAdd_Click);
			// 
			// listBoxHistory
			// 
			this.listBoxHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxHistory.FormattingEnabled = true;
			this.listBoxHistory.ItemHeight = 16;
			this.listBoxHistory.Location = new System.Drawing.Point(9, 234);
			this.listBoxHistory.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxHistory.Name = "listBoxHistory";
			this.listBoxHistory.Size = new System.Drawing.Size(596, 68);
			this.listBoxHistory.TabIndex = 33;
			this.listBoxHistory.DoubleClick += new System.EventHandler(this.listBoxHistory_DoubleClick);
			// 
			// labelListExclude
			// 
			this.labelListExclude.AutoSize = true;
			this.labelListExclude.Location = new System.Drawing.Point(5, 313);
			this.labelListExclude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListExclude.Name = "labelListExclude";
			this.labelListExclude.Size = new System.Drawing.Size(380, 17);
			this.labelListExclude.TabIndex = 32;
			this.labelListExclude.Text = "Exclude: File and Folder patterns (will not be in the backup)";
			// 
			// buttonExcludeDelete
			// 
			this.buttonExcludeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExcludeDelete.AutoSize = true;
			this.buttonExcludeDelete.FlatAppearance.BorderSize = 0;
			this.buttonExcludeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExcludeDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonExcludeDelete.Location = new System.Drawing.Point(607, 368);
			this.buttonExcludeDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonExcludeDelete.Name = "buttonExcludeDelete";
			this.buttonExcludeDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonExcludeDelete.TabIndex = 31;
			this.buttonExcludeDelete.Tag = "";
			this.buttonExcludeDelete.UseVisualStyleBackColor = true;
			this.buttonExcludeDelete.Click += new System.EventHandler(this.buttonExcludeDelete_Click);
			// 
			// buttonExcludeAdd
			// 
			this.buttonExcludeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonExcludeAdd.AutoSize = true;
			this.buttonExcludeAdd.FlatAppearance.BorderSize = 0;
			this.buttonExcludeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExcludeAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonExcludeAdd.Location = new System.Drawing.Point(607, 332);
			this.buttonExcludeAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonExcludeAdd.Name = "buttonExcludeAdd";
			this.buttonExcludeAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonExcludeAdd.TabIndex = 30;
			this.buttonExcludeAdd.UseVisualStyleBackColor = true;
			this.buttonExcludeAdd.Click += new System.EventHandler(this.buttonExcludeAdd_Click);
			// 
			// listBoxExclude
			// 
			this.listBoxExclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxExclude.FormattingEnabled = true;
			this.listBoxExclude.ItemHeight = 16;
			this.listBoxExclude.Location = new System.Drawing.Point(9, 332);
			this.listBoxExclude.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxExclude.Name = "listBoxExclude";
			this.listBoxExclude.Size = new System.Drawing.Size(596, 68);
			this.listBoxExclude.TabIndex = 29;
			this.listBoxExclude.DoubleClick += new System.EventHandler(this.listBoxExclude_DoubleClick);
			// 
			// labelListInclude
			// 
			this.labelListInclude.AutoSize = true;
			this.labelListInclude.Location = new System.Drawing.Point(5, 116);
			this.labelListInclude.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListInclude.Name = "labelListInclude";
			this.labelListInclude.Size = new System.Drawing.Size(352, 17);
			this.labelListInclude.TabIndex = 28;
			this.labelListInclude.Text = "Include: File and Folder patterns (will be in the backup)";
			// 
			// buttonIncludeDelete
			// 
			this.buttonIncludeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonIncludeDelete.AutoSize = true;
			this.buttonIncludeDelete.FlatAppearance.BorderSize = 0;
			this.buttonIncludeDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonIncludeDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonIncludeDelete.Location = new System.Drawing.Point(607, 171);
			this.buttonIncludeDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonIncludeDelete.Name = "buttonIncludeDelete";
			this.buttonIncludeDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonIncludeDelete.TabIndex = 27;
			this.buttonIncludeDelete.Tag = "";
			this.buttonIncludeDelete.UseVisualStyleBackColor = true;
			this.buttonIncludeDelete.Click += new System.EventHandler(this.buttonIncludeDelete_Click);
			// 
			// buttonIncludeAdd
			// 
			this.buttonIncludeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonIncludeAdd.AutoSize = true;
			this.buttonIncludeAdd.FlatAppearance.BorderSize = 0;
			this.buttonIncludeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonIncludeAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonIncludeAdd.Location = new System.Drawing.Point(607, 135);
			this.buttonIncludeAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonIncludeAdd.Name = "buttonIncludeAdd";
			this.buttonIncludeAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonIncludeAdd.TabIndex = 26;
			this.buttonIncludeAdd.UseVisualStyleBackColor = true;
			this.buttonIncludeAdd.Click += new System.EventHandler(this.buttonIncludeAdd_Click);
			// 
			// listBoxInclude
			// 
			this.listBoxInclude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxInclude.FormattingEnabled = true;
			this.listBoxInclude.ItemHeight = 16;
			this.listBoxInclude.Location = new System.Drawing.Point(9, 135);
			this.listBoxInclude.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxInclude.Name = "listBoxInclude";
			this.listBoxInclude.Size = new System.Drawing.Size(596, 68);
			this.listBoxInclude.TabIndex = 25;
			this.listBoxInclude.DoubleClick += new System.EventHandler(this.listBoxInclude_DoubleClick);
			// 
			// textBoxFolderPath
			// 
			this.textBoxFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxFolderPath.Location = new System.Drawing.Point(68, 81);
			this.textBoxFolderPath.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxFolderPath.Name = "textBoxFolderPath";
			this.textBoxFolderPath.Size = new System.Drawing.Size(537, 22);
			this.textBoxFolderPath.TabIndex = 15;
			// 
			// labelFolderPath
			// 
			this.labelFolderPath.AutoSize = true;
			this.labelFolderPath.Location = new System.Drawing.Point(5, 85);
			this.labelFolderPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolderPath.Name = "labelFolderPath";
			this.labelFolderPath.Size = new System.Drawing.Size(37, 17);
			this.labelFolderPath.TabIndex = 14;
			this.labelFolderPath.Text = "Path";
			// 
			// textBoxFolderName
			// 
			this.textBoxFolderName.Location = new System.Drawing.Point(68, 49);
			this.textBoxFolderName.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxFolderName.Name = "textBoxFolderName";
			this.textBoxFolderName.Size = new System.Drawing.Size(249, 22);
			this.textBoxFolderName.TabIndex = 13;
			this.textBoxFolderName.TextChanged += new System.EventHandler(this.textBoxFolderName_TextChanged);
			// 
			// labelFolderName
			// 
			this.labelFolderName.AutoSize = true;
			this.labelFolderName.Location = new System.Drawing.Point(5, 53);
			this.labelFolderName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolderName.Name = "labelFolderName";
			this.labelFolderName.Size = new System.Drawing.Size(45, 17);
			this.labelFolderName.TabIndex = 12;
			this.labelFolderName.Text = "Name";
			// 
			// labelFolder
			// 
			this.labelFolder.AutoSize = true;
			this.labelFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFolder.Location = new System.Drawing.Point(5, 4);
			this.labelFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelFolder.Name = "labelFolder";
			this.labelFolder.Size = new System.Drawing.Size(54, 17);
			this.labelFolder.TabIndex = 6;
			this.labelFolder.Text = "Folder";
			// 
			// panelArchive
			// 
			this.panelArchive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelArchive.Controls.Add(this.labelArchiveFullPath);
			this.panelArchive.Controls.Add(this.buttonSave);
			this.panelArchive.Controls.Add(this.buttonFolderDelete);
			this.panelArchive.Controls.Add(this.buttonFolderAdd);
			this.panelArchive.Controls.Add(this.labelListFolders);
			this.panelArchive.Controls.Add(this.listBoxFolders);
			this.panelArchive.Controls.Add(this.textBoxArchiveMinute);
			this.panelArchive.Controls.Add(this.labelArchiveMinute);
			this.panelArchive.Controls.Add(this.textBoxArchiveHour);
			this.panelArchive.Controls.Add(this.labelArchiveHour);
			this.panelArchive.Controls.Add(this.textBoxArchiveDay);
			this.panelArchive.Controls.Add(this.labelArchiveDay);
			this.panelArchive.Controls.Add(this.labelArchiveHistory);
			this.panelArchive.Controls.Add(this.textBoxArchiveMonth);
			this.panelArchive.Controls.Add(this.labelArchiveMonth);
			this.panelArchive.Controls.Add(this.labelArchivePath);
			this.panelArchive.Controls.Add(this.labelArchive);
			this.panelArchive.Location = new System.Drawing.Point(4, 4);
			this.panelArchive.Margin = new System.Windows.Forms.Padding(4);
			this.panelArchive.Name = "panelArchive";
			this.panelArchive.Size = new System.Drawing.Size(643, 318);
			this.panelArchive.TabIndex = 1;
			// 
			// labelArchiveFullPath
			// 
			this.labelArchiveFullPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelArchiveFullPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelArchiveFullPath.Location = new System.Drawing.Point(9, 60);
			this.labelArchiveFullPath.Name = "labelArchiveFullPath";
			this.labelArchiveFullPath.Size = new System.Drawing.Size(596, 22);
			this.labelArchiveFullPath.TabIndex = 25;
			this.labelArchiveFullPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(536, 4);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(100, 28);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonFolderDelete
			// 
			this.buttonFolderDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderDelete.AutoSize = true;
			this.buttonFolderDelete.FlatAppearance.BorderSize = 0;
			this.buttonFolderDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderDelete.Image = global::KeepBack.Properties.Resources.Delete;
			this.buttonFolderDelete.Location = new System.Drawing.Point(607, 231);
			this.buttonFolderDelete.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderDelete.Name = "buttonFolderDelete";
			this.buttonFolderDelete.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderDelete.TabIndex = 24;
			this.buttonFolderDelete.Tag = "";
			this.buttonFolderDelete.UseVisualStyleBackColor = true;
			this.buttonFolderDelete.Click += new System.EventHandler(this.buttonFolderDelete_Click);
			// 
			// buttonFolderAdd
			// 
			this.buttonFolderAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonFolderAdd.AutoSize = true;
			this.buttonFolderAdd.FlatAppearance.BorderSize = 0;
			this.buttonFolderAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonFolderAdd.Image = global::KeepBack.Properties.Resources.Add;
			this.buttonFolderAdd.Location = new System.Drawing.Point(607, 196);
			this.buttonFolderAdd.Margin = new System.Windows.Forms.Padding(4);
			this.buttonFolderAdd.Name = "buttonFolderAdd";
			this.buttonFolderAdd.Size = new System.Drawing.Size(32, 30);
			this.buttonFolderAdd.TabIndex = 23;
			this.buttonFolderAdd.UseVisualStyleBackColor = true;
			this.buttonFolderAdd.Click += new System.EventHandler(this.buttonFolderAdd_Click);
			// 
			// labelListFolders
			// 
			this.labelListFolders.AutoSize = true;
			this.labelListFolders.Location = new System.Drawing.Point(5, 176);
			this.labelListFolders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelListFolders.Name = "labelListFolders";
			this.labelListFolders.Size = new System.Drawing.Size(255, 17);
			this.labelListFolders.TabIndex = 22;
			this.labelListFolders.Text = "Folders to be backed up to the archive.";
			// 
			// listBoxFolders
			// 
			this.listBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxFolders.FormattingEnabled = true;
			this.listBoxFolders.ItemHeight = 16;
			this.listBoxFolders.Location = new System.Drawing.Point(9, 196);
			this.listBoxFolders.Margin = new System.Windows.Forms.Padding(4);
			this.listBoxFolders.Name = "listBoxFolders";
			this.listBoxFolders.Size = new System.Drawing.Size(596, 100);
			this.listBoxFolders.TabIndex = 21;
			this.listBoxFolders.DoubleClick += new System.EventHandler(this.listBoxFolders_DoubleClick);
			// 
			// textBoxArchiveMinute
			// 
			this.textBoxArchiveMinute.Location = new System.Drawing.Point(521, 133);
			this.textBoxArchiveMinute.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveMinute.Name = "textBoxArchiveMinute";
			this.textBoxArchiveMinute.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveMinute.TabIndex = 20;
			this.textBoxArchiveMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveMinute, "After this number of minutes, minute-by-minute backups will be merged together in" +
        "to hours.");
			// 
			// labelArchiveMinute
			// 
			this.labelArchiveMinute.AutoSize = true;
			this.labelArchiveMinute.Location = new System.Drawing.Point(461, 137);
			this.labelArchiveMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveMinute.Name = "labelArchiveMinute";
			this.labelArchiveMinute.Size = new System.Drawing.Size(57, 17);
			this.labelArchiveMinute.TabIndex = 19;
			this.labelArchiveMinute.Text = "Minutes";
			this.labelArchiveMinute.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveHour
			// 
			this.textBoxArchiveHour.Location = new System.Drawing.Point(377, 133);
			this.textBoxArchiveHour.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveHour.Name = "textBoxArchiveHour";
			this.textBoxArchiveHour.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveHour.TabIndex = 18;
			this.textBoxArchiveHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveHour, "After this number of hours, hourly backups will be merged together into days.");
			// 
			// labelArchiveHour
			// 
			this.labelArchiveHour.AutoSize = true;
			this.labelArchiveHour.Location = new System.Drawing.Point(329, 137);
			this.labelArchiveHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveHour.Name = "labelArchiveHour";
			this.labelArchiveHour.Size = new System.Drawing.Size(46, 17);
			this.labelArchiveHour.TabIndex = 17;
			this.labelArchiveHour.Text = "Hours";
			this.labelArchiveHour.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// textBoxArchiveDay
			// 
			this.textBoxArchiveDay.Location = new System.Drawing.Point(233, 133);
			this.textBoxArchiveDay.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveDay.Name = "textBoxArchiveDay";
			this.textBoxArchiveDay.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveDay.TabIndex = 16;
			this.textBoxArchiveDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveDay, "After this number of days, daily backups will be merged together into months.");
			// 
			// labelArchiveDay
			// 
			this.labelArchiveDay.AutoSize = true;
			this.labelArchiveDay.Location = new System.Drawing.Point(191, 137);
			this.labelArchiveDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveDay.Name = "labelArchiveDay";
			this.labelArchiveDay.Size = new System.Drawing.Size(40, 17);
			this.labelArchiveDay.TabIndex = 15;
			this.labelArchiveDay.Text = "Days";
			this.labelArchiveDay.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelArchiveHistory
			// 
			this.labelArchiveHistory.AutoSize = true;
			this.labelArchiveHistory.Location = new System.Drawing.Point(5, 105);
			this.labelArchiveHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveHistory.Name = "labelArchiveHistory";
			this.labelArchiveHistory.Size = new System.Drawing.Size(515, 17);
			this.labelArchiveHistory.TabIndex = 14;
			this.labelArchiveHistory.Text = "Historical backups are merged together at four levels after these periods of time" +
    ":";
			// 
			// textBoxArchiveMonth
			// 
			this.textBoxArchiveMonth.Location = new System.Drawing.Point(89, 133);
			this.textBoxArchiveMonth.Margin = new System.Windows.Forms.Padding(4);
			this.textBoxArchiveMonth.Name = "textBoxArchiveMonth";
			this.textBoxArchiveMonth.Size = new System.Drawing.Size(40, 22);
			this.textBoxArchiveMonth.TabIndex = 13;
			this.textBoxArchiveMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip.SetToolTip(this.textBoxArchiveMonth, "After this number of months, monthly backups will be merged together into years.");
			// 
			// labelArchiveMonth
			// 
			this.labelArchiveMonth.AutoSize = true;
			this.labelArchiveMonth.Location = new System.Drawing.Point(32, 137);
			this.labelArchiveMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchiveMonth.Name = "labelArchiveMonth";
			this.labelArchiveMonth.Size = new System.Drawing.Size(54, 17);
			this.labelArchiveMonth.TabIndex = 12;
			this.labelArchiveMonth.Text = "Months";
			this.labelArchiveMonth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// labelArchivePath
			// 
			this.labelArchivePath.AutoSize = true;
			this.labelArchivePath.Location = new System.Drawing.Point(6, 40);
			this.labelArchivePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchivePath.Name = "labelArchivePath";
			this.labelArchivePath.Size = new System.Drawing.Size(66, 17);
			this.labelArchivePath.TabIndex = 8;
			this.labelArchivePath.Text = "Location:";
			// 
			// labelArchive
			// 
			this.labelArchive.AutoSize = true;
			this.labelArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelArchive.Location = new System.Drawing.Point(5, 4);
			this.labelArchive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelArchive.Name = "labelArchive";
			this.labelArchive.Size = new System.Drawing.Size(62, 17);
			this.labelArchive.TabIndex = 5;
			this.labelArchive.Text = "Archive";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 15000;
			this.toolTip.InitialDelay = 100;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			// 
			// FormEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1076, 617);
			this.Controls.Add(this.splitContainer);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FormEdit";
			this.Text = "Backup Selection";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
			this.Shown += new System.EventHandler(this.FormEdit_Shown);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.panelPattern.ResumeLayout(false);
			this.panelPattern.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBoxCase.ResumeLayout(false);
			this.groupBoxCase.PerformLayout();
			this.groupBoxPatternMatch.ResumeLayout(false);
			this.groupBoxPatternMatch.PerformLayout();
			this.groupBoxPatternApply.ResumeLayout(false);
			this.groupBoxPatternApply.PerformLayout();
			this.panelFolder.ResumeLayout(false);
			this.panelFolder.PerformLayout();
			this.panelArchive.ResumeLayout(false);
			this.panelArchive.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView treeViewControl;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Panel panelPattern;
		private System.Windows.Forms.Panel panelFolder;
		private System.Windows.Forms.Panel panelArchive;
		private System.Windows.Forms.ImageList imageListTree;
		private System.Windows.Forms.Label labelArchive;
		private System.Windows.Forms.Label labelArchivePath;
		private System.Windows.Forms.TextBox textBoxArchiveMonth;
		private System.Windows.Forms.Label labelArchiveMonth;
		private System.Windows.Forms.Label labelArchiveHistory;
		private System.Windows.Forms.TextBox textBoxArchiveMinute;
		private System.Windows.Forms.Label labelArchiveMinute;
		private System.Windows.Forms.TextBox textBoxArchiveHour;
		private System.Windows.Forms.Label labelArchiveHour;
		private System.Windows.Forms.TextBox textBoxArchiveDay;
		private System.Windows.Forms.Label labelArchiveDay;
		private System.Windows.Forms.Label labelListFolders;
		private System.Windows.Forms.ListBox listBoxFolders;
		private System.Windows.Forms.Button buttonFolderDelete;
		private System.Windows.Forms.Button buttonFolderAdd;
		private System.Windows.Forms.TextBox textBoxFolderPath;
		private System.Windows.Forms.Label labelFolderPath;
		private System.Windows.Forms.TextBox textBoxFolderName;
		private System.Windows.Forms.Label labelFolderName;
		private System.Windows.Forms.Label labelFolder;
		private System.Windows.Forms.Label labelListInclude;
		private System.Windows.Forms.Button buttonIncludeDelete;
		private System.Windows.Forms.Button buttonIncludeAdd;
		private System.Windows.Forms.ListBox listBoxInclude;
		private System.Windows.Forms.Label labelListExclude;
		private System.Windows.Forms.Button buttonExcludeDelete;
		private System.Windows.Forms.Button buttonExcludeAdd;
		private System.Windows.Forms.ListBox listBoxExclude;
		private System.Windows.Forms.Label labelListHistory;
		private System.Windows.Forms.Button buttonHistoryDelete;
		private System.Windows.Forms.Button buttonHistoryAdd;
		private System.Windows.Forms.ListBox listBoxHistory;
		private System.Windows.Forms.TextBox textBoxPatternPattern;
		private System.Windows.Forms.Label labelPatternPattern;
		private System.Windows.Forms.Label labelPattern;
		private System.Windows.Forms.RadioButton radioButtonApplyRelative;
		private System.Windows.Forms.RadioButton radioButtonApplyAbsolute;
		private System.Windows.Forms.RadioButton radioButtonMatchFile;
		private System.Windows.Forms.RadioButton radioButtonMatchFolder;
		private System.Windows.Forms.GroupBox groupBoxPatternMatch;
		private System.Windows.Forms.GroupBox groupBoxPatternApply;
		private System.Windows.Forms.Button buttonFolderPath;
		private System.Windows.Forms.Button buttonFolderPrevious;
		private System.Windows.Forms.Button buttonPatternPrevious;
		private System.Windows.Forms.CheckBox checkBoxPatternDebug;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.GroupBox groupBoxCase;
		private System.Windows.Forms.RadioButton radioButtonCaseSensitive;
		private System.Windows.Forms.RadioButton radioButtonCaseIgnore;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label labelPattern5Description;
		private System.Windows.Forms.Label labelPattern4Tag;
		private System.Windows.Forms.Label labelPattern3Description;
		private System.Windows.Forms.Label labelPattern3Tag;
		private System.Windows.Forms.Label labelPattern2Description;
		private System.Windows.Forms.Label labelPattern2Tag;
		private System.Windows.Forms.Label labelPattern1Description;
		private System.Windows.Forms.Label labelPattern1Tag;
		private System.Windows.Forms.Label labelPattern5Tag;
		private System.Windows.Forms.Label labelPattern4Description;
		private System.Windows.Forms.Label labelArchiveFullPath;
		private System.Windows.Forms.ToolTip toolTip;
	}
}