Imports System.Drawing
Imports System.IO
Imports Datos
Namespace movitoPadres
    Public Class ClsMovitoPadres
#Region "Variables"
        Private taMovitoPadres As New dsAlcoCotizacionesTableAdapters.tc017_MovitoPadreCotizaTableAdapter
#End Region
#Region "Procedimientos"
        Public Function Ingresar(usuarioCreacion As String, idCotizacion As Integer, ubicacion As String, descripcion As String, ancho As Decimal,
                                 alto As Decimal, cantidad As Integer, idAcabado As Integer, idVidrio As Integer, idColorVidrio As Integer,
                                 idEspesor As Integer, factor As Decimal, descuento As Decimal, verCostoVidrio As Integer, verCostoAccesorios As Integer,
                                 verCostoNiveles As Integer, verCostoAcabado As Integer, verCostokiloAluminio As Integer, verCostoOtros As Integer,
                                 calculoNSR As Boolean, cumpleNorma As Boolean, numero_cuerpos_norma As Integer, idPropiedadMasica As Integer, idEstado As Integer,
                                 tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, tasaImpuesto As Decimal,
                                 costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal, costoOtros As Decimal, costoUnitario As Decimal,
                                 costoTotal As Decimal, precioUnitario As Decimal, precioTotal As Decimal, valorDescuento As Decimal, vlrDespVidrio As Decimal,
                                 vlrDespPerfiles As Decimal, vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, imagen As Byte(),
                                 unidadmedidainstala As String, descuentoinstala As Decimal) As Integer
            Try
                Return Convert.ToInt32(taMovitoPadres.sp_tc017_insert(usuarioCreacion, idCotizacion, ubicacion, descripcion, ancho, alto, cantidad, idAcabado,
                                                                      idVidrio, idColorVidrio, idEspesor, factor, descuento, verCostoVidrio, verCostoAccesorios,
                                                                      verCostoNiveles, verCostoAcabado, verCostokiloAluminio, verCostoOtros, calculoNSR, cumpleNorma, numero_cuerpos_norma,
                                                                      idPropiedadMasica, idEstado, tarifaMtInstalacion, precioInstalacion, tasaImpuesto,
                                                                      costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costoUnitario,
                                                                       costoTotal, precioUnitario, precioTotal, valorDescuento, vlrDespVidrio, vlrDespPerfiles,
                                                                      vlrDespAccesorios, vlrDespOtros, imagen, unidadmedidainstala, descuentoinstala))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Sub Modificar(id As Integer, ubicacion As String, descripcion As String, ancho As Decimal, alto As Decimal, cantidad As Integer,
                            idAcabado As Integer, idVidrio As Integer, idColorVidrio As Integer, idEspesor As Integer, factor As Decimal,
                            descuento As Decimal, versCostoVidrio As Integer, versCostoAccesorios As Integer, versCostoNiveles As Integer,
                            versCostoAcabado As Integer, versCostoKiloAluminio As Integer, versCostoOtros As Integer, calculoNSR As Boolean,
                            cumpleNorma As Boolean, numero_cuerpos_norma As Integer, idPropiedadMasica As Integer, usuario As String, idEstado As Integer, tarifaMtInstalacion As Decimal,
                            precioInsalacion As Decimal, tasaImpuesto As Decimal, costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal,
                            costoOtros As Decimal, costoUnitario As Decimal,
                            costoTotal As Decimal, precioUnitario As Decimal, precioTotal As Decimal, valorDescuento As Decimal, vlrDespVidrio As Decimal,
                            vlrDespPerfiles As Decimal, vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, imagen As Byte(),
                            unidadmedidainstala As String, descuentoinstala As Decimal)
            Try
                taMovitoPadres.sp_tc017_update(id, ubicacion, descripcion, ancho, alto, cantidad, idAcabado, idVidrio, idColorVidrio, idEspesor, factor,
                                               descuento, versCostoVidrio, versCostoAccesorios, versCostoNiveles, versCostoAcabado, versCostoKiloAluminio,
                                               versCostoOtros, calculoNSR, cumpleNorma, numero_cuerpos_norma, idPropiedadMasica, usuario, idEstado, tarifaMtInstalacion, precioInsalacion,
                                               tasaImpuesto, costoVidrio, costoPerfiles, costoAccesorios, costoOtros, costoUnitario,
                                                                       costoTotal, precioUnitario, precioTotal, valorDescuento, vlrDespVidrio, vlrDespPerfiles,
                                                                      vlrDespAccesorios, vlrDespOtros, imagen, unidadmedidainstala, descuentoinstala)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub


        Public Function Duplicar(idcotiza As Integer, id As Integer, idacabado As Integer, usuario As String) As Integer
            Try
                Return Convert.ToInt32(taMovitoPadres.sp_tc017_duplicar(idcotiza, id, idacabado, usuario))
            Catch ex As ArgumentException
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Sub CambioEstado(id As Integer, idEstado As Integer)
            Try
                taMovitoPadres.sp_tc017_updateEstado(id, idEstado)
            Catch ex As ArgumentException
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Function TraerxId(id As Integer) As movitoPadre
            Try
                Dim util As New ClsUtilidadesImagenes
                Dim bmp As New Bitmap(400, 400)
                Dim miImagenBytes() As Byte = New Byte() {}
                If File.Exists("\\servidor\codigos\índice.jpg") Then
                    miImagenBytes = Imagen_Bytes(Image.FromFile("\\servidor\codigos\índice.jpg"))
                End If
                TraerxId = New movitoPadre
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc017_selectbyIdTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc017_selectbyIdDataTable = taAll.GetData(id)
                If txAll.Rows.Count > 0 Then
                    Dim ti As dsAlcoCotizaciones.sp_tc017_selectbyIdRow = DirectCast(txAll.Rows(0), dsAlcoCotizaciones.sp_tc017_selectbyIdRow)
                    TraerxId = New movitoPadre(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idCotizacion, ti.ubicacion,
                                                           ti.descripcion, ti.ancho, ti.alto, ti.cantidad, ti.idAcabado, ti.acabado, ti.idVidrio,
                                                           ti.vidrio, ti.idColorVidrio, ti.colorVidrio, ti.idEspesor, ti.espesor, ti.factor, ti.descuento,
                                                           ti.verCostoVidrio, ti.verCostoAccesorios, ti.verCostoNiveles, ti.verCostoAcabado,
                                                           ti.verCostokiloAluminio, ti.verCostoOtros, ti.calculo_NSR, ti.cumpleNorma, ti.numero_cuerpos, ti.idPropiedadMasica, ti.propiedadMasica,
                                                           ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.mtCuadrados, ti.precioMtInstalacion, ti.precioInstalacion, ti.unidainstala, ti.descuentoInstala,
                                                           ti.tasaImpuesto, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                           ti.precioUnitario, ti.precioTotal, ti.valorDescuento, ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                           ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros, miImagenBytes)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="idCotiza"></param>
        ''' <returns></returns>
        Public Function TraerxIdCotiza(idCotiza As Integer) As List(Of movitoPadre)
            Try
                Dim util As New ClsUtilidadesImagenes
                Dim bmp As New Bitmap(400, 400)
                Dim miImagenBytes() As Byte = New Byte() {}
                If File.Exists("\\servidor\codigos\índice.jpg") Then
                    miImagenBytes = Imagen_Bytes(Image.FromFile("\\servidor\codigos\índice.jpg"))
                End If

                TraerxIdCotiza = New List(Of movitoPadre)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc017_selectByIdCotizaTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc017_selectByIdCotizaDataTable = taAll.GetData(idCotiza)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc017_selectByIdCotizaRow In txAll.Rows
                        TraerxIdCotiza.Add(New movitoPadre(ti.id, ti.fechaCreacion, ti.usuarioCreacion, ti.idCotizacion, ti.ubicacion,
                                                           ti.descripcion, ti.ancho, ti.alto, ti.cantidad, ti.idAcabado, ti.acabado, ti.idVidrio,
                                                           ti.vidrio, ti.idColorVidrio, ti.colorVidrio, ti.idEspesor, ti.espesor, ti.factor, ti.descuento,
                                                           ti.verCostoVidrio, ti.verCostoAccesorios, ti.verCostoNiveles, ti.verCostoAcabado,
                                                           ti.verCostokiloAluminio, ti.verCostoOtros, ti.calculo_NSR, ti.cumpleNorma, ti.numero_cuerpos, ti.idPropiedadMasica, ti.propiedadMasica,
                                                           ti.fechaModi, ti.usuarioModi, ti.idEstado, ti.mtCuadrados, ti.precioMtInstalacion, ti.precioInstalacion, ti.unidainstala, ti.descuentoInstala,
                                                           ti.tasaImpuesto, ti.costoVidrio, ti.costoPerfiles, ti.costoAccesorios, ti.costoOtros, ti.costoUnitario, ti.costoTotal,
                                                           ti.precioUnitario, ti.precioTotal, ti.valorDescuento, ti.Vlr_Desp_Vidrio, ti.Vlr_Desp_Perfiles,
                                                           ti.Vlr_Desp_Accesorios, ti.Vlr_Desp_Otros, Nothing)) 'miImagenBytes))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
            'si hay imagen
            If Not Imagen Is Nothing Then
                'variable de datos binarios en stream(flujo)
                Dim Bin As New MemoryStream
                'convertir a bytes
                Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
                Bin.Dispose()
                'retorna binario
                Return Bin.GetBuffer
            Else
                Return Nothing
            End If
        End Function
        Public Function TraerxIdCotiza_TablaDatos(idCotiza As Integer) As DataTable
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc017_selectByIdCotizaTableAdapter
                Return taAll.GetData(idCotiza).Copy()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function traerByGroupCotiza(cadena As String, Optional ByRef tb As DataTable = Nothing) As List(Of movitoPadre)
            Try
                traerByGroupCotiza = New List(Of movitoPadre)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc017_selectByGroupOfCotizaTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc017_selectByGroupOfCotizaDataTable = taAll.GetData(cadena)
                If txAll.Rows.Count > 0 Then
                    'For Each ti As dsAlcoCotizaciones.sp_tc017_selectByGroupOfCotizaRow In txAll.Rows
                    '    traerByGroupCotiza.Add(New movitoPadre(CInt(ti.Item("id")), CDate(ti.Item("fechaCreacion")), ti.Item("usuarioCreacion").ToString, CInt(ti.Item("idCotizacion")),
                    '                                           ti.Item("ubicacion").ToString, ti.Item("descripcion").ToString, CDec(ti.Item("ancho")), CDec(ti.Item("alto")), CInt(ti.Item("cantidad")),
                    '                                           CInt(ti.Item("idAcabado")), ti.Item("acabado").ToString, CInt(ti.Item("idVidrio")), ti.Item("vidrio").ToString, CInt(ti.Item("idColorVidrio")), ti.Item("colorVidrio").ToString,
                    '                                           CInt(ti.Item("idEspesor")), ti.Item("espesor").ToString, CDec(ti.Item("factor")), CDec(ti.Item("descuento")),
                    '                                           CInt(ti.Item("verCostoVidrio")), CInt(ti.Item("verCostoAccesorios")), CInt(ti.Item("verCostoNiveles")), CInt(ti.Item("verCostoAcabado")),
                    '                                           CInt(ti.Item("verCostokiloAluminio")), CInt(ti.Item("verCostoOtros")), CBool(ti.Item("calculo_NSR")), CBool(ti.Item("cumpleNorma")),
                    '                                           CInt(ti.Item("idPropiedadMasica")), ti.Item("propiedadMasica").ToString, CDate(ti.Item("fechaModi")), ti.Item("usuarioModi").ToString, CInt(ti.Item("idEstado")),
                    '                                           CDec(ti.Item("mtCuadrados")), CDec(ti.Item("precioMtInstalacion")), CDec(ti.Item("precioInstalacion")), CInt(ti.Item("idTasaImpuesto")), CDec(ti.Item("tasaImpuesto")),
                    '                                           CDec(ti.Item("costoVidrio")), CDec(ti.Item("costoPerfiles")), CDec(ti.Item("costoAccesorios")), CDec(ti.Item("costoOtros")), CDec(ti.Item("CostoUnitario")), CDec(ti.Item("costoTotal")),
                    '                                           CDec(ti.Item("precioUnitario")), CDec(ti.Item("precioTotal")), CDec(ti.Item("valorDescuento"))))
                    'Next
                    tb = txAll.CopyToDataTable
                End If

            Catch ex As Exception
                Throw New Exception("Error al cargar los padres de la cotización", ex.InnerException)
            End Try
        End Function
#End Region
#Region "Funciones"

#End Region
    End Class
    Public Class movitoPadre
        Inherits ClsBaseParametros
#Region "Variables"
        Protected _idCotiza As Integer
        Protected _ubicacion As String
        Protected _descripcion As String
        Protected _ancho As Decimal
        Protected _alto As Decimal
        Protected _cantidad As Decimal
        Protected _idAcabadoPerfil As Integer
        Protected _acabadoPerfil As String
        Protected _idVidrio As Integer
        Protected _vidrio As String
        Protected _colorVidrio As String
        Protected _idColorVidrio As Integer
        Protected _idEspesor As Integer
        Protected _espesor As String
        Protected _factor As Decimal
        Protected _versionCostoVidrio As Integer
        Protected _versionCostoAccesorios As Integer
        Protected _versionCostoNiveles As Integer
        Protected _versionCostoAcabado As Integer
        Protected _versionCostoKiloAluminio As Integer
        Protected _versionCostoOtrosArticulos As Integer
        Protected _calculoNSR As Boolean
        Protected _cumpleNorma As Boolean
        Protected _numero_cuerpos_norma As Integer = 1
        Protected _idPropiedadMasica As Integer
        Protected _propiedadMasica As String
        Protected _descuento As Decimal
        Protected _mtCuadrados As Decimal
        Protected _tarifaMtInstalacion As Decimal
        Protected _precioInstalacion As Decimal
        Protected _unidadinstalacion As String
        Protected _descuentoinstalacion As Decimal
        Protected _tasaImpuesto As Decimal
        Protected _costoVidrio As Decimal
        Protected _costoPerfiles As Decimal
        Protected _precioUnitario As Decimal
        Protected _precioTotal As Decimal
        Protected _valorDescuento As Decimal
        Protected _vlrDespVidrio As Decimal
        Protected _vlrDespPerfiles As Decimal
        Protected _vlrDespOtros As Decimal
        Protected _imagen As Byte()
        Protected _vlrDespAccesorios As Decimal
        Protected _costoTotal As Decimal
        Protected _costoUnitario As Decimal
        Protected _costoOtros As Decimal
        Protected _costoAccesrios As Decimal
#End Region

#Region "Propiedades"
        Public Property IdCotiza As Integer
            Get
                Return _idCotiza
            End Get
            Set(ByVal value As Integer)
                _idCotiza = value
            End Set
        End Property
        Public Property Ubicacion As String
            Get
                Return _ubicacion
            End Get
            Set(ByVal value As String)
                _ubicacion = value
            End Set
        End Property
        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property Ancho As Decimal
            Get
                Return _ancho
            End Get
            Set(ByVal value As Decimal)
                _ancho = value
            End Set
        End Property
        Public Property Alto As Decimal
            Get
                Return _alto
            End Get
            Set(ByVal value As Decimal)
                _alto = value
            End Set
        End Property
        Public Property Cantidad As Decimal
            Get
                Return _cantidad
            End Get
            Set(ByVal value As Decimal)
                _cantidad = value
            End Set
        End Property
        Public Property IdAcabadoPerfil As Integer
            Get
                Return _idAcabadoPerfil
            End Get
            Set(ByVal value As Integer)
                _idAcabadoPerfil = value
            End Set
        End Property
        Public Property AcabadoPerfil As String
            Get
                Return _acabadoPerfil
            End Get
            Set(ByVal value As String)
                _acabadoPerfil = value
            End Set
        End Property
        Public Property IdVidrio As Integer
            Get
                Return _idVidrio
            End Get
            Set(ByVal value As Integer)
                _idVidrio = value
            End Set
        End Property
        Public Property Vidrio As String
            Get
                Return _vidrio
            End Get
            Set(ByVal value As String)
                _vidrio = value
            End Set
        End Property
        Public Property IdColorVidrio As Integer
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
        Public Property factor() As Decimal
            Get
                Return _factor
            End Get
            Set(ByVal value As Decimal)
                _factor = value
            End Set
        End Property
        Public Property Descuento() As Decimal
            Get
                Return _descuento
            End Get
            Set(ByVal value As Decimal)
                _descuento = value
            End Set
        End Property
        Public Property versionCostoVidrio() As Integer
            Get
                Return _versionCostoVidrio
            End Get
            Set(ByVal value As Integer)
                _versionCostoVidrio = value
            End Set
        End Property
        Public Property versionCostoAccesorios() As Integer
            Get
                Return _versionCostoAccesorios
            End Get
            Set(ByVal value As Integer)
                _versionCostoAccesorios = value
            End Set
        End Property
        Public Property versionCostoNiveles() As Integer
            Get
                Return _versionCostoNiveles
            End Get
            Set(ByVal value As Integer)
                _versionCostoNiveles = value
            End Set
        End Property
        Public Property versionCostoAcabado() As Integer
            Get
                Return _versionCostoAcabado
            End Get
            Set(ByVal value As Integer)
                _versionCostoAcabado = value
            End Set
        End Property
        Public Property versionCostoKiloAluminio() As Integer
            Get
                Return _versionCostoKiloAluminio
            End Get
            Set(ByVal value As Integer)
                _versionCostoKiloAluminio = value
            End Set
        End Property
        Public Property versionCostoOtrosArticulos() As Integer
            Get
                Return _versionCostoOtrosArticulos
            End Get
            Set(ByVal value As Integer)
                _versionCostoOtrosArticulos = value
            End Set
        End Property
        Public Property calculo_NSR() As Boolean
            Get
                Return _calculoNSR
            End Get
            Set(ByVal value As Boolean)
                _calculoNSR = value
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
        Public Property idPropiedadMasica() As Integer
            Get
                Return _idPropiedadMasica
            End Get
            Set(ByVal value As Integer)
                _idPropiedadMasica = value
            End Set
        End Property
        Public Property propiedadMasica() As String
            Get
                Return _propiedadMasica
            End Get
            Set(ByVal value As String)
                _propiedadMasica = value
            End Set
        End Property
        Public Property mtCuadrados() As Decimal
            Get
                Return _mtCuadrados
            End Get
            Set(ByVal value As Decimal)
                _mtCuadrados = value
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
        Public Property UnidadMedidaInstalacion As String
            Get
                Return _unidadinstalacion
            End Get
            Set(value As String)
                _unidadinstalacion = value
            End Set
        End Property
        Public Property Descuento_Instalacion As Decimal
            Get
                Return _descuentoinstalacion
            End Get
            Set(ByVal value As Decimal)
                _descuentoinstalacion = value
            End Set
        End Property
        Public Property tasaImpuesto() As Decimal
            Get
                Return _tasaImpuesto
            End Get
            Set(ByVal value As Decimal)
                _tasaImpuesto = value
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
        Public Property costoAccesorio() As Decimal
            Get
                Return _costoAccesrios
            End Get
            Set(ByVal value As Decimal)
                _costoAccesrios = value
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
        Public Property costoTotoal() As Decimal
            Get
                Return _costoTotal
            End Get
            Set(ByVal value As Decimal)
                _costoTotal = value
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
        Public Property valorDescuento() As Decimal
            Get
                Return _valorDescuento
            End Get
            Set(ByVal value As Decimal)
                _valorDescuento = value
            End Set
        End Property
        Public Property vlrDespVidrio() As Decimal
            Get
                Return _vlrDespVidrio
            End Get
            Set(ByVal value As Decimal)
                _vlrDespVidrio = value
            End Set
        End Property
        Public Property vlrDespPerfiles() As Decimal
            Get
                Return _vlrDespPerfiles
            End Get
            Set(ByVal value As Decimal)
                _vlrDespPerfiles = value
            End Set
        End Property
        Public Property vlrDespAccesorios() As Decimal
            Get
                Return _vlrDespAccesorios
            End Get
            Set(ByVal value As Decimal)
                _vlrDespAccesorios = value
            End Set
        End Property
        Public Property vlrDespOtros() As Decimal
            Get
                Return _vlrDespOtros
            End Get
            Set(ByVal value As Decimal)
                _vlrDespOtros = value
            End Set
        End Property
        Public Property imagen() As Byte()
            Get
                Return _imagen
            End Get
            Set(ByVal value As Byte())
                _imagen = value
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
        Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idCotizacion As Integer, ubicacion As String,
                       descripcion As String, ancho As Decimal, alto As Decimal, cantidad As Integer, idAcabado As Integer, acabado As String,
                       idVidrio As Integer, vidrio As String, idColorVidrio As Integer, colorVidrio As String, idEspesor As Integer,
                       Espesor As String, factor As Decimal, descuento As Decimal, verCostoVidrio As Integer, verCostoAccesorios As Integer, verCostoNiveles As Integer,
                       verCostoAcabado As Integer, verCostokiloAluminio As Integer, verCostoOtros As Integer, calculo_NSR As Boolean, cumpleNorma As Boolean, numero_cuerpos As Integer,
                       idPropiedadMasica As Integer, propiedadMasica As String, fechaModi As DateTime, usuarioModi As String, IdEstado As Integer, mtCuadrados As Decimal,
                       tarifaMtInstalacion As Decimal, precioInstalacion As Decimal, unidadinstalacion As String, descuentoinstalacion As Decimal, tasaImpuesto As Decimal,
                       costoVidrio As Decimal, costoPerfiles As Decimal, costoAccesorios As Decimal, costoOtros As Decimal, costoUnitario As Decimal,
                       costoTotal As Decimal, precioUnitario As Decimal, precioTotal As Decimal, valorDescuento As Decimal,
                       vlrDespVidrio As Decimal, vlrDespPerfiles As Decimal, vlrDespAccesorios As Decimal, vlrDespOtros As Decimal, imagen As Byte())
            Try
                Me.Id = id
                Me.FechaCreacion = fechaCreacion
                Me.UsuarioCreacion = usuarioCreacion
                _idCotiza = idCotizacion
                _ubicacion = ubicacion
                _descripcion = descripcion
                _ancho = ancho
                _alto = alto
                _cantidad = cantidad
                _idAcabadoPerfil = idAcabado
                _acabadoPerfil = acabado
                _idVidrio = idVidrio
                _vidrio = vidrio
                _idColorVidrio = idColorVidrio
                _colorVidrio = colorVidrio
                _idEspesor = idEspesor
                _espesor = Espesor
                _factor = factor
                _descuento = descuento
                _versionCostoVidrio = verCostoVidrio
                _versionCostoAccesorios = verCostoAccesorios
                _versionCostoNiveles = verCostoNiveles
                _versionCostoAcabado = verCostoAcabado
                _versionCostoKiloAluminio = verCostokiloAluminio
                _versionCostoOtrosArticulos = verCostoOtros
                _calculoNSR = calculo_NSR
                _cumpleNorma = cumpleNorma
                _numero_cuerpos_norma = numero_cuerpos
                _idPropiedadMasica = idPropiedadMasica
                _propiedadMasica = propiedadMasica
                Me.FechaModificacion = fechaModi
                Me.UsuarioModificacion = usuarioModi
                Me.IdEstado = IdEstado
                _mtCuadrados = mtCuadrados
                _tarifaMtInstalacion = tarifaMtInstalacion
                _precioInstalacion = precioInstalacion
                _unidadinstalacion = unidadinstalacion
                _descuentoinstalacion = descuentoinstalacion
                _tasaImpuesto = tasaImpuesto
                _costoVidrio = costoVidrio
                _costoPerfiles = costoPerfiles
                _costoAccesrios = costoAccesorio
                _costoOtros = costoOtros
                _costoUnitario = costoUnitario
                _costoTotal = costoUnitario
                _precioUnitario = precioUnitario
                _precioTotal = precioTotal
                _valorDescuento = valorDescuento
                _vlrDespVidrio = vlrDespVidrio
                _vlrDespPerfiles = vlrDespPerfiles
                _vlrDespAccesorios = vlrDespAccesorios
                _vlrDespOtros = vlrDespOtros
                _imagen = imagen
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

