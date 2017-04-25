namespace ControlesPersonalizados
{
    partial class DibujosPlantilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DibujosPlantilla));
            this.tlpContenedor = new System.Windows.Forms.TableLayoutPanel();
            this.tlpencabezado = new System.Windows.Forms.TableLayoutPanel();
            this.lbpredeterminado = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.txtpredeterminado = new System.Windows.Forms.TextBox();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnformular = new System.Windows.Forms.Button();
            this.cbplantillavidrio = new System.Windows.Forms.CheckBox();
            this.dDxf = new DXF.DibujanteDXF();
            this.tlpContenedor.SuspendLayout();
            this.tlpencabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContenedor
            // 
            this.tlpContenedor.ColumnCount = 1;
            this.tlpContenedor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tlpContenedor.Controls.Add(this.tlpencabezado, 0, 0);
            this.tlpContenedor.Controls.Add(this.dDxf, 0, 1);
            this.tlpContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedor.Location = new System.Drawing.Point(0, 0);
            this.tlpContenedor.Name = "tlpContenedor";
            this.tlpContenedor.RowCount = 2;
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.16867F));
            this.tlpContenedor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.83132F));
            this.tlpContenedor.Size = new System.Drawing.Size(482, 408);
            this.tlpContenedor.TabIndex = 0;
            // 
            // tlpencabezado
            // 
            this.tlpencabezado.ColumnCount = 4;
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.07712F));
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.92288F));
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpencabezado.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tlpencabezado.Controls.Add(this.lbpredeterminado, 0, 1);
            this.tlpencabezado.Controls.Add(this.lbNombre, 0, 0);
            this.tlpencabezado.Controls.Add(this.txtnombre, 1, 0);
            this.tlpencabezado.Controls.Add(this.txtpredeterminado, 1, 1);
            this.tlpencabezado.Controls.Add(this.btncancelar, 3, 0);
            this.tlpencabezado.Controls.Add(this.btnformular, 2, 1);
            this.tlpencabezado.Controls.Add(this.cbplantillavidrio, 3, 1);
            this.tlpencabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpencabezado.Location = new System.Drawing.Point(3, 3);
            this.tlpencabezado.Name = "tlpencabezado";
            this.tlpencabezado.RowCount = 2;
            this.tlpencabezado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpencabezado.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpencabezado.Size = new System.Drawing.Size(476, 64);
            this.tlpencabezado.TabIndex = 0;
            // 
            // lbpredeterminado
            // 
            this.lbpredeterminado.AutoSize = true;
            this.lbpredeterminado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbpredeterminado.Location = new System.Drawing.Point(3, 39);
            this.lbpredeterminado.Name = "lbpredeterminado";
            this.lbpredeterminado.Size = new System.Drawing.Size(86, 25);
            this.lbpredeterminado.TabIndex = 3;
            this.lbpredeterminado.Text = "Predeterminado";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(3, 0);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(58, 15);
            this.lbNombre.TabIndex = 0;
            this.lbNombre.Text = "Nombre";
            // 
            // txtnombre
            // 
            this.tlpencabezado.SetColumnSpan(this.txtnombre, 2);
            this.txtnombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnombre.Location = new System.Drawing.Point(100, 3);
            this.txtnombre.MaxLength = 30;
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(255, 20);
            this.txtnombre.TabIndex = 1;
            // 
            // txtpredeterminado
            // 
            this.txtpredeterminado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpredeterminado.Location = new System.Drawing.Point(100, 42);
            this.txtpredeterminado.Name = "txtpredeterminado";
            this.txtpredeterminado.Size = new System.Drawing.Size(220, 20);
            this.txtpredeterminado.TabIndex = 4;
            this.txtpredeterminado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpredeterminado_KeyDown);
            // 
            // btncancelar
            // 
            this.btncancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncancelar.BackgroundImage")));
            this.btncancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btncancelar.Location = new System.Drawing.Point(361, 3);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(32, 30);
            this.btncancelar.TabIndex = 2;
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnformular
            // 
            this.btnformular.Location = new System.Drawing.Point(326, 42);
            this.btnformular.Name = "btnformular";
            this.btnformular.Size = new System.Drawing.Size(28, 19);
            this.btnformular.TabIndex = 5;
            this.btnformular.Text = "...";
            this.btnformular.UseVisualStyleBackColor = true;
            this.btnformular.Click += new System.EventHandler(this.btnformular_Click);
            // 
            // cbplantillavidrio
            // 
            this.cbplantillavidrio.AutoSize = true;
            this.cbplantillavidrio.Location = new System.Drawing.Point(361, 42);
            this.cbplantillavidrio.Name = "cbplantillavidrio";
            this.cbplantillavidrio.Size = new System.Drawing.Size(91, 17);
            this.cbplantillavidrio.TabIndex = 6;
            this.cbplantillavidrio.Text = "Plantilla Vidrio";
            this.cbplantillavidrio.UseVisualStyleBackColor = true;
            this.cbplantillavidrio.CheckedChanged += new System.EventHandler(this.cbplantillavidrio_CheckedChanged);
            // 
            // dDxf
            // 
            this.dDxf.Analizador = null;
            this.dDxf.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.dDxf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dDxf.IgnorarFactorVisibilidad = true;
            this.dDxf.Location = new System.Drawing.Point(3, 73);
            this.dDxf.Name = "dDxf";
            this.dDxf.Size = new System.Drawing.Size(476, 332);
            this.dDxf.SoloLectura = false;
            this.dDxf.TabIndex = 1;
            // 
            // DibujosPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpContenedor);
            this.Name = "DibujosPlantilla";
            this.Size = new System.Drawing.Size(482, 408);
            this.tlpContenedor.ResumeLayout(false);
            this.tlpencabezado.ResumeLayout(false);
            this.tlpencabezado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContenedor;
        private System.Windows.Forms.TableLayoutPanel tlpencabezado;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TextBox txtnombre;
        private DXF.DibujanteDXF dDxf;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Label lbpredeterminado;
        private System.Windows.Forms.TextBox txtpredeterminado;
        private System.Windows.Forms.Button btnformular;
        private System.Windows.Forms.CheckBox cbplantillavidrio;
    }
}
