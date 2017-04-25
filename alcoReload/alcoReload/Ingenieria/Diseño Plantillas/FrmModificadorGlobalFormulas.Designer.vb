<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificadorGlobalFormulas
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tlpgeneral = New System.Windows.Forms.TableLayoutPanel()
        Me.itPlantillas = New ControlesPersonalizados.Intellisens.intellises()
        Me.lbelementos = New System.Windows.Forms.ListBox()
        Me.lbdiseños = New System.Windows.Forms.CheckedListBox()
        Me.tlpelementosmaterial = New System.Windows.Forms.TableLayoutPanel()
        Me.btnformularpxuni = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnformulaespesor = New System.Windows.Forms.Button()
        Me.txtreferencia = New System.Windows.Forms.TextBox()
        Me.txtespesor = New System.Windows.Forms.TextBox()
        Me.txtacabado = New System.Windows.Forms.TextBox()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.btnformularreferencia = New System.Windows.Forms.Button()
        Me.btnformularacabado = New System.Windows.Forms.Button()
        Me.btnformularcantidad = New System.Windows.Forms.Button()
        Me.btnformularvisibilidad = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtvisibilidad = New System.Windows.Forms.TextBox()
        Me.txtpeso = New System.Windows.Forms.TextBox()
        Me.btnformularpeso = New System.Windows.Forms.Button()
        Me.cbcortes = New System.Windows.Forms.ComboBox()
        Me.cbtipomaterial = New System.Windows.Forms.ComboBox()
        Me.cbmaterialpara = New System.Windows.Forms.ComboBox()
        Me.cbubicacion = New System.Windows.Forms.ComboBox()
        Me.cborientacion = New System.Windows.Forms.ComboBox()
        Me.btnformulardetalle = New System.Windows.Forms.Button()
        Me.txtdetalle = New System.Windows.Forms.TextBox()
        Me.txtalto = New System.Windows.Forms.TextBox()
        Me.btnformularalto = New System.Windows.Forms.Button()
        Me.txtancho = New System.Windows.Forms.TextBox()
        Me.btnformularancho = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtpxuni = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlpgeneral.SuspendLayout()
        Me.tlpelementosmaterial.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Plantillas"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tlpgeneral)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpelementosmaterial)
        Me.SplitContainer1.Size = New System.Drawing.Size(616, 452)
        Me.SplitContainer1.SplitterDistance = 308
        Me.SplitContainer1.TabIndex = 28
        '
        'tlpgeneral
        '
        Me.tlpgeneral.ColumnCount = 2
        Me.tlpgeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpgeneral.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpgeneral.Controls.Add(Me.Label1, 0, 0)
        Me.tlpgeneral.Controls.Add(Me.itPlantillas, 0, 1)
        Me.tlpgeneral.Controls.Add(Me.lbelementos, 0, 2)
        Me.tlpgeneral.Controls.Add(Me.lbdiseños, 1, 2)
        Me.tlpgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpgeneral.Location = New System.Drawing.Point(0, 0)
        Me.tlpgeneral.Name = "tlpgeneral"
        Me.tlpgeneral.RowCount = 3
        Me.tlpgeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpgeneral.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpgeneral.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpgeneral.Size = New System.Drawing.Size(308, 452)
        Me.tlpgeneral.TabIndex = 28
        '
        'itPlantillas
        '
        Me.itPlantillas.AlternativeColumn = "Familia_Modelo"
        Me.itPlantillas.ColToReturn = "Nombre_Modelo"
        Me.tlpgeneral.SetColumnSpan(Me.itPlantillas, 2)
        Me.itPlantillas.ColumnsToFilter = New String() {"Nombre_Modelo", "Descripcion"}
        Me.itPlantillas.ColumnsToShow = New String() {"Nombre_Modelo", "Descripcion"}
        Me.itPlantillas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.itPlantillas.Dropdown_Width = 250
        Me.itPlantillas.Id_Column_Name = "Id"
        Me.itPlantillas.Location = New System.Drawing.Point(3, 23)
        Me.itPlantillas.Maximo_Items_DropDown = 5
        Me.itPlantillas.Name = "itPlantillas"
        Me.itPlantillas.selected_item = Nothing
        Me.itPlantillas.Seleted_rowid = Nothing
        Me.itPlantillas.Size = New System.Drawing.Size(302, 20)
        Me.itPlantillas.TabIndex = 26
        Me.itPlantillas.TablaFuente = Nothing
        Me.itPlantillas.Value2 = ""
        '
        'lbelementos
        '
        Me.lbelementos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbelementos.FormattingEnabled = True
        Me.lbelementos.Location = New System.Drawing.Point(3, 53)
        Me.lbelementos.Name = "lbelementos"
        Me.lbelementos.Size = New System.Drawing.Size(148, 405)
        Me.lbelementos.TabIndex = 28
        '
        'lbdiseños
        '
        Me.lbdiseños.CheckOnClick = True
        Me.lbdiseños.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbdiseños.FormattingEnabled = True
        Me.lbdiseños.Location = New System.Drawing.Point(157, 53)
        Me.lbdiseños.Name = "lbdiseños"
        Me.lbdiseños.Size = New System.Drawing.Size(148, 405)
        Me.lbdiseños.TabIndex = 29
        '
        'tlpelementosmaterial
        '
        Me.tlpelementosmaterial.ColumnCount = 3
        Me.tlpelementosmaterial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743!))
        Me.tlpelementosmaterial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.10257!))
        Me.tlpelementosmaterial.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41.0!))
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularpxuni, 2, 4)
        Me.tlpelementosmaterial.Controls.Add(Me.Label2, 0, 0)
        Me.tlpelementosmaterial.Controls.Add(Me.Label3, 0, 1)
        Me.tlpelementosmaterial.Controls.Add(Me.Label4, 0, 2)
        Me.tlpelementosmaterial.Controls.Add(Me.Label5, 0, 3)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformulaespesor, 2, 1)
        Me.tlpelementosmaterial.Controls.Add(Me.txtreferencia, 1, 0)
        Me.tlpelementosmaterial.Controls.Add(Me.txtespesor, 1, 1)
        Me.tlpelementosmaterial.Controls.Add(Me.txtacabado, 1, 2)
        Me.tlpelementosmaterial.Controls.Add(Me.txtcantidad, 1, 3)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularreferencia, 2, 0)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularacabado, 2, 2)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularcantidad, 2, 3)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularvisibilidad, 2, 14)
        Me.tlpelementosmaterial.Controls.Add(Me.Label15, 0, 14)
        Me.tlpelementosmaterial.Controls.Add(Me.Label14, 0, 13)
        Me.tlpelementosmaterial.Controls.Add(Me.Label13, 0, 12)
        Me.tlpelementosmaterial.Controls.Add(Me.Label12, 0, 11)
        Me.tlpelementosmaterial.Controls.Add(Me.Label11, 0, 10)
        Me.tlpelementosmaterial.Controls.Add(Me.Label10, 0, 9)
        Me.tlpelementosmaterial.Controls.Add(Me.Label9, 0, 8)
        Me.tlpelementosmaterial.Controls.Add(Me.Label8, 0, 7)
        Me.tlpelementosmaterial.Controls.Add(Me.Label7, 0, 6)
        Me.tlpelementosmaterial.Controls.Add(Me.Label6, 0, 5)
        Me.tlpelementosmaterial.Controls.Add(Me.txtvisibilidad, 1, 14)
        Me.tlpelementosmaterial.Controls.Add(Me.txtpeso, 1, 13)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularpeso, 2, 13)
        Me.tlpelementosmaterial.Controls.Add(Me.cbcortes, 1, 12)
        Me.tlpelementosmaterial.Controls.Add(Me.cbtipomaterial, 1, 11)
        Me.tlpelementosmaterial.Controls.Add(Me.cbmaterialpara, 1, 10)
        Me.tlpelementosmaterial.Controls.Add(Me.cbubicacion, 1, 9)
        Me.tlpelementosmaterial.Controls.Add(Me.cborientacion, 1, 8)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformulardetalle, 2, 7)
        Me.tlpelementosmaterial.Controls.Add(Me.txtdetalle, 1, 7)
        Me.tlpelementosmaterial.Controls.Add(Me.txtalto, 1, 6)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularalto, 2, 6)
        Me.tlpelementosmaterial.Controls.Add(Me.txtancho, 1, 5)
        Me.tlpelementosmaterial.Controls.Add(Me.btnformularancho, 2, 5)
        Me.tlpelementosmaterial.Controls.Add(Me.Label16, 0, 4)
        Me.tlpelementosmaterial.Controls.Add(Me.txtpxuni, 1, 4)
        Me.tlpelementosmaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpelementosmaterial.Location = New System.Drawing.Point(0, 0)
        Me.tlpelementosmaterial.Name = "tlpelementosmaterial"
        Me.tlpelementosmaterial.RowCount = 15
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpelementosmaterial.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpelementosmaterial.Size = New System.Drawing.Size(304, 452)
        Me.tlpelementosmaterial.TabIndex = 0
        '
        'btnformularpxuni
        '
        Me.btnformularpxuni.Location = New System.Drawing.Point(265, 123)
        Me.btnformularpxuni.Name = "btnformularpxuni"
        Me.btnformularpxuni.Size = New System.Drawing.Size(26, 23)
        Me.btnformularpxuni.TabIndex = 39
        Me.btnformularpxuni.Text = "..."
        Me.btnformularpxuni.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Referencia"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Espesor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Acabado/Color"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Cantidad"
        '
        'btnformulaespesor
        '
        Me.btnformulaespesor.Location = New System.Drawing.Point(265, 33)
        Me.btnformulaespesor.Name = "btnformulaespesor"
        Me.btnformulaespesor.Size = New System.Drawing.Size(26, 23)
        Me.btnformulaespesor.TabIndex = 9
        Me.btnformulaespesor.Text = "..."
        Me.btnformulaespesor.UseVisualStyleBackColor = True
        '
        'txtreferencia
        '
        Me.txtreferencia.AccessibleName = "1"
        Me.txtreferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtreferencia.Location = New System.Drawing.Point(97, 3)
        Me.txtreferencia.Name = "txtreferencia"
        Me.txtreferencia.Size = New System.Drawing.Size(162, 20)
        Me.txtreferencia.TabIndex = 20
        '
        'txtespesor
        '
        Me.txtespesor.AccessibleName = "2"
        Me.txtespesor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtespesor.Location = New System.Drawing.Point(97, 33)
        Me.txtespesor.Name = "txtespesor"
        Me.txtespesor.Size = New System.Drawing.Size(162, 20)
        Me.txtespesor.TabIndex = 21
        '
        'txtacabado
        '
        Me.txtacabado.AccessibleName = "3"
        Me.txtacabado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtacabado.Location = New System.Drawing.Point(97, 63)
        Me.txtacabado.Name = "txtacabado"
        Me.txtacabado.Size = New System.Drawing.Size(162, 20)
        Me.txtacabado.TabIndex = 22
        '
        'txtcantidad
        '
        Me.txtcantidad.AccessibleName = "4"
        Me.txtcantidad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtcantidad.Location = New System.Drawing.Point(97, 93)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(162, 20)
        Me.txtcantidad.TabIndex = 23
        '
        'btnformularreferencia
        '
        Me.btnformularreferencia.Location = New System.Drawing.Point(265, 3)
        Me.btnformularreferencia.Name = "btnformularreferencia"
        Me.btnformularreferencia.Size = New System.Drawing.Size(26, 23)
        Me.btnformularreferencia.TabIndex = 29
        Me.btnformularreferencia.Text = "..."
        Me.btnformularreferencia.UseVisualStyleBackColor = True
        '
        'btnformularacabado
        '
        Me.btnformularacabado.Location = New System.Drawing.Point(265, 63)
        Me.btnformularacabado.Name = "btnformularacabado"
        Me.btnformularacabado.Size = New System.Drawing.Size(26, 23)
        Me.btnformularacabado.TabIndex = 30
        Me.btnformularacabado.Text = "..."
        Me.btnformularacabado.UseVisualStyleBackColor = True
        '
        'btnformularcantidad
        '
        Me.btnformularcantidad.Location = New System.Drawing.Point(265, 93)
        Me.btnformularcantidad.Name = "btnformularcantidad"
        Me.btnformularcantidad.Size = New System.Drawing.Size(26, 23)
        Me.btnformularcantidad.TabIndex = 31
        Me.btnformularcantidad.Text = "..."
        Me.btnformularcantidad.UseVisualStyleBackColor = True
        '
        'btnformularvisibilidad
        '
        Me.btnformularvisibilidad.Location = New System.Drawing.Point(265, 423)
        Me.btnformularvisibilidad.Name = "btnformularvisibilidad"
        Me.btnformularvisibilidad.Size = New System.Drawing.Size(26, 23)
        Me.btnformularvisibilidad.TabIndex = 36
        Me.btnformularvisibilidad.Text = "..."
        Me.btnformularvisibilidad.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 420)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Visibilidad"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 390)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Peso"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 360)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Cortes"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 330)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(68, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Tipo Material"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 300)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Material Para"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Ubicación"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 240)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Orientacion"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Detalle"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Alto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 26)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Ancho/Dimension"
        '
        'txtvisibilidad
        '
        Me.txtvisibilidad.AccessibleName = "14"
        Me.txtvisibilidad.Location = New System.Drawing.Point(97, 423)
        Me.txtvisibilidad.Name = "txtvisibilidad"
        Me.txtvisibilidad.Size = New System.Drawing.Size(162, 20)
        Me.txtvisibilidad.TabIndex = 28
        '
        'txtpeso
        '
        Me.txtpeso.AccessibleName = "13"
        Me.txtpeso.Location = New System.Drawing.Point(97, 393)
        Me.txtpeso.Name = "txtpeso"
        Me.txtpeso.Size = New System.Drawing.Size(162, 20)
        Me.txtpeso.TabIndex = 27
        '
        'btnformularpeso
        '
        Me.btnformularpeso.Location = New System.Drawing.Point(265, 393)
        Me.btnformularpeso.Name = "btnformularpeso"
        Me.btnformularpeso.Size = New System.Drawing.Size(26, 23)
        Me.btnformularpeso.TabIndex = 35
        Me.btnformularpeso.Text = "..."
        Me.btnformularpeso.UseVisualStyleBackColor = True
        '
        'cbcortes
        '
        Me.cbcortes.AccessibleName = "12"
        Me.tlpelementosmaterial.SetColumnSpan(Me.cbcortes, 2)
        Me.cbcortes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cbcortes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbcortes.FormattingEnabled = True
        Me.cbcortes.Location = New System.Drawing.Point(97, 363)
        Me.cbcortes.Name = "cbcortes"
        Me.cbcortes.Size = New System.Drawing.Size(203, 21)
        Me.cbcortes.TabIndex = 19
        '
        'cbtipomaterial
        '
        Me.cbtipomaterial.AccessibleName = "11"
        Me.tlpelementosmaterial.SetColumnSpan(Me.cbtipomaterial, 2)
        Me.cbtipomaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipomaterial.FormattingEnabled = True
        Me.cbtipomaterial.Location = New System.Drawing.Point(97, 333)
        Me.cbtipomaterial.Name = "cbtipomaterial"
        Me.cbtipomaterial.Size = New System.Drawing.Size(203, 21)
        Me.cbtipomaterial.TabIndex = 18
        '
        'cbmaterialpara
        '
        Me.cbmaterialpara.AccessibleName = "10"
        Me.tlpelementosmaterial.SetColumnSpan(Me.cbmaterialpara, 2)
        Me.cbmaterialpara.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbmaterialpara.FormattingEnabled = True
        Me.cbmaterialpara.Location = New System.Drawing.Point(97, 303)
        Me.cbmaterialpara.Name = "cbmaterialpara"
        Me.cbmaterialpara.Size = New System.Drawing.Size(203, 21)
        Me.cbmaterialpara.TabIndex = 17
        '
        'cbubicacion
        '
        Me.cbubicacion.AccessibleName = "9"
        Me.tlpelementosmaterial.SetColumnSpan(Me.cbubicacion, 2)
        Me.cbubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbubicacion.FormattingEnabled = True
        Me.cbubicacion.Location = New System.Drawing.Point(97, 273)
        Me.cbubicacion.Name = "cbubicacion"
        Me.cbubicacion.Size = New System.Drawing.Size(203, 21)
        Me.cbubicacion.TabIndex = 16
        '
        'cborientacion
        '
        Me.cborientacion.AccessibleName = "8"
        Me.tlpelementosmaterial.SetColumnSpan(Me.cborientacion, 2)
        Me.cborientacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cborientacion.FormattingEnabled = True
        Me.cborientacion.Location = New System.Drawing.Point(97, 243)
        Me.cborientacion.Name = "cborientacion"
        Me.cborientacion.Size = New System.Drawing.Size(203, 21)
        Me.cborientacion.TabIndex = 8
        '
        'btnformulardetalle
        '
        Me.btnformulardetalle.Location = New System.Drawing.Point(265, 213)
        Me.btnformulardetalle.Name = "btnformulardetalle"
        Me.btnformulardetalle.Size = New System.Drawing.Size(26, 23)
        Me.btnformulardetalle.TabIndex = 34
        Me.btnformulardetalle.Text = "..."
        Me.btnformulardetalle.UseVisualStyleBackColor = True
        '
        'txtdetalle
        '
        Me.txtdetalle.AccessibleName = "7"
        Me.txtdetalle.Location = New System.Drawing.Point(97, 213)
        Me.txtdetalle.Name = "txtdetalle"
        Me.txtdetalle.Size = New System.Drawing.Size(162, 20)
        Me.txtdetalle.TabIndex = 26
        '
        'txtalto
        '
        Me.txtalto.AccessibleName = "6"
        Me.txtalto.Location = New System.Drawing.Point(97, 183)
        Me.txtalto.Name = "txtalto"
        Me.txtalto.Size = New System.Drawing.Size(162, 20)
        Me.txtalto.TabIndex = 25
        '
        'btnformularalto
        '
        Me.btnformularalto.Location = New System.Drawing.Point(265, 183)
        Me.btnformularalto.Name = "btnformularalto"
        Me.btnformularalto.Size = New System.Drawing.Size(26, 23)
        Me.btnformularalto.TabIndex = 33
        Me.btnformularalto.Text = "..."
        Me.btnformularalto.UseVisualStyleBackColor = True
        '
        'txtancho
        '
        Me.txtancho.AccessibleName = "5"
        Me.txtancho.Location = New System.Drawing.Point(97, 153)
        Me.txtancho.Name = "txtancho"
        Me.txtancho.Size = New System.Drawing.Size(162, 20)
        Me.txtancho.TabIndex = 24
        '
        'btnformularancho
        '
        Me.btnformularancho.Location = New System.Drawing.Point(265, 153)
        Me.btnformularancho.Name = "btnformularancho"
        Me.btnformularancho.Size = New System.Drawing.Size(26, 23)
        Me.btnformularancho.TabIndex = 32
        Me.btnformularancho.Text = "..."
        Me.btnformularancho.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 120)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 13)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Piezas x Unidad"
        '
        'txtpxuni
        '
        Me.txtpxuni.AccessibleName = "15"
        Me.txtpxuni.Location = New System.Drawing.Point(97, 123)
        Me.txtpxuni.Name = "txtpxuni"
        Me.txtpxuni.Size = New System.Drawing.Size(162, 20)
        Me.txtpxuni.TabIndex = 38
        '
        'FrmModificadorGlobalFormulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 452)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmModificadorGlobalFormulas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Modificador Global Formulas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlpgeneral.ResumeLayout(False)
        Me.tlpgeneral.PerformLayout()
        Me.tlpelementosmaterial.ResumeLayout(False)
        Me.tlpelementosmaterial.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents itPlantillas As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label1 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tlpgeneral As TableLayoutPanel
    Friend WithEvents lbelementos As ListBox
    Friend WithEvents lbdiseños As CheckedListBox
    Friend WithEvents tlpelementosmaterial As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cborientacion As ComboBox
    Friend WithEvents btnformulaespesor As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cbubicacion As ComboBox
    Friend WithEvents cbmaterialpara As ComboBox
    Friend WithEvents cbtipomaterial As ComboBox
    Friend WithEvents cbcortes As ComboBox
    Friend WithEvents txtreferencia As TextBox
    Friend WithEvents txtespesor As TextBox
    Friend WithEvents txtacabado As TextBox
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents txtancho As TextBox
    Friend WithEvents txtalto As TextBox
    Friend WithEvents txtdetalle As TextBox
    Friend WithEvents txtpeso As TextBox
    Friend WithEvents txtvisibilidad As TextBox
    Friend WithEvents btnformularreferencia As Button
    Friend WithEvents btnformularacabado As Button
    Friend WithEvents btnformularcantidad As Button
    Friend WithEvents btnformularancho As Button
    Friend WithEvents btnformularalto As Button
    Friend WithEvents btnformulardetalle As Button
    Friend WithEvents btnformularpeso As Button
    Friend WithEvents btnformularvisibilidad As Button
    Friend WithEvents btnformularpxuni As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents txtpxuni As TextBox
End Class
