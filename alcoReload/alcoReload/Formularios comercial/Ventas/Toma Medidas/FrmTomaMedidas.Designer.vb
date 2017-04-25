<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTomaMedidas
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
        Me.spcgeneral = New System.Windows.Forms.SplitContainer()
        Me.dwItems = New DatagridTreeView.DataTreeGridView()
        Me.eatomapuntos = New ControlesPersonalizados.Estructurador.Estructurador_Acotado()
        Me.id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.iditemcontrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidadproduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.especial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btndibujo = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.enedicion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.spcgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spcgeneral.Panel1.SuspendLayout()
        Me.spcgeneral.Panel2.SuspendLayout()
        Me.spcgeneral.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spcgeneral
        '
        Me.spcgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.spcgeneral.Location = New System.Drawing.Point(0, 0)
        Me.spcgeneral.Name = "spcgeneral"
        '
        'spcgeneral.Panel1
        '
        Me.spcgeneral.Panel1.Controls.Add(Me.dwItems)
        '
        'spcgeneral.Panel2
        '
        Me.spcgeneral.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.spcgeneral.Panel2.Controls.Add(Me.eatomapuntos)
        Me.spcgeneral.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.spcgeneral.Size = New System.Drawing.Size(566, 371)
        Me.spcgeneral.SplitterDistance = 232
        Me.spcgeneral.TabIndex = 0
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.iditemcontrato, Me.idcotiza, Me.nombre, Me.ancho, Me.alto, Me.cantidad, Me.cantidadproduccion, Me.observaciones, Me.especial, Me.btndibujo, Me.enedicion})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 0)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItems.Size = New System.Drawing.Size(232, 371)
        Me.dwItems.TabIndex = 2
        '
        'eatomapuntos
        '
        Me.eatomapuntos.BackColor = System.Drawing.Color.White
        Me.eatomapuntos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.eatomapuntos.Cota_Seleccionada = Nothing
        Me.eatomapuntos.Cotas = Nothing
        Me.eatomapuntos.Desfase = 30.0!
        Me.eatomapuntos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.eatomapuntos.Location = New System.Drawing.Point(10, 10)
        Me.eatomapuntos.Name = "eatomapuntos"
        Me.eatomapuntos.Size = New System.Drawing.Size(310, 351)
        Me.eatomapuntos.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.ImagenporDefecto = Nothing
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.id.Width = 41
        '
        'iditemcontrato
        '
        Me.iditemcontrato.HeaderText = "Id Item Contrato"
        Me.iditemcontrato.Name = "iditemcontrato"
        Me.iditemcontrato.Visible = False
        Me.iditemcontrato.Width = 107
        '
        'idcotiza
        '
        Me.idcotiza.HeaderText = "Id Item Cotiza"
        Me.idcotiza.Name = "idcotiza"
        Me.idcotiza.Visible = False
        Me.idcotiza.Width = 96
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 69
        '
        'ancho
        '
        Me.ancho.HeaderText = "Ancho"
        Me.ancho.Name = "ancho"
        Me.ancho.Width = 63
        '
        'alto
        '
        Me.alto.HeaderText = "Alto"
        Me.alto.Name = "alto"
        Me.alto.Width = 50
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 74
        '
        'cantidadproduccion
        '
        Me.cantidadproduccion.HeaderText = "A Producción"
        Me.cantidadproduccion.Name = "cantidadproduccion"
        Me.cantidadproduccion.Width = 96
        '
        'observaciones
        '
        Me.observaciones.HeaderText = "Observaciones"
        Me.observaciones.Name = "observaciones"
        Me.observaciones.Width = 103
        '
        'especial
        '
        Me.especial.HeaderText = "Especial"
        Me.especial.Name = "especial"
        Me.especial.Visible = False
        Me.especial.Width = 72
        '
        'btndibujo
        '
        Me.btndibujo.HeaderText = "..."
        Me.btndibujo.Name = "btndibujo"
        Me.btndibujo.Width = 22
        '
        'enedicion
        '
        Me.enedicion.HeaderText = "Edicion"
        Me.enedicion.Name = "enedicion"
        Me.enedicion.ReadOnly = True
        Me.enedicion.Visible = False
        Me.enedicion.Width = 48
        '
        'FrmTomaMedidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 371)
        Me.Controls.Add(Me.spcgeneral)
        Me.Name = "FrmTomaMedidas"
        Me.ShowIcon = False
        Me.Text = "Toma Medidas"
        Me.spcgeneral.Panel1.ResumeLayout(False)
        Me.spcgeneral.Panel2.ResumeLayout(False)
        CType(Me.spcgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spcgeneral.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents spcgeneral As SplitContainer
    Friend WithEvents dwItems As DatagridTreeView.DataTreeGridView
    Friend WithEvents eatomapuntos As ControlesPersonalizados.Estructurador.Estructurador_Acotado
    Friend WithEvents id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents iditemcontrato As DataGridViewTextBoxColumn
    Friend WithEvents idcotiza As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents ancho As DataGridViewTextBoxColumn
    Friend WithEvents alto As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents cantidadproduccion As DataGridViewTextBoxColumn
    Friend WithEvents observaciones As DataGridViewTextBoxColumn
    Friend WithEvents especial As DataGridViewTextBoxColumn
    Friend WithEvents btndibujo As DataGridViewButtonColumn
    Friend WithEvents enedicion As DataGridViewCheckBoxColumn
End Class
