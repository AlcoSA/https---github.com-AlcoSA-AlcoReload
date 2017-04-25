<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPruebasEjecutor
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
        Me.btncalcular = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtformula = New System.Windows.Forms.TextBox()
        Me.lbresultado = New System.Windows.Forms.Label()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btncalcular
        '
        Me.btncalcular.Location = New System.Drawing.Point(238, 133)
        Me.btncalcular.Name = "btncalcular"
        Me.btncalcular.Size = New System.Drawing.Size(75, 23)
        Me.btncalcular.TabIndex = 0
        Me.btncalcular.Text = "Calcular"
        Me.btncalcular.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Formula"
        '
        'txtformula
        '
        Me.txtformula.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtformula.Location = New System.Drawing.Point(13, 39)
        Me.txtformula.Multiline = True
        Me.txtformula.Name = "txtformula"
        Me.txtformula.Size = New System.Drawing.Size(300, 48)
        Me.txtformula.TabIndex = 2
        '
        'lbresultado
        '
        Me.lbresultado.AutoSize = True
        Me.lbresultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbresultado.ForeColor = System.Drawing.Color.Red
        Me.lbresultado.Location = New System.Drawing.Point(16, 94)
        Me.lbresultado.Name = "lbresultado"
        Me.lbresultado.Size = New System.Drawing.Size(19, 20)
        Me.lbresultado.TabIndex = 3
        Me.lbresultado.Text = "="
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(202, 133)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(30, 23)
        Me.btncancelar.TabIndex = 4
        Me.btncancelar.Text = "X"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'FrmPruebasEjecutor
        '
        Me.AcceptButton = Me.btncalcular
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(325, 168)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.lbresultado)
        Me.Controls.Add(Me.txtformula)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btncalcular)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmPruebasEjecutor"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pruebas Ejecutor"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btncalcular As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtformula As TextBox
    Friend WithEvents lbresultado As Label
    Friend WithEvents btncancelar As Button
End Class
