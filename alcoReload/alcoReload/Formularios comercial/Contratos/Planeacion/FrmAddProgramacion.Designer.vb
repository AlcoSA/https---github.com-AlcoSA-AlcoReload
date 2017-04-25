<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddProgramacion
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddProgramacion))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.txtConstructora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigoSucursal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumeroContrato = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRegion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaFin = New System.Windows.Forms.TextBox()
        Me.txtValorContrato = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalUnidades = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.lblVendedor = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTotalPuntos = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtMetros = New System.Windows.Forms.TextBox()
        Me.gbInfoContrato = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbInfoItems = New System.Windows.Forms.GroupBox()
        Me.lblPtsProgramados = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPuntosSelec = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtMetrosSelec = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUnidadesSelec = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_totalPuntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_puntosSinPlanear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.puntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewImageColumn()
        Me.fechaSemana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroSemana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbInfoContrato.SuspendLayout()
        Me.gbInfoItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(76, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nit:"
        '
        'txtNit
        '
        Me.txtNit.Enabled = False
        Me.txtNit.Location = New System.Drawing.Point(105, 24)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.ReadOnly = True
        Me.txtNit.Size = New System.Drawing.Size(150, 20)
        Me.txtNit.TabIndex = 1
        '
        'txtConstructora
        '
        Me.txtConstructora.Enabled = False
        Me.txtConstructora.Location = New System.Drawing.Point(105, 50)
        Me.txtConstructora.Name = "txtConstructora"
        Me.txtConstructora.ReadOnly = True
        Me.txtConstructora.Size = New System.Drawing.Size(336, 20)
        Me.txtConstructora.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Constructora:"
        '
        'txtObra
        '
        Me.txtObra.Enabled = False
        Me.txtObra.Location = New System.Drawing.Point(105, 76)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.ReadOnly = True
        Me.txtObra.Size = New System.Drawing.Size(336, 20)
        Me.txtObra.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Obra:"
        '
        'txtCodigoSucursal
        '
        Me.txtCodigoSucursal.Enabled = False
        Me.txtCodigoSucursal.Location = New System.Drawing.Point(355, 24)
        Me.txtCodigoSucursal.Name = "txtCodigoSucursal"
        Me.txtCodigoSucursal.ReadOnly = True
        Me.txtCodigoSucursal.Size = New System.Drawing.Size(86, 20)
        Me.txtCodigoSucursal.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(278, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cod sucursal:"
        '
        'txtNumeroContrato
        '
        Me.txtNumeroContrato.Enabled = False
        Me.txtNumeroContrato.Location = New System.Drawing.Point(105, 102)
        Me.txtNumeroContrato.Name = "txtNumeroContrato"
        Me.txtNumeroContrato.ReadOnly = True
        Me.txtNumeroContrato.Size = New System.Drawing.Size(120, 20)
        Me.txtNumeroContrato.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Número contrato:"
        '
        'txtRegion
        '
        Me.txtRegion.Enabled = False
        Me.txtRegion.Location = New System.Drawing.Point(321, 102)
        Me.txtRegion.Name = "txtRegion"
        Me.txtRegion.ReadOnly = True
        Me.txtRegion.Size = New System.Drawing.Size(120, 20)
        Me.txtRegion.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(271, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Región:"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Enabled = False
        Me.txtFechaInicio.Location = New System.Drawing.Point(555, 24)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.ReadOnly = True
        Me.txtFechaInicio.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaInicio.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(482, 31)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Fecha inicio:"
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Enabled = False
        Me.txtFechaFin.Location = New System.Drawing.Point(757, 24)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.ReadOnly = True
        Me.txtFechaFin.Size = New System.Drawing.Size(120, 20)
        Me.txtFechaFin.TabIndex = 15
        '
        'txtValorContrato
        '
        Me.txtValorContrato.Enabled = False
        Me.txtValorContrato.Location = New System.Drawing.Point(555, 50)
        Me.txtValorContrato.Name = "txtValorContrato"
        Me.txtValorContrato.ReadOnly = True
        Me.txtValorContrato.Size = New System.Drawing.Size(120, 20)
        Me.txtValorContrato.TabIndex = 27
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(473, 57)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Valor contrato:"
        '
        'txtTotalUnidades
        '
        Me.txtTotalUnidades.Enabled = False
        Me.txtTotalUnidades.Location = New System.Drawing.Point(555, 76)
        Me.txtTotalUnidades.Name = "txtTotalUnidades"
        Me.txtTotalUnidades.ReadOnly = True
        Me.txtTotalUnidades.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalUnidades.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(469, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Total unidades:"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 265)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(889, 230)
        Me.Panel.TabIndex = 28
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.item_id, Me.item_ubicacion, Me.item_descripcion, Me.item_totalPuntos, Me.item_puntosSinPlanear, Me.puntos, Me.fecha, Me.fechaSemana, Me.numeroSemana, Me.mes, Me.anio, Me.concepto})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(879, 220)
        Me.dwItems.TabIndex = 0
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.lblVendedor, Me.ToolStripLabel2})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(923, 25)
        Me.tsMenu.TabIndex = 30
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "ToolStripButton1"
        '
        'lblVendedor
        '
        Me.lblVendedor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblVendedor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblVendedor.Name = "lblVendedor"
        Me.lblVendedor.Size = New System.Drawing.Size(54, 22)
        Me.lblVendedor.Text = "//Vend"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripLabel2.Text = "Vendedor:"
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "Planeacion 17x17.png")
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IdProgramación"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 106
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Puntos"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 65
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha semana"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 102
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "# semana"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 79
        '
        'txtTotalPuntos
        '
        Me.txtTotalPuntos.Enabled = False
        Me.txtTotalPuntos.Location = New System.Drawing.Point(757, 76)
        Me.txtTotalPuntos.Name = "txtTotalPuntos"
        Me.txtTotalPuntos.ReadOnly = True
        Me.txtTotalPuntos.Size = New System.Drawing.Size(120, 20)
        Me.txtTotalPuntos.TabIndex = 29
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(682, 83)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(69, 13)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Total puntos:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(709, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Metros:"
        '
        'txtMetros
        '
        Me.txtMetros.Enabled = False
        Me.txtMetros.Location = New System.Drawing.Point(757, 50)
        Me.txtMetros.Name = "txtMetros"
        Me.txtMetros.ReadOnly = True
        Me.txtMetros.Size = New System.Drawing.Size(120, 20)
        Me.txtMetros.TabIndex = 34
        '
        'gbInfoContrato
        '
        Me.gbInfoContrato.Controls.Add(Me.txtNit)
        Me.gbInfoContrato.Controls.Add(Me.txtTotalPuntos)
        Me.gbInfoContrato.Controls.Add(Me.Label4)
        Me.gbInfoContrato.Controls.Add(Me.Label20)
        Me.gbInfoContrato.Controls.Add(Me.txtCodigoSucursal)
        Me.gbInfoContrato.Controls.Add(Me.Label1)
        Me.gbInfoContrato.Controls.Add(Me.txtConstructora)
        Me.gbInfoContrato.Controls.Add(Me.Label3)
        Me.gbInfoContrato.Controls.Add(Me.txtFechaFin)
        Me.gbInfoContrato.Controls.Add(Me.txtObra)
        Me.gbInfoContrato.Controls.Add(Me.Label8)
        Me.gbInfoContrato.Controls.Add(Me.Label2)
        Me.gbInfoContrato.Controls.Add(Me.Label7)
        Me.gbInfoContrato.Controls.Add(Me.txtNumeroContrato)
        Me.gbInfoContrato.Controls.Add(Me.txtFechaInicio)
        Me.gbInfoContrato.Controls.Add(Me.Label15)
        Me.gbInfoContrato.Controls.Add(Me.Label6)
        Me.gbInfoContrato.Controls.Add(Me.Label9)
        Me.gbInfoContrato.Controls.Add(Me.txtTotalUnidades)
        Me.gbInfoContrato.Controls.Add(Me.txtMetros)
        Me.gbInfoContrato.Controls.Add(Me.txtRegion)
        Me.gbInfoContrato.Controls.Add(Me.txtValorContrato)
        Me.gbInfoContrato.Controls.Add(Me.Label10)
        Me.gbInfoContrato.Controls.Add(Me.Label5)
        Me.gbInfoContrato.Location = New System.Drawing.Point(12, 28)
        Me.gbInfoContrato.Name = "gbInfoContrato"
        Me.gbInfoContrato.Size = New System.Drawing.Size(889, 147)
        Me.gbInfoContrato.TabIndex = 35
        Me.gbInfoContrato.TabStop = False
        Me.gbInfoContrato.Text = "Información contrato"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(697, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Fecha fin:"
        '
        'gbInfoItems
        '
        Me.gbInfoItems.Controls.Add(Me.lblPtsProgramados)
        Me.gbInfoItems.Controls.Add(Me.Label14)
        Me.gbInfoItems.Controls.Add(Me.txtPuntosSelec)
        Me.gbInfoItems.Controls.Add(Me.Label13)
        Me.gbInfoItems.Controls.Add(Me.txtMetrosSelec)
        Me.gbInfoItems.Controls.Add(Me.Label12)
        Me.gbInfoItems.Controls.Add(Me.txtUnidadesSelec)
        Me.gbInfoItems.Controls.Add(Me.Label11)
        Me.gbInfoItems.Location = New System.Drawing.Point(12, 181)
        Me.gbInfoItems.Name = "gbInfoItems"
        Me.gbInfoItems.Size = New System.Drawing.Size(889, 78)
        Me.gbInfoItems.TabIndex = 36
        Me.gbInfoItems.TabStop = False
        Me.gbInfoItems.Text = "Items seleccionados"
        '
        'lblPtsProgramados
        '
        Me.lblPtsProgramados.AutoSize = True
        Me.lblPtsProgramados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPtsProgramados.Location = New System.Drawing.Point(473, 41)
        Me.lblPtsProgramados.Name = "lblPtsProgramados"
        Me.lblPtsProgramados.Size = New System.Drawing.Size(0, 17)
        Me.lblPtsProgramados.TabIndex = 42
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(473, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Puntos"
        '
        'txtPuntosSelec
        '
        Me.txtPuntosSelec.Enabled = False
        Me.txtPuntosSelec.Location = New System.Drawing.Point(331, 38)
        Me.txtPuntosSelec.Name = "txtPuntosSelec"
        Me.txtPuntosSelec.ReadOnly = True
        Me.txtPuntosSelec.Size = New System.Drawing.Size(120, 20)
        Me.txtPuntosSelec.TabIndex = 40
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(328, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Puntos"
        '
        'txtMetrosSelec
        '
        Me.txtMetrosSelec.Enabled = False
        Me.txtMetrosSelec.Location = New System.Drawing.Point(179, 38)
        Me.txtMetrosSelec.Name = "txtMetrosSelec"
        Me.txtMetrosSelec.ReadOnly = True
        Me.txtMetrosSelec.Size = New System.Drawing.Size(120, 20)
        Me.txtMetrosSelec.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(176, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Metros"
        '
        'txtUnidadesSelec
        '
        Me.txtUnidadesSelec.Enabled = False
        Me.txtUnidadesSelec.Location = New System.Drawing.Point(23, 38)
        Me.txtUnidadesSelec.Name = "txtUnidadesSelec"
        Me.txtUnidadesSelec.ReadOnly = True
        Me.txtUnidadesSelec.Size = New System.Drawing.Size(120, 20)
        Me.txtUnidadesSelec.TabIndex = 36
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(20, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "Unidades"
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 41
        '
        'item_id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.item_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_id.HeaderText = "Id item"
        Me.item_id.Name = "item_id"
        Me.item_id.ReadOnly = True
        Me.item_id.Visible = False
        Me.item_id.Width = 63
        '
        'item_ubicacion
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.item_ubicacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_ubicacion.HeaderText = "Ubicación"
        Me.item_ubicacion.Name = "item_ubicacion"
        Me.item_ubicacion.ReadOnly = True
        Me.item_ubicacion.Width = 80
        '
        'item_descripcion
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.item_descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.item_descripcion.HeaderText = "Descripción"
        Me.item_descripcion.Name = "item_descripcion"
        Me.item_descripcion.ReadOnly = True
        Me.item_descripcion.Width = 88
        '
        'item_totalPuntos
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.item_totalPuntos.DefaultCellStyle = DataGridViewCellStyle4
        Me.item_totalPuntos.HeaderText = "Total puntos"
        Me.item_totalPuntos.Name = "item_totalPuntos"
        Me.item_totalPuntos.ReadOnly = True
        Me.item_totalPuntos.Width = 91
        '
        'item_puntosSinPlanear
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.item_puntosSinPlanear.DefaultCellStyle = DataGridViewCellStyle5
        Me.item_puntosSinPlanear.HeaderText = "Puntos sin planear"
        Me.item_puntosSinPlanear.Name = "item_puntosSinPlanear"
        Me.item_puntosSinPlanear.ReadOnly = True
        Me.item_puntosSinPlanear.Width = 119
        '
        'puntos
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.puntos.DefaultCellStyle = DataGridViewCellStyle6
        Me.puntos.HeaderText = "Puntos"
        Me.puntos.Name = "puntos"
        Me.puntos.Width = 65
        '
        'fecha
        '
        Me.fecha.HeaderText = ""
        Me.fecha.Image = CType(resources.GetObject("fecha.Image"), System.Drawing.Image)
        Me.fecha.Name = "fecha"
        Me.fecha.Width = 5
        '
        'fechaSemana
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.fechaSemana.DefaultCellStyle = DataGridViewCellStyle7
        Me.fechaSemana.HeaderText = "Fecha semana"
        Me.fechaSemana.Name = "fechaSemana"
        Me.fechaSemana.ReadOnly = True
        Me.fechaSemana.Width = 102
        '
        'numeroSemana
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        Me.numeroSemana.DefaultCellStyle = DataGridViewCellStyle8
        Me.numeroSemana.HeaderText = "# semana"
        Me.numeroSemana.Name = "numeroSemana"
        Me.numeroSemana.ReadOnly = True
        Me.numeroSemana.Visible = False
        Me.numeroSemana.Width = 79
        '
        'mes
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        Me.mes.DefaultCellStyle = DataGridViewCellStyle9
        Me.mes.HeaderText = "# mes"
        Me.mes.Name = "mes"
        Me.mes.ReadOnly = True
        Me.mes.Visible = False
        Me.mes.Width = 61
        '
        'anio
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        Me.anio.DefaultCellStyle = DataGridViewCellStyle10
        Me.anio.HeaderText = "# Año"
        Me.anio.Name = "anio"
        Me.anio.ReadOnly = True
        Me.anio.Visible = False
        Me.anio.Width = 61
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.concepto.Width = 59
        '
        'FrmAddProgramacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 507)
        Me.Controls.Add(Me.gbInfoItems)
        Me.Controls.Add(Me.gbInfoContrato)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddProgramacion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar programación"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbInfoContrato.ResumeLayout(False)
        Me.gbInfoContrato.PerformLayout()
        Me.gbInfoItems.ResumeLayout(False)
        Me.gbInfoItems.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtNit As TextBox
    Friend WithEvents txtConstructora As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigoSucursal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNumeroContrato As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRegion As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFechaInicio As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFechaFin As TextBox
    Friend WithEvents txtValorContrato As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalUnidades As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents imgList As ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents txtTotalPuntos As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lblVendedor As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents txtMetros As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents gbInfoItems As GroupBox
    Friend WithEvents txtPuntosSelec As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtMetrosSelec As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtUnidadesSelec As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents gbInfoContrato As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPtsProgramados As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents item_id As DataGridViewTextBoxColumn
    Friend WithEvents item_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents item_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents item_totalPuntos As DataGridViewTextBoxColumn
    Friend WithEvents item_puntosSinPlanear As DataGridViewTextBoxColumn
    Friend WithEvents puntos As DataGridViewTextBoxColumn
    Friend WithEvents fecha As DataGridViewImageColumn
    Friend WithEvents fechaSemana As DataGridViewTextBoxColumn
    Friend WithEvents numeroSemana As DataGridViewTextBoxColumn
    Friend WithEvents mes As DataGridViewTextBoxColumn
    Friend WithEvents anio As DataGridViewTextBoxColumn
    Friend WithEvents concepto As DataGridViewComboBoxColumn
End Class
