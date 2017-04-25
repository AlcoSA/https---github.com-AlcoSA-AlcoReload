Imports DatagridTreeView
Imports ReglasNegocio.cotizaciones
Imports ReglasNegocio.movitoHijos
Imports ReglasNegocio.movitoPadres

Public Class frmDuplicadoItem
#Region "Variables"
    Private mCotizacion As ClsCostizaciones
    Private mMovitoPadre As ClsMovitoPadres
    Private mMovitoHijo As ClsMovitoHijos
#End Region
#Region "Propiedades"
    Private _Nodo As DataGridViewTreeNode
    Public ReadOnly Property Nodo() As DataGridViewTreeNode
        Get
            Return _Nodo
        End Get
    End Property
#End Region
    Private Sub frmDuplicadoItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            mCotizacion = New ClsCostizaciones
            'Dim ListNombreCotiza As List(Of cotizacion) = mCotizacion.TraerNombreCotizacion()
            'txtNombreCotizacion.AutoCompleteCustomSource.AddRange(ListNombreCotiza.Select(Function(a) a.nombreCotizacion).ToArray())

            Dim listCotiza As List(Of cotizacion) = mCotizacion.traerTodos()
            listCotiza.Insert(0, New cotizacion)
            cmbNombreCotiza.DisplayMember = "nombreCotizacion"
            cmbNombreCotiza.ValueMember = "id"
            cmbNombreCotiza.DataSource = listCotiza
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub cmbNombreCotiza_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNombreCotiza.SelectedValueChanged
        Try
            dwItem.Nodes.Clear()
            mMovitoPadre = New ClsMovitoPadres
            Dim listPadre As List(Of movitoPadre) = mMovitoPadre.TraerxIdCotiza(cmbNombreCotiza.SelectedValue)
            Dim idPadre As Integer
            For Each item As movitoPadre In listPadre
                Dim ndp As DataGridViewTreeNode = dwItem.Nodes.Add()
                ndp.Cells(ubicacion.Index).Value = item.ubicacion
                ndp.Cells(idArticulo.Index).Value = 0
                ndp.Cells(descripcion.Index).Value = item.descripcion
                ndp.Cells(ancho.Index).Value = item.ancho
                ndp.Cells(alto.Index).Value = item.alto
                ndp.Cells(mtCuadrados.Index).Value = "Pendiente"
                ndp.Cells(cantidad.Index).Value = item.cantidad
                ndp.Cells(idAcabadoPerfileria.Index).Value = item.idAcabadoPerfil
                ndp.Cells(acabadoPerfileria.Index).Value = item.acabadoPerfil
                ndp.Cells(idVidrio.Index).Value = item.idVidrio
                ndp.Cells(vidrio.Index).Value = item.vidrio
                ndp.Cells(idColorVidrio.Index).Value = item.idColorVidrio
                ndp.Cells(colorVidrio.Index).Value = item.colorVidrio
                ndp.Cells(idEspesor.Index).Value = item.idEspesor
                ndp.Cells(espesor.Index).Value = item.espesor
                'ndp.Cells(costoUnitario.Index).Value = item.costoUnitario
                'ndp.Cells(precioUnitario.Index).Value = item.precioVenta
                'ndp.Cells(costoTotal.Index).Value = Convert.ToDecimal(item.costoUnitario) * Convert.ToInt32(item.cantidad)
                'ndp.Cells(total.Index).Value = Convert.ToDecimal(item.precioVenta) * Convert.ToInt32(item.cantidad)
                ndp.Cells(precioInstalacion.Index).Value = "Pendiente"
                ndp.Cells(unidadMedida.Index).Value = "-"
                ndp.Cells(tipoItem.Index).Value = "-"
                idPadre = item.Id

                mMovitoHijo = New ClsMovitoHijos
                Dim listHijos As List(Of movitoHijo) = mMovitoHijo.TraerxIdPadre(item.Id)
                For Each ith As movitoHijo In listHijos
                    Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                    ndh.Cells(ubicacion.Index).Value = ith.referencia
                    ndh.Cells(id.Index).Value = ith.idArticulo
                    ndh.Cells(descripcion.Index).Value = ith.descripcion
                    ndh.Cells(ancho.Index).Value = ith.ancho
                    ndh.Cells(alto.Index).Value = ith.alto
                    ndh.Cells(mtCuadrados.Index).Value = "Pendiente"
                    ndh.Cells(cantidad.Index).Value = ith.cantidad
                    ndh.Cells(idAcabadoPerfileria.Index).Value = ith.idAcabadoPerfil
                    ndh.Cells(acabadoPerfileria.Index).Value = ith.acabadoPerfil
                    ndh.Cells(idEspesor.Index).Value = ith.idEspesor
                    ndh.Cells(espesor.Index).Value = ith.espesor
                    ndh.Cells(idColorVidrio.Index).Value = ith.idColorVidrio
                    ndh.Cells(colorVidrio.Index).Value = ith.colorVidrio
                    'ndh.Cells(costoUnitario.Index).Value = ith.costoUnitario
                    'ndh.Cells(precioUnitario.Index).Value = ith.precioUnitario
                    'ndh.Cells(costoTotal.Index).Value = Convert.ToDecimal(ith.costoUnitario) * Convert.ToInt32(ith.cantidad)
                    'ndh.Cells(total.Index).Value = Convert.ToDecimal(ith.precioUnitario) * Convert.ToInt32(ith.cantidad)
                    ndh.Cells(precioInstalacion.Index).Value = ""
                    ndh.Cells(unidadMedida.Index).Value = ith.unidadMedida
                    ndh.Cells(tipoItem.Index).Value = ith.tipoItem
                Next
            Next
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Try
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            _nodo = DirectCast(dwItem.SelectedRows(0), DataGridViewTreeNode)
            If _nodo.Level <> 1 Then
                _nodo = _nodo.Parent
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
        ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
End Class