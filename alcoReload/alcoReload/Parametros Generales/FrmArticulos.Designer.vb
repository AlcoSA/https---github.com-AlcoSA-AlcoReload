<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmArticulos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbcerrarImagen = New System.Windows.Forms.Label()
        Me.tbinfo = New System.Windows.Forms.TabControl()
        Me.tpinfo = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudAltoDescunto = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.nudcostoinstalacion = New System.Windows.Forms.NumericUpDown()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.nudcosto = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbTasaImpuesto = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.nudPorcDesperdicio = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudperimetro = New System.Windows.Forms.NumericUpDown()
        Me.cmbFamiliaMaterial = New System.Windows.Forms.ComboBox()
        Me.nudpeso = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtReferencia = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.tpimagenes = New System.Windows.Forms.TabPage()
        Me.flpImagenes = New System.Windows.Forms.FlowLayoutPanel()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnagregarimagen = New System.Windows.Forms.ToolStripButton()
        Me.spgeneral = New System.Windows.Forms.SplitContainer()
        Me.spinfo = New System.Windows.Forms.SplitContainer()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Peso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Perimetro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unidad_medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Familia_Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Familia_Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Tasa_Impuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tasa_Impuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.porcentajeDesperdicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Alto_para_descuentos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo_instalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbinfo.SuspendLayout()
        Me.tpinfo.SuspendLayout()
        CType(Me.nudAltoDescunto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudcostoinstalacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudcosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudperimetro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudpeso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpimagenes.SuspendLayout()
        Me.tsherramientas.SuspendLayout()
        CType(Me.spgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spgeneral.Panel1.SuspendLayout()
        Me.spgeneral.Panel2.SuspendLayout()
        Me.spgeneral.SuspendLayout()
        CType(Me.spinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spinfo.Panel1.SuspendLayout()
        Me.spinfo.Panel2.SuspendLayout()
        Me.spinfo.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbcerrarImagen
        '
        Me.lbcerrarImagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbcerrarImagen.AutoSize = True
        Me.lbcerrarImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcerrarImagen.Image = CType(resources.GetObject("lbcerrarImagen.Image"), System.Drawing.Image)
        Me.lbcerrarImagen.Location = New System.Drawing.Point(1058, 16)
        Me.lbcerrarImagen.Name = "lbcerrarImagen"
        Me.lbcerrarImagen.Size = New System.Drawing.Size(20, 17)
        Me.lbcerrarImagen.TabIndex = 6
        Me.lbcerrarImagen.Text = "   "
        '
        'tbinfo
        '
        Me.tbinfo.Controls.Add(Me.tpinfo)
        Me.tbinfo.Controls.Add(Me.tpimagenes)
        Me.tbinfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbinfo.Location = New System.Drawing.Point(10, 10)
        Me.tbinfo.Name = "tbinfo"
        Me.tbinfo.SelectedIndex = 0
        Me.tbinfo.Size = New System.Drawing.Size(978, 134)
        Me.tbinfo.TabIndex = 0
        '
        'tpinfo
        '
        Me.tpinfo.Controls.Add(Me.Label28)
        Me.tpinfo.Controls.Add(Me.Label13)
        Me.tpinfo.Controls.Add(Me.nudAltoDescunto)
        Me.tpinfo.Controls.Add(Me.Label27)
        Me.tpinfo.Controls.Add(Me.nudcostoinstalacion)
        Me.tpinfo.Controls.Add(Me.lblCosto)
        Me.tpinfo.Controls.Add(Me.nudcosto)
        Me.tpinfo.Controls.Add(Me.Label23)
        Me.tpinfo.Controls.Add(Me.Label22)
        Me.tpinfo.Controls.Add(Me.Label21)
        Me.tpinfo.Controls.Add(Me.Label20)
        Me.tpinfo.Controls.Add(Me.Label19)
        Me.tpinfo.Controls.Add(Me.Label18)
        Me.tpinfo.Controls.Add(Me.Label17)
        Me.tpinfo.Controls.Add(Me.Label16)
        Me.tpinfo.Controls.Add(Me.Label15)
        Me.tpinfo.Controls.Add(Me.Label14)
        Me.tpinfo.Controls.Add(Me.cmbTasaImpuesto)
        Me.tpinfo.Controls.Add(Me.cmbEstado)
        Me.tpinfo.Controls.Add(Me.nudPorcDesperdicio)
        Me.tpinfo.Controls.Add(Me.Label11)
        Me.tpinfo.Controls.Add(Me.Label10)
        Me.tpinfo.Controls.Add(Me.cmbUnidadMedida)
        Me.tpinfo.Controls.Add(Me.Label9)
        Me.tpinfo.Controls.Add(Me.txtdescripcion)
        Me.tpinfo.Controls.Add(Me.Label5)
        Me.tpinfo.Controls.Add(Me.Label8)
        Me.tpinfo.Controls.Add(Me.Label3)
        Me.tpinfo.Controls.Add(Me.Label7)
        Me.tpinfo.Controls.Add(Me.nudperimetro)
        Me.tpinfo.Controls.Add(Me.cmbFamiliaMaterial)
        Me.tpinfo.Controls.Add(Me.nudpeso)
        Me.tpinfo.Controls.Add(Me.Label2)
        Me.tpinfo.Controls.Add(Me.Label6)
        Me.tpinfo.Controls.Add(Me.txtReferencia)
        Me.tpinfo.Controls.Add(Me.Label4)
        Me.tpinfo.Controls.Add(Me.cmbNivel)
        Me.tpinfo.Controls.Add(Me.Label1)
        Me.tpinfo.Controls.Add(Me.Label12)
        Me.tpinfo.Controls.Add(Me.Label24)
        Me.tpinfo.Controls.Add(Me.Label25)
        Me.tpinfo.Controls.Add(Me.Label26)
        Me.tpinfo.Location = New System.Drawing.Point(4, 22)
        Me.tpinfo.Name = "tpinfo"
        Me.tpinfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tpinfo.Size = New System.Drawing.Size(970, 108)
        Me.tpinfo.TabIndex = 0
        Me.tpinfo.Text = "Informacion"
        Me.tpinfo.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(399, 88)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(23, 13)
        Me.Label28.TabIndex = 41
        Me.Label28.Text = "mm"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(318, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Alto Decuento"
        '
        'nudAltoDescunto
        '
        Me.nudAltoDescunto.DecimalPlaces = 2
        Me.nudAltoDescunto.Location = New System.Drawing.Point(321, 81)
        Me.nudAltoDescunto.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudAltoDescunto.Name = "nudAltoDescunto"
        Me.nudAltoDescunto.Size = New System.Drawing.Size(72, 20)
        Me.nudAltoDescunto.TabIndex = 40
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(645, 66)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(127, 13)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "Costo Unitario Instalación"
        '
        'nudcostoinstalacion
        '
        Me.nudcostoinstalacion.DecimalPlaces = 3
        Me.nudcostoinstalacion.Location = New System.Drawing.Point(648, 81)
        Me.nudcostoinstalacion.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudcostoinstalacion.Name = "nudcostoinstalacion"
        Me.nudcostoinstalacion.Size = New System.Drawing.Size(124, 20)
        Me.nudcostoinstalacion.TabIndex = 38
        '
        'lblCosto
        '
        Me.lblCosto.AutoSize = True
        Me.lblCosto.Location = New System.Drawing.Point(506, 66)
        Me.lblCosto.Name = "lblCosto"
        Me.lblCosto.Size = New System.Drawing.Size(74, 13)
        Me.lblCosto.TabIndex = 21
        Me.lblCosto.Text = "Costo Artículo"
        Me.lblCosto.Visible = False
        '
        'nudcosto
        '
        Me.nudcosto.DecimalPlaces = 2
        Me.nudcosto.Location = New System.Drawing.Point(509, 81)
        Me.nudcosto.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudcosto.Name = "nudcosto"
        Me.nudcosto.Size = New System.Drawing.Size(95, 20)
        Me.nudcosto.TabIndex = 22
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(828, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 13)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Estado"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(746, 13)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(76, 13)
        Me.Label22.TabIndex = 19
        Me.Label22.Text = "Tasa impuesto"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(644, 13)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Unidad medida"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(538, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 15
        Me.Label20.Text = "Nivel"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(223, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Desperdicio"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(122, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Perímetro"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(31, 13)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "Peso"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(391, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Familia material"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(129, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 13)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Descripción"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Referencia"
        '
        'cmbTasaImpuesto
        '
        Me.cmbTasaImpuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTasaImpuesto.FormattingEnabled = True
        Me.cmbTasaImpuesto.Location = New System.Drawing.Point(749, 29)
        Me.cmbTasaImpuesto.Name = "cmbTasaImpuesto"
        Me.cmbTasaImpuesto.Size = New System.Drawing.Size(73, 21)
        Me.cmbTasaImpuesto.TabIndex = 20
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(831, 29)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 24
        '
        'nudPorcDesperdicio
        '
        Me.nudPorcDesperdicio.DecimalPlaces = 2
        Me.nudPorcDesperdicio.Location = New System.Drawing.Point(226, 81)
        Me.nudPorcDesperdicio.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudPorcDesperdicio.Name = "nudPorcDesperdicio"
        Me.nudPorcDesperdicio.Size = New System.Drawing.Size(60, 20)
        Me.nudPorcDesperdicio.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(245, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(172, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 14
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(647, 29)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(75, 21)
        Me.cmbUnidadMedida.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(128, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 2
        '
        'txtdescripcion
        '
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.Location = New System.Drawing.Point(131, 30)
        Me.txtdescripcion.MaxLength = 50
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(241, 20)
        Me.txtdescripcion.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(203, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 8
        '
        'nudperimetro
        '
        Me.nudperimetro.DecimalPlaces = 2
        Me.nudperimetro.Location = New System.Drawing.Point(125, 81)
        Me.nudperimetro.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudperimetro.Name = "nudperimetro"
        Me.nudperimetro.Size = New System.Drawing.Size(61, 20)
        Me.nudperimetro.TabIndex = 10
        '
        'cmbFamiliaMaterial
        '
        Me.cmbFamiliaMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFamiliaMaterial.FormattingEnabled = True
        Me.cmbFamiliaMaterial.Location = New System.Drawing.Point(394, 29)
        Me.cmbFamiliaMaterial.Name = "cmbFamiliaMaterial"
        Me.cmbFamiliaMaterial.Size = New System.Drawing.Size(120, 21)
        Me.cmbFamiliaMaterial.TabIndex = 5
        '
        'nudpeso
        '
        Me.nudpeso.DecimalPlaces = 2
        Me.nudpeso.Location = New System.Drawing.Point(15, 80)
        Me.nudpeso.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.nudpeso.Name = "nudpeso"
        Me.nudpeso.Size = New System.Drawing.Size(78, 20)
        Me.nudpeso.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(637, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(122, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 6
        '
        'txtReferencia
        '
        Me.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferencia.Location = New System.Drawing.Point(9, 30)
        Me.txtReferencia.MaxLength = 50
        Me.txtReferencia.Name = "txtReferencia"
        Me.txtReferencia.Size = New System.Drawing.Size(104, 20)
        Me.txtReferencia.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 4
        '
        'cmbNivel
        '
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.FormattingEnabled = True
        Me.cmbNivel.Location = New System.Drawing.Point(541, 29)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(83, 21)
        Me.cmbNivel.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(563, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(730, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 13)
        Me.Label12.TabIndex = 14
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(92, 85)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(13, 13)
        Me.Label24.TabIndex = 34
        Me.Label24.Text = "g"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(185, 87)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(23, 13)
        Me.Label25.TabIndex = 35
        Me.Label25.Text = "mm"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(284, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(15, 13)
        Me.Label26.TabIndex = 36
        Me.Label26.Text = "%"
        '
        'tpimagenes
        '
        Me.tpimagenes.Controls.Add(Me.flpImagenes)
        Me.tpimagenes.Controls.Add(Me.tsherramientas)
        Me.tpimagenes.Location = New System.Drawing.Point(4, 22)
        Me.tpimagenes.Name = "tpimagenes"
        Me.tpimagenes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpimagenes.Size = New System.Drawing.Size(970, 108)
        Me.tpimagenes.TabIndex = 1
        Me.tpimagenes.Text = "Imagenes"
        Me.tpimagenes.UseVisualStyleBackColor = True
        '
        'flpImagenes
        '
        Me.flpImagenes.AutoScroll = True
        Me.flpImagenes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpImagenes.Location = New System.Drawing.Point(3, 28)
        Me.flpImagenes.Name = "flpImagenes"
        Me.flpImagenes.Size = New System.Drawing.Size(964, 77)
        Me.flpImagenes.TabIndex = 1
        Me.flpImagenes.TabStop = True
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnagregarimagen})
        Me.tsherramientas.Location = New System.Drawing.Point(3, 3)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(964, 25)
        Me.tsherramientas.TabIndex = 0
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnagregarimagen
        '
        Me.btnagregarimagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnagregarimagen.Image = CType(resources.GetObject("btnagregarimagen.Image"), System.Drawing.Image)
        Me.btnagregarimagen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnagregarimagen.Name = "btnagregarimagen"
        Me.btnagregarimagen.Size = New System.Drawing.Size(23, 22)
        Me.btnagregarimagen.Text = "Agregar Imagen"
        '
        'spgeneral
        '
        Me.spgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spgeneral.Location = New System.Drawing.Point(0, 0)
        Me.spgeneral.Name = "spgeneral"
        Me.spgeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spgeneral.Panel1
        '
        Me.spgeneral.Panel1.Controls.Add(Me.tbinfo)
        Me.spgeneral.Panel1.Padding = New System.Windows.Forms.Padding(10, 10, 10, 0)
        '
        'spgeneral.Panel2
        '
        Me.spgeneral.Panel2.Controls.Add(Me.spinfo)
        Me.spgeneral.Panel2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.spgeneral.Size = New System.Drawing.Size(998, 443)
        Me.spgeneral.SplitterDistance = 144
        Me.spgeneral.TabIndex = 0
        '
        'spinfo
        '
        Me.spinfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spinfo.Location = New System.Drawing.Point(10, 0)
        Me.spinfo.Name = "spinfo"
        Me.spinfo.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spinfo.Panel1
        '
        Me.spinfo.Panel1.Controls.Add(Me.fddFiltros)
        '
        'spinfo.Panel2
        '
        Me.spinfo.Panel2.Controls.Add(Me.dwItems)
        Me.spinfo.Size = New System.Drawing.Size(978, 295)
        Me.spinfo.SplitterDistance = 89
        Me.spinfo.TabIndex = 2
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(978, 89)
        Me.fddFiltros.TabIndex = 0
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha_Creacion, Me.Usuario_Creacion, Me.Referencia, Me.Descripcion, Me.Peso, Me.Perimetro, Me.Unidad_medida, Me.Id_Familia_Material, Me.Familia_Material, Me.Id_Nivel, Me.Nivel, Me.Id_Tasa_Impuesto, Me.Tasa_Impuesto, Me.porcentajeDesperdicio, Me.Alto_para_descuentos, Me.costo_instalacion, Me.Fecha_Modificacion, Me.Usuario_Modificacion, Me.Id_Estado, Me.Estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 0)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(978, 202)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 41
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
        'Referencia
        '
        Me.Referencia.HeaderText = "Referencia"
        Me.Referencia.Name = "Referencia"
        Me.Referencia.ReadOnly = True
        Me.Referencia.Width = 84
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Peso
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = "N2"
        Me.Peso.DefaultCellStyle = DataGridViewCellStyle1
        Me.Peso.HeaderText = "Peso"
        Me.Peso.Name = "Peso"
        Me.Peso.ReadOnly = True
        Me.Peso.Width = 56
        '
        'Perimetro
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        Me.Perimetro.DefaultCellStyle = DataGridViewCellStyle2
        Me.Perimetro.HeaderText = "Perimetro"
        Me.Perimetro.Name = "Perimetro"
        Me.Perimetro.ReadOnly = True
        Me.Perimetro.Width = 76
        '
        'Unidad_medida
        '
        Me.Unidad_medida.HeaderText = "Unidad de medida"
        Me.Unidad_medida.Name = "Unidad_medida"
        Me.Unidad_medida.ReadOnly = True
        Me.Unidad_medida.Width = 108
        '
        'Id_Familia_Material
        '
        Me.Id_Familia_Material.HeaderText = "Id familia material"
        Me.Id_Familia_Material.Name = "Id_Familia_Material"
        Me.Id_Familia_Material.ReadOnly = True
        Me.Id_Familia_Material.Visible = False
        Me.Id_Familia_Material.Width = 103
        '
        'Familia_Material
        '
        Me.Familia_Material.HeaderText = "Familia material"
        Me.Familia_Material.Name = "Familia_Material"
        Me.Familia_Material.ReadOnly = True
        Me.Familia_Material.Width = 95
        '
        'Id_Nivel
        '
        Me.Id_Nivel.HeaderText = "Id nivel"
        Me.Id_Nivel.Name = "Id_Nivel"
        Me.Id_Nivel.ReadOnly = True
        Me.Id_Nivel.Visible = False
        Me.Id_Nivel.Width = 61
        '
        'Nivel
        '
        Me.Nivel.HeaderText = "Nivel"
        Me.Nivel.Name = "Nivel"
        Me.Nivel.ReadOnly = True
        Me.Nivel.Width = 56
        '
        'Id_Tasa_Impuesto
        '
        Me.Id_Tasa_Impuesto.HeaderText = "Id tasa impuesto"
        Me.Id_Tasa_Impuesto.Name = "Id_Tasa_Impuesto"
        Me.Id_Tasa_Impuesto.ReadOnly = True
        Me.Id_Tasa_Impuesto.Visible = False
        '
        'Tasa_Impuesto
        '
        Me.Tasa_Impuesto.HeaderText = "Tasa impuesto"
        Me.Tasa_Impuesto.Name = "Tasa_Impuesto"
        Me.Tasa_Impuesto.ReadOnly = True
        Me.Tasa_Impuesto.Width = 93
        '
        'porcentajeDesperdicio
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N2"
        Me.porcentajeDesperdicio.DefaultCellStyle = DataGridViewCellStyle3
        Me.porcentajeDesperdicio.HeaderText = "Desperdicio (%)"
        Me.porcentajeDesperdicio.Name = "porcentajeDesperdicio"
        Me.porcentajeDesperdicio.ReadOnly = True
        Me.porcentajeDesperdicio.Width = 96
        '
        'Alto_para_descuentos
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N2"
        Me.Alto_para_descuentos.DefaultCellStyle = DataGridViewCellStyle4
        Me.Alto_para_descuentos.HeaderText = "Alto Descuento"
        Me.Alto_para_descuentos.Name = "Alto_para_descuentos"
        Me.Alto_para_descuentos.ReadOnly = True
        Me.Alto_para_descuentos.Width = 96
        '
        'costo_instalacion
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        Me.costo_instalacion.DefaultCellStyle = DataGridViewCellStyle5
        Me.costo_instalacion.HeaderText = "Costo Instalacion"
        Me.costo_instalacion.Name = "costo_instalacion"
        Me.costo_instalacion.ReadOnly = True
        Me.costo_instalacion.Width = 104
        '
        'Fecha_Modificacion
        '
        Me.Fecha_Modificacion.HeaderText = "Fecha modificación"
        Me.Fecha_Modificacion.Name = "Fecha_Modificacion"
        Me.Fecha_Modificacion.ReadOnly = True
        Me.Fecha_Modificacion.Width = 114
        '
        'Usuario_Modificacion
        '
        Me.Usuario_Modificacion.HeaderText = "Usuario modificación"
        Me.Usuario_Modificacion.Name = "Usuario_Modificacion"
        Me.Usuario_Modificacion.ReadOnly = True
        Me.Usuario_Modificacion.Width = 119
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
        'FrmArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(998, 443)
        Me.Controls.Add(Me.spgeneral)
        Me.Controls.Add(Me.lbcerrarImagen)
        Me.Name = "FrmArticulos"
        Me.ShowIcon = False
        Me.Text = "Articulos"
        Me.tbinfo.ResumeLayout(False)
        Me.tpinfo.ResumeLayout(False)
        Me.tpinfo.PerformLayout()
        CType(Me.nudAltoDescunto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudcostoinstalacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudcosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcDesperdicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudperimetro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudpeso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpimagenes.ResumeLayout(False)
        Me.tpimagenes.PerformLayout()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.spgeneral.Panel1.ResumeLayout(False)
        Me.spgeneral.Panel2.ResumeLayout(False)
        CType(Me.spgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spgeneral.ResumeLayout(False)
        Me.spinfo.Panel1.ResumeLayout(False)
        Me.spinfo.Panel2.ResumeLayout(False)
        CType(Me.spinfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spinfo.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbcerrarImagen As Label
    Friend WithEvents tbinfo As TabControl
    Friend WithEvents tpimagenes As TabPage
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnagregarimagen As ToolStripButton
    Friend WithEvents flpImagenes As FlowLayoutPanel
    Friend WithEvents spgeneral As SplitContainer
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents tpinfo As TabPage
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbTasaImpuesto As ComboBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents nudPorcDesperdicio As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents nudperimetro As NumericUpDown
    Friend WithEvents cmbFamiliaMaterial As ComboBox
    Friend WithEvents nudpeso As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtReferencia As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbNivel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents lblCosto As Label
    Friend WithEvents nudcosto As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents nudcostoinstalacion As NumericUpDown
    Friend WithEvents Label28 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents nudAltoDescunto As NumericUpDown
    Friend WithEvents spinfo As SplitContainer
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Referencia As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Peso As DataGridViewTextBoxColumn
    Friend WithEvents Perimetro As DataGridViewTextBoxColumn
    Friend WithEvents Unidad_medida As DataGridViewTextBoxColumn
    Friend WithEvents Id_Familia_Material As DataGridViewTextBoxColumn
    Friend WithEvents Familia_Material As DataGridViewTextBoxColumn
    Friend WithEvents Id_Nivel As DataGridViewTextBoxColumn
    Friend WithEvents Nivel As DataGridViewTextBoxColumn
    Friend WithEvents Id_Tasa_Impuesto As DataGridViewTextBoxColumn
    Friend WithEvents Tasa_Impuesto As DataGridViewTextBoxColumn
    Friend WithEvents porcentajeDesperdicio As DataGridViewTextBoxColumn
    Friend WithEvents Alto_para_descuentos As DataGridViewTextBoxColumn
    Friend WithEvents costo_instalacion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
