<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPermisosExtra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisosExtra))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.spgrids = New System.Windows.Forms.SplitContainer()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.dwpermisos = New System.Windows.Forms.DataGridView()
        Me.idpermiso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.permiso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcionpermiso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigopermiso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnagregar = New System.Windows.Forms.ToolStripButton()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtmodulo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudcodigo = New System.Windows.Forms.NumericUpDown()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.spgrids, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spgrids.Panel1.SuspendLayout()
        Me.spgrids.Panel2.SuspendLayout()
        Me.spgrids.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwpermisos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudcodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(15, 55)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 12
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.spgrids)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 81)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(659, 312)
        Me.Panel.TabIndex = 13
        '
        'spgrids
        '
        Me.spgrids.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spgrids.Location = New System.Drawing.Point(0, 73)
        Me.spgrids.Name = "spgrids"
        '
        'spgrids.Panel1
        '
        Me.spgrids.Panel1.Controls.Add(Me.dwItems)
        '
        'spgrids.Panel2
        '
        Me.spgrids.Panel2.Controls.Add(Me.dwpermisos)
        Me.spgrids.Panel2.Controls.Add(Me.tsherramientas)
        Me.spgrids.Size = New System.Drawing.Size(655, 235)
        Me.spgrids.SplitterDistance = 329
        Me.spgrids.TabIndex = 2
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha_creacion, Me.Usuario_creacion, Me.modulo, Me.codigo, Me.Descripcion, Me.Fecha_modificacion, Me.Usuario_modificacion, Me.Id_Estado, Me.Estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 0)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(329, 235)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'dwpermisos
        '
        Me.dwpermisos.AllowUserToAddRows = False
        Me.dwpermisos.BackgroundColor = System.Drawing.Color.White
        Me.dwpermisos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwpermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwpermisos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idpermiso, Me.permiso, Me.descripcionpermiso, Me.codigopermiso})
        Me.dwpermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwpermisos.Location = New System.Drawing.Point(0, 25)
        Me.dwpermisos.Name = "dwpermisos"
        Me.dwpermisos.RowHeadersWidth = 25
        Me.dwpermisos.Size = New System.Drawing.Size(322, 210)
        Me.dwpermisos.TabIndex = 4
        '
        'idpermiso
        '
        Me.idpermiso.HeaderText = "Id"
        Me.idpermiso.Name = "idpermiso"
        Me.idpermiso.Visible = False
        '
        'permiso
        '
        Me.permiso.HeaderText = "Permiso"
        Me.permiso.MaxInputLength = 50
        Me.permiso.Name = "permiso"
        '
        'descripcionpermiso
        '
        Me.descripcionpermiso.HeaderText = "Descripcion"
        Me.descripcionpermiso.MaxInputLength = 255
        Me.descripcionpermiso.Name = "descripcionpermiso"
        '
        'codigopermiso
        '
        Me.codigopermiso.HeaderText = "Codigo"
        Me.codigopermiso.MaxInputLength = 10
        Me.codigopermiso.Name = "codigopermiso"
        Me.codigopermiso.ReadOnly = True
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnagregar})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(322, 25)
        Me.tsherramientas.TabIndex = 3
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnagregar
        '
        Me.btnagregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnagregar.Image = CType(resources.GetObject("btnagregar.Image"), System.Drawing.Image)
        Me.btnagregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(23, 22)
        Me.btnagregar.Text = "ToolStripButton1"
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(655, 73)
        Me.fddFiltros.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Estado"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(221, 16)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(272, 20)
        Me.txtDescripcion.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Descripción"
        '
        'txtmodulo
        '
        Me.txtmodulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmodulo.Location = New System.Drawing.Point(15, 17)
        Me.txtmodulo.MaxLength = 15
        Me.txtmodulo.Name = "txtmodulo"
        Me.txtmodulo.Size = New System.Drawing.Size(192, 20)
        Me.txtmodulo.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Modulo"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(500, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Modulo"
        '
        'nudcodigo
        '
        Me.nudcodigo.Enabled = False
        Me.nudcodigo.Location = New System.Drawing.Point(503, 16)
        Me.nudcodigo.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.nudcodigo.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudcodigo.Name = "nudcodigo"
        Me.nudcodigo.ReadOnly = True
        Me.nudcodigo.Size = New System.Drawing.Size(78, 20)
        Me.nudcodigo.TabIndex = 15
        Me.nudcodigo.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 41
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
        'modulo
        '
        Me.modulo.HeaderText = "Modulo"
        Me.modulo.Name = "modulo"
        Me.modulo.ReadOnly = True
        Me.modulo.Width = 67
        '
        'codigo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.codigo.DefaultCellStyle = DataGridViewCellStyle1
        Me.codigo.HeaderText = "Codigo"
        Me.codigo.Name = "codigo"
        Me.codigo.ReadOnly = True
        Me.codigo.Width = 65
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
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
        'FrmPermisosExtra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 398)
        Me.Controls.Add(Me.nudcodigo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtmodulo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmPermisosExtra"
        Me.ShowIcon = False
        Me.Text = "Permisos Extra"
        Me.Panel.ResumeLayout(False)
        Me.spgrids.Panel1.ResumeLayout(False)
        Me.spgrids.Panel2.ResumeLayout(False)
        Me.spgrids.Panel2.PerformLayout()
        CType(Me.spgrids, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spgrids.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwpermisos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudcodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtmodulo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents nudcodigo As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents spgrids As SplitContainer
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnagregar As ToolStripButton
    Friend WithEvents dwpermisos As DataGridView
    Friend WithEvents idpermiso As DataGridViewTextBoxColumn
    Friend WithEvents permiso As DataGridViewTextBoxColumn
    Friend WithEvents descripcionpermiso As DataGridViewTextBoxColumn
    Friend WithEvents codigopermiso As DataGridViewTextBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_creacion As DataGridViewTextBoxColumn
    Friend WithEvents modulo As DataGridViewTextBoxColumn
    Friend WithEvents codigo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
