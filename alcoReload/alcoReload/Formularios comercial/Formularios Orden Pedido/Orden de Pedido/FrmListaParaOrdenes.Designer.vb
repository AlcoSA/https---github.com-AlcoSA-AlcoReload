<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListaParaOrdenes
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NitYo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Objeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Para = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaTerminacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefijoVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(701, 440)
        Me.SplitContainer1.SplitterDistance = 84
        Me.SplitContainer1.TabIndex = 2
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(701, 84)
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
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.nit, Me.NitYo, Me.CodigoObra, Me.Cliente, Me.ClienteYO, Me.Obra, Me.Objeto, Me.Para, Me.nContrato, Me.FechaInicio, Me.FechaTerminacion, Me.TipoImpuesto, Me.ValorContrato, Me.idtipoCotiza, Me.Notas, Me.UsuarioCreacion, Me.UsuarioModi, Me.FechaModificacion, Me.AIU_Administracion, Me.AIU_Improvistos, Me.AIU_Utilidad})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(701, 352)
        Me.dwItem.TabIndex = 0
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Visible = False
        Me.id.Width = 24
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaCreacion.Visible = False
        Me.fechaCreacion.Width = 87
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nit.Width = 26
        '
        'NitYo
        '
        Me.NitYo.HeaderText = "Nit Y/O"
        Me.NitYo.Name = "NitYo"
        Me.NitYo.ReadOnly = True
        Me.NitYo.Visible = False
        Me.NitYo.Width = 68
        '
        'CodigoObra
        '
        Me.CodigoObra.HeaderText = "Código Obra"
        Me.CodigoObra.Name = "CodigoObra"
        Me.CodigoObra.ReadOnly = True
        Me.CodigoObra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoObra.Width = 72
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cliente.Width = 45
        '
        'ClienteYO
        '
        Me.ClienteYO.HeaderText = "Cliente Y/O"
        Me.ClienteYO.Name = "ClienteYO"
        Me.ClienteYO.ReadOnly = True
        Me.ClienteYO.Visible = False
        Me.ClienteYO.Width = 87
        '
        'Obra
        '
        Me.Obra.HeaderText = "Obra"
        Me.Obra.Name = "Obra"
        Me.Obra.ReadOnly = True
        Me.Obra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Obra.Width = 36
        '
        'Objeto
        '
        Me.Objeto.HeaderText = "Objeto"
        Me.Objeto.Name = "Objeto"
        Me.Objeto.Width = 63
        '
        'Para
        '
        Me.Para.HeaderText = "Para"
        Me.Para.Name = "Para"
        Me.Para.Width = 54
        '
        'nContrato
        '
        Me.nContrato.HeaderText = "# Contrato"
        Me.nContrato.Name = "nContrato"
        Me.nContrato.ReadOnly = True
        Me.nContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nContrato.Visible = False
        Me.nContrato.Width = 63
        '
        'FechaInicio
        '
        Me.FechaInicio.HeaderText = "Fecha Inicio"
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.ReadOnly = True
        Me.FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaInicio.Visible = False
        Me.FechaInicio.Width = 71
        '
        'FechaTerminacion
        '
        Me.FechaTerminacion.HeaderText = "Fecha Terminacion"
        Me.FechaTerminacion.Name = "FechaTerminacion"
        Me.FechaTerminacion.ReadOnly = True
        Me.FechaTerminacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaTerminacion.Visible = False
        Me.FechaTerminacion.Width = 104
        '
        'TipoImpuesto
        '
        Me.TipoImpuesto.HeaderText = "TipoImpuesto"
        Me.TipoImpuesto.Name = "TipoImpuesto"
        Me.TipoImpuesto.ReadOnly = True
        Me.TipoImpuesto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TipoImpuesto.Visible = False
        Me.TipoImpuesto.Width = 77
        '
        'ValorContrato
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ValorContrato.DefaultCellStyle = DataGridViewCellStyle3
        Me.ValorContrato.HeaderText = "Valor Contrato"
        Me.ValorContrato.Name = "ValorContrato"
        Me.ValorContrato.ReadOnly = True
        Me.ValorContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorContrato.Visible = False
        Me.ValorContrato.Width = 80
        '
        'idtipoCotiza
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.idtipoCotiza.DefaultCellStyle = DataGridViewCellStyle4
        Me.idtipoCotiza.HeaderText = "Valor Iva"
        Me.idtipoCotiza.Name = "idtipoCotiza"
        Me.idtipoCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idtipoCotiza.Visible = False
        Me.idtipoCotiza.Width = 55
        '
        'Notas
        '
        Me.Notas.HeaderText = "Notas"
        Me.Notas.Name = "Notas"
        Me.Notas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Notas.Visible = False
        Me.Notas.Width = 41
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creacion"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioCreacion.Visible = False
        Me.UsuarioCreacion.Width = 94
        '
        'UsuarioModi
        '
        Me.UsuarioModi.HeaderText = "Usuario Modi"
        Me.UsuarioModi.Name = "UsuarioModi"
        Me.UsuarioModi.ReadOnly = True
        Me.UsuarioModi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioModi.Visible = False
        Me.UsuarioModi.Width = 75
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha Modificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.Visible = False
        Me.FechaModificacion.Width = 125
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
        'prefijoVendedor
        '
        Me.prefijoVendedor.HeaderText = "Vendedor"
        Me.prefijoVendedor.Name = "prefijoVendedor"
        Me.prefijoVendedor.ReadOnly = True
        Me.prefijoVendedor.Width = 78
        '
        'FrmListaParaOrdenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 440)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmListaParaOrdenes"
        Me.ShowIcon = False
        Me.Text = "Generar ordenes de Pedido"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents prefijoVendedor As DataGridViewTextBoxColumn
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents NitYo As DataGridViewTextBoxColumn
    Friend WithEvents CodigoObra As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents ClienteYO As DataGridViewTextBoxColumn
    Friend WithEvents Obra As DataGridViewTextBoxColumn
    Friend WithEvents Objeto As DataGridViewTextBoxColumn
    Friend WithEvents Para As DataGridViewTextBoxColumn
    Friend WithEvents nContrato As DataGridViewTextBoxColumn
    Friend WithEvents FechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents FechaTerminacion As DataGridViewTextBoxColumn
    Friend WithEvents TipoImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents ValorContrato As DataGridViewTextBoxColumn
    Friend WithEvents idtipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents Notas As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Utilidad As DataGridViewTextBoxColumn
End Class
