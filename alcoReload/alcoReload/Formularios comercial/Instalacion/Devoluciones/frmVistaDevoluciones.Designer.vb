<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaDevoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaDevoluciones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnAnularDevolucion = New System.Windows.Forms.ToolStripButton()
        Me.lblConsecutivo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.gbEncabezado = New System.Windows.Forms.GroupBox()
        Me.txtFechaCreacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEncargado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblValorDevuelto = New System.Windows.Forms.Label()
        Me.lblCantidadDevuelta = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_retenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_undMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidadDevuelta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorDevuelto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsHerramientas.SuspendLayout()
        Me.gbEncabezado.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAnularDevolucion, Me.lblConsecutivo, Me.ToolStripLabel2, Me.lblDocumento, Me.ToolStripLabel1})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(694, 25)
        Me.tsHerramientas.TabIndex = 1
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnAnularDevolucion
        '
        Me.btnAnularDevolucion.Image = CType(resources.GetObject("btnAnularDevolucion.Image"), System.Drawing.Image)
        Me.btnAnularDevolucion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnularDevolucion.Name = "btnAnularDevolucion"
        Me.btnAnularDevolucion.Size = New System.Drawing.Size(124, 22)
        Me.btnAnularDevolucion.Text = "Anular devolución"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(21, 22)
        Me.lblConsecutivo.Text = "15"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(73, 22)
        Me.ToolStripLabel2.Text = "Consecutivo"
        '
        'lblDocumento
        '
        Me.lblDocumento.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(34, 22)
        Me.lblDocumento.Text = "OTM"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(70, 22)
        Me.ToolStripLabel1.Text = "Documento"
        '
        'gbEncabezado
        '
        Me.gbEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEncabezado.Controls.Add(Me.txtFechaCreacion)
        Me.gbEncabezado.Controls.Add(Me.Label5)
        Me.gbEncabezado.Controls.Add(Me.txtEncargado)
        Me.gbEncabezado.Controls.Add(Me.Label3)
        Me.gbEncabezado.Controls.Add(Me.txtProveedor)
        Me.gbEncabezado.Controls.Add(Me.Label4)
        Me.gbEncabezado.Controls.Add(Me.txtVendedor)
        Me.gbEncabezado.Controls.Add(Me.Label2)
        Me.gbEncabezado.Controls.Add(Me.txtObra)
        Me.gbEncabezado.Controls.Add(Me.Label1)
        Me.gbEncabezado.Location = New System.Drawing.Point(12, 28)
        Me.gbEncabezado.Name = "gbEncabezado"
        Me.gbEncabezado.Size = New System.Drawing.Size(670, 120)
        Me.gbEncabezado.TabIndex = 3
        Me.gbEncabezado.TabStop = False
        Me.gbEncabezado.Text = "Encabezado"
        '
        'txtFechaCreacion
        '
        Me.txtFechaCreacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaCreacion.Enabled = False
        Me.txtFechaCreacion.Location = New System.Drawing.Point(437, 40)
        Me.txtFechaCreacion.Name = "txtFechaCreacion"
        Me.txtFechaCreacion.Size = New System.Drawing.Size(131, 20)
        Me.txtFechaCreacion.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(434, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha creación"
        '
        'txtEncargado
        '
        Me.txtEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEncargado.Enabled = False
        Me.txtEncargado.Location = New System.Drawing.Point(331, 83)
        Me.txtEncargado.Name = "txtEncargado"
        Me.txtEncargado.Size = New System.Drawing.Size(289, 20)
        Me.txtEncargado.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(328, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Encargado"
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(18, 84)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(289, 20)
        Me.txtProveedor.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Proveedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(331, 40)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(80, 20)
        Me.txtVendedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendedor"
        '
        'txtObra
        '
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.Enabled = False
        Me.txtObra.Location = New System.Drawing.Point(18, 40)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(289, 20)
        Me.txtObra.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Obra"
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMovimiento.Controls.Add(Me.dwItems)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 154)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(670, 254)
        Me.gbMovimiento.TabIndex = 4
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_concepto, Me.col_descripcion, Me.col_precio, Me.col_retenido, Me.col_undMedida, Me.col_cantidadDevuelta, Me.col_valorDevuelto})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 19)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(658, 229)
        Me.dwItems.TabIndex = 15
        '
        'gbTotales
        '
        Me.gbTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTotales.Controls.Add(Me.lblValorDevuelto)
        Me.gbTotales.Controls.Add(Me.lblCantidadDevuelta)
        Me.gbTotales.Controls.Add(Me.Label6)
        Me.gbTotales.Controls.Add(Me.Label7)
        Me.gbTotales.Location = New System.Drawing.Point(422, 414)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(260, 95)
        Me.gbTotales.TabIndex = 6
        Me.gbTotales.TabStop = False
        Me.gbTotales.Text = "Totales"
        '
        'lblValorDevuelto
        '
        Me.lblValorDevuelto.AutoSize = True
        Me.lblValorDevuelto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorDevuelto.Location = New System.Drawing.Point(119, 55)
        Me.lblValorDevuelto.Name = "lblValorDevuelto"
        Me.lblValorDevuelto.Size = New System.Drawing.Size(14, 13)
        Me.lblValorDevuelto.TabIndex = 3
        Me.lblValorDevuelto.Text = "0"
        '
        'lblCantidadDevuelta
        '
        Me.lblCantidadDevuelta.AutoSize = True
        Me.lblCantidadDevuelta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDevuelta.Location = New System.Drawing.Point(119, 26)
        Me.lblCantidadDevuelta.Name = "lblCantidadDevuelta"
        Me.lblCantidadDevuelta.Size = New System.Drawing.Size(14, 13)
        Me.lblCantidadDevuelta.TabIndex = 2
        Me.lblCantidadDevuelta.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Valor devuelto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cantidad devuelta:"
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Width = 41
        '
        'col_concepto
        '
        Me.col_concepto.HeaderText = "Concepto"
        Me.col_concepto.Name = "col_concepto"
        Me.col_concepto.ReadOnly = True
        Me.col_concepto.Width = 78
        '
        'col_descripcion
        '
        Me.col_descripcion.HeaderText = "Descripción"
        Me.col_descripcion.Name = "col_descripcion"
        Me.col_descripcion.ReadOnly = True
        Me.col_descripcion.Width = 88
        '
        'col_precio
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C0"
        Me.col_precio.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_precio.HeaderText = "Precio"
        Me.col_precio.Name = "col_precio"
        Me.col_precio.ReadOnly = True
        Me.col_precio.Width = 62
        '
        'col_retenido
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        Me.col_retenido.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_retenido.HeaderText = "Porcentaje retenido"
        Me.col_retenido.Name = "col_retenido"
        Me.col_retenido.ReadOnly = True
        Me.col_retenido.Visible = False
        Me.col_retenido.Width = 124
        '
        'col_undMedida
        '
        Me.col_undMedida.HeaderText = "Unidad medida"
        Me.col_undMedida.Name = "col_undMedida"
        Me.col_undMedida.ReadOnly = True
        Me.col_undMedida.Width = 95
        '
        'col_cantidadDevuelta
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N0"
        Me.col_cantidadDevuelta.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_cantidadDevuelta.HeaderText = "Cantidad devuelta"
        Me.col_cantidadDevuelta.Name = "col_cantidadDevuelta"
        Me.col_cantidadDevuelta.ReadOnly = True
        Me.col_cantidadDevuelta.Width = 108
        '
        'col_valorDevuelto
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        Me.col_valorDevuelto.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_valorDevuelto.HeaderText = "Valor devuelto"
        Me.col_valorDevuelto.Name = "col_valorDevuelto"
        Me.col_valorDevuelto.ReadOnly = True
        Me.col_valorDevuelto.Width = 92
        '
        'frmVistaDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 521)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.Controls.Add(Me.tsHerramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaDevoluciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista devoluciones"
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnAnularDevolucion As ToolStripButton
    Friend WithEvents lblConsecutivo As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents lblDocumento As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents gbEncabezado As GroupBox
    Friend WithEvents txtFechaCreacion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEncargado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbMovimiento As GroupBox
    Friend WithEvents gbTotales As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents lblValorDevuelto As Label
    Friend WithEvents lblCantidadDevuelta As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_concepto As DataGridViewTextBoxColumn
    Friend WithEvents col_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents col_precio As DataGridViewTextBoxColumn
    Friend WithEvents col_retenido As DataGridViewTextBoxColumn
    Friend WithEvents col_undMedida As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidadDevuelta As DataGridViewTextBoxColumn
    Friend WithEvents col_valorDevuelto As DataGridViewTextBoxColumn
End Class
