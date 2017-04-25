Imports DatagridTreeView
Imports ReglasNegocio
Public Class FrmReemplazoItems

#Region "Variables"
    Private _idcontrato As Integer = 0
    Private _expresionConsulta As String = String.Empty
    Private _valororiginalcontrato As Decimal = 0
#End Region

#Region "Propiedades"
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property

    Public Property ExpresionConsulta() As String
        Get
            Return _expresionConsulta
        End Get
        Set(ByVal value As String)
            _expresionConsulta = value
        End Set
    End Property
#End Region

#Region "Procedimientos"
    Private Sub cargarMovitoItemsNuevos()
        Try
            Dim _objHijoCotizas As New movitoPadres.ClsMovitoPadres
            Dim dtPadres As DataTable = Nothing
            _objHijoCotizas.traerByGroupCotiza(_expresionConsulta, dtPadres)

            If dtPadres IsNot Nothing Then
                Dim mMovitoHijo As New movitoHijos.ClsMovitoHijos
                For Each item As DataRow In dtPadres.Rows
#Region "Carga Padres"
                    Dim ndp As DataGridViewTreeNode = dwItemsnuevos.Nodes.Add()
                    ndp.Cells(nidpadrecotiza.Index).Value = item.Item("id")
                    ndp.Cells(nidcotizacion.Index).Value = item.Item("idCotizacion")
                    ndp.Cells(nubicacion.Index).Value = RTrim(item.Item("ubicacion"))
                    ndp.Cells(ndescripcion.Index).Value = RTrim(item.Item("descripcion"))
                    ndp.Cells(nancho.Index).Value = Math.Round(CDec(item.Item("ancho")), 0)
                    ndp.Cells(nalto.Index).Value = Math.Round(CDec(item.Item("alto")), 0)
                    ndp.Cells(nmetros.Index).Value = ((CDec(item.Item("ancho")) / 1000) * (CDec(item.Item("alto")) / 1000))
                    ndp.Cells(ncantidad.Index).Value = Math.Round(CDec(item.Item("cantidad")), 0)
                    ndp.Cells(nacabado.Index).Value = item.Item("acabado")
                    ndp.Cells(nvidrio.Index).Value = item.Item("vidrio")
                    ndp.Cells(ncolor.Index).Value = item.Item("colorVidrio")
                    ndp.Cells(nespesor.Index).Value = item.Item("espesor")
                    ndp.Cells(nfactor.Index).Value = Math.Round(CDec(item.Item("factor")), 2)
                    ndp.Cells(npiezasxund.Index).Value = 1
                    ndp.Cells(ndescuento.Index).Value = Math.Round(CDec(item.Item("Descuento")), 0)
                    ndp.Cells(npreciometroinstala.Index).Value = Math.Round(CDec(item.Item("precioMtInstalacion")), 0)
                    ndp.Cells(nprecioinstalacion.Index).Value = Math.Round(CDec(item.Item("precioInstalacion")), 0) '(((CDec(ndp.Cells(mtCuadrados.Index).Value)) * item.cantidad) * Convert.ToDecimal(cmbInstalacion.Text))
                    ndp.Cells(nunidadmedida.Index).Value = "-"
                    ndp.Cells(ntipoitem.Index).Value = "-"
                    ndp.Cells(vercostos.Index).Value = Convert.ToString(item.Item("verCostoKiloAluminio")) & "." & Convert.ToString(item.Item("verCostoVidrio"))

