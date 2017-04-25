<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotas))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoNota = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbContrato = New System.Windows.Forms.ComboBox()
        Me.grPara = New System.Windows.Forms.GroupBox()
        Me.dwItemsPara = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.selected2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.componente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idComponente2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.valorDefecto2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ivaPleno2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idParaSuministro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ParaSuministro2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idParaInstalacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paraInstalacion2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grObjeto = New System.Windows.Forms.GroupBox()
        Me.dwItemsObjetos = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.selected1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModif1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDe = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblCuota = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPorcAnticipo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtValorContrato = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtValorNota = New System.Windows.Forms.TextBox()
        Me.cbIvaSobreUtilidad = New System.Windows.Forms.CheckBox()
        Me.btnDescombinar = New System.Windows.Forms.Button()
        Me.btnCombinar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDetalleNota = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnGuardado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.lblConsecutivo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtValSuministro = New System.Windows.Forms.ToolStripLabel()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.idPlan = New System.Windows.Forms.ToolStripLabel()
        Me.lblpesos1 = New System.Windows.Forms.Label()
        Me.lblpesos2 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreYo = New System.Windows.Forms.Label()
        Me.ctrObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.ctrCodSucursal = New ControlesPersonalizados.Intellisens.intellises()
        Me.ctrCliente = New ControlesPersonalizados.Intellisens.intellises()
        Me.ctrlNit = New ControlesPersonalizados.Intellisens.intellises()
        Me.lblNitYo = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grPara.SuspendLayout()
        CType(Me.dwItemsPara, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grObjeto.SuspendLayout()
        CType(Me.dwItemsObjetos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(475, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Sucursal:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Cod. sucursal:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(484, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cliente:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Nit:"
        '
        'cmbTipoNota
        '
        Me.cmbTipoNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNota.FormattingEnabled = True
        Me.cmbTipoNota.Location = New System.Drawing.Point(112, 101)
        Me.cmbTipoNota.Name = "cmbTipoNota"
        Me.cmbTipoNota.Size = New System.Drawing.Size(242, 21)
        Me.cmbTipoNota.TabIndex = 10
        Me.cmbTipoNota.Tag = "{tipo_nota}"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(51, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Tipo nota:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(56, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Contrato:"
        '
        'cmbContrato
        '
        Me.cmbContrato.FormattingEnabled = True
        Me.cmbContrato.Location = New System.Drawing.Point(112, 128)
        Me.cmbContrato.Name = "cmbContrato"
        Me.cmbContrato.Size = New System.Drawing.Size(242, 21)
        Me.cmbContrato.TabIndex = 12
        Me.cmbContrato.Tag = "{num_contrato}"
        '
        'grPara
        '
        Me.grPara.Controls.Add(Me.dwItemsPara)
        Me.grPara.Location = New System.Drawing.Point(759, 139)
        Me.grPara.Name = "grPara"
        Me.grPara.Size = New System.Drawing.Size(245, 151)
        Me.grPara.TabIndex = 28
        Me.grPara.TabStop = False
        Me.grPara.Tag = "2"
        Me.grPara.Text = "Para"
        '
        'dwItemsPara
        '
        Me.dwItemsPara.AllowUserToAddRows = False
        Me.dwItemsPara.AllowUserToDeleteRows = False
        Me.dwItemsPara.AllowUserToResizeColumns = False
        Me.dwItemsPara.AllowUserToResizeRows = False
        Me.dwItemsPara.AutoGenerateColumns = False
        Me.dwItemsPara.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItemsPara.BackgroundColor = System.Drawing.Color.White
        Me.dwItemsPara.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItemsPara.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwItemsPara.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selected2, Me.id2, Me.fechaCreacion2, Me.usuarioCreacion2, Me.descripcion2, Me.componente2, Me.idComponente2, Me.usuarioModi2, Me.fechaModi2, Me.estado2, Me.valorDefecto2, Me.ivaPleno2, Me.idParaSuministro2, Me.ParaSuministro2, Me.idParaInstalacion2, Me.paraInstalacion2})
        Me.dwItemsPara.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItemsPara.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItemsPara.ImageList = Nothing
        Me.dwItemsPara.Location = New System.Drawing.Point(3, 16)
        Me.dwItemsPara.MostrarFiltros = False
        Me.dwItemsPara.MultiSelect = False
        Me.dwItemsPara.Name = "dwItemsPara"
        Me.dwItemsPara.RowHeadersVisible = False
        Me.dwItemsPara.RowHeadersWidth = 25
        Me.dwItemsPara.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItemsPara.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItemsPara.Size = New System.Drawing.Size(239, 132)
        Me.dwItemsPara.TabIndex = 0
        Me.dwItemsPara.TablaDatos = Nothing
        Me.dwItemsPara.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'selected2
        '
        Me.selected2.Frozen = True
        Me.selected2.HeaderText = ""
        Me.selected2.Name = "selected2"
        Me.selected2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.selected2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.selected2.Width = 19
        '
        'id2
        '
        Me.id2.HeaderText = "Id"
        Me.id2.Name = "id2"
        Me.id2.Visible = False
        Me.id2.Width = 41
        '
        'fechaCreacion2
        '
        Me.fechaCreacion2.HeaderText = "Fecha creación"
        Me.fechaCreacion2.Name = "fechaCreacion2"
        Me.fechaCreacion2.Visible = False
        Me.fechaCreacion2.Width = 106
        '
        'usuarioCreacion2
        '
        Me.usuarioCreacion2.HeaderText = "Usuario creación"
        Me.usuarioCreacion2.Name = "usuarioCreacion2"
        Me.usuarioCreacion2.Visible = False
        Me.usuarioCreacion2.Width = 112
        '
        'descripcion2
        '
        Me.descripcion2.HeaderText = "Descripción"
        Me.descripcion2.Name = "descripcion2"
        Me.descripcion2.ReadOnly = True
        Me.descripcion2.Width = 88
        '
        'componente2
        '
        Me.componente2.HeaderText = "Componente"
        Me.componente2.Name = "componente2"
        Me.componente2.Visible = False
        Me.componente2.Width = 92
        '
        'idComponente2
        '
        Me.idComponente2.HeaderText = "IdComponente"
        Me.idComponente2.Name = "idComponente2"
        Me.idComponente2.Visible = False
        Me.idComponente2.Width = 101
        '
        'usuarioModi2
        '
        Me.usuarioModi2.HeaderText = "Usuario modificación"
        Me.usuarioModi2.Name = "usuarioModi2"
        Me.usuarioModi2.Visible = False
        Me.usuarioModi2.Width = 130
        '
        'fechaModi2
        '
        Me.fechaModi2.HeaderText = "Fecha modificación"
        Me.fechaModi2.Name = "fechaModi2"
        Me.fechaModi2.Visible = False
        Me.fechaModi2.Width = 124
        '
        'estado2
        '
        Me.estado2.HeaderText = "Estado"
        Me.estado2.Name = "estado2"
        Me.estado2.Visible = False
        Me.estado2.Width = 46
        '
        'valorDefecto2
        '
        Me.valorDefecto2.HeaderText = "Valor por defecto"
        Me.valorDefecto2.Name = "valorDefecto2"
        Me.valorDefecto2.Visible = False
        Me.valorDefecto2.Width = 94
        '
        'ivaPleno2
        '
        Me.ivaPleno2.HeaderText = "IVA pleno"
        Me.ivaPleno2.Name = "ivaPleno2"
        Me.ivaPleno2.Visible = False
        Me.ivaPleno2.Width = 59
        '
        'idParaSuministro2
        '
        Me.idParaSuministro2.HeaderText = "id Para Suministro"
        Me.idParaSuministro2.Name = "idParaSuministro2"
        Me.idParaSuministro2.ReadOnly = True
        Me.idParaSuministro2.Visible = False
        Me.idParaSuministro2.Width = 116
        '
        'ParaSuministro2
        '
        Me.ParaSuministro2.HeaderText = "Para Suministro"
        Me.ParaSuministro2.Name = "ParaSuministro2"
        Me.ParaSuministro2.ReadOnly = True
        Me.ParaSuministro2.Visible = False
        Me.ParaSuministro2.Width = 105
        '
        'idParaInstalacion2
        '
        Me.idParaInstalacion2.HeaderText = "id Para Instalacion"
        Me.idParaInstalacion2.Name = "idParaInstalacion2"
        Me.idParaInstalacion2.ReadOnly = True
        Me.idParaInstalacion2.Visible = False
        Me.idParaInstalacion2.Width = 119
        '
        'paraInstalacion2
        '
        Me.paraInstalacion2.HeaderText = "Para Instalacion"
        Me.paraInstalacion2.Name = "paraInstalacion2"
        Me.paraInstalacion2.ReadOnly = True
        Me.paraInstalacion2.Visible = False
        Me.paraInstalacion2.Width = 108
        '
        'grObjeto
        '
        Me.grObjeto.Controls.Add(Me.dwItemsObjetos)
        Me.grObjeto.Location = New System.Drawing.Point(452, 140)
        Me.grObjeto.Name = "grObjeto"
        Me.grObjeto.Size = New System.Drawing.Size(283, 150)
        Me.grObjeto.TabIndex = 27
        Me.grObjeto.TabStop = False
        Me.grObjeto.Tag = "1"
        Me.grObjeto.Text = "Objeto Contrato"
        '
        'dwItemsObjetos
        '
        Me.dwItemsObjetos.AllowUserToAddRows = False
        Me.dwItemsObjetos.AllowUserToDeleteRows = False
        Me.dwItemsObjetos.AllowUserToResizeColumns = False
        Me.dwItemsObjetos.AllowUserToResizeRows = False
        Me.dwItemsObjetos.AutoGenerateColumns = False
        Me.dwItemsObjetos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItemsObjetos.BackgroundColor = System.Drawing.Color.White
        Me.dwItemsObjetos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItemsObjetos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItemsObjetos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selected1, Me.id1, Me.FechaCreacion1, Me.usuarioCreacion1, Me.descripcion1, Me.UsuarioModif1, Me.fechaModi1, Me.idEstado1, Me.estado1})
        Me.dwItemsObjetos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItemsObjetos.ImageList = Nothing
        Me.dwItemsObjetos.Location = New System.Drawing.Point(3, 16)
        Me.dwItemsObjetos.MostrarFiltros = False
        Me.dwItemsObjetos.Name = "dwItemsObjetos"
        Me.dwItemsObjetos.RowHeadersVisible = False
        Me.dwItemsObjetos.RowHeadersWidth = 25
        Me.dwItemsObjetos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItemsObjetos.Size = New System.Drawing.Size(277, 131)
        Me.dwItemsObjetos.TabIndex = 0
        Me.dwItemsObjetos.TablaDatos = Nothing
        Me.dwItemsObjetos.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'selected1
        '
        Me.selected1.Frozen = True
        Me.selected1.HeaderText = ""
        Me.selected1.Name = "selected1"
        Me.selected1.Width = 5
        '
        'id1
        '
        Me.id1.HeaderText = "Id"
        Me.id1.Name = "id1"
        Me.id1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id1.Visible = False
        Me.id1.Width = 22
        '
        'FechaCreacion1
        '
        Me.FechaCreacion1.HeaderText = "Fecha Creacion"
        Me.FechaCreacion1.Name = "FechaCreacion1"
        Me.FechaCreacion1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaCreacion1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaCreacion1.Visible = False
        Me.FechaCreacion1.Width = 88
        '
        'usuarioCreacion1
        '
        Me.usuarioCreacion1.HeaderText = "Usuario Creacion"
        Me.usuarioCreacion1.Name = "usuarioCreacion1"
        Me.usuarioCreacion1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.usuarioCreacion1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.usuarioCreacion1.Visible = False
        Me.usuarioCreacion1.Width = 94
        '
        'descripcion1
        '
        Me.descripcion1.HeaderText = "Descripción"
        Me.descripcion1.Name = "descripcion1"
        Me.descripcion1.ReadOnly = True
        Me.descripcion1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcion1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descripcion1.Width = 69
        '
        'UsuarioModif1
        '
        Me.UsuarioModif1.HeaderText = "Usuario Modi"
        Me.UsuarioModif1.Name = "UsuarioModif1"
        Me.UsuarioModif1.Visible = False
        Me.UsuarioModif1.Width = 94
        '
        'fechaModi1
        '
        Me.fechaModi1.HeaderText = "Fecha Modi"
        Me.fechaModi1.Name = "fechaModi1"
        Me.fechaModi1.Visible = False
        Me.fechaModi1.Width = 88
        '
        'idEstado1
        '
        Me.idEstado1.HeaderText = "id Estado"
        Me.idEstado1.Name = "idEstado1"
        Me.idEstado1.Visible = False
        Me.idEstado1.Width = 76
        '
        'estado1
        '
        Me.estado1.HeaderText = "Estado"
        Me.estado1.Name = "estado1"
        Me.estado1.Visible = False
        Me.estado1.Width = 65
        '
        'lblDe
        '
        Me.lblDe.AutoSize = True
        Me.lblDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDe.Location = New System.Drawing.Point(108, 303)
        Me.lblDe.Name = "lblDe"
        Me.lblDe.Size = New System.Drawing.Size(27, 20)
        Me.lblDe.TabIndex = 26
        Me.lblDe.Tag = "{cantidad_cuotas}"
        Me.lblDe.Text = "---"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(82, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(24, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "De:"
        '
        'lblCuota
        '
        Me.lblCuota.AutoSize = True
        Me.lblCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuota.Location = New System.Drawing.Point(109, 265)
        Me.lblCuota.Name = "lblCuota"
        Me.lblCuota.Size = New System.Drawing.Size(27, 20)
        Me.lblCuota.TabIndex = 24
        Me.lblCuota.Tag = "{num_cuota}"
        Me.lblCuota.Text = "---"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(68, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Cuota:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(47, 240)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "% Anticipo:"
        '
        'txtPorcAnticipo
        '
        Me.txtPorcAnticipo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPorcAnticipo.Location = New System.Drawing.Point(112, 233)
        Me.txtPorcAnticipo.Name = "txtPorcAnticipo"
        Me.txtPorcAnticipo.Size = New System.Drawing.Size(242, 20)
        Me.txtPorcAnticipo.TabIndex = 22
        Me.txtPorcAnticipo.Tag = "{porcentaje}"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(50, 214)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Vendedor:"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(112, 207)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(242, 20)
        Me.txtVendedor.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 188)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Valor contrato:"
        '
        'txtValorContrato
        '
        Me.txtValorContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorContrato.Location = New System.Drawing.Point(125, 181)
        Me.txtValorContrato.Name = "txtValorContrato"
        Me.txtValorContrato.Size = New System.Drawing.Size(229, 20)
        Me.txtValorContrato.TabIndex = 18
        Me.txtValorContrato.Tag = "{valor_contrato}"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(48, 162)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Valor nota:"
        '
        'txtValorNota
        '
        Me.txtValorNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValorNota.Location = New System.Drawing.Point(125, 155)
        Me.txtValorNota.Name = "txtValorNota"
        Me.txtValorNota.Size = New System.Drawing.Size(229, 20)
        Me.txtValorNota.TabIndex = 15
        '
        'cbIvaSobreUtilidad
        '
        Me.cbIvaSobreUtilidad.AutoSize = True
        Me.cbIvaSobreUtilidad.Location = New System.Drawing.Point(759, 310)
        Me.cbIvaSobreUtilidad.Name = "cbIvaSobreUtilidad"
        Me.cbIvaSobreUtilidad.Size = New System.Drawing.Size(151, 17)
        Me.cbIvaSobreUtilidad.TabIndex = 29
        Me.cbIvaSobreUtilidad.Text = "Calcular IVA sobre utiilidad"
        Me.cbIvaSobreUtilidad.UseVisualStyleBackColor = True
        '
        'btnDescombinar
        '
        Me.btnDescombinar.Image = CType(resources.GetObject("btnDescombinar.Image"), System.Drawing.Image)
        Me.btnDescombinar.Location = New System.Drawing.Point(932, 296)
        Me.btnDescombinar.Name = "btnDescombinar"
        Me.btnDescombinar.Size = New System.Drawing.Size(35, 31)
        Me.btnDescombinar.TabIndex = 30
        Me.btnDescombinar.UseVisualStyleBackColor = True
        '
        'btnCombinar
        '
        Me.btnCombinar.Image = CType(resources.GetObject("btnCombinar.Image"), System.Drawing.Image)
        Me.btnCombinar.Location = New System.Drawing.Point(969, 296)
        Me.btnCombinar.Name = "btnCombinar"
        Me.btnCombinar.Size = New System.Drawing.Size(35, 31)
        Me.btnCombinar.TabIndex = 31
        Me.btnCombinar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(36, 464)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(968, 66)
        Me.txtObservaciones.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(33, 448)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Observaciones"
        '
        'txtDetalleNota
        '
        Me.txtDetalleNota.Location = New System.Drawing.Point(36, 361)
        Me.txtDetalleNota.Multiline = True
        Me.txtDetalleNota.Name = "txtDetalleNota"
        Me.txtDetalleNota.Size = New System.Drawing.Size(968, 66)
        Me.txtDetalleNota.TabIndex = 33
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(33, 345)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(67, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Detalle nota:"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'btnGuardado
        '
        Me.btnGuardado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardado.Image = CType(resources.GetObject("btnGuardado.Image"), System.Drawing.Image)
        Me.btnGuardado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardado.Name = "btnGuardado"
        Me.btnGuardado.Size = New System.Drawing.Size(23, 20)
        Me.btnGuardado.Text = "% Anticipo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(78, 15)
        Me.ToolStripLabel8.Text = "Nota número"
        Me.ToolStripLabel8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(19, 21)
        Me.lblConsecutivo.Text = "0"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'txtValSuministro
        '
        Me.txtValSuministro.Name = "txtValSuministro"
        Me.txtValSuministro.Size = New System.Drawing.Size(38, 15)
        Me.txtValSuministro.Text = "Fecha"
        '
        'tsherramientas
        '
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar, Me.ToolStripSeparator3, Me.btnGuardado, Me.ToolStripSeparator4, Me.ToolStripLabel8, Me.lblConsecutivo, Me.ToolStripSeparator6, Me.txtValSuministro, Me.idPlan})
        Me.tsherramientas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(1040, 24)
        Me.tsherramientas.Stretch = True
        Me.tsherramientas.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 4)
        Me.btnGuardar.Text = "Guardar PLan"
        '
        'idPlan
        '
        Me.idPlan.Name = "idPlan"
        Me.idPlan.Size = New System.Drawing.Size(17, 15)
        Me.idPlan.Text = "--"
        Me.idPlan.Visible = False
        '
        'lblpesos1
        '
        Me.lblpesos1.AutoSize = True
        Me.lblpesos1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpesos1.Location = New System.Drawing.Point(110, 156)
        Me.lblpesos1.Name = "lblpesos1"
        Me.lblpesos1.Size = New System.Drawing.Size(16, 17)
        Me.lblpesos1.TabIndex = 14
        Me.lblpesos1.Text = "$"
        '
        'lblpesos2
        '
        Me.lblpesos2.AutoSize = True
        Me.lblpesos2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpesos2.Location = New System.Drawing.Point(110, 182)
        Me.lblpesos2.Name = "lblpesos2"
        Me.lblpesos2.Size = New System.Drawing.Size(16, 17)
        Me.lblpesos2.TabIndex = 17
        Me.lblpesos2.Text = "$"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(665, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Nombre Y/O:"
        '
        'lblNombreYo
        '
        Me.lblNombreYo.AutoSize = True
        Me.lblNombreYo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreYo.Location = New System.Drawing.Point(741, 109)
        Me.lblNombreYo.Name = "lblNombreYo"
        Me.lblNombreYo.Size = New System.Drawing.Size(0, 13)
        Me.lblNombreYo.TabIndex = 37
        '
        'ctrObra
        '
        Me.ctrObra.AlternativeColumn = "codigoObra"
        Me.ctrObra.ColToReturn = "obra"
        Me.ctrObra.ColumnsToFilter = New String() {"codigoObra", "obra"}
        Me.ctrObra.ColumnsToShow = New String() {"codigoObra", "obra"}
        Me.ctrObra.Dropdown_Width = 500
        Me.ctrObra.Id_Column_Name = "codigoObra"
        Me.ctrObra.Location = New System.Drawing.Point(532, 74)
        Me.ctrObra.Maximo_Items_DropDown = 5
        Me.ctrObra.Name = "ctrObra"
        Me.ctrObra.selected_item = Nothing
        Me.ctrObra.Seleted_rowid = Nothing
        Me.ctrObra.Size = New System.Drawing.Size(472, 20)
        Me.ctrObra.TabIndex = 8
        Me.ctrObra.TablaFuente = Nothing
        Me.ctrObra.Value2 = Nothing
        '
        'ctrCodSucursal
        '
        Me.ctrCodSucursal.AlternativeColumn = "obra"
        Me.ctrCodSucursal.ColToReturn = "codigoObra"
        Me.ctrCodSucursal.ColumnsToFilter = New String() {"codigoObra", "obra"}
        Me.ctrCodSucursal.ColumnsToShow = New String() {"codigoObra", "obra"}
        Me.ctrCodSucursal.Dropdown_Width = 500
        Me.ctrCodSucursal.Id_Column_Name = "codigoObra"
        Me.ctrCodSucursal.Location = New System.Drawing.Point(112, 74)
        Me.ctrCodSucursal.Maximo_Items_DropDown = 5
        Me.ctrCodSucursal.Name = "ctrCodSucursal"
        Me.ctrCodSucursal.selected_item = Nothing
        Me.ctrCodSucursal.Seleted_rowid = Nothing
        Me.ctrCodSucursal.Size = New System.Drawing.Size(242, 20)
        Me.ctrCodSucursal.TabIndex = 6
        Me.ctrCodSucursal.TablaFuente = Nothing
        Me.ctrCodSucursal.Value2 = Nothing
        '
        'ctrCliente
        '
        Me.ctrCliente.AlternativeColumn = "nit"
        Me.ctrCliente.ColToReturn = "cliente"
        Me.ctrCliente.ColumnsToFilter = New String() {"nit", "cliente", "nombreEstablecimiento"}
        Me.ctrCliente.ColumnsToShow = New String() {"nit", "cliente", "nombreEstablecimiento"}
        Me.ctrCliente.Dropdown_Width = 500
        Me.ctrCliente.Id_Column_Name = "nit"
        Me.ctrCliente.Location = New System.Drawing.Point(532, 47)
        Me.ctrCliente.Maximo_Items_DropDown = 5
        Me.ctrCliente.Name = "ctrCliente"
        Me.ctrCliente.selected_item = Nothing
        Me.ctrCliente.Seleted_rowid = Nothing
        Me.ctrCliente.Size = New System.Drawing.Size(472, 20)
        Me.ctrCliente.TabIndex = 4
        Me.ctrCliente.TablaFuente = Nothing
        Me.ctrCliente.Value2 = Nothing
        '
        'ctrlNit
        '
        Me.ctrlNit.AlternativeColumn = "cliente"
        Me.ctrlNit.ColToReturn = "nit"
        Me.ctrlNit.ColumnsToFilter = New String() {"nit", "cliente", "nombreEstablecimiento"}
        Me.ctrlNit.ColumnsToShow = New String() {"nit", "cliente", "nombreEstablecimiento"}
        Me.ctrlNit.Dropdown_Width = 500
        Me.ctrlNit.Id_Column_Name = "nit"
        Me.ctrlNit.Location = New System.Drawing.Point(112, 48)
        Me.ctrlNit.Maximo_Items_DropDown = 5
        Me.ctrlNit.Name = "ctrlNit"
        Me.ctrlNit.selected_item = Nothing
        Me.ctrlNit.Seleted_rowid = Nothing
        Me.ctrlNit.Size = New System.Drawing.Size(242, 20)
        Me.ctrlNit.TabIndex = 2
        Me.ctrlNit.TablaFuente = Nothing
        Me.ctrlNit.Value2 = Nothing
        '
        'lblNitYo
        '
        Me.lblNitYo.AutoSize = True
        Me.lblNitYo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNitYo.Location = New System.Drawing.Point(529, 109)
        Me.lblNitYo.Name = "lblNitYo"
        Me.lblNitYo.Size = New System.Drawing.Size(0, 13)
        Me.lblNitYo.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(477, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Nit Y/O:"
        '
        'FrmNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 542)
        Me.Controls.Add(Me.lblNitYo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.lblNombreYo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtValorContrato)
        Me.Controls.Add(Me.lblpesos2)
        Me.Controls.Add(Me.txtValorNota)
        Me.Controls.Add(Me.lblpesos1)
        Me.Controls.Add(Me.tsherramientas)
        Me.Controls.Add(Me.cbIvaSobreUtilidad)
        Me.Controls.Add(Me.btnDescombinar)
        Me.Controls.Add(Me.btnCombinar)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtDetalleNota)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblDe)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblCuota)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPorcAnticipo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.grPara)
        Me.Controls.Add(Me.grObjeto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbContrato)
        Me.Controls.Add(Me.cmbTipoNota)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ctrObra)
        Me.Controls.Add(Me.ctrCodSucursal)
        Me.Controls.Add(Me.ctrCliente)
        Me.Controls.Add(Me.ctrlNit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNotas"
        Me.ShowIcon = False
        Me.Text = "Notas"
        Me.grPara.ResumeLayout(False)
        CType(Me.dwItemsPara, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grObjeto.ResumeLayout(False)
        CType(Me.dwItemsObjetos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctrObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents ctrCodSucursal As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents ctrCliente As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents ctrlNit As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbTipoNota As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbContrato As ComboBox
    Friend WithEvents grPara As GroupBox
    Friend WithEvents dwItemsPara As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents selected2 As DataGridViewCheckBoxColumn
    Friend WithEvents id2 As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion2 As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion2 As DataGridViewTextBoxColumn
    Friend WithEvents descripcion2 As DataGridViewTextBoxColumn
    Friend WithEvents componente2 As DataGridViewTextBoxColumn
    Friend WithEvents idComponente2 As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi2 As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi2 As DataGridViewTextBoxColumn
    Friend WithEvents estado2 As DataGridViewCheckBoxColumn
    Friend WithEvents valorDefecto2 As DataGridViewCheckBoxColumn
    Friend WithEvents ivaPleno2 As DataGridViewCheckBoxColumn
    Friend WithEvents idParaSuministro2 As DataGridViewTextBoxColumn
    Friend WithEvents ParaSuministro2 As DataGridViewTextBoxColumn
    Friend WithEvents idParaInstalacion2 As DataGridViewTextBoxColumn
    Friend WithEvents paraInstalacion2 As DataGridViewTextBoxColumn
    Friend WithEvents grObjeto As GroupBox
    Friend WithEvents dwItemsObjetos As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents selected1 As DataGridViewCheckBoxColumn
    Friend WithEvents id1 As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion1 As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion1 As DataGridViewTextBoxColumn
    Friend WithEvents descripcion1 As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModif1 As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi1 As DataGridViewTextBoxColumn
    Friend WithEvents idEstado1 As DataGridViewTextBoxColumn
    Friend WithEvents estado1 As DataGridViewTextBoxColumn
    Friend WithEvents lblDe As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblCuota As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPorcAnticipo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtValorContrato As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtValorNota As TextBox
    Friend WithEvents cbIvaSobreUtilidad As CheckBox
    Friend WithEvents btnDescombinar As Button
    Friend WithEvents btnCombinar As Button
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtDetalleNota As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnGuardado As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents lblConsecutivo As ToolStripLabel
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents txtValSuministro As ToolStripLabel
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents idPlan As ToolStripLabel
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents lblpesos1 As Label
    Friend WithEvents lblpesos2 As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents lblNombreYo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNitYo As Label
    Friend WithEvents Label17 As Label
End Class
