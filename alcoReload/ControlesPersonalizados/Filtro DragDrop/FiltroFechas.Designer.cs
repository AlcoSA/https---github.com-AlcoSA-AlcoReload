namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FiltroFechas
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
            this.lbdesde = new System.Windows.Forms.Label();
            this.lbhasta = new System.Windows.Forms.Label();
            this.dtpdesde = new System.Windows.Forms.DateTimePicker();
            this.dtphasta = new System.Windows.Forms.DateTimePicker();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbdesde
            // 
            this.lbdesde.AutoSize = true;
            this.lbdesde.Location = new System.Drawing.Point(7, 15);
            this.lbdesde.Name = "lbdesde";
            this.lbdesde.Size = new System.Drawing.Size(38, 13);
            this.lbdesde.TabIndex = 0;
            this.lbdesde.Text = "Desde";
            // 
            // lbhasta
            // 
            this.lbhasta.AutoSize = true;
            this.lbhasta.Location = new System.Drawing.Point(7, 42);
            this.lbhasta.Name = "lbhasta";
            this.lbhasta.Size = new System.Drawing.Size(35, 13);
            this.lbhasta.TabIndex = 1;
            this.lbhasta.Text = "Hasta";
            // 
            // dtpdesde
            // 
            this.dtpdesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdesde.Location = new System.Drawing.Point(49, 7);
            this.dtpdesde.Name = "dtpdesde";
            this.dtpdesde.Size = new System.Drawing.Size(109, 20);
            this.dtpdesde.TabIndex = 2;
            this.dtpdesde.ValueChanged += new System.EventHandler(this.dtpdesde_ValueChanged);
            // 
            // dtphasta
            // 
            this.dtphasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtphasta.Location = new System.Drawing.Point(49, 34);
            this.dtphasta.Name = "dtphasta";
            this.dtphasta.Size = new System.Drawing.Size(109, 20);
            this.dtphasta.TabIndex = 3;
            this.dtphasta.ValueChanged += new System.EventHandler(this.dtphasta_ValueChanged);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Location = new System.Drawing.Point(164, 7);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(43, 47);
            this.btnbuscar.TabIndex = 4;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // FiltroFechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.dtphasta);
            this.Controls.Add(this.dtpdesde);
            this.Controls.Add(this.lbhasta);
            this.Controls.Add(this.lbdesde);
            this.Name = "FiltroFechas";
            this.Size = new System.Drawing.Size(217, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbdesde;
        private System.Windows.Forms.Label lbhasta;
        private System.Windows.Forms.DateTimePicker dtpdesde;
        private System.Windows.Forms.DateTimePicker dtphasta;
        private System.Windows.Forms.Button btnbuscar;
    }
}
