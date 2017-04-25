namespace ControlesPersonalizados.Estructurador
{
    partial class FrmCambioValorCota
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
            this.nudvalorcota = new System.Windows.Forms.NumericUpDown();
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudvalorcota)).BeginInit();
            this.tlpgeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudvalorcota
            // 
            this.nudvalorcota.Location = new System.Drawing.Point(91, 12);
            this.nudvalorcota.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nudvalorcota.Name = "nudvalorcota";
            this.nudvalorcota.Size = new System.Drawing.Size(153, 20);
            this.nudvalorcota.TabIndex = 0;
            // 
            // tlpgeneral
            // 
            this.tlpgeneral.ColumnCount = 3;
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.57895F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0081F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0081F));
            this.tlpgeneral.Controls.Add(this.btnaceptar, 1, 0);
            this.tlpgeneral.Controls.Add(this.btncancelar, 2, 0);
            this.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpgeneral.Location = new System.Drawing.Point(0, 54);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 1;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpgeneral.Size = new System.Drawing.Size(247, 27);
            this.tlpgeneral.TabIndex = 4;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnaceptar.Location = new System.Drawing.Point(81, 3);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(78, 21);
            this.btnaceptar.TabIndex = 2;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btncancelar.Location = new System.Drawing.Point(165, 3);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(79, 21);
            this.btncancelar.TabIndex = 3;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Valor Cota";
            // 
            // FrmCambioValorCota
            // 
            this.AcceptButton = this.btnaceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(247, 81);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tlpgeneral);
            this.Controls.Add(this.nudvalorcota);
            this.Name = "FrmCambioValorCota";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Valor Cota";
            ((System.ComponentModel.ISupportInitialize)(this.nudvalorcota)).EndInit();
            this.tlpgeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudvalorcota;
        internal System.Windows.Forms.TableLayoutPanel tlpgeneral;
        internal System.Windows.Forms.Button btnaceptar;
        internal System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label label1;
    }
}