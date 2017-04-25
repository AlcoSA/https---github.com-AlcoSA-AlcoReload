<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVendedores
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
        Me.txtIdSiesa = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbValorDefecto = New System.Windows.Forms.CheckBox()
        Me.cmbDirector = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.IdAlcoSys = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdSiesa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdDirector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreDirector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.valorPorDefecto = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIdSiesa
        '
        Me.txtIdSiesa.Enabled = False
        Me.txtIdSiesa.Location = New System.Drawing.Point(12, 25)
        Me.txtIdSiesa.Name = "txtIdSiesa"
        Me.txtIdSiesa.ReadOnly = True
        Me.txtIdSiesa.Size = New System.Drawing.Size(65, 20)
        Me.txtIdSiesa.TabIndex = 1
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(108, 25)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(251, 20)
        Me.txtNombre.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Siesa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        '
        'cbValorDefecto
        '
        Me.cbValorDefecto.AutoSize = True
        Me.cbValorDefecto.Location = New System.Drawing.Point(162, 109)
        Me.cbValorDefecto.Name = "cbValorDefecto"
        Me.cbValorDefecto.Size = New System.Drawing.Size(107, 17)
        Me.cbValorDefecto.TabIndex = 7
        Me.cbValorDefecto.Text = "Valor por defecto"
        Me.cbValorDefecto.UseVisualStyleBackColor = True
        '
        'cmbDirector
        '
        Me.cmbDirector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDirector.FormattingEnabled = True
        Me.cmbDirector.Location = New System.Drawing.Point(12, 64)
        Me.cmbDirector.Name = "cmbDirector"
        Me.cmbDirector.Size = New System.Drawing.Size(245, 21)
        Me.cmbDirector.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Director"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 132)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(560, 224)
        Me.Panel.TabIndex = 8
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdAlcoSys, Me.IdSiesa, Me.Nombre, Me.IdDirector, Me.NombreDirector, Me.idEstado, Me.valorPorDefecto})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 81)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(556, 139)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'IdAlcoSys
        '
        Me.IdAlcoSys.HeaderText = "Id"
        Me.IdAlcoSys.Name = "IdAlcoSys"
        Me.IdAlcoSys.ReadOnly = True
        Me.IdAlcoSys.Visible = False
        Me.IdAlcoSys.Width = 22
        '
        'IdSiesa
        '
        Me.IdSiesa.HeaderText = "Id Siesa"
        Me.IdSiesa.Name = "IdSiesa"
        Me.IdSiesa.ReadOnly = True
        Me.IdSiesa.Visible = False
        Me.IdSiesa.Width = 51
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 69
        '
        'IdDirector
        '
        Me.IdDirector.HeaderText = "Id Director"
        Me.IdDirector.Name = "IdDirector"
        Me.IdDirector.ReadOnly = True
        Me.IdDirector.Visible = False
        Me.IdDirector.Width = 81
        '
        'NombreDirector
        '
        Me.NombreDirector.HeaderText = "Nombre director"
        Me.NombreDirector.Name = "NombreDirector"
        Me.NombreDirector.ReadOnly = True
        Me.NombreDirector.Width = 98
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Width = 46
        '
        'valorPorDefecto
        '
        Me.valorPorDefecto.HeaderText = "Valor por defecto"
        Me.valorPorDefecto.Name = "valorPorDefecto"
        Me.valorPorDefecto.ReadOnly = True
        Me.valorPorDefecto.Width = 85
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(556, 81)
        Me.fddFiltros.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Estado"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(12, 105)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 10
        '
        'FrmVendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 368)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbDirector)
        Me.Controls.Add(Me.cbValorDefecto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtIdSiesa)
        Me.Name = "FrmVendedores"
        Me.ShowIcon = False
        Me.Text = "Vendedores"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtIdSiesa As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbValorDefecto As CheckBox
    Friend WithEvents cmbDirector As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents IdAlcoSys As DataGridViewTextBoxColumn
    Friend WithEvents IdSiesa As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents IdDirector As DataGridViewTextBoxColumn
    Friend WithEvents NombreDirector As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewCheckBoxColumn
    Friend WithEvents valorPorDefecto As DataGridViewCheckBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbEstado As ComboBox
End Class
