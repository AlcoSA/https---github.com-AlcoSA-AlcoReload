namespace Formulador.Formularios_Ayuda
{
    partial class FrmAyudanteFormulacion
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
            this.lbayudante = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbayudante
            // 
            this.lbayudante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbayudante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbayudante.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbayudante.FormattingEnabled = true;
            this.lbayudante.ItemHeight = 16;
            this.lbayudante.Location = new System.Drawing.Point(0, 0);
            this.lbayudante.Name = "lbayudante";
            this.lbayudante.Size = new System.Drawing.Size(157, 182);
            this.lbayudante.TabIndex = 1;
            this.lbayudante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbayudante_KeyDown);
            this.lbayudante.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbayudante_MouseDoubleClick);
            // 
            // FrmAyudanteFormulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(157, 182);
            this.Controls.Add(this.lbayudante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAyudanteFormulacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ayudante Formulacion";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.FrmAyudanteFormulacion_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAyudanteFormulacion_FormClosed);
            this.Load += new System.EventHandler(this.FrmAyudanteFormulacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox lbayudante;
    }
}