namespace ManualesyAyudas
{
    partial class FrmVideoAyuda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVideoAyuda));
            this.tsherramientas = new System.Windows.Forms.ToolStrip();
            this.lbayuda = new System.Windows.Forms.ToolStripLabel();
            this.tlpreproductorayuda = new System.Windows.Forms.TableLayoutPanel();
            this.wmpVideoAyuda = new AxWMPLib.AxWindowsMediaPlayer();
            this.preproduccion = new System.Windows.Forms.Panel();
            this.btnrepetir = new System.Windows.Forms.Button();
            this.btnvolumen = new System.Windows.Forms.Button();
            this.tbvolumen = new System.Windows.Forms.TrackBar();
            this.btnpausar = new System.Windows.Forms.Button();
            this.tlpestadoreproduccion = new System.Windows.Forms.TableLayoutPanel();
            this.tbduracion = new System.Windows.Forms.TrackBar();
            this.lbestadoreproduccion = new System.Windows.Forms.Label();
            this.lbtotalreproduccion = new System.Windows.Forms.Label();
            this.btnparar = new System.Windows.Forms.Button();
            this.btnreproducir = new System.Windows.Forms.Button();
            this.mreproduccion = new System.Windows.Forms.Timer(this.components);
            this.tsherramientas.SuspendLayout();
            this.tlpreproductorayuda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideoAyuda)).BeginInit();
            this.preproduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbvolumen)).BeginInit();
            this.tlpestadoreproduccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbduracion)).BeginInit();
            this.SuspendLayout();
            // 
            // tsherramientas
            // 
            this.tsherramientas.BackColor = System.Drawing.Color.White;
            this.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsherramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbayuda});
            this.tsherramientas.Location = new System.Drawing.Point(0, 0);
            this.tsherramientas.Name = "tsherramientas";
            this.tsherramientas.Size = new System.Drawing.Size(464, 25);
            this.tsherramientas.TabIndex = 0;
            this.tsherramientas.Text = "toolStrip1";
            // 
            // lbayuda
            // 
            this.lbayuda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbayuda.Name = "lbayuda";
            this.lbayuda.Size = new System.Drawing.Size(21, 22);
            this.lbayuda.Text = "--";
            // 
            // tlpreproductorayuda
            // 
            this.tlpreproductorayuda.ColumnCount = 1;
            this.tlpreproductorayuda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpreproductorayuda.Controls.Add(this.wmpVideoAyuda, 0, 0);
            this.tlpreproductorayuda.Controls.Add(this.preproduccion, 0, 1);
            this.tlpreproductorayuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpreproductorayuda.Location = new System.Drawing.Point(0, 25);
            this.tlpreproductorayuda.Name = "tlpreproductorayuda";
            this.tlpreproductorayuda.RowCount = 2;
            this.tlpreproductorayuda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.7485F));
            this.tlpreproductorayuda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.2515F));
            this.tlpreproductorayuda.Size = new System.Drawing.Size(464, 334);
            this.tlpreproductorayuda.TabIndex = 1;
            // 
            // wmpVideoAyuda
            // 
            this.wmpVideoAyuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmpVideoAyuda.Enabled = true;
            this.wmpVideoAyuda.Location = new System.Drawing.Point(3, 3);
            this.wmpVideoAyuda.Name = "wmpVideoAyuda";
            this.wmpVideoAyuda.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpVideoAyuda.OcxState")));
            this.wmpVideoAyuda.Size = new System.Drawing.Size(458, 246);
            this.wmpVideoAyuda.TabIndex = 0;
            this.wmpVideoAyuda.MediaChange += new AxWMPLib._WMPOCXEvents_MediaChangeEventHandler(this.wmpVideoAyuda_MediaChange);
            // 
            // preproduccion
            // 
            this.preproduccion.Controls.Add(this.btnrepetir);
            this.preproduccion.Controls.Add(this.btnvolumen);
            this.preproduccion.Controls.Add(this.tbvolumen);
            this.preproduccion.Controls.Add(this.btnpausar);
            this.preproduccion.Controls.Add(this.tlpestadoreproduccion);
            this.preproduccion.Controls.Add(this.btnparar);
            this.preproduccion.Controls.Add(this.btnreproducir);
            this.preproduccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preproduccion.Location = new System.Drawing.Point(3, 255);
            this.preproduccion.Name = "preproduccion";
            this.preproduccion.Size = new System.Drawing.Size(458, 76);
            this.preproduccion.TabIndex = 1;
            // 
            // btnrepetir
            // 
            this.btnrepetir.BackColor = System.Drawing.Color.White;
            this.btnrepetir.Image = ((System.Drawing.Image)(resources.GetObject("btnrepetir.Image")));
            this.btnrepetir.Location = new System.Drawing.Point(111, 39);
            this.btnrepetir.Name = "btnrepetir";
            this.btnrepetir.Size = new System.Drawing.Size(25, 25);
            this.btnrepetir.TabIndex = 9;
            this.btnrepetir.UseVisualStyleBackColor = false;
            this.btnrepetir.Click += new System.EventHandler(this.btnrepetir_Click);
            // 
            // btnvolumen
            // 
            this.btnvolumen.BackColor = System.Drawing.Color.White;
            this.btnvolumen.Image = global::ManualesyAyudas.Properties.Resources.Sonido_Inactivo_16x16;
            this.btnvolumen.Location = new System.Drawing.Point(329, 46);
            this.btnvolumen.Name = "btnvolumen";
            this.btnvolumen.Size = new System.Drawing.Size(25, 25);
            this.btnvolumen.TabIndex = 8;
            this.btnvolumen.UseVisualStyleBackColor = false;
            this.btnvolumen.Click += new System.EventHandler(this.btnvolumen_Click);
            // 
            // tbvolumen
            // 
            this.tbvolumen.LargeChange = 0;
            this.tbvolumen.Location = new System.Drawing.Point(357, 48);
            this.tbvolumen.Maximum = 100;
            this.tbvolumen.Name = "tbvolumen";
            this.tbvolumen.Size = new System.Drawing.Size(104, 45);
            this.tbvolumen.TabIndex = 7;
            this.tbvolumen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbvolumen.ValueChanged += new System.EventHandler(this.tbvolumen_ValueChanged);
            // 
            // btnpausar
            // 
            this.btnpausar.BackColor = System.Drawing.Color.White;
            this.btnpausar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnpausar.Image = ((System.Drawing.Image)(resources.GetObject("btnpausar.Image")));
            this.btnpausar.Location = new System.Drawing.Point(49, 39);
            this.btnpausar.Name = "btnpausar";
            this.btnpausar.Size = new System.Drawing.Size(25, 25);
            this.btnpausar.TabIndex = 6;
            this.btnpausar.UseVisualStyleBackColor = false;
            this.btnpausar.Click += new System.EventHandler(this.btnpausar_Click);
            // 
            // tlpestadoreproduccion
            // 
            this.tlpestadoreproduccion.ColumnCount = 3;
            this.tlpestadoreproduccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.60494F));
            this.tlpestadoreproduccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.39507F));
            this.tlpestadoreproduccion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpestadoreproduccion.Controls.Add(this.tbduracion, 1, 0);
            this.tlpestadoreproduccion.Controls.Add(this.lbestadoreproduccion, 0, 0);
            this.tlpestadoreproduccion.Controls.Add(this.lbtotalreproduccion, 2, 0);
            this.tlpestadoreproduccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpestadoreproduccion.Location = new System.Drawing.Point(0, 0);
            this.tlpestadoreproduccion.Name = "tlpestadoreproduccion";
            this.tlpestadoreproduccion.RowCount = 1;
            this.tlpestadoreproduccion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpestadoreproduccion.Size = new System.Drawing.Size(458, 32);
            this.tlpestadoreproduccion.TabIndex = 5;
            // 
            // tbduracion
            // 
            this.tbduracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbduracion.Location = new System.Drawing.Point(50, 3);
            this.tbduracion.Name = "tbduracion";
            this.tbduracion.Size = new System.Drawing.Size(353, 26);
            this.tbduracion.TabIndex = 0;
            this.tbduracion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbduracion.ValueChanged += new System.EventHandler(this.tbduracion_ValueChanged);
            // 
            // lbestadoreproduccion
            // 
            this.lbestadoreproduccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbestadoreproduccion.AutoSize = true;
            this.lbestadoreproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbestadoreproduccion.Location = new System.Drawing.Point(4, 9);
            this.lbestadoreproduccion.Name = "lbestadoreproduccion";
            this.lbestadoreproduccion.Size = new System.Drawing.Size(39, 13);
            this.lbestadoreproduccion.TabIndex = 1;
            this.lbestadoreproduccion.Text = "00:00";
            // 
            // lbtotalreproduccion
            // 
            this.lbtotalreproduccion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbtotalreproduccion.AutoSize = true;
            this.lbtotalreproduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotalreproduccion.Location = new System.Drawing.Point(412, 9);
            this.lbtotalreproduccion.Name = "lbtotalreproduccion";
            this.lbtotalreproduccion.Size = new System.Drawing.Size(39, 13);
            this.lbtotalreproduccion.TabIndex = 2;
            this.lbtotalreproduccion.Text = "00:00";
            // 
            // btnparar
            // 
            this.btnparar.BackColor = System.Drawing.Color.White;
            this.btnparar.Image = ((System.Drawing.Image)(resources.GetObject("btnparar.Image")));
            this.btnparar.Location = new System.Drawing.Point(80, 39);
            this.btnparar.Name = "btnparar";
            this.btnparar.Size = new System.Drawing.Size(25, 25);
            this.btnparar.TabIndex = 4;
            this.btnparar.UseVisualStyleBackColor = false;
            this.btnparar.Click += new System.EventHandler(this.btnparar_Click);
            // 
            // btnreproducir
            // 
            this.btnreproducir.BackColor = System.Drawing.Color.White;
            this.btnreproducir.Image = ((System.Drawing.Image)(resources.GetObject("btnreproducir.Image")));
            this.btnreproducir.Location = new System.Drawing.Point(3, 31);
            this.btnreproducir.Name = "btnreproducir";
            this.btnreproducir.Size = new System.Drawing.Size(40, 40);
            this.btnreproducir.TabIndex = 1;
            this.btnreproducir.UseVisualStyleBackColor = false;
            this.btnreproducir.Click += new System.EventHandler(this.btnreproducir_Click);
            // 
            // mreproduccion
            // 
            this.mreproduccion.Enabled = true;
            this.mreproduccion.Interval = 500;
            this.mreproduccion.Tick += new System.EventHandler(this.mreproduccion_Tick);
            // 
            // FrmVideoAyuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 359);
            this.Controls.Add(this.tlpreproductorayuda);
            this.Controls.Add(this.tsherramientas);
            this.Name = "FrmVideoAyuda";
            this.ShowIcon = false;
            this.Text = "Video Ayuda";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVideoAyuda_FormClosed);
            this.Load += new System.EventHandler(this.FrmVideoAyuda_Load);
            this.Shown += new System.EventHandler(this.FrmVideoAyuda_Shown);
            this.tsherramientas.ResumeLayout(false);
            this.tsherramientas.PerformLayout();
            this.tlpreproductorayuda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wmpVideoAyuda)).EndInit();
            this.preproduccion.ResumeLayout(false);
            this.preproduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbvolumen)).EndInit();
            this.tlpestadoreproduccion.ResumeLayout(false);
            this.tlpestadoreproduccion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbduracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsherramientas;
        private System.Windows.Forms.ToolStripLabel lbayuda;
        private System.Windows.Forms.TableLayoutPanel tlpreproductorayuda;
        private AxWMPLib.AxWindowsMediaPlayer wmpVideoAyuda;
        private System.Windows.Forms.Panel preproduccion;
        private System.Windows.Forms.TrackBar tbduracion;
        private System.Windows.Forms.Button btnparar;
        private System.Windows.Forms.Button btnreproducir;
        private System.Windows.Forms.TableLayoutPanel tlpestadoreproduccion;
        private System.Windows.Forms.Label lbestadoreproduccion;
        private System.Windows.Forms.Label lbtotalreproduccion;
        private System.Windows.Forms.Timer mreproduccion;
        private System.Windows.Forms.Button btnpausar;
        private System.Windows.Forms.TrackBar tbvolumen;
        private System.Windows.Forms.Button btnvolumen;
        private System.Windows.Forms.Button btnrepetir;
    }
}