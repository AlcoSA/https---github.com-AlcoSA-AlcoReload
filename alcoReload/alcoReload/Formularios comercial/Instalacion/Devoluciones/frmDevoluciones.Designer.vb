<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevoluciones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDocumentos = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbEncabezadoCCobro = New System.Windows.Forms.GroupBox()
        Me.txtConsecutivoCCobro = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDocumentoCCobro = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaCreacion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEncargado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObra = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.col_idMovito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidadDisponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorDisponible = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantDevolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorDevolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Insertar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gbEncabezadoCCobro.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Documento"
        '
        'cmbDocumentos
        '
        Me.cmbDocumentos.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbDocumentos.DropDownHeight = 200
        Me.cmbDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentos.DropDownWidth = 300
        Me.cmbDocumentos.IntegralHeight = False
        Me.cmbDocumentos.Location = New System.Drawing.Point(35, 29)
        Me.cmbDocumentos.Name = "cmbDocumentos"
        Me.cmbDocumentos.Size = New System.Drawing.Size(80, 21)
        Me.cmbDocumentos.TabIndex = 2
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.Location = New System.Drawing.Point(153, 29)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 15)
        Me.lblConsecutivo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(153, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Consecutivo"
        '
        'gbEncabezadoCCobro
        '
        Me.gbEncabezadoCCobro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtConsecutivoCCobro)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label9)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtDocumentoCCobro)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label8)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtFechaCreacion)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label5)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtEncargado)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label3)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtProveedor)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label4)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtVendedor)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label6)
        Me.gbEncabezadoCCobro.Controls.Add(Me.txtObra)
        Me.gbEncabezadoCCobro.Controls.Add(Me.Label7)
        Me.gbEncabezadoCCobro.Location = New System.Drawing.Point(12, 64)
        Me.gbEncabezadoCCobro.Name = "gbEncabezadoCCobro"
        Me.gbEncabezadoCCobro.Size = New System.Drawing.Size(861, 172)
        Me.gbEncabezadoCCobro.TabIndex = 6
        Me.gbEncabezadoCCobro.TabStop = False
        Me.gbEncabezadoCCobro.Text = "Encabezado cuenta de cobro"
        '
        'txtConsecutivoCCobro
        '
        Me.txtConsecutivoCCobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConsecutivoCCobro.Enabled = False
        Me.txtConsecutivoCCobro.Location = New System.Drawing.Point(144, 42)
        Me.txtConsecutivoCCobro.Name = "txtConsecutivoCCobro"
        Me.txtConsecutivoCCobro.Size = New System.Drawing.Size(80, 20)
        Me.txtConsecutivoCCobro.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(141, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Consecutivo"
        '
        'txtDocumentoCCobro
        '
        Me.txtDocumentoCCobro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDocumentoCCobro.Enabled = False
        Me.txtDocumentoCCobro.Location = New System.Drawing.Point(23, 42)
        Me.txtDocumentoCCobro.Name = "txtDocumentoCCobro"
        Me.txtDocumentoCCobro.Size = New System.Drawing.Size(80, 20)
        Me.txtDocumentoCCobro.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Documento"
        '
        'txtFechaCreacion
        '
        Me.txtFechaCreacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaCreacion.Enabled = False
        Me.txtFechaCreacion.Location = New System.Drawing.Point(442, 90)
        Me.txtFechaCreacion.Name = "txtFechaCreacion"
        Me.txtFechaCreacion.Size = New System.Drawing.Size(131, 20)
        Me.txtFechaCreacion.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(439, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fecha creación"
        '
        'txtEncargado
        '
        Me.txtEncargado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEncargado.Enabled = False
        Me.txtEncargado.Location = New System.Drawing.Point(336, 133)
        Me.txtEncargado.Name = "txtEncargado"
        Me.txtEncargado.Size = New System.Drawing.Size(289, 20)
        Me.txtEncargado.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(333, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Encargado"
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Enabled = False
        Me.txtProveedor.Location = New System.Drawing.Point(23, 134)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(289, 20)
        Me.txtProveedor.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Proveedor"
        '
        'txtVendedor
        '
        Me.txtVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVendedor.Enabled = False
        Me.txtVendedor.Location = New System.Drawing.Point(336, 90)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.Size = New System.Drawing.Size(80, 20)
        Me.txtVendedor.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(333, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Vendedor"
        '
        'txtObra
        '
        Me.txtObra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObra.Enabled = False
        Me.txtObra.Location = New System.Drawing.Point(23, 90)
        Me.txtObra.Name = "txtObra"
        Me.txtObra.Size = New System.Drawing.Size(289, 20)
        Me.txtObra.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Obra"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 242)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(861, 237)
        Me.Panel.TabIndex = 7
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idMovito, Me.col_idConcepto, Me.col_concepto, Me.col_unidadMedida, Me.col_cantidad, Me.col_valor, Me.col_total, Me.col_cantidadDisponible, Me.col_valorDisponible, Me.col_cantDevolucion, Me.col_valorDevolucion, Me.col_Insertar})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(829, 227)
        Me.dwItems.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'col_idMovito
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idMovito.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_idMovito.HeaderText = "Id movito"
        Me.col_idMovito.Name = "col_idMovito"
        Me.col_idMovito.ReadOnly = True
        Me.col_idMovito.Visible = False
        Me.col_idMovito.Width = 56
        '
        'col_idConcepto
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idConcepto.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_idConcepto.HeaderText = "Id concepto"
        Me.col_idConcepto.Name = "col_idConcepto"
        Me.col_idConcepto.ReadOnly = True
        Me.col_idConcepto.Visible = False
        Me.col_idConcepto.Width = 70
        '
        'col_concepto
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.col_concepto.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_concepto.HeaderText = "Concepto"
        Me.col_concepto.Name = "col_concepto"
        Me.col_concepto.ReadOnly = True
        Me.col_concepto.Width = 78
        '
        'col_unidadMedida
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.col_unidadMedida.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_unidadMedida.HeaderText = "Unidad medida"
        Me.col_unidadMedida.Name = "col_unidadMedida"
        Me.col_unidadMedida.ReadOnly = True
        Me.col_unidadMedida.Width = 95
        '
        'col_cantidad
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle5.Format = "N0"
        Me.col_cantidad.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_cantidad.HeaderText = "Cantidad"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.ReadOnly = True
        Me.col_cantidad.Width = 74
        '
        'col_valor
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle6.Format = "C0"
        Me.col_valor.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_valor.HeaderText = "Valor"
        Me.col_valor.Name = "col_valor"
        Me.col_valor.ReadOnly = True
        Me.col_valor.Width = 56
        '
        'col_total
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Format = "C0"
        Me.col_total.DefaultCellStyle = DataGridViewCellStyle7
        Me.col_total.HeaderText = "Total"
        Me.col_total.Name = "col_total"
        Me.col_total.ReadOnly = True
        Me.col_total.Width = 56
        '
        'col_cantidadDisponible
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Format = "N0"
        Me.col_cantidadDisponible.DefaultCellStyle = DataGridViewCellStyle8
        Me.col_cantidadDisponible.HeaderText = "Cantidad disponible"
        Me.col_cantidadDisponible.Name = "col_cantidadDisponible"
        Me.col_cantidadDisponible.ReadOnly = True
        Me.col_cantidadDisponible.Width = 114
        '
        'col_valorDisponible
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle9.Format = "C0"
        Me.col_valorDisponible.DefaultCellStyle = DataGridViewCellStyle9
        Me.col_valorDisponible.HeaderText = "Valor disponible"
        Me.col_valorDisponible.Name = "col_valorDisponible"
        Me.col_valorDisponible.ReadOnly = True
        Me.col_valorDisponible.Width = 97
        '
        'col_cantDevolucion
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0"
        Me.col_cantDevolucion.DefaultCellStyle = DataGridViewCellStyle10
        Me.col_cantDevolucion.HeaderText = "Cantidad a devolver"
        Me.col_cantDevolucion.Name = "col_cantDevolucion"
        Me.col_cantDevolucion.Width = 116
        '
        'col_valorDevolucion
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.col_valorDevolucion.DefaultCellStyle = DataGridViewCellStyle11
        Me.col_valorDevolucion.HeaderText = "Valor a devolver"
        Me.col_valorDevolucion.Name = "col_valorDevolucion"
        '
        'col_Insertar
        '
        Me.col_Insertar.HeaderText = "Insertar"
        Me.col_Insertar.Name = "col_Insertar"
        Me.col_Insertar.ReadOnly = True
        Me.col_Insertar.Width = 48
        '
        'frmDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 491)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.gbEncabezadoCCobro)
        Me.Controls.Add(Me.lblConsecutivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbDocumentos)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDevoluciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Devoluciones"
        Me.gbEncabezadoCCobro.ResumeLayout(False)
        Me.gbEncabezadoCCobro.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbDocumentos As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents gbEncabezadoCCobro As GroupBox
    Friend WithEvents txtConsecutivoCCobro As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDocumentoCCobro As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtFechaCreacion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtEncargado As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtProveedor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtObra As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents col_idMovito As DataGridViewTextBoxColumn
    Friend WithEvents col_idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents col_concepto As DataGridViewTextBoxColumn
    Friend WithEvents col_unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents col_valor As DataGridViewTextBoxColumn
    Friend WithEvents col_total As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidadDisponible As DataGridViewTextBoxColumn
    Friend WithEvents col_valorDisponible As DataGridViewTextBoxColumn
    Friend WithEvents col_cantDevolucion As DataGridViewTextBoxColumn
    Friend WithEvents col_valorDevolucion As DataGridViewTextBoxColumn
    Friend WithEvents col_Insertar As DataGridViewCheckBoxColumn
End Class
