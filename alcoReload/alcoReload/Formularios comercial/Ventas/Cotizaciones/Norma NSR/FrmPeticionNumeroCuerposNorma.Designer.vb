<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPeticionNumeroCuerposNorma
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudnumerocuerpos = New System.Windows.Forms.NumericUpDown()
        Me.tlpbotones = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.nudnumerocuerpos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpbotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese el numero de cuerpos"
        '
        'nudnumerocuerpos
        '
        Me.nudnumerocuerpos.Location = New System.Drawing.Point(23, 25)
        Me.nudnumerocuerpos.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudnumerocuerpos.Name = "nudnumerocuerpos"
        Me.nudnumerocuerpos.Size = New System.Drawing.Size(144, 20)
        Me.nudnumerocuerpos.TabIndex = 1
        Me.nudnumerocuerpos.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'tlpbotones
        '
        Me.tlpbotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpbotones.ColumnCount = 2
        Me.tlpbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.Controls.Add(Me.btnCancelar, 1, 0)
        Me.tlpbotones.Controls.Add(Me.btnAceptar, 0, 0)
        Me.tlpbotones.Location = New System.Drawing.Point(6, 59)
        Me.tlpbotones.Name = "tlpbotones"
        Me.tlpbotones.RowCount = 1
        Me.tlpbotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.Size = New System.Drawing.Size(171, 28)
        Me.tlpbotones.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancelar.Location = New System.Drawing.Point(88, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 22)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 22)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'FrmPeticionNumeroCuerposNorma
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(189, 99)
        Me.Controls.Add(Me.tlpbotones)
        Me.Controls.Add(Me.nudnumerocuerpos)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmPeticionNumeroCuerposNorma"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numero Cuerpos Norma"
        CType(Me.nudnumerocuerpos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpbotones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents nudnumerocuerpos As NumericUpDown
    Friend WithEvents tlpbotones As TableLayoutPanel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
End Class
