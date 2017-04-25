<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVerCotizaciones
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
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.tabListas = New System.Windows.Forms.TabPage()
        Me.spcListas = New System.Windows.Forms.SplitContainer()
        Me.tabRechazadas = New System.Windows.Forms.TabPage()
        Me.spcRechazadas = New System.Windows.Forms.SplitContainer()
        Me.fddRechazadas = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwRechazadas = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.rec_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idAprobacionCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_aprobacioncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_numIdentificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_nombreObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_nombreCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_fechaCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_NombreCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_nombreAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_idTipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_TipoCotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_AIU_administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_AIU_improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rec_AIU_utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabArchivadas = New System.Windows.Forms.TabPage()
        Me.spcArchivadas = New System.Windows.Forms.SplitContainer()
        Me.fddArchivadas = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwArchivadas = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.arc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idaprobacioncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_aprobacioncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_numIdentificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_nombreObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_nombreCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_fechaCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_NombreCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_nombreAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_idtipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_tipoCotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.arc_AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idaprobacioncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aprobacioncliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numIdentificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl.SuspendLayout()
        Me.tabListas.SuspendLayout()
        CType(Me.spcListas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcListas.Panel1.SuspendLayout()
        Me.spcListas.Panel2.SuspendLayout()
        Me.spcListas.SuspendLayout()
        Me.tabRechazadas.SuspendLayout()
        CType(Me.spcRechazadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcRechazadas.Panel1.SuspendLayout()
        Me.spcRechazadas.Panel2.SuspendLayout()
        Me.spcRechazadas.SuspendLayout()
        CType(Me.dwRechazadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArchivadas.SuspendLayout()
        CType(Me.spcArchivadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcArchivadas.Panel1.SuspendLayout()
        Me.spcArchivadas.Panel2.SuspendLayout()
        Me.spcArchivadas.SuspendLayout()
        CType(Me.dwArchivadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(874, 90)
        Me.fddFiltrado.TabIndex = 0
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AutoGenerateColumns = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion, Me.id, Me.idEstado, Me.estado, Me.idaprobacioncliente, Me.aprobacioncliente, Me.fechaCreacion, Me.usuarioCreacion, Me.idTipoDocumento, Me.numIdentificacion, Me.cliente, Me.nombreObra, Me.nombreCotiza, Me.fechaCotiza, Me.idCiudad, Me.NombreCiudad, Me.idAcabado, Me.nombreAcabado, Me.idtipoCotiza, Me.TipoCotizacion, Me.AIU_Administracion, Me.AIU_Improvistos, Me.AIU_Utilidad})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 25
        Me.dwItem.Size = New System.Drawing.Size(874, 286)
        Me.dwItem.TabIndex = 0
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'bwcargas
        '
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.tabListas)
        Me.TabControl.Controls.Add(Me.tabRechazadas)
        Me.TabControl.Controls.Add(Me.tabArchivadas)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(892, 420)
        Me.TabControl.TabIndex = 1
        '
        'tabListas
        '
        Me.tabListas.BackColor = System.Drawing.SystemColors.Control
        Me.tabListas.Controls.Add(Me.spcListas)
        Me.tabListas.Location = New System.Drawing.Point(4, 22)
        Me.tabListas.Name = "tabListas"
        Me.tabListas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListas.Size = New System.Drawing.Size(884, 394)
        Me.tabListas.TabIndex = 0
        Me.tabListas.Text = "Lista cotizaciones"
        '
        'spcListas
        '
        Me.spcListas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcListas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcListas.Location = New System.Drawing.Point(3, 3)
        Me.spcListas.Name = "spcListas"
        Me.spcListas.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcListas.Panel1
        '
        Me.spcListas.Panel1.Controls.Add(Me.fddFiltrado)
        '
        'spcListas.Panel2
        '
        Me.spcListas.Panel2.Controls.Add(Me.dwItem)
        Me.spcListas.Size = New System.Drawing.Size(878, 388)
        Me.spcListas.SplitterDistance = 94
        Me.spcListas.TabIndex = 1
        '
        'tabRechazadas
        '
        Me.tabRechazadas.BackColor = System.Drawing.SystemColors.Control
        Me.tabRechazadas.Controls.Add(Me.spcRechazadas)
        Me.tabRechazadas.Location = New System.Drawing.Point(4, 22)
        Me.tabRechazadas.Name = "tabRechazadas"
        Me.tabRechazadas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabRechazadas.Size = New System.Drawing.Size(884, 394)
        Me.tabRechazadas.TabIndex = 1
        Me.tabRechazadas.Text = "Rechazadas"
        '
        'spcRechazadas
        '
        Me.spcRechazadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcRechazadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcRechazadas.Location = New System.Drawing.Point(3, 3)
        Me.spcRechazadas.Name = "spcRechazadas"
        Me.spcRechazadas.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcRechazadas.Panel1
        '
        Me.spcRechazadas.Panel1.Controls.Add(Me.fddRechazadas)
        '
        'spcRechazadas.Panel2
        '
        Me.spcRechazadas.Panel2.Controls.Add(Me.dwRechazadas)
        Me.spcRechazadas.Size = New System.Drawing.Size(878, 388)
        Me.spcRechazadas.SplitterDistance = 96
        Me.spcRechazadas.TabIndex = 0
        '
        'fddRechazadas
        '
        Me.fddRechazadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddRechazadas.Grid = Me.dwRechazadas
        Me.fddRechazadas.Location = New System.Drawing.Point(0, 0)
        Me.fddRechazadas.Name = "fddRechazadas"
        Me.fddRechazadas.Size = New System.Drawing.Size(874, 92)
        Me.fddRechazadas.TabIndex = 1
        '
        'dwRechazadas
        '
        Me.dwRechazadas.AllowUserToAddRows = False
        Me.dwRechazadas.AllowUserToDeleteRows = False
        Me.dwRechazadas.AutoGenerateColumns = False
        Me.dwRechazadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwRechazadas.BackgroundColor = System.Drawing.Color.White
        Me.dwRechazadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwRechazadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.rec_id, Me.rec_idEstado, Me.rec_estado, Me.rec_idAprobacionCliente, Me.rec_aprobacioncliente, Me.rec_fechaCreacion, Me.rec_usuarioCreacion, Me.rec_idTipoDocumento, Me.rec_numIdentificacion, Me.rec_cliente, Me.rec_nombreObra, Me.rec_nombreCotiza, Me.rec_fechaCotiza, Me.rec_idCiudad, Me.rec_NombreCiudad, Me.rec_idAcabado, Me.rec_nombreAcabado, Me.rec_idTipoCotiza, Me.rec_TipoCotizacion, Me.rec_AIU_administracion, Me.rec_AIU_improvistos, Me.rec_AIU_utilidad})
        Me.dwRechazadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwRechazadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwRechazadas.ImageList = Nothing
        Me.dwRechazadas.Location = New System.Drawing.Point(0, 0)
        Me.dwRechazadas.MostrarFiltros = True
        Me.dwRechazadas.Name = "dwRechazadas"
        Me.dwRechazadas.RowHeadersWidth = 25
        Me.dwRechazadas.Size = New System.Drawing.Size(874, 284)
        Me.dwRechazadas.TabIndex = 1
        Me.dwRechazadas.TablaDatos = Nothing
        Me.dwRechazadas.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'rec_id
        '
        Me.rec_id.HeaderText = "Id"
        Me.rec_id.Name = "rec_id"
        Me.rec_id.ReadOnly = True
        Me.rec_id.Width = 41
        '
        'rec_idEstado
        '
        Me.rec_idEstado.HeaderText = "Id estado"
        Me.rec_idEstado.Name = "rec_idEstado"
        Me.rec_idEstado.ReadOnly = True
        Me.rec_idEstado.Visible = False
        Me.rec_idEstado.Width = 76
        '
        'rec_estado
        '
        Me.rec_estado.HeaderText = "Estado"
        Me.rec_estado.Name = "rec_estado"
        Me.rec_estado.ReadOnly = True
        Me.rec_estado.Width = 65
        '
        'rec_idAprobacionCliente
        '
        Me.rec_idAprobacionCliente.HeaderText = "Estado aprobación cliente"
        Me.rec_idAprobacionCliente.Name = "rec_idAprobacionCliente"
        Me.rec_idAprobacionCliente.ReadOnly = True
        Me.rec_idAprobacionCliente.Visible = False
        Me.rec_idAprobacionCliente.Width = 155
        '
        'rec_aprobacioncliente
        '
        Me.rec_aprobacioncliente.HeaderText = "Estado aprobación cliente"
        Me.rec_aprobacioncliente.Name = "rec_aprobacioncliente"
        Me.rec_aprobacioncliente.ReadOnly = True
        Me.rec_aprobacioncliente.Width = 155
        '
        'rec_fechaCreacion
        '
        Me.rec_fechaCreacion.HeaderText = "Fecha creación"
        Me.rec_fechaCreacion.Name = "rec_fechaCreacion"
        Me.rec_fechaCreacion.ReadOnly = True
        Me.rec_fechaCreacion.Visible = False
        Me.rec_fechaCreacion.Width = 106
        '
        'rec_usuarioCreacion
        '
        Me.rec_usuarioCreacion.HeaderText = "Usuario creación"
        Me.rec_usuarioCreacion.Name = "rec_usuarioCreacion"
        Me.rec_usuarioCreacion.ReadOnly = True
        Me.rec_usuarioCreacion.Visible = False
        Me.rec_usuarioCreacion.Width = 112
        '
        'rec_idTipoDocumento
        '
        Me.rec_idTipoDocumento.HeaderText = "Id tipo documento"
        Me.rec_idTipoDocumento.Name = "rec_idTipoDocumento"
        Me.rec_idTipoDocumento.ReadOnly = True
        Me.rec_idTipoDocumento.Visible = False
        Me.rec_idTipoDocumento.Width = 117
        '
        'rec_numIdentificacion
        '
        Me.rec_numIdentificacion.HeaderText = "Documento"
        Me.rec_numIdentificacion.Name = "rec_numIdentificacion"
        Me.rec_numIdentificacion.ReadOnly = True
        Me.rec_numIdentificacion.Width = 87
        '
        'rec_cliente
        '
        Me.rec_cliente.HeaderText = "Constructora"
        Me.rec_cliente.Name = "rec_cliente"
        Me.rec_cliente.ReadOnly = True
        Me.rec_cliente.Width = 92
        '
        'rec_nombreObra
        '
        Me.rec_nombreObra.HeaderText = "Obra"
        Me.rec_nombreObra.Name = "rec_nombreObra"
        Me.rec_nombreObra.ReadOnly = True
        Me.rec_nombreObra.Width = 55
        '
        'rec_nombreCotiza
        '
        Me.rec_nombreCotiza.HeaderText = "Nombre personalizado"
        Me.rec_nombreCotiza.Name = "rec_nombreCotiza"
        Me.rec_nombreCotiza.ReadOnly = True
        Me.rec_nombreCotiza.Width = 137
        '
        'rec_fechaCotiza
        '
        Me.rec_fechaCotiza.HeaderText = "Fecha cotización"
        Me.rec_fechaCotiza.Name = "rec_fechaCotiza"
        Me.rec_fechaCotiza.ReadOnly = True
        Me.rec_fechaCotiza.Width = 113
        '
        'rec_idCiudad
        '
        Me.rec_idCiudad.HeaderText = "Id ciudad"
        Me.rec_idCiudad.Name = "rec_idCiudad"
        Me.rec_idCiudad.ReadOnly = True
        Me.rec_idCiudad.Visible = False
        Me.rec_idCiudad.Width = 76
        '
        'rec_NombreCiudad
        '
        Me.rec_NombreCiudad.HeaderText = "Ciudad"
        Me.rec_NombreCiudad.Name = "rec_NombreCiudad"
        Me.rec_NombreCiudad.ReadOnly = True
        Me.rec_NombreCiudad.Width = 65
        '
        'rec_idAcabado
        '
        Me.rec_idAcabado.HeaderText = "Id acabado"
        Me.rec_idAcabado.Name = "rec_idAcabado"
        Me.rec_idAcabado.ReadOnly = True
        Me.rec_idAcabado.Visible = False
        Me.rec_idAcabado.Width = 86
        '
        'rec_nombreAcabado
        '
        Me.rec_nombreAcabado.HeaderText = "Acabado"
        Me.rec_nombreAcabado.Name = "rec_nombreAcabado"
        Me.rec_nombreAcabado.ReadOnly = True
        Me.rec_nombreAcabado.Width = 75
        '
        'rec_idTipoCotiza
        '
        Me.rec_idTipoCotiza.HeaderText = "Id tipo cotiza"
        Me.rec_idTipoCotiza.Name = "rec_idTipoCotiza"
        Me.rec_idTipoCotiza.ReadOnly = True
        Me.rec_idTipoCotiza.Visible = False
        Me.rec_idTipoCotiza.Width = 92
        '
        'rec_TipoCotizacion
        '
        Me.rec_TipoCotizacion.HeaderText = "Tipo cotización"
        Me.rec_TipoCotizacion.Name = "rec_TipoCotizacion"
        Me.rec_TipoCotizacion.ReadOnly = True
        Me.rec_TipoCotizacion.Width = 104
        '
        'rec_AIU_administracion
        '
        Me.rec_AIU_administracion.HeaderText = "AIU administración"
        Me.rec_AIU_administracion.Name = "rec_AIU_administracion"
        Me.rec_AIU_administracion.ReadOnly = True
        Me.rec_AIU_administracion.Width = 120
        '
        'rec_AIU_improvistos
        '
        Me.rec_AIU_improvistos.HeaderText = "AIU improvistos"
        Me.rec_AIU_improvistos.Name = "rec_AIU_improvistos"
        Me.rec_AIU_improvistos.ReadOnly = True
        Me.rec_AIU_improvistos.Width = 105
        '
        'rec_AIU_utilidad
        '
        Me.rec_AIU_utilidad.HeaderText = "AIU utilidad"
        Me.rec_AIU_utilidad.Name = "rec_AIU_utilidad"
        Me.rec_AIU_utilidad.ReadOnly = True
        Me.rec_AIU_utilidad.Width = 86
        '
        'tabArchivadas
        '
        Me.tabArchivadas.BackColor = System.Drawing.SystemColors.Control
        Me.tabArchivadas.Controls.Add(Me.spcArchivadas)
        Me.tabArchivadas.Location = New System.Drawing.Point(4, 22)
        Me.tabArchivadas.Name = "tabArchivadas"
        Me.tabArchivadas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabArchivadas.Size = New System.Drawing.Size(884, 394)
        Me.tabArchivadas.TabIndex = 2
        Me.tabArchivadas.Text = "Archivadas"
        '
        'spcArchivadas
        '
        Me.spcArchivadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spcArchivadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcArchivadas.Location = New System.Drawing.Point(3, 3)
        Me.spcArchivadas.Name = "spcArchivadas"
        Me.spcArchivadas.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcArchivadas.Panel1
        '
        Me.spcArchivadas.Panel1.Controls.Add(Me.fddArchivadas)
        Me.spcArchivadas.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'spcArchivadas.Panel2
        '
        Me.spcArchivadas.Panel2.Controls.Add(Me.dwArchivadas)
        Me.spcArchivadas.Size = New System.Drawing.Size(878, 388)
        Me.spcArchivadas.SplitterDistance = 96
        Me.spcArchivadas.TabIndex = 1
        '
        'fddArchivadas
        '
        Me.fddArchivadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddArchivadas.Grid = Me.dwArchivadas
        Me.fddArchivadas.Location = New System.Drawing.Point(0, 0)
        Me.fddArchivadas.Name = "fddArchivadas"
        Me.fddArchivadas.Size = New System.Drawing.Size(874, 92)
        Me.fddArchivadas.TabIndex = 1
        '
        'dwArchivadas
        '
        Me.dwArchivadas.AllowUserToAddRows = False
        Me.dwArchivadas.AllowUserToDeleteRows = False
        Me.dwArchivadas.AutoGenerateColumns = False
        Me.dwArchivadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwArchivadas.BackgroundColor = System.Drawing.Color.White
        Me.dwArchivadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwArchivadas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.arc_id, Me.arc_idEstado, Me.arc_estado, Me.arc_idaprobacioncliente, Me.arc_aprobacioncliente, Me.arc_fechaCreacion, Me.arc_usuarioCreacion, Me.arc_idTipoDocumento, Me.arc_numIdentificacion, Me.arc_cliente, Me.arc_nombreObra, Me.arc_nombreCotiza, Me.arc_fechaCotiza, Me.arc_idCiudad, Me.arc_NombreCiudad, Me.arc_idAcabado, Me.arc_nombreAcabado, Me.arc_idtipoCotiza, Me.arc_tipoCotizacion, Me.arc_AIU_Administracion, Me.arc_AIU_Improvistos, Me.arc_AIU_Utilidad})
        Me.dwArchivadas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwArchivadas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwArchivadas.ImageList = Nothing
        Me.dwArchivadas.Location = New System.Drawing.Point(0, 0)
        Me.dwArchivadas.MostrarFiltros = True
        Me.dwArchivadas.Name = "dwArchivadas"
        Me.dwArchivadas.RowHeadersWidth = 25
        Me.dwArchivadas.Size = New System.Drawing.Size(874, 284)
        Me.dwArchivadas.TabIndex = 1
        Me.dwArchivadas.TablaDatos = Nothing
        Me.dwArchivadas.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'arc_id
        '
        Me.arc_id.HeaderText = "Id"
        Me.arc_id.Name = "arc_id"
        Me.arc_id.ReadOnly = True
        Me.arc_id.Width = 41
        '
        'arc_idEstado
        '
        Me.arc_idEstado.HeaderText = "Id estado"
        Me.arc_idEstado.Name = "arc_idEstado"
        Me.arc_idEstado.ReadOnly = True
        Me.arc_idEstado.Visible = False
        Me.arc_idEstado.Width = 76
        '
        'arc_estado
        '
        Me.arc_estado.HeaderText = "Estado"
        Me.arc_estado.Name = "arc_estado"
        Me.arc_estado.ReadOnly = True
        Me.arc_estado.Width = 65
        '
        'arc_idaprobacioncliente
        '
        Me.arc_idaprobacioncliente.HeaderText = "Id aprobacion"
        Me.arc_idaprobacioncliente.Name = "arc_idaprobacioncliente"
        Me.arc_idaprobacioncliente.ReadOnly = True
        Me.arc_idaprobacioncliente.Visible = False
        Me.arc_idaprobacioncliente.Width = 97
        '
        'arc_aprobacioncliente
        '
        Me.arc_aprobacioncliente.HeaderText = "Estado aprobación cliente"
        Me.arc_aprobacioncliente.Name = "arc_aprobacioncliente"
        Me.arc_aprobacioncliente.ReadOnly = True
        Me.arc_aprobacioncliente.Width = 155
        '
        'arc_fechaCreacion
        '
        Me.arc_fechaCreacion.HeaderText = "Fecha creación"
        Me.arc_fechaCreacion.Name = "arc_fechaCreacion"
        Me.arc_fechaCreacion.ReadOnly = True
        Me.arc_fechaCreacion.Visible = False
        Me.arc_fechaCreacion.Width = 106
        '
        'arc_usuarioCreacion
        '
        Me.arc_usuarioCreacion.HeaderText = "Usuario creación"
        Me.arc_usuarioCreacion.Name = "arc_usuarioCreacion"
        Me.arc_usuarioCreacion.ReadOnly = True
        Me.arc_usuarioCreacion.Visible = False
        Me.arc_usuarioCreacion.Width = 112
        '
        'arc_idTipoDocumento
        '
        Me.arc_idTipoDocumento.HeaderText = "Id tipo documento"
        Me.arc_idTipoDocumento.Name = "arc_idTipoDocumento"
        Me.arc_idTipoDocumento.ReadOnly = True
        Me.arc_idTipoDocumento.Visible = False
        Me.arc_idTipoDocumento.Width = 117
        '
        'arc_numIdentificacion
        '
        Me.arc_numIdentificacion.HeaderText = "Documento"
        Me.arc_numIdentificacion.Name = "arc_numIdentificacion"
        Me.arc_numIdentificacion.ReadOnly = True
        Me.arc_numIdentificacion.Width = 87
        '
        'arc_cliente
        '
        Me.arc_cliente.HeaderText = "Constructora"
        Me.arc_cliente.Name = "arc_cliente"
        Me.arc_cliente.ReadOnly = True
        Me.arc_cliente.Width = 92
        '
        'arc_nombreObra
        '
        Me.arc_nombreObra.HeaderText = "Obra"
        Me.arc_nombreObra.Name = "arc_nombreObra"
        Me.arc_nombreObra.ReadOnly = True
        Me.arc_nombreObra.Width = 55
        '
        'arc_nombreCotiza
        '
        Me.arc_nombreCotiza.HeaderText = "Nombre personalizado"
        Me.arc_nombreCotiza.Name = "arc_nombreCotiza"
        Me.arc_nombreCotiza.ReadOnly = True
        Me.arc_nombreCotiza.Width = 137
        '
        'arc_fechaCotiza
        '
        Me.arc_fechaCotiza.HeaderText = "Fecha cotizacion"
        Me.arc_fechaCotiza.Name = "arc_fechaCotiza"
        Me.arc_fechaCotiza.ReadOnly = True
        Me.arc_fechaCotiza.Width = 113
        '
        'arc_idCiudad
        '
        Me.arc_idCiudad.HeaderText = "Id ciudad"
        Me.arc_idCiudad.Name = "arc_idCiudad"
        Me.arc_idCiudad.ReadOnly = True
        Me.arc_idCiudad.Visible = False
        Me.arc_idCiudad.Width = 76
        '
        'arc_NombreCiudad
        '
        Me.arc_NombreCiudad.HeaderText = "Ciudad"
        Me.arc_NombreCiudad.Name = "arc_NombreCiudad"
        Me.arc_NombreCiudad.ReadOnly = True
        Me.arc_NombreCiudad.Width = 65
        '
        'arc_idAcabado
        '
        Me.arc_idAcabado.HeaderText = "Id acabado"
        Me.arc_idAcabado.Name = "arc_idAcabado"
        Me.arc_idAcabado.ReadOnly = True
        Me.arc_idAcabado.Visible = False
        Me.arc_idAcabado.Width = 86
        '
        'arc_nombreAcabado
        '
        Me.arc_nombreAcabado.HeaderText = "Acabado"
        Me.arc_nombreAcabado.Name = "arc_nombreAcabado"
        Me.arc_nombreAcabado.ReadOnly = True
        Me.arc_nombreAcabado.Width = 75
        '
        'arc_idtipoCotiza
        '
        Me.arc_idtipoCotiza.HeaderText = "Id tipo cotización"
        Me.arc_idtipoCotiza.Name = "arc_idtipoCotiza"
        Me.arc_idtipoCotiza.ReadOnly = True
        Me.arc_idtipoCotiza.Visible = False
        Me.arc_idtipoCotiza.Width = 112
        '
        'arc_tipoCotizacion
        '
        Me.arc_tipoCotizacion.HeaderText = "Tipo cotización"
        Me.arc_tipoCotizacion.Name = "arc_tipoCotizacion"
        Me.arc_tipoCotizacion.ReadOnly = True
        Me.arc_tipoCotizacion.Width = 104
        '
        'arc_AIU_Administracion
        '
        Me.arc_AIU_Administracion.HeaderText = "AIU administración"
        Me.arc_AIU_Administracion.Name = "arc_AIU_Administracion"
        Me.arc_AIU_Administracion.ReadOnly = True
        Me.arc_AIU_Administracion.Width = 120
        '
        'arc_AIU_Improvistos
        '
        Me.arc_AIU_Improvistos.HeaderText = "AIU improvistos"
        Me.arc_AIU_Improvistos.Name = "arc_AIU_Improvistos"
        Me.arc_AIU_Improvistos.ReadOnly = True
        Me.arc_AIU_Improvistos.Width = 105
        '
        'arc_AIU_Utilidad
        '
        Me.arc_AIU_Utilidad.HeaderText = "AIU utilidad"
        Me.arc_AIU_Utilidad.Name = "arc_AIU_Utilidad"
        Me.arc_AIU_Utilidad.ReadOnly = True
        Me.arc_AIU_Utilidad.Width = 86
        '
        'seleccion
        '
        Me.seleccion.HeaderText = "Selección"
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Width = 60
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 41
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 76
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'idaprobacioncliente
        '
        Me.idaprobacioncliente.HeaderText = "Id aprobación cliente"
        Me.idaprobacioncliente.Name = "idaprobacioncliente"
        Me.idaprobacioncliente.ReadOnly = True
        Me.idaprobacioncliente.Visible = False
        Me.idaprobacioncliente.Width = 131
        '
        'aprobacioncliente
        '
        Me.aprobacioncliente.HeaderText = "Estado aprobación cliente"
        Me.aprobacioncliente.Name = "aprobacioncliente"
        Me.aprobacioncliente.ReadOnly = True
        Me.aprobacioncliente.Width = 155
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
        'idTipoDocumento
        '
        Me.idTipoDocumento.HeaderText = "Id tipo documento"
        Me.idTipoDocumento.Name = "idTipoDocumento"
        Me.idTipoDocumento.ReadOnly = True
        Me.idTipoDocumento.Visible = False
        Me.idTipoDocumento.Width = 117
        '
        'numIdentificacion
        '
        Me.numIdentificacion.HeaderText = "Documento"
        Me.numIdentificacion.Name = "numIdentificacion"
        Me.numIdentificacion.ReadOnly = True
        Me.numIdentificacion.Width = 87
        '
        'cliente
        '
        Me.cliente.HeaderText = "Constructora"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 92
        '
        'nombreObra
        '
        Me.nombreObra.HeaderText = "Obra"
        Me.nombreObra.Name = "nombreObra"
        Me.nombreObra.ReadOnly = True
        Me.nombreObra.Width = 55
        '
        'nombreCotiza
        '
        Me.nombreCotiza.HeaderText = "Nombre personalizado"
        Me.nombreCotiza.Name = "nombreCotiza"
        Me.nombreCotiza.ReadOnly = True
        Me.nombreCotiza.Width = 137
        '
        'fechaCotiza
        '
        Me.fechaCotiza.HeaderText = "Fecha cotización"
        Me.fechaCotiza.Name = "fechaCotiza"
        Me.fechaCotiza.ReadOnly = True
        Me.fechaCotiza.Width = 113
        '
        'idCiudad
        '
        Me.idCiudad.HeaderText = "Id ciudad"
        Me.idCiudad.Name = "idCiudad"
        Me.idCiudad.ReadOnly = True
        Me.idCiudad.Visible = False
        Me.idCiudad.Width = 76
        '
        'NombreCiudad
        '
        Me.NombreCiudad.HeaderText = "Ciudad"
        Me.NombreCiudad.Name = "NombreCiudad"
        Me.NombreCiudad.ReadOnly = True
        Me.NombreCiudad.Width = 65
        '
        'idAcabado
        '
        Me.idAcabado.HeaderText = "Id acabado"
        Me.idAcabado.Name = "idAcabado"
        Me.idAcabado.ReadOnly = True
        Me.idAcabado.Visible = False
        Me.idAcabado.Width = 86
        '
        'nombreAcabado
        '
        Me.nombreAcabado.HeaderText = "Acabado"
        Me.nombreAcabado.Name = "nombreAcabado"
        Me.nombreAcabado.ReadOnly = True
        Me.nombreAcabado.Width = 75
        '
        'idtipoCotiza
        '
        Me.idtipoCotiza.HeaderText = "Id tipo cotización"
        Me.idtipoCotiza.Name = "idtipoCotiza"
        Me.idtipoCotiza.ReadOnly = True
        Me.idtipoCotiza.Visible = False
        Me.idtipoCotiza.Width = 112
        '
        'TipoCotizacion
        '
        Me.TipoCotizacion.HeaderText = "Tipo cotización"
        Me.TipoCotizacion.Name = "TipoCotizacion"
        Me.TipoCotizacion.ReadOnly = True
        Me.TipoCotizacion.Width = 104
        '
        'AIU_Administracion
        '
        Me.AIU_Administracion.HeaderText = "AIU administración"
        Me.AIU_Administracion.Name = "AIU_Administracion"
        Me.AIU_Administracion.ReadOnly = True
        Me.AIU_Administracion.Width = 120
        '
        'AIU_Improvistos
        '
        Me.AIU_Improvistos.HeaderText = "AIU improvistos"
        Me.AIU_Improvistos.Name = "AIU_Improvistos"
        Me.AIU_Improvistos.ReadOnly = True
        Me.AIU_Improvistos.Width = 105
        '
        'AIU_Utilidad
        '
        Me.AIU_Utilidad.HeaderText = "AIU utilidad"
        Me.AIU_Utilidad.Name = "AIU_Utilidad"
        Me.AIU_Utilidad.ReadOnly = True
        Me.AIU_Utilidad.Width = 86
        '
        'FrmVerCotizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 420)
        Me.Controls.Add(Me.TabControl)
        Me.Name = "FrmVerCotizaciones"
        Me.ShowIcon = False
        Me.Text = "Ver cotizaciones"
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl.ResumeLayout(False)
        Me.tabListas.ResumeLayout(False)
        Me.spcListas.Panel1.ResumeLayout(False)
        Me.spcListas.Panel2.ResumeLayout(False)
        CType(Me.spcListas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcListas.ResumeLayout(False)
        Me.tabRechazadas.ResumeLayout(False)
        Me.spcRechazadas.Panel1.ResumeLayout(False)
        Me.spcRechazadas.Panel2.ResumeLayout(False)
        CType(Me.spcRechazadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcRechazadas.ResumeLayout(False)
        CType(Me.dwRechazadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArchivadas.ResumeLayout(False)
        Me.spcArchivadas.Panel1.ResumeLayout(False)
        Me.spcArchivadas.Panel2.ResumeLayout(False)
        CType(Me.spcArchivadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcArchivadas.ResumeLayout(False)
        CType(Me.dwArchivadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents prefijoVendedor As DataGridViewTextBoxColumn
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabControl As TabControl
    Friend WithEvents tabListas As TabPage
    Friend WithEvents spcListas As SplitContainer
    Friend WithEvents tabRechazadas As TabPage
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents tabArchivadas As TabPage
    Friend WithEvents spcRechazadas As SplitContainer
    Friend WithEvents spcArchivadas As SplitContainer
    Friend WithEvents fddRechazadas As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwRechazadas As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddArchivadas As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwArchivadas As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents arc_id As DataGridViewTextBoxColumn
    Friend WithEvents arc_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents arc_estado As DataGridViewTextBoxColumn
    Friend WithEvents arc_idaprobacioncliente As DataGridViewTextBoxColumn
    Friend WithEvents arc_aprobacioncliente As DataGridViewTextBoxColumn
    Friend WithEvents arc_fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents arc_usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents arc_idTipoDocumento As DataGridViewTextBoxColumn
    Friend WithEvents arc_numIdentificacion As DataGridViewTextBoxColumn
    Friend WithEvents arc_cliente As DataGridViewTextBoxColumn
    Friend WithEvents arc_nombreObra As DataGridViewTextBoxColumn
    Friend WithEvents arc_nombreCotiza As DataGridViewTextBoxColumn
    Friend WithEvents arc_fechaCotiza As DataGridViewTextBoxColumn
    Friend WithEvents arc_idCiudad As DataGridViewTextBoxColumn
    Friend WithEvents arc_NombreCiudad As DataGridViewTextBoxColumn
    Friend WithEvents arc_idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents arc_nombreAcabado As DataGridViewTextBoxColumn
    Friend WithEvents arc_idtipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents arc_tipoCotizacion As DataGridViewTextBoxColumn
    Friend WithEvents arc_AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents arc_AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents arc_AIU_Utilidad As DataGridViewTextBoxColumn
    Friend WithEvents rec_id As DataGridViewTextBoxColumn
    Friend WithEvents rec_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents rec_estado As DataGridViewTextBoxColumn
    Friend WithEvents rec_idAprobacionCliente As DataGridViewTextBoxColumn
    Friend WithEvents rec_aprobacioncliente As DataGridViewTextBoxColumn
    Friend WithEvents rec_fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents rec_usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents rec_idTipoDocumento As DataGridViewTextBoxColumn
    Friend WithEvents rec_numIdentificacion As DataGridViewTextBoxColumn
    Friend WithEvents rec_cliente As DataGridViewTextBoxColumn
    Friend WithEvents rec_nombreObra As DataGridViewTextBoxColumn
    Friend WithEvents rec_nombreCotiza As DataGridViewTextBoxColumn
    Friend WithEvents rec_fechaCotiza As DataGridViewTextBoxColumn
    Friend WithEvents rec_idCiudad As DataGridViewTextBoxColumn
    Friend WithEvents rec_NombreCiudad As DataGridViewTextBoxColumn
    Friend WithEvents rec_idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents rec_nombreAcabado As DataGridViewTextBoxColumn
    Friend WithEvents rec_idTipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents rec_TipoCotizacion As DataGridViewTextBoxColumn
    Friend WithEvents rec_AIU_administracion As DataGridViewTextBoxColumn
    Friend WithEvents rec_AIU_improvistos As DataGridViewTextBoxColumn
    Friend WithEvents rec_AIU_utilidad As DataGridViewTextBoxColumn
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents idaprobacioncliente As DataGridViewTextBoxColumn
    Friend WithEvents aprobacioncliente As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idTipoDocumento As DataGridViewTextBoxColumn
    Friend WithEvents numIdentificacion As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents nombreObra As DataGridViewTextBoxColumn
    Friend WithEvents nombreCotiza As DataGridViewTextBoxColumn
    Friend WithEvents fechaCotiza As DataGridViewTextBoxColumn
    Friend WithEvents idCiudad As DataGridViewTextBoxColumn
    Friend WithEvents NombreCiudad As DataGridViewTextBoxColumn
    Friend WithEvents idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents nombreAcabado As DataGridViewTextBoxColumn
    Friend WithEvents idtipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents TipoCotizacion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Utilidad As DataGridViewTextBoxColumn
End Class
