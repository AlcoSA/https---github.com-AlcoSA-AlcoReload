<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModificacionVariables
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valorminimo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valormaximo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(194, 301)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(164, 31)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(85, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
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
        Me.dwitems.Location = New System.Drawing.Point(12, 12)
        Me.dwitems.Name = "dwitems"
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.Size = New System.Drawing.Size(342, 283)
        Me.dwitems.TabIndex = 5
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
        'FrmModificacionVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 344)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.dwitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmModificacionVariables"
        Me.ShowIcon = False
        Me.Text = "Modificación Variables"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents dwitems As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents variable As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents valorminimo As DataGridViewTextBoxColumn
    Friend WithEvents valormaximo As DataGridViewTextBoxColumn
    Friend WithEvents tipodato As DataGridViewTextBoxColumn
End Class
