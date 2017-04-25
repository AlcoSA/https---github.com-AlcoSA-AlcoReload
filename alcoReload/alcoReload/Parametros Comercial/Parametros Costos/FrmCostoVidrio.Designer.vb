<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCostoVidrio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCostoVidrio))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cmbColor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbVidrio = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbEspesor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCargarCostos = New System.Windows.Forms.Button()
        Me.btnRecalcular = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.col_idVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idEspesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_versionActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nuevaVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bwcargas
        '
        Me.bwcargas.WorkerReportsProgress = True
        Me.bwcargas.WorkerSupportsCancellation = True
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTextBoxColumn1.HeaderText = "Fecha creación"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 97
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Usuario creación"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 103
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "idArticulo"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn4.HeaderText = "Artículo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 69
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn5.HeaderText = "idEspesor"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 78
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn6.HeaderText = "Espesor"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn7.HeaderText = "idAcabado"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 83
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn8.HeaderText = "Acabado"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 75
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn9.HeaderText = "Versión actual"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 91
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn10.HeaderText = "Nueva versión"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 93
        '
        'DataGridViewTextBoxColumn11
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn11.HeaderText = "Costo actual"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 84
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn12.HeaderText = "Nuevo costo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 86
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "id"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 40
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "usuarioModificación"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 126
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "fechaModificación"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 119
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "idEstado"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 73
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.HeaderText = "estado"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.ReadOnly = True
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 64
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idVidrio, Me.col_vidrio, Me.col_idColor, Me.col_color, Me.col_idEspesor, Me.col_espesor, Me.col_versionActual, Me.col_nuevaVersion, Me.col_costo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(12, 77)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(810, 268)
        Me.dwItems.TabIndex = 24
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(421, 37)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cmbColor
        '
        Me.cmbColor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbColor.DropDownHeight = 200
        Me.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColor.DropDownWidth = 300
        Me.cmbColor.IntegralHeight = False
        Me.cmbColor.Location = New System.Drawing.Point(156, 37)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(105, 21)
        Me.cmbColor.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(296, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 22
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
        Me.cmbVidrio.Location = New System.Drawing.Point(21, 37)
        Me.cmbVidrio.Name = "cmbVidrio"
        Me.cmbVidrio.Size = New System.Drawing.Size(105, 21)
        Me.cmbVidrio.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 21
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
        Me.cmbEspesor.Location = New System.Drawing.Point(299, 37)
        Me.cmbEspesor.Name = "cmbEspesor"
        Me.cmbEspesor.Size = New System.Drawing.Size(105, 21)
        Me.cmbEspesor.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Vidrio"
        '
        'btnCargarCostos
        '
        Me.btnCargarCostos.Location = New System.Drawing.Point(502, 37)
        Me.btnCargarCostos.Name = "btnCargarCostos"
        Me.btnCargarCostos.Size = New System.Drawing.Size(104, 23)
        Me.btnCargarCostos.TabIndex = 25
        Me.btnCargarCostos.Text = "Cargar existentes"
        Me.btnCargarCostos.UseVisualStyleBackColor = True
        '
        'btnRecalcular
        '
        Me.btnRecalcular.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRecalcular.Enabled = False
        Me.btnRecalcular.Image = CType(resources.GetObject("btnRecalcular.Image"), System.Drawing.Image)
        Me.btnRecalcular.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRecalcular.Location = New System.Drawing.Point(692, 351)
        Me.btnRecalcular.Name = "btnRecalcular"
        Me.btnRecalcular.Size = New System.Drawing.Size(130, 59)
        Me.btnRecalcular.TabIndex = 26
        Me.btnRecalcular.Text = "Recalcular costo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "vidrio"
        Me.btnRecalcular.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRecalcular.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'col_idVidrio
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idVidrio.DefaultCellStyle = DataGridViewCellStyle13
        Me.col_idVidrio.HeaderText = "Id vidrio"
        Me.col_idVidrio.Name = "col_idVidrio"
        Me.col_idVidrio.ReadOnly = True
        Me.col_idVidrio.Visible = False
        Me.col_idVidrio.Width = 50
        '
        'col_vidrio
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro
        Me.col_vidrio.DefaultCellStyle = DataGridViewCellStyle14
        Me.col_vidrio.HeaderText = "Vidrio"
        Me.col_vidrio.Name = "col_vidrio"
        Me.col_vidrio.ReadOnly = True
        Me.col_vidrio.Width = 58
        '
        'col_idColor
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idColor.DefaultCellStyle = DataGridViewCellStyle15
        Me.col_idColor.HeaderText = "Id color"
        Me.col_idColor.Name = "col_idColor"
        Me.col_idColor.ReadOnly = True
        Me.col_idColor.Visible = False
        Me.col_idColor.Width = 67
        '
        'col_color
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro
        Me.col_color.DefaultCellStyle = DataGridViewCellStyle16
        Me.col_color.HeaderText = "Color"
        Me.col_color.Name = "col_color"
        Me.col_color.ReadOnly = True
        Me.col_color.Width = 56
        '
        'col_idEspesor
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idEspesor.DefaultCellStyle = DataGridViewCellStyle17
        Me.col_idEspesor.HeaderText = "Id espesor"
        Me.col_idEspesor.Name = "col_idEspesor"
        Me.col_idEspesor.ReadOnly = True
        Me.col_idEspesor.Visible = False
        Me.col_idEspesor.Width = 81
        '
        'col_espesor
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Gainsboro
        Me.col_espesor.DefaultCellStyle = DataGridViewCellStyle18
        Me.col_espesor.HeaderText = "Espesor"
        Me.col_espesor.Name = "col_espesor"
        Me.col_espesor.ReadOnly = True
        Me.col_espesor.Width = 70
        '
        'col_versionActual
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle19.Format = "N0"
        Me.col_versionActual.DefaultCellStyle = DataGridViewCellStyle19
        Me.col_versionActual.HeaderText = "Versión actual"
        Me.col_versionActual.Name = "col_versionActual"
        Me.col_versionActual.ReadOnly = True
        Me.col_versionActual.Width = 99
        '
        'col_nuevaVersion
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle20.Format = "N0"
        Me.col_nuevaVersion.DefaultCellStyle = DataGridViewCellStyle20
        Me.col_nuevaVersion.HeaderText = "Nueva versión"
        Me.col_nuevaVersion.Name = "col_nuevaVersion"
        Me.col_nuevaVersion.ReadOnly = True
        Me.col_nuevaVersion.Width = 101
        '
        'col_costo
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N0"
        Me.col_costo.DefaultCellStyle = DataGridViewCellStyle21
        Me.col_costo.HeaderText = "Costo"
        Me.col_costo.Name = "col_costo"
        Me.col_costo.Width = 59
        '
        'FrmCostoVidrio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 422)
        Me.Controls.Add(Me.btnRecalcular)
        Me.Controls.Add(Me.btnCargarCostos)
        Me.Controls.Add(Me.dwItems)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbVidrio)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbEspesor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmCostoVidrio"
        Me.ShowIcon = False
        Me.Text = "Costo vidrio"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents btnAgregar As Button
    Friend WithEvents cmbColor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbVidrio As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbEspesor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCargarCostos As Button
    Friend WithEvents btnRecalcular As Button
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents col_idVidrio As DataGridViewTextBoxColumn
    Friend WithEvents col_vidrio As DataGridViewTextBoxColumn
    Friend WithEvents col_idColor As DataGridViewTextBoxColumn
    Friend WithEvents col_color As DataGridViewTextBoxColumn
    Friend WithEvents col_idEspesor As DataGridViewTextBoxColumn
    Friend WithEvents col_espesor As DataGridViewTextBoxColumn
    Friend WithEvents col_versionActual As DataGridViewTextBoxColumn
    Friend WithEvents col_nuevaVersion As DataGridViewTextBoxColumn
    Friend WithEvents col_costo As DataGridViewTextBoxColumn
End Class
