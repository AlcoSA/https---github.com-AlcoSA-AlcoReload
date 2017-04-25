namespace DXF
{
    partial class CargadorDXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargadorDXF));
            this.pbdxf = new System.Windows.Forms.PictureBox();
            this.btnzoommas = new System.Windows.Forms.Button();
            this.btnzoommenos = new System.Windows.Forms.Button();
            this.btnnormalizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbdxf)).BeginInit();
            this.SuspendLayout();
            // 
            // pbdxf
            // 
            this.pbdxf.BackColor = System.Drawing.Color.White;
            this.pbdxf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbdxf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbdxf.Location = new System.Drawing.Point(0, 0);
            this.pbdxf.Name = "pbdxf";
            this.pbdxf.Size = new System.Drawing.Size(210, 189);
            this.pbdxf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbdxf.TabIndex = 0;
            this.pbdxf.TabStop = false;
            this.pbdxf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseDown);
            this.pbdxf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseMove);
            this.pbdxf.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseUp);
            // 
            // btnzoommas
            // 
            this.btnzoommas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnzoommas.BackColor = System.Drawing.Color.White;
            this.btnzoommas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnzoommas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzoommas.Image = ((System.Drawing.Image)(resources.GetObject("btnzoommas.Image")));
            this.btnzoommas.Location = new System.Drawing.Point(186, 3);
            this.btnzoommas.Name = "btnzoommas";
            this.btnzoommas.Size = new System.Drawing.Size(20, 20);
            this.btnzoommas.TabIndex = 1;
            this.btnzoommas.UseVisualStyleBackColor = false;
            this.btnzoommas.Click += new System.EventHandler(this.btnzoommas_Click);
            // 
            // btnzoommenos
            // 
            this.btnzoommenos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnzoommenos.BackColor = System.Drawing.Color.White;
            this.btnzoommenos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnzoommenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnzoommenos.Image = ((System.Drawing.Image)(resources.GetObject("btnzoommenos.Image")));
            this.btnzoommenos.Location = new System.Drawing.Point(186, 25);
            this.btnzoommenos.Name = "btnzoommenos";
            this.btnzoommenos.Size = new System.Drawing.Size(20, 20);
            this.btnzoommenos.TabIndex = 2;
            this.btnzoommenos.UseVisualStyleBackColor = false;
            this.btnzoommenos.Click += new System.EventHandler(this.btnzoommenos_Click);
            // 
            // btnnormalizar
            // 
            this.btnnormalizar.BackColor = System.Drawing.Color.White;
            this.btnnormalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnnormalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnnormalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnnormalizar.Image")));
            this.btnnormalizar.Location = new System.Drawing.Point(3, 3);
            this.btnnormalizar.Name = "btnnormalizar";
            this.btnnormalizar.Size = new System.Drawing.Size(20, 20);
            this.btnnormalizar.TabIndex = 3;
            this.btnnormalizar.UseVisualStyleBackColor = false;
            this.btnnormalizar.Click += new System.EventHandler(this.btnnormalizar_Click);
            // 
            // CargadorDXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnnormalizar);
            this.Controls.Add(this.btnzoommenos);
            this.Controls.Add(this.btnzoommas);
            this.Controls.Add(this.pbdxf);
            this.Name = "CargadorDXF";
            this.Size = new System.Drawing.Size(210, 189);
            ((System.ComponentModel.ISupportInitialize)(this.pbdxf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbdxf;
        private System.Windows.Forms.Button btnzoommas;
        private System.Windows.Forms.Button btnzoommenos;
        private System.Windows.Forms.Button btnnormalizar;
    }
}
