<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPropiedadesMasicas
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdescripcion = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudinercia = New System.Windows.Forms.NumericUpDown()
        Me.nudmoduloseccion = New System.Windows.Forms.NumericUpDown()
        Me.eppropiedades = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.spcontenedor = New System.Windows.Forms.SplitContainer()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.gpmodelos = New System.Windows.Forms.GroupBox()
        Me.dwmodelos = New System.Windows.Forms.DataGridView()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Inercia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo_Seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Modi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Modi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.utilizar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idcombinacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmodelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idpropiedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.propiedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.nudinercia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudmoduloseccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.eppropiedades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spcontenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcontenedor.Panel1.SuspendLayout()
        Me.spcontenedor.Panel2.SuspendLayout()
        Me.spcontenedor.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpmodelos.SuspendLayout()
        CType(Me.dwmodelos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Estado"
        '
        'txtdescripcion
        '
        Me.txtdescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescripcion.Location = New System.Drawing.Point(15, 67)
        Me.txtdescripcion.MaxLength = 100
        Me.txtdescripcion.Name = "txtdescripcion"
        Me.txtdescripcion.Size = New System.Drawing.Size(321, 20)
        Me.txtdescripcion.TabIndex = 45
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 50)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(63, 13)
        Me.label2.TabIndex = 49
        Me.label2.Text = "Descripción"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(15, 27)
        Me.txtnombre.MaxLength = 50
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(149, 20)
        Me.txtnombre.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(133, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Modulo Sección"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Inercia"
        '
        'nudinercia
        '
        Me.nudinercia.DecimalPlaces = 2
        Me.nudinercia.Location = New System.Drawing.Point(15, 109)
        Me.nudinercia.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.nudinercia.Name = "nudinercia"
        Me.nudinercia.Size = New System.Drawing.Size(101, 20)
        Me.nudinercia.TabIndex = 53
        '
        'nudmoduloseccion
        '
        Me.nudmoduloseccion.DecimalPlaces = 2
        Me.nudmoduloseccion.Location = New System.Drawing.Point(136, 109)
        Me.nudmoduloseccion.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.nudmoduloseccion.Name = "nudmoduloseccion"
        Me.nudmoduloseccion.Size = New System.Drawing.Size(101, 20)
        Me.nudmoduloseccion.TabIndex = 54
        '
        'eppropiedades
        '
        Me.eppropiedades.ContainerControl = Me
        '
        'spcontenedor
        '
        Me.spcontenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcontenedor.Location = New System.Drawing.Point(0, 0)
        Me.spcontenedor.Name = "spcontenedor"
        '
        'spcontenedor.Panel1
        '
        Me.spcontenedor.Panel1.Controls.Add(Me.Panel)
        Me.spcontenedor.Panel1.Controls.Add(Me.cmbEstado)
        Me.spcontenedor.Panel1.Controls.Add(Me.Label1)
        Me.spcontenedor.Panel1.Controls.Add(Me.nudmoduloseccion)
        Me.spcontenedor.Panel1.Controls.Add(Me.txtnombre)
        Me.spcontenedor.Panel1.Controls.Add(Me.nudinercia)
        Me.spcontenedor.Panel1.Controls.Add(Me.label2)
        Me.spcontenedor.Panel1.Controls.Add(Me.Label5)
        Me.spcontenedor.Panel1.Controls.Add(Me.txtdescripcion)
        Me.spcontenedor.Panel1.Controls.Add(Me.Label4)
        Me.spcontenedor.Panel1.Controls.Add(Me.Label3)
        '
        'spcontenedor.Panel2
        '
        Me.spcontenedor.Panel2.Controls.Add(Me.gpmodelos)
        Me.spcontenedor.Panel2.Padding = New System.Windows.Forms.Padding(5, 10, 5, 5)
        Me.spcontenedor.Size = New System.Drawing.Size(809, 426)
        Me.spcontenedor.SplitterDistance = 592
        Me.spcontenedor.TabIndex = 55
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 175)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(577, 239)
        Me.Panel.TabIndex = 56
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Usuario_Creacion, Me.Fecha_Creacion, Me.Nombre, Me.Descripcion, Me.Inercia, Me.Modulo_Seccion, Me.Usuario_Modi, Me.Fecha_Modi, Me.Id_Estado, Me.Estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 110)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(567, 122)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fddFiltros
        '
        Me.fddFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(567, 101)
        Me.fddFiltros.TabIndex = 0
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(15, 148)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 55
        '
        'gpmodelos
        '
        Me.gpmodelos.Controls.Add(Me.dwmodelos)
        Me.gpmodelos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpmodelos.Location = New System.Drawing.Point(5, 10)
        Me.gpmodelos.Name = "gpmodelos"
        Me.gpmodelos.Size = New System.Drawing.Size(203, 411)
        Me.gpmodelos.TabIndex = 0
        Me.gpmodelos.TabStop = False
        Me.gpmodelos.Text = "Modelos"
        '
        'dwmodelos
        '
        Me.dwmodelos.AllowUserToAddRows = False
        Me.dwmodelos.AllowUserToDeleteRows = False
        Me.dwmodelos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwmodelos.BackgroundColor = System.Drawing.Color.White
        Me.dwmodelos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwmodelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwmodelos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.utilizar, Me.idcombinacion, Me.idmodelo, Me.idpropiedad, Me.modelo, Me.propiedad})
        Me.dwmodelos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwmodelos.Location = New System.Drawing.Point(3, 16)
        Me.dwmodelos.Name = "dwmodelos"
        Me.dwmodelos.RowHeadersVisible = False
        Me.dwmodelos.Size = New System.Drawing.Size(197, 392)
        Me.dwmodelos.TabIndex = 0
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 41
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        Me.Usuario_Creacion.Width = 103
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        Me.Fecha_Creacion.Width = 97
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 69
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Inercia
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N2"
        Me.Inercia.DefaultCellStyle = DataGridViewCellStyle1
        Me.Inercia.HeaderText = "Inercia"
        Me.Inercia.Name = "Inercia"
        Me.Inercia.ReadOnly = True
        Me.Inercia.Width = 64
        '
        'Modulo_Seccion
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        Me.Modulo_Seccion.DefaultCellStyle = DataGridViewCellStyle2
        Me.Modulo_Seccion.HeaderText = "Módulo sección"
        Me.Modulo_Seccion.Name = "Modulo_Seccion"
        Me.Modulo_Seccion.ReadOnly = True
        Me.Modulo_Seccion.Width = 98
        '
        'Usuario_Modi
        '
        Me.Usuario_Modi.HeaderText = "Usuario modificación"
        Me.Usuario_Modi.Name = "Usuario_Modi"
        Me.Usuario_Modi.ReadOnly = True
        Me.Usuario_Modi.Width = 119
        '
        'Fecha_Modi
        '
        Me.Fecha_Modi.HeaderText = "Fecha modificación"
        Me.Fecha_Modi.Name = "Fecha_Modi"
        Me.Fecha_Modi.ReadOnly = True
        Me.Fecha_Modi.Width = 114
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 70
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'utilizar
        '
        Me.utilizar.HeaderText = "..."
        Me.utilizar.Name = "utilizar"
        Me.utilizar.Width = 22
        '
        'idcombinacion
        '
        Me.idcombinacion.HeaderText = "Idcombinacion"
        Me.idcombinacion.Name = "idcombinacion"
        Me.idcombinacion.ReadOnly = True
        Me.idcombinacion.Visible = False
        Me.idcombinacion.Width = 101
        '
        'idmodelo
        '
        Me.idmodelo.HeaderText = "IdModelo"
        Me.idmodelo.Name = "idmodelo"
        Me.idmodelo.ReadOnly = True
        Me.idmodelo.Visible = False
        Me.idmodelo.Width = 76
        '
        'idpropiedad
        '
        Me.idpropiedad.HeaderText = "IdPropiedad"
        Me.idpropiedad.Name = "idpropiedad"
        Me.idpropiedad.ReadOnly = True
        Me.idpropiedad.Visible = False
        Me.idpropiedad.Width = 89
        '
        'modelo
        '
        Me.modelo.HeaderText = "Modelo"
        Me.modelo.Name = "modelo"
        Me.modelo.ReadOnly = True
        Me.modelo.Width = 67
        '
        'propiedad
        '
        Me.propiedad.HeaderText = "Propiedad"
        Me.propiedad.Name = "propiedad"
        Me.propiedad.ReadOnly = True
        Me.propiedad.Width = 80
        '
        'FrmPropiedadesMasicas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 426)
        Me.Controls.Add(Me.spcontenedor)
        Me.Name = "FrmPropiedadesMasicas"
        Me.ShowIcon = False
        Me.Text = "Propiedades Masicas"
        CType(Me.nudinercia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudmoduloseccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.eppropiedades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcontenedor.Panel1.ResumeLayout(False)
        Me.spcontenedor.Panel1.PerformLayout()
        Me.spcontenedor.Panel2.ResumeLayout(False)
        CType(Me.spcontenedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcontenedor.ResumeLayout(False)
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpmodelos.ResumeLayout(False)
        CType(Me.dwmodelos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdescripcion As TextBox
    Friend WithEvents label2 As Label
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudinercia As NumericUpDown
    Friend WithEvents nudmoduloseccion As NumericUpDown
    Friend WithEvents eppropiedades As ErrorProvider
    Friend WithEvents spcontenedor As SplitContainer
    Friend WithEvents gpmodelos As GroupBox
    Friend WithEvents dwmodelos As DataGridView
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Inercia As DataGridViewTextBoxColumn
    Friend WithEvents Modulo_Seccion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Modi As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Modi As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents utilizar As DataGridViewCheckBoxColumn
    Friend WithEvents idcombinacion As DataGridViewTextBoxColumn
    Friend WithEvents idmodelo As DataGridViewTextBoxColumn
    Friend WithEvents idpropiedad As DataGridViewTextBoxColumn
    Friend WithEvents modelo As DataGridViewTextBoxColumn
    Friend WithEvents propiedad As DataGridViewTextBoxColumn
End Class
