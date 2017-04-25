<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreaTabla
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
        Me.gptabla = New System.Windows.Forms.GroupBox()
        Me.nudfilas = New System.Windows.Forms.NumericUpDown()
        Me.nudcolumnas = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.contenedorBtones = New System.Windows.Forms.TableLayoutPanel()
        Me.btonAceptar = New System.Windows.Forms.Button()
        Me.btonCancelar = New System.Windows.Forms.Button()
        Me.gptabla.SuspendLayout()
        CType(Me.nudfilas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudcolumnas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contenedorBtones.SuspendLayout()
        Me.SuspendLayout()
        '
        'gptabla
        '
        Me.gptabla.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gptabla.Controls.Add(Me.nudfilas)
        Me.gptabla.Controls.Add(Me.nudcolumnas)
        Me.gptabla.Controls.Add(Me.Label2)
        Me.gptabla.Controls.Add(Me.Label1)
        Me.gptabla.Location = New System.Drawing.Point(13, 13)
        Me.gptabla.Name = "gptabla"
        Me.gptabla.Size = New System.Drawing.Size(220, 103)
        Me.gptabla.TabIndex = 0
        Me.gptabla.TabStop = False
        Me.gptabla.Text = "Tamaño Tabla"
        '
        'nudfilas
        '
        Me.nudfilas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudfilas.Location = New System.Drawing.Point(125, 58)
        Me.nudfilas.Name = "nudfilas"
        Me.nudfilas.Size = New System.Drawing.Size(74, 20)
        Me.nudfilas.TabIndex = 3
        Me.nudfilas.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'nudcolumnas
        '
        Me.nudcolumnas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudcolumnas.Location = New System.Drawing.Point(125, 21)
        Me.nudcolumnas.Name = "nudcolumnas"
        Me.nudcolumnas.Size = New System.Drawing.Size(74, 20)
        Me.nudcolumnas.TabIndex = 2
        Me.nudcolumnas.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Numero de Filas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Numero de Columnas"
        '
        'contenedorBtones
        '
        Me.contenedorBtones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contenedorBtones.ColumnCount = 2
        Me.contenedorBtones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.6732!))
        Me.contenedorBtones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.3268!))
        Me.contenedorBtones.Controls.Add(Me.btonAceptar, 0, 0)
        Me.contenedorBtones.Controls.Add(Me.btonCancelar, 1, 0)
        Me.contenedorBtones.Location = New System.Drawing.Point(73, 127)
        Me.contenedorBtones.Name = "contenedorBtones"
        Me.contenedorBtones.RowCount = 1
        Me.contenedorBtones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.contenedorBtones.Size = New System.Drawing.Size(160, 29)
        Me.contenedorBtones.TabIndex = 10
        '
        'btonAceptar
        '
        Me.btonAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btonAceptar.Location = New System.Drawing.Point(3, 3)
        Me.btonAceptar.Name = "btonAceptar"
        Me.btonAceptar.Size = New System.Drawing.Size(73, 23)
        Me.btonAceptar.TabIndex = 0
        Me.btonAceptar.Text = "Aceptar"
        Me.btonAceptar.UseVisualStyleBackColor = True
        '
        'btonCancelar
        '
        Me.btonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btonCancelar.Location = New System.Drawing.Point(82, 3)
        Me.btonCancelar.Name = "btonCancelar"
        Me.btonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btonCancelar.TabIndex = 1
        Me.btonCancelar.Text = "Cancelar"
        Me.btonCancelar.UseVisualStyleBackColor = True
        '
        'frmCreaTabla
        '
        Me.AcceptButton = Me.btonAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btonCancelar
        Me.ClientSize = New System.Drawing.Size(245, 168)
        Me.Controls.Add(Me.contenedorBtones)
        Me.Controls.Add(Me.gptabla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCreaTabla"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Matriz"
        Me.gptabla.ResumeLayout(False)
        Me.gptabla.PerformLayout()
        CType(Me.nudfilas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudcolumnas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contenedorBtones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gptabla As System.Windows.Forms.GroupBox
    Friend WithEvents contenedorBtones As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btonAceptar As System.Windows.Forms.Button
    Friend WithEvents btonCancelar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudfilas As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudcolumnas As System.Windows.Forms.NumericUpDown
End Class
