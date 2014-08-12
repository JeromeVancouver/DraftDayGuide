namespace DraftDayGuide
{
    partial class fmPlayerLookup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmPlayerLookup));
            this.dgPart = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPart
            // 
            this.dgPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPart.Location = new System.Drawing.Point(12, 12);
            this.dgPart.Name = "dgPart";
            this.dgPart.Size = new System.Drawing.Size(485, 368);
            this.dgPart.TabIndex = 0;
            this.dgPart.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPart_CellDoubleClick);
            this.dgPart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgPart_KeyPress);
            // 
            // fmPlayerLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 392);
            this.Controls.Add(this.dgPart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmPlayerLookup";
            this.Text = "Part Lookup";
            this.Load += new System.EventHandler(this.fmPartLookup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPart;
    }
}