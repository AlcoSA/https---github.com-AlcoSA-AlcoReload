namespace ControlesPersonalizados
{
    partial class VisorDXFBasico
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
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.tlpencabezado = new System.Windows.Forms.TableLayoutPanel();
            this.lbdescripcion = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.pbcargadxf = new DXF.CargadorDXF();
            this.tlpbonotenera = new System.Windows.Forms.TableLayoutPanel();
            this.btncargar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.tlpgeneral.SuspendLayout();
            this.tlpencabezado.SuspendLayout();
            this.tlpbonotenera.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpgeneral
            // 
            this.tlpgeneral.ColumnCount = 1;
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpgeneral.Controls.Add(this.tlpencabezado, 0, 0);
            this.tlpgeneral.Controls.Add(this.pbcargadxf, 0, 1);
            this.tlpgeneral.Controls.Add(this.tlpbonotenera, 0, 2);
            this.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpgeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 3;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.85714F));
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.14286F));
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlpgeneral.Size = new System.Drawing.Size(240, 210);
            this.tlpgeneral.TabIndex = 1;
            // 
            // tlpencabezado
            // 
            this.tlpencabezado.ColumnCount = 2;
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.51389F));
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.48611F));
            this.tlpencabezado.Controls.Add(this.lbdescripcion, 0, 0);
            this.tlpencabezado.Controls.Add(this.txtdescripcion, 1, 0);
            this.tlpencabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpencabezado.Location = new System.Drawing.Point(3, 3);
            this.tlpencabezado.Name = "tlpencabezado";
            this.tlpencabezado.RowCount = 1;
            this.tlpencabezado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpencabezado.Size = new System.Drawing.Size(234, 25);
            this.tlpencabezado.TabIndex = 2;
            // 
            // lbdescripcion
            // 
            this.lbdescripcion.AutoSize = true;
            this.lbdescripcion.Location = new System.Drawing.Point(3, 0);
            this.lbdescripcion.Name = "lbdescripcion";
            this.lbdescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbdescripcion.TabIndex = 0;
            this.lbdescripcion.Text = "Descripción";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtdescripcion.Location = new System.Drawing.Point(72, 3);
            this.txtdescripcion.MaxLength = 20;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(159, 20);
            this.txtdescripcion.TabIndex = 1;
            // 
            // pbcargadxf
            // 
            this.pbcargadxf.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbcargadxf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbcargadxf.Location = new System.Drawing.Point(3, 34);
            this.pbcargadxf.Name = "pbcargadxf";
            this.pbcargadxf.RutaDXF = "";
            this.pbcargadxf.Size = new System.Drawing.Size(234, 139);
            this.pbcargadxf.TabIndex = 0;
            this.pbcargadxf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pbcargadxf_KeyDown);
            // 
            // tlpbonotenera
            // 
            this.tlpbonotenera.ColumnCount = 2;
            this.tlpbonotenera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbonotenera.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbonotenera.Controls.Add(this.btncargar, 0, 0);
            this.tlpbonotenera.Controls.Add(this.btneliminar, 1, 0);
            this.tlpbonotenera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpbonotenera.Location = new System.Drawing.Point(3, 179);
            this.tlpbonotenera.Name = "tlpbonotenera";
            this.tlpbonotenera.RowCount = 1;
            this.tlpbonotenera.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpbonotenera.Size = new System.Drawing.Size(234, 28);
            this.tlpbonotenera.TabIndex = 1;
            // 
            // btncargar
            // 
            this.btncargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btncargar.Location = new System.Drawing.Point(3, 3);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(111, 22);
            this.btncargar.TabIndex = 0;
            this.btncargar.Text = "Cargar";
            this.btncargar.UseVisualStyleBackColor = true;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btneliminar.Location = new System.Drawing.Point(120, 3);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(111, 22);
            this.btneliminar.TabIndex = 1;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // VisorDXFBasico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpgeneral);
            this.Name = "VisorDXFBasico";
            this.Size = new System.Drawing.Size(240, 210);
            this.tlpgeneral.ResumeLayout(false);
            this.tlpencabezado.ResumeLayout(false);
            this.tlpencabezado.PerformLayout();
            this.tlpbonotenera.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DXF.CargadorDXF pbcargadxf;
        private System.Windows.Forms.TableLayoutPanel tlpgeneral;
        private System.Windows.Forms.TableLayoutPanel tlpbonotenera;
        private System.Windows.Forms.TableLayoutPanel tlpencabezado;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Label lbdescripcion;
        private System.Windows.Forms.TextBox txtdescripcion;
    }
}
