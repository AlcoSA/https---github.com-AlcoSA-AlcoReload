<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListaContratos
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.IdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefijoVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabListasContratos = New System.Windows.Forms.TabControl()
        Me.tabListaEnContratacion = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrosContratacion = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwContratacion = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.tabContratadas = New System.Windows.Forms.TabPage()
        Me.col_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombreObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabListasContratos.SuspendLayout()
        Me.tabListaEnContratacion.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dwContratacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContratadas.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(683, 404)
        Me.SplitContainer1.SplitterDistance = 87
        Me.SplitContainer1.TabIndex = 2
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(683, 87)
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
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.nit, Me.NitYo, Me.CodigoObra, Me.Cliente, Me.ClienteYO, Me.Obra, Me.Objeto, Me.Para, Me.nContrato, Me.FechaInicio, Me.FechaTerminacion, Me.TipoImpuesto, Me.ValorContrato, Me.idtipoCotiza, Me.IdEstado, Me.DescEstado, Me.Notas, Me.UsuarioCreacion, Me.UsuarioModi, Me.FechaModificacion, Me.AIU_Administracion, Me.AIU_Improvistos, Me.AIU_Utilidad})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(683, 313)
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
        Me.CodigoObra.Width = 65
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
        Me.Objeto.ReadOnly = True
        Me.Objeto.Width = 63
        '
        'Para
        '
        Me.Para.HeaderText = "Para"
        Me.Para.Name = "Para"
        Me.Para.ReadOnly = True
        Me.Para.Width = 54
        '
        'nContrato
        '
        Me.nContrato.HeaderText = "# Contrato"
        Me.nContrato.Name = "nContrato"
        Me.nContrato.ReadOnly = True
        Me.nContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nContrato.Width = 57
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
        Me.FechaTerminacion.Width = 94
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ValorContrato.DefaultCellStyle = DataGridViewCellStyle4
        Me.ValorContrato.HeaderText = "Valor Contrato"
        Me.ValorContrato.Name = "ValorContrato"
        Me.ValorContrato.ReadOnly = True
        Me.ValorContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorContrato.Width = 72
        '
        'idtipoCotiza
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.idtipoCotiza.DefaultCellStyle = DataGridViewCellStyle5
        Me.idtipoCotiza.HeaderText = "Valor Iva"
        Me.idtipoCotiza.Name = "idtipoCotiza"
        Me.idtipoCotiza.ReadOnly = True
        Me.idtipoCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idtipoCotiza.Visible = False
        Me.idtipoCotiza.Width = 50
        '
        'IdEstado
        '
        Me.IdEstado.HeaderText = "Id estado"
        Me.IdEstado.Name = "IdEstado"
        Me.IdEstado.ReadOnly = True
        Me.IdEstado.Visible = False
        Me.IdEstado.Width = 70
        '
        'DescEstado
        '
        Me.DescEstado.HeaderText = "Estado"
        Me.DescEstado.Name = "DescEstado"
        Me.DescEstado.ReadOnly = True
        Me.DescEstado.Width = 65
        '
        'Notas
        '
        Me.Notas.HeaderText = "Notas"
        Me.Notas.Name = "Notas"
        Me.Notas.ReadOnly = True
        Me.Notas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Notas.Width = 41
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creacion"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioCreacion.Visible = False
        Me.UsuarioCreacion.Width = 85
        '
        'UsuarioModi
        '
        Me.UsuarioModi.HeaderText = "Usuario Modi"
        Me.UsuarioModi.Name = "UsuarioModi"
        Me.UsuarioModi.ReadOnly = True
        Me.UsuarioModi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioModi.Visible = False
        Me.UsuarioModi.Width = 68
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha Modificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.ReadOnly = True
        Me.FechaModificacion.Visible = False
        Me.FechaModificacion.Width = 114
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
        'tabListasContratos
        '
        Me.tabListasContratos.Controls.Add(Me.tabListaEnContratacion)
        Me.tabListasContratos.Controls.Add(Me.tabContratadas)
        Me.tabListasContratos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabListasContratos.Location = New System.Drawing.Point(0, 0)
        Me.tabListasContratos.Name = "tabListasContratos"
        Me.tabListasContratos.SelectedIndex = 0
        Me.tabListasContratos.Size = New System.Drawing.Size(701, 440)
        Me.tabListasContratos.TabIndex = 3
        '
        'tabListaEnContratacion
        '
        Me.tabListaEnContratacion.BackColor = System.Drawing.SystemColors.Control
        Me.tabListaEnContratacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabListaEnContratacion.Controls.Add(Me.SplitContainer2)
        Me.tabListaEnContratacion.Location = New System.Drawing.Point(4, 22)
        Me.tabListaEnContratacion.Name = "tabListaEnContratacion"
        Me.tabListaEnContratacion.Padding = New System.Windows.Forms.Padding(3)
        Me.tabListaEnContratacion.Size = New System.Drawing.Size(693, 414)
        Me.tabListaEnContratacion.TabIndex = 0
        Me.tabListaEnContratacion.Text = "En contratación"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.fddFiltrosContratacion)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.dwContratacion)
        Me.SplitContainer2.Size = New System.Drawing.Size(683, 404)
        Me.SplitContainer2.SplitterDistance = 81
        Me.SplitContainer2.TabIndex = 4
        '
        'fddFiltrosContratacion
        '
        Me.fddFiltrosContratacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrosContratacion.Grid = Me.dwContratacion
        Me.fddFiltrosContratacion.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrosContratacion.Name = "fddFiltrosContratacion"
        Me.fddFiltrosContratacion.Size = New System.Drawing.Size(683, 81)
        Me.fddFiltrosContratacion.TabIndex = 0
        '
        'dwContratacion
        '
        Me.dwContratacion.AllowUserToAddRows = False
        Me.dwContratacion.AllowUserToDeleteRows = False
        Me.dwContratacion.AllowUserToResizeColumns = False
        Me.dwContratacion.AllowUserToResizeRows = False
        Me.dwContratacion.AutoGenerateColumns = False
        Me.dwContratacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwContratacion.BackgroundColor = System.Drawing.Color.White
        Me.dwContratacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwContratacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwContratacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_seleccion, Me.col_id, Me.col_idEstado, Me.col_estado, Me.col_documento, Me.col_cliente, Me.col_nombreObra, Me.col_valorContrato})
        Me.dwContratacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwContratacion.ImageList = Nothing
        Me.dwContratacion.Location = New System.Drawing.Point(0, 0)
        Me.dwContratacion.MostrarFiltros = True
        Me.dwContratacion.MultiSelect = False
        Me.dwContratacion.Name = "dwContratacion"
        Me.dwContratacion.RowHeadersWidth = 30
        Me.dwContratacion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwContratacion.Size = New System.Drawing.Size(683, 319)
        Me.dwContratacion.TabIndex = 0
        Me.dwContratacion.TablaDatos = Nothing
        Me.dwContratacion.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'tabContratadas
        '
        Me.tabContratadas.BackColor = System.Drawing.SystemColors.Control
        Me.tabContratadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabContratadas.Controls.Add(Me.SplitContainer1)
        Me.tabContratadas.Location = New System.Drawing.Point(4, 22)
        Me.tabContratadas.Name = "tabContratadas"
        Me.tabContratadas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabContratadas.Size = New System.Drawing.Size(693, 414)
        Me.tabContratadas.TabIndex = 1
        Me.tabContratadas.Text = "Contratadas"
        '
        'col_seleccion
        '
        Me.col_seleccion.HeaderText = "Selección"
        Me.col_seleccion.Name = "col_seleccion"
        Me.col_seleccion.Width = 60
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Width = 41
        '
        'col_idEstado
        '
        Me.col_idEstado.HeaderText = "Id estado"
        Me.col_idEstado.Name = "col_idEstado"
        Me.col_idEstado.ReadOnly = True
        Me.col_idEstado.Visible = False
        Me.col_idEstado.Width = 76
        '
        'col_estado
        '
        Me.col_estado.HeaderText = "Estado"
        Me.col_estado.Name = "col_estado"
        Me.col_estado.ReadOnly = True
        Me.col_estado.Width = 65
        '
        'col_documento
        '
        Me.col_documento.HeaderText = "Documento"
        Me.col_documento.Name = "col_documento"
        Me.col_documento.ReadOnly = True
        Me.col_documento.Width = 87
        '
        'col_cliente
        '
        Me.col_cliente.HeaderText = "Cliente"
        Me.col_cliente.Name = "col_cliente"
        Me.col_cliente.ReadOnly = True
        Me.col_cliente.Width = 64
        '
        'col_nombreObra
        '
        Me.col_nombreObra.HeaderText = "Nombre obra"
        Me.col_nombreObra.Name = "col_nombreObra"
        Me.col_nombreObra.ReadOnly = True
        Me.col_nombreObra.Width = 93
        '
        'col_valorContrato
        '
        DataGridViewCellStyle6.Format = "C0"
        Me.col_valorContrato.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_valorContrato.HeaderText = "Valor contrato"
        Me.col_valorContrato.Name = "col_valorContrato"
        Me.col_valorContrato.ReadOnly = True
        Me.col_valorContrato.Width = 98
        '
        'FrmListaContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 440)
        Me.Controls.Add(Me.tabListasContratos)
        Me.Name = "FrmListaContratos"
        Me.ShowIcon = False
        Me.Text = "Ver Contratos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabListasContratos.ResumeLayout(False)
        Me.tabListaEnContratacion.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dwContratacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContratadas.ResumeLayout(False)
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
    Friend WithEvents IdEstado As DataGridViewTextBoxColumn
    Friend WithEvents DescEstado As DataGridViewTextBoxColumn
    Friend WithEvents Notas As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Utilidad As DataGridViewTextBoxColumn
    Friend WithEvents tabListasContratos As TabControl
    Friend WithEvents tabListaEnContratacion As TabPage
    Friend WithEvents tabContratadas As TabPage
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents fddFiltrosContratacion As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwContratacion As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents col_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents col_estado As DataGridViewTextBoxColumn
    Friend WithEvents col_documento As DataGridViewTextBoxColumn
    Friend WithEvents col_cliente As DataGridViewTextBoxColumn
    Friend WithEvents col_nombreObra As DataGridViewTextBoxColumn
    Friend WithEvents col_valorContrato As DataGridViewTextBoxColumn
End Class
