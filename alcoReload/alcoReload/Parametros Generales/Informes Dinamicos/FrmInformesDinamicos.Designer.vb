<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInformesDinamicos
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
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreSP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombresp = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmbmodulo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(277, 65)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(162, 21)
        Me.cmbEstado.TabIndex = 12
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel.Location = New System.Drawing.Point(0, 0)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(596, 317)
        Me.Panel.TabIndex = 13
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaCreacion, Me.UsuarioCreacion, Me.IdModulo, Me.Modulo, Me.nombre, Me.NombreSP, Me.FechaModificacion, Me.UsuarioModificacion, Me.IdEstado, Me.Estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 95)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(592, 218)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 22
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.Width = 97
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.Width = 103
        '
        'IdModulo
        '
        Me.IdModulo.HeaderText = "IdModulo"
        Me.IdModulo.Name = "IdModulo"
        Me.IdModulo.ReadOnly = True
        Me.IdModulo.Visible = False
        Me.IdModulo.Width = 76
        '
        'Modulo
        '
        Me.Modulo.HeaderText = "Modulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.ReadOnly = True
        Me.Modulo.Visible = False
        Me.Modulo.Width = 67
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre Visible"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 94
        '
        'NombreSP
        '
        Me.NombreSP.HeaderText = "Nombre SP"
        Me.NombreSP.Name = "NombreSP"
        Me.NombreSP.ReadOnly = True
        Me.NombreSP.Width = 79
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha modificación"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.ReadOnly = True
        Me.FechaModificacion.Width = 114
        '
        'UsuarioModificacion
        '
        Me.UsuarioModificacion.HeaderText = "Usuario modificación"
        Me.UsuarioModificacion.Name = "UsuarioModificacion"
        Me.UsuarioModificacion.ReadOnly = True
        Me.UsuarioModificacion.Width = 119
        '
        'IdEstado
        '
        Me.IdEstado.HeaderText = "Id estado"
        Me.IdEstado.Name = "IdEstado"
        Me.IdEstado.ReadOnly = True
        Me.IdEstado.Visible = False
        Me.IdEstado.Width = 70
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Nothing
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(592, 95)
        Me.fddFiltros.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(274, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Estado"
        '
        'txtnombresp
        '
        Me.txtnombresp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombresp.Location = New System.Drawing.Point(6, 65)
        Me.txtnombresp.MaxLength = 30
        Me.txtnombresp.Name = "txtnombresp"
        Me.txtnombresp.Size = New System.Drawing.Size(222, 20)
        Me.txtnombresp.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Nombre SP"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(6, 26)
        Me.txtnombre.MaxLength = 15
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(222, 20)
        Me.txtnombre.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nombre para Mostrar"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbmodulo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cmbEstado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtnombre)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtnombresp)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel)
        Me.SplitContainer1.Size = New System.Drawing.Size(596, 416)
        Me.SplitContainer1.SplitterDistance = 95
        Me.SplitContainer1.TabIndex = 14
        '
        'cmbmodulo
        '
        Me.cmbmodulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmodulo.FormattingEnabled = True
        Me.cmbmodulo.Location = New System.Drawing.Point(277, 25)
        Me.cmbmodulo.Name = "cmbmodulo"
        Me.cmbmodulo.Size = New System.Drawing.Size(162, 21)
        Me.cmbmodulo.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(274, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Modulo"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmInformesDinamicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 416)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmInformesDinamicos"
        Me.ShowIcon = False
        Me.Text = "Informes Dinamicos"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label3 As Label
    Friend WithEvents txtnombresp As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents cmbmodulo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents IdModulo As DataGridViewTextBoxColumn
    Friend WithEvents Modulo As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents NombreSP As DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModificacion As DataGridViewTextBoxColumn
    Friend WithEvents IdEstado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
