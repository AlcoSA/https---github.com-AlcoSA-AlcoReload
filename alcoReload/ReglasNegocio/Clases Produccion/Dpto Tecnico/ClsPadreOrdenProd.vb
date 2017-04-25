Imports Datos
Public Class ClsPadreOrdenProd
#Region "vars"
    Private _mItemOp As New dsAlcoOrdenesProduccionTableAdapters.top002_MovitoPadresOpTableAdapter
#End Region
#Region "props"
    Public Function Insertar(idordenprod As Integer, idpadreoped As Integer, observaciones As String,
                             puntos As Decimal, preciounitario As Decimal, usuario As String, estado As Integer,
                             indNSR As Boolean) As Integer
        Try
            Return Convert.ToInt32(_mItemOp.sp_top002_insert(idordenprod, idpadreoped, observaciones, puntos,
                                      preciounitario, usuario, estado, indNSR))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(idordenprod As Integer, idpadreoped As Integer, observaciones As String,
                             puntos As Decimal, preciounitario As Decimal, usuario As String, estado As Integer,
                             indNSR As Boolean, id As Integer)
        Try
            _mItemOp.sp_top002_update(idordenprod, idpadreoped, observaciones, puntos, preciounitario,
                                      usuario, estado, indNSR, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdOrdenPed(idordenped As Integer) As List(Of PadreOrdenProd)
        TraerxIdOrdenPed = New List(Of PadreOrdenProd)
        Try
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top002_selectCombinadobyIdOrdenpedTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top002_selectCombinadobyIdOrdenpedDataTable = sp.GetData(idordenped)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top002_selectCombinadobyIdOrdenpedRow).ToList.ForEach(
                Sub(it)
                    TraerxIdOrdenPed.Add(New PadreOrdenProd(it.id, it.idoped, it.FormulaAncho, it.ValorAncho, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAlto, it.ValorAlto, it.formulaaltofabrica, it.valoraltofabrica, it.formulaCantRequerida, it.valorCantidadRequerida, it.FormulaPXURequerida,
                                               it.ValorPxURequerida, it.mtrosRequeridos, it.idTipoVidrio, it.vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.mtrosOriginales, it.IndAutomatico, it.usuarioCreacion, it.fechaCreacion, it.usuarioAprobacion,
                                               it.fechaAprobacion, it.UsuarioAnulacion, it.FechaAnulacion, it.usuarioModi, it.FechaModi, it.idEstado, it.Estado,
                                               it.ubicacion, it.descripcion,
                                               it.precioUnitario, it.precioIntalacion, it.puntos, it.metrosInstalacion, it.indNSR,
                                               it.UbicacionEstructura, it.aproba_cliente, it.Observaciones, it.Imagen))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
Public Class PadreOrdenProd
    Inherits ItemsOp
#Region "vars"
    Protected _idoped As Integer = 0
#End Region
#Region "props"
    Public Property IdOrdenped As Integer
        Get
            Return _idoped
        End Get
        Set(value As Integer)
            _idoped = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, idoped As Integer, FormulaAnchoRequerido As String,
                   ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
                   FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
                   valoraltofabrica As Decimal, FormulaCantidadrequerida As String,
                   CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                   IdVidrio As Integer, Vidrio As String, IdColorVidrio As Integer, ColorVidrio As String,
                   IdEspesor As Integer, Espesor As String, IdAcbadoPerdiles As Integer, Acabado As String,
                   AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, pxuOriginal As Decimal, MetrosOriginales As Decimal,
                   indAutomatico As Boolean, usuarioCreacion As String, fechaCreacion As DateTime, usuarioAprobacion As String,
                   fechaAprobacion As DateTime, usuarioAnulacion As String, fechaAnulacion As DateTime, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, Estado As String, ubicacion As String, descripcion As String,
                   precioUnitario As Decimal, precioInstalacion As Decimal, puntos As Decimal, metrosIntalacion As Decimal, indNSR As Boolean,
                   ubicacionEstructura As String, aprobado_cliente As Integer, observaciones As String, imagen As Byte())
        _id = id
        _idoped = idoped
        _id = id
        _usuariocreacion = usuarioCreacion
        _fechacreacion = fechaCreacion
        _usuarioAprobacion = usuarioAprobacion
        _fechaAprobacion = fechaAprobacion
        _usuarioAnulacion = usuarioAnulacion
        _fechaAnulacion = fechaAnulacion
        _usuariomodificacion = usuarioModi
        _fechamodificacion = fechaModi
        _idestado = idEstado
        _estado = Estado
        _formulaAnchoRequerido = Trim(FormulaAnchoRequerido)
        _anchoRequerido = ValorAnchoRequerido
        _formulaAnchofabricacion = Trim(formulaanchofabrica)
        _anchofabricacion = valoranchofabrica
        _formulaAltoRequerido = Trim(FormulaAltoRequerido)
        _altoRequerido = valorAltoRequerido
        _formulaAltofabricacion = Trim(formulaaltofabrica)
        _altofabricacion = valoraltofabrica
        _formulaCantidadRequerida = Trim(FormulaCantidadrequerida)
        _cantidadRequerida = CantidadRequerida
        _FormulaPxURequeridas = Trim(FormulaPxURequeridas)
        _piezasXUnidadrequeridas = PxURequeridas
        _metrosRequeridos = MetrosRequeridos
        _idVidrio = IdVidrio
        _vidrio = Trim(Vidrio)
        _idColorVidrio = IdColorVidrio
        _colorVidrio = Trim(ColorVidrio)
        _idEspesor = IdEspesor
        _espesor = Trim(Espesor)
        _idAcabadoPerfil = IdAcbadoPerdiles
        _acabadoPerfil = Trim(Acabado)
        _ancho = AnchoOriginal
        _alto = AltoOriginal
        _cantidad = CantidadOriginal
        _pxunidad = pxuOriginal
        _mtCuadrados = MetrosOriginales
        _indAutomatico = indAutomatico
        _ubicacion = Trim(ubicacion)
        _descripcion = Trim(descripcion)
        _precioUnitario = precioUnitario
        _precioInstalacion = precioInstalacion
        _punto = puntos
        _metrosInstalacion = metrosIntalacion
        _IndNSR = indNSR
        _ubicacionEstructura = Trim(ubicacionEstructura)
        _aprobado_cliente = aprobado_cliente
        _observaciones = Trim(observaciones)
        _imagen = imagen
    End Sub
#End Region
End Class
