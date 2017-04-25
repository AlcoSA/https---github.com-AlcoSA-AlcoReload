<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaOrdenTrabajo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaOrdenTrabajo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnAnularOrden = New System.Windows.Forms.ToolStripButton()
        Me.lblConsecutivo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.txtFechaCreacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.tsMovimiento = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRetenido = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.item_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_cantidadOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_cantidadOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_estado = New System.Windows.Forms.DataGridViewImageColumn()
        Me.item_notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAnularOrden, Me.lblConsecutivo, Me.ToolStripLabel2, Me.lblDocumento, Me.ToolStripLabel1})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(694, 25)
        Me.tsHerramientas.TabIndex = 0
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnAnularOrden
        '
        Me.btnAnularOrden.Image = CType(resources.GetObject("btnAnularOrden.Image"), System.Drawing.Image)
        Me.btnAnularOrden.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularOrden.Name = "btnAnularOrden"
        Me.btnAnularOrden.Size = New System.Drawing.Size(96, 22)
        Me.btnAnularOrden.Text = "Anular orden"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(21, 22)
        Me.lblConsecutivo.Text = "15"
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
        Me.lblDocumento.Size = New System.Drawing.Size(34, 22)
        Me.lblDocumento.Text = "OTM"
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
        Me.gbEncabezado.Controls.Add(Me.txtProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label4)
        Me.gbEncabezado.Controls.Add(Me.txtVendedor)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.txtObra)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 28)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(670, 120)
        Me.gbEncabezado.TabIndex = 1
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
        Me.gbMovimiento.TabIndex = 2
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'tsMovimiento
        '
        Me.tsMovimiento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripButton1})
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(92, 22)
        Me.ToolStripButton2.Text = "Movimiento"
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_concepto, Me.item_cantidadOrden, Me.item_cantidadOrigen, Me.item_unidadMedida, Me.item_precioUnitario, Me.item_subtotal, Me.item_porcRetenido, Me.item_facturable, Me.item_motivo, Me.item_idEstado, Me.item_estado, Me.item_notas})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 44)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(658, 204)
        Me.dwItems.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 411)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Notas"
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
        Me.gbTotales.TabIndex = 4
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
        Me.ImageList.Images.SetKeyName(1, "Con planeacion 17x17.png")
        Me.ImageList.Images.SetKeyName(2, "Sin planear 17x17.png")
        '
        'txtNotas
        '
        Me.txtNotas.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNotas.Enabled = False
        Me.txtNotas.Location = New System.Drawing.Point(12, 429)
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(440, 80)
        Me.txtNotas.TabIndex = 5
        '
        'item_concepto
        '
        Me.item_concepto.HeaderText = "Concepto"
        Me.item_concepto.Name = "item_concepto"
        Me.item_concepto.ReadOnly = True
        Me.item_concepto.Width = 78
        '
        'item_cantidadOrden
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.item_cantidadOrden.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_cantidadOrden.HeaderText = "Cantidad orden"
        Me.item_cantidadOrden.Name = "item_cantidadOrden"
        Me.item_cantidadOrden.ReadOnly = True
        Me.item_cantidadOrden.Width = 96
        '
        'item_cantidadOrigen
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        Me.item_cantidadOrigen.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_cantidadOrigen.HeaderText = "Cantidad origen"
        Me.item_cantidadOrigen.Name = "item_cantidadOrigen"
        Me.item_cantidadOrigen.ReadOnly = True
        Me.item_cantidadOrigen.Width = 97
        '
        'item_unidadMedida
        '
        Me.item_unidadMedida.HeaderText = "Unidad medida"
        Me.item_unidadMedida.Name = "item_unidadMedida"
        Me.item_unidadMedida.ReadOnly = True
        Me.item_unidadMedida.Width = 95
        '
        'item_precioUnitario
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.item_precioUnitario.DefaultCellStyle = DataGridViewCellStyle3
        Me.item_precioUnitario.HeaderText = "Precio unitario"
        Me.item_precioUnitario.Name = "item_precioUnitario"
        Me.item_precioUnitario.ReadOnly = True
        Me.item_precioUnitario.Width = 91
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
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
        'item_motivo
        '
        Me.item_motivo.HeaderText = "Motivo"
        Me.item_motivo.Name = "item_motivo"
        Me.item_motivo.ReadOnly = True
        Me.item_motivo.Width = 64
        '
        'item_idEstado
        '
        Me.item_idEstado.HeaderText = "IdEstado"
        Me.item_idEstado.Name = "item_idEstado"
        Me.item_idEstado.ReadOnly = True
        Me.item_idEstado.Visible = False
        Me.item_idEstado.Width = 74
        '
        'item_estado
        '
        Me.item_estado.HeaderText = "Estado"
        Me.item_estado.Name = "item_estado"
        Me.item_estado.ReadOnly = True
        Me.item_estado.Width = 46
        '
        'item_notas
        '
        Me.item_notas.HeaderText = "Notas"
        Me.item_notas.Name = "item_notas"
        Me.item_notas.ReadOnly = True
        Me.item_notas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.item_notas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.item_notas.Width = 41
        '
        'frmVistaOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 521)
        Me.Controls.Add(Me.txtNotas)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.Controls.Add(Me.tsHerramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaOrdenTrabajo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista orden trabajo"
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
    Friend WithEvents btnAnularOrden As ToolStripButton
    Friend WithEvents lblConsecutivo As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents lblDocumento As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents gbEncabezado As GroupBox
    Friend WithEvents txtFechaCreacion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbMovimiento As GroupBox
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents gbTotales As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblRetenido As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tsMovimiento As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ImageList As ImageList
    Friend WithEvents txtNotas As TextBox
    Friend WithEvents item_concepto As DataGridViewTextBoxColumn
    Friend WithEvents item_cantidadOrden As DataGridViewTextBoxColumn
    Friend WithEvents item_cantidadOrigen As DataGridViewTextBoxColumn
    Friend WithEvents item_unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents item_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents item_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents item_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents item_facturable As DataGridViewCheckBoxColumn
    Friend WithEvents item_motivo As DataGridViewTextBoxColumn
    Friend WithEvents item_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents item_estado As DataGridViewImageColumn
    Friend WithEvents item_notas As DataGridViewTextBoxColumn
End Class
