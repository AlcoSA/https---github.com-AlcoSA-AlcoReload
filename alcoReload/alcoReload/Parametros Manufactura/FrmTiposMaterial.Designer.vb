﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTiposMaterial
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Modificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Estado"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(12, 28)
        Me.txtnombre.MaxLength = 15
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(130, 20)
        Me.txtnombre.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 101)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(530, 306)
        Me.Panel.TabIndex = 4
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Fecha_Creacion, Me.Usuario_Creacion, Me.Nombre, Me.Fecha_Modificacion, Me.Usuario_Modificacion, Me.Id_Estado, Me.Estado})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 110)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(520, 189)
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
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 69
        '
        'Fecha_Modificacion
        '
        Me.Fecha_Modificacion.HeaderText = "Fecha modificación"
        Me.Fecha_Modificacion.Name = "Fecha_Modificacion"
        Me.Fecha_Modificacion.ReadOnly = True
        Me.Fecha_Modificacion.Width = 114
        '
        'Usuario_Modificacion
        '
        Me.Usuario_Modificacion.HeaderText = "Usuario modificación"
        Me.Usuario_Modificacion.Name = "Usuario_Modificacion"
        Me.Usuario_Modificacion.ReadOnly = True
        Me.Usuario_Modificacion.Width = 119
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
        'fddFiltros
        '
        Me.fddFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(520, 101)
        Me.fddFiltros.TabIndex = 0
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(12, 74)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 3
        '
        'FrmTiposMaterial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 419)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtnombre)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmTiposMaterial"
        Me.ShowIcon = False
        Me.Text = "Tipos Material"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Nombre As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Modificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class