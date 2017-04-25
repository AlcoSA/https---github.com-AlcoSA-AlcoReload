namespace RichTextboxExtendido
{
    partial class DocumentoExtendido
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
            this.tlpBaseDoc = new System.Windows.Forms.TableLayoutPanel();
            this.txtheader = new RichTextboxExtendido.ParteDocumento();
            this.txtbody = new RichTextboxExtendido.ParteDocumento();
            this.txtfooter = new RichTextboxExtendido.ParteDocumento();
            this.tlpBaseDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBaseDoc
            // 
            this.tlpBaseDoc.BackColor = System.Drawing.SystemColors.Window;
            this.tlpBaseDoc.ColumnCount = 1;
            this.tlpBaseDoc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaseDoc.Controls.Add(this.txtheader, 0, 0);
            this.tlpBaseDoc.Controls.Add(this.txtbody, 0, 1);
            this.tlpBaseDoc.Controls.Add(this.txtfooter, 0, 2);
            this.tlpBaseDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBaseDoc.Location = new System.Drawing.Point(0, 0);
            this.tlpBaseDoc.Name = "tlpBaseDoc";
            this.tlpBaseDoc.RowCount = 3;
            this.tlpBaseDoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpBaseDoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBaseDoc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpBaseDoc.Size = new System.Drawing.Size(814, 1054);
            this.tlpBaseDoc.TabIndex = 0;
            // 
            // txtheader
            // 
            this.txtheader.BackColor = System.Drawing.SystemColors.Window;
            this.txtheader.BlockOnMargin = true;
            this.txtheader.BorderColor = System.Drawing.Color.LightGray;
            this.txtheader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtheader.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtheader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtheader.DocumentPartName = "Encabezado";
            this.txtheader.DrawBottomBorder = true;
            this.txtheader.DrawLeftBorder = true;
            this.txtheader.DrawPartName = true;
            this.txtheader.DrawRightBorder = true;
            this.txtheader.DrawTopBorder = true;
            this.txtheader.EnableAutoDragDrop = true;
            this.txtheader.Location = new System.Drawing.Point(0, 0);
            this.txtheader.Margin = new System.Windows.Forms.Padding(0);
            this.txtheader.MarginColor = System.Drawing.Color.LightGray;
            this.txtheader.Name = "txtheader";
            this.txtheader.ReadOnly = true;
            this.txtheader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtheader.Size = new System.Drawing.Size(814, 56);
            this.txtheader.TabIndex = 1;
            this.txtheader.TabStop = false;
            this.txtheader.Text = "";
            this.txtheader.Enter += new System.EventHandler(this.DocPart_Enter);
            this.txtheader.Leave += new System.EventHandler(this.Dpart_Sec_Leave);
            this.txtheader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Dpart_Sec_MouseDoubleClick);
            // 
            // txtbody
            // 
            this.txtbody.AcceptsTab = true;
            this.txtbody.AllowDrop = true;
            this.txtbody.BackColor = System.Drawing.SystemColors.Window;
            this.txtbody.BlockOnMargin = true;
            this.txtbody.BorderColor = System.Drawing.Color.LightGray;
            this.txtbody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbody.BulletIndent = 1;
            this.txtbody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbody.DocumentPartName = "Body";
            this.txtbody.DrawBottomBorder = true;
            this.txtbody.DrawLeftBorder = true;
            this.txtbody.DrawPartName = false;
            this.txtbody.DrawRightBorder = true;
            this.txtbody.DrawTopBorder = true;
            this.txtbody.EnableAutoDragDrop = true;
            this.txtbody.Location = new System.Drawing.Point(0, 56);
            this.txtbody.Margin = new System.Windows.Forms.Padding(0);
            this.txtbody.MarginColor = System.Drawing.Color.LightGray;
            this.txtbody.Name = "txtbody";
            this.txtbody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtbody.ShowSelectionMargin = true;
            this.txtbody.Size = new System.Drawing.Size(814, 942);
            this.txtbody.TabIndex = 0;
            this.txtbody.Text = "";
            this.txtbody.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.txtbody_ContentsResized);
            this.txtbody.Enter += new System.EventHandler(this.DocPart_Enter);
            // 
            // txtfooter
            // 
            this.txtfooter.BackColor = System.Drawing.SystemColors.Window;
            this.txtfooter.BlockOnMargin = true;
            this.txtfooter.BorderColor = System.Drawing.Color.LightGray;
            this.txtfooter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtfooter.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtfooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtfooter.DocumentPartName = "Pie de Pagina";
            this.txtfooter.DrawBottomBorder = true;
            this.txtfooter.DrawLeftBorder = true;
            this.txtfooter.DrawPartName = true;
            this.txtfooter.DrawRightBorder = true;
            this.txtfooter.DrawTopBorder = true;
            this.txtfooter.EnableAutoDragDrop = true;
            this.txtfooter.Location = new System.Drawing.Point(0, 998);
            this.txtfooter.Margin = new System.Windows.Forms.Padding(0);
            this.txtfooter.MarginColor = System.Drawing.Color.LightGray;
            this.txtfooter.Name = "txtfooter";
            this.txtfooter.ReadOnly = true;
            this.txtfooter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtfooter.Size = new System.Drawing.Size(814, 56);
            this.txtfooter.TabIndex = 2;
            this.txtfooter.TabStop = false;
            this.txtfooter.Text = "";
            this.txtfooter.Enter += new System.EventHandler(this.DocPart_Enter);
            this.txtfooter.Leave += new System.EventHandler(this.Dpart_Sec_Leave);
            this.txtfooter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Dpart_Sec_MouseDoubleClick);
            // 
            // DocumentoExtendido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpBaseDoc);
            this.MaximumSize = new System.Drawing.Size(816, 1056);
            this.MinimumSize = new System.Drawing.Size(816, 1056);
            this.Name = "DocumentoExtendido";
            this.Size = new System.Drawing.Size(814, 1054);
            this.tlpBaseDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpBaseDoc;
        protected ParteDocumento txtbody;
        protected ParteDocumento txtheader;
        protected ParteDocumento txtfooter;
    }
}
