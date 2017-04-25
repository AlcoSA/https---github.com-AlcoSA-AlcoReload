<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenTrabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenTrabajo))
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
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.lblObra = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDocumentos = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.tsMovimiento = New System.Windows.Forms.ToolStrip()
        Me.btnOrdenTrabajo = New System.Windows.Forms.ToolStripButton()
        Me.btnItemsOP = New System.Windows.Forms.ToolStripButton()
        Me.spMovimiento = New System.Windows.Forms.SplitContainer()
        Me.PanelOrdenTrabajo = New System.Windows.Forms.Panel()
        Me.lblErrorOT = New System.Windows.Forms.Label()
        Me.btnAnclajeOrdenTrabajo = New System.Windows.Forms.Button()
        Me.btnAgregarFila = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dwOrdenPedido = New System.Windows.Forms.DataGridView()
        Me.PanelItemsOP = New System.Windows.Forms.Panel()
        Me.btnAnclajeItemsOP = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dwTotales = New System.Windows.Forms.DataGridView()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ImageListAnclaje = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.ot_concepto = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ot_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_idTipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_tipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_cantidadOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_unidadMedida = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ot_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_porcRecaudo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ot_notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_actualizarPrecio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ot_precioOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_porcRetOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_motivoCambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_mt2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_instalado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbEncabezado.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        Me.tsMovimiento.SuspendLayout()
        CType(Me.spMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spMovimiento.Panel1.SuspendLayout()
        Me.spMovimiento.Panel2.SuspendLayout()
        Me.spMovimiento.SuspendLayout()
        Me.PanelOrdenTrabajo.SuspendLayout()
        CType(Me.dwOrdenPedido, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.gbEncabezado.Controls.Add(Me.lblObra)
        Me.gbEncabezado.Controls.Add(Me.Label6)
        Me.gbEncabezado.Controls.Add(Me.cmbProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label3)
        Me.gbEncabezado.Controls.Add(Me.lblConsecutivo)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.cmbDocumentos)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 12)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(1108, 70)
        Me.gbEncabezado.TabIndex = 0
        Me.gbEncabezado.TabStop = False
        Me.gbEncabezado.Text = "Encabezado"
        '
        'lblObra
        '
        Me.lblObra.AutoSize = True
        Me.lblObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObra.Location = New System.Drawing.Point(449, 34)
        Me.lblObra.Name = "lblObra"
        Me.lblObra.Size = New System.Drawing.Size(21, 15)
        Me.lblObra.TabIndex = 9
        Me.lblObra.Text = "- -"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(449, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Obra"
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
        Me.lblConsecutivo.Size = New System.Drawing.Size(21, 15)
        Me.lblConsecutivo.TabIndex = 3
        Me.lblConsecutivo.Text = "- -"
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
        Me.gbMovimiento.Controls.Add(Me.tsMovimiento)
        Me.gbMovimiento.Controls.Add(Me.spMovimiento)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 88)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(1108, 302)
        Me.gbMovimiento.TabIndex = 1
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'tsMovimiento
        '
        Me.tsMovimiento.Dock = System.Windows.Forms.DockStyle.Left
        Me.tsMovimiento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOrdenTrabajo, Me.btnItemsOP})
        Me.tsMovimiento.Location = New System.Drawing.Point(3, 16)
        Me.tsMovimiento.Name = "tsMovimiento"
        Me.tsMovimiento.Size = New System.Drawing.Size(26, 283)
        Me.tsMovimiento.TabIndex = 2
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
        Me.spMovimiento.Size = New System.Drawing.Size(1070, 280)
        Me.spMovimiento.SplitterDistance = 615
        Me.spMovimiento.TabIndex = 1
        '
        'PanelOrdenTrabajo
        '
        Me.PanelOrdenTrabajo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelOrdenTrabajo.Controls.Add(Me.lblErrorOT)
        Me.PanelOrdenTrabajo.Controls.Add(Me.btnAnclajeOrdenTrabajo)
        Me.PanelOrdenTrabajo.Controls.Add(Me.btnAgregarFila)
        Me.PanelOrdenTrabajo.Controls.Add(Me.Label7)
        Me.PanelOrdenTrabajo.Controls.Add(Me.dwOrdenPedido)
        Me.PanelOrdenTrabajo.Location = New System.Drawing.Point(3, 3)
        Me.PanelOrdenTrabajo.Name = "PanelOrdenTrabajo"
        Me.PanelOrdenTrabajo.Size = New System.Drawing.Size(605, 270)
        Me.PanelOrdenTrabajo.TabIndex = 11
        Me.PanelOrdenTrabajo.Tag = "A"
        '
        'lblErrorOT
        '
        Me.lblErrorOT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblErrorOT.AutoSize = True
        Me.lblErrorOT.Location = New System.Drawing.Point(581, 45)
        Me.lblErrorOT.Name = "lblErrorOT"
        Me.lblErrorOT.Size = New System.Drawing.Size(0, 13)
        Me.lblErrorOT.TabIndex = 11
        '
        'btnAnclajeOrdenTrabajo
        '
        Me.btnAnclajeOrdenTrabajo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnclajeOrdenTrabajo.BackgroundImage = CType(resources.GetObject("btnAnclajeOrdenTrabajo.BackgroundImage"), System.Drawing.Image)
        Me.btnAnclajeOrdenTrabajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnclajeOrdenTrabajo.Location = New System.Drawing.Point(584, 3)
        Me.btnAnclajeOrdenTrabajo.Name = "btnAnclajeOrdenTrabajo"
        Me.btnAnclajeOrdenTrabajo.Size = New System.Drawing.Size(18, 18)
        Me.btnAnclajeOrdenTrabajo.TabIndex = 4
        Me.btnAnclajeOrdenTrabajo.UseVisualStyleBackColor = True
        '
        'btnAgregarFila
        '
        Me.btnAgregarFila.Image = CType(resources.GetObject("btnAgregarFila.Image"), System.Drawing.Image)
        Me.btnAgregarFila.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarFila.Location = New System.Drawing.Point(6, 35)
        Me.btnAgregarFila.Name = "btnAgregarFila"
        Me.btnAgregarFila.Size = New System.Drawing.Size(88, 23)
        Me.btnAgregarFila.TabIndex = 6
        Me.btnAgregarFila.Text = "Agregar fila"
        Me.btnAgregarFila.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregarFila.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Ordenes de trabajo"
        '
        'dwOrdenPedido
        '
        Me.dwOrdenPedido.AllowUserToAddRows = False
        Me.dwOrdenPedido.AllowUserToDeleteRows = False
        Me.dwOrdenPedido.AllowUserToResizeColumns = False
        Me.dwOrdenPedido.AllowUserToResizeRows = False
        Me.dwOrdenPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwOrdenPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwOrdenPedido.BackgroundColor = System.Drawing.Color.White
        Me.dwOrdenPedido.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwOrdenPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwOrdenPedido.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ot_concepto, Me.ot_descripcion, Me.ot_idTipoObra, Me.ot_tipoObra, Me.ot_cantidadOrden, Me.ot_unidadMedida, Me.ot_precioUnitario, Me.ot_precioCliente, Me.ot_subtotal, Me.ot_porcRecaudo, Me.ot_facturable, Me.ot_notas, Me.ot_actualizarPrecio, Me.ot_precioOriginal, Me.ot_porcRetOriginal, Me.ot_motivoCambio})
        Me.dwOrdenPedido.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwOrdenPedido.Location = New System.Drawing.Point(6, 64)
        Me.dwOrdenPedido.MultiSelect = False
        Me.dwOrdenPedido.Name = "dwOrdenPedido"
        Me.dwOrdenPedido.RowHeadersVisible = False
        Me.dwOrdenPedido.Size = New System.Drawing.Size(596, 203)
        Me.dwOrdenPedido.TabIndex = 1
        '
        'PanelItemsOP
        '
        Me.PanelItemsOP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelItemsOP.Controls.Add(Me.btnAnclajeItemsOP)
        Me.PanelItemsOP.Controls.Add(Me.Label8)
        Me.PanelItemsOP.Controls.Add(Me.dwTotales)
        Me.PanelItemsOP.Controls.Add(Me.dwItems)
        Me.PanelItemsOP.Location = New System.Drawing.Point(3, 3)
        Me.PanelItemsOP.Name = "PanelItemsOP"
        Me.PanelItemsOP.Size = New System.Drawing.Size(441, 270)
        Me.PanelItemsOP.TabIndex = 12
        Me.PanelItemsOP.Tag = "A"
        '
        'btnAnclajeItemsOP
        '
        Me.btnAnclajeItemsOP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnclajeItemsOP.BackgroundImage = CType(resources.GetObject("btnAnclajeItemsOP.BackgroundImage"), System.Drawing.Image)
        Me.btnAnclajeItemsOP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnclajeItemsOP.Location = New System.Drawing.Point(420, 3)
        Me.btnAnclajeItemsOP.Name = "btnAnclajeItemsOP"
        Me.btnAnclajeItemsOP.Size = New System.Drawing.Size(18, 18)
        Me.btnAnclajeItemsOP.TabIndex = 5
        Me.btnAnclajeItemsOP.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Items orden producción"
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
        Me.dwTotales.Location = New System.Drawing.Point(6, 186)
        Me.dwTotales.Name = "dwTotales"
        Me.dwTotales.ReadOnly = True
        Me.dwTotales.RowHeadersVisible = False
        Me.dwTotales.Size = New System.Drawing.Size(432, 81)
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_idOP, Me.item_fechaInicio, Me.item_fechaFin, Me.item_mt2, Me.item_instalado, Me.item_disponible, Me.item_idTipo, Me.item_tipo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 27)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(432, 153)
        Me.dwItems.TabIndex = 1
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'ImageListAnclaje
        '
        Me.ImageListAnclaje.ImageStream = CType(resources.GetObject("ImageListAnclaje.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListAnclaje.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListAnclaje.Images.SetKeyName(0, "Anclar 17x17.png")
        Me.ImageListAnclaje.Images.SetKeyName(1, "Desanclar 17x17.png")
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 393)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Notas"
        '
        'txtNotas
        '
        Me.txtNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNotas.Location = New System.Drawing.Point(12, 409)
        Me.txtNotas.MaxLength = 150
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(642, 61)
        Me.txtNotas.TabIndex = 4
        Me.txtNotas.Text = resources.GetString("txtNotas.Text")
        '
        'ot_concepto
        '
        Me.ot_concepto.HeaderText = "Concepto"
        Me.ot_concepto.Name = "ot_concepto"
        Me.ot_concepto.Width = 59
        '
        'ot_descripcion
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.ot_descripcion.DefaultCellStyle = DataGridViewCellStyle1
        Me.ot_descripcion.HeaderText = "Descripción"
        Me.ot_descripcion.Name = "ot_descripcion"
        Me.ot_descripcion.Width = 88
        '
        'ot_idTipoObra
        '
        Me.ot_idTipoObra.HeaderText = "Id tipo obra"
        Me.ot_idTipoObra.Name = "ot_idTipoObra"
        Me.ot_idTipoObra.ReadOnly = True
        Me.ot_idTipoObra.Visible = False
        Me.ot_idTipoObra.Width = 85
        '
        'ot_tipoObra
        '
        Me.ot_tipoObra.HeaderText = "Tipo obra"
        Me.ot_tipoObra.Name = "ot_tipoObra"
        Me.ot_tipoObra.ReadOnly = True
        Me.ot_tipoObra.Visible = False
        Me.ot_tipoObra.Width = 77
        '
        'ot_cantidadOrden
        '
        DataGridViewCellStyle2.NullValue = "0"
        Me.ot_cantidadOrden.DefaultCellStyle = DataGridViewCellStyle2
        Me.ot_cantidadOrden.HeaderText = "Cantidad orden"
        Me.ot_cantidadOrden.Name = "ot_cantidadOrden"
        Me.ot_cantidadOrden.Width = 96
        '
        'ot_unidadMedida
        '
        Me.ot_unidadMedida.HeaderText = "Unidad de medida"
        Me.ot_unidadMedida.Name = "ot_unidadMedida"
        Me.ot_unidadMedida.ReadOnly = True
        Me.ot_unidadMedida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ot_unidadMedida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ot_unidadMedida.Width = 108
        '
        'ot_precioUnitario
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.ot_precioUnitario.DefaultCellStyle = DataGridViewCellStyle3
        Me.ot_precioUnitario.HeaderText = "Precio unitario"
        Me.ot_precioUnitario.Name = "ot_precioUnitario"
        Me.ot_precioUnitario.ReadOnly = True
        Me.ot_precioUnitario.Width = 91
        '
        'ot_precioCliente
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.ot_precioCliente.DefaultCellStyle = DataGridViewCellStyle4
        Me.ot_precioCliente.HeaderText = "Precio cliente"
        Me.ot_precioCliente.Name = "ot_precioCliente"
        Me.ot_precioCliente.Width = 88
        '
        'ot_subtotal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.ot_subtotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.ot_subtotal.HeaderText = "Subtotal"
        Me.ot_subtotal.Name = "ot_subtotal"
        Me.ot_subtotal.ReadOnly = True
        Me.ot_subtotal.Width = 71
        '
        'ot_porcRecaudo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.ot_porcRecaudo.DefaultCellStyle = DataGridViewCellStyle6
        Me.ot_porcRecaudo.HeaderText = "Recaudo (%)"
        Me.ot_porcRecaudo.Name = "ot_porcRecaudo"
        Me.ot_porcRecaudo.ReadOnly = True
        Me.ot_porcRecaudo.Width = 86
        '
        'ot_facturable
        '
        Me.ot_facturable.HeaderText = "Facturable"
        Me.ot_facturable.Name = "ot_facturable"
        Me.ot_facturable.Width = 63
        '
        'ot_notas
        '
        Me.ot_notas.HeaderText = "Notas"
        Me.ot_notas.Name = "ot_notas"
        Me.ot_notas.Width = 60
        '
        'ot_actualizarPrecio
        '
        Me.ot_actualizarPrecio.HeaderText = "Actualizar precio"
        Me.ot_actualizarPrecio.Name = "ot_actualizarPrecio"
        Me.ot_actualizarPrecio.ReadOnly = True
        Me.ot_actualizarPrecio.Visible = False
        Me.ot_actualizarPrecio.Width = 82
        '
        'ot_precioOriginal
        '
        DataGridViewCellStyle7.Format = "N0"
        Me.ot_precioOriginal.DefaultCellStyle = DataGridViewCellStyle7
        Me.ot_precioOriginal.HeaderText = "Precio original"
        Me.ot_precioOriginal.Name = "ot_precioOriginal"
        Me.ot_precioOriginal.ReadOnly = True
        Me.ot_precioOriginal.Visible = False
        Me.ot_precioOriginal.Width = 90
        '
        'ot_porcRetOriginal
        '
        DataGridViewCellStyle8.Format = "N0"
        Me.ot_porcRetOriginal.DefaultCellStyle = DataGridViewCellStyle8
        Me.ot_porcRetOriginal.HeaderText = "Por - retenido original"
        Me.ot_porcRetOriginal.Name = "ot_porcRetOriginal"
        Me.ot_porcRetOriginal.ReadOnly = True
        Me.ot_porcRetOriginal.Visible = False
        Me.ot_porcRetOriginal.Width = 120
        '
        'ot_motivoCambio
        '
        Me.ot_motivoCambio.HeaderText = "Motivo cambio"
        Me.ot_motivoCambio.Name = "ot_motivoCambio"
        Me.ot_motivoCambio.ReadOnly = True
        Me.ot_motivoCambio.Visible = False
        Me.ot_motivoCambio.Width = 93
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
        DataGridViewCellStyle9.Format = "dd/mm/yyyy"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.item_fechaInicio.DefaultCellStyle = DataGridViewCellStyle9
        Me.item_fechaInicio.HeaderText = "Fecha incio"
        Me.item_fechaInicio.Name = "item_fechaInicio"
        Me.item_fechaInicio.ReadOnly = True
        Me.item_fechaInicio.Width = 87
        '
        'item_fechaFin
        '
        DataGridViewCellStyle10.Format = "dd/mm/yyyy"
        Me.item_fechaFin.DefaultCellStyle = DataGridViewCellStyle10
        Me.item_fechaFin.HeaderText = "Fecha fin"
        Me.item_fechaFin.Name = "item_fechaFin"
        Me.item_fechaFin.ReadOnly = True
        Me.item_fechaFin.Width = 76
        '
        'item_mt2
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.item_mt2.DefaultCellStyle = DataGridViewCellStyle11
        Me.item_mt2.HeaderText = "MT²"
        Me.item_mt2.Name = "item_mt2"
        Me.item_mt2.ReadOnly = True
        Me.item_mt2.Width = 51
        '
        'item_instalado
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        Me.item_instalado.DefaultCellStyle = DataGridViewCellStyle12
        Me.item_instalado.HeaderText = "Instalado"
        Me.item_instalado.Name = "item_instalado"
        Me.item_instalado.ReadOnly = True
        Me.item_instalado.Width = 75
        '
        'item_disponible
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        Me.item_disponible.DefaultCellStyle = DataGridViewCellStyle13
        Me.item_disponible.HeaderText = "Disponible"
        Me.item_disponible.Name = "item_disponible"
        Me.item_disponible.ReadOnly = True
        Me.item_disponible.Width = 81
        '
        'item_idTipo
        '
        Me.item_idTipo.HeaderText = "Id tipo"
        Me.item_idTipo.Name = "item_idTipo"
        Me.item_idTipo.ReadOnly = True
        Me.item_idTipo.Visible = False
        Me.item_idTipo.Width = 61
        '
        'item_tipo
        '
        Me.item_tipo.HeaderText = "Tipo"
        Me.item_tipo.Name = "item_tipo"
        Me.item_tipo.ReadOnly = True
        Me.item_tipo.Width = 53
        '
        'frmOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1132, 482)
        Me.Controls.Add(Me.txtNotas)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenTrabajo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Orden de trabajo"
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
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
        CType(Me.dwOrdenPedido, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents cmbDocumentos As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents lblObra As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbProveedor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label3 As Label
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents gbMovimiento As GroupBox
    Friend WithEvents spMovimiento As SplitContainer
    Friend WithEvents dwOrdenPedido As DataGridView
    Friend WithEvents dwTotales As DataGridView
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents tsMovimiento As ToolStrip
    Friend WithEvents btnAnclajeOrdenTrabajo As Button
    Friend WithEvents btnAnclajeItemsOP As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAgregarFila As Button
    Friend WithEvents btnOrdenTrabajo As ToolStripButton
    Friend WithEvents btnItemsOP As ToolStripButton
    Friend WithEvents Label8 As Label
    Friend WithEvents ImageListAnclaje As ImageList
    Friend WithEvents PanelOrdenTrabajo As Panel
    Friend WithEvents PanelItemsOP As Panel
    Friend WithEvents lblErrorOT As Label
    Friend WithEvents txtNotas As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ot_concepto As DataGridViewComboBoxColumn
    Friend WithEvents ot_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ot_idTipoObra As DataGridViewTextBoxColumn
    Friend WithEvents ot_tipoObra As DataGridViewTextBoxColumn
    Friend WithEvents ot_cantidadOrden As DataGridViewTextBoxColumn
    Friend WithEvents ot_unidadMedida As DataGridViewComboBoxColumn
    Friend WithEvents ot_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioCliente As DataGridViewTextBoxColumn
    Friend WithEvents ot_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents ot_porcRecaudo As DataGridViewTextBoxColumn
    Friend WithEvents ot_facturable As DataGridViewCheckBoxColumn
    Friend WithEvents ot_notas As DataGridViewTextBoxColumn
    Friend WithEvents ot_actualizarPrecio As DataGridViewCheckBoxColumn
    Friend WithEvents ot_precioOriginal As DataGridViewTextBoxColumn
    Friend WithEvents ot_porcRetOriginal As DataGridViewTextBoxColumn
    Friend WithEvents ot_motivoCambio As DataGridViewTextBoxColumn
    Friend WithEvents item_idOP As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaFin As DataGridViewTextBoxColumn
    Friend WithEvents item_mt2 As DataGridViewTextBoxColumn
    Friend WithEvents item_instalado As DataGridViewTextBoxColumn
    Friend WithEvents item_disponible As DataGridViewTextBoxColumn
    Friend WithEvents item_idTipo As DataGridViewTextBoxColumn
    Friend WithEvents item_tipo As DataGridViewTextBoxColumn
End Class
