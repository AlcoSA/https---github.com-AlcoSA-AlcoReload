Imports Datos
Public Class ClsItemsOped
#Region "vars"
    Private _objItemOp As New dsAlcoProduccionTableAdapters.tp003_movitoPadresOpTableAdapter

#End Region
#Region "Procedimientos"
    Public Function Insertar(idEncabeOp As Integer, idItemPadreContrato As Integer, observaciones As String, FormulaAnchoRequerido As String,
                            ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
                            FormulaAltoRequerido As String, valorAltoRequerido As Decimal,
                            formulaaltofabrica As String, valoraltofabrica As Decimal,
                            FormulaCantidadrequerida As String, CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                            IdVidrio As Integer, IdColorVidrio As Integer, IdEspesor As Integer, IdAcbadoPerdiles As Integer, AnchoOriginal As Decimal,
                            AltoOriginal As Decimal, CantidadOriginal As Decimal, PxUoriginal As Decimal, MetrosOriginales As Decimal, indAutomatico As Boolean,
                            puntos As Decimal, preciounitario As Decimal, precioinstalacion As Decimal, metrosinstalacion As Decimal, usuario As String,
                            idEstado As Integer, imagen As Byte(), indNsr As Boolean, ubicacionEstructura As String) As Integer
        Try
            Return Convert.ToInt32(_objItemOp.sp_tp003_insert(idEncabeOp, idItemPadreContrato, FormulaAnchoRequerido,
                                       ValorAnchoRequerido, formulaanchofabrica, valoranchofabrica, FormulaAltoRequerido, valorAltoRequerido,
                                       formulaaltofabrica, valoraltofabrica, FormulaCantidadrequerida,
                                       CantidadRequerida, FormulaPxURequeridas, PxURequeridas, MetrosRequeridos, observaciones,
                                       IdVidrio, IdEspesor, IdColorVidrio, IdAcbadoPerdiles, AnchoOriginal, AltoOriginal, CantidadOriginal, PxUoriginal, MetrosOriginales,
                                       puntos, indAutomatico, preciounitario, precioinstalacion,
                                     metrosinstalacion, usuario, idEstado, imagen, indNsr, ubicacionEstructura))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(idEncabeOp As Integer, idItemPadreContrato As Integer, observaciones As String, FormulaAnchoRequerido As String,
                        ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
                        FormulaAltoRequerido As String, valorAltoRequerido As Decimal,
                        formulaaltofabrica As String, valoraltofabrica As Decimal,
                        FormulaCantidadrequerida As String, CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                        IdVidrio As Integer, IdColorVidrio As Integer, IdEspesor As Integer, IdAcbadoPerdiles As Integer, AnchoOriginal As Decimal,
                        AltoOriginal As Decimal, CantidadOriginal As Decimal, PxUoriginal As Decimal, MetrosOriginales As Decimal, indAutomatico As Boolean,
                        puntos As Decimal, preciounitario As Decimal, precioinstalacion As Decimal, metrosinstalacion As Decimal, usuario As String,
                        idEstado As Integer, imagen As Byte(), indNsr As Boolean, ubicacionEstructura As String, id As Integer)
        Try
            _objItemOp.sp_tp003_update(id, idEncabeOp, idItemPadreContrato, FormulaAnchoRequerido,
                                       ValorAnchoRequerido, formulaanchofabrica, valoranchofabrica, FormulaAltoRequerido,
                                       valorAltoRequerido, formulaaltofabrica, valoraltofabrica, FormulaCantidadrequerida,
                                       CantidadRequerida, FormulaPxURequeridas, PxURequeridas, MetrosRequeridos, observaciones,
                                       IdVidrio, IdEspesor, IdColorVidrio, IdAcbadoPerdiles, AnchoOriginal, AltoOriginal, CantidadOriginal, PxUoriginal, MetrosOriginales,
                                       puntos, indAutomatico, preciounitario, precioinstalacion,
                                     metrosinstalacion, usuario, idEstado, imagen, indNsr, ubicacionEstructura)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(ByRef Optional tb As DataTable = Nothing) As List(Of ItemsOp)
        Try
            TraerTodos = New List(Of ItemsOp)
            Dim sp As New dsAlcoProduccionTableAdapters.sp_tp003_selectAllTableAdapter()
            Dim ta As dsAlcoProduccion.sp_tp003_selectAllDataTable = sp.GetData()
            ta.Rows.Cast(Of dsAlcoProduccion.sp_tp003_selectAllRow).ToList.ForEach(
                Sub(it)
                    TraerTodos.Add(New ItemsOp(it.id, it.IdEncabezado, it.IdPadreContrato, it.FormulaAncho, it.ValorAncho, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAlto, it.ValorAlto, it.formulaaltofabrica, it.valoraltofabrica, it.formulaCantRequerida, it.valorCantidadRequerida, it.FormulaPXURequerida,
                                               it.ValorPxURequerida, it.mtrosRequeridos, it.idTipoVidrio, it.vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.mtrosOriginales, it.IndAutomatico, it.usuarioCreacion, it.fechaCreacion, it.usuarioAprobacion,
                                               it.fechaAprobacion, it.UsuarioAnulacion, it.FechaAnulacion, it.usuarioModi, it.FechaModi, it.idEstado, it.Estado,
                                               it.ubicacion, it.descripcion, it.idCotiza, it.idPadreCotiza,
                                               it.precioUnitario, it.precioIntalacion, it.puntos, it.metrosInstalacion, it.indNSR,
                                               it.UbicacionEstructura, it.aproba_cliente, it.Observaciones, it.Imagen,
                                               it.versioncostoKiloAluminio, it.versioncostoacabado, it.versioncostoniveles,
                                               it.versioncostovidrio, it.versioncostoaccesorios, it.versioncostootros, it.refSiesa))
                End Sub)
            tb = If(ta.Count > 0, ta.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdOrdenPedido(idOrdenPedido As Integer) As List(Of ItemsOp)
        TraerxIdOrdenPedido = New List(Of ItemsOp)
        Try
            Dim sp As New dsAlcoProduccionTableAdapters.sp_tp003_selectbyIdOrdenTableAdapter()
            Dim ta As dsAlcoProduccion.sp_tp003_selectbyIdOrdenDataTable = sp.GetData(idOrdenPedido)
            ta.Rows.Cast(Of dsAlcoProduccion.sp_tp003_selectbyIdOrdenRow).ToList.ForEach(
                Sub(it)
                    TraerxIdOrdenPedido.Add(New ItemsOp(it.id, it.IdEncabezado, it.IdPadreContrato, it.FormulaAncho, it.ValorAncho, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAlto, it.ValorAlto, it.formulaaltofabrica, it.valoraltofabrica, it.formulaCantRequerida, it.valorCantidadRequerida, it.FormulaPXURequerida,
                                               it.ValorPxURequerida, it.mtrosRequeridos, it.idTipoVidrio, it.vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.mtrosOriginales, it.IndAutomatico, it.usuarioCreacion, it.fechaCreacion, it.usuarioAprobacion,
                                               it.fechaAprobacion, it.UsuarioAnulacion, it.FechaAnulacion, it.usuarioModi, it.FechaModi, it.idEstado, it.Estado,
                                               it.ubicacion, it.descripcion, it.idCotiza, it.idPadreCotiza,
                                               it.precioUnitario, it.precioIntalacion, it.puntos, it.metrosInstalacion, it.indNSR,
                                               it.UbicacionEstructura, it.aproba_cliente, it.Observaciones, it.Imagen,
                                               it.versioncostoKiloAluminio, it.versioncostoacabado, it.versioncostoniveles,
                                               it.versioncostovidrio, it.versioncostoaccesorios, it.versioncostootros, it.refSiesa))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class ItemsOp : Inherits movitoPadres.movitoPadre

#Region "vars"
    Protected _idEncabeOp As Integer
    Protected _idItemContrato As Integer
    Protected _idItemCotiza As Integer
    Protected _formulaAnchoRequerido As String
    Protected _anchoRequerido As Decimal
    Protected _formulaAltoRequerido As String
    Protected _altoRequerido As Decimal
    Protected _formulaCantidadRequerida As String
    Protected _cantidadRequerida As Decimal
    Protected _FormulaPxURequeridas As String
    Protected _piezasXUnidadrequeridas As Decimal
    Protected _metrosRequeridos As Decimal
    Protected _indAutomatico As Boolean
    Protected _punto As Decimal
    Protected _metrosInstalacion As Decimal
    Protected _IndNSR As Boolean
    Protected _ubicacionEstructura As String
    Protected _aprobado_cliente As Integer
    Protected _observaciones As String
    Protected _formulaAnchofabricacion As String
    Protected _anchofabricacion As Decimal
    Protected _formulaAltofabricacion As String
    Protected _altofabricacion As Decimal
    Protected _pxunidad As Decimal
#End Region
#Region "Propiedades"
    Public Property IdEncabeOp As Integer
        Get
            Return _idEncabeOp
        End Get
        Set(ByVal value As Integer)
            _idEncabeOp = value
        End Set
    End Property
    Public Property IdItemContrato As Integer
        Get
            Return _idItemContrato
        End Get
        Set(ByVal value As Integer)
            _idItemContrato = value
        End Set
    End Property
    Public Property idItemCotiza As Integer
        Get
            Return _idItemCotiza
        End Get
        Set(ByVal value As Integer)
            _idItemCotiza = value
        End Set
    End Property
    Public Property FormulaAnchoRequerido As String
        Get
            Return _formulaAnchoRequerido
        End Get
        Set(ByVal value As String)
            _formulaAnchoRequerido = value
        End Set
    End Property
    Public Property anchoRequerido As Decimal
        Get
            Return _anchoRequerido
        End Get
        Set(ByVal value As Decimal)
            _anchoRequerido = value
        End Set
    End Property
    Public Property FormulaAnchoFabricacion As String
        Get
            Return _formulaAnchofabricacion
        End Get
        Set(ByVal value As String)
            _formulaAnchofabricacion = value
        End Set
    End Property
    Public Property AnchoFabricacion As Decimal
        Get
            Return _anchofabricacion
        End Get
        Set(ByVal value As Decimal)
            _anchofabricacion = value
        End Set
    End Property
    Public Property FormulaAltoRequerido() As String
        Get
            Return _formulaAltoRequerido
        End Get
        Set(ByVal value As String)
            _formulaAltoRequerido = value
        End Set
    End Property
    Public Property AltoRequerido As Decimal
        Get
            Return _altoRequerido
        End Get
        Set(ByVal value As Decimal)
            _altoRequerido = value
        End Set
    End Property
    Public Property FormulaAltoFabricacion As String
        Get
            Return _formulaAltofabricacion
        End Get
        Set(ByVal value As String)
            _formulaAltofabricacion = value
        End Set
    End Property
    Public Property AltoFabricacion As Decimal
        Get
            Return _altofabricacion
        End Get
        Set(ByVal value As Decimal)
            _altofabricacion = value
        End Set
    End Property
    Public Property FormulaCantidadRequerida As String
        Get
            Return _formulaCantidadRequerida
        End Get
        Set(ByVal value As String)
            _formulaCantidadRequerida = value
        End Set
    End Property
    Public Property CantidadRequerida As Decimal
        Get
            Return _cantidadRequerida
        End Get
        Set(ByVal value As Decimal)
            _cantidadRequerida = value
        End Set
    End Property
    Public Property FormulaPxURequeridas As String
        Get
            Return _FormulaPxURequeridas
        End Get
        Set(ByVal value As String)
            _FormulaPxURequeridas = value
        End Set
    End Property
    Public Property PiezasxUnidadRequeridas As Decimal
        Get
            Return _piezasXUnidadrequeridas
        End Get
        Set(ByVal value As Decimal)
            _piezasXUnidadrequeridas = value
        End Set
    End Property
    Public Property MetrosRequeridos() As Decimal
        Get
            Return _metrosRequeridos
        End Get
        Set(ByVal value As Decimal)
            _metrosRequeridos = value
        End Set
    End Property
    Public Property indAutomatico As Boolean
        Get
            Return _indAutomatico
        End Get
        Set(ByVal value As Boolean)
            _indAutomatico = value
        End Set
    End Property
    Public Property Puntos As Decimal
        Get
            Return _punto
        End Get
        Set(ByVal value As Decimal)
            _punto = value
        End Set
    End Property
    Public Property metrosIntalacion As Decimal
        Get
            Return _metrosInstalacion
        End Get
        Set(ByVal value As Decimal)
            _metrosInstalacion = value
        End Set
    End Property
    Public Property indNSR As Boolean
        Get
            Return _IndNSR
        End Get
        Set(ByVal value As Boolean)
            _IndNSR = value
        End Set
    End Property
    Public Property UbicacionEstructura As String
        Get
            Return _ubicacionEstructura
        End Get
        Set(ByVal value As String)
            _ubicacionEstructura = value
        End Set
    End Property
    Public Property Aprobado_Cliente As Integer
        Get
            Return _aprobado_cliente
        End Get
        Set(value As Integer)
            _aprobado_cliente = value
        End Set
    End Property
    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property
    Private _refSieas As String
    Public Property refSiesa() As String
        Get
            Return _refSieas
        End Get
        Set(ByVal value As String)
            _refSieas = value
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
    Public Sub New(id As Integer, idEncabeOp As Integer, idItemPadreContrato As Integer, FormulaAnchoRequerido As String,
                   ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
                   FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
                   valoraltofabrica As Decimal, FormulaCantidadrequerida As String,
                   CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                   IdVidrio As Integer, Vidrio As String, IdColorVidrio As Integer, ColorVidrio As String,
                   IdEspesor As Integer, Espesor As String, IdAcbadoPerdiles As Integer, Acabado As String,
                   AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, pxunidad As Decimal, MetrosOriginales As Decimal,
                   indAutomatico As Boolean, usuarioCreacion As String, fechaCreacion As DateTime, usuarioAprobacion As String,
                   fechaAprobacion As DateTime, usuarioAnulacion As String, fechaAnulacion As DateTime, usuarioModi As String,
                   fechaModi As DateTime, idEstado As Integer, Estado As String, ubicacion As String, descripcion As String, idCotiza As Integer, idItemCotiza As Integer,
                   precioUnitario As Decimal, precioInstalacion As Decimal, puntos As Decimal, metrosIntalacion As Decimal, indNSR As Boolean,
                   ubicacionEstructura As String, aprobado_cliente As Integer, observaciones As String, imagen As Byte(),
                   versionCostoKiloAluminio As Integer, versionCostoNiveles As Integer, versionCostoAcabado As Integer,
                   versionCostoVidrio As Integer, versionCostoAccesorios As Integer, versionCostoOtros As Integer, refsiesa As String)
        Try
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
            _idEncabeOp = idEncabeOp
            _idItemContrato = idItemPadreContrato
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
            _cantidad = Convert.ToInt32(CantidadOriginal)
            _pxunidad = pxunidad
            _mtCuadrados = MetrosOriginales
            _indAutomatico = indAutomatico
            _idCotiza = idCotiza
            _idItemCotiza = idItemCotiza
            _ubicacion = Trim(ubicacion)
            _descripcion = Trim(descripcion)
            _precioUnitario = precioUnitario
            precioInstalacion = precioInstalacion
            _punto = puntos
            _metrosInstalacion = metrosIntalacion
            _IndNSR = indNSR
            _ubicacionEstructura = Trim(ubicacionEstructura)
            _aprobado_cliente = aprobado_cliente
            _observaciones = Trim(observaciones)
            _imagen = imagen
            _versionCostoKiloAluminio = versionCostoKiloAluminio
            _versionCostoAcabado = versionCostoAcabado
            _versionCostoNiveles = versionCostoNiveles
            _versionCostoVidrio = versionCostoVidrio
            _versionCostoAccesorios = versionCostoAccesorios
            _versionCostoOtrosArticulos = versionCostoOtros
            _refSieas = refsiesa
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
