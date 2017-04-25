<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListadoNotas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idPlanAnticipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idOrigen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.origen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorNota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcentAnticipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalCuotas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ivaSobreUtilidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numeroImpresiones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.regionUnoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstadoImpresion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estadoImpresion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(605, 419)
        Me.Panel.TabIndex = 0
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idPlanAnticipo, Me.idEstado, Me.estado, Me.fechaCreacion, Me.usuarioCreacion, Me.nit, Me.codigoObra, Me.cliente, Me.obra, Me.fechaNota, Me.idTipoNota, Me.tipoNota, Me.idOrigen, Me.origen, Me.valorNota, Me.valorContrato, Me.idVendedor, Me.numeroContrato, Me.porcentAnticipo, Me.numeroCuota, Me.totalCuotas, Me.ivaSobreUtilidad, Me.observaciones, Me.numeroImpresiones, Me.usuarioModi, Me.fechaModi, Me.regionUnoee, Me.idEstadoImpresion, Me.estadoImpresion})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 95)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(601, 320)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 41
        '
        'idPlanAnticipo
        '
        Me.idPlanAnticipo.HeaderText = "Id plan anticipo"
        Me.idPlanAnticipo.Name = "idPlanAnticipo"
        Me.idPlanAnticipo.ReadOnly = True
        Me.idPlanAnticipo.Visible = False
        Me.idPlanAnticipo.Width = 104
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
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 45
        '
        'codigoObra
        '
        Me.codigoObra.HeaderText = "Codigo obra"
        Me.codigoObra.Name = "codigoObra"
        Me.codigoObra.ReadOnly = True
        Me.codigoObra.Width = 82
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 64
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        Me.obra.Width = 55
        '
        'fechaNota
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.fechaNota.DefaultCellStyle = DataGridViewCellStyle1
        Me.fechaNota.HeaderText = "Fecha nota"
        Me.fechaNota.Name = "fechaNota"
        Me.fechaNota.ReadOnly = True
        Me.fechaNota.Width = 79
        '
        'idTipoNota
        '
        Me.idTipoNota.HeaderText = "Id tipo nota"
        Me.idTipoNota.Name = "idTipoNota"
        Me.idTipoNota.ReadOnly = True
        Me.idTipoNota.Visible = False
        Me.idTipoNota.Width = 85
        '
        'tipoNota
        '
        Me.tipoNota.HeaderText = "Tipo nota"
        Me.tipoNota.Name = "tipoNota"
        Me.tipoNota.ReadOnly = True
        Me.tipoNota.Width = 71
        '
        'idOrigen
        '
        Me.idOrigen.HeaderText = "Id origen"
        Me.idOrigen.Name = "idOrigen"
        Me.idOrigen.ReadOnly = True
        Me.idOrigen.Visible = False
        Me.idOrigen.Width = 73
        '
        'origen
        '
        Me.origen.HeaderText = "Origen"
        Me.origen.Name = "origen"
        Me.origen.ReadOnly = True
        Me.origen.Width = 63
        '
        'valorNota
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.valorNota.DefaultCellStyle = DataGridViewCellStyle2
        Me.valorNota.HeaderText = "Valor nota"
        Me.valorNota.Name = "valorNota"
        Me.valorNota.ReadOnly = True
        Me.valorNota.Width = 74
        '
        'valorContrato
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.valorContrato.DefaultCellStyle = DataGridViewCellStyle3
        Me.valorContrato.HeaderText = "Valor contrato"
        Me.valorContrato.Name = "valorContrato"
        Me.valorContrato.ReadOnly = True
        Me.valorContrato.Visible = False
        Me.valorContrato.Width = 98
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "Vendedor"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Width = 78
        '
        'numeroContrato
        '
        Me.numeroContrato.HeaderText = "Contrato"
        Me.numeroContrato.Name = "numeroContrato"
        Me.numeroContrato.ReadOnly = True
        Me.numeroContrato.Visible = False
        Me.numeroContrato.Width = 72
        '
        'porcentAnticipo
        '
        Me.porcentAnticipo.HeaderText = "Anticipo (%)"
        Me.porcentAnticipo.Name = "porcentAnticipo"
        Me.porcentAnticipo.ReadOnly = True
        Me.porcentAnticipo.Visible = False
        Me.porcentAnticipo.Width = 87
        '
        'numeroCuota
        '
        Me.numeroCuota.HeaderText = "Número cuota"
        Me.numeroCuota.Name = "numeroCuota"
        Me.numeroCuota.ReadOnly = True
        Me.numeroCuota.Visible = False
        Me.numeroCuota.Width = 99
        '
        'totalCuotas
        '
        Me.totalCuotas.HeaderText = "Total cuotas"
        Me.totalCuotas.Name = "totalCuotas"
        Me.totalCuotas.ReadOnly = True
        Me.totalCuotas.Visible = False
        Me.totalCuotas.Width = 91
        '
        'ivaSobreUtilidad
        '
        Me.ivaSobreUtilidad.HeaderText = "Iva sobre utilidad"
        Me.ivaSobreUtilidad.Name = "ivaSobreUtilidad"
        Me.ivaSobreUtilidad.ReadOnly = True
        Me.ivaSobreUtilidad.Visible = False
        Me.ivaSobreUtilidad.Width = 93
        '
        'observaciones
        '
        Me.observaciones.HeaderText = "Observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.ReadOnly = True
        Me.observaciones.Visible = False
        Me.observaciones.Width = 103
        '
        'numeroImpresiones
        '
        Me.numeroImpresiones.HeaderText = "Número impresiones"
        Me.numeroImpresiones.Name = "numeroImpresiones"
        Me.numeroImpresiones.ReadOnly = True
        Me.numeroImpresiones.Visible = False
        Me.numeroImpresiones.Width = 127
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario Modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Visible = False
        Me.usuarioModi.Width = 131
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Visible = False
        Me.fechaModi.Width = 124
        '
        'regionUnoee
        '
        Me.regionUnoee.HeaderText = "Región"
        Me.regionUnoee.Name = "regionUnoee"
        Me.regionUnoee.ReadOnly = True
        Me.regionUnoee.Width = 66
        '
        'idEstadoImpresion
        '
        Me.idEstadoImpresion.HeaderText = "Id estado impresion"
        Me.idEstadoImpresion.Name = "idEstadoImpresion"
        Me.idEstadoImpresion.ReadOnly = True
        Me.idEstadoImpresion.Visible = False
        Me.idEstadoImpresion.Width = 123
        '
        'estadoImpresion
        '
        Me.estadoImpresion.HeaderText = "Estado impresión"
        Me.estadoImpresion.Name = "estadoImpresion"
        Me.estadoImpresion.ReadOnly = True
        Me.estadoImpresion.Width = 103
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(601, 95)
        Me.fddFiltros.TabIndex = 0
        '
        'FrmListadoNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 443)
        Me.Controls.Add(Me.Panel)
        Me.Name = "FrmListadoNotas"
        Me.ShowIcon = False
        Me.Text = "Listado notas"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idPlanAnticipo As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents fechaNota As DataGridViewTextBoxColumn
    Friend WithEvents idTipoNota As DataGridViewTextBoxColumn
    Friend WithEvents tipoNota As DataGridViewTextBoxColumn
    Friend WithEvents idOrigen As DataGridViewTextBoxColumn
    Friend WithEvents origen As DataGridViewTextBoxColumn
    Friend WithEvents valorNota As DataGridViewTextBoxColumn
    Friend WithEvents valorContrato As DataGridViewTextBoxColumn
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents numeroContrato As DataGridViewTextBoxColumn
    Friend WithEvents porcentAnticipo As DataGridViewTextBoxColumn
    Friend WithEvents numeroCuota As DataGridViewTextBoxColumn
    Friend WithEvents totalCuotas As DataGridViewTextBoxColumn
    Friend WithEvents ivaSobreUtilidad As DataGridViewCheckBoxColumn
    Friend WithEvents observaciones As DataGridViewTextBoxColumn
    Friend WithEvents numeroImpresiones As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents regionUnoee As DataGridViewTextBoxColumn
    Friend WithEvents idEstadoImpresion As DataGridViewTextBoxColumn
    Friend WithEvents estadoImpresion As DataGridViewTextBoxColumn
End Class
