namespace ControlesPersonalizados.Editor_RTF
{
    partial class FrmConfTabla
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
            this.label2 = new System.Windows.Forms.Label();
            this.nudfilas = new System.Windows.Forms.NumericUpDown();
            this.nudcolumnas = new System.Windows.Forms.NumericUpDown();
            this.tlpbotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudfilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcolumnas)).BeginInit();
            this.tlpbotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Columnas";
            // 
            // nudfilas
            // 
            this.nudfilas.Location = new System.Drawing.Point(74, 2);
            this.nudfilas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudfilas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudfilas.Name = "nudfilas";
            this.nudfilas.Size = new System.Drawing.Size(96, 20);
            this.nudfilas.TabIndex = 2;
            this.nudfilas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudcolumnas
            // 
            this.nudcolumnas.Location = new System.Drawing.Point(74, 36);
            this.nudcolumnas.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudcolumnas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudcolumnas.Name = "nudcolumnas";
            this.nudcolumnas.Size = new System.Drawing.Size(96, 20);
            this.nudcolumnas.TabIndex = 3;
            this.nudcolumnas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tlpbotones
            // 
            this.tlpbotones.ColumnCount = 2;
            this.tlpbotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.93617F));
            this.tlpbotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.06383F));
            this.tlpbotones.Controls.Add(this.btnaceptar, 0, 0);
            this.tlpbotones.Controls.Add(this.btncancelar, 1, 0);
            this.tlpbotones.Location = new System.Drawing.Point(56, 87);
            this.tlpbotones.Name = "tlpbotones";
            this.tlpbotones.RowCount = 1;
            this.tlpbotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbotones.Size = new System.Drawing.Size(157, 29);
            this.tlpbotones.TabIndex = 4;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnaceptar.Location = new System.Drawing.Point(3, 3);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(70, 23);
            this.btnaceptar.TabIndex = 0;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btncancelar.Location = new System.Drawing.Point(79, 3);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(75, 23);
            this.btncancelar.TabIndex = 1;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // FrmConfTabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 120);
            this.Controls.Add(this.tlpbotones);
            this.Controls.Add(this.nudcolumnas);
            this.Controls.Add(this.nudfilas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConfTabla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla";
            ((System.ComponentModel.ISupportInitialize)(this.nudfilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudcolumnas)).EndInit();
            this.tlpbotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudfilas;
        private System.Windows.Forms.NumericUpDown nudcolumnas;
        private System.Windows.Forms.TableLayoutPanel tlpbotones;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.Button btncancelar;
    }
}