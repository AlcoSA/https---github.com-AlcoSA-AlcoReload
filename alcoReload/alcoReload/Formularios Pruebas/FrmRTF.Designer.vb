<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRTF
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rtxbase = New System.Windows.Forms.RichTextBox()
        Me.rtxrtf = New System.Windows.Forms.RichTextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtxbase)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtxrtf)
        Me.SplitContainer1.Size = New System.Drawing.Size(555, 324)
        Me.SplitContainer1.SplitterDistance = 256
        Me.SplitContainer1.TabIndex = 0
        '
        'rtxbase
        '
        Me.rtxbase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxbase.Location = New System.Drawing.Point(0, 0)
        Me.rtxbase.Name = "rtxbase"
        Me.rtxbase.Size = New System.Drawing.Size(256, 324)
        Me.rtxbase.TabIndex = 0
        Me.rtxbase.Text = ""
        '
        'rtxrtf
        '
        Me.rtxrtf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxrtf.Location = New System.Drawing.Point(0, 0)
        Me.rtxrtf.Name = "rtxrtf"
        Me.rtxrtf.Size = New System.Drawing.Size(295, 324)
        Me.rtxrtf.TabIndex = 1
        Me.rtxrtf.Text = ""
        '
        'FrmRTF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 324)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmRTF"
        Me.ShowIcon = False
        Me.Text = "RTF"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents rtxbase As RichTextBox
    Friend WithEvents rtxrtf As RichTextBox
End Class
