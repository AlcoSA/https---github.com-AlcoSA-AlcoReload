<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnvio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEnvio))
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCuerpo = New System.Windows.Forms.TextBox()
        Me.dwAdjuntos = New System.Windows.Forms.DataGridView()
        Me.col_imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.panelPDF = New System.Windows.Forms.Panel()
        Me.lectorPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.bwCargas = New System.ComponentModel.BackgroundWorker()
        CType(Me.dwAdjuntos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPDF.SuspendLayout()
        CType(Me.lectorPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDestino
        '
        Me.txtDestino.Location = New System.Drawing.Point(12, 27)
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(366, 20)
        Me.txtDestino.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Para"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Asunto"
        '
        'txtAsunto
        '
        Me.txtAsunto.Location = New System.Drawing.Point(12, 66)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(366, 20)
        Me.txtAsunto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mensaje"
        '
        'txtCuerpo
        '
        Me.txtCuerpo.Location = New System.Drawing.Point(12, 105)
        Me.txtCuerpo.Multiline = True
        Me.txtCuerpo.Name = "txtCuerpo"
        Me.txtCuerpo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCuerpo.Size = New System.Drawing.Size(366, 242)
        Me.txtCuerpo.TabIndex = 5
        '
        'dwAdjuntos
        '
        Me.dwAdjuntos.AllowUserToAddRows = False
        Me.dwAdjuntos.AllowUserToDeleteRows = False
        Me.dwAdjuntos.AllowUserToResizeColumns = False
        Me.dwAdjuntos.AllowUserToResizeRows = False
        Me.dwAdjuntos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dwAdjuntos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwAdjuntos.BackgroundColor = System.Drawing.Color.White
        Me.dwAdjuntos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwAdjuntos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_imagen, Me.col_ruta, Me.col_nombreArchivo, Me.col_formato})
        Me.dwAdjuntos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwAdjuntos.Location = New System.Drawing.Point(12, 366)
        Me.dwAdjuntos.MultiSelect = False
        Me.dwAdjuntos.Name = "dwAdjuntos"
        Me.dwAdjuntos.ReadOnly = True
        Me.dwAdjuntos.RowHeadersVisible = False
        Me.dwAdjuntos.Size = New System.Drawing.Size(366, 96)
        Me.dwAdjuntos.TabIndex = 7
        '
        'col_imagen
        '
        Me.col_imagen.HeaderText = ""
        Me.col_imagen.Image = CType(resources.GetObject("col_imagen.Image"), System.Drawing.Image)
        Me.col_imagen.Name = "col_imagen"
        Me.col_imagen.ReadOnly = True
        Me.col_imagen.Width = 5
        '
        'col_ruta
        '
        Me.col_ruta.HeaderText = "Ruta"
        Me.col_ruta.Name = "col_ruta"
        Me.col_ruta.ReadOnly = True
        Me.col_ruta.Visible = False
        Me.col_ruta.Width = 36
        '
        'col_nombreArchivo
        '
        Me.col_nombreArchivo.HeaderText = "Nombre archivo"
        Me.col_nombreArchivo.Name = "col_nombreArchivo"
        Me.col_nombreArchivo.ReadOnly = True
        Me.col_nombreArchivo.Width = 107
        '
        'col_formato
        '
        Me.col_formato.HeaderText = "Formato"
        Me.col_formato.Name = "col_formato"
        Me.col_formato.ReadOnly = True
        Me.col_formato.Visible = False
        Me.col_formato.Width = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 350)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Archivos adjuntos"
        '
        'panelPDF
        '
        Me.panelPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPDF.Controls.Add(Me.lectorPDF)
        Me.panelPDF.Location = New System.Drawing.Point(397, 11)
        Me.panelPDF.Name = "panelPDF"
        Me.panelPDF.Size = New System.Drawing.Size(475, 451)
        Me.panelPDF.TabIndex = 8
        '
        'lectorPDF
        '
        Me.lectorPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lectorPDF.Enabled = True
        Me.lectorPDF.Location = New System.Drawing.Point(0, 0)
        Me.lectorPDF.Name = "lectorPDF"
        Me.lectorPDF.OcxState = CType(resources.GetObject("lectorPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.lectorPDF.Size = New System.Drawing.Size(471, 447)
        Me.lectorPDF.TabIndex = 0
        '
        'btnEnviar
        '
        Me.btnEnviar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnviar.Location = New System.Drawing.Point(136, 468)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(118, 36)
        Me.btnEnviar.TabIndex = 9
        Me.btnEnviar.Text = "Enviar"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(260, 468)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(118, 36)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'bwCargas
        '
        '
        'FrmEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 516)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.panelPDF)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dwAdjuntos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCuerpo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAsunto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEnvio"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envío "
        CType(Me.dwAdjuntos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPDF.ResumeLayout(False)
        CType(Me.lectorPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDestino As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAsunto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCuerpo As TextBox
    Friend WithEvents dwAdjuntos As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents panelPDF As Panel
    Friend WithEvents lectorPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents col_imagen As DataGridViewImageColumn
    Friend WithEvents col_ruta As DataGridViewTextBoxColumn
    Friend WithEvents col_nombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents col_formato As DataGridViewTextBoxColumn
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents bwCargas As System.ComponentModel.BackgroundWorker
End Class
