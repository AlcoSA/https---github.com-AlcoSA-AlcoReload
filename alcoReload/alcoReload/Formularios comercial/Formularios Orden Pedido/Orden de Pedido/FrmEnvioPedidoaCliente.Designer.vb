<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnvioPedidoaCliente
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
        Me.txtcorreo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtasunto = New System.Windows.Forms.TextBox()
        Me.gbmensaje = New System.Windows.Forms.GroupBox()
        Me.txtmensaje = New System.Windows.Forms.RichTextBox()
        Me.tlpenvio = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnenviar = New System.Windows.Forms.Button()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.gbmensaje.SuspendLayout()
        Me.tlpenvio.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Para:"
        '
        'txtcorreo
        '
        Me.txtcorreo.Location = New System.Drawing.Point(58, 10)
        Me.txtcorreo.Name = "txtcorreo"
        Me.txtcorreo.Size = New System.Drawing.Size(214, 20)
        Me.txtcorreo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Asunto"
        '
        'txtasunto
        '
        Me.txtasunto.Location = New System.Drawing.Point(58, 40)
        Me.txtasunto.Name = "txtasunto"
        Me.txtasunto.Size = New System.Drawing.Size(214, 20)
        Me.txtasunto.TabIndex = 3
        Me.txtasunto.Text = "Orden Pedido"
        '
        'gbmensaje
        '
        Me.gbmensaje.Controls.Add(Me.txtmensaje)
        Me.gbmensaje.Location = New System.Drawing.Point(16, 80)
        Me.gbmensaje.Name = "gbmensaje"
        Me.gbmensaje.Size = New System.Drawing.Size(383, 232)
        Me.gbmensaje.TabIndex = 4
        Me.gbmensaje.TabStop = False
        Me.gbmensaje.Text = "Mensaje"
        '
        'txtmensaje
        '
        Me.txtmensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtmensaje.Location = New System.Drawing.Point(3, 16)
        Me.txtmensaje.Name = "txtmensaje"
        Me.txtmensaje.Size = New System.Drawing.Size(377, 213)
        Me.txtmensaje.TabIndex = 0
        Me.txtmensaje.Text = ""
        '
        'tlpenvio
        '
        Me.tlpenvio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpenvio.ColumnCount = 2
        Me.tlpenvio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.Controls.Add(Me.btncancelar, 1, 0)
        Me.tlpenvio.Controls.Add(Me.btnenviar, 0, 0)
        Me.tlpenvio.Location = New System.Drawing.Point(232, 318)
        Me.tlpenvio.Name = "tlpenvio"
        Me.tlpenvio.RowCount = 1
        Me.tlpenvio.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpenvio.Size = New System.Drawing.Size(164, 31)
        Me.tlpenvio.TabIndex = 7
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(85, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnenviar
        '
        Me.btnenviar.Location = New System.Drawing.Point(3, 3)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(75, 23)
        Me.btnenviar.TabIndex = 0
        Me.btnenviar.Text = "Enviar"
        Me.btnenviar.UseVisualStyleBackColor = True
        '
        'bwcargas
        '
        '
        'FrmEnvioPedidoaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(411, 358)
        Me.Controls.Add(Me.tlpenvio)
        Me.Controls.Add(Me.gbmensaje)
        Me.Controls.Add(Me.txtasunto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcorreo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmEnvioPedidoaCliente"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envio Pedido Cliente"
        Me.gbmensaje.ResumeLayout(False)
        Me.tlpenvio.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtcorreo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtasunto As TextBox
    Friend WithEvents gbmensaje As GroupBox
    Friend WithEvents txtmensaje As RichTextBox
    Friend WithEvents tlpenvio As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnenviar As Button
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
End Class
