<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddNuevoItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddNuevoItem))
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnAddAcabadosTemp = New System.Windows.Forms.ToolStripButton()
        Me.btnAddEspesoresTemp = New System.Windows.Forms.ToolStripButton()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnAddColoresTemp = New System.Windows.Forms.ToolStripButton()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.lblNivel = New System.Windows.Forms.Label()
        Me.cmbTasaImpuesto = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.nudPerimetro = New System.Windows.Forms.NumericUpDown()
        Me.lblDesperdicio = New System.Windows.Forms.Label()
        Me.lblPerimetro = New System.Windows.Forms.Label()
        Me.nudPorcDesperdicio = New System.Windows.Forms.NumericUpDown()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.lblmmPerimetro = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudPeso = New System.Windows.Forms.NumericUpDown()
        Me.lblgrPeso = New System.Windows.Forms.Label()
        Me.lblporcDesp = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_perimetro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idFamiliaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_familiaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_porcentDesperdicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idTasaImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_tasaImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nudCosto = New System.Windows.Forms.NumericUpDown()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnPrecioVidrio = New System.Windows.Forms.Button()
        Me.btnPrecioPerfil = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsMenu.SuspendLayout()
        CType(Me.nudPerimetro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddAcabadosTemp, Me.btnAddEspesoresTemp, Me.btnGuardar, Me.btnAddColoresTemp})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(716, 25)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.Text = "ToolStrip1"
        '
        'btnAddAcabadosTemp
        '
        Me.btnAddAcabadosTemp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAddAcabadosTemp.Image = CType(resources.GetObject("btnAddAcabadosTemp.Image"), System.Drawing.Image)
        Me.btnAddAcabadosTemp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddAcabadosTemp.Name = "btnAddAcabadosTemp"
        Me.btnAddAcabadosTemp.Size = New System.Drawing.Size(141, 22)
        Me.btnAddAcabadosTemp.Text = "Acabados temporales"
        Me.btnAddAcabadosTemp.Visible = False
        '
        'btnAddEspesoresTemp
        '
        Me.btnAddEspesoresTemp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAddEspesoresTemp.Image = CType(resources.GetObject("btnAddEspesoresTemp.Image"), System.Drawing.Image)
        Me.btnAddEspesoresTemp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddEspesoresTemp.Name = "btnAddEspesoresTemp"
        Me.btnAddEspesoresTemp.Size = New System.Drawing.Size(140, 22)
        Me.btnAddEspesoresTemp.Text = "Espesores temporales"
        Me.btnAddEspesoresTemp.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        Me.btnGuardar.Text = "Guardar"
        '
        'btnAddColoresTemp
        '
        Me.btnAddColoresTemp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAddColoresTemp.Image = CType(resources.GetObject("btnAddColoresTemp.Image"), System.Drawing.Image)
        Me.btnAddColoresTemp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAddColoresTemp.Name = "btnAddColoresTemp"
        Me.btnAddColoresTemp.Size = New System.Drawing.Size(129, 22)
        Me.btnAddColoresTemp.Text = "Colores temporales"
        Me.btnAddColoresTemp.Visible = False
        '
        'cmbNivel
        '
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Location = New System.Drawing.Point(351, 99)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(103, 21)
        Me.cmbNivel.TabIndex = 18
        Me.cmbNivel.Visible = False
        '
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.Location = New System.Drawing.Point(348, 83)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(31, 13)
        Me.lblNivel.TabIndex = 17
        Me.lblNivel.Text = "Nivel"
        Me.lblNivel.Visible = False
        '
        'cmbTasaImpuesto
        '
        Me.cmbTasaImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTasaImpuesto.FormattingEnabled = True
        Me.cmbTasaImpuesto.Location = New System.Drawing.Point(585, 98)
        Me.cmbTasaImpuesto.Name = "cmbTasaImpuesto"
        Me.cmbTasaImpuesto.Size = New System.Drawing.Size(103, 21)
        Me.cmbTasaImpuesto.TabIndex = 23
        Me.cmbTasaImpuesto.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(582, 82)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Tasa de impuesto"
        Me.Label12.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(154, 51)
        Me.txtDescripcion.MaxLength = 99
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(301, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(151, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Descripción"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(235, 99)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(90, 21)
        Me.cmbUnidadMedida.TabIndex = 16
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Location = New System.Drawing.Point(232, 83)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(93, 13)
        Me.lblUnidadMedida.TabIndex = 15
        Me.lblUnidadMedida.Text = "Unidad de medida"
        '
        'nudPerimetro
        '
        Me.nudPerimetro.DecimalPlaces = 2
        Me.nudPerimetro.Location = New System.Drawing.Point(475, 99)
        Me.nudPerimetro.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudPerimetro.Name = "nudPerimetro"
        Me.nudPerimetro.Size = New System.Drawing.Size(69, 20)
        Me.nudPerimetro.TabIndex = 20
        Me.nudPerimetro.Visible = False
        '
        'lblDesperdicio
        '
        Me.lblDesperdicio.AutoSize = True
        Me.lblDesperdicio.Location = New System.Drawing.Point(124, 82)
        Me.lblDesperdicio.Name = "lblDesperdicio"
        Me.lblDesperdicio.Size = New System.Drawing.Size(63, 13)
        Me.lblDesperdicio.TabIndex = 12
        Me.lblDesperdicio.Text = "Desperdicio"
        '
        'lblPerimetro
        '
        Me.lblPerimetro.AutoSize = True
        Me.lblPerimetro.Location = New System.Drawing.Point(472, 82)
        Me.lblPerimetro.Name = "lblPerimetro"
        Me.lblPerimetro.Size = New System.Drawing.Size(53, 13)
        Me.lblPerimetro.TabIndex = 19
        Me.lblPerimetro.Text = "Perímetro"
        Me.lblPerimetro.Visible = False
        '
        'nudPorcDesperdicio
        '
        Me.nudPorcDesperdicio.DecimalPlaces = 2
        Me.nudPorcDesperdicio.Location = New System.Drawing.Point(127, 99)
        Me.nudPorcDesperdicio.Name = "nudPorcDesperdicio"
        Me.nudPorcDesperdicio.Size = New System.Drawing.Size(69, 20)
        Me.nudPorcDesperdicio.TabIndex = 13
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Location = New System.Drawing.Point(24, 51)
        Me.txtReferencia.MaxLength = 50
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(110, 20)
        Me.txtReferencia.TabIndex = 2
        '
        'lblmmPerimetro
        '
        Me.lblmmPerimetro.AutoSize = True
        Me.lblmmPerimetro.Location = New System.Drawing.Point(544, 107)
        Me.lblmmPerimetro.Name = "lblmmPerimetro"
        Me.lblmmPerimetro.Size = New System.Drawing.Size(23, 13)
        Me.lblmmPerimetro.TabIndex = 21
        Me.lblmmPerimetro.Text = "mm"
        Me.lblmmPerimetro.Visible = False
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Location = New System.Drawing.Point(21, 83)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(31, 13)
        Me.lblPeso.TabIndex = 9
        Me.lblPeso.Text = "Peso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Referencia"
        '
        'nudPeso
        '
        Me.nudPeso.DecimalPlaces = 2
        Me.nudPeso.Location = New System.Drawing.Point(24, 99)
        Me.nudPeso.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudPeso.Name = "nudPeso"
        Me.nudPeso.Size = New System.Drawing.Size(69, 20)
        Me.nudPeso.TabIndex = 10
        '
        'lblgrPeso
        '
        Me.lblgrPeso.AutoSize = True
        Me.lblgrPeso.Location = New System.Drawing.Point(92, 105)
        Me.lblgrPeso.Name = "lblgrPeso"
        Me.lblgrPeso.Size = New System.Drawing.Size(13, 13)
        Me.lblgrPeso.TabIndex = 11
        Me.lblgrPeso.Text = "g"
        '
        'lblporcDesp
        '
        Me.lblporcDesp.AutoSize = True
        Me.lblporcDesp.Location = New System.Drawing.Point(194, 107)
        Me.lblporcDesp.Name = "lblporcDesp"
        Me.lblporcDesp.Size = New System.Drawing.Size(15, 13)
        Me.lblporcDesp.TabIndex = 14
        Me.lblporcDesp.Text = "%"
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 137)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(684, 277)
        Me.Panel.TabIndex = 24
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
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_id, Me.item_fechaCreacion, Me.item_usuarioCreacion, Me.item_idCotiza, Me.item_referencia, Me.item_descripcion, Me.item_peso, Me.item_unidadMedida, Me.item_perimetro, Me.item_idNivel, Me.item_nivel, Me.item_idFamiliaMaterial, Me.item_familiaMaterial, Me.item_porcentDesperdicio, Me.item_idTasaImpuesto, Me.item_tasaImpuesto, Me.item_costo, Me.item_usuarioModi, Me.item_fechaModi, Me.item_idEstado, Me.item_estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(674, 267)
        Me.dwItems.TabIndex = 0
        '
        'item_id
        '
        Me.item_id.HeaderText = "Id"
        Me.item_id.Name = "item_id"
        Me.item_id.ReadOnly = True
        Me.item_id.Visible = False
        Me.item_id.Width = 22
        '
        'item_fechaCreacion
        '
        Me.item_fechaCreacion.HeaderText = "Fecha creación"
        Me.item_fechaCreacion.Name = "item_fechaCreacion"
        Me.item_fechaCreacion.ReadOnly = True
        Me.item_fechaCreacion.Visible = False
        Me.item_fechaCreacion.Width = 87
        '
        'item_usuarioCreacion
        '
        Me.item_usuarioCreacion.HeaderText = "Usuario creación"
        Me.item_usuarioCreacion.Name = "item_usuarioCreacion"
        Me.item_usuarioCreacion.ReadOnly = True
        Me.item_usuarioCreacion.Visible = False
        Me.item_usuarioCreacion.Width = 93
        '
        'item_idCotiza
        '
        Me.item_idCotiza.HeaderText = "Id cotiza"
        Me.item_idCotiza.Name = "item_idCotiza"
        Me.item_idCotiza.ReadOnly = True
        Me.item_idCotiza.Visible = False
        Me.item_idCotiza.Width = 53
        '
        'item_referencia
        '
        Me.item_referencia.HeaderText = "Referencia"
        Me.item_referencia.Name = "item_referencia"
        Me.item_referencia.ReadOnly = True
        Me.item_referencia.Width = 84
        '
        'item_descripcion
        '
        Me.item_descripcion.HeaderText = "Descripción"
        Me.item_descripcion.Name = "item_descripcion"
        Me.item_descripcion.ReadOnly = True
        Me.item_descripcion.Width = 88
        '
        'item_peso
        '
        Me.item_peso.HeaderText = "Peso"
        Me.item_peso.Name = "item_peso"
        Me.item_peso.ReadOnly = True
        Me.item_peso.Width = 56
        '
        'item_unidadMedida
        '
        Me.item_unidadMedida.HeaderText = "Unidad medida"
        Me.item_unidadMedida.Name = "item_unidadMedida"
        Me.item_unidadMedida.ReadOnly = True
        Me.item_unidadMedida.Width = 95
        '
        'item_perimetro
        '
        Me.item_perimetro.HeaderText = "Perímetro"
        Me.item_perimetro.Name = "item_perimetro"
        Me.item_perimetro.ReadOnly = True
        Me.item_perimetro.Width = 78
        '
        'item_idNivel
        '
        Me.item_idNivel.HeaderText = "Id nivel"
        Me.item_idNivel.Name = "item_idNivel"
        Me.item_idNivel.ReadOnly = True
        Me.item_idNivel.Visible = False
        Me.item_idNivel.Width = 61
        '
        'item_nivel
        '
        Me.item_nivel.HeaderText = "Nivel"
        Me.item_nivel.Name = "item_nivel"
        Me.item_nivel.ReadOnly = True
        Me.item_nivel.Width = 56
        '
        'item_idFamiliaMaterial
        '
        Me.item_idFamiliaMaterial.HeaderText = "Id familia material"
        Me.item_idFamiliaMaterial.Name = "item_idFamiliaMaterial"
        Me.item_idFamiliaMaterial.ReadOnly = True
        Me.item_idFamiliaMaterial.Visible = False
        Me.item_idFamiliaMaterial.Width = 103
        '
        'item_familiaMaterial
        '
        Me.item_familiaMaterial.HeaderText = "Familia material"
        Me.item_familiaMaterial.Name = "item_familiaMaterial"
        Me.item_familiaMaterial.ReadOnly = True
        Me.item_familiaMaterial.Width = 95
        '
        'item_porcentDesperdicio
        '
        Me.item_porcentDesperdicio.HeaderText = "Porcentaje desperdicio"
        Me.item_porcentDesperdicio.Name = "item_porcentDesperdicio"
        Me.item_porcentDesperdicio.ReadOnly = True
        Me.item_porcentDesperdicio.Width = 128
        '
        'item_idTasaImpuesto
        '
        Me.item_idTasaImpuesto.HeaderText = "Id tasa Impuesto"
        Me.item_idTasaImpuesto.Name = "item_idTasaImpuesto"
        Me.item_idTasaImpuesto.ReadOnly = True
        Me.item_idTasaImpuesto.Visible = False
        Me.item_idTasaImpuesto.Width = 101
        '
        'item_tasaImpuesto
        '
        Me.item_tasaImpuesto.HeaderText = "Tasa impuesto"
        Me.item_tasaImpuesto.Name = "item_tasaImpuesto"
        Me.item_tasaImpuesto.ReadOnly = True
        Me.item_tasaImpuesto.Width = 93
        '
        'item_costo
        '
        Me.item_costo.HeaderText = "Costo"
        Me.item_costo.Name = "item_costo"
        Me.item_costo.ReadOnly = True
        Me.item_costo.Width = 59
        '
        'item_usuarioModi
        '
        Me.item_usuarioModi.HeaderText = "Usuario modificación"
        Me.item_usuarioModi.Name = "item_usuarioModi"
        Me.item_usuarioModi.ReadOnly = True
        Me.item_usuarioModi.Visible = False
        Me.item_usuarioModi.Width = 119
        '
        'item_fechaModi
        '
        Me.item_fechaModi.HeaderText = "Fecha modificación"
        Me.item_fechaModi.Name = "item_fechaModi"
        Me.item_fechaModi.ReadOnly = True
        Me.item_fechaModi.Visible = False
        Me.item_fechaModi.Width = 114
        '
        'item_idEstado
        '
        Me.item_idEstado.HeaderText = "Id estado"
        Me.item_idEstado.Name = "item_idEstado"
        Me.item_idEstado.ReadOnly = True
        Me.item_idEstado.Visible = False
        Me.item_idEstado.Width = 70
        '
        'item_estado
        '
        Me.item_estado.HeaderText = "Estado"
        Me.item_estado.Name = "item_estado"
        Me.item_estado.ReadOnly = True
        Me.item_estado.Width = 65
        '
        'nudCosto
        '
        Me.nudCosto.Location = New System.Drawing.Point(483, 51)
        Me.nudCosto.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudCosto.Name = "nudCosto"
        Me.nudCosto.Size = New System.Drawing.Size(116, 20)
        Me.nudCosto.TabIndex = 6
        Me.nudCosto.Visible = False
        '
        'lblCosto
        '
        Me.lblCosto.AutoSize = True
        Me.lblCosto.Location = New System.Drawing.Point(480, 34)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(34, 13)
        Me.lblCosto.TabIndex = 5
        Me.lblCosto.Text = "Costo"
        Me.lblCosto.Visible = False
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'btnPrecioVidrio
        '
        Me.btnPrecioVidrio.Image = CType(resources.GetObject("btnPrecioVidrio.Image"), System.Drawing.Image)
        Me.btnPrecioVidrio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrecioVidrio.Location = New System.Drawing.Point(574, 37)
        Me.btnPrecioVidrio.Name = "btnPrecioVidrio"
        Me.btnPrecioVidrio.Size = New System.Drawing.Size(99, 34)
        Me.btnPrecioVidrio.TabIndex = 7
        Me.btnPrecioVidrio.Text = "Precio vidrio"
        Me.btnPrecioVidrio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrecioVidrio.UseVisualStyleBackColor = True
        Me.btnPrecioVidrio.Visible = False
        '
        'btnPrecioPerfil
        '
        Me.btnPrecioPerfil.Image = CType(resources.GetObject("btnPrecioPerfil.Image"), System.Drawing.Image)
        Me.btnPrecioPerfil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrecioPerfil.Location = New System.Drawing.Point(575, 37)
        Me.btnPrecioPerfil.Name = "btnPrecioPerfil"
        Me.btnPrecioPerfil.Size = New System.Drawing.Size(99, 34)
        Me.btnPrecioPerfil.TabIndex = 8
        Me.btnPrecioPerfil.Text = "Precio perfil"
        Me.btnPrecioPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrecioPerfil.UseVisualStyleBackColor = True
        Me.btnPrecioPerfil.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 41
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha creación"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 106
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Usuario creación"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 112
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Id cotiza"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 72
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Referencia"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 84
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Descripción"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 88
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Peso"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 56
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Unidad medida"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 95
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Perímetro"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 78
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Id nivel"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 61
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Nivel"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 56
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Id familia material"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 103
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "Familia material"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 95
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Porcentaje desperdicio"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 128
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Id tasa Impuesto"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 101
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Tasa impuesto"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 93
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "Costo"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 59
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.HeaderText = "Usuario modificación"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 119
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Fecha modificación"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        Me.DataGridViewTextBoxColumn19.Width = 114
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Id estado"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        Me.DataGridViewTextBoxColumn20.Width = 70
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Estado"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 65
        '
        'FrmAddNuevoItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 426)
        Me.Controls.Add(Me.nudCosto)
        Me.Controls.Add(Me.lblCosto)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.cmbNivel)
        Me.Controls.Add(Me.lblNivel)
        Me.Controls.Add(Me.cmbTasaImpuesto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUnidadMedida)
        Me.Controls.Add(Me.lblUnidadMedida)
        Me.Controls.Add(Me.nudPerimetro)
        Me.Controls.Add(Me.lblDesperdicio)
        Me.Controls.Add(Me.lblPerimetro)
        Me.Controls.Add(Me.nudPorcDesperdicio)
        Me.Controls.Add(Me.txtReferencia)
        Me.Controls.Add(Me.lblmmPerimetro)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudPeso)
        Me.Controls.Add(Me.lblgrPeso)
        Me.Controls.Add(Me.lblporcDesp)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.btnPrecioVidrio)
        Me.Controls.Add(Me.btnPrecioPerfil)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddNuevoItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar "
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.nudPerimetro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnAddAcabadosTemp As ToolStripButton
    Friend WithEvents btnAddEspesoresTemp As ToolStripButton
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents btnAddColoresTemp As ToolStripButton
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents lblNivel As Label
    Friend WithEvents cmbTasaImpuesto As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents lblUnidadMedida As Label
    Friend WithEvents nudPerimetro As NumericUpDown
    Friend WithEvents lblDesperdicio As Label
    Friend WithEvents lblPerimetro As Label
    Friend WithEvents nudPorcDesperdicio As NumericUpDown
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents lblmmPerimetro As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents nudPeso As NumericUpDown
    Friend WithEvents lblgrPeso As Label
    Friend WithEvents lblporcDesp As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents nudCosto As NumericUpDown
    Friend WithEvents lblCosto As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents btnPrecioVidrio As Button
    Friend WithEvents btnPrecioPerfil As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents item_id As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents item_usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents item_idCotiza As DataGridViewTextBoxColumn
    Friend WithEvents item_referencia As DataGridViewTextBoxColumn
    Friend WithEvents item_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents item_peso As DataGridViewTextBoxColumn
    Friend WithEvents item_unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents item_perimetro As DataGridViewTextBoxColumn
    Friend WithEvents item_idNivel As DataGridViewTextBoxColumn
    Friend WithEvents item_nivel As DataGridViewTextBoxColumn
    Friend WithEvents item_idFamiliaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents item_familiaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents item_porcentDesperdicio As DataGridViewTextBoxColumn
    Friend WithEvents item_idTasaImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents item_tasaImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents item_costo As DataGridViewTextBoxColumn
    Friend WithEvents item_usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents item_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents item_estado As DataGridViewTextBoxColumn
End Class
