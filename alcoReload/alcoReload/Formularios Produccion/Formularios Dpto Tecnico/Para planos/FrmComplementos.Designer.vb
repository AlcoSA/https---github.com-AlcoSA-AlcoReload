<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComplementos
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
        Me.tlpenvio = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.chlubicacion = New System.Windows.Forms.CheckedListBox()
        Me.tlpenvio.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpenvio
        '
        Me.tlpenvio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpenvio.ColumnCount = 2
        Me.tlpenvio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.Controls.Add(Me.btncancelar, 1, 0)
        Me.tlpenvio.Controls.Add(Me.btnaceptar, 0, 0)
        Me.tlpenvio.Location = New System.Drawing.Point(69, 174)
        Me.tlpenvio.Name = "tlpenvio"
        Me.tlpenvio.RowCount = 1
        Me.tlpenvio.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.Size = New System.Drawing.Size(160, 26)
        Me.tlpenvio.TabIndex = 8
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(83, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(74, 20)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(74, 20)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'chlubicacion
        '
        Me.chlubicacion.FormattingEnabled = True
        Me.chlubicacion.Location = New System.Drawing.Point(13, 13)
        Me.chlubicacion.Name = "chlubicacion"
        Me.chlubicacion.Size = New System.Drawing.Size(216, 154)
        Me.chlubicacion.TabIndex = 9
        '
        'FrmComplementos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(241, 209)
        Me.Controls.Add(Me.chlubicacion)
        Me.Controls.Add(Me.tlpenvio)
        Me.Name = "FrmComplementos"
        Me.ShowIcon = False
        Me.Text = "Complementos"
        Me.tlpenvio.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tlpenvio As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents chlubicacion As CheckedListBox
End Class
