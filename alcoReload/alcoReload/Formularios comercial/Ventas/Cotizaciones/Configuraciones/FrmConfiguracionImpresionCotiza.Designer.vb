<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConfiguracionImpresionCotiza
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
        Me.gbimpresoras = New System.Windows.Forms.GroupBox()
        Me.lbcomentario = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.lbpuerto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbestado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbimpresora = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbpaginas = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txthasta = New System.Windows.Forms.TextBox()
        Me.txtdesde = New System.Windows.Forms.TextBox()
        Me.rbpaginas = New System.Windows.Forms.RadioButton()
        Me.rbtodo = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nudcopias = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chbimagenes = New System.Windows.Forms.CheckBox()
        Me.gbimpresoras.SuspendLayout()
        Me.gbpaginas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudcopias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbimpresoras
        '
        Me.gbimpresoras.Controls.Add(Me.lbcomentario)
        Me.gbimpresoras.Controls.Add(Me.label5)
        Me.gbimpresoras.Controls.Add(Me.lbpuerto)
        Me.gbimpresoras.Controls.Add(Me.Label4)
        Me.gbimpresoras.Controls.Add(Me.lbestado)
        Me.gbimpresoras.Controls.Add(Me.Label2)
        Me.gbimpresoras.Controls.Add(Me.cbimpresora)
        Me.gbimpresoras.Controls.Add(Me.Label1)
        Me.gbimpresoras.Location = New System.Drawing.Point(13, 13)
        Me.gbimpresoras.Name = "gbimpresoras"
        Me.gbimpresoras.Size = New System.Drawing.Size(278, 125)
        Me.gbimpresoras.TabIndex = 0
        Me.gbimpresoras.TabStop = False
        Me.gbimpresoras.Text = "Impresoras"
        '
        'lbcomentario
        '
        Me.lbcomentario.AutoSize = True
        Me.lbcomentario.Location = New System.Drawing.Point(66, 101)
        Me.lbcomentario.Name = "lbcomentario"
        Me.lbcomentario.Size = New System.Drawing.Size(16, 13)
        Me.lbcomentario.TabIndex = 7
        Me.lbcomentario.Text = "..."
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(10, 102)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(60, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Comentario"
        '
        'lbpuerto
        '
        Me.lbpuerto.AutoSize = True
        Me.lbpuerto.Location = New System.Drawing.Point(66, 75)
        Me.lbpuerto.Name = "lbpuerto"
        Me.lbpuerto.Size = New System.Drawing.Size(16, 13)
        Me.lbpuerto.TabIndex = 5
        Me.lbpuerto.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Puerto"
        '
        'lbestado
        '
        Me.lbestado.AutoSize = True
        Me.lbestado.Location = New System.Drawing.Point(66, 50)
        Me.lbestado.Name = "lbestado"
        Me.lbestado.Size = New System.Drawing.Size(16, 13)
        Me.lbestado.TabIndex = 3
        Me.lbestado.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Estado"
        '
        'cbimpresora
        '
        Me.cbimpresora.FormattingEnabled = True
        Me.cbimpresora.Location = New System.Drawing.Point(66, 17)
        Me.cbimpresora.Name = "cbimpresora"
        Me.cbimpresora.Size = New System.Drawing.Size(201, 21)
        Me.cbimpresora.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Impresora"
        '
        'gbpaginas
        '
        Me.gbpaginas.Controls.Add(Me.Label3)
        Me.gbpaginas.Controls.Add(Me.txthasta)
        Me.gbpaginas.Controls.Add(Me.txtdesde)
        Me.gbpaginas.Controls.Add(Me.rbpaginas)
        Me.gbpaginas.Controls.Add(Me.rbtodo)
        Me.gbpaginas.Location = New System.Drawing.Point(13, 144)
        Me.gbpaginas.Name = "gbpaginas"
        Me.gbpaginas.Size = New System.Drawing.Size(278, 81)
        Me.gbpaginas.TabIndex = 1
        Me.gbpaginas.TabStop = False
        Me.gbpaginas.Text = "Paginas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(126, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Hasta"
        '
        'txthasta
        '
        Me.txthasta.Location = New System.Drawing.Point(167, 40)
        Me.txthasta.Name = "txthasta"
        Me.txthasta.ReadOnly = True
        Me.txthasta.Size = New System.Drawing.Size(45, 20)
        Me.txthasta.TabIndex = 3
        Me.txthasta.Text = "1"
        '
        'txtdesde
        '
        Me.txtdesde.Enabled = False
        Me.txtdesde.Location = New System.Drawing.Point(78, 42)
        Me.txtdesde.Name = "txtdesde"
        Me.txtdesde.ReadOnly = True
        Me.txtdesde.Size = New System.Drawing.Size(45, 20)
        Me.txtdesde.TabIndex = 2
        Me.txtdesde.Text = "1"
        '
        'rbpaginas
        '
        Me.rbpaginas.AutoSize = True
        Me.rbpaginas.Location = New System.Drawing.Point(10, 43)
        Me.rbpaginas.Name = "rbpaginas"
        Me.rbpaginas.Size = New System.Drawing.Size(62, 17)
        Me.rbpaginas.TabIndex = 1
        Me.rbpaginas.Text = "paginas"
        Me.rbpaginas.UseVisualStyleBackColor = True
        '
        'rbtodo
        '
        Me.rbtodo.AutoSize = True
        Me.rbtodo.Checked = True
        Me.rbtodo.Location = New System.Drawing.Point(10, 20)
        Me.rbtodo.Name = "rbtodo"
        Me.rbtodo.Size = New System.Drawing.Size(50, 17)
        Me.rbtodo.TabIndex = 0
        Me.rbtodo.TabStop = True
        Me.rbtodo.Text = "Todo"
        Me.rbtodo.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(417, 332)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(164, 31)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btncancelar.Location = New System.Drawing.Point(85, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(76, 25)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnaceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nudcopias)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 231)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 94)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paginas"
        '
        'nudcopias
        '
        Me.nudcopias.Location = New System.Drawing.Point(70, 18)
        Me.nudcopias.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudcopias.Name = "nudcopias"
        Me.nudcopias.Size = New System.Drawing.Size(54, 20)
        Me.nudcopias.TabIndex = 9
        Me.nudcopias.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Copias"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chbimagenes)
        Me.GroupBox2.Location = New System.Drawing.Point(303, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 312)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuracion Cotizacion"
        '
        'chbimagenes
        '
        Me.chbimagenes.AutoSize = True
        Me.chbimagenes.Checked = True
        Me.chbimagenes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbimagenes.Location = New System.Drawing.Point(18, 20)
        Me.chbimagenes.Name = "chbimagenes"
        Me.chbimagenes.Size = New System.Drawing.Size(110, 17)
        Me.chbimagenes.TabIndex = 0
        Me.chbimagenes.Text = "Imprimir Imagenes"
        Me.chbimagenes.UseVisualStyleBackColor = True
        '
        'FrmConfiguracionImpresionCotiza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(593, 375)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.gbpaginas)
        Me.Controls.Add(Me.gbimpresoras)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmConfiguracionImpresionCotiza"
        Me.ShowIcon = False
        Me.Text = "Configuracion Impresión"
        Me.gbimpresoras.ResumeLayout(False)
        Me.gbimpresoras.PerformLayout()
        Me.gbpaginas.ResumeLayout(False)
        Me.gbpaginas.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudcopias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbimpresoras As GroupBox
    Friend WithEvents cbimpresora As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbestado As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbpuerto As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbcomentario As Label
    Friend WithEvents label5 As Label
    Friend WithEvents gbpaginas As GroupBox
    Friend WithEvents txtdesde As TextBox
    Friend WithEvents rbpaginas As RadioButton
    Friend WithEvents rbtodo As RadioButton
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txthasta As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudcopias As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chbimagenes As CheckBox
End Class
