<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostoVidrioIndividual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostoVidrioIndividual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.nudCosto = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbColor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbVidrio = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEspesor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.col_idVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEspesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 80)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(759, 334)
        Me.Panel.TabIndex = 0
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idVidrio, Me.col_vidrio, Me.col_idColor, Me.col_color, Me.col_idEspesor, Me.col_espesor, Me.col_version, Me.col_costo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(749, 324)
        Me.dwItems.TabIndex = 0
        '
        'nudCosto
        '
        Me.nudCosto.Location = New System.Drawing.Point(512, 38)
        Me.nudCosto.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudCosto.Name = "nudCosto"
        Me.nudCosto.Size = New System.Drawing.Size(92, 20)
        Me.nudCosto.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(509, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Costo"
        '
        'cmbVersion
        '
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Location = New System.Drawing.Point(407, 37)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(75, 21)
        Me.cmbVersion.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(404, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Versión"
        '
        'cmbColor
        '
        Me.cmbColor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbColor.DropDownHeight = 200
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.DropDownWidth = 300
        Me.cmbColor.IntegralHeight = False
        Me.cmbColor.Location = New System.Drawing.Point(144, 37)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(105, 21)
        Me.cmbColor.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(273, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Espesor"
        '
        'cmbVidrio
        '
        Me.cmbVidrio.DatosVisibles = New String(-1) {}
        Me.cmbVidrio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbVidrio.DropDownHeight = 200
        Me.cmbVidrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVidrio.DropDownWidth = 300
        Me.cmbVidrio.IntegralHeight = False
        Me.cmbVidrio.Location = New System.Drawing.Point(12, 36)
        Me.cmbVidrio.Name = "cmbVidrio"
        Me.cmbVidrio.Size = New System.Drawing.Size(105, 21)
        Me.cmbVidrio.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(141, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Color"
        '
        'cmbEspesor
        '
        Me.cmbEspesor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbEspesor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEspesor.DropDownHeight = 200
        Me.cmbEspesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEspesor.DropDownWidth = 300
        Me.cmbEspesor.IntegralHeight = False
        Me.cmbEspesor.Location = New System.Drawing.Point(276, 37)
        Me.cmbEspesor.Name = "cmbEspesor"
        Me.cmbEspesor.Size = New System.Drawing.Size(105, 21)
        Me.cmbEspesor.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Vidrio"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(633, 34)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 45
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecalcular.Enabled = False
        Me.btnRecalcular.Image = CType(resources.GetObject("btnRecalcular.Image"), System.Drawing.Image)
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecalcular.Location = New System.Drawing.Point(641, 420)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(130, 59)
        Me.btnRecalcular.TabIndex = 47
        Me.btnRecalcular.Text = "Insertar costo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "vidrio"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'col_idVidrio
        '
        Me.col_idVidrio.HeaderText = "Id vidrio"
        Me.col_idVidrio.Name = "col_idVidrio"
        Me.col_idVidrio.ReadOnly = True
        Me.col_idVidrio.Visible = False
        Me.col_idVidrio.Width = 50
        '
        'col_vidrio
        '
        Me.col_vidrio.HeaderText = "Vidrio"
        Me.col_vidrio.Name = "col_vidrio"
        Me.col_vidrio.ReadOnly = True
        Me.col_vidrio.Width = 58
        '
        'col_idColor
        '
        Me.col_idColor.HeaderText = "Id color"
        Me.col_idColor.Name = "col_idColor"
        Me.col_idColor.ReadOnly = True
        Me.col_idColor.Visible = False
        Me.col_idColor.Width = 67
        '
        'col_color
        '
        Me.col_color.HeaderText = "Color"
        Me.col_color.Name = "col_color"
        Me.col_color.ReadOnly = True
        Me.col_color.Width = 56
        '
        'col_idEspesor
        '
        Me.col_idEspesor.HeaderText = "Id espesor"
        Me.col_idEspesor.Name = "col_idEspesor"
        Me.col_idEspesor.ReadOnly = True
        Me.col_idEspesor.Visible = False
        Me.col_idEspesor.Width = 81
        '
        'col_espesor
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.col_espesor.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_espesor.HeaderText = "Espesor"
        Me.col_espesor.Name = "col_espesor"
        Me.col_espesor.ReadOnly = True
        Me.col_espesor.Width = 70
        '
        'col_version
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N0"
        Me.col_version.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_version.HeaderText = "Version"
        Me.col_version.Name = "col_version"
        Me.col_version.ReadOnly = True
        Me.col_version.Width = 67
        '
        'col_costo
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.col_costo.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_costo.HeaderText = "Costo"
        Me.col_costo.Name = "col_costo"
        Me.col_costo.ReadOnly = True
        Me.col_costo.Width = 59
        '
        'FrmCostoVidrioIndividual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 491)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.nudCosto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbVersion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbVidrio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbEspesor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCostoVidrioIndividual"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Costo vidrio individual"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents nudCosto As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbColor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbVidrio As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEspesor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents col_idVidrio As DataGridViewTextBoxColumn
    Friend WithEvents col_vidrio As DataGridViewTextBoxColumn
    Friend WithEvents col_idColor As DataGridViewTextBoxColumn
    Friend WithEvents col_color As DataGridViewTextBoxColumn
    Friend WithEvents col_idEspesor As DataGridViewTextBoxColumn
    Friend WithEvents col_espesor As DataGridViewTextBoxColumn
    Friend WithEvents col_version As DataGridViewTextBoxColumn
    Friend WithEvents col_costo As DataGridViewTextBoxColumn
End Class
