<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaCobroDirecta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentaCobroDirecta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblClienteYO = New System.Windows.Forms.Label()
        Me.lblNitYO = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.itObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.itCodigoObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.itCliente = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.itNit = New ControlesPersonalizados.Intellisens.intellises()
        Me.cmbEncargado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDocumentos = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.dwMovimiento = New System.Windows.Forms.DataGridView()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnAgregarFila = New System.Windows.Forms.ToolStripButton()
        Me.facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantDisponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_concepto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.item_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_cantidadOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_undMedia = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.item_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_precioCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_motivo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.item_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_precioOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_porcentOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_motivoCambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_actualizarPrecio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gbEncabezado.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        CType(Me.dwMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsHerramientas.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbEncabezado
        '
        Me.gbEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEncabezado.Controls.Add(Me.txtVendedor)
        Me.gbEncabezado.Controls.Add(Me.Label9)
        Me.gbEncabezado.Controls.Add(Me.lblClienteYO)
        Me.gbEncabezado.Controls.Add(Me.lblNitYO)
        Me.gbEncabezado.Controls.Add(Me.Label12)
        Me.gbEncabezado.Controls.Add(Me.Label11)
        Me.gbEncabezado.Controls.Add(Me.Label8)
        Me.gbEncabezado.Controls.Add(Me.itObra)
        Me.gbEncabezado.Controls.Add(Me.Label7)
        Me.gbEncabezado.Controls.Add(Me.itCodigoObra)
        Me.gbEncabezado.Controls.Add(Me.Label6)
        Me.gbEncabezado.Controls.Add(Me.itCliente)
        Me.gbEncabezado.Controls.Add(Me.Label5)
        Me.gbEncabezado.Controls.Add(Me.itNit)
        Me.gbEncabezado.Controls.Add(Me.cmbEncargado)
        Me.gbEncabezado.Controls.Add(Me.Label4)
        Me.gbEncabezado.Controls.Add(Me.cmbProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label3)
        Me.gbEncabezado.Controls.Add(Me.lblConsecutivo)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.cmbDocumentos)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 12)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(942, 140)
        Me.gbEncabezado.TabIndex = 1
        Me.gbEncabezado.TabStop = False
        Me.gbEncabezado.Text = "Encabezado"
        '
        'txtVendedor
        '
        Me.txtVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(859, 36)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(61, 20)
        Me.txtVendedor.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(856, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Vendedor"
        '
        'lblClienteYO
        '
        Me.lblClienteYO.AutoSize = True
        Me.lblClienteYO.Location = New System.Drawing.Point(297, 114)
        Me.lblClienteYO.Name = "lblClienteYO"
        Me.lblClienteYO.Size = New System.Drawing.Size(13, 13)
        Me.lblClienteYO.TabIndex = 22
        Me.lblClienteYO.Text = "--"
        '
        'lblNitYO
        '
        Me.lblNitYO.AutoSize = True
        Me.lblNitYO.Location = New System.Drawing.Point(64, 114)
        Me.lblNitYO.Name = "lblNitYO"
        Me.lblNitYO.Size = New System.Drawing.Size(13, 13)
        Me.lblNitYO.TabIndex = 21
        Me.lblNitYO.Text = "--"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(226, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Cliente Y/O:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Nit Y/O:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(583, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Obra"
        '
        'itObra
        '
        Me.itObra.AlternativeColumn = "idObra"
        Me.itObra.ColToReturn = "nombreObra"
        Me.itObra.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.itObra.ColumnsToShow = New String() {"idObra", "nombreObra"}
        Me.itObra.Dropdown_Width = 250
        Me.itObra.Id_Column_Name = "idObra"
        Me.itObra.Location = New System.Drawing.Point(588, 79)
        Me.itObra.Maximo_Items_DropDown = 5
        Me.itObra.Name = "itObra"
        Me.itObra.selected_item = Nothing
        Me.itObra.Seleted_rowid = Nothing
        Me.itObra.Size = New System.Drawing.Size(260, 20)
        Me.itObra.TabIndex = 14
        Me.itObra.TablaFuente = Nothing
        Me.itObra.Value2 = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(443, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Código obra"
        '
        'itCodigoObra
        '
        Me.itCodigoObra.AlternativeColumn = "nombreObra"
        Me.itCodigoObra.ColToReturn = "idObra"
        Me.itCodigoObra.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.itCodigoObra.ColumnsToShow = New String() {"idObra", "nombreObra"}
        Me.itCodigoObra.Dropdown_Width = 250
        Me.itCodigoObra.Id_Column_Name = "idObra"
        Me.itCodigoObra.Location = New System.Drawing.Point(446, 79)
        Me.itCodigoObra.Maximo_Items_DropDown = 5
        Me.itCodigoObra.Name = "itCodigoObra"
        Me.itCodigoObra.selected_item = Nothing
        Me.itCodigoObra.Seleted_rowid = Nothing
        Me.itCodigoObra.Size = New System.Drawing.Size(113, 20)
        Me.itCodigoObra.TabIndex = 12
        Me.itCodigoObra.TablaFuente = Nothing
        Me.itCodigoObra.Value2 = Nothing
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(155, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cliente"
        '
        'itCliente
        '
        Me.itCliente.AlternativeColumn = "nit"
        Me.itCliente.ColToReturn = "nombreCliente"
        Me.itCliente.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itCliente.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itCliente.Dropdown_Width = 250
        Me.itCliente.Id_Column_Name = "idCliente"
        Me.itCliente.Location = New System.Drawing.Point(158, 79)
        Me.itCliente.Maximo_Items_DropDown = 5
        Me.itCliente.Name = "itCliente"
        Me.itCliente.selected_item = Nothing
        Me.itCliente.Seleted_rowid = Nothing
        Me.itCliente.Size = New System.Drawing.Size(260, 20)
        Me.itCliente.TabIndex = 10
        Me.itCliente.TablaFuente = Nothing
        Me.itCliente.Value2 = Nothing
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Nit"
        '
        'itNit
        '
        Me.itNit.AlternativeColumn = "nombreCliente"
        Me.itNit.ColToReturn = "nit"
        Me.itNit.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itNit.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itNit.Dropdown_Width = 250
        Me.itNit.Id_Column_Name = "idCliente"
        Me.itNit.Location = New System.Drawing.Point(15, 79)
        Me.itNit.Maximo_Items_DropDown = 5
        Me.itNit.Name = "itNit"
        Me.itNit.selected_item = Nothing
        Me.itNit.Seleted_rowid = Nothing
        Me.itNit.Size = New System.Drawing.Size(113, 20)
        Me.itNit.TabIndex = 8
        Me.itNit.TablaFuente = Nothing
        Me.itNit.Value2 = Nothing
        '
        'cmbEncargado
        '
        Me.cmbEncargado.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbEncargado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEncargado.DropDownHeight = 200
        Me.cmbEncargado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEncargado.DropDownWidth = 300
        Me.cmbEncargado.IntegralHeight = False
        Me.cmbEncargado.Location = New System.Drawing.Point(446, 35)
        Me.cmbEncargado.Name = "cmbEncargado"
        Me.cmbEncargado.Size = New System.Drawing.Size(188, 21)
        Me.cmbEncargado.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(443, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Encargado"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbProveedor.DropDownHeight = 200
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.DropDownWidth = 300
        Me.cmbProveedor.IntegralHeight = False
        Me.cmbProveedor.Location = New System.Drawing.Point(230, 35)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(188, 21)
        Me.cmbProveedor.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(227, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Proveedor"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.Location = New System.Drawing.Point(120, 35)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 15)
        Me.lblConsecutivo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Consecutivo"
        '
        'cmbDocumentos
        '
        Me.cmbDocumentos.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbDocumentos.DropDownHeight = 200
        Me.cmbDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentos.DropDownWidth = 300
        Me.cmbDocumentos.IntegralHeight = False
        Me.cmbDocumentos.Location = New System.Drawing.Point(15, 35)
        Me.cmbDocumentos.Name = "cmbDocumentos"
        Me.cmbDocumentos.Size = New System.Drawing.Size(77, 21)
        Me.cmbDocumentos.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento"
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMovimiento.Controls.Add(Me.Label10)
        Me.gbMovimiento.Controls.Add(Me.txtObservaciones)
        Me.gbMovimiento.Controls.Add(Me.dwMovimiento)
        Me.gbMovimiento.Controls.Add(Me.tsHerramientas)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 158)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(942, 318)
        Me.gbMovimiento.TabIndex = 2
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(6, 249)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(914, 63)
        Me.txtObservaciones.TabIndex = 2
        '
        'dwMovimiento
        '
        Me.dwMovimiento.AllowUserToAddRows = False
        Me.dwMovimiento.AllowUserToDeleteRows = False
        Me.dwMovimiento.AllowUserToResizeColumns = False
        Me.dwMovimiento.AllowUserToResizeRows = False
        Me.dwMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwMovimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwMovimiento.BackgroundColor = System.Drawing.Color.White
        Me.dwMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwMovimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_concepto, Me.item_descripcion, Me.item_cantidadOrden, Me.item_undMedia, Me.item_precioUnitario, Me.item_precioCliente, Me.item_subtotal, Me.item_porcRetenido, Me.item_motivo, Me.item_facturable, Me.item_precioOriginal, Me.item_porcentOriginal, Me.item_motivoCambio, Me.item_actualizarPrecio})
        Me.dwMovimiento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwMovimiento.Location = New System.Drawing.Point(6, 44)
        Me.dwMovimiento.MultiSelect = False
        Me.dwMovimiento.Name = "dwMovimiento"
        Me.dwMovimiento.RowHeadersVisible = False
        Me.dwMovimiento.Size = New System.Drawing.Size(914, 186)
        Me.dwMovimiento.TabIndex = 1
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAgregarFila})
        Me.tsHerramientas.Location = New System.Drawing.Point(3, 16)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(936, 25)
        Me.tsHerramientas.TabIndex = 0
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnAgregarFila
        '
        Me.btnAgregarFila.Image = CType(resources.GetObject("btnAgregarFila.Image"), System.Drawing.Image)
        Me.btnAgregarFila.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAgregarFila.Name = "btnAgregarFila"
        Me.btnAgregarFila.Size = New System.Drawing.Size(88, 22)
        Me.btnAgregarFila.Text = "Agregar fila"
        '
        'facturable
        '
        Me.facturable.HeaderText = "Facturable"
        Me.facturable.Name = "facturable"
        Me.facturable.ReadOnly = True
        Me.facturable.Width = 63
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 88
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cantidad orden"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 96
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Precio unitario"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 91
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Precio cliente"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 88
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Subtotal"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 71
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Retenido (%)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 85
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.ImagenporDefecto = Nothing
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.Width = 41
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.Width = 78
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'cantTotal
        '
        Me.cantTotal.HeaderText = "Cantidad total"
        Me.cantTotal.Name = "cantTotal"
        Me.cantTotal.ReadOnly = True
        Me.cantTotal.Width = 97
        '
        'cantDisponible
        '
        Me.cantDisponible.HeaderText = "Cantidad disponibla"
        Me.cantDisponible.Name = "cantDisponible"
        Me.cantDisponible.ReadOnly = True
        Me.cantDisponible.Width = 124
        '
        'cantidadCuenta
        '
        Me.cantidadCuenta.HeaderText = "Cantidad cuenta"
        Me.cantidadCuenta.Name = "cantidadCuenta"
        Me.cantidadCuenta.ReadOnly = True
        Me.cantidadCuenta.Width = 110
        '
        'unMedida
        '
        Me.unMedida.HeaderText = "Unidad medida"
        Me.unMedida.Name = "unMedida"
        Me.unMedida.ReadOnly = True
        Me.unMedida.Width = 103
        '
        'precioUnitario
        '
        Me.precioUnitario.HeaderText = "Precio unitario"
        Me.precioUnitario.Name = "precioUnitario"
        Me.precioUnitario.ReadOnly = True
        Me.precioUnitario.Width = 99
        '
        'subtotal
        '
        Me.subtotal.HeaderText = "Subtotal"
        Me.subtotal.Name = "subtotal"
        Me.subtotal.ReadOnly = True
        Me.subtotal.Width = 71
        '
        'porcRetenido
        '
        Me.porcRetenido.HeaderText = "Porcentaje retenido"
        Me.porcRetenido.Name = "porcRetenido"
        Me.porcRetenido.ReadOnly = True
        Me.porcRetenido.Width = 124
        '
        'tipo
        '
        Me.tipo.HeaderText = "Tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.Width = 53
        '
        'notas
        '
        Me.notas.HeaderText = "Notas"
        Me.notas.Name = "notas"
        Me.notas.ReadOnly = True
        Me.notas.Width = 60
        '
        'item_concepto
        '
        Me.item_concepto.HeaderText = "Concepto"
        Me.item_concepto.Name = "item_concepto"
        Me.item_concepto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.item_concepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.item_concepto.Width = 78
        '
        'item_descripcion
        '
        Me.item_descripcion.HeaderText = "Descripción"
        Me.item_descripcion.Name = "item_descripcion"
        Me.item_descripcion.ReadOnly = True
        Me.item_descripcion.Width = 88
        '
        'item_cantidadOrden
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.item_cantidadOrden.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_cantidadOrden.HeaderText = "Cantidad orden"
        Me.item_cantidadOrden.Name = "item_cantidadOrden"
        Me.item_cantidadOrden.Width = 96
        '
        'item_undMedia
        '
        Me.item_undMedia.HeaderText = "Unidad medida"
        Me.item_undMedia.Name = "item_undMedia"
        Me.item_undMedia.ReadOnly = True
        Me.item_undMedia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.item_undMedia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.item_undMedia.Width = 95
        '
        'item_precioUnitario
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C0"
        Me.item_precioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_precioUnitario.HeaderText = "Precio unitario"
        Me.item_precioUnitario.Name = "item_precioUnitario"
        Me.item_precioUnitario.ReadOnly = True
        Me.item_precioUnitario.Width = 91
        '
        'item_precioCliente
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.item_precioCliente.DefaultCellStyle = DataGridViewCellStyle3
        Me.item_precioCliente.HeaderText = "Precio cliente"
        Me.item_precioCliente.Name = "item_precioCliente"
        Me.item_precioCliente.Width = 88
        '
        'item_subtotal
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        Me.item_subtotal.DefaultCellStyle = DataGridViewCellStyle4
        Me.item_subtotal.HeaderText = "Subtotal"
        Me.item_subtotal.Name = "item_subtotal"
        Me.item_subtotal.ReadOnly = True
        Me.item_subtotal.Width = 71
        '
        'item_porcRetenido
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.Format = "N2"
        Me.item_porcRetenido.DefaultCellStyle = DataGridViewCellStyle5
        Me.item_porcRetenido.HeaderText = "Retenido (%)"
        Me.item_porcRetenido.Name = "item_porcRetenido"
        Me.item_porcRetenido.ReadOnly = True
        Me.item_porcRetenido.Width = 85
        '
        'item_motivo
        '
        Me.item_motivo.HeaderText = "Motivo"
        Me.item_motivo.Name = "item_motivo"
        Me.item_motivo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.item_motivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.item_motivo.Width = 64
        '
        'item_facturable
        '
        Me.item_facturable.HeaderText = "Facturable"
        Me.item_facturable.Name = "item_facturable"
        Me.item_facturable.Width = 63
        '
        'item_precioOriginal
        '
        Me.item_precioOriginal.HeaderText = "Precio original"
        Me.item_precioOriginal.Name = "item_precioOriginal"
        Me.item_precioOriginal.ReadOnly = True
        Me.item_precioOriginal.Visible = False
        Me.item_precioOriginal.Width = 90
        '
        'item_porcentOriginal
        '
        Me.item_porcentOriginal.HeaderText = "Por - original"
        Me.item_porcentOriginal.Name = "item_porcentOriginal"
        Me.item_porcentOriginal.ReadOnly = True
        Me.item_porcentOriginal.Visible = False
        Me.item_porcentOriginal.Width = 83
        '
        'item_motivoCambio
        '
        Me.item_motivoCambio.HeaderText = "Motivo cambio"
        Me.item_motivoCambio.Name = "item_motivoCambio"
        Me.item_motivoCambio.ReadOnly = True
        Me.item_motivoCambio.Visible = False
        Me.item_motivoCambio.Width = 93
        '
        'item_actualizarPrecio
        '
        Me.item_actualizarPrecio.HeaderText = "Actualizar precio"
        Me.item_actualizarPrecio.Name = "item_actualizarPrecio"
        Me.item_actualizarPrecio.ReadOnly = True
        Me.item_actualizarPrecio.Visible = False
        Me.item_actualizarPrecio.Width = 82
        '
        'frmCuentaCobroDirecta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 488)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaCobroDirecta"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Cuenta cobro directa"
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        Me.gbMovimiento.PerformLayout()
        CType(Me.dwMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbEncabezado As GroupBox
    Friend WithEvents cmbEncargado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProveedor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label3 As Label
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDocumentos As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents itObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label7 As Label
    Friend WithEvents itCodigoObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label6 As Label
    Friend WithEvents itCliente As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label5 As Label
    Friend WithEvents itNit As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents gbMovimiento As GroupBox

    Friend WithEvents id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents concepto As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents cantTotal As DataGridViewTextBoxColumn
    Friend WithEvents cantDisponible As DataGridViewTextBoxColumn
    Friend WithEvents cantidadCuenta As DataGridViewTextBoxColumn
    Friend WithEvents unMedida As DataGridViewTextBoxColumn
    Friend WithEvents precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents subtotal As DataGridViewTextBoxColumn
    Friend WithEvents porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents tipo As DataGridViewTextBoxColumn
    Friend WithEvents facturable As DataGridViewCheckBoxColumn
    Friend WithEvents notas As DataGridViewTextBoxColumn
    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnAgregarFila As ToolStripButton
    Friend WithEvents dwMovimiento As DataGridView
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblClienteYO As Label
    Friend WithEvents lblNitYO As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents item_concepto As DataGridViewComboBoxColumn
    Friend WithEvents item_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents item_cantidadOrden As DataGridViewTextBoxColumn
    Friend WithEvents item_undMedia As DataGridViewComboBoxColumn
    Friend WithEvents item_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents item_precioCliente As DataGridViewTextBoxColumn
    Friend WithEvents item_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents item_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents item_motivo As DataGridViewComboBoxColumn
    Friend WithEvents item_facturable As DataGridViewCheckBoxColumn
    Friend WithEvents item_precioOriginal As DataGridViewTextBoxColumn
    Friend WithEvents item_porcentOriginal As DataGridViewTextBoxColumn
    Friend WithEvents item_motivoCambio As DataGridViewTextBoxColumn
    Friend WithEvents item_actualizarPrecio As DataGridViewCheckBoxColumn
End Class
