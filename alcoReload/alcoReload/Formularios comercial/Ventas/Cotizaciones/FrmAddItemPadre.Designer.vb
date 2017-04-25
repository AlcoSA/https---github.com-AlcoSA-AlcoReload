<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddItemPadre
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
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddItemPadre))
        Me.nudcantidad = New System.Windows.Forms.NumericUpDown()
        Me.nudalto = New System.Windows.Forms.NumericUpDown()
        Me.nudancho = New System.Windows.Forms.NumericUpDown()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.txtUbicacion = New System.Windows.Forms.TextBox()
        Me.lbEspesor = New System.Windows.Forms.Label()
        Me.lbVidrio = New System.Windows.Forms.Label()
        Me.lbAcabado = New System.Windows.Forms.Label()
        Me.lbCantidad = New System.Windows.Forms.Label()
        Me.lbAlto = New System.Windows.Forms.Label()
        Me.lbAncho = New System.Windows.Forms.Label()
        Me.lbDescripcion = New System.Windows.Forms.Label()
        Me.lbUbicacion = New System.Windows.Forms.Label()
        Me.gpComponentes = New System.Windows.Forms.GroupBox()
        Me.dwItem = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idArticuloTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.piezasXUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtCuadrados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prcDesperdicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabadoPerf = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.vidrio = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colorVidrio = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioMtInstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioInstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoinstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoPerfiles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoAccesorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoOtros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrDesperdicioVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrDesperdicioPerfiles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrDespedicioAccesorios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vlrDespOtros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.especial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actualizar_plantilla = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idTasaImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tasaImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.espesorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.calcular_nsr = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cumplenorma = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.numero_cuerpos_norma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tselementos = New System.Windows.Forms.ToolStrip()
        Me.btnplantilla = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddAccesorio = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddPerfil = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddVidrio = New System.Windows.Forms.ToolStripButton()
        Me.tsbAddOtros = New System.Windows.Forms.ToolStripButton()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnguardarcerrar = New System.Windows.Forms.ToolStripButton()
        Me.btncolpanel = New System.Windows.Forms.ToolStripButton()
        Me.nudDescuento = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.scgenpadre = New System.Windows.Forms.SplitContainer()
        Me.cmbuminstala = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nuddescuentoinstalacion = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudtasa = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudPrecioInstalacion = New System.Windows.Forms.NumericUpDown()
        Me.cmbcolorvidrio = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.cmbAcabado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.cmbEspesores = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.cmbVidrio = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.tlpestructurador = New System.Windows.Forms.TableLayoutPanel()
        Me.egmodelo = New ControlesPersonalizados.Estructurador.EstructuradorGrafico()
        Me.nudhorizontal = New System.Windows.Forms.NumericUpDown()
        Me.nudvertical = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        CType(Me.nudcantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudalto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudancho, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpComponentes.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tselementos.SuspendLayout()
        Me.tsherramientas.SuspendLayout()
        CType(Me.nudDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scgenpadre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scgenpadre.Panel1.SuspendLayout()
        Me.scgenpadre.Panel2.SuspendLayout()
        Me.scgenpadre.SuspendLayout()
        CType(Me.nuddescuentoinstalacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudtasa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPrecioInstalacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpestructurador.SuspendLayout()
        CType(Me.nudhorizontal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudvertical, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudcantidad
        '
        Me.nudcantidad.Location = New System.Drawing.Point(178, 64)
        Me.nudcantidad.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudcantidad.Name = "nudcantidad"
        Me.nudcantidad.Size = New System.Drawing.Size(89, 20)
        Me.nudcantidad.TabIndex = 12
        '
        'nudalto
        '
        Me.nudalto.Location = New System.Drawing.Point(95, 64)
        Me.nudalto.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudalto.Name = "nudalto"
        Me.nudalto.Size = New System.Drawing.Size(71, 20)
        Me.nudalto.TabIndex = 9
        '
        'nudancho
        '
        Me.nudancho.Location = New System.Drawing.Point(14, 64)
        Me.nudancho.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudancho.Name = "nudancho"
        Me.nudancho.Size = New System.Drawing.Size(69, 20)
        Me.nudancho.TabIndex = 6
        '
        'txtdescripcion
        '
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.Location = New System.Drawing.Point(366, 26)
        Me.txtdescripcion.MaxLength = 40
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(487, 20)
        Me.txtdescripcion.TabIndex = 4
        '
        'txtUbicacion
        '
        Me.txtUbicacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUbicacion.Location = New System.Drawing.Point(15, 26)
        Me.txtUbicacion.MaxLength = 22
        Me.txtUbicacion.Name = "txtUbicacion"
        Me.txtUbicacion.Size = New System.Drawing.Size(332, 20)
        Me.txtUbicacion.TabIndex = 2
        '
        'lbEspesor
        '
        Me.lbEspesor.AutoSize = True
        Me.lbEspesor.Location = New System.Drawing.Point(654, 49)
        Me.lbEspesor.Name = "lbEspesor"
        Me.lbEspesor.Size = New System.Drawing.Size(48, 13)
        Me.lbEspesor.TabIndex = 22
        Me.lbEspesor.Text = "Espesor:"
        '
        'lbVidrio
        '
        Me.lbVidrio.AutoSize = True
        Me.lbVidrio.Location = New System.Drawing.Point(463, 49)
        Me.lbVidrio.Name = "lbVidrio"
        Me.lbVidrio.Size = New System.Drawing.Size(36, 13)
        Me.lbVidrio.TabIndex = 18
        Me.lbVidrio.Text = "Vidrio:"
        '
        'lbAcabado
        '
        Me.lbAcabado.AutoSize = True
        Me.lbAcabado.Location = New System.Drawing.Point(363, 49)
        Me.lbAcabado.Name = "lbAcabado"
        Me.lbAcabado.Size = New System.Drawing.Size(94, 13)
        Me.lbAcabado.TabIndex = 16
        Me.lbAcabado.Text = "Acabado aluminio:"
        '
        'lbCantidad
        '
        Me.lbCantidad.AutoSize = True
        Me.lbCantidad.Location = New System.Drawing.Point(175, 49)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(52, 13)
        Me.lbCantidad.TabIndex = 11
        Me.lbCantidad.Text = "Cantidad:"
        '
        'lbAlto
        '
        Me.lbAlto.AutoSize = True
        Me.lbAlto.Location = New System.Drawing.Point(92, 49)
        Me.lbAlto.Name = "lbAlto"
        Me.lbAlto.Size = New System.Drawing.Size(53, 13)
        Me.lbAlto.TabIndex = 8
        Me.lbAlto.Text = "Alto (mm):"
        '
        'lbAncho
        '
        Me.lbAncho.AutoSize = True
        Me.lbAncho.Location = New System.Drawing.Point(11, 49)
        Me.lbAncho.Name = "lbAncho"
        Me.lbAncho.Size = New System.Drawing.Size(66, 13)
        Me.lbAncho.TabIndex = 5
        Me.lbAncho.Text = "Ancho (mm):"
        '
        'lbDescripcion
        '
        Me.lbDescripcion.AutoSize = True
        Me.lbDescripcion.Location = New System.Drawing.Point(363, 10)
        Me.lbDescripcion.Name = "lbDescripcion"
        Me.lbDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lbDescripcion.TabIndex = 3
        Me.lbDescripcion.Text = "Descripción:"
        '
        'lbUbicacion
        '
        Me.lbUbicacion.AutoSize = True
        Me.lbUbicacion.Location = New System.Drawing.Point(12, 10)
        Me.lbUbicacion.Name = "lbUbicacion"
        Me.lbUbicacion.Size = New System.Drawing.Size(58, 13)
        Me.lbUbicacion.TabIndex = 1
        Me.lbUbicacion.Text = "Ubicación:"
        '
        'gpComponentes
        '
        Me.gpComponentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpComponentes.Controls.Add(Me.dwItem)
        Me.gpComponentes.Controls.Add(Me.tselementos)
        Me.gpComponentes.Location = New System.Drawing.Point(15, 100)
        Me.gpComponentes.Name = "gpComponentes"
        Me.gpComponentes.Size = New System.Drawing.Size(1106, 434)
        Me.gpComponentes.TabIndex = 24
        Me.gpComponentes.TabStop = False
        Me.gpComponentes.Text = "Componentes"
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idArticulo, Me.idArticuloTemp, Me.referencia, Me.descripcion, Me.ancho, Me.alto, Me.cantidad, Me.piezasXUnidad, Me.mtCuadrados, Me.prcDesperdicio, Me.acabadoPerf, Me.vidrio, Me.colorVidrio, Me.espesor, Me.unidadMedida, Me.descuento, Me.valorDescuento, Me.factor, Me.tipoItem, Me.precioUnitario, Me.precioTotal, Me.precioMtInstalacion, Me.precioInstalacion, Me.costoinstalacion, Me.costoVidrio, Me.costoPerfiles, Me.costoAccesorio, Me.costoOtros, Me.costoUnitario, Me.costoTotal, Me.vlrDesperdicioVidrio, Me.vlrDesperdicioPerfiles, Me.vlrDespedicioAccesorios, Me.vlrDespOtros, Me.especial, Me.actualizar_plantilla, Me.idTasaImpuesto, Me.tasaImpuesto, Me.acabTemporal, Me.colorTemporal, Me.espesorTemporal, Me.calcular_nsr, Me.cumplenorma, Me.numero_cuerpos_norma})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.Location = New System.Drawing.Point(3, 47)
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersVisible = False
        Me.dwItem.RowHeadersWidth = 25
        Me.dwItem.Size = New System.Drawing.Size(1100, 384)
        Me.dwItem.TabIndex = 1
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 41
        '
        'idArticulo
        '
        Me.idArticulo.HeaderText = "Id"
        Me.idArticulo.Name = "idArticulo"
        Me.idArticulo.ReadOnly = True
        Me.idArticulo.Visible = False
        Me.idArticulo.Width = 41
        '
        'idArticuloTemp
        '
        Me.idArticuloTemp.HeaderText = "Id Articulo Temp"
        Me.idArticuloTemp.Name = "idArticuloTemp"
        Me.idArticuloTemp.ReadOnly = True
        Me.idArticuloTemp.Visible = False
        Me.idArticuloTemp.Width = 109
        '
        'referencia
        '
        Me.referencia.HeaderText = "Ubicación"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Width = 80
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'ancho
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.NullValue = Nothing
        Me.ancho.DefaultCellStyle = DataGridViewCellStyle24
        Me.ancho.HeaderText = "Ancho"
        Me.ancho.Name = "ancho"
        Me.ancho.Width = 63
        '
        'alto
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.NullValue = Nothing
        Me.alto.DefaultCellStyle = DataGridViewCellStyle25
        Me.alto.HeaderText = "Alto"
        Me.alto.Name = "alto"
        Me.alto.Width = 50
        '
        'cantidad
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle26
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'piezasXUnidad
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle27.Format = "N2"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.piezasXUnidad.DefaultCellStyle = DataGridViewCellStyle27
        Me.piezasXUnidad.HeaderText = "Piezas x unidad"
        Me.piezasXUnidad.Name = "piezasXUnidad"
        Me.piezasXUnidad.Width = 106
        '
        'mtCuadrados
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle28.Format = "N3"
        DataGridViewCellStyle28.NullValue = Nothing
        Me.mtCuadrados.DefaultCellStyle = DataGridViewCellStyle28
        Me.mtCuadrados.HeaderText = "Mt²"
        Me.mtCuadrados.Name = "mtCuadrados"
        Me.mtCuadrados.ReadOnly = True
        Me.mtCuadrados.Width = 47
        '
        'prcDesperdicio
        '
        Me.prcDesperdicio.HeaderText = "Porcentaje desperdicio"
        Me.prcDesperdicio.Name = "prcDesperdicio"
        Me.prcDesperdicio.ReadOnly = True
        Me.prcDesperdicio.Visible = False
        Me.prcDesperdicio.Width = 140
        '
        'acabadoPerf
        '
        Me.acabadoPerf.HeaderText = "Acabado perfilería"
        Me.acabadoPerf.Name = "acabadoPerf"
        Me.acabadoPerf.ReadOnly = True
        Me.acabadoPerf.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.acabadoPerf.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.acabadoPerf.Width = 119
        '
        'vidrio
        '
        Me.vidrio.HeaderText = "Vidrio"
        Me.vidrio.Name = "vidrio"
        Me.vidrio.ReadOnly = True
        Me.vidrio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vidrio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.vidrio.Width = 58
        '
        'colorVidrio
        '
        Me.colorVidrio.HeaderText = "Color vidrio"
        Me.colorVidrio.Name = "colorVidrio"
        Me.colorVidrio.ReadOnly = True
        Me.colorVidrio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colorVidrio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colorVidrio.Width = 84
        '
        'espesor
        '
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.ReadOnly = True
        Me.espesor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.espesor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.espesor.Width = 70
        '
        'unidadMedida
        '
        Me.unidadMedida.HeaderText = "Unidad medida"
        Me.unidadMedida.Name = "unidadMedida"
        Me.unidadMedida.ReadOnly = True
        Me.unidadMedida.Width = 103
        '
        'descuento
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.NullValue = Nothing
        Me.descuento.DefaultCellStyle = DataGridViewCellStyle29
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.Width = 84
        '
        'valorDescuento
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.Format = "N0"
        DataGridViewCellStyle30.NullValue = Nothing
        Me.valorDescuento.DefaultCellStyle = DataGridViewCellStyle30
        Me.valorDescuento.HeaderText = "valorDescuento"
        Me.valorDescuento.Name = "valorDescuento"
        Me.valorDescuento.ReadOnly = True
        Me.valorDescuento.Visible = False
        Me.valorDescuento.Width = 107
        '
        'factor
        '
        Me.factor.HeaderText = "Factor"
        Me.factor.Name = "factor"
        Me.factor.Width = 62
        '
        'tipoItem
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.tipoItem.DefaultCellStyle = DataGridViewCellStyle31
        Me.tipoItem.HeaderText = "Tipo item"
        Me.tipoItem.Name = "tipoItem"
        Me.tipoItem.ReadOnly = True
        Me.tipoItem.Width = 75
        '
        'precioUnitario
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.Format = "C0"
        DataGridViewCellStyle32.NullValue = "0"
        Me.precioUnitario.DefaultCellStyle = DataGridViewCellStyle32
        Me.precioUnitario.HeaderText = "Precio unitario"
        Me.precioUnitario.Name = "precioUnitario"
        Me.precioUnitario.ReadOnly = True
        Me.precioUnitario.Width = 99
        '
        'precioTotal
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle33.Format = "C0"
        DataGridViewCellStyle33.NullValue = Nothing
        Me.precioTotal.DefaultCellStyle = DataGridViewCellStyle33
        Me.precioTotal.HeaderText = "Precio total"
        Me.precioTotal.Name = "precioTotal"
        Me.precioTotal.ReadOnly = True
        Me.precioTotal.Width = 85
        '
        'precioMtInstalacion
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.Format = "C0"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.precioMtInstalacion.DefaultCellStyle = DataGridViewCellStyle34
        Me.precioMtInstalacion.HeaderText = "Precio Mt² instalación"
        Me.precioMtInstalacion.Name = "precioMtInstalacion"
        Me.precioMtInstalacion.ReadOnly = True
        Me.precioMtInstalacion.Width = 133
        '
        'precioInstalacion
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "C0"
        DataGridViewCellStyle35.NullValue = Nothing
        Me.precioInstalacion.DefaultCellStyle = DataGridViewCellStyle35
        Me.precioInstalacion.HeaderText = "Precio de instalación"
        Me.precioInstalacion.Name = "precioInstalacion"
        Me.precioInstalacion.ReadOnly = True
        Me.precioInstalacion.Width = 130
        '
        'costoinstalacion
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.Format = "C0"
        DataGridViewCellStyle36.NullValue = "0"
        Me.costoinstalacion.DefaultCellStyle = DataGridViewCellStyle36
        Me.costoinstalacion.HeaderText = "Costo Instalacion"
        Me.costoinstalacion.Name = "costoinstalacion"
        Me.costoinstalacion.ReadOnly = True
        Me.costoinstalacion.Width = 113
        '
        'costoVidrio
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "C0"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.costoVidrio.DefaultCellStyle = DataGridViewCellStyle37
        Me.costoVidrio.HeaderText = "Costo vidrio"
        Me.costoVidrio.Name = "costoVidrio"
        Me.costoVidrio.ReadOnly = True
        Me.costoVidrio.ToolTipText = "El costo incluye el desperdicio asignado en la pestaña configuración de la cotiza" &
    "ción"
        Me.costoVidrio.Width = 87
        '
        'costoPerfiles
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.Format = "C0"
        DataGridViewCellStyle38.NullValue = Nothing
        Me.costoPerfiles.DefaultCellStyle = DataGridViewCellStyle38
        Me.costoPerfiles.HeaderText = "Costo perfiles"
        Me.costoPerfiles.Name = "costoPerfiles"
        Me.costoPerfiles.ReadOnly = True
        Me.costoPerfiles.ToolTipText = "El costo incluye el desperdicio asignado en la pestaña configuración de la cotiza" &
    "ción"
        Me.costoPerfiles.Width = 95
        '
        'costoAccesorio
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.Format = "C0"
        DataGridViewCellStyle39.NullValue = Nothing
        Me.costoAccesorio.DefaultCellStyle = DataGridViewCellStyle39
        Me.costoAccesorio.HeaderText = "Costo accesorio"
        Me.costoAccesorio.Name = "costoAccesorio"
        Me.costoAccesorio.ReadOnly = True
        Me.costoAccesorio.ToolTipText = "El costo incluye el desperdicio asignado en la pestaña configuración de la cotiza" &
    "ción"
        Me.costoAccesorio.Width = 108
        '
        'costoOtros
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "C0"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.costoOtros.DefaultCellStyle = DataGridViewCellStyle40
        Me.costoOtros.HeaderText = "Costo otros"
        Me.costoOtros.Name = "costoOtros"
        Me.costoOtros.ReadOnly = True
        Me.costoOtros.ToolTipText = "El costo incluye el desperdicio asignado en la pestaña configuración de la cotiza" &
    "ción"
        Me.costoOtros.Width = 85
        '
        'costoUnitario
        '
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.Format = "C0"
        DataGridViewCellStyle41.NullValue = "0"
        Me.costoUnitario.DefaultCellStyle = DataGridViewCellStyle41
        Me.costoUnitario.HeaderText = "Costo unitario"
        Me.costoUnitario.Name = "costoUnitario"
        Me.costoUnitario.ReadOnly = True
        Me.costoUnitario.Width = 96
        '
        'costoTotal
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "C0"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.costoTotal.DefaultCellStyle = DataGridViewCellStyle42
        Me.costoTotal.HeaderText = "Costo total"
        Me.costoTotal.Name = "costoTotal"
        Me.costoTotal.ReadOnly = True
        Me.costoTotal.Width = 82
        '
        'vlrDesperdicioVidrio
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle43.Format = "C0"
        DataGridViewCellStyle43.NullValue = "0"
        Me.vlrDesperdicioVidrio.DefaultCellStyle = DataGridViewCellStyle43
        Me.vlrDesperdicioVidrio.HeaderText = "Vlr. Desp. Vidrios"
        Me.vlrDesperdicioVidrio.Name = "vlrDesperdicioVidrio"
        Me.vlrDesperdicioVidrio.ReadOnly = True
        Me.vlrDesperdicioVidrio.Width = 112
        '
        'vlrDesperdicioPerfiles
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle44.Format = "C0"
        DataGridViewCellStyle44.NullValue = "0"
        Me.vlrDesperdicioPerfiles.DefaultCellStyle = DataGridViewCellStyle44
        Me.vlrDesperdicioPerfiles.HeaderText = "Vlr. Desp. Perfiles"
        Me.vlrDesperdicioPerfiles.Name = "vlrDesperdicioPerfiles"
        Me.vlrDesperdicioPerfiles.Width = 115
        '
        'vlrDespedicioAccesorios
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle45.Format = "C0"
        DataGridViewCellStyle45.NullValue = "0"
        Me.vlrDespedicioAccesorios.DefaultCellStyle = DataGridViewCellStyle45
        Me.vlrDespedicioAccesorios.HeaderText = "Vlr. Desp. Accesorio"
        Me.vlrDespedicioAccesorios.Name = "vlrDespedicioAccesorios"
        Me.vlrDespedicioAccesorios.Width = 128
        '
        'vlrDespOtros
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle46.Format = "C0"
        DataGridViewCellStyle46.NullValue = "C"
        Me.vlrDespOtros.DefaultCellStyle = DataGridViewCellStyle46
        Me.vlrDespOtros.HeaderText = "Vlr. Desp. Otros"
        Me.vlrDespOtros.Name = "vlrDespOtros"
        Me.vlrDespOtros.Width = 106
        '
        'especial
        '
        Me.especial.HeaderText = "Especial"
        Me.especial.Name = "especial"
        Me.especial.ReadOnly = True
        Me.especial.Visible = False
        Me.especial.Width = 72
        '
        'actualizar_plantilla
        '
        Me.actualizar_plantilla.HeaderText = "Actualizar"
        Me.actualizar_plantilla.Name = "actualizar_plantilla"
        Me.actualizar_plantilla.ReadOnly = True
        Me.actualizar_plantilla.Width = 59
        '
        'idTasaImpuesto
        '
        Me.idTasaImpuesto.HeaderText = "idTasaImpuesto"
        Me.idTasaImpuesto.Name = "idTasaImpuesto"
        Me.idTasaImpuesto.ReadOnly = True
        Me.idTasaImpuesto.Width = 107
        '
        'tasaImpuesto
        '
        Me.tasaImpuesto.HeaderText = "tasaImpuesto"
        Me.tasaImpuesto.Name = "tasaImpuesto"
        Me.tasaImpuesto.ReadOnly = True
        Me.tasaImpuesto.Width = 95
        '
        'acabTemporal
        '
        Me.acabTemporal.HeaderText = "Acabado temporal"
        Me.acabTemporal.Name = "acabTemporal"
        Me.acabTemporal.ReadOnly = True
        Me.acabTemporal.Width = 99
        '
        'colorTemporal
        '
        Me.colorTemporal.HeaderText = "Color temporal"
        Me.colorTemporal.Name = "colorTemporal"
        Me.colorTemporal.ReadOnly = True
        Me.colorTemporal.Width = 80
        '
        'espesorTemporal
        '
        Me.espesorTemporal.HeaderText = "Espesor temporal"
        Me.espesorTemporal.Name = "espesorTemporal"
        Me.espesorTemporal.ReadOnly = True
        Me.espesorTemporal.Width = 94
        '
        'calcular_nsr
        '
        Me.calcular_nsr.HeaderText = "Calcular NSR"
        Me.calcular_nsr.Name = "calcular_nsr"
        Me.calcular_nsr.ReadOnly = True
        Me.calcular_nsr.Visible = False
        Me.calcular_nsr.Width = 77
        '
        'cumplenorma
        '
        Me.cumplenorma.HeaderText = "Cumple Norma"
        Me.cumplenorma.Name = "cumplenorma"
        Me.cumplenorma.ReadOnly = True
        Me.cumplenorma.Visible = False
        Me.cumplenorma.Width = 82
        '
        'numero_cuerpos_norma
        '
        Me.numero_cuerpos_norma.HeaderText = "Nro Cuerpos Norma"
        Me.numero_cuerpos_norma.Name = "numero_cuerpos_norma"
        Me.numero_cuerpos_norma.ReadOnly = True
        Me.numero_cuerpos_norma.Visible = False
        Me.numero_cuerpos_norma.Width = 125
        '
        'tselementos
        '
        Me.tselementos.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tselementos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnplantilla, Me.tsbAddAccesorio, Me.tsbAddPerfil, Me.tsbAddVidrio, Me.tsbAddOtros})
        Me.tselementos.Location = New System.Drawing.Point(3, 16)
        Me.tselementos.Name = "tselementos"
        Me.tselementos.Size = New System.Drawing.Size(1100, 31)
        Me.tselementos.TabIndex = 0
        Me.tselementos.Text = "ToolStrip2"
        '
        'btnplantilla
        '
        Me.btnplantilla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnplantilla.Image = CType(resources.GetObject("btnplantilla.Image"), System.Drawing.Image)
        Me.btnplantilla.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnplantilla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnplantilla.Name = "btnplantilla"
        Me.btnplantilla.Size = New System.Drawing.Size(28, 28)
        Me.btnplantilla.ToolTipText = "Adición Diseño Crtl + Alt + D"
        '
        'tsbAddAccesorio
        '
        Me.tsbAddAccesorio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddAccesorio.Image = CType(resources.GetObject("tsbAddAccesorio.Image"), System.Drawing.Image)
        Me.tsbAddAccesorio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAddAccesorio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddAccesorio.Name = "tsbAddAccesorio"
        Me.tsbAddAccesorio.Size = New System.Drawing.Size(28, 28)
        Me.tsbAddAccesorio.ToolTipText = "Adición Accesorio Crtl + Alt + A"
        '
        'tsbAddPerfil
        '
        Me.tsbAddPerfil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddPerfil.Image = CType(resources.GetObject("tsbAddPerfil.Image"), System.Drawing.Image)
        Me.tsbAddPerfil.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAddPerfil.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddPerfil.Name = "tsbAddPerfil"
        Me.tsbAddPerfil.Size = New System.Drawing.Size(28, 28)
        Me.tsbAddPerfil.Text = "Agregar existente"
        Me.tsbAddPerfil.ToolTipText = "Adición Perfiles Crtl + Alt + P"
        '
        'tsbAddVidrio
        '
        Me.tsbAddVidrio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddVidrio.Image = CType(resources.GetObject("tsbAddVidrio.Image"), System.Drawing.Image)
        Me.tsbAddVidrio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbAddVidrio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddVidrio.Name = "tsbAddVidrio"
        Me.tsbAddVidrio.Size = New System.Drawing.Size(28, 28)
        Me.tsbAddVidrio.ToolTipText = "Adición Vidrio Ctrl + Alt + V"
        '
        'tsbAddOtros
        '
        Me.tsbAddOtros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAddOtros.Image = CType(resources.GetObject("tsbAddOtros.Image"), System.Drawing.Image)
        Me.tsbAddOtros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAddOtros.Name = "tsbAddOtros"
        Me.tsbAddOtros.Size = New System.Drawing.Size(23, 28)
        Me.tsbAddOtros.Text = "Adición Otros Items Ctrl + Alt + O"
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnguardarcerrar, Me.btncolpanel})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(1133, 31)
        Me.tsherramientas.TabIndex = 0
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnguardarcerrar
        '
        Me.btnguardarcerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnguardarcerrar.Image = CType(resources.GetObject("btnguardarcerrar.Image"), System.Drawing.Image)
        Me.btnguardarcerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnguardarcerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnguardarcerrar.Name = "btnguardarcerrar"
        Me.btnguardarcerrar.Size = New System.Drawing.Size(28, 28)
        Me.btnguardarcerrar.ToolTipText = "Guardar y Cerrar"
        '
        'btncolpanel
        '
        Me.btncolpanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btncolpanel.CheckOnClick = True
        Me.btncolpanel.Image = CType(resources.GetObject("btncolpanel.Image"), System.Drawing.Image)
        Me.btncolpanel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncolpanel.Name = "btncolpanel"
        Me.btncolpanel.Size = New System.Drawing.Size(106, 28)
        Me.btncolpanel.Text = "Mostrar Dibujo"
        '
        'nudDescuento
        '
        Me.nudDescuento.Location = New System.Drawing.Point(279, 64)
        Me.nudDescuento.Name = "nudDescuento"
        Me.nudDescuento.Size = New System.Drawing.Size(56, 20)
        Me.nudDescuento.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(275, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Descuento (%)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(558, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Color Vidrio:"
        '
        'scgenpadre
        '
        Me.scgenpadre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scgenpadre.Location = New System.Drawing.Point(0, 31)
        Me.scgenpadre.Name = "scgenpadre"
        '
        'scgenpadre.Panel1
        '
        Me.scgenpadre.Panel1.Controls.Add(Me.cmbuminstala)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label4)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label2)
        Me.scgenpadre.Panel1.Controls.Add(Me.nuddescuentoinstalacion)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label1)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudtasa)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label8)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudPrecioInstalacion)
        Me.scgenpadre.Panel1.Controls.Add(Me.gpComponentes)
        Me.scgenpadre.Panel1.Controls.Add(Me.cmbcolorvidrio)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbUbicacion)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label5)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbAlto)
        Me.scgenpadre.Panel1.Controls.Add(Me.cmbAcabado)
        Me.scgenpadre.Panel1.Controls.Add(Me.cmbEspesores)
        Me.scgenpadre.Panel1.Controls.Add(Me.txtUbicacion)
        Me.scgenpadre.Panel1.Controls.Add(Me.cmbVidrio)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudDescuento)
        Me.scgenpadre.Panel1.Controls.Add(Me.txtdescripcion)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbAncho)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbDescripcion)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbEspesor)
        Me.scgenpadre.Panel1.Controls.Add(Me.Label3)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbVidrio)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbAcabado)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudalto)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudancho)
        Me.scgenpadre.Panel1.Controls.Add(Me.lbCantidad)
        Me.scgenpadre.Panel1.Controls.Add(Me.nudcantidad)
        '
        'scgenpadre.Panel2
        '
        Me.scgenpadre.Panel2.Controls.Add(Me.tlpestructurador)
        Me.scgenpadre.Panel2Collapsed = True
        Me.scgenpadre.Size = New System.Drawing.Size(1133, 546)
        Me.scgenpadre.SplitterDistance = 574
        Me.scgenpadre.TabIndex = 25
        '
        'cmbuminstala
        '
        Me.cmbuminstala.DatosVisibles = Nothing
        Me.cmbuminstala.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbuminstala.DropDownHeight = 200
        Me.cmbuminstala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbuminstala.DropDownWidth = 150
        Me.cmbuminstala.IntegralHeight = False
        Me.cmbuminstala.Location = New System.Drawing.Point(1036, 63)
        Me.cmbuminstala.Name = "cmbuminstala"
        Me.cmbuminstala.Size = New System.Drawing.Size(80, 21)
        Me.cmbuminstala.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1033, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "U.M Inst:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(932, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Descuento Inst (%):"
        '
        'nuddescuentoinstalacion
        '
        Me.nuddescuentoinstalacion.Location = New System.Drawing.Point(935, 64)
        Me.nuddescuentoinstalacion.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nuddescuentoinstalacion.Name = "nuddescuentoinstalacion"
        Me.nuddescuentoinstalacion.Size = New System.Drawing.Size(79, 20)
        Me.nuddescuentoinstalacion.TabIndex = 29
        Me.nuddescuentoinstalacion.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(860, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Impuesto (%):"
        '
        'nudtasa
        '
        Me.nudtasa.Location = New System.Drawing.Point(863, 64)
        Me.nudtasa.Name = "nudtasa"
        Me.nudtasa.Size = New System.Drawing.Size(61, 20)
        Me.nudtasa.TabIndex = 27
        Me.nudtasa.ThousandsSeparator = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(742, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Precio instalación:"
        '
        'nudPrecioInstalacion
        '
        Me.nudPrecioInstalacion.Location = New System.Drawing.Point(745, 65)
        Me.nudPrecioInstalacion.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudPrecioInstalacion.Name = "nudPrecioInstalacion"
        Me.nudPrecioInstalacion.Size = New System.Drawing.Size(108, 20)
        Me.nudPrecioInstalacion.TabIndex = 25
        Me.nudPrecioInstalacion.ThousandsSeparator = True
        '
        'cmbcolorvidrio
        '
        Me.cmbcolorvidrio.DatosVisibles = Nothing
        Me.cmbcolorvidrio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbcolorvidrio.DropDownHeight = 200
        Me.cmbcolorvidrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcolorvidrio.DropDownWidth = 230
        Me.cmbcolorvidrio.IntegralHeight = False
        Me.cmbcolorvidrio.Location = New System.Drawing.Point(561, 64)
        Me.cmbcolorvidrio.Name = "cmbcolorvidrio"
        Me.cmbcolorvidrio.Size = New System.Drawing.Size(85, 21)
        Me.cmbcolorvidrio.TabIndex = 21
        '
        'cmbAcabado
        '
        Me.cmbAcabado.DatosVisibles = Nothing
        Me.cmbAcabado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbAcabado.DropDownHeight = 200
        Me.cmbAcabado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcabado.DropDownWidth = 230
        Me.cmbAcabado.IntegralHeight = False
        Me.cmbAcabado.Location = New System.Drawing.Point(366, 64)
        Me.cmbAcabado.Name = "cmbAcabado"
        Me.cmbAcabado.Size = New System.Drawing.Size(91, 21)
        Me.cmbAcabado.TabIndex = 17
        '
        'cmbEspesores
        '
        Me.cmbEspesores.DatosVisibles = Nothing
        Me.cmbEspesores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEspesores.DropDownHeight = 200
        Me.cmbEspesores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEspesores.DropDownWidth = 150
        Me.cmbEspesores.IntegralHeight = False
        Me.cmbEspesores.Location = New System.Drawing.Point(657, 64)
        Me.cmbEspesores.Name = "cmbEspesores"
        Me.cmbEspesores.Size = New System.Drawing.Size(80, 21)
        Me.cmbEspesores.TabIndex = 23
        '
        'cmbVidrio
        '
        Me.cmbVidrio.DatosVisibles = Nothing
        Me.cmbVidrio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbVidrio.DropDownHeight = 200
        Me.cmbVidrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVidrio.DropDownWidth = 260
        Me.cmbVidrio.IntegralHeight = False
        Me.cmbVidrio.Location = New System.Drawing.Point(466, 64)
        Me.cmbVidrio.Name = "cmbVidrio"
        Me.cmbVidrio.Size = New System.Drawing.Size(85, 21)
        Me.cmbVidrio.TabIndex = 19
        '
        'tlpestructurador
        '
        Me.tlpestructurador.ColumnCount = 3
        Me.tlpestructurador.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.73993!))
        Me.tlpestructurador.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.26007!))
        Me.tlpestructurador.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223.0!))
        Me.tlpestructurador.Controls.Add(Me.egmodelo, 1, 1)
        Me.tlpestructurador.Controls.Add(Me.nudhorizontal, 0, 2)
        Me.tlpestructurador.Controls.Add(Me.nudvertical, 2, 0)
        Me.tlpestructurador.Controls.Add(Me.Label6, 1, 0)
        Me.tlpestructurador.Controls.Add(Me.Label7, 0, 1)
        Me.tlpestructurador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpestructurador.Location = New System.Drawing.Point(0, 0)
        Me.tlpestructurador.Name = "tlpestructurador"
        Me.tlpestructurador.RowCount = 3
        Me.tlpestructurador.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.96581!))
        Me.tlpestructurador.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.03419!))
        Me.tlpestructurador.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 337.0!))
        Me.tlpestructurador.Size = New System.Drawing.Size(96, 100)
        Me.tlpestructurador.TabIndex = 1
        '
        'egmodelo
        '
        Me.egmodelo.AllowDrop = True
        Me.egmodelo.BackColor = System.Drawing.Color.White
        Me.egmodelo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tlpestructurador.SetColumnSpan(Me.egmodelo, 2)
        Me.egmodelo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.egmodelo.Location = New System.Drawing.Point(-30, -25)
        Me.egmodelo.Name = "egmodelo"
        Me.tlpestructurador.SetRowSpan(Me.egmodelo, 2)
        Me.egmodelo.Size = New System.Drawing.Size(124, 123)
        Me.egmodelo.TabIndex = 0
        '
        'nudhorizontal
        '
        Me.nudhorizontal.Dock = System.Windows.Forms.DockStyle.Top
        Me.nudhorizontal.Location = New System.Drawing.Point(3, -233)
        Me.nudhorizontal.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudhorizontal.Name = "nudhorizontal"
        Me.nudhorizontal.Size = New System.Drawing.Size(1, 20)
        Me.nudhorizontal.TabIndex = 1
        Me.nudhorizontal.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudvertical
        '
        Me.nudvertical.Location = New System.Drawing.Point(-123, 3)
        Me.nudvertical.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudvertical.Name = "nudvertical"
        Me.nudvertical.Size = New System.Drawing.Size(54, 20)
        Me.nudvertical.TabIndex = 2
        Me.nudvertical.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-30, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(1, 1)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Vertical"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, -28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(1, 1)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Horizontal"
        '
        'FrmAddItemPadre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 577)
        Me.Controls.Add(Me.scgenpadre)
        Me.Controls.Add(Me.tsherramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddItemPadre"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adición Item"
        CType(Me.nudcantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudalto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudancho, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpComponentes.ResumeLayout(False)
        Me.gpComponentes.PerformLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tselementos.ResumeLayout(False)
        Me.tselementos.PerformLayout()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        CType(Me.nudDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgenpadre.Panel1.ResumeLayout(False)
        Me.scgenpadre.Panel1.PerformLayout()
        Me.scgenpadre.Panel2.ResumeLayout(False)
        CType(Me.scgenpadre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgenpadre.ResumeLayout(False)
        CType(Me.nuddescuentoinstalacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudtasa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPrecioInstalacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpestructurador.ResumeLayout(False)
        Me.tlpestructurador.PerformLayout()
        CType(Me.nudhorizontal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudvertical, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpComponentes As GroupBox
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnguardarcerrar As ToolStripButton
    Friend WithEvents lbAcabado As Label
    Friend WithEvents lbCantidad As Label
    Friend WithEvents lbAlto As Label
    Friend WithEvents lbAncho As Label
    Friend WithEvents lbDescripcion As Label
    Friend WithEvents lbUbicacion As Label
    Friend WithEvents lbEspesor As Label
    Friend WithEvents lbVidrio As Label
    Friend WithEvents cmbEspesores As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents cmbVidrio As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents nudcantidad As NumericUpDown
    Friend WithEvents nudalto As NumericUpDown
    Friend WithEvents nudancho As NumericUpDown
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents txtUbicacion As TextBox
    Friend WithEvents tselementos As ToolStrip
    Friend WithEvents cmbAcabado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents btnplantilla As ToolStripButton
    Friend WithEvents dwItem As DataGridView
    Friend WithEvents nudDescuento As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbcolorvidrio As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label5 As Label
    Friend WithEvents btncolpanel As ToolStripButton
    Friend WithEvents scgenpadre As SplitContainer
    Friend WithEvents egmodelo As ControlesPersonalizados.Estructurador.EstructuradorGrafico
    Friend WithEvents tlpestructurador As TableLayoutPanel
    Friend WithEvents nudhorizontal As NumericUpDown
    Friend WithEvents nudvertical As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnTempEspesor As Button
    Friend WithEvents btnTempColorVidrio As Button
    Friend WithEvents tsbAddAccesorio As ToolStripButton
    Friend WithEvents tsbAddPerfil As ToolStripButton
    Friend WithEvents tsbAddVidrio As ToolStripButton
    Friend WithEvents tsbAddOtros As ToolStripButton
    Friend WithEvents nudPrecioInstalacion As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents nudtasa As NumericUpDown
    Friend WithEvents cmbuminstala As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nuddescuentoinstalacion As NumericUpDown
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idArticulo As DataGridViewTextBoxColumn
    Friend WithEvents idArticuloTemp As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ancho As DataGridViewTextBoxColumn
    Friend WithEvents alto As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents piezasXUnidad As DataGridViewTextBoxColumn
    Friend WithEvents mtCuadrados As DataGridViewTextBoxColumn
    Friend WithEvents prcDesperdicio As DataGridViewTextBoxColumn
    Friend WithEvents acabadoPerf As DataGridViewComboBoxColumn
    Friend WithEvents vidrio As DataGridViewComboBoxColumn
    Friend WithEvents colorVidrio As DataGridViewComboBoxColumn
    Friend WithEvents espesor As DataGridViewComboBoxColumn
    Friend WithEvents unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents descuento As DataGridViewTextBoxColumn
    Friend WithEvents valorDescuento As DataGridViewTextBoxColumn
    Friend WithEvents factor As DataGridViewTextBoxColumn
    Friend WithEvents tipoItem As DataGridViewTextBoxColumn
    Friend WithEvents precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents precioTotal As DataGridViewTextBoxColumn
    Friend WithEvents precioMtInstalacion As DataGridViewTextBoxColumn
    Friend WithEvents precioInstalacion As DataGridViewTextBoxColumn
    Friend WithEvents costoinstalacion As DataGridViewTextBoxColumn
    Friend WithEvents costoVidrio As DataGridViewTextBoxColumn
    Friend WithEvents costoPerfiles As DataGridViewTextBoxColumn
    Friend WithEvents costoAccesorio As DataGridViewTextBoxColumn
    Friend WithEvents costoOtros As DataGridViewTextBoxColumn
    Friend WithEvents costoUnitario As DataGridViewTextBoxColumn
    Friend WithEvents costoTotal As DataGridViewTextBoxColumn
    Friend WithEvents vlrDesperdicioVidrio As DataGridViewTextBoxColumn
    Friend WithEvents vlrDesperdicioPerfiles As DataGridViewTextBoxColumn
    Friend WithEvents vlrDespedicioAccesorios As DataGridViewTextBoxColumn
    Friend WithEvents vlrDespOtros As DataGridViewTextBoxColumn
    Friend WithEvents especial As DataGridViewTextBoxColumn
    Friend WithEvents actualizar_plantilla As DataGridViewCheckBoxColumn
    Friend WithEvents idTasaImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents tasaImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents acabTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents colorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents espesorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents calcular_nsr As DataGridViewCheckBoxColumn
    Friend WithEvents cumplenorma As DataGridViewCheckBoxColumn
    Friend WithEvents numero_cuerpos_norma As DataGridViewTextBoxColumn
End Class
