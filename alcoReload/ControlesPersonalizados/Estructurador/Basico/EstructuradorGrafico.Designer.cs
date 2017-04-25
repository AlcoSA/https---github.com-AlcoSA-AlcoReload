namespace ControlesPersonalizados.Estructurador
{
    partial class EstructuradorGrafico
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
            this.SuspendLayout();
            // 
            // EstructuradorGrafico
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Name = "EstructuradorGrafico";
            this.Size = new System.Drawing.Size(420, 309);
            this.SizeChanged += new System.EventHandler(this.EstructuradorGrafico_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.EstructuradorGrafico_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.EstructuradorGrafico_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EstructuradorGrafico_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EstructuradorGrafico_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EstructuradorGrafico_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EstructuradorGrafico_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.EstructuradorGrafico_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
