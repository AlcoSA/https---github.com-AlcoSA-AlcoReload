<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVerimagen
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
        Me.pbimagen = New System.Windows.Forms.PictureBox()
        CType(Me.pbimagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbimagen
        '
        Me.pbimagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbimagen.Location = New System.Drawing.Point(0, 0)
        Me.pbimagen.Name = "pbimagen"
        Me.pbimagen.Size = New System.Drawing.Size(333, 311)
        Me.pbimagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbimagen.TabIndex = 0
        Me.pbimagen.TabStop = False
        '
        'FrmVerimagen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 311)
        Me.Controls.Add(Me.pbimagen)
        Me.Name = "FrmVerimagen"
        Me.ShowIcon = False
        Me.Text = "Ver imagen"
        CType(Me.pbimagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbimagen As PictureBox
End Class
