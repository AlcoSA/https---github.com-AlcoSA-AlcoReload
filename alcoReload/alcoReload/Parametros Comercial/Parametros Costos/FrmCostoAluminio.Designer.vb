<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCostoAluminio
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dwCostoNivel = New System.Windows.Forms.DataGridView()
        Me.gbNiveles = New System.Windows.Forms.GroupBox()
        Me.cbRecalcularNivel = New System.Windows.Forms.CheckBox()
        Me.gbCostoAcabado = New System.Windows.Forms.GroupBox()
        Me.dwCostoAcabado = New System.Windows.Forms.DataGridView()
        Me.cbRecalcularAcabado = New System.Windows.Forms.CheckBox()
        Me.gbCostoAluminio = New System.Windows.Forms.GroupBox()
        Me.dwCostoKiloAluminio = New System.Windows.Forms.DataGridView()
        Me.cbRecalcularAluminio = New System.Windows.Forms.CheckBox()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.nudPorcentCN = New System.Windows.Forms.NumericUpDown()
        Me.lblCNiveles = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.nudPorcentCA = New System.Windows.Forms.NumericUpDown()
        Me.lblCAcabados = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudPorcentCK = New System.Windows.Forms.NumericUpDown()
        Me.lblCKAlumn = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbRecalcular = New System.Windows.Forms.GroupBox()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.gbVersionBase = New System.Windows.Forms.GroupBox()
        Me.btnCambiarVersionBase = New System.Windows.Forms.Button()
        Me.lblCKAlumn2 = New System.Windows.Forms.Label()
        Me.lblCAcabados2 = New System.Windows.Forms.Label()
        Me.cmbVersCostoKiloAlum = New System.Windows.Forms.ComboBox()
        Me.lblCNiveles2 = New System.Windows.Forms.Label()
        Me.cmbVersCostoNiveles = New System.Windows.Forms.ComboBox()
        Me.cmbVersCostoAcabados = New System.Windows.Forms.ComboBox()
        Me.idCostoNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechacNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuariocNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.versionActNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proxVersionNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoActNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevoCostoNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.motivoCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCostoAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechacAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuariocAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fMaterialCostoAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.versionActAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proxVersionAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoActAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevoCostoAcabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCostoKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechacKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuariocKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.versionActKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.proxVersionKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoActKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nuevoCostoKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwCostoNivel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNiveles.SuspendLayout()
        Me.gbCostoAcabado.SuspendLayout()
        CType(Me.dwCostoAcabado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCostoAluminio.SuspendLayout()
        CType(Me.dwCostoKiloAluminio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentCN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentCA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentCK, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRecalcular.SuspendLayout()
        Me.gbVersionBase.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwCostoNivel
        '
        Me.dwCostoNivel.AllowUserToAddRows = False
        Me.dwCostoNivel.AllowUserToDeleteRows = False
        Me.dwCostoNivel.AllowUserToOrderColumns = True
        Me.dwCostoNivel.AllowUserToResizeColumns = False
        Me.dwCostoNivel.AllowUserToResizeRows = False
        Me.dwCostoNivel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwCostoNivel.BackgroundColor = System.Drawing.Color.White
        Me.dwCostoNivel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCostoNivel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwCostoNivel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCostoNivel, Me.fechacNivel, Me.usuariocNivel, Me.idNivel, Me.nivel, Me.versionActNivel, Me.proxVersionNivel, Me.costoActNivel, Me.nuevoCostoNivel, Me.motivoCreacion})
        Me.dwCostoNivel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwCostoNivel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwCostoNivel.Location = New System.Drawing.Point(3, 16)
        Me.dwCostoNivel.Name = "dwCostoNivel"
        Me.dwCostoNivel.RowHeadersVisible = False
        Me.dwCostoNivel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwCostoNivel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwCostoNivel.Size = New System.Drawing.Size(555, 248)
        Me.dwCostoNivel.TabIndex = 0
        '
        'gbNiveles
        '
        Me.gbNiveles.Controls.Add(Me.dwCostoNivel)
        Me.gbNiveles.Controls.Add(Me.cbRecalcularNivel)
        Me.gbNiveles.Location = New System.Drawing.Point(12, 31)
        Me.gbNiveles.Name = "gbNiveles"
        Me.gbNiveles.Size = New System.Drawing.Size(561, 284)
        Me.gbNiveles.TabIndex = 0
        Me.gbNiveles.TabStop = False
        Me.gbNiveles.Text = "Costo niveles"
        '
        'cbRecalcularNivel
        '
        Me.cbRecalcularNivel.AutoSize = True
        Me.cbRecalcularNivel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbRecalcularNivel.Location = New System.Drawing.Point(3, 264)
        Me.cbRecalcularNivel.Name = "cbRecalcularNivel"
        Me.cbRecalcularNivel.Size = New System.Drawing.Size(555, 17)
        Me.cbRecalcularNivel.TabIndex = 1
        Me.cbRecalcularNivel.Text = "Recalcular costo niveles"
        Me.cbRecalcularNivel.UseVisualStyleBackColor = True
        '
        'gbCostoAcabado
        '
        Me.gbCostoAcabado.Controls.Add(Me.dwCostoAcabado)
        Me.gbCostoAcabado.Controls.Add(Me.cbRecalcularAcabado)
        Me.gbCostoAcabado.Location = New System.Drawing.Point(579, 31)
        Me.gbCostoAcabado.Name = "gbCostoAcabado"
        Me.gbCostoAcabado.Size = New System.Drawing.Size(660, 320)
        Me.gbCostoAcabado.TabIndex = 2
        Me.gbCostoAcabado.TabStop = False
        Me.gbCostoAcabado.Text = "Costo acabados"
        '
        'dwCostoAcabado
        '
        Me.dwCostoAcabado.AllowUserToAddRows = False
        Me.dwCostoAcabado.AllowUserToDeleteRows = False
        Me.dwCostoAcabado.AllowUserToOrderColumns = True
        Me.dwCostoAcabado.AllowUserToResizeColumns = False
        Me.dwCostoAcabado.AllowUserToResizeRows = False
        Me.dwCostoAcabado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwCostoAcabado.BackgroundColor = System.Drawing.Color.White
        Me.dwCostoAcabado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCostoAcabado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwCostoAcabado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCostoAcabado, Me.fechacAcabado, Me.usuariocAcabado, Me.idAcabado, Me.acabado, Me.fMaterialCostoAcabado, Me.versionActAcabado, Me.proxVersionAcabado, Me.costoActAcabado, Me.nuevoCostoAcabado})
        Me.dwCostoAcabado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwCostoAcabado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwCostoAcabado.Location = New System.Drawing.Point(3, 16)
        Me.dwCostoAcabado.Name = "dwCostoAcabado"
        Me.dwCostoAcabado.RowHeadersVisible = False
        Me.dwCostoAcabado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwCostoAcabado.Size = New System.Drawing.Size(654, 284)
        Me.dwCostoAcabado.TabIndex = 0
        '
        'cbRecalcularAcabado
        '
        Me.cbRecalcularAcabado.AutoSize = True
        Me.cbRecalcularAcabado.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbRecalcularAcabado.Location = New System.Drawing.Point(3, 300)
        Me.cbRecalcularAcabado.Name = "cbRecalcularAcabado"
        Me.cbRecalcularAcabado.Size = New System.Drawing.Size(654, 17)
        Me.cbRecalcularAcabado.TabIndex = 1
        Me.cbRecalcularAcabado.Text = "Recalcular costo acabados"
        Me.cbRecalcularAcabado.UseVisualStyleBackColor = True
        '
        'gbCostoAluminio
        '
        Me.gbCostoAluminio.Controls.Add(Me.dwCostoKiloAluminio)
        Me.gbCostoAluminio.Controls.Add(Me.cbRecalcularAluminio)
        Me.gbCostoAluminio.Location = New System.Drawing.Point(12, 329)
        Me.gbCostoAluminio.Name = "gbCostoAluminio"
        Me.gbCostoAluminio.Size = New System.Drawing.Size(561, 190)
        Me.gbCostoAluminio.TabIndex = 1
        Me.gbCostoAluminio.TabStop = False
        Me.gbCostoAluminio.Text = "Costo kilo aluminio"
        '
        'dwCostoKiloAluminio
        '
        Me.dwCostoKiloAluminio.AllowUserToAddRows = False
        Me.dwCostoKiloAluminio.AllowUserToDeleteRows = False
        Me.dwCostoKiloAluminio.AllowUserToOrderColumns = True
        Me.dwCostoKiloAluminio.AllowUserToResizeColumns = False
        Me.dwCostoKiloAluminio.AllowUserToResizeRows = False
        Me.dwCostoKiloAluminio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwCostoKiloAluminio.BackgroundColor = System.Drawing.Color.White
        Me.dwCostoKiloAluminio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCostoKiloAluminio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwCostoKiloAluminio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCostoKiloAluminio, Me.fechacKiloAluminio, Me.usuariocKiloAluminio, Me.descripcion, Me.idKiloAluminio, Me.versionActKiloAluminio, Me.proxVersionKiloAluminio, Me.costoActKiloAluminio, Me.nuevoCostoKiloAluminio})
        Me.dwCostoKiloAluminio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwCostoKiloAluminio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwCostoKiloAluminio.Location = New System.Drawing.Point(3, 16)
        Me.dwCostoKiloAluminio.Name = "dwCostoKiloAluminio"
        Me.dwCostoKiloAluminio.RowHeadersVisible = False
        Me.dwCostoKiloAluminio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwCostoKiloAluminio.Size = New System.Drawing.Size(555, 154)
        Me.dwCostoKiloAluminio.TabIndex = 0
        '
        'cbRecalcularAluminio
        '
        Me.cbRecalcularAluminio.AutoSize = True
        Me.cbRecalcularAluminio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cbRecalcularAluminio.Location = New System.Drawing.Point(3, 170)
        Me.cbRecalcularAluminio.Name = "cbRecalcularAluminio"
        Me.cbRecalcularAluminio.Size = New System.Drawing.Size(555, 17)
        Me.cbRecalcularAluminio.TabIndex = 1
        Me.cbRecalcularAluminio.Text = "Recalcular costo kilo aluminio"
        Me.cbRecalcularAluminio.UseVisualStyleBackColor = True
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Image = Global.alcoReload.My.Resources.Resources.Recalcular_32x32
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecalcular.Location = New System.Drawing.Point(1096, 451)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(143, 68)
        Me.btnRecalcular.TabIndex = 4
        Me.btnRecalcular.Text = "Recalcular costos seleccionados"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'nudPorcentCN
        '
        Me.nudPorcentCN.DecimalPlaces = 2
        Me.nudPorcentCN.Location = New System.Drawing.Point(110, 28)
        Me.nudPorcentCN.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.nudPorcentCN.Name = "nudPorcentCN"
        Me.nudPorcentCN.Size = New System.Drawing.Size(62, 20)
        Me.nudPorcentCN.TabIndex = 1
        '
        'lblCNiveles
        '
        Me.lblCNiveles.AutoSize = True
        Me.lblCNiveles.Location = New System.Drawing.Point(38, 30)
        Me.lblCNiveles.Name = "lblCNiveles"
        Me.lblCNiveles.Size = New System.Drawing.Size(70, 13)
        Me.lblCNiveles.TabIndex = 0
        Me.lblCNiveles.Text = "Costo niveles"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(170, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "%"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(110, 106)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'nudPorcentCA
        '
        Me.nudPorcentCA.DecimalPlaces = 2
        Me.nudPorcentCA.Location = New System.Drawing.Point(110, 54)
        Me.nudPorcentCA.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.nudPorcentCA.Name = "nudPorcentCA"
        Me.nudPorcentCA.Size = New System.Drawing.Size(62, 20)
        Me.nudPorcentCA.TabIndex = 4
        '
        'lblCAcabados
        '
        Me.lblCAcabados.AutoSize = True
        Me.lblCAcabados.Location = New System.Drawing.Point(24, 56)
        Me.lblCAcabados.Name = "lblCAcabados"
        Me.lblCAcabados.Size = New System.Drawing.Size(84, 13)
        Me.lblCAcabados.TabIndex = 3
        Me.lblCAcabados.Text = "Costo acabados"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(170, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(15, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "%"
        '
        'nudPorcentCK
        '
        Me.nudPorcentCK.DecimalPlaces = 2
        Me.nudPorcentCK.Location = New System.Drawing.Point(110, 80)
        Me.nudPorcentCK.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.nudPorcentCK.Name = "nudPorcentCK"
        Me.nudPorcentCK.Size = New System.Drawing.Size(62, 20)
        Me.nudPorcentCK.TabIndex = 7
        '
        'lblCKAlumn
        '
        Me.lblCKAlumn.AutoSize = True
        Me.lblCKAlumn.Location = New System.Drawing.Point(14, 83)
        Me.lblCKAlumn.Name = "lblCKAlumn"
        Me.lblCKAlumn.Size = New System.Drawing.Size(94, 13)
        Me.lblCKAlumn.TabIndex = 6
        Me.lblCKAlumn.Text = "Costo kilo aluminio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(170, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "%"
        '
        'gbRecalcular
        '
        Me.gbRecalcular.Controls.Add(Me.lblCKAlumn)
        Me.gbRecalcular.Controls.Add(Me.nudPorcentCK)
        Me.gbRecalcular.Controls.Add(Me.lblCAcabados)
        Me.gbRecalcular.Controls.Add(Me.nudPorcentCA)
        Me.gbRecalcular.Controls.Add(Me.btnAceptar)
        Me.gbRecalcular.Controls.Add(Me.lblCNiveles)
        Me.gbRecalcular.Controls.Add(Me.nudPorcentCN)
        Me.gbRecalcular.Controls.Add(Me.Label5)
        Me.gbRecalcular.Controls.Add(Me.Label3)
        Me.gbRecalcular.Controls.Add(Me.Label2)
        Me.gbRecalcular.Enabled = False
        Me.gbRecalcular.Location = New System.Drawing.Point(579, 372)
        Me.gbRecalcular.Name = "gbRecalcular"
        Me.gbRecalcular.Size = New System.Drawing.Size(205, 147)
        Me.gbRecalcular.TabIndex = 3
        Me.gbRecalcular.TabStop = False
        Me.gbRecalcular.Text = "Recalcular"
        '
        'bwcargas
        '
        '
        'gbVersionBase
        '
        Me.gbVersionBase.Controls.Add(Me.btnCambiarVersionBase)
        Me.gbVersionBase.Controls.Add(Me.lblCKAlumn2)
        Me.gbVersionBase.Controls.Add(Me.lblCAcabados2)
        Me.gbVersionBase.Controls.Add(Me.cmbVersCostoKiloAlum)
        Me.gbVersionBase.Controls.Add(Me.lblCNiveles2)
        Me.gbVersionBase.Controls.Add(Me.cmbVersCostoNiveles)
        Me.gbVersionBase.Controls.Add(Me.cmbVersCostoAcabados)
        Me.gbVersionBase.Enabled = False
        Me.gbVersionBase.Location = New System.Drawing.Point(790, 372)
        Me.gbVersionBase.Name = "gbVersionBase"
        Me.gbVersionBase.Size = New System.Drawing.Size(221, 147)
        Me.gbVersionBase.TabIndex = 5
        Me.gbVersionBase.TabStop = False
        Me.gbVersionBase.Text = "Versión costo base"
        '
        'btnCambiarVersionBase
        '
        Me.btnCambiarVersionBase.Location = New System.Drawing.Point(128, 106)
        Me.btnCambiarVersionBase.Name = "btnCambiarVersionBase"
        Me.btnCambiarVersionBase.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiarVersionBase.TabIndex = 10
        Me.btnCambiarVersionBase.Text = "Cambiar"
        Me.btnCambiarVersionBase.UseVisualStyleBackColor = True
        '
        'lblCKAlumn2
        '
        Me.lblCKAlumn2.AutoSize = True
        Me.lblCKAlumn2.Location = New System.Drawing.Point(28, 84)
        Me.lblCKAlumn2.Name = "lblCKAlumn2"
        Me.lblCKAlumn2.Size = New System.Drawing.Size(94, 13)
        Me.lblCKAlumn2.TabIndex = 12
        Me.lblCKAlumn2.Text = "Costo kilo aluminio"
        '
        'lblCAcabados2
        '
        Me.lblCAcabados2.AutoSize = True
        Me.lblCAcabados2.Location = New System.Drawing.Point(38, 57)
        Me.lblCAcabados2.Name = "lblCAcabados2"
        Me.lblCAcabados2.Size = New System.Drawing.Size(84, 13)
        Me.lblCAcabados2.TabIndex = 11
        Me.lblCAcabados2.Text = "Costo acabados"
        '
        'cmbVersCostoKiloAlum
        '
        Me.cmbVersCostoKiloAlum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersCostoKiloAlum.FormattingEnabled = True
        Me.cmbVersCostoKiloAlum.Location = New System.Drawing.Point(128, 79)
        Me.cmbVersCostoKiloAlum.Name = "cmbVersCostoKiloAlum"
        Me.cmbVersCostoKiloAlum.Size = New System.Drawing.Size(75, 21)
        Me.cmbVersCostoKiloAlum.TabIndex = 2
        '
        'lblCNiveles2
        '
        Me.lblCNiveles2.AutoSize = True
        Me.lblCNiveles2.Location = New System.Drawing.Point(52, 31)
        Me.lblCNiveles2.Name = "lblCNiveles2"
        Me.lblCNiveles2.Size = New System.Drawing.Size(70, 13)
        Me.lblCNiveles2.TabIndex = 10
        Me.lblCNiveles2.Text = "Costo niveles"
        '
        'cmbVersCostoNiveles
        '
        Me.cmbVersCostoNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersCostoNiveles.FormattingEnabled = True
        Me.cmbVersCostoNiveles.Location = New System.Drawing.Point(128, 28)
        Me.cmbVersCostoNiveles.Name = "cmbVersCostoNiveles"
        Me.cmbVersCostoNiveles.Size = New System.Drawing.Size(75, 21)
        Me.cmbVersCostoNiveles.TabIndex = 0
        '
        'cmbVersCostoAcabados
        '
        Me.cmbVersCostoAcabados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVersCostoAcabados.FormattingEnabled = True
        Me.cmbVersCostoAcabados.Location = New System.Drawing.Point(128, 53)
        Me.cmbVersCostoAcabados.Name = "cmbVersCostoAcabados"
        Me.cmbVersCostoAcabados.Size = New System.Drawing.Size(75, 21)
        Me.cmbVersCostoAcabados.TabIndex = 1
        '
        'idCostoNivel
        '
        Me.idCostoNivel.HeaderText = "ID"
        Me.idCostoNivel.Name = "idCostoNivel"
        Me.idCostoNivel.Visible = False
        Me.idCostoNivel.Width = 43
        '
        'fechacNivel
        '
        Me.fechacNivel.HeaderText = "Fecha creación"
        Me.fechacNivel.Name = "fechacNivel"
        Me.fechacNivel.Visible = False
        Me.fechacNivel.Width = 106
        '
        'usuariocNivel
        '
        Me.usuariocNivel.HeaderText = "Usuario creación"
        Me.usuariocNivel.Name = "usuariocNivel"
        Me.usuariocNivel.Visible = False
        Me.usuariocNivel.Width = 112
        '
        'idNivel
        '
        Me.idNivel.HeaderText = "Id nivel"
        Me.idNivel.Name = "idNivel"
        Me.idNivel.Visible = False
        Me.idNivel.Width = 66
        '
        'nivel
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.nivel.DefaultCellStyle = DataGridViewCellStyle1
        Me.nivel.HeaderText = "Nivel"
        Me.nivel.Name = "nivel"
        Me.nivel.ReadOnly = True
        Me.nivel.Width = 56
        '
        'versionActNivel
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Format = "N0"
        Me.versionActNivel.DefaultCellStyle = DataGridViewCellStyle2
        Me.versionActNivel.HeaderText = "Versión actual"
        Me.versionActNivel.Name = "versionActNivel"
        Me.versionActNivel.ReadOnly = True
        Me.versionActNivel.Width = 99
        '
        'proxVersionNivel
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Format = "N0"
        Me.proxVersionNivel.DefaultCellStyle = DataGridViewCellStyle3
        Me.proxVersionNivel.HeaderText = "Próxima versión"
        Me.proxVersionNivel.Name = "proxVersionNivel"
        Me.proxVersionNivel.ReadOnly = True
        Me.proxVersionNivel.Width = 106
        '
        'costoActNivel
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.costoActNivel.DefaultCellStyle = DataGridViewCellStyle4
        Me.costoActNivel.HeaderText = "Costo actual"
        Me.costoActNivel.Name = "costoActNivel"
        Me.costoActNivel.ReadOnly = True
        Me.costoActNivel.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.costoActNivel.Width = 91
        '
        'nuevoCostoNivel
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.nuevoCostoNivel.DefaultCellStyle = DataGridViewCellStyle5
        Me.nuevoCostoNivel.HeaderText = "Nuevo costo"
        Me.nuevoCostoNivel.Name = "nuevoCostoNivel"
        Me.nuevoCostoNivel.Width = 93
        '
        'motivoCreacion
        '
        Me.motivoCreacion.HeaderText = "Motivo de creación"
        Me.motivoCreacion.Name = "motivoCreacion"
        Me.motivoCreacion.Width = 123
        '
        'idCostoAcabado
        '
        Me.idCostoAcabado.HeaderText = "ID"
        Me.idCostoAcabado.Name = "idCostoAcabado"
        Me.idCostoAcabado.ReadOnly = True
        Me.idCostoAcabado.Visible = False
        Me.idCostoAcabado.Width = 24
        '
        'fechacAcabado
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.fechacAcabado.DefaultCellStyle = DataGridViewCellStyle6
        Me.fechacAcabado.HeaderText = "Fecha creación"
        Me.fechacAcabado.Name = "fechacAcabado"
        Me.fechacAcabado.ReadOnly = True
        Me.fechacAcabado.Visible = False
        Me.fechacAcabado.Width = 87
        '
        'usuariocAcabado
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.usuariocAcabado.DefaultCellStyle = DataGridViewCellStyle7
        Me.usuariocAcabado.HeaderText = "Usuario creación "
        Me.usuariocAcabado.Name = "usuariocAcabado"
        Me.usuariocAcabado.ReadOnly = True
        Me.usuariocAcabado.Visible = False
        Me.usuariocAcabado.Width = 96
        '
        'idAcabado
        '
        Me.idAcabado.HeaderText = "ID"
        Me.idAcabado.Name = "idAcabado"
        Me.idAcabado.Visible = False
        Me.idAcabado.Width = 24
        '
        'acabado
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        Me.acabado.DefaultCellStyle = DataGridViewCellStyle8
        Me.acabado.HeaderText = "Acabado"
        Me.acabado.Name = "acabado"
        Me.acabado.ReadOnly = True
        Me.acabado.Width = 75
        '
        'fMaterialCostoAcabado
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        Me.fMaterialCostoAcabado.DefaultCellStyle = DataGridViewCellStyle9
        Me.fMaterialCostoAcabado.HeaderText = "Familia material"
        Me.fMaterialCostoAcabado.Name = "fMaterialCostoAcabado"
        Me.fMaterialCostoAcabado.ReadOnly = True
        Me.fMaterialCostoAcabado.Visible = False
        Me.fMaterialCostoAcabado.Width = 103
        '
        'versionActAcabado
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle10.Format = "N0"
        Me.versionActAcabado.DefaultCellStyle = DataGridViewCellStyle10
        Me.versionActAcabado.HeaderText = "Versión actual"
        Me.versionActAcabado.Name = "versionActAcabado"
        Me.versionActAcabado.ReadOnly = True
        Me.versionActAcabado.Width = 99
        '
        'proxVersionAcabado
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle11.Format = "N0"
        Me.proxVersionAcabado.DefaultCellStyle = DataGridViewCellStyle11
        Me.proxVersionAcabado.HeaderText = "Proxima versión"
        Me.proxVersionAcabado.Name = "proxVersionAcabado"
        Me.proxVersionAcabado.ReadOnly = True
        Me.proxVersionAcabado.Width = 97
        '
        'costoActAcabado
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.Format = "C4"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.costoActAcabado.DefaultCellStyle = DataGridViewCellStyle12
        Me.costoActAcabado.HeaderText = "Costo actual"
        Me.costoActAcabado.Name = "costoActAcabado"
        Me.costoActAcabado.ReadOnly = True
        Me.costoActAcabado.Width = 84
        '
        'nuevoCostoAcabado
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N4"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.nuevoCostoAcabado.DefaultCellStyle = DataGridViewCellStyle13
        Me.nuevoCostoAcabado.HeaderText = "Nuevo costo"
        Me.nuevoCostoAcabado.Name = "nuevoCostoAcabado"
        Me.nuevoCostoAcabado.Width = 86
        '
        'idCostoKiloAluminio
        '
        Me.idCostoKiloAluminio.HeaderText = "ID"
        Me.idCostoKiloAluminio.Name = "idCostoKiloAluminio"
        Me.idCostoKiloAluminio.Visible = False
        Me.idCostoKiloAluminio.Width = 24
        '
        'fechacKiloAluminio
        '
        Me.fechacKiloAluminio.HeaderText = "Fecha creación"
        Me.fechacKiloAluminio.Name = "fechacKiloAluminio"
        Me.fechacKiloAluminio.Visible = False
        Me.fechacKiloAluminio.Width = 87
        '
        'usuariocKiloAluminio
        '
        Me.usuariocKiloAluminio.HeaderText = "Usuario creación"
        Me.usuariocKiloAluminio.Name = "usuariocKiloAluminio"
        Me.usuariocKiloAluminio.Visible = False
        Me.usuariocKiloAluminio.Width = 93
        '
        'descripcion
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro
        Me.descripcion.DefaultCellStyle = DataGridViewCellStyle14
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'idKiloAluminio
        '
        Me.idKiloAluminio.HeaderText = "Id Kilo aluminio"
        Me.idKiloAluminio.Name = "idKiloAluminio"
        Me.idKiloAluminio.Visible = False
        Me.idKiloAluminio.Width = 102
        '
        'versionActKiloAluminio
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle15.Format = "C0"
        Me.versionActKiloAluminio.DefaultCellStyle = DataGridViewCellStyle15
        Me.versionActKiloAluminio.HeaderText = "Versión actual"
        Me.versionActKiloAluminio.Name = "versionActKiloAluminio"
        Me.versionActKiloAluminio.ReadOnly = True
        Me.versionActKiloAluminio.Width = 99
        '
        'proxVersionKiloAluminio
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle16.Format = "C0"
        Me.proxVersionKiloAluminio.DefaultCellStyle = DataGridViewCellStyle16
        Me.proxVersionKiloAluminio.HeaderText = "Próxima versión"
        Me.proxVersionKiloAluminio.Name = "proxVersionKiloAluminio"
        Me.proxVersionKiloAluminio.ReadOnly = True
        Me.proxVersionKiloAluminio.Width = 97
        '
        'costoActKiloAluminio
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle17.Format = "C0"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.costoActKiloAluminio.DefaultCellStyle = DataGridViewCellStyle17
        Me.costoActKiloAluminio.HeaderText = "Costo actual"
        Me.costoActKiloAluminio.Name = "costoActKiloAluminio"
        Me.costoActKiloAluminio.ReadOnly = True
        Me.costoActKiloAluminio.Width = 84
        '
        'nuevoCostoKiloAluminio
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = Nothing
        Me.nuevoCostoKiloAluminio.DefaultCellStyle = DataGridViewCellStyle18
        Me.nuevoCostoKiloAluminio.HeaderText = "Nuevo costo"
        Me.nuevoCostoKiloAluminio.Name = "nuevoCostoKiloAluminio"
        Me.nuevoCostoKiloAluminio.Width = 86
        '
        'FrmCostoAluminio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1247, 536)
        Me.Controls.Add(Me.gbVersionBase)
        Me.Controls.Add(Me.gbRecalcular)
        Me.Controls.Add(Me.gbCostoAluminio)
        Me.Controls.Add(Me.gbCostoAcabado)
        Me.Controls.Add(Me.gbNiveles)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Name = "FrmCostoAluminio"
        Me.ShowIcon = False
        Me.Text = "Costos aluminio"
        CType(Me.dwCostoNivel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNiveles.ResumeLayout(False)
        Me.gbNiveles.PerformLayout()
        Me.gbCostoAcabado.ResumeLayout(False)
        Me.gbCostoAcabado.PerformLayout()
        CType(Me.dwCostoAcabado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCostoAluminio.ResumeLayout(False)
        Me.gbCostoAluminio.PerformLayout()
        CType(Me.dwCostoKiloAluminio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentCN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentCA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentCK, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRecalcular.ResumeLayout(False)
        Me.gbRecalcular.PerformLayout()
        Me.gbVersionBase.ResumeLayout(False)
        Me.gbVersionBase.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dwCostoNivel As DataGridView
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents gbNiveles As GroupBox
    Friend WithEvents gbCostoAcabado As GroupBox
    Friend WithEvents gbCostoAluminio As GroupBox
    Friend WithEvents dwCostoAcabado As DataGridView
    Friend WithEvents dwCostoKiloAluminio As DataGridView
    Friend WithEvents cbRecalcularNivel As CheckBox
    Friend WithEvents cbRecalcularAcabado As CheckBox
    Friend WithEvents cbRecalcularAluminio As CheckBox
    Friend WithEvents nudPorcentCN As NumericUpDown
    Friend WithEvents lblCNiveles As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents nudPorcentCA As NumericUpDown
    Friend WithEvents lblCAcabados As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents nudPorcentCK As NumericUpDown
    Friend WithEvents lblCKAlumn As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents gbRecalcular As GroupBox
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents gbVersionBase As GroupBox
    Friend WithEvents btnCambiarVersionBase As Button
    Friend WithEvents lblCKAlumn2 As Label
    Friend WithEvents lblCAcabados2 As Label
    Friend WithEvents cmbVersCostoKiloAlum As ComboBox
    Friend WithEvents lblCNiveles2 As Label
    Friend WithEvents cmbVersCostoNiveles As ComboBox
    Friend WithEvents cmbVersCostoAcabados As ComboBox
    Friend WithEvents idCostoNivel As DataGridViewTextBoxColumn
    Friend WithEvents fechacNivel As DataGridViewTextBoxColumn
    Friend WithEvents usuariocNivel As DataGridViewTextBoxColumn
    Friend WithEvents idNivel As DataGridViewTextBoxColumn
    Friend WithEvents nivel As DataGridViewTextBoxColumn
    Friend WithEvents versionActNivel As DataGridViewTextBoxColumn
    Friend WithEvents proxVersionNivel As DataGridViewTextBoxColumn
    Friend WithEvents costoActNivel As DataGridViewTextBoxColumn
    Friend WithEvents nuevoCostoNivel As DataGridViewTextBoxColumn
    Friend WithEvents motivoCreacion As DataGridViewTextBoxColumn
    Friend WithEvents idCostoAcabado As DataGridViewTextBoxColumn
    Friend WithEvents fechacAcabado As DataGridViewTextBoxColumn
    Friend WithEvents usuariocAcabado As DataGridViewTextBoxColumn
    Friend WithEvents idAcabado As DataGridViewTextBoxColumn
    Friend WithEvents acabado As DataGridViewTextBoxColumn
    Friend WithEvents fMaterialCostoAcabado As DataGridViewTextBoxColumn
    Friend WithEvents versionActAcabado As DataGridViewTextBoxColumn
    Friend WithEvents proxVersionAcabado As DataGridViewTextBoxColumn
    Friend WithEvents costoActAcabado As DataGridViewTextBoxColumn
    Friend WithEvents nuevoCostoAcabado As DataGridViewTextBoxColumn
    Friend WithEvents idCostoKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents fechacKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents usuariocKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents idKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents versionActKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents proxVersionKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents costoActKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents nuevoCostoKiloAluminio As DataGridViewTextBoxColumn
End Class
