namespace ControlesPersonalizados.GridFiltrado
{
    partial class FrmVisibilidadColumnas
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Seleccionar Todos");
            this.tvFiltro = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvFiltro
            // 
            this.tvFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFiltro.CheckBoxes = true;
            this.tvFiltro.Location = new System.Drawing.Point(3, 4);
            this.tvFiltro.Name = "tvFiltro";
            treeNode3.Checked = true;
            treeNode3.Name = "todos";
            treeNode3.Text = "Seleccionar Todos";
            this.tvFiltro.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.tvFiltro.PathSeparator = "/";
            this.tvFiltro.Size = new System.Drawing.Size(182, 228);
            this.tvFiltro.TabIndex = 18;
            this.tvFiltro.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvFiltro_AfterCheck);
            // 
            // FrmVisibilidadColumnas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(188, 238);
            this.ControlBox = false;
            this.Controls.Add(this.tvFiltro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmVisibilidadColumnas";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FrmVisibilidadColumnas_Deactivate);
            this.Load += new System.EventHandler(this.FrmVisiibilidadColumnas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVisibilidadColumnas_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TreeView tvFiltro;
    }
}