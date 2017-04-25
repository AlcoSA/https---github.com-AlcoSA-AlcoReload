namespace ControlesPersonalizados.Estructurador
{
    partial class FrmDivisionesEstructura
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
            this.gborientacion = new System.Windows.Forms.GroupBox();
            this.rbhorizontal = new System.Windows.Forms.RadioButton();
            this.rbvertical = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.nudDivisiones = new System.Windows.Forms.NumericUpDown();
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.gborientacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivisiones)).BeginInit();
            this.tlpgeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // gborientacion
            // 
            this.gborientacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gborientacion.Controls.Add(this.rbvertical);
            this.gborientacion.Controls.Add(this.rbhorizontal);
            this.gborientacion.Location = new System.Drawing.Point(12, 13);
            this.gborientacion.Name = "gborientacion";
            this.gborientacion.Size = new System.Drawing.Size(230, 77);
            this.gborientacion.TabIndex = 0;
            this.gborientacion.TabStop = false;
            this.gborientacion.Text = "Orientación";
            // 
            // rbhorizontal
            // 
            this.rbhorizontal.AutoSize = true;
            this.rbhorizontal.Checked = true;
            this.rbhorizontal.Location = new System.Drawing.Point(21, 29);
            this.rbhorizontal.Name = "rbhorizontal";
            this.rbhorizontal.Size = new System.Drawing.Size(72, 17);
            this.rbhorizontal.TabIndex = 0;
            this.rbhorizontal.TabStop = true;
            this.rbhorizontal.Text = "Horizontal";
            this.rbhorizontal.UseVisualStyleBackColor = true;
            // 
            // rbvertical
            // 
            this.rbvertical.AutoSize = true;
            this.rbvertical.Location = new System.Drawing.Point(139, 29);
            this.rbvertical.Name = "rbvertical";
            this.rbvertical.Size = new System.Drawing.Size(60, 17);
            this.rbvertical.TabIndex = 1;
            this.rbvertical.Text = "Vertical";
            this.rbvertical.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero Divisiones";
            // 
            // nudDivisiones
            // 
            this.nudDivisiones.Location = new System.Drawing.Point(15, 110);
            this.nudDivisiones.Name = "nudDivisiones";
            this.nudDivisiones.Size = new System.Drawing.Size(120, 20);
            this.nudDivisiones.TabIndex = 2;
            // 
            // tlpgeneral
            // 
            this.tlpgeneral.ColumnCount = 3;
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpgeneral.Controls.Add(this.btnaceptar, 1, 0);
            this.tlpgeneral.Controls.Add(this.btncancelar, 2, 0);
            this.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpgeneral.Location = new System.Drawing.Point(0, 152);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 1;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpgeneral.Size = new System.Drawing.Size(254, 29);
            this.tlpgeneral.TabIndex = 3;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(130, 3);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(57, 23);
            this.btnaceptar.TabIndex = 2;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancelar.Location = new System.Drawing.Point(193, 3);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(58, 23);
            this.btncancelar.TabIndex = 3;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // FrmDivisionesEstructura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 181);
            this.Controls.Add(this.tlpgeneral);
            this.Controls.Add(this.nudDivisiones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gborientacion);
            this.Name = "FrmDivisionesEstructura";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Divisiones Estructura";
            this.gborientacion.ResumeLayout(false);
            this.gborientacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDivisiones)).EndInit();
            this.tlpgeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gborientacion;
        private System.Windows.Forms.RadioButton rbvertical;
        private System.Windows.Forms.RadioButton rbhorizontal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDivisiones;
        internal System.Windows.Forms.TableLayoutPanel tlpgeneral;
        internal System.Windows.Forms.Button btnaceptar;
        internal System.Windows.Forms.Button btncancelar;
    }
}