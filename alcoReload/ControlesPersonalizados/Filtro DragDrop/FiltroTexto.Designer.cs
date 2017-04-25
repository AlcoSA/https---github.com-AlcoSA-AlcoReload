namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FiltroTexto
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
            this.txtfiltro = new System.Windows.Forms.TextBox();
            this.cbtipofiltro = new System.Windows.Forms.ComboBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtfiltro
            // 
            this.txtfiltro.Location = new System.Drawing.Point(4, 4);
            this.txtfiltro.Name = "txtfiltro";
            this.txtfiltro.Size = new System.Drawing.Size(229, 20);
            this.txtfiltro.TabIndex = 0;
            this.txtfiltro.TextChanged += new System.EventHandler(this.txtfiltro_TextChanged);
            // 
            // cbtipofiltro
            // 
            this.cbtipofiltro.FormattingEnabled = true;
            this.cbtipofiltro.Items.AddRange(new object[] {
            "COINCIDENCIA",
            "EXACTA"});
            this.cbtipofiltro.Location = new System.Drawing.Point(62, 31);
            this.cbtipofiltro.Name = "cbtipofiltro";
            this.cbtipofiltro.Size = new System.Drawing.Size(109, 21);
            this.cbtipofiltro.TabIndex = 1;
            this.cbtipofiltro.SelectedIndexChanged += new System.EventHandler(this.cbtipofiltro_SelectedIndexChanged);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(177, 29);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(56, 23);
            this.btnbuscar.TabIndex = 2;
            this.btnbuscar.Text = "Filtrar";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tipo Filtro";
            // 
            // FiltroTexto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.cbtipofiltro);
            this.Controls.Add(this.txtfiltro);
            this.Name = "FiltroTexto";
            this.Size = new System.Drawing.Size(238, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfiltro;
        private System.Windows.Forms.ComboBox cbtipofiltro;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.Label label1;
    }
}
