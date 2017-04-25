<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContratosOT
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.idContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoSucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.regionUnoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel.Size = New System.Drawing.Size(670, 384)
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idContrato, Me.cliente, Me.codigoSucursal, Me.obra, Me.fechaInicio, Me.fechaFin, Me.metros, Me.vendedor, Me.regionUnoee})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 89)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(666, 291)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'idContrato
        '
        Me.idContrato.HeaderText = "Id contrato"
        Me.idContrato.Name = "idContrato"
        Me.idContrato.ReadOnly = True
        Me.idContrato.Visible = False
        Me.idContrato.Width = 64
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 64
        '
        'codigoSucursal
        '
        Me.codigoSucursal.HeaderText = "Código sucursal"
        Me.codigoSucursal.Name = "codigoSucursal"
        Me.codigoSucursal.ReadOnly = True
        Me.codigoSucursal.Width = 98
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        Me.obra.Width = 55
        '
        'fechaInicio
        '
        DataGridViewCellStyle7.Format = "d"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.fechaInicio.DefaultCellStyle = DataGridViewCellStyle7
        Me.fechaInicio.HeaderText = "Fecha inicio"
        Me.fechaInicio.Name = "fechaInicio"
        Me.fechaInicio.ReadOnly = True
        Me.fechaInicio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaInicio.Width = 63
        '
        'fechaFin
        '
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.fechaFin.DefaultCellStyle = DataGridViewCellStyle8
        Me.fechaFin.HeaderText = "Fecha fin"
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.ReadOnly = True
        Me.fechaFin.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fechaFin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaFin.Width = 51
        '
        'metros
        '
        DataGridViewCellStyle9.Format = "N2"
        Me.metros.DefaultCellStyle = DataGridViewCellStyle9
        Me.metros.HeaderText = "Mt²"
        Me.metros.Name = "metros"
        Me.metros.ReadOnly = True
        Me.metros.Width = 47
        '
        'vendedor
        '
        Me.vendedor.HeaderText = "Vendedor"
        Me.vendedor.Name = "vendedor"
        Me.vendedor.ReadOnly = True
        Me.vendedor.Width = 78
        '
        'regionUnoee
        '
        Me.regionUnoee.HeaderText = "Región"
        Me.regionUnoee.Name = "regionUnoee"
        Me.regionUnoee.ReadOnly = True
        Me.regionUnoee.Width = 66
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(666, 89)
        Me.fddFiltros.TabIndex = 0
        '
        'frmContratosOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 408)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContratosOT"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Lista Contratos"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents idContrato As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents codigoSucursal As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents fechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents fechaFin As DataGridViewTextBoxColumn
    Friend WithEvents metros As DataGridViewTextBoxColumn
    Friend WithEvents vendedor As DataGridViewTextBoxColumn
    Friend WithEvents regionUnoee As DataGridViewTextBoxColumn
End Class
