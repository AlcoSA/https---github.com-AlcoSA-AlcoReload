<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmControlesEnlaceConectores
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
        Me.components = New System.ComponentModel.Container()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.control = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcontrol = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scgeneral = New System.Windows.Forms.SplitContainer()
        Me.scinfo = New System.Windows.Forms.SplitContainer()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scgeneral.Panel1.SuspendLayout()
        Me.scgeneral.Panel2.SuspendLayout()
        Me.scgeneral.SuspendLayout()
        CType(Me.scinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scinfo.Panel1.SuspendLayout()
        Me.scinfo.Panel2.SuspendLayout()
        Me.scinfo.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(15, 65)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(121, 21)
        Me.cmbEstado.TabIndex = 12
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
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.FechaCreacion, Me.UsuarioCreacion, Me.control, Me.FechaModificacion, Me.UsuarioModificacion, Me.Id_Estado, Me.Estado})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 0)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(528, 249)
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
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.Width = 97
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.Width = 103
        '
        'control
        '
        Me.control.HeaderText = "Control"
        Me.control.Name = "control"
        Me.control.ReadOnly = True
        Me.control.Width = 65
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha modificación"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.ReadOnly = True
        Me.FechaModificacion.Width = 114
        '
        'UsuarioModificacion
        '
        Me.UsuarioModificacion.HeaderText = "Usuario modificación"
        Me.UsuarioModificacion.Name = "UsuarioModificacion"
        Me.UsuarioModificacion.ReadOnly = True
        Me.UsuarioModificacion.Width = 119
        '
        'Id_Estado
        '
        Me.Id_Estado.HeaderText = "Id estado"
        Me.Id_Estado.Name = "Id_Estado"
        Me.Id_Estado.ReadOnly = True
        Me.Id_Estado.Visible = False
        Me.Id_Estado.Width = 70
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
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(528, 69)
        Me.fddFiltros.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Estado"
        '
        'txtcontrol
        '
        Me.txtcontrol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcontrol.Location = New System.Drawing.Point(15, 26)
        Me.txtcontrol.MaxLength = 50
        Me.txtcontrol.Name = "txtcontrol"
        Me.txtcontrol.Size = New System.Drawing.Size(271, 20)
        Me.txtcontrol.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Control"
        '
        'scgeneral
        '
        Me.scgeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scgeneral.Location = New System.Drawing.Point(0, 0)
        Me.scgeneral.Name = "scgeneral"
        Me.scgeneral.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scgeneral.Panel1
        '
        Me.scgeneral.Panel1.Controls.Add(Me.Label1)
        Me.scgeneral.Panel1.Controls.Add(Me.cmbEstado)
        Me.scgeneral.Panel1.Controls.Add(Me.txtcontrol)
        Me.scgeneral.Panel1.Controls.Add(Me.Label3)
        '
        'scgeneral.Panel2
        '
        Me.scgeneral.Panel2.Controls.Add(Me.scinfo)
        Me.scgeneral.Size = New System.Drawing.Size(528, 414)
        Me.scgeneral.SplitterDistance = 88
        Me.scgeneral.TabIndex = 14
        '
        'scinfo
        '
        Me.scinfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scinfo.Location = New System.Drawing.Point(0, 0)
        Me.scinfo.Name = "scinfo"
        Me.scinfo.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scinfo.Panel1
        '
        Me.scinfo.Panel1.Controls.Add(Me.fddFiltros)
        '
        'scinfo.Panel2
        '
        Me.scinfo.Panel2.Controls.Add(Me.dwItems)
        Me.scinfo.Size = New System.Drawing.Size(528, 322)
        Me.scinfo.SplitterDistance = 69
        Me.scinfo.TabIndex = 2
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmControlesEnlaceConectores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 414)
        Me.Controls.Add(Me.scgeneral)
        Me.Name = "FrmControlesEnlaceConectores"
        Me.ShowIcon = False
        Me.Text = "Formularios"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgeneral.Panel1.ResumeLayout(False)
        Me.scgeneral.Panel1.PerformLayout()
        Me.scgeneral.Panel2.ResumeLayout(False)
        CType(Me.scgeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scgeneral.ResumeLayout(False)
        Me.scinfo.Panel1.ResumeLayout(False)
        Me.scinfo.Panel2.ResumeLayout(False)
        CType(Me.scinfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scinfo.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcontrol As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents scgeneral As SplitContainer
    Friend WithEvents scinfo As SplitContainer
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents control As DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModificacion As DataGridViewTextBoxColumn
    Friend WithEvents Id_Estado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
End Class
