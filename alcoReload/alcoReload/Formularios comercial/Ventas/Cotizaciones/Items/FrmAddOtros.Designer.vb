<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddOtros
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddOtros))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAcabado = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudPiezasxUnidad = New System.Windows.Forms.NumericUpDown()
        Me.itItem = New ControlesPersonalizados.Intellisens.intellises()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbTrabajos = New System.Windows.Forms.GroupBox()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.col_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_idTrabajo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_unMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAgregarTrabajo = New System.Windows.Forms.Button()
        Me.cmbTrabajo = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudfactor = New System.Windows.Forms.NumericUpDown()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPiezasxUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTrabajos.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudfactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(328, 283)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 31)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New System.Drawing.Point(162, 33)
        Me.nudCantidad.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New System.Drawing.Size(67, 20)
        Me.nudCantidad.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cantidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(254, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Acabado"
        '
        'cmbAcabado
        '
        Me.cmbAcabado.DatosVisibles = Nothing
        Me.cmbAcabado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbAcabado.DropDownHeight = 200
        Me.cmbAcabado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAcabado.DropDownWidth = 230
        Me.cmbAcabado.IntegralHeight = False
        Me.cmbAcabado.Location = New System.Drawing.Point(257, 32)
        Me.cmbAcabado.Name = "cmbAcabado"
        Me.cmbAcabado.Size = New System.Drawing.Size(113, 21)
        Me.cmbAcabado.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(409, 283)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 31)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(393, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Piezas por unidad"
        '
        'nudPiezasxUnidad
        '
        Me.nudPiezasxUnidad.DecimalPlaces = 2
        Me.nudPiezasxUnidad.Location = New System.Drawing.Point(396, 32)
        Me.nudPiezasxUnidad.Name = "nudPiezasxUnidad"
        Me.nudPiezasxUnidad.Size = New System.Drawing.Size(67, 20)
        Me.nudPiezasxUnidad.TabIndex = 7
        '
        'itItem
        '
        Me.itItem.AlternativeColumn = Nothing
        Me.itItem.ColToReturn = "Referencia"
        Me.itItem.ColumnsToFilter = New String() {"Referencia", "Descripcion"}
        Me.itItem.ColumnsToShow = New String() {"Referencia", "Descripcion"}
        Me.itItem.Dropdown_Width = 250
        Me.itItem.Id_Column_Name = "Id"
        Me.itItem.Location = New System.Drawing.Point(21, 33)
        Me.itItem.Maximo_Items_DropDown = 5
        Me.itItem.Name = "itItem"
        Me.itItem.selected_item = Nothing
        Me.itItem.Seleted_rowid = Nothing
        Me.itItem.Size = New System.Drawing.Size(113, 20)
        Me.itItem.TabIndex = 1
        Me.itItem.TablaFuente = Nothing
        Me.itItem.Value2 = Nothing
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'gbTrabajos
        '
        Me.gbTrabajos.Controls.Add(Me.dwItems)
        Me.gbTrabajos.Controls.Add(Me.btnAgregarTrabajo)
        Me.gbTrabajos.Controls.Add(Me.cmbTrabajo)
        Me.gbTrabajos.Location = New System.Drawing.Point(20, 98)
        Me.gbTrabajos.Name = "gbTrabajos"
        Me.gbTrabajos.Size = New System.Drawing.Size(464, 176)
        Me.gbTrabajos.TabIndex = 12
        Me.gbTrabajos.TabStop = False
        Me.gbTrabajos.Text = "Servicios"
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_id, Me.col_idTrabajo, Me.col_prefijo, Me.col_descripcion, Me.col_unMedida, Me.col_costo, Me.col_cantidad})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(6, 46)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(437, 124)
        Me.dwItems.TabIndex = 15
        '
        'col_id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.col_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.col_id.HeaderText = "Id"
        Me.col_id.Name = "col_id"
        Me.col_id.ReadOnly = True
        Me.col_id.Visible = False
        Me.col_id.Width = 22
        '
        'col_idTrabajo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        Me.col_idTrabajo.DefaultCellStyle = DataGridViewCellStyle2
        Me.col_idTrabajo.HeaderText = "IdTrabajo"
        Me.col_idTrabajo.Name = "col_idTrabajo"
        Me.col_idTrabajo.ReadOnly = True
        Me.col_idTrabajo.Visible = False
        Me.col_idTrabajo.Width = 58
        '
        'col_prefijo
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        Me.col_prefijo.DefaultCellStyle = DataGridViewCellStyle3
        Me.col_prefijo.HeaderText = "Prefijo"
        Me.col_prefijo.Name = "col_prefijo"
        Me.col_prefijo.ReadOnly = True
        Me.col_prefijo.Width = 61
        '
        'col_descripcion
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro
        Me.col_descripcion.DefaultCellStyle = DataGridViewCellStyle4
        Me.col_descripcion.HeaderText = "Descripción"
        Me.col_descripcion.Name = "col_descripcion"
        Me.col_descripcion.ReadOnly = True
        Me.col_descripcion.Width = 88
        '
        'col_unMedida
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro
        Me.col_unMedida.DefaultCellStyle = DataGridViewCellStyle5
        Me.col_unMedida.HeaderText = "Unidad medida"
        Me.col_unMedida.Name = "col_unMedida"
        Me.col_unMedida.ReadOnly = True
        Me.col_unMedida.Width = 95
        '
        'col_costo
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.col_costo.DefaultCellStyle = DataGridViewCellStyle6
        Me.col_costo.HeaderText = "Costo"
        Me.col_costo.Name = "col_costo"
        Me.col_costo.ReadOnly = True
        Me.col_costo.Width = 59
        '
        'col_cantidad
        '
        Me.col_cantidad.HeaderText = "Cantidad"
        Me.col_cantidad.Name = "col_cantidad"
        Me.col_cantidad.Width = 74
        '
        'btnAgregarTrabajo
        '
        Me.btnAgregarTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarTrabajo.Image = CType(resources.GetObject("btnAgregarTrabajo.Image"), System.Drawing.Image)
        Me.btnAgregarTrabajo.Location = New System.Drawing.Point(178, 19)
        Me.btnAgregarTrabajo.Name = "btnAgregarTrabajo"
        Me.btnAgregarTrabajo.Size = New System.Drawing.Size(21, 21)
        Me.btnAgregarTrabajo.TabIndex = 12
        Me.btnAgregarTrabajo.UseVisualStyleBackColor = True
        '
        'cmbTrabajo
        '
        Me.cmbTrabajo.DatosVisibles = Nothing
        Me.cmbTrabajo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbTrabajo.DropDownHeight = 200
        Me.cmbTrabajo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTrabajo.DropDownWidth = 230
        Me.cmbTrabajo.IntegralHeight = False
        Me.cmbTrabajo.Location = New System.Drawing.Point(6, 19)
        Me.cmbTrabajo.Name = "cmbTrabajo"
        Me.cmbTrabajo.Size = New System.Drawing.Size(166, 21)
        Me.cmbTrabajo.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Factor"
        '
        'nudfactor
        '
        Me.nudfactor.DecimalPlaces = 2
        Me.nudfactor.Location = New System.Drawing.Point(21, 72)
        Me.nudfactor.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudfactor.Name = "nudfactor"
        Me.nudfactor.Size = New System.Drawing.Size(113, 20)
        Me.nudfactor.TabIndex = 35
        Me.nudfactor.ThousandsSeparator = True
        '
        'FrmAddOtros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 325)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.nudfactor)
        Me.Controls.Add(Me.gbTrabajos)
        Me.Controls.Add(Me.itItem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.nudPiezasxUnidad)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbAcabado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudCantidad)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddOtros"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar otros items"
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPiezasxUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTrabajos.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudfactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As Button
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAcabado As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents btnCancelar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents nudPiezasxUnidad As NumericUpDown
    Friend WithEvents itItem As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents gbTrabajos As GroupBox
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents btnAgregarTrabajo As Button
    Friend WithEvents cmbTrabajo As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents col_id As DataGridViewTextBoxColumn
    Friend WithEvents col_idTrabajo As DataGridViewTextBoxColumn
    Friend WithEvents col_prefijo As DataGridViewTextBoxColumn
    Friend WithEvents col_descripcion As DataGridViewTextBoxColumn
    Friend WithEvents col_unMedida As DataGridViewTextBoxColumn
    Friend WithEvents col_costo As DataGridViewTextBoxColumn
    Friend WithEvents col_cantidad As DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents nudfactor As NumericUpDown
End Class
