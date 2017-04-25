namespace Formulador.Formularios_Ayuda
{
    partial class FrmFormulador
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Vidrios");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Perfilería");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Accesorios");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Variables Matematicas");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Funciones Matematicas");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Variables Cadena");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Funciones Cadena");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFormulador));
            this.sclistasyformulas = new System.Windows.Forms.SplitContainer();
            this.tlpelementosformulacion = new System.Windows.Forms.TableLayoutPanel();
            this.tlpmateriales = new System.Windows.Forms.TableLayoutPanel();
            this.tvmateriales = new System.Windows.Forms.TreeView();
            this.lbmateriales = new System.Windows.Forms.Label();
            this.tlpvariables = new System.Windows.Forms.TableLayoutPanel();
            this.tvvariables = new System.Windows.Forms.TreeView();
            this.lbvariables = new System.Windows.Forms.Label();
            this.tlpfunciones = new System.Windows.Forms.TableLayoutPanel();
            this.tvfunciones = new System.Windows.Forms.TreeView();
            this.lbfunciones = new System.Windows.Forms.Label();
            this.pcodificacion = new System.Windows.Forms.Panel();
            this.sccodificacionyerrores = new System.Windows.Forms.SplitContainer();
            this.rtbformulador = new RichTextBoxSintaxHighLight.RichtTexboxSyntax();
            this.dwerrores = new System.Windows.Forms.DataGridView();
            this.mensajeerror = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.len = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsherramientas = new System.Windows.Forms.ToolStrip();
            this.btnguardarcerrar = new System.Windows.Forms.ToolStripButton();
            this.btnverificar = new System.Windows.Forms.ToolStripButton();
            this.tlpdescuentos = new System.Windows.Forms.TableLayoutPanel();
            this.tvdescuentos = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sclistasyformulas)).BeginInit();
            this.sclistasyformulas.Panel1.SuspendLayout();
            this.sclistasyformulas.Panel2.SuspendLayout();
            this.sclistasyformulas.SuspendLayout();
            this.tlpelementosformulacion.SuspendLayout();
            this.tlpmateriales.SuspendLayout();
            this.tlpvariables.SuspendLayout();
            this.tlpfunciones.SuspendLayout();
            this.pcodificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sccodificacionyerrores)).BeginInit();
            this.sccodificacionyerrores.Panel1.SuspendLayout();
            this.sccodificacionyerrores.Panel2.SuspendLayout();
            this.sccodificacionyerrores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dwerrores)).BeginInit();
            this.tsherramientas.SuspendLayout();
            this.tlpdescuentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // sclistasyformulas
            // 
            this.sclistasyformulas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sclistasyformulas.Location = new System.Drawing.Point(0, 25);
            this.sclistasyformulas.Name = "sclistasyformulas";
            this.sclistasyformulas.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sclistasyformulas.Panel1
            // 
            this.sclistasyformulas.Panel1.Controls.Add(this.tlpelementosformulacion);
            // 
            // sclistasyformulas.Panel2
            // 
            this.sclistasyformulas.Panel2.Controls.Add(this.pcodificacion);
            this.sclistasyformulas.Size = new System.Drawing.Size(687, 426);
            this.sclistasyformulas.SplitterDistance = 172;
            this.sclistasyformulas.TabIndex = 3;
            // 
            // tlpelementosformulacion
            // 
            this.tlpelementosformulacion.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tlpelementosformulacion.ColumnCount = 4;
            this.tlpelementosformulacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpelementosformulacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpelementosformulacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpelementosformulacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpelementosformulacion.Controls.Add(this.tlpdescuentos, 2, 0);
            this.tlpelementosformulacion.Controls.Add(this.tlpmateriales, 0, 0);
            this.tlpelementosformulacion.Controls.Add(this.tlpvariables, 1, 0);
            this.tlpelementosformulacion.Controls.Add(this.tlpfunciones, 3, 0);
            this.tlpelementosformulacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpelementosformulacion.Location = new System.Drawing.Point(0, 0);
            this.tlpelementosformulacion.Name = "tlpelementosformulacion";
            this.tlpelementosformulacion.RowCount = 1;
            this.tlpelementosformulacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpelementosformulacion.Size = new System.Drawing.Size(687, 172);
            this.tlpelementosformulacion.TabIndex = 0;
            // 
            // tlpmateriales
            // 
            this.tlpmateriales.ColumnCount = 1;
            this.tlpmateriales.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpmateriales.Controls.Add(this.tvmateriales, 0, 1);
            this.tlpmateriales.Controls.Add(this.lbmateriales, 0, 0);
            this.tlpmateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpmateriales.Location = new System.Drawing.Point(6, 6);
            this.tlpmateriales.Name = "tlpmateriales";
            this.tlpmateriales.RowCount = 2;
            this.tlpmateriales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.875F));
            this.tlpmateriales.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.125F));
            this.tlpmateriales.Size = new System.Drawing.Size(162, 160);
            this.tlpmateriales.TabIndex = 3;
            // 
            // tvmateriales
            // 
            this.tvmateriales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvmateriales.Location = new System.Drawing.Point(3, 22);
            this.tvmateriales.Name = "tvmateriales";
            treeNode1.Name = "vidrios";
            treeNode1.Text = "Vidrios";
            treeNode1.ToolTipText = "Vidrios disponibles para formular";
            treeNode2.Name = "perfiles";
            treeNode2.Text = "Perfilería";
            treeNode2.ToolTipText = "Perfiles disponibles para formular";
            treeNode3.Name = "accesorios";
            treeNode3.Text = "Accesorios";
            treeNode3.ToolTipText = "Accesorios disponibles para formular";
            this.tvmateriales.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvmateriales.PathSeparator = ".";
            this.tvmateriales.ShowNodeToolTips = true;
            this.tvmateriales.Size = new System.Drawing.Size(156, 135);
            this.tvmateriales.TabIndex = 0;
            this.tvmateriales.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvmateriales_ItemDrag);
            this.tvmateriales.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvmateriales_NodeMouseClick);
            this.tvmateriales.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvmateriales_NodeMouseDoubleClick);
            // 
            // lbmateriales
            // 
            this.lbmateriales.AutoSize = true;
            this.lbmateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmateriales.Location = new System.Drawing.Point(3, 0);
            this.lbmateriales.Name = "lbmateriales";
            this.lbmateriales.Size = new System.Drawing.Size(75, 15);
            this.lbmateriales.TabIndex = 1;
            this.lbmateriales.Text = "Materiales";
            // 
            // tlpvariables
            // 
            this.tlpvariables.ColumnCount = 1;
            this.tlpvariables.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpvariables.Controls.Add(this.tvvariables, 0, 1);
            this.tlpvariables.Controls.Add(this.lbvariables, 0, 0);
            this.tlpvariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpvariables.Location = new System.Drawing.Point(177, 6);
            this.tlpvariables.Name = "tlpvariables";
            this.tlpvariables.RowCount = 2;
            this.tlpvariables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.625F));
            this.tlpvariables.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.375F));
            this.tlpvariables.Size = new System.Drawing.Size(162, 160);
            this.tlpvariables.TabIndex = 4;
            // 
            // tvvariables
            // 
            this.tvvariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvvariables.Location = new System.Drawing.Point(3, 20);
            this.tvvariables.Name = "tvvariables";
            this.tvvariables.PathSeparator = ".";
            this.tvvariables.ShowNodeToolTips = true;
            this.tvvariables.Size = new System.Drawing.Size(156, 137);
            this.tvvariables.TabIndex = 1;
            this.tvvariables.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvvariables_ItemDrag);
            this.tvvariables.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvvariables_NodeMouseClick);
            this.tvvariables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvvariables_NodeMouseDoubleClick);
            // 
            // lbvariables
            // 
            this.lbvariables.AutoSize = true;
            this.lbvariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbvariables.Location = new System.Drawing.Point(3, 0);
            this.lbvariables.Name = "lbvariables";
            this.lbvariables.Size = new System.Drawing.Size(67, 15);
            this.lbvariables.TabIndex = 2;
            this.lbvariables.Text = "Variables";
            // 
            // tlpfunciones
            // 
            this.tlpfunciones.ColumnCount = 1;
            this.tlpfunciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpfunciones.Controls.Add(this.tvfunciones, 0, 1);
            this.tlpfunciones.Controls.Add(this.lbfunciones, 0, 0);
            this.tlpfunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpfunciones.Location = new System.Drawing.Point(519, 6);
            this.tlpfunciones.Name = "tlpfunciones";
            this.tlpfunciones.RowCount = 2;
            this.tlpfunciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpfunciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpfunciones.Size = new System.Drawing.Size(162, 160);
            this.tlpfunciones.TabIndex = 5;
            // 
            // tvfunciones
            // 
            this.tvfunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvfunciones.Location = new System.Drawing.Point(3, 19);
            this.tvfunciones.Name = "tvfunciones";
            treeNode4.Name = "vmatematica";
            treeNode4.Text = "Variables Matematicas";
            treeNode5.Name = "fmatematica";
            treeNode5.Text = "Funciones Matematicas";
            treeNode6.Name = "vcadena";
            treeNode6.Text = "Variables Cadena";
            treeNode7.Name = "fcadena";
            treeNode7.Text = "Funciones Cadena";
            this.tvfunciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.tvfunciones.PathSeparator = ".";
            this.tvfunciones.ShowNodeToolTips = true;
            this.tvfunciones.Size = new System.Drawing.Size(156, 138);
            this.tvfunciones.TabIndex = 2;
            this.tvfunciones.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvfunciones_ItemDrag);
            this.tvfunciones.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvfunciones_NodeMouseClick);
            this.tvfunciones.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvfunciones_NodeMouseDoubleClick);
            // 
            // lbfunciones
            // 
            this.lbfunciones.AutoSize = true;
            this.lbfunciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbfunciones.Location = new System.Drawing.Point(3, 0);
            this.lbfunciones.Name = "lbfunciones";
            this.lbfunciones.Size = new System.Drawing.Size(73, 15);
            this.lbfunciones.TabIndex = 3;
            this.lbfunciones.Text = "Funciones";
            // 
            // pcodificacion
            // 
            this.pcodificacion.Controls.Add(this.sccodificacionyerrores);
            this.pcodificacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcodificacion.Location = new System.Drawing.Point(0, 0);
            this.pcodificacion.Name = "pcodificacion";
            this.pcodificacion.Size = new System.Drawing.Size(687, 250);
            this.pcodificacion.TabIndex = 1;
            // 
            // sccodificacionyerrores
            // 
            this.sccodificacionyerrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sccodificacionyerrores.Location = new System.Drawing.Point(0, 0);
            this.sccodificacionyerrores.Name = "sccodificacionyerrores";
            this.sccodificacionyerrores.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sccodificacionyerrores.Panel1
            // 
            this.sccodificacionyerrores.Panel1.Controls.Add(this.rtbformulador);
            // 
            // sccodificacionyerrores.Panel2
            // 
            this.sccodificacionyerrores.Panel2.Controls.Add(this.dwerrores);
            this.sccodificacionyerrores.Size = new System.Drawing.Size(687, 250);
            this.sccodificacionyerrores.SplitterDistance = 160;
            this.sccodificacionyerrores.TabIndex = 0;
            // 
            // rtbformulador
            // 
            this.rtbformulador.AutoWordSelection = true;
            this.rtbformulador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbformulador.EnableAutoDragDrop = true;
            this.rtbformulador.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbformulador.Location = new System.Drawing.Point(0, 0);
            this.rtbformulador.MaxLength = 21474836;
            this.rtbformulador.Name = "rtbformulador";
            this.rtbformulador.ShowSelectionMargin = true;
            this.rtbformulador.Size = new System.Drawing.Size(687, 160);
            this.rtbformulador.TabIndex = 0;
            this.rtbformulador.Text = "";
            this.rtbformulador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtbformulador_KeyUp);
            // 
            // dwerrores
            // 
            this.dwerrores.AllowUserToAddRows = false;
            this.dwerrores.AllowUserToDeleteRows = false;
            this.dwerrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dwerrores.BackgroundColor = System.Drawing.Color.White;
            this.dwerrores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dwerrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dwerrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mensajeerror,
            this.index,
            this.len});
            this.dwerrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dwerrores.Location = new System.Drawing.Point(0, 0);
            this.dwerrores.Name = "dwerrores";
            this.dwerrores.ReadOnly = true;
            this.dwerrores.RowHeadersWidth = 25;
            this.dwerrores.Size = new System.Drawing.Size(687, 86);
            this.dwerrores.TabIndex = 0;
            // 
            // mensajeerror
            // 
            this.mensajeerror.HeaderText = "Error";
            this.mensajeerror.Name = "mensajeerror";
            this.mensajeerror.ReadOnly = true;
            this.mensajeerror.Width = 54;
            // 
            // index
            // 
            this.index.HeaderText = "Inicio";
            this.index.Name = "index";
            this.index.ReadOnly = true;
            this.index.Width = 57;
            // 
            // len
            // 
            this.len.HeaderText = "Largo";
            this.len.Name = "len";
            this.len.ReadOnly = true;
            this.len.Width = 59;
            // 
            // tsherramientas
            // 
            this.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsherramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnguardarcerrar,
            this.btnverificar});
            this.tsherramientas.Location = new System.Drawing.Point(0, 0);
            this.tsherramientas.Name = "tsherramientas";
            this.tsherramientas.Size = new System.Drawing.Size(687, 25);
            this.tsherramientas.TabIndex = 2;
            this.tsherramientas.Text = "ToolStrip1";
            // 
            // btnguardarcerrar
            // 
            this.btnguardarcerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnguardarcerrar.Image")));
            this.btnguardarcerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnguardarcerrar.Name = "btnguardarcerrar";
            this.btnguardarcerrar.Size = new System.Drawing.Size(113, 22);
            this.btnguardarcerrar.Text = "Guardar y Cerrar";
            this.btnguardarcerrar.Click += new System.EventHandler(this.btnguardarcerrar_Click);
            // 
            // btnverificar
            // 
            this.btnverificar.Image = ((System.Drawing.Image)(resources.GetObject("btnverificar.Image")));
            this.btnverificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnverificar.Name = "btnverificar";
            this.btnverificar.Size = new System.Drawing.Size(116, 22);
            this.btnverificar.Text = "Verificar Formula";
            this.btnverificar.Click += new System.EventHandler(this.btnverificar_Click);
            // 
            // tlpdescuentos
            // 
            this.tlpdescuentos.ColumnCount = 1;
            this.tlpdescuentos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpdescuentos.Controls.Add(this.tvdescuentos, 0, 1);
            this.tlpdescuentos.Controls.Add(this.label1, 0, 0);
            this.tlpdescuentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpdescuentos.Location = new System.Drawing.Point(348, 6);
            this.tlpdescuentos.Name = "tlpdescuentos";
            this.tlpdescuentos.RowCount = 2;
            this.tlpdescuentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpdescuentos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpdescuentos.Size = new System.Drawing.Size(162, 160);
            this.tlpdescuentos.TabIndex = 6;
            // 
            // tvdescuentos
            // 
            this.tvdescuentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvdescuentos.Location = new System.Drawing.Point(3, 19);
            this.tvdescuentos.Name = "tvdescuentos";
            this.tvdescuentos.PathSeparator = ".";
            this.tvdescuentos.ShowNodeToolTips = true;
            this.tvdescuentos.Size = new System.Drawing.Size(156, 138);
            this.tvdescuentos.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descuentos";
            // 
            // FrmFormulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 451);
            this.Controls.Add(this.sclistasyformulas);
            this.Controls.Add(this.tsherramientas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFormulador";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFormulador_FormClosing);
            this.Load += new System.EventHandler(this.FrmFormulador_Load);
            this.sclistasyformulas.Panel1.ResumeLayout(false);
            this.sclistasyformulas.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sclistasyformulas)).EndInit();
            this.sclistasyformulas.ResumeLayout(false);
            this.tlpelementosformulacion.ResumeLayout(false);
            this.tlpmateriales.ResumeLayout(false);
            this.tlpmateriales.PerformLayout();
            this.tlpvariables.ResumeLayout(false);
            this.tlpvariables.PerformLayout();
            this.tlpfunciones.ResumeLayout(false);
            this.tlpfunciones.PerformLayout();
            this.pcodificacion.ResumeLayout(false);
            this.sccodificacionyerrores.Panel1.ResumeLayout(false);
            this.sccodificacionyerrores.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sccodificacionyerrores)).EndInit();
            this.sccodificacionyerrores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dwerrores)).EndInit();
            this.tsherramientas.ResumeLayout(false);
            this.tsherramientas.PerformLayout();
            this.tlpdescuentos.ResumeLayout(false);
            this.tlpdescuentos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.SplitContainer sclistasyformulas;
        internal System.Windows.Forms.TableLayoutPanel tlpelementosformulacion;
        internal System.Windows.Forms.TableLayoutPanel tlpmateriales;
        internal System.Windows.Forms.TreeView tvmateriales;
        internal System.Windows.Forms.Label lbmateriales;
        internal System.Windows.Forms.TableLayoutPanel tlpvariables;
        internal System.Windows.Forms.TreeView tvvariables;
        internal System.Windows.Forms.Label lbvariables;
        internal System.Windows.Forms.TableLayoutPanel tlpfunciones;
        internal System.Windows.Forms.TreeView tvfunciones;
        internal System.Windows.Forms.Label lbfunciones;
        internal System.Windows.Forms.Panel pcodificacion;
        internal System.Windows.Forms.SplitContainer sccodificacionyerrores;
        public RichTextBoxSintaxHighLight.RichtTexboxSyntax rtbformulador;
        internal System.Windows.Forms.DataGridView dwerrores;
        internal System.Windows.Forms.DataGridViewTextBoxColumn mensajeerror;
        internal System.Windows.Forms.DataGridViewTextBoxColumn index;
        internal System.Windows.Forms.DataGridViewTextBoxColumn len;
        internal System.Windows.Forms.ToolStrip tsherramientas;
        internal System.Windows.Forms.ToolStripButton btnguardarcerrar;
        internal System.Windows.Forms.ToolStripButton btnverificar;
        internal System.Windows.Forms.TableLayoutPanel tlpdescuentos;
        internal System.Windows.Forms.TreeView tvdescuentos;
        internal System.Windows.Forms.Label label1;
    }
}