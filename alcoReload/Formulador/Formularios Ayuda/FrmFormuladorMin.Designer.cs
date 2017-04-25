namespace Formulador.Formularios_Ayuda
{
    partial class FrmFormuladorMin
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
            this.rtbformulador = new RichTextBoxSintaxHighLight.RichtTexboxSyntax();
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.btncancelar = new System.Windows.Forms.Button();
            this.tlpgeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbformulador
            // 
            this.rtbformulador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbformulador.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbformulador.Location = new System.Drawing.Point(0, 0);
            this.rtbformulador.MaxLength = 21474836;
            this.rtbformulador.Name = "rtbformulador";
            this.rtbformulador.Size = new System.Drawing.Size(306, 108);
            this.rtbformulador.TabIndex = 0;
            this.rtbformulador.Text = "";
            this.rtbformulador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbformulador_KeyUp);
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
            this.tlpgeneral.Location = new System.Drawing.Point(0, 108);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 1;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpgeneral.Size = new System.Drawing.Size(306, 29);
            this.tlpgeneral.TabIndex = 1;
            // 
            // btnaceptar
            // 
            this.btnaceptar.Location = new System.Drawing.Point(156, 3);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(67, 23);
            this.btnaceptar.TabIndex = 2;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.UseVisualStyleBackColor = true;
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btncancelar.Location = new System.Drawing.Point(232, 3);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(68, 23);
            this.btncancelar.TabIndex = 3;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // FrmFormuladorMin
            // 
            this.AcceptButton = this.btnaceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btncancelar;
            this.ClientSize = new System.Drawing.Size(306, 137);
            this.Controls.Add(this.rtbformulador);
            this.Controls.Add(this.tlpgeneral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFormuladorMin";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulador";
            this.Load += new System.EventHandler(this.FrmFormuladorCotas_Load);
            this.tlpgeneral.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal RichTextBoxSintaxHighLight.RichtTexboxSyntax rtbformulador;
        internal System.Windows.Forms.TableLayoutPanel tlpgeneral;
        internal System.Windows.Forms.Button btnaceptar;
        internal System.Windows.Forms.Button btncancelar;
    }
}