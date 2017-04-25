<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmParametrosInformesDinamicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmParametrosInformesDinamicos))
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnagregarparametro = New System.Windows.Forms.ToolStripButton()
        Me.dwparametros = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombrebd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodato = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.tsherramientas.SuspendLayout()
        CType(Me.dwparametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnagregarparametro})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(590, 25)
        Me.tsherramientas.TabIndex = 0
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnagregarparametro
        '
        Me.btnagregarparametro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnagregarparametro.Image = CType(resources.GetObject("btnagregarparametro.Image"), System.Drawing.Image)
        Me.btnagregarparametro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnagregarparametro.Name = "btnagregarparametro"
        Me.btnagregarparametro.Size = New System.Drawing.Size(23, 22)
        Me.btnagregarparametro.Text = "Agregar Parametro"
        '
        'dwparametros
        '
        Me.dwparametros.AllowUserToAddRows = False
        Me.dwparametros.BackgroundColor = System.Drawing.Color.White
        Me.dwparametros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwparametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwparametros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombrebd, Me.nombre, Me.tipodato, Me.estado})
        Me.dwparametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwparametros.Location = New System.Drawing.Point(0, 25)
        Me.dwparametros.Name = "dwparametros"
        Me.dwparametros.RowHeadersWidth = 25
        Me.dwparametros.Size = New System.Drawing.Size(590, 210)
        Me.dwparametros.TabIndex = 1
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'nombrebd
        '
        Me.nombrebd.HeaderText = "Nombre BD"
        Me.nombrebd.Name = "nombrebd"
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre Visibile"
        Me.nombre.Name = "nombre"
        '
        'tipodato
        '
        Me.tipodato.HeaderText = "Tipo Dato"
        Me.tipodato.Name = "tipodato"
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 235)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(590, 26)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(513, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(74, 20)
        Me.btncancelar.TabIndex = 0
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(433, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(74, 20)
        Me.btnaceptar.TabIndex = 1
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'FrmParametrosInformesDinamicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(590, 261)
        Me.Controls.Add(Me.dwparametros)
        Me.Controls.Add(Me.tsherramientas)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmParametrosInformesDinamicos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros Informes Dinamicos"
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        CType(Me.dwparametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnagregarparametro As ToolStripButton
    Friend WithEvents dwparametros As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nombrebd As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents tipodato As DataGridViewComboBoxColumn
    Friend WithEvents estado As DataGridViewCheckBoxColumn
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
End Class
