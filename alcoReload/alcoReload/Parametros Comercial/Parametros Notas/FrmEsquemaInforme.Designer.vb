<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEsquemaInforme
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEsquemaInforme))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbPorcentaje = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbTotalCuotas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNumCuota = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbValorContrato = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbObjetoNota = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNumContrato = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbTipoNota = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPieDePagina = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pieDePagina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorDefecto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cbValorDefecto = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbTipoNota = New System.Windows.Forms.ComboBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo nota"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.AllowDrop = True
        Me.txtDescripcion.Location = New System.Drawing.Point(31, 89)
        Me.txtDescripcion.MaxLength = 1000
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(1066, 111)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Esquema detalle nota de cobro"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowDrop = True
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbPorcentaje, Me.ToolStripSeparator1, Me.tsbTotalCuotas, Me.ToolStripSeparator2, Me.tsbNumCuota, Me.ToolStripSeparator3, Me.tsbValorContrato, Me.ToolStripSeparator4, Me.tsbObjetoNota, Me.ToolStripSeparator5, Me.tsbNumContrato, Me.ToolStripSeparator6, Me.tsbTipoNota, Me.ToolStripSeparator7})
        Me.ToolStrip1.Location = New System.Drawing.Point(31, 203)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1066, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbPorcentaje
        '
        Me.tsbPorcentaje.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbPorcentaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbPorcentaje.Image = CType(resources.GetObject("tsbPorcentaje.Image"), System.Drawing.Image)
        Me.tsbPorcentaje.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPorcentaje.Name = "tsbPorcentaje"
        Me.tsbPorcentaje.Size = New System.Drawing.Size(67, 22)
        Me.tsbPorcentaje.Tag = "{porcentaje}"
        Me.tsbPorcentaje.Text = "Porcentaje"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbTotalCuotas
        '
        Me.tsbTotalCuotas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbTotalCuotas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbTotalCuotas.Image = CType(resources.GetObject("tsbTotalCuotas.Image"), System.Drawing.Image)
        Me.tsbTotalCuotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTotalCuotas.Name = "tsbTotalCuotas"
        Me.tsbTotalCuotas.Size = New System.Drawing.Size(75, 22)
        Me.tsbTotalCuotas.Tag = "{cantidad_cuotas}"
        Me.tsbTotalCuotas.Text = "Total cuotas"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNumCuota
        '
        Me.tsbNumCuota.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbNumCuota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNumCuota.Image = CType(resources.GetObject("tsbNumCuota.Image"), System.Drawing.Image)
        Me.tsbNumCuota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNumCuota.Name = "tsbNumCuota"
        Me.tsbNumCuota.Size = New System.Drawing.Size(53, 22)
        Me.tsbNumCuota.Tag = "{num_cuota}"
        Me.tsbNumCuota.Text = "# Cuota"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbValorContrato
        '
        Me.tsbValorContrato.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbValorContrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbValorContrato.Image = CType(resources.GetObject("tsbValorContrato.Image"), System.Drawing.Image)
        Me.tsbValorContrato.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbValorContrato.Name = "tsbValorContrato"
        Me.tsbValorContrato.Size = New System.Drawing.Size(67, 22)
        Me.tsbValorContrato.Tag = "{valor_contrato}"
        Me.tsbValorContrato.Text = "$ Contrato"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbObjetoNota
        '
        Me.tsbObjetoNota.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbObjetoNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbObjetoNota.Image = CType(resources.GetObject("tsbObjetoNota.Image"), System.Drawing.Image)
        Me.tsbObjetoNota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbObjetoNota.Name = "tsbObjetoNota"
        Me.tsbObjetoNota.Size = New System.Drawing.Size(74, 22)
        Me.tsbObjetoNota.Tag = "{objeto_nota}"
        Me.tsbObjetoNota.Text = "Objeto nota"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNumContrato
        '
        Me.tsbNumContrato.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbNumContrato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbNumContrato.Image = CType(resources.GetObject("tsbNumContrato.Image"), System.Drawing.Image)
        Me.tsbNumContrato.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNumContrato.Name = "tsbNumContrato"
        Me.tsbNumContrato.Size = New System.Drawing.Size(68, 22)
        Me.tsbNumContrato.Tag = "{num_contrato}"
        Me.tsbNumContrato.Text = "# Contrato"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbTipoNota
        '
        Me.tsbTipoNota.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbTipoNota.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbTipoNota.Image = CType(resources.GetObject("tsbTipoNota.Image"), System.Drawing.Image)
        Me.tsbTipoNota.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbTipoNota.Name = "tsbTipoNota"
        Me.tsbTipoNota.Size = New System.Drawing.Size(62, 22)
        Me.tsbTipoNota.Tag = "{tipo_nota}"
        Me.tsbTipoNota.Text = "Tipo nota"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Pie de página nota de cobro"
        '
        'txtPieDePagina
        '
        Me.txtPieDePagina.Location = New System.Drawing.Point(31, 244)
        Me.txtPieDePagina.MaxLength = 1000
        Me.txtPieDePagina.Multiline = True
        Me.txtPieDePagina.Name = "txtPieDePagina"
        Me.txtPieDePagina.Size = New System.Drawing.Size(1066, 67)
        Me.txtPieDePagina.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 341)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Lista de esquemas actuales"
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.fechaCreacion, Me.usuarioCreacion, Me.idTipoNota, Me.tipoNota, Me.descripcion, Me.pieDePagina, Me.fechaModi, Me.usuarioModi, Me.valorDefecto})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(31, 357)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(1066, 162)
        Me.dwItems.TabIndex = 8
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 22
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Visible = False
        Me.fechaCreacion.Width = 87
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Visible = False
        Me.usuarioCreacion.Width = 93
        '
        'idTipoNota
        '
        Me.idTipoNota.HeaderText = "Id tipo nota"
        Me.idTipoNota.Name = "idTipoNota"
        Me.idTipoNota.ReadOnly = True
        Me.idTipoNota.Visible = False
        Me.idTipoNota.Width = 66
        '
        'tipoNota
        '
        Me.tipoNota.HeaderText = "Tipo de nota"
        Me.tipoNota.Name = "tipoNota"
        Me.tipoNota.ReadOnly = True
        Me.tipoNota.Width = 85
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Detalle"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 65
        '
        'pieDePagina
        '
        Me.pieDePagina.HeaderText = "Pie de página"
        Me.pieDePagina.Name = "pieDePagina"
        Me.pieDePagina.ReadOnly = True
        Me.pieDePagina.Width = 89
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Visible = False
        Me.fechaModi.Width = 124
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Visible = False
        Me.usuarioModi.Width = 130
        '
        'valorDefecto
        '
        Me.valorDefecto.HeaderText = "Valor por defecto"
        Me.valorDefecto.Name = "valorDefecto"
        Me.valorDefecto.ReadOnly = True
        Me.valorDefecto.Width = 85
        '
        'cbValorDefecto
        '
        Me.cbValorDefecto.AutoSize = True
        Me.cbValorDefecto.Location = New System.Drawing.Point(990, 317)
        Me.cbValorDefecto.Name = "cbValorDefecto"
        Me.cbValorDefecto.Size = New System.Drawing.Size(107, 17)
        Me.cbValorDefecto.TabIndex = 9
        Me.cbValorDefecto.Text = "Valor por defecto"
        Me.cbValorDefecto.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha creación"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Usuario creación"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Id tipo nota"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tipo de nota"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 85
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Detalle"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 65
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Pie de página"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha modificación"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Usuario modificación"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        '
        'cmbTipoNota
        '
        Me.cmbTipoNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNota.FormattingEnabled = True
        Me.cmbTipoNota.Location = New System.Drawing.Point(31, 34)
        Me.cmbTipoNota.Name = "cmbTipoNota"
        Me.cmbTipoNota.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoNota.TabIndex = 10
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrmEsquemaInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1125, 531)
        Me.Controls.Add(Me.cmbTipoNota)
        Me.Controls.Add(Me.cbValorDefecto)
        Me.Controls.Add(Me.dwItems)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPieDePagina)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmEsquemaInforme"
        Me.ShowIcon = False
        Me.Text = "Esquema informe"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPieDePagina As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents tsbPorcentaje As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbTotalCuotas As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbNumCuota As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbValorContrato As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsbObjetoNota As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsbNumContrato As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbTipoNota As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents cbValorDefecto As CheckBox
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idTipoNota As DataGridViewTextBoxColumn
    Friend WithEvents tipoNota As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents pieDePagina As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents valorDefecto As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents cmbTipoNota As ComboBox
    Friend WithEvents ErrorProvider As ErrorProvider
End Class
