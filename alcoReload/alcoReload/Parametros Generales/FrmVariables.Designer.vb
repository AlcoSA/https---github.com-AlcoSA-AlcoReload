<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVariables
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoDato = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbdesdebd = New System.Windows.Forms.CheckBox()
        Me.cbusopredeterminado = New System.Windows.Forms.CheckBox()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudorden = New System.Windows.Forms.NumericUpDown()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_TipoDato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Dato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Modifiacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Modifiacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor_Desde_BD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Uso_Predeterminado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Edicion_Produccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Imprimir = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Orden = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.gbValores = New System.Windows.Forms.GroupBox()
        Me.chbimprimir = New System.Windows.Forms.CheckBox()
        Me.cbedicionproduccion = New System.Windows.Forms.CheckBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudorden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbValores.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Estado"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(15, 30)
        Me.txtnombre.MaxLength = 15
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(128, 20)
        Me.txtnombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(15, 70)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(222, 20)
        Me.txtDescripcion.TabIndex = 5
        Me.txtDescripcion.Text = " "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Descripción"
        '
        'cmbTipoDato
        '
        Me.cmbTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDato.FormattingEnabled = True
        Me.cmbTipoDato.Location = New System.Drawing.Point(171, 29)
        Me.cmbTipoDato.Name = "cmbTipoDato"
        Me.cmbTipoDato.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipoDato.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(168, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tipo de dato"
        '
        'cbdesdebd
        '
        Me.cbdesdebd.AutoSize = True
        Me.cbdesdebd.Location = New System.Drawing.Point(11, 21)
        Me.cbdesdebd.Name = "cbdesdebd"
        Me.cbdesdebd.Size = New System.Drawing.Size(119, 17)
        Me.cbdesdebd.TabIndex = 11
        Me.cbdesdebd.Tag = ""
        Me.cbdesdebd.Text = "Valores Base Datos"
        Me.cbdesdebd.UseVisualStyleBackColor = True
        '
        'cbusopredeterminado
        '
        Me.cbusopredeterminado.AutoSize = True
        Me.cbusopredeterminado.Location = New System.Drawing.Point(147, 21)
        Me.cbusopredeterminado.Name = "cbusopredeterminado"
        Me.cbusopredeterminado.Size = New System.Drawing.Size(122, 17)
        Me.cbusopredeterminado.TabIndex = 12
        Me.cbusopredeterminado.Tag = ""
        Me.cbusopredeterminado.Text = "Uso Predeterminado"
        Me.cbusopredeterminado.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Orden"
        '
        'nudorden
        '
        Me.nudorden.Location = New System.Drawing.Point(263, 70)
        Me.nudorden.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudorden.Name = "nudorden"
        Me.nudorden.Size = New System.Drawing.Size(68, 20)
        Me.nudorden.TabIndex = 7
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 155)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(615, 250)
        Me.Panel.TabIndex = 13
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha_Creacion, Me.Usuario_Creacion, Me.Nombre_Variable, Me.Descripcion, Me.Id_TipoDato, Me.Tipo_Dato, Me.Fecha_Modifiacion, Me.Usuario_Modifiacion, Me.Id_Estado, Me.Estado, Me.Valor_Desde_BD, Me.Uso_Predeterminado, Me.Edicion_Produccion, Me.Imprimir, Me.Orden})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 110)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(605, 133)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 22
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        Me.Fecha_Creacion.Width = 97
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        Me.Usuario_Creacion.Width = 103
        '
        'Nombre_Variable
        '
        Me.Nombre_Variable.HeaderText = "Nombre variable"
        Me.Nombre_Variable.Name = "Nombre_Variable"
        Me.Nombre_Variable.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Id_TipoDato
        '
        Me.Id_TipoDato.HeaderText = "Id tipo dato"
        Me.Id_TipoDato.Name = "Id_TipoDato"
        Me.Id_TipoDato.ReadOnly = True
        Me.Id_TipoDato.Visible = False
        Me.Id_TipoDato.Width = 78
        '
        'Tipo_Dato
        '
        Me.Tipo_Dato.HeaderText = "Tipo de dato"
        Me.Tipo_Dato.Name = "Tipo_Dato"
        Me.Tipo_Dato.ReadOnly = True
        Me.Tipo_Dato.Width = 85
        '
        'Fecha_Modifiacion
        '
        Me.Fecha_Modifiacion.HeaderText = "Fecha modificación"
        Me.Fecha_Modifiacion.Name = "Fecha_Modifiacion"
        Me.Fecha_Modifiacion.ReadOnly = True
        Me.Fecha_Modifiacion.Width = 114
        '
        'Usuario_Modifiacion
        '
        Me.Usuario_Modifiacion.HeaderText = "Usuario modificación"
        Me.Usuario_Modifiacion.Name = "Usuario_Modifiacion"
        Me.Usuario_Modifiacion.ReadOnly = True
        Me.Usuario_Modifiacion.Width = 119
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Id_Estado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 51
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Valor_Desde_BD
        '
        Me.Valor_Desde_BD.HeaderText = "Valor base datos"
        Me.Valor_Desde_BD.Name = "Valor_Desde_BD"
        Me.Valor_Desde_BD.ReadOnly = True
        Me.Valor_Desde_BD.Width = 83
        '
        'Uso_Predeterminado
        '
        Me.Uso_Predeterminado.HeaderText = "Uso predeterminado"
        Me.Uso_Predeterminado.Name = "Uso_Predeterminado"
        Me.Uso_Predeterminado.ReadOnly = True
        Me.Uso_Predeterminado.Width = 97
        '
        'Edicion_Produccion
        '
        Me.Edicion_Produccion.HeaderText = "Edicion"
        Me.Edicion_Produccion.Name = "Edicion_Produccion"
        Me.Edicion_Produccion.ReadOnly = True
        Me.Edicion_Produccion.Width = 48
        '
        'Imprimir
        '
        Me.Imprimir.HeaderText = "Imprimir"
        Me.Imprimir.Name = "Imprimir"
        Me.Imprimir.ReadOnly = True
        Me.Imprimir.Width = 48
        '
        'Orden
        '
        Me.Orden.HeaderText = "Orden"
        Me.Orden.Name = "Orden"
        Me.Orden.ReadOnly = True
        Me.Orden.Width = 61
        '
        'fddFiltros
        '
        Me.fddFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(605, 101)
        Me.fddFiltros.TabIndex = 0
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(15, 118)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 14
        '
        'gbValores
        '
        Me.gbValores.Controls.Add(Me.chbimprimir)
        Me.gbValores.Controls.Add(Me.cbedicionproduccion)
        Me.gbValores.Controls.Add(Me.cbdesdebd)
        Me.gbValores.Controls.Add(Me.cbusopredeterminado)
        Me.gbValores.Location = New System.Drawing.Point(160, 100)
        Me.gbValores.Name = "gbValores"
        Me.gbValores.Size = New System.Drawing.Size(465, 52)
        Me.gbValores.TabIndex = 15
        Me.gbValores.TabStop = False
        Me.gbValores.Text = "Tipo de valores"
        '
        'chbimprimir
        '
        Me.chbimprimir.AutoSize = True
        Me.chbimprimir.Location = New System.Drawing.Point(399, 18)
        Me.chbimprimir.Name = "chbimprimir"
        Me.chbimprimir.Size = New System.Drawing.Size(61, 17)
        Me.chbimprimir.TabIndex = 14
        Me.chbimprimir.Tag = ""
        Me.chbimprimir.Text = "Imprimir"
        Me.chbimprimir.UseVisualStyleBackColor = True
        '
        'cbedicionproduccion
        '
        Me.cbedicionproduccion.AutoSize = True
        Me.cbedicionproduccion.Location = New System.Drawing.Point(275, 19)
        Me.cbedicionproduccion.Name = "cbedicionproduccion"
        Me.cbedicionproduccion.Size = New System.Drawing.Size(118, 17)
        Me.cbedicionproduccion.TabIndex = 13
        Me.cbedicionproduccion.Tag = ""
        Me.cbedicionproduccion.Text = "Edicion Producción"
        Me.cbedicionproduccion.UseVisualStyleBackColor = True
        '
        'FrmVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 417)
        Me.Controls.Add(Me.gbValores)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.nudorden)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbTipoDato)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmVariables"
        Me.ShowIcon = False
        Me.Text = "Variables"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudorden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbValores.ResumeLayout(False)
        Me.gbValores.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtnombre As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDato As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbdesdebd As CheckBox
    Friend WithEvents cbusopredeterminado As CheckBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents nudorden As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents gbValores As GroupBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents cbedicionproduccion As CheckBox
    Friend WithEvents chbimprimir As CheckBox
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Variable As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Id_TipoDato As DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Dato As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Modifiacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Modifiacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Valor_Desde_BD As DataGridViewCheckBoxColumn
    Friend WithEvents Uso_Predeterminado As DataGridViewCheckBoxColumn
    Friend WithEvents Edicion_Produccion As DataGridViewCheckBoxColumn
    Friend WithEvents Imprimir As DataGridViewCheckBoxColumn
    Friend WithEvents Orden As DataGridViewTextBoxColumn
End Class
