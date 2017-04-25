<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUsuarios
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
        Me.components = New System.ComponentModel.Container()
        Me.cbunoee = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idunoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unoee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iddepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.departamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbusuario = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbdepartamento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbestado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbgrupo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbunoee
        '
        Me.cbunoee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbunoee.FormattingEnabled = True
        Me.cbunoee.Location = New System.Drawing.Point(216, 25)
        Me.cbunoee.Name = "cbunoee"
        Me.cbunoee.Size = New System.Drawing.Size(200, 21)
        Me.cbunoee.TabIndex = 1
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(15, 106)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(647, 336)
        Me.Panel.TabIndex = 4
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha_creacion, Me.Usuario_creacion, Me.usuario, Me.idunoee, Me.unoee, Me.iddepartamento, Me.departamento, Me.Id_grupo, Me.Grupo, Me.Fecha_modificacion, Me.Usuario_modificacion, Me.Id_Estado, Me.Estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 95)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(643, 237)
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
        'Fecha_creacion
        '
        Me.Fecha_creacion.HeaderText = "Fecha creación"
        Me.Fecha_creacion.Name = "Fecha_creacion"
        Me.Fecha_creacion.ReadOnly = True
        Me.Fecha_creacion.Width = 97
        '
        'Usuario_creacion
        '
        Me.Usuario_creacion.HeaderText = "Usuario creación"
        Me.Usuario_creacion.Name = "Usuario_creacion"
        Me.Usuario_creacion.ReadOnly = True
        Me.Usuario_creacion.Width = 103
        '
        'usuario
        '
        Me.usuario.HeaderText = "Usuario"
        Me.usuario.Name = "usuario"
        Me.usuario.ReadOnly = True
        Me.usuario.Width = 68
        '
        'idunoee
        '
        Me.idunoee.HeaderText = "Id Unoee"
        Me.idunoee.Name = "idunoee"
        Me.idunoee.ReadOnly = True
        Me.idunoee.Visible = False
        Me.idunoee.Width = 70
        '
        'unoee
        '
        Me.unoee.HeaderText = "Unoee"
        Me.unoee.Name = "unoee"
        Me.unoee.ReadOnly = True
        Me.unoee.Width = 64
        '
        'iddepartamento
        '
        Me.iddepartamento.HeaderText = "Id Departamento"
        Me.iddepartamento.Name = "iddepartamento"
        Me.iddepartamento.ReadOnly = True
        Me.iddepartamento.Visible = False
        Me.iddepartamento.Width = 102
        '
        'departamento
        '
        Me.departamento.HeaderText = "Departamento"
        Me.departamento.Name = "departamento"
        Me.departamento.ReadOnly = True
        Me.departamento.Width = 99
        '
        'Id_grupo
        '
        Me.Id_grupo.HeaderText = "Id Grupo"
        Me.Id_grupo.Name = "Id_grupo"
        Me.Id_grupo.ReadOnly = True
        Me.Id_grupo.Visible = False
        Me.Id_grupo.Width = 68
        '
        'Grupo
        '
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 61
        '
        'Fecha_modificacion
        '
        Me.Fecha_modificacion.HeaderText = "Fecha modificación"
        Me.Fecha_modificacion.Name = "Fecha_modificacion"
        Me.Fecha_modificacion.ReadOnly = True
        Me.Fecha_modificacion.Width = 114
        '
        'Usuario_modificacion
        '
        Me.Usuario_modificacion.HeaderText = "Usuario modificación"
        Me.Usuario_modificacion.Name = "Usuario_modificacion"
        Me.Usuario_modificacion.ReadOnly = True
        Me.Usuario_modificacion.Width = 119
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 70
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
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(643, 95)
        Me.fddFiltros.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(213, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Unoee"
        '
        'cbusuario
        '
        Me.cbusuario.FormattingEnabled = True
        Me.cbusuario.Location = New System.Drawing.Point(15, 25)
        Me.cbusuario.Name = "cbusuario"
        Me.cbusuario.Size = New System.Drawing.Size(185, 21)
        Me.cbusuario.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Usuario"
        '
        'cbdepartamento
        '
        Me.cbdepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdepartamento.FormattingEnabled = True
        Me.cbdepartamento.Location = New System.Drawing.Point(15, 65)
        Me.cbdepartamento.Name = "cbdepartamento"
        Me.cbdepartamento.Size = New System.Drawing.Size(185, 21)
        Me.cbdepartamento.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Departamento"
        '
        'cbestado
        '
        Me.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbestado.FormattingEnabled = True
        Me.cbestado.Location = New System.Drawing.Point(429, 65)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(121, 21)
        Me.cbestado.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(426, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Estado"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cbgrupo
        '
        Me.cbgrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbgrupo.FormattingEnabled = True
        Me.cbgrupo.Location = New System.Drawing.Point(216, 65)
        Me.cbgrupo.Name = "cbgrupo"
        Me.cbgrupo.Size = New System.Drawing.Size(200, 21)
        Me.cbgrupo.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(213, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Grupo"
        '
        'FrmUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 454)
        Me.Controls.Add(Me.cbgrupo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbestado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbdepartamento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbusuario)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbunoee)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label3)
        Me.Name = "FrmUsuarios"
        Me.ShowIcon = False
        Me.Text = "Usuarios"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbunoee As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label3 As Label
    Friend WithEvents cbusuario As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbdepartamento As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbestado As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents cbgrupo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_creacion As DataGridViewTextBoxColumn
    Friend WithEvents usuario As DataGridViewTextBoxColumn
    Friend WithEvents idunoee As DataGridViewTextBoxColumn
    Friend WithEvents unoee As DataGridViewTextBoxColumn
    Friend WithEvents iddepartamento As DataGridViewTextBoxColumn
    Friend WithEvents departamento As DataGridViewTextBoxColumn
    Friend WithEvents Id_grupo As DataGridViewTextBoxColumn
    Friend WithEvents Grupo As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
