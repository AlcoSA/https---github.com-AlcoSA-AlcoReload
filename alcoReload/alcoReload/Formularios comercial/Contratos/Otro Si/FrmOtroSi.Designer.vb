<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOtroSi
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOtroSi))
        Me.gbnotas = New System.Windows.Forms.GroupBox()
        Me.rtbnotas = New System.Windows.Forms.RichTextBox()
        Me.tbgeneral = New System.Windows.Forms.TabControl()
        Me.tpgeneral = New System.Windows.Forms.TabPage()
        Me.spcontendorgeneral = New System.Windows.Forms.SplitContainer()
        Me.txtformaPago = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtcedularepr = New System.Windows.Forms.TextBox()
        Me.txtrepresentante = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ClienteYo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NitYo = New System.Windows.Forms.Label()
        Me.dtpfechainicial = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpfechafinal = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ctrObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctrCodSucursal = New ControlesPersonalizados.Intellisens.intellises()
        Me.txtnumero = New System.Windows.Forms.TextBox()
        Me.ctrCliente = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ctrlNit = New ControlesPersonalizados.Intellisens.intellises()
        Me.nudvalor = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.spespecificos = New System.Windows.Forms.SplitContainer()
        Me.gbporcpolizas = New System.Windows.Forms.GroupBox()
        Me.dwItemsPoliza = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.selpol = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PorcentajeDefecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.tpanticipos = New System.Windows.Forms.TabPage()
        Me.dwItemsAnticipos = New System.Windows.Forms.DataGridView()
        Me.idCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._ColnCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._colPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCuota = New DateTimeGridColumn()
        Me._colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsanticipos = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.nudanticipo = New ToolStrip_Extras.NumericUpDownToolStripItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.nudcuotas = New ToolStrip_Extras.NumericUpDownToolStripItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbDias = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.dtpfechaprimeracuota = New ToolStrip_Extras.DatetimePickerToolStripItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.txtValSuministro = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.txtValInstalacion = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.cbtipoanticipo = New System.Windows.Forms.ToolStripComboBox()
        Me.btonCalculo = New System.Windows.Forms.ToolStripButton()
        Me.btnCancelar = New System.Windows.Forms.ToolStripButton()
        Me.idPlan = New System.Windows.Forms.ToolStripLabel()
        Me.tpminuta = New System.Windows.Forms.TabPage()
        Me.editorMinutas = New ControlesPersonalizados.Editor_RTF.EditorRTF()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnnuevo = New System.Windows.Forms.ToolStripButton()
        Me.btnguardar = New System.Windows.Forms.ToolStripButton()
        Me.tsseparador = New System.Windows.Forms.ToolStripSeparator()
        Me.ddbformatos = New System.Windows.Forms.ToolStripDropDownButton()
        Me.lbindnombre = New System.Windows.Forms.ToolStripLabel()
        Me.lbnombredocumento = New System.Windows.Forms.ToolStripLabel()
        Me.tssep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.sbimprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnvistaprevia = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnimprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.sbexportar = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnword = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnpdf = New System.Windows.Forms.ToolStripMenuItem()
        Me.btncombinar = New System.Windows.Forms.ToolStripButton()
        Me.lbotrosi = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel()
        Me.gbnotas.SuspendLayout()
        Me.tbgeneral.SuspendLayout()
        Me.tpgeneral.SuspendLayout()
        CType(Me.spcontendorgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcontendorgeneral.Panel1.SuspendLayout()
        Me.spcontendorgeneral.Panel2.SuspendLayout()
        Me.spcontendorgeneral.SuspendLayout()
        CType(Me.nudvalor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spespecificos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spespecificos.Panel1.SuspendLayout()
        Me.spespecificos.Panel2.SuspendLayout()
        Me.spespecificos.SuspendLayout()
        Me.gbporcpolizas.SuspendLayout()
        CType(Me.dwItemsPoliza, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grObjeto.SuspendLayout()
        CType(Me.dwItemsObjetos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpanticipos.SuspendLayout()
        CType(Me.dwItemsAnticipos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsanticipos.SuspendLayout()
        Me.tpminuta.SuspendLayout()
        Me.tsherramientas.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbnotas
        '
        Me.gbnotas.Controls.Add(Me.rtbnotas)
        Me.gbnotas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gbnotas.Location = New System.Drawing.Point(0, 171)
        Me.gbnotas.Name = "gbnotas"
        Me.gbnotas.Size = New System.Drawing.Size(700, 59)
        Me.gbnotas.TabIndex = 8
        Me.gbnotas.TabStop = False
        Me.gbnotas.Text = "Notas"
        '
        'rtbnotas
        '
        Me.rtbnotas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbnotas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbnotas.Location = New System.Drawing.Point(3, 16)
        Me.rtbnotas.MaxLength = 500
        Me.rtbnotas.Name = "rtbnotas"
        Me.rtbnotas.Size = New System.Drawing.Size(694, 40)
        Me.rtbnotas.TabIndex = 0
        Me.rtbnotas.Text = ""
        '
        'tbgeneral
        '
        Me.tbgeneral.Controls.Add(Me.tpgeneral)
        Me.tbgeneral.Controls.Add(Me.tpanticipos)
        Me.tbgeneral.Controls.Add(Me.tpminuta)
        Me.tbgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbgeneral.Location = New System.Drawing.Point(0, 25)
        Me.tbgeneral.Name = "tbgeneral"
        Me.tbgeneral.SelectedIndex = 0
        Me.tbgeneral.Size = New System.Drawing.Size(714, 466)
        Me.tbgeneral.TabIndex = 29
        '
        'tpgeneral
        '
        Me.tpgeneral.Controls.Add(Me.spcontendorgeneral)
        Me.tpgeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpgeneral.Name = "tpgeneral"
        Me.tpgeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgeneral.Size = New System.Drawing.Size(706, 440)
        Me.tpgeneral.TabIndex = 0
        Me.tpgeneral.Text = "General"
        Me.tpgeneral.UseVisualStyleBackColor = True
        '
        'spcontendorgeneral
        '
        Me.spcontendorgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcontendorgeneral.Location = New System.Drawing.Point(3, 3)
        Me.spcontendorgeneral.Name = "spcontendorgeneral"
        Me.spcontendorgeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcontendorgeneral.Panel1
        '
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.txtformaPago)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label20)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label18)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.txtcedularepr)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.txtrepresentante)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label17)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.ClienteYo)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label2)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.NitYo)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.dtpfechainicial)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label21)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.dtpfechafinal)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label19)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label3)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.ctrObra)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label1)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.ctrCodSucursal)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.txtnumero)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.ctrCliente)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label4)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.ctrlNit)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.nudvalor)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label5)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label8)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label6)
        Me.spcontendorgeneral.Panel1.Controls.Add(Me.Label7)
        '
        'spcontendorgeneral.Panel2
        '
        Me.spcontendorgeneral.Panel2.Controls.Add(Me.spespecificos)
        Me.spcontendorgeneral.Panel2.Controls.Add(Me.gbnotas)
        Me.spcontendorgeneral.Size = New System.Drawing.Size(700, 434)
        Me.spcontendorgeneral.SplitterDistance = 200
        Me.spcontendorgeneral.TabIndex = 36
        '
        'txtformaPago
        '
        Me.txtformaPago.Location = New System.Drawing.Point(365, 142)
        Me.txtformaPago.Multiline = True
        Me.txtformaPago.Name = "txtformaPago"
        Me.txtformaPago.Size = New System.Drawing.Size(330, 49)
        Me.txtformaPago.TabIndex = 60
        Me.txtformaPago.Tag = "Forma de Pago"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(292, 149)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 13)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "Forma Pago:"
        '
        'Label18
        '
        Me.Label18.AccessibleName = "Cedula representante legal"
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 178)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 13)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Cedula Repr:"
        '
        'txtcedularepr
        '
        Me.txtcedularepr.Location = New System.Drawing.Point(89, 171)
        Me.txtcedularepr.Name = "txtcedularepr"
        Me.txtcedularepr.Size = New System.Drawing.Size(184, 20)
        Me.txtcedularepr.TabIndex = 58
        Me.txtcedularepr.Tag = "Cédula Representante Legal"
        '
        'txtrepresentante
        '
        Me.txtrepresentante.Location = New System.Drawing.Point(89, 142)
        Me.txtrepresentante.Name = "txtrepresentante"
        Me.txtrepresentante.Size = New System.Drawing.Size(184, 20)
        Me.txtrepresentante.TabIndex = 56
        Me.txtrepresentante.Tag = "Representante Legal"
        '
        'Label17
        '
        Me.Label17.AccessibleName = "Representante legal"
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1, 149)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 13)
        Me.Label17.TabIndex = 55
        Me.Label17.Text = "Representante:"
        '
        'ClienteYo
        '
        Me.ClienteYo.AutoSize = True
        Me.ClienteYo.Location = New System.Drawing.Point(295, 68)
        Me.ClienteYo.Name = "ClienteYo"
        Me.ClienteYo.Size = New System.Drawing.Size(13, 13)
        Me.ClienteYo.TabIndex = 54
        Me.ClienteYo.Text = "--"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(292, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Fecha Inicial"
        '
        'NitYo
        '
        Me.NitYo.AutoSize = True
        Me.NitYo.Location = New System.Drawing.Point(82, 68)
        Me.NitYo.Name = "NitYo"
        Me.NitYo.Size = New System.Drawing.Size(13, 13)
        Me.NitYo.TabIndex = 52
        Me.NitYo.Text = "--"
        '
        'dtpfechainicial
        '
        Me.dtpfechainicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicial.Location = New System.Drawing.Point(365, 89)
        Me.dtpfechainicial.Name = "dtpfechainicial"
        Me.dtpfechainicial.Size = New System.Drawing.Size(119, 20)
        Me.dtpfechainicial.TabIndex = 37
        '
        'Label21
        '
        Me.Label21.AccessibleName = "Codigo Sucursal"
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(224, 69)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 53
        Me.Label21.Text = "Cliente Y/O:"
        '
        'dtpfechafinal
        '
        Me.dtpfechafinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechafinal.Location = New System.Drawing.Point(365, 117)
        Me.dtpfechafinal.Name = "dtpfechafinal"
        Me.dtpfechafinal.Size = New System.Drawing.Size(119, 20)
        Me.dtpfechafinal.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AccessibleName = "Codigo Sucursal"
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(29, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 51
        Me.Label19.Text = "Nit Y/O:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(297, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Fecha Final"
        '
        'ctrObra
        '
        Me.ctrObra.AlternativeColumn = "idObra"
        Me.ctrObra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctrObra.ColToReturn = "nombreObra"
        Me.ctrObra.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.ctrObra.ColumnsToShow = New String() {"idObra", "nombreObra"}
        Me.ctrObra.Dropdown_Width = 500
        Me.ctrObra.Id_Column_Name = "idCliente"
        Me.ctrObra.Location = New System.Drawing.Point(295, 33)
        Me.ctrObra.Maximo_Items_DropDown = 5
        Me.ctrObra.Name = "ctrObra"
        Me.ctrObra.selected_item = Nothing
        Me.ctrObra.Seleted_rowid = Nothing
        Me.ctrObra.Size = New System.Drawing.Size(400, 20)
        Me.ctrObra.TabIndex = 50
        Me.ctrObra.TablaFuente = Nothing
        Me.ctrObra.Tag = "Sucursal"
        Me.ctrObra.Value2 = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Numero Otro Si:"
        '
        'ctrCodSucursal
        '
        Me.ctrCodSucursal.AlternativeColumn = "nombreObra"
        Me.ctrCodSucursal.ColToReturn = "idObra"
        Me.ctrCodSucursal.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.ctrCodSucursal.ColumnsToShow = New String() {"idObra", "nombreObra", "idVendedor"}
        Me.ctrCodSucursal.Dropdown_Width = 250
        Me.ctrCodSucursal.Id_Column_Name = "idCliente"
        Me.ctrCodSucursal.Location = New System.Drawing.Point(89, 33)
        Me.ctrCodSucursal.Maximo_Items_DropDown = 5
        Me.ctrCodSucursal.Name = "ctrCodSucursal"
        Me.ctrCodSucursal.selected_item = Nothing
        Me.ctrCodSucursal.Seleted_rowid = Nothing
        Me.ctrCodSucursal.Size = New System.Drawing.Size(132, 20)
        Me.ctrCodSucursal.TabIndex = 48
        Me.ctrCodSucursal.TablaFuente = Nothing
        Me.ctrCodSucursal.Tag = "Código Sucursal"
        Me.ctrCodSucursal.Value2 = Nothing
        '
        'txtnumero
        '
        Me.txtnumero.Location = New System.Drawing.Point(89, 88)
        Me.txtnumero.Name = "txtnumero"
        Me.txtnumero.Size = New System.Drawing.Size(184, 20)
        Me.txtnumero.TabIndex = 36
        '
        'ctrCliente
        '
        Me.ctrCliente.AlternativeColumn = "nit"
        Me.ctrCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ctrCliente.ColToReturn = "nombreCliente"
        Me.ctrCliente.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.ctrCliente.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.ctrCliente.Dropdown_Width = 500
        Me.ctrCliente.Id_Column_Name = "idCliente"
        Me.ctrCliente.Location = New System.Drawing.Point(295, 6)
        Me.ctrCliente.Maximo_Items_DropDown = 5
        Me.ctrCliente.Name = "ctrCliente"
        Me.ctrCliente.selected_item = Nothing
        Me.ctrCliente.Seleted_rowid = Nothing
        Me.ctrCliente.Size = New System.Drawing.Size(400, 20)
        Me.ctrCliente.TabIndex = 46
        Me.ctrCliente.TablaFuente = Nothing
        Me.ctrCliente.Tag = "Cliente"
        Me.ctrCliente.Value2 = Nothing
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Valor Otro Si:"
        '
        'ctrlNit
        '
        Me.ctrlNit.AlternativeColumn = "nombreCliente"
        Me.ctrlNit.ColToReturn = "nit"
        Me.ctrlNit.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.ctrlNit.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.ctrlNit.Dropdown_Width = 500
        Me.ctrlNit.Id_Column_Name = "idCliente"
        Me.ctrlNit.Location = New System.Drawing.Point(89, 8)
        Me.ctrlNit.Maximo_Items_DropDown = 5
        Me.ctrlNit.Name = "ctrlNit"
        Me.ctrlNit.selected_item = Nothing
        Me.ctrlNit.Seleted_rowid = Nothing
        Me.ctrlNit.Size = New System.Drawing.Size(132, 20)
        Me.ctrlNit.TabIndex = 44
        Me.ctrlNit.TablaFuente = Nothing
        Me.ctrlNit.Tag = "Nit"
        Me.ctrlNit.Value2 = Nothing
        '
        'nudvalor
        '
        Me.nudvalor.Location = New System.Drawing.Point(89, 116)
        Me.nudvalor.Maximum = New Decimal(New Integer() {-402653185, -1613725636, 54210108, 0})
        Me.nudvalor.Minimum = New Decimal(New Integer() {-159383553, 46653770, 5421, -2147483648})
        Me.nudvalor.Name = "nudvalor"
        Me.nudvalor.Size = New System.Drawing.Size(184, 20)
        Me.nudvalor.TabIndex = 42
        '
        'Label5
        '
        Me.Label5.AccessibleName = ""
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(238, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Sucursal:"
        '
        'Label8
        '
        Me.Label8.AccessibleName = "Nit Cliente"
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(60, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Nit:"
        '
        'Label6
        '
        Me.Label6.AccessibleName = ""
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(247, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Cliente:"
        '
        'Label7
        '
        Me.Label7.AccessibleName = "Codigo Sucursal"
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Cod Sucursal:"
        '
        'spespecificos
        '
        Me.spespecificos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spespecificos.Location = New System.Drawing.Point(0, 0)
        Me.spespecificos.Name = "spespecificos"
        '
        'spespecificos.Panel1
        '
        Me.spespecificos.Panel1.Controls.Add(Me.gbporcpolizas)
        '
        'spespecificos.Panel2
        '
        Me.spespecificos.Panel2.Controls.Add(Me.grObjeto)
        Me.spespecificos.Size = New System.Drawing.Size(700, 171)
        Me.spespecificos.SplitterDistance = 339
        Me.spespecificos.TabIndex = 36
        '
        'gbporcpolizas
        '
        Me.gbporcpolizas.Controls.Add(Me.dwItemsPoliza)
        Me.gbporcpolizas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbporcpolizas.Location = New System.Drawing.Point(0, 0)
        Me.gbporcpolizas.Name = "gbporcpolizas"
        Me.gbporcpolizas.Size = New System.Drawing.Size(339, 171)
        Me.gbporcpolizas.TabIndex = 35
        Me.gbporcpolizas.TabStop = False
        Me.gbporcpolizas.Text = "Porcentajes Polizas"
        '
        'dwItemsPoliza
        '
        Me.dwItemsPoliza.AllowUserToAddRows = False
        Me.dwItemsPoliza.AllowUserToDeleteRows = False
        Me.dwItemsPoliza.AllowUserToResizeColumns = False
        Me.dwItemsPoliza.AutoGenerateColumns = False
        Me.dwItemsPoliza.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItemsPoliza.BackgroundColor = System.Drawing.Color.White
        Me.dwItemsPoliza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItemsPoliza.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItemsPoliza.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selpol, Me.id, Me.FechaCreacion, Me.UsuarioCreacion, Me.Descripcion, Me.PorcentajeDefecto, Me.UsuarioModif, Me.FechaModi, Me.idEstado})
        Me.dwItemsPoliza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItemsPoliza.ImageList = Nothing
        Me.dwItemsPoliza.Location = New System.Drawing.Point(3, 16)
        Me.dwItemsPoliza.MostrarFiltros = False
        Me.dwItemsPoliza.Name = "dwItemsPoliza"
        Me.dwItemsPoliza.RowHeadersVisible = False
        Me.dwItemsPoliza.RowHeadersWidth = 25
        Me.dwItemsPoliza.Size = New System.Drawing.Size(333, 152)
        Me.dwItemsPoliza.TabIndex = 0
        Me.dwItemsPoliza.TablaDatos = Nothing
        Me.dwItemsPoliza.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'selpol
        '
        Me.selpol.Frozen = True
        Me.selpol.HeaderText = ""
        Me.selpol.Name = "selpol"
        Me.selpol.Width = 5
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha Creacion"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaCreacion.Visible = False
        Me.FechaCreacion.Width = 88
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creacion"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UsuarioCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioCreacion.Visible = False
        Me.UsuarioCreacion.Width = 94
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Descripcion.Width = 69
        '
        'PorcentajeDefecto
        '
        Me.PorcentajeDefecto.HeaderText = "Porcentaje Defecto"
        Me.PorcentajeDefecto.Name = "PorcentajeDefecto"
        Me.PorcentajeDefecto.Width = 114
        '
        'UsuarioModif
        '
        Me.UsuarioModif.HeaderText = "Usuario Modi"
        Me.UsuarioModif.Name = "UsuarioModif"
        Me.UsuarioModif.ReadOnly = True
        Me.UsuarioModif.Visible = False
        Me.UsuarioModif.Width = 87
        '
        'FechaModi
        '
        Me.FechaModi.HeaderText = "Fecha Modi"
        Me.FechaModi.Name = "FechaModi"
        Me.FechaModi.ReadOnly = True
        Me.FechaModi.Visible = False
        Me.FechaModi.Width = 81
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "id Estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 70
        '
        'grObjeto
        '
        Me.grObjeto.Controls.Add(Me.dwItemsObjetos)
        Me.grObjeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grObjeto.Location = New System.Drawing.Point(0, 0)
        Me.grObjeto.Name = "grObjeto"
        Me.grObjeto.Size = New System.Drawing.Size(357, 171)
        Me.grObjeto.TabIndex = 2
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
        Me.dwItemsObjetos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selected1, Me.id1, Me.FechaCreacion1, Me.usuarioCreacion1, Me.descripcion1, Me.UsuarioModif1, Me.fechaModi1, Me.idEstado1})
        Me.dwItemsObjetos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItemsObjetos.ImageList = Nothing
        Me.dwItemsObjetos.Location = New System.Drawing.Point(3, 16)
        Me.dwItemsObjetos.MostrarFiltros = False
        Me.dwItemsObjetos.Name = "dwItemsObjetos"
        Me.dwItemsObjetos.RowHeadersVisible = False
        Me.dwItemsObjetos.RowHeadersWidth = 25
        Me.dwItemsObjetos.Size = New System.Drawing.Size(351, 152)
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
        Me.id1.ReadOnly = True
        Me.id1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id1.Visible = False
        Me.id1.Width = 22
        '
        'FechaCreacion1
        '
        Me.FechaCreacion1.HeaderText = "Fecha Creacion"
        Me.FechaCreacion1.Name = "FechaCreacion1"
        Me.FechaCreacion1.ReadOnly = True
        Me.FechaCreacion1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FechaCreacion1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaCreacion1.Visible = False
        Me.FechaCreacion1.Width = 88
        '
        'usuarioCreacion1
        '
        Me.usuarioCreacion1.HeaderText = "Usuario Creacion"
        Me.usuarioCreacion1.Name = "usuarioCreacion1"
        Me.usuarioCreacion1.ReadOnly = True
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
        Me.UsuarioModif1.ReadOnly = True
        Me.UsuarioModif1.Visible = False
        Me.UsuarioModif1.Width = 94
        '
        'fechaModi1
        '
        Me.fechaModi1.HeaderText = "Fecha Modi"
        Me.fechaModi1.Name = "fechaModi1"
        Me.fechaModi1.ReadOnly = True
        Me.fechaModi1.Visible = False
        Me.fechaModi1.Width = 88
        '
        'idEstado1
        '
        Me.idEstado1.HeaderText = "id Estado"
        Me.idEstado1.Name = "idEstado1"
        Me.idEstado1.ReadOnly = True
        Me.idEstado1.Visible = False
        Me.idEstado1.Width = 76
        '
        'tpanticipos
        '
        Me.tpanticipos.Controls.Add(Me.dwItemsAnticipos)
        Me.tpanticipos.Controls.Add(Me.tsanticipos)
        Me.tpanticipos.Location = New System.Drawing.Point(4, 22)
        Me.tpanticipos.Name = "tpanticipos"
        Me.tpanticipos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpanticipos.Size = New System.Drawing.Size(706, 440)
        Me.tpanticipos.TabIndex = 2
        Me.tpanticipos.Text = "Plan de Anticipos"
        Me.tpanticipos.UseVisualStyleBackColor = True
        '
        'dwItemsAnticipos
        '
        Me.dwItemsAnticipos.AllowUserToAddRows = False
        Me.dwItemsAnticipos.AllowUserToDeleteRows = False
        Me.dwItemsAnticipos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwItemsAnticipos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItemsAnticipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItemsAnticipos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCuota, Me._ColnCuota, Me._colPorcentaje, Me.FechaCuota, Me._colValor})
        Me.dwItemsAnticipos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItemsAnticipos.Location = New System.Drawing.Point(3, 58)
        Me.dwItemsAnticipos.Name = "dwItemsAnticipos"
        Me.dwItemsAnticipos.RowHeadersVisible = False
        Me.dwItemsAnticipos.Size = New System.Drawing.Size(700, 379)
        Me.dwItemsAnticipos.TabIndex = 3
        '
        'idCuota
        '
        Me.idCuota.HeaderText = "id"
        Me.idCuota.Name = "idCuota"
        Me.idCuota.Visible = False
        '
        '_ColnCuota
        '
        Me._ColnCuota.HeaderText = "#Cuota"
        Me._ColnCuota.Name = "_ColnCuota"
        Me._ColnCuota.ReadOnly = True
        Me._ColnCuota.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me._ColnCuota.Width = 50
        '
        '_colPorcentaje
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me._colPorcentaje.DefaultCellStyle = DataGridViewCellStyle1
        Me._colPorcentaje.HeaderText = "% Anticipo"
        Me._colPorcentaje.Name = "_colPorcentaje"
        Me._colPorcentaje.ReadOnly = True
        Me._colPorcentaje.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me._colPorcentaje.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me._colPorcentaje.Width = 64
        '
        'FechaCuota
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FechaCuota.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaCuota.HeaderText = "Fecha Cuota"
        Me.FechaCuota.Name = "FechaCuota"
        '
        '_colValor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        DataGridViewCellStyle3.NullValue = "0"
        Me._colValor.DefaultCellStyle = DataGridViewCellStyle3
        Me._colValor.HeaderText = "Valor Anticipo"
        Me._colValor.Name = "_colValor"
        '
        'tsanticipos
        '
        Me.tsanticipos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.nudanticipo, Me.ToolStripLabel1, Me.nudcuotas, Me.ToolStripSeparator4, Me.ToolStripLabel2, Me.cmbDias, Me.ToolStripSeparator6, Me.ToolStripLabel8, Me.dtpfechaprimeracuota, Me.ToolStripSeparator5, Me.ToolStripLabel7, Me.txtValSuministro, Me.ToolStripSeparator8, Me.ToolStripLabel5, Me.txtValInstalacion, Me.ToolStripLabel6, Me.cbtipoanticipo, Me.btonCalculo, Me.btnCancelar, Me.idPlan})
        Me.tsanticipos.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.tsanticipos.Location = New System.Drawing.Point(3, 3)
        Me.tsanticipos.Name = "tsanticipos"
        Me.tsanticipos.Size = New System.Drawing.Size(700, 55)
        Me.tsanticipos.Stretch = True
        Me.tsanticipos.TabIndex = 4
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(65, 15)
        Me.ToolStripLabel3.Text = "% Anticipo"
        '
        'nudanticipo
        '
        Me.nudanticipo.Name = "nudanticipo"
        Me.nudanticipo.Size = New System.Drawing.Size(41, 23)
        Me.nudanticipo.Text = "0"
        Me.nudanticipo.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(54, 15)
        Me.ToolStripLabel1.Text = "# Cuotas"
        '
        'nudcuotas
        '
        Me.nudcuotas.Name = "nudcuotas"
        Me.nudcuotas.Size = New System.Drawing.Size(41, 23)
        Me.nudcuotas.Text = "0"
        Me.nudcuotas.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(66, 15)
        Me.ToolStripLabel2.Text = "Rango Días"
        '
        'cmbDias
        '
        Me.cmbDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDias.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDias.Items.AddRange(New Object() {"0", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60"})
        Me.cmbDias.Name = "cmbDias"
        Me.cmbDias.Size = New System.Drawing.Size(75, 23)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(104, 15)
        Me.ToolStripLabel8.Text = "Fecha Prim. Cuota"
        '
        'dtpfechaprimeracuota
        '
        Me.dtpfechaprimeracuota.AutoSize = False
        Me.dtpfechaprimeracuota.CustomFormat = Nothing
        Me.dtpfechaprimeracuota.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechaprimeracuota.Name = "dtpfechaprimeracuota"
        Me.dtpfechaprimeracuota.Size = New System.Drawing.Size(100, 23)
        Me.dtpfechaprimeracuota.Text = "15/09/2016"
        Me.dtpfechaprimeracuota.Value = New Date(2016, 9, 15, 15, 26, 34, 635)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(82, 15)
        Me.ToolStripLabel7.Text = "Val Suministro"
        '
        'txtValSuministro
        '
        Me.txtValSuministro.Name = "txtValSuministro"
        Me.txtValSuministro.Size = New System.Drawing.Size(19, 15)
        Me.txtValSuministro.Text = "$0"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 23)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(85, 15)
        Me.ToolStripLabel5.Text = "Val Instalación:"
        Me.ToolStripLabel5.ToolTipText = "Valor Instalación"
        '
        'txtValInstalacion
        '
        Me.txtValInstalacion.Name = "txtValInstalacion"
        Me.txtValInstalacion.Size = New System.Drawing.Size(19, 15)
        Me.txtValInstalacion.Text = "$0"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(74, 15)
        Me.ToolStripLabel6.Text = "Tipo Calculo"
        '
        'cbtipoanticipo
        '
        Me.cbtipoanticipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipoanticipo.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cbtipoanticipo.Name = "cbtipoanticipo"
        Me.cbtipoanticipo.Size = New System.Drawing.Size(121, 23)
        '
        'btonCalculo
        '
        Me.btonCalculo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btonCalculo.Image = CType(resources.GetObject("btonCalculo.Image"), System.Drawing.Image)
        Me.btonCalculo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btonCalculo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btonCalculo.Name = "btonCalculo"
        Me.btonCalculo.Size = New System.Drawing.Size(26, 26)
        Me.btonCalculo.Text = "AutoCalculo"
        Me.btonCalculo.ToolTipText = "Calcular"
        '
        'btnCancelar
        '
        Me.btnCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(23, 4)
        Me.btnCancelar.Text = "Cancelar"
        '
        'idPlan
        '
        Me.idPlan.Name = "idPlan"
        Me.idPlan.Size = New System.Drawing.Size(17, 15)
        Me.idPlan.Text = "--"
        Me.idPlan.Visible = False
        '
        'tpminuta
        '
        Me.tpminuta.Controls.Add(Me.editorMinutas)
        Me.tpminuta.Location = New System.Drawing.Point(4, 22)
        Me.tpminuta.Name = "tpminuta"
        Me.tpminuta.Padding = New System.Windows.Forms.Padding(3)
        Me.tpminuta.Size = New System.Drawing.Size(706, 440)
        Me.tpminuta.TabIndex = 1
        Me.tpminuta.Text = "Minuta"
        Me.tpminuta.UseVisualStyleBackColor = True
        '
        'editorMinutas
        '
        Me.editorMinutas.AltoEncabezado = New Decimal(New Integer() {125, 0, 0, 131072})
        Me.editorMinutas.AltoPiedePagina = New Decimal(New Integer() {125, 0, 0, 131072})
        Me.editorMinutas.BackColor = System.Drawing.Color.White
        Me.editorMinutas.Cuerpo = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editorMinutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editorMinutas.Encabezado = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editorMinutas.Location = New System.Drawing.Point(3, 3)
        Me.editorMinutas.Name = "editorMinutas"
        Me.editorMinutas.PiedePagina = "{\rtf1\ansi\ansicpg1252\deff0\deflang3082{\fonttbl{\f0\fnil\fcharset0 Calibri;}}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "\viewkind4\uc1\pard\f0\fs20\par" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.editorMinutas.Size = New System.Drawing.Size(700, 434)
        Me.editorMinutas.TabIndex = 1
        Me.editorMinutas.TablasValoresVariables = Nothing
        Me.editorMinutas.TablaVariables = Nothing
        Me.editorMinutas.Tag = "0"
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnnuevo, Me.btnguardar, Me.tsseparador, Me.ddbformatos, Me.lbindnombre, Me.lbnombredocumento, Me.tssep2, Me.sbimprimir, Me.sbexportar, Me.btncombinar, Me.lbotrosi, Me.ToolStripSeparator1, Me.ToolStripLabel9})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(714, 25)
        Me.tsherramientas.TabIndex = 30
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnnuevo
        '
        Me.btnnuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnnuevo.Image = CType(resources.GetObject("btnnuevo.Image"), System.Drawing.Image)
        Me.btnnuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(23, 22)
        Me.btnnuevo.Text = "Nuevo"
        '
        'btnguardar
        '
        Me.btnguardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(23, 22)
        Me.btnguardar.Text = "2q"
        '
        'tsseparador
        '
        Me.tsseparador.Name = "tsseparador"
        Me.tsseparador.Size = New System.Drawing.Size(6, 25)
        Me.tsseparador.Visible = False
        '
        'ddbformatos
        '
        Me.ddbformatos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ddbformatos.Image = CType(resources.GetObject("ddbformatos.Image"), System.Drawing.Image)
        Me.ddbformatos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ddbformatos.Name = "ddbformatos"
        Me.ddbformatos.Size = New System.Drawing.Size(29, 22)
        Me.ddbformatos.Text = "Documentos"
        Me.ddbformatos.Visible = False
        '
        'lbindnombre
        '
        Me.lbindnombre.Name = "lbindnombre"
        Me.lbindnombre.Size = New System.Drawing.Size(120, 22)
        Me.lbindnombre.Text = "Nombre Documento:"
        Me.lbindnombre.Visible = False
        '
        'lbnombredocumento
        '
        Me.lbnombredocumento.Name = "lbnombredocumento"
        Me.lbnombredocumento.Size = New System.Drawing.Size(17, 22)
        Me.lbnombredocumento.Text = "--"
        Me.lbnombredocumento.Visible = False
        '
        'tssep2
        '
        Me.tssep2.Name = "tssep2"
        Me.tssep2.Size = New System.Drawing.Size(6, 25)
        Me.tssep2.Visible = False
        '
        'sbimprimir
        '
        Me.sbimprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sbimprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnvistaprevia, Me.btnimprimir})
        Me.sbimprimir.Image = CType(resources.GetObject("sbimprimir.Image"), System.Drawing.Image)
        Me.sbimprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sbimprimir.Name = "sbimprimir"
        Me.sbimprimir.Size = New System.Drawing.Size(32, 22)
        Me.sbimprimir.Text = "ToolStripSplitButton1"
        Me.sbimprimir.Visible = False
        '
        'btnvistaprevia
        '
        Me.btnvistaprevia.Image = CType(resources.GetObject("btnvistaprevia.Image"), System.Drawing.Image)
        Me.btnvistaprevia.Name = "btnvistaprevia"
        Me.btnvistaprevia.Size = New System.Drawing.Size(134, 22)
        Me.btnvistaprevia.Text = "Vista Previa"
        '
        'btnimprimir
        '
        Me.btnimprimir.Image = CType(resources.GetObject("btnimprimir.Image"), System.Drawing.Image)
        Me.btnimprimir.Name = "btnimprimir"
        Me.btnimprimir.Size = New System.Drawing.Size(134, 22)
        Me.btnimprimir.Text = "Imprimir"
        '
        'sbexportar
        '
        Me.sbexportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sbexportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnword, Me.btnpdf})
        Me.sbexportar.Image = CType(resources.GetObject("sbexportar.Image"), System.Drawing.Image)
        Me.sbexportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sbexportar.Name = "sbexportar"
        Me.sbexportar.Size = New System.Drawing.Size(32, 22)
        Me.sbexportar.Text = "ToolStripSplitButton2"
        Me.sbexportar.Visible = False
        '
        'btnword
        '
        Me.btnword.Image = CType(resources.GetObject("btnword.Image"), System.Drawing.Image)
        Me.btnword.Name = "btnword"
        Me.btnword.Size = New System.Drawing.Size(103, 22)
        Me.btnword.Text = "Word"
        '
        'btnpdf
        '
        Me.btnpdf.Image = CType(resources.GetObject("btnpdf.Image"), System.Drawing.Image)
        Me.btnpdf.Name = "btnpdf"
        Me.btnpdf.Size = New System.Drawing.Size(103, 22)
        Me.btnpdf.Text = "Pdf"
        '
        'btncombinar
        '
        Me.btncombinar.CheckOnClick = True
        Me.btncombinar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btncombinar.Image = CType(resources.GetObject("btncombinar.Image"), System.Drawing.Image)
        Me.btncombinar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncombinar.Name = "btncombinar"
        Me.btncombinar.Size = New System.Drawing.Size(23, 22)
        Me.btncombinar.Text = "Combinar valores"
        Me.btncombinar.Visible = False
        '
        'lbotrosi
        '
        Me.lbotrosi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbotrosi.Name = "lbotrosi"
        Me.lbotrosi.Size = New System.Drawing.Size(17, 22)
        Me.lbotrosi.Text = "--"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel9.Text = "Otro Si"
        '
        'FrmOtroSi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 491)
        Me.Controls.Add(Me.tbgeneral)
        Me.Controls.Add(Me.tsherramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmOtroSi"
        Me.ShowIcon = False
        Me.Text = "Otro Si"
        Me.gbnotas.ResumeLayout(False)
        Me.tbgeneral.ResumeLayout(False)
        Me.tpgeneral.ResumeLayout(False)
        Me.spcontendorgeneral.Panel1.ResumeLayout(False)
        Me.spcontendorgeneral.Panel1.PerformLayout()
        Me.spcontendorgeneral.Panel2.ResumeLayout(False)
        CType(Me.spcontendorgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcontendorgeneral.ResumeLayout(False)
        CType(Me.nudvalor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spespecificos.Panel1.ResumeLayout(False)
        Me.spespecificos.Panel2.ResumeLayout(False)
        CType(Me.spespecificos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spespecificos.ResumeLayout(False)
        Me.gbporcpolizas.ResumeLayout(False)
        CType(Me.dwItemsPoliza, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grObjeto.ResumeLayout(False)
        CType(Me.dwItemsObjetos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpanticipos.ResumeLayout(False)
        Me.tpanticipos.PerformLayout()
        CType(Me.dwItemsAnticipos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsanticipos.ResumeLayout(False)
        Me.tsanticipos.PerformLayout()
        Me.tpminuta.ResumeLayout(False)
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbnotas As GroupBox
    Friend WithEvents rtbnotas As RichTextBox
    Friend WithEvents tbgeneral As TabControl
    Friend WithEvents tpgeneral As TabPage
    Friend WithEvents tpminuta As TabPage
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnguardar As ToolStripButton
    Friend WithEvents tsseparador As ToolStripSeparator
    Friend WithEvents editorMinutas As ControlesPersonalizados.Editor_RTF.EditorRTF
    Friend WithEvents ddbformatos As ToolStripDropDownButton
    Friend WithEvents lbindnombre As ToolStripLabel
    Friend WithEvents tssep2 As ToolStripSeparator
    Friend WithEvents sbimprimir As ToolStripSplitButton
    Friend WithEvents btnvistaprevia As ToolStripMenuItem
    Friend WithEvents btnimprimir As ToolStripMenuItem
    Friend WithEvents sbexportar As ToolStripSplitButton
    Friend WithEvents btnword As ToolStripMenuItem
    Friend WithEvents btnpdf As ToolStripMenuItem
    Friend WithEvents btncombinar As ToolStripButton
    Friend WithEvents lbnombredocumento As ToolStripLabel
    Friend WithEvents btnnuevo As ToolStripButton
    Friend WithEvents tpanticipos As TabPage
    Friend WithEvents dwItemsAnticipos As DataGridView
    Friend WithEvents idCuota As DataGridViewTextBoxColumn
    Friend WithEvents _ColnCuota As DataGridViewTextBoxColumn
    Friend WithEvents _colPorcentaje As DataGridViewTextBoxColumn
    Friend WithEvents FechaCuota As DateTimeGridColumn
    Friend WithEvents _colValor As DataGridViewTextBoxColumn
    Friend WithEvents tsanticipos As ToolStrip
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cmbDias As ToolStripComboBox
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents txtValSuministro As ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents txtValInstalacion As ToolStripLabel
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents cbtipoanticipo As ToolStripComboBox
    Friend WithEvents btonCalculo As ToolStripButton
    Friend WithEvents btnCancelar As ToolStripButton
    Friend WithEvents idPlan As ToolStripLabel
    Friend WithEvents dtpfechaprimeracuota As ToolStrip_Extras.DatetimePickerToolStripItem
    Friend WithEvents nudanticipo As ToolStrip_Extras.NumericUpDownToolStripItem
    Friend WithEvents nudcuotas As ToolStrip_Extras.NumericUpDownToolStripItem
    Friend WithEvents gbporcpolizas As GroupBox
    Friend WithEvents dwItemsPoliza As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents spcontendorgeneral As SplitContainer
    Friend WithEvents txtformaPago As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtcedularepr As TextBox
    Friend WithEvents txtrepresentante As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents ClienteYo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents NitYo As Label
    Friend WithEvents dtpfechainicial As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents dtpfechafinal As DateTimePicker
    Friend WithEvents Label19 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ctrObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label1 As Label
    Friend WithEvents ctrCodSucursal As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents txtnumero As TextBox
    Friend WithEvents ctrCliente As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label4 As Label
    Friend WithEvents ctrlNit As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents nudvalor As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents spespecificos As SplitContainer
    Friend WithEvents selpol As DataGridViewCheckBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents PorcentajeDefecto As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModif As DataGridViewTextBoxColumn
    Friend WithEvents FechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
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
    Friend WithEvents lbotrosi As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel9 As ToolStripLabel
End Class
