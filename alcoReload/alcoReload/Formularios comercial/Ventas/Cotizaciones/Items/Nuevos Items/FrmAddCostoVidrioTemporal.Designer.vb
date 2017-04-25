<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddCostoVidrioTemporal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddCostoVidrioTemporal))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.idCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vidrioTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espesorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idEspesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actualizar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmbColor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbEspesor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbVidrio = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 85)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(556, 313)
        Me.Panel.TabIndex = 8
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCosto, Me.vidrioTemporal, Me.idVidrio, Me.vidrio, Me.colorTemporal, Me.idColor, Me.color, Me.espesorTemporal, Me.idEspesor, Me.espesor, Me.precioOriginal, Me.precio, Me.actualizar})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(546, 303)
        Me.dwItems.TabIndex = 0
        '
        'idCosto
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.idCosto.DefaultCellStyle = DataGridViewCellStyle1
        Me.idCosto.HeaderText = "Id"
        Me.idCosto.Name = "idCosto"
        Me.idCosto.ReadOnly = True
        Me.idCosto.Width = 41
        '
        'vidrioTemporal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.NullValue = False
        Me.vidrioTemporal.DefaultCellStyle = DataGridViewCellStyle2
        Me.vidrioTemporal.HeaderText = "Vidrio temporal"
        Me.vidrioTemporal.Name = "vidrioTemporal"
        Me.vidrioTemporal.ReadOnly = True
        Me.vidrioTemporal.Visible = False
        Me.vidrioTemporal.Width = 82
        '
        'idVidrio
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.idVidrio.DefaultCellStyle = DataGridViewCellStyle3
        Me.idVidrio.HeaderText = "Id vidrio"
        Me.idVidrio.Name = "idVidrio"
        Me.idVidrio.ReadOnly = True
        Me.idVidrio.Visible = False
        Me.idVidrio.Width = 69
        '
        'vidrio
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.vidrio.DefaultCellStyle = DataGridViewCellStyle4
        Me.vidrio.HeaderText = "Vidrio"
        Me.vidrio.Name = "vidrio"
        Me.vidrio.ReadOnly = True
        Me.vidrio.Width = 58
        '
        'colorTemporal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.NullValue = False
        Me.colorTemporal.DefaultCellStyle = DataGridViewCellStyle5
        Me.colorTemporal.HeaderText = "Color temporal"
        Me.colorTemporal.Name = "colorTemporal"
        Me.colorTemporal.ReadOnly = True
        Me.colorTemporal.Visible = False
        Me.colorTemporal.Width = 80
        '
        'idColor
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.idColor.DefaultCellStyle = DataGridViewCellStyle6
        Me.idColor.HeaderText = "Id color"
        Me.idColor.Name = "idColor"
        Me.idColor.ReadOnly = True
        Me.idColor.Visible = False
        Me.idColor.Width = 67
        '
        'color
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.color.DefaultCellStyle = DataGridViewCellStyle7
        Me.color.HeaderText = "Color"
        Me.color.Name = "color"
        Me.color.ReadOnly = True
        Me.color.Width = 56
        '
        'espesorTemporal
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.NullValue = False
        Me.espesorTemporal.DefaultCellStyle = DataGridViewCellStyle8
        Me.espesorTemporal.HeaderText = "Espesor temporal"
        Me.espesorTemporal.Name = "espesorTemporal"
        Me.espesorTemporal.ReadOnly = True
        Me.espesorTemporal.Visible = False
        Me.espesorTemporal.Width = 94
        '
        'idEspesor
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        Me.idEspesor.DefaultCellStyle = DataGridViewCellStyle9
        Me.idEspesor.HeaderText = "Id espesor"
        Me.idEspesor.Name = "idEspesor"
        Me.idEspesor.ReadOnly = True
        Me.idEspesor.Visible = False
        Me.idEspesor.Width = 81
        '
        'espesor
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        Me.espesor.DefaultCellStyle = DataGridViewCellStyle10
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.ReadOnly = True
        Me.espesor.Width = 70
        '
        'precioOriginal
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        Me.precioOriginal.DefaultCellStyle = DataGridViewCellStyle11
        Me.precioOriginal.HeaderText = "Costo original"
        Me.precioOriginal.Name = "precioOriginal"
        Me.precioOriginal.ReadOnly = True
        Me.precioOriginal.Visible = False
        Me.precioOriginal.Width = 95
        '
        'precio
        '
        Me.precio.HeaderText = "Costo"
        Me.precio.Name = "precio"
        Me.precio.Width = 59
        '
        'actualizar
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.NullValue = False
        Me.actualizar.DefaultCellStyle = DataGridViewCellStyle12
        Me.actualizar.HeaderText = "Actualizar"
        Me.actualizar.Name = "actualizar"
        Me.actualizar.ReadOnly = True
        Me.actualizar.Visible = False
        Me.actualizar.Width = 59
        '
        'cmbColor
        '
        Me.cmbColor.DatosVisibles = Nothing
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbColor.DropDownHeight = 200
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.DropDownWidth = 230
        Me.cmbColor.IntegralHeight = False
        Me.cmbColor.Location = New System.Drawing.Point(158, 46)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(112, 21)
        Me.cmbColor.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(155, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Color"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(303, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Espesor"
        '
        'cmbEspesor
        '
        Me.cmbEspesor.DatosVisibles = Nothing
        Me.cmbEspesor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEspesor.DropDownHeight = 200
        Me.cmbEspesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEspesor.DropDownWidth = 150
        Me.cmbEspesor.IntegralHeight = False
        Me.cmbEspesor.Location = New System.Drawing.Point(306, 46)
        Me.cmbEspesor.Name = "cmbEspesor"
        Me.cmbEspesor.Size = New System.Drawing.Size(112, 21)
        Me.cmbEspesor.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vidrio"
        '
        'cmbVidrio
        '
        Me.cmbVidrio.DatosVisibles = Nothing
        Me.cmbVidrio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbVidrio.DropDownHeight = 200
        Me.cmbVidrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVidrio.DropDownWidth = 230
        Me.cmbVidrio.IntegralHeight = False
        Me.cmbVidrio.Location = New System.Drawing.Point(12, 46)
        Me.cmbVidrio.Name = "cmbVidrio"
        Me.cmbVidrio.Size = New System.Drawing.Size(112, 21)
        Me.cmbVidrio.TabIndex = 2
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(493, 44)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 7
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(580, 25)
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
        'FrmAddCostoVidrioTemporal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 410)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbVidrio)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbEspesor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddCostoVidrioTemporal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio de vidrio temporal"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents cmbColor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbEspesor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbVidrio As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents btnAgregar As Button
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents idCosto As DataGridViewTextBoxColumn
    Friend WithEvents vidrioTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents idVidrio As DataGridViewTextBoxColumn
    Friend WithEvents vidrio As DataGridViewTextBoxColumn
    Friend WithEvents colorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents idColor As DataGridViewTextBoxColumn
    Friend WithEvents color As DataGridViewTextBoxColumn
    Friend WithEvents espesorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents idEspesor As DataGridViewTextBoxColumn
    Friend WithEvents espesor As DataGridViewTextBoxColumn
    Friend WithEvents precioOriginal As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents actualizar As DataGridViewCheckBoxColumn
End Class
