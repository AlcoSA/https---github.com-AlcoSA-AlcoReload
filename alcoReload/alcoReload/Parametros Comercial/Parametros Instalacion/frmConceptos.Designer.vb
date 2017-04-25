<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.cmbTipoObra = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbTipos = New System.Windows.Forms.GroupBox()
        Me.cbConceptoEspecial = New System.Windows.Forms.CheckBox()
        Me.cbConceptoContrato = New System.Windows.Forms.CheckBox()
        Me.cbConceptoAdicional = New System.Windows.Forms.CheckBox()
        Me.gbTipoCalculo = New System.Windows.Forms.GroupBox()
        Me.cbCruzaConOP = New System.Windows.Forms.CheckBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.undMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cContrato = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cAdicional = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cEspecial = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cruzaConOP = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gbTipos.SuspendLayout()
        Me.gbTipoCalculo.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Concepto:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Location = New System.Drawing.Point(106, 12)
        Me.txtConcepto.MaxLength = 50
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(347, 20)
        Me.txtConcepto.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 38)
        Me.txtDescripcion.MaxLength = 100
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(347, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripcion:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Unidad medida:"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(106, 64)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(89, 21)
        Me.cmbUnidadMedida.TabIndex = 5
        '
        'cmbTipoObra
        '
        Me.cmbTipoObra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoObra.FormattingEnabled = True
        Me.cmbTipoObra.Location = New System.Drawing.Point(281, 64)
        Me.cmbTipoObra.Name = "cmbTipoObra"
        Me.cmbTipoObra.Size = New System.Drawing.Size(172, 21)
        Me.cmbTipoObra.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(220, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo obra:"
        '
        'gbTipos
        '
        Me.gbTipos.Controls.Add(Me.cbConceptoEspecial)
        Me.gbTipos.Controls.Add(Me.cbConceptoContrato)
        Me.gbTipos.Controls.Add(Me.cbConceptoAdicional)
        Me.gbTipos.Location = New System.Drawing.Point(459, 12)
        Me.gbTipos.Name = "gbTipos"
        Me.gbTipos.Size = New System.Drawing.Size(159, 86)
        Me.gbTipos.TabIndex = 8
        Me.gbTipos.TabStop = False
        Me.gbTipos.Text = "Tipos"
        '
        'cbConceptoEspecial
        '
        Me.cbConceptoEspecial.AutoSize = True
        Me.cbConceptoEspecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbConceptoEspecial.Location = New System.Drawing.Point(25, 67)
        Me.cbConceptoEspecial.Name = "cbConceptoEspecial"
        Me.cbConceptoEspecial.Size = New System.Drawing.Size(114, 17)
        Me.cbConceptoEspecial.TabIndex = 2
        Me.cbConceptoEspecial.Text = "Concepto especial"
        Me.cbConceptoEspecial.UseVisualStyleBackColor = True
        '
        'cbConceptoContrato
        '
        Me.cbConceptoContrato.AutoSize = True
        Me.cbConceptoContrato.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbConceptoContrato.Location = New System.Drawing.Point(25, 21)
        Me.cbConceptoContrato.Name = "cbConceptoContrato"
        Me.cbConceptoContrato.Size = New System.Drawing.Size(114, 17)
        Me.cbConceptoContrato.TabIndex = 0
        Me.cbConceptoContrato.Text = "Concepto contrato"
        Me.cbConceptoContrato.UseVisualStyleBackColor = True
        '
        'cbConceptoAdicional
        '
        Me.cbConceptoAdicional.AutoSize = True
        Me.cbConceptoAdicional.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbConceptoAdicional.Location = New System.Drawing.Point(22, 44)
        Me.cbConceptoAdicional.Name = "cbConceptoAdicional"
        Me.cbConceptoAdicional.Size = New System.Drawing.Size(117, 17)
        Me.cbConceptoAdicional.TabIndex = 1
        Me.cbConceptoAdicional.Text = "Concepto adicional"
        Me.cbConceptoAdicional.UseVisualStyleBackColor = True
        '
        'gbTipoCalculo
        '
        Me.gbTipoCalculo.Controls.Add(Me.cbCruzaConOP)
        Me.gbTipoCalculo.Location = New System.Drawing.Point(624, 12)
        Me.gbTipoCalculo.Name = "gbTipoCalculo"
        Me.gbTipoCalculo.Size = New System.Drawing.Size(104, 73)
        Me.gbTipoCalculo.TabIndex = 9
        Me.gbTipoCalculo.TabStop = False
        Me.gbTipoCalculo.Text = "Tipo cálculo"
        '
        'cbCruzaConOP
        '
        Me.cbCruzaConOP.AutoSize = True
        Me.cbCruzaConOP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cbCruzaConOP.Location = New System.Drawing.Point(6, 19)
        Me.cbCruzaConOP.Name = "cbCruzaConOP"
        Me.cbCruzaConOP.Size = New System.Drawing.Size(92, 17)
        Me.cbCruzaConOP.TabIndex = 0
        Me.cbCruzaConOP.Text = "Cruza con OP"
        Me.cbCruzaConOP.UseVisualStyleBackColor = True
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(106, 91)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(89, 21)
        Me.cmbEstado.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Estado:"
        '
        'Panel
        '
        Me.Panel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel.Controls.Add(Me.dwItems)
        Me.Panel.Controls.Add(Me.fddFiltros)
        Me.Panel.Location = New System.Drawing.Point(12, 137)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(712, 343)
        Me.Panel.TabIndex = 12
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.concepto, Me.descripcion, Me.undMedida, Me.idTipoObra, Me.tipoObra, Me.cContrato, Me.cAdicional, Me.cEspecial, Me.cruzaConOP, Me.usuarioModi, Me.fechaModi, Me.idEstado, Me.estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 89)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(708, 250)
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
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Width = 97
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Width = 103
        '
        'concepto
        '
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        Me.concepto.Width = 78
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'undMedida
        '
        Me.undMedida.HeaderText = "Unidad medida"
        Me.undMedida.Name = "undMedida"
        Me.undMedida.ReadOnly = True
        Me.undMedida.Width = 95
        '
        'idTipoObra
        '
        Me.idTipoObra.HeaderText = "Id tipo obra"
        Me.idTipoObra.Name = "idTipoObra"
        Me.idTipoObra.ReadOnly = True
        Me.idTipoObra.Visible = False
        Me.idTipoObra.Width = 78
        '
        'tipoObra
        '
        Me.tipoObra.HeaderText = "Tipo obra"
        Me.tipoObra.Name = "tipoObra"
        Me.tipoObra.ReadOnly = True
        Me.tipoObra.Width = 71
        '
        'cContrato
        '
        Me.cContrato.HeaderText = "Contrato"
        Me.cContrato.Name = "cContrato"
        Me.cContrato.ReadOnly = True
        Me.cContrato.Width = 53
        '
        'cAdicional
        '
        Me.cAdicional.HeaderText = "Adicional"
        Me.cAdicional.Name = "cAdicional"
        Me.cAdicional.ReadOnly = True
        Me.cAdicional.Width = 56
        '
        'cEspecial
        '
        Me.cEspecial.HeaderText = "Especial"
        Me.cEspecial.Name = "cEspecial"
        Me.cEspecial.ReadOnly = True
        Me.cEspecial.Width = 53
        '
        'cruzaConOP
        '
        Me.cruzaConOP.HeaderText = "Cruza con OP"
        Me.cruzaConOP.Name = "cruzaConOP"
        Me.cruzaConOP.ReadOnly = True
        Me.cruzaConOP.Width = 58
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        Me.usuarioModi.Visible = False
        Me.usuarioModi.Width = 119
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Visible = False
        Me.fechaModi.Width = 114
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        Me.idEstado.Width = 70
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        Me.estado.Width = 65
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(708, 89)
        Me.fddFiltros.TabIndex = 0
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmConceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 492)
        Me.Controls.Add(Me.Panel)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gbTipoCalculo)
        Me.Controls.Add(Me.gbTipos)
        Me.Controls.Add(Me.cmbTipoObra)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbUnidadMedida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtConcepto)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConceptos"
        Me.ShowIcon = False
        Me.Text = "Conceptos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbTipos.ResumeLayout(False)
        Me.gbTipos.PerformLayout()
        Me.gbTipoCalculo.ResumeLayout(False)
        Me.gbTipoCalculo.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents cmbTipoObra As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents gbTipos As GroupBox
    Friend WithEvents cbConceptoEspecial As CheckBox
    Friend WithEvents cbConceptoContrato As CheckBox
    Friend WithEvents cbConceptoAdicional As CheckBox
    Friend WithEvents gbTipoCalculo As GroupBox
    Friend WithEvents cbCruzaConOP As CheckBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents concepto As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents undMedida As DataGridViewTextBoxColumn
    Friend WithEvents idTipoObra As DataGridViewTextBoxColumn
    Friend WithEvents tipoObra As DataGridViewTextBoxColumn
    Friend WithEvents cContrato As DataGridViewCheckBoxColumn
    Friend WithEvents cAdicional As DataGridViewCheckBoxColumn
    Friend WithEvents cEspecial As DataGridViewCheckBoxColumn
    Friend WithEvents cruzaConOP As DataGridViewCheckBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
End Class
