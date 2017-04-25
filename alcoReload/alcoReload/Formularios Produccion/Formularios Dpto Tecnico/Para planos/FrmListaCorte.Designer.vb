<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaCorte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaCorte))
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnoptimizar = New System.Windows.Forms.ToolStripButton()
        Me.btnguardar = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewProgressBarColumn1 = New SpecialColumns.DataGridViewProgressBarColumn()
        Me.scgeneral = New System.Windows.Forms.SplitContainer()
        Me.tlpmovimientos = New System.Windows.Forms.TableLayoutPanel()
        Me.dwestimado = New System.Windows.Forms.DataGridView()
        Me.eid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ereferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.perfilesnecesarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desperdicio = New SpecialColumns.DataGridViewProgressBarColumn()
        Me.dwagrupados = New System.Windows.Forms.DataGridView()
        Me.gid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.greferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lotesperfileria = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idarticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idacabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dimension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadnecesaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idlote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lotesugerido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desperdicioperfil = New SpecialColumns.DataGridViewProgressBarColumn()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scgeneral.Panel1.SuspendLayout()
        Me.scgeneral.Panel2.SuspendLayout()
        Me.scgeneral.SuspendLayout()
        Me.tlpmovimientos.SuspendLayout()
        CType(Me.dwestimado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwagrupados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idarticulo, Me.referencia, Me.idacabado, Me.acabado, Me.cantidad, Me.dimension, Me.cantidadnecesaria, Me.idlote, Me.lotesugerido, Me.desperdicioperfil})
        Me.dwitems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwitems.Location = New System.Drawing.Point(0, 0)
        Me.dwitems.Name = "dwitems"
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.Size = New System.Drawing.Size(367, 408)
        Me.dwitems.TabIndex = 0
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnoptimizar, Me.btnguardar})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(714, 25)
        Me.tsherramientas.TabIndex = 1
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnoptimizar
        '
        Me.btnoptimizar.Image = CType(resources.GetObject("btnoptimizar.Image"), System.Drawing.Image)
        Me.btnoptimizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnoptimizar.Name = "btnoptimizar"
        Me.btnoptimizar.Size = New System.Drawing.Size(79, 22)
        Me.btnoptimizar.Text = "Optimizar"
        '
        'btnguardar
        '
        Me.btnguardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnguardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(23, 22)
        Me.btnguardar.Text = "Guardar"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 21
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "referencia"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Referencia"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 84
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "acabado"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Acabado"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 75
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "cantidad"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 74
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "dimension"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Dimension"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 81
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Cantidad Uso"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 96
        '
        'DataGridViewProgressBarColumn1
        '
        Me.DataGridViewProgressBarColumn1.ColorBarra = System.Drawing.SystemColors.Highlight
        Me.DataGridViewProgressBarColumn1.HeaderText = "Porc. Uso (%)"
        Me.DataGridViewProgressBarColumn1.Name = "DataGridViewProgressBarColumn1"
        Me.DataGridViewProgressBarColumn1.ReadOnly = True
        Me.DataGridViewProgressBarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewProgressBarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressBarColumn1.Width = 96
        '
        'scgeneral
        '
        Me.scgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scgeneral.Location = New System.Drawing.Point(0, 25)
        Me.scgeneral.Name = "scgeneral"
        '
        'scgeneral.Panel1
        '
        Me.scgeneral.Panel1.Controls.Add(Me.dwitems)
        '
        'scgeneral.Panel2
        '
        Me.scgeneral.Panel2.Controls.Add(Me.tlpmovimientos)
        Me.scgeneral.Size = New System.Drawing.Size(714, 408)
        Me.scgeneral.SplitterDistance = 367
        Me.scgeneral.TabIndex = 2
        '
        'tlpmovimientos
        '
        Me.tlpmovimientos.ColumnCount = 1
        Me.tlpmovimientos.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpmovimientos.Controls.Add(Me.dwestimado, 0, 1)
        Me.tlpmovimientos.Controls.Add(Me.dwagrupados, 0, 0)
        Me.tlpmovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpmovimientos.Location = New System.Drawing.Point(0, 0)
        Me.tlpmovimientos.Name = "tlpmovimientos"
        Me.tlpmovimientos.RowCount = 2
        Me.tlpmovimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpmovimientos.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpmovimientos.Size = New System.Drawing.Size(343, 408)
        Me.tlpmovimientos.TabIndex = 0
        '
        'dwestimado
        '
        Me.dwestimado.AllowUserToAddRows = False
        Me.dwestimado.AllowUserToDeleteRows = False
        Me.dwestimado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwestimado.BackgroundColor = System.Drawing.Color.White
        Me.dwestimado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwestimado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwestimado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.eid, Me.ereferencia, Me.eacabado, Me.lote, Me.perfilesnecesarios, Me.desperdicio})
        Me.dwestimado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwestimado.Location = New System.Drawing.Point(3, 207)
        Me.dwestimado.Name = "dwestimado"
        Me.dwestimado.RowHeadersVisible = False
        Me.dwestimado.Size = New System.Drawing.Size(337, 198)
        Me.dwestimado.TabIndex = 2
        '
        'eid
        '
        Me.eid.DataPropertyName = "id"
        Me.eid.HeaderText = "Id"
        Me.eid.Name = "eid"
        Me.eid.ReadOnly = True
        Me.eid.Visible = False
        Me.eid.Width = 22
        '
        'ereferencia
        '
        Me.ereferencia.DataPropertyName = "referencia"
        Me.ereferencia.HeaderText = "Referencia"
        Me.ereferencia.Name = "ereferencia"
        Me.ereferencia.ReadOnly = True
        Me.ereferencia.Width = 84
        '
        'eacabado
        '
        Me.eacabado.DataPropertyName = "acabado"
        Me.eacabado.HeaderText = "Acabado"
        Me.eacabado.Name = "eacabado"
        Me.eacabado.ReadOnly = True
        Me.eacabado.Width = 75
        '
        'lote
        '
        Me.lote.HeaderText = "Lote"
        Me.lote.Name = "lote"
        Me.lote.ReadOnly = True
        Me.lote.Width = 53
        '
        'perfilesnecesarios
        '
        Me.perfilesnecesarios.HeaderText = "Necesarios"
        Me.perfilesnecesarios.Name = "perfilesnecesarios"
        Me.perfilesnecesarios.ReadOnly = True
        Me.perfilesnecesarios.Width = 85
        '
        'desperdicio
        '
        Me.desperdicio.ColorBarra = System.Drawing.SystemColors.MenuHighlight
        Me.desperdicio.HeaderText = "Porcentaje Desperdicio"
        Me.desperdicio.Name = "desperdicio"
        Me.desperdicio.ReadOnly = True
        Me.desperdicio.Width = 111
        '
        'dwagrupados
        '
        Me.dwagrupados.AllowUserToAddRows = False
        Me.dwagrupados.AllowUserToDeleteRows = False
        Me.dwagrupados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwagrupados.BackgroundColor = System.Drawing.Color.White
        Me.dwagrupados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwagrupados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwagrupados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gid, Me.greferencia, Me.gacabado, Me.lotesperfileria})
        Me.dwagrupados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwagrupados.Location = New System.Drawing.Point(3, 3)
        Me.dwagrupados.Name = "dwagrupados"
        Me.dwagrupados.RowHeadersVisible = False
        Me.dwagrupados.Size = New System.Drawing.Size(337, 198)
        Me.dwagrupados.TabIndex = 1
        '
        'gid
        '
        Me.gid.DataPropertyName = "id"
        Me.gid.HeaderText = "Id"
        Me.gid.Name = "gid"
        Me.gid.ReadOnly = True
        Me.gid.Visible = False
        Me.gid.Width = 22
        '
        'greferencia
        '
        Me.greferencia.DataPropertyName = "referencia"
        Me.greferencia.HeaderText = "Referencia"
        Me.greferencia.Name = "greferencia"
        Me.greferencia.ReadOnly = True
        Me.greferencia.Width = 84
        '
        'gacabado
        '
        Me.gacabado.DataPropertyName = "acabado"
        Me.gacabado.HeaderText = "Acabado"
        Me.gacabado.Name = "gacabado"
        Me.gacabado.ReadOnly = True
        Me.gacabado.Width = 75
        '
        'lotesperfileria
        '
        Me.lotesperfileria.HeaderText = "Lotes"
        Me.lotesperfileria.Name = "lotesperfileria"
        Me.lotesperfileria.Width = 39
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 21
        '
        'idarticulo
        '
        Me.idarticulo.DataPropertyName = "idarticulo"
        Me.idarticulo.HeaderText = "Id Articulo"
        Me.idarticulo.Name = "idarticulo"
        Me.idarticulo.Visible = False
        Me.idarticulo.Width = 60
        '
        'referencia
        '
        Me.referencia.DataPropertyName = "referencia"
        Me.referencia.HeaderText = "Referencia"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Width = 84
        '
        'idacabado
        '
        Me.idacabado.DataPropertyName = "idacabado"
        Me.idacabado.HeaderText = "Id Acabado"
        Me.idacabado.Name = "idacabado"
        Me.idacabado.ReadOnly = True
        Me.idacabado.Visible = False
        Me.idacabado.Width = 87
        '
        'acabado
        '
        Me.acabado.DataPropertyName = "acabado"
        Me.acabado.HeaderText = "Acabado"
        Me.acabado.Name = "acabado"
        Me.acabado.ReadOnly = True
        Me.acabado.Width = 75
        '
        'cantidad
        '
        Me.cantidad.DataPropertyName = "cantidad"
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 74
        '
        'dimension
        '
        Me.dimension.DataPropertyName = "dimension"
        Me.dimension.HeaderText = "Dimension"
        Me.dimension.Name = "dimension"
        Me.dimension.ReadOnly = True
        Me.dimension.Width = 81
        '
        'cantidadnecesaria
        '
        Me.cantidadnecesaria.DataPropertyName = "cantidad_necesaria"
        Me.cantidadnecesaria.HeaderText = "Cantidad Necesaria"
        Me.cantidadnecesaria.Name = "cantidadnecesaria"
        Me.cantidadnecesaria.ReadOnly = True
        Me.cantidadnecesaria.Width = 114
        '
        'idlote
        '
        Me.idlote.DataPropertyName = "idlote"
        Me.idlote.HeaderText = "Id Lote"
        Me.idlote.Name = "idlote"
        Me.idlote.ReadOnly = True
        Me.idlote.Width = 60
        '
        'lotesugerido
        '
        Me.lotesugerido.DataPropertyName = "lote"
        Me.lotesugerido.HeaderText = "Lote"
        Me.lotesugerido.Name = "lotesugerido"
        Me.lotesugerido.ReadOnly = True
        Me.lotesugerido.Width = 53
        '
        'desperdicioperfil
        '
        Me.desperdicioperfil.ColorBarra = System.Drawing.SystemColors.HotTrack
        Me.desperdicioperfil.DataPropertyName = "desperdicio"
        Me.desperdicioperfil.HeaderText = "Desperdicio"
        Me.desperdicioperfil.Name = "desperdicioperfil"
        Me.desperdicioperfil.ReadOnly = True
        Me.desperdicioperfil.Width = 69
        '
        'FrmListaCorte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 433)
        Me.Controls.Add(Me.scgeneral)
        Me.Controls.Add(Me.tsherramientas)
        Me.Name = "FrmListaCorte"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Corte"
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.scgeneral.Panel1.ResumeLayout(False)
        Me.scgeneral.Panel2.ResumeLayout(False)
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgeneral.ResumeLayout(False)
        Me.tlpmovimientos.ResumeLayout(False)
        CType(Me.dwestimado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwagrupados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dwitems As DataGridView
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnoptimizar As ToolStripButton
    Friend WithEvents btnguardar As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewProgressBarColumn1 As SpecialColumns.DataGridViewProgressBarColumn
    Friend WithEvents scgeneral As SplitContainer
    Friend WithEvents tlpmovimientos As TableLayoutPanel
    Friend WithEvents dwagrupados As DataGridView
    Friend WithEvents dwestimado As DataGridView
    Friend WithEvents eid As DataGridViewTextBoxColumn
    Friend WithEvents ereferencia As DataGridViewTextBoxColumn
    Friend WithEvents eacabado As DataGridViewTextBoxColumn
    Friend WithEvents lote As DataGridViewTextBoxColumn
    Friend WithEvents perfilesnecesarios As DataGridViewTextBoxColumn
    Friend WithEvents desperdicio As SpecialColumns.DataGridViewProgressBarColumn
    Friend WithEvents gid As DataGridViewTextBoxColumn
    Friend WithEvents greferencia As DataGridViewTextBoxColumn
    Friend WithEvents gacabado As DataGridViewTextBoxColumn
    Friend WithEvents lotesperfileria As DataGridViewComboBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idarticulo As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents idacabado As DataGridViewTextBoxColumn
    Friend WithEvents acabado As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents dimension As DataGridViewTextBoxColumn
    Friend WithEvents cantidadnecesaria As DataGridViewTextBoxColumn
    Friend WithEvents idlote As DataGridViewTextBoxColumn
    Friend WithEvents lotesugerido As DataGridViewTextBoxColumn
    Friend WithEvents desperdicioperfil As SpecialColumns.DataGridViewProgressBarColumn
End Class
