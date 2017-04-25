Imports Datos
Namespace movitoHijos
    Public Class ClsMovitoHijos
#Region "Variables"
        Private taMovitoHijos As New dsAlcoCotizacionesTableAdapters.tc018_movitoHijoCotizaTableAdapter
#End Region
#Region "Procedimientos"
        Public Function Insertar(usuarioCreacion As String, idPadre As Integer, idArticulo As Integer, idPlantilla As Integer, idArticuloTemp As Integer,
                                 cantidad As Integer, piezasxUnidad As Decimal, ancho As Decimal, alto As Decimal, idAcabadoPerfileria As Integer,
                                 idVidrio As Integer, idColorVidrio As Integer, idEspesor As Integer, versionCostoVidrio As Integer,
                                 versionCostoNiveles As Integer, versionCostoAcabado As Integer, versionCostoKiloAluminio As Integer,
                                 versionCostoAccesorios As Integer, versionCostoOtrosArticulos As Integer, descuento As Decimal, factor As Decimal,
                                 tipoItem As Integer, tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, calculoNSR As Boolean,
                                 cumpleNorma As Boolean, numero_cuerpos_norma As Integer, idEstado As Integer, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorio As Decimal,
                                 costoOtros As Decimal, modelo As String, descModelo As String, colorTemporal As Boolean, espesorTemporal As Boolean,
                                 acabadoTemporal As Boolean, costoUnitario As Decimal, costoTotal As Decimal, precioUnitario As Decimal,
                                 precioTotal As Decimal, valorDescuento As Decimal, vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal,
                                 vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, costoinstalacionuni As Decimal) As Integer
            Try
                Return Convert.ToInt32(taMovitoHijos.sp_tc018_insert(usuarioCreacion, idPadre, idArticulo, idPlantilla, idArticuloTemp, cantidad,
                                                                     piezasxUnidad, ancho, alto, idAcabadoPerfileria, idVidrio, idColorVidrio, idEspesor,
                                                                     versionCostoVidrio, versionCostoNiveles, versionCostoAcabado, versionCostoKiloAluminio,
                                                                     versionCostoAccesorios, versionCostoOtrosArticulos, descuento, factor, tipoItem,
                                                                     tarifaMtInstalacion, precioInstalacion, calculoNSR, cumpleNorma, numero_cuerpos_norma, idEstado, costoVidrio,
                                                                     costoPerfiles, costoAccesorio, costoOtros, modelo, descModelo, colorTemporal,
                                                                     espesorTemporal, acabadoTemporal, costoUnitario, costoTotal, precioUnitario, precioTotal,
                                                                     valorDescuento, vlrDespVidrio, vlrDespPerfiles, vlrDespAccesorios, vlrDespOtros,
                                                                     costoinstalacionuni))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Sub Modificar(id As Integer, cantidad As Integer, piezasxUnidad As Decimal, ancho As Decimal, alto As Decimal,
                             idAcabado As Integer, idVidrio As Integer, idColorVidrio As Integer, idEspesor As Integer,
                             versCostoVidrio As Integer, versCostoNiveles As Integer, versCostoAcabado As Integer, versCostoKiloAluminio As Integer,
                             versCostoAccesorios As Integer, versCostoOtros As Integer, descuento As Decimal, factor As Decimal,
                             tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, calculoNSR As Boolean, cumpleNorma As Boolean,
                             numero_cuerpos_norma As Integer, usuario As String, idEstado As Integer, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorio As Decimal,
                             costoOtros As Decimal, colorTemporal As Boolean, espesorTemporal As Boolean, acabadoTemporal As Boolean,
                             costoUnitario As Decimal, costoTotal As Decimal, precioUnitario As Decimal, precioTotal As Decimal, valorDescuento As Decimal,
                             vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal, vlrDespAccesorios As Decimal, vlrDespOtros As Decimal,
                             costoinstalacionuni As Decimal)
            Try
                taMovitoHijos.sp_tc018_update(id, cantidad, piezasxUnidad, ancho, alto, idAcabado, idVidrio, idColorVidrio, idEspesor,
                                              versCostoVidrio, versCostoNiveles, versCostoAcabado, versCostoKiloAluminio, versCostoAccesorios,
                                              versCostoOtros, descuento, factor, tarifaMtInstalacion, precioInstalacion, calculoNSR,
                                              cumpleNorma, numero_cuerpos_norma, usuario, idEstado, costoVidrio, costoPerfiles, costoAccesorio, costoOtros,
                                              colorTemporal, espesorTemporal, acabadoTemporal, costoUnitario,
                                              costoTotal, precioUnitario, precioTotal, valorDescuento, vlrDespVidrio, vlrDespPerfiles,
                                              vlrDespAccesorios, vlrDespOtros, costoinstalacionuni)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        Public Function Duplicar(idpadre As Integer, id_viejo As Integer, idacabado As Integer, usuario As String) As Integer
            Try
                Return Convert.ToInt32(taMovitoHijos.sp_tc018_duplicar(idpadre, id_viejo, idacabado, usuario))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Sub cambioEstado(id As Integer, idEstado As Integer)
            Try
                taMovitoHijos.sp_tc018_updateEstado(id, idEstado)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Function TraerxId(id As Integer) As movitoHijo
            Try
                TraerxId = New movitoHijo
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc018_selectByIdTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc018_selectByIdDataTable = taAll.GetData(id)
                If txAll.Rows.Count > 0 Then
                    Dim ti As dsAlcoCotizaciones.sp_tc018_selectByIdRow = DirectCast(txAll.Rows(0), dsAlcoCotizaciones.sp_tc018_selectByIdRow)
                    TraerxId = New movitoHijo(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPadre, ti.idArticulo, ti.Referencia,
                                                                    ti.Descripcion, ti.idPlantilla, ti.idArticuloTemporal, ti.cantidad, ti.piezasxUnidad, ti.ancho, ti.alto, ti.idAcabadoPerfilaria,
                                                                    ti.acabado, ti.idVidrio, ti.vidrio, ti.idColorVidrio, ti.colorVidrio, ti.idEspesor,
                                                                    ti.espesor, ti.unidadMedida, ti.descuento, ti.factor, ti.tipoItem, ti.tarifaInstalacion, ti.calculo_NSR,
                                                                    ti.cumpleNorma, ti.numero_cuerpos, ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.valorDescuento, ti.precioUnitario,
                                                         ti.precioTotal, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                         ti.precioInstalacion, ti.colorTemporal, ti.espesorTemporal, ti.acabadoTemporal,
                                                         ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                         ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros, ti.costo_instalacionUni)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function TraerxIdPadre(idpadre As Integer) As List(Of movitoHijo)
            Try
                TraerxIdPadre = New List(Of movitoHijo)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc018_selectByIdPadreTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc018_selectByIdPadreDataTable = taAll.GetData(idpadre)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc018_selectByIdPadreRow In txAll.Rows
                        TraerxIdPadre.Add(New movitoHijo(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPadre, ti.idArticulo, ti.Referencia,
                                                                    ti.Descripcion, ti.idPlantilla, ti.idArticuloTemporal, ti.cantidad, ti.piezasxUnidad, ti.ancho, ti.alto, ti.idAcabadoPerfilaria,
                                                                    ti.acabado, ti.idVidrio, ti.vidrio, ti.idColorVidrio, ti.colorVidrio, ti.idEspesor,
                                                                    ti.espesor, ti.unidadMedida, ti.descuento, ti.factor, ti.tipoItem, ti.tarifaInstalacion, ti.calculo_NSR,
                                                                    ti.cumpleNorma, ti.numero_cuerpos, ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.valorDescuento, ti.precioUnitario,
                                                         ti.precioTotal, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                         ti.precioInstalacion, ti.colorTemporal, ti.espesorTemporal, ti.acabadoTemporal,
                                                         ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                         ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros, ti.costo_instalacionUni,
                                                ti.verCostoKiloAluminio, ti.verCostoAcabado, ti.verCostoNiveles, ti.verCostoVidrio,
                                                ti.verCostoAccesorios, ti.verCostoOtros))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxIdCotiza(idCotiza As Integer) As List(Of movitoHijo)
            Try
                TraerxIdCotiza = New List(Of movitoHijo)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc018_selectByIdCotizaTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc018_selectByIdCotizaDataTable = taAll.GetData(idCotiza)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc018_selectByIdCotizaRow In txAll.Rows
                        TraerxIdCotiza.Add(New movitoHijo(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPadre, ti.idArticulo, ti.Referencia,
                                                          ti.Descripcion, ti.idPlantilla, ti.idArticuloTemporal, ti.cantidad, ti.piezasxUnidad,
                                                          ti.ancho, ti.alto, ti.idAcabadoPerfilaria, ti.acabado, ti.idVidrio, ti.vidrio,
                                                          ti.idColorVidrio, ti.colorVidrio, ti.idEspesor, ti.espesor, ti.unidadMedida, ti.descuento,
                                                          ti.factor, ti.tipoItem, ti.tarifaInstalacion, ti.calculo_NSR,
                                                          ti.cumpleNorma, ti.numero_cuerpos, ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.valorDescuento, ti.precioUnitario,
                                                         ti.precioTotal, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                         ti.precioInstalacion, ti.colorTemporal, ti.espesorTemporal, ti.acabadoTemporal,
                                                         ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                         ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros, ti.costo_instalacionUni))

                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerparaOrdenPedidoxIdPadreCotiza(idpadreCotiza As Integer) As List(Of movitoHijoOrdenPed)
            Try
                TraerparaOrdenPedidoxIdPadreCotiza = New List(Of movitoHijoOrdenPed)
                Dim taAll As New dsAlcoProduccionTableAdapters.sp_tc018_selectparaOrdenPedidoTableAdapter
                Dim txAll As dsAlcoProduccion.sp_tc018_selectparaOrdenPedidoDataTable = taAll.GetData(idpadreCotiza)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoProduccion.sp_tc018_selectparaOrdenPedidoRow In txAll.Rows
                        TraerparaOrdenPedidoxIdPadreCotiza.Add(New movitoHijoOrdenPed(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idPadre, ti.idArticulo, ti.Referencia,
                                                                    ti.Descripcion, ti.idPlantilla, ti.idArticuloTemporal, ti.cantidad, ti.cantidad_disponible, ti.piezasxUnidad, ti.ancho, ti.alto, ti.idAcabadoPerfilaria,
                                                                    ti.acabado, ti.idVidrio, ti.vidrio, ti.idColorVidrio, ti.colorVidrio, ti.idEspesor,
                                                                    ti.espesor, ti.unidadMedida, ti.descuento, ti.factor, ti.tipoItem, ti.tarifaInstalacion, ti.calculo_NSR,
                                                                    ti.cumpleNorma, ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.valorDescuento, ti.precioUnitario,
                                                         ti.precioTotal, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                         ti.precioInstalacion, ti.colorTemporal, ti.espesorTemporal, ti.acabadoTemporal,
                                                         ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                         ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TemporalesCotizados(idCotiza As Integer, busqueda As String, referencia As String) As Integer
            Try
                Return Convert.ToInt32(taMovitoHijos.sp_tc018_selectTemporales(idCotiza, busqueda, referencia))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region
    End Class
    Public Class movitoHijo
        Inherits ClsBaseParametros
#Region "Variables"
        Private _idPadre As Integer = 0
        Private _idArticulo As Integer = 0
        Private _idPlantilla As Integer = 0
        Private _idArticuloTemporal As Integer
        Private _descripcion As String = String.Empty
        Private _referencia As String = String.Empty
        Private _unidadMedia As String = String.Empty
        Private _ancho As Decimal = 0
        Private _alto As Decimal = 0
        Private _cantidad As Integer = 0
        Private _piezasxUnidad As Decimal = 0
        Private _idAcabadoPerfil As Integer = 0
        Private _acabadoPerfil As String = String.Empty
        Private _idVidrio As Integer = 0
        Private _vidrio As String = String.Empty
        Private _idColorVidrio As Integer = 0
        Private _colorVidrio As String = String.Empty
        Private _idEspesor As Integer = 0
        Private _espesor As String = String.Empty
        Private _verCostoVidrio As Integer = 0
        Private _verCostoNiveles As Integer = 0
        Private _verCostoAcabado As Integer = 0
        Private _verCostoKiloAluminio As Integer = 0
        Private _verCostoAccesorios As Integer = 0
        Private _verCostoOtrosArticulos As Integer = 0
        Private _descuento As Decimal = 0
        Private _valorDescuento As Decimal = 0
        Private _factor As Decimal = 0
        Private _tipoItem As Integer = 0
        Private _precioUnitario As Decimal = 0
        Private _precioTotal As Decimal = 0
        Private _costoVidrio As Decimal = 0
        Private _costoPerfiles As Decimal = 0
        Private _costoAccesorios As Decimal = 0
        Private _costoOtros As Decimal = 0
        Private _costoUnitario As Decimal = 0
        Private _costoTotal As Decimal = 0
        Private _tarifaMtInstalacion As Decimal = 0
        Private _precioInstalacion As Decimal = 0
        Private _calculo_NSR As Boolean = False
        Private _cumpleNorma As Boolean = False
        Private _numero_cuerpos_norma As Integer = 1
        Private _colorTemporal As Boolean
        Private _espesorTemporal As Boolean
        Private _acabadoTemporal As Boolean
        Private _costoinstalacionuni As Decimal
#End Region
#Region "Propiedades"
        Public Property idPadre() As Integer
            Get
                Return _idPadre
            End Get
            Set(ByVal value As Integer)
                _idPadre = value
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
        Public Property idPlantilla() As Integer
            Get
                Return _idPlantilla
            End Get
            Set(ByVal value As Integer)
                _idPlantilla = value
            End Set
        End Property
        Public Property IdArticuloTemporal() As Integer
            Get
                Return _idArticuloTemporal
            End Get
            Set(ByVal value As Integer)
                _idArticuloTemporal = value
            End Set
        End Property
        Public Property descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property referencia() As String
            Get
                Return _referencia
            End Get
            Set(ByVal value As String)
                _referencia = value
            End Set
        End Property
        Public Property unidadMedida() As String
            Get
                Return _unidadMedia
            End Get
            Set(ByVal value As String)
                _unidadMedia = value
            End Set
        End Property
        Public Property cantidad() As Integer
            Get
                Return _cantidad
            End Get
            Set(ByVal value As Integer)
                _cantidad = value
            End Set
        End Property
        Public Property piezasxUnidad() As Decimal
            Get
                Return _piezasxUnidad
            End Get
            Set(ByVal value As Decimal)
                _piezasxUnidad = value
            End Set
        End Property
        Public Property ancho() As Decimal
            Get
                Return _ancho
            End Get
            Set(ByVal value As Decimal)
                _ancho = value
            End Set
        End Property
        Public Property alto() As Decimal
            Get
                Return _alto
            End Get
            Set(ByVal value As Decimal)
                _alto = value
            End Set
        End Property
        Public Property idAcabadoPerfil() As Integer
            Get
                Return _idAcabadoPerfil
            End Get
            Set(ByVal value As Integer)
                _idAcabadoPerfil = value
            End Set
        End Property
        Public Property acabadoPerfil() As String
            Get
                Return _acabadoPerfil
            End Get
            Set(ByVal value As String)
                _acabadoPerfil = value
            End Set
        End Property
        Public Property idVidrio() As Integer
            Get
                Return _idVidrio
            End Get
            Set(ByVal value As Integer)
                _idVidrio = value
            End Set
        End Property
        Public Property vidrio() As String
            Get
                Return _vidrio
            End Get
            Set(ByVal value As String)
                _vidrio = value
            End Set
        End Property
        Public Property idColorVidrio() As Integer
            Get
                Return _idColorVidrio
            End Get
            Set(ByVal value As Integer)
                _idColorVidrio = value
            End Set
        End Property
        Public Property colorVidrio() As String
            Get
                Return _colorVidrio
            End Get
            Set(ByVal value As String)
                _colorVidrio = value
            End Set
        End Property
        Public Property idEspesor() As Integer
            Get
                Return _idEspesor
            End Get
            Set(ByVal value As Integer)
                _idEspesor = value
            End Set
        End Property
        Public Property espesor() As String
            Get
                Return _espesor
            End Get
            Set(ByVal value As String)
                _espesor = value
            End Set
        End Property
        Public Property verCostoVidrio() As Integer
            Get
                Return _verCostoVidrio
            End Get
            Set(ByVal value As Integer)
                _verCostoVidrio = value
            End Set
        End Property
        Public Property verCostoNiveles() As Integer
            Get
                Return _verCostoNiveles
            End Get
            Set(ByVal value As Integer)
                _verCostoNiveles = value
            End Set
        End Property
        Public Property verCostoAcabado() As Integer
            Get
                Return _verCostoAcabado
            End Get
            Set(ByVal value As Integer)
                _verCostoAcabado = value
            End Set
        End Property
        Public Property verCostoKiloAluminio() As Integer
            Get
                Return _verCostoKiloAluminio
            End Get
            Set(ByVal value As Integer)
                _verCostoKiloAluminio = value
            End Set
        End Property
        Public Property verCostoAccesorios() As Integer
            Get
                Return _verCostoAccesorios
            End Get
            Set(ByVal value As Integer)
                _verCostoAccesorios = value
            End Set
        End Property
        Public Property verCostoOtrosArticulos() As Integer
            Get
                Return _verCostoOtrosArticulos
            End Get
            Set(ByVal value As Integer)
                _verCostoOtrosArticulos = value
            End Set
        End Property
        Public Property descuento() As Decimal
            Get
                Return _descuento
            End Get
            Set(ByVal value As Decimal)
                _descuento = value
            End Set
        End Property
        Public Property valorDescuento() As Decimal
            Get
                Return _valorDescuento
            End Get
            Set(ByVal value As Decimal)
                _valorDescuento = value
            End Set
        End Property
        Public Property factor() As Decimal
            Get
                Return _factor
            End Get
            Set(ByVal value As Decimal)
                _factor = value
            End Set
        End Property
        Public Property tipoItem() As Integer
            Get
                Return _tipoItem
            End Get
            Set(ByVal value As Integer)
                _tipoItem = value
            End Set
        End Property
        Public Property precioUnitario() As Decimal
            Get
                Return _precioUnitario
            End Get
            Set(ByVal value As Decimal)
                _precioUnitario = value
            End Set
        End Property
        Public Property precioTotal() As Decimal
            Get
                Return _precioTotal
            End Get
            Set(ByVal value As Decimal)
                _precioTotal = value
            End Set
        End Property
        Public Property costoVidrio() As Decimal
            Get
                Return _costoVidrio
            End Get
            Set(ByVal value As Decimal)
                _costoVidrio = value
            End Set
        End Property
        Public Property costoPerfiles() As Decimal
            Get
                Return _costoPerfiles
            End Get
            Set(ByVal value As Decimal)
                _costoPerfiles = value
            End Set
        End Property
        Public Property costoAccesorios() As Decimal
            Get
                Return _costoAccesorios
            End Get
            Set(ByVal value As Decimal)
                _costoAccesorios = value
            End Set
        End Property
        Public Property costoOtros() As Decimal
            Get
                Return _costoOtros
            End Get
            Set(ByVal value As Decimal)
                _costoOtros = value
            End Set
        End Property
        Public Property costoUnitario() As Decimal
            Get
                Return _costoUnitario
            End Get
            Set(ByVal value As Decimal)
                _costoUnitario = value
            End Set
        End Property
        Public Property costoTotal() As Decimal
            Get
                Return _costoTotal
            End Get
            Set(ByVal value As Decimal)
                _costoTotal = value
            End Set
        End Property
        Public Property tarifaMtInstalacion() As Decimal
            Get
                Return _tarifaMtInstalacion
            End Get
            Set(ByVal value As Decimal)
                _tarifaMtInstalacion = value
            End Set
        End Property
        Public Property precioInstalacion() As Decimal
            Get
                Return _precioInstalacion
            End Get
            Set(ByVal value As Decimal)
                _precioInstalacion = value
            End Set
        End Property
        Public Property calculo_NSR() As Boolean
            Get
                Return _calculo_NSR
            End Get
            Set(ByVal value As Boolean)
                _calculo_NSR = value
            End Set
        End Property
        Public Property cumpleNorma() As Boolean
            Get
                Return _cumpleNorma
            End Get
            Set(ByVal value As Boolean)
                _cumpleNorma = value
            End Set
        End Property
        Public Property Numero_Cuerpos_Norma As Integer
            Get
                Return _numero_cuerpos_norma
            End Get
            Set(value As Integer)
                _numero_cuerpos_norma = value
            End Set
        End Property
        Public Property ColorTemporal() As Boolean
            Get
                Return _colorTemporal
            End Get
            Set(ByVal value As Boolean)
                _colorTemporal = value
            End Set
        End Property
        Public Property EspesorTemporal() As Boolean
            Get
                Return _espesorTemporal
            End Get
            Set(ByVal value As Boolean)
                _espesorTemporal = value
            End Set
        End Property
        Public Property AcabadoTemporal() As Boolean
            Get
                Return _acabadoTemporal
            End Get
            Set(ByVal value As Boolean)
                _acabadoTemporal = value
            End Set
        End Property
        Private _vlrDespVidrio As Decimal
        Public Property vlrDespVidrio() As Decimal
            Get
                Return _vlrDespVidrio
            End Get
            Set(ByVal value As Decimal)
                _vlrDespVidrio = value
            End Set
        End Property
        Private _vlrDespPerfiles As Decimal
        Public Property vlrDespPerfiles() As Decimal
            Get
                Return _vlrDespPerfiles
            End Get
            Set(ByVal value As Decimal)
                _vlrDespPerfiles = value
            End Set
        End Property
        Private _vlrDespAccesorios As Decimal
        Public Property vlrDespAccesorios() As Decimal
            Get
                Return _vlrDespAccesorios
            End Get
            Set(ByVal value As Decimal)
                _vlrDespAccesorios = value
            End Set
        End Property
        Private _vlrDespOtros As Decimal
        Public Property vlrDespOtros() As Decimal
            Get
                Return _vlrDespOtros
            End Get
            Set(ByVal value As Decimal)
                _vlrDespOtros = value
            End Set
        End Property

        Public Property CostoInstalacion_Unitaria As Decimal
            Get
                Return _costoinstalacionuni
            End Get
            Set(value As Decimal)
                _costoinstalacionuni = value
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

        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idPadre As Integer, idArticulo As Integer,
                       referencia As String, descripcion As String, idplantilla As Integer, idArticuloTemporal As Integer, cantidad As Integer, piezasxUnidad As Decimal,
                       ancho As Decimal, alto As Decimal, idAcabado As Integer, acabado As String, idVidrio As Integer, vidrio As String,
                       idColorVidrio As Integer, colorVidrio As String, idEspesor As Integer, espesor As String, unidadMedida As String,
                       descuento As Decimal, factor As Decimal, tipoItem As Integer, tarifaInstalacion As Decimal, calculoNSR As Boolean,
                       cumpleNorma As Boolean, numero_cuerpos As Integer, fechaModi As DateTime, usuarioModi As String, idEstado As Integer, valorDcto As Decimal,
                       precioUnitario As Decimal, precioTotal As Decimal, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal,
                       costoOtros As Decimal, costoUnitario As Decimal, costoTotal As Decimal, precioMt2Instalacion As Decimal, colorTemporal As Boolean,
                       espesorTemporal As Boolean, acabadoTemporal As Boolean, vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal,
                       vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, costoinstalacion_uni As Decimal)
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = usuarioCreacion
                _idPadre = idPadre
                _idArticulo = idArticulo
                _referencia = Trim(referencia)
                _descripcion = Trim(descripcion)
                _idPlantilla = idplantilla
                _idArticuloTemporal = idArticuloTemporal
                _cantidad = cantidad
                _piezasxUnidad = piezasxUnidad
                _ancho = ancho
                _alto = alto
                _idAcabadoPerfil = idAcabado
                _acabadoPerfil = Trim(acabado)
                _idVidrio = idVidrio
                _vidrio = Trim(vidrio)
                _idColorVidrio = idColorVidrio
                _colorVidrio = Trim(colorVidrio)
                _idEspesor = idEspesor
                _espesor = Trim(espesor)
                _unidadMedia = Trim(unidadMedida)
                _descuento = descuento
                _valorDescuento = valorDcto
                _factor = factor
                _tipoItem = tipoItem
                _precioUnitario = precioUnitario
                _precioTotal = precioTotal
                _costoVidrio = costoVidrio
                _costoPerfiles = costoPerfiles
                _costoAccesorios = costoAccesorios
                _costoOtros = costoOtros
                _costoUnitario = costoUnitario
                _costoTotal = costoTotal
                _tarifaMtInstalacion = tarifaInstalacion
                _precioInstalacion = precioMt2Instalacion
                _calculo_NSR = calculoNSR
                _cumpleNorma = cumpleNorma
                _numero_cuerpos_norma = numero_cuerpos
                _fechamodificacion = fechaModi
                _usuariomodificacion = usuarioModi
                _idestado = idEstado
                _colorTemporal = colorTemporal
                _espesorTemporal = espesorTemporal
                _acabadoTemporal = acabadoTemporal
                _vlrDespVidrio = vlrDespVidrio
                _vlrDespPerfiles = vlrDespPerfiles
                _vlrDespAccesorios = vlrDespAccesorios
                _vlrDespOtros = vlrDespOtros
                _costoinstalacionuni = costoinstalacion_uni
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idPadre As Integer, idArticulo As Integer,
                       referencia As String, descripcion As String, idplantilla As Integer, idArticuloTemporal As Integer, cantidad As Integer, piezasxUnidad As Decimal,
                       ancho As Decimal, alto As Decimal, idAcabado As Integer, acabado As String, idVidrio As Integer, vidrio As String,
                       idColorVidrio As Integer, colorVidrio As String, idEspesor As Integer, espesor As String, unidadMedida As String,
                       descuento As Decimal, factor As Decimal, tipoItem As Integer, tarifaInstalacion As Decimal, calculoNSR As Boolean,
                       cumpleNorma As Boolean, numero_cuerpos As Integer, fechaModi As DateTime, usuarioModi As String, idEstado As Integer, valorDcto As Decimal,
                       precioUnitario As Decimal, precioTotal As Decimal, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal,
                       costoOtros As Decimal, costoUnitario As Decimal, costoTotal As Decimal, precioMt2Instalacion As Decimal, colorTemporal As Boolean,
                       espesorTemporal As Boolean, acabadoTemporal As Boolean, vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal,
                       vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, costoinstalacion_uni As Decimal,
                       vercostokiloaluminio As Integer, vercostoacabado As Integer, vercostoniveles As Integer, vercostovidrio As Integer,
                       vercostoaccesorios As Integer, vercostootros As Integer)
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = usuarioCreacion
                _idPadre = idPadre
                _idArticulo = idArticulo
                _referencia = Trim(referencia)
                _descripcion = Trim(descripcion)
                _idPlantilla = idplantilla
                _idArticuloTemporal = idArticuloTemporal
                _cantidad = cantidad
                _piezasxUnidad = piezasxUnidad
                _ancho = ancho
                _alto = alto
                _idAcabadoPerfil = idAcabado
                _acabadoPerfil = Trim(acabado)
                _idVidrio = idVidrio
                _vidrio = Trim(vidrio)
                _idColorVidrio = idColorVidrio
                _colorVidrio = Trim(colorVidrio)
                _idEspesor = idEspesor
                _espesor = Trim(espesor)
                _unidadMedia = Trim(unidadMedida)
                _descuento = descuento
                _valorDescuento = valorDcto
                _factor = factor
                _tipoItem = tipoItem
                _precioUnitario = precioUnitario
                _precioTotal = precioTotal
                _costoVidrio = costoVidrio
                _costoPerfiles = costoPerfiles
                _costoAccesorios = costoAccesorios
                _costoOtros = costoOtros
                _costoUnitario = costoUnitario
                _costoTotal = costoTotal
                _tarifaMtInstalacion = tarifaInstalacion
                _precioInstalacion = precioMt2Instalacion
                _calculo_NSR = calculoNSR
                _cumpleNorma = cumpleNorma
                _numero_cuerpos_norma = numero_cuerpos
                _fechamodificacion = fechaModi
                _usuariomodificacion = usuarioModi
                _idestado = idEstado
                _colorTemporal = colorTemporal
                _espesorTemporal = espesorTemporal
                _acabadoTemporal = acabadoTemporal
                _vlrDespVidrio = vlrDespVidrio
                _vlrDespPerfiles = vlrDespPerfiles
                _vlrDespAccesorios = vlrDespAccesorios
                _vlrDespOtros = vlrDespOtros
                _costoinstalacionuni = costoinstalacion_uni
                _verCostoKiloAluminio = vercostokiloaluminio
                _verCostoAcabado = vercostoacabado
                _verCostoNiveles = vercostoniveles
                _verCostoVidrio = vercostovidrio
                _verCostoAccesorios = vercostoaccesorios
                _verCostoOtrosArticulos = vercostootros
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class

    Public Class movitoHijoOrdenPed
        Inherits movitoHijo
