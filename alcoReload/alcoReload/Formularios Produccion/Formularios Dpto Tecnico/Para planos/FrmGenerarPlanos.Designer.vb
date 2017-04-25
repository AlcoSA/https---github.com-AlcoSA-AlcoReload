<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerarPlanos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGenerarPlanos))
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.automatico = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idordenped = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idarticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anchofabricacion = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.altofabricacion = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.cantidad = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.piezasxunidad = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.anchovano = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.altovano = New EspecialColumns.Columna_Formula.FormuleGridColumn()
        Me.metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.metros_instalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anchooriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.altooriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadoriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vidrio = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.acabado = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colorvidrio = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.preciou = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio_instala = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.puntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoitem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.especial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nsr = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbcliente = New System.Windows.Forms.Label()
        Me.lbcodobra = New System.Windows.Forms.Label()
        Me.lbobra = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lbfechacreacion = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tbGeneral = New System.Windows.Forms.TabControl()
        Me.Planos = New System.Windows.Forms.TabPage()
        Me.tsutiles = New System.Windows.Forms.ToolStrip()
        Me.btnlistacorte = New System.Windows.Forms.ToolStripButton()
        Me.ListaCorte = New System.Windows.Forms.TabPage()
        Me.visor = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tbGeneral.SuspendLayout()
        Me.Planos.SuspendLayout()
        Me.tsutiles.SuspendLayout()
        Me.ListaCorte.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwItem
        '
        Me.dwItem.AllowDrop = True
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoGenerateColumns = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.automatico, Me.idordenped, Me.idarticulo, Me.ubicacion, Me.descripcion, Me.observaciones, Me.anchofabricacion, Me.altofabricacion, Me.cantidad, Me.piezasxunidad, Me.anchovano, Me.altovano, Me.metros, Me.metros_instalacion, Me.anchooriginal, Me.altooriginal, Me.cantidadoriginal, Me.vidrio, Me.acabado, Me.colorvidrio, Me.espesor, Me.preciou, Me.precio_instala, Me.puntos, Me.tipoitem, Me.especial, Me.nsr, Me.idestado})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(3, 28)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 20
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(605, 240)
        Me.dwItem.TabIndex = 3
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'Id
        '
        Me.Id.HeaderText = "."
        Me.Id.ImagenporDefecto = Nothing
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 35
        '
        'automatico
        '
        Me.automatico.HeaderText = "Automatico"
        Me.automatico.Name = "automatico"
        Me.automatico.Visible = False
        Me.automatico.Width = 66
        '
        'idordenped
        '
        Me.idordenped.HeaderText = "IdOrden"
        Me.idordenped.Name = "idordenped"
        Me.idordenped.ReadOnly = True
        Me.idordenped.Width = 70
        '
        'idarticulo
        '
        Me.idarticulo.HeaderText = "Id Articulo"
        Me.idarticulo.Name = "idarticulo"
        Me.idarticulo.ReadOnly = True
        Me.idarticulo.Visible = False
        Me.idarticulo.Width = 79
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "Ubicacion"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.ReadOnly = True
        Me.ubicacion.Width = 80
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'observaciones
        '
        Me.observaciones.HeaderText = "Observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.Width = 103
        '
        'anchofabricacion
        '
        Me.anchofabricacion.HeaderText = "Ancho Fabricacion"
        Me.anchofabricacion.Name = "anchofabricacion"
        Me.anchofabricacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.anchofabricacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.anchofabricacion.Width = 111
        '
        'altofabricacion
        '
        Me.altofabricacion.HeaderText = "Alto Fabricacion"
        Me.altofabricacion.Name = "altofabricacion"
        Me.altofabricacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.altofabricacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.altofabricacion.Width = 99
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cantidad.Width = 74
        '
        'piezasxunidad
        '
        Me.piezasxunidad.HeaderText = "P. x Unidad"
        Me.piezasxunidad.Name = "piezasxunidad"
        Me.piezasxunidad.ReadOnly = True
        Me.piezasxunidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.piezasxunidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.piezasxunidad.Width = 80
        '
        'anchovano
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.anchovano.DefaultCellStyle = DataGridViewCellStyle1
        Me.anchovano.HeaderText = "Ancho Vano"
        Me.anchovano.Name = "anchovano"
        Me.anchovano.ReadOnly = True
        Me.anchovano.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.anchovano.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.anchovano.Width = 84
        '
        'altovano
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.altovano.DefaultCellStyle = DataGridViewCellStyle2
        Me.altovano.HeaderText = "Alto Vano"
        Me.altovano.Name = "altovano"
        Me.altovano.ReadOnly = True
        Me.altovano.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.altovano.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.altovano.Width = 72
        '
        'metros
        '
        Me.metros.HeaderText = "Mts"
        Me.metros.Name = "metros"
        Me.metros.ReadOnly = True
        Me.metros.Width = 49
        '
        'metros_instalacion
        '
        Me.metros_instalacion.HeaderText = "Mts Instalacion"
        Me.metros_instalacion.Name = "metros_instalacion"
        Me.metros_instalacion.ReadOnly = True
        Me.metros_instalacion.Width = 95
        '
        'anchooriginal
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.anchooriginal.DefaultCellStyle = DataGridViewCellStyle3
        Me.anchooriginal.HeaderText = "Ancho Original"
        Me.anchooriginal.Name = "anchooriginal"
        Me.anchooriginal.ReadOnly = True
        Me.anchooriginal.Width = 93
        '
        'altooriginal
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.altooriginal.DefaultCellStyle = DataGridViewCellStyle4
        Me.altooriginal.HeaderText = "Alto Original"
        Me.altooriginal.Name = "altooriginal"
        Me.altooriginal.ReadOnly = True
        Me.altooriginal.Width = 81
        '
        'cantidadoriginal
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cantidadoriginal.DefaultCellStyle = DataGridViewCellStyle5
        Me.cantidadoriginal.HeaderText = "Cantidad Original"
        Me.cantidadoriginal.Name = "cantidadoriginal"
        Me.cantidadoriginal.ReadOnly = True
        Me.cantidadoriginal.Width = 103
        '
        'vidrio
        '
        Me.vidrio.HeaderText = "Vidrio"
        Me.vidrio.Name = "vidrio"
        Me.vidrio.Width = 39
        '
        'acabado
        '
        Me.acabado.HeaderText = "Acabado"
        Me.acabado.Name = "acabado"
        Me.acabado.Width = 56
        '
        'colorvidrio
        '
        Me.colorvidrio.HeaderText = "Color Vidrio"
        Me.colorvidrio.Name = "colorvidrio"
        Me.colorvidrio.Width = 59
        '
        'espesor
        '
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.Width = 51
        '
        'preciou
        '
        Me.preciou.HeaderText = "Precio Unitario"
        Me.preciou.Name = "preciou"
        Me.preciou.ReadOnly = True
        Me.preciou.Width = 93
        '
        'precio_instala
        '
        Me.precio_instala.HeaderText = "Precio Instalacion"
        Me.precio_instala.Name = "precio_instala"
        Me.precio_instala.ReadOnly = True
        Me.precio_instala.Width = 106
        '
        'puntos
        '
        Me.puntos.HeaderText = "Puntos"
        Me.puntos.Name = "puntos"
        Me.puntos.ReadOnly = True
        Me.puntos.Width = 65
        '
        'tipoitem
        '
        Me.tipoitem.HeaderText = "Tipo Item"
        Me.tipoitem.Name = "tipoitem"
        Me.tipoitem.ReadOnly = True
        Me.tipoitem.Visible = False
        Me.tipoitem.Width = 70
        '
        'especial
        '
        Me.especial.HeaderText = "--"
        Me.especial.Name = "especial"
        Me.especial.ReadOnly = True
        Me.especial.Visible = False
        Me.especial.Width = 38
        '
        'nsr
        '
        Me.nsr.HeaderText = "NSR"
        Me.nsr.Name = "nsr"
        Me.nsr.ReadOnly = True
        Me.nsr.Width = 36
        '
        'idestado
        '
        Me.idestado.HeaderText = "idestado"
        Me.idestado.Name = "idestado"
        Me.idestado.ReadOnly = True
        Me.idestado.Visible = False
        Me.idestado.Width = 72
        '
        'lbcliente
        '
        Me.lbcliente.AccessibleName = "Cliente"
        Me.lbcliente.AutoSize = True
        Me.lbcliente.Location = New System.Drawing.Point(78, 13)
        Me.lbcliente.Name = "lbcliente"
        Me.lbcliente.Size = New System.Drawing.Size(13, 13)
        Me.lbcliente.TabIndex = 29
        Me.lbcliente.Text = "--"
        '
        'lbcodobra
        '
        Me.lbcodobra.AccessibleName = "Codigo Obra"
        Me.lbcodobra.AutoSize = True
        Me.lbcodobra.Location = New System.Drawing.Point(78, 66)
        Me.lbcodobra.Name = "lbcodobra"
        Me.lbcodobra.Size = New System.Drawing.Size(13, 13)
        Me.lbcodobra.TabIndex = 28
        Me.lbcodobra.Text = "--"
        '
        'lbobra
        '
        Me.lbobra.AccessibleName = "Obra"
        Me.lbobra.AutoSize = True
        Me.lbobra.Location = New System.Drawing.Point(78, 38)
        Me.lbobra.Name = "lbobra"
        Me.lbobra.Size = New System.Drawing.Size(13, 13)
        Me.lbobra.TabIndex = 27
        Me.lbobra.Text = "--"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Cliente:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 66)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Código Obra:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(3, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Obra:"
        '
        'lbfechacreacion
        '
        Me.lbfechacreacion.AccessibleName = "Obra"
        Me.lbfechacreacion.AutoSize = True
        Me.lbfechacreacion.Location = New System.Drawing.Point(435, 13)
        Me.lbfechacreacion.Name = "lbfechacreacion"
        Me.lbfechacreacion.Size = New System.Drawing.Size(13, 13)
        Me.lbfechacreacion.TabIndex = 32
        Me.lbfechacreacion.Text = "--"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(349, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Fecha Creación:"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbfechacreacion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbcliente)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbobra)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbcodobra)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tbGeneral)
        Me.SplitContainer1.Size = New System.Drawing.Size(619, 381)
        Me.SplitContainer1.SplitterDistance = 80
        Me.SplitContainer1.TabIndex = 33
        '
        'tbGeneral
        '
        Me.tbGeneral.Controls.Add(Me.Planos)
        Me.tbGeneral.Controls.Add(Me.ListaCorte)
        Me.tbGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbGeneral.Location = New System.Drawing.Point(0, 0)
        Me.tbGeneral.Name = "tbGeneral"
        Me.tbGeneral.SelectedIndex = 0
        Me.tbGeneral.Size = New System.Drawing.Size(619, 297)
        Me.tbGeneral.TabIndex = 5
        '
        'Planos
        '
        Me.Planos.Controls.Add(Me.dwItem)
        Me.Planos.Controls.Add(Me.tsutiles)
        Me.Planos.Location = New System.Drawing.Point(4, 22)
        Me.Planos.Name = "Planos"
        Me.Planos.Padding = New System.Windows.Forms.Padding(3)
        Me.Planos.Size = New System.Drawing.Size(611, 271)
        Me.Planos.TabIndex = 0
        Me.Planos.Text = "Generar Planos"
        Me.Planos.UseVisualStyleBackColor = True
        '
        'tsutiles
        '
        Me.tsutiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsutiles.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnlistacorte})
        Me.tsutiles.Location = New System.Drawing.Point(3, 3)
        Me.tsutiles.Name = "tsutiles"
        Me.tsutiles.Size = New System.Drawing.Size(605, 25)
        Me.tsutiles.TabIndex = 4
        Me.tsutiles.Text = "ToolStrip1"
        '
        'btnlistacorte
        '
        Me.btnlistacorte.Image = CType(resources.GetObject("btnlistacorte.Image"), System.Drawing.Image)
        Me.btnlistacorte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnlistacorte.Name = "btnlistacorte"
        Me.btnlistacorte.Size = New System.Drawing.Size(83, 22)
        Me.btnlistacorte.Text = "Lista Corte"
        '
        'ListaCorte
        '
        Me.ListaCorte.Controls.Add(Me.visor)
        Me.ListaCorte.Location = New System.Drawing.Point(4, 22)
        Me.ListaCorte.Name = "ListaCorte"
        Me.ListaCorte.Padding = New System.Windows.Forms.Padding(3)
        Me.ListaCorte.Size = New System.Drawing.Size(611, 271)
        Me.ListaCorte.TabIndex = 1
        Me.ListaCorte.Text = "Lista Corte"
        Me.ListaCorte.UseVisualStyleBackColor = True
        '
        'visor
        '
        Me.visor.ActiveViewIndex = -1
        Me.visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.visor.Cursor = System.Windows.Forms.Cursors.Default
        Me.visor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.visor.Location = New System.Drawing.Point(3, 3)
        Me.visor.Name = "visor"
        Me.visor.ShowCloseButton = False
        Me.visor.ShowCopyButton = False
        Me.visor.ShowGroupTreeButton = False
        Me.visor.ShowLogo = False
        Me.visor.ShowParameterPanelButton = False
        Me.visor.Size = New System.Drawing.Size(605, 265)
        Me.visor.TabIndex = 1
        Me.visor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'FrmGenerarPlanos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 381)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmGenerarPlanos"
        Me.ShowIcon = False
        Me.Text = "Generar Planos"
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tbGeneral.ResumeLayout(False)
        Me.Planos.ResumeLayout(False)
        Me.Planos.PerformLayout()
        Me.tsutiles.ResumeLayout(False)
        Me.tsutiles.PerformLayout()
        Me.ListaCorte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents lbcliente As Label
    Friend WithEvents lbcodobra As Label
    Friend WithEvents lbobra As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lbfechacreacion As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents tsutiles As ToolStrip
    Friend WithEvents btnlistacorte As ToolStripButton
    Friend WithEvents tbGeneral As TabControl
    Friend WithEvents Planos As TabPage
    Friend WithEvents ListaCorte As TabPage
    Friend WithEvents visor As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents automatico As DataGridViewCheckBoxColumn
    Friend WithEvents idordenped As DataGridViewTextBoxColumn
    Friend WithEvents idarticulo As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents observaciones As DataGridViewTextBoxColumn
    Friend WithEvents anchofabricacion As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents altofabricacion As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents cantidad As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents piezasxunidad As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents anchovano As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents altovano As EspecialColumns.Columna_Formula.FormuleGridColumn
    Friend WithEvents metros As DataGridViewTextBoxColumn
    Friend WithEvents metros_instalacion As DataGridViewTextBoxColumn
    Friend WithEvents anchooriginal As DataGridViewTextBoxColumn
    Friend WithEvents altooriginal As DataGridViewTextBoxColumn
    Friend WithEvents cantidadoriginal As DataGridViewTextBoxColumn
    Friend WithEvents vidrio As DataGridViewComboBoxColumn
    Friend WithEvents acabado As DataGridViewComboBoxColumn
    Friend WithEvents colorvidrio As DataGridViewComboBoxColumn
    Friend WithEvents espesor As DataGridViewComboBoxColumn
    Friend WithEvents preciou As DataGridViewTextBoxColumn
    Friend WithEvents precio_instala As DataGridViewTextBoxColumn
    Friend WithEvents puntos As DataGridViewTextBoxColumn
    Friend WithEvents tipoitem As DataGridViewTextBoxColumn
    Friend WithEvents especial As DataGridViewTextBoxColumn
    Friend WithEvents nsr As DataGridViewCheckBoxColumn
    Friend WithEvents idestado As DataGridViewTextBoxColumn
End Class
