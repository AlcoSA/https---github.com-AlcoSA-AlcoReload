<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCambioSeccion
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConsecutivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSeccionOriginal = New System.Windows.Forms.TextBox()
        Me.txtResponsableOriginal = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbSeccion = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.txtResponsableCambio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMotivoCambio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Consecutivo problema"
        '
        'txtConsecutivo
        '
        Me.txtConsecutivo.Enabled = False
        Me.txtConsecutivo.Location = New System.Drawing.Point(132, 21)
        Me.txtConsecutivo.Name = "txtConsecutivo"
        Me.txtConsecutivo.ReadOnly = True
        Me.txtConsecutivo.Size = New System.Drawing.Size(158, 20)
        Me.txtConsecutivo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sección original"
        '
        'txtSeccionOriginal
        '
        Me.txtSeccionOriginal.Enabled = False
        Me.txtSeccionOriginal.Location = New System.Drawing.Point(132, 47)
        Me.txtSeccionOriginal.Name = "txtSeccionOriginal"
        Me.txtSeccionOriginal.ReadOnly = True
        Me.txtSeccionOriginal.Size = New System.Drawing.Size(263, 20)
        Me.txtSeccionOriginal.TabIndex = 3
        '
        'txtResponsableOriginal
        '
        Me.txtResponsableOriginal.Enabled = False
        Me.txtResponsableOriginal.Location = New System.Drawing.Point(132, 73)
        Me.txtResponsableOriginal.Name = "txtResponsableOriginal"
        Me.txtResponsableOriginal.ReadOnly = True
        Me.txtResponsableOriginal.Size = New System.Drawing.Size(263, 20)
        Me.txtResponsableOriginal.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Responsable original"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Sección de cambio"
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbSeccion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbSeccion.DropDownHeight = 200
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.DropDownWidth = 300
        Me.cmbSeccion.IntegralHeight = False
        Me.cmbSeccion.Location = New System.Drawing.Point(132, 123)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(156, 21)
        Me.cmbSeccion.TabIndex = 25
        '
        'txtResponsableCambio
        '
        Me.txtResponsableCambio.Enabled = False
        Me.txtResponsableCambio.Location = New System.Drawing.Point(132, 150)
        Me.txtResponsableCambio.Name = "txtResponsableCambio"
        Me.txtResponsableCambio.ReadOnly = True
        Me.txtResponsableCambio.Size = New System.Drawing.Size(263, 20)
        Me.txtResponsableCambio.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Responsable cambio"
        '
        'txtMotivoCambio
        '
        Me.txtMotivoCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotivoCambio.Location = New System.Drawing.Point(17, 212)
        Me.txtMotivoCambio.MaxLength = 255
        Me.txtMotivoCambio.Multiline = True
        Me.txtMotivoCambio.Name = "txtMotivoCambio"
        Me.txtMotivoCambio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMotivoCambio.Size = New System.Drawing.Size(378, 147)
        Me.txtMotivoCambio.TabIndex = 29
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Motivo cambio"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(239, 371)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 30
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(320, 371)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 31
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrmCambioSeccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 406)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtMotivoCambio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtResponsableCambio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbSeccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtResponsableOriginal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSeccionOriginal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConsecutivo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCambioSeccion"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de sección"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtConsecutivo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSeccionOriginal As TextBox
    Friend WithEvents txtResponsableOriginal As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbSeccion As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents txtResponsableCambio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMotivoCambio As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents ErrorProvider As ErrorProvider
End Class
