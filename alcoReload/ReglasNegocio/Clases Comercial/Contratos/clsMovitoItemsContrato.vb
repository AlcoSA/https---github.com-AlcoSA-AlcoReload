Imports Datos

Public Class clsMovitoItemsContrato
#Region "Variables"
    Private _dsitemsContrato As New dsAlcoContratosTableAdapters.tc040_movitoItemsContratoTableAdapter

#End Region
#Region "Procedimientos y funciones"

    Public Function tc040_insert(idContrato As Integer, idotrosi As Integer, idpadrecotiza As Integer, usuarioCreacion As String) As Integer
        Try
            Return Convert.ToInt32(_dsitemsContrato.sp_tc040_insert(idContrato,
                                                                    idotrosi, idpadrecotiza,
                                                                    usuarioCreacion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub tc040_update(id As Integer, idContrato As Integer, idotrosi As Integer, idItemCotiza As Integer, usuarioModi As String, idEstado As Integer)
        Try
            _dsitemsContrato.sp_tc040_update(id, idContrato, idotrosi, idItemCotiza, usuarioModi, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function tc040_selectAllByIdContrato(idContrato As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of ItemContrato)
        tc040_selectAllByIdContrato = New List(Of ItemContrato)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc040_selectByIdContratoTableAdapter
            Dim td As dsAlcoContratos.sp_tc040_selectByIdContratoDataTable = ta.GetData(idContrato)
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc040_selectByIdContratoRow In td.Rows
                    tc040_selectAllByIdContrato.Add(New ItemContrato(fila.id, fila.id_cotiza, fila.FechaCreacion,
                                                                     fila.UsuarioCreacion, fila.idCotizacion, fila.ubicacion, fila.descripcion,
                                                                     fila.ancho, fila.alto, fila.cantidad, fila.idAcabado, fila.acabado, fila.idVidrio, fila.vidrio,
                                                                     fila.idColorVidrio, fila.colorVidrio, fila.idEspesor, fila.espesor, fila.factor, fila.descuento,
                                                                     fila.verCostoVidrio, fila.verCostoAccesorios, fila.verCostoNiveles, fila.verCostoAcabado,
                                                                     fila.verCostokiloAluminio, fila.verCostoOtros, fila.calculo_NSR, fila.cumpleNorma, fila.idPropiedadMasica,
                                                                     fila.FechaModi, fila.UsusarioModi, fila.idEstado, fila.mtCuadrados,
                                                                     fila.precioMtInstalacion, fila.precioMtInstalacion, fila.precio_Unitario, fila.precio_Total))
                Next
            End If
            dt = td.Copy
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerpaOrdenPedByIdContrato(idContrato As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of ItemContratoOrdenPed)
        TraerpaOrdenPedByIdContrato = New List(Of ItemContratoOrdenPed)
        Try
            Dim ta As New dsAlcoProduccionTableAdapters.sp_tc040_selectOrdenPedidoTableAdapter
            Dim td As dsAlcoProduccion.sp_tc040_selectOrdenPedidoDataTable = ta.GetData(idContrato)
            If td.Rows.Count > 0 Then
                For Each fila As dsAlcoProduccion.sp_tc040_selectOrdenPedidoRow In td.Rows
                    TraerpaOrdenPedByIdContrato.Add(New ItemContratoOrdenPed(fila.id, fila.id_cotiza, fila.FechaCreacion,
                                                                     fila.UsuarioCreacion, fila.idCotizacion, fila.ubicacion, fila.descripcion,
                                                                     fila.ancho, fila.alto, fila.cantidad, fila.cantidad_disponible, fila.idAcabado, fila.acabado, fila.idVidrio, fila.vidrio,
                                                                     fila.idColorVidrio, fila.colorVidrio, fila.idEspesor, fila.espesor, fila.factor, fila.descuento,
                                                                     fila.verCostoVidrio, fila.verCostoAccesorios, fila.verCostoNiveles, fila.verCostoAcabado,
                                                                     fila.verCostokiloAluminio, fila.verCostoOtros, fila.calculo_NSR, fila.cumpleNorma, fila.idPropiedadMasica,
                                                                     fila.FechaModi, fila.UsusarioModi, fila.idEstado, fila.mtCuadrados,
                                                                     fila.precioMtInstalacion, fila.precioMtInstalacion, fila.precio_Unitario, fila.precio_Total))
                Next
                dt = td.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerValoresMinuta(idContrato As Integer) As DataTable
        TraerValoresMinuta = New DataTable
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc040_ValoresMinutaTableAdapter
            TraerValoresMinuta = ta.GetData(idContrato)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub EliminarItem(id As Integer)
        Try
            _dsitemsContrato.Delete(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class

Public Class ItemContrato : Inherits movitoPadres.movitoPadre

#Region "Variables"
    Private _iditemcotiza As Integer
#End Region

#Region "Propiedades"
    Public Property IdItemCotiza As Integer
        Get
            Return _iditemcotiza
        End Get
        Set(value As Integer)
            _iditemcotiza = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, iditemcotiza As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotizacion As Integer, ubicacion As String,
                       descripcion As String, ancho As Decimal, alto As Decimal, cantidad As Integer, idAcabado As Integer, acabado As String,
                       idVidrio As Integer, vidrio As String, idColorVidrio As Integer, colorVidrio As String, idEspesor As Integer,
                       Espesor As String, factor As Decimal, descuento As Decimal, verCostoVidrio As Integer, verCostoAccesorios As Integer, verCostoNiveles As Integer,
                       verCostoAcabado As Integer, verCostokiloAluminio As Integer, verCostoOtros As Integer, calculo_NSR As Boolean, cumpleNorma As Boolean,
                       idPropiedadMasica As Integer, fechaModi As DateTime, usuarioModi As String, IdEstado As Integer, mtCuadrados As Decimal,
                       tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, preciounitario As Decimal, preciototal As Decimal)
        Try
            Me.Id = id
            _iditemcotiza = iditemcotiza
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.idCotiza = idCotizacion
            Me.ubicacion = Trim(ubicacion)
            Me.descripcion = Trim(descripcion)
            Me.ancho = ancho
            Me.alto = alto
            Me.cantidad = cantidad
            Me.idAcabadoPerfil = idAcabado
            Me.acabadoPerfil = Trim(acabado)
            Me.idVidrio = idVidrio
            Me.vidrio = Trim(vidrio)
            Me.idColorVidrio = idColorVidrio
            Me.colorVidrio = Trim(colorVidrio)
            Me.idEspesor = idEspesor
            Me.espesor = Trim(Espesor)
            Me.factor = factor
            Me.Descuento = descuento
            Me.versionCostoVidrio = verCostoVidrio
            Me.versionCostoAccesorios = verCostoAccesorios
            Me.versionCostoNiveles = verCostoNiveles
            Me.versionCostoAcabado = verCostoAcabado
            Me.versionCostoKiloAluminio = verCostokiloAluminio
            Me.versionCostoOtrosArticulos = verCostoOtros
            Me.calculo_NSR = calculo_NSR
            Me.cumpleNorma = cumpleNorma
            Me.idPropiedadMasica = idPropiedadMasica
            Me.IdEstado = IdEstado
            Me.mtCuadrados = mtCuadrados
            Me.tarifaMtInstalacion = tarifaMtInstalacion
            Me.precioInstalacion = precioInstalacion
            Me.precioUnitario = preciounitario
            Me.precioTotal = preciototal
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = Trim(usuarioModi)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class

Public Class ItemContratoOrdenPed : Inherits ItemContrato

#Region "Variables"
    Private _cantidad_pendiente As Decimal
#End Region

#Region "Propiedades"
    Public Property Cantidad_Pendiente As Decimal
        Get
            Return _cantidad_pendiente
        End Get
        Set(value As Decimal)
            _cantidad_pendiente = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, iditemcotiza As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotizacion As Integer, ubicacion As String,
                       descripcion As String, ancho As Decimal, alto As Decimal, cantidad As Integer, cantidad_disponible As Decimal, idAcabado As Integer, acabado As String,
                       idVidrio As Integer, vidrio As String, idColorVidrio As Integer, colorVidrio As String, idEspesor As Integer,
                       Espesor As String, factor As Decimal, descuento As Decimal, verCostoVidrio As Integer, verCostoAccesorios As Integer, verCostoNiveles As Integer,
                       verCostoAcabado As Integer, verCostokiloAluminio As Integer, verCostoOtros As Integer, calculo_NSR As Boolean, cumpleNorma As Boolean,
                       idPropiedadMasica As Integer, fechaModi As DateTime, usuarioModi As String, IdEstado As Integer, mtCuadrados As Decimal,
                       tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, preciounitario As Decimal, preciototal As Decimal)
        Try
            Me.Id = id
            Me.IdItemCotiza = iditemcotiza
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = Trim(usuarioCreacion)
            Me.idCotiza = idCotizacion
            Me.ubicacion = Trim(ubicacion)
            Me.descripcion = Trim(descripcion)
            Me.ancho = ancho
            Me.alto = alto
            Me.cantidad = cantidad
            _cantidad_pendiente = cantidad_disponible
            Me.idAcabadoPerfil = idAcabado
            Me.acabadoPerfil = Trim(acabado)
            Me.idVidrio = idVidrio
            Me.vidrio = Trim(vidrio)
            Me.idColorVidrio = idColorVidrio
            Me.colorVidrio = Trim(colorVidrio)
            Me.idEspesor = idEspesor
            Me.espesor = Trim(Espesor)
            Me.factor = factor
            Me.Descuento = descuento
            Me.versionCostoVidrio = verCostoVidrio
            Me.versionCostoAccesorios = verCostoAccesorios
            Me.versionCostoNiveles = verCostoNiveles
            Me.versionCostoAcabado = verCostoAcabado
            Me.versionCostoKiloAluminio = verCostokiloAluminio
            Me.versionCostoOtrosArticulos = verCostoOtros
            Me.calculo_NSR = calculo_NSR
            Me.cumpleNorma = cumpleNorma
            Me.idPropiedadMasica = idPropiedadMasica
            Me.IdEstado = IdEstado
            Me.mtCuadrados = mtCuadrados
            Me.tarifaMtInstalacion = tarifaMtInstalacion
            Me.precioInstalacion = precioInstalacion
            Me.precioUnitario = preciounitario
            Me.precioTotal = preciototal
            Me.FechaModificacion = fechaModi
            Me.UsuarioModificacion = Trim(usuarioModi)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

End Class


