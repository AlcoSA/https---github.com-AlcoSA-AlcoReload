namespace DXF
{
    partial class DibujanteDXF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DibujanteDXF));
            this.tsherramientasdxf = new System.Windows.Forms.ToolStrip();
            this.btnninguno = new System.Windows.Forms.ToolStripButton();
            this.btndevolveraccion = new System.Windows.Forms.ToolStripButton();
            this.btntrasladar = new System.Windows.Forms.ToolStripButton();
            this.btnmarco = new System.Windows.Forms.ToolStripButton();
            this.btnrejilla = new System.Windows.Forms.ToolStripButton();
            this.btnacotar = new System.Windows.Forms.ToolStripButton();
            this.btnangeo = new System.Windows.Forms.ToolStripButton();
            this.btnele = new System.Windows.Forms.ToolStripButton();
            this.btnarco = new System.Windows.Forms.ToolStripButton();
            this.btntexto = new System.Windows.Forms.ToolStripButton();
            this.btnflecha = new System.Windows.Forms.ToolStripButton();
            this.btnlinea = new System.Windows.Forms.ToolStripButton();
            this.btnanticondensacion = new System.Windows.Forms.ToolStripButton();
            this.pbdxf = new System.Windows.Forms.PictureBox();
            this.tbzoom = new System.Windows.Forms.TrackBar();
            this.tsherramientasdxf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbdxf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbzoom)).BeginInit();
            this.SuspendLayout();
            // 
            // tsherramientasdxf
            // 
            this.tsherramientasdxf.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsherramientasdxf.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsherramientasdxf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnninguno,
            this.btndevolveraccion,
            this.btntrasladar,
            this.btnmarco,
            this.btnrejilla,
            this.btnacotar,
            this.btnangeo,
            this.btnele,
            this.btnarco,
            this.btntexto,
            this.btnflecha,
            this.btnlinea,
            this.btnanticondensacion});
            this.tsherramientasdxf.Location = new System.Drawing.Point(0, 0);
            this.tsherramientasdxf.Name = "tsherramientasdxf";
            this.tsherramientasdxf.Size = new System.Drawing.Size(32, 398);
            this.tsherramientasdxf.TabIndex = 0;
            this.tsherramientasdxf.Text = "toolStrip1";
            this.tsherramientasdxf.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsherramientasdxf_ItemClicked);
            // 
            // btnninguno
            // 
            this.btnninguno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnninguno.Image = ((System.Drawing.Image)(resources.GetObject("btnninguno.Image")));
            this.btnninguno.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnninguno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnninguno.Name = "btnninguno";
            this.btnninguno.Size = new System.Drawing.Size(29, 24);
            this.btnninguno.Text = "Ninguno";
            this.btnninguno.Click += new System.EventHandler(this.btnninguno_Click);
            // 
            // btndevolveraccion
            // 
            this.btndevolveraccion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btndevolveraccion.Image = ((System.Drawing.Image)(resources.GetObject("btndevolveraccion.Image")));
            this.btndevolveraccion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btndevolveraccion.Name = "btndevolveraccion";
            this.btndevolveraccion.Size = new System.Drawing.Size(29, 20);
            this.btndevolveraccion.Text = "Devolver Acción";
            this.btndevolveraccion.ToolTipText = "Devolver Acción";
            this.btndevolveraccion.Click += new System.EventHandler(this.btndevolveraccion_Click);
            // 
            // btntrasladar
            // 
            this.btntrasladar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btntrasladar.Image = ((System.Drawing.Image)(resources.GetObject("btntrasladar.Image")));
            this.btntrasladar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btntrasladar.Name = "btntrasladar";
            this.btntrasladar.Size = new System.Drawing.Size(29, 20);
            this.btntrasladar.Text = "Mover";
            this.btntrasladar.Click += new System.EventHandler(this.btntrasladar_Click);
            // 
            // btnmarco
            // 
            this.btnmarco.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnmarco.Image = ((System.Drawing.Image)(resources.GetObject("btnmarco.Image")));
            this.btnmarco.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnmarco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmarco.Name = "btnmarco";
            this.btnmarco.Size = new System.Drawing.Size(29, 24);
            this.btnmarco.Tag = "1";
            this.btnmarco.Text = "Marco";
            this.btnmarco.Click += new System.EventHandler(this.btnmarco_Click);
            // 
            // btnrejilla
            // 
            this.btnrejilla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnrejilla.Image = ((System.Drawing.Image)(resources.GetObject("btnrejilla.Image")));
            this.btnrejilla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnrejilla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnrejilla.Name = "btnrejilla";
            this.btnrejilla.Size = new System.Drawing.Size(29, 24);
            this.btnrejilla.Text = "Rejilla";
            this.btnrejilla.Click += new System.EventHandler(this.btnrejilla_Click);
            // 
            // btnacotar
            // 
            this.btnacotar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnacotar.Image = ((System.Drawing.Image)(resources.GetObject("btnacotar.Image")));
            this.btnacotar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnacotar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnacotar.Name = "btnacotar";
            this.btnacotar.Size = new System.Drawing.Size(29, 24);
            this.btnacotar.Text = "Acotar";
            this.btnacotar.Click += new System.EventHandler(this.btnacotar_Click);
            // 
            // btnangeo
            // 
            this.btnangeo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnangeo.Image = ((System.Drawing.Image)(resources.GetObject("btnangeo.Image")));
            this.btnangeo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnangeo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnangeo.Name = "btnangeo";
            this.btnangeo.Size = new System.Drawing.Size(29, 24);
            this.btnangeo.Text = "Angeo";
            this.btnangeo.Click += new System.EventHandler(this.btnangeo_Click);
            // 
            // btnele
            // 
            this.btnele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnele.Image = ((System.Drawing.Image)(resources.GetObject("btnele.Image")));
            this.btnele.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnele.Name = "btnele";
            this.btnele.Size = new System.Drawing.Size(29, 20);
            this.btnele.Text = "Escuadra";
            this.btnele.Click += new System.EventHandler(this.btnele_Click);
            // 
            // btnarco
            // 
            this.btnarco.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnarco.Image = ((System.Drawing.Image)(resources.GetObject("btnarco.Image")));
            this.btnarco.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnarco.Name = "btnarco";
            this.btnarco.Size = new System.Drawing.Size(29, 20);
            this.btnarco.Text = "Arco";
            this.btnarco.Click += new System.EventHandler(this.btnarco_Click);
            // 
            // btntexto
            // 
            this.btntexto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btntexto.Image = ((System.Drawing.Image)(resources.GetObject("btntexto.Image")));
            this.btntexto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btntexto.Name = "btntexto";
            this.btntexto.Size = new System.Drawing.Size(29, 20);
            this.btntexto.Text = "Texto";
            this.btntexto.Click += new System.EventHandler(this.btntexto_Click);
            // 
            // btnflecha
            // 
            this.btnflecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnflecha.Image = ((System.Drawing.Image)(resources.GetObject("btnflecha.Image")));
            this.btnflecha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnflecha.Name = "btnflecha";
            this.btnflecha.Size = new System.Drawing.Size(29, 20);
            this.btnflecha.Text = "Flecha";
            this.btnflecha.Click += new System.EventHandler(this.btnflecha_Click);
            // 
            // btnlinea
            // 
            this.btnlinea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnlinea.Image = ((System.Drawing.Image)(resources.GetObject("btnlinea.Image")));
            this.btnlinea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlinea.Name = "btnlinea";
            this.btnlinea.Size = new System.Drawing.Size(29, 20);
            this.btnlinea.Text = "Linea";
            this.btnlinea.Click += new System.EventHandler(this.btnlinea_Click);
            // 
            // btnanticondensacion
            // 
            this.btnanticondensacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnanticondensacion.Image = ((System.Drawing.Image)(resources.GetObject("btnanticondensacion.Image")));
            this.btnanticondensacion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnanticondensacion.Name = "btnanticondensacion";
            this.btnanticondensacion.Size = new System.Drawing.Size(29, 20);
            this.btnanticondensacion.Text = "Anticondensación";
            this.btnanticondensacion.Click += new System.EventHandler(this.btnanticondensacion_Click);
            // 
            // pbdxf
            // 
            this.pbdxf.BackColor = System.Drawing.SystemColors.Window;
            this.pbdxf.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbdxf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbdxf.Location = new System.Drawing.Point(32, 0);
            this.pbdxf.Name = "pbdxf";
            this.pbdxf.Size = new System.Drawing.Size(438, 398);
            this.pbdxf.TabIndex = 1;
            this.pbdxf.TabStop = false;
            this.pbdxf.Paint += new System.Windows.Forms.PaintEventHandler(this.pbdxf_Paint);
            this.pbdxf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseDown);
            this.pbdxf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseMove);
            this.pbdxf.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbdxf_MouseUp);
            this.pbdxf.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Pbdxf_MouseWheel);
            this.pbdxf.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pbdxf_PreviewKeyDown);
            // 
            // tbzoom
            // 
            this.tbzoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbzoom.BackColor = System.Drawing.Color.White;
            this.tbzoom.LargeChange = 1;
            this.tbzoom.Location = new System.Drawing.Point(366, 366);
            this.tbzoom.Maximum = 5;
            this.tbzoom.Minimum = 1;
            this.tbzoom.Name = "tbzoom";
            this.tbzoom.Size = new System.Drawing.Size(104, 45);
            this.tbzoom.TabIndex = 2;
            this.tbzoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbzoom.Value = 2;
            this.tbzoom.ValueChanged += new System.EventHandler(this.tbzoom_ValueChanged);
            // 
            // DibujanteDXF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbzoom);
            this.Controls.Add(this.pbdxf);
            this.Controls.Add(this.tsherramientasdxf);
            this.Name = "DibujanteDXF";
            this.Size = new System.Drawing.Size(470, 398);
            this.tsherramientasdxf.ResumeLayout(false);
            this.tsherramientasdxf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbdxf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbzoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip tsherramientasdxf;
        private System.Windows.Forms.ToolStripButton btnmarco;
        private System.Windows.Forms.PictureBox pbdxf;
        private System.Windows.Forms.ToolStripButton btnrejilla;
        private System.Windows.Forms.ToolStripButton btnacotar;
        private System.Windows.Forms.ToolStripButton btnangeo;
        private System.Windows.Forms.ToolStripButton btnninguno;
        private System.Windows.Forms.ToolStripButton btnele;
        private System.Windows.Forms.ToolStripButton btnarco;
        private System.Windows.Forms.ToolStripButton btntexto;
        private System.Windows.Forms.ToolStripButton btnflecha;
        private System.Windows.Forms.ToolStripButton btnlinea;
        private System.Windows.Forms.TrackBar tbzoom;
        private System.Windows.Forms.ToolStripButton btntrasladar;
        private System.Windows.Forms.ToolStripButton btnanticondensacion;
        private System.Windows.Forms.ToolStripButton btndevolveraccion;
    }
}
