namespace ControlesPersonalizados.GridFiltrado
{
    partial class FrmfiltroGrid
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Seleccionar Todos");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmfiltroGrid));
            this.tvFiltro = new System.Windows.Forms.TreeView();
            this.btndesc = new System.Windows.Forms.Button();
            this.btnasc = new System.Windows.Forms.Button();
            this.contenedorBtones = new System.Windows.Forms.TableLayoutPanel();
            this.btonAceptar = new System.Windows.Forms.Button();
            this.btonCancelar = new System.Windows.Forms.Button();
            this.contenedorBtones.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFiltro
            // 
            this.tvFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFiltro.CheckBoxes = true;
            this.tvFiltro.Location = new System.Drawing.Point(13, 66);
            this.tvFiltro.Name = "tvFiltro";
            treeNode1.Checked = true;
            treeNode1.Name = "todos";
            treeNode1.Text = "Seleccionar Todos";
            this.tvFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tvFiltro.PathSeparator = "/";
            this.tvFiltro.ShowNodeToolTips = true;
            this.tvFiltro.Size = new System.Drawing.Size(182, 209);
            this.tvFiltro.TabIndex = 17;
            this.tvFiltro.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFiltro_AfterCheck);
            // 
            // btndesc
            // 
            this.btndesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btndesc.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btndesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndesc.Image = ((System.Drawing.Image)(resources.GetObject("btndesc.Image")));
            this.btndesc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndesc.Location = new System.Drawing.Point(13, 8);
            this.btndesc.Name = "btndesc";
            this.btndesc.Size = new System.Drawing.Size(182, 23);
            this.btndesc.TabIndex = 16;
            this.btndesc.Text = "Ordenar de A a Z";
            this.btndesc.UseVisualStyleBackColor = true;
            this.btndesc.Click += new System.EventHandler(this.btndesc_Click);
            // 
            // btnasc
            // 
            this.btnasc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnasc.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnasc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnasc.Image = ((System.Drawing.Image)(resources.GetObject("btnasc.Image")));
            this.btnasc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnasc.Location = new System.Drawing.Point(13, 37);
            this.btnasc.Name = "btnasc";
            this.btnasc.Size = new System.Drawing.Size(182, 23);
            this.btnasc.TabIndex = 15;
            this.btnasc.Text = "Ordenar de Z a A";
            this.btnasc.UseVisualStyleBackColor = true;
            this.btnasc.Click += new System.EventHandler(this.btnasc_Click);
            // 
            // contenedorBtones
            // 
            this.contenedorBtones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorBtones.ColumnCount = 2;
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6732F));
            this.contenedorBtones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3268F));
            this.contenedorBtones.Controls.Add(this.btonAceptar, 0, 0);
            this.contenedorBtones.Controls.Add(this.btonCancelar, 1, 0);
            this.contenedorBtones.Location = new System.Drawing.Point(35, 281);
            this.contenedorBtones.Name = "contenedorBtones";
            this.contenedorBtones.RowCount = 1;
            this.contenedorBtones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.contenedorBtones.Size = new System.Drawing.Size(160, 29);
            this.contenedorBtones.TabIndex = 14;
            // 
            // btonAceptar
            // 
            this.btonAceptar.Location = new System.Drawing.Point(3, 3);
            this.btonAceptar.Name = "btonAceptar";
            this.btonAceptar.Size = new System.Drawing.Size(73, 23);
            this.btonAceptar.TabIndex = 0;
            this.btonAceptar.Text = "ACEPTAR";
            this.btonAceptar.UseVisualStyleBackColor = true;
            this.btonAceptar.Click += new System.EventHandler(this.btonAceptar_Click);
            // 
            // btonCancelar
            // 
            this.btonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btonCancelar.Location = new System.Drawing.Point(82, 3);
            this.btonCancelar.Name = "btonCancelar";
            this.btonCancelar.Size = new System.Drawing.Size(75, 23);
            this.btonCancelar.TabIndex = 1;
            this.btonCancelar.Text = "CANCELAR";
            this.btonCancelar.UseVisualStyleBackColor = true;
            this.btonCancelar.Click += new System.EventHandler(this.btonCancelar_Click);
            // 
            // FrmfiltroGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btonCancelar;
            this.ClientSize = new System.Drawing.Size(207, 318);
            this.ControlBox = false;
            this.Controls.Add(this.tvFiltro);
            this.Controls.Add(this.btndesc);
            this.Controls.Add(this.btnasc);
            this.Controls.Add(this.contenedorBtones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmfiltroGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FrmfiltroGrid_Deactivate);
            this.Load += new System.EventHandler(this.FrmfiltroGrid_Load);
            this.contenedorBtones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView tvFiltro;
        internal System.Windows.Forms.Button btndesc;
        internal System.Windows.Forms.Button btnasc;
        internal System.Windows.Forms.TableLayoutPanel contenedorBtones;
        internal System.Windows.Forms.Button btonAceptar;
        internal System.Windows.Forms.Button btonCancelar;
    }
}