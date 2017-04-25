<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmmedidasperfileria
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idperfil = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuario_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.spbase = New System.Windows.Forms.SplitContainer()
        Me.spencabe = New System.Windows.Forms.SplitContainer()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtperfil = New ControlesPersonalizados.Intellisens.intellises()
        Me.nuddescuento = New System.Windows.Forms.NumericUpDown()
        Me.nudmedida = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spbase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spbase.Panel1.SuspendLayout()
        Me.spbase.Panel2.SuspendLayout()
        Me.spbase.SuspendLayout()
        CType(Me.spencabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spencabe.Panel1.SuspendLayout()
        Me.spencabe.Panel2.SuspendLayout()
        Me.spencabe.SuspendLayout()
        CType(Me.nuddescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudmedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(271, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Medida (mm)"
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.usuario_creacion, Me.fecha_creacion, Me.idperfil, Me.referencia, Me.medida, Me.descuento, Me.usuario_modificacion, Me.fecha_modificacion, Me.id_estado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 0)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(604, 214)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'usuario_creacion
        '
        Me.usuario_creacion.HeaderText = "Usuario Creacion"
        Me.usuario_creacion.Name = "usuario_creacion"
        Me.usuario_creacion.ReadOnly = True
        Me.usuario_creacion.Width = 104
        '
        'fecha_creacion
        '
        Me.fecha_creacion.HeaderText = "Fecha Creacion"
        Me.fecha_creacion.Name = "fecha_creacion"
        Me.fecha_creacion.ReadOnly = True
        Me.fecha_creacion.Width = 98
        '
        'idperfil
        '
        Me.idperfil.HeaderText = "idperfil"
        Me.idperfil.Name = "idperfil"
        Me.idperfil.ReadOnly = True
        Me.idperfil.Visible = False
        Me.idperfil.Width = 62
        '
        'referencia
        '
        Me.referencia.HeaderText = "Referencia"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Width = 84
        '
        'medida
        '
        Me.medida.HeaderText = "Medida"
        Me.medida.Name = "medida"
        Me.medida.ReadOnly = True
        Me.medida.Width = 67
        '
        'descuento
        '
        Me.descuento.HeaderText = "Descuento"
        Me.descuento.Name = "descuento"
        Me.descuento.ReadOnly = True
        Me.descuento.Width = 84
        '
        'usuario_modificacion
        '
        Me.usuario_modificacion.HeaderText = "Usuario Modificacion"
        Me.usuario_modificacion.Name = "usuario_modificacion"
        Me.usuario_modificacion.ReadOnly = True
        Me.usuario_modificacion.Width = 120
        '
        'fecha_modificacion
        '
        Me.fecha_modificacion.HeaderText = "Fecha Modificacion"
        Me.fecha_modificacion.Name = "fecha_modificacion"
        Me.fecha_modificacion.ReadOnly = True
        Me.fecha_modificacion.Width = 114
        '
        'id_estado
        '
        Me.id_estado.HeaderText = "Id Estado"
        Me.id_estado.Name = "id_estado"
        Me.id_estado.ReadOnly = True
        Me.id_estado.Visible = False
        Me.id_estado.Width = 71
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(604, 77)
        Me.fddFiltros.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Perfil"
        '
        'spbase
        '
        Me.spbase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spbase.Location = New System.Drawing.Point(0, 0)
        Me.spbase.Name = "spbase"
        Me.spbase.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spbase.Panel1
        '
        Me.spbase.Panel1.Controls.Add(Me.spencabe)
        '
        'spbase.Panel2
        '
        Me.spbase.Panel2.Controls.Add(Me.dwItems)
        Me.spbase.Size = New System.Drawing.Size(604, 394)
        Me.spbase.SplitterDistance = 176
        Me.spbase.TabIndex = 12
        '
        'spencabe
        '
        Me.spencabe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spencabe.Location = New System.Drawing.Point(0, 0)
        Me.spencabe.Name = "spencabe"
        Me.spencabe.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spencabe.Panel1
        '
        Me.spencabe.Panel1.Controls.Add(Me.cmbEstado)
        Me.spencabe.Panel1.Controls.Add(Me.Label4)
        Me.spencabe.Panel1.Controls.Add(Me.txtperfil)
        Me.spencabe.Panel1.Controls.Add(Me.nuddescuento)
        Me.spencabe.Panel1.Controls.Add(Me.nudmedida)
        Me.spencabe.Panel1.Controls.Add(Me.Label3)
        Me.spencabe.Panel1.Controls.Add(Me.Label1)
        Me.spencabe.Panel1.Controls.Add(Me.Label2)
        '
        'spencabe.Panel2
        '
        Me.spencabe.Panel2.Controls.Add(Me.fddFiltros)
        Me.spencabe.Size = New System.Drawing.Size(604, 176)
        Me.spencabe.SplitterDistance = 95
        Me.spencabe.TabIndex = 0
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(11, 65)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Estado"
        '
        'txtperfil
        '
        Me.txtperfil.AlternativeColumn = "Referencia"
        Me.txtperfil.ColToReturn = "Referencia"
        Me.txtperfil.ColumnsToFilter = New String() {"Referencia", "Descripcion"}
        Me.txtperfil.ColumnsToShow = New String() {"Referencia", "Descripcion"}
        Me.txtperfil.Dropdown_Width = 500
        Me.txtperfil.Id_Column_Name = "id"
        Me.txtperfil.Location = New System.Drawing.Point(11, 27)
        Me.txtperfil.Maximo_Items_DropDown = 5
        Me.txtperfil.MaxLength = 20
        Me.txtperfil.Name = "txtperfil"
        Me.txtperfil.selected_item = Nothing
        Me.txtperfil.Seleted_rowid = Nothing
        Me.txtperfil.Size = New System.Drawing.Size(215, 20)
        Me.txtperfil.TabIndex = 0
        Me.txtperfil.TablaFuente = Nothing
        Me.txtperfil.Tag = "Nit"
        Me.txtperfil.Value2 = Nothing
        '
        'nuddescuento
        '
        Me.nuddescuento.DecimalPlaces = 2
        Me.nuddescuento.Location = New System.Drawing.Point(441, 27)
        Me.nuddescuento.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nuddescuento.Name = "nuddescuento"
        Me.nuddescuento.Size = New System.Drawing.Size(120, 20)
        Me.nuddescuento.TabIndex = 2
        '
        'nudmedida
        '
        Me.nudmedida.Location = New System.Drawing.Point(274, 27)
        Me.nudmedida.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudmedida.Name = "nudmedida"
        Me.nudmedida.Size = New System.Drawing.Size(120, 20)
        Me.nudmedida.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(438, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Descuento (mm)"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Frmmedidasperfileria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 394)
        Me.Controls.Add(Me.spbase)
        Me.Name = "Frmmedidasperfileria"
        Me.ShowIcon = False
        Me.Text = "Medidas Perfileria"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spbase.Panel1.ResumeLayout(False)
        Me.spbase.Panel2.ResumeLayout(False)
        CType(Me.spbase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spbase.ResumeLayout(False)
        Me.spencabe.Panel1.ResumeLayout(False)
        Me.spencabe.Panel1.PerformLayout()
        Me.spencabe.Panel2.ResumeLayout(False)
        CType(Me.spencabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spencabe.ResumeLayout(False)
        CType(Me.nuddescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudmedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label1 As Label
    Friend WithEvents spbase As SplitContainer
    Friend WithEvents spencabe As SplitContainer
    Friend WithEvents Label3 As Label
    Friend WithEvents nuddescuento As NumericUpDown
    Friend WithEvents nudmedida As NumericUpDown
    Friend WithEvents txtperfil As ControlesPersonalizados.Intellisens.intellises
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents usuario_creacion As DataGridViewTextBoxColumn
    Friend WithEvents fecha_creacion As DataGridViewTextBoxColumn
    Friend WithEvents idperfil As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents medida As DataGridViewTextBoxColumn
    Friend WithEvents descuento As DataGridViewTextBoxColumn
    Friend WithEvents usuario_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents fecha_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents id_estado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
