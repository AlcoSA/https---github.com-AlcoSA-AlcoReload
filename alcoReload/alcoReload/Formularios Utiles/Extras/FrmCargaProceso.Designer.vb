<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCargaProceso
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
        Me.lbproceso = New System.Windows.Forms.Label()
        Me.bppcargaproceso = New ControlesPersonalizados.BarradeProgresoPersonalizada()
        Me.lbPorcentaje = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbproceso
        '
        Me.lbproceso.AutoSize = True
        Me.lbproceso.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbproceso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbproceso.ForeColor = System.Drawing.Color.Black
        Me.lbproceso.Location = New System.Drawing.Point(0, 131)
        Me.lbproceso.Name = "lbproceso"
        Me.lbproceso.Size = New System.Drawing.Size(24, 20)
        Me.lbproceso.TabIndex = 1
        Me.lbproceso.Text = "..."
        Me.lbproceso.UseWaitCursor = True
        '
        'bppcargaproceso
        '
        Me.bppcargaproceso.AnguloInicial = 30.0!
        Me.bppcargaproceso.BackColor = System.Drawing.Color.Transparent
        Me.bppcargaproceso.DireccionRotativa = ControlesPersonalizados.BarradeProgresoPersonalizada.Direction.MANECILLASRELOJ
        Me.bppcargaproceso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bppcargaproceso.Intervalo = 60
        Me.bppcargaproceso.Location = New System.Drawing.Point(0, 0)
        Me.bppcargaproceso.MinimumSize = New System.Drawing.Size(28, 28)
        Me.bppcargaproceso.Name = "bppcargaproceso"
        Me.bppcargaproceso.PorcentajeEjecucion = 0!
        Me.bppcargaproceso.ProcesoActual = Nothing
        Me.bppcargaproceso.showPorcentaje = False
        Me.bppcargaproceso.Size = New System.Drawing.Size(185, 151)
        Me.bppcargaproceso.TabIndex = 0
        Me.bppcargaproceso.TickColor = System.Drawing.Color.FromArgb(CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.bppcargaproceso.UseWaitCursor = True
        '
        'lbPorcentaje
        '
        Me.lbPorcentaje.AutoSize = True
        Me.lbPorcentaje.Location = New System.Drawing.Point(82, 70)
        Me.lbPorcentaje.Name = "lbPorcentaje"
        Me.lbPorcentaje.Size = New System.Drawing.Size(0, 13)
        Me.lbPorcentaje.TabIndex = 2
        Me.lbPorcentaje.UseWaitCursor = True
        '
        'FrmCargaProceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(185, 151)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbPorcentaje)
        Me.Controls.Add(Me.lbproceso)
        Me.Controls.Add(Me.bppcargaproceso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCargaProceso"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procesando"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.UseWaitCursor = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bppcargaproceso As ControlesPersonalizados.BarradeProgresoPersonalizada
    Friend WithEvents lbproceso As Label
    Friend WithEvents lbPorcentaje As Label
End Class
