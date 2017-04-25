<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListaPrecios
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scPrincipal = New System.Windows.Forms.SplitContainer()
        Me.dwConceptos = New System.Windows.Forms.DataGridView()
        Me.conc_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.conc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conc_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conc_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conc_unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conc_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.conc_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dwPrecios = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbProveedores = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scPrincipal.Panel1.SuspendLayout()
        Me.scPrincipal.Panel2.SuspendLayout()
        Me.scPrincipal.SuspendLayout()
        CType(Me.dwConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Proveedor:"
        '
        'scPrincipal
        '
        Me.scPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.scPrincipal.Location = New System.Drawing.Point(12, 53)
        Me.scPrincipal.Name = "scPrincipal"
        Me.scPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scPrincipal.Panel1
        '
        Me.scPrincipal.Panel1.Controls.Add(Me.dwConceptos)
        '
        'scPrincipal.Panel2
        '
        Me.scPrincipal.Panel2.Controls.Add(Me.dwPrecios)
        Me.scPrincipal.Size = New System.Drawing.Size(1092, 430)
        Me.scPrincipal.SplitterDistance = 179
        Me.scPrincipal.TabIndex = 5
        '
        'dwConceptos
        '
        Me.dwConceptos.AllowUserToAddRows = False
        Me.dwConceptos.AllowUserToDeleteRows = False
        Me.dwConceptos.AllowUserToResizeColumns = False
        Me.dwConceptos.AllowUserToResizeRows = False
        Me.dwConceptos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwConceptos.BackgroundColor = System.Drawing.Color.White
        Me.dwConceptos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.conc_seleccion, Me.conc_id, Me.conc_concepto, Me.conc_descripcion, Me.conc_unidadMedida, Me.conc_precio, Me.conc_porcRetenido})
        Me.dwConceptos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwConceptos.Location = New System.Drawing.Point(3, 3)
        Me.dwConceptos.MultiSelect = False
        Me.dwConceptos.Name = "dwConceptos"
        Me.dwConceptos.RowHeadersVisible = False
        Me.dwConceptos.Size = New System.Drawing.Size(1067, 169)
        Me.dwConceptos.TabIndex = 0
        '
        'conc_seleccion
        '
        Me.conc_seleccion.HeaderText = "Selección"
        Me.conc_seleccion.Name = "conc_seleccion"
        Me.conc_seleccion.Width = 60
        '
        'conc_id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.conc_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.conc_id.HeaderText = "Id concepto"
        Me.conc_id.Name = "conc_id"
        Me.conc_id.ReadOnly = True
        Me.conc_id.Visible = False
        Me.conc_id.Width = 89
        '
        'conc_concepto
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.conc_concepto.DefaultCellStyle = DataGridViewCellStyle2
        Me.conc_concepto.HeaderText = "Concepto"
        Me.conc_concepto.Name = "conc_concepto"
        Me.conc_concepto.ReadOnly = True
        Me.conc_concepto.Width = 78
        '
        'conc_descripcion
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.conc_descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.conc_descripcion.HeaderText = "Descripción"
        Me.conc_descripcion.Name = "conc_descripcion"
        Me.conc_descripcion.ReadOnly = True
        Me.conc_descripcion.Width = 88
        '
        'conc_unidadMedida
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.conc_unidadMedida.DefaultCellStyle = DataGridViewCellStyle4
        Me.conc_unidadMedida.HeaderText = "Unidad medida"
        Me.conc_unidadMedida.Name = "conc_unidadMedida"
        Me.conc_unidadMedida.ReadOnly = True
        Me.conc_unidadMedida.Width = 95
        '
        'conc_precio
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.conc_precio.DefaultCellStyle = DataGridViewCellStyle5
        Me.conc_precio.HeaderText = "Precio"
        Me.conc_precio.Name = "conc_precio"
        Me.conc_precio.Width = 62
        '
        'conc_porcRetenido
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.conc_porcRetenido.DefaultCellStyle = DataGridViewCellStyle6
        Me.conc_porcRetenido.HeaderText = "(%) Retenido"
        Me.conc_porcRetenido.Name = "conc_porcRetenido"
        Me.conc_porcRetenido.Width = 85
        '
        'dwPrecios
        '
        Me.dwPrecios.AllowUserToAddRows = False
        Me.dwPrecios.AllowUserToDeleteRows = False
        Me.dwPrecios.AllowUserToResizeRows = False
        Me.dwPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwPrecios.AutoGenerateColumns = False
        Me.dwPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwPrecios.BackgroundColor = System.Drawing.Color.White
        Me.dwPrecios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.idProveedor, Me.proveedor, Me.idConcepto, Me.concepto, Me.unidadMedida, Me.precio, Me.porcRetenido, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwPrecios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwPrecios.ImageList = Nothing
        Me.dwPrecios.Location = New System.Drawing.Point(3, 3)
        Me.dwPrecios.MostrarFiltros = False
        Me.dwPrecios.MultiSelect = False
        Me.dwPrecios.Name = "dwPrecios"
        Me.dwPrecios.ReadOnly = True
        Me.dwPrecios.RowHeadersVisible = False
        Me.dwPrecios.RowHeadersWidth = 25
        Me.dwPrecios.Size = New System.Drawing.Size(1067, 237)
        Me.dwPrecios.TabIndex = 2
        Me.dwPrecios.TablaDatos = Nothing
        Me.dwPrecios.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'cmbProveedores
        '
        Me.cmbProveedores.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbProveedores.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbProveedores.DropDownHeight = 200
        Me.cmbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedores.DropDownWidth = 300
        Me.cmbProveedores.IntegralHeight = False
        Me.cmbProveedores.Location = New System.Drawing.Point(87, 17)
        Me.cmbProveedores.Name = "cmbProveedores"
        Me.cmbProveedores.Size = New System.Drawing.Size(277, 21)
        Me.cmbProveedores.TabIndex = 6
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
        Me.usuarioCreacion.Width = 103
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
        'idConcepto
        '
        Me.idConcepto.HeaderText = "Id concepto"
        Me.idConcepto.Name = "idConcepto"
        Me.idConcepto.ReadOnly = True
        Me.idConcepto.Visible = False
        Me.idConcepto.Width = 82
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.Width = 78
        '
        'unidadMedida
        '
        Me.unidadMedida.HeaderText = "Unidad medida"
        Me.unidadMedida.Name = "unidadMedida"
        Me.unidadMedida.ReadOnly = True
        Me.unidadMedida.Width = 95
        '
        'precio
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.precio.DefaultCellStyle = DataGridViewCellStyle7
        Me.precio.HeaderText = "Precio"
        Me.precio.Name = "precio"
        Me.precio.ReadOnly = True
        Me.precio.Width = 62
        '
        'porcRetenido
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.porcRetenido.DefaultCellStyle = DataGridViewCellStyle8
        Me.porcRetenido.HeaderText = "(%) Retenido"
        Me.porcRetenido.Name = "porcRetenido"
        Me.porcRetenido.ReadOnly = True
        Me.porcRetenido.Width = 85
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
        'frmListaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1116, 495)
        Me.Controls.Add(Me.cmbProveedores)
        Me.Controls.Add(Me.scPrincipal)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListaPrecios"
        Me.ShowIcon = False
        Me.Text = "Lista precios instalación"
        Me.scPrincipal.Panel1.ResumeLayout(False)
        Me.scPrincipal.Panel2.ResumeLayout(False)
        CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scPrincipal.ResumeLayout(False)
        CType(Me.dwConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents scPrincipal As SplitContainer
    Friend WithEvents dwConceptos As DataGridView
    Friend WithEvents dwPrecios As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents conc_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents conc_id As DataGridViewTextBoxColumn
    Friend WithEvents conc_concepto As DataGridViewTextBoxColumn
    Friend WithEvents conc_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents conc_unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents conc_precio As DataGridViewTextBoxColumn
    Friend WithEvents conc_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents cmbProveedores As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idProveedor As DataGridViewTextBoxColumn
    Friend WithEvents proveedor As DataGridViewTextBoxColumn
    Friend WithEvents idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents concepto As DataGridViewTextBoxColumn
    Friend WithEvents unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
