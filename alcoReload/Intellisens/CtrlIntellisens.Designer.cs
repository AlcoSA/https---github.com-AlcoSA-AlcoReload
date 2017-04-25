namespace Intellisens
{
    partial class CtrlIntellisens
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
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.Txt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.Dgv.BackgroundColor = System.Drawing.Color.White;
            this.Dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv.Location = new System.Drawing.Point(4, 23);
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersVisible = false;
            this.Dgv.Size = new System.Drawing.Size(200, 69);
            this.Dgv.TabIndex = 1;
            this.Dgv.Visible = false;
            this.Dgv.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.Dgv_ColumnAdded);
            // 
            // Txt
            // 
            this.Txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txt.Location = new System.Drawing.Point(4, 3);
            this.Txt.Name = "Txt";
            this.Txt.Size = new System.Drawing.Size(100, 20);
            this.Txt.TabIndex = 2;
            this.Txt.TextChanged += new System.EventHandler(this.Txt_TextChanged);
            this.Txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_KeyPress);
            // 
            // CtrlIntellisens
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Txt);
            this.Controls.Add(this.Dgv);
            this.Name = "CtrlIntellisens";
            this.Size = new System.Drawing.Size(210, 93);
            this.Load += new System.EventHandler(this.CtrlIntellisens_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.TextBox Txt;
    }
}
