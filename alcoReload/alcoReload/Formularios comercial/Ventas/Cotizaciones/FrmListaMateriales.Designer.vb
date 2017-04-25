<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaMateriales
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaMateriales))
        Me.dwItem = New System.Windows.Forms.DataGridView()
        Me.utilizar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.indice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.piezasxunidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadrequerida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orientacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.para = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costou = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CostoSinDesperdicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dwTotales = New System.Windows.Forms.DataGridView()
        Me.tVidSinDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tPerfSinDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tPerfileria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tAccesoSinDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tAccesorio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tOtrosSinDesp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tOtros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btnguardar = New System.Windows.Forms.ToolStripButton()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.utilizar, Me.tipo, Me.material, Me.indice, Me.referencia, Me.acabado, Me.espesor, Me.ancho, Me.alto, Me.cantidad, Me.piezasxunidad, Me.cantidadrequerida, Me.orientacion, Me.ubicacion, Me.para, Me.costou, Me.costo, Me.CostoSinDesperdicio})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.Location = New System.Drawing.Point(0, 31)
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersVisible = False
        Me.dwItem.Size = New System.Drawing.Size(904, 260)
        Me.dwItem.TabIndex = 0
        '
        'utilizar
        '
        Me.utilizar.HeaderText = "Cobrar"
        Me.utilizar.Name = "utilizar"
        Me.utilizar.Width = 44
        '
        'tipo
        '
        Me.tipo.HeaderText = "tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.ReadOnly = True
        Me.tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tipo.Visible = False
        Me.tipo.Width = 30
        '
        'material
        '
        Me.material.HeaderText = "Material"
        Me.material.Name = "material"
        Me.material.ReadOnly = True
        Me.material.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.material.Width = 50
        '
        'indice
        '
        Me.indice.HeaderText = "Indice"
        Me.indice.Name = "indice"
        Me.indice.ReadOnly = True
        Me.indice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.indice.Visible = False
        Me.indice.Width = 42
        '
        'referencia
        '
        Me.referencia.HeaderText = "Referencia"
        Me.referencia.Name = "referencia"
        Me.referencia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.referencia.Width = 65
        '
        'acabado
        '
        Me.acabado.HeaderText = "Acabado/Color"
        Me.acabado.Name = "acabado"
        Me.acabado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.acabado.Width = 85
        '
        'espesor
        '
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.espesor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.espesor.Width = 51
        '
        'ancho
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ancho.DefaultCellStyle = DataGridViewCellStyle1
        Me.ancho.HeaderText = "Dimension/Ancho"
        Me.ancho.Name = "ancho"
        Me.ancho.ReadOnly = True
        Me.ancho.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ancho.Width = 98
        '
        'alto
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.alto.DefaultCellStyle = DataGridViewCellStyle2
        Me.alto.HeaderText = "Alto"
        Me.alto.Name = "alto"
        Me.alto.ReadOnly = True
        Me.alto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.alto.Width = 31
        '
        'cantidad
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.NullValue = Nothing
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle3
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cantidad.Width = 55
        '
        'piezasxunidad
        '
        Me.piezasxunidad.HeaderText = "P.xUnidad"
        Me.piezasxunidad.Name = "piezasxunidad"
        Me.piezasxunidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.piezasxunidad.Width = 62
        '
        'cantidadrequerida
        '
        Me.cantidadrequerida.HeaderText = "Cant. Requerida"
        Me.cantidadrequerida.Name = "cantidadrequerida"
        Me.cantidadrequerida.ReadOnly = True
        Me.cantidadrequerida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cantidadrequerida.Width = 81
        '
        'orientacion
        '
        Me.orientacion.HeaderText = "Orientacion"
        Me.orientacion.Name = "orientacion"
        Me.orientacion.ReadOnly = True
        Me.orientacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.orientacion.Width = 67
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "Ubicacion"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.ReadOnly = True
        Me.ubicacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ubicacion.Width = 61
        '
        'para
        '
        Me.para.HeaderText = "Para"
        Me.para.Name = "para"
        Me.para.ReadOnly = True
        Me.para.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.para.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.para.Width = 35
        '
        'costou
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.costou.DefaultCellStyle = DataGridViewCellStyle4
        Me.costou.HeaderText = "Costo Unitario"
        Me.costou.Name = "costou"
        Me.costou.ReadOnly = True
        Me.costou.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.costou.Width = 71
        '
        'costo
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.costo.DefaultCellStyle = DataGridViewCellStyle5
        Me.costo.HeaderText = "Costo Total"
        Me.costo.Name = "costo"
        Me.costo.ReadOnly = True
        Me.costo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.costo.Width = 60
        '
        'CostoSinDesperdicio
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.CostoSinDesperdicio.DefaultCellStyle = DataGridViewCellStyle6
        Me.CostoSinDesperdicio.HeaderText = "Costo sin desp."
        Me.CostoSinDesperdicio.Name = "CostoSinDesperdicio"
        Me.CostoSinDesperdicio.ReadOnly = True
        Me.CostoSinDesperdicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CostoSinDesperdicio.Width = 77
        '
        'dwTotales
        '
        Me.dwTotales.AllowUserToAddRows = False
        Me.dwTotales.AllowUserToDeleteRows = False
        Me.dwTotales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwTotales.BackgroundColor = System.Drawing.Color.White
        Me.dwTotales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwTotales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tVidSinDesp, Me.tVidrio, Me.tPerfSinDesp, Me.tPerfileria, Me.tAccesoSinDesp, Me.tAccesorio, Me.tOtrosSinDesp, Me.tOtros})
        Me.dwTotales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dwTotales.Location = New System.Drawing.Point(0, 291)
        Me.dwTotales.Name = "dwTotales"
        Me.dwTotales.ReadOnly = True
        Me.dwTotales.RowHeadersVisible = False
        Me.dwTotales.Size = New System.Drawing.Size(904, 93)
        Me.dwTotales.TabIndex = 1
        '
        'tVidSinDesp
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.tVidSinDesp.DefaultCellStyle = DataGridViewCellStyle7
        Me.tVidSinDesp.HeaderText = "Tot. Vidr. sin desperdicio"
        Me.tVidSinDesp.Name = "tVidSinDesp"
        Me.tVidSinDesp.ReadOnly = True
        Me.tVidSinDesp.Width = 135
        '
        'tVidrio
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.tVidrio.DefaultCellStyle = DataGridViewCellStyle8
        Me.tVidrio.HeaderText = "Total vidrio"
        Me.tVidrio.Name = "tVidrio"
        Me.tVidrio.ReadOnly = True
        Me.tVidrio.Width = 78
        '
        'tPerfSinDesp
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "C0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.tPerfSinDesp.DefaultCellStyle = DataGridViewCellStyle9
        Me.tPerfSinDesp.HeaderText = "Tot. Perf. Sin desperdicio"
        Me.tPerfSinDesp.Name = "tPerfSinDesp"
        Me.tPerfSinDesp.ReadOnly = True
        Me.tPerfSinDesp.Width = 138
        '
        'tPerfileria
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "C0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.tPerfileria.DefaultCellStyle = DataGridViewCellStyle10
        Me.tPerfileria.HeaderText = "Total perfilería"
        Me.tPerfileria.Name = "tPerfileria"
        Me.tPerfileria.ReadOnly = True
        Me.tPerfileria.Width = 92
        '
        'tAccesoSinDesp
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "C0"
        DataGridViewCellStyle11.NullValue = "0"
        Me.tAccesoSinDesp.DefaultCellStyle = DataGridViewCellStyle11
        Me.tAccesoSinDesp.HeaderText = "Tot. Acce. Sin desperdicio"
        Me.tAccesoSinDesp.Name = "tAccesoSinDesp"
        Me.tAccesoSinDesp.ReadOnly = True
        Me.tAccesoSinDesp.Width = 143
        '
        'tAccesorio
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "C0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.tAccesorio.DefaultCellStyle = DataGridViewCellStyle12
        Me.tAccesorio.HeaderText = "Total accesorios"
        Me.tAccesorio.Name = "tAccesorio"
        Me.tAccesorio.ReadOnly = True
        Me.tAccesorio.Width = 101
        '
        'tOtrosSinDesp
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "C0"
        DataGridViewCellStyle13.NullValue = "0"
        Me.tOtrosSinDesp.DefaultCellStyle = DataGridViewCellStyle13
        Me.tOtrosSinDesp.HeaderText = "Tot. Otro. Sin desperdicio"
        Me.tOtrosSinDesp.Name = "tOtrosSinDesp"
        Me.tOtrosSinDesp.ReadOnly = True
        Me.tOtrosSinDesp.Width = 139
        '
        'tOtros
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "C0"
        DataGridViewCellStyle14.NullValue = "0"
        Me.tOtros.DefaultCellStyle = DataGridViewCellStyle14
        Me.tOtros.HeaderText = "Total Otros"
        Me.tOtros.Name = "tOtros"
        Me.tOtros.ReadOnly = True
        Me.tOtros.Width = 78
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnguardar})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(904, 31)
        Me.tsherramientas.TabIndex = 2
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btnguardar
        '
        Me.btnguardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnguardar.Image = CType(resources.GetObject("btnguardar.Image"), System.Drawing.Image)
        Me.btnguardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnguardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(28, 28)
        Me.btnguardar.Text = "Guardar Cambios"
        '
        'FrmListaMateriales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(904, 384)
        Me.Controls.Add(Me.dwItem)
        Me.Controls.Add(Me.dwTotales)
        Me.Controls.Add(Me.tsherramientas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmListaMateriales"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de materiales"
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dwItem As DataGridView
    Friend WithEvents dwTotales As DataGridView
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btnguardar As ToolStripButton
    Friend WithEvents tVidSinDesp As DataGridViewTextBoxColumn
    Friend WithEvents tVidrio As DataGridViewTextBoxColumn
    Friend WithEvents tPerfSinDesp As DataGridViewTextBoxColumn
    Friend WithEvents tPerfileria As DataGridViewTextBoxColumn
    Friend WithEvents tAccesoSinDesp As DataGridViewTextBoxColumn
    Friend WithEvents tAccesorio As DataGridViewTextBoxColumn
    Friend WithEvents tOtrosSinDesp As DataGridViewTextBoxColumn
    Friend WithEvents tOtros As DataGridViewTextBoxColumn
    Friend WithEvents utilizar As DataGridViewCheckBoxColumn
    Friend WithEvents tipo As DataGridViewTextBoxColumn
    Friend WithEvents material As DataGridViewTextBoxColumn
    Friend WithEvents indice As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents acabado As DataGridViewTextBoxColumn
    Friend WithEvents espesor As DataGridViewTextBoxColumn
    Friend WithEvents ancho As DataGridViewTextBoxColumn
    Friend WithEvents alto As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents piezasxunidad As DataGridViewTextBoxColumn
    Friend WithEvents cantidadrequerida As DataGridViewTextBoxColumn
    Friend WithEvents orientacion As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents para As DataGridViewTextBoxColumn
    Friend WithEvents costou As DataGridViewTextBoxColumn
    Friend WithEvents costo As DataGridViewTextBoxColumn
    Friend WithEvents CostoSinDesperdicio As DataGridViewTextBoxColumn
End Class
