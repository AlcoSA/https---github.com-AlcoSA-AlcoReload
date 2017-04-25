<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmListaParaAprobaciones
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.fddFiltrado = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_contrato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codigo_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mail_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contacto_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contacto_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ciudad_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mail_obra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_recibido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_Toma_medidas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_tiempo_entrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tiempo_entrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SemanaEntrega = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Puntos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Zona = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Metros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Destino_Materiales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTerceroProd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerceroProduccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirTercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telTercero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nroDevoluciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioCreacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioModi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioAprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAprobacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsuarioAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaAnulacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idestado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.indDiasHabiles = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.facturable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Aproba_cliente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkSeleccion = New System.Windows.Forms.CheckBox()
        Me.prefijoVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.visroReportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.bwcargas = New System.ComponentModel.BackgroundWorker()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.fddFiltrado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dwItems)
        Me.SplitContainer1.Panel2.Controls.Add(Me.lblError)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.chkSeleccion)
        Me.SplitContainer1.Size = New System.Drawing.Size(297, 440)
        Me.SplitContainer1.SplitterDistance = 95
        Me.SplitContainer1.TabIndex = 2
        '
        'fddFiltrado
        '
        Me.fddFiltrado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltrado.Grid = Nothing
        Me.fddFiltrado.Location = New System.Drawing.Point(0, 0)
        Me.fddFiltrado.Name = "fddFiltrado"
        Me.fddFiltrado.Size = New System.Drawing.Size(297, 95)
        Me.fddFiltrado.TabIndex = 0
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeColumns = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoGenerateColumns = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion, Me.Id, Me.Id_contrato, Me.codigo_obra, Me.obra, Me.nit, Me.cliente, Me.telefono_cliente, Me.direccion_cliente, Me.mail_cliente, Me.contacto_cliente, Me.contacto_obra, Me.telefono_obra, Me.direccion_obra, Me.ciudad_obra, Me.mail_obra, Me.fecha_recibido, Me.fecha_Toma_medidas, Me.id_tiempo_entrega, Me.tiempo_entrega, Me.FechaEntrega, Me.SemanaEntrega, Me.Puntos, Me.idVendedor, Me.Zona, Me.Metros, Me.Destino_Materiales, Me.idTerceroProd, Me.TerceroProduccion, Me.DirTercero, Me.telTercero, Me.nroDevoluciones, Me.FechaCreacion, Me.UsuarioCreacion, Me.FechaModi, Me.UsuarioModi, Me.UsuarioAprobacion, Me.FechaAprobacion, Me.UsuarioAnulacion, Me.FechaAnulacion, Me.Idestado, Me.Estado, Me.indDiasHabiles, Me.facturable, Me.Aproba_cliente})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(8, 27)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.RowHeadersWidth = 30
        Me.dwItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItems.Size = New System.Drawing.Size(286, 302)
        Me.dwItems.TabIndex = 5
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'seleccion
        '
        Me.seleccion.Frozen = True
        Me.seleccion.HeaderText = ""
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Width = 5
        '
        'Id
        '
        Me.Id.HeaderText = "Id"
        Me.Id.Name = "Id"
        Me.Id.ReadOnly = True
        Me.Id.Width = 41
        '
        'Id_contrato
        '
        Me.Id_contrato.HeaderText = "Id contrato"
        Me.Id_contrato.Name = "Id_contrato"
        Me.Id_contrato.ReadOnly = True
        Me.Id_contrato.Visible = False
        Me.Id_contrato.Width = 83
        '
        'codigo_obra
        '
        Me.codigo_obra.HeaderText = "Código obra"
        Me.codigo_obra.Name = "codigo_obra"
        Me.codigo_obra.ReadOnly = True
        Me.codigo_obra.Width = 82
        '
        'obra
        '
        Me.obra.HeaderText = "Obra"
        Me.obra.Name = "obra"
        Me.obra.ReadOnly = True
        Me.obra.Width = 55
        '
        'nit
        '
        Me.nit.HeaderText = "Nit"
        Me.nit.Name = "nit"
        Me.nit.ReadOnly = True
        Me.nit.Width = 45
        '
        'cliente
        '
        Me.cliente.HeaderText = "Cliente"
        Me.cliente.Name = "cliente"
        Me.cliente.ReadOnly = True
        Me.cliente.Width = 64
        '
        'telefono_cliente
        '
        Me.telefono_cliente.HeaderText = "Teléfono cliente"
        Me.telefono_cliente.Name = "telefono_cliente"
        Me.telefono_cliente.ReadOnly = True
        Me.telefono_cliente.Width = 99
        '
        'direccion_cliente
        '
        Me.direccion_cliente.HeaderText = "Dirección cliente"
        Me.direccion_cliente.Name = "direccion_cliente"
        Me.direccion_cliente.ReadOnly = True
        Me.direccion_cliente.Width = 102
        '
        'mail_cliente
        '
        Me.mail_cliente.HeaderText = "Mail cliente"
        Me.mail_cliente.Name = "mail_cliente"
        Me.mail_cliente.ReadOnly = True
        Me.mail_cliente.Width = 78
        '
        'contacto_cliente
        '
        Me.contacto_cliente.HeaderText = "Contacto cliente"
        Me.contacto_cliente.Name = "contacto_cliente"
        Me.contacto_cliente.ReadOnly = True
        '
        'contacto_obra
        '
        Me.contacto_obra.HeaderText = "Contacto obra"
        Me.contacto_obra.Name = "contacto_obra"
        Me.contacto_obra.ReadOnly = True
        Me.contacto_obra.Width = 91
        '
        'telefono_obra
        '
        Me.telefono_obra.HeaderText = "Teléfono obra"
        Me.telefono_obra.Name = "telefono_obra"
        Me.telefono_obra.ReadOnly = True
        Me.telefono_obra.Width = 90
        '
        'direccion_obra
        '
        Me.direccion_obra.HeaderText = "Dirección obra"
        Me.direccion_obra.Name = "direccion_obra"
        Me.direccion_obra.ReadOnly = True
        Me.direccion_obra.Width = 93
        '
        'ciudad_obra
        '
        Me.ciudad_obra.HeaderText = "Ciudad obra"
        Me.ciudad_obra.Name = "ciudad_obra"
        Me.ciudad_obra.ReadOnly = True
        Me.ciudad_obra.Width = 82
        '
        'mail_obra
        '
        Me.mail_obra.HeaderText = "Mail obra"
        Me.mail_obra.Name = "mail_obra"
        Me.mail_obra.ReadOnly = True
        Me.mail_obra.Width = 69
        '
        'fecha_recibido
        '
        Me.fecha_recibido.HeaderText = "Fecha recibido"
        Me.fecha_recibido.Name = "fecha_recibido"
        Me.fecha_recibido.ReadOnly = True
        Me.fecha_recibido.Width = 94
        '
        'fecha_Toma_medidas
        '
        Me.fecha_Toma_medidas.HeaderText = "Fecha toma medidas"
        Me.fecha_Toma_medidas.Name = "fecha_Toma_medidas"
        Me.fecha_Toma_medidas.ReadOnly = True
        Me.fecha_Toma_medidas.Width = 119
        '
        'id_tiempo_entrega
        '
        Me.id_tiempo_entrega.HeaderText = "Id tiempo entrega"
        Me.id_tiempo_entrega.Name = "id_tiempo_entrega"
        Me.id_tiempo_entrega.ReadOnly = True
        Me.id_tiempo_entrega.Width = 105
        '
        'tiempo_entrega
        '
        Me.tiempo_entrega.HeaderText = "Tiempo entrega"
        Me.tiempo_entrega.Name = "tiempo_entrega"
        Me.tiempo_entrega.ReadOnly = True
        Me.tiempo_entrega.Width = 97
        '
        'FechaEntrega
        '
        Me.FechaEntrega.HeaderText = "Fecha entrega"
        Me.FechaEntrega.Name = "FechaEntrega"
        Me.FechaEntrega.ReadOnly = True
        Me.FechaEntrega.Width = 93
        '
        'SemanaEntrega
        '
        Me.SemanaEntrega.HeaderText = "Semana entrega"
        Me.SemanaEntrega.Name = "SemanaEntrega"
        Me.SemanaEntrega.ReadOnly = True
        Me.SemanaEntrega.Width = 101
        '
        'Puntos
        '
        Me.Puntos.HeaderText = "Puntos"
        Me.Puntos.Name = "Puntos"
        Me.Puntos.ReadOnly = True
        Me.Puntos.Width = 65
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "Id vendedor"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Width = 82
        '
        'Zona
        '
        Me.Zona.HeaderText = "Zona"
        Me.Zona.Name = "Zona"
        Me.Zona.ReadOnly = True
        Me.Zona.Width = 57
        '
        'Metros
        '
        Me.Metros.HeaderText = "Metros"
        Me.Metros.Name = "Metros"
        Me.Metros.ReadOnly = True
        Me.Metros.Width = 64
        '
        'Destino_Materiales
        '
        Me.Destino_Materiales.HeaderText = "Destino materiales"
        Me.Destino_Materiales.Name = "Destino_Materiales"
        Me.Destino_Materiales.ReadOnly = True
        Me.Destino_Materiales.Width = 108
        '
        'idTerceroProd
        '
        Me.idTerceroProd.HeaderText = "Id tercero producción"
        Me.idTerceroProd.Name = "idTerceroProd"
        Me.idTerceroProd.ReadOnly = True
        Me.idTerceroProd.Visible = False
        Me.idTerceroProd.Width = 122
        '
        'TerceroProduccion
        '
        Me.TerceroProduccion.HeaderText = "Tercero producción"
        Me.TerceroProduccion.Name = "TerceroProduccion"
        Me.TerceroProduccion.ReadOnly = True
        Me.TerceroProduccion.Width = 114
        '
        'DirTercero
        '
        Me.DirTercero.HeaderText = "Dirección tercero"
        Me.DirTercero.Name = "DirTercero"
        Me.DirTercero.ReadOnly = True
        Me.DirTercero.Width = 104
        '
        'telTercero
        '
        Me.telTercero.HeaderText = "Teléfono tercero"
        Me.telTercero.Name = "telTercero"
        Me.telTercero.ReadOnly = True
        Me.telTercero.Width = 101
        '
        'nroDevoluciones
        '
        Me.nroDevoluciones.HeaderText = "Número devoluciones"
        Me.nroDevoluciones.Name = "nroDevoluciones"
        Me.nroDevoluciones.ReadOnly = True
        Me.nroDevoluciones.Width = 123
        '
        'FechaCreacion
        '
        Me.FechaCreacion.HeaderText = "Fecha creación"
        Me.FechaCreacion.Name = "FechaCreacion"
        Me.FechaCreacion.ReadOnly = True
        Me.FechaCreacion.Visible = False
        Me.FechaCreacion.Width = 97
        '
        'UsuarioCreacion
        '
        Me.UsuarioCreacion.HeaderText = "Usuario creación"
        Me.UsuarioCreacion.Name = "UsuarioCreacion"
        Me.UsuarioCreacion.ReadOnly = True
        Me.UsuarioCreacion.Visible = False
        Me.UsuarioCreacion.Width = 103
        '
        'FechaModi
        '
        Me.FechaModi.HeaderText = "Fecha modificación"
        Me.FechaModi.Name = "FechaModi"
        Me.FechaModi.ReadOnly = True
        Me.FechaModi.Visible = False
        Me.FechaModi.Width = 114
        '
        'UsuarioModi
        '
        Me.UsuarioModi.HeaderText = "Usuario modificacion"
        Me.UsuarioModi.Name = "UsuarioModi"
        Me.UsuarioModi.ReadOnly = True
        Me.UsuarioModi.Visible = False
        Me.UsuarioModi.Width = 119
        '
        'UsuarioAprobacion
        '
        Me.UsuarioAprobacion.HeaderText = "Usuario aprobación"
        Me.UsuarioAprobacion.Name = "UsuarioAprobacion"
        Me.UsuarioAprobacion.ReadOnly = True
        Me.UsuarioAprobacion.Visible = False
        Me.UsuarioAprobacion.Width = 114
        '
        'FechaAprobacion
        '
        Me.FechaAprobacion.HeaderText = "Fecha aprobación"
        Me.FechaAprobacion.Name = "FechaAprobacion"
        Me.FechaAprobacion.ReadOnly = True
        Me.FechaAprobacion.Visible = False
        Me.FechaAprobacion.Width = 108
        '
        'UsuarioAnulacion
        '
        Me.UsuarioAnulacion.HeaderText = "Usuario anulación"
        Me.UsuarioAnulacion.Name = "UsuarioAnulacion"
        Me.UsuarioAnulacion.ReadOnly = True
        Me.UsuarioAnulacion.Visible = False
        Me.UsuarioAnulacion.Width = 107
        '
        'FechaAnulacion
        '
        Me.FechaAnulacion.HeaderText = "Fecha anulación"
        Me.FechaAnulacion.Name = "FechaAnulacion"
        Me.FechaAnulacion.ReadOnly = True
        Me.FechaAnulacion.Visible = False
        Me.FechaAnulacion.Width = 102
        '
        'Idestado
        '
        Me.Idestado.HeaderText = "Id estado"
        Me.Idestado.Name = "Idestado"
        Me.Idestado.ReadOnly = True
        Me.Idestado.Visible = False
        Me.Idestado.Width = 70
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 65
        '
        'indDiasHabiles
        '
        Me.indDiasHabiles.HeaderText = "Dias hábiles"
        Me.indDiasHabiles.Name = "indDiasHabiles"
        Me.indDiasHabiles.ReadOnly = True
        Me.indDiasHabiles.Width = 63
        '
        'facturable
        '
        Me.facturable.HeaderText = "Facturable"
        Me.facturable.Name = "facturable"
        Me.facturable.ReadOnly = True
        Me.facturable.Width = 63
        '
        'Aproba_cliente
        '
        Me.Aproba_cliente.HeaderText = "Aprobación cliente"
        Me.Aproba_cliente.Name = "Aproba_cliente"
        Me.Aproba_cliente.ReadOnly = True
        Me.Aproba_cliente.Width = 91
        '
        'lblError
        '
        Me.lblError.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblError.AutoSize = True
        Me.lblError.Location = New System.Drawing.Point(275, 8)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 13)
        Me.lblError.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Seleccionar todos"
        '
        'chkSeleccion
        '
        Me.chkSeleccion.AutoSize = True
        Me.chkSeleccion.BackColor = System.Drawing.Color.Transparent
        Me.chkSeleccion.Location = New System.Drawing.Point(8, 7)
        Me.chkSeleccion.Name = "chkSeleccion"
        Me.chkSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.chkSeleccion.TabIndex = 1
        Me.chkSeleccion.UseVisualStyleBackColor = False
        '
        'prefijoVendedor
        '
        Me.prefijoVendedor.HeaderText = "Vendedor"
        Me.prefijoVendedor.Name = "prefijoVendedor"
        Me.prefijoVendedor.ReadOnly = True
        Me.prefijoVendedor.Width = 78
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.visroReportes)
        Me.SplitContainer2.Size = New System.Drawing.Size(943, 440)
        Me.SplitContainer2.SplitterDistance = 297
        Me.SplitContainer2.TabIndex = 3
        '
        'visroReportes
        '
        Me.visroReportes.ActiveViewIndex = -1
        Me.visroReportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.visroReportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.visroReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.visroReportes.EnableToolTips = False
        Me.visroReportes.Location = New System.Drawing.Point(0, 0)
        Me.visroReportes.Name = "visroReportes"
        Me.visroReportes.ShowLogo = False
        Me.visroReportes.Size = New System.Drawing.Size(642, 440)
        Me.visroReportes.TabIndex = 0
        Me.visroReportes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'bwcargas
        '
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'FrmListaParaAprobaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 440)
        Me.Controls.Add(Me.SplitContainer2)
        Me.Name = "FrmListaParaAprobaciones"
        Me.ShowIcon = False
        Me.Text = "Disponibles para ordenes de pedido"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents prefijoVendedor As DataGridViewTextBoxColumn
    Friend WithEvents fddFiltrado As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents chkSeleccion As CheckBox
    Friend WithEvents visroReportes As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bwcargas As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As Label
    Friend WithEvents lblError As Label
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents Id As DataGridViewTextBoxColumn
    Friend WithEvents Id_contrato As DataGridViewTextBoxColumn
    Friend WithEvents codigo_obra As DataGridViewTextBoxColumn
    Friend WithEvents obra As DataGridViewTextBoxColumn
    Friend WithEvents nit As DataGridViewTextBoxColumn
    Friend WithEvents cliente As DataGridViewTextBoxColumn
    Friend WithEvents telefono_cliente As DataGridViewTextBoxColumn
    Friend WithEvents direccion_cliente As DataGridViewTextBoxColumn
    Friend WithEvents mail_cliente As DataGridViewTextBoxColumn
    Friend WithEvents contacto_cliente As DataGridViewTextBoxColumn
    Friend WithEvents contacto_obra As DataGridViewTextBoxColumn
    Friend WithEvents telefono_obra As DataGridViewTextBoxColumn
    Friend WithEvents direccion_obra As DataGridViewTextBoxColumn
    Friend WithEvents ciudad_obra As DataGridViewTextBoxColumn
    Friend WithEvents mail_obra As DataGridViewTextBoxColumn
    Friend WithEvents fecha_recibido As DataGridViewTextBoxColumn
    Friend WithEvents fecha_Toma_medidas As DataGridViewTextBoxColumn
    Friend WithEvents id_tiempo_entrega As DataGridViewTextBoxColumn
    Friend WithEvents tiempo_entrega As DataGridViewTextBoxColumn
    Friend WithEvents FechaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents SemanaEntrega As DataGridViewTextBoxColumn
    Friend WithEvents Puntos As DataGridViewTextBoxColumn
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents Zona As DataGridViewTextBoxColumn
    Friend WithEvents Metros As DataGridViewTextBoxColumn
    Friend WithEvents Destino_Materiales As DataGridViewTextBoxColumn
    Friend WithEvents idTerceroProd As DataGridViewTextBoxColumn
    Friend WithEvents TerceroProduccion As DataGridViewTextBoxColumn
    Friend WithEvents DirTercero As DataGridViewTextBoxColumn
    Friend WithEvents telTercero As DataGridViewTextBoxColumn
    Friend WithEvents nroDevoluciones As DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioCreacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaModi As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioModi As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioAprobacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaAprobacion As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents FechaAnulacion As DataGridViewTextBoxColumn
    Friend WithEvents Idestado As DataGridViewTextBoxColumn
    Friend WithEvents Estado As DataGridViewTextBoxColumn
    Friend WithEvents indDiasHabiles As DataGridViewCheckBoxColumn
    Friend WithEvents facturable As DataGridViewCheckBoxColumn
    Friend WithEvents Aproba_cliente As DataGridViewCheckBoxColumn
End Class
