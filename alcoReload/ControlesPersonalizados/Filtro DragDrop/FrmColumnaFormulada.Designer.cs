namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FrmColumnaFormulada
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtxexpression = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flpcolumnas = new System.Windows.Forms.FlowLayoutPanel();
            this.txtnombrecolumna = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contenedorBtones = new System.Windows.Forms.TableLayoutPanel();
            this.btonAceptar = new System.Windows.Forms.Button();
            this.btonCancelar = new System.Windows.Forms.Button();
            this.lbposicion = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.contenedorBtones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expresión";
            // 
            // rtxexpression
            // 
            this.rtxexpression.Location = new System.Drawing.Point(15, 75);
            this.rtxexpression.Name = "rtxexpression";
            this.rtxexpression.Size = new System.Drawing.Size(410, 50);
            this.rtxexpression.TabIndex = 1;
            this.rtxexpression.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Columnas";
            // 
            // flpcolumnas
            // 
            this.flpcolumnas.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpcolumnas.Location = new System.Drawing.Point(18, 149);
            this.flpcolumnas.Name = "flpcolumnas";
            this.flpcolumnas.Size = new System.Drawing.Size(407, 63);
            this.flpcolumnas.TabIndex = 3;
            // 
            // txtnombrecolumna
            // 
            this.txtnombrecolumna.Location = new System.Drawing.Point(15, 35);
            this.txtnombrecolumna.Name = "txtnombrecolumna";
            this.txtnombrecolumna.Size = new System.Drawing.Size(410, 20);
            this.txtnombrecolumna.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre Columna";
            // 
            // contenedorBtones
            // 
            this.contenedorBtones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorBtones.ColumnCount = 2;
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6732F));
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3268F));
            this.contenedorBtones.Controls.Add(this.btonAceptar, 0, 0);
            this.contenedorBtones.Controls.Add(this.btonCancelar, 1, 0);
            this.contenedorBtones.Location = new System.Drawing.Point(430, 217);
            this.contenedorBtones.Name = "contenedorBtones";
            this.contenedorBtones.RowCount = 1;
            this.contenedorBtones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contenedorBtones.Size = new System.Drawing.Size(160, 29);
            this.contenedorBtones.TabIndex = 15;
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
            // lbposicion
            // 
            this.lbposicion.FormattingEnabled = true;
            this.lbposicion.Location = new System.Drawing.Point(453, 35);
            this.lbposicion.Name = "lbposicion";
            this.lbposicion.Size = new System.Drawing.Size(137, 173);
            this.lbposicion.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Posición";
            // 
            // FrmColumnaFormulada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 255);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbposicion);
            this.Controls.Add(this.contenedorBtones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtnombrecolumna);
            this.Controls.Add(this.flpcolumnas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtxexpression);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmColumnaFormulada";
            this.Text = "Columna Formulada";
            this.Load += new System.EventHandler(this.FrmColumnaFormulada_Load);
            this.contenedorBtones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxexpression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpcolumnas;
        private System.Windows.Forms.TextBox txtnombrecolumna;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TableLayoutPanel contenedorBtones;
        internal System.Windows.Forms.Button btonAceptar;
        internal System.Windows.Forms.Button btonCancelar;
        private System.Windows.Forms.ListBox lbposicion;
        private System.Windows.Forms.Label label4;
    }
}