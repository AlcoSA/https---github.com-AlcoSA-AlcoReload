namespace ControlesPersonalizados.Intellisens
{
    partial class FrmIntelisense
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
            this.dwintelisense = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dwintelisense)).BeginInit();
            this.SuspendLayout();
            // 
            // dwintelisense
            // 
            this.dwintelisense.AllowUserToAddRows = false;
            this.dwintelisense.AllowUserToDeleteRows = false;
            this.dwintelisense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dwintelisense.BackgroundColor = System.Drawing.Color.White;
            this.dwintelisense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dwintelisense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwintelisense.ColumnHeadersVisible = false;
            this.dwintelisense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwintelisense.Location = new System.Drawing.Point(0, 0);
            this.dwintelisense.Name = "dwintelisense";
            this.dwintelisense.ReadOnly = true;
            this.dwintelisense.RowHeadersVisible = false;
            this.dwintelisense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dwintelisense.Size = new System.Drawing.Size(327, 171);
            this.dwintelisense.TabIndex = 0;
            this.dwintelisense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dwintelisense_CellDoubleClick);
            this.dwintelisense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dwintelisense_KeyDown);
            // 
            // FrmIntelisense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 171);
            this.Controls.Add(this.dwintelisense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmIntelisense";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Intelisense";
            this.Deactivate += new System.EventHandler(this.FrmIntelisense_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIntelisense_FormClosed);
            this.Load += new System.EventHandler(this.FrmIntelisense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dwintelisense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dwintelisense;
    }
}