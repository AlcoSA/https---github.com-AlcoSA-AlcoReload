<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreacionVariables
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
        Me.spuniversal = New System.Windows.Forms.SplitContainer()
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valors = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pvariables = New System.Windows.Forms.Panel()
        Me.tlpelementos = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtvariable = New RichTextBoxSintaxHighLight.RichtTexboxSyntax()
        Me.cbestado = New System.Windows.Forms.CheckBox()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.flpTablas = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.spuniversal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spuniversal.Panel1.SuspendLayout()
        Me.spuniversal.Panel2.SuspendLayout()
        Me.spuniversal.SuspendLayout()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pvariables.SuspendLayout()
        Me.tlpelementos.SuspendLayout()
        Me.SuspendLayout()
        '
        'spuniversal
        '
        Me.spuniversal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.spuniversal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spuniversal.Location = New System.Drawing.Point(0, 0)
        Me.spuniversal.Name = "spuniversal"
        '
        'spuniversal.Panel1
        '
        Me.spuniversal.Panel1.Controls.Add(Me.dwitems)
        Me.spuniversal.Panel1.Controls.Add(Me.pvariables)
        '
        'spuniversal.Panel2
        '
        Me.spuniversal.Panel2.Controls.Add(Me.flpTablas)
        Me.spuniversal.Size = New System.Drawing.Size(709, 536)
        Me.spuniversal.SplitterDistance = 360
        Me.spuniversal.TabIndex = 0
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.valor, Me.valors, Me.estado})
        Me.dwitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwitems.Location = New System.Drawing.Point(0, 152)
        Me.dwitems.Name = "dwitems"
        Me.dwitems.ReadOnly = True
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.Size = New System.Drawing.Size(356, 380)
        Me.dwitems.TabIndex = 1
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre Campo"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'valor
        '
        Me.valor.HeaderText = "Valor Campo"
        Me.valor.Name = "valor"
        Me.valor.ReadOnly = True
        '
        'valors
        '
        Me.valors.HeaderText = "Valor Campo Sistema"
        Me.valors.Name = "valors"
        Me.valors.ReadOnly = True
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        '
        'pvariables
        '
        Me.pvariables.Controls.Add(Me.tlpelementos)
        Me.pvariables.Dock = System.Windows.Forms.DockStyle.Top
        Me.pvariables.Location = New System.Drawing.Point(0, 0)
        Me.pvariables.Name = "pvariables"
        Me.pvariables.Size = New System.Drawing.Size(356, 152)
        Me.pvariables.TabIndex = 0
        '
        'tlpelementos
        '
        Me.tlpelementos.ColumnCount = 2
        Me.tlpelementos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.97633!))
        Me.tlpelementos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.02367!))
        Me.tlpelementos.Controls.Add(Me.Label3, 0, 2)
        Me.tlpelementos.Controls.Add(Me.txtvariable, 1, 1)
        Me.tlpelementos.Controls.Add(Me.cbestado, 1, 2)
        Me.tlpelementos.Controls.Add(Me.txtnombre, 1, 0)
        Me.tlpelementos.Controls.Add(Me.Label1, 0, 1)
        Me.tlpelementos.Controls.Add(Me.Label2, 0, 0)
        Me.tlpelementos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpelementos.Location = New System.Drawing.Point(0, 0)
        Me.tlpelementos.Name = "tlpelementos"
        Me.tlpelementos.RowCount = 3
        Me.tlpelementos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.84733!))
        Me.tlpelementos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.15267!))
        Me.tlpelementos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.tlpelementos.Size = New System.Drawing.Size(356, 152)
        Me.tlpelementos.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Estado"
        '
        'txtvariable
        '
        Me.txtvariable.AutoWordSelection = True
        Me.txtvariable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtvariable.EnableAutoDragDrop = True
        Me.txtvariable.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvariable.Location = New System.Drawing.Point(59, 28)
        Me.txtvariable.MaxLength = 255
        Me.txtvariable.Name = "txtvariable"
        Me.txtvariable.Size = New System.Drawing.Size(294, 97)
        Me.txtvariable.TabIndex = 7
        Me.txtvariable.Text = ""
        '
        'cbestado
        '
        Me.cbestado.AutoSize = True
        Me.cbestado.Location = New System.Drawing.Point(59, 131)
        Me.cbestado.Name = "cbestado"
        Me.cbestado.Size = New System.Drawing.Size(64, 17)
        Me.cbestado.TabIndex = 5
        Me.cbestado.Tag = "6"
        Me.cbestado.Text = "Inactivo"
        Me.cbestado.UseVisualStyleBackColor = True
        '
        'txtnombre
        '
        Me.txtnombre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtnombre.Location = New System.Drawing.Point(59, 3)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(294, 20)
        Me.txtnombre.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Valor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre"
        '
        'flpTablas
        '
        Me.flpTablas.AutoScroll = True
        Me.flpTablas.BackColor = System.Drawing.Color.White
        Me.flpTablas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpTablas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpTablas.Location = New System.Drawing.Point(0, 0)
        Me.flpTablas.Name = "flpTablas"
        Me.flpTablas.Size = New System.Drawing.Size(341, 532)
        Me.flpTablas.TabIndex = 0
        '
        'FrmCreacionVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 536)
        Me.Controls.Add(Me.spuniversal)
        Me.Name = "FrmCreacionVariables"
        Me.ShowIcon = False
        Me.Text = "Creacion Variables"
        Me.spuniversal.Panel1.ResumeLayout(False)
        Me.spuniversal.Panel2.ResumeLayout(False)
        CType(Me.spuniversal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spuniversal.ResumeLayout(False)
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pvariables.ResumeLayout(False)
        Me.tlpelementos.ResumeLayout(False)
        Me.tlpelementos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spuniversal As System.Windows.Forms.SplitContainer
    Friend WithEvents flpTablas As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pvariables As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dwitems As System.Windows.Forms.DataGridView
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents cbestado As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvariable As RichTextBoxSintaxHighLight.RichtTexboxSyntax
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents valors As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents estado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tlpelementos As TableLayoutPanel
End Class
