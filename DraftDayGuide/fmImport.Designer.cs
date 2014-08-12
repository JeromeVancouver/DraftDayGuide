namespace DraftDayGuide
{
    partial class fmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmImport));
            this.label1 = new System.Windows.Forms.Label();
            this.dgCWTable = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbExcelTable = new System.Windows.Forms.ComboBox();
            this.btOpenFile = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgCWTransfer = new System.Windows.Forms.DataGridView();
            this.dgXLTable = new System.Windows.Forms.DataGridView();
            this.dgXLTransfer = new System.Windows.Forms.DataGridView();
            this.btXLTransfer = new System.Windows.Forms.Button();
            this.btCWTransfer = new System.Windows.Forms.Button();
            this.odExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.btImport = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgCWTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCWTransfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgXLTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgXLTransfer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Table";
            // 
            // dgCWTable
            // 
            this.dgCWTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCWTable.Location = new System.Drawing.Point(12, 64);
            this.dgCWTable.Name = "dgCWTable";
            this.dgCWTable.Size = new System.Drawing.Size(225, 295);
            this.dgCWTable.TabIndex = 35;
            this.dgCWTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCWTable_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(700, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Table";
            // 
            // cbExcelTable
            // 
            this.cbExcelTable.FormattingEnabled = true;
            this.cbExcelTable.Location = new System.Drawing.Point(754, 30);
            this.cbExcelTable.Name = "cbExcelTable";
            this.cbExcelTable.Size = new System.Drawing.Size(244, 21);
            this.cbExcelTable.TabIndex = 36;
            this.cbExcelTable.SelectedIndexChanged += new System.EventHandler(this.cbExcelTable_SelectedIndexChanged);
            // 
            // btOpenFile
            // 
            this.btOpenFile.Location = new System.Drawing.Point(976, 3);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(22, 21);
            this.btOpenFile.TabIndex = 122;
            this.btOpenFile.Text = "..";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(754, 4);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(216, 20);
            this.tbFileName.TabIndex = 121;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(700, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 20);
            this.label14.TabIndex = 120;
            this.label14.Text = "File";
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(97, 30);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(244, 21);
            this.cbTable.TabIndex = 123;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 124;
            this.label3.Text = "Database";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(97, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 125;
            this.label4.Text = "CW";
            // 
            // dgCWTransfer
            // 
            this.dgCWTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCWTransfer.Location = new System.Drawing.Point(277, 64);
            this.dgCWTransfer.Name = "dgCWTransfer";
            this.dgCWTransfer.Size = new System.Drawing.Size(225, 295);
            this.dgCWTransfer.TabIndex = 126;
            // 
            // dgXLTable
            // 
            this.dgXLTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgXLTable.Location = new System.Drawing.Point(773, 64);
            this.dgXLTable.Name = "dgXLTable";
            this.dgXLTable.Size = new System.Drawing.Size(225, 295);
            this.dgXLTable.TabIndex = 128;
            this.dgXLTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgExcel_CellClick);
            // 
            // dgXLTransfer
            // 
            this.dgXLTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgXLTransfer.Location = new System.Drawing.Point(508, 64);
            this.dgXLTransfer.Name = "dgXLTransfer";
            this.dgXLTransfer.Size = new System.Drawing.Size(225, 295);
            this.dgXLTransfer.TabIndex = 127;
            // 
            // btXLTransfer
            // 
            this.btXLTransfer.Location = new System.Drawing.Point(739, 185);
            this.btXLTransfer.Name = "btXLTransfer";
            this.btXLTransfer.Size = new System.Drawing.Size(28, 22);
            this.btXLTransfer.TabIndex = 129;
            this.btXLTransfer.Text = "<--";
            this.btXLTransfer.UseVisualStyleBackColor = true;
            this.btXLTransfer.Click += new System.EventHandler(this.btXLTransfer_Click);
            // 
            // btCWTransfer
            // 
            this.btCWTransfer.Location = new System.Drawing.Point(243, 185);
            this.btCWTransfer.Name = "btCWTransfer";
            this.btCWTransfer.Size = new System.Drawing.Size(28, 22);
            this.btCWTransfer.TabIndex = 130;
            this.btCWTransfer.Text = "-->";
            this.btCWTransfer.UseVisualStyleBackColor = true;
            this.btCWTransfer.Click += new System.EventHandler(this.btCWTransfer_Click);
            // 
            // odExcelFile
            // 
            this.odExcelFile.FileName = "openFileDialog1";
            // 
            // btImport
            // 
            this.btImport.Location = new System.Drawing.Point(467, 365);
            this.btImport.Name = "btImport";
            this.btImport.Size = new System.Drawing.Size(75, 23);
            this.btImport.TabIndex = 131;
            this.btImport.Text = "Import";
            this.btImport.UseVisualStyleBackColor = true;
            this.btImport.Click += new System.EventHandler(this.btImport_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(277, 366);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(184, 20);
            this.tbName.TabIndex = 132;
            // 
            // fmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 397);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btImport);
            this.Controls.Add(this.btCWTransfer);
            this.Controls.Add(this.btXLTransfer);
            this.Controls.Add(this.dgXLTable);
            this.Controls.Add(this.dgXLTransfer);
            this.Controls.Add(this.dgCWTransfer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.btOpenFile);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbExcelTable);
            this.Controls.Add(this.dgCWTable);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmImport";
            this.Text = "Import Tool";
            this.Load += new System.EventHandler(this.fmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCWTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCWTransfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgXLTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgXLTransfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgCWTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbExcelTable;
        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgCWTransfer;
        private System.Windows.Forms.DataGridView dgXLTable;
        private System.Windows.Forms.DataGridView dgXLTransfer;
        private System.Windows.Forms.Button btXLTransfer;
        private System.Windows.Forms.Button btCWTransfer;
        private System.Windows.Forms.OpenFileDialog odExcelFile;
        private System.Windows.Forms.Button btImport;
        private System.Windows.Forms.TextBox tbName;
    }
}