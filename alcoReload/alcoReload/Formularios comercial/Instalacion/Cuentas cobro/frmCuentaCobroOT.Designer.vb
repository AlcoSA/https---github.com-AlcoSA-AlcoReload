<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentaCobroContrato
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentaCobroContrato))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.cmbEncargado = New System.Windows.Forms.ComboBox()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDocumentos = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.lblCuentasRealizadas = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.tsMovimiento = New System.Windows.Forms.ToolStrip()
        Me.btnOrdenTrabajo = New System.Windows.Forms.ToolStripButton()
        Me.btnItemsOP = New System.Windows.Forms.ToolStripButton()
        Me.spMovimiento = New System.Windows.Forms.SplitContainer()
        Me.PanelOrdenTrabajo = New System.Windows.Forms.Panel()
        Me.lblErrorListaOt = New System.Windows.Forms.Label()
        Me.dwOrdenesTrabajo = New DatagridTreeView.DataTreeGridView()
        Me.btnAnclajeOrdenTrabajo = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PanelItemsOP = New System.Windows.Forms.Panel()
        Me.dwTotales = New System.Windows.Forms.DataGridView()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.btnAnclajeItemsOP = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ImageListAnclaje = New System.Windows.Forms.ImageList(Me.components)
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.ot_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.ot_idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_cantTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_cantDisponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_cantCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_undMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_idTipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_tipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ot_notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_mt2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_instalado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbEncabezado.SuspendLayout()
        Me.tsHerramientas.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        Me.tsMovimiento.SuspendLayout()
        CType(Me.spMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMovimiento.Panel1.SuspendLayout()
        Me.spMovimiento.Panel2.SuspendLayout()
        Me.spMovimiento.SuspendLayout()
        Me.PanelOrdenTrabajo.SuspendLayout()
        CType(Me.dwOrdenesTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelItemsOP.SuspendLayout()
        CType(Me.dwTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbEncabezado
        '
        Me.gbEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEncabezado.Controls.Add(Me.cmbEncargado)
        Me.gbEncabezado.Controls.Add(Me.txtObra)
        Me.gbEncabezado.Controls.Add(Me.Label6)
        Me.gbEncabezado.Controls.Add(Me.Label5)
        Me.gbEncabezado.Controls.Add(Me.txtProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label4)
        Me.gbEncabezado.Controls.Add(Me.lblConsecutivo)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.cmbDocumentos)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 28)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(1129, 128)
        Me.gbEncabezado.TabIndex = 1
        Me.gbEncabezado.TabStop = False
        Me.gbEncabezado.Text = "Encabezado"
        '
        'cmbEncargado
        '
        Me.cmbEncargado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEncargado.FormattingEnabled = True
        Me.cmbEncargado.Location = New System.Drawing.Point(375, 91)
        Me.cmbEncargado.Name = "cmbEncargado"
        Me.cmbEncargado.Size = New System.Drawing.Size(259, 21)
        Me.cmbEncargado.TabIndex = 9
        '
        'txtObra
        '
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.Enabled = False
        Me.txtObra.Location = New System.Drawing.Point(234, 43)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(400, 20)
        Me.txtObra.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(231, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Obra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(372, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Encargado"
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(22, 91)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(335, 20)
        Me.txtProveedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Proveedor"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.Location = New System.Drawing.Point(133, 46)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 17)
        Me.lblConsecutivo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 26)
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
        Me.cmbDocumentos.Location = New System.Drawing.Point(22, 42)
        Me.cmbDocumentos.Name = "cmbDocumentos"
        Me.cmbDocumentos.Size = New System.Drawing.Size(77, 21)
        Me.cmbDocumentos.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento"
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.lblCuentasRealizadas, Me.ToolStripLabel1})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(1153, 25)
        Me.tsHerramientas.TabIndex = 0
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "Guardar"
        '
        'lblCuentasRealizadas
        '
        Me.lblCuentasRealizadas.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCuentasRealizadas.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCuentasRealizadas.Name = "lblCuentasRealizadas"
        Me.lblCuentasRealizadas.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripLabel1.Text = "Cuentas realizadas"
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMovimiento.Controls.Add(Me.tsMovimiento)
        Me.gbMovimiento.Controls.Add(Me.spMovimiento)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 162)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(1129, 314)
        Me.gbMovimiento.TabIndex = 2
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'tsMovimiento
        '
        Me.tsMovimiento.Dock = System.Windows.Forms.DockStyle.Left
        Me.tsMovimiento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOrdenTrabajo, Me.btnItemsOP})
        Me.tsMovimiento.Location = New System.Drawing.Point(3, 16)
        Me.tsMovimiento.Name = "tsMovimiento"
        Me.tsMovimiento.Size = New System.Drawing.Size(26, 295)
        Me.tsMovimiento.TabIndex = 0
        Me.tsMovimiento.Text = "ToolStrip1"
        '
        'btnOrdenTrabajo
        '
        Me.btnOrdenTrabajo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnOrdenTrabajo.Image = CType(resources.GetObject("btnOrdenTrabajo.Image"), System.Drawing.Image)
        Me.btnOrdenTrabajo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOrdenTrabajo.Name = "btnOrdenTrabajo"
        Me.btnOrdenTrabajo.Size = New System.Drawing.Size(21, 111)
        Me.btnOrdenTrabajo.Text = "Ordenes de trabajo"
        Me.btnOrdenTrabajo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        Me.btnOrdenTrabajo.Visible = False
        '
        'btnItemsOP
        '
        Me.btnItemsOP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnItemsOP.Image = CType(resources.GetObject("btnItemsOP.Image"), System.Drawing.Image)
        Me.btnItemsOP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnItemsOP.Name = "btnItemsOP"
        Me.btnItemsOP.Size = New System.Drawing.Size(21, 138)
        Me.btnItemsOP.Text = "Items orden producción"
        Me.btnItemsOP.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90
        Me.btnItemsOP.Visible = False
        '
        'spMovimiento
        '
        Me.spMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spMovimiento.Location = New System.Drawing.Point(32, 16)
        Me.spMovimiento.Name = "spMovimiento"
        '
        'spMovimiento.Panel1
        '
        Me.spMovimiento.Panel1.Controls.Add(Me.PanelOrdenTrabajo)
        '
        'spMovimiento.Panel2
        '
        Me.spMovimiento.Panel2.Controls.Add(Me.PanelItemsOP)
        Me.spMovimiento.Size = New System.Drawing.Size(1091, 295)
        Me.spMovimiento.SplitterDistance = 735
        Me.spMovimiento.TabIndex = 0
        '
        'PanelOrdenTrabajo
        '
        Me.PanelOrdenTrabajo.Controls.Add(Me.lblErrorListaOt)
        Me.PanelOrdenTrabajo.Controls.Add(Me.dwOrdenesTrabajo)
        Me.PanelOrdenTrabajo.Controls.Add(Me.btnAnclajeOrdenTrabajo)
        Me.PanelOrdenTrabajo.Controls.Add(Me.Label8)
        Me.PanelOrdenTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelOrdenTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.PanelOrdenTrabajo.Name = "PanelOrdenTrabajo"
        Me.PanelOrdenTrabajo.Size = New System.Drawing.Size(731, 291)
        Me.PanelOrdenTrabajo.TabIndex = 0
        Me.PanelOrdenTrabajo.Tag = "A"
        '
        'lblErrorListaOt
        '
        Me.lblErrorListaOt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorListaOt.AutoSize = True
        Me.lblErrorListaOt.Location = New System.Drawing.Point(678, 6)
        Me.lblErrorListaOt.Name = "lblErrorListaOt"
        Me.lblErrorListaOt.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorListaOt.TabIndex = 2
        '
        'dwOrdenesTrabajo
        '
        Me.dwOrdenesTrabajo.AllowUserToAddRows = False
        Me.dwOrdenesTrabajo.AllowUserToDeleteRows = False
        Me.dwOrdenesTrabajo.AllowUserToResizeColumns = False
        Me.dwOrdenesTrabajo.AllowUserToResizeRows = False
        Me.dwOrdenesTrabajo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwOrdenesTrabajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwOrdenesTrabajo.BackgroundColor = System.Drawing.Color.White
        Me.dwOrdenesTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwOrdenesTrabajo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ot_id, Me.ot_idConcepto, Me.ot_concepto, Me.ot_descripcion, Me.ot_cantTotal, Me.ot_cantDisponible, Me.ot_cantCuenta, Me.ot_undMedida, Me.ot_precioUnitario, Me.ot_subtotal, Me.ot_porcRetenido, Me.ot_idTipoObra, Me.ot_tipoObra, Me.ot_facturable, Me.ot_notas})
        Me.dwOrdenesTrabajo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwOrdenesTrabajo.ImageList = Nothing
        Me.dwOrdenesTrabajo.Location = New System.Drawing.Point(3, 28)
        Me.dwOrdenesTrabajo.MultiSelect = False
        Me.dwOrdenesTrabajo.Name = "dwOrdenesTrabajo"
        Me.dwOrdenesTrabajo.RowHeadersVisible = False
        Me.dwOrdenesTrabajo.RowHeadersWidth = 20
        Me.dwOrdenesTrabajo.Size = New System.Drawing.Size(725, 263)
        Me.dwOrdenesTrabajo.TabIndex = 1
        '
        'btnAnclajeOrdenTrabajo
        '
        Me.btnAnclajeOrdenTrabajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnclajeOrdenTrabajo.BackgroundImage = CType(resources.GetObject("btnAnclajeOrdenTrabajo.BackgroundImage"), System.Drawing.Image)
        Me.btnAnclajeOrdenTrabajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnclajeOrdenTrabajo.Location = New System.Drawing.Point(710, 3)
        Me.btnAnclajeOrdenTrabajo.Name = "btnAnclajeOrdenTrabajo"
        Me.btnAnclajeOrdenTrabajo.Size = New System.Drawing.Size(18, 18)
        Me.btnAnclajeOrdenTrabajo.TabIndex = 3
        Me.btnAnclajeOrdenTrabajo.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Ordenes de trabajo"
        '
        'PanelItemsOP
        '
        Me.PanelItemsOP.Controls.Add(Me.dwTotales)
        Me.PanelItemsOP.Controls.Add(Me.dwItems)
        Me.PanelItemsOP.Controls.Add(Me.btnAnclajeItemsOP)
        Me.PanelItemsOP.Controls.Add(Me.Label7)
        Me.PanelItemsOP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelItemsOP.Location = New System.Drawing.Point(0, 0)
        Me.PanelItemsOP.Name = "PanelItemsOP"
        Me.PanelItemsOP.Size = New System.Drawing.Size(348, 291)
        Me.PanelItemsOP.TabIndex = 1
        Me.PanelItemsOP.Tag = "A"
        '
        'dwTotales
        '
        Me.dwTotales.AllowUserToAddRows = False
        Me.dwTotales.AllowUserToDeleteRows = False
        Me.dwTotales.AllowUserToResizeColumns = False
        Me.dwTotales.AllowUserToResizeRows = False
        Me.dwTotales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwTotales.BackgroundColor = System.Drawing.Color.White
        Me.dwTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwTotales.Location = New System.Drawing.Point(3, 207)
        Me.dwTotales.Name = "dwTotales"
        Me.dwTotales.ReadOnly = True
        Me.dwTotales.RowHeadersVisible = False
        Me.dwTotales.Size = New System.Drawing.Size(342, 81)
        Me.dwTotales.TabIndex = 2
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
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_idOP, Me.item_fechaInicio, Me.item_fechaFin, Me.item_mt2, Me.item_instalado, Me.item_disponible, Me.item_tipo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 31)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(342, 170)
        Me.dwItems.TabIndex = 1
        '
        'btnAnclajeItemsOP
        '
        Me.btnAnclajeItemsOP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnclajeItemsOP.BackgroundImage = CType(resources.GetObject("btnAnclajeItemsOP.BackgroundImage"), System.Drawing.Image)
        Me.btnAnclajeItemsOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnclajeItemsOP.Location = New System.Drawing.Point(327, 3)
        Me.btnAnclajeItemsOP.Name = "btnAnclajeItemsOP"
        Me.btnAnclajeItemsOP.Size = New System.Drawing.Size(18, 18)
        Me.btnAnclajeItemsOP.TabIndex = 5
        Me.btnAnclajeItemsOP.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Items orden producción"
        '
        'ImageListAnclaje
        '
        Me.ImageListAnclaje.ImageStream = CType(resources.GetObject("ImageListAnclaje.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListAnclaje.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListAnclaje.Images.SetKeyName(0, "Anclar 17x17.png")
        Me.ImageListAnclaje.Images.SetKeyName(1, "Desanclar 17x17.png")
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 479)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(12, 495)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(1129, 63)
        Me.txtObservaciones.TabIndex = 4
        '
        'ot_id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.ot_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.ot_id.HeaderText = "Id"
        Me.ot_id.ImagenporDefecto = Nothing
        Me.ot_id.Name = "ot_id"
        Me.ot_id.ReadOnly = True
        Me.ot_id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ot_id.Width = 41
        '
        'ot_idConcepto
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.ot_idConcepto.DefaultCellStyle = DataGridViewCellStyle2
        Me.ot_idConcepto.HeaderText = "Id concepto"
        Me.ot_idConcepto.Name = "ot_idConcepto"
        Me.ot_idConcepto.ReadOnly = True
        Me.ot_idConcepto.Visible = False
        Me.ot_idConcepto.Width = 89
        '
        'ot_concepto
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.ot_concepto.DefaultCellStyle = DataGridViewCellStyle3
        Me.ot_concepto.HeaderText = "Concepto"
        Me.ot_concepto.Name = "ot_concepto"
        Me.ot_concepto.ReadOnly = True
        Me.ot_concepto.Width = 78
        '
        'ot_descripcion
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.ot_descripcion.DefaultCellStyle = DataGridViewCellStyle4
        Me.ot_descripcion.HeaderText = "Descripción"
        Me.ot_descripcion.Name = "ot_descripcion"
        Me.ot_descripcion.ReadOnly = True
        Me.ot_descripcion.Width = 88
        '
        'ot_cantTotal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ot_cantTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.ot_cantTotal.HeaderText = "Cantidad total"
        Me.ot_cantTotal.Name = "ot_cantTotal"
        Me.ot_cantTotal.ReadOnly = True
        Me.ot_cantTotal.Width = 97
        '
        'ot_cantDisponible
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ot_cantDisponible.DefaultCellStyle = DataGridViewCellStyle6
        Me.ot_cantDisponible.HeaderText = "Cantidad disponible"
        Me.ot_cantDisponible.Name = "ot_cantDisponible"
        Me.ot_cantDisponible.ReadOnly = True
        Me.ot_cantDisponible.Width = 124
        '
        'ot_cantCuenta
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.Format = "N0"
        Me.ot_cantCuenta.DefaultCellStyle = DataGridViewCellStyle7
        Me.ot_cantCuenta.HeaderText = "Cantidad cuenta"
        Me.ot_cantCuenta.Name = "ot_cantCuenta"
        Me.ot_cantCuenta.ReadOnly = True
        Me.ot_cantCuenta.Width = 110
        '
        'ot_undMedida
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.ot_undMedida.DefaultCellStyle = DataGridViewCellStyle8
        Me.ot_undMedida.HeaderText = "Unidad medida"
        Me.ot_undMedida.Name = "ot_undMedida"
        Me.ot_undMedida.ReadOnly = True
        Me.ot_undMedida.Width = 103
        '
        'ot_precioUnitario
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Format = "C0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.ot_precioUnitario.DefaultCellStyle = DataGridViewCellStyle9
        Me.ot_precioUnitario.HeaderText = "Precio unitario"
        Me.ot_precioUnitario.Name = "ot_precioUnitario"
        Me.ot_precioUnitario.ReadOnly = True
        Me.ot_precioUnitario.Width = 99
        '
        'ot_subtotal
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Format = "C0"
        Me.ot_subtotal.DefaultCellStyle = DataGridViewCellStyle10
        Me.ot_subtotal.HeaderText = "Subtotal"
        Me.ot_subtotal.Name = "ot_subtotal"
        Me.ot_subtotal.ReadOnly = True
        Me.ot_subtotal.Width = 71
        '
        'ot_porcRetenido
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Format = "N2"
        Me.ot_porcRetenido.DefaultCellStyle = DataGridViewCellStyle11
        Me.ot_porcRetenido.HeaderText = "Retenido (%)"
        Me.ot_porcRetenido.Name = "ot_porcRetenido"
        Me.ot_porcRetenido.ReadOnly = True
        Me.ot_porcRetenido.Width = 92
        '
        'ot_idTipoObra
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        Me.ot_idTipoObra.DefaultCellStyle = DataGridViewCellStyle12
        Me.ot_idTipoObra.HeaderText = "Id tipo obra"
        Me.ot_idTipoObra.Name = "ot_idTipoObra"
        Me.ot_idTipoObra.ReadOnly = True
        Me.ot_idTipoObra.Visible = False
        Me.ot_idTipoObra.Width = 85
        '
        'ot_tipoObra
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        Me.ot_tipoObra.DefaultCellStyle = DataGridViewCellStyle13
        Me.ot_tipoObra.HeaderText = "Tipo obra"
        Me.ot_tipoObra.Name = "ot_tipoObra"
        Me.ot_tipoObra.ReadOnly = True
        Me.ot_tipoObra.Width = 77
        '
        'ot_facturable
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle14.NullValue = False
        Me.ot_facturable.DefaultCellStyle = DataGridViewCellStyle14
        Me.ot_facturable.HeaderText = "Facturable"
        Me.ot_facturable.Name = "ot_facturable"
        Me.ot_facturable.ReadOnly = True
        Me.ot_facturable.Width = 63
        '
        'ot_notas
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.White
        Me.ot_notas.DefaultCellStyle = DataGridViewCellStyle15
        Me.ot_notas.HeaderText = "Notas"
        Me.ot_notas.Name = "ot_notas"
        Me.ot_notas.ReadOnly = True
        Me.ot_notas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ot_notas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_notas.Width = 41
        '
        'item_idOP
        '
        Me.item_idOP.HeaderText = "OP"
        Me.item_idOP.Name = "item_idOP"
        Me.item_idOP.ReadOnly = True
        Me.item_idOP.Width = 47
        '
        'item_fechaInicio
        '
        DataGridViewCellStyle16.Format = "dd/mm/yyyy"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.item_fechaInicio.DefaultCellStyle = DataGridViewCellStyle16
        Me.item_fechaInicio.HeaderText = "Fecha incio"
        Me.item_fechaInicio.Name = "item_fechaInicio"
        Me.item_fechaInicio.ReadOnly = True
        Me.item_fechaInicio.Width = 87
        '
        'item_fechaFin
        '
        DataGridViewCellStyle17.Format = "dd/mm/yyyy"
        Me.item_fechaFin.DefaultCellStyle = DataGridViewCellStyle17
        Me.item_fechaFin.HeaderText = "Fecha fin"
        Me.item_fechaFin.Name = "item_fechaFin"
        Me.item_fechaFin.ReadOnly = True
        Me.item_fechaFin.Width = 76
        '
        'item_mt2
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.item_mt2.DefaultCellStyle = DataGridViewCellStyle18
        Me.item_mt2.HeaderText = "MT²"
        Me.item_mt2.Name = "item_mt2"
        Me.item_mt2.ReadOnly = True
        Me.item_mt2.Width = 51
        '
        'item_instalado
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.Format = "N2"
        Me.item_instalado.DefaultCellStyle = DataGridViewCellStyle19
        Me.item_instalado.HeaderText = "Instalado"
        Me.item_instalado.Name = "item_instalado"
        Me.item_instalado.ReadOnly = True
        Me.item_instalado.Width = 75
        '
        'item_disponible
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.Format = "N2"
        Me.item_disponible.DefaultCellStyle = DataGridViewCellStyle20
        Me.item_disponible.HeaderText = "Disponible"
        Me.item_disponible.Name = "item_disponible"
        Me.item_disponible.ReadOnly = True
        Me.item_disponible.Width = 81
        '
        'item_tipo
        '
        Me.item_tipo.HeaderText = "Tipo"
        Me.item_tipo.Name = "item_tipo"
        Me.item_tipo.ReadOnly = True
        Me.item_tipo.Width = 53
        '
        'frmCuentaCobroContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 570)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.tsHerramientas)
        Me.Controls.Add(Me.gbEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCuentaCobroContrato"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta de cobro"
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        Me.gbMovimiento.PerformLayout()
        Me.tsMovimiento.ResumeLayout(False)
        Me.tsMovimiento.PerformLayout()
        Me.spMovimiento.Panel1.ResumeLayout(False)
        Me.spMovimiento.Panel2.ResumeLayout(False)
        CType(Me.spMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spMovimiento.ResumeLayout(False)
        Me.PanelOrdenTrabajo.ResumeLayout(False)
        Me.PanelOrdenTrabajo.PerformLayout()
        CType(Me.dwOrdenesTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelItemsOP.ResumeLayout(False)
        Me.PanelItemsOP.PerformLayout()
        CType(Me.dwTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbEncabezado As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDocumentos As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents lblCuentasRealizadas As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents gbMovimiento As GroupBox
    Friend WithEvents spMovimiento As SplitContainer
    Friend WithEvents PanelItemsOP As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAnclajeItemsOP As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents btnAnclajeOrdenTrabajo As Button
    Friend WithEvents PanelOrdenTrabajo As Panel
    Friend WithEvents dwTotales As DataGridView
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents tsMovimiento As ToolStrip
    Friend WithEvents btnOrdenTrabajo As ToolStripButton
    Friend WithEvents btnItemsOP As ToolStripButton
    Friend WithEvents dwOrdenesTrabajo As DatagridTreeView.DataTreeGridView
    Friend WithEvents ImageListAnclaje As ImageList
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents cmbEncargado As ComboBox
    Friend WithEvents lblErrorListaOt As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents ot_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents ot_idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents ot_concepto As DataGridViewTextBoxColumn
    Friend WithEvents ot_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ot_cantTotal As DataGridViewTextBoxColumn
    Friend WithEvents ot_cantDisponible As DataGridViewTextBoxColumn
    Friend WithEvents ot_cantCuenta As DataGridViewTextBoxColumn
    Friend WithEvents ot_undMedida As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ot_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents ot_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents ot_idTipoObra As DataGridViewTextBoxColumn
    Friend WithEvents ot_tipoObra As DataGridViewTextBoxColumn
    Friend WithEvents ot_facturable As DataGridViewCheckBoxColumn
    Friend WithEvents ot_notas As DataGridViewTextBoxColumn
    Friend WithEvents item_idOP As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaFin As DataGridViewTextBoxColumn
    Friend WithEvents item_mt2 As DataGridViewTextBoxColumn
    Friend WithEvents item_instalado As DataGridViewTextBoxColumn
    Friend WithEvents item_disponible As DataGridViewTextBoxColumn
    Friend WithEvents item_tipo As DataGridViewTextBoxColumn
End Class
