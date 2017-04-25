namespace ControlesPersonalizados.Filtro_DragDrop
{
    partial class FiltroDragDrop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiltroDragDrop));
            this.flpFiltros = new System.Windows.Forms.FlowLayoutPanel();
            this.lbindicacion = new System.Windows.Forms.Label();
            this.tlpgeneral = new System.Windows.Forms.TableLayoutPanel();
            this.flpagrupaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.lbindicador = new System.Windows.Forms.Label();
            this.tsherramientas = new System.Windows.Forms.ToolStrip();
            this.btntotales = new System.Windows.Forms.ToolStripSplitButton();
            this.sinTotalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalArribaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalAbajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnformularcolumna = new System.Windows.Forms.ToolStripButton();
            this.flpFiltros.SuspendLayout();
            this.tlpgeneral.SuspendLayout();
            this.flpagrupaciones.SuspendLayout();
            this.tsherramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpFiltros
            // 
            this.flpFiltros.AllowDrop = true;
            this.flpFiltros.Controls.Add(this.lbindicacion);
            this.flpFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFiltros.Location = new System.Drawing.Point(3, 3);
            this.flpFiltros.Name = "flpFiltros";
            this.flpFiltros.Size = new System.Drawing.Size(469, 46);
            this.flpFiltros.TabIndex = 0;
            this.flpFiltros.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpFiltros_DragDrop);
            this.flpFiltros.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpFiltros_DragEnter);
            // 
            // lbindicacion
            // 
            this.lbindicacion.AutoSize = true;
            this.lbindicacion.BackColor = System.Drawing.Color.Transparent;
            this.lbindicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbindicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbindicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbindicacion.ForeColor = System.Drawing.Color.DarkGray;
            this.lbindicacion.Location = new System.Drawing.Point(3, 0);
            this.lbindicacion.Name = "lbindicacion";
            this.lbindicacion.Size = new System.Drawing.Size(319, 15);
            this.lbindicacion.TabIndex = 3;
            this.lbindicacion.Text = "Con click derecho sostenido, arrastre la columna que desea filtrar.";
            // 
            // tlpgeneral
            // 
            this.tlpgeneral.ColumnCount = 2;
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpgeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpgeneral.Controls.Add(this.flpagrupaciones, 0, 1);
            this.tlpgeneral.Controls.Add(this.flpFiltros, 0, 0);
            this.tlpgeneral.Controls.Add(this.tsherramientas, 1, 0);
            this.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpgeneral.Location = new System.Drawing.Point(0, 0);
            this.tlpgeneral.Name = "tlpgeneral";
            this.tlpgeneral.RowCount = 2;
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpgeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpgeneral.Size = new System.Drawing.Size(506, 81);
            this.tlpgeneral.TabIndex = 1;
            // 
            // flpagrupaciones
            // 
            this.flpagrupaciones.AllowDrop = true;
            this.flpagrupaciones.Controls.Add(this.lbindicador);
            this.flpagrupaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpagrupaciones.Location = new System.Drawing.Point(3, 55);
            this.flpagrupaciones.Name = "flpagrupaciones";
            this.flpagrupaciones.Size = new System.Drawing.Size(469, 23);
            this.flpagrupaciones.TabIndex = 1;
            this.flpagrupaciones.DragDrop += new System.Windows.Forms.DragEventHandler(this.flpagrupaciones_DragDrop);
            this.flpagrupaciones.DragEnter += new System.Windows.Forms.DragEventHandler(this.flpagrupaciones_DragEnter);
            // 
            // lbindicador
            // 
            this.lbindicador.AutoSize = true;
            this.lbindicador.BackColor = System.Drawing.Color.Transparent;
            this.lbindicador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbindicador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbindicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbindicador.ForeColor = System.Drawing.Color.DarkGray;
            this.lbindicador.Location = new System.Drawing.Point(3, 0);
            this.lbindicador.Name = "lbindicador";
            this.lbindicador.Size = new System.Drawing.Size(430, 15);
            this.lbindicador.TabIndex = 3;
            this.lbindicador.Text = "Con click derecho sostenido, arrastre la columna por la que desea agrupar la info" +
    "rmación.";
            // 
            // tsherramientas
            // 
            this.tsherramientas.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsherramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btntotales,
            this.btnformularcolumna});
            this.tsherramientas.Location = new System.Drawing.Point(475, 0);
            this.tsherramientas.Name = "tsherramientas";
            this.tlpgeneral.SetRowSpan(this.tsherramientas, 2);
            this.tsherramientas.Size = new System.Drawing.Size(31, 81);
            this.tsherramientas.TabIndex = 2;
            this.tsherramientas.Text = "toolStrip1";
            // 
            // btntotales
            // 
            this.btntotales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btntotales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sinTotalesToolStripMenuItem,
            this.totalArribaToolStripMenuItem,
            this.totalAbajoToolStripMenuItem});
            this.btntotales.Image = global::ControlesPersonalizados.Properties.Resources.Total_24x24;
            this.btntotales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btntotales.Name = "btntotales";
            this.btntotales.Size = new System.Drawing.Size(30, 20);
            this.btntotales.Text = "Agregar Totales";
            // 
            // sinTotalesToolStripMenuItem
            // 
            this.sinTotalesToolStripMenuItem.Checked = true;
            this.sinTotalesToolStripMenuItem.CheckOnClick = true;
            this.sinTotalesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sinTotalesToolStripMenuItem.Name = "sinTotalesToolStripMenuItem";
            this.sinTotalesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sinTotalesToolStripMenuItem.Tag = "1";
            this.sinTotalesToolStripMenuItem.Text = "Sin Totales";
            this.sinTotalesToolStripMenuItem.Click += new System.EventHandler(this.ttToolStripMenuItem_Click);
            // 
            // totalArribaToolStripMenuItem
            // 
            this.totalArribaToolStripMenuItem.CheckOnClick = true;
            this.totalArribaToolStripMenuItem.Image = global::ControlesPersonalizados.Properties.Resources.Totalizar_en_priemra_fila_24x24;
            this.totalArribaToolStripMenuItem.Name = "totalArribaToolStripMenuItem";
            this.totalArribaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.totalArribaToolStripMenuItem.Tag = "2";
            this.totalArribaToolStripMenuItem.Text = "Total Arriba";
            this.totalArribaToolStripMenuItem.Click += new System.EventHandler(this.ttToolStripMenuItem_Click);
            // 
            // totalAbajoToolStripMenuItem
            // 
            this.totalAbajoToolStripMenuItem.CheckOnClick = true;
            this.totalAbajoToolStripMenuItem.Image = global::ControlesPersonalizados.Properties.Resources.Totalizar_en_ultima_fila_24x24;
            this.totalAbajoToolStripMenuItem.Name = "totalAbajoToolStripMenuItem";
            this.totalAbajoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.totalAbajoToolStripMenuItem.Tag = "3";
            this.totalAbajoToolStripMenuItem.Text = "Total Abajo";
            this.totalAbajoToolStripMenuItem.Click += new System.EventHandler(this.ttToolStripMenuItem_Click);
            // 
            // btnformularcolumna
            // 
            this.btnformularcolumna.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnformularcolumna.Image = ((System.Drawing.Image)(resources.GetObject("btnformularcolumna.Image")));
            this.btnformularcolumna.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnformularcolumna.Name = "btnformularcolumna";
            this.btnformularcolumna.Size = new System.Drawing.Size(30, 20);
            this.btnformularcolumna.Text = "0";
            this.btnformularcolumna.Click += new System.EventHandler(this.btnformularcolumna_Click);
            // 
            // FiltroDragDrop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpgeneral);
            this.Name = "FiltroDragDrop";
            this.Size = new System.Drawing.Size(506, 81);
            this.flpFiltros.ResumeLayout(false);
            this.flpFiltros.PerformLayout();
            this.tlpgeneral.ResumeLayout(false);
            this.tlpgeneral.PerformLayout();
            this.flpagrupaciones.ResumeLayout(false);
            this.flpagrupaciones.PerformLayout();
            this.tsherramientas.ResumeLayout(false);
            this.tsherramientas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpFiltros;
        internal System.Windows.Forms.Label lbindicacion;
        private System.Windows.Forms.TableLayoutPanel tlpgeneral;
        private System.Windows.Forms.FlowLayoutPanel flpagrupaciones;
        internal System.Windows.Forms.Label lbindicador;
        private System.Windows.Forms.ToolStrip tsherramientas;
        private System.Windows.Forms.ToolStripSplitButton btntotales;
        private System.Windows.Forms.ToolStripMenuItem sinTotalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalArribaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalAbajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnformularcolumna;
    }
}
