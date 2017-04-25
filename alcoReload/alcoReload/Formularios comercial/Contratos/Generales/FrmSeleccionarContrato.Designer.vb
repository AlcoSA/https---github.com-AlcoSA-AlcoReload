<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionarContrato
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaTerminacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoImpuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorContrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idtipoCotiza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Notas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NitYo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClienteYO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Administracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Improvistos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AIU_Utilidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 394)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(633, 31)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(560, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(70, 23)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(484, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(70, 23)
        Me.btnaceptar.TabIndex = 0
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltrado.Grid = Me.dwItem
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(633, 95)
        Me.fddFiltrado.TabIndex = 11
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoGenerateColumns = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.nit, Me.CodigoObra, Me.Cliente, Me.Obra, Me.nContrato, Me.FechaInicio, Me.FechaTerminacion, Me.TipoImpuesto, Me.ValorContrato, Me.idtipoCotiza, Me.Notas, Me.UsuarioCreacion, Me.UsuarioModi, Me.FechaModificacion, Me.NitYo, Me.ClienteYO, Me.AIU_Administracion, Me.AIU_Improvistos, Me.AIU_Utilidad})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 95)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItem.Size = New System.Drawing.Size(633, 299)
        Me.dwItem.TabIndex = 12
        Me.dwItem.TablaDatos = Nothing
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.id.Visible = False
        Me.id.Width = 24
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.fechaCreacion.Visible = False
        Me.fechaCreacion.Width = 87
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nit.Width = 26
        '
        'CodigoObra
        '
        Me.CodigoObra.HeaderText = "Código Obra"
        Me.CodigoObra.Name = "CodigoObra"
        Me.CodigoObra.ReadOnly = True
        Me.CodigoObra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CodigoObra.Width = 65
        '
        'Cliente
        '
        Me.Cliente.HeaderText = "Cliente"
        Me.Cliente.Name = "Cliente"
        Me.Cliente.ReadOnly = True
        Me.Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Cliente.Width = 45
        '
        'Obra
        '
        Me.Obra.HeaderText = "Obra"
        Me.Obra.Name = "Obra"
        Me.Obra.ReadOnly = True
        Me.Obra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Obra.Width = 36
        '
        'nContrato
        '
        Me.nContrato.HeaderText = "# Contrato Personalizado"
        Me.nContrato.Name = "nContrato"
        Me.nContrato.ReadOnly = True
        Me.nContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.nContrato.Width = 119
        '
        'FechaInicio
        '
        Me.FechaInicio.HeaderText = "Fecha Inicio"
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.ReadOnly = True
        Me.FechaInicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaInicio.Visible = False
        Me.FechaInicio.Width = 64
        '
        'FechaTerminacion
        '
        Me.FechaTerminacion.HeaderText = "Fecha Terminacion"
        Me.FechaTerminacion.Name = "FechaTerminacion"
        Me.FechaTerminacion.ReadOnly = True
        Me.FechaTerminacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FechaTerminacion.Width = 94
        '
        'TipoImpuesto
        '
        Me.TipoImpuesto.HeaderText = "TipoImpuesto"
        Me.TipoImpuesto.Name = "TipoImpuesto"
        Me.TipoImpuesto.ReadOnly = True
        Me.TipoImpuesto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.TipoImpuesto.Visible = False
        Me.TipoImpuesto.Width = 77
        '
        'ValorContrato
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "C0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ValorContrato.DefaultCellStyle = DataGridViewCellStyle1
        Me.ValorContrato.HeaderText = "Valor Contrato"
        Me.ValorContrato.Name = "ValorContrato"
        Me.ValorContrato.ReadOnly = True
        Me.ValorContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ValorContrato.Width = 72
        '
        'idtipoCotiza
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.idtipoCotiza.DefaultCellStyle = DataGridViewCellStyle2
        Me.idtipoCotiza.HeaderText = "Valor Iva"
        Me.idtipoCotiza.Name = "idtipoCotiza"
        Me.idtipoCotiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.idtipoCotiza.Visible = False
        Me.idtipoCotiza.Width = 50
        '
        'Notas
        '
        Me.Notas.HeaderText = "Notas"
        Me.Notas.Name = "Notas"
        Me.Notas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Notas.Width = 41
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario Creacion"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioCreacion.Visible = False
        Me.UsuarioCreacion.Width = 85
        '
        'UsuarioModi
        '
        Me.UsuarioModi.HeaderText = "Usuario Modi"
        Me.UsuarioModi.Name = "UsuarioModi"
        Me.UsuarioModi.ReadOnly = True
        Me.UsuarioModi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UsuarioModi.Visible = False
        Me.UsuarioModi.Width = 68
        '
        'FechaModificacion
        '
        Me.FechaModificacion.HeaderText = "Fecha Modificacion"
        Me.FechaModificacion.Name = "FechaModificacion"
        Me.FechaModificacion.Visible = False
        Me.FechaModificacion.Width = 114
        '
        'NitYo
        '
        Me.NitYo.HeaderText = "Nit Y/O"
        Me.NitYo.Name = "NitYo"
        Me.NitYo.Width = 63
        '
        'ClienteYO
        '
        Me.ClienteYO.HeaderText = "Cliente Y/O"
        Me.ClienteYO.Name = "ClienteYO"
        Me.ClienteYO.Width = 80
        '
        'AIU_Administracion
        '
        Me.AIU_Administracion.HeaderText = "AIU_Administracion"
        Me.AIU_Administracion.Name = "AIU_Administracion"
        Me.AIU_Administracion.ReadOnly = True
        Me.AIU_Administracion.Visible = False
        Me.AIU_Administracion.Width = 124
        '
        'AIU_Improvistos
        '
        Me.AIU_Improvistos.HeaderText = "AIU_Improvistos"
        Me.AIU_Improvistos.Name = "AIU_Improvistos"
        Me.AIU_Improvistos.ReadOnly = True
        Me.AIU_Improvistos.Visible = False
        Me.AIU_Improvistos.Width = 109
        '
        'AIU_Utilidad
        '
        Me.AIU_Utilidad.HeaderText = "AIU_Utilidad"
        Me.AIU_Utilidad.Name = "AIU_Utilidad"
        Me.AIU_Utilidad.ReadOnly = True
        Me.AIU_Utilidad.Visible = False
        Me.AIU_Utilidad.Width = 91
        '
        'FrmSeleccionarContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 425)
        Me.Controls.Add(Me.dwItem)
        Me.Controls.Add(Me.fddFiltrado)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmSeleccionarContrato"
        Me.ShowIcon = False
        Me.Text = "Seleccionar Contrato"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents CodigoObra As DataGridViewTextBoxColumn
    Friend WithEvents Cliente As DataGridViewTextBoxColumn
    Friend WithEvents Obra As DataGridViewTextBoxColumn
    Friend WithEvents nContrato As DataGridViewTextBoxColumn
    Friend WithEvents FechaInicio As DataGridViewTextBoxColumn
    Friend WithEvents FechaTerminacion As DataGridViewTextBoxColumn
    Friend WithEvents TipoImpuesto As DataGridViewTextBoxColumn
    Friend WithEvents ValorContrato As DataGridViewTextBoxColumn
    Friend WithEvents idtipoCotiza As DataGridViewTextBoxColumn
    Friend WithEvents Notas As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents FechaModificacion As DataGridViewTextBoxColumn
    Friend WithEvents NitYo As DataGridViewTextBoxColumn
    Friend WithEvents ClienteYO As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Administracion As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Improvistos As DataGridViewTextBoxColumn
    Friend WithEvents AIU_Utilidad As DataGridViewTextBoxColumn
End Class
