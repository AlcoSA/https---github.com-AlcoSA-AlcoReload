<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPruebasColumnasGrid
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
        Me.dwcolumnas = New EspecialColumns.Grid_MRP.DatagridviewMRP()
        Me.columnafecha = New DateTimeGridColumn()
        Me.columnaformula = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        CType(Me.dwcolumnas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dwcolumnas
        '
        Me.dwcolumnas.BackgroundColor = System.Drawing.Color.White
        Me.dwcolumnas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwcolumnas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwcolumnas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnafecha, Me.columnaformula})
        Me.dwcolumnas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwcolumnas.Location = New System.Drawing.Point(0, 0)
        Me.dwcolumnas.Name = "dwcolumnas"
        Me.dwcolumnas.Size = New System.Drawing.Size(284, 261)
        Me.dwcolumnas.TabIndex = 0
        '
        'columnafecha
        '
        Me.columnafecha.HeaderText = "Fecha"
        Me.columnafecha.Name = "columnafecha"
        '
        'columnaformula
        '
        Me.columnaformula.HeaderText = "Formula"
        Me.columnaformula.Name = "columnaformula"
        '
        'FrmPruebasColumnasGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.dwcolumnas)
        Me.Name = "FrmPruebasColumnasGrid"
        Me.ShowIcon = False
        Me.Text = "Pruebas Columnas Grid"
        CType(Me.dwcolumnas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dwcolumnas As EspecialColumns.Grid_MRP.DatagridviewMRP
    Friend WithEvents columnafecha As DateTimeGridColumn
    Friend WithEvents columnaformula As EspecialColumns.Columna_Formula.FormuleGridColumn
End Class
