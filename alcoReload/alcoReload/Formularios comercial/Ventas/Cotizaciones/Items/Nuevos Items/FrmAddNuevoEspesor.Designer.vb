<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddNuevoEspesor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddNuevoEspesor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefijo = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tsHerramientas = New System.Windows.Forms.ToolStrip()
        Me.btnGuardar = New System.Windows.Forms.ToolStripButton()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefijo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsHerramientas.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prefijo"
        '
        'txtPrefijo
        '
        Me.txtPrefijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrefijo.Location = New System.Drawing.Point(13, 47)
        Me.txtPrefijo.MaxLength = 15
        Me.txtPrefijo.Name = "txtPrefijo"
        Me.txtPrefijo.Size = New System.Drawing.Size(100, 20)
        Me.txtPrefijo.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(147, 47)
        Me.txtDescripcion.MaxLength = 29
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(240, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(144, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'tsHerramientas
        '
        Me.tsHerramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGuardar})
        Me.tsHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsHerramientas.Name = "tsHerramientas"
        Me.tsHerramientas.Size = New System.Drawing.Size(522, 25)
        Me.tsHerramientas.TabIndex = 4
        Me.tsHerramientas.Text = "ToolStrip1"
        '
        'btnGuardar
        '
        Me.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(23, 22)
        '
        'Panel
        '
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Location = New System.Drawing.Point(12, 83)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(498, 245)
        Me.Panel.TabIndex = 10
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.prefijo, Me.descripcion, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(3, 3)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(488, 235)
        Me.dwItems.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Width = 97
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Width = 103
        '
        'prefijo
        '
        Me.prefijo.HeaderText = "Prefijo"
        Me.prefijo.Name = "prefijo"
        Me.prefijo.ReadOnly = True
        Me.prefijo.Width = 61
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Width = 119
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Width = 114
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'FrmAddNuevoEspesor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 340)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.tsHerramientas)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrefijo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddNuevoEspesor"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espesor temporal"
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsHerramientas.ResumeLayout(False)
        Me.tsHerramientas.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrefijo As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents tsHerramientas As ToolStrip
    Friend WithEvents btnGuardar As ToolStripButton
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents prefijo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
