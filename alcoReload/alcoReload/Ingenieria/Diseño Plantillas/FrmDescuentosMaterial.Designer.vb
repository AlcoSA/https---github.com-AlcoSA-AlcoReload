<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDescuentosMaterial
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDescuentosMaterial))
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.iddescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fvalor = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.usar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btonAddDescuento = New System.Windows.Forms.ToolStripButton()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.tsherramientas.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.iddescuento, Me.descuento, Me.valor, Me.fvalor, Me.usar})
        Me.dwitems.Location = New System.Drawing.Point(12, 31)
        Me.dwitems.Name = "dwitems"
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.Size = New System.Drawing.Size(319, 223)
        Me.dwitems.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'iddescuento
        '
        Me.iddescuento.HeaderText = "Id Descuento"
        Me.iddescuento.Name = "iddescuento"
        Me.iddescuento.ReadOnly = True
        Me.iddescuento.Visible = False
        Me.iddescuento.Width = 77
        '
        'descuento
        '
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.ReadOnly = True
        Me.descuento.Width = 84
        '
        'valor
        '
        Me.valor.HeaderText = "Valor"
        Me.valor.MaxInputLength = 255
        Me.valor.Name = "valor"
        Me.valor.Width = 56
        '
        'fvalor
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = "..."
        Me.fvalor.DefaultCellStyle = DataGridViewCellStyle1
        Me.fvalor.HeaderText = "..."
        Me.fvalor.Name = "fvalor"
        Me.fvalor.Width = 22
        '
        'usar
        '
        Me.usar.HeaderText = "Usar"
        Me.usar.Name = "usar"
        Me.usar.Width = 35
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(175, 269)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(156, 27)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(72, 21)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Location = New System.Drawing.Point(81, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(72, 21)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btonAddDescuento})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(343, 25)
        Me.tsherramientas.TabIndex = 2
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btonAddDescuento
        '
        Me.btonAddDescuento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btonAddDescuento.Image = CType(resources.GetObject("btonAddDescuento.Image"), System.Drawing.Image)
        Me.btonAddDescuento.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btonAddDescuento.Name = "btonAddDescuento"
        Me.btonAddDescuento.Size = New System.Drawing.Size(23, 22)
        Me.btonAddDescuento.Text = "Agregar Descuento"
        '
        'FrmDescuentosMaterial
        '
        Me.AcceptButton = Me.btnaceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(343, 308)
        Me.Controls.Add(Me.tsherramientas)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.dwitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmDescuentosMaterial"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descuentos"
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dwitems As DataGridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btnaceptar As Button
    Friend WithEvents btncancelar As Button
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btonAddDescuento As ToolStripButton
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents iddescuento As DataGridViewTextBoxColumn
    Friend WithEvents descuento As DataGridViewTextBoxColumn
    Friend WithEvents valor As DataGridViewTextBoxColumn
    Friend WithEvents fvalor As DataGridViewButtonColumn
    Friend WithEvents usar As DataGridViewCheckBoxColumn
End Class
