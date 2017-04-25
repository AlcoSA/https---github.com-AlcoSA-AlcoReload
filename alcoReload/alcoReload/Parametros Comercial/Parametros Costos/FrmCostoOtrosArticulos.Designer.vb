<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCostoOtrosArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostoOtrosArticulos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.gbRecalcular = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.nudPorcent = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idFamiliaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.familiaMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevaVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevoCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.gbxVersionCostoBase = New System.Windows.Forms.GroupBox()
        Me.cmbVersion = New System.Windows.Forms.ComboBox()
        Me.btnCambiarVersionBase = New System.Windows.Forms.Button()
        Me.gbRecalcular.SuspendLayout()
        CType(Me.nudPorcent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxVersionCostoBase.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecalcular.Image = CType(resources.GetObject("btnRecalcular.Image"), System.Drawing.Image)
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecalcular.Location = New System.Drawing.Point(540, 379)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(119, 52)
        Me.btnRecalcular.TabIndex = 2
        Me.btnRecalcular.Text = "Recalcular costos"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'gbRecalcular
        '
        Me.gbRecalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRecalcular.Controls.Add(Me.btnAceptar)
        Me.gbRecalcular.Controls.Add(Me.nudPorcent)
        Me.gbRecalcular.Controls.Add(Me.Label1)
        Me.gbRecalcular.Enabled = False
        Me.gbRecalcular.Location = New System.Drawing.Point(495, 91)
        Me.gbRecalcular.Name = "gbRecalcular"
        Me.gbRecalcular.Size = New System.Drawing.Size(200, 52)
        Me.gbRecalcular.TabIndex = 1
        Me.gbRecalcular.TabStop = False
        Me.gbRecalcular.Text = "Recalcular"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(107, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'nudPorcent
        '
        Me.nudPorcent.DecimalPlaces = 2
        Me.nudPorcent.Location = New System.Drawing.Point(7, 20)
        Me.nudPorcent.Name = "nudPorcent"
        Me.nudPorcent.Size = New System.Drawing.Size(65, 20)
        Me.nudPorcent.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "%"
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
        Me.Panel.Size = New System.Drawing.Size(477, 424)
        Me.Panel.TabIndex = 4
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fechaCreacion, Me.usuarioCreacion, Me.idArticulo, Me.descripcion, Me.idFamiliaMaterial, Me.familiaMaterial, Me.version, Me.nuevaVersion, Me.costo, Me.nuevoCosto})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 82)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(473, 338)
        Me.dwItems.TabIndex = 3
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fechaCreacion
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.fechaCreacion.DefaultCellStyle = DataGridViewCellStyle1
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Width = 120
        '
        'usuarioCreacion
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.usuarioCreacion.DefaultCellStyle = DataGridViewCellStyle2
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Width = 120
        '
        'idArticulo
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.idArticulo.DefaultCellStyle = DataGridViewCellStyle3
        Me.idArticulo.HeaderText = "Id Artículo"
        Me.idArticulo.Name = "idArticulo"
        Me.idArticulo.ReadOnly = True
        Me.idArticulo.Visible = False
        '
        'descripcion
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle4
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 300
        '
        'idFamiliaMaterial
        '
        Me.idFamiliaMaterial.HeaderText = "Id familia material"
        Me.idFamiliaMaterial.Name = "idFamiliaMaterial"
        Me.idFamiliaMaterial.ReadOnly = True
        Me.idFamiliaMaterial.Visible = False
        '
        'familiaMaterial
        '
        Me.familiaMaterial.HeaderText = "Familia material"
        Me.familiaMaterial.Name = "familiaMaterial"
        Me.familiaMaterial.ReadOnly = True
        '
        'version
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.version.DefaultCellStyle = DataGridViewCellStyle5
        Me.version.HeaderText = "Versión"
        Me.version.Name = "version"
        Me.version.ReadOnly = True
        Me.version.Width = 67
        '
        'nuevaVersion
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.nuevaVersion.DefaultCellStyle = DataGridViewCellStyle6
        Me.nuevaVersion.HeaderText = "Nueva versión"
        Me.nuevaVersion.Name = "nuevaVersion"
        Me.nuevaVersion.ReadOnly = True
        '
        'costo
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.costo.DefaultCellStyle = DataGridViewCellStyle7
        Me.costo.HeaderText = "Costo"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.Width = 59
        '
        'nuevoCosto
        '
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
        Me.fddFiltros.Size = New System.Drawing.Size(473, 82)
        Me.fddFiltros.TabIndex = 2
        '
        'bwcargas
        '
        '
        'gbxVersionCostoBase
        '
        Me.gbxVersionCostoBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxVersionCostoBase.Controls.Add(Me.cmbVersion)
        Me.gbxVersionCostoBase.Controls.Add(Me.btnCambiarVersionBase)
        Me.gbxVersionCostoBase.Enabled = False
        Me.gbxVersionCostoBase.Location = New System.Drawing.Point(495, 12)
        Me.gbxVersionCostoBase.Name = "gbxVersionCostoBase"
        Me.gbxVersionCostoBase.Size = New System.Drawing.Size(200, 73)
        Me.gbxVersionCostoBase.TabIndex = 5
        Me.gbxVersionCostoBase.TabStop = False
        Me.gbxVersionCostoBase.Text = "Versión costo base"
        '
        'cmbVersion
        '
        Me.cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersion.FormattingEnabled = True
        Me.cmbVersion.Location = New System.Drawing.Point(16, 30)
        Me.cmbVersion.Name = "cmbVersion"
        Me.cmbVersion.Size = New System.Drawing.Size(74, 21)
        Me.cmbVersion.TabIndex = 4
        '
        'btnCambiarVersionBase
        '
        Me.btnCambiarVersionBase.Location = New System.Drawing.Point(109, 28)
        Me.btnCambiarVersionBase.Name = "btnCambiarVersionBase"
        Me.btnCambiarVersionBase.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiarVersionBase.TabIndex = 2
        Me.btnCambiarVersionBase.Text = "Cambiar"
        Me.btnCambiarVersionBase.UseVisualStyleBackColor = True
        '
        'FrmCostoOtrosArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 448)
        Me.Controls.Add(Me.gbxVersionCostoBase)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.gbRecalcular)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Name = "FrmCostoOtrosArticulos"
        Me.ShowIcon = False
        Me.Text = "Costo de otros articulos"
        Me.gbRecalcular.ResumeLayout(False)
        Me.gbRecalcular.PerformLayout()
        CType(Me.nudPorcent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxVersionCostoBase.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents gbRecalcular As GroupBox
    Friend WithEvents nudPorcent As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents gbxVersionCostoBase As GroupBox
    Friend WithEvents cmbVersion As ComboBox
    Friend WithEvents btnCambiarVersionBase As Button
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idArticulo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents idFamiliaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents familiaMaterial As DataGridViewTextBoxColumn
    Friend WithEvents version As DataGridViewTextBoxColumn
    Friend WithEvents nuevaVersion As DataGridViewTextBoxColumn
    Friend WithEvents costo As DataGridViewTextBoxColumn
    Friend WithEvents nuevoCosto As DataGridViewTextBoxColumn
End Class
