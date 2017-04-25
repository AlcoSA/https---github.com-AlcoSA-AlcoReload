<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaCuentaCobroDirecta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaCuentaCobroDirecta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnAnularCuenta = New System.Windows.Forms.ToolStripButton()
        Me.lblConsecutivo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.txtFechaCreacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEncargado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.tsMovimiento = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRetenido = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.item_idMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_undMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_precioCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_idMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_estado = New System.Windows.Forms.DataGridViewImageColumn()
        Me.tsHerramientas.SuspendLayout()
        Me.gbEncabezado.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        Me.tsMovimiento.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAnularCuenta, Me.lblConsecutivo, Me.ToolStripLabel2, Me.lblDocumento, Me.ToolStripLabel1})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(694, 25)
        Me.tsHerramientas.TabIndex = 1
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnAnularCuenta
        '
        Me.btnAnularCuenta.Image = CType(resources.GetObject("btnAnularCuenta.Image"), System.Drawing.Image)
        Me.btnAnularCuenta.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularCuenta.Name = "btnAnularCuenta"
        Me.btnAnularCuenta.Size = New System.Drawing.Size(101, 22)
        Me.btnAnularCuenta.Text = "Anular cuenta"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripLabel2.Text = "Consecutivo"
        '
        'lblDocumento
        '
        Me.lblDocumento.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel1.Text = "Documento"
        '
        'gbEncabezado
        '
        Me.gbEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEncabezado.Controls.Add(Me.txtFechaCreacion)
        Me.gbEncabezado.Controls.Add(Me.Label5)
        Me.gbEncabezado.Controls.Add(Me.txtEncargado)
        Me.gbEncabezado.Controls.Add(Me.Label3)
        Me.gbEncabezado.Controls.Add(Me.txtProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label4)
        Me.gbEncabezado.Controls.Add(Me.txtVendedor)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.txtObra)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 28)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(670, 120)
        Me.gbEncabezado.TabIndex = 2
        Me.gbEncabezado.TabStop = False
        Me.gbEncabezado.Text = "Encabezado"
        '
        'txtFechaCreacion
        '
        Me.txtFechaCreacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaCreacion.Enabled = False
        Me.txtFechaCreacion.Location = New System.Drawing.Point(437, 40)
        Me.txtFechaCreacion.Name = "txtFechaCreacion"
        Me.txtFechaCreacion.Size = New System.Drawing.Size(131, 20)
        Me.txtFechaCreacion.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(434, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha creación"
        '
        'txtEncargado
        '
        Me.txtEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEncargado.Enabled = False
        Me.txtEncargado.Location = New System.Drawing.Point(331, 83)
        Me.txtEncargado.Name = "txtEncargado"
        Me.txtEncargado.Size = New System.Drawing.Size(289, 20)
        Me.txtEncargado.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Encargado"
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(18, 84)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(289, 20)
        Me.txtProveedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Proveedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(331, 40)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(80, 20)
        Me.txtVendedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendedor"
        '
        'txtObra
        '
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.Enabled = False
        Me.txtObra.Location = New System.Drawing.Point(18, 40)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(289, 20)
        Me.txtObra.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Obra"
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMovimiento.Controls.Add(Me.tsMovimiento)
        Me.gbMovimiento.Controls.Add(Me.dwItems)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 154)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(670, 254)
        Me.gbMovimiento.TabIndex = 3
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'tsMovimiento
        '
        Me.tsMovimiento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton1})
        Me.tsMovimiento.Location = New System.Drawing.Point(3, 16)
        Me.tsMovimiento.Name = "tsMovimiento"
        Me.tsMovimiento.Size = New System.Drawing.Size(664, 25)
        Me.tsMovimiento.TabIndex = 0
        Me.tsMovimiento.Text = "ToolStrip2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(61, 22)
        Me.ToolStripButton3.Text = "Activo"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 22)
        Me.ToolStripButton1.Text = "Anulado"
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_idMovimiento, Me.item_idConcepto, Me.item_concepto, Me.item_descripcion, Me.item_cantidad, Me.item_undMedida, Me.item_precioUnitario, Me.item_precioCliente, Me.item_subtotal, Me.item_porcRetenido, Me.item_facturable, Me.item_idMotivo, Me.item_motivo, Me.item_idEstado, Me.item_estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 44)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(658, 204)
        Me.dwItems.TabIndex = 1
        '
        'gbTotales
        '
        Me.gbTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTotales.Controls.Add(Me.lblTotal)
        Me.gbTotales.Controls.Add(Me.Label12)
        Me.gbTotales.Controls.Add(Me.lblRetenido)
        Me.gbTotales.Controls.Add(Me.Label10)
        Me.gbTotales.Controls.Add(Me.lblSubtotal)
        Me.gbTotales.Controls.Add(Me.Label7)
        Me.gbTotales.Location = New System.Drawing.Point(458, 414)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(224, 95)
        Me.gbTotales.TabIndex = 5
        Me.gbTotales.TabStop = False
        Me.gbTotales.Text = "Totales"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(101, 69)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(25, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(61, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Total:"
        '
        'lblRetenido
        '
        Me.lblRetenido.AutoSize = True
        Me.lblRetenido.Location = New System.Drawing.Point(101, 48)
        Me.lblRetenido.Name = "lblRetenido"
        Me.lblRetenido.Size = New System.Drawing.Size(25, 13)
        Me.lblRetenido.TabIndex = 3
        Me.lblRetenido.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Retenido:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(101, 27)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(25, 13)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(46, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Subtotal:"
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Terminado 17x17.png")
        Me.ImageList.Images.SetKeyName(1, "Sin planear 17x17.png")
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(12, 430)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(440, 79)
        Me.txtObservaciones.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 414)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Observaciones"
        '
        'item_idMovimiento
        '
        Me.item_idMovimiento.HeaderText = "Id"
        Me.item_idMovimiento.Name = "item_idMovimiento"
        Me.item_idMovimiento.ReadOnly = True
        Me.item_idMovimiento.Visible = False
        Me.item_idMovimiento.Width = 22
        '
        'item_idConcepto
        '
        Me.item_idConcepto.HeaderText = "Id concepto"
        Me.item_idConcepto.Name = "item_idConcepto"
        Me.item_idConcepto.ReadOnly = True
        Me.item_idConcepto.Visible = False
        Me.item_idConcepto.Width = 70
        '
        'item_concepto
        '
        Me.item_concepto.HeaderText = "Concepto"
        Me.item_concepto.Name = "item_concepto"
        Me.item_concepto.ReadOnly = True
        Me.item_concepto.Width = 78
        '
        'item_descripcion
        '
        Me.item_descripcion.HeaderText = "Descripción"
        Me.item_descripcion.Name = "item_descripcion"
        Me.item_descripcion.ReadOnly = True
        Me.item_descripcion.Width = 88
        '
        'item_cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.item_cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_cantidad.HeaderText = "Cantidad"
        Me.item_cantidad.Name = "item_cantidad"
        Me.item_cantidad.ReadOnly = True
        Me.item_cantidad.Width = 74
        '
        'item_undMedida
        '
        Me.item_undMedida.HeaderText = "Unidad medida"
        Me.item_undMedida.Name = "item_undMedida"
        Me.item_undMedida.ReadOnly = True
        Me.item_undMedida.Width = 95
        '
        'item_precioUnitario
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C0"
        Me.item_precioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_precioUnitario.HeaderText = "PrecioUnitario"
        Me.item_precioUnitario.Name = "item_precioUnitario"
        Me.item_precioUnitario.ReadOnly = True
        Me.item_precioUnitario.Width = 98
        '
        'item_precioCliente
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.item_precioCliente.DefaultCellStyle = DataGridViewCellStyle3
        Me.item_precioCliente.HeaderText = "Precio cliente"
        Me.item_precioCliente.Name = "item_precioCliente"
        Me.item_precioCliente.ReadOnly = True
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
        'item_facturable
        '
        Me.item_facturable.HeaderText = "Facturable"
        Me.item_facturable.Name = "item_facturable"
        Me.item_facturable.ReadOnly = True
        Me.item_facturable.Width = 63
        '
        'item_idMotivo
        '
        Me.item_idMotivo.HeaderText = "id motivo"
        Me.item_idMotivo.Name = "item_idMotivo"
        Me.item_idMotivo.ReadOnly = True
        Me.item_idMotivo.Visible = False
        Me.item_idMotivo.Width = 69
        '
        'item_motivo
        '
        Me.item_motivo.HeaderText = "Motivo"
        Me.item_motivo.Name = "item_motivo"
        Me.item_motivo.ReadOnly = True
        Me.item_motivo.Width = 64
        '
        'item_idEstado
        '
        Me.item_idEstado.HeaderText = "Id estado"
        Me.item_idEstado.Name = "item_idEstado"
        Me.item_idEstado.ReadOnly = True
        Me.item_idEstado.Visible = False
        Me.item_idEstado.Width = 70
        '
        'item_estado
        '
        Me.item_estado.HeaderText = "Estado"
        Me.item_estado.Name = "item_estado"
        Me.item_estado.ReadOnly = True
        Me.item_estado.Width = 46
        '
        'frmVistaCuentaCobroDirecta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 521)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.Controls.Add(Me.tsHerramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaCuentaCobroDirecta"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista cuenta cobro directa"
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        Me.gbMovimiento.PerformLayout()
        Me.tsMovimiento.ResumeLayout(False)
        Me.tsMovimiento.PerformLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnAnularCuenta As ToolStripButton
    Friend WithEvents lblConsecutivo As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents lblDocumento As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents gbEncabezado As GroupBox
    Friend WithEvents txtFechaCreacion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEncargado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbMovimiento As GroupBox
    Friend WithEvents tsMovimiento As ToolStrip
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents gbTotales As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblRetenido As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents ImageList As ImageList
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents item_idMovimiento As DataGridViewTextBoxColumn
    Friend WithEvents item_idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents item_concepto As DataGridViewTextBoxColumn
    Friend WithEvents item_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents item_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents item_undMedida As DataGridViewTextBoxColumn
    Friend WithEvents item_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents item_precioCliente As DataGridViewTextBoxColumn
    Friend WithEvents item_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents item_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents item_facturable As DataGridViewCheckBoxColumn
    Friend WithEvents item_idMotivo As DataGridViewTextBoxColumn
    Friend WithEvents item_motivo As DataGridViewTextBoxColumn
    Friend WithEvents item_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents item_estado As DataGridViewImageColumn
End Class
