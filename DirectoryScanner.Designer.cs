namespace CeDirScan
{
    partial class DirectoryScanner
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ofdBrowse = new System.Windows.Forms.OpenFileDialog();
            this.rbSortByFileType = new System.Windows.Forms.RadioButton();
            this.rbSortByFileName = new System.Windows.Forms.RadioButton();
            this.rbSortByFilePath = new System.Windows.Forms.RadioButton();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.gbSortingOptions = new System.Windows.Forms.GroupBox();
            this.rbSortByFileSize = new System.Windows.Forms.RadioButton();
            this.btnGo = new System.Windows.Forms.Button();
            this.sfdSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.gbSortAscDesc = new System.Windows.Forms.GroupBox();
            this.rbSortByAscending = new System.Windows.Forms.RadioButton();
            this.rbSortByDescending = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.gbSortingOptions.SuspendLayout();
            this.gbSortAscDesc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(495, 10);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(84, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 193);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(100, 17);
            this.tsslStatus.Text = "Wating For User...";
            // 
            // ofdBrowse
            // 
            this.ofdBrowse.FileName = "C:\\";
            // 
            // rbSortByFileType
            // 
            this.rbSortByFileType.AutoSize = true;
            this.rbSortByFileType.Location = new System.Drawing.Point(6, 88);
            this.rbSortByFileType.Name = "rbSortByFileType";
            this.rbSortByFileType.Size = new System.Drawing.Size(68, 17);
            this.rbSortByFileType.TabIndex = 2;
            this.rbSortByFileType.Text = "File Type";
            this.rbSortByFileType.UseVisualStyleBackColor = true;
            // 
            // rbSortByFileName
            // 
            this.rbSortByFileName.AutoSize = true;
            this.rbSortByFileName.Checked = true;
            this.rbSortByFileName.Location = new System.Drawing.Point(6, 19);
            this.rbSortByFileName.Name = "rbSortByFileName";
            this.rbSortByFileName.Size = new System.Drawing.Size(72, 17);
            this.rbSortByFileName.TabIndex = 3;
            this.rbSortByFileName.TabStop = true;
            this.rbSortByFileName.Text = "File Name";
            this.rbSortByFileName.UseVisualStyleBackColor = true;
            // 
            // rbSortByFilePath
            // 
            this.rbSortByFilePath.AutoSize = true;
            this.rbSortByFilePath.Location = new System.Drawing.Point(6, 42);
            this.rbSortByFilePath.Name = "rbSortByFilePath";
            this.rbSortByFilePath.Size = new System.Drawing.Size(66, 17);
            this.rbSortByFilePath.TabIndex = 4;
            this.rbSortByFilePath.Text = "File Path";
            this.rbSortByFilePath.UseVisualStyleBackColor = true;
            // 
            // tbDirectory
            // 
            this.tbDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDirectory.Location = new System.Drawing.Point(12, 12);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.Size = new System.Drawing.Size(477, 20);
            this.tbDirectory.TabIndex = 5;
            // 
            // gbSortingOptions
            // 
            this.gbSortingOptions.Controls.Add(this.rbSortByFileSize);
            this.gbSortingOptions.Controls.Add(this.rbSortByFileName);
            this.gbSortingOptions.Controls.Add(this.rbSortByFileType);
            this.gbSortingOptions.Controls.Add(this.rbSortByFilePath);
            this.gbSortingOptions.Location = new System.Drawing.Point(12, 39);
            this.gbSortingOptions.Name = "gbSortingOptions";
            this.gbSortingOptions.Size = new System.Drawing.Size(99, 125);
            this.gbSortingOptions.TabIndex = 6;
            this.gbSortingOptions.TabStop = false;
            this.gbSortingOptions.Text = "Sorting Options";
            // 
            // rbSortByFileSize
            // 
            this.rbSortByFileSize.AutoSize = true;
            this.rbSortByFileSize.Location = new System.Drawing.Point(6, 65);
            this.rbSortByFileSize.Name = "rbSortByFileSize";
            this.rbSortByFileSize.Size = new System.Drawing.Size(64, 17);
            this.rbSortByFileSize.TabIndex = 5;
            this.rbSortByFileSize.Text = "File Size";
            this.rbSortByFileSize.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(495, 39);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(84, 23);
            this.btnGo.TabIndex = 7;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // gbSortAscDesc
            // 
            this.gbSortAscDesc.Controls.Add(this.rbSortByAscending);
            this.gbSortAscDesc.Controls.Add(this.rbSortByDescending);
            this.gbSortAscDesc.Location = new System.Drawing.Point(127, 39);
            this.gbSortAscDesc.Name = "gbSortAscDesc";
            this.gbSortAscDesc.Size = new System.Drawing.Size(191, 49);
            this.gbSortAscDesc.TabIndex = 7;
            this.gbSortAscDesc.TabStop = false;
            this.gbSortAscDesc.Text = "Ascending/Descending Sorting";
            // 
            // rbSortByAscending
            // 
            this.rbSortByAscending.AutoSize = true;
            this.rbSortByAscending.Checked = true;
            this.rbSortByAscending.Location = new System.Drawing.Point(6, 19);
            this.rbSortByAscending.Name = "rbSortByAscending";
            this.rbSortByAscending.Size = new System.Drawing.Size(75, 17);
            this.rbSortByAscending.TabIndex = 3;
            this.rbSortByAscending.TabStop = true;
            this.rbSortByAscending.Text = "Ascending";
            this.rbSortByAscending.UseVisualStyleBackColor = true;
            // 
            // rbSortByDescending
            // 
            this.rbSortByDescending.AutoSize = true;
            this.rbSortByDescending.Location = new System.Drawing.Point(87, 19);
            this.rbSortByDescending.Name = "rbSortByDescending";
            this.rbSortByDescending.Size = new System.Drawing.Size(82, 17);
            this.rbSortByDescending.TabIndex = 4;
            this.rbSortByDescending.Text = "Descending";
            this.rbSortByDescending.UseVisualStyleBackColor = true;
            // 
            // DirectoryScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 215);
            this.Controls.Add(this.gbSortAscDesc);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.gbSortingOptions);
            this.Controls.Add(this.tbDirectory);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnBrowse);
            this.Name = "DirectoryScanner";
            this.Text = "Directory Scanner";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbSortingOptions.ResumeLayout(false);
            this.gbSortingOptions.PerformLayout();
            this.gbSortAscDesc.ResumeLayout(false);
            this.gbSortAscDesc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.OpenFileDialog ofdBrowse;
        private System.Windows.Forms.RadioButton rbSortByFileType;
        private System.Windows.Forms.RadioButton rbSortByFileName;
        private System.Windows.Forms.RadioButton rbSortByFilePath;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.GroupBox gbSortingOptions;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.SaveFileDialog sfdSaveFile;
        private System.Windows.Forms.RadioButton rbSortByFileSize;
        private System.Windows.Forms.GroupBox gbSortAscDesc;
        private System.Windows.Forms.RadioButton rbSortByAscending;
        private System.Windows.Forms.RadioButton rbSortByDescending;
    }
}

