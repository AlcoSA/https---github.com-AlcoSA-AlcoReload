<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddCostoPerfilTemporal
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddCostoPerfilTemporal))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.item_idCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_perfilTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_idPerfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_perfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_acabadoTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_acabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idCostoAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idCostoNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_idCostoAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAcabado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.itPerfil = New ControlesPersonalizados.Intellisens.intellises()
        Me.btnAgregarAcabado = New System.Windows.Forms.Button()
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
        Me.Panel.TabIndex = 9
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_idCosto, Me.item_perfilTemporal, Me.item_idPerfil, Me.item_perfil, Me.item_acabadoTemporal, Me.item_idAcabado, Me.item_acabado, Me.item_idCostoAcabado, Me.item_idCostoNivel, Me.item_idCostoAluminio, Me.item_costo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(546, 303)
        Me.dwItems.TabIndex = 0
        '
        'item_idCosto
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.item_idCosto.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_idCosto.HeaderText = "Id"
        Me.item_idCosto.Name = "item_idCosto"
        Me.item_idCosto.ReadOnly = True
        Me.item_idCosto.Width = 41
        '
        'item_perfilTemporal
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.NullValue = False
        Me.item_perfilTemporal.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_perfilTemporal.HeaderText = "Perfil temporal"
        Me.item_perfilTemporal.Name = "item_perfilTemporal"
        Me.item_perfilTemporal.ReadOnly = True
        Me.item_perfilTemporal.Visible = False
        Me.item_perfilTemporal.Width = 79
        '
        'item_idPerfil
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        Me.item_idPerfil.DefaultCellStyle = DataGridViewCellStyle3
        Me.item_idPerfil.HeaderText = "Id perfil"
        Me.item_idPerfil.Name = "item_idPerfil"
        Me.item_idPerfil.ReadOnly = True
        Me.item_idPerfil.Visible = False
        Me.item_idPerfil.Width = 66
        '
        'item_perfil
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.item_perfil.DefaultCellStyle = DataGridViewCellStyle4
        Me.item_perfil.HeaderText = "Perfil"
        Me.item_perfil.Name = "item_perfil"
        Me.item_perfil.ReadOnly = True
        Me.item_perfil.Width = 55
        '
        'item_acabadoTemporal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.NullValue = False
        Me.item_acabadoTemporal.DefaultCellStyle = DataGridViewCellStyle5
        Me.item_acabadoTemporal.HeaderText = "Acabado temporal"
        Me.item_acabadoTemporal.Name = "item_acabadoTemporal"
        Me.item_acabadoTemporal.ReadOnly = True
        Me.item_acabadoTemporal.Visible = False
        Me.item_acabadoTemporal.Width = 99
        '
        'item_idAcabado
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        Me.item_idAcabado.DefaultCellStyle = DataGridViewCellStyle6
        Me.item_idAcabado.HeaderText = "Id acabado"
        Me.item_idAcabado.Name = "item_idAcabado"
        Me.item_idAcabado.ReadOnly = True
        Me.item_idAcabado.Visible = False
        Me.item_idAcabado.Width = 86
        '
        'item_acabado
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.item_acabado.DefaultCellStyle = DataGridViewCellStyle7
        Me.item_acabado.HeaderText = "Acabado"
        Me.item_acabado.Name = "item_acabado"
        Me.item_acabado.ReadOnly = True
        Me.item_acabado.Width = 75
        '
        'item_idCostoAcabado
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        Me.item_idCostoAcabado.DefaultCellStyle = DataGridViewCellStyle8
        Me.item_idCostoAcabado.HeaderText = "Id Costo acabado"
        Me.item_idCostoAcabado.Name = "item_idCostoAcabado"
        Me.item_idCostoAcabado.ReadOnly = True
        Me.item_idCostoAcabado.Visible = False
        Me.item_idCostoAcabado.Width = 116
        '
        'item_idCostoNivel
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        Me.item_idCostoNivel.DefaultCellStyle = DataGridViewCellStyle9
        Me.item_idCostoNivel.HeaderText = "Id costo nivel"
        Me.item_idCostoNivel.Name = "item_idCostoNivel"
        Me.item_idCostoNivel.ReadOnly = True
        Me.item_idCostoNivel.Visible = False
        Me.item_idCostoNivel.Width = 95
        '
        'item_idCostoAluminio
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        Me.item_idCostoAluminio.DefaultCellStyle = DataGridViewCellStyle10
        Me.item_idCostoAluminio.HeaderText = "Id costo aluminio"
        Me.item_idCostoAluminio.Name = "item_idCostoAluminio"
        Me.item_idCostoAluminio.ReadOnly = True
        Me.item_idCostoAluminio.Visible = False
        Me.item_idCostoAluminio.Width = 111
        '
        'item_costo
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        Me.item_costo.DefaultCellStyle = DataGridViewCellStyle11
        Me.item_costo.HeaderText = "Precio"
        Me.item_costo.Name = "item_costo"
        Me.item_costo.ReadOnly = True
        Me.item_costo.Width = 62
        '
        'tsMenu
        '
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
        Me.tsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(580, 25)
        Me.tsMenu.TabIndex = 10
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Perfil"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(217, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Acabado"
        '
        'cmbAcabado
        '
        Me.cmbAcabado.DatosVisibles = Nothing
        Me.cmbAcabado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbAcabado.DropDownHeight = 200
        Me.cmbAcabado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcabado.DropDownWidth = 230
        Me.cmbAcabado.IntegralHeight = False
        Me.cmbAcabado.Location = New System.Drawing.Point(220, 43)
        Me.cmbAcabado.Name = "cmbAcabado"
        Me.cmbAcabado.Size = New System.Drawing.Size(112, 21)
        Me.cmbAcabado.TabIndex = 14
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(493, 41)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 15
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'itPerfil
        '
        Me.itPerfil.AlternativeColumn = Nothing
        Me.itPerfil.ColToReturn = "Referencia"
        Me.itPerfil.ColumnsToFilter = New String() {"Referencia", "Descripcion"}
        Me.itPerfil.ColumnsToShow = New String() {"Referencia", "Descripcion"}
        Me.itPerfil.Dropdown_Width = 250
        Me.itPerfil.Id_Column_Name = "Id"
        Me.itPerfil.Location = New System.Drawing.Point(12, 44)
        Me.itPerfil.Maximo_Items_DropDown = 5
        Me.itPerfil.Name = "itPerfil"
        Me.itPerfil.selected_item = Nothing
        Me.itPerfil.Seleted_rowid = Nothing
        Me.itPerfil.Size = New System.Drawing.Size(176, 20)
        Me.itPerfil.TabIndex = 16
        Me.itPerfil.TablaFuente = Nothing
        Me.itPerfil.Value2 = Nothing
        '
        'btnAgregarAcabado
        '
        Me.btnAgregarAcabado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch, CType(0, Byte))
        Me.btnAgregarAcabado.Image = CType(resources.GetObject("btnAgregarAcabado.Image"), System.Drawing.Image)
        Me.btnAgregarAcabado.Location = New System.Drawing.Point(334, 43)
        Me.btnAgregarAcabado.Name = "btnAgregarAcabado"
        Me.btnAgregarAcabado.Size = New System.Drawing.Size(25, 21)
        Me.btnAgregarAcabado.TabIndex = 18
        Me.btnAgregarAcabado.UseVisualStyleBackColor = True
        '
        'FrmAddCostoPerfilTemporal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 410)
        Me.Controls.Add(Me.btnAgregarAcabado)
        Me.Controls.Add(Me.itPerfil)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbAcabado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddCostoPerfilTemporal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precio de perfil temporal"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbAcabado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents btnAgregar As Button
    Friend WithEvents itPerfil As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents item_idCosto As DataGridViewTextBoxColumn
    Friend WithEvents item_perfilTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents item_idPerfil As DataGridViewTextBoxColumn
    Friend WithEvents item_perfil As DataGridViewTextBoxColumn
    Friend WithEvents item_acabadoTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents item_idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents item_acabado As DataGridViewTextBoxColumn
    Friend WithEvents item_idCostoAcabado As DataGridViewTextBoxColumn
    Friend WithEvents item_idCostoNivel As DataGridViewTextBoxColumn
    Friend WithEvents item_idCostoAluminio As DataGridViewTextBoxColumn
    Friend WithEvents item_costo As DataGridViewTextBoxColumn
    Friend WithEvents btnAgregarAcabado As Button
End Class
