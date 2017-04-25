<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddPoliza
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddPoliza))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsControls = New System.Windows.Forms.ToolStrip()
        Me.btnGuardado = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.txtSuc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNumContrato = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodSuc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.numPoliza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaInicio = New DateTimeGridColumn()
        Me.fechaVencimiento = New DateTimeGridColumn()
        Me.valorAsegurado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aseguradora = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsControls.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsControls
        '
        Me.tsControls.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardado})
        Me.tsControls.Location = New System.Drawing.Point(0, 0)
        Me.tsControls.Name = "tsControls"
        Me.tsControls.Size = New System.Drawing.Size(877, 25)
        Me.tsControls.TabIndex = 0
        Me.tsControls.Text = "ToolStrip1"
        '
        'btnGuardado
        '
        Me.btnGuardado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardado.Image = CType(resources.GetObject("btnGuardado.Image"), System.Drawing.Image)
        Me.btnGuardado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardado.Name = "btnGuardado"
        Me.btnGuardado.Size = New System.Drawing.Size(23, 22)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(313, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nit"
        '
        'txtNit
        '
        Me.txtNit.Enabled = False
        Me.txtNit.Location = New System.Drawing.Point(339, 40)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(235, 20)
        Me.txtNit.TabIndex = 4
        '
        'txtSuc
        '
        Me.txtSuc.Enabled = False
        Me.txtSuc.Location = New System.Drawing.Point(339, 92)
        Me.txtSuc.Name = "txtSuc"
        Me.txtSuc.Size = New System.Drawing.Size(235, 20)
        Me.txtSuc.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(303, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Obra"
        '
        'txtCliente
        '
        Me.txtCliente.Enabled = False
        Me.txtCliente.Location = New System.Drawing.Point(108, 66)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(466, 20)
        Me.txtCliente.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(63, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cliente"
        '
        'txtNumContrato
        '
        Me.txtNumContrato.Enabled = False
        Me.txtNumContrato.Location = New System.Drawing.Point(108, 40)
        Me.txtNumContrato.Name = "txtNumContrato"
        Me.txtNumContrato.Size = New System.Drawing.Size(170, 20)
        Me.txtNumContrato.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Número contrato"
        '
        'txtCodSuc
        '
        Me.txtCodSuc.Enabled = False
        Me.txtCodSuc.Location = New System.Drawing.Point(108, 92)
        Me.txtCodSuc.Name = "txtCodSuc"
        Me.txtCodSuc.Size = New System.Drawing.Size(170, 20)
        Me.txtCodSuc.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Código sucursal"
        '
        'dwItems
        '
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.concepto, Me.numPoliza, Me.anexo, Me.fechaInicio, Me.fechaVencimiento, Me.valorAsegurado, Me.aseguradora, Me.observaciones, Me.idEstado, Me.estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(822, 250)
        Me.dwItems.TabIndex = 0
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 134)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(832, 260)
        Me.Panel.TabIndex = 11
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.Width = 59
        '
        'numPoliza
        '
        Me.numPoliza.HeaderText = "Número póliza"
        Me.numPoliza.Name = "numPoliza"
        Me.numPoliza.Width = 99
        '
        'anexo
        '
        Me.anexo.HeaderText = "Anexo"
        Me.anexo.Name = "anexo"
        Me.anexo.Width = 62
        '
        'fechaInicio
        '
        Me.fechaInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Format = "dd/MM/yyyy"
        DataGridViewCellStyle1.NullValue = "01/01/1999"
        Me.fechaInicio.DefaultCellStyle = DataGridViewCellStyle1
        Me.fechaInicio.HeaderText = "Fecha inicio"
        Me.fechaInicio.Name = "fechaInicio"
        Me.fechaInicio.Width = 90
        '
        'fechaVencimiento
        '
        Me.fechaVencimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = "01/01/1999"
        Me.fechaVencimiento.DefaultCellStyle = DataGridViewCellStyle2
        Me.fechaVencimiento.HeaderText = "Vencimiento"
        Me.fechaVencimiento.Name = "fechaVencimiento"
        Me.fechaVencimiento.Width = 90
        '
        'valorAsegurado
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.valorAsegurado.DefaultCellStyle = DataGridViewCellStyle3
        Me.valorAsegurado.HeaderText = "Valor asegurado"
        Me.valorAsegurado.Name = "valorAsegurado"
        '
        'aseguradora
        '
        Me.aseguradora.HeaderText = "Aseguradora"
        Me.aseguradora.Name = "aseguradora"
        Me.aseguradora.Width = 73
        '
        'observaciones
        '
        Me.observaciones.HeaderText = "Observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.observaciones.Width = 84
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id Estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 71
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Visible = False
        Me.estado.Width = 65
        '
        'FrmAddPoliza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 406)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.txtCodSuc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNumContrato)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSuc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tsControls)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddPoliza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Póliza por contrato"
        Me.tsControls.ResumeLayout(False)
        Me.tsControls.PerformLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsControls As ToolStrip
    Friend WithEvents btnGuardado As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNit As TextBox
    Friend WithEvents txtSuc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNumContrato As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCodSuc As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents Panel As Panel
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents concepto As DataGridViewComboBoxColumn
    Friend WithEvents numPoliza As DataGridViewTextBoxColumn
    Friend WithEvents anexo As DataGridViewTextBoxColumn
    Friend WithEvents fechaInicio As DateTimeGridColumn
    Friend WithEvents fechaVencimiento As DateTimeGridColumn
    Friend WithEvents valorAsegurado As DataGridViewTextBoxColumn
    Friend WithEvents aseguradora As DataGridViewComboBoxColumn
    Friend WithEvents observaciones As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
