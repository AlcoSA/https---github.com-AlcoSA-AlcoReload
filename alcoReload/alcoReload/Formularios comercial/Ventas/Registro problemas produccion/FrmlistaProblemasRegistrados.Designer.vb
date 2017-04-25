<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmlistaProblemasRegistrados
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel = New System.Windows.Forms.Panel()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.consecutivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstadoSolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estadoSolucion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idOp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaRegistro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigoObra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contacto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idPais = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idDepartamento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idCiudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ciudad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idSeccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fechaAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usuarioAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcionProblema = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.Panel.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel.Location = New System.Drawing.Point(12, 12)
        Me.Panel.Name = "Panel"
        Me.Panel.Size = New System.Drawing.Size(674, 388)
        Me.Panel.TabIndex = 3
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.fechaCreacion, Me.usuarioCreacion, Me.consecutivo, Me.idEstadoSolucion, Me.estadoSolucion, Me.idOp, Me.fechaRegistro, Me.nit, Me.cliente, Me.codigoObra, Me.obra, Me.contacto, Me.idPais, Me.idDepartamento, Me.idCiudad, Me.ciudad, Me.telefono, Me.fax, Me.direccion, Me.idSeccion, Me.seccion, Me.idVendedor, Me.vendedor, Me.idEstado, Me.estado, Me.fechaModi, Me.usuarioModi, Me.fechaAnulacion, Me.usuarioAnulacion, Me.descripcionProblema})
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(0, 79)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(670, 305)
        Me.dwItems.TabIndex = 1
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'fechaCreacion
        '
        Me.fechaCreacion.HeaderText = "Fecha creación"
        Me.fechaCreacion.Name = "fechaCreacion"
        Me.fechaCreacion.ReadOnly = True
        Me.fechaCreacion.Visible = False
        '
        'usuarioCreacion
        '
        Me.usuarioCreacion.HeaderText = "Usuario creación"
        Me.usuarioCreacion.Name = "usuarioCreacion"
        Me.usuarioCreacion.ReadOnly = True
        Me.usuarioCreacion.Visible = False
        '
        'consecutivo
        '
        Me.consecutivo.HeaderText = "Consecutivo"
        Me.consecutivo.Name = "consecutivo"
        Me.consecutivo.ReadOnly = True
        '
        'idEstadoSolucion
        '
        Me.idEstadoSolucion.HeaderText = "Id estado solucion"
        Me.idEstadoSolucion.Name = "idEstadoSolucion"
        Me.idEstadoSolucion.ReadOnly = True
        Me.idEstadoSolucion.Visible = False
        '
        'estadoSolucion
        '
        Me.estadoSolucion.HeaderText = "Estado solución"
        Me.estadoSolucion.Name = "estadoSolucion"
        Me.estadoSolucion.ReadOnly = True
        '
        'idOp
        '
        Me.idOp.HeaderText = "Número op"
        Me.idOp.Name = "idOp"
        Me.idOp.ReadOnly = True
        '
        'fechaRegistro
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.fechaRegistro.DefaultCellStyle = DataGridViewCellStyle1
        Me.fechaRegistro.HeaderText = "Fecha registro"
        Me.fechaRegistro.Name = "fechaRegistro"
        Me.fechaRegistro.ReadOnly = True
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        '
        'codigoObra
        '
        Me.codigoObra.HeaderText = "Código obra"
        Me.codigoObra.Name = "codigoObra"
        Me.codigoObra.ReadOnly = True
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        '
        'contacto
        '
        Me.contacto.HeaderText = "Contacto"
        Me.contacto.Name = "contacto"
        Me.contacto.ReadOnly = True
        '
        'idPais
        '
        Me.idPais.HeaderText = "Id pais"
        Me.idPais.Name = "idPais"
        Me.idPais.ReadOnly = True
        Me.idPais.Visible = False
        '
        'idDepartamento
        '
        Me.idDepartamento.HeaderText = "Id departamento"
        Me.idDepartamento.Name = "idDepartamento"
        Me.idDepartamento.ReadOnly = True
        Me.idDepartamento.Visible = False
        '
        'idCiudad
        '
        Me.idCiudad.HeaderText = "Id ciudad"
        Me.idCiudad.Name = "idCiudad"
        Me.idCiudad.ReadOnly = True
        Me.idCiudad.Visible = False
        '
        'ciudad
        '
        Me.ciudad.HeaderText = "Ciudad"
        Me.ciudad.Name = "ciudad"
        Me.ciudad.ReadOnly = True
        '
        'telefono
        '
        Me.telefono.HeaderText = "Telefono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        '
        'fax
        '
        Me.fax.HeaderText = "Fax"
        Me.fax.Name = "fax"
        Me.fax.ReadOnly = True
        '
        'direccion
        '
        Me.direccion.HeaderText = "Dirección"
        Me.direccion.Name = "direccion"
        Me.direccion.ReadOnly = True
        '
        'idSeccion
        '
        Me.idSeccion.HeaderText = "Id seccion"
        Me.idSeccion.Name = "idSeccion"
        Me.idSeccion.ReadOnly = True
        Me.idSeccion.Visible = False
        '
        'seccion
        '
        Me.seccion.HeaderText = "Sección"
        Me.seccion.Name = "seccion"
        Me.seccion.ReadOnly = True
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "Id vendedor"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Visible = False
        '
        'vendedor
        '
        Me.vendedor.HeaderText = "Vendedor"
        Me.vendedor.Name = "vendedor"
        Me.vendedor.ReadOnly = True
        '
        'idEstado
        '
        Me.idEstado.HeaderText = "Id estado"
        Me.idEstado.Name = "idEstado"
        Me.idEstado.ReadOnly = True
        Me.idEstado.Visible = False
        '
        'estado
        '
        Me.estado.HeaderText = "Estado"
        Me.estado.Name = "estado"
        Me.estado.ReadOnly = True
        '
        'fechaModi
        '
        Me.fechaModi.HeaderText = "Fecha modificación"
        Me.fechaModi.Name = "fechaModi"
        Me.fechaModi.ReadOnly = True
        Me.fechaModi.Visible = False
        '
        'usuarioModi
        '
        Me.usuarioModi.HeaderText = "Usuario modificación"
        Me.usuarioModi.Name = "usuarioModi"
        Me.usuarioModi.ReadOnly = True
        '
        'fechaAnulacion
        '
        Me.fechaAnulacion.HeaderText = "Fecha anulación"
        Me.fechaAnulacion.Name = "fechaAnulacion"
        Me.fechaAnulacion.ReadOnly = True
        Me.fechaAnulacion.Visible = False
        '
        'usuarioAnulacion
        '
        Me.usuarioAnulacion.HeaderText = "Usuario anulación"
        Me.usuarioAnulacion.Name = "usuarioAnulacion"
        Me.usuarioAnulacion.ReadOnly = True
        Me.usuarioAnulacion.Visible = False
        '
        'descripcionProblema
        '
        Me.descripcionProblema.HeaderText = "Descripción problema"
        Me.descripcionProblema.Name = "descripcionProblema"
        Me.descripcionProblema.ReadOnly = True
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.fddFiltros.Grid = Me.dwItems
        Me.fddFiltros.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(670, 79)
        Me.fddFiltros.TabIndex = 0
        '
        'FrmlistaProblemasRegistrados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 412)
        Me.Controls.Add(Me.Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmlistaProblemasRegistrados"
        Me.ShowIcon = False
        Me.Text = "Lista problemas registrados"
        Me.Panel.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel As Panel
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents fechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents consecutivo As DataGridViewTextBoxColumn
    Friend WithEvents idEstadoSolucion As DataGridViewTextBoxColumn
    Friend WithEvents estadoSolucion As DataGridViewTextBoxColumn
    Friend WithEvents idOp As DataGridViewTextBoxColumn
    Friend WithEvents fechaRegistro As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents codigoObra As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents contacto As DataGridViewTextBoxColumn
    Friend WithEvents idPais As DataGridViewTextBoxColumn
    Friend WithEvents idDepartamento As DataGridViewTextBoxColumn
    Friend WithEvents idCiudad As DataGridViewTextBoxColumn
    Friend WithEvents ciudad As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents fax As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents idSeccion As DataGridViewTextBoxColumn
    Friend WithEvents seccion As DataGridViewTextBoxColumn
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents vendedor As DataGridViewTextBoxColumn
    Friend WithEvents idEstado As DataGridViewTextBoxColumn
    Friend WithEvents estado As DataGridViewTextBoxColumn
    Friend WithEvents fechaModi As DataGridViewTextBoxColumn
    Friend WithEvents usuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents fechaAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents usuarioAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents descripcionProblema As DataGridViewTextBoxColumn
End Class
