<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoRetenidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoRetenidos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbEncargado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbDocumentos = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.dwItems = New DatagridTreeView.DataTreeGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblTotalPagado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblValorPagar = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.col_id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.col_idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_encargado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_obraFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_totalCuentas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_retenido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorPagado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorPendiente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_valorPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_directa = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.col_insertar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEncargado
        '
        Me.cmbEncargado.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbEncargado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEncargado.DropDownHeight = 200
        Me.cmbEncargado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEncargado.DropDownWidth = 300
        Me.cmbEncargado.IntegralHeight = False
        Me.cmbEncargado.Location = New System.Drawing.Point(454, 40)
        Me.cmbEncargado.Name = "cmbEncargado"
        Me.cmbEncargado.Size = New System.Drawing.Size(188, 21)
        Me.cmbEncargado.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(451, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Encargado"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbProveedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbProveedor.DropDownHeight = 200
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.DropDownWidth = 300
        Me.cmbProveedor.IntegralHeight = False
        Me.cmbProveedor.Location = New System.Drawing.Point(238, 40)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(188, 21)
        Me.cmbProveedor.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(235, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Proveedor"
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.AutoSize = True
        Me.lblConsecutivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsecutivo.Location = New System.Drawing.Point(128, 40)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(0, 15)
        Me.lblConsecutivo.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(128, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Consecutivo"
        '
        'cmbDocumentos
        '
        Me.cmbDocumentos.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbDocumentos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbDocumentos.DropDownHeight = 200
        Me.cmbDocumentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDocumentos.DropDownWidth = 300
        Me.cmbDocumentos.IntegralHeight = False
        Me.cmbDocumentos.Location = New System.Drawing.Point(23, 40)
        Me.cmbDocumentos.Name = "cmbDocumentos"
        Me.cmbDocumentos.Size = New System.Drawing.Size(77, 21)
        Me.cmbDocumentos.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Documento"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(666, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(48, 38)
        Me.btnBuscar.TabIndex = 16
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel.Controls.Add(Me.ToolStrip2)
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 78)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(884, 399)
        Me.Panel.TabIndex = 17
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(882, 25)
        Me.ToolStrip2.TabIndex = 15
        Me.ToolStrip2.Text = "ToolStrip2"
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_idDocumento, Me.col_documento, Me.col_consecutivo, Me.col_proveedor, Me.col_encargado, Me.col_codigoObra, Me.col_obraFecha, Me.col_vendedor, Me.col_totalCuentas, Me.col_retenido, Me.col_valorPagado, Me.col_valorPendiente, Me.col_valorPagar, Me.col_directa, Me.col_insertar})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 28)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.RowHeadersWidth = 20
        Me.dwItems.Size = New System.Drawing.Size(876, 366)
        Me.dwItems.TabIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotalPagado, Me.ToolStripLabel3, Me.ToolStripSeparator1, Me.lblValorPagar, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 480)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(908, 25)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblTotalPagado
        '
        Me.lblTotalPagado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTotalPagado.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalPagado.Name = "lblTotalPagado"
        Me.lblTotalPagado.Size = New System.Drawing.Size(0, 22)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.ActiveLinkColor = System.Drawing.Color.Red
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(76, 22)
        Me.ToolStripLabel3.Text = "Total pagado"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblValorPagar
        '
        Me.lblValorPagar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblValorPagar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblValorPagar.Name = "lblValorPagar"
        Me.lblValorPagar.Size = New System.Drawing.Size(41, 22)
        Me.lblValorPagar.Text = "7800"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripLabel1.Text = "Valor a pagar"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'col_id
        '
        Me.col_id.HeaderText = "Id"
        Me.col_id.ImagenporDefecto = Nothing
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Width = 41
        '
        'col_idDocumento
        '
        Me.col_idDocumento.HeaderText = "Id documento"
        Me.col_idDocumento.Name = "col_idDocumento"
        Me.col_idDocumento.ReadOnly = True
        Me.col_idDocumento.Visible = False
        Me.col_idDocumento.Width = 97
        '
        'col_documento
        '
        Me.col_documento.HeaderText = "Documento"
        Me.col_documento.Name = "col_documento"
        Me.col_documento.ReadOnly = True
        Me.col_documento.Width = 87
        '
        'col_consecutivo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        Me.col_consecutivo.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_consecutivo.HeaderText = "Consecutivo"
        Me.col_consecutivo.Name = "col_consecutivo"
        Me.col_consecutivo.ReadOnly = True
        Me.col_consecutivo.Width = 91
        '
        'col_proveedor
        '
        Me.col_proveedor.HeaderText = "Proveedor"
        Me.col_proveedor.Name = "col_proveedor"
        Me.col_proveedor.ReadOnly = True
        Me.col_proveedor.Width = 81
        '
        'col_encargado
        '
        Me.col_encargado.HeaderText = "Encargado"
        Me.col_encargado.Name = "col_encargado"
        Me.col_encargado.ReadOnly = True
        Me.col_encargado.Width = 84
        '
        'col_codigoObra
        '
        Me.col_codigoObra.HeaderText = "Código obra"
        Me.col_codigoObra.Name = "col_codigoObra"
        Me.col_codigoObra.ReadOnly = True
        Me.col_codigoObra.Width = 89
        '
        'col_obraFecha
        '
        Me.col_obraFecha.HeaderText = "Obra/Fecha"
        Me.col_obraFecha.Name = "col_obraFecha"
        Me.col_obraFecha.ReadOnly = True
        Me.col_obraFecha.Width = 90
        '
        'col_vendedor
        '
        Me.col_vendedor.HeaderText = "Vendedor"
        Me.col_vendedor.Name = "col_vendedor"
        Me.col_vendedor.ReadOnly = True
        Me.col_vendedor.Width = 78
        '
        'col_totalCuentas
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C0"
        Me.col_totalCuentas.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_totalCuentas.HeaderText = "Total cuentas"
        Me.col_totalCuentas.Name = "col_totalCuentas"
        Me.col_totalCuentas.ReadOnly = True
        Me.col_totalCuentas.Width = 97
        '
        'col_retenido
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C0"
        Me.col_retenido.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_retenido.HeaderText = "Retenido"
        Me.col_retenido.Name = "col_retenido"
        Me.col_retenido.ReadOnly = True
        Me.col_retenido.Width = 75
        '
        'col_valorPagado
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        Me.col_valorPagado.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_valorPagado.HeaderText = "Valor pagado"
        Me.col_valorPagado.Name = "col_valorPagado"
        Me.col_valorPagado.ReadOnly = True
        Me.col_valorPagado.Width = 95
        '
        'col_valorPendiente
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        Me.col_valorPendiente.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_valorPendiente.HeaderText = "Valor pendiente"
        Me.col_valorPendiente.Name = "col_valorPendiente"
        Me.col_valorPendiente.ReadOnly = True
        Me.col_valorPendiente.Width = 106
        '
        'col_valorPagar
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.col_valorPagar.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_valorPagar.HeaderText = "Valor a pagar"
        Me.col_valorPagar.Name = "col_valorPagar"
        Me.col_valorPagar.ReadOnly = True
        Me.col_valorPagar.Width = 95
        '
        'col_directa
        '
        Me.col_directa.HeaderText = "Directa"
        Me.col_directa.Name = "col_directa"
        Me.col_directa.ReadOnly = True
        Me.col_directa.Width = 47
        '
        'col_insertar
        '
        Me.col_insertar.HeaderText = "Insertar"
        Me.col_insertar.Name = "col_insertar"
        Me.col_insertar.ReadOnly = True
        Me.col_insertar.Visible = False
        Me.col_insertar.Width = 48
        '
        'frmPagoRetenidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(908, 505)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.cmbEncargado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblConsecutivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbDocumentos)
        Me.Controls.Add(Me.Label5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPagoRetenidos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Pago retenidos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel.ResumeLayout(False)
        Me.Panel.PerformLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbEncargado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbProveedor As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label3 As Label
    Friend WithEvents lblConsecutivo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDocumentos As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label5 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Panel As Panel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lblTotalPagado As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lblValorPagar As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents dwItems As DatagridTreeView.DataTreeGridView
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents col_id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents col_idDocumento As DataGridViewTextBoxColumn
    Friend WithEvents col_documento As DataGridViewTextBoxColumn
    Friend WithEvents col_consecutivo As DataGridViewTextBoxColumn
    Friend WithEvents col_proveedor As DataGridViewTextBoxColumn
    Friend WithEvents col_encargado As DataGridViewTextBoxColumn
    Friend WithEvents col_codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents col_obraFecha As DataGridViewTextBoxColumn
    Friend WithEvents col_vendedor As DataGridViewTextBoxColumn
    Friend WithEvents col_totalCuentas As DataGridViewTextBoxColumn
    Friend WithEvents col_retenido As DataGridViewTextBoxColumn
    Friend WithEvents col_valorPagado As DataGridViewTextBoxColumn
    Friend WithEvents col_valorPendiente As DataGridViewTextBoxColumn
    Friend WithEvents col_valorPagar As DataGridViewTextBoxColumn
    Friend WithEvents col_directa As DataGridViewCheckBoxColumn
    Friend WithEvents col_insertar As DataGridViewCheckBoxColumn
End Class
