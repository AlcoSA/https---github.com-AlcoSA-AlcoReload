<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReemplazarPlantilla
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
        Me.spcontenidofiltros = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwitems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_modelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.spcontenidofiltros.Size = New System.Drawing.Size(575, 379)
        Me.spcontenidofiltros.SplitterDistance = 71
        Me.spcontenidofiltros.TabIndex = 2
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Me.dwitems
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(575, 71)
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
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Obra, Me.nombre_modelo, Me.descripcion, Me.id_estado, Me.estado})
        Me.dwitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwitems.ImageList = Nothing
        Me.dwitems.Location = New System.Drawing.Point(0, 0)
        Me.dwitems.MostrarFiltros = True
        Me.dwitems.Name = "dwitems"
        Me.dwitems.ReadOnly = True
        Me.dwitems.RowHeadersWidth = 20
        Me.dwitems.Size = New System.Drawing.Size(575, 304)
        Me.dwitems.TabIndex = 0
        Me.dwitems.TablaDatos = Nothing
        Me.dwitems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'Obra
        '
        Me.Obra.HeaderText = "Obra"
        Me.Obra.Name = "Obra"
        Me.Obra.ReadOnly = True
        Me.Obra.Width = 55
        '
        'nombre_modelo
        '
        Me.nombre_modelo.HeaderText = "Modelo"
        Me.nombre_modelo.Name = "nombre_modelo"
        Me.nombre_modelo.ReadOnly = True
        Me.nombre_modelo.Width = 67
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'id_estado
        '
        Me.id_estado.HeaderText = "Id Estado"
        Me.id_estado.Name = "id_estado"
        Me.id_estado.ReadOnly = True
        Me.id_estado.Visible = False
        Me.id_estado.Width = 77
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'FrmReemplazarPlantilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(575, 379)
        Me.Controls.Add(Me.spcontenidofiltros)
        Me.Name = "FrmReemplazarPlantilla"
        Me.ShowIcon = False
        Me.Text = "Reemplazar Plantilla"
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
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Obra As DataGridViewTextBoxColumn
    Friend WithEvents nombre_modelo As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents id_estado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
