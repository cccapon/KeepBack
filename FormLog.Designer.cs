namespace KeepBack
{
	partial class FormLog
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
			this.panelList = new System.Windows.Forms.Panel();
			this.labelDirections = new System.Windows.Forms.Label();
			this.listViewLogs = new System.Windows.Forms.ListView();
			this.panelLog = new System.Windows.Forms.Panel();
			this.labelLog = new System.Windows.Forms.Label();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.buttonPrevious = new System.Windows.Forms.Button();
			this.panelList.SuspendLayout();
			this.panelLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelList
			// 
			this.panelList.Controls.Add(this.labelDirections);
			this.panelList.Controls.Add(this.listViewLogs);
			this.panelList.Location = new System.Drawing.Point(12, 12);
			this.panelList.Name = "panelList";
			this.panelList.Size = new System.Drawing.Size(540, 122);
			this.panelList.TabIndex = 0;
			// 
			// labelDirections
			// 
			this.labelDirections.AutoSize = true;
			this.labelDirections.Location = new System.Drawing.Point(10, 13);
			this.labelDirections.Name = "labelDirections";
			this.labelDirections.Size = new System.Drawing.Size(333, 13);
			this.labelDirections.TabIndex = 1;
			this.labelDirections.Text = "Please select a log file from the list to view the details of your backup.";
			// 
			// listViewLogs
			// 
			this.listViewLogs.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listViewLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listViewLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listViewLogs.HideSelection = false;
			this.listViewLogs.Location = new System.Drawing.Point(3, 34);
			this.listViewLogs.MultiSelect = false;
			this.listViewLogs.Name = "listViewLogs";
			this.listViewLogs.Size = new System.Drawing.Size(534, 85);
			this.listViewLogs.TabIndex = 1;
			this.listViewLogs.UseCompatibleStateImageBehavior = false;
			this.listViewLogs.View = System.Windows.Forms.View.List;
			this.listViewLogs.ItemActivate += new System.EventHandler(this.listViewLogs_ItemActivate);
			// 
			// panelLog
			// 
			this.panelLog.Controls.Add(this.buttonPrevious);
			this.panelLog.Controls.Add(this.labelLog);
			this.panelLog.Controls.Add(this.richTextBoxLog);
			this.panelLog.Location = new System.Drawing.Point(42, 190);
			this.panelLog.Name = "panelLog";
			this.panelLog.Size = new System.Drawing.Size(654, 161);
			this.panelLog.TabIndex = 1;
			// 
			// labelLog
			// 
			this.labelLog.AutoSize = true;
			this.labelLog.Location = new System.Drawing.Point(10, 13);
			this.labelLog.Name = "labelLog";
			this.labelLog.Size = new System.Drawing.Size(44, 13);
			this.labelLog.TabIndex = 1;
			this.labelLog.Text = "Log File";
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBoxLog.BackColor = System.Drawing.SystemColors.Window;
			this.richTextBoxLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBoxLog.Location = new System.Drawing.Point(0, 34);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ReadOnly = true;
			this.richTextBoxLog.Size = new System.Drawing.Size(651, 124);
			this.richTextBoxLog.TabIndex = 2;
			this.richTextBoxLog.Text = "";
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPrevious.AutoSize = true;
			this.buttonPrevious.FlatAppearance.BorderSize = 0;
			this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPrevious.Image = global::KeepBack.Properties.Resources.Previous;
			this.buttonPrevious.Location = new System.Drawing.Point(627, 4);
			this.buttonPrevious.Name = "buttonPrevious";
			this.buttonPrevious.Size = new System.Drawing.Size(24, 24);
			this.buttonPrevious.TabIndex = 2;
			this.buttonPrevious.UseVisualStyleBackColor = true;
			this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
			// 
			// FormLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(708, 459);
			this.Controls.Add(this.panelLog);
			this.Controls.Add(this.panelList);
			this.Name = "FormLog";
			this.Text = "Backup Log Files";
			this.Shown += new System.EventHandler(this.FormLog_Shown);
			this.panelList.ResumeLayout(false);
			this.panelList.PerformLayout();
			this.panelLog.ResumeLayout(false);
			this.panelLog.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelList;
		private System.Windows.Forms.ListView listViewLogs;
		private System.Windows.Forms.Panel panelLog;
		private System.Windows.Forms.Label labelLog;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Label labelDirections;
		private System.Windows.Forms.Button buttonPrevious;
	}
}