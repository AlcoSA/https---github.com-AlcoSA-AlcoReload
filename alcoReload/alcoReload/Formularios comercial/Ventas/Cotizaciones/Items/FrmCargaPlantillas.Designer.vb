<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCargaPlantillas
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
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorminimo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valormaximo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.itPlantillas = New ControlesPersonalizados.Intellisens.intellises()
        Me.itFamilia = New ControlesPersonalizados.Intellisens.intellises()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nudfactor = New System.Windows.Forms.NumericUpDown()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudfactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.variable, Me.valor, Me.valorminimo, Me.valormaximo, Me.tipodato})
        Me.dwitems.Location = New System.Drawing.Point(15, 104)
        Me.dwitems.Name = "dwitems"
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.Size = New System.Drawing.Size(390, 290)
        Me.dwitems.TabIndex = 3
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'variable
        '
        Me.variable.HeaderText = "Variable"
        Me.variable.Name = "variable"
        Me.variable.ReadOnly = True
        Me.variable.Width = 70
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.Name = "valor"
        Me.valor.Width = 56
        '
        'valorminimo
        '
        Me.valorminimo.HeaderText = "Valor Minimo"
        Me.valorminimo.Name = "valorminimo"
        Me.valorminimo.ReadOnly = True
        Me.valorminimo.Width = 92
        '
        'valormaximo
        '
        Me.valormaximo.HeaderText = "Valor Maximo"
        Me.valormaximo.Name = "valormaximo"
        Me.valormaximo.ReadOnly = True
        Me.valormaximo.Width = 95
        '
        'tipodato
        '
        Me.tipodato.HeaderText = "Tipo Dato"
        Me.tipodato.Name = "tipodato"
        Me.tipodato.ReadOnly = True
        Me.tipodato.Visible = False
        Me.tipodato.Width = 79
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Diseño"
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(249, 403)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(330, 403)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Familia"
        '
        'itPlantillas
        '
        Me.itPlantillas.AlternativeColumn = "Familia_Modelo"
        Me.itPlantillas.ColToReturn = "Nombre_Modelo"
        Me.itPlantillas.ColumnsToFilter = New String() {"Nombre_Modelo", "Descripcion"}
        Me.itPlantillas.ColumnsToShow = New String() {"Nombre_Modelo", "Descripcion"}
        Me.itPlantillas.Dropdown_Width = 250
        Me.itPlantillas.Id_Column_Name = "Id"
        Me.itPlantillas.Location = New System.Drawing.Point(16, 70)
        Me.itPlantillas.Maximo_Items_DropDown = 5
        Me.itPlantillas.Name = "itPlantillas"
        Me.itPlantillas.selected_item = Nothing
        Me.itPlantillas.Seleted_rowid = Nothing
        Me.itPlantillas.Size = New System.Drawing.Size(200, 20)
        Me.itPlantillas.TabIndex = 25
        Me.itPlantillas.TablaFuente = Nothing
        Me.itPlantillas.Value2 = ""
        '
        'itFamilia
        '
        Me.itFamilia.AlternativeColumn = Nothing
        Me.itFamilia.ColToReturn = "Familia"
        Me.itFamilia.ColumnsToFilter = New String() {"Familia", "Prefijo"}
        Me.itFamilia.ColumnsToShow = New String() {"Familia", "Prefijo"}
        Me.itFamilia.Dropdown_Width = 250
        Me.itFamilia.Id_Column_Name = "Id"
        Me.itFamilia.Location = New System.Drawing.Point(15, 30)
        Me.itFamilia.Maximo_Items_DropDown = 5
        Me.itFamilia.Name = "itFamilia"
        Me.itFamilia.selected_item = Nothing
        Me.itFamilia.Seleted_rowid = Nothing
        Me.itFamilia.Size = New System.Drawing.Size(200, 20)
        Me.itFamilia.TabIndex = 24
        Me.itFamilia.TablaFuente = Nothing
        Me.itFamilia.Value2 = Nothing
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(294, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Factor"
        '
        'nudfactor
        '
        Me.nudfactor.DecimalPlaces = 2
        Me.nudfactor.Location = New System.Drawing.Point(297, 70)
        Me.nudfactor.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudfactor.Name = "nudfactor"
        Me.nudfactor.Size = New System.Drawing.Size(108, 20)
        Me.nudfactor.TabIndex = 27
        Me.nudfactor.ThousandsSeparator = True
        '
        'FrmCargaPlantillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 441)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nudfactor)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.itPlantillas)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.itFamilia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dwitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCargaPlantillas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudfactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dwitems As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents variable As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents valorminimo As DataGridViewTextBoxColumn
    Friend WithEvents valormaximo As DataGridViewTextBoxColumn
    Friend WithEvents tipodato As DataGridViewTextBoxColumn
    Friend WithEvents btnaceptar As Button
    Friend WithEvents btncancelar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents itFamilia As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents itPlantillas As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents Label8 As Label
    Friend WithEvents nudfactor As NumericUpDown
End Class
