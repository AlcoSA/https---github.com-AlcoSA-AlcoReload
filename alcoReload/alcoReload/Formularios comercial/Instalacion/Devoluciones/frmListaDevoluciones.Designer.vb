<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaDevoluciones
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
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCuentaCobro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEncargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.encargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel.Size = New System.Drawing.Size(679, 429)
        Me.Panel.TabIndex = 1
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.idCuentaCobro, Me.idDocumento, Me.documento, Me.consecutivo, Me.idProveedor, Me.proveedor, Me.idEncargado, Me.encargado, Me.codigoObra, Me.obra, Me.vendedor, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 101)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(675, 324)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(675, 101)
        Me.fddFiltros.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 41
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
        Me.usuarioCreacion.Visible = False
        Me.usuarioCreacion.Width = 103
        '
        'idCuentaCobro
        '
        Me.idCuentaCobro.HeaderText = "Id cuenta cobro"
        Me.idCuentaCobro.Name = "idCuentaCobro"
        Me.idCuentaCobro.ReadOnly = True
        Me.idCuentaCobro.Visible = False
        Me.idCuentaCobro.Width = 98
        '
        'idDocumento
        '
        Me.idDocumento.HeaderText = "Id documento"
        Me.idDocumento.Name = "idDocumento"
        Me.idDocumento.ReadOnly = True
        Me.idDocumento.Visible = False
        Me.idDocumento.Width = 89
        '
        'documento
        '
        Me.documento.HeaderText = "Documento"
        Me.documento.Name = "documento"
        Me.documento.ReadOnly = True
        Me.documento.Width = 87
        '
        'consecutivo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.consecutivo.DefaultCellStyle = DataGridViewCellStyle1
        Me.consecutivo.HeaderText = "Consecutivo"
        Me.consecutivo.Name = "consecutivo"
        Me.consecutivo.ReadOnly = True
        Me.consecutivo.Width = 91
        '
        'idProveedor
        '
        Me.idProveedor.HeaderText = "Id proveedor"
        Me.idProveedor.Name = "idProveedor"
        Me.idProveedor.ReadOnly = True
        Me.idProveedor.Visible = False
        Me.idProveedor.Width = 85
        '
        'proveedor
        '
        Me.proveedor.HeaderText = "Proveedor"
        Me.proveedor.Name = "proveedor"
        Me.proveedor.ReadOnly = True
        Me.proveedor.Width = 81
        '
        'idEncargado
        '
        Me.idEncargado.HeaderText = "Id encargado"
        Me.idEncargado.Name = "idEncargado"
        Me.idEncargado.ReadOnly = True
        Me.idEncargado.Visible = False
        Me.idEncargado.Width = 87
        '
        'encargado
        '
        Me.encargado.HeaderText = "Encargado"
        Me.encargado.Name = "encargado"
        Me.encargado.ReadOnly = True
        Me.encargado.Width = 84
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
        'vendedor
        '
        Me.vendedor.HeaderText = "Vendedor"
        Me.vendedor.Name = "vendedor"
        Me.vendedor.ReadOnly = True
        Me.vendedor.Width = 78
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Visible = False
        Me.usuarioModi.Width = 119
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Visible = False
        Me.fechaModi.Width = 114
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'frmListaDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 453)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaDevoluciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Lista devoluciones"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idCuentaCobro As DataGridViewTextBoxColumn
    Friend WithEvents idDocumento As DataGridViewTextBoxColumn
    Friend WithEvents documento As DataGridViewTextBoxColumn
    Friend WithEvents consecutivo As DataGridViewTextBoxColumn
    Friend WithEvents idProveedor As DataGridViewTextBoxColumn
    Friend WithEvents proveedor As DataGridViewTextBoxColumn
    Friend WithEvents idEncargado As DataGridViewTextBoxColumn
    Friend WithEvents encargado As DataGridViewTextBoxColumn
    Friend WithEvents codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents vendedor As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
