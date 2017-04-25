<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEsquemasContratos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEsquemasContratos))
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnminutas = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtnombredocumento = New System.Windows.Forms.ToolStripTextBox()
        Me.editordocumentos = New ControlesPersonalizados.Editor_RTF.EditorRTF()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cbtipoformato = New System.Windows.Forms.ToolStripComboBox()
        Me.tsherramientas.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnminutas, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.txtnombredocumento, Me.ToolStripLabel2, Me.cbtipoformato})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(682, 25)
        Me.tsherramientas.TabIndex = 0
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnminutas
        '
        Me.btnminutas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnminutas.Image = CType(resources.GetObject("btnminutas.Image"), System.Drawing.Image)
        Me.btnminutas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnminutas.Name = "btnminutas"
        Me.btnminutas.Size = New System.Drawing.Size(32, 22)
        Me.btnminutas.Text = "Formatos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripLabel1.Text = "Nombre Documento:"
        '
        'txtnombredocumento
        '
        Me.txtnombredocumento.Name = "txtnombredocumento"
        Me.txtnombredocumento.Size = New System.Drawing.Size(200, 25)
        '
        'editordocumentos
        '
        Me.editordocumentos.AltoEncabezado = New Decimal(New Integer() {125, 0, 0, 131072})
        Me.editordocumentos.AltoPiedePagina = New Decimal(New Integer() {125, 0, 0, 131072})
        Me.editordocumentos.BackColor = System.Drawing.Color.White
        Me.editordocumentos.Cuerpo = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editordocumentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editordocumentos.Encabezado = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editordocumentos.Location = New System.Drawing.Point(0, 25)
        Me.editordocumentos.Name = "editordocumentos"
        Me.editordocumentos.PiedePagina = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editordocumentos.Size = New System.Drawing.Size(682, 403)
        Me.editordocumentos.TabIndex = 1
        Me.editordocumentos.TablasValoresVariables = Nothing
        Me.editordocumentos.TablaVariables = Nothing
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel2.Text = "Tipo Formato"
        '
        'cbtipoformato
        '
        Me.cbtipoformato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipoformato.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cbtipoformato.Name = "cbtipoformato"
        Me.cbtipoformato.Size = New System.Drawing.Size(121, 25)
        '
        'frmEsquemasContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 428)
        Me.Controls.Add(Me.editordocumentos)
        Me.Controls.Add(Me.tsherramientas)
        Me.Name = "frmEsquemasContratos"
        Me.ShowIcon = False
        Me.Text = "Minutas Contratos"
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnminutas As ToolStripSplitButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtnombredocumento As ToolStripTextBox
    Friend WithEvents editordocumentos As ControlesPersonalizados.Editor_RTF.EditorRTF
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cbtipoformato As ToolStripComboBox
End Class
