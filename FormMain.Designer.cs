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
			this.labelChanged = new System.Windows.Forms.Label();
			this.labelAttribute = new System.Windows.Forms.Label();
			this.labelWritten = new System.Windows.Forms.Label();
			this.labelLength = new System.Windows.Forms.Label();
			this.labelAttrs = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelCreated = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.labelDeleted = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.buttonMerge = new System.Windows.Forms.Button();
			this.buttonExplore = new System.Windows.Forms.Button();
			this.labelSkipped = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonNew = new System.Windows.Forms.Button();
			this.panelStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonBackup
			// 
			this.buttonBackup.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonBackup.Location = new System.Drawing.Point( 801, 233 );
			this.buttonBackup.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonBackup.Name = "buttonBackup";
			this.buttonBackup.Size = new System.Drawing.Size( 101, 28 );
			this.buttonBackup.TabIndex = 12;
			this.buttonBackup.Text = "Backup";
			this.buttonBackup.UseVisualStyleBackColor = true;
			this.buttonBackup.Click += new System.EventHandler( this.buttonBackup_Click );
			// 
			// richTextBoxInfo
			// 
			this.richTextBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.richTextBoxInfo.Font = new System.Drawing.Font( "Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
			this.richTextBoxInfo.Location = new System.Drawing.Point( 16, 268 );
			this.richTextBoxInfo.Margin = new System.Windows.Forms.Padding( 4 );
			this.richTextBoxInfo.Name = "richTextBoxInfo";
			this.richTextBoxInfo.ReadOnly = true;
			this.richTextBoxInfo.Size = new System.Drawing.Size( 885, 163 );
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
			this.labelCurrentDirectory.Location = new System.Drawing.Point( 16, 25 );
			this.labelCurrentDirectory.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelCurrentDirectory.Name = "labelCurrentDirectory";
			this.labelCurrentDirectory.Size = new System.Drawing.Size( 886, 28 );
			this.labelCurrentDirectory.TabIndex = 1;
			this.labelCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCurrentFile
			// 
			this.labelCurrentFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCurrentFile.AutoEllipsis = true;
			this.labelCurrentFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCurrentFile.Location = new System.Drawing.Point( 16, 69 );
			this.labelCurrentFile.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelCurrentFile.Name = "labelCurrentFile";
			this.labelCurrentFile.Size = new System.Drawing.Size( 419, 28 );
			this.labelCurrentFile.TabIndex = 3;
			this.labelCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelChanged
			// 
			this.labelChanged.AutoEllipsis = true;
			this.labelChanged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelChanged.Location = new System.Drawing.Point( 85, 12 );
			this.labelChanged.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelChanged.Name = "labelChanged";
			this.labelChanged.Size = new System.Drawing.Size( 85, 28 );
			this.labelChanged.TabIndex = 1;
			this.labelChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelAttribute
			// 
			this.labelAttribute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelAttribute.Location = new System.Drawing.Point( 269, 69 );
			this.labelAttribute.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelAttribute.Name = "labelAttribute";
			this.labelAttribute.Size = new System.Drawing.Size( 85, 28 );
			this.labelAttribute.TabIndex = 9;
			this.labelAttribute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelWritten
			// 
			this.labelWritten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelWritten.Location = new System.Drawing.Point( 269, 41 );
			this.labelWritten.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelWritten.Name = "labelWritten";
			this.labelWritten.Size = new System.Drawing.Size( 85, 28 );
			this.labelWritten.TabIndex = 7;
			this.labelWritten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelLength
			// 
			this.labelLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelLength.Location = new System.Drawing.Point( 449, 41 );
			this.labelLength.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelLength.Name = "labelLength";
			this.labelLength.Size = new System.Drawing.Size( 85, 28 );
			this.labelLength.TabIndex = 13;
			this.labelLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelAttrs
			// 
			this.labelAttrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAttrs.AutoEllipsis = true;
			this.labelAttrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelAttrs.Location = new System.Drawing.Point( 444, 69 );
			this.labelAttrs.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelAttrs.Name = "labelAttrs";
			this.labelAttrs.Size = new System.Drawing.Size( 458, 28 );
			this.labelAttrs.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 203, 75 );
			this.label1.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 61, 17 );
			this.label1.TabIndex = 8;
			this.label1.Text = "Attribute";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 11, 18 );
			this.label2.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 65, 17 );
			this.label2.TabIndex = 0;
			this.label2.Text = "Changed";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 203, 47 );
			this.label3.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 49, 17 );
			this.label3.TabIndex = 6;
			this.label3.Text = "Writen";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 383, 47 );
			this.label4.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 35, 17 );
			this.label4.TabIndex = 12;
			this.label4.Text = "Size";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 440, 53 );
			this.label5.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 67, 17 );
			this.label5.TabIndex = 4;
			this.label5.Text = "attributes";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 12, 9 );
			this.label6.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 106, 17 );
			this.label6.TabIndex = 0;
			this.label6.Text = "current location";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 12, 53 );
			this.label7.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 104, 17 );
			this.label7.TabIndex = 2;
			this.label7.Text = "most recent file";
			// 
			// labelCreated
			// 
			this.labelCreated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelCreated.Location = new System.Drawing.Point( 269, 12 );
			this.labelCreated.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelCreated.Name = "labelCreated";
			this.labelCreated.Size = new System.Drawing.Size( 85, 28 );
			this.labelCreated.TabIndex = 5;
			this.labelCreated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 203, 18 );
			this.label8.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 58, 17 );
			this.label8.TabIndex = 4;
			this.label8.Text = "Created";
			// 
			// labelDeleted
			// 
			this.labelDeleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelDeleted.Location = new System.Drawing.Point( 449, 12 );
			this.labelDeleted.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelDeleted.Name = "labelDeleted";
			this.labelDeleted.Size = new System.Drawing.Size( 85, 28 );
			this.labelDeleted.TabIndex = 11;
			this.labelDeleted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point( 383, 18 );
			this.label10.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size( 57, 17 );
			this.label10.TabIndex = 10;
			this.label10.Text = "Deleted";
			// 
			// buttonOpen
			// 
			this.buttonOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonOpen.Location = new System.Drawing.Point( 125, 233 );
			this.buttonOpen.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size( 101, 28 );
			this.buttonOpen.TabIndex = 8;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler( this.buttonOpen_Click );
			// 
			// buttonMerge
			// 
			this.buttonMerge.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonMerge.Location = new System.Drawing.Point( 692, 233 );
			this.buttonMerge.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonMerge.Name = "buttonMerge";
			this.buttonMerge.Size = new System.Drawing.Size( 101, 28 );
			this.buttonMerge.TabIndex = 11;
			this.buttonMerge.Text = "Merge";
			this.buttonMerge.UseVisualStyleBackColor = true;
			this.buttonMerge.Click += new System.EventHandler( this.buttonMerge_Click );
			// 
			// buttonExplore
			// 
			this.buttonExplore.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonExplore.Location = new System.Drawing.Point( 457, 233 );
			this.buttonExplore.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonExplore.Name = "buttonExplore";
			this.buttonExplore.Size = new System.Drawing.Size( 101, 28 );
			this.buttonExplore.TabIndex = 10;
			this.buttonExplore.Text = "Explore";
			this.buttonExplore.UseVisualStyleBackColor = true;
			this.buttonExplore.Click += new System.EventHandler( this.buttonExplore_Click );
			// 
			// labelSkipped
			// 
			this.labelSkipped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelSkipped.Location = new System.Drawing.Point( 85, 41 );
			this.labelSkipped.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.labelSkipped.Name = "labelSkipped";
			this.labelSkipped.Size = new System.Drawing.Size( 85, 28 );
			this.labelSkipped.TabIndex = 3;
			this.labelSkipped.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point( 11, 47 );
			this.label11.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size( 59, 17 );
			this.label11.TabIndex = 2;
			this.label11.Text = "Skipped";
			// 
			// panelStatus
			// 
			this.panelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panelStatus.Controls.Add( this.label2 );
			this.panelStatus.Controls.Add( this.labelSkipped );
			this.panelStatus.Controls.Add( this.label11 );
			this.panelStatus.Controls.Add( this.labelDeleted );
			this.panelStatus.Controls.Add( this.label10 );
			this.panelStatus.Controls.Add( this.labelChanged );
			this.panelStatus.Controls.Add( this.label8 );
			this.panelStatus.Controls.Add( this.label4 );
			this.panelStatus.Controls.Add( this.labelCreated );
			this.panelStatus.Controls.Add( this.label3 );
			this.panelStatus.Controls.Add( this.labelLength );
			this.panelStatus.Controls.Add( this.label1 );
			this.panelStatus.Controls.Add( this.labelAttribute );
			this.panelStatus.Controls.Add( this.labelWritten );
			this.panelStatus.Location = new System.Drawing.Point( 175, 116 );
			this.panelStatus.Margin = new System.Windows.Forms.Padding( 4 );
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size( 552, 110 );
			this.panelStatus.TabIndex = 6;
			// 
			// buttonEdit
			// 
			this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonEdit.Location = new System.Drawing.Point( 235, 233 );
			this.buttonEdit.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size( 101, 28 );
			this.buttonEdit.TabIndex = 9;
			this.buttonEdit.Text = "Edit";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler( this.buttonEdit_Click );
			// 
			// buttonNew
			// 
			this.buttonNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.buttonNew.Location = new System.Drawing.Point( 16, 233 );
			this.buttonNew.Margin = new System.Windows.Forms.Padding( 4 );
			this.buttonNew.Name = "buttonNew";
			this.buttonNew.Size = new System.Drawing.Size( 101, 28 );
			this.buttonNew.TabIndex = 7;
			this.buttonNew.Text = "New";
			this.buttonNew.UseVisualStyleBackColor = true;
			this.buttonNew.Click += new System.EventHandler( this.buttonNew_Click );
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 16F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 923, 447 );
			this.Controls.Add( this.buttonNew );
			this.Controls.Add( this.buttonEdit );
			this.Controls.Add( this.panelStatus );
			this.Controls.Add( this.buttonExplore );
			this.Controls.Add( this.buttonOpen );
			this.Controls.Add( this.buttonMerge );
			this.Controls.Add( this.label7 );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.labelAttrs );
			this.Controls.Add( this.labelCurrentFile );
			this.Controls.Add( this.labelCurrentDirectory );
			this.Controls.Add( this.richTextBoxInfo );
			this.Controls.Add( this.buttonBackup );
			this.Margin = new System.Windows.Forms.Padding( 4 );
			this.MinimumSize = new System.Drawing.Size( 927, 47 );
			this.Name = "FormMain";
			this.Text = "Keep Back";
			this.Load += new System.EventHandler( this.FormMain_Load );
			this.panelStatus.ResumeLayout( false );
			this.panelStatus.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonBackup;
		private System.Windows.Forms.RichTextBox richTextBoxInfo;
		private System.Windows.Forms.Label labelCurrentDirectory;
		private System.Windows.Forms.Label labelCurrentFile;
		private System.Windows.Forms.Label labelChanged;
		private System.Windows.Forms.Label labelAttribute;
		private System.Windows.Forms.Label labelWritten;
		private System.Windows.Forms.Label labelLength;
		private System.Windows.Forms.Label labelAttrs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelCreated;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label labelDeleted;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonMerge;
		private System.Windows.Forms.Button buttonExplore;
		private System.Windows.Forms.Label labelSkipped;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panelStatus;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonNew;
	}
}