#Region "Variables"
        Private cant_disponible As Decimal = 0
#End Region

#Region "Propiedades"

        Public Property Cantidad_Disponible As Decimal
            Get
                Return cant_disponible
            End Get
            Set(value As Decimal)
                cant_disponible = value
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

        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idPadre As Integer, idArticulo As Integer,
                       referencia As String, descripcion As String, idplantilla As Integer, idArticuloTemporal As Integer, cantidad As Integer,
                       cantidad_disponible As Decimal, piezasxUnidad As Decimal, ancho As Decimal, alto As Decimal, idAcabado As Integer,
                       acabado As String, idVidrio As Integer, vidrio As String, idColorVidrio As Integer, colorVidrio As String,
                       idEspesor As Integer, espesor As String, unidadMedida As String, descuento As Decimal, factor As Decimal, tipoItem As Integer,
                       tarifaInstalacion As Decimal, calculoNSR As Boolean, cumpleNorma As Boolean, fechaModi As DateTime, usuarioModi As String,
                       idEstado As Integer, valorDcto As Decimal, precioUnitario As Decimal, precioTotal As Decimal, costoVidrio As Decimal,
                       costoPerfiles As Decimal, costoAccesorios As Decimal, costoOtros As Decimal, costoUnitario As Decimal, costoTotal As Decimal,
                       precioMt2Instalacion As Decimal, colorTemporal As Boolean, espesorTemporal As Boolean, acabadoTemporal As Boolean,
                       vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal, vlrDespAccesorios As Decimal, vlrDespOtros As Decimal)
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = usuarioCreacion
                Me.idPadre = idPadre
                Me.idArticulo = idArticulo
                Me.referencia = Trim(referencia)
                Me.descripcion = Trim(descripcion)
                Me.idPlantilla = idplantilla
                Me.IdArticuloTemporal = idArticuloTemporal
                Me.cantidad = cantidad
                cant_disponible = cantidad_disponible
                Me.piezasxUnidad = piezasxUnidad
                Me.ancho = ancho
                Me.alto = alto
                Me.idAcabadoPerfil = idAcabado
                Me.acabadoPerfil = Trim(acabado)
                Me.idVidrio = idVidrio
                Me.vidrio = Trim(vidrio)
                Me.idColorVidrio = idColorVidrio
                Me.colorVidrio = Trim(colorVidrio)
                Me.idEspesor = idEspesor
                Me.espesor = Trim(espesor)
                Me.unidadMedida = Trim(unidadMedida)
                Me.descuento = descuento
                Me.valorDescuento = valorDcto
                Me.factor = factor
                Me.tipoItem = tipoItem
                Me.precioUnitario = precioUnitario
                Me.precioTotal = precioTotal
                Me.costoVidrio = costoVidrio
                Me.costoPerfiles = costoPerfiles
                Me.costoAccesorios = costoAccesorios
                Me.costoOtros = costoOtros
                Me.costoUnitario = costoUnitario
                Me.costoTotal = costoTotal
                Me.tarifaMtInstalacion = tarifaInstalacion
                Me.precioInstalacion = precioMt2Instalacion
                Me.calculo_NSR = calculoNSR
                Me.cumpleNorma = cumpleNorma
                Me.FechaModificacion = fechaModi
                Me.UsuarioModificacion = usuarioModi
                Me.IdEstado = idEstado
                Me.ColorTemporal = colorTemporal
                Me.EspesorTemporal = espesorTemporal
                Me.AcabadoTemporal = acabadoTemporal
                Me.vlrDespVidrio = vlrDespVidrio
                Me.vlrDespPerfiles = vlrDespPerfiles
                Me.vlrDespAccesorios = vlrDespAccesorios
                Me.vlrDespOtros = vlrDespOtros
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace


