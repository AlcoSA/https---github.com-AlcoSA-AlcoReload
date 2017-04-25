Imports Datos
Public Class ClsItemsHijoOped
#Region "vars"
    Private _objItemHojoOp As New dsAlcoProduccionTableAdapters.tp004_movitoHijosOPTableAdapter

#End Region
#Region "Procedimientos"
    Public Function Insertar(idpadreop As Integer, idItemcotiza As Integer, FormulaAnchoRequerido As String,
                    ValorAnchoRequerido As Decimal, formulaanchofabrica As String, anchofabrica As Decimal,
                    FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
                    altofabrica As Decimal, FormulaCantidadrequerida As String,
                    CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                    IdVidrio As Integer, IdColorVidrio As Integer, IdEspesor As Integer, IdAcbadoPerdiles As Integer,
                    AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, PxUOriginales As Decimal,
                    MetrosOriginales As Decimal, indAutomatico As Boolean, preciounitario As Decimal, precioinstalacion As Decimal,
                             metrosinstalacion As Decimal, puntos As Decimal, observaciones As String, usuario As String, idArticulo As Integer, indNsr As Boolean, tipoItem As Integer, idEstado As Integer,
                             ubicacion As String, descripcion As String) As Integer
        Try
            Return Convert.ToInt32(_objItemHojoOp.sp_tp004_insert(idpadreop, idItemcotiza, FormulaAnchoRequerido,
                                           ValorAnchoRequerido, formulaanchofabrica, anchofabrica,
                                        FormulaAltoRequerido, valorAltoRequerido, formulaaltofabrica, altofabrica, FormulaCantidadrequerida,
                                           CantidadRequerida, FormulaPxURequeridas, PxURequeridas, MetrosRequeridos, IdVidrio,
                                           IdEspesor, IdColorVidrio, IdAcbadoPerdiles, AnchoOriginal, AltoOriginal, CantidadOriginal, PxUOriginales,
                                           MetrosOriginales, indAutomatico, preciounitario, precioinstalacion, metrosinstalacion, puntos,
                                         observaciones, usuario, idArticulo, indNsr, tipoItem, idEstado, ubicacion, descripcion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(idpadreop As Integer, idItemcotiza As Integer, FormulaAnchoRequerido As String,
                    ValorAnchoRequerido As Decimal, formulaanchofabrica As String, anchofabrica As Decimal,
                    FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
                    altofabrica As Decimal, FormulaCantidadrequerida As String,
                    CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                    IdVidrio As Integer, IdColorVidrio As Integer, IdEspesor As Integer, IdAcbadoPerdiles As Integer,
                    AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, PxUOriginales As Decimal,
                    MetrosOriginales As Decimal, indAutomatico As Boolean, preciounitario As Decimal, precioinstalacion As Decimal,
                    metrosinstalacion As Decimal, puntos As Decimal, observaciones As String, usuario As String, idArticulo As Integer, indNsr As Boolean, tipoItem As Integer, idEstado As Integer,
                    ubicacion As String, descripcion As String, id As Integer)
        Try
            _objItemHojoOp.sp_tp004_update(id, idpadreop, idItemcotiza, FormulaAnchoRequerido, ValorAnchoRequerido,
                                           formulaanchofabrica, anchofabrica, FormulaAltoRequerido, valorAltoRequerido,
                                           formulaaltofabrica, altofabrica, FormulaCantidadrequerida, CantidadRequerida,
                                           FormulaPxURequeridas, PxURequeridas, MetrosRequeridos, IdVidrio,
                                           IdEspesor, IdColorVidrio, IdAcbadoPerdiles, AnchoOriginal, AltoOriginal, CantidadOriginal,
                                           PxUOriginales, MetrosOriginales, indAutomatico, preciounitario,
                                           precioinstalacion, metrosinstalacion, puntos, observaciones, usuario, idArticulo, indNsr,
                                           tipoItem, idEstado, ubicacion, descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(ByRef Optional tb As DataTable = Nothing) As List(Of ItemHijoOp)
        Try
            TraerTodos = New List(Of ItemHijoOp)
            Dim sp As New dsAlcoProduccionTableAdapters.sp_tp004_SelectAllTableAdapter()
            Dim ta As dsAlcoProduccion.sp_tp004_SelectAllDataTable = sp.GetData()
            ta.Rows.Cast(Of dsAlcoProduccion.sp_tp004_SelectAllRow).ToList.ForEach(
                Sub(it)
                    TraerTodos.Add(New ItemHijoOp(it.id, it.IdPadre, it.iditemcotiza, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.UsuarioAprobacion, it.FechaAprobacion,
                                               it.UsuarioAnulacion, it.FechaAnulacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.disponible, it.ubicacion, it.descripcion, it.idPadreCotiza, it.idCotiza, it.idItemContrato, it.Estado, it.Observaciones,
                                               it.versioncostokiloaluminio, it.versioncostoacabado, it.versioncostoniveles,
                                               it.versioncostovidrio, it.versioncostoaccesorios, it.versioncostootros))
                End Sub)
            tb = If(ta.Count > 0, ta.CopyToDataTable, New DataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdPadre(idPadreOp As Integer) As List(Of ItemHijoOp)
        TraerxIdPadre = New List(Of ItemHijoOp)
        Try
            Dim sp As New dsAlcoProduccionTableAdapters.sp_tp004_selectByIdPadreTableAdapter
            Dim ta As dsAlcoProduccion.sp_tp004_selectByIdPadreDataTable = sp.GetData(idPadreOp)
            ta.Rows.Cast(Of dsAlcoProduccion.sp_tp004_selectByIdPadreRow).ToList.ForEach(
                Sub(it)
                    TraerxIdPadre.Add(New ItemHijoOp(it.id, it.IdPadre, it.iditemcotiza, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.UsuarioAprobacion, it.FechaAprobacion,
                                               it.UsuarioAnulacion, it.FechaAnulacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.disponible, it.ubicacion, it.descripcion, it.idPadreCotiza, it.idCotiza, it.idItemContrato, it.Estado, it.Observaciones,
                                               it.versioncostokiloaluminio, it.versioncostoacabado, it.versioncostoniveles,
                                               it.versioncostovidrio, it.versioncostoaccesorios, it.versioncostootros))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerIdCotizacionPertenece(iditem As Integer) As Integer
        TraerIdCotizacionPertenece = 0
        Try
            Return Convert.ToInt32(_objItemHojoOp.sp_tp004_selectCotizaPertenece(iditem))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


#End Region
End Class
Public Class ItemHijoOp : Inherits ItemsOp
#Region "vars"
    Protected _idItemPadre As Integer
    Protected _idItemPadreCotiza As Integer
    Protected _idArticulo As Integer
    Protected _tipoItem As Integer
    Protected _disponible As Decimal
#End Region
#Region "Propiedades"
    Public Property IdItemPadre() As Integer
        Get
            Return _idItemPadre
        End Get
        Set(ByVal value As Integer)
            _idItemPadre = value
        End Set
    End Property
    Public Property idItemPadreCotiza() As Integer
        Get
            Return _idItemPadreCotiza
        End Get
        Set(ByVal value As Integer)
            _idItemPadreCotiza = value
        End Set
    End Property
    Public Property idArticulo() As Integer
        Get
            Return _idArticulo
        End Get
        Set(ByVal value As Integer)
            _idArticulo = value
        End Set
    End Property
    Public Property tipoitem() As Integer
        Get
            Return _tipoItem
        End Get
        Set(ByVal value As Integer)
            _tipoItem = value
        End Set
    End Property
    Public Property disponible() As Decimal
        Get
            Return _disponible
        End Get
        Set(ByVal value As Decimal)
            _disponible = value
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
    Public Sub New(id As Integer, idItemPadre As Integer, idItemPadreCotiza As Integer, FormulaAnchoRequerido As String,
                    ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
                   FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
                   valoraltofabrica As Decimal, FormulaCantidadrequerida As String,
                    CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                    IdVidrio As Integer, Vidrio As String, IdColorVidrio As Integer, ColorVidrio As String,
                    IdEspesor As Integer, Espesor As String, IdAcbadoPerdiles As Integer, Acabado As String,
                    AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, pxuOriginal As Decimal, MetrosOriginales As Decimal,
                   indAutomatico As Boolean, precioUnitario As Decimal, precioInstalacion As Decimal, metrosInstalacion As Decimal, puntos As Decimal,
                   UsuarioCreacion As String, fechaCreacion As DateTime, usuarioAprobacion As String, fechaAprobacion As DateTime, usuarioAnulacion As String,
                   fechaAnulacion As DateTime, usuarioModi As String, fechaModi As DateTime, IdEstado As Integer, idArticulo As Integer,
                   indNsr As Boolean, tipoItem As Integer, disponible As Decimal, ubicacion As String, descripcion As String, idPadreCotiza As Integer,
                   idCotiza As Integer, idItemContrato As Integer, Estado As String, observaciones As String,
                   versionCostoKiloAluminio As Integer, versionCostoNiveles As Integer, versionCostoAcabado As Integer,
                   versionCostoVidrio As Integer, versionCostoAccesorios As Integer, versionCostoOtros As Integer)
        Try
            _id = id
            _usuariocreacion = UsuarioCreacion
            _fechacreacion = fechaCreacion
            _usuarioAprobacion = usuarioAprobacion
            _fechaAprobacion = fechaAprobacion
            _usuarioAnulacion = usuarioAnulacion
            _fechaAnulacion = fechaAnulacion
            _usuariomodificacion = usuarioModi
            _fechamodificacion = fechaModi
            _idestado = IdEstado
            _estado = Trim(Estado)
            _idEncabeOp = IdEncabeOp
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
            _precioUnitario = precioUnitario
            _precioInstalacion = precioInstalacion
            _metrosInstalacion = metrosInstalacion
            _punto = puntos
            _ubicacion = Trim(ubicacion)
            _descripcion = Trim(descripcion)
            _idItemPadre = idPadreCotiza
            _idItemContrato = idItemContrato
            _idArticulo = idArticulo
            _idItemPadre = idItemPadre
            _idItemPadreCotiza = idItemPadreCotiza
            _IndNSR = indNsr
            _tipoItem = tipoItem
            _disponible = disponible
            _observaciones = Trim(observaciones)
            _versionCostoKiloAluminio = versionCostoKiloAluminio
            _versionCostoAcabado = versionCostoAcabado
            _versionCostoNiveles = versionCostoNiveles
            _versionCostoVidrio = versionCostoVidrio
            _versionCostoAccesorios = versionCostoAccesorios
            _versionCostoOtrosArticulos = versionCostoOtros
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class

