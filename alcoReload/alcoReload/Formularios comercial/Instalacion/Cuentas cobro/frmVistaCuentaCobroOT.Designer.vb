<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVistaCuentaCobro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaCuentaCobro))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnAnular = New System.Windows.Forms.ToolStripButton()
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
        Me.dwCuentaCobro = New DatagridTreeView.DataTreeGridView()
        Me.gbTotales = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblRetenido = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cc_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.cc_idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_undMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_subtotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_porcRetenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc_facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tsHerramientas.SuspendLayout()
        Me.gbEncabezado.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        CType(Me.dwCuentaCobro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTotales.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAnular, Me.lblConsecutivo, Me.ToolStripLabel2, Me.lblDocumento, Me.ToolStripLabel1})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(694, 25)
        Me.tsHerramientas.TabIndex = 0
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnAnular
        '
        Me.btnAnular.Image = CType(resources.GetObject("btnAnular.Image"), System.Drawing.Image)
        Me.btnAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Size = New System.Drawing.Size(101, 22)
        Me.btnAnular.Text = "Anular cuenta"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblConsecutivo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 22)
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
        Me.lblDocumento.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(0, 22)
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
        Me.gbEncabezado.TabIndex = 2
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
        Me.gbMovimiento.Controls.Add(Me.dwCuentaCobro)
        Me.gbMovimiento.Location = New System.Drawing.Point(12, 154)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Size = New System.Drawing.Size(670, 254)
        Me.gbMovimiento.TabIndex = 3
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Movimiento"
        '
        'dwCuentaCobro
        '
        Me.dwCuentaCobro.AllowUserToAddRows = False
        Me.dwCuentaCobro.AllowUserToDeleteRows = False
        Me.dwCuentaCobro.AllowUserToResizeColumns = False
        Me.dwCuentaCobro.AllowUserToResizeRows = False
        Me.dwCuentaCobro.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwCuentaCobro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwCuentaCobro.BackgroundColor = System.Drawing.Color.White
        Me.dwCuentaCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwCuentaCobro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cc_id, Me.cc_idConcepto, Me.cc_concepto, Me.cc_descripcion, Me.cc_undMedida, Me.cc_cantidad, Me.cc_precioUnitario, Me.cc_subtotal, Me.cc_porcRetenido, Me.cc_facturable})
        Me.dwCuentaCobro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwCuentaCobro.ImageList = Nothing
        Me.dwCuentaCobro.Location = New System.Drawing.Point(6, 19)
        Me.dwCuentaCobro.MultiSelect = False
        Me.dwCuentaCobro.Name = "dwCuentaCobro"
        Me.dwCuentaCobro.RowHeadersVisible = False
        Me.dwCuentaCobro.RowHeadersWidth = 20
        Me.dwCuentaCobro.Size = New System.Drawing.Size(658, 229)
        Me.dwCuentaCobro.TabIndex = 14
        '
        'gbTotales
        '
        Me.gbTotales.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTotales.Controls.Add(Me.lblTotal)
        Me.gbTotales.Controls.Add(Me.Label12)
        Me.gbTotales.Controls.Add(Me.lblRetenido)
        Me.gbTotales.Controls.Add(Me.Label10)
        Me.gbTotales.Controls.Add(Me.lblSubtotal)
        Me.gbTotales.Controls.Add(Me.Label7)
        Me.gbTotales.Location = New System.Drawing.Point(458, 414)
        Me.gbTotales.Name = "gbTotales"
        Me.gbTotales.Size = New System.Drawing.Size(224, 95)
        Me.gbTotales.TabIndex = 5
        Me.gbTotales.TabStop = False
        Me.gbTotales.Text = "Totales"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(101, 69)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(25, 13)
        Me.lblTotal.TabIndex = 5
        Me.lblTotal.Text = "000"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(61, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Total:"
        '
        'lblRetenido
        '
        Me.lblRetenido.AutoSize = True
        Me.lblRetenido.Location = New System.Drawing.Point(101, 48)
        Me.lblRetenido.Name = "lblRetenido"
        Me.lblRetenido.Size = New System.Drawing.Size(25, 13)
        Me.lblRetenido.TabIndex = 3
        Me.lblRetenido.Text = "000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(42, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Retenido:"
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Location = New System.Drawing.Point(101, 27)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(25, 13)
        Me.lblSubtotal.TabIndex = 1
        Me.lblSubtotal.Text = "000"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(46, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Subtotal:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 414)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Observaciones"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Enabled = False
        Me.txtObservaciones.Location = New System.Drawing.Point(12, 430)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(440, 79)
        Me.txtObservaciones.TabIndex = 8
        '
        'cc_id
        '
        Me.cc_id.HeaderText = "Id"
        Me.cc_id.ImagenporDefecto = Nothing
        Me.cc_id.Name = "cc_id"
        Me.cc_id.ReadOnly = True
        Me.cc_id.Width = 41
        '
        'cc_idConcepto
        '
        Me.cc_idConcepto.HeaderText = "Id concepto"
        Me.cc_idConcepto.Name = "cc_idConcepto"
        Me.cc_idConcepto.ReadOnly = True
        Me.cc_idConcepto.Visible = False
        Me.cc_idConcepto.Width = 89
        '
        'cc_concepto
        '
        Me.cc_concepto.HeaderText = "Concepto"
        Me.cc_concepto.Name = "cc_concepto"
        Me.cc_concepto.ReadOnly = True
        Me.cc_concepto.Width = 78
        '
        'cc_descripcion
        '
        Me.cc_descripcion.HeaderText = "Descripción"
        Me.cc_descripcion.Name = "cc_descripcion"
        Me.cc_descripcion.ReadOnly = True
        Me.cc_descripcion.Width = 88
        '
        'cc_undMedida
        '
        Me.cc_undMedida.HeaderText = "Unidad medida"
        Me.cc_undMedida.Name = "cc_undMedida"
        Me.cc_undMedida.ReadOnly = True
        Me.cc_undMedida.Width = 103
        '
        'cc_cantidad
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.cc_cantidad.DefaultCellStyle = DataGridViewCellStyle1
        Me.cc_cantidad.HeaderText = "Cantidad"
        Me.cc_cantidad.Name = "cc_cantidad"
        Me.cc_cantidad.ReadOnly = True
        Me.cc_cantidad.Width = 74
        '
        'cc_precioUnitario
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C0"
        Me.cc_precioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.cc_precioUnitario.HeaderText = "Precio unitario"
        Me.cc_precioUnitario.Name = "cc_precioUnitario"
        Me.cc_precioUnitario.ReadOnly = True
        Me.cc_precioUnitario.Width = 99
        '
        'cc_subtotal
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.cc_subtotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.cc_subtotal.HeaderText = "Subtotal"
        Me.cc_subtotal.Name = "cc_subtotal"
        Me.cc_subtotal.ReadOnly = True
        Me.cc_subtotal.Width = 71
        '
        'cc_porcRetenido
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Format = "N2"
        Me.cc_porcRetenido.DefaultCellStyle = DataGridViewCellStyle4
        Me.cc_porcRetenido.HeaderText = "Retenido (%)"
        Me.cc_porcRetenido.Name = "cc_porcRetenido"
        Me.cc_porcRetenido.ReadOnly = True
        Me.cc_porcRetenido.Width = 92
        '
        'cc_facturable
        '
        Me.cc_facturable.HeaderText = "Facturable"
        Me.cc_facturable.Name = "cc_facturable"
        Me.cc_facturable.ReadOnly = True
        Me.cc_facturable.Width = 63
        '
        'frmVistaCuentaCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 521)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.gbTotales)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbEncabezado)
        Me.Controls.Add(Me.tsHerramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVistaCuentaCobro"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vista cuenta cobro orden de trabajo"
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.gbEncabezado.ResumeLayout(False)
        Me.gbEncabezado.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        CType(Me.dwCuentaCobro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTotales.ResumeLayout(False)
        Me.gbTotales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnAnular As ToolStripButton
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
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblRetenido As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblSubtotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dwCuentaCobro As DatagridTreeView.DataTreeGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents cc_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents cc_idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents cc_concepto As DataGridViewTextBoxColumn
    Friend WithEvents cc_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents cc_undMedida As DataGridViewTextBoxColumn
    Friend WithEvents cc_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents cc_precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents cc_subtotal As DataGridViewTextBoxColumn
    Friend WithEvents cc_porcRetenido As DataGridViewTextBoxColumn
    Friend WithEvents cc_facturable As DataGridViewCheckBoxColumn
End Class
