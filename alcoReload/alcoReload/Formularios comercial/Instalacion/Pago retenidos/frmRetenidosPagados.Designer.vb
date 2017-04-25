<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetenidosPagados
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
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New DatagridTreeView.DataTreeGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.col_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.col_idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_proveedorObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEncargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_encargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEstadoImpresion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_estadoImpresion = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(852, 442)
        Me.Panel.TabIndex = 0
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_idDocumento, Me.col_documento, Me.col_consecutivo, Me.col_fechaCreacion, Me.col_idProveedor, Me.col_proveedorObra, Me.col_idEncargado, Me.col_encargado, Me.col_valorPagado, Me.col_idEstado, Me.col_estado, Me.col_idEstadoImpresion, Me.col_estadoImpresion})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.RowHeadersWidth = 20
        Me.dwItems.Size = New System.Drawing.Size(842, 432)
        Me.dwItems.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(644, 470)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Total pagado:"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(723, 463)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(136, 20)
        Me.txtTotal.TabIndex = 3
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.ImagenporDefecto = Nothing
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Width = 41
        '
        'col_idDocumento
        '
        Me.col_idDocumento.HeaderText = "Id documento"
        Me.col_idDocumento.Name = "col_idDocumento"
        Me.col_idDocumento.ReadOnly = True
        Me.col_idDocumento.Visible = False
        Me.col_idDocumento.Width = 97
        '
        'col_documento
        '
        Me.col_documento.HeaderText = "Documento"
        Me.col_documento.Name = "col_documento"
        Me.col_documento.ReadOnly = True
        Me.col_documento.Width = 87
        '
        'col_consecutivo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.col_consecutivo.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_consecutivo.HeaderText = "Consecutivo"
        Me.col_consecutivo.Name = "col_consecutivo"
        Me.col_consecutivo.ReadOnly = True
        Me.col_consecutivo.Width = 91
        '
        'col_fechaCreacion
        '
        DataGridViewCellStyle2.Format = "dd/mm/yyyy"
        Me.col_fechaCreacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_fechaCreacion.HeaderText = "Fecha creación"
        Me.col_fechaCreacion.Name = "col_fechaCreacion"
        Me.col_fechaCreacion.ReadOnly = True
        Me.col_fechaCreacion.Width = 106
        '
        'col_idProveedor
        '
        Me.col_idProveedor.HeaderText = "Id proveedor"
        Me.col_idProveedor.Name = "col_idProveedor"
        Me.col_idProveedor.ReadOnly = True
        Me.col_idProveedor.Visible = False
        Me.col_idProveedor.Width = 92
        '
        'col_proveedorObra
        '
        Me.col_proveedorObra.HeaderText = "Proveedor/Obra"
        Me.col_proveedorObra.Name = "col_proveedorObra"
        Me.col_proveedorObra.ReadOnly = True
        Me.col_proveedorObra.Width = 109
        '
        'col_idEncargado
        '
        Me.col_idEncargado.HeaderText = "Id encargado"
        Me.col_idEncargado.Name = "col_idEncargado"
        Me.col_idEncargado.ReadOnly = True
        Me.col_idEncargado.Visible = False
        Me.col_idEncargado.Width = 95
        '
        'col_encargado
        '
        Me.col_encargado.HeaderText = "Encargado"
        Me.col_encargado.Name = "col_encargado"
        Me.col_encargado.ReadOnly = True
        Me.col_encargado.Width = 84
        '
        'col_valorPagado
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.col_valorPagado.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_valorPagado.HeaderText = "Valor pagado"
        Me.col_valorPagado.Name = "col_valorPagado"
        Me.col_valorPagado.ReadOnly = True
        Me.col_valorPagado.Width = 95
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
        'col_idEstadoImpresion
        '
        Me.col_idEstadoImpresion.HeaderText = "Id estado impresion"
        Me.col_idEstadoImpresion.Name = "col_idEstadoImpresion"
        Me.col_idEstadoImpresion.ReadOnly = True
        Me.col_idEstadoImpresion.Visible = False
        Me.col_idEstadoImpresion.Width = 123
        '
        'col_estadoImpresion
        '
        Me.col_estadoImpresion.HeaderText = "Estado impresión"
        Me.col_estadoImpresion.Name = "col_estadoImpresion"
        Me.col_estadoImpresion.ReadOnly = True
        Me.col_estadoImpresion.Width = 112
        '
        'frmRetenidosPagados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 504)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRetenidosPagados"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Retenidos pagados"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DatagridTreeView.DataTreeGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents col_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents col_idDocumento As DataGridViewTextBoxColumn
    Friend WithEvents col_documento As DataGridViewTextBoxColumn
    Friend WithEvents col_consecutivo As DataGridViewTextBoxColumn
    Friend WithEvents col_fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents col_idProveedor As DataGridViewTextBoxColumn
    Friend WithEvents col_proveedorObra As DataGridViewTextBoxColumn
    Friend WithEvents col_idEncargado As DataGridViewTextBoxColumn
    Friend WithEvents col_encargado As DataGridViewTextBoxColumn
    Friend WithEvents col_valorPagado As DataGridViewTextBoxColumn
    Friend WithEvents col_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents col_estado As DataGridViewTextBoxColumn
    Friend WithEvents col_idEstadoImpresion As DataGridViewTextBoxColumn
    Friend WithEvents col_estadoImpresion As DataGridViewTextBoxColumn
End Class
