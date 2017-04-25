<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMotivosDevolucionProduccion
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtDescripcion = New System.Windows.Forms.RichTextBox()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(84, 96)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 8
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltrado)
        Me.Panel.Location = New System.Drawing.Point(10, 123)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(660, 403)
        Me.Panel.TabIndex = 9
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Fecha_creacion, Me.Usuario_creacion, Me.Motivo, Me.Usuario_modificacion, Me.Fecha_modificacion, Me.Id_estado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 97)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(656, 302)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltrado.Grid = Me.dwItems
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(656, 97)
        Me.fddFiltrado.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Estado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Motivo:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDescripcion.Location = New System.Drawing.Point(84, 12)
        Me.txtDescripcion.MaxLength = 500
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(584, 67)
        Me.txtDescripcion.TabIndex = 10
        Me.txtDescripcion.Text = ""
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Width = 22
        '
        'Fecha_creacion
        '
        Me.Fecha_creacion.HeaderText = "Fecha Creacion"
        Me.Fecha_creacion.Name = "Fecha_creacion"
        Me.Fecha_creacion.ReadOnly = True
        Me.Fecha_creacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Fecha_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Fecha_creacion.Width = 79
        '
        'Usuario_creacion
        '
        Me.Usuario_creacion.HeaderText = "Usuario Creacion"
        Me.Usuario_creacion.Name = "Usuario_creacion"
        Me.Usuario_creacion.ReadOnly = True
        Me.Usuario_creacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Usuario_creacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Usuario_creacion.Width = 85
        '
        'Motivo
        '
        Me.Motivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Motivo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Motivo.HeaderText = "Motivo"
        Me.Motivo.Name = "Motivo"
        Me.Motivo.ReadOnly = True
        Me.Motivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Motivo.Width = 450
        '
        'Usuario_modificacion
        '
        Me.Usuario_modificacion.HeaderText = "Usuario Modificacion"
        Me.Usuario_modificacion.Name = "Usuario_modificacion"
        Me.Usuario_modificacion.ReadOnly = True
        Me.Usuario_modificacion.Width = 120
        '
        'Fecha_modificacion
        '
        Me.Fecha_modificacion.HeaderText = "Fecha Modificacion"
        Me.Fecha_modificacion.Name = "Fecha_modificacion"
        Me.Fecha_modificacion.ReadOnly = True
        Me.Fecha_modificacion.Width = 114
        '
        'Id_estado
        '
        Me.Id_estado.HeaderText = "id Estado"
        Me.Id_estado.Name = "Id_estado"
        Me.Id_estado.ReadOnly = True
        Me.Id_estado.Visible = False
        Me.Id_estado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'FrmMotivosDevolucionProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 538)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmMotivosDevolucionProduccion"
        Me.ShowIcon = False
        Me.Text = "Motivos Devolución Producción"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Panel As Panel
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents txtDescripcion As RichTextBox
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_creacion As DataGridViewTextBoxColumn
    Friend WithEvents Motivo As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_estado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