#End Region
#Region "Carga Hijos"

                    Dim listHijos As List(Of movitoHijos.movitoHijo) = mMovitoHijo.TraerxIdPadre(item.Item("id"))
                    For Each ith As movitoHijos.movitoHijo In listHijos
                        Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                        ndh.Cells(nidcotizacion.Index).Value = ith.Id
                        'ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                        ndh.Cells(nubicacion.Index).Value = ndp.Cells(nubicacion.Index).Value 'RTrim(ith.referencia)
                        ndh.Cells(ndescripcion.Index).Value = RTrim(ith.referencia)
                        ndh.Cells(nancho.Index).Value = Math.Round(ith.ancho)
                        ndh.Cells(nalto.Index).Value = Math.Round(ith.alto)
                        ndh.Cells(nmetros.Index).Value = ((Math.Round(ith.ancho) * Math.Round(ith.alto, 0)) / 10000000) * ith.piezasxUnidad * ith.cantidad '"Pendiente"
                        ndh.Cells(ncantidad.Index).Value = ith.cantidad
                        ndh.Cells(nacabado.Index).Value = ith.acabadoPerfil
                        ndh.Cells(nvidrio.Index).Value = ith.vidrio
                        ndh.Cells(ncolor.Index).Value = ith.colorVidrio
                        ndh.Cells(nespesor.Index).Value = ith.espesor
                        ndh.Cells(nfactor.Index).Value = ith.factor
                        ndh.Cells(ndescuento.Index).Value = ith.descuento
                        ndh.Cells(nvalordescuento.Index).Value = ith.valorDescuento
                        ndh.Cells(npreciounitario.Index).Value = ith.precioUnitario
                        ndh.Cells(npreciototal.Index).Value = ith.precioTotal
                        ndh.Cells(npiezasxund.Index).Value = ith.piezasxUnidad
                        ndh.Cells(ncostovidrio.Index).Value = ith.costoVidrio
                        ndh.Cells(ncostoperfiles.Index).Value = ith.costoPerfiles
                        ndh.Cells(ncostoaccesorios.Index).Value = ith.costoAccesorios
                        ndh.Cells(ncostootros.Index).Value = ith.costoOtros
                        ndh.Cells(ncostounitario.Index).Value = ith.costoUnitario
                        ndh.Cells(ncostototal.Index).Value = ith.costoTotal
                        ndh.Cells(npreciometroinstala.Index).Value = ith.tarifaMtInstalacion
                        ndh.Cells(nprecioinstalacion.Index).Value = ith.precioInstalacion
                        ndh.Cells(nunidadmedida.Index).Value = RTrim(ith.unidadMedida)
                        ndh.Cells(nvalordescuento.Index).Value = ith.valorDescuento
                        ndh.Cells(ntipoitem.Index).Value = ith.tipoItem
                        Select Case DirectCast(ith.tipoItem, ClsEnums.FamiliasMateriales)
                            Case ClsEnums.FamiliasMateriales.DISEÑOS
                                ndh.Cells(vercostos.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoAcabado) & "." & Convert.ToString(ith.verCostoNiveles) &
                                    "." & Convert.ToString(ith.verCostoVidrio) & "." & Convert.ToString(ith.verCostoAccesorios) & "." & Convert.ToString(ith.verCostoOtrosArticulos)
                            Case ClsEnums.FamiliasMateriales.ACCESORIOS
                                ndh.Cells(vercostos.Index).Value = Convert.ToString(ith.verCostoAccesorios)
                            Case ClsEnums.FamiliasMateriales.OTROS
                                ndh.Cells(vercostos.Index).Value = Convert.ToString(ith.verCostoOtrosArticulos)
                            Case ClsEnums.FamiliasMateriales.PERFILERIA
                                ndh.Cells(vercostos.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoAcabado) & "." & Convert.ToString(ith.verCostoNiveles)
                            Case ClsEnums.FamiliasMateriales.VIDRIO
                                ndh.Cells(vercostos.Index).Value = Convert.ToString(ith.verCostoVidrio)
                        End Select
                        'If ith.tipoItem = ClsEnums.FamiliasMateriales.DISEÑOS Then
                        '    ndh.Cells(idArticulo.Index).Value = ith.idPlantilla
                        'Else
                        '    ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                        'End If
                    Next
#End Region
                    ndp.Cells(nvalordescuento.Index).Value = listHijos.Sum(Function(a) a.valorDescuento)
                    ndp.Cells(npreciounitario.Index).Value = listHijos.Sum(Function(a) a.precioUnitario)
                    ndp.Cells(npreciototal.Index).Value = listHijos.Sum(Function(a) a.precioTotal)
                    ndp.Cells(ncostoaccesorios.Index).Value = listHijos.Sum(Function(a) a.costoAccesorios)
                    ndp.Cells(ncostoperfiles.Index).Value = listHijos.Sum(Function(a) a.costoPerfiles)
                    ndp.Cells(ncostovidrio.Index).Value = listHijos.Sum(Function(a) a.costoVidrio)
                    ndp.Cells(ncostootros.Index).Value = listHijos.Sum(Function(a) a.costoOtros)
                    ndp.Cells(ncostounitario.Index).Value = listHijos.Sum(Function(a) a.costoUnitario)
                    ndp.Cells(ncostototal.Index).Value = listHijos.Sum(Function(a) a.costoTotal)

                Next
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub CargarMovitoOriginal()
        Try
            Dim objcontratos As New clsMovitoItemsContrato
            Dim dtPadres As DataTable = Nothing
            objcontratos.tc040_selectAllByIdContrato(_idcontrato, dtPadres)
            Dim mMovitoHijo As New ReglasNegocio.movitoHijos.ClsMovitoHijos
            For Each item As DataRow In dtPadres.Rows
#Region "Carga Padres"
                Dim ndp As DataGridViewTreeNode = dwitemsoriginales.Nodes.Add()
                ndp.Cells(oid.Index).Value = item.Item("id")
                ndp.Cells(oidotrosi.Index).Value = item.Item("id_otrosi")
                ndp.Cells(oidpadrecotiza.Index).Value = item.Item("id_cotiza")
                ndp.Cells(oidcotizacion.Index).Value = item.Item("idCotizacion")
                ndp.Cells(oubicacion.Index).Value = RTrim(item.Item("ubicacion"))
                ndp.Cells(odescripcion.Index).Value = RTrim(item.Item("descripcion"))
                ndp.Cells(oancho.Index).Value = Math.Round(CDec(item.Item("ancho")), 0)
                ndp.Cells(oalto.Index).Value = Math.Round(CDec(item.Item("alto")), 0)
                ndp.Cells(ometros.Index).Value = ((CDec(item.Item("ancho")) / 1000) * (CDec(item.Item("alto")) / 1000))
                ndp.Cells(ocantidad.Index).Value = Math.Round(CDec(item.Item("cantidad")), 0)
                ndp.Cells(oacabado.Index).Value = item.Item("acabado")
                ndp.Cells(ovidrio.Index).Value = item.Item("vidrio")
                ndp.Cells(ocolor.Index).Value = item.Item("colorVidrio")
                ndp.Cells(oespesor.Index).Value = item.Item("espesor")
                ndp.Cells(ofactor.Index).Value = Math.Round(CDec(item.Item("factor")), 2)
                ndp.Cells(opiezasxund.Index).Value = 1
                ndp.Cells(odescuento.Index).Value = Math.Round(CDec(item.Item("Descuento")), 0)
                ndp.Cells(opreciometroinstala.Index).Value = Math.Round(CDec(item.Item("precioMtInstalacion")), 0)
                ndp.Cells(oprecioinstalacion.Index).Value = Math.Round(CDec(item.Item("precioInstalacion")), 0)
                ndp.Cells(ounidadmedida.Index).Value = "-"
                ndp.Cells(otipoitem.Index).Value = "-"
                ndp.Cells(versioncosto.Index).Value = Convert.ToString(item.Item("verCostoKiloAluminio")) & "." & Convert.ToString(item.Item("verCostoVidrio"))
#End Region
#Region "Carga Hijos"
                Dim listHijos As List(Of ReglasNegocio.movitoHijos.movitoHijo) = mMovitoHijo.TraerxIdPadre(item.Item("id_cotiza"))
                For Each ith As ReglasNegocio.movitoHijos.movitoHijo In listHijos
                    Dim ndh As DataGridViewTreeNode = ndp.Nodes.Add
                    ndh.Cells(oidcotizacion.Index).Value = ith.Id
                    'ndh.Cells(idArticulo.Index).Value = ith.idArticulo
                    ndh.Cells(oubicacion.Index).Value = ndp.Cells(oubicacion.Index).Value 'RTrim(ith.referencia)
                    ndh.Cells(odescripcion.Index).Value = RTrim(ith.referencia)
                    ndh.Cells(oancho.Index).Value = Math.Round(ith.ancho)
                    ndh.Cells(oalto.Index).Value = Math.Round(ith.alto)
                    ndh.Cells(ometros.Index).Value = ((Math.Round(ith.ancho) * Math.Round(ith.alto, 0)) / 10000000) * ith.piezasxUnidad * ith.cantidad '"Pendiente"
                    ndh.Cells(ocantidad.Index).Value = ith.cantidad
                    ndh.Cells(oacabado.Index).Value = ith.idAcabadoPerfil
                    ndh.Cells(ovidrio.Index).Value = ith.idVidrio
                    ndh.Cells(ocolor.Index).Value = ith.idColorVidrio
                    ndh.Cells(oespesor.Index).Value = ith.idEspesor
                    ndh.Cells(ofactor.Index).Value = ith.factor
                    ndh.Cells(odescuento.Index).Value = ith.descuento
                    ndh.Cells(ovalordescuento.Index).Value = ith.valorDescuento
                    ndh.Cells(opreciounitario.Index).Value = ith.precioUnitario
                    ndh.Cells(opreciototal.Index).Value = ith.precioTotal
                    ndh.Cells(opiezasxund.Index).Value = ith.piezasxUnidad
                    ndh.Cells(ocostovidrio.Index).Value = ith.costoVidrio
                    ndh.Cells(ocostoperfiles.Index).Value = ith.costoPerfiles
                    ndh.Cells(ocostoaccesorios.Index).Value = ith.costoAccesorios
                    ndh.Cells(ocostootros.Index).Value = ith.costoOtros
                    ndh.Cells(ocostounitario.Index).Value = ith.costoUnitario
                    ndh.Cells(ocostototal.Index).Value = ith.costoTotal
                    ndh.Cells(opreciometroinstala.Index).Value = ith.tarifaMtInstalacion
                    ndh.Cells(oprecioinstalacion.Index).Value = ith.precioInstalacion
                    ndh.Cells(ounidadmedida.Index).Value = RTrim(ith.unidadMedida)
                    ndh.Cells(ovalordescuento.Index).Value = ith.valorDescuento
                    ndh.Cells(otipoitem.Index).Value = ith.tipoItem
                    ndh.Cells(versioncosto.Index).Value = Convert.ToString(ith.verCostoKiloAluminio) & "." & Convert.ToString(ith.verCostoVidrio)
                Next
