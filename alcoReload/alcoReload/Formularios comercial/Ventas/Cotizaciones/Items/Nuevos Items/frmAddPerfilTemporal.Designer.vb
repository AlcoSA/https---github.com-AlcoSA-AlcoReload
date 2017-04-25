<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPerfilTemporal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddPerfilTemporal))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.item_usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.lblNivel = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.nudPerimetro = New System.Windows.Forms.NumericUpDown()
        Me.lblDesperdicio = New System.Windows.Forms.Label()
        Me.lblPerimetro = New System.Windows.Forms.Label()
        Me.nudPorcDesperdicio = New System.Windows.Forms.NumericUpDown()
        Me.lblmmPerimetro = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudPeso = New System.Windows.Forms.NumericUpDown()
        Me.lblgrPeso = New System.Windows.Forms.Label()
        Me.lblporcDesp = New System.Windows.Forms.Label()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.btnLimpiar = New System.Windows.Forms.ToolStripButton()
        Me.gbInfoPerfil = New System.Windows.Forms.GroupBox()
        Me.itPerfil = New ControlesPersonalizados.Intellisens.intellises()
        Me.gbPerfiles = New System.Windows.Forms.GroupBox()
        Me.btnAgregarAcabado = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAcabado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.gbPreciosPerfil = New System.Windows.Forms.GroupBox()
        Me.dwPrecios = New System.Windows.Forms.DataGridView()
        Me.prec_idCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_perfilTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.prec_idPerfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_perfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_acabadoTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.prec_idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_acabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_idCostoAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_idCostoNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_idCostoAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prec_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPerimetro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.gbInfoPerfil.SuspendLayout()
        Me.gbPerfiles.SuspendLayout()
        Me.gbPreciosPerfil.SuspendLayout()
        CType(Me.dwPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_id, Me.item_fechaCreacion, Me.item_usuarioCreacion, Me.item_idCotiza, Me.item_referencia, Me.item_descripcion, Me.item_peso, Me.item_unidadMedida, Me.item_perimetro, Me.item_idNivel, Me.item_nivel, Me.item_idFamiliaMaterial, Me.item_familiaMaterial, Me.item_porcentDesperdicio, Me.item_idTasaImpuesto, Me.item_tasaImpuesto, Me.item_usuarioModi, Me.item_fechaModi, Me.item_idEstado, Me.item_estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 19)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(586, 162)
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
        'cmbNivel
        '
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Location = New System.Drawing.Point(351, 90)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(103, 21)
        Me.cmbNivel.TabIndex = 13
        '
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.Location = New System.Drawing.Point(348, 73)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(31, 13)
        Me.lblNivel.TabIndex = 12
        Me.lblNivel.Text = "Nivel"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(153, 41)
        Me.txtDescripcion.MaxLength = 99
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(301, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(150, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(229, 90)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(90, 21)
        Me.cmbUnidadMedida.TabIndex = 11
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Location = New System.Drawing.Point(226, 74)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(93, 13)
        Me.lblUnidadMedida.TabIndex = 10
        Me.lblUnidadMedida.Text = "Unidad de medida"
        '
        'nudPerimetro
        '
        Me.nudPerimetro.DecimalPlaces = 2
        Me.nudPerimetro.Location = New System.Drawing.Point(486, 90)
        Me.nudPerimetro.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudPerimetro.Name = "nudPerimetro"
        Me.nudPerimetro.Size = New System.Drawing.Size(69, 20)
        Me.nudPerimetro.TabIndex = 15
        '
        'lblDesperdicio
        '
        Me.lblDesperdicio.AutoSize = True
        Me.lblDesperdicio.Location = New System.Drawing.Point(126, 73)
        Me.lblDesperdicio.Name = "lblDesperdicio"
        Me.lblDesperdicio.Size = New System.Drawing.Size(63, 13)
        Me.lblDesperdicio.TabIndex = 7
        Me.lblDesperdicio.Text = "Desperdicio"
        '
        'lblPerimetro
        '
        Me.lblPerimetro.AutoSize = True
        Me.lblPerimetro.Location = New System.Drawing.Point(483, 73)
        Me.lblPerimetro.Name = "lblPerimetro"
        Me.lblPerimetro.Size = New System.Drawing.Size(53, 13)
        Me.lblPerimetro.TabIndex = 14
        Me.lblPerimetro.Text = "Perímetro"
        '
        'nudPorcDesperdicio
        '
        Me.nudPorcDesperdicio.DecimalPlaces = 2
        Me.nudPorcDesperdicio.Location = New System.Drawing.Point(129, 90)
        Me.nudPorcDesperdicio.Name = "nudPorcDesperdicio"
        Me.nudPorcDesperdicio.Size = New System.Drawing.Size(69, 20)
        Me.nudPorcDesperdicio.TabIndex = 8
        '
        'lblmmPerimetro
        '
        Me.lblmmPerimetro.AutoSize = True
        Me.lblmmPerimetro.Location = New System.Drawing.Point(555, 98)
        Me.lblmmPerimetro.Name = "lblmmPerimetro"
        Me.lblmmPerimetro.Size = New System.Drawing.Size(23, 13)
        Me.lblmmPerimetro.TabIndex = 16
        Me.lblmmPerimetro.Text = "mm"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.Location = New System.Drawing.Point(21, 74)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(31, 13)
        Me.lblPeso.TabIndex = 4
        Me.lblPeso.Text = "Peso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Referencia"
        '
        'nudPeso
        '
        Me.nudPeso.DecimalPlaces = 2
        Me.nudPeso.Location = New System.Drawing.Point(24, 90)
        Me.nudPeso.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudPeso.Name = "nudPeso"
        Me.nudPeso.Size = New System.Drawing.Size(69, 20)
        Me.nudPeso.TabIndex = 5
        '
        'lblgrPeso
        '
        Me.lblgrPeso.AutoSize = True
        Me.lblgrPeso.Location = New System.Drawing.Point(92, 96)
        Me.lblgrPeso.Name = "lblgrPeso"
        Me.lblgrPeso.Size = New System.Drawing.Size(13, 13)
        Me.lblgrPeso.TabIndex = 6
        Me.lblgrPeso.Text = "g"
        '
        'lblporcDesp
        '
        Me.lblporcDesp.AutoSize = True
        Me.lblporcDesp.Location = New System.Drawing.Point(196, 98)
        Me.lblporcDesp.Name = "lblporcDesp"
        Me.lblporcDesp.Size = New System.Drawing.Size(15, 13)
        Me.lblporcDesp.TabIndex = 9
        Me.lblporcDesp.Text = "%"
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.btnLimpiar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(622, 25)
        Me.tsMenu.TabIndex = 0
        Me.tsMenu.Text = "ToolStrip1"
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
        'btnLimpiar
        '
        Me.btnLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
        Me.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(23, 22)
        Me.btnLimpiar.Text = "Limpiar"
        '
        'gbInfoPerfil
        '
        Me.gbInfoPerfil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbInfoPerfil.Controls.Add(Me.itPerfil)
        Me.gbInfoPerfil.Controls.Add(Me.Label1)
        Me.gbInfoPerfil.Controls.Add(Me.txtDescripcion)
        Me.gbInfoPerfil.Controls.Add(Me.Label2)
        Me.gbInfoPerfil.Controls.Add(Me.cmbNivel)
        Me.gbInfoPerfil.Controls.Add(Me.lblNivel)
        Me.gbInfoPerfil.Controls.Add(Me.nudPerimetro)
        Me.gbInfoPerfil.Controls.Add(Me.lblPerimetro)
        Me.gbInfoPerfil.Controls.Add(Me.nudPeso)
        Me.gbInfoPerfil.Controls.Add(Me.lblmmPerimetro)
        Me.gbInfoPerfil.Controls.Add(Me.lblgrPeso)
        Me.gbInfoPerfil.Controls.Add(Me.lblPeso)
        Me.gbInfoPerfil.Controls.Add(Me.nudPorcDesperdicio)
        Me.gbInfoPerfil.Controls.Add(Me.cmbUnidadMedida)
        Me.gbInfoPerfil.Controls.Add(Me.lblUnidadMedida)
        Me.gbInfoPerfil.Controls.Add(Me.lblporcDesp)
        Me.gbInfoPerfil.Controls.Add(Me.lblDesperdicio)
        Me.gbInfoPerfil.Location = New System.Drawing.Point(12, 28)
        Me.gbInfoPerfil.Name = "gbInfoPerfil"
        Me.gbInfoPerfil.Size = New System.Drawing.Size(598, 132)
        Me.gbInfoPerfil.TabIndex = 1
        Me.gbInfoPerfil.TabStop = False
        Me.gbInfoPerfil.Text = "Información perfil"
        '
        'itPerfil
        '
        Me.itPerfil.AlternativeColumn = Nothing
        Me.itPerfil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.itPerfil.ColToReturn = "Referencia"
        Me.itPerfil.ColumnsToFilter = New String() {"Referencia", "Descripcion"}
        Me.itPerfil.ColumnsToShow = New String() {"Referencia", "Descripcion"}
        Me.itPerfil.Dropdown_Width = 250
        Me.itPerfil.Id_Column_Name = "Id"
        Me.itPerfil.Location = New System.Drawing.Point(23, 41)
        Me.itPerfil.Maximo_Items_DropDown = 5
        Me.itPerfil.MaxLength = 30
        Me.itPerfil.Name = "itPerfil"
        Me.itPerfil.selected_item = Nothing
        Me.itPerfil.Seleted_rowid = Nothing
        Me.itPerfil.Size = New System.Drawing.Size(102, 20)
        Me.itPerfil.TabIndex = 1
        Me.itPerfil.TablaFuente = Nothing
        Me.itPerfil.Value2 = Nothing
        '
        'gbPerfiles
        '
        Me.gbPerfiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPerfiles.Controls.Add(Me.dwItems)
        Me.gbPerfiles.Location = New System.Drawing.Point(12, 209)
        Me.gbPerfiles.Name = "gbPerfiles"
        Me.gbPerfiles.Size = New System.Drawing.Size(598, 187)
        Me.gbPerfiles.TabIndex = 5
        Me.gbPerfiles.TabStop = False
        Me.gbPerfiles.Text = "Perfiles temporales"
        '
        'btnAgregarAcabado
        '
        Me.btnAgregarAcabado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch, CType(0, Byte))
        Me.btnAgregarAcabado.Image = CType(resources.GetObject("btnAgregarAcabado.Image"), System.Drawing.Image)
        Me.btnAgregarAcabado.Location = New System.Drawing.Point(150, 182)
        Me.btnAgregarAcabado.Name = "btnAgregarAcabado"
        Me.btnAgregarAcabado.Size = New System.Drawing.Size(25, 21)
        Me.btnAgregarAcabado.TabIndex = 4
        Me.btnAgregarAcabado.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Acabado"
        '
        'cmbAcabado
        '
        Me.cmbAcabado.DatosVisibles = Nothing
        Me.cmbAcabado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbAcabado.DropDownHeight = 200
        Me.cmbAcabado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcabado.DropDownWidth = 230
        Me.cmbAcabado.IntegralHeight = False
        Me.cmbAcabado.Location = New System.Drawing.Point(36, 182)
        Me.cmbAcabado.Name = "cmbAcabado"
        Me.cmbAcabado.Size = New System.Drawing.Size(112, 21)
        Me.cmbAcabado.TabIndex = 3
        '
        'gbPreciosPerfil
        '
        Me.gbPreciosPerfil.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbPreciosPerfil.Controls.Add(Me.dwPrecios)
        Me.gbPreciosPerfil.Location = New System.Drawing.Point(12, 402)
        Me.gbPreciosPerfil.Name = "gbPreciosPerfil"
        Me.gbPreciosPerfil.Size = New System.Drawing.Size(598, 136)
        Me.gbPreciosPerfil.TabIndex = 6
        Me.gbPreciosPerfil.TabStop = False
        Me.gbPreciosPerfil.Text = "Precios"
        '
        'dwPrecios
        '
        Me.dwPrecios.AllowUserToAddRows = False
        Me.dwPrecios.AllowUserToDeleteRows = False
        Me.dwPrecios.AllowUserToResizeColumns = False
        Me.dwPrecios.AllowUserToResizeRows = False
        Me.dwPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwPrecios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwPrecios.BackgroundColor = System.Drawing.Color.White
        Me.dwPrecios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.prec_idCosto, Me.prec_perfilTemporal, Me.prec_idPerfil, Me.prec_perfil, Me.prec_acabadoTemporal, Me.prec_idAcabado, Me.prec_acabado, Me.prec_idCostoAcabado, Me.prec_idCostoNivel, Me.prec_idCostoAluminio, Me.prec_precio})
        Me.dwPrecios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwPrecios.Location = New System.Drawing.Point(6, 19)
        Me.dwPrecios.MultiSelect = False
        Me.dwPrecios.Name = "dwPrecios"
        Me.dwPrecios.RowHeadersVisible = False
        Me.dwPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwPrecios.Size = New System.Drawing.Size(586, 111)
        Me.dwPrecios.TabIndex = 0
        '
        'prec_idCosto
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.prec_idCosto.DefaultCellStyle = DataGridViewCellStyle1
        Me.prec_idCosto.HeaderText = "Id"
        Me.prec_idCosto.Name = "prec_idCosto"
        Me.prec_idCosto.ReadOnly = True
        Me.prec_idCosto.Visible = False
        Me.prec_idCosto.Width = 22
        '
        'prec_perfilTemporal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.NullValue = False
        Me.prec_perfilTemporal.DefaultCellStyle = DataGridViewCellStyle2
        Me.prec_perfilTemporal.HeaderText = "Perfil temporal"
        Me.prec_perfilTemporal.Name = "prec_perfilTemporal"
        Me.prec_perfilTemporal.ReadOnly = True
        Me.prec_perfilTemporal.Visible = False
        Me.prec_perfilTemporal.Width = 79
        '
        'prec_idPerfil
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.prec_idPerfil.DefaultCellStyle = DataGridViewCellStyle3
        Me.prec_idPerfil.HeaderText = "Id perfil"
        Me.prec_idPerfil.Name = "prec_idPerfil"
        Me.prec_idPerfil.ReadOnly = True
        Me.prec_idPerfil.Visible = False
        Me.prec_idPerfil.Width = 47
        '
        'prec_perfil
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.prec_perfil.DefaultCellStyle = DataGridViewCellStyle4
        Me.prec_perfil.HeaderText = "Perfil"
        Me.prec_perfil.Name = "prec_perfil"
        Me.prec_perfil.ReadOnly = True
        Me.prec_perfil.Width = 55
        '
        'prec_acabadoTemporal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.NullValue = False
        Me.prec_acabadoTemporal.DefaultCellStyle = DataGridViewCellStyle5
        Me.prec_acabadoTemporal.HeaderText = "Acabado temporal"
        Me.prec_acabadoTemporal.Name = "prec_acabadoTemporal"
        Me.prec_acabadoTemporal.ReadOnly = True
        Me.prec_acabadoTemporal.Visible = False
        Me.prec_acabadoTemporal.Width = 99
        '
        'prec_idAcabado
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        Me.prec_idAcabado.DefaultCellStyle = DataGridViewCellStyle6
        Me.prec_idAcabado.HeaderText = "Id acabado"
        Me.prec_idAcabado.Name = "prec_idAcabado"
        Me.prec_idAcabado.ReadOnly = True
        Me.prec_idAcabado.Visible = False
        Me.prec_idAcabado.Width = 86
        '
        'prec_acabado
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.prec_acabado.DefaultCellStyle = DataGridViewCellStyle7
        Me.prec_acabado.HeaderText = "Acabado"
        Me.prec_acabado.Name = "prec_acabado"
        Me.prec_acabado.ReadOnly = True
        Me.prec_acabado.Width = 75
        '
        'prec_idCostoAcabado
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.prec_idCostoAcabado.DefaultCellStyle = DataGridViewCellStyle8
        Me.prec_idCostoAcabado.HeaderText = "Id Costo acabado"
        Me.prec_idCostoAcabado.Name = "prec_idCostoAcabado"
        Me.prec_idCostoAcabado.ReadOnly = True
        Me.prec_idCostoAcabado.Visible = False
        Me.prec_idCostoAcabado.Width = 116
        '
        'prec_idCostoNivel
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        Me.prec_idCostoNivel.DefaultCellStyle = DataGridViewCellStyle9
        Me.prec_idCostoNivel.HeaderText = "Id costo nivel"
        Me.prec_idCostoNivel.Name = "prec_idCostoNivel"
        Me.prec_idCostoNivel.ReadOnly = True
        Me.prec_idCostoNivel.Visible = False
        Me.prec_idCostoNivel.Width = 95
        '
        'prec_idCostoAluminio
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        Me.prec_idCostoAluminio.DefaultCellStyle = DataGridViewCellStyle10
        Me.prec_idCostoAluminio.HeaderText = "Id costo aluminio"
        Me.prec_idCostoAluminio.Name = "prec_idCostoAluminio"
        Me.prec_idCostoAluminio.ReadOnly = True
        Me.prec_idCostoAluminio.Visible = False
        Me.prec_idCostoAluminio.Width = 111
        '
        'prec_precio
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        Me.prec_precio.DefaultCellStyle = DataGridViewCellStyle11
        Me.prec_precio.HeaderText = "Precio"
        Me.prec_precio.Name = "prec_precio"
        Me.prec_precio.ReadOnly = True
        Me.prec_precio.Width = 62
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmAddPerfilTemporal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 550)
        Me.Controls.Add(Me.gbPreciosPerfil)
        Me.Controls.Add(Me.btnAgregarAcabado)
        Me.Controls.Add(Me.gbPerfiles)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbInfoPerfil)
        Me.Controls.Add(Me.cmbAcabado)
        Me.Controls.Add(Me.tsMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddPerfilTemporal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar perfil temporal"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPerimetro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPeso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.gbInfoPerfil.ResumeLayout(False)
        Me.gbInfoPerfil.PerformLayout()
        Me.gbPerfiles.ResumeLayout(False)
        Me.gbPreciosPerfil.ResumeLayout(False)
        CType(Me.dwPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents lblNivel As Label
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents lblUnidadMedida As Label
    Friend WithEvents nudPerimetro As NumericUpDown
    Friend WithEvents lblDesperdicio As Label
    Friend WithEvents lblPerimetro As Label
    Friend WithEvents nudPorcDesperdicio As NumericUpDown
    Friend WithEvents lblmmPerimetro As Label
    Friend WithEvents lblPeso As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents nudPeso As NumericUpDown
    Friend WithEvents lblgrPeso As Label
    Friend WithEvents lblporcDesp As Label
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents gbInfoPerfil As GroupBox
    Friend WithEvents gbPerfiles As GroupBox
    Friend WithEvents btnAgregarAcabado As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAcabado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents itPerfil As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents gbPreciosPerfil As GroupBox
    Friend WithEvents dwPrecios As DataGridView
    Friend WithEvents ErrorProvider As ErrorProvider
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
    Friend WithEvents item_usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents item_fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents item_idEstado As DataGridViewTextBoxColumn
    Friend WithEvents item_estado As DataGridViewTextBoxColumn
    Friend WithEvents btnLimpiar As ToolStripButton
    Friend WithEvents prec_idCosto As DataGridViewTextBoxColumn
    Friend WithEvents prec_perfilTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents prec_idPerfil As DataGridViewTextBoxColumn
    Friend WithEvents prec_perfil As DataGridViewTextBoxColumn
    Friend WithEvents prec_acabadoTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents prec_idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents prec_acabado As DataGridViewTextBoxColumn
    Friend WithEvents prec_idCostoAcabado As DataGridViewTextBoxColumn
    Friend WithEvents prec_idCostoNivel As DataGridViewTextBoxColumn
    Friend WithEvents prec_idCostoAluminio As DataGridViewTextBoxColumn
    Friend WithEvents prec_precio As DataGridViewTextBoxColumn
End Class
