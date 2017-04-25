<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerTemporales
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
        Me.gbArticulos = New System.Windows.Forms.GroupBox()
        Me.dwArticulos = New System.Windows.Forms.DataGridView()
        Me.art_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.art_Referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.art_Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.art_idFamilia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.art_familia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.art_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbColores = New System.Windows.Forms.GroupBox()
        Me.dwColores = New System.Windows.Forms.DataGridView()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbEspesores = New System.Windows.Forms.GroupBox()
        Me.dwEspesores = New System.Windows.Forms.DataGridView()
        Me.esp_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.esp_prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.esp_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dwCostoVidrio = New System.Windows.Forms.DataGridView()
        Me.cv_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_vidrioTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cv_idVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_colorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cv_idColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_espesorTemporal = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cv_idEspesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cv_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbArticulos.SuspendLayout()
        CType(Me.dwArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbColores.SuspendLayout()
        CType(Me.dwColores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbEspesores.SuspendLayout()
        CType(Me.dwEspesores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dwCostoVidrio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbArticulos
        '
        Me.gbArticulos.Controls.Add(Me.dwArticulos)
        Me.gbArticulos.Location = New System.Drawing.Point(12, 12)
        Me.gbArticulos.Name = "gbArticulos"
        Me.gbArticulos.Size = New System.Drawing.Size(397, 335)
        Me.gbArticulos.TabIndex = 0
        Me.gbArticulos.TabStop = False
        Me.gbArticulos.Text = "Artículos"
        '
        'dwArticulos
        '
        Me.dwArticulos.AllowUserToAddRows = False
        Me.dwArticulos.AllowUserToDeleteRows = False
        Me.dwArticulos.AllowUserToResizeRows = False
        Me.dwArticulos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwArticulos.BackgroundColor = System.Drawing.Color.White
        Me.dwArticulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.art_id, Me.art_Referencia, Me.art_Descripcion, Me.art_idFamilia, Me.art_familia, Me.art_costo})
        Me.dwArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwArticulos.Location = New System.Drawing.Point(6, 19)
        Me.dwArticulos.MultiSelect = False
        Me.dwArticulos.Name = "dwArticulos"
        Me.dwArticulos.ReadOnly = True
        Me.dwArticulos.RowHeadersVisible = False
        Me.dwArticulos.Size = New System.Drawing.Size(385, 310)
        Me.dwArticulos.TabIndex = 0
        Me.dwArticulos.Tag = "1"
        '
        'art_id
        '
        Me.art_id.HeaderText = "Id"
        Me.art_id.Name = "art_id"
        Me.art_id.ReadOnly = True
        Me.art_id.Visible = False
        Me.art_id.Width = 22
        '
        'art_Referencia
        '
        Me.art_Referencia.HeaderText = "Referencia"
        Me.art_Referencia.Name = "art_Referencia"
        Me.art_Referencia.ReadOnly = True
        Me.art_Referencia.Width = 84
        '
        'art_Descripcion
        '
        Me.art_Descripcion.HeaderText = "Descripción"
        Me.art_Descripcion.Name = "art_Descripcion"
        Me.art_Descripcion.ReadOnly = True
        Me.art_Descripcion.Width = 88
        '
        'art_idFamilia
        '
        Me.art_idFamilia.HeaderText = "Id familia"
        Me.art_idFamilia.Name = "art_idFamilia"
        Me.art_idFamilia.ReadOnly = True
        Me.art_idFamilia.Visible = False
        Me.art_idFamilia.Width = 73
        '
        'art_familia
        '
        Me.art_familia.HeaderText = "Familia material"
        Me.art_familia.Name = "art_familia"
        Me.art_familia.ReadOnly = True
        Me.art_familia.Width = 95
        '
        'art_costo
        '
        Me.art_costo.HeaderText = "Costo"
        Me.art_costo.Name = "art_costo"
        Me.art_costo.ReadOnly = True
        Me.art_costo.Width = 59
        '
        'gbColores
        '
        Me.gbColores.Controls.Add(Me.dwColores)
        Me.gbColores.Location = New System.Drawing.Point(415, 12)
        Me.gbColores.Name = "gbColores"
        Me.gbColores.Size = New System.Drawing.Size(197, 335)
        Me.gbColores.TabIndex = 1
        Me.gbColores.TabStop = False
        Me.gbColores.Text = "Colores de vidrio"
        '
        'dwColores
        '
        Me.dwColores.AllowUserToAddRows = False
        Me.dwColores.AllowUserToDeleteRows = False
        Me.dwColores.AllowUserToResizeRows = False
        Me.dwColores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwColores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwColores.BackgroundColor = System.Drawing.Color.White
        Me.dwColores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwColores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwColores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_prefijo, Me.col_nombre})
        Me.dwColores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwColores.Location = New System.Drawing.Point(6, 19)
        Me.dwColores.MultiSelect = False
        Me.dwColores.Name = "dwColores"
        Me.dwColores.ReadOnly = True
        Me.dwColores.RowHeadersVisible = False
        Me.dwColores.Size = New System.Drawing.Size(185, 310)
        Me.dwColores.TabIndex = 1
        Me.dwColores.Tag = "2"
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Visible = False
        Me.col_id.Width = 22
        '
        'col_prefijo
        '
        Me.col_prefijo.HeaderText = "Prefijo"
        Me.col_prefijo.Name = "col_prefijo"
        Me.col_prefijo.ReadOnly = True
        Me.col_prefijo.Width = 61
        '
        'col_nombre
        '
        Me.col_nombre.HeaderText = "Nombre"
        Me.col_nombre.Name = "col_nombre"
        Me.col_nombre.ReadOnly = True
        Me.col_nombre.Width = 69
        '
        'gbEspesores
        '
        Me.gbEspesores.Controls.Add(Me.dwEspesores)
        Me.gbEspesores.Location = New System.Drawing.Point(618, 12)
        Me.gbEspesores.Name = "gbEspesores"
        Me.gbEspesores.Size = New System.Drawing.Size(197, 335)
        Me.gbEspesores.TabIndex = 2
        Me.gbEspesores.TabStop = False
        Me.gbEspesores.Text = "Espesores"
        '
        'dwEspesores
        '
        Me.dwEspesores.AllowUserToAddRows = False
        Me.dwEspesores.AllowUserToDeleteRows = False
        Me.dwEspesores.AllowUserToResizeRows = False
        Me.dwEspesores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwEspesores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwEspesores.BackgroundColor = System.Drawing.Color.White
        Me.dwEspesores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwEspesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwEspesores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.esp_id, Me.esp_prefijo, Me.esp_descripcion})
        Me.dwEspesores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwEspesores.Location = New System.Drawing.Point(6, 19)
        Me.dwEspesores.MultiSelect = False
        Me.dwEspesores.Name = "dwEspesores"
        Me.dwEspesores.ReadOnly = True
        Me.dwEspesores.RowHeadersVisible = False
        Me.dwEspesores.Size = New System.Drawing.Size(185, 310)
        Me.dwEspesores.TabIndex = 2
        Me.dwEspesores.Tag = "3"
        '
        'esp_id
        '
        Me.esp_id.HeaderText = "Id"
        Me.esp_id.Name = "esp_id"
        Me.esp_id.ReadOnly = True
        Me.esp_id.Visible = False
        Me.esp_id.Width = 22
        '
        'esp_prefijo
        '
        Me.esp_prefijo.HeaderText = "Prefijo"
        Me.esp_prefijo.Name = "esp_prefijo"
        Me.esp_prefijo.ReadOnly = True
        Me.esp_prefijo.Width = 61
        '
        'esp_descripcion
        '
        Me.esp_descripcion.HeaderText = "Descripcion"
        Me.esp_descripcion.Name = "esp_descripcion"
        Me.esp_descripcion.ReadOnly = True
        Me.esp_descripcion.Width = 88
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dwCostoVidrio)
        Me.GroupBox1.Location = New System.Drawing.Point(821, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 335)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Costos vidrio"
        '
        'dwCostoVidrio
        '
        Me.dwCostoVidrio.AllowUserToAddRows = False
        Me.dwCostoVidrio.AllowUserToDeleteRows = False
        Me.dwCostoVidrio.AllowUserToResizeRows = False
        Me.dwCostoVidrio.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwCostoVidrio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwCostoVidrio.BackgroundColor = System.Drawing.Color.White
        Me.dwCostoVidrio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCostoVidrio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwCostoVidrio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cv_id, Me.cv_vidrioTemporal, Me.cv_idVidrio, Me.cv_vidrio, Me.cv_colorTemporal, Me.cv_idColor, Me.cv_color, Me.cv_espesorTemporal, Me.cv_idEspesor, Me.cv_espesor, Me.cv_costo})
        Me.dwCostoVidrio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwCostoVidrio.Location = New System.Drawing.Point(6, 19)
        Me.dwCostoVidrio.MultiSelect = False
        Me.dwCostoVidrio.Name = "dwCostoVidrio"
        Me.dwCostoVidrio.ReadOnly = True
        Me.dwCostoVidrio.RowHeadersVisible = False
        Me.dwCostoVidrio.Size = New System.Drawing.Size(295, 310)
        Me.dwCostoVidrio.TabIndex = 2
        Me.dwCostoVidrio.Tag = "4"
        '
        'cv_id
        '
        Me.cv_id.HeaderText = "Id"
        Me.cv_id.Name = "cv_id"
        Me.cv_id.ReadOnly = True
        Me.cv_id.Visible = False
        Me.cv_id.Width = 22
        '
        'cv_vidrioTemporal
        '
        Me.cv_vidrioTemporal.HeaderText = "Vidrio temporal"
        Me.cv_vidrioTemporal.Name = "cv_vidrioTemporal"
        Me.cv_vidrioTemporal.ReadOnly = True
        Me.cv_vidrioTemporal.Visible = False
        Me.cv_vidrioTemporal.Width = 82
        '
        'cv_idVidrio
        '
        Me.cv_idVidrio.HeaderText = "Id Vidrio"
        Me.cv_idVidrio.Name = "cv_idVidrio"
        Me.cv_idVidrio.ReadOnly = True
        Me.cv_idVidrio.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cv_idVidrio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cv_idVidrio.Visible = False
        Me.cv_idVidrio.Width = 51
        '
        'cv_vidrio
        '
        Me.cv_vidrio.HeaderText = "Vidrio"
        Me.cv_vidrio.Name = "cv_vidrio"
        Me.cv_vidrio.ReadOnly = True
        Me.cv_vidrio.Width = 58
        '
        'cv_colorTemporal
        '
        Me.cv_colorTemporal.HeaderText = "Color temporal"
        Me.cv_colorTemporal.Name = "cv_colorTemporal"
        Me.cv_colorTemporal.ReadOnly = True
        Me.cv_colorTemporal.Visible = False
        Me.cv_colorTemporal.Width = 80
        '
        'cv_idColor
        '
        Me.cv_idColor.HeaderText = "Id Color"
        Me.cv_idColor.Name = "cv_idColor"
        Me.cv_idColor.ReadOnly = True
        Me.cv_idColor.Visible = False
        Me.cv_idColor.Width = 68
        '
        'cv_color
        '
        Me.cv_color.HeaderText = "Color"
        Me.cv_color.Name = "cv_color"
        Me.cv_color.ReadOnly = True
        Me.cv_color.Width = 56
        '
        'cv_espesorTemporal
        '
        Me.cv_espesorTemporal.HeaderText = "Espesor temporal"
        Me.cv_espesorTemporal.Name = "cv_espesorTemporal"
        Me.cv_espesorTemporal.ReadOnly = True
        Me.cv_espesorTemporal.Visible = False
        Me.cv_espesorTemporal.Width = 94
        '
        'cv_idEspesor
        '
        Me.cv_idEspesor.HeaderText = "Id Espesor"
        Me.cv_idEspesor.Name = "cv_idEspesor"
        Me.cv_idEspesor.ReadOnly = True
        Me.cv_idEspesor.Visible = False
        Me.cv_idEspesor.Width = 82
        '
        'cv_espesor
        '
        Me.cv_espesor.HeaderText = "Espesor"
        Me.cv_espesor.Name = "cv_espesor"
        Me.cv_espesor.ReadOnly = True
        Me.cv_espesor.Width = 70
        '
        'cv_costo
        '
        Me.cv_costo.HeaderText = "Costo"
        Me.cv_costo.Name = "cv_costo"
        Me.cv_costo.ReadOnly = True
        Me.cv_costo.Width = 59
        '
        'FrmVerTemporales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbEspesores)
        Me.Controls.Add(Me.gbColores)
        Me.Controls.Add(Me.gbArticulos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVerTemporales"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de temporales cotización "
        Me.gbArticulos.ResumeLayout(False)
        CType(Me.dwArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbColores.ResumeLayout(False)
        CType(Me.dwColores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbEspesores.ResumeLayout(False)
        CType(Me.dwEspesores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dwCostoVidrio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbArticulos As GroupBox
    Friend WithEvents gbColores As GroupBox
    Friend WithEvents gbEspesores As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dwArticulos As DataGridView
    Friend WithEvents dwColores As DataGridView
    Friend WithEvents dwEspesores As DataGridView
    Friend WithEvents dwCostoVidrio As DataGridView
    Friend WithEvents art_id As DataGridViewTextBoxColumn
    Friend WithEvents art_Referencia As DataGridViewTextBoxColumn
    Friend WithEvents art_Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents art_idFamilia As DataGridViewTextBoxColumn
    Friend WithEvents art_familia As DataGridViewTextBoxColumn
    Friend WithEvents art_costo As DataGridViewTextBoxColumn
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_prefijo As DataGridViewTextBoxColumn
    Friend WithEvents col_nombre As DataGridViewTextBoxColumn
    Friend WithEvents esp_id As DataGridViewTextBoxColumn
    Friend WithEvents esp_prefijo As DataGridViewTextBoxColumn
    Friend WithEvents esp_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents cv_id As DataGridViewTextBoxColumn
    Friend WithEvents cv_vidrioTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents cv_idVidrio As DataGridViewTextBoxColumn
    Friend WithEvents cv_vidrio As DataGridViewTextBoxColumn
    Friend WithEvents cv_colorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents cv_idColor As DataGridViewTextBoxColumn
    Friend WithEvents cv_color As DataGridViewTextBoxColumn
    Friend WithEvents cv_espesorTemporal As DataGridViewCheckBoxColumn
    Friend WithEvents cv_idEspesor As DataGridViewTextBoxColumn
    Friend WithEvents cv_espesor As DataGridViewTextBoxColumn
    Friend WithEvents cv_costo As DataGridViewTextBoxColumn
End Class
