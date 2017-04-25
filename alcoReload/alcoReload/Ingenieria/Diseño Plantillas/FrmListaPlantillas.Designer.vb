<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListaPlantillas
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
        Me.spcontenidofiltros = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwitems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre_Modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Usuario_Creacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Materiales = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Aprobado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.spcontenidofiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcontenidofiltros.Panel1.SuspendLayout()
        Me.spcontenidofiltros.Panel2.SuspendLayout()
        Me.spcontenidofiltros.SuspendLayout()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spcontenidofiltros
        '
        Me.spcontenidofiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcontenidofiltros.Location = New System.Drawing.Point(0, 0)
        Me.spcontenidofiltros.Name = "spcontenidofiltros"
        Me.spcontenidofiltros.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'spcontenidofiltros.Panel1
        '
        Me.spcontenidofiltros.Panel1.Controls.Add(Me.fddFiltrado)
        '
        'spcontenidofiltros.Panel2
        '
        Me.spcontenidofiltros.Panel2.Controls.Add(Me.dwitems)
        Me.spcontenidofiltros.Size = New System.Drawing.Size(572, 411)
        Me.spcontenidofiltros.SplitterDistance = 78
        Me.spcontenidofiltros.TabIndex = 1
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwitems
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(572, 78)
        Me.fddFiltrado.TabIndex = 0
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.AutoGenerateColumns = False
        Me.dwitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.Nombre_Modelo, Me.Descripcion, Me.Fecha_Creacion, Me.Usuario_Creacion, Me.Id_Estado, Me.Estado, Me.Materiales, Me.Aprobado})
        Me.dwitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwitems.ImageList = Nothing
        Me.dwitems.Location = New System.Drawing.Point(0, 0)
        Me.dwitems.MostrarFiltros = True
        Me.dwitems.Name = "dwitems"
        Me.dwitems.ReadOnly = True
        Me.dwitems.RowHeadersWidth = 20
        Me.dwitems.Size = New System.Drawing.Size(572, 329)
        Me.dwitems.TabIndex = 0
        Me.dwitems.TablaDatos = Nothing
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Visible = False
        Me.Id.Width = 22
        '
        'Nombre_Modelo
        '
        Me.Nombre_Modelo.HeaderText = "Nombre"
        Me.Nombre_Modelo.Name = "Nombre_Modelo"
        Me.Nombre_Modelo.ReadOnly = True
        Me.Nombre_Modelo.Width = 69
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        Me.Descripcion.Width = 88
        '
        'Fecha_Creacion
        '
        Me.Fecha_Creacion.HeaderText = "Fecha Creación"
        Me.Fecha_Creacion.Name = "Fecha_Creacion"
        Me.Fecha_Creacion.ReadOnly = True
        Me.Fecha_Creacion.Width = 98
        '
        'Usuario_Creacion
        '
        Me.Usuario_Creacion.HeaderText = "Usuario Creación"
        Me.Usuario_Creacion.Name = "Usuario_Creacion"
        Me.Usuario_Creacion.ReadOnly = True
        Me.Usuario_Creacion.Width = 104
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id Estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 71
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'Materiales
        '
        Me.Materiales.HeaderText = "Con trabajo"
        Me.Materiales.Name = "Materiales"
        Me.Materiales.ReadOnly = True
        Me.Materiales.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Materiales.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Materiales.Width = 79
        '
        'Aprobado
        '
        Me.Aprobado.HeaderText = "Aprobado"
        Me.Aprobado.Name = "Aprobado"
        Me.Aprobado.ReadOnly = True
        Me.Aprobado.Width = 59
        '
        'FrmListaPlantillas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 411)
        Me.Controls.Add(Me.spcontenidofiltros)
        Me.Name = "FrmListaPlantillas"
        Me.ShowIcon = False
        Me.Text = "Lista Plantillas"
        Me.spcontenidofiltros.Panel1.ResumeLayout(False)
        Me.spcontenidofiltros.Panel2.ResumeLayout(False)
        CType(Me.spcontenidofiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcontenidofiltros.ResumeLayout(False)
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spcontenidofiltros As SplitContainer
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwitems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Nombre_Modelo As DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As DataGridViewTextBoxColumn
    Friend WithEvents Fecha_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Usuario_Creacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents Materiales As DataGridViewCheckBoxColumn
    Friend WithEvents Aprobado As DataGridViewCheckBoxColumn
End Class
