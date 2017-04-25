<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTrabajosItems
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefijo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFamiliaMaterial = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idFamiliaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.familiaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.nudCosto = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prefijo"
        '
        'txtPrefijo
        '
        Me.txtPrefijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrefijo.Location = New System.Drawing.Point(26, 35)
        Me.txtPrefijo.MaxLength = 15
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(100, 20)
        Me.txtPrefijo.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(158, 35)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(276, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(464, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Familia material"
        '
        'cmbFamiliaMaterial
        '
        Me.cmbFamiliaMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFamiliaMaterial.FormattingEnabled = True
        Me.cmbFamiliaMaterial.Location = New System.Drawing.Point(467, 34)
        Me.cmbFamiliaMaterial.Name = "cmbFamiliaMaterial"
        Me.cmbFamiliaMaterial.Size = New System.Drawing.Size(121, 21)
        Me.cmbFamiliaMaterial.TabIndex = 5
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(323, 83)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Estado"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 124)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(593, 347)
        Me.Panel.TabIndex = 12
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.prefijo, Me.descripcion, Me.unidadMedida, Me.idFamiliaMaterial, Me.familiaMaterial, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 110)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(583, 230)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
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
        'prefijo
        '
        Me.prefijo.HeaderText = "Prefijo"
        Me.prefijo.Name = "prefijo"
        Me.prefijo.ReadOnly = True
        Me.prefijo.Width = 61
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'unidadMedida
        '
        Me.unidadMedida.HeaderText = "Unidad medida"
        Me.unidadMedida.Name = "unidadMedida"
        Me.unidadMedida.ReadOnly = True
        Me.unidadMedida.Width = 95
        '
        'idFamiliaMaterial
        '
        Me.idFamiliaMaterial.HeaderText = "Id familia material"
        Me.idFamiliaMaterial.Name = "idFamiliaMaterial"
        Me.idFamiliaMaterial.ReadOnly = True
        Me.idFamiliaMaterial.Visible = False
        Me.idFamiliaMaterial.Width = 103
        '
        'familiaMaterial
        '
        Me.familiaMaterial.HeaderText = "Familia material"
        Me.familiaMaterial.Name = "familiaMaterial"
        Me.familiaMaterial.ReadOnly = True
        Me.familiaMaterial.Width = 95
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Width = 119
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
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
        Me.fddFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(583, 101)
        Me.fddFiltros.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'nudCosto
        '
        Me.nudCosto.DecimalPlaces = 2
        Me.nudCosto.Location = New System.Drawing.Point(183, 84)
        Me.nudCosto.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudCosto.Name = "nudCosto"
        Me.nudCosto.Size = New System.Drawing.Size(100, 20)
        Me.nudCosto.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Costo"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(26, 83)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(121, 21)
        Me.cmbUnidadMedida.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Unidad medida"
        '
        'FrmTrabajosItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 483)
        Me.Controls.Add(Me.cmbUnidadMedida)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudCosto)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbFamiliaMaterial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrefijo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTrabajosItems"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Trabajos items"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrefijo As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbFamiliaMaterial As ComboBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents Label5 As Label
    Friend WithEvents nudCosto As NumericUpDown
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents prefijo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents idFamiliaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents familiaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
