namespace ControlesPersonalizados
{
    partial class BarradeProgresoPersonalizada
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
        public new void Dispose()
        {
            Dispose(true);

            System.GC.SuppressFinalize(this);

        }

        ~BarradeProgresoPersonalizada()
        {
            Dispose(false);
        }
        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbProcess = new System.Windows.Forms.Label();
            this.lbPorcentaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbProcess
            // 
            this.LbProcess.AutoSize = true;
            this.LbProcess.Location = new System.Drawing.Point(0, 136);
            this.LbProcess.Name = "LbProcess";
            this.LbProcess.Size = new System.Drawing.Size(0, 13);
            this.LbProcess.TabIndex = 0;
            // 
            // lbPorcentaje
            // 
            this.lbPorcentaje.AutoSize = true;
            this.lbPorcentaje.Location = new System.Drawing.Point(62, 64);
            this.lbPorcentaje.Name = "lbPorcentaje";
            this.lbPorcentaje.Size = new System.Drawing.Size(0, 13);
            this.lbPorcentaje.TabIndex = 1;
            // 
            // BarradeProgresoPersonalizada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbPorcentaje);
            this.Controls.Add(this.LbProcess);
            this.Name = "BarradeProgresoPersonalizada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbProcess;
        private System.Windows.Forms.Label lbPorcentaje;
    }
}
