<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPruebasNuevoDatagrid
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPruebasNuevoDatagrid))
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.btncargar = New System.Windows.Forms.ToolStripButton()
        Me.dw = New DatagridTreeView.DataTreeGridView()
        Me.id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsherramientas.SuspendLayout()
        CType(Me.dw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btncargar})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.Size = New System.Drawing.Size(412, 25)
        Me.tsherramientas.TabIndex = 1
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'btncargar
        '
        Me.btncargar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btncargar.Image = CType(resources.GetObject("btncargar.Image"), System.Drawing.Image)
        Me.btncargar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncargar.Name = "btncargar"
        Me.btncargar.Size = New System.Drawing.Size(23, 22)
        Me.btncargar.Text = "Cargar Datagrid"
        '
        'dw
        '
        Me.dw.AllowUserToAddRows = False
        Me.dw.AllowUserToDeleteRows = False
        Me.dw.BackgroundColor = System.Drawing.Color.White
        Me.dw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.apellido})
        Me.dw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dw.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dw.ImageList = Nothing
        Me.dw.Location = New System.Drawing.Point(0, 25)
        Me.dw.Name = "dw"
        Me.dw.RowHeadersVisible = False
        Me.dw.Size = New System.Drawing.Size(412, 280)
        Me.dw.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.ImagenporDefecto = Nothing
        Me.id.Name = "id"
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        '
        'apellido
        '
        Me.apellido.HeaderText = "Apellido"
        Me.apellido.Name = "apellido"
        '
        'FrmPruebasNuevoDatagrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 305)
        Me.Controls.Add(Me.dw)
        Me.Controls.Add(Me.tsherramientas)
        Me.Name = "FrmPruebasNuevoDatagrid"
        Me.Text = "PruebasNuevoDatagrid"
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        CType(Me.dw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dw As DatagridTreeView.DataTreeGridView
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents btncargar As ToolStripButton
    Friend WithEvents id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
End Class
