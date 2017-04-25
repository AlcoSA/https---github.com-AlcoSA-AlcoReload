<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTesteadorPlantillas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTesteadorPlantillas))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.lbplantilla = New System.Windows.Forms.ToolStripLabel()
        Me.tcextras = New System.Windows.Forms.TabControl()
        Me.tpvariables = New System.Windows.Forms.TabPage()
        Me.dwvariables = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorminimo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valormaximo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpmateriales = New System.Windows.Forms.TabPage()
        Me.tcmateriales = New System.Windows.Forms.TabControl()
        Me.tpvidrio = New System.Windows.Forms.TabPage()
        Me.dwVidrios = New System.Windows.Forms.DataGridView()
        Me.tpperfileria = New System.Windows.Forms.TabPage()
        Me.dwPerfiles = New System.Windows.Forms.DataGridView()
        Me.tpaccesorios = New System.Windows.Forms.TabPage()
        Me.dwAccesorios = New System.Windows.Forms.DataGridView()
        Me.tpotros = New System.Windows.Forms.TabPage()
        Me.dwotros = New System.Windows.Forms.DataGridView()
        Me.tshmientas = New System.Windows.Forms.ToolStrip()
        Me.btnvisibilidadcolumnas = New System.Windows.Forms.ToolStripButton()
        Me.tpdibujos = New System.Windows.Forms.TabPage()
        Me.flpContenedordibujos = New System.Windows.Forms.FlowLayoutPanel()
        Me.tpobservaciones = New System.Windows.Forms.TabPage()
        Me.flpcontenedorobservaciones = New System.Windows.Forms.FlowLayoutPanel()
        Me.tbDescuentosDiseño = New System.Windows.Forms.TabPage()
        Me.dwDescuentos = New System.Windows.Forms.DataGridView()
        Me.idDescGlobal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iddescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuentoG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fvalor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.usarG = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.vid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vreferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vespesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vcantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vpxuni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vdetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vorientacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vmaterialpara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vtipomaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vpeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vvisibilidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ppxuni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pdimension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pdescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pdetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porientacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pmaterialpara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ptipomaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcortes = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ppeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pvisibilidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.aid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.areferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apxuni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adimension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.adetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aorientacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amaterialpara = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.atipomaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apeso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.avisibilidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.oid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oreferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ocantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opxuni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oalto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.odetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ovisibilidad = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tsherramientas.SuspendLayout()
        Me.tcextras.SuspendLayout()
        Me.tpvariables.SuspendLayout()
        CType(Me.dwvariables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpmateriales.SuspendLayout()
        Me.tcmateriales.SuspendLayout()
        Me.tpvidrio.SuspendLayout()
        CType(Me.dwVidrios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpperfileria.SuspendLayout()
        CType(Me.dwPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpaccesorios.SuspendLayout()
        CType(Me.dwAccesorios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpotros.SuspendLayout()
        CType(Me.dwotros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tshmientas.SuspendLayout()
        Me.tpdibujos.SuspendLayout()
        Me.tpobservaciones.SuspendLayout()
        Me.tbDescuentosDiseño.SuspendLayout()
        CType(Me.dwDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbplantilla})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(671, 25)
        Me.tsherramientas.TabIndex = 0
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'lbplantilla
        '
        Me.lbplantilla.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lbplantilla.Name = "lbplantilla"
        Me.lbplantilla.Size = New System.Drawing.Size(21, 22)
        Me.lbplantilla.Text = "--"
        '
        'tcextras
        '
        Me.tcextras.Controls.Add(Me.tpvariables)
        Me.tcextras.Controls.Add(Me.tpmateriales)
        Me.tcextras.Controls.Add(Me.tpdibujos)
        Me.tcextras.Controls.Add(Me.tpobservaciones)
        Me.tcextras.Controls.Add(Me.tbDescuentosDiseño)
        Me.tcextras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcextras.Location = New System.Drawing.Point(0, 25)
        Me.tcextras.Name = "tcextras"
        Me.tcextras.Padding = New System.Drawing.Point(0, 0)
        Me.tcextras.SelectedIndex = 0
        Me.tcextras.Size = New System.Drawing.Size(671, 375)
        Me.tcextras.TabIndex = 14
        '
        'tpvariables
        '
        Me.tpvariables.Controls.Add(Me.dwvariables)
        Me.tpvariables.Location = New System.Drawing.Point(4, 22)
        Me.tpvariables.Name = "tpvariables"
        Me.tpvariables.Padding = New System.Windows.Forms.Padding(3)
        Me.tpvariables.Size = New System.Drawing.Size(663, 349)
        Me.tpvariables.TabIndex = 4
        Me.tpvariables.Text = "Variables"
        Me.tpvariables.UseVisualStyleBackColor = True
        '
        'dwvariables
        '
        Me.dwvariables.AllowUserToAddRows = False
        Me.dwvariables.AllowUserToDeleteRows = False
        Me.dwvariables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwvariables.BackgroundColor = System.Drawing.Color.White
        Me.dwvariables.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwvariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwvariables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.variable, Me.valorminimo, Me.valormaximo, Me.valor, Me.tipodato})
        Me.dwvariables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwvariables.Location = New System.Drawing.Point(3, 3)
        Me.dwvariables.Name = "dwvariables"
        Me.dwvariables.RowHeadersVisible = False
        Me.dwvariables.Size = New System.Drawing.Size(657, 343)
        Me.dwvariables.TabIndex = 17
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'variable
        '
        Me.variable.HeaderText = "Variable"
        Me.variable.Name = "variable"
        Me.variable.ReadOnly = True
        Me.variable.Width = 70
        '
        'valorminimo
        '
        Me.valorminimo.HeaderText = "Valor Minimo"
        Me.valorminimo.Name = "valorminimo"
        Me.valorminimo.ReadOnly = True
        Me.valorminimo.Width = 92
        '
        'valormaximo
        '
        Me.valormaximo.HeaderText = "Valor Maximo"
        Me.valormaximo.Name = "valormaximo"
        Me.valormaximo.ReadOnly = True
        Me.valormaximo.Width = 95
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.Width = 56
        '
        'tipodato
        '
        Me.tipodato.HeaderText = "Tipo Dato"
        Me.tipodato.Name = "tipodato"
        Me.tipodato.ReadOnly = True
        Me.tipodato.Visible = False
        Me.tipodato.Width = 79
        '
        'tpmateriales
        '
        Me.tpmateriales.Controls.Add(Me.tcmateriales)
        Me.tpmateriales.Controls.Add(Me.tshmientas)
        Me.tpmateriales.Location = New System.Drawing.Point(4, 22)
        Me.tpmateriales.Name = "tpmateriales"
        Me.tpmateriales.Padding = New System.Windows.Forms.Padding(3)
        Me.tpmateriales.Size = New System.Drawing.Size(663, 349)
        Me.tpmateriales.TabIndex = 3
        Me.tpmateriales.Text = "Materiales"
        Me.tpmateriales.UseVisualStyleBackColor = True
        '
        'tcmateriales
        '
        Me.tcmateriales.Controls.Add(Me.tpvidrio)
        Me.tcmateriales.Controls.Add(Me.tpperfileria)
        Me.tcmateriales.Controls.Add(Me.tpaccesorios)
        Me.tcmateriales.Controls.Add(Me.tpotros)
        Me.tcmateriales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcmateriales.ItemSize = New System.Drawing.Size(42, 15)
        Me.tcmateriales.Location = New System.Drawing.Point(3, 28)
        Me.tcmateriales.Name = "tcmateriales"
        Me.tcmateriales.SelectedIndex = 0
        Me.tcmateriales.Size = New System.Drawing.Size(657, 318)
        Me.tcmateriales.TabIndex = 1
        '
        'tpvidrio
        '
        Me.tpvidrio.Controls.Add(Me.dwVidrios)
        Me.tpvidrio.Location = New System.Drawing.Point(4, 19)
        Me.tpvidrio.Name = "tpvidrio"
        Me.tpvidrio.Padding = New System.Windows.Forms.Padding(3)
        Me.tpvidrio.Size = New System.Drawing.Size(649, 295)
        Me.tpvidrio.TabIndex = 0
        Me.tpvidrio.Text = "Vidrio"
        Me.tpvidrio.UseVisualStyleBackColor = True
        '
        'dwVidrios
        '
        Me.dwVidrios.AccessibleName = "VIDRIO"
        Me.dwVidrios.AllowUserToAddRows = False
        Me.dwVidrios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwVidrios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwVidrios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwVidrios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwVidrios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.vid, Me.vreferencia, Me.vespesor, Me.vacabado, Me.vcantidad, Me.vpxuni, Me.vancho, Me.valto, Me.vdetalle, Me.vorientacion, Me.vmaterialpara, Me.vtipomaterial, Me.vpeso, Me.vvisibilidad})
        Me.dwVidrios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwVidrios.Location = New System.Drawing.Point(3, 3)
        Me.dwVidrios.Name = "dwVidrios"
        Me.dwVidrios.RowHeadersWidth = 20
        Me.dwVidrios.Size = New System.Drawing.Size(643, 289)
        Me.dwVidrios.TabIndex = 0
        '
        'tpperfileria
        '
        Me.tpperfileria.Controls.Add(Me.dwPerfiles)
        Me.tpperfileria.Location = New System.Drawing.Point(4, 19)
        Me.tpperfileria.Name = "tpperfileria"
        Me.tpperfileria.Padding = New System.Windows.Forms.Padding(3)
        Me.tpperfileria.Size = New System.Drawing.Size(649, 295)
        Me.tpperfileria.TabIndex = 1
        Me.tpperfileria.Text = "Perfileria"
        Me.tpperfileria.UseVisualStyleBackColor = True
        '
        'dwPerfiles
        '
        Me.dwPerfiles.AccessibleName = "PERFIL"
        Me.dwPerfiles.AllowUserToAddRows = False
        Me.dwPerfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwPerfiles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwPerfiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.pid, Me.preferencia, Me.pacabado, Me.pcantidad, Me.ppxuni, Me.pdimension, Me.pdescuento, Me.pdetalle, Me.porientacion, Me.pubicacion, Me.pmaterialpara, Me.ptipomaterial, Me.pcortes, Me.ppeso, Me.pvisibilidad})
        Me.dwPerfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwPerfiles.Location = New System.Drawing.Point(3, 3)
        Me.dwPerfiles.Name = "dwPerfiles"
        Me.dwPerfiles.RowHeadersWidth = 20
        Me.dwPerfiles.Size = New System.Drawing.Size(643, 289)
        Me.dwPerfiles.TabIndex = 1
        '
        'tpaccesorios
        '
        Me.tpaccesorios.Controls.Add(Me.dwAccesorios)
        Me.tpaccesorios.Location = New System.Drawing.Point(4, 19)
        Me.tpaccesorios.Name = "tpaccesorios"
        Me.tpaccesorios.Padding = New System.Windows.Forms.Padding(3)
        Me.tpaccesorios.Size = New System.Drawing.Size(649, 295)
        Me.tpaccesorios.TabIndex = 2
        Me.tpaccesorios.Text = "Accesorios"
        Me.tpaccesorios.UseVisualStyleBackColor = True
        '
        'dwAccesorios
        '
        Me.dwAccesorios.AccessibleName = "ACCESORIOS"
        Me.dwAccesorios.AllowUserToAddRows = False
        Me.dwAccesorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwAccesorios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwAccesorios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwAccesorios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.aid, Me.areferencia, Me.aacabado, Me.acantidad, Me.apxuni, Me.adimension, Me.adetalle, Me.aorientacion, Me.amaterialpara, Me.atipomaterial, Me.apeso, Me.avisibilidad})
        Me.dwAccesorios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwAccesorios.Location = New System.Drawing.Point(3, 3)
        Me.dwAccesorios.Name = "dwAccesorios"
        Me.dwAccesorios.RowHeadersWidth = 20
        Me.dwAccesorios.Size = New System.Drawing.Size(643, 289)
        Me.dwAccesorios.TabIndex = 1
        '
        'tpotros
        '
        Me.tpotros.Controls.Add(Me.dwotros)
        Me.tpotros.Location = New System.Drawing.Point(4, 19)
        Me.tpotros.Name = "tpotros"
        Me.tpotros.Padding = New System.Windows.Forms.Padding(3)
        Me.tpotros.Size = New System.Drawing.Size(649, 295)
        Me.tpotros.TabIndex = 3
        Me.tpotros.Text = "Otros"
        Me.tpotros.UseVisualStyleBackColor = True
        '
        'dwotros
        '
        Me.dwotros.AccessibleName = "OTROS"
        Me.dwotros.AllowUserToAddRows = False
        Me.dwotros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwotros.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dwotros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwotros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwotros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.oid, Me.oreferencia, Me.ocantidad, Me.opxuni, Me.oancho, Me.oalto, Me.odetalle, Me.ovisibilidad})
        Me.dwotros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwotros.Location = New System.Drawing.Point(3, 3)
        Me.dwotros.Name = "dwotros"
        Me.dwotros.RowHeadersWidth = 20
        Me.dwotros.Size = New System.Drawing.Size(643, 289)
        Me.dwotros.TabIndex = 2
        '
        'tshmientas
        '
        Me.tshmientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tshmientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnvisibilidadcolumnas})
        Me.tshmientas.Location = New System.Drawing.Point(3, 3)
        Me.tshmientas.Name = "tshmientas"
        Me.tshmientas.Size = New System.Drawing.Size(657, 25)
        Me.tshmientas.TabIndex = 2
        Me.tshmientas.Text = "ToolStrip1"
        '
        'btnvisibilidadcolumnas
        '
        Me.btnvisibilidadcolumnas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnvisibilidadcolumnas.Image = CType(resources.GetObject("btnvisibilidadcolumnas.Image"), System.Drawing.Image)
        Me.btnvisibilidadcolumnas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnvisibilidadcolumnas.Name = "btnvisibilidadcolumnas"
        Me.btnvisibilidadcolumnas.Size = New System.Drawing.Size(23, 22)
        Me.btnvisibilidadcolumnas.Text = "Mostrar Columnas"
        Me.btnvisibilidadcolumnas.ToolTipText = "Seleccionar columnas"
        '
        'tpdibujos
        '
        Me.tpdibujos.Controls.Add(Me.flpContenedordibujos)
        Me.tpdibujos.Location = New System.Drawing.Point(4, 22)
        Me.tpdibujos.Name = "tpdibujos"
        Me.tpdibujos.Padding = New System.Windows.Forms.Padding(3)
        Me.tpdibujos.Size = New System.Drawing.Size(663, 349)
        Me.tpdibujos.TabIndex = 0
        Me.tpdibujos.Text = "Dibujos"
        Me.tpdibujos.UseVisualStyleBackColor = True
        '
        'flpContenedordibujos
        '
        Me.flpContenedordibujos.BackColor = System.Drawing.Color.DarkGray
        Me.flpContenedordibujos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpContenedordibujos.Location = New System.Drawing.Point(3, 3)
        Me.flpContenedordibujos.Name = "flpContenedordibujos"
        Me.flpContenedordibujos.Size = New System.Drawing.Size(657, 343)
        Me.flpContenedordibujos.TabIndex = 2
        '
        'tpobservaciones
        '
        Me.tpobservaciones.Controls.Add(Me.flpcontenedorobservaciones)
        Me.tpobservaciones.Location = New System.Drawing.Point(4, 22)
        Me.tpobservaciones.Name = "tpobservaciones"
        Me.tpobservaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tpobservaciones.Size = New System.Drawing.Size(663, 349)
        Me.tpobservaciones.TabIndex = 1
        Me.tpobservaciones.Text = "Observaciones"
        Me.tpobservaciones.UseVisualStyleBackColor = True
        '
        'flpcontenedorobservaciones
        '
        Me.flpcontenedorobservaciones.BackColor = System.Drawing.Color.DarkGray
        Me.flpcontenedorobservaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpcontenedorobservaciones.Location = New System.Drawing.Point(3, 3)
        Me.flpcontenedorobservaciones.Name = "flpcontenedorobservaciones"
        Me.flpcontenedorobservaciones.Size = New System.Drawing.Size(657, 343)
        Me.flpcontenedorobservaciones.TabIndex = 0
        '
        'tbDescuentosDiseño
        '
        Me.tbDescuentosDiseño.Controls.Add(Me.dwDescuentos)
        Me.tbDescuentosDiseño.Location = New System.Drawing.Point(4, 22)
        Me.tbDescuentosDiseño.Name = "tbDescuentosDiseño"
        Me.tbDescuentosDiseño.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDescuentosDiseño.Size = New System.Drawing.Size(663, 349)
        Me.tbDescuentosDiseño.TabIndex = 5
        Me.tbDescuentosDiseño.Text = "Descuentos Globales"
        Me.tbDescuentosDiseño.UseVisualStyleBackColor = True
        '
        'dwDescuentos
        '
        Me.dwDescuentos.AllowUserToAddRows = False
        Me.dwDescuentos.AllowUserToDeleteRows = False
        Me.dwDescuentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwDescuentos.BackgroundColor = System.Drawing.Color.White
        Me.dwDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwDescuentos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idDescGlobal, Me.iddescuento, Me.descuentoG, Me.valorG, Me.fvalor, Me.usarG})
        Me.dwDescuentos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwDescuentos.Location = New System.Drawing.Point(3, 3)
        Me.dwDescuentos.MultiSelect = False
        Me.dwDescuentos.Name = "dwDescuentos"
        Me.dwDescuentos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dwDescuentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dwDescuentos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dwDescuentos.Size = New System.Drawing.Size(657, 343)
        Me.dwDescuentos.TabIndex = 2
        '
        'idDescGlobal
        '
        DataGridViewCellStyle2.NullValue = "0"
        Me.idDescGlobal.DefaultCellStyle = DataGridViewCellStyle2
        Me.idDescGlobal.HeaderText = "Id"
        Me.idDescGlobal.Name = "idDescGlobal"
        Me.idDescGlobal.ReadOnly = True
        Me.idDescGlobal.Visible = False
        Me.idDescGlobal.Width = 41
        '
        'iddescuento
        '
        Me.iddescuento.HeaderText = "Id Descuento"
        Me.iddescuento.Name = "iddescuento"
        Me.iddescuento.ReadOnly = True
        Me.iddescuento.Visible = False
        Me.iddescuento.Width = 96
        '
        'descuentoG
        '
        Me.descuentoG.HeaderText = "Descuento"
        Me.descuentoG.Name = "descuentoG"
        Me.descuentoG.ReadOnly = True
        Me.descuentoG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.descuentoG.Width = 65
        '
        'valorG
        '
        Me.valorG.HeaderText = "Valor"
        Me.valorG.MaxInputLength = 255
        Me.valorG.Name = "valorG"
        Me.valorG.ReadOnly = True
        Me.valorG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.valorG.Width = 37
        '
        'fvalor
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = "..."
        Me.fvalor.DefaultCellStyle = DataGridViewCellStyle3
        Me.fvalor.HeaderText = "..."
        Me.fvalor.Name = "fvalor"
        Me.fvalor.ReadOnly = True
        Me.fvalor.Text = "valorG"
        Me.fvalor.Width = 22
        '
        'usarG
        '
        Me.usarG.HeaderText = "Usar"
        Me.usarG.Name = "usarG"
        Me.usarG.ReadOnly = True
        Me.usarG.Visible = False
        Me.usarG.Width = 35
        '
        'bwcargas
        '
        '
        'vid
        '
        Me.vid.HeaderText = "Id"
        Me.vid.Name = "vid"
        Me.vid.ReadOnly = True
        Me.vid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vid.Visible = False
        Me.vid.Width = 22
        '
        'vreferencia
        '
        Me.vreferencia.HeaderText = "REFERENCIA"
        Me.vreferencia.MaxInputLength = 255
        Me.vreferencia.Name = "vreferencia"
        Me.vreferencia.ReadOnly = True
        Me.vreferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vreferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vreferencia.Width = 81
        '
        'vespesor
        '
        Me.vespesor.HeaderText = "ESPESOR"
        Me.vespesor.Name = "vespesor"
        Me.vespesor.ReadOnly = True
        Me.vespesor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vespesor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vespesor.Width = 64
        '
        'vacabado
        '
        Me.vacabado.HeaderText = "COLOR"
        Me.vacabado.MaxInputLength = 255
        Me.vacabado.Name = "vacabado"
        Me.vacabado.ReadOnly = True
        Me.vacabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vacabado.Width = 50
        '
        'vcantidad
        '
        Me.vcantidad.HeaderText = "CANTIDAD"
        Me.vcantidad.MaxInputLength = 255
        Me.vcantidad.Name = "vcantidad"
        Me.vcantidad.ReadOnly = True
        Me.vcantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vcantidad.Width = 68
        '
        'vpxuni
        '
        Me.vpxuni.HeaderText = "PXUNIDAD"
        Me.vpxuni.Name = "vpxuni"
        Me.vpxuni.Width = 88
        '
        'vancho
        '
        DataGridViewCellStyle1.NullValue = Nothing
        Me.vancho.DefaultCellStyle = DataGridViewCellStyle1
        Me.vancho.HeaderText = "ANCHO"
        Me.vancho.MaxInputLength = 255
        Me.vancho.Name = "vancho"
        Me.vancho.ReadOnly = True
        Me.vancho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vancho.Width = 51
        '
        'valto
        '
        Me.valto.HeaderText = "ALTO"
        Me.valto.MaxInputLength = 255
        Me.valto.Name = "valto"
        Me.valto.ReadOnly = True
        Me.valto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.valto.Width = 41
        '
        'vdetalle
        '
        Me.vdetalle.HeaderText = "DETALLE"
        Me.vdetalle.MaxInputLength = 255
        Me.vdetalle.Name = "vdetalle"
        Me.vdetalle.ReadOnly = True
        Me.vdetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vdetalle.Width = 61
        '
        'vorientacion
        '
        Me.vorientacion.HeaderText = "ORIENTACION"
        Me.vorientacion.Name = "vorientacion"
        Me.vorientacion.ReadOnly = True
        Me.vorientacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vorientacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vorientacion.Width = 87
        '
        'vmaterialpara
        '
        Me.vmaterialpara.HeaderText = "PARA"
        Me.vmaterialpara.Name = "vmaterialpara"
        Me.vmaterialpara.ReadOnly = True
        Me.vmaterialpara.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vmaterialpara.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vmaterialpara.Width = 42
        '
        'vtipomaterial
        '
        Me.vtipomaterial.HeaderText = "TIPO"
        Me.vtipomaterial.Name = "vtipomaterial"
        Me.vtipomaterial.ReadOnly = True
        Me.vtipomaterial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vtipomaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vtipomaterial.Width = 38
        '
        'vpeso
        '
        Me.vpeso.HeaderText = "PESO"
        Me.vpeso.Name = "vpeso"
        Me.vpeso.ReadOnly = True
        Me.vpeso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.vpeso.Width = 42
        '
        'vvisibilidad
        '
        Me.vvisibilidad.HeaderText = "VISIBILIDAD"
        Me.vvisibilidad.Name = "vvisibilidad"
        Me.vvisibilidad.ReadOnly = True
        Me.vvisibilidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vvisibilidad.Width = 75
        '
        'pid
        '
        Me.pid.HeaderText = "Id"
        Me.pid.Name = "pid"
        Me.pid.ReadOnly = True
        Me.pid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pid.Visible = False
        Me.pid.Width = 22
        '
        'preferencia
        '
        Me.preferencia.HeaderText = "REFERENCIA"
        Me.preferencia.Name = "preferencia"
        Me.preferencia.ReadOnly = True
        Me.preferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.preferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.preferencia.Width = 81
        '
        'pacabado
        '
        Me.pacabado.HeaderText = "ACABADO"
        Me.pacabado.Name = "pacabado"
        Me.pacabado.ReadOnly = True
        Me.pacabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pacabado.Width = 64
        '
        'pcantidad
        '
        Me.pcantidad.HeaderText = "CANTIDAD"
        Me.pcantidad.Name = "pcantidad"
        Me.pcantidad.ReadOnly = True
        Me.pcantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pcantidad.Width = 68
        '
        'ppxuni
        '
        Me.ppxuni.HeaderText = "PXUNIDAD"
        Me.ppxuni.Name = "ppxuni"
        Me.ppxuni.Width = 88
        '
        'pdimension
        '
        Me.pdimension.HeaderText = "DIMENSION"
        Me.pdimension.Name = "pdimension"
        Me.pdimension.ReadOnly = True
        Me.pdimension.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pdimension.Width = 74
        '
        'pdescuento
        '
        Me.pdescuento.HeaderText = "DESCUENTO"
        Me.pdescuento.Name = "pdescuento"
        Me.pdescuento.ReadOnly = True
        Me.pdescuento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pdescuento.Visible = False
        Me.pdescuento.Width = 80
        '
        'pdetalle
        '
        Me.pdetalle.HeaderText = "DETALLE"
        Me.pdetalle.MaxInputLength = 255
        Me.pdetalle.Name = "pdetalle"
        Me.pdetalle.ReadOnly = True
        Me.pdetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pdetalle.Width = 61
        '
        'porientacion
        '
        Me.porientacion.HeaderText = "ORIENTACION"
        Me.porientacion.Name = "porientacion"
        Me.porientacion.ReadOnly = True
        Me.porientacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.porientacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.porientacion.Width = 87
        '
        'pubicacion
        '
        Me.pubicacion.HeaderText = "UBICACION"
        Me.pubicacion.Name = "pubicacion"
        Me.pubicacion.ReadOnly = True
        Me.pubicacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pubicacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pubicacion.Width = 71
        '
        'pmaterialpara
        '
        Me.pmaterialpara.HeaderText = "PARA"
        Me.pmaterialpara.Name = "pmaterialpara"
        Me.pmaterialpara.ReadOnly = True
        Me.pmaterialpara.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pmaterialpara.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pmaterialpara.Width = 42
        '
        'ptipomaterial
        '
        Me.ptipomaterial.HeaderText = "TIPO"
        Me.ptipomaterial.Name = "ptipomaterial"
        Me.ptipomaterial.ReadOnly = True
        Me.ptipomaterial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ptipomaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ptipomaterial.Width = 38
        '
        'pcortes
        '
        Me.pcortes.HeaderText = "CORTES"
        Me.pcortes.Name = "pcortes"
        Me.pcortes.ReadOnly = True
        Me.pcortes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pcortes.Width = 57
        '
        'ppeso
        '
        Me.ppeso.HeaderText = "PESO"
        Me.ppeso.Name = "ppeso"
        Me.ppeso.ReadOnly = True
        Me.ppeso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ppeso.Width = 42
        '
        'pvisibilidad
        '
        Me.pvisibilidad.HeaderText = "VISIBILIDAD"
        Me.pvisibilidad.Name = "pvisibilidad"
        Me.pvisibilidad.ReadOnly = True
        Me.pvisibilidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.pvisibilidad.Width = 75
        '
        'aid
        '
        Me.aid.HeaderText = "Id"
        Me.aid.Name = "aid"
        Me.aid.ReadOnly = True
        Me.aid.Visible = False
        Me.aid.Width = 22
        '
        'areferencia
        '
        Me.areferencia.HeaderText = "REFERENCIA"
        Me.areferencia.Name = "areferencia"
        Me.areferencia.ReadOnly = True
        Me.areferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.areferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.areferencia.Width = 81
        '
        'aacabado
        '
        Me.aacabado.HeaderText = "ACABADO"
        Me.aacabado.Name = "aacabado"
        Me.aacabado.ReadOnly = True
        Me.aacabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.aacabado.Width = 64
        '
        'acantidad
        '
        Me.acantidad.HeaderText = "CANTIDAD"
        Me.acantidad.Name = "acantidad"
        Me.acantidad.ReadOnly = True
        Me.acantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.acantidad.Width = 68
        '
        'apxuni
        '
        Me.apxuni.HeaderText = "PXUNIDAD"
        Me.apxuni.Name = "apxuni"
        Me.apxuni.Width = 88
        '
        'adimension
        '
        Me.adimension.HeaderText = "DIMENSION"
        Me.adimension.Name = "adimension"
        Me.adimension.ReadOnly = True
        Me.adimension.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.adimension.Width = 74
        '
        'adetalle
        '
        Me.adetalle.HeaderText = "DETALLE"
        Me.adetalle.MaxInputLength = 255
        Me.adetalle.Name = "adetalle"
        Me.adetalle.ReadOnly = True
        Me.adetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.adetalle.Width = 61
        '
        'aorientacion
        '
        Me.aorientacion.HeaderText = "ORIENTACION"
        Me.aorientacion.Name = "aorientacion"
        Me.aorientacion.ReadOnly = True
        Me.aorientacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.aorientacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.aorientacion.Width = 87
        '
        'amaterialpara
        '
        Me.amaterialpara.HeaderText = "PARA"
        Me.amaterialpara.Name = "amaterialpara"
        Me.amaterialpara.ReadOnly = True
        Me.amaterialpara.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.amaterialpara.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.amaterialpara.Width = 42
        '
        'atipomaterial
        '
        Me.atipomaterial.HeaderText = "TIPO"
        Me.atipomaterial.Name = "atipomaterial"
        Me.atipomaterial.ReadOnly = True
        Me.atipomaterial.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.atipomaterial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.atipomaterial.Width = 38
        '
        'apeso
        '
        Me.apeso.HeaderText = "PESO"
        Me.apeso.Name = "apeso"
        Me.apeso.ReadOnly = True
        Me.apeso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.apeso.Width = 42
        '
        'avisibilidad
        '
        Me.avisibilidad.HeaderText = "VISIBILIDAD"
        Me.avisibilidad.Name = "avisibilidad"
        Me.avisibilidad.ReadOnly = True
        Me.avisibilidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.avisibilidad.Width = 75
        '
        'oid
        '
        Me.oid.HeaderText = "Id"
        Me.oid.Name = "oid"
        Me.oid.ReadOnly = True
        Me.oid.Visible = False
        Me.oid.Width = 22
        '
        'oreferencia
        '
        Me.oreferencia.HeaderText = "REFERENCIA"
        Me.oreferencia.Name = "oreferencia"
        Me.oreferencia.ReadOnly = True
        Me.oreferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.oreferencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.oreferencia.Width = 81
        '
        'ocantidad
        '
        Me.ocantidad.HeaderText = "CANTIDAD"
        Me.ocantidad.Name = "ocantidad"
        Me.ocantidad.ReadOnly = True
        Me.ocantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ocantidad.Width = 68
        '
        'opxuni
        '
        Me.opxuni.HeaderText = "PXUNIDAD"
        Me.opxuni.Name = "opxuni"
        Me.opxuni.Width = 88
        '
        'oancho
        '
        Me.oancho.HeaderText = "ANCHO"
        Me.oancho.Name = "oancho"
        Me.oancho.ReadOnly = True
        Me.oancho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.oancho.Width = 51
        '
        'oalto
        '
        Me.oalto.HeaderText = "ALTO"
        Me.oalto.Name = "oalto"
        Me.oalto.ReadOnly = True
        Me.oalto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.oalto.Width = 41
        '
        'odetalle
        '
        Me.odetalle.HeaderText = "DETALLE"
        Me.odetalle.MaxInputLength = 255
        Me.odetalle.Name = "odetalle"
        Me.odetalle.ReadOnly = True
        Me.odetalle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.odetalle.Width = 61
        '
        'ovisibilidad
        '
        Me.ovisibilidad.HeaderText = "VISIBILIDAD"
        Me.ovisibilidad.Name = "ovisibilidad"
        Me.ovisibilidad.ReadOnly = True
        Me.ovisibilidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ovisibilidad.Width = 75
        '
        'FrmTesteadorPlantillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 400)
        Me.Controls.Add(Me.tcextras)
        Me.Controls.Add(Me.tsherramientas)
        Me.Name = "FrmTesteadorPlantillas"
        Me.ShowIcon = False
        Me.Text = "Cargador Plantillas"
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.tcextras.ResumeLayout(False)
        Me.tpvariables.ResumeLayout(False)
        CType(Me.dwvariables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpmateriales.ResumeLayout(False)
        Me.tpmateriales.PerformLayout()
        Me.tcmateriales.ResumeLayout(False)
        Me.tpvidrio.ResumeLayout(False)
        CType(Me.dwVidrios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpperfileria.ResumeLayout(False)
        CType(Me.dwPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpaccesorios.ResumeLayout(False)
        CType(Me.dwAccesorios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpotros.ResumeLayout(False)
        CType(Me.dwotros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tshmientas.ResumeLayout(False)
        Me.tshmientas.PerformLayout()
        Me.tpdibujos.ResumeLayout(False)
        Me.tpobservaciones.ResumeLayout(False)
        Me.tbDescuentosDiseño.ResumeLayout(False)
        CType(Me.dwDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents lbplantilla As ToolStripLabel
    Friend WithEvents tcextras As TabControl
    Friend WithEvents tpmateriales As TabPage
    Friend WithEvents tpdibujos As TabPage
    Friend WithEvents flpContenedordibujos As FlowLayoutPanel
    Friend WithEvents tpobservaciones As TabPage
    Friend WithEvents flpcontenedorobservaciones As FlowLayoutPanel
    Friend WithEvents tpvariables As TabPage
    Friend WithEvents dwvariables As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents variable As DataGridViewTextBoxColumn
    Friend WithEvents valorminimo As DataGridViewTextBoxColumn
    Friend WithEvents valormaximo As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents tipodato As DataGridViewTextBoxColumn
    Friend WithEvents tbDescuentosDiseño As TabPage
    Friend WithEvents dwDescuentos As DataGridView
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents tcmateriales As TabControl
    Friend WithEvents tpvidrio As TabPage
    Friend WithEvents dwVidrios As DataGridView
    Friend WithEvents tpperfileria As TabPage
    Friend WithEvents dwPerfiles As DataGridView
    Friend WithEvents tpaccesorios As TabPage
    Friend WithEvents dwAccesorios As DataGridView
    Friend WithEvents tpotros As TabPage
    Friend WithEvents dwotros As DataGridView
    Friend WithEvents tshmientas As ToolStrip
    Friend WithEvents btnvisibilidadcolumnas As ToolStripButton
    Friend WithEvents idDescGlobal As DataGridViewTextBoxColumn
    Friend WithEvents iddescuento As DataGridViewTextBoxColumn
    Friend WithEvents descuentoG As DataGridViewTextBoxColumn
    Friend WithEvents valorG As DataGridViewTextBoxColumn
    Friend WithEvents fvalor As DataGridViewButtonColumn
    Friend WithEvents usarG As DataGridViewCheckBoxColumn
    Friend WithEvents vid As DataGridViewTextBoxColumn
    Friend WithEvents vreferencia As DataGridViewTextBoxColumn
    Friend WithEvents vespesor As DataGridViewTextBoxColumn
    Friend WithEvents vacabado As DataGridViewTextBoxColumn
    Friend WithEvents vcantidad As DataGridViewTextBoxColumn
    Friend WithEvents vpxuni As DataGridViewTextBoxColumn
    Friend WithEvents vancho As DataGridViewTextBoxColumn
    Friend WithEvents valto As DataGridViewTextBoxColumn
    Friend WithEvents vdetalle As DataGridViewTextBoxColumn
    Friend WithEvents vorientacion As DataGridViewTextBoxColumn
    Friend WithEvents vmaterialpara As DataGridViewTextBoxColumn
    Friend WithEvents vtipomaterial As DataGridViewTextBoxColumn
    Friend WithEvents vpeso As DataGridViewTextBoxColumn
    Friend WithEvents vvisibilidad As DataGridViewCheckBoxColumn
    Friend WithEvents pid As DataGridViewTextBoxColumn
    Friend WithEvents preferencia As DataGridViewTextBoxColumn
    Friend WithEvents pacabado As DataGridViewTextBoxColumn
    Friend WithEvents pcantidad As DataGridViewTextBoxColumn
    Friend WithEvents ppxuni As DataGridViewTextBoxColumn
    Friend WithEvents pdimension As DataGridViewTextBoxColumn
    Friend WithEvents pdescuento As DataGridViewTextBoxColumn
    Friend WithEvents pdetalle As DataGridViewTextBoxColumn
    Friend WithEvents porientacion As DataGridViewTextBoxColumn
    Friend WithEvents pubicacion As DataGridViewTextBoxColumn
    Friend WithEvents pmaterialpara As DataGridViewTextBoxColumn
    Friend WithEvents ptipomaterial As DataGridViewTextBoxColumn
    Friend WithEvents pcortes As DataGridViewImageColumn
    Friend WithEvents ppeso As DataGridViewTextBoxColumn
    Friend WithEvents pvisibilidad As DataGridViewCheckBoxColumn
    Friend WithEvents aid As DataGridViewTextBoxColumn
    Friend WithEvents areferencia As DataGridViewTextBoxColumn
    Friend WithEvents aacabado As DataGridViewTextBoxColumn
    Friend WithEvents acantidad As DataGridViewTextBoxColumn
    Friend WithEvents apxuni As DataGridViewTextBoxColumn
    Friend WithEvents adimension As DataGridViewTextBoxColumn
    Friend WithEvents adetalle As DataGridViewTextBoxColumn
    Friend WithEvents aorientacion As DataGridViewTextBoxColumn
    Friend WithEvents amaterialpara As DataGridViewTextBoxColumn
    Friend WithEvents atipomaterial As DataGridViewTextBoxColumn
    Friend WithEvents apeso As DataGridViewTextBoxColumn
    Friend WithEvents avisibilidad As DataGridViewCheckBoxColumn
    Friend WithEvents oid As DataGridViewTextBoxColumn
    Friend WithEvents oreferencia As DataGridViewTextBoxColumn
    Friend WithEvents ocantidad As DataGridViewTextBoxColumn
    Friend WithEvents opxuni As DataGridViewTextBoxColumn
    Friend WithEvents oancho As DataGridViewTextBoxColumn
    Friend WithEvents oalto As DataGridViewTextBoxColumn
    Friend WithEvents odetalle As DataGridViewTextBoxColumn
    Friend WithEvents ovisibilidad As DataGridViewCheckBoxColumn
End Class
