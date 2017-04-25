<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistroProblemasProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistroProblemasProduccion))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContacto = New System.Windows.Forms.TextBox()
        Me.txtCiudad = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbSeccion = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbVendedor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtOp = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnBuscarArchivosDescripcionProblema = New System.Windows.Forms.Button()
        Me.txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDescripcionProblema = New System.Windows.Forms.TextBox()
        Me.gbGeneral = New System.Windows.Forms.GroupBox()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.itCliente = New ControlesPersonalizados.Intellisens.intellises()
        Me.itNit = New ControlesPersonalizados.Intellisens.intellises()
        Me.itCodigoObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.itObra = New ControlesPersonalizados.Intellisens.intellises()
        Me.AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.pnlPDF = New System.Windows.Forms.Panel()
        Me.btnAgregarArchivo = New System.Windows.Forms.Button()
        Me.btnQuitarArchivo = New System.Windows.Forms.Button()
        Me.lblError = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dwArchivos = New System.Windows.Forms.DataGridView()
        Me.col_idAdjunto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.col_nombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_rutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlIMG = New System.Windows.Forms.Panel()
        Me.PictureBox = New System.Windows.Forms.PictureBox()
        Me.gbGeneral.SuspendLayout()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPDF.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIMG.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(56, 22)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(113, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(20, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Nit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(188, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Cliente"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Código obra"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(109, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Obra"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Contacto"
        '
        'txtContacto
        '
        Me.txtContacto.Location = New System.Drawing.Point(13, 140)
        Me.txtContacto.Name = "txtContacto"
        Me.txtContacto.Size = New System.Drawing.Size(263, 20)
        Me.txtContacto.TabIndex = 11
        '
        'txtCiudad
        '
        Me.txtCiudad.Location = New System.Drawing.Point(303, 140)
        Me.txtCiudad.Name = "txtCiudad"
        Me.txtCiudad.Size = New System.Drawing.Size(165, 20)
        Me.txtCiudad.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(300, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Ciudad reclamación"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(491, 140)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(111, 20)
        Me.txtTelefono.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(488, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Teléfono"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(13, 181)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(111, 20)
        Me.txtFax.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Fax"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(148, 181)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(454, 20)
        Me.txtDireccion.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(145, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Dirección"
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbSeccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbSeccion.DropDownHeight = 200
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.DropDownWidth = 300
        Me.cmbSeccion.IntegralHeight = False
        Me.cmbSeccion.Location = New System.Drawing.Point(13, 268)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(156, 21)
        Me.cmbSeccion.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 252)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Sección"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Vendedor"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbVendedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbVendedor.DropDownHeight = 200
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.DropDownWidth = 300
        Me.cmbVendedor.IntegralHeight = False
        Me.cmbVendedor.Location = New System.Drawing.Point(13, 224)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(85, 21)
        Me.cmbVendedor.TabIndex = 21
        '
        'txtVendedor
        '
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(104, 224)
        Me.txtVendedor.Multiline = True
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(364, 21)
        Me.txtVendedor.TabIndex = 22
        '
        'txtOp
        '
        Me.txtOp.Location = New System.Drawing.Point(191, 268)
        Me.txtOp.Name = "txtOp"
        Me.txtOp.Size = New System.Drawing.Size(111, 20)
        Me.txtOp.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(188, 252)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "OP"
        '
        'btnBuscarArchivosDescripcionProblema
        '
        Me.btnBuscarArchivosDescripcionProblema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarArchivosDescripcionProblema.Location = New System.Drawing.Point(610, 363)
        Me.btnBuscarArchivosDescripcionProblema.Name = "btnBuscarArchivosDescripcionProblema"
        Me.btnBuscarArchivosDescripcionProblema.Size = New System.Drawing.Size(30, 21)
        Me.btnBuscarArchivosDescripcionProblema.TabIndex = 7
        Me.btnBuscarArchivosDescripcionProblema.Text = "..."
        Me.btnBuscarArchivosDescripcionProblema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscarArchivosDescripcionProblema.UseVisualStyleBackColor = True
        '
        'txtRutaArchivo
        '
        Me.txtRutaArchivo.Enabled = False
        Me.txtRutaArchivo.Location = New System.Drawing.Point(408, 364)
        Me.txtRutaArchivo.Name = "txtRutaArchivo"
        Me.txtRutaArchivo.Size = New System.Drawing.Size(196, 20)
        Me.txtRutaArchivo.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(405, 348)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Adjuntar archivo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 348)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(126, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Descripción del problema"
        '
        'txtDescripcionProblema
        '
        Me.txtDescripcionProblema.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionProblema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionProblema.Location = New System.Drawing.Point(12, 364)
        Me.txtDescripcionProblema.Multiline = True
        Me.txtDescripcionProblema.Name = "txtDescripcionProblema"
        Me.txtDescripcionProblema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcionProblema.Size = New System.Drawing.Size(374, 124)
        Me.txtDescripcionProblema.TabIndex = 3
        '
        'gbGeneral
        '
        Me.gbGeneral.Controls.Add(Me.lblConsecutivo)
        Me.gbGeneral.Controls.Add(Me.Label16)
        Me.gbGeneral.Controls.Add(Me.txtOp)
        Me.gbGeneral.Controls.Add(Me.txtDireccion)
        Me.gbGeneral.Controls.Add(Me.Label13)
        Me.gbGeneral.Controls.Add(Me.dtpFecha)
        Me.gbGeneral.Controls.Add(Me.Label11)
        Me.gbGeneral.Controls.Add(Me.txtVendedor)
        Me.gbGeneral.Controls.Add(Me.cmbSeccion)
        Me.gbGeneral.Controls.Add(Me.Label5)
        Me.gbGeneral.Controls.Add(Me.Label12)
        Me.gbGeneral.Controls.Add(Me.txtCiudad)
        Me.gbGeneral.Controls.Add(Me.cmbVendedor)
        Me.gbGeneral.Controls.Add(Me.Label3)
        Me.gbGeneral.Controls.Add(Me.itCliente)
        Me.gbGeneral.Controls.Add(Me.Label7)
        Me.gbGeneral.Controls.Add(Me.itNit)
        Me.gbGeneral.Controls.Add(Me.Label10)
        Me.gbGeneral.Controls.Add(Me.txtTelefono)
        Me.gbGeneral.Controls.Add(Me.Label2)
        Me.gbGeneral.Controls.Add(Me.Label6)
        Me.gbGeneral.Controls.Add(Me.itCodigoObra)
        Me.gbGeneral.Controls.Add(Me.Label4)
        Me.gbGeneral.Controls.Add(Me.Label8)
        Me.gbGeneral.Controls.Add(Me.txtFax)
        Me.gbGeneral.Controls.Add(Me.Label9)
        Me.gbGeneral.Controls.Add(Me.itObra)
        Me.gbGeneral.Controls.Add(Me.txtContacto)
        Me.gbGeneral.Controls.Add(Me.Label1)
        Me.gbGeneral.Location = New System.Drawing.Point(12, 12)
        Me.gbGeneral.Name = "gbGeneral"
        Me.gbGeneral.Size = New System.Drawing.Size(628, 308)
        Me.gbGeneral.TabIndex = 1
        Me.gbGeneral.TabStop = False
        Me.gbGeneral.Text = "Información general"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.Location = New System.Drawing.Point(483, 28)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(36, 17)
        Me.lblConsecutivo.TabIndex = 28
        Me.lblConsecutivo.Text = "- - -"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(411, 29)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 13)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "Consecutivo"
        '
        'itCliente
        '
        Me.itCliente.AlternativeColumn = "nit"
        Me.itCliente.ColToReturn = "nombreCliente"
        Me.itCliente.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itCliente.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itCliente.Dropdown_Width = 500
        Me.itCliente.Id_Column_Name = "idCliente"
        Me.itCliente.Location = New System.Drawing.Point(191, 62)
        Me.itCliente.Maximo_Items_DropDown = 5
        Me.itCliente.Name = "itCliente"
        Me.itCliente.selected_item = Nothing
        Me.itCliente.Seleted_rowid = Nothing
        Me.itCliente.Size = New System.Drawing.Size(411, 20)
        Me.itCliente.TabIndex = 5
        Me.itCliente.TablaFuente = Nothing
        Me.itCliente.Value2 = Nothing
        '
        'itNit
        '
        Me.itNit.AlternativeColumn = "nombreCliente"
        Me.itNit.ColToReturn = "nit"
        Me.itNit.ColumnsToFilter = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itNit.ColumnsToShow = New String() {"nit", "nombreCliente", "nombreEstablecimiento"}
        Me.itNit.Dropdown_Width = 500
        Me.itNit.Id_Column_Name = "idCliente"
        Me.itNit.Location = New System.Drawing.Point(13, 62)
        Me.itNit.Maximo_Items_DropDown = 5
        Me.itNit.Name = "itNit"
        Me.itNit.selected_item = Nothing
        Me.itNit.Seleted_rowid = Nothing
        Me.itNit.Size = New System.Drawing.Size(156, 20)
        Me.itNit.TabIndex = 3
        Me.itNit.TablaFuente = Nothing
        Me.itNit.Value2 = Nothing
        '
        'itCodigoObra
        '
        Me.itCodigoObra.AlternativeColumn = "nombreObra"
        Me.itCodigoObra.ColToReturn = "idObra"
        Me.itCodigoObra.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.itCodigoObra.ColumnsToShow = New String() {"idObra", "nombreObra"}
        Me.itCodigoObra.Dropdown_Width = 500
        Me.itCodigoObra.Id_Column_Name = "idObra"
        Me.itCodigoObra.Location = New System.Drawing.Point(13, 101)
        Me.itCodigoObra.Maximo_Items_DropDown = 5
        Me.itCodigoObra.Name = "itCodigoObra"
        Me.itCodigoObra.selected_item = Nothing
        Me.itCodigoObra.Seleted_rowid = Nothing
        Me.itCodigoObra.Size = New System.Drawing.Size(75, 20)
        Me.itCodigoObra.TabIndex = 7
        Me.itCodigoObra.TablaFuente = Nothing
        Me.itCodigoObra.Value2 = Nothing
        '
        'itObra
        '
        Me.itObra.AlternativeColumn = "idObra"
        Me.itObra.ColToReturn = "nombreObra"
        Me.itObra.ColumnsToFilter = New String() {"idObra", "nombreObra"}
        Me.itObra.ColumnsToShow = New String() {"idObra", "nombreObra"}
        Me.itObra.Dropdown_Width = 500
        Me.itObra.Id_Column_Name = "idObra"
        Me.itObra.Location = New System.Drawing.Point(112, 101)
        Me.itObra.Maximo_Items_DropDown = 5
        Me.itObra.Name = "itObra"
        Me.itObra.selected_item = Nothing
        Me.itObra.Seleted_rowid = Nothing
        Me.itObra.Size = New System.Drawing.Size(490, 20)
        Me.itObra.TabIndex = 9
        Me.itObra.TablaFuente = Nothing
        Me.itObra.Value2 = Nothing
        '
        'AxAcroPDF
        '
        Me.AxAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF.Enabled = True
        Me.AxAcroPDF.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF.Name = "AxAcroPDF"
        Me.AxAcroPDF.OcxState = CType(resources.GetObject("AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF.Size = New System.Drawing.Size(692, 456)
        Me.AxAcroPDF.TabIndex = 0
        '
        'pnlPDF
        '
        Me.pnlPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPDF.Controls.Add(Me.AxAcroPDF)
        Me.pnlPDF.Location = New System.Drawing.Point(651, 21)
        Me.pnlPDF.Name = "pnlPDF"
        Me.pnlPDF.Size = New System.Drawing.Size(696, 460)
        Me.pnlPDF.TabIndex = 35
        Me.pnlPDF.Visible = False
        '
        'btnAgregarArchivo
        '
        Me.btnAgregarArchivo.Location = New System.Drawing.Point(408, 386)
        Me.btnAgregarArchivo.Name = "btnAgregarArchivo"
        Me.btnAgregarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.btnAgregarArchivo.TabIndex = 8
        Me.btnAgregarArchivo.Text = "Agregar"
        Me.btnAgregarArchivo.UseVisualStyleBackColor = True
        '
        'btnQuitarArchivo
        '
        Me.btnQuitarArchivo.Enabled = False
        Me.btnQuitarArchivo.Location = New System.Drawing.Point(527, 386)
        Me.btnQuitarArchivo.Name = "btnQuitarArchivo"
        Me.btnQuitarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.btnQuitarArchivo.TabIndex = 9
        Me.btnQuitarArchivo.Text = "Quitar"
        Me.btnQuitarArchivo.UseVisualStyleBackColor = True
        '
        'lblError
        '
        Me.lblError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(574, 348)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 13)
        Me.lblError.TabIndex = 5
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'dwArchivos
        '
        Me.dwArchivos.AllowUserToAddRows = False
        Me.dwArchivos.AllowUserToDeleteRows = False
        Me.dwArchivos.AllowUserToResizeColumns = False
        Me.dwArchivos.AllowUserToResizeRows = False
        Me.dwArchivos.BackgroundColor = System.Drawing.Color.White
        Me.dwArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idAdjunto, Me.col_imagen, Me.col_nombreArchivo, Me.col_rutaArchivo, Me.col_formato})
        Me.dwArchivos.Location = New System.Drawing.Point(408, 411)
        Me.dwArchivos.MultiSelect = False
        Me.dwArchivos.Name = "dwArchivos"
        Me.dwArchivos.ReadOnly = True
        Me.dwArchivos.RowHeadersVisible = False
        Me.dwArchivos.Size = New System.Drawing.Size(232, 77)
        Me.dwArchivos.TabIndex = 10
        '
        'col_idAdjunto
        '
        Me.col_idAdjunto.HeaderText = "Id"
        Me.col_idAdjunto.Name = "col_idAdjunto"
        Me.col_idAdjunto.ReadOnly = True
        Me.col_idAdjunto.Visible = False
        '
        'col_imagen
        '
        Me.col_imagen.HeaderText = ""
        Me.col_imagen.Name = "col_imagen"
        Me.col_imagen.ReadOnly = True
        Me.col_imagen.Width = 20
        '
        'col_nombreArchivo
        '
        Me.col_nombreArchivo.HeaderText = "Nombre archivo"
        Me.col_nombreArchivo.Name = "col_nombreArchivo"
        Me.col_nombreArchivo.ReadOnly = True
        Me.col_nombreArchivo.Width = 200
        '
        'col_rutaArchivo
        '
        Me.col_rutaArchivo.HeaderText = "Ruta"
        Me.col_rutaArchivo.Name = "col_rutaArchivo"
        Me.col_rutaArchivo.ReadOnly = True
        Me.col_rutaArchivo.Visible = False
        '
        'col_formato
        '
        Me.col_formato.HeaderText = "Formato"
        Me.col_formato.Name = "col_formato"
        Me.col_formato.ReadOnly = True
        Me.col_formato.Visible = False
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Archivo PDF 17x17.png")
        Me.ImageList.Images.SetKeyName(1, "Archivo IMG 17x17.png")
        '
        'pnlIMG
        '
        Me.pnlIMG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlIMG.Controls.Add(Me.PictureBox)
        Me.pnlIMG.Location = New System.Drawing.Point(646, 16)
        Me.pnlIMG.Name = "pnlIMG"
        Me.pnlIMG.Size = New System.Drawing.Size(701, 472)
        Me.pnlIMG.TabIndex = 12
        Me.pnlIMG.Visible = False
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox.Location = New System.Drawing.Point(12, 10)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(672, 445)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'FrmRegistroProblemasProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 500)
        Me.Controls.Add(Me.pnlIMG)
        Me.Controls.Add(Me.dwArchivos)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.btnQuitarArchivo)
        Me.Controls.Add(Me.btnAgregarArchivo)
        Me.Controls.Add(Me.pnlPDF)
        Me.Controls.Add(Me.btnBuscarArchivosDescripcionProblema)
        Me.Controls.Add(Me.txtRutaArchivo)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbGeneral)
        Me.Controls.Add(Me.txtDescripcionProblema)
        Me.Controls.Add(Me.Label14)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRegistroProblemasProduccion"
        Me.ShowIcon = False
        Me.Text = "Registro problemas de producción"
        Me.gbGeneral.ResumeLayout(False)
        Me.gbGeneral.PerformLayout()
        CType(Me.AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPDF.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIMG.ResumeLayout(False)
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents itNit As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents itCliente As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label7 As Label
    Friend WithEvents itCodigoObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label8 As Label
    Friend WithEvents itObra As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtContacto As TextBox
    Friend WithEvents txtCiudad As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFax As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbSeccion As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbVendedor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtOp As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtDescripcionProblema As TextBox
    Friend WithEvents btnBuscarArchivosDescripcionProblema As Button
    Friend WithEvents txtRutaArchivo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents gbGeneral As GroupBox
    Friend WithEvents AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents pnlPDF As Panel
    Friend WithEvents btnAgregarArchivo As Button
    Friend WithEvents btnQuitarArchivo As Button
    Friend WithEvents lblError As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents dwArchivos As DataGridView
    Friend WithEvents ImageList As ImageList
    Friend WithEvents pnlIMG As Panel
    Friend WithEvents PictureBox As PictureBox
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents col_idAdjunto As DataGridViewTextBoxColumn
    Friend WithEvents col_imagen As DataGridViewImageColumn
    Friend WithEvents col_nombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents col_rutaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents col_formato As DataGridViewTextBoxColumn
End Class
