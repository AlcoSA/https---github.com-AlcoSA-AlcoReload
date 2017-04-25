<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpAprobadas
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
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idOped = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefonoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccionCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mailCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefonoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccionObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ciudadObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mailObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaRecibido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaTomaMedidas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTiempoEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiempoentrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.semanaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.puntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.zona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.destinoMateriales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTerceroProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.terceroProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroDevoluciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.indDiasHabiles = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.aprobacionCliente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltrado.Grid = Nothing
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(654, 82)
        Me.fddFiltrado.TabIndex = 1
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoGenerateColumns = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idOped, Me.nit, Me.cliente, Me.telefonoCliente, Me.direccionCliente, Me.mailCliente, Me.contactoCliente, Me.codigoObra, Me.obra, Me.contactoObra, Me.telefonoObra, Me.direccionObra, Me.ciudadObra, Me.mailObra, Me.fechaRecibido, Me.fechaTomaMedidas, Me.idTiempoEntrega, Me.tiempoentrega, Me.fechaEntrega, Me.semanaEntrega, Me.puntos, Me.idVendedor, Me.zona, Me.metros, Me.destinoMateriales, Me.idTerceroProduccion, Me.terceroProduccion, Me.numeroDevoluciones, Me.fechaCreacion, Me.usuarioCreacion, Me.idEstado, Me.estado, Me.indDiasHabiles, Me.facturable, Me.aprobacionCliente})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 82)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(654, 350)
        Me.dwItem.TabIndex = 2
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id OP"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 59
        '
        'idOped
        '
        Me.idOped.HeaderText = "Id Oped"
        Me.idOped.Name = "idOped"
        Me.idOped.ReadOnly = True
        Me.idOped.Visible = False
        Me.idOped.Width = 70
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 45
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 64
        '
        'telefonoCliente
        '
        Me.telefonoCliente.HeaderText = "Teléfono cliente"
        Me.telefonoCliente.Name = "telefonoCliente"
        Me.telefonoCliente.ReadOnly = True
        Me.telefonoCliente.Width = 99
        '
        'direccionCliente
        '
        Me.direccionCliente.HeaderText = "Dirección cliente"
        Me.direccionCliente.Name = "direccionCliente"
        Me.direccionCliente.ReadOnly = True
        Me.direccionCliente.Width = 102
        '
        'mailCliente
        '
        Me.mailCliente.HeaderText = "Mail cliente"
        Me.mailCliente.Name = "mailCliente"
        Me.mailCliente.ReadOnly = True
        Me.mailCliente.Width = 78
        '
        'contactoCliente
        '
        Me.contactoCliente.HeaderText = "Contacto cliente"
        Me.contactoCliente.Name = "contactoCliente"
        Me.contactoCliente.ReadOnly = True
        '
        'codigoObra
        '
        Me.codigoObra.HeaderText = "Código obra"
        Me.codigoObra.Name = "codigoObra"
        Me.codigoObra.ReadOnly = True
        Me.codigoObra.Width = 82
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        Me.obra.Width = 55
        '
        'contactoObra
        '
        Me.contactoObra.HeaderText = "Contacto obra"
        Me.contactoObra.Name = "contactoObra"
        Me.contactoObra.ReadOnly = True
        Me.contactoObra.Width = 91
        '
        'telefonoObra
        '
        Me.telefonoObra.HeaderText = "Teléfono obra"
        Me.telefonoObra.Name = "telefonoObra"
        Me.telefonoObra.ReadOnly = True
        Me.telefonoObra.Width = 90
        '
        'direccionObra
        '
        Me.direccionObra.HeaderText = "Dirección obra"
        Me.direccionObra.Name = "direccionObra"
        Me.direccionObra.ReadOnly = True
        Me.direccionObra.Width = 93
        '
        'ciudadObra
        '
        Me.ciudadObra.HeaderText = "Ciudad obra"
        Me.ciudadObra.Name = "ciudadObra"
        Me.ciudadObra.ReadOnly = True
        Me.ciudadObra.Width = 82
        '
        'mailObra
        '
        Me.mailObra.HeaderText = "Mail obra"
        Me.mailObra.Name = "mailObra"
        Me.mailObra.ReadOnly = True
        Me.mailObra.Width = 69
        '
        'fechaRecibido
        '
        Me.fechaRecibido.HeaderText = "Fecha recibido"
        Me.fechaRecibido.Name = "fechaRecibido"
        Me.fechaRecibido.ReadOnly = True
        Me.fechaRecibido.Width = 94
        '
        'fechaTomaMedidas
        '
        Me.fechaTomaMedidas.HeaderText = "Fecha toma medidas"
        Me.fechaTomaMedidas.Name = "fechaTomaMedidas"
        Me.fechaTomaMedidas.ReadOnly = True
        Me.fechaTomaMedidas.Width = 119
        '
        'idTiempoEntrega
        '
        Me.idTiempoEntrega.HeaderText = "Id tiempo entrega"
        Me.idTiempoEntrega.Name = "idTiempoEntrega"
        Me.idTiempoEntrega.ReadOnly = True
        Me.idTiempoEntrega.Visible = False
        Me.idTiempoEntrega.Width = 105
        '
        'tiempoentrega
        '
        Me.tiempoentrega.HeaderText = "Dias entrega"
        Me.tiempoentrega.Name = "tiempoentrega"
        Me.tiempoentrega.ReadOnly = True
        Me.tiempoentrega.Width = 85
        '
        'fechaEntrega
        '
        Me.fechaEntrega.HeaderText = "Fecha entrega"
        Me.fechaEntrega.Name = "fechaEntrega"
        Me.fechaEntrega.ReadOnly = True
        Me.fechaEntrega.Width = 93
        '
        'semanaEntrega
        '
        Me.semanaEntrega.HeaderText = "Semana entrega"
        Me.semanaEntrega.Name = "semanaEntrega"
        Me.semanaEntrega.ReadOnly = True
        Me.semanaEntrega.Width = 101
        '
        'puntos
        '
        Me.puntos.HeaderText = "Puntos"
        Me.puntos.Name = "puntos"
        Me.puntos.ReadOnly = True
        Me.puntos.Width = 65
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "Id vendedor"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Width = 82
        '
        'zona
        '
        Me.zona.HeaderText = "Zona"
        Me.zona.Name = "zona"
        Me.zona.ReadOnly = True
        Me.zona.Width = 57
        '
        'metros
        '
        Me.metros.HeaderText = "Metros"
        Me.metros.Name = "metros"
        Me.metros.ReadOnly = True
        Me.metros.Width = 64
        '
        'destinoMateriales
        '
        Me.destinoMateriales.HeaderText = "Destino materiales"
        Me.destinoMateriales.Name = "destinoMateriales"
        Me.destinoMateriales.ReadOnly = True
        Me.destinoMateriales.Width = 108
        '
        'idTerceroProduccion
        '
        Me.idTerceroProduccion.HeaderText = "Id tercero producción"
        Me.idTerceroProduccion.Name = "idTerceroProduccion"
        Me.idTerceroProduccion.ReadOnly = True
        Me.idTerceroProduccion.Visible = False
        Me.idTerceroProduccion.Width = 122
        '
        'terceroProduccion
        '
        Me.terceroProduccion.HeaderText = "Tercero producción"
        Me.terceroProduccion.Name = "terceroProduccion"
        Me.terceroProduccion.ReadOnly = True
        Me.terceroProduccion.Width = 114
        '
        'numeroDevoluciones
        '
        Me.numeroDevoluciones.HeaderText = "Número devoluciones"
        Me.numeroDevoluciones.Name = "numeroDevoluciones"
        Me.numeroDevoluciones.ReadOnly = True
        Me.numeroDevoluciones.Width = 123
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Width = 97
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Width = 103
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'indDiasHabiles
        '
        Me.indDiasHabiles.HeaderText = "Ind dias hábiles"
        Me.indDiasHabiles.Name = "indDiasHabiles"
        Me.indDiasHabiles.ReadOnly = True
        Me.indDiasHabiles.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.indDiasHabiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.indDiasHabiles.Width = 96
        '
        'facturable
        '
        Me.facturable.HeaderText = "Facturable"
        Me.facturable.Name = "facturable"
        Me.facturable.ReadOnly = True
        Me.facturable.Width = 63
        '
        'aprobacionCliente
        '
        Me.aprobacionCliente.HeaderText = "Aprobación cliente"
        Me.aprobacionCliente.Name = "aprobacionCliente"
        Me.aprobacionCliente.ReadOnly = True
        Me.aprobacionCliente.Width = 91
        '
        'FrmOpAprobadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 432)
        Me.Controls.Add(Me.dwItem)
        Me.Controls.Add(Me.fddFiltrado)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOpAprobadas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Ordenes producción aprobadas"
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idOped As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents telefonoCliente As DataGridViewTextBoxColumn
    Friend WithEvents direccionCliente As DataGridViewTextBoxColumn
    Friend WithEvents mailCliente As DataGridViewTextBoxColumn
    Friend WithEvents contactoCliente As DataGridViewTextBoxColumn
    Friend WithEvents codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents contactoObra As DataGridViewTextBoxColumn
    Friend WithEvents telefonoObra As DataGridViewTextBoxColumn
    Friend WithEvents direccionObra As DataGridViewTextBoxColumn
    Friend WithEvents ciudadObra As DataGridViewTextBoxColumn
    Friend WithEvents mailObra As DataGridViewTextBoxColumn
    Friend WithEvents fechaRecibido As DataGridViewTextBoxColumn
    Friend WithEvents fechaTomaMedidas As DataGridViewTextBoxColumn
    Friend WithEvents idTiempoEntrega As DataGridViewTextBoxColumn
    Friend WithEvents tiempoentrega As DataGridViewTextBoxColumn
    Friend WithEvents fechaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents semanaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents puntos As DataGridViewTextBoxColumn
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents zona As DataGridViewTextBoxColumn
    Friend WithEvents metros As DataGridViewTextBoxColumn
    Friend WithEvents destinoMateriales As DataGridViewTextBoxColumn
    Friend WithEvents idTerceroProduccion As DataGridViewTextBoxColumn
    Friend WithEvents terceroProduccion As DataGridViewTextBoxColumn
    Friend WithEvents numeroDevoluciones As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents indDiasHabiles As DataGridViewCheckBoxColumn
    Friend WithEvents facturable As DataGridViewCheckBoxColumn
    Friend WithEvents aprobacionCliente As DataGridViewCheckBoxColumn
End Class
