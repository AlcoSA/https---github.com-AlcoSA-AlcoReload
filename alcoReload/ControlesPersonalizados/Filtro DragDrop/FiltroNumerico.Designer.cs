namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FiltroNumerico
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
            this.btnbuscar = new System.Windows.Forms.Button();
            this.cbtipofiltro = new System.Windows.Forms.ComboBox();
            this.nudfiltro = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudfiltro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(172, 30);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(57, 23);
            this.btnbuscar.TabIndex = 4;
            this.btnbuscar.Text = "Filtrar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // cbtipofiltro
            // 
            this.cbtipofiltro.FormattingEnabled = true;
            this.cbtipofiltro.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            ">=",
            "<="});
            this.cbtipofiltro.Location = new System.Drawing.Point(63, 30);
            this.cbtipofiltro.Name = "cbtipofiltro";
            this.cbtipofiltro.Size = new System.Drawing.Size(103, 21);
            this.cbtipofiltro.TabIndex = 3;
            this.cbtipofiltro.SelectedIndexChanged += new System.EventHandler(this.cbtipofiltro_SelectedIndexChanged);
            // 
            // nudfiltro
            // 
            this.nudfiltro.Location = new System.Drawing.Point(4, 4);
            this.nudfiltro.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudfiltro.Minimum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            -2147483648});
            this.nudfiltro.Name = "nudfiltro";
            this.nudfiltro.Size = new System.Drawing.Size(228, 20);
            this.nudfiltro.TabIndex = 5;
            this.nudfiltro.ValueChanged += new System.EventHandler(this.nudfiltro_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo Filtro";
            // 
            // FiltroNumerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudfiltro);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.cbtipofiltro);
            this.Name = "FiltroNumerico";
            this.Size = new System.Drawing.Size(237, 56);
            ((System.ComponentModel.ISupportInitialize)(this.nudfiltro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.ComboBox cbtipofiltro;
        private System.Windows.Forms.NumericUpDown nudfiltro;
        private System.Windows.Forms.Label label1;
    }
}
