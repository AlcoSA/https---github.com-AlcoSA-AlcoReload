<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListarOrdenesPedido
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.scgeneral = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aproba_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ciudad_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiempo_entrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SemanaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Puntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Zona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UbicacionVentanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTerceroProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerceroProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirTercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telTercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nroDevoluciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioAprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scgeneral.Panel1.SuspendLayout()
        Me.scgeneral.Panel2.SuspendLayout()
        Me.scgeneral.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scgeneral
        '
        Me.scgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scgeneral.Location = New System.Drawing.Point(0, 0)
        Me.scgeneral.Name = "scgeneral"
        Me.scgeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scgeneral.Panel1
        '
        Me.scgeneral.Panel1.Controls.Add(Me.fddFiltrado)
        '
        'scgeneral.Panel2
        '
        Me.scgeneral.Panel2.Controls.Add(Me.dwItem)
        Me.scgeneral.Size = New System.Drawing.Size(546, 422)
        Me.scgeneral.SplitterDistance = 80
        Me.scgeneral.TabIndex = 3
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(546, 80)
        Me.fddFiltrado.TabIndex = 0
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
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion, Me.Estado, Me.Aproba_cliente, Me.id, Me.nit, Me.codigo_obra, Me.Obra, Me.Cliente, Me.telefono_cliente, Me.idContrato, Me.direccion_cliente, Me.telefono_obra, Me.direccion_obra, Me.ciudad_obra, Me.tiempo_entrega, Me.FechaEntrega, Me.SemanaEntrega, Me.Puntos, Me.idVendedor, Me.Zona, Me.Metros, Me.UbicacionVentanas, Me.idTerceroProd, Me.TerceroProduccion, Me.DirTercero, Me.telTercero, Me.nroDevoluciones, Me.FechaCreacion, Me.UsuarioCreacion, Me.FechaModi, Me.UsuarioModi, Me.UsuarioAprobacion, Me.FechaAprobacion, Me.UsuarioAnulacion, Me.FechaAnulacion, Me.Idestado})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(546, 338)
        Me.dwItem.TabIndex = 1
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Nro. Op"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 64
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nit"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 45
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "Cod. Obra"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 74
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.Frozen = True
        Me.DataGridViewTextBoxColumn4.HeaderText = "Obra"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 55
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cliente"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 64
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Tel. Cliente"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 85
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Nro. Contrato"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 95
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Dir. Cliente"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 83
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Tel. Obra"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 76
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Dir. Obra"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 74
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Ciudad Obra"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 84
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Plazo Entrega"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 90
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Fecha entrega"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 93
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Semana Entrega"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 111
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Puntos"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 65
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Vendedor"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 78
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Zona"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 57
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Metros"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Width = 64
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Ubic. Ventanas"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 105
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "id Terc. Produccion"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.ReadOnly = True
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 125
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Terc. Producción"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.ReadOnly = True
        Me.DataGridViewTextBoxColumn21.Width = 105
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "Dir Tercero Prod."
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.ReadOnly = True
        Me.DataGridViewTextBoxColumn22.Visible = False
        Me.DataGridViewTextBoxColumn22.Width = 104
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "Tel. Terc. Prod"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        Me.DataGridViewTextBoxColumn23.Width = 95
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "Nro. Devoluciones."
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        Me.DataGridViewTextBoxColumn24.Visible = False
        Me.DataGridViewTextBoxColumn24.Width = 113
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Fecha Creacion"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        Me.DataGridViewTextBoxColumn25.Width = 98
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "Usuario Creación"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        Me.DataGridViewTextBoxColumn26.Width = 104
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.HeaderText = "Fecha Modificación"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.ReadOnly = True
        Me.DataGridViewTextBoxColumn27.Visible = False
        Me.DataGridViewTextBoxColumn27.Width = 114
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.HeaderText = "Usuario Modificación"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.ReadOnly = True
        Me.DataGridViewTextBoxColumn28.Visible = False
        Me.DataGridViewTextBoxColumn28.Width = 120
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.HeaderText = "Usuario Aprobación"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        Me.DataGridViewTextBoxColumn29.ReadOnly = True
        Me.DataGridViewTextBoxColumn29.Visible = False
        Me.DataGridViewTextBoxColumn29.Width = 114
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.HeaderText = "Fecha Aprobación"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.ReadOnly = True
        Me.DataGridViewTextBoxColumn30.Visible = False
        Me.DataGridViewTextBoxColumn30.Width = 109
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.HeaderText = "Usuario Anulación"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.ReadOnly = True
        Me.DataGridViewTextBoxColumn31.Visible = False
        Me.DataGridViewTextBoxColumn31.Width = 108
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.HeaderText = "Fecha Anulación"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        Me.DataGridViewTextBoxColumn32.ReadOnly = True
        Me.DataGridViewTextBoxColumn32.Visible = False
        Me.DataGridViewTextBoxColumn32.Width = 103
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.HeaderText = "Id Estado"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        Me.DataGridViewTextBoxColumn33.ReadOnly = True
        Me.DataGridViewTextBoxColumn33.Visible = False
        Me.DataGridViewTextBoxColumn33.Width = 71
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        Me.DataGridViewTextBoxColumn34.ReadOnly = True
        Me.DataGridViewTextBoxColumn34.Width = 65
        '
        'seleccion
        '
        Me.seleccion.HeaderText = "Selección"
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Width = 60
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Aproba_cliente
        '
        Me.Aproba_cliente.HeaderText = "Aprobado"
        Me.Aproba_cliente.Name = "Aproba_cliente"
        Me.Aproba_cliente.ReadOnly = True
        Me.Aproba_cliente.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Aproba_cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Aproba_cliente.Visible = False
        Me.Aproba_cliente.Width = 59
        '
        'id
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.id.DefaultCellStyle = DataGridViewCellStyle1
        Me.id.HeaderText = "Nro. Op"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 69
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 45
        '
        'codigo_obra
        '
        Me.codigo_obra.HeaderText = "Cod. Obra"
        Me.codigo_obra.Name = "codigo_obra"
        Me.codigo_obra.ReadOnly = True
        Me.codigo_obra.Width = 80
        '
        'Obra
        '
        Me.Obra.HeaderText = "Obra"
        Me.Obra.Name = "Obra"
        Me.Obra.ReadOnly = True
        Me.Obra.Width = 55
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.Width = 64
        '
        'telefono_cliente
        '
        Me.telefono_cliente.HeaderText = "Tel. Cliente"
        Me.telefono_cliente.Name = "telefono_cliente"
        Me.telefono_cliente.ReadOnly = True
        Me.telefono_cliente.Visible = False
        Me.telefono_cliente.Width = 85
        '
        'idContrato
        '
        Me.idContrato.HeaderText = "Nro. Contrato"
        Me.idContrato.Name = "idContrato"
        Me.idContrato.ReadOnly = True
        Me.idContrato.Visible = False
        Me.idContrato.Width = 95
        '
        'direccion_cliente
        '
        Me.direccion_cliente.HeaderText = "Dir. Cliente"
        Me.direccion_cliente.Name = "direccion_cliente"
        Me.direccion_cliente.ReadOnly = True
        Me.direccion_cliente.Visible = False
        Me.direccion_cliente.Width = 83
        '
        'telefono_obra
        '
        Me.telefono_obra.HeaderText = "Tel. Obra"
        Me.telefono_obra.Name = "telefono_obra"
        Me.telefono_obra.ReadOnly = True
        Me.telefono_obra.Visible = False
        Me.telefono_obra.Width = 76
        '
        'direccion_obra
        '
        Me.direccion_obra.HeaderText = "Dir. Obra"
        Me.direccion_obra.Name = "direccion_obra"
        Me.direccion_obra.ReadOnly = True
        Me.direccion_obra.Visible = False
        Me.direccion_obra.Width = 74
        '
        'ciudad_obra
        '
        Me.ciudad_obra.HeaderText = "Ciudad Obra"
        Me.ciudad_obra.Name = "ciudad_obra"
        Me.ciudad_obra.ReadOnly = True
        Me.ciudad_obra.Width = 91
        '
        'tiempo_entrega
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        Me.tiempo_entrega.DefaultCellStyle = DataGridViewCellStyle2
        Me.tiempo_entrega.HeaderText = "Plazo Entrega"
        Me.tiempo_entrega.Name = "tiempo_entrega"
        Me.tiempo_entrega.ReadOnly = True
        Me.tiempo_entrega.Width = 98
        '
        'FechaEntrega
        '
        Me.FechaEntrega.HeaderText = "Fecha entrega"
        Me.FechaEntrega.Name = "FechaEntrega"
        Me.FechaEntrega.ReadOnly = True
        Me.FechaEntrega.Width = 101
        '
        'SemanaEntrega
        '
        Me.SemanaEntrega.HeaderText = "Semana Entrega"
        Me.SemanaEntrega.Name = "SemanaEntrega"
        Me.SemanaEntrega.ReadOnly = True
        Me.SemanaEntrega.Visible = False
        Me.SemanaEntrega.Width = 111
        '
        'Puntos
        '
        Me.Puntos.HeaderText = "Puntos"
        Me.Puntos.Name = "Puntos"
        Me.Puntos.ReadOnly = True
        Me.Puntos.Visible = False
        Me.Puntos.Width = 65
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "Vendedor"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Visible = False
        Me.idVendedor.Width = 78
        '
        'Zona
        '
        Me.Zona.HeaderText = "Zona"
        Me.Zona.Name = "Zona"
        Me.Zona.ReadOnly = True
        Me.Zona.Visible = False
        Me.Zona.Width = 57
        '
        'Metros
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N2"
        Me.Metros.DefaultCellStyle = DataGridViewCellStyle3
        Me.Metros.HeaderText = "Metros"
        Me.Metros.Name = "Metros"
        Me.Metros.ReadOnly = True
        Me.Metros.Width = 64
        '
        'UbicacionVentanas
        '
        Me.UbicacionVentanas.HeaderText = "Ubic. Ventanas"
        Me.UbicacionVentanas.Name = "UbicacionVentanas"
        Me.UbicacionVentanas.ReadOnly = True
        Me.UbicacionVentanas.Visible = False
        Me.UbicacionVentanas.Width = 105
        '
        'idTerceroProd
        '
        Me.idTerceroProd.HeaderText = "id Terc. Produccion"
        Me.idTerceroProd.Name = "idTerceroProd"
        Me.idTerceroProd.ReadOnly = True
        Me.idTerceroProd.Visible = False
        Me.idTerceroProd.Width = 125
        '
        'TerceroProduccion
        '
        Me.TerceroProduccion.HeaderText = "Terc. Producción"
        Me.TerceroProduccion.Name = "TerceroProduccion"
        Me.TerceroProduccion.ReadOnly = True
        Me.TerceroProduccion.Width = 105
        '
        'DirTercero
        '
        Me.DirTercero.HeaderText = "Dir Tercero Prod."
        Me.DirTercero.Name = "DirTercero"
        Me.DirTercero.ReadOnly = True
        Me.DirTercero.Visible = False
        Me.DirTercero.Width = 104
        '
        'telTercero
        '
        Me.telTercero.HeaderText = "Tel. Terc. Prod"
        Me.telTercero.Name = "telTercero"
        Me.telTercero.ReadOnly = True
        Me.telTercero.Visible = False
        Me.telTercero.Width = 95
        '
        'nroDevoluciones
        '
        Me.nroDevoluciones.HeaderText = "Nro. Devoluciones."
        Me.nroDevoluciones.Name = "nroDevoluciones"
        Me.nroDevoluciones.ReadOnly = True
        Me.nroDevoluciones.Visible = False
        Me.nroDevoluciones.Width = 113
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha Creacion"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.Width = 98
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.Width = 104
        '
        'FechaModi
        '
        Me.FechaModi.HeaderText = "Fecha Modificación"
        Me.FechaModi.Name = "FechaModi"
        Me.FechaModi.ReadOnly = True
        Me.FechaModi.Visible = False
        Me.FechaModi.Width = 114
        '
        'UsuarioModi
        '
        Me.UsuarioModi.HeaderText = "Usuario Modificación"
        Me.UsuarioModi.Name = "UsuarioModi"
        Me.UsuarioModi.ReadOnly = True
        Me.UsuarioModi.Visible = False
        Me.UsuarioModi.Width = 120
        '
        'UsuarioAprobacion
        '
        Me.UsuarioAprobacion.HeaderText = "Usuario Aprobación"
        Me.UsuarioAprobacion.Name = "UsuarioAprobacion"
        Me.UsuarioAprobacion.ReadOnly = True
        Me.UsuarioAprobacion.Visible = False
        Me.UsuarioAprobacion.Width = 114
        '
        'FechaAprobacion
        '
        Me.FechaAprobacion.HeaderText = "Fecha Aprobación"
        Me.FechaAprobacion.Name = "FechaAprobacion"
        Me.FechaAprobacion.ReadOnly = True
        Me.FechaAprobacion.Visible = False
        Me.FechaAprobacion.Width = 109
        '
        'UsuarioAnulacion
        '
        Me.UsuarioAnulacion.HeaderText = "Usuario Anulación"
        Me.UsuarioAnulacion.Name = "UsuarioAnulacion"
        Me.UsuarioAnulacion.ReadOnly = True
        Me.UsuarioAnulacion.Visible = False
        Me.UsuarioAnulacion.Width = 108
        '
        'FechaAnulacion
        '
        Me.FechaAnulacion.HeaderText = "Fecha Anulación"
        Me.FechaAnulacion.Name = "FechaAnulacion"
        Me.FechaAnulacion.ReadOnly = True
        Me.FechaAnulacion.Visible = False
        Me.FechaAnulacion.Width = 103
        '
        'Idestado
        '
        Me.Idestado.HeaderText = "Id Estado"
        Me.Idestado.Name = "Idestado"
        Me.Idestado.ReadOnly = True
        Me.Idestado.Visible = False
        Me.Idestado.Width = 71
        '
        'FrmListarOrdenesPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 422)
        Me.Controls.Add(Me.scgeneral)
        Me.Name = "FrmListarOrdenesPedido"
        Me.ShowIcon = False
        Me.Text = "Ordenes Pedido"
        Me.scgeneral.Panel1.ResumeLayout(False)
        Me.scgeneral.Panel2.ResumeLayout(False)
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgeneral.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents scgeneral As SplitContainer
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As DataGridViewTextBoxColumn
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Aproba_cliente As DataGridViewTextBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents codigo_obra As DataGridViewTextBoxColumn
    Friend WithEvents Obra As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents telefono_cliente As DataGridViewTextBoxColumn
    Friend WithEvents idContrato As DataGridViewTextBoxColumn
    Friend WithEvents direccion_cliente As DataGridViewTextBoxColumn
    Friend WithEvents telefono_obra As DataGridViewTextBoxColumn
    Friend WithEvents direccion_obra As DataGridViewTextBoxColumn
    Friend WithEvents ciudad_obra As DataGridViewTextBoxColumn
    Friend WithEvents tiempo_entrega As DataGridViewTextBoxColumn
    Friend WithEvents FechaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents SemanaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents Puntos As DataGridViewTextBoxColumn
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents Zona As DataGridViewTextBoxColumn
    Friend WithEvents Metros As DataGridViewTextBoxColumn
    Friend WithEvents UbicacionVentanas As DataGridViewTextBoxColumn
    Friend WithEvents idTerceroProd As DataGridViewTextBoxColumn
    Friend WithEvents TerceroProduccion As DataGridViewTextBoxColumn
    Friend WithEvents DirTercero As DataGridViewTextBoxColumn
    Friend WithEvents telTercero As DataGridViewTextBoxColumn
    Friend WithEvents nroDevoluciones As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaModi As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioAprobacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaAprobacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents Idestado As DataGridViewTextBoxColumn
End Class
