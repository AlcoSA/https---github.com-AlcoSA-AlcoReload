<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDuplicadoItem
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dwItem = New DatagridTreeView.DataTreeGridView()
        Me.cmbNombreCotiza = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.id = New DatagridTreeView.DataGridViewTreeColumn()
        Me.idArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ubicacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ancho = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mtCuadrados = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAcabadoPerfileria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acabadoPerfileria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idColorVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colorVidrio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEspesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espesor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.costoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precioInstalacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.referencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unidadMedida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.especial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre cotización"
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToOrderColumns = True
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.idArticulo, Me.ubicacion, Me.descripcion, Me.ancho, Me.alto, Me.mtCuadrados, Me.cantidad, Me.idAcabadoPerfileria, Me.acabadoPerfileria, Me.idVidrio, Me.vidrio, Me.idColorVidrio, Me.colorVidrio, Me.idEspesor, Me.espesor, Me.costoUnitario, Me.precioUnitario, Me.costoTotal, Me.total, Me.precioInstalacion, Me.referencia, Me.unidadMedida, Me.tipoItem, Me.especial})
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(12, 72)
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersVisible = False
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwItem.Size = New System.Drawing.Size(392, 154)
        Me.dwItem.TabIndex = 2
        '
        'cmbNombreCotiza
        '
        Me.cmbNombreCotiza.FormattingEnabled = True
        Me.cmbNombreCotiza.Location = New System.Drawing.Point(25, 35)
        Me.cmbNombreCotiza.Name = "cmbNombreCotiza"
        Me.cmbNombreCotiza.Size = New System.Drawing.Size(368, 21)
        Me.cmbNombreCotiza.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(329, 254)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(248, 254)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'id
        '
        Me.id.HeaderText = ""
        Me.id.ImagenporDefecto = Nothing
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 19
        '
        'idArticulo
        '
        Me.idArticulo.HeaderText = "idArticulo"
        Me.idArticulo.Name = "idArticulo"
        Me.idArticulo.ReadOnly = True
        Me.idArticulo.Visible = False
        Me.idArticulo.Width = 75
        '
        'ubicacion
        '
        Me.ubicacion.HeaderText = "Ubicación"
        Me.ubicacion.Name = "ubicacion"
        Me.ubicacion.ReadOnly = True
        Me.ubicacion.Width = 80
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 88
        '
        'ancho
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ancho.DefaultCellStyle = DataGridViewCellStyle1
        Me.ancho.HeaderText = "Ancho"
        Me.ancho.Name = "ancho"
        Me.ancho.ReadOnly = True
        Me.ancho.Width = 63
        '
        'alto
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.alto.DefaultCellStyle = DataGridViewCellStyle2
        Me.alto.HeaderText = "Alto"
        Me.alto.Name = "alto"
        Me.alto.ReadOnly = True
        Me.alto.Width = 50
        '
        'mtCuadrados
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.mtCuadrados.DefaultCellStyle = DataGridViewCellStyle3
        Me.mtCuadrados.HeaderText = "Mt²"
        Me.mtCuadrados.Name = "mtCuadrados"
        Me.mtCuadrados.ReadOnly = True
        Me.mtCuadrados.Width = 47
        '
        'cantidad
        '
        DataGridViewCellStyle4.Format = "N0"
        Me.cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.cantidad.HeaderText = "Cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        Me.cantidad.Width = 74
        '
        'idAcabadoPerfileria
        '
        Me.idAcabadoPerfileria.HeaderText = "idAcabadoPerfileria"
        Me.idAcabadoPerfileria.Name = "idAcabadoPerfileria"
        Me.idAcabadoPerfileria.ReadOnly = True
        Me.idAcabadoPerfileria.Visible = False
        Me.idAcabadoPerfileria.Width = 123
        '
        'acabadoPerfileria
        '
        Me.acabadoPerfileria.HeaderText = "Acabado perfilería"
        Me.acabadoPerfileria.Name = "acabadoPerfileria"
        Me.acabadoPerfileria.ReadOnly = True
        Me.acabadoPerfileria.Width = 119
        '
        'idVidrio
        '
        Me.idVidrio.HeaderText = "idVidrio"
        Me.idVidrio.Name = "idVidrio"
        Me.idVidrio.ReadOnly = True
        Me.idVidrio.Visible = False
        Me.idVidrio.Width = 66
        '
        'vidrio
        '
        Me.vidrio.HeaderText = "Vidrio"
        Me.vidrio.Name = "vidrio"
        Me.vidrio.ReadOnly = True
        Me.vidrio.Width = 58
        '
        'idColorVidrio
        '
        Me.idColorVidrio.HeaderText = "idColorVidrio"
        Me.idColorVidrio.Name = "idColorVidrio"
        Me.idColorVidrio.ReadOnly = True
        Me.idColorVidrio.Visible = False
        Me.idColorVidrio.Width = 90
        '
        'colorVidrio
        '
        Me.colorVidrio.HeaderText = "Color de vidrio"
        Me.colorVidrio.Name = "colorVidrio"
        Me.colorVidrio.ReadOnly = True
        Me.colorVidrio.Width = 99
        '
        'idEspesor
        '
        Me.idEspesor.HeaderText = "idEspesor"
        Me.idEspesor.Name = "idEspesor"
        Me.idEspesor.ReadOnly = True
        Me.idEspesor.Visible = False
        Me.idEspesor.Width = 78
        '
        'espesor
        '
        Me.espesor.HeaderText = "Espesor"
        Me.espesor.Name = "espesor"
        Me.espesor.ReadOnly = True
        Me.espesor.Width = 70
        '
        'costoUnitario
        '
        DataGridViewCellStyle5.Format = "N0"
        Me.costoUnitario.DefaultCellStyle = DataGridViewCellStyle5
        Me.costoUnitario.HeaderText = "Costo unitario"
        Me.costoUnitario.Name = "costoUnitario"
        Me.costoUnitario.ReadOnly = True
        Me.costoUnitario.Width = 96
        '
        'precioUnitario
        '
        DataGridViewCellStyle6.Format = "N0"
        Me.precioUnitario.DefaultCellStyle = DataGridViewCellStyle6
        Me.precioUnitario.HeaderText = "Precio unitario"
        Me.precioUnitario.Name = "precioUnitario"
        Me.precioUnitario.ReadOnly = True
        Me.precioUnitario.Width = 99
        '
        'costoTotal
        '
        DataGridViewCellStyle7.Format = "N0"
        Me.costoTotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.costoTotal.HeaderText = "Costo total"
        Me.costoTotal.Name = "costoTotal"
        Me.costoTotal.ReadOnly = True
        Me.costoTotal.Width = 82
        '
        'total
        '
        DataGridViewCellStyle8.Format = "N0"
        Me.total.DefaultCellStyle = DataGridViewCellStyle8
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.Width = 56
        '
        'precioInstalacion
        '
        DataGridViewCellStyle9.Format = "N0"
        Me.precioInstalacion.DefaultCellStyle = DataGridViewCellStyle9
        Me.precioInstalacion.HeaderText = "Precio instalación"
        Me.precioInstalacion.Name = "precioInstalacion"
        Me.precioInstalacion.ReadOnly = True
        Me.precioInstalacion.Width = 115
        '
        'referencia
        '
        Me.referencia.HeaderText = "Referencia"
        Me.referencia.Name = "referencia"
        Me.referencia.ReadOnly = True
        Me.referencia.Visible = False
        Me.referencia.Width = 84
        '
        'unidadMedida
        '
        Me.unidadMedida.HeaderText = "Unidad medida"
        Me.unidadMedida.Name = "unidadMedida"
        Me.unidadMedida.ReadOnly = True
        Me.unidadMedida.Visible = False
        Me.unidadMedida.Width = 103
        '
        'tipoItem
        '
        Me.tipoItem.HeaderText = "tipoItem"
        Me.tipoItem.Name = "tipoItem"
        Me.tipoItem.ReadOnly = True
        Me.tipoItem.Visible = False
        Me.tipoItem.Width = 69
        '
        'especial
        '
        Me.especial.HeaderText = "Especial"
        Me.especial.Name = "especial"
        Me.especial.ReadOnly = True
        Me.especial.Visible = False
        Me.especial.Width = 72
        '
        'frmDuplicadoItem
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(416, 289)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cmbNombreCotiza)
        Me.Controls.Add(Me.dwItem)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDuplicadoItem"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicado item"
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents dwItem As DatagridTreeView.DataTreeGridView
    Friend WithEvents cmbNombreCotiza As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAceptar As Button
    Friend WithEvents id As DatagridTreeView.DataGridViewTreeColumn
    Friend WithEvents idArticulo As DataGridViewTextBoxColumn
    Friend WithEvents ubicacion As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents ancho As DataGridViewTextBoxColumn
    Friend WithEvents alto As DataGridViewTextBoxColumn
    Friend WithEvents mtCuadrados As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents idAcabadoPerfileria As DataGridViewTextBoxColumn
    Friend WithEvents acabadoPerfileria As DataGridViewTextBoxColumn
    Friend WithEvents idVidrio As DataGridViewTextBoxColumn
    Friend WithEvents vidrio As DataGridViewTextBoxColumn
    Friend WithEvents idColorVidrio As DataGridViewTextBoxColumn
    Friend WithEvents colorVidrio As DataGridViewTextBoxColumn
    Friend WithEvents idEspesor As DataGridViewTextBoxColumn
    Friend WithEvents espesor As DataGridViewTextBoxColumn
    Friend WithEvents costoUnitario As DataGridViewTextBoxColumn
    Friend WithEvents precioUnitario As DataGridViewTextBoxColumn
    Friend WithEvents costoTotal As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
    Friend WithEvents precioInstalacion As DataGridViewTextBoxColumn
    Friend WithEvents referencia As DataGridViewTextBoxColumn
    Friend WithEvents unidadMedida As DataGridViewTextBoxColumn
    Friend WithEvents tipoItem As DataGridViewTextBoxColumn
    Friend WithEvents especial As DataGridViewTextBoxColumn
End Class
