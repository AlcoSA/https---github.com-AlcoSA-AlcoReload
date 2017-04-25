<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaOT
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.regionUnoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.objeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.para = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel.Size = New System.Drawing.Size(706, 395)
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idContrato, Me.idDocumento, Me.documento, Me.consecutivo, Me.idProveedor, Me.proveedor, Me.cliente, Me.codigoObra, Me.obra, Me.fechaInicio, Me.fechaFin, Me.metros, Me.vendedor, Me.regionUnoee, Me.objeto, Me.para})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 89)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(702, 302)
        Me.dwItems.TabIndex = 3
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'idContrato
        '
        Me.idContrato.HeaderText = "Id contrato"
        Me.idContrato.Name = "idContrato"
        Me.idContrato.ReadOnly = True
        Me.idContrato.Visible = False
        Me.idContrato.Width = 64
        '
        'idDocumento
        '
        Me.idDocumento.HeaderText = "Id documento"
        Me.idDocumento.Name = "idDocumento"
        Me.idDocumento.ReadOnly = True
        Me.idDocumento.Visible = False
        Me.idDocumento.Width = 78
        '
        'documento
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.documento.DefaultCellStyle = DataGridViewCellStyle7
        Me.documento.HeaderText = "Documento"
        Me.documento.Name = "documento"
        Me.documento.ReadOnly = True
        Me.documento.Visible = False
        Me.documento.Width = 68
        '
        'consecutivo
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.consecutivo.DefaultCellStyle = DataGridViewCellStyle8
        Me.consecutivo.HeaderText = "Consecutivo"
        Me.consecutivo.Name = "consecutivo"
        Me.consecutivo.ReadOnly = True
        Me.consecutivo.Visible = False
        Me.consecutivo.Width = 72
        '
        'idProveedor
        '
        Me.idProveedor.HeaderText = "Id proveedor"
        Me.idProveedor.Name = "idProveedor"
        Me.idProveedor.ReadOnly = True
        Me.idProveedor.Visible = False
        Me.idProveedor.Width = 73
        '
        'proveedor
        '
        Me.proveedor.HeaderText = "Proveedor"
        Me.proveedor.Name = "proveedor"
        Me.proveedor.ReadOnly = True
        Me.proveedor.Width = 81
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 64
        '
        'codigoObra
        '
        Me.codigoObra.HeaderText = "Código obra"
        Me.codigoObra.Name = "codigoObra"
        Me.codigoObra.ReadOnly = True
        Me.codigoObra.Width = 89
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
        DataGridViewCellStyle9.Format = "d"
        Me.fechaInicio.DefaultCellStyle = DataGridViewCellStyle9
        Me.fechaInicio.HeaderText = "Fecha inicio"
        Me.fechaInicio.Name = "fechaInicio"
        Me.fechaInicio.ReadOnly = True
        Me.fechaInicio.Width = 89
        '
        'fechaFin
        '
        DataGridViewCellStyle10.Format = "d"
        Me.fechaFin.DefaultCellStyle = DataGridViewCellStyle10
        Me.fechaFin.HeaderText = "Fecha fin"
        Me.fechaFin.Name = "fechaFin"
        Me.fechaFin.ReadOnly = True
        Me.fechaFin.Width = 76
        '
        'metros
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.metros.DefaultCellStyle = DataGridViewCellStyle11
        Me.metros.HeaderText = "Metros"
        Me.metros.Name = "metros"
        Me.metros.ReadOnly = True
        Me.metros.Width = 64
        '
        'vendedor
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.vendedor.DefaultCellStyle = DataGridViewCellStyle12
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
        'objeto
        '
        Me.objeto.HeaderText = "Objeto"
        Me.objeto.Name = "objeto"
        Me.objeto.ReadOnly = True
        Me.objeto.Visible = False
        Me.objeto.Width = 63
        '
        'para
        '
        Me.para.HeaderText = "Para"
        Me.para.Name = "para"
        Me.para.ReadOnly = True
        Me.para.Visible = False
        Me.para.Width = 54
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(702, 89)
        Me.fddFiltros.TabIndex = 2
        '
        'frmListaOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 419)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaOT"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Cuenta por orden trabajo"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idContrato As DataGridViewTextBoxColumn
    Friend WithEvents idDocumento As DataGridViewTextBoxColumn
    Friend WithEvents documento As DataGridViewTextBoxColumn
    Friend WithEvents consecutivo As DataGridViewTextBoxColumn
    Friend WithEvents idProveedor As DataGridViewTextBoxColumn
    Friend WithEvents proveedor As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents fechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents fechaFin As DataGridViewTextBoxColumn
    Friend WithEvents metros As DataGridViewTextBoxColumn
    Friend WithEvents vendedor As DataGridViewTextBoxColumn
    Friend WithEvents regionUnoee As DataGridViewTextBoxColumn
    Friend WithEvents objeto As DataGridViewTextBoxColumn
    Friend WithEvents para As DataGridViewTextBoxColumn
End Class
