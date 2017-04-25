<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostoTrabajosItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostoTrabajosItems))
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idFamiliaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.familiaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevaVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevoCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.gbVersionCosto = New System.Windows.Forms.GroupBox()
        Me.btnCambiarVersion = New System.Windows.Forms.Button()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.gbRecalculo = New System.Windows.Forms.GroupBox()
        Me.nudPorcent = New System.Windows.Forms.NumericUpDown()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbVersionCosto.SuspendLayout()
        Me.gbRecalculo.SuspendLayout()
        CType(Me.nudPorcent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(475, 483)
        Me.Panel.TabIndex = 0
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.idTrabajo, Me.descripcion, Me.idFamiliaMaterial, Me.familiaMaterial, Me.version, Me.nuevaVersion, Me.costo, Me.nuevoCosto})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 78)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(471, 401)
        Me.dwItems.TabIndex = 5
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.id.DefaultCellStyle = DataGridViewCellStyle1
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 41
        '
        'fechaCreacion
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.fechaCreacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Width = 97
        '
        'usuarioCreacion
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.usuarioCreacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Width = 103
        '
        'idTrabajo
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.idTrabajo.DefaultCellStyle = DataGridViewCellStyle4
        Me.idTrabajo.HeaderText = "Id trabajo"
        Me.idTrabajo.Name = "idTrabajo"
        Me.idTrabajo.ReadOnly = True
        Me.idTrabajo.Visible = False
        Me.idTrabajo.Width = 70
        '
        'descripcion
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle5
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'idFamiliaMaterial
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.idFamiliaMaterial.DefaultCellStyle = DataGridViewCellStyle6
        Me.idFamiliaMaterial.HeaderText = "Id familia material"
        Me.idFamiliaMaterial.Name = "idFamiliaMaterial"
        Me.idFamiliaMaterial.ReadOnly = True
        Me.idFamiliaMaterial.Visible = False
        Me.idFamiliaMaterial.Width = 103
        '
        'familiaMaterial
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.familiaMaterial.DefaultCellStyle = DataGridViewCellStyle7
        Me.familiaMaterial.HeaderText = "Familia material"
        Me.familiaMaterial.Name = "familiaMaterial"
        Me.familiaMaterial.ReadOnly = True
        Me.familiaMaterial.Width = 95
        '
        'version
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        Me.version.DefaultCellStyle = DataGridViewCellStyle8
        Me.version.HeaderText = "Versión"
        Me.version.Name = "version"
        Me.version.ReadOnly = True
        Me.version.Width = 67
        '
        'nuevaVersion
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        Me.nuevaVersion.DefaultCellStyle = DataGridViewCellStyle9
        Me.nuevaVersion.HeaderText = "Nueva versión"
        Me.nuevaVersion.Name = "nuevaVersion"
        Me.nuevaVersion.ReadOnly = True
        Me.nuevaVersion.Width = 93
        '
        'costo
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle10.Format = "C2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.costo.DefaultCellStyle = DataGridViewCellStyle10
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 59
        '
        'nuevoCosto
        '
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.nuevoCosto.DefaultCellStyle = DataGridViewCellStyle11
        Me.nuevoCosto.HeaderText = "Nuevo costo"
        Me.nuevoCosto.Name = "nuevoCosto"
        Me.nuevoCosto.Width = 86
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(471, 78)
        Me.fddFiltros.TabIndex = 4
        '
        'gbVersionCosto
        '
        Me.gbVersionCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbVersionCosto.Controls.Add(Me.btnCambiarVersion)
        Me.gbVersionCosto.Controls.Add(Me.cmbVersion)
        Me.gbVersionCosto.Enabled = False
        Me.gbVersionCosto.Location = New System.Drawing.Point(493, 12)
        Me.gbVersionCosto.Name = "gbVersionCosto"
        Me.gbVersionCosto.Size = New System.Drawing.Size(201, 75)
        Me.gbVersionCosto.TabIndex = 1
        Me.gbVersionCosto.TabStop = False
        Me.gbVersionCosto.Text = "Versión costo base"
        '
        'btnCambiarVersion
        '
        Me.btnCambiarVersion.Location = New System.Drawing.Point(116, 27)
        Me.btnCambiarVersion.Name = "btnCambiarVersion"
        Me.btnCambiarVersion.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiarVersion.TabIndex = 1
        Me.btnCambiarVersion.Text = "Cambiar"
        Me.btnCambiarVersion.UseVisualStyleBackColor = True
        '
        'cmbVersion
        '
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Location = New System.Drawing.Point(6, 29)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(104, 21)
        Me.cmbVersion.TabIndex = 0
        '
        'gbRecalculo
        '
        Me.gbRecalculo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRecalculo.Controls.Add(Me.nudPorcent)
        Me.gbRecalculo.Controls.Add(Me.btnAceptar)
        Me.gbRecalculo.Controls.Add(Me.Label1)
        Me.gbRecalculo.Enabled = False
        Me.gbRecalculo.Location = New System.Drawing.Point(493, 93)
        Me.gbRecalculo.Name = "gbRecalculo"
        Me.gbRecalculo.Size = New System.Drawing.Size(201, 75)
        Me.gbRecalculo.TabIndex = 2
        Me.gbRecalculo.TabStop = False
        Me.gbRecalculo.Text = "Recalcular"
        '
        'nudPorcent
        '
        Me.nudPorcent.Location = New System.Drawing.Point(6, 19)
        Me.nudPorcent.Name = "nudPorcent"
        Me.nudPorcent.Size = New System.Drawing.Size(90, 20)
        Me.nudPorcent.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(116, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "%"
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecalcular.Image = CType(resources.GetObject("btnRecalcular.Image"), System.Drawing.Image)
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecalcular.Location = New System.Drawing.Point(518, 443)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(136, 47)
        Me.btnRecalcular.TabIndex = 4
        Me.btnRecalcular.Text = "Recalcular costos"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'FrmCostoTrabajosItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 507)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.gbRecalculo)
        Me.Controls.Add(Me.gbVersionCosto)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCostoTrabajosItems"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Costo trabajos items"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbVersionCosto.ResumeLayout(False)
        Me.gbRecalculo.ResumeLayout(False)
        Me.gbRecalculo.PerformLayout()
        CType(Me.nudPorcent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents gbVersionCosto As GroupBox
    Friend WithEvents btnCambiarVersion As Button
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents gbRecalculo As GroupBox
    Friend WithEvents nudPorcent As NumericUpDown
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idTrabajo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents idFamiliaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents familiaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents version As DataGridViewTextBoxColumn
    Friend WithEvents nuevaVersion As DataGridViewTextBoxColumn
    Friend WithEvents costo As DataGridViewTextBoxColumn
    Friend WithEvents nuevoCosto As DataGridViewTextBoxColumn
End Class
