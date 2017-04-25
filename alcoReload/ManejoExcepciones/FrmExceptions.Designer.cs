namespace ManejoExcepciones
{
    partial class FrmExceptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExceptions));
            this.pgpropiedades = new System.Windows.Forms.PropertyGrid();
            this.lbmensaje = new System.Windows.Forms.Label();
            this.btnok = new System.Windows.Forms.Button();
            this.tlpacomodador = new System.Windows.Forms.TableLayoutPanel();
            this.pbicono = new System.Windows.Forms.PictureBox();
            this.iml = new System.Windows.Forms.ImageList(this.components);
            this.llbenviar = new System.Windows.Forms.LinkLabel();
            this.gbdescripcionsituacion = new System.Windows.Forms.GroupBox();
            this.rtbdescripcion = new System.Windows.Forms.RichTextBox();
            this.tlpacomodador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbicono)).BeginInit();
            this.gbdescripcionsituacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgpropiedades
            // 
            this.pgpropiedades.HelpVisible = false;
            this.pgpropiedades.Location = new System.Drawing.Point(12, 82);
            this.pgpropiedades.Name = "pgpropiedades";
            this.pgpropiedades.Size = new System.Drawing.Size(422, 172);
            this.pgpropiedades.TabIndex = 0;
            this.pgpropiedades.ToolbarVisible = false;
            // 
            // lbmensaje
            // 
            this.lbmensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbmensaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbmensaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbmensaje.Location = new System.Drawing.Point(68, 0);
            this.lbmensaje.MaximumSize = new System.Drawing.Size(350, 0);
            this.lbmensaje.Name = "lbmensaje";
            this.lbmensaje.Size = new System.Drawing.Size(350, 63);
            this.lbmensaje.TabIndex = 1;
            this.lbmensaje.Text = "--";
            // 
            // btnok
            // 
            this.btnok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnok.Location = new System.Drawing.Point(359, 352);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "Cerrar";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // tlpacomodador
            // 
            this.tlpacomodador.ColumnCount = 2;
            this.tlpacomodador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.49296F));
            this.tlpacomodador.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.50704F));
            this.tlpacomodador.Controls.Add(this.lbmensaje, 1, 0);
            this.tlpacomodador.Controls.Add(this.pbicono, 0, 0);
            this.tlpacomodador.Location = new System.Drawing.Point(12, 13);
            this.tlpacomodador.Name = "tlpacomodador";
            this.tlpacomodador.RowCount = 1;
            this.tlpacomodador.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpacomodador.Size = new System.Drawing.Size(422, 63);
            this.tlpacomodador.TabIndex = 3;
            // 
            // pbicono
            // 
            this.pbicono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbicono.Location = new System.Drawing.Point(3, 3);
            this.pbicono.Name = "pbicono";
            this.pbicono.Size = new System.Drawing.Size(59, 57);
            this.pbicono.TabIndex = 2;
            this.pbicono.TabStop = false;
            // 
            // iml
            // 
            this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
            this.iml.TransparentColor = System.Drawing.Color.Transparent;
            this.iml.Images.SetKeyName(0, "critical.png");
            this.iml.Images.SetKeyName(1, "warning.png");
            // 
            // llbenviar
            // 
            this.llbenviar.AutoSize = true;
            this.llbenviar.Location = new System.Drawing.Point(9, 362);
            this.llbenviar.Name = "llbenviar";
            this.llbenviar.Size = new System.Drawing.Size(88, 13);
            this.llbenviar.TabIndex = 4;
            this.llbenviar.TabStop = true;
            this.llbenviar.Text = "Enviar por correo";
            this.llbenviar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbenviar_LinkClicked);
            // 
            // gbdescripcionsituacion
            // 
            this.gbdescripcionsituacion.Controls.Add(this.rtbdescripcion);
            this.gbdescripcionsituacion.Location = new System.Drawing.Point(12, 261);
            this.gbdescripcionsituacion.Name = "gbdescripcionsituacion";
            this.gbdescripcionsituacion.Size = new System.Drawing.Size(422, 80);
            this.gbdescripcionsituacion.TabIndex = 5;
            this.gbdescripcionsituacion.TabStop = false;
            this.gbdescripcionsituacion.Text = "Descripción situación";
            // 
            // rtbdescripcion
            // 
            this.rtbdescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbdescripcion.Location = new System.Drawing.Point(3, 16);
            this.rtbdescripcion.MaxLength = 1000;
            this.rtbdescripcion.Name = "rtbdescripcion";
            this.rtbdescripcion.Size = new System.Drawing.Size(416, 61);
            this.rtbdescripcion.TabIndex = 0;
            this.rtbdescripcion.Text = "";
            // 
            // FrmExceptions
            // 
            this.AcceptButton = this.btnok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnok;
            this.ClientSize = new System.Drawing.Size(446, 384);
            this.Controls.Add(this.gbdescripcionsituacion);
            this.Controls.Add(this.llbenviar);
            this.Controls.Add(this.tlpacomodador);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.pgpropiedades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmExceptions";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alco";
            this.Load += new System.EventHandler(this.FrmExceptions_Load);
            this.tlpacomodador.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbicono)).EndInit();
            this.gbdescripcionsituacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid pgpropiedades;
        private System.Windows.Forms.Label lbmensaje;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.TableLayoutPanel tlpacomodador;
        private System.Windows.Forms.PictureBox pbicono;
        private System.Windows.Forms.ImageList iml;
        private System.Windows.Forms.LinkLabel llbenviar;
        private System.Windows.Forms.GroupBox gbdescripcionsituacion;
        private System.Windows.Forms.RichTextBox rtbdescripcion;
    }
}