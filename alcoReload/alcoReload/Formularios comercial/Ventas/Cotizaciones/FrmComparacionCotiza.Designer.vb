<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComparacionCotiza
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
        Me.dwCotizaciones = New DatagridTreeView.DataTreeGridView()
        Me.gbCotizaciones = New System.Windows.Forms.GroupBox()
        Me.btnComparar = New System.Windows.Forms.Button()
        Me.gbComparacion = New System.Windows.Forms.GroupBox()
        Me.dwComparacion = New System.Windows.Forms.DataGridView()
        Me.comp_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comp_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cot_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.cot_seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cot_nombreCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cot_idHijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cot_ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cot_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cot_verCostoKiloAluminio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cot_verCostoVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwCotizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCotizaciones.SuspendLayout()
        Me.gbComparacion.SuspendLayout()
        CType(Me.dwComparacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwCotizaciones
        '
        Me.dwCotizaciones.AllowUserToAddRows = False
        Me.dwCotizaciones.AllowUserToDeleteRows = False
        Me.dwCotizaciones.AllowUserToResizeColumns = False
        Me.dwCotizaciones.AllowUserToResizeRows = False
        Me.dwCotizaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwCotizaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwCotizaciones.BackgroundColor = System.Drawing.Color.White
        Me.dwCotizaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwCotizaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cot_id, Me.cot_seleccion, Me.cot_nombreCotiza, Me.cot_idHijo, Me.cot_ubicacion, Me.cot_descripcion, Me.cot_verCostoKiloAluminio, Me.cot_verCostoVidrio})
        Me.dwCotizaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dwCotizaciones.ImageList = Nothing
        Me.dwCotizaciones.Location = New System.Drawing.Point(6, 19)
        Me.dwCotizaciones.MultiSelect = False
        Me.dwCotizaciones.Name = "dwCotizaciones"
        Me.dwCotizaciones.RowHeadersWidth = 20
        Me.dwCotizaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwCotizaciones.Size = New System.Drawing.Size(1015, 294)
        Me.dwCotizaciones.TabIndex = 2
        '
        'gbCotizaciones
        '
        Me.gbCotizaciones.Controls.Add(Me.dwCotizaciones)
        Me.gbCotizaciones.Controls.Add(Me.btnComparar)
        Me.gbCotizaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbCotizaciones.Location = New System.Drawing.Point(0, 0)
        Me.gbCotizaciones.Name = "gbCotizaciones"
        Me.gbCotizaciones.Size = New System.Drawing.Size(1027, 360)
        Me.gbCotizaciones.TabIndex = 3
        Me.gbCotizaciones.TabStop = False
        Me.gbCotizaciones.Text = "Cotizaciones"
        '
        'btnComparar
        '
        Me.btnComparar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnComparar.Location = New System.Drawing.Point(833, 319)
        Me.btnComparar.Name = "btnComparar"
        Me.btnComparar.Size = New System.Drawing.Size(188, 35)
        Me.btnComparar.TabIndex = 4
        Me.btnComparar.Text = "Comparar"
        Me.btnComparar.UseVisualStyleBackColor = True
        '
        'gbComparacion
        '
        Me.gbComparacion.Controls.Add(Me.dwComparacion)
        Me.gbComparacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbComparacion.Location = New System.Drawing.Point(0, 0)
        Me.gbComparacion.Name = "gbComparacion"
        Me.gbComparacion.Size = New System.Drawing.Size(1027, 234)
        Me.gbComparacion.TabIndex = 5
        Me.gbComparacion.TabStop = False
        Me.gbComparacion.Text = "Comparación"
        '
        'dwComparacion
        '
        Me.dwComparacion.AllowUserToAddRows = False
        Me.dwComparacion.AllowUserToDeleteRows = False
        Me.dwComparacion.AllowUserToResizeColumns = False
        Me.dwComparacion.AllowUserToResizeRows = False
        Me.dwComparacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwComparacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwComparacion.BackgroundColor = System.Drawing.Color.White
        Me.dwComparacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwComparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwComparacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comp_ubicacion, Me.comp_descripcion, Me.comp_vidrio, Me.comp_ancho, Me.comp_alto, Me.comp_cantidad})
        Me.dwComparacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwComparacion.Location = New System.Drawing.Point(6, 19)
        Me.dwComparacion.MultiSelect = False
        Me.dwComparacion.Name = "dwComparacion"
        Me.dwComparacion.ReadOnly = True
        Me.dwComparacion.RowHeadersVisible = False
        Me.dwComparacion.Size = New System.Drawing.Size(1015, 209)
        Me.dwComparacion.TabIndex = 0
        '
        'comp_ubicacion
        '
        Me.comp_ubicacion.HeaderText = "Ubicación"
        Me.comp_ubicacion.Name = "comp_ubicacion"
        Me.comp_ubicacion.ReadOnly = True
        Me.comp_ubicacion.Width = 80
        '
        'comp_descripcion
        '
        Me.comp_descripcion.HeaderText = "Descripción"
        Me.comp_descripcion.Name = "comp_descripcion"
        Me.comp_descripcion.ReadOnly = True
        Me.comp_descripcion.Width = 88
        '
        'comp_vidrio
        '
        Me.comp_vidrio.HeaderText = "Vidrio"
        Me.comp_vidrio.Name = "comp_vidrio"
        Me.comp_vidrio.ReadOnly = True
        Me.comp_vidrio.Width = 58
        '
        'comp_ancho
        '
        Me.comp_ancho.HeaderText = "Ancho"
        Me.comp_ancho.Name = "comp_ancho"
        Me.comp_ancho.ReadOnly = True
        Me.comp_ancho.Width = 63
        '
        'comp_alto
        '
        Me.comp_alto.HeaderText = "Alto"
        Me.comp_alto.Name = "comp_alto"
        Me.comp_alto.ReadOnly = True
        Me.comp_alto.Width = 50
        '
        'comp_cantidad
        '
        Me.comp_cantidad.HeaderText = "Cantidad"
        Me.comp_cantidad.Name = "comp_cantidad"
        Me.comp_cantidad.ReadOnly = True
        Me.comp_cantidad.Width = 74
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbCotizaciones)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gbComparacion)
        Me.SplitContainer1.Size = New System.Drawing.Size(1031, 606)
        Me.SplitContainer1.SplitterDistance = 364
        Me.SplitContainer1.TabIndex = 6
        '
        'cot_id
        '
        Me.cot_id.HeaderText = ""
        Me.cot_id.ImagenporDefecto = Nothing
        Me.cot_id.Name = "cot_id"
        Me.cot_id.ReadOnly = True
        Me.cot_id.Width = 19
        '
        'cot_seleccion
        '
        Me.cot_seleccion.HeaderText = "Selección"
        Me.cot_seleccion.Name = "cot_seleccion"
        Me.cot_seleccion.Width = 60
        '
        'cot_nombreCotiza
        '
        Me.cot_nombreCotiza.HeaderText = ""
        Me.cot_nombreCotiza.Name = "cot_nombreCotiza"
        Me.cot_nombreCotiza.ReadOnly = True
        Me.cot_nombreCotiza.Width = 19
        '
        'cot_idHijo
        '
        Me.cot_idHijo.HeaderText = "ID hijo"
        Me.cot_idHijo.Name = "cot_idHijo"
        Me.cot_idHijo.Visible = False
        Me.cot_idHijo.Width = 62
        '
        'cot_ubicacion
        '
        Me.cot_ubicacion.HeaderText = "Ubicación"
        Me.cot_ubicacion.Name = "cot_ubicacion"
        Me.cot_ubicacion.ReadOnly = True
        Me.cot_ubicacion.Width = 80
        '
        'cot_descripcion
        '
        Me.cot_descripcion.HeaderText = "Descripción"
        Me.cot_descripcion.Name = "cot_descripcion"
        Me.cot_descripcion.ReadOnly = True
        Me.cot_descripcion.Width = 88
        '
        'cot_verCostoKiloAluminio
        '
        Me.cot_verCostoKiloAluminio.HeaderText = "Version costo kilo aluminio"
        Me.cot_verCostoKiloAluminio.Name = "cot_verCostoKiloAluminio"
        Me.cot_verCostoKiloAluminio.ReadOnly = True
        Me.cot_verCostoKiloAluminio.Visible = False
        Me.cot_verCostoKiloAluminio.Width = 156
        '
        'cot_verCostoVidrio
        '
        Me.cot_verCostoVidrio.HeaderText = "Version costo vidrio"
        Me.cot_verCostoVidrio.Name = "cot_verCostoVidrio"
        Me.cot_verCostoVidrio.ReadOnly = True
        Me.cot_verCostoVidrio.Visible = False
        Me.cot_verCostoVidrio.Width = 124
        '
        'FrmComparacionCotiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 606)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmComparacionCotiza"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comparación"
        CType(Me.dwCotizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCotizaciones.ResumeLayout(False)
        Me.gbComparacion.ResumeLayout(False)
        CType(Me.dwComparacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dwCotizaciones As DatagridTreeView.DataTreeGridView
    Friend WithEvents gbCotizaciones As GroupBox
    Friend WithEvents btnComparar As Button
    Friend WithEvents gbComparacion As GroupBox
    Friend WithEvents dwComparacion As DataGridView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents comp_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents comp_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents comp_vidrio As DataGridViewTextBoxColumn
    Friend WithEvents comp_ancho As DataGridViewTextBoxColumn
    Friend WithEvents comp_alto As DataGridViewTextBoxColumn
    Friend WithEvents comp_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents cot_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents cot_seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents cot_nombreCotiza As DataGridViewTextBoxColumn
    Friend WithEvents cot_idHijo As DataGridViewTextBoxColumn
    Friend WithEvents cot_ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents cot_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents cot_verCostoKiloAluminio As DataGridViewTextBoxColumn
    Friend WithEvents cot_verCostoVidrio As DataGridViewTextBoxColumn
End Class
