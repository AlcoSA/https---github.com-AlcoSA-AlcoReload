<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmspellCheck
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
        Me.txttexto = New System.Windows.Forms.RichTextBox()
        Me.lbsugerencias = New System.Windows.Forms.ListBox()
        Me.txtreemplazo = New System.Windows.Forms.TextBox()
        Me.btnignorar = New System.Windows.Forms.Button()
        Me.btnignorartodo = New System.Windows.Forms.Button()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.btnreemplazar = New System.Windows.Forms.Button()
        Me.btnreemplazartodo = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txttexto
        '
        Me.txttexto.Location = New System.Drawing.Point(13, 36)
        Me.txttexto.Name = "txttexto"
        Me.txttexto.Size = New System.Drawing.Size(277, 104)
        Me.txttexto.TabIndex = 0
        Me.txttexto.Text = ""
        '
        'lbsugerencias
        '
        Me.lbsugerencias.FormattingEnabled = True
        Me.lbsugerencias.Location = New System.Drawing.Point(13, 218)
        Me.lbsugerencias.Name = "lbsugerencias"
        Me.lbsugerencias.Size = New System.Drawing.Size(277, 121)
        Me.lbsugerencias.TabIndex = 1
        '
        'txtreemplazo
        '
        Me.txtreemplazo.Location = New System.Drawing.Point(13, 171)
        Me.txtreemplazo.Name = "txtreemplazo"
        Me.txtreemplazo.Size = New System.Drawing.Size(277, 20)
        Me.txtreemplazo.TabIndex = 2
        '
        'btnignorar
        '
        Me.btnignorar.Location = New System.Drawing.Point(310, 27)
        Me.btnignorar.Name = "btnignorar"
        Me.btnignorar.Size = New System.Drawing.Size(103, 23)
        Me.btnignorar.TabIndex = 3
        Me.btnignorar.Text = "Ignorar"
        Me.btnignorar.UseVisualStyleBackColor = True
        '
        'btnignorartodo
        '
        Me.btnignorartodo.Location = New System.Drawing.Point(310, 71)
        Me.btnignorartodo.Name = "btnignorartodo"
        Me.btnignorartodo.Size = New System.Drawing.Size(103, 23)
        Me.btnignorartodo.TabIndex = 4
        Me.btnignorartodo.Text = "Ignorar Todo"
        Me.btnignorartodo.UseVisualStyleBackColor = True
        '
        'btnagregar
        '
        Me.btnagregar.Location = New System.Drawing.Point(310, 117)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(103, 23)
        Me.btnagregar.TabIndex = 5
        Me.btnagregar.Text = "Agregar"
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'btnreemplazar
        '
        Me.btnreemplazar.Location = New System.Drawing.Point(310, 163)
        Me.btnreemplazar.Name = "btnreemplazar"
        Me.btnreemplazar.Size = New System.Drawing.Size(103, 23)
        Me.btnreemplazar.TabIndex = 6
        Me.btnreemplazar.Text = "Reemplazar"
        Me.btnreemplazar.UseVisualStyleBackColor = True
        '
        'btnreemplazartodo
        '
        Me.btnreemplazartodo.Location = New System.Drawing.Point(310, 209)
        Me.btnreemplazartodo.Name = "btnreemplazartodo"
        Me.btnreemplazartodo.Size = New System.Drawing.Size(103, 23)
        Me.btnreemplazartodo.TabIndex = 7
        Me.btnreemplazartodo.Text = "Reemplazar Todo"
        Me.btnreemplazartodo.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(310, 316)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(103, 23)
        Me.btncancelar.TabIndex = 9
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Texto para Revisar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Reemplazar Con"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Sugerencias"
        '
        'FrmspellCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(430, 355)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.btnreemplazartodo)
        Me.Controls.Add(Me.btnreemplazar)
        Me.Controls.Add(Me.btnagregar)
        Me.Controls.Add(Me.btnignorartodo)
        Me.Controls.Add(Me.btnignorar)
        Me.Controls.Add(Me.txtreemplazo)
        Me.Controls.Add(Me.lbsugerencias)
        Me.Controls.Add(Me.txttexto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmspellCheck"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Corrector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txttexto As System.Windows.Forms.RichTextBox
    Friend WithEvents lbsugerencias As System.Windows.Forms.ListBox
    Friend WithEvents txtreemplazo As System.Windows.Forms.TextBox
    Friend WithEvents btnignorar As System.Windows.Forms.Button
    Friend WithEvents btnignorartodo As System.Windows.Forms.Button
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents btnreemplazar As System.Windows.Forms.Button
    Friend WithEvents btnreemplazartodo As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
