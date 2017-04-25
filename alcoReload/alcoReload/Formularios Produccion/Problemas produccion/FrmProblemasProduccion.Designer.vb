<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProblemasProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProblemasProduccion))
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSeccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigoObra = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDescripcionProblema = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabAnalisisCausa = New System.Windows.Forms.TabPage()
        Me.Aca_pnlIMG = New System.Windows.Forms.Panel()
        Me.Aca_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Aca_pnlPDF = New System.Windows.Forms.Panel()
        Me.Aca_AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.Aca_dwArchivos = New System.Windows.Forms.DataGridView()
        Me.Aca_col_idArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aca_col_imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Aca_col_nombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aca_col_rutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aca_col_formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Aca_lblErrorDw = New System.Windows.Forms.Label()
        Me.Aca_btnQuitarArchivo = New System.Windows.Forms.Button()
        Me.Aca_btnAgregarArchivo = New System.Windows.Forms.Button()
        Me.Aca_btnBuscarArchivosDescripcionProblema = New System.Windows.Forms.Button()
        Me.Aca_txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Aca_txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabAccionInmediata = New System.Windows.Forms.TabPage()
        Me.Ain_pnlIMG = New System.Windows.Forms.Panel()
        Me.Ain_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Ain_pnlPDF = New System.Windows.Forms.Panel()
        Me.Ain_AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.Ain_dwArchivos = New System.Windows.Forms.DataGridView()
        Me.Ain_col_idArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ain_col_imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ain_col_nombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ain_col_rutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ain_col_formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ain_lblErrorDw = New System.Windows.Forms.Label()
        Me.Ain_btnQuitarArchivo = New System.Windows.Forms.Button()
        Me.Ain_btnAgregarArchivo = New System.Windows.Forms.Button()
        Me.Ain_btnBuscarArchivosDescripcionProblema = New System.Windows.Forms.Button()
        Me.Ain_txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Ain_txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tabAccionesDefinidas = New System.Windows.Forms.TabPage()
        Me.Ade_PnlIMG = New System.Windows.Forms.Panel()
        Me.Ade_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Ade_pnlPDF = New System.Windows.Forms.Panel()
        Me.Ade_AxAcroPDF = New AxAcroPDFLib.AxAcroPDF()
        Me.Ade_dwArchivos = New System.Windows.Forms.DataGridView()
        Me.Ade_col_idArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ade_col_imagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Ade_col_nombreArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ade_col_rutaArchivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ade_col_formato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ade_lblErrorDw = New System.Windows.Forms.Label()
        Me.Ade_btnQuitarArchivo = New System.Windows.Forms.Button()
        Me.Ade_btnAgregarArchivo = New System.Windows.Forms.Button()
        Me.Ade_btnBuscarArchivosDescripcionProblema = New System.Windows.Forms.Button()
        Me.Ade_txtRutaArchivo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Ade_txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAbrir = New System.Windows.Forms.ToolStripButton()
        Me.btnEnviarProblema = New System.Windows.Forms.ToolStripButton()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblConsecutivo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.btnCambiarResponsable = New System.Windows.Forms.ToolStripButton()
        Me.btnProblemaAnterior = New System.Windows.Forms.ToolStripButton()
        Me.btnProblemaSiguiente = New System.Windows.Forms.ToolStripButton()
        Me.btnAnularProblema = New System.Windows.Forms.ToolStripButton()
        Me.btnDevolverProblema = New System.Windows.Forms.ToolStripButton()
        Me.btnSolucionProblema = New System.Windows.Forms.ToolStripButton()
        Me.tabControl.SuspendLayout()
        Me.tabAnalisisCausa.SuspendLayout()
        Me.Aca_pnlIMG.SuspendLayout()
        CType(Me.Aca_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Aca_pnlPDF.SuspendLayout()
        CType(Me.Aca_AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Aca_dwArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAccionInmediata.SuspendLayout()
        Me.Ain_pnlIMG.SuspendLayout()
        CType(Me.Ain_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ain_pnlPDF.SuspendLayout()
        CType(Me.Ain_AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ain_dwArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAccionesDefinidas.SuspendLayout()
        Me.Ade_PnlIMG.SuspendLayout()
        CType(Me.Ade_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Ade_pnlPDF.SuspendLayout()
        CType(Me.Ade_AxAcroPDF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ade_dwArchivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha"
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(15, 89)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(285, 20)
        Me.txtVendedor.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Vendedor"
        '
        'txtSeccion
        '
        Me.txtSeccion.Location = New System.Drawing.Point(15, 128)
        Me.txtSeccion.Name = "txtSeccion"
        Me.txtSeccion.ReadOnly = True
        Me.txtSeccion.Size = New System.Drawing.Size(285, 20)
        Me.txtSeccion.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Seccion"
        '
        'txtNit
        '
        Me.txtNit.Location = New System.Drawing.Point(15, 167)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.ReadOnly = True
        Me.txtNit.Size = New System.Drawing.Size(285, 20)
        Me.txtNit.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(20, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Nit"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(15, 206)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(285, 20)
        Me.txtCliente.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 190)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Cliente"
        '
        'txtCodigoObra
        '
        Me.txtCodigoObra.Location = New System.Drawing.Point(15, 245)
        Me.txtCodigoObra.Name = "txtCodigoObra"
        Me.txtCodigoObra.ReadOnly = True
        Me.txtCodigoObra.Size = New System.Drawing.Size(285, 20)
        Me.txtCodigoObra.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 229)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Código obra"
        '
        'txtObra
        '
        Me.txtObra.Location = New System.Drawing.Point(15, 284)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.ReadOnly = True
        Me.txtObra.Size = New System.Drawing.Size(285, 20)
        Me.txtObra.TabIndex = 17
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 268)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Obra"
        '
        'txtDescripcionProblema
        '
        Me.txtDescripcionProblema.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcionProblema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcionProblema.Location = New System.Drawing.Point(15, 335)
        Me.txtDescripcionProblema.Multiline = True
        Me.txtDescripcionProblema.Name = "txtDescripcionProblema"
        Me.txtDescripcionProblema.ReadOnly = True
        Me.txtDescripcionProblema.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcionProblema.Size = New System.Drawing.Size(285, 195)
        Me.txtDescripcionProblema.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 319)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(126, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Descripción del problema"
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabControl.Controls.Add(Me.tabAnalisisCausa)
        Me.tabControl.Controls.Add(Me.tabAccionInmediata)
        Me.tabControl.Controls.Add(Me.tabAccionesDefinidas)
        Me.tabControl.Location = New System.Drawing.Point(306, 28)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(1036, 506)
        Me.tabControl.TabIndex = 20
        '
        'tabAnalisisCausa
        '
        Me.tabAnalisisCausa.BackColor = System.Drawing.SystemColors.Control
        Me.tabAnalisisCausa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_pnlIMG)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_pnlPDF)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_dwArchivos)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_lblErrorDw)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_btnQuitarArchivo)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_btnAgregarArchivo)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_btnBuscarArchivosDescripcionProblema)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_txtRutaArchivo)
        Me.tabAnalisisCausa.Controls.Add(Me.Label15)
        Me.tabAnalisisCausa.Controls.Add(Me.Aca_txtDescripcion)
        Me.tabAnalisisCausa.Controls.Add(Me.Label2)
        Me.tabAnalisisCausa.Location = New System.Drawing.Point(4, 22)
        Me.tabAnalisisCausa.Name = "tabAnalisisCausa"
        Me.tabAnalisisCausa.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAnalisisCausa.Size = New System.Drawing.Size(1028, 480)
        Me.tabAnalisisCausa.TabIndex = 0
        Me.tabAnalisisCausa.Text = "Análisis de causa"
        '
        'Aca_pnlIMG
        '
        Me.Aca_pnlIMG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aca_pnlIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Aca_pnlIMG.Controls.Add(Me.Aca_PictureBox)
        Me.Aca_pnlIMG.Location = New System.Drawing.Point(344, 6)
        Me.Aca_pnlIMG.Name = "Aca_pnlIMG"
        Me.Aca_pnlIMG.Size = New System.Drawing.Size(672, 461)
        Me.Aca_pnlIMG.TabIndex = 13
        Me.Aca_pnlIMG.Visible = False
        '
        'Aca_PictureBox
        '
        Me.Aca_PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aca_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Aca_PictureBox.Location = New System.Drawing.Point(12, 10)
        Me.Aca_PictureBox.Name = "Aca_PictureBox"
        Me.Aca_PictureBox.Size = New System.Drawing.Size(643, 434)
        Me.Aca_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Aca_PictureBox.TabIndex = 0
        Me.Aca_PictureBox.TabStop = False
        '
        'Aca_pnlPDF
        '
        Me.Aca_pnlPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Aca_pnlPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Aca_pnlPDF.Controls.Add(Me.Aca_AxAcroPDF)
        Me.Aca_pnlPDF.Location = New System.Drawing.Point(348, 6)
        Me.Aca_pnlPDF.Name = "Aca_pnlPDF"
        Me.Aca_pnlPDF.Size = New System.Drawing.Size(670, 461)
        Me.Aca_pnlPDF.TabIndex = 37
        Me.Aca_pnlPDF.Visible = False
        '
        'Aca_AxAcroPDF
        '
        Me.Aca_AxAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Aca_AxAcroPDF.Enabled = True
        Me.Aca_AxAcroPDF.Location = New System.Drawing.Point(0, 0)
        Me.Aca_AxAcroPDF.Name = "Aca_AxAcroPDF"
        Me.Aca_AxAcroPDF.OcxState = CType(resources.GetObject("Aca_AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Aca_AxAcroPDF.Size = New System.Drawing.Size(666, 457)
        Me.Aca_AxAcroPDF.TabIndex = 0
        '
        'Aca_dwArchivos
        '
        Me.Aca_dwArchivos.AllowUserToAddRows = False
        Me.Aca_dwArchivos.AllowUserToDeleteRows = False
        Me.Aca_dwArchivos.AllowUserToResizeColumns = False
        Me.Aca_dwArchivos.AllowUserToResizeRows = False
        Me.Aca_dwArchivos.BackgroundColor = System.Drawing.Color.White
        Me.Aca_dwArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Aca_dwArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Aca_dwArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Aca_col_idArchivo, Me.Aca_col_imagen, Me.Aca_col_nombreArchivo, Me.Aca_col_rutaArchivo, Me.Aca_col_formato})
        Me.Aca_dwArchivos.Location = New System.Drawing.Point(9, 390)
        Me.Aca_dwArchivos.MultiSelect = False
        Me.Aca_dwArchivos.Name = "Aca_dwArchivos"
        Me.Aca_dwArchivos.ReadOnly = True
        Me.Aca_dwArchivos.RowHeadersVisible = False
        Me.Aca_dwArchivos.Size = New System.Drawing.Size(329, 77)
        Me.Aca_dwArchivos.TabIndex = 29
        Me.Aca_dwArchivos.Tag = "2"
        '
        'Aca_col_idArchivo
        '
        Me.Aca_col_idArchivo.HeaderText = "Id"
        Me.Aca_col_idArchivo.Name = "Aca_col_idArchivo"
        Me.Aca_col_idArchivo.ReadOnly = True
        Me.Aca_col_idArchivo.Visible = False
        '
        'Aca_col_imagen
        '
        Me.Aca_col_imagen.HeaderText = ""
        Me.Aca_col_imagen.Name = "Aca_col_imagen"
        Me.Aca_col_imagen.ReadOnly = True
        Me.Aca_col_imagen.Width = 20
        '
        'Aca_col_nombreArchivo
        '
        Me.Aca_col_nombreArchivo.HeaderText = "Nombre archivo"
        Me.Aca_col_nombreArchivo.Name = "Aca_col_nombreArchivo"
        Me.Aca_col_nombreArchivo.ReadOnly = True
        Me.Aca_col_nombreArchivo.Width = 200
        '
        'Aca_col_rutaArchivo
        '
        Me.Aca_col_rutaArchivo.HeaderText = "Ruta"
        Me.Aca_col_rutaArchivo.Name = "Aca_col_rutaArchivo"
        Me.Aca_col_rutaArchivo.ReadOnly = True
        Me.Aca_col_rutaArchivo.Visible = False
        '
        'Aca_col_formato
        '
        Me.Aca_col_formato.HeaderText = "Formato"
        Me.Aca_col_formato.Name = "Aca_col_formato"
        Me.Aca_col_formato.ReadOnly = True
        Me.Aca_col_formato.Visible = False
        '
        'Aca_lblErrorDw
        '
        Me.Aca_lblErrorDw.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Aca_lblErrorDw.AutoSize = True
        Me.Aca_lblErrorDw.Location = New System.Drawing.Point(272, 327)
        Me.Aca_lblErrorDw.Name = "Aca_lblErrorDw"
        Me.Aca_lblErrorDw.Size = New System.Drawing.Size(0, 13)
        Me.Aca_lblErrorDw.TabIndex = 24
        '
        'Aca_btnQuitarArchivo
        '
        Me.Aca_btnQuitarArchivo.Enabled = False
        Me.Aca_btnQuitarArchivo.Location = New System.Drawing.Point(128, 365)
        Me.Aca_btnQuitarArchivo.Name = "Aca_btnQuitarArchivo"
        Me.Aca_btnQuitarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Aca_btnQuitarArchivo.TabIndex = 28
        Me.Aca_btnQuitarArchivo.Text = "Quitar"
        Me.Aca_btnQuitarArchivo.UseVisualStyleBackColor = True
        '
        'Aca_btnAgregarArchivo
        '
        Me.Aca_btnAgregarArchivo.Location = New System.Drawing.Point(9, 365)
        Me.Aca_btnAgregarArchivo.Name = "Aca_btnAgregarArchivo"
        Me.Aca_btnAgregarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Aca_btnAgregarArchivo.TabIndex = 27
        Me.Aca_btnAgregarArchivo.Text = "Agregar"
        Me.Aca_btnAgregarArchivo.UseVisualStyleBackColor = True
        '
        'Aca_btnBuscarArchivosDescripcionProblema
        '
        Me.Aca_btnBuscarArchivosDescripcionProblema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Aca_btnBuscarArchivosDescripcionProblema.Location = New System.Drawing.Point(308, 342)
        Me.Aca_btnBuscarArchivosDescripcionProblema.Name = "Aca_btnBuscarArchivosDescripcionProblema"
        Me.Aca_btnBuscarArchivosDescripcionProblema.Size = New System.Drawing.Size(30, 21)
        Me.Aca_btnBuscarArchivosDescripcionProblema.TabIndex = 26
        Me.Aca_btnBuscarArchivosDescripcionProblema.Text = "..."
        Me.Aca_btnBuscarArchivosDescripcionProblema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Aca_btnBuscarArchivosDescripcionProblema.UseVisualStyleBackColor = True
        '
        'Aca_txtRutaArchivo
        '
        Me.Aca_txtRutaArchivo.Enabled = False
        Me.Aca_txtRutaArchivo.Location = New System.Drawing.Point(9, 343)
        Me.Aca_txtRutaArchivo.Name = "Aca_txtRutaArchivo"
        Me.Aca_txtRutaArchivo.Size = New System.Drawing.Size(293, 20)
        Me.Aca_txtRutaArchivo.TabIndex = 25
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 327)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Adjuntar archivo"
        '
        'Aca_txtDescripcion
        '
        Me.Aca_txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Aca_txtDescripcion.Location = New System.Drawing.Point(9, 29)
        Me.Aca_txtDescripcion.Multiline = True
        Me.Aca_txtDescripcion.Name = "Aca_txtDescripcion"
        Me.Aca_txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Aca_txtDescripcion.Size = New System.Drawing.Size(329, 295)
        Me.Aca_txtDescripcion.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Descripción análisis de causa"
        '
        'tabAccionInmediata
        '
        Me.tabAccionInmediata.BackColor = System.Drawing.SystemColors.Control
        Me.tabAccionInmediata.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabAccionInmediata.Controls.Add(Me.Ain_pnlIMG)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_pnlPDF)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_dwArchivos)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_lblErrorDw)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_btnQuitarArchivo)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_btnAgregarArchivo)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_btnBuscarArchivosDescripcionProblema)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_txtRutaArchivo)
        Me.tabAccionInmediata.Controls.Add(Me.Label13)
        Me.tabAccionInmediata.Controls.Add(Me.Ain_txtDescripcion)
        Me.tabAccionInmediata.Controls.Add(Me.Label14)
        Me.tabAccionInmediata.Location = New System.Drawing.Point(4, 22)
        Me.tabAccionInmediata.Name = "tabAccionInmediata"
        Me.tabAccionInmediata.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAccionInmediata.Size = New System.Drawing.Size(1028, 480)
        Me.tabAccionInmediata.TabIndex = 1
        Me.tabAccionInmediata.Text = "Acción inmediata"
        '
        'Ain_pnlIMG
        '
        Me.Ain_pnlIMG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ain_pnlIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ain_pnlIMG.Controls.Add(Me.Ain_PictureBox)
        Me.Ain_pnlIMG.Location = New System.Drawing.Point(344, 6)
        Me.Ain_pnlIMG.Name = "Ain_pnlIMG"
        Me.Ain_pnlIMG.Size = New System.Drawing.Size(672, 461)
        Me.Ain_pnlIMG.TabIndex = 14
        Me.Ain_pnlIMG.Visible = False
        '
        'Ain_PictureBox
        '
        Me.Ain_PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ain_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ain_PictureBox.Location = New System.Drawing.Point(12, 10)
        Me.Ain_PictureBox.Name = "Ain_PictureBox"
        Me.Ain_PictureBox.Size = New System.Drawing.Size(643, 434)
        Me.Ain_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ain_PictureBox.TabIndex = 0
        Me.Ain_PictureBox.TabStop = False
        '
        'Ain_pnlPDF
        '
        Me.Ain_pnlPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ain_pnlPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ain_pnlPDF.Controls.Add(Me.Ain_AxAcroPDF)
        Me.Ain_pnlPDF.Location = New System.Drawing.Point(348, 6)
        Me.Ain_pnlPDF.Name = "Ain_pnlPDF"
        Me.Ain_pnlPDF.Size = New System.Drawing.Size(670, 461)
        Me.Ain_pnlPDF.TabIndex = 47
        Me.Ain_pnlPDF.Visible = False
        '
        'Ain_AxAcroPDF
        '
        Me.Ain_AxAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ain_AxAcroPDF.Enabled = True
        Me.Ain_AxAcroPDF.Location = New System.Drawing.Point(0, 0)
        Me.Ain_AxAcroPDF.Name = "Ain_AxAcroPDF"
        Me.Ain_AxAcroPDF.OcxState = CType(resources.GetObject("Ain_AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ain_AxAcroPDF.Size = New System.Drawing.Size(666, 457)
        Me.Ain_AxAcroPDF.TabIndex = 0
        '
        'Ain_dwArchivos
        '
        Me.Ain_dwArchivos.AllowUserToAddRows = False
        Me.Ain_dwArchivos.AllowUserToDeleteRows = False
        Me.Ain_dwArchivos.AllowUserToResizeColumns = False
        Me.Ain_dwArchivos.AllowUserToResizeRows = False
        Me.Ain_dwArchivos.BackgroundColor = System.Drawing.Color.White
        Me.Ain_dwArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ain_dwArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ain_dwArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ain_col_idArchivo, Me.Ain_col_imagen, Me.Ain_col_nombreArchivo, Me.Ain_col_rutaArchivo, Me.Ain_col_formato})
        Me.Ain_dwArchivos.Location = New System.Drawing.Point(9, 390)
        Me.Ain_dwArchivos.MultiSelect = False
        Me.Ain_dwArchivos.Name = "Ain_dwArchivos"
        Me.Ain_dwArchivos.ReadOnly = True
        Me.Ain_dwArchivos.RowHeadersVisible = False
        Me.Ain_dwArchivos.Size = New System.Drawing.Size(329, 77)
        Me.Ain_dwArchivos.TabIndex = 46
        Me.Ain_dwArchivos.Tag = "3"
        '
        'Ain_col_idArchivo
        '
        Me.Ain_col_idArchivo.HeaderText = "Id"
        Me.Ain_col_idArchivo.Name = "Ain_col_idArchivo"
        Me.Ain_col_idArchivo.ReadOnly = True
        Me.Ain_col_idArchivo.Visible = False
        '
        'Ain_col_imagen
        '
        Me.Ain_col_imagen.HeaderText = ""
        Me.Ain_col_imagen.Name = "Ain_col_imagen"
        Me.Ain_col_imagen.ReadOnly = True
        Me.Ain_col_imagen.Width = 20
        '
        'Ain_col_nombreArchivo
        '
        Me.Ain_col_nombreArchivo.HeaderText = "Nombre archivo"
        Me.Ain_col_nombreArchivo.Name = "Ain_col_nombreArchivo"
        Me.Ain_col_nombreArchivo.ReadOnly = True
        Me.Ain_col_nombreArchivo.Width = 200
        '
        'Ain_col_rutaArchivo
        '
        Me.Ain_col_rutaArchivo.HeaderText = "Ruta"
        Me.Ain_col_rutaArchivo.Name = "Ain_col_rutaArchivo"
        Me.Ain_col_rutaArchivo.ReadOnly = True
        Me.Ain_col_rutaArchivo.Visible = False
        '
        'Ain_col_formato
        '
        Me.Ain_col_formato.HeaderText = "Formato"
        Me.Ain_col_formato.Name = "Ain_col_formato"
        Me.Ain_col_formato.ReadOnly = True
        Me.Ain_col_formato.Visible = False
        '
        'Ain_lblErrorDw
        '
        Me.Ain_lblErrorDw.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ain_lblErrorDw.AutoSize = True
        Me.Ain_lblErrorDw.Location = New System.Drawing.Point(272, 327)
        Me.Ain_lblErrorDw.Name = "Ain_lblErrorDw"
        Me.Ain_lblErrorDw.Size = New System.Drawing.Size(0, 13)
        Me.Ain_lblErrorDw.TabIndex = 41
        '
        'Ain_btnQuitarArchivo
        '
        Me.Ain_btnQuitarArchivo.Enabled = False
        Me.Ain_btnQuitarArchivo.Location = New System.Drawing.Point(128, 365)
        Me.Ain_btnQuitarArchivo.Name = "Ain_btnQuitarArchivo"
        Me.Ain_btnQuitarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Ain_btnQuitarArchivo.TabIndex = 45
        Me.Ain_btnQuitarArchivo.Text = "Quitar"
        Me.Ain_btnQuitarArchivo.UseVisualStyleBackColor = True
        '
        'Ain_btnAgregarArchivo
        '
        Me.Ain_btnAgregarArchivo.Location = New System.Drawing.Point(9, 365)
        Me.Ain_btnAgregarArchivo.Name = "Ain_btnAgregarArchivo"
        Me.Ain_btnAgregarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Ain_btnAgregarArchivo.TabIndex = 44
        Me.Ain_btnAgregarArchivo.Text = "Agregar"
        Me.Ain_btnAgregarArchivo.UseVisualStyleBackColor = True
        '
        'Ain_btnBuscarArchivosDescripcionProblema
        '
        Me.Ain_btnBuscarArchivosDescripcionProblema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ain_btnBuscarArchivosDescripcionProblema.Location = New System.Drawing.Point(308, 342)
        Me.Ain_btnBuscarArchivosDescripcionProblema.Name = "Ain_btnBuscarArchivosDescripcionProblema"
        Me.Ain_btnBuscarArchivosDescripcionProblema.Size = New System.Drawing.Size(30, 21)
        Me.Ain_btnBuscarArchivosDescripcionProblema.TabIndex = 43
        Me.Ain_btnBuscarArchivosDescripcionProblema.Text = "..."
        Me.Ain_btnBuscarArchivosDescripcionProblema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Ain_btnBuscarArchivosDescripcionProblema.UseVisualStyleBackColor = True
        '
        'Ain_txtRutaArchivo
        '
        Me.Ain_txtRutaArchivo.Enabled = False
        Me.Ain_txtRutaArchivo.Location = New System.Drawing.Point(9, 343)
        Me.Ain_txtRutaArchivo.Name = "Ain_txtRutaArchivo"
        Me.Ain_txtRutaArchivo.Size = New System.Drawing.Size(293, 20)
        Me.Ain_txtRutaArchivo.TabIndex = 42
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 327)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Adjuntar archivo"
        '
        'Ain_txtDescripcion
        '
        Me.Ain_txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ain_txtDescripcion.Location = New System.Drawing.Point(9, 29)
        Me.Ain_txtDescripcion.Multiline = True
        Me.Ain_txtDescripcion.Name = "Ain_txtDescripcion"
        Me.Ain_txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Ain_txtDescripcion.Size = New System.Drawing.Size(329, 295)
        Me.Ain_txtDescripcion.TabIndex = 39
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(146, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "Descripción acción inmediata"
        '
        'tabAccionesDefinidas
        '
        Me.tabAccionesDefinidas.BackColor = System.Drawing.SystemColors.Control
        Me.tabAccionesDefinidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_PnlIMG)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_pnlPDF)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_dwArchivos)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_lblErrorDw)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_btnQuitarArchivo)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_btnAgregarArchivo)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_btnBuscarArchivosDescripcionProblema)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_txtRutaArchivo)
        Me.tabAccionesDefinidas.Controls.Add(Me.Label17)
        Me.tabAccionesDefinidas.Controls.Add(Me.Ade_txtDescripcion)
        Me.tabAccionesDefinidas.Controls.Add(Me.Label18)
        Me.tabAccionesDefinidas.Location = New System.Drawing.Point(4, 22)
        Me.tabAccionesDefinidas.Name = "tabAccionesDefinidas"
        Me.tabAccionesDefinidas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAccionesDefinidas.Size = New System.Drawing.Size(1028, 480)
        Me.tabAccionesDefinidas.TabIndex = 2
        Me.tabAccionesDefinidas.Text = "Acciones definidas"
        '
        'Ade_PnlIMG
        '
        Me.Ade_PnlIMG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ade_PnlIMG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ade_PnlIMG.Controls.Add(Me.Ade_PictureBox)
        Me.Ade_PnlIMG.Location = New System.Drawing.Point(344, 6)
        Me.Ade_PnlIMG.Name = "Ade_PnlIMG"
        Me.Ade_PnlIMG.Size = New System.Drawing.Size(672, 461)
        Me.Ade_PnlIMG.TabIndex = 15
        Me.Ade_PnlIMG.Visible = False
        '
        'Ade_PictureBox
        '
        Me.Ade_PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ade_PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ade_PictureBox.Location = New System.Drawing.Point(12, 10)
        Me.Ade_PictureBox.Name = "Ade_PictureBox"
        Me.Ade_PictureBox.Size = New System.Drawing.Size(643, 434)
        Me.Ade_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Ade_PictureBox.TabIndex = 0
        Me.Ade_PictureBox.TabStop = False
        '
        'Ade_pnlPDF
        '
        Me.Ade_pnlPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ade_pnlPDF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ade_pnlPDF.Controls.Add(Me.Ade_AxAcroPDF)
        Me.Ade_pnlPDF.Location = New System.Drawing.Point(348, 6)
        Me.Ade_pnlPDF.Name = "Ade_pnlPDF"
        Me.Ade_pnlPDF.Size = New System.Drawing.Size(670, 461)
        Me.Ade_pnlPDF.TabIndex = 48
        Me.Ade_pnlPDF.Visible = False
        '
        'Ade_AxAcroPDF
        '
        Me.Ade_AxAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ade_AxAcroPDF.Enabled = True
        Me.Ade_AxAcroPDF.Location = New System.Drawing.Point(0, 0)
        Me.Ade_AxAcroPDF.Name = "Ade_AxAcroPDF"
        Me.Ade_AxAcroPDF.OcxState = CType(resources.GetObject("Ade_AxAcroPDF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ade_AxAcroPDF.Size = New System.Drawing.Size(666, 457)
        Me.Ade_AxAcroPDF.TabIndex = 0
        '
        'Ade_dwArchivos
        '
        Me.Ade_dwArchivos.AllowUserToAddRows = False
        Me.Ade_dwArchivos.AllowUserToDeleteRows = False
        Me.Ade_dwArchivos.AllowUserToResizeColumns = False
        Me.Ade_dwArchivos.AllowUserToResizeRows = False
        Me.Ade_dwArchivos.BackgroundColor = System.Drawing.Color.White
        Me.Ade_dwArchivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Ade_dwArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Ade_dwArchivos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ade_col_idArchivo, Me.Ade_col_imagen, Me.Ade_col_nombreArchivo, Me.Ade_col_rutaArchivo, Me.Ade_col_formato})
        Me.Ade_dwArchivos.Location = New System.Drawing.Point(9, 390)
        Me.Ade_dwArchivos.MultiSelect = False
        Me.Ade_dwArchivos.Name = "Ade_dwArchivos"
        Me.Ade_dwArchivos.ReadOnly = True
        Me.Ade_dwArchivos.RowHeadersVisible = False
        Me.Ade_dwArchivos.Size = New System.Drawing.Size(329, 77)
        Me.Ade_dwArchivos.TabIndex = 46
        Me.Ade_dwArchivos.Tag = "4"
        '
        'Ade_col_idArchivo
        '
        Me.Ade_col_idArchivo.HeaderText = "Id"
        Me.Ade_col_idArchivo.Name = "Ade_col_idArchivo"
        Me.Ade_col_idArchivo.ReadOnly = True
        Me.Ade_col_idArchivo.Visible = False
        '
        'Ade_col_imagen
        '
        Me.Ade_col_imagen.HeaderText = ""
        Me.Ade_col_imagen.Name = "Ade_col_imagen"
        Me.Ade_col_imagen.ReadOnly = True
        Me.Ade_col_imagen.Width = 20
        '
        'Ade_col_nombreArchivo
        '
        Me.Ade_col_nombreArchivo.HeaderText = "Nombre archivo"
        Me.Ade_col_nombreArchivo.Name = "Ade_col_nombreArchivo"
        Me.Ade_col_nombreArchivo.ReadOnly = True
        Me.Ade_col_nombreArchivo.Width = 200
        '
        'Ade_col_rutaArchivo
        '
        Me.Ade_col_rutaArchivo.HeaderText = "Ruta"
        Me.Ade_col_rutaArchivo.Name = "Ade_col_rutaArchivo"
        Me.Ade_col_rutaArchivo.ReadOnly = True
        Me.Ade_col_rutaArchivo.Visible = False
        '
        'Ade_col_formato
        '
        Me.Ade_col_formato.HeaderText = "Formato"
        Me.Ade_col_formato.Name = "Ade_col_formato"
        Me.Ade_col_formato.ReadOnly = True
        Me.Ade_col_formato.Visible = False
        '
        'Ade_lblErrorDw
        '
        Me.Ade_lblErrorDw.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Ade_lblErrorDw.AutoSize = True
        Me.Ade_lblErrorDw.Location = New System.Drawing.Point(272, 327)
        Me.Ade_lblErrorDw.Name = "Ade_lblErrorDw"
        Me.Ade_lblErrorDw.Size = New System.Drawing.Size(0, 13)
        Me.Ade_lblErrorDw.TabIndex = 41
        '
        'Ade_btnQuitarArchivo
        '
        Me.Ade_btnQuitarArchivo.Enabled = False
        Me.Ade_btnQuitarArchivo.Location = New System.Drawing.Point(128, 365)
        Me.Ade_btnQuitarArchivo.Name = "Ade_btnQuitarArchivo"
        Me.Ade_btnQuitarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Ade_btnQuitarArchivo.TabIndex = 45
        Me.Ade_btnQuitarArchivo.Text = "Quitar"
        Me.Ade_btnQuitarArchivo.UseVisualStyleBackColor = True
        '
        'Ade_btnAgregarArchivo
        '
        Me.Ade_btnAgregarArchivo.Location = New System.Drawing.Point(9, 365)
        Me.Ade_btnAgregarArchivo.Name = "Ade_btnAgregarArchivo"
        Me.Ade_btnAgregarArchivo.Size = New System.Drawing.Size(113, 23)
        Me.Ade_btnAgregarArchivo.TabIndex = 44
        Me.Ade_btnAgregarArchivo.Text = "Agregar"
        Me.Ade_btnAgregarArchivo.UseVisualStyleBackColor = True
        '
        'Ade_btnBuscarArchivosDescripcionProblema
        '
        Me.Ade_btnBuscarArchivosDescripcionProblema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ade_btnBuscarArchivosDescripcionProblema.Location = New System.Drawing.Point(308, 342)
        Me.Ade_btnBuscarArchivosDescripcionProblema.Name = "Ade_btnBuscarArchivosDescripcionProblema"
        Me.Ade_btnBuscarArchivosDescripcionProblema.Size = New System.Drawing.Size(30, 21)
        Me.Ade_btnBuscarArchivosDescripcionProblema.TabIndex = 43
        Me.Ade_btnBuscarArchivosDescripcionProblema.Text = "..."
        Me.Ade_btnBuscarArchivosDescripcionProblema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Ade_btnBuscarArchivosDescripcionProblema.UseVisualStyleBackColor = True
        '
        'Ade_txtRutaArchivo
        '
        Me.Ade_txtRutaArchivo.Enabled = False
        Me.Ade_txtRutaArchivo.Location = New System.Drawing.Point(9, 343)
        Me.Ade_txtRutaArchivo.Name = "Ade_txtRutaArchivo"
        Me.Ade_txtRutaArchivo.Size = New System.Drawing.Size(293, 20)
        Me.Ade_txtRutaArchivo.TabIndex = 42
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 327)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(84, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Adjuntar archivo"
        '
        'Ade_txtDescripcion
        '
        Me.Ade_txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Ade_txtDescripcion.Location = New System.Drawing.Point(9, 29)
        Me.Ade_txtDescripcion.Multiline = True
        Me.Ade_txtDescripcion.Name = "Ade_txtDescripcion"
        Me.Ade_txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Ade_txtDescripcion.Size = New System.Drawing.Size(329, 295)
        Me.Ade_txtDescripcion.TabIndex = 39
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Análisis de causa"
        '
        'txtFecha
        '
        Me.txtFecha.Location = New System.Drawing.Point(15, 50)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(143, 20)
        Me.txtFecha.TabIndex = 21
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "Archivo PDF 17x17.png")
        Me.ImageList.Images.SetKeyName(1, "Archivo IMG 17x17.png")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAbrir, Me.btnEnviarProblema, Me.lblEstado, Me.ToolStripLabel2, Me.lblConsecutivo, Me.ToolStripLabel3, Me.btnCambiarResponsable, Me.btnProblemaAnterior, Me.btnProblemaSiguiente, Me.btnAnularProblema, Me.btnDevolverProblema, Me.btnSolucionProblema})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1354, 25)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnAbrir
        '
        Me.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAbrir.Enabled = False
        Me.btnAbrir.Image = CType(resources.GetObject("btnAbrir.Image"), System.Drawing.Image)
        Me.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAbrir.Name = "btnAbrir"
        Me.btnAbrir.Size = New System.Drawing.Size(23, 22)
        Me.btnAbrir.Text = "Abrir"
        Me.btnAbrir.Visible = False
        '
        'btnEnviarProblema
        '
        Me.btnEnviarProblema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnEnviarProblema.Enabled = False
        Me.btnEnviarProblema.Image = CType(resources.GetObject("btnEnviarProblema.Image"), System.Drawing.Image)
        Me.btnEnviarProblema.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEnviarProblema.Name = "btnEnviarProblema"
        Me.btnEnviarProblema.Size = New System.Drawing.Size(23, 22)
        Me.btnEnviarProblema.Text = "Enviar problema"
        Me.btnEnviarProblema.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(28, 22)
        Me.lblEstado.Text = "- - -"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(51, 22)
        Me.ToolStripLabel2.Text = "Estado:  "
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(35, 22)
        Me.lblConsecutivo.Text = "- - -"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(82, 22)
        Me.ToolStripLabel3.Text = "Consecutivo:  "
        '
        'btnCambiarResponsable
        '
        Me.btnCambiarResponsable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCambiarResponsable.Image = CType(resources.GetObject("btnCambiarResponsable.Image"), System.Drawing.Image)
        Me.btnCambiarResponsable.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCambiarResponsable.Name = "btnCambiarResponsable"
        Me.btnCambiarResponsable.Size = New System.Drawing.Size(23, 22)
        Me.btnCambiarResponsable.Text = "Cambiar responsable"
        '
        'btnProblemaAnterior
        '
        Me.btnProblemaAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProblemaAnterior.Enabled = False
        Me.btnProblemaAnterior.Image = CType(resources.GetObject("btnProblemaAnterior.Image"), System.Drawing.Image)
        Me.btnProblemaAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProblemaAnterior.Name = "btnProblemaAnterior"
        Me.btnProblemaAnterior.Size = New System.Drawing.Size(23, 22)
        Me.btnProblemaAnterior.Text = "Problema anterior"
        Me.btnProblemaAnterior.Visible = False
        '
        'btnProblemaSiguiente
        '
        Me.btnProblemaSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnProblemaSiguiente.Enabled = False
        Me.btnProblemaSiguiente.Image = CType(resources.GetObject("btnProblemaSiguiente.Image"), System.Drawing.Image)
        Me.btnProblemaSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnProblemaSiguiente.Name = "btnProblemaSiguiente"
        Me.btnProblemaSiguiente.Size = New System.Drawing.Size(23, 22)
        Me.btnProblemaSiguiente.Text = "Siguiente problema"
        Me.btnProblemaSiguiente.Visible = False
        '
        'btnAnularProblema
        '
        Me.btnAnularProblema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnularProblema.Image = CType(resources.GetObject("btnAnularProblema.Image"), System.Drawing.Image)
        Me.btnAnularProblema.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularProblema.Name = "btnAnularProblema"
        Me.btnAnularProblema.Size = New System.Drawing.Size(23, 22)
        Me.btnAnularProblema.Text = "Anular problema"
        '
        'btnDevolverProblema
        '
        Me.btnDevolverProblema.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDevolverProblema.Image = CType(resources.GetObject("btnDevolverProblema.Image"), System.Drawing.Image)
        Me.btnDevolverProblema.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDevolverProblema.Name = "btnDevolverProblema"
        Me.btnDevolverProblema.Size = New System.Drawing.Size(23, 22)
        Me.btnDevolverProblema.Text = "Devolver problema"
        '
        'btnSolucionProblema
        '
        Me.btnSolucionProblema.Image = CType(resources.GetObject("btnSolucionProblema.Image"), System.Drawing.Image)
        Me.btnSolucionProblema.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSolucionProblema.Name = "btnSolucionProblema"
        Me.btnSolucionProblema.Size = New System.Drawing.Size(127, 22)
        Me.btnSolucionProblema.Text = "Solución problema"
        '
        'FrmProblemasProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1354, 546)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.txtDescripcionProblema)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtObra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCodigoObra)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNit)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSeccion)
        Me.Controls.Add(Me.txtVendedor)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProblemasProduccion"
        Me.ShowIcon = False
        Me.Text = "Problemas de producción"
        Me.tabControl.ResumeLayout(False)
        Me.tabAnalisisCausa.ResumeLayout(False)
        Me.tabAnalisisCausa.PerformLayout()
        Me.Aca_pnlIMG.ResumeLayout(False)
        CType(Me.Aca_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Aca_pnlPDF.ResumeLayout(False)
        CType(Me.Aca_AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Aca_dwArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAccionInmediata.ResumeLayout(False)
        Me.tabAccionInmediata.PerformLayout()
        Me.Ain_pnlIMG.ResumeLayout(False)
        CType(Me.Ain_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ain_pnlPDF.ResumeLayout(False)
        CType(Me.Ain_AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ain_dwArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAccionesDefinidas.ResumeLayout(False)
        Me.tabAccionesDefinidas.PerformLayout()
        Me.Ade_PnlIMG.ResumeLayout(False)
        CType(Me.Ade_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Ade_pnlPDF.ResumeLayout(False)
        CType(Me.Ade_AxAcroPDF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ade_dwArchivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSeccion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNit As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCodigoObra As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDescripcionProblema As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents tabControl As TabControl
    Friend WithEvents tabAnalisisCausa As TabPage
    Friend WithEvents tabAccionInmediata As TabPage
    Friend WithEvents tabAccionesDefinidas As TabPage
    Friend WithEvents txtFecha As TextBox
    Friend WithEvents Aca_txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Aca_dwArchivos As DataGridView
    Friend WithEvents Aca_lblErrorDw As Label
    Friend WithEvents Aca_btnQuitarArchivo As Button
    Friend WithEvents Aca_btnAgregarArchivo As Button
    Friend WithEvents Aca_btnBuscarArchivosDescripcionProblema As Button
    Friend WithEvents Aca_txtRutaArchivo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Ain_dwArchivos As DataGridView
    Friend WithEvents Ain_lblErrorDw As Label
    Friend WithEvents Ain_btnQuitarArchivo As Button
    Friend WithEvents Ain_btnAgregarArchivo As Button
    Friend WithEvents Ain_btnBuscarArchivosDescripcionProblema As Button
    Friend WithEvents Ain_txtRutaArchivo As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Ain_txtDescripcion As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Ade_dwArchivos As DataGridView
    Friend WithEvents Ade_lblErrorDw As Label
    Friend WithEvents Ade_btnQuitarArchivo As Button
    Friend WithEvents Ade_btnAgregarArchivo As Button
    Friend WithEvents Ade_btnBuscarArchivosDescripcionProblema As Button
    Friend WithEvents Ade_txtRutaArchivo As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Ade_txtDescripcion As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Aca_pnlPDF As Panel
    Friend WithEvents Aca_AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents ImageList As ImageList
    Friend WithEvents Aca_pnlIMG As Panel
    Friend WithEvents Aca_PictureBox As PictureBox
    Friend WithEvents Ain_pnlIMG As Panel
    Friend WithEvents Ain_PictureBox As PictureBox
    Friend WithEvents Ain_pnlPDF As Panel
    Friend WithEvents Ain_AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Ade_pnlPDF As Panel
    Friend WithEvents Ade_AxAcroPDF As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Ade_PnlIMG As Panel
    Friend WithEvents Ade_PictureBox As PictureBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnAbrir As ToolStripButton
    Friend WithEvents btnEnviarProblema As ToolStripButton
    Friend WithEvents lblEstado As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents lblConsecutivo As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents btnCambiarResponsable As ToolStripButton
    Friend WithEvents btnProblemaAnterior As ToolStripButton
    Friend WithEvents btnProblemaSiguiente As ToolStripButton
    Friend WithEvents btnAnularProblema As ToolStripButton
    Friend WithEvents btnDevolverProblema As ToolStripButton
    Friend WithEvents btnSolucionProblema As ToolStripButton
    Friend WithEvents Aca_col_idArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Aca_col_imagen As DataGridViewImageColumn
    Friend WithEvents Aca_col_nombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Aca_col_rutaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Aca_col_formato As DataGridViewTextBoxColumn
    Friend WithEvents Ain_col_idArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ain_col_imagen As DataGridViewImageColumn
    Friend WithEvents Ain_col_nombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ain_col_rutaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ain_col_formato As DataGridViewTextBoxColumn
    Friend WithEvents Ade_col_idArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ade_col_imagen As DataGridViewImageColumn
    Friend WithEvents Ade_col_nombreArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ade_col_rutaArchivo As DataGridViewTextBoxColumn
    Friend WithEvents Ade_col_formato As DataGridViewTextBoxColumn
End Class
