Imports Datos
Public Class ClsHijosOrdenProd
#Region "vars"
    Private _mItemOp As New dsAlcoOrdenesProduccionTableAdapters.top003_MovitoHijosOpTableAdapter
#End Region
#Region "procs"
    Public Function Insertar(idpadreoprod As Integer, iditemordenped As Integer,
                             formulaanchofabrica As String, anchofabrica As Decimal, formulaaltofabrica As String,
                             altofabrica As Decimal, formulacantidad As String, cantidad As Decimal, formulapxuni As String,
                             pxuni As Decimal, mtscuadrados As Decimal, idvidrio As Integer, idespesor As Integer,
                             idcolorvidrio As Integer, idacabado As Integer, indautomatico As Boolean, preciounitario As Decimal,
                             precioinstalacion As Decimal, metrosinstalacion As Decimal, puntos As Decimal, observaciones As String,
                             usuario As String, idarticulo As Integer, estado As Integer, indNSR As Boolean,
                             tipoitem As Integer, ubicacion As String, descripcion As String) As Integer
        Try
            Return Convert.ToInt32(_mItemOp.sp_top003_insert(idpadreoprod, iditemordenped, formulaanchofabrica, anchofabrica,
                                      formulaaltofabrica, altofabrica, formulacantidad, cantidad, formulapxuni,
                                      pxuni, mtscuadrados, idvidrio, idespesor, idcolorvidrio, idacabado, indautomatico,
                                      preciounitario, precioinstalacion, metrosinstalacion, puntos, observaciones, usuario, idarticulo,
                                      estado, indNSR, tipoitem, ubicacion, descripcion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(idpadreoprod As Integer, iditemordenped As Integer,
                             formulaanchofabrica As String, anchofabrica As Decimal, formulaaltofabrica As String,
                             altofabrica As Decimal, formulacantidad As String, cantidad As Decimal, formulapxuni As String,
                             pxuni As Decimal, mtscuadrados As Decimal, idvidrio As Integer, idespesor As Integer,
                             idcolorvidrio As Integer, idacabado As Integer, indautomatico As Boolean, preciounitario As Decimal,
                             precioinstalacion As Decimal, metrosinstalacion As Decimal, puntos As Decimal, observaciones As String,
                             usuario As String, idarticulo As Integer, estado As Integer, indNSR As Boolean,
                             tipoitem As Integer, ubicacion As String, descripcion As String, id As Integer)
        Try
            _mItemOp.sp_top003_update(idpadreoprod, iditemordenped, formulaanchofabrica, anchofabrica,
                                      formulaaltofabrica, altofabrica, formulacantidad, cantidad, formulapxuni, pxuni, mtscuadrados,
                                      idvidrio, idespesor, idcolorvidrio, idacabado, indautomatico, preciounitario, precioinstalacion,
                                      metrosinstalacion, puntos, observaciones, usuario, idarticulo, estado, indNSR, tipoitem, ubicacion, descripcion,
                                      id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar_Estado(idhijoprod As Integer, estado As Integer, usuario As String)
        Try
            _mItemOp.sp_top003_updateEstado(idhijoprod, estado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Eliminar_por_Id(idhijoprod As Integer)
        Try
            _mItemOp.sp_top003_deleteById(idhijoprod)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerporIdPadreOrdenPed(idpadreordenped As Integer) As List(Of HijoOrdenProd)
        Try
            TraerporIdPadreOrdenPed = New List(Of HijoOrdenProd)
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top003_selectCombinadoByIdItemPadreTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top003_selectCombinadoByIdItemPadreDataTable = sp.GetData(idpadreordenped)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top003_selectCombinadoByIdItemPadreRow).ToList.ForEach(
                Sub(it)
                    TraerporIdPadreOrdenPed.Add(New HijoOrdenProd(it.id, it.iditemoped, it.IdPadre, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.ubicacion, it.descripcion, it.Estado, it.Observaciones))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerporIdPadreOrdenProduccion(idpadreordenprod As Integer) As List(Of HijoOrdenProd)
        Try
            TraerporIdPadreOrdenProduccion = New List(Of HijoOrdenProd)
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top003_selectByIdPadreTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top003_selectByIdPadreDataTable = sp.GetData(idpadreordenprod)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top003_selectByIdPadreRow).ToList.ForEach(
                Sub(it)
                    TraerporIdPadreOrdenProduccion.Add(New HijoOrdenProd(it.id, it.iditemoped, it.IdPadre, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.ubicacion, it.descripcion, it.Estado, it.Observaciones))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerporId(id As Integer) As HijoOrdenProd
        Try
            TraerporId = New HijoOrdenProd
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top003_selectByIdTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top003_selectByIdDataTable = sp.GetData(id)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top003_selectByIdRow).ToList.ForEach(
                Sub(it)
                    TraerporId = New HijoOrdenProd(it.id, it.iditemoped, it.IdPadre, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.ubicacion, it.descripcion, it.Estado, it.Observaciones)
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function Traerbasexidbase(iditemoped As Integer) As HijoOrdenProd
        Traerbasexidbase = New HijoOrdenProd
        Try
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top003_selectBaseTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top003_selectBaseDataTable = sp.GetData(iditemoped)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top003_selectBaseRow).ToList.ForEach(
                Sub(it)
                    Traerbasexidbase = New HijoOrdenProd(it.id, it.iditemoped, it.IdPadre, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.ubicacion, it.descripcion, it.Estado, it.Observaciones)
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerbasexidPadreOped(iditempadreoped As Integer) As List(Of HijoOrdenProd)
        TraerbasexidPadreOped = New List(Of HijoOrdenProd)
        Try
            Dim sp As New dsAlcoOrdenesProduccionTableAdapters.sp_top003_selectbaseByIdpadreOpedTableAdapter
            Dim ta As dsAlcoOrdenesProduccion.sp_top003_selectbaseByIdpadreOpedDataTable = sp.GetData(iditempadreoped)
            ta.Rows.Cast(Of dsAlcoOrdenesProduccion.sp_top003_selectbaseByIdpadreOpedRow).ToList.ForEach(
                Sub(it)
                    TraerbasexidPadreOped.Add(New HijoOrdenProd(it.id, it.iditemoped, it.IdPadre, it.FormulaAnchoR, it.valorAnchoR, it.formulaanchofabrica, it.valoranchofabrica,
                                               it.FormulaAltoR, it.ValorAltoR, it.formulaaltofabrica, it.valoraltofabrica, it.FormulaCantR, it.ValorCantR, it.FormulaPxUR,
                                               it.ValorPxUR, it.MtrosRequeridos, it.idVidrio, it.Vidrio, it.idColorVidrio, it.ColorVidrio,
                                               it.idEspesor, it.Espesor, it.idAcabado, it.AcabadoPerfiles, it.AnchoOriginal, it.AltoOriginal, it.CantidadOriginal,
                                               it.PxUOriginal, it.MtrosOriginales, it.indicadorAutomatico, it.precioUnitario, it.precionInstalacion,
                                               it.metrosInstalacion, it.puntos, it.UsuarioCreacion, it.FechaCreacion, it.usuarioModi, it.FechaModi, it.idEstado, it.idArticulo, it.indNsr, it.TipoItem,
                                               it.ubicacion, it.descripcion, it.Estado, it.Observaciones))
                End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class HijoOrdenProd
    Inherits ItemHijoOp
#Region "vars"
    Private _idoped As Integer = 0
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
    Public Sub New(id As Integer, iditemoped As Integer, idItemPadre As Integer, FormulaAnchoRequerido As String,
                ValorAnchoRequerido As Decimal, formulaanchofabrica As String, valoranchofabrica As Decimal,
               FormulaAltoRequerido As String, valorAltoRequerido As Decimal, formulaaltofabrica As String,
               valoraltofabrica As Decimal, FormulaCantidadrequerida As String,
                CantidadRequerida As Decimal, FormulaPxURequeridas As String, PxURequeridas As Decimal, MetrosRequeridos As Decimal,
                IdVidrio As Integer, Vidrio As String, IdColorVidrio As Integer, ColorVidrio As String,
                IdEspesor As Integer, Espesor As String, IdAcbadoPerdiles As Integer, Acabado As String,
                AnchoOriginal As Decimal, AltoOriginal As Decimal, CantidadOriginal As Decimal, pxuOriginal As Decimal, MetrosOriginales As Decimal,
               indAutomatico As Boolean, precioUnitario As Decimal, precioInstalacion As Decimal, metrosInstalacion As Decimal, puntos As Decimal,
               UsuarioCreacion As String, fechaCreacion As DateTime, usuarioModi As String, fechaModi As DateTime, IdEstado As Integer, idArticulo As Integer,
               indNsr As Boolean, tipoItem As Integer, ubicacion As String, descripcion As String, Estado As String, observaciones As String)
        Try
            _id = id
            _idoped = iditemoped
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
            _idArticulo = idArticulo
            _idItemPadre = idItemPadre
            _idItemPadreCotiza = idItemPadreCotiza
            _IndNSR = indNsr
            _tipoItem = tipoItem
            Me.Observaciones = Trim(observaciones)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
