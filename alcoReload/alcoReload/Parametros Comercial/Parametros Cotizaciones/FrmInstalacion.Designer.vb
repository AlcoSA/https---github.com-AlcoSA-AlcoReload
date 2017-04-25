<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInstalacion
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudValor = New System.Windows.Forms.NumericUpDown()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cbValorPorDefecto = New System.Windows.Forms.CheckBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.id_ManoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Dpto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_Pais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad_Medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Modi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_modi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor_Defecto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.nudValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(12, 25)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(306, 20)
        Me.txtDescripcion.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Unidad de medida"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(12, 104)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(121, 21)
        Me.cmbUnidadMedida.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(156, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Valor"
        '
        'nudValor
        '
        Me.nudValor.Location = New System.Drawing.Point(159, 104)
        Me.nudValor.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudValor.Name = "nudValor"
        Me.nudValor.Size = New System.Drawing.Size(158, 20)
        Me.nudValor.TabIndex = 11
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cbValorPorDefecto
        '
        Me.cbValorPorDefecto.AutoSize = True
        Me.cbValorPorDefecto.Location = New System.Drawing.Point(159, 149)
        Me.cbValorPorDefecto.Name = "cbValorPorDefecto"
        Me.cbValorPorDefecto.Size = New System.Drawing.Size(107, 17)
        Me.cbValorPorDefecto.TabIndex = 14
        Me.cbValorPorDefecto.Tag = ""
        Me.cbValorPorDefecto.Text = "Valor por defecto"
        Me.cbValorPorDefecto.UseVisualStyleBackColor = True
        '
        'cmbPais
        '
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(12, 64)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(121, 21)
        Me.cmbPais.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "País"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(158, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Departamento"
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.Enabled = False
        Me.cmbDepartamento.FormattingEnabled = True
        Me.cmbDepartamento.Location = New System.Drawing.Point(161, 64)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(121, 21)
        Me.cmbDepartamento.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(309, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ciudad"
        '
        'cmbCiudad
        '
        Me.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCiudad.Enabled = False
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(312, 64)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(121, 21)
        Me.cmbCiudad.TabIndex = 7
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 172)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(534, 201)
        Me.Panel.TabIndex = 15
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_ManoObra, Me.Fecha_Creacion, Me.Usuario_Creacion, Me.Descripcion, Me.Id_Ciudad, Me.Ciudad, Me.Id_Dpto, Me.id_Pais, Me.Unidad_Medida, Me.Valor, Me.Usuario_Modi, Me.Fecha_modi, Me.Id_Estado, Me.Estado, Me.valor_Defecto})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 77)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(530, 120)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(530, 77)
        Me.fddFiltros.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(12, 145)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 13
        '
        'id_ManoObra
        '
        Me.id_ManoObra.HeaderText = "Id"
        Me.id_ManoObra.Name = "id_ManoObra"
        Me.id_ManoObra.ReadOnly = True
        Me.id_ManoObra.Visible = False
        Me.id_ManoObra.Width = 41
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        Me.Fecha_Creacion.Width = 97
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        Me.Usuario_Creacion.Width = 103
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Id_Ciudad
        '
        Me.Id_Ciudad.HeaderText = "Id Ciudad"
        Me.Id_Ciudad.Name = "Id_Ciudad"
        Me.Id_Ciudad.ReadOnly = True
        Me.Id_Ciudad.Visible = False
        Me.Id_Ciudad.Width = 71
        '
        'Ciudad
        '
        Me.Ciudad.HeaderText = "Ciudad"
        Me.Ciudad.Name = "Ciudad"
        Me.Ciudad.ReadOnly = True
        Me.Ciudad.Width = 65
        '
        'Id_Dpto
        '
        Me.Id_Dpto.HeaderText = "Id Dpto"
        Me.Id_Dpto.Name = "Id_Dpto"
        Me.Id_Dpto.ReadOnly = True
        Me.Id_Dpto.Visible = False
        Me.Id_Dpto.Width = 62
        '
        'id_Pais
        '
        Me.id_Pais.HeaderText = "Id Pais"
        Me.id_Pais.Name = "id_Pais"
        Me.id_Pais.ReadOnly = True
        Me.id_Pais.Visible = False
        Me.id_Pais.Width = 60
        '
        'Unidad_Medida
        '
        Me.Unidad_Medida.HeaderText = "Unidad de medida"
        Me.Unidad_Medida.Name = "Unidad_Medida"
        Me.Unidad_Medida.ReadOnly = True
        Me.Unidad_Medida.Width = 108
        '
        'Valor
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C0"
        Me.Valor.DefaultCellStyle = DataGridViewCellStyle1
        Me.Valor.HeaderText = "Valor"
        Me.Valor.Name = "Valor"
        Me.Valor.ReadOnly = True
        Me.Valor.Width = 56
        '
        'Usuario_Modi
        '
        Me.Usuario_Modi.HeaderText = "Usuario modificación"
        Me.Usuario_Modi.Name = "Usuario_Modi"
        Me.Usuario_Modi.ReadOnly = True
        Me.Usuario_Modi.Width = 119
        '
        'Fecha_modi
        '
        Me.Fecha_modi.HeaderText = "Fecha modificación"
        Me.Fecha_modi.Name = "Fecha_modi"
        Me.Fecha_modi.ReadOnly = True
        Me.Fecha_modi.Width = 114
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Id_Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 51
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'valor_Defecto
        '
        Me.valor_Defecto.HeaderText = "Valor por defecto"
        Me.valor_Defecto.Name = "valor_Defecto"
        Me.valor_Defecto.ReadOnly = True
        Me.valor_Defecto.Width = 85
        '
        'FrmInstalacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 385)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCiudad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbDepartamento)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPais)
        Me.Controls.Add(Me.cbValorPorDefecto)
        Me.Controls.Add(Me.nudValor)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbUnidadMedida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmInstalacion"
        Me.ShowIcon = False
        Me.Text = " Instalación"
        CType(Me.nudValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents nudValor As NumericUpDown
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents cbValorPorDefecto As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbPais As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCiudad As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbDepartamento As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents id_ManoObra As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Ciudad As DataGridViewTextBoxColumn
    Friend WithEvents Ciudad As DataGridViewTextBoxColumn
    Friend WithEvents Id_Dpto As DataGridViewTextBoxColumn
    Friend WithEvents id_Pais As DataGridViewTextBoxColumn
    Friend WithEvents Unidad_Medida As DataGridViewTextBoxColumn
    Friend WithEvents Valor As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Modi As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_modi As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents valor_Defecto As DataGridViewCheckBoxColumn
End Class