#End Region
                ndp.Cells(nvalordescuento.Index).Value = listHijos.Sum(Function(a) a.valorDescuento)
                ndp.Cells(npreciounitario.Index).Value = listHijos.Sum(Function(a) a.precioUnitario)
                ndp.Cells(npreciototal.Index).Value = listHijos.Sum(Function(a) a.precioTotal)
                ndp.Cells(ncostoaccesorios.Index).Value = listHijos.Sum(Function(a) a.costoAccesorios)
                ndp.Cells(ncostoperfiles.Index).Value = listHijos.Sum(Function(a) a.costoPerfiles)
                ndp.Cells(ncostovidrio.Index).Value = listHijos.Sum(Function(a) a.costoVidrio)
                ndp.Cells(ncostootros.Index).Value = listHijos.Sum(Function(a) a.costoOtros)
                ndp.Cells(ncostounitario.Index).Value = listHijos.Sum(Function(a) a.costoUnitario)
                ndp.Cells(ncostototal.Index).Value = listHijos.Sum(Function(a) a.costoTotal)
                _valororiginalcontrato += Convert.ToDecimal(ndp.Cells(npreciototal.Index).Value)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        Try
            If dwItemsnuevos.SelectedRows.Count > 0 Then
                Dim n As DataGridViewTreeNode = DirectCast(dwItemsnuevos.SelectedRows(0), DataGridViewTreeNode)
                If n.Level = 1 Then
                    Dim nn As DataGridViewTreeNode = dwitemsoriginales.Nodes.Add()
                    For i As Integer = 0 To nn.Cells.Count - 1
                        nn.Cells(i).Value = n.Cells(i).Value
                    Next
                    For i As Integer = 0 To n.Nodes.Count - 1
                        Dim nd As DataGridViewTreeNode = nn.Nodes.Add()
                        For j As Integer = 0 To n.Nodes(i).Cells.Count - 1
                            nd.Cells(j).Value = n.Nodes(i).Cells(j).Value
                        Next
                    Next
                    dwItemsnuevos.Nodes.Remove(n)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnquitar_Click(sender As Object, e As EventArgs) Handles btnquitar.Click
        Try
            If dwitemsoriginales.SelectedRows.Count > 0 And dwitemsoriginales.Rows.Count > 1 Then
                Dim n As DataGridViewTreeNode = DirectCast(dwitemsoriginales.SelectedRows(0), DataGridViewTreeNode)
                If n.Level = 1 Then
                    Dim nn As DataGridViewTreeNode = dwItemsnuevos.Nodes.Add()
                    For i As Integer = 0 To nn.Cells.Count - 1
                        nn.Cells(i).Value = n.Cells(i).Value
                    Next
                    For i As Integer = 0 To n.Nodes.Count - 1
                        Dim nd As DataGridViewTreeNode = nn.Nodes.Add()
                        For j As Integer = 0 To n.Nodes(i).Cells.Count - 1
                            nd.Cells(j).Value = n.Nodes(i).Cells(j).Value
                        Next
                    Next
                    dwitemsoriginales.Nodes.Remove(n)
                End If
            End If
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        Try
            Dim fotrosi As New FrmOtroSi
            fotrosi.IdContrato = _idcontrato
            fotrosi.ctrCliente.Enabled = False
            fotrosi.ctrlNit.Enabled = False
            fotrosi.ctrObra.Enabled = False
            fotrosi.ctrCodSucursal.Enabled = False
            fotrosi.NitYo.Enabled = False
            fotrosi.ClienteYo.Enabled = False
            Dim _nuevoValor As Decimal = 0
            For i As Integer = 0 To dwitemsoriginales.Nodes.Count - 1
                _nuevoValor += Convert.ToDecimal(dwitemsoriginales.Nodes(i).Cells(opreciototal.Index).Value)
            Next
            fotrosi.Valor = _nuevoValor - _valororiginalcontrato
            If fotrosi.ShowDialog() = DialogResult.OK Then
                Dim _idotrosi As Integer = fotrosi.IdOtroSi
                Dim movcot As New cotizaciones.ClsCostizaciones
                Dim movCont As New clsMovitoItemsContrato

                For Each n As DataGridViewTreeNode In dwitemsoriginales.Nodes
                    If String.IsNullOrEmpty(Convert.ToString(n.Cells(oid.Index).Value)) Then
                        movCont.tc040_insert(_idcontrato, _idotrosi,
                             Convert.ToInt32(n.Cells(oidpadrecotiza.Index).Value),
                             My.Settings.UsuarioActivo)
                        movcot.ModificarEstado(ClsEnums.Estados.CONTRATADO,
                                               Convert.ToString(n.Cells(oidcotizacion.Index).Value))
                    End If
                Next
                For Each n As DataGridViewTreeNode In dwItemsnuevos.Nodes
                    If Not String.IsNullOrEmpty(Convert.ToString(n.Cells(nid.Index).Value)) Then
                        movCont.EliminarItem(Convert.ToInt32(n.Cells(nid.Index).Value))
                        If dwitemsoriginales.Nodes.Cast(Of DataGridViewTreeNode).Where(Function(x) Convert.ToInt32(x.Cells(oidcotizacion.Index).Value) = Convert.ToInt32(n.Cells(nidcotizacion.Index).Value)).Count() <= 0 Then
                            movcot.ModificarEstado(ClsEnums.Estados.PENDIENTE_CONTRATAR,
                                               Convert.ToString(n.Cells(oidcotizacion.Index).Value))
                        End If
                    End If
                Next
                DialogResult = DialogResult.OK
                Close()
            End If

        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncancelar_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        Try
            DialogResult = DialogResult.Cancel
            Close()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub FrmReemplazoItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CargarMovitoOriginal()
            cargarMovitoItemsNuevos()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpandir_Click(sender As Object, e As EventArgs) Handles btnexpandir.Click
        Try
            For i As Integer = 0 To dwItemsnuevos.Nodes.Count - 1
                dwItemsnuevos.Nodes(i).Expand()
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer_Click(sender As Object, e As EventArgs) Handles btncontraer.Click
        Try
            For i As Integer = 0 To dwItemsnuevos.Nodes.Count - 1
                dwItemsnuevos.Nodes(i).Collapse()
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnvisibilidadcolumnas_Click(sender As Object, e As EventArgs) Handles btnvisibilidadcolumnas.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwItemsnuevos
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnvisibilidad_Click(sender As Object, e As EventArgs) Handles btnvisibilidad.Click
        Try
            Dim selector As New ControlesPersonalizados.GridFiltrado.FrmVisibilidadColumnas
            selector.Grid2 = dwitemsoriginales
            selector.Location = MousePosition
            selector.Show()
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btnexpandir2_Click(sender As Object, e As EventArgs) Handles btnexpandir2.Click
        Try
            For i As Integer = 0 To dwitemsoriginales.Nodes.Count - 1
                dwitemsoriginales.Nodes(i).Expand()
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
    Private Sub btncontraer2_Click(sender As Object, e As EventArgs) Handles btncontraer2.Click
        Try
            For i As Integer = 0 To dwitemsoriginales.Nodes.Count - 1
                dwitemsoriginales.Nodes(i).Collapse()
            Next
        Catch ex As Exception
            ManejoExcepciones.MensajeExcepcion.Show(ex, ManejoExcepciones.TipoExcepcion.Critica)
        End Try
    End Sub
#End Region

End Class