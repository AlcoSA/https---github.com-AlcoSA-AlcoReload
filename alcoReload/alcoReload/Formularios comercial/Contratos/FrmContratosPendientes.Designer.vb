<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContratosPendientes
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
        Me.idarticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtcuadrados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabadoperf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colorvidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.factor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valordescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciounitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciototal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.piezasxunidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costovidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoperfiles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoaccesorios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costootros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costounitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costototal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preciomtinstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioinstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidadmedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoitem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.selectToContract = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numIdentificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoCotizacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'idarticulo
        '
        Me.idarticulo.HeaderText = "Id Articulo"
        Me.idarticulo.Name = "idarticulo"
        Me.idarticulo.Visible = False
        Me.idarticulo.Width = 79
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "Ubicacion"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.Width = 80
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Width = 88
        '
        'ancho
        '
        Me.ancho.HeaderText = "Ancho"
        Me.ancho.Name = "ancho"
        Me.ancho.Width = 63
        '
        'alto
        '
        Me.alto.HeaderText = "Alto"
        Me.alto.Name = "alto"
        Me.alto.Width = 50
        '
        'mtcuadrados
        '
        Me.mtcuadrados.HeaderText = "Metros Cuadrados"
        Me.mtcuadrados.Name = "mtcuadrados"
        Me.mtcuadrados.Width = 118
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Width = 74
        '
        'acabadoperf
        '
        Me.acabadoperf.HeaderText = "Acabado"
        Me.acabadoperf.Name = "acabadoperf"
        Me.acabadoperf.Width = 75
        '
        'vidrio
        '
        Me.vidrio.HeaderText = "Vidrio"
        Me.vidrio.Name = "vidrio"
        Me.vidrio.Width = 58
        '
        'colorvidrio
        '
        Me.colorvidrio.HeaderText = "Color Vidrio"
        Me.colorvidrio.Name = "colorvidrio"
        Me.colorvidrio.Width = 85
        '
        'espesor
        '
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.Width = 70
        '
        'factor
        '
        Me.factor.HeaderText = "Factor"
        Me.factor.Name = "factor"
        Me.factor.Width = 62
        '
        'descuento
        '
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.Width = 84
        '
        'valordescuento
        '
        Me.valordescuento.HeaderText = "Valor Descuento"
        Me.valordescuento.Name = "valordescuento"
        Me.valordescuento.Width = 111
        '
        'preciounitario
        '
        Me.preciounitario.HeaderText = "Precio Unitario"
        Me.preciounitario.Name = "preciounitario"
        Me.preciounitario.Width = 101
        '
        'preciototal
        '
        Me.preciototal.HeaderText = "Precio Total"
        Me.preciototal.Name = "preciototal"
        Me.preciototal.Width = 89
        '
        'piezasxunidad
        '
        Me.piezasxunidad.HeaderText = "Piezas x Und."
        Me.piezasxunidad.Name = "piezasxunidad"
        Me.piezasxunidad.Width = 97
        '
        'costovidrio
        '
        Me.costovidrio.HeaderText = "Costo Vidrio"
        Me.costovidrio.Name = "costovidrio"
        Me.costovidrio.Width = 88
        '
        'costoperfiles
        '
        Me.costoperfiles.HeaderText = "Costo Perfiles"
        Me.costoperfiles.Name = "costoperfiles"
        Me.costoperfiles.Width = 96
        '
        'costoaccesorios
        '
        Me.costoaccesorios.HeaderText = "Costo Accesorios"
        Me.costoaccesorios.Name = "costoaccesorios"
        Me.costoaccesorios.Width = 114
        '
        'costootros
        '
        Me.costootros.HeaderText = "Costo Otros"
        Me.costootros.Name = "costootros"
        Me.costootros.Width = 87
        '
        'costounitario
        '
        Me.costounitario.HeaderText = "Costo Unitario"
        Me.costounitario.Name = "costounitario"
        Me.costounitario.Width = 98
        '
        'costototal
        '
        Me.costototal.HeaderText = "Costo Total"
        Me.costototal.Name = "costototal"
        Me.costototal.Width = 86
        '
        'preciomtinstalacion
        '
        Me.preciomtinstalacion.HeaderText = "Precio Metro Instalacion"
        Me.preciomtinstalacion.Name = "preciomtinstalacion"
        Me.preciomtinstalacion.Width = 146
        '
        'precioinstalacion
        '
        Me.precioinstalacion.HeaderText = "Precio Instalación"
        Me.precioinstalacion.Name = "precioinstalacion"
        Me.precioinstalacion.Width = 116
        '
        'unidadmedida
        '
        Me.unidadmedida.HeaderText = "Unidad Medida"
        Me.unidadmedida.Name = "unidadmedida"
        Me.unidadmedida.Width = 104
        '
        'tipoitem
        '
        Me.tipoitem.HeaderText = "Tipo Item"
        Me.tipoitem.Name = "tipoitem"
        Me.tipoitem.Visible = False
        Me.tipoitem.Width = 76
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(5, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.fddFiltrado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dwItem)
        Me.SplitContainer1.Size = New System.Drawing.Size(714, 451)
        Me.SplitContainer1.SplitterDistance = 91
        Me.SplitContainer1.TabIndex = 3
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(714, 91)
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
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selectToContract, Me.id, Me.idcotizacion, Me.idEstado, Me.estado, Me.numIdentificacion, Me.cliente, Me.nombreObra, Me.nombreCotiza, Me.fechaCreacion, Me.fechaCotiza, Me.idCiudad, Me.nombreCiudad, Me.idAcabado, Me.nombreAcabado, Me.idtipoCotiza, Me.TipoCotizacion, Me.AIU_Administracion, Me.AIU_Improvistos, Me.AIU_Utilidad})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(714, 356)
        Me.dwItem.TabIndex = 0
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'selectToContract
        '
        Me.selectToContract.HeaderText = "Seleccionar"
        Me.selectToContract.Name = "selectToContract"
        Me.selectToContract.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selectToContract.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selectToContract.Width = 88
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'idcotizacion
        '
        Me.idcotizacion.HeaderText = "Id Cotizacion"
        Me.idcotizacion.Name = "idcotizacion"
        Me.idcotizacion.ReadOnly = True
        Me.idcotizacion.Width = 93
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "idEstado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idEstado.Visible = False
        Me.idEstado.Width = 54
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.estado.Width = 46
        '
        'numIdentificacion
        '
        Me.numIdentificacion.HeaderText = "Documento"
        Me.numIdentificacion.Name = "numIdentificacion"
        Me.numIdentificacion.ReadOnly = True
        Me.numIdentificacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.numIdentificacion.Width = 68
        '
        'cliente
        '
        Me.cliente.HeaderText = "Constructora"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cliente.Width = 73
        '
        'nombreObra
        '
        Me.nombreObra.HeaderText = "Nombre de obra"
        Me.nombreObra.Name = "nombreObra"
        Me.nombreObra.ReadOnly = True
        Me.nombreObra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombreObra.Width = 61
        '
        'nombreCotiza
        '
        Me.nombreCotiza.HeaderText = "Nombre personalizado"
        Me.nombreCotiza.Name = "nombreCotiza"
        Me.nombreCotiza.ReadOnly = True
        Me.nombreCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombreCotiza.Width = 106
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaCreacion.Width = 78
        '
        'fechaCotiza
        '
        Me.fechaCotiza.HeaderText = "Fecha cotización"
        Me.fechaCotiza.Name = "fechaCotiza"
        Me.fechaCotiza.ReadOnly = True
        Me.fechaCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaCotiza.Width = 85
        '
        'idCiudad
        '
        Me.idCiudad.HeaderText = "idCiudad"
        Me.idCiudad.Name = "idCiudad"
        Me.idCiudad.ReadOnly = True
        Me.idCiudad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idCiudad.Visible = False
        Me.idCiudad.Width = 54
        '
        'nombreCiudad
        '
        Me.nombreCiudad.HeaderText = "Ciudad"
        Me.nombreCiudad.Name = "nombreCiudad"
        Me.nombreCiudad.ReadOnly = True
        Me.nombreCiudad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombreCiudad.Width = 46
        '
        'idAcabado
        '
        Me.idAcabado.HeaderText = "idAcabado"
        Me.idAcabado.Name = "idAcabado"
        Me.idAcabado.ReadOnly = True
        Me.idAcabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idAcabado.Visible = False
        Me.idAcabado.Width = 64
        '
        'nombreAcabado
        '
        Me.nombreAcabado.HeaderText = "Acabado"
        Me.nombreAcabado.Name = "nombreAcabado"
        Me.nombreAcabado.ReadOnly = True
        Me.nombreAcabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nombreAcabado.Width = 56
        '
        'idtipoCotiza
        '
        Me.idtipoCotiza.HeaderText = "id Tipo Cotiza"
        Me.idtipoCotiza.Name = "idtipoCotiza"
        Me.idtipoCotiza.ReadOnly = True
        Me.idtipoCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idtipoCotiza.Visible = False
        Me.idtipoCotiza.Width = 69
        '
        'TipoCotizacion
        '
        Me.TipoCotizacion.HeaderText = "Tipo Cotizacion"
        Me.TipoCotizacion.Name = "TipoCotizacion"
        Me.TipoCotizacion.ReadOnly = True
        Me.TipoCotizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TipoCotizacion.Width = 77
        '
        'AIU_Administracion
        '
        Me.AIU_Administracion.HeaderText = "AIU_Administracion"
        Me.AIU_Administracion.Name = "AIU_Administracion"
        Me.AIU_Administracion.ReadOnly = True
        Me.AIU_Administracion.Visible = False
        Me.AIU_Administracion.Width = 124
        '
        'AIU_Improvistos
        '
        Me.AIU_Improvistos.HeaderText = "AIU_Improvistos"
        Me.AIU_Improvistos.Name = "AIU_Improvistos"
        Me.AIU_Improvistos.ReadOnly = True
        Me.AIU_Improvistos.Visible = False
        Me.AIU_Improvistos.Width = 109
        '
        'AIU_Utilidad
        '
        Me.AIU_Utilidad.HeaderText = "AIU_Utilidad"
        Me.AIU_Utilidad.Name = "AIU_Utilidad"
        Me.AIU_Utilidad.ReadOnly = True
        Me.AIU_Utilidad.Visible = False
        Me.AIU_Utilidad.Width = 91
        '
        'FrmContratosPendientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 461)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmContratosPendientes"
        Me.Padding = New System.Windows.Forms.Padding(5, 0, 5, 10)
        Me.ShowIcon = False
        Me.Text = "Contratos Pendientes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents idarticulo As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ancho As DataGridViewTextBoxColumn
    Friend WithEvents alto As DataGridViewTextBoxColumn
    Friend WithEvents mtcuadrados As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents acabadoperf As DataGridViewTextBoxColumn
    Friend WithEvents vidrio As DataGridViewTextBoxColumn
    Friend WithEvents colorvidrio As DataGridViewTextBoxColumn
    Friend WithEvents espesor As DataGridViewTextBoxColumn
    Friend WithEvents factor As DataGridViewTextBoxColumn
    Friend WithEvents descuento As DataGridViewTextBoxColumn
    Friend WithEvents valordescuento As DataGridViewTextBoxColumn
    Friend WithEvents preciounitario As DataGridViewTextBoxColumn
    Friend WithEvents preciototal As DataGridViewTextBoxColumn
    Friend WithEvents piezasxunidad As DataGridViewTextBoxColumn
    Friend WithEvents costovidrio As DataGridViewTextBoxColumn
    Friend WithEvents costoperfiles As DataGridViewTextBoxColumn
    Friend WithEvents costoaccesorios As DataGridViewTextBoxColumn
    Friend WithEvents costootros As DataGridViewTextBoxColumn
    Friend WithEvents costounitario As DataGridViewTextBoxColumn
    Friend WithEvents costototal As DataGridViewTextBoxColumn
    Friend WithEvents preciomtinstalacion As DataGridViewTextBoxColumn
    Friend WithEvents precioinstalacion As DataGridViewTextBoxColumn
    Friend WithEvents unidadmedida As DataGridViewTextBoxColumn
    Friend WithEvents tipoitem As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents selectToContract As DataGridViewCheckBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idcotizacion As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents numIdentificacion As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents nombreObra As DataGridViewTextBoxColumn
    Friend WithEvents nombreCotiza As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents fechaCotiza As DataGridViewTextBoxColumn
    Friend WithEvents idCiudad As DataGridViewTextBoxColumn
    Friend WithEvents nombreCiudad As DataGridViewTextBoxColumn
    Friend WithEvents idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents nombreAcabado As DataGridViewTextBoxColumn
    Friend WithEvents idtipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents TipoCotizacion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Utilidad As DataGridViewTextBoxColumn
End Class
