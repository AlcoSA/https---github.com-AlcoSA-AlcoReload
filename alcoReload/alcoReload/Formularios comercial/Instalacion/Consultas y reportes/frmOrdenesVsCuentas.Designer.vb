<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrdenesVsCuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenesVsCuentas))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtObra = New System.Windows.Forms.ToolStripTextBox()
        Me.btnBuscarObra = New System.Windows.Forms.ToolStripButton()
        Me.btnExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.spcPrincipal = New System.Windows.Forms.SplitContainer()
        Me.dwOrdenesTrabajo = New DatagridTreeView.DataTreeGridView()
        Me.spcDetalles = New System.Windows.Forms.SplitContainer()
        Me.dwPagoRetenidos = New System.Windows.Forms.DataGridView()
        Me.pr_fechaPagoRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_fechaCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_encargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_retenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_retenidoPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.ot_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_pagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_disponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_precioTotalCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ot_motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsHerramientas.SuspendLayout()
        CType(Me.spcPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcPrincipal.Panel1.SuspendLayout()
        Me.spcPrincipal.Panel2.SuspendLayout()
        Me.spcPrincipal.SuspendLayout()
        CType(Me.dwOrdenesTrabajo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spcDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcDetalles.Panel1.SuspendLayout()
        Me.spcDetalles.SuspendLayout()
        CType(Me.dwPagoRetenidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txtObra, Me.btnBuscarObra, Me.btnExportExcel})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(971, 25)
        Me.tsHerramientas.TabIndex = 0
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel1.Text = "Obra:"
        '
        'txtObra
        '
        Me.txtObra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtObra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.MaxLength = 100
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(200, 25)
        '
        'btnBuscarObra
        '
        Me.btnBuscarObra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscarObra.Image = CType(resources.GetObject("btnBuscarObra.Image"), System.Drawing.Image)
        Me.btnBuscarObra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscarObra.Name = "btnBuscarObra"
        Me.btnBuscarObra.Size = New System.Drawing.Size(23, 22)
        Me.btnBuscarObra.Text = "Buscar obras"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(108, 22)
        Me.btnExportExcel.Text = "Exportar a Excel"
        '
        'spcPrincipal
        '
        Me.spcPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcPrincipal.Location = New System.Drawing.Point(0, 25)
        Me.spcPrincipal.Name = "spcPrincipal"
        Me.spcPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcPrincipal.Panel1
        '
        Me.spcPrincipal.Panel1.Controls.Add(Me.dwOrdenesTrabajo)
        '
        'spcPrincipal.Panel2
        '
        Me.spcPrincipal.Panel2.Controls.Add(Me.spcDetalles)
        Me.spcPrincipal.Size = New System.Drawing.Size(971, 496)
        Me.spcPrincipal.SplitterDistance = 348
        Me.spcPrincipal.TabIndex = 1
        '
        'dwOrdenesTrabajo
        '
        Me.dwOrdenesTrabajo.AllowUserToAddRows = False
        Me.dwOrdenesTrabajo.AllowUserToDeleteRows = False
        Me.dwOrdenesTrabajo.AllowUserToResizeColumns = False
        Me.dwOrdenesTrabajo.AllowUserToResizeRows = False
        Me.dwOrdenesTrabajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwOrdenesTrabajo.BackgroundColor = System.Drawing.Color.White
        Me.dwOrdenesTrabajo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dwOrdenesTrabajo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ot_id, Me.ot_concepto, Me.ot_descripcion, Me.ot_idProveedor, Me.ot_proveedor, Me.ot_cantidad, Me.ot_precioUnitario, Me.ot_precioTotal, Me.ot_pagado, Me.ot_disponible, Me.ot_precioCliente, Me.ot_precioTotalCliente, Me.ot_utilidad, Me.ot_motivo})
        Me.dwOrdenesTrabajo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwOrdenesTrabajo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwOrdenesTrabajo.GridColor = System.Drawing.Color.DarkGray
        Me.dwOrdenesTrabajo.ImageList = Nothing
        Me.dwOrdenesTrabajo.Location = New System.Drawing.Point(0, 0)
        Me.dwOrdenesTrabajo.MultiSelect = False
        Me.dwOrdenesTrabajo.Name = "dwOrdenesTrabajo"
        Me.dwOrdenesTrabajo.ReadOnly = True
        Me.dwOrdenesTrabajo.RowHeadersVisible = False
        Me.dwOrdenesTrabajo.RowHeadersWidth = 20
        Me.dwOrdenesTrabajo.Size = New System.Drawing.Size(967, 344)
        Me.dwOrdenesTrabajo.TabIndex = 2
        '
        'spcDetalles
        '
        Me.spcDetalles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcDetalles.Location = New System.Drawing.Point(0, 0)
        Me.spcDetalles.Name = "spcDetalles"
        '
        'spcDetalles.Panel1
        '
        Me.spcDetalles.Panel1.Controls.Add(Me.dwPagoRetenidos)
        Me.spcDetalles.Size = New System.Drawing.Size(971, 144)
        Me.spcDetalles.SplitterDistance = 546
        Me.spcDetalles.TabIndex = 0
        '
        'dwPagoRetenidos
        '
        Me.dwPagoRetenidos.AllowUserToAddRows = False
        Me.dwPagoRetenidos.AllowUserToDeleteRows = False
        Me.dwPagoRetenidos.AllowUserToResizeColumns = False
        Me.dwPagoRetenidos.AllowUserToResizeRows = False
        Me.dwPagoRetenidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwPagoRetenidos.BackgroundColor = System.Drawing.Color.White
        Me.dwPagoRetenidos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dwPagoRetenidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwPagoRetenidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pr_fechaPagoRetenido, Me.pr_fechaCuenta, Me.pr_proveedor, Me.pr_encargado, Me.pr_subtotal, Me.pr_retenido, Me.pr_total, Me.pr_retenidoPagado})
        Me.dwPagoRetenidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwPagoRetenidos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwPagoRetenidos.Location = New System.Drawing.Point(0, 0)
        Me.dwPagoRetenidos.MultiSelect = False
        Me.dwPagoRetenidos.Name = "dwPagoRetenidos"
        Me.dwPagoRetenidos.ReadOnly = True
        Me.dwPagoRetenidos.RowHeadersVisible = False
        Me.dwPagoRetenidos.Size = New System.Drawing.Size(542, 140)
        Me.dwPagoRetenidos.TabIndex = 0
        '
        'pr_fechaPagoRetenido
        '
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.pr_fechaPagoRetenido.DefaultCellStyle = DataGridViewCellStyle9
        Me.pr_fechaPagoRetenido.HeaderText = "Fecha pago retenido"
        Me.pr_fechaPagoRetenido.Name = "pr_fechaPagoRetenido"
        Me.pr_fechaPagoRetenido.ReadOnly = True
        Me.pr_fechaPagoRetenido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_fechaPagoRetenido.Visible = False
        Me.pr_fechaPagoRetenido.Width = 111
        '
        'pr_fechaCuenta
        '
        DataGridViewCellStyle10.Format = "d"
        Me.pr_fechaCuenta.DefaultCellStyle = DataGridViewCellStyle10
        Me.pr_fechaCuenta.HeaderText = "Fecha cuenta"
        Me.pr_fechaCuenta.Name = "pr_fechaCuenta"
        Me.pr_fechaCuenta.ReadOnly = True
        Me.pr_fechaCuenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_fechaCuenta.Width = 71
        '
        'pr_proveedor
        '
        Me.pr_proveedor.HeaderText = "Proveedor"
        Me.pr_proveedor.Name = "pr_proveedor"
        Me.pr_proveedor.ReadOnly = True
        Me.pr_proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_proveedor.Width = 62
        '
        'pr_encargado
        '
        Me.pr_encargado.HeaderText = "Encargado"
        Me.pr_encargado.Name = "pr_encargado"
        Me.pr_encargado.ReadOnly = True
        Me.pr_encargado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_encargado.Width = 65
        '
        'pr_subtotal
        '
        DataGridViewCellStyle11.Format = "C0"
        Me.pr_subtotal.DefaultCellStyle = DataGridViewCellStyle11
        Me.pr_subtotal.HeaderText = "Subtotal"
        Me.pr_subtotal.Name = "pr_subtotal"
        Me.pr_subtotal.ReadOnly = True
        Me.pr_subtotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_subtotal.Width = 52
        '
        'pr_retenido
        '
        DataGridViewCellStyle12.Format = "C0"
        Me.pr_retenido.DefaultCellStyle = DataGridViewCellStyle12
        Me.pr_retenido.HeaderText = "Retenido"
        Me.pr_retenido.Name = "pr_retenido"
        Me.pr_retenido.ReadOnly = True
        Me.pr_retenido.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_retenido.Width = 56
        '
        'pr_total
        '
        DataGridViewCellStyle13.Format = "C0"
        Me.pr_total.DefaultCellStyle = DataGridViewCellStyle13
        Me.pr_total.HeaderText = "Total"
        Me.pr_total.Name = "pr_total"
        Me.pr_total.ReadOnly = True
        Me.pr_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_total.Width = 37
        '
        'pr_retenidoPagado
        '
        DataGridViewCellStyle14.Format = "C0"
        Me.pr_retenidoPagado.DefaultCellStyle = DataGridViewCellStyle14
        Me.pr_retenidoPagado.HeaderText = "Retenido pagado"
        Me.pr_retenidoPagado.Name = "pr_retenidoPagado"
        Me.pr_retenidoPagado.ReadOnly = True
        Me.pr_retenidoPagado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pr_retenidoPagado.Width = 86
        '
        'ot_id
        '
        Me.ot_id.HeaderText = ""
        Me.ot_id.ImagenporDefecto = Nothing
        Me.ot_id.Name = "ot_id"
        Me.ot_id.ReadOnly = True
        Me.ot_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_id.Width = 5
        '
        'ot_concepto
        '
        Me.ot_concepto.HeaderText = "Concepto"
        Me.ot_concepto.Name = "ot_concepto"
        Me.ot_concepto.ReadOnly = True
        Me.ot_concepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_concepto.Width = 59
        '
        'ot_descripcion
        '
        Me.ot_descripcion.HeaderText = "Descripción"
        Me.ot_descripcion.Name = "ot_descripcion"
        Me.ot_descripcion.ReadOnly = True
        Me.ot_descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_descripcion.Width = 69
        '
        'ot_idProveedor
        '
        Me.ot_idProveedor.HeaderText = "Id proveedor"
        Me.ot_idProveedor.Name = "ot_idProveedor"
        Me.ot_idProveedor.ReadOnly = True
        Me.ot_idProveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_idProveedor.Visible = False
        Me.ot_idProveedor.Width = 73
        '
        'ot_proveedor
        '
        Me.ot_proveedor.HeaderText = "Proveedor"
        Me.ot_proveedor.Name = "ot_proveedor"
        Me.ot_proveedor.ReadOnly = True
        Me.ot_proveedor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_proveedor.Width = 62
        '
        'ot_cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.ot_cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.ot_cantidad.HeaderText = "Cantidad"
        Me.ot_cantidad.Name = "ot_cantidad"
        Me.ot_cantidad.ReadOnly = True
        Me.ot_cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_cantidad.Width = 55
        '
        'ot_precioUnitario
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C0"
        Me.ot_precioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.ot_precioUnitario.HeaderText = "Precio unitario"
        Me.ot_precioUnitario.Name = "ot_precioUnitario"
        Me.ot_precioUnitario.ReadOnly = True
        Me.ot_precioUnitario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_precioUnitario.Width = 80
        '
        'ot_precioTotal
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.ot_precioTotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.ot_precioTotal.HeaderText = "Precio total"
        Me.ot_precioTotal.Name = "ot_precioTotal"
        Me.ot_precioTotal.ReadOnly = True
        Me.ot_precioTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_precioTotal.Width = 66
        '
        'ot_pagado
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        Me.ot_pagado.DefaultCellStyle = DataGridViewCellStyle4
        Me.ot_pagado.HeaderText = "Pagado"
        Me.ot_pagado.Name = "ot_pagado"
        Me.ot_pagado.ReadOnly = True
        Me.ot_pagado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_pagado.Width = 50
        '
        'ot_disponible
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        Me.ot_disponible.DefaultCellStyle = DataGridViewCellStyle5
        Me.ot_disponible.HeaderText = "Disponible"
        Me.ot_disponible.Name = "ot_disponible"
        Me.ot_disponible.ReadOnly = True
        Me.ot_disponible.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_disponible.Width = 62
        '
        'ot_precioCliente
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C0"
        Me.ot_precioCliente.DefaultCellStyle = DataGridViewCellStyle6
        Me.ot_precioCliente.HeaderText = "Precio cliente"
        Me.ot_precioCliente.Name = "ot_precioCliente"
        Me.ot_precioCliente.ReadOnly = True
        Me.ot_precioCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_precioCliente.Width = 77
        '
        'ot_precioTotalCliente
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C0"
        Me.ot_precioTotalCliente.DefaultCellStyle = DataGridViewCellStyle7
        Me.ot_precioTotalCliente.HeaderText = "Precio total cliente"
        Me.ot_precioTotalCliente.Name = "ot_precioTotalCliente"
        Me.ot_precioTotalCliente.ReadOnly = True
        Me.ot_precioTotalCliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ot_utilidad
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C0"
        Me.ot_utilidad.DefaultCellStyle = DataGridViewCellStyle8
        Me.ot_utilidad.HeaderText = "Utilidad"
        Me.ot_utilidad.Name = "ot_utilidad"
        Me.ot_utilidad.ReadOnly = True
        Me.ot_utilidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_utilidad.Width = 48
        '
        'ot_motivo
        '
        Me.ot_motivo.HeaderText = "Motivo"
        Me.ot_motivo.Name = "ot_motivo"
        Me.ot_motivo.ReadOnly = True
        Me.ot_motivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ot_motivo.Width = 45
        '
        'frmOrdenesVsCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 521)
        Me.Controls.Add(Me.spcPrincipal)
        Me.Controls.Add(Me.tsHerramientas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenesVsCuentas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Ordenes vs cuentas"
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.spcPrincipal.Panel1.ResumeLayout(False)
        Me.spcPrincipal.Panel2.ResumeLayout(False)
        CType(Me.spcPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcPrincipal.ResumeLayout(False)
        CType(Me.dwOrdenesTrabajo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcDetalles.Panel1.ResumeLayout(False)
        CType(Me.spcDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcDetalles.ResumeLayout(False)
        CType(Me.dwPagoRetenidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtObra As ToolStripTextBox
    Friend WithEvents btnBuscarObra As ToolStripButton
    Friend WithEvents spcPrincipal As SplitContainer
    Friend WithEvents dwOrdenesTrabajo As DatagridTreeView.DataTreeGridView
    Friend WithEvents spcDetalles As SplitContainer
    Friend WithEvents dwPagoRetenidos As DataGridView
    Friend WithEvents pr_fechaPagoRetenido As DataGridViewTextBoxColumn
    Friend WithEvents pr_fechaCuenta As DataGridViewTextBoxColumn
    Friend WithEvents pr_proveedor As DataGridViewTextBoxColumn
    Friend WithEvents pr_encargado As DataGridViewTextBoxColumn
    Friend WithEvents pr_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents pr_retenido As DataGridViewTextBoxColumn
    Friend WithEvents pr_total As DataGridViewTextBoxColumn
    Friend WithEvents pr_retenidoPagado As DataGridViewTextBoxColumn
    Friend WithEvents btnExportExcel As ToolStripButton
    Friend WithEvents ot_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents ot_concepto As DataGridViewTextBoxColumn
    Friend WithEvents ot_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ot_idProveedor As DataGridViewTextBoxColumn
    Friend WithEvents ot_proveedor As DataGridViewTextBoxColumn
    Friend WithEvents ot_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioTotal As DataGridViewTextBoxColumn
    Friend WithEvents ot_pagado As DataGridViewTextBoxColumn
    Friend WithEvents ot_disponible As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioCliente As DataGridViewTextBoxColumn
    Friend WithEvents ot_precioTotalCliente As DataGridViewTextBoxColumn
    Friend WithEvents ot_utilidad As DataGridViewTextBoxColumn
    Friend WithEvents ot_motivo As DataGridViewTextBoxColumn
End Class
