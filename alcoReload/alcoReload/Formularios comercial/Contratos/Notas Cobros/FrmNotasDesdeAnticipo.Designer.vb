<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNotasDesdeAnticipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotasDesdeAnticipo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dwItems = New DatagridTreeView.DataTreeGridView()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtValSuministro = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFiltrar = New System.Windows.Forms.ToolStripButton()
        Me.btnReiniciarFiltros = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportarExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnExportarPDF = New System.Windows.Forms.ToolStripButton()
        Me.Id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idPlan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.constructora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoAnticipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoAnticipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcentAnticipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuotas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rangoDias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorContratado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.seleccion, Me.idPlan, Me.fechaCreacion, Me.usuarioCreacion, Me.idContrato, Me.nit, Me.obra, Me.constructora, Me.codSucursal, Me.numContrato, Me.idTipoAnticipo, Me.tipoAnticipo, Me.porcentAnticipo, Me.cuotas, Me.rangoDias, Me.valorContratado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(11, 26)
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(768, 391)
        Me.dwItems.TabIndex = 3
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.ToolStripSeparator3, Me.txtValSuministro, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripLabel3, Me.ToolStripSeparator2, Me.btnFiltrar, Me.btnReiniciarFiltros, Me.ToolStripSeparator4, Me.btnExportarExcel, Me.btnExportarPDF})
        Me.tsherramientas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(792, 23)
        Me.tsherramientas.Stretch = True
        Me.tsherramientas.TabIndex = 4
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 4)
        Me.btnGuardar.Text = "Guardar PLan"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'txtValSuministro
        '
        Me.txtValSuministro.Name = "txtValSuministro"
        Me.txtValSuministro.Size = New System.Drawing.Size(70, 15)
        Me.txtValSuministro.Text = "Fecha inicio"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(17, 15)
        Me.ToolStripLabel1.Text = "--"
        Me.ToolStripLabel1.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(55, 15)
        Me.ToolStripLabel2.Text = "Fecha fin"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 15)
        Me.ToolStripLabel3.Text = "--"
        Me.ToolStripLabel3.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Image = CType(resources.GetObject("btnFiltrar.Image"), System.Drawing.Image)
        Me.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(57, 20)
        Me.btnFiltrar.Text = "Filtrar"
        '
        'btnReiniciarFiltros
        '
        Me.btnReiniciarFiltros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReiniciarFiltros.Image = CType(resources.GetObject("btnReiniciarFiltros.Image"), System.Drawing.Image)
        Me.btnReiniciarFiltros.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReiniciarFiltros.Name = "btnReiniciarFiltros"
        Me.btnReiniciarFiltros.Size = New System.Drawing.Size(23, 20)
        Me.btnReiniciarFiltros.Text = "Recargar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(23, 20)
        Me.btnExportarExcel.Text = "Exportar a Excel"
        '
        'btnExportarPDF
        '
        Me.btnExportarPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExportarPDF.Image = CType(resources.GetObject("btnExportarPDF.Image"), System.Drawing.Image)
        Me.btnExportarPDF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportarPDF.Name = "btnExportarPDF"
        Me.btnExportarPDF.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExportarPDF.Size = New System.Drawing.Size(23, 20)
        Me.btnExportarPDF.Text = "Exportar a PDF"
        '
        'Id
        '
        Me.Id.Frozen = True
        Me.Id.HeaderText = ""
        Me.Id.ImagenporDefecto = Nothing
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 19
        '
        'seleccion
        '
        Me.seleccion.Frozen = True
        Me.seleccion.HeaderText = "Selección"
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Visible = False
        Me.seleccion.Width = 60
        '
        'idPlan
        '
        Me.idPlan.HeaderText = "Id plan"
        Me.idPlan.Name = "idPlan"
        Me.idPlan.ReadOnly = True
        Me.idPlan.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idPlan.Visible = False
        Me.idPlan.Width = 64
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Visible = False
        Me.fechaCreacion.Width = 106
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Visible = False
        Me.usuarioCreacion.Width = 112
        '
        'idContrato
        '
        Me.idContrato.HeaderText = "IdContrato"
        Me.idContrato.Name = "idContrato"
        Me.idContrato.ReadOnly = True
        Me.idContrato.Visible = False
        Me.idContrato.Width = 81
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nit.Width = 45
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        Me.obra.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.obra.Width = 55
        '
        'constructora
        '
        Me.constructora.HeaderText = "Constructora"
        Me.constructora.Name = "constructora"
        Me.constructora.ReadOnly = True
        Me.constructora.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.constructora.Width = 92
        '
        'codSucursal
        '
        Me.codSucursal.HeaderText = "Código sucursal"
        Me.codSucursal.Name = "codSucursal"
        Me.codSucursal.ReadOnly = True
        Me.codSucursal.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.codSucursal.Width = 107
        '
        'numContrato
        '
        Me.numContrato.HeaderText = "Número contrato"
        Me.numContrato.Name = "numContrato"
        Me.numContrato.ReadOnly = True
        Me.numContrato.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.numContrato.Width = 111
        '
        'idTipoAnticipo
        '
        Me.idTipoAnticipo.HeaderText = "IdTipoAnticipo"
        Me.idTipoAnticipo.Name = "idTipoAnticipo"
        Me.idTipoAnticipo.ReadOnly = True
        Me.idTipoAnticipo.Visible = False
        '
        'tipoAnticipo
        '
        Me.tipoAnticipo.HeaderText = "Tipo anticipo"
        Me.tipoAnticipo.Name = "tipoAnticipo"
        Me.tipoAnticipo.ReadOnly = True
        Me.tipoAnticipo.Width = 93
        '
        'porcentAnticipo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N2"
        Me.porcentAnticipo.DefaultCellStyle = DataGridViewCellStyle1
        Me.porcentAnticipo.HeaderText = "Porcentaje anticipo"
        Me.porcentAnticipo.Name = "porcentAnticipo"
        Me.porcentAnticipo.ReadOnly = True
        Me.porcentAnticipo.Width = 123
        '
        'cuotas
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        Me.cuotas.DefaultCellStyle = DataGridViewCellStyle2
        Me.cuotas.HeaderText = "Cuotas"
        Me.cuotas.Name = "cuotas"
        Me.cuotas.ReadOnly = True
        Me.cuotas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cuotas.Width = 65
        '
        'rangoDias
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.rangoDias.DefaultCellStyle = DataGridViewCellStyle3
        Me.rangoDias.HeaderText = "Rango días / fecha cuota"
        Me.rangoDias.Name = "rangoDias"
        Me.rangoDias.ReadOnly = True
        Me.rangoDias.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.rangoDias.Width = 156
        '
        'valorContratado
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.valorContratado.DefaultCellStyle = DataGridViewCellStyle4
        Me.valorContratado.HeaderText = "Valor contratado"
        Me.valorContratado.Name = "valorContratado"
        Me.valorContratado.ReadOnly = True
        Me.valorContratado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.valorContratado.Width = 110
        '
        'FrmNotasDesdeAnticipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 428)
        Me.Controls.Add(Me.tsherramientas)
        Me.Controls.Add(Me.dwItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNotasDesdeAnticipo"
        Me.Text = "Notas desde anticipo"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dwItems As DatagridTreeView.DataTreeGridView
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents txtValSuministro As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnFiltrar As ToolStripButton
    Friend WithEvents btnReiniciarFiltros As ToolStripButton
    Friend WithEvents btnExportarExcel As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnExportarPDF As ToolStripButton
    Friend WithEvents Id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents idPlan As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idContrato As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents constructora As DataGridViewTextBoxColumn
    Friend WithEvents codSucursal As DataGridViewTextBoxColumn
    Friend WithEvents numContrato As DataGridViewTextBoxColumn
    Friend WithEvents idTipoAnticipo As DataGridViewTextBoxColumn
    Friend WithEvents tipoAnticipo As DataGridViewTextBoxColumn
    Friend WithEvents porcentAnticipo As DataGridViewTextBoxColumn
    Friend WithEvents cuotas As DataGridViewTextBoxColumn
    Friend WithEvents rangoDias As DataGridViewTextBoxColumn
    Friend WithEvents valorContratado As DataGridViewTextBoxColumn
End Class
