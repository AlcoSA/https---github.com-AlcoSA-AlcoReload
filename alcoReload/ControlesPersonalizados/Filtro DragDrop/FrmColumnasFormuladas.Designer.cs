namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FrmColumnasFormuladas
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
            this.contenedorBtones = new System.Windows.Forms.TableLayoutPanel();
            this.btonAceptar = new System.Windows.Forms.Button();
            this.btonCancelar = new System.Windows.Forms.Button();
            this.lbcolumnasformuladas = new System.Windows.Forms.ListBox();
            this.contenedorBtones.SuspendLayout();
            this.SuspendLayout();
            // 
            // contenedorBtones
            // 
            this.contenedorBtones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorBtones.ColumnCount = 2;
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6732F));
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3268F));
            this.contenedorBtones.Controls.Add(this.btonAceptar, 0, 0);
            this.contenedorBtones.Controls.Add(this.btonCancelar, 1, 0);
            this.contenedorBtones.Location = new System.Drawing.Point(54, 249);
            this.contenedorBtones.Name = "contenedorBtones";
            this.contenedorBtones.RowCount = 1;
            this.contenedorBtones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contenedorBtones.Size = new System.Drawing.Size(160, 29);
            this.contenedorBtones.TabIndex = 16;
            // 
            // btonAceptar
            // 
            this.btonAceptar.Location = new System.Drawing.Point(3, 3);
            this.btonAceptar.Name = "btonAceptar";
            this.btonAceptar.Size = new System.Drawing.Size(73, 23);
            this.btonAceptar.TabIndex = 0;
            this.btonAceptar.Text = "Aceptar";
            this.btonAceptar.UseVisualStyleBackColor = true;
            this.btonAceptar.Click += new System.EventHandler(this.btonAceptar_Click);
            // 
            // btonCancelar
            // 
            this.btonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btonCancelar.Location = new System.Drawing.Point(82, 3);
            this.btonCancelar.Name = "btonCancelar";
            this.btonCancelar.Size = new System.Drawing.Size(75, 23);
            this.btonCancelar.TabIndex = 1;
            this.btonCancelar.Text = "Cancelar";
            this.btonCancelar.UseVisualStyleBackColor = true;
            this.btonCancelar.Click += new System.EventHandler(this.btonCancelar_Click);
            // 
            // lbcolumnasformuladas
            // 
            this.lbcolumnasformuladas.FormattingEnabled = true;
            this.lbcolumnasformuladas.Items.AddRange(new object[] {
            "Nueva"});
            this.lbcolumnasformuladas.Location = new System.Drawing.Point(13, 13);
            this.lbcolumnasformuladas.Name = "lbcolumnasformuladas";
            this.lbcolumnasformuladas.Size = new System.Drawing.Size(198, 225);
            this.lbcolumnasformuladas.TabIndex = 17;
            this.lbcolumnasformuladas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbcolumnasformuladas_KeyDown);
            // 
            // FrmColumnasFormuladas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 290);
            this.Controls.Add(this.lbcolumnasformuladas);
            this.Controls.Add(this.contenedorBtones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmColumnasFormuladas";
            this.Text = "Columnas Formuladas";
            this.Load += new System.EventHandler(this.FrmColumnasFormuladas_Load);
            this.contenedorBtones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel contenedorBtones;
        internal System.Windows.Forms.Button btonAceptar;
        internal System.Windows.Forms.Button btonCancelar;
        private System.Windows.Forms.ListBox lbcolumnasformuladas;
    }
}