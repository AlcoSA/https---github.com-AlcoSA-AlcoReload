<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMotivosPorSecciones
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
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefijoSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSecciones = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.cmbMotivo = New ComboBoxMultiColumna.CmbMultiColumna()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 81)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(702, 362)
        Me.Panel.TabIndex = 5
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idSeccion, Me.prefijoSeccion, Me.seccion, Me.idConcepto, Me.codigoMotivo, Me.motivo})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 114)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(692, 241)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 22
        '
        'idSeccion
        '
        Me.idSeccion.HeaderText = "Id sección"
        Me.idSeccion.Name = "idSeccion"
        Me.idSeccion.ReadOnly = True
        Me.idSeccion.Visible = False
        Me.idSeccion.Width = 62
        '
        'prefijoSeccion
        '
        Me.prefijoSeccion.HeaderText = "Prefijo sección"
        Me.prefijoSeccion.Name = "prefijoSeccion"
        Me.prefijoSeccion.ReadOnly = True
        Me.prefijoSeccion.Width = 101
        '
        'seccion
        '
        Me.seccion.HeaderText = "Sección"
        Me.seccion.Name = "seccion"
        Me.seccion.ReadOnly = True
        Me.seccion.Width = 71
        '
        'idConcepto
        '
        Me.idConcepto.HeaderText = "Id concepto"
        Me.idConcepto.Name = "idConcepto"
        Me.idConcepto.ReadOnly = True
        Me.idConcepto.Visible = False
        Me.idConcepto.Width = 89
        '
        'codigoMotivo
        '
        Me.codigoMotivo.HeaderText = "Codigo motivo"
        Me.codigoMotivo.Name = "codigoMotivo"
        Me.codigoMotivo.ReadOnly = True
        Me.codigoMotivo.Width = 99
        '
        'motivo
        '
        Me.motivo.HeaderText = "Motivo"
        Me.motivo.Name = "motivo"
        Me.motivo.ReadOnly = True
        Me.motivo.Width = 64
        '
        'fddFiltros
        '
        Me.fddFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(692, 105)
        Me.fddFiltros.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sección"
        '
        'cmbSecciones
        '
        Me.cmbSecciones.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbSecciones.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbSecciones.DropDownHeight = 200
        Me.cmbSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSecciones.DropDownWidth = 300
        Me.cmbSecciones.IntegralHeight = False
        Me.cmbSecciones.Location = New System.Drawing.Point(12, 41)
        Me.cmbSecciones.Name = "cmbSecciones"
        Me.cmbSecciones.Size = New System.Drawing.Size(95, 21)
        Me.cmbSecciones.TabIndex = 1
        '
        'cmbMotivo
        '
        Me.cmbMotivo.DatosVisibles = New String() {"idSiesa", "Nombre"}
        Me.cmbMotivo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbMotivo.DropDownHeight = 200
        Me.cmbMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMotivo.DropDownWidth = 300
        Me.cmbMotivo.IntegralHeight = False
        Me.cmbMotivo.Location = New System.Drawing.Point(136, 41)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(216, 21)
        Me.cmbMotivo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(133, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Motivo"
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(381, 39)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmMotivosPorSecciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 455)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.cmbMotivo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbSecciones)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMotivosPorSecciones"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Motivos por secciones"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSecciones As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents cmbMotivo As ComboBoxMultiColumna.CmbMultiColumna
    Friend WithEvents Label2 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents idSeccion As DataGridViewTextBoxColumn
    Friend WithEvents prefijoSeccion As DataGridViewTextBoxColumn
    Friend WithEvents seccion As DataGridViewTextBoxColumn
    Friend WithEvents idConcepto As DataGridViewTextBoxColumn
    Friend WithEvents codigoMotivo As DataGridViewTextBoxColumn
    Friend WithEvents motivo As DataGridViewTextBoxColumn
End Class
