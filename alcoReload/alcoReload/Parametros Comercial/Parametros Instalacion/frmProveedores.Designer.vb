<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProveedores
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRpteLegal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.itProveedor = New ControlesPersonalizados.Intellisens.intellises()
        Me.itNit = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idSiesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreEstablecimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreContacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idRegionUnoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.regionUnoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtIdSiesa = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nit:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(242, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Proveedor:"
        '
        'txtRpteLegal
        '
        Me.txtRpteLegal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRpteLegal.Location = New System.Drawing.Point(80, 41)
        Me.txtRpteLegal.MaxLength = 50
        Me.txtRpteLegal.Name = "txtRpteLegal"
        Me.txtRpteLegal.Size = New System.Drawing.Size(346, 20)
        Me.txtRpteLegal.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Rpte. legal:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(479, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Zona:"
        '
        'txtDireccion
        '
        Me.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDireccion.Location = New System.Drawing.Point(80, 67)
        Me.txtDireccion.MaxLength = 30
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(212, 20)
        Me.txtDireccion.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Dirección:"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(386, 67)
        Me.txtTelefono.MaxLength = 20
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(100, 20)
        Me.txtTelefono.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(328, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Teléfono:"
        '
        'itProveedor
        '
        Me.itProveedor.AlternativeColumn = "nit"
        Me.itProveedor.ColToReturn = "nombreProveedor"
        Me.itProveedor.ColumnsToFilter = New String() {"nit", "nombreProveedor", "nombreEstablecimiento"}
        Me.itProveedor.ColumnsToShow = New String() {"nit", "nombreProveedor", "nombreEstablecimiento"}
        Me.itProveedor.Dropdown_Width = 500
        Me.itProveedor.Id_Column_Name = "nombreProveedor"
        Me.itProveedor.Location = New System.Drawing.Point(307, 15)
        Me.itProveedor.Maximo_Items_DropDown = 5
        Me.itProveedor.MaxLength = 100
        Me.itProveedor.Name = "itProveedor"
        Me.itProveedor.selected_item = Nothing
        Me.itProveedor.Seleted_rowid = Nothing
        Me.itProveedor.Size = New System.Drawing.Size(334, 20)
        Me.itProveedor.TabIndex = 3
        Me.itProveedor.TablaFuente = Nothing
        Me.itProveedor.Value2 = Nothing
        '
        'itNit
        '
        Me.itNit.AlternativeColumn = "nombreProveedor"
        Me.itNit.ColToReturn = "nit"
        Me.itNit.ColumnsToFilter = New String() {"nit", "nombreProveedor", "nombreEstablecimiento"}
        Me.itNit.ColumnsToShow = New String() {"nit", "nombreProveedor", "nombreEstablecimiento"}
        Me.itNit.Dropdown_Width = 500
        Me.itNit.Id_Column_Name = "nit"
        Me.itNit.Location = New System.Drawing.Point(80, 15)
        Me.itNit.Maximo_Items_DropDown = 5
        Me.itNit.MaxLength = 30
        Me.itNit.Name = "itNit"
        Me.itNit.selected_item = Nothing
        Me.itNit.Seleted_rowid = Nothing
        Me.itNit.Size = New System.Drawing.Size(126, 20)
        Me.itNit.TabIndex = 1
        Me.itNit.TablaFuente = Nothing
        Me.itNit.Value2 = Nothing
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 101)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Estado:"
        '
        'cmbZona
        '
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(520, 40)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(121, 21)
        Me.cmbZona.TabIndex = 7
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(80, 93)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(126, 21)
        Me.cmbEstado.TabIndex = 13
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 130)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(711, 313)
        Me.Panel.TabIndex = 14
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.idSiesa, Me.nit, Me.nombreProveedor, Me.nombreEstablecimiento, Me.nombreContacto, Me.direccion, Me.telefono, Me.idRegionUnoee, Me.regionUnoee, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 89)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(707, 220)
        Me.dwItems.TabIndex = 1
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
        'idSiesa
        '
        Me.idSiesa.HeaderText = "IdSiesa"
        Me.idSiesa.Name = "idSiesa"
        Me.idSiesa.ReadOnly = True
        Me.idSiesa.Width = 67
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 45
        '
        'nombreProveedor
        '
        Me.nombreProveedor.HeaderText = "Proveedor"
        Me.nombreProveedor.Name = "nombreProveedor"
        Me.nombreProveedor.ReadOnly = True
        Me.nombreProveedor.Width = 81
        '
        'nombreEstablecimiento
        '
        Me.nombreEstablecimiento.HeaderText = "Nombre establecimiento"
        Me.nombreEstablecimiento.Name = "nombreEstablecimiento"
        Me.nombreEstablecimiento.ReadOnly = True
        Me.nombreEstablecimiento.Width = 132
        '
        'nombreContacto
        '
        Me.nombreContacto.HeaderText = "Contacto"
        Me.nombreContacto.Name = "nombreContacto"
        Me.nombreContacto.ReadOnly = True
        Me.nombreContacto.Width = 75
        '
        'direccion
        '
        Me.direccion.HeaderText = "Dirección"
        Me.direccion.Name = "direccion"
        Me.direccion.ReadOnly = True
        Me.direccion.Width = 77
        '
        'telefono
        '
        Me.telefono.HeaderText = "Teléfono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        Me.telefono.Width = 74
        '
        'idRegionUnoee
        '
        Me.idRegionUnoee.HeaderText = "Id region"
        Me.idRegionUnoee.Name = "idRegionUnoee"
        Me.idRegionUnoee.ReadOnly = True
        Me.idRegionUnoee.Visible = False
        Me.idRegionUnoee.Width = 68
        '
        'regionUnoee
        '
        Me.regionUnoee.HeaderText = "Región"
        Me.regionUnoee.Name = "regionUnoee"
        Me.regionUnoee.ReadOnly = True
        Me.regionUnoee.Width = 66
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
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(707, 89)
        Me.fddFiltros.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'txtIdSiesa
        '
        Me.txtIdSiesa.Enabled = False
        Me.txtIdSiesa.Location = New System.Drawing.Point(582, 67)
        Me.txtIdSiesa.Name = "txtIdSiesa"
        Me.txtIdSiesa.Size = New System.Drawing.Size(59, 20)
        Me.txtIdSiesa.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(530, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Id siesa:"
        '
        'frmProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 455)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtIdSiesa)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.cmbZona)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.itProveedor)
        Me.Controls.Add(Me.itNit)
        Me.Controls.Add(Me.txtTelefono)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtRpteLegal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProveedores"
        Me.ShowIcon = False
        Me.Text = "Proveedores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRpteLegal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents itProveedor As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents itNit As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbZona As ComboBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents Label8 As Label
    Friend WithEvents txtIdSiesa As TextBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idSiesa As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents nombreProveedor As DataGridViewTextBoxColumn
    Friend WithEvents nombreEstablecimiento As DataGridViewTextBoxColumn
    Friend WithEvents nombreContacto As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents idRegionUnoee As DataGridViewTextBoxColumn
    Friend WithEvents regionUnoee As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
