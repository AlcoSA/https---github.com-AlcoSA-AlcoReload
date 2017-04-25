namespace ControlesPersonalizados
{
    partial class ObservacionesenPlantilla
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObservacionesenPlantilla));
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.rtbobservacion = new System.Windows.Forms.RichTextBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.cbimprimir = new System.Windows.Forms.CheckBox();
            this.tlpgeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpgeneral
            // 
            this.tlpgeneral.ColumnCount = 3;
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.852217F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.10838F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.03941F));
            this.tlpgeneral.Controls.Add(this.rtbobservacion, 1, 0);
            this.tlpgeneral.Controls.Add(this.btncancel, 0, 0);
            this.tlpgeneral.Controls.Add(this.cbimprimir, 2, 0);
            this.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpgeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 1;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpgeneral.Size = new System.Drawing.Size(434, 59);
            this.tlpgeneral.TabIndex = 0;
            // 
            // rtbobservacion
            // 
            this.rtbobservacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbobservacion.Location = new System.Drawing.Point(45, 3);
            this.rtbobservacion.MaxLength = 255;
            this.rtbobservacion.Name = "rtbobservacion";
            this.rtbobservacion.Size = new System.Drawing.Size(324, 53);
            this.rtbobservacion.TabIndex = 0;
            this.rtbobservacion.Text = "";
            // 
            // btncancel
            // 
            this.btncancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btncancel.Image = ((System.Drawing.Image)(resources.GetObject("btncancel.Image")));
            this.btncancel.Location = new System.Drawing.Point(3, 16);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(36, 27);
            this.btncancel.TabIndex = 1;
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // cbimprimir
            // 
            this.cbimprimir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbimprimir.AutoSize = true;
            this.cbimprimir.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cbimprimir.Location = new System.Drawing.Point(382, 13);
            this.cbimprimir.Name = "cbimprimir";
            this.cbimprimir.Size = new System.Drawing.Size(49, 32);
            this.cbimprimir.TabIndex = 2;
            this.cbimprimir.Text = "Imprimir";
            this.cbimprimir.UseCompatibleTextRendering = true;
            this.cbimprimir.UseVisualStyleBackColor = true;
            // 
            // ObservacionesenPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpgeneral);
            this.Name = "ObservacionesenPlantilla";
            this.Size = new System.Drawing.Size(434, 59);
            this.tlpgeneral.ResumeLayout(false);
            this.tlpgeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpgeneral;
        private System.Windows.Forms.RichTextBox rtbobservacion;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.CheckBox cbimprimir;
    }
}
