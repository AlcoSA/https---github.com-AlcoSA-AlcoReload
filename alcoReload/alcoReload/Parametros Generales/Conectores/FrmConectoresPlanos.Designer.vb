<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConectoresPlanos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConectoresPlanos))
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tspconectores = New System.Windows.Forms.ToolStrip()
        Me.btnabrirconector = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtNombreConector = New System.Windows.Forms.ToolStripTextBox()
        Me.dwconector = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreCampo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.indObligatorio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.posicionInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posicionFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.longitud = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Decimales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorDefecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.autoincremento = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.splitAdiciones = New System.Windows.Forms.SplitContainer()
        Me.listaHojas = New System.Windows.Forms.ListBox()
        Me.tbgeneral = New System.Windows.Forms.TabControl()
        Me.tbAdicion = New System.Windows.Forms.TabPage()
        Me.tbConsulta = New System.Windows.Forms.TabPage()
        Me.splitConsultas = New System.Windows.Forms.SplitContainer()
        Me.dwConectores = New System.Windows.Forms.DataGridView()
        Me.idConector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Conector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dwconectorconsulta = New System.Windows.Forms.DataGridView()
        Me.id1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idConector1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreCampo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipoDato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoDato1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observaciones1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.indObligatorio1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.inicio1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fin1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.longitud1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.decimales1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorDefecto1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.formato1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.autoincrement = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpcombinar = New System.Windows.Forms.TabPage()
        Me.spcombinacion = New System.Windows.Forms.SplitContainer()
        Me.tlpcontenedor = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbconectores = New System.Windows.Forms.ComboBox()
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombreplano = New System.Windows.Forms.TextBox()
        Me.tlpformulario = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbformulario = New System.Windows.Forms.ComboBox()
        Me.pformulario = New System.Windows.Forms.Panel()
        Me.bwCarga = New System.ComponentModel.BackgroundWorker()
        Me.idenlace = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.campo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcioncampo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controlasociado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipocontrol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valordefectocampo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.autoincrementocampo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.obligatorio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tspconectores.SuspendLayout()
        CType(Me.dwconector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.splitAdiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitAdiciones.Panel1.SuspendLayout()
        Me.splitAdiciones.Panel2.SuspendLayout()
        Me.splitAdiciones.SuspendLayout()
        Me.tbgeneral.SuspendLayout()
        Me.tbAdicion.SuspendLayout()
        Me.tbConsulta.SuspendLayout()
        CType(Me.splitConsultas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitConsultas.Panel1.SuspendLayout()
        Me.splitConsultas.Panel2.SuspendLayout()
        Me.splitConsultas.SuspendLayout()
        CType(Me.dwConectores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwconectorconsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpcombinar.SuspendLayout()
        CType(Me.spcombinacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcombinacion.Panel1.SuspendLayout()
        Me.spcombinacion.Panel2.SuspendLayout()
        Me.spcombinacion.SuspendLayout()
        Me.tlpcontenedor.SuspendLayout()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpformulario.SuspendLayout()
        Me.SuspendLayout()
        '
        'tspconectores
        '
        Me.tspconectores.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tspconectores.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnabrirconector, Me.ToolStripLabel1, Me.txtNombreConector})
        Me.tspconectores.Location = New System.Drawing.Point(3, 3)
        Me.tspconectores.Name = "tspconectores"
        Me.tspconectores.Size = New System.Drawing.Size(806, 30)
        Me.tspconectores.TabIndex = 0
        Me.tspconectores.Text = "ToolStrip1"
        '
        'btnabrirconector
        '
        Me.btnabrirconector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnabrirconector.Image = CType(resources.GetObject("btnabrirconector.Image"), System.Drawing.Image)
        Me.btnabrirconector.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnabrirconector.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnabrirconector.Name = "btnabrirconector"
        Me.btnabrirconector.Size = New System.Drawing.Size(27, 27)
        Me.btnabrirconector.Text = "Abrir Conector"
        Me.btnabrirconector.ToolTipText = "Cargar Archivo"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(106, 27)
        Me.ToolStripLabel1.Text = "Nombre Conector:"
        '
        'txtNombreConector
        '
        Me.txtNombreConector.AutoSize = False
        Me.txtNombreConector.MaxLength = 255
        Me.txtNombreConector.Name = "txtNombreConector"
        Me.txtNombreConector.Size = New System.Drawing.Size(450, 30)
        '
        'dwconector
        '
        Me.dwconector.AllowUserToAddRows = False
        Me.dwconector.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dwconector.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dwconector.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dwconector.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwconector.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwconector.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombreCampo, Me.descripcion, Me.TipoDato, Me.Observaciones, Me.indObligatorio, Me.posicionInicial, Me.posicionFinal, Me.longitud, Me.Decimales, Me.valorDefecto, Me.Formato, Me.autoincremento})
        Me.dwconector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwconector.Location = New System.Drawing.Point(0, 0)
        Me.dwconector.Name = "dwconector"
        Me.dwconector.RowHeadersVisible = False
        Me.dwconector.Size = New System.Drawing.Size(692, 419)
        Me.dwconector.TabIndex = 1
        '
        'id
        '
        DataGridViewCellStyle2.NullValue = "0"
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'nombreCampo
        '
        Me.nombreCampo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.nombreCampo.HeaderText = "Nombre Campo"
        Me.nombreCampo.Name = "nombreCampo"
        Me.nombreCampo.ReadOnly = True
        Me.nombreCampo.Width = 96
        '
        'descripcion
        '
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle3
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 150
        '
        'TipoDato
        '
        Me.TipoDato.HeaderText = "Tipo Dato"
        Me.TipoDato.Name = "TipoDato"
        Me.TipoDato.ReadOnly = True
        '
        'Observaciones
        '
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Observaciones.DefaultCellStyle = DataGridViewCellStyle4
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        Me.Observaciones.ReadOnly = True
        Me.Observaciones.Width = 250
        '
        'indObligatorio
        '
        Me.indObligatorio.HeaderText = "Obligatorio"
        Me.indObligatorio.Name = "indObligatorio"
        Me.indObligatorio.ReadOnly = True
        '
        'posicionInicial
        '
        Me.posicionInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.posicionInicial.DefaultCellStyle = DataGridViewCellStyle5
        Me.posicionInicial.HeaderText = "Inicio"
        Me.posicionInicial.Name = "posicionInicial"
        Me.posicionInicial.ReadOnly = True
        Me.posicionInicial.Width = 57
        '
        'posicionFinal
        '
        Me.posicionFinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.posicionFinal.DefaultCellStyle = DataGridViewCellStyle6
        Me.posicionFinal.HeaderText = "Final"
        Me.posicionFinal.Name = "posicionFinal"
        Me.posicionFinal.ReadOnly = True
        Me.posicionFinal.Width = 54
        '
        'longitud
        '
        Me.longitud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.longitud.DefaultCellStyle = DataGridViewCellStyle7
        Me.longitud.HeaderText = "Longitud"
        Me.longitud.Name = "longitud"
        Me.longitud.ReadOnly = True
        Me.longitud.Width = 73
        '
        'Decimales
        '
        Me.Decimales.HeaderText = "Decimales"
        Me.Decimales.Name = "Decimales"
        '
        'valorDefecto
        '
        Me.valorDefecto.HeaderText = "Valor Defecto"
        Me.valorDefecto.Name = "valorDefecto"
        '
        'Formato
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Formato.DefaultCellStyle = DataGridViewCellStyle8
        Me.Formato.HeaderText = "formato"
        Me.Formato.Name = "Formato"
        Me.Formato.ReadOnly = True
        '
        'autoincremento
        '
        Me.autoincremento.HeaderText = "AutoIncremento"
        Me.autoincremento.Name = "autoincremento"
        '
        'splitAdiciones
        '
        Me.splitAdiciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.splitAdiciones.IsSplitterFixed = True
        Me.splitAdiciones.Location = New System.Drawing.Point(0, 36)
        Me.splitAdiciones.Name = "splitAdiciones"
        '
        'splitAdiciones.Panel1
        '
        Me.splitAdiciones.Panel1.Controls.Add(Me.listaHojas)
        '
        'splitAdiciones.Panel2
        '
        Me.splitAdiciones.Panel2.Controls.Add(Me.dwconector)
        Me.splitAdiciones.Size = New System.Drawing.Size(812, 419)
        Me.splitAdiciones.SplitterDistance = 116
        Me.splitAdiciones.TabIndex = 2
        '
        'listaHojas
        '
        Me.listaHojas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listaHojas.FormattingEnabled = True
        Me.listaHojas.Location = New System.Drawing.Point(0, 0)
        Me.listaHojas.Name = "listaHojas"
        Me.listaHojas.Size = New System.Drawing.Size(116, 419)
        Me.listaHojas.TabIndex = 0
        '
        'tbgeneral
        '
        Me.tbgeneral.Controls.Add(Me.tbAdicion)
        Me.tbgeneral.Controls.Add(Me.tbConsulta)
        Me.tbgeneral.Controls.Add(Me.tpcombinar)
        Me.tbgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbgeneral.Location = New System.Drawing.Point(0, 0)
        Me.tbgeneral.Name = "tbgeneral"
        Me.tbgeneral.SelectedIndex = 0
        Me.tbgeneral.Size = New System.Drawing.Size(820, 481)
        Me.tbgeneral.TabIndex = 3
        '
        'tbAdicion
        '
        Me.tbAdicion.Controls.Add(Me.tspconectores)
        Me.tbAdicion.Controls.Add(Me.splitAdiciones)
        Me.tbAdicion.Location = New System.Drawing.Point(4, 22)
        Me.tbAdicion.Name = "tbAdicion"
        Me.tbAdicion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAdicion.Size = New System.Drawing.Size(812, 455)
        Me.tbAdicion.TabIndex = 0
        Me.tbAdicion.Text = "Adición"
        Me.tbAdicion.UseVisualStyleBackColor = True
        '
        'tbConsulta
        '
        Me.tbConsulta.Controls.Add(Me.splitConsultas)
        Me.tbConsulta.Location = New System.Drawing.Point(4, 22)
        Me.tbConsulta.Name = "tbConsulta"
        Me.tbConsulta.Padding = New System.Windows.Forms.Padding(3)
        Me.tbConsulta.Size = New System.Drawing.Size(812, 455)
        Me.tbConsulta.TabIndex = 1
        Me.tbConsulta.Text = "Consulta"
        Me.tbConsulta.UseVisualStyleBackColor = True
        '
        'splitConsultas
        '
        Me.splitConsultas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitConsultas.IsSplitterFixed = True
        Me.splitConsultas.Location = New System.Drawing.Point(3, 3)
        Me.splitConsultas.Name = "splitConsultas"
        '
        'splitConsultas.Panel1
        '
        Me.splitConsultas.Panel1.Controls.Add(Me.dwConectores)
        '
        'splitConsultas.Panel2
        '
        Me.splitConsultas.Panel2.Controls.Add(Me.dwconectorconsulta)
        Me.splitConsultas.Size = New System.Drawing.Size(806, 449)
        Me.splitConsultas.SplitterDistance = 191
        Me.splitConsultas.TabIndex = 0
        '
        'dwConectores
        '
        Me.dwConectores.AllowUserToAddRows = False
        Me.dwConectores.AllowUserToDeleteRows = False
        Me.dwConectores.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwConectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwConectores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idConector, Me.Conector})
        Me.dwConectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwConectores.Location = New System.Drawing.Point(0, 0)
        Me.dwConectores.Name = "dwConectores"
        Me.dwConectores.ReadOnly = True
        Me.dwConectores.RowHeadersVisible = False
        Me.dwConectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwConectores.Size = New System.Drawing.Size(191, 449)
        Me.dwConectores.TabIndex = 0
        '
        'idConector
        '
        Me.idConector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.idConector.HeaderText = "id"
        Me.idConector.Name = "idConector"
        Me.idConector.ReadOnly = True
        Me.idConector.Width = 50
        '
        'Conector
        '
        Me.Conector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Conector.HeaderText = "Conector"
        Me.Conector.Name = "Conector"
        Me.Conector.ReadOnly = True
        Me.Conector.Width = 75
        '
        'dwconectorconsulta
        '
        Me.dwconectorconsulta.AllowUserToAddRows = False
        Me.dwconectorconsulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dwconectorconsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dwconectorconsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dwconectorconsulta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwconectorconsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwconectorconsulta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id1, Me.idConector1, Me.nombreCampo1, Me.descripcion1, Me.idtipoDato, Me.TipoDato1, Me.observaciones1, Me.indObligatorio1, Me.inicio1, Me.fin1, Me.longitud1, Me.decimales1, Me.valorDefecto1, Me.formato1, Me.autoincrement})
        Me.dwconectorconsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwconectorconsulta.Location = New System.Drawing.Point(0, 0)
        Me.dwconectorconsulta.Name = "dwconectorconsulta"
        Me.dwconectorconsulta.RowHeadersVisible = False
        Me.dwconectorconsulta.Size = New System.Drawing.Size(611, 449)
        Me.dwconectorconsulta.TabIndex = 2
        '
        'id1
        '
        DataGridViewCellStyle10.NullValue = "0"
        Me.id1.DefaultCellStyle = DataGridViewCellStyle10
        Me.id1.HeaderText = "id"
        Me.id1.Name = "id1"
        Me.id1.ReadOnly = True
        Me.id1.Width = 60
        '
        'idConector1
        '
        Me.idConector1.HeaderText = "Conector"
        Me.idConector1.Name = "idConector1"
        Me.idConector1.ReadOnly = True
        Me.idConector1.Visible = False
        '
        'nombreCampo1
        '
        Me.nombreCampo1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.nombreCampo1.HeaderText = "Nombre Campo"
        Me.nombreCampo1.Name = "nombreCampo1"
        Me.nombreCampo1.ReadOnly = True
        Me.nombreCampo1.Width = 96
        '
        'descripcion1
        '
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.descripcion1.DefaultCellStyle = DataGridViewCellStyle11
        Me.descripcion1.HeaderText = "Descripcion"
        Me.descripcion1.Name = "descripcion1"
        Me.descripcion1.ReadOnly = True
        Me.descripcion1.Width = 150
        '
        'idtipoDato
        '
        Me.idtipoDato.HeaderText = "id Tipo Dato"
        Me.idtipoDato.Name = "idtipoDato"
        Me.idtipoDato.ReadOnly = True
        Me.idtipoDato.Visible = False
        '
        'TipoDato1
        '
        Me.TipoDato1.HeaderText = "Tipo Dato"
        Me.TipoDato1.Name = "TipoDato1"
        '
        'observaciones1
        '
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.observaciones1.DefaultCellStyle = DataGridViewCellStyle12
        Me.observaciones1.HeaderText = "Observaciones"
        Me.observaciones1.Name = "observaciones1"
        Me.observaciones1.ReadOnly = True
        Me.observaciones1.Width = 250
        '
        'indObligatorio1
        '
        Me.indObligatorio1.HeaderText = "Obligatorio"
        Me.indObligatorio1.Name = "indObligatorio1"
        Me.indObligatorio1.ReadOnly = True
        '
        'inicio1
        '
        Me.inicio1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.inicio1.DefaultCellStyle = DataGridViewCellStyle13
        Me.inicio1.HeaderText = "Inicio"
        Me.inicio1.Name = "inicio1"
        Me.inicio1.ReadOnly = True
        Me.inicio1.Width = 57
        '
        'fin1
        '
        Me.fin1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.fin1.DefaultCellStyle = DataGridViewCellStyle14
        Me.fin1.HeaderText = "Final"
        Me.fin1.Name = "fin1"
        Me.fin1.ReadOnly = True
        Me.fin1.Width = 54
        '
        'longitud1
        '
        Me.longitud1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.longitud1.DefaultCellStyle = DataGridViewCellStyle15
        Me.longitud1.HeaderText = "Longitud"
        Me.longitud1.Name = "longitud1"
        Me.longitud1.ReadOnly = True
        Me.longitud1.Width = 73
        '
        'decimales1
        '
        Me.decimales1.HeaderText = "Decimales"
        Me.decimales1.Name = "decimales1"
        '
        'valorDefecto1
        '
        Me.valorDefecto1.HeaderText = "Valor Defecto"
        Me.valorDefecto1.Name = "valorDefecto1"
        '
        'formato1
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.formato1.DefaultCellStyle = DataGridViewCellStyle16
        Me.formato1.HeaderText = "formato"
        Me.formato1.Name = "formato1"
        Me.formato1.ReadOnly = True
        '
        'autoincrement
        '
        Me.autoincrement.HeaderText = "Autoincremento"
        Me.autoincrement.Name = "autoincrement"
        '
        'tpcombinar
        '
        Me.tpcombinar.Controls.Add(Me.spcombinacion)
        Me.tpcombinar.Location = New System.Drawing.Point(4, 22)
        Me.tpcombinar.Name = "tpcombinar"
        Me.tpcombinar.Padding = New System.Windows.Forms.Padding(3)
        Me.tpcombinar.Size = New System.Drawing.Size(812, 455)
        Me.tpcombinar.TabIndex = 2
        Me.tpcombinar.Text = "Combinar"
        Me.tpcombinar.UseVisualStyleBackColor = True
        '
        'spcombinacion
        '
        Me.spcombinacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcombinacion.Location = New System.Drawing.Point(3, 3)
        Me.spcombinacion.Name = "spcombinacion"
        '
        'spcombinacion.Panel1
        '
        Me.spcombinacion.Panel1.Controls.Add(Me.tlpcontenedor)
        '
        'spcombinacion.Panel2
        '
        Me.spcombinacion.Panel2.Controls.Add(Me.tlpformulario)
        Me.spcombinacion.Size = New System.Drawing.Size(806, 449)
        Me.spcombinacion.SplitterDistance = 261
        Me.spcombinacion.TabIndex = 0
        '
        'tlpcontenedor
        '
        Me.tlpcontenedor.ColumnCount = 1
        Me.tlpcontenedor.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpcontenedor.Controls.Add(Me.Label1, 0, 0)
        Me.tlpcontenedor.Controls.Add(Me.cmbconectores, 0, 1)
        Me.tlpcontenedor.Controls.Add(Me.dwitems, 0, 4)
        Me.tlpcontenedor.Controls.Add(Me.Label3, 0, 2)
        Me.tlpcontenedor.Controls.Add(Me.txtnombreplano, 0, 3)
        Me.tlpcontenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpcontenedor.Location = New System.Drawing.Point(0, 0)
        Me.tlpcontenedor.Name = "tlpcontenedor"
        Me.tlpcontenedor.RowCount = 5
        Me.tlpcontenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpcontenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpcontenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpcontenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpcontenedor.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpcontenedor.Size = New System.Drawing.Size(261, 449)
        Me.tlpcontenedor.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Conector"
        '
        'cmbconectores
        '
        Me.cmbconectores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbconectores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbconectores.FormattingEnabled = True
        Me.cmbconectores.Location = New System.Drawing.Point(3, 23)
        Me.cmbconectores.Name = "cmbconectores"
        Me.cmbconectores.Size = New System.Drawing.Size(255, 21)
        Me.cmbconectores.TabIndex = 1
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idenlace, Me.idcon, Me.campo, Me.descripcioncampo, Me.controlasociado, Me.tipocontrol, Me.valordefectocampo, Me.autoincrementocampo, Me.obligatorio})
        Me.dwitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwitems.Location = New System.Drawing.Point(3, 93)
        Me.dwitems.MultiSelect = False
        Me.dwitems.Name = "dwitems"
        Me.dwitems.ReadOnly = True
        Me.dwitems.RowHeadersWidth = 20
        Me.dwitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwitems.Size = New System.Drawing.Size(255, 353)
        Me.dwitems.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nombre Plano"
        '
        'txtnombreplano
        '
        Me.txtnombreplano.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtnombreplano.Location = New System.Drawing.Point(3, 68)
        Me.txtnombreplano.Name = "txtnombreplano"
        Me.txtnombreplano.Size = New System.Drawing.Size(255, 20)
        Me.txtnombreplano.TabIndex = 4
        '
        'tlpformulario
        '
        Me.tlpformulario.ColumnCount = 2
        Me.tlpformulario.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.22124!))
        Me.tlpformulario.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.77876!))
        Me.tlpformulario.Controls.Add(Me.Label2, 0, 0)
        Me.tlpformulario.Controls.Add(Me.cmbformulario, 1, 0)
        Me.tlpformulario.Controls.Add(Me.pformulario, 0, 1)
        Me.tlpformulario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpformulario.Location = New System.Drawing.Point(0, 0)
        Me.tlpformulario.Name = "tlpformulario"
        Me.tlpformulario.RowCount = 2
        Me.tlpformulario.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.454343!))
        Me.tlpformulario.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.54565!))
        Me.tlpformulario.Size = New System.Drawing.Size(541, 449)
        Me.tlpformulario.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Formulario"
        '
        'cmbformulario
        '
        Me.cmbformulario.FormattingEnabled = True
        Me.cmbformulario.Location = New System.Drawing.Point(85, 3)
        Me.cmbformulario.Name = "cmbformulario"
        Me.cmbformulario.Size = New System.Drawing.Size(234, 21)
        Me.cmbformulario.TabIndex = 1
        '
        'pformulario
        '
        Me.pformulario.AutoScroll = True
        Me.tlpformulario.SetColumnSpan(Me.pformulario, 2)
        Me.pformulario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pformulario.Location = New System.Drawing.Point(3, 23)
        Me.pformulario.Name = "pformulario"
        Me.pformulario.Size = New System.Drawing.Size(535, 423)
        Me.pformulario.TabIndex = 2
        '
        'bwCarga
        '
        Me.bwCarga.WorkerReportsProgress = True
        Me.bwCarga.WorkerSupportsCancellation = True
        '
        'idenlace
        '
        Me.idenlace.HeaderText = "idmovcon"
        Me.idenlace.Name = "idenlace"
        Me.idenlace.ReadOnly = True
        Me.idenlace.Width = 78
        '
        'idcon
        '
        Me.idcon.HeaderText = "IdCon"
        Me.idcon.Name = "idcon"
        Me.idcon.ReadOnly = True
        Me.idcon.Visible = False
        Me.idcon.Width = 60
        '
        'campo
        '
        Me.campo.HeaderText = "Campo"
        Me.campo.Name = "campo"
        Me.campo.ReadOnly = True
        Me.campo.Width = 65
        '
        'descripcioncampo
        '
        Me.descripcioncampo.HeaderText = "Descripcion"
        Me.descripcioncampo.Name = "descripcioncampo"
        Me.descripcioncampo.ReadOnly = True
        Me.descripcioncampo.Width = 88
        '
        'controlasociado
        '
        Me.controlasociado.HeaderText = "Control Asociado"
        Me.controlasociado.Name = "controlasociado"
        Me.controlasociado.ReadOnly = True
        Me.controlasociado.Width = 103
        '
        'tipocontrol
        '
        Me.tipocontrol.HeaderText = "Tipo Control"
        Me.tipocontrol.Name = "tipocontrol"
        Me.tipocontrol.ReadOnly = True
        Me.tipocontrol.Width = 82
        '
        'valordefectocampo
        '
        Me.valordefectocampo.HeaderText = "Valor Defecto"
        Me.valordefectocampo.Name = "valordefectocampo"
        Me.valordefectocampo.ReadOnly = True
        Me.valordefectocampo.Width = 89
        '
        'autoincrementocampo
        '
        Me.autoincrementocampo.HeaderText = "Autoincremento"
        Me.autoincrementocampo.Name = "autoincrementocampo"
        Me.autoincrementocampo.ReadOnly = True
        Me.autoincrementocampo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.autoincrementocampo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.autoincrementocampo.Width = 106
        '
        'obligatorio
        '
        Me.obligatorio.HeaderText = "Obligatorio"
        Me.obligatorio.Name = "obligatorio"
        Me.obligatorio.ReadOnly = True
        Me.obligatorio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.obligatorio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.obligatorio.Width = 82
        '
        'FrmConectoresPlanos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 481)
        Me.Controls.Add(Me.tbgeneral)
        Me.Name = "FrmConectoresPlanos"
        Me.ShowIcon = False
        Me.Text = "Creación y consulta de conectores"
        Me.tspconectores.ResumeLayout(False)
        Me.tspconectores.PerformLayout()
        CType(Me.dwconector, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitAdiciones.Panel1.ResumeLayout(False)
        Me.splitAdiciones.Panel2.ResumeLayout(False)
        CType(Me.splitAdiciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitAdiciones.ResumeLayout(False)
        Me.tbgeneral.ResumeLayout(False)
        Me.tbAdicion.ResumeLayout(False)
        Me.tbAdicion.PerformLayout()
        Me.tbConsulta.ResumeLayout(False)
        Me.splitConsultas.Panel1.ResumeLayout(False)
        Me.splitConsultas.Panel2.ResumeLayout(False)
        CType(Me.splitConsultas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitConsultas.ResumeLayout(False)
        CType(Me.dwConectores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwconectorconsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpcombinar.ResumeLayout(False)
        Me.spcombinacion.Panel1.ResumeLayout(False)
        Me.spcombinacion.Panel2.ResumeLayout(False)
        CType(Me.spcombinacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcombinacion.ResumeLayout(False)
        Me.tlpcontenedor.ResumeLayout(False)
        Me.tlpcontenedor.PerformLayout()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpformulario.ResumeLayout(False)
        Me.tlpformulario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tspconectores As ToolStrip
    Friend WithEvents btnabrirconector As ToolStripButton
    Friend WithEvents dwconector As DataGridView
    Friend WithEvents splitAdiciones As SplitContainer
    Friend WithEvents listaHojas As ListBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txtNombreConector As ToolStripTextBox
    Friend WithEvents tbgeneral As TabControl
    Friend WithEvents tbAdicion As TabPage
    Friend WithEvents tbConsulta As TabPage
    Friend WithEvents splitConsultas As SplitContainer
    Friend WithEvents dwconectorconsulta As DataGridView
    Friend WithEvents bwCarga As System.ComponentModel.BackgroundWorker
    Friend WithEvents dwConectores As DataGridView
    Friend WithEvents idConector As DataGridViewTextBoxColumn
    Friend WithEvents Conector As DataGridViewTextBoxColumn
    Friend WithEvents tpcombinar As TabPage
    Friend WithEvents spcombinacion As SplitContainer
    Friend WithEvents tlpcontenedor As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbconectores As ComboBox
    Friend WithEvents tlpformulario As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbformulario As ComboBox
    Friend WithEvents pformulario As Panel
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nombreCampo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents TipoDato As DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As DataGridViewTextBoxColumn
    Friend WithEvents indObligatorio As DataGridViewCheckBoxColumn
    Friend WithEvents posicionInicial As DataGridViewTextBoxColumn
    Friend WithEvents posicionFinal As DataGridViewTextBoxColumn
    Friend WithEvents longitud As DataGridViewTextBoxColumn
    Friend WithEvents Decimales As DataGridViewTextBoxColumn
    Friend WithEvents valorDefecto As DataGridViewTextBoxColumn
    Friend WithEvents Formato As DataGridViewTextBoxColumn
    Friend WithEvents autoincremento As DataGridViewCheckBoxColumn
    Friend WithEvents id1 As DataGridViewTextBoxColumn
    Friend WithEvents idConector1 As DataGridViewTextBoxColumn
    Friend WithEvents nombreCampo1 As DataGridViewTextBoxColumn
    Friend WithEvents descripcion1 As DataGridViewTextBoxColumn
    Friend WithEvents idtipoDato As DataGridViewTextBoxColumn
    Friend WithEvents TipoDato1 As DataGridViewTextBoxColumn
    Friend WithEvents observaciones1 As DataGridViewTextBoxColumn
    Friend WithEvents indObligatorio1 As DataGridViewCheckBoxColumn
    Friend WithEvents inicio1 As DataGridViewTextBoxColumn
    Friend WithEvents fin1 As DataGridViewTextBoxColumn
    Friend WithEvents longitud1 As DataGridViewTextBoxColumn
    Friend WithEvents decimales1 As DataGridViewTextBoxColumn
    Friend WithEvents valorDefecto1 As DataGridViewTextBoxColumn
    Friend WithEvents formato1 As DataGridViewTextBoxColumn
    Friend WithEvents autoincrement As DataGridViewCheckBoxColumn
    Friend WithEvents dwitems As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents txtnombreplano As TextBox
    Friend WithEvents idenlace As DataGridViewTextBoxColumn
    Friend WithEvents idcon As DataGridViewTextBoxColumn
    Friend WithEvents campo As DataGridViewTextBoxColumn
    Friend WithEvents descripcioncampo As DataGridViewTextBoxColumn
    Friend WithEvents controlasociado As DataGridViewTextBoxColumn
    Friend WithEvents tipocontrol As DataGridViewTextBoxColumn
    Friend WithEvents valordefectocampo As DataGridViewTextBoxColumn
    Friend WithEvents autoincrementocampo As DataGridViewCheckBoxColumn
    Friend WithEvents obligatorio As DataGridViewCheckBoxColumn
End Class
