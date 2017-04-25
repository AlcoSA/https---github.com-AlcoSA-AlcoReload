<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTiposObra
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
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.cbValorDefecto = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbComponente = New System.Windows.Forms.ComboBox()
        Me.cbIVA = New System.Windows.Forms.CheckBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbParaSuministro = New System.Windows.Forms.ComboBox()
        Me.cmbParaInstalacion = New System.Windows.Forms.ComboBox()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idComponente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Componente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorDefecto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tipoImpuesto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idParaSuministro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paraSuministro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idParaInstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paraInstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descripción"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(12, 25)
        Me.txtDescripcion.MaxLength = 50
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(246, 20)
        Me.txtDescripcion.TabIndex = 2
        '
        'cbValorDefecto
        '
        Me.cbValorDefecto.AutoSize = True
        Me.cbValorDefecto.Location = New System.Drawing.Point(160, 108)
        Me.cbValorDefecto.Name = "cbValorDefecto"
        Me.cbValorDefecto.Size = New System.Drawing.Size(107, 17)
        Me.cbValorDefecto.TabIndex = 4
        Me.cbValorDefecto.Tag = ""
        Me.cbValorDefecto.Text = "Valor por defecto"
        Me.cbValorDefecto.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Componente"
        '
        'cmbComponente
        '
        Me.cmbComponente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComponente.FormattingEnabled = True
        Me.cmbComponente.Location = New System.Drawing.Point(12, 64)
        Me.cmbComponente.Name = "cmbComponente"
        Me.cmbComponente.Size = New System.Drawing.Size(246, 21)
        Me.cmbComponente.TabIndex = 6
        '
        'cbIVA
        '
        Me.cbIVA.AutoSize = True
        Me.cbIVA.Location = New System.Drawing.Point(273, 108)
        Me.cbIVA.Name = "cbIVA"
        Me.cbIVA.Size = New System.Drawing.Size(119, 17)
        Me.cbIVA.TabIndex = 7
        Me.cbIVA.Tag = "2"
        Me.cbIVA.Text = "IVA sobre la utilidad"
        Me.cbIVA.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 131)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(569, 237)
        Me.Panel.TabIndex = 8
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.fechaCreacion, Me.usuarioCreacion, Me.descripcion, Me.usuarioModi, Me.fechaModi, Me.idComponente, Me.Componente, Me.idEstado, Me.estado, Me.valorDefecto, Me.tipoImpuesto, Me.idParaSuministro, Me.paraSuministro, Me.idParaInstalacion, Me.paraInstalacion})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 70)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(565, 163)
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
        Me.fddFiltros.Size = New System.Drawing.Size(565, 70)
        Me.fddFiltros.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(12, 104)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(316, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Para Suministro"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(316, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Para Instalacion"
        '
        'cmbParaSuministro
        '
        Me.cmbParaSuministro.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbParaSuministro.FormattingEnabled = True
        Me.cmbParaSuministro.Location = New System.Drawing.Point(319, 24)
        Me.cmbParaSuministro.Name = "cmbParaSuministro"
        Me.cmbParaSuministro.Size = New System.Drawing.Size(246, 21)
        Me.cmbParaSuministro.TabIndex = 13
        '
        'cmbParaInstalacion
        '
        Me.cmbParaInstalacion.FormattingEnabled = True
        Me.cmbParaInstalacion.Location = New System.Drawing.Point(319, 64)
        Me.cmbParaInstalacion.Name = "cmbParaInstalacion"
        Me.cmbParaInstalacion.Size = New System.Drawing.Size(246, 21)
        Me.cmbParaInstalacion.TabIndex = 14
        '
        'Id
        '
        Me.Id.HeaderText = "ID"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 43
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
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modi"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Width = 86
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Width = 114
        '
        'idComponente
        '
        Me.idComponente.HeaderText = "idComponente"
        Me.idComponente.Name = "idComponente"
        Me.idComponente.ReadOnly = True
        Me.idComponente.Visible = False
        '
        'Componente
        '
        Me.Componente.HeaderText = "Componente"
        Me.Componente.Name = "Componente"
        Me.Componente.ReadOnly = True
        Me.Componente.Width = 92
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.idEstado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idEstado.Visible = False
        Me.idEstado.Width = 51
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'valorDefecto
        '
        Me.valorDefecto.HeaderText = "Valor por defecto"
        Me.valorDefecto.Name = "valorDefecto"
        Me.valorDefecto.ReadOnly = True
        Me.valorDefecto.Width = 85
        '
        'tipoImpuesto
        '
        Me.tipoImpuesto.HeaderText = "IVA pleno"
        Me.tipoImpuesto.Name = "tipoImpuesto"
        Me.tipoImpuesto.ReadOnly = True
        Me.tipoImpuesto.Width = 53
        '
        'idParaSuministro
        '
        Me.idParaSuministro.HeaderText = "idParaSuministro"
        Me.idParaSuministro.Name = "idParaSuministro"
        Me.idParaSuministro.ReadOnly = True
        Me.idParaSuministro.Visible = False
        Me.idParaSuministro.Width = 110
        '
        'paraSuministro
        '
        Me.paraSuministro.HeaderText = "Para Suministro"
        Me.paraSuministro.Name = "paraSuministro"
        Me.paraSuministro.ReadOnly = True
        Me.paraSuministro.Width = 96
        '
        'idParaInstalacion
        '
        Me.idParaInstalacion.HeaderText = "idParaInstalacion"
        Me.idParaInstalacion.Name = "idParaInstalacion"
        Me.idParaInstalacion.ReadOnly = True
        Me.idParaInstalacion.Visible = False
        Me.idParaInstalacion.Width = 113
        '
        'paraInstalacion
        '
        Me.paraInstalacion.HeaderText = "Para Instalacion"
        Me.paraInstalacion.Name = "paraInstalacion"
        Me.paraInstalacion.ReadOnly = True
        Me.paraInstalacion.Width = 99
        '
        'FrmTiposObra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 380)
        Me.Controls.Add(Me.cmbParaInstalacion)
        Me.Controls.Add(Me.cmbParaSuministro)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.cbIVA)
        Me.Controls.Add(Me.cmbComponente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbValorDefecto)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmTiposObra"
        Me.ShowIcon = False
        Me.Text = "Tipos obra"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents cbValorDefecto As CheckBox
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents cmbComponente As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbIVA As CheckBox
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbParaInstalacion As ComboBox
    Friend WithEvents cmbParaSuministro As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idComponente As DataGridViewTextBoxColumn
    Friend WithEvents Componente As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents valorDefecto As DataGridViewCheckBoxColumn
    Friend WithEvents tipoImpuesto As DataGridViewCheckBoxColumn
    Friend WithEvents idParaSuministro As DataGridViewTextBoxColumn
    Friend WithEvents paraSuministro As DataGridViewTextBoxColumn
    Friend WithEvents idParaInstalacion As DataGridViewTextBoxColumn
    Friend WithEvents paraInstalacion As DataGridViewTextBoxColumn
End Class
