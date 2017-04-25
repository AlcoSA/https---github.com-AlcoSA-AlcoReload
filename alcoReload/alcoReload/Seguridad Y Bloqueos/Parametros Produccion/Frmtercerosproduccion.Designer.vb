<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmtercerosproduccion
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
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(265, 34)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 13
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltrado)
        Me.Panel.Location = New System.Drawing.Point(6, 73)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(484, 349)
        Me.Panel.TabIndex = 14
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Fecha_creacion, Me.Usuario_creacion, Me.tercero, Me.direccion, Me.telefono, Me.Usuario_modificacion, Me.Fecha_modificacion, Me.Id_estado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 97)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(480, 248)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Width = 22
        '
        'Fecha_creacion
        '
        Me.Fecha_creacion.HeaderText = "Fecha Creacion"
        Me.Fecha_creacion.Name = "Fecha_creacion"
        Me.Fecha_creacion.ReadOnly = True
        Me.Fecha_creacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha_creacion.Width = 79
        '
        'Usuario_creacion
        '
        Me.Usuario_creacion.HeaderText = "Usuario Creacion"
        Me.Usuario_creacion.Name = "Usuario_creacion"
        Me.Usuario_creacion.ReadOnly = True
        Me.Usuario_creacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Usuario_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Usuario_creacion.Width = 85
        '
        'tercero
        '
        Me.tercero.HeaderText = "Tercero"
        Me.tercero.Name = "tercero"
        Me.tercero.ReadOnly = True
        Me.tercero.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.tercero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tercero.Width = 50
        '
        'direccion
        '
        Me.direccion.HeaderText = "Direccion"
        Me.direccion.Name = "direccion"
        Me.direccion.ReadOnly = True
        Me.direccion.Width = 77
        '
        'telefono
        '
        Me.telefono.HeaderText = "Telefono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        Me.telefono.Width = 74
        '
        'Usuario_modificacion
        '
        Me.Usuario_modificacion.HeaderText = "Usuario Modificacion"
        Me.Usuario_modificacion.Name = "Usuario_modificacion"
        Me.Usuario_modificacion.ReadOnly = True
        Me.Usuario_modificacion.Width = 120
        '
        'Fecha_modificacion
        '
        Me.Fecha_modificacion.HeaderText = "Fecha Modificacion"
        Me.Fecha_modificacion.Name = "Fecha_modificacion"
        Me.Fecha_modificacion.ReadOnly = True
        Me.Fecha_modificacion.Width = 114
        '
        'Id_estado
        '
        Me.Id_estado.HeaderText = "id Estado"
        Me.Id_estado.Name = "Id_estado"
        Me.Id_estado.ReadOnly = True
        Me.Id_estado.Visible = False
        Me.Id_estado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltrado.Grid = Me.dwItems
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(480, 97)
        Me.fddFiltrado.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Estado:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(51, 6)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(121, 20)
        Me.txtDescripcion.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Tercero:"
        '
        'txttelefono
        '
        Me.txttelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttelefono.Location = New System.Drawing.Point(265, 6)
        Me.txttelefono.MaxLength = 30
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(121, 20)
        Me.txttelefono.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(208, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Telefono:"
        '
        'txtdireccion
        '
        Me.txtdireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdireccion.Location = New System.Drawing.Point(51, 35)
        Me.txtdireccion.MaxLength = 50
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(121, 20)
        Me.txtdireccion.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Dirección:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Frmtercerosproduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 434)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Frmtercerosproduccion"
        Me.ShowIcon = False
        Me.Text = "Terceros Producción"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txttelefono As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdireccion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_creacion As DataGridViewTextBoxColumn
    Friend WithEvents tercero As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_estado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
