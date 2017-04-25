Imports System.Threading.Tasks
Imports Datos
Imports System.Linq
Namespace cotizaciones
    Public Class ClsCostizaciones
#Region "Variables"
        Private taCotizaciones As New dsAlcoCotizacionesTableAdapters.tc016_CotizacionesTableAdapter
#End Region
#Region "Procedimientos"

        Public Function Ingresar(usuarioCreacion As String, nombreCotiza As String, fechaCotizacion As DateTime, idTipoCotizacion As Integer,
                                 idVendedorSiesa As Integer, idAcabadoGlobal As Integer, idCiudad As Integer, idFactorGlobal As Integer, descuentoGlobal As Decimal,
                                 idFormaPago As Integer, idTiempoEntrega As Integer, conInstalacion As Integer, idManoObraInstalacion As Integer,
                                 idTasaImpuesto As Integer, idVigencia As Integer, AIU_porcAdministracion As Decimal, AIU_porcImprovistos As Decimal, AIU_porcUtilidad As Decimal,
                                 idTipoIdentificacion As Integer, numIdentificacion As String, digitoVerificacion As String, cliente As String,
                                 telCliente As String, dirCliente As String, mailCliente As String, nombreContactoCliente As String, nombreObra As String,
                                 nombreContactoObra As String, telObra As String, mailObra As String, idTipoEdificacion As Integer, idCategoriaExposicion As Integer,
                                 idComponente As Integer, idGrupoDeUso As Integer, idTipoCubierta As Integer, idpresion As Integer, altoEdificio As Decimal, anchoEdificio As Decimal,
                                 alturaCaballete As Decimal, alturaAlero As Decimal, alturaEntreLosas As Decimal, versionCostoVidrio As Integer,
                                 versionCostoAcabado As Integer, versionCostoNivel As Integer, versionCostoKiloAluminio As Integer, versionCostoAccesorios As Integer,
                                 versionCostoOtrosArticulos As Integer, numImpresiones As Integer, idHistoriaUsuarioModi As Integer, idEstado As Integer,
                                 descuentoInstalacion As Decimal, cobraMtReales As Boolean, ind_AIU As Boolean) As Integer
            Try
                Ingresar = Convert.ToInt32(taCotizaciones.sp_tc016_insert(usuarioCreacion, nombreCotiza, fechaCotizacion, idTipoCotizacion, idVendedorSiesa, idAcabadoGlobal,
                                                                      idCiudad, idFactorGlobal, descuentoGlobal, idFormaPago, idTiempoEntrega, conInstalacion, idManoObraInstalacion,
                                                                      idTasaImpuesto, idVigencia, AIU_porcAdministracion, AIU_porcImprovistos, AIU_porcUtilidad, idTipoIdentificacion,
                                                                      numIdentificacion, digitoVerificacion, cliente, telCliente, dirCliente, mailCliente, nombreContactoCliente, nombreObra,
                                                                      nombreContactoObra, telObra, mailObra, idTipoEdificacion, idCategoriaExposicion, idComponente,
                                                                      idGrupoDeUso, idTipoCubierta, idpresion, altoEdificio, anchoEdificio, alturaCaballete, alturaAlero, alturaEntreLosas,
                                                                      versionCostoVidrio, versionCostoAcabado, versionCostoNivel, versionCostoKiloAluminio, versionCostoAccesorios,
                                                                      versionCostoOtrosArticulos, numImpresiones, idHistoriaUsuarioModi, idEstado, descuentoInstalacion, cobraMtReales, ind_AIU))
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Sub Modificar(idCotiza As Integer, usuario As String, nombreCotiza As String, fechaCotiza As DateTime, tipoCotiza As Integer,
                             idVendedor As Integer, idAcabado As Integer, idCiudad As Integer, idFactor As Integer, descuentoGlobal As Decimal, idFormaPago As Integer,
                             idTiempoEntrega As Integer, conInstalacion As Integer, idManoObra As Integer, idTasaImpuesto As Integer, idVigencia As Integer,
                             AIUAdministracion As Decimal, AIUImprovistos As Decimal, AIUUtilidad As Decimal, idTipoIdentificacion As Integer,
                             numIdentificacion As String, digitoVerificacion As String, cliente As String, telefonoCliente As String,
                             direccionCliente As String, mailCliente As String, contactoCliente As String, nombreObra As String,
                             contactoObra As String, telefonoObra As String, mailObra As String, idTipoEdificacion As Integer,
                             idCategExposicion As Integer, idComponente As Integer, idGrupoUso As Integer, idTipoCubierta As Integer,
                             idpresion As Integer, altoEdificio As Decimal, anchoEdificio As Decimal, alturaCaballete As Decimal, alturaAlero As Decimal,
                             alturaEntreLosas As Decimal, versCostoVidrio As Integer, versCostoAcabado As Integer, versCostoNivel As Integer,
                             versCostoKiloAluminio As Integer, versCostoAccesorios As Integer, versCostoOtros As Integer, numImpresiones As Integer,
                             idEstado As Integer, descuentoInstalacion As Decimal, cobraMtReales As Boolean, ind_AIU As Boolean)
            Try
                taCotizaciones.sp_tc016_update(idCotiza, usuario, nombreCotiza, fechaCotiza, tipoCotiza, idVendedor, idAcabado, idCiudad, idFactor, descuentoGlobal,
                                               idFormaPago, idTiempoEntrega, conInstalacion, idManoObra, idTasaImpuesto, idVigencia, AIUAdministracion, AIUImprovistos,
                                               AIUUtilidad, idTipoIdentificacion, numIdentificacion, digitoVerificacion, cliente, telefonoCliente,
                                               direccionCliente, mailCliente, contactoCliente, nombreObra, contactoObra, telefonoObra, mailObra,
                                               idTipoEdificacion, idCategExposicion, idComponente, idGrupoUso, idTipoCubierta, idpresion, altoEdificio, anchoEdificio,
                                               alturaCaballete, alturaAlero, alturaEntreLosas, versCostoVidrio, versCostoAcabado, versCostoNivel,
                                               versCostoKiloAluminio, versCostoAccesorios, versCostoOtros, numImpresiones, idEstado, descuentoInstalacion, cobraMtReales, ind_AIU)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        ''' <summary>
        ''' Modifica el estado de la cotización
        ''' </summary>
        ''' <param name="idEstado">Id del estado que le asignará a la cotización</param>
        ''' <param name="cadena">Lista concatenada con ',' de los Id de las cotizaciones a actualizar</param>
        Public Sub ModificarEstado(idEstado As Integer, cadena As String)
            Try
                taCotizaciones.sp_tc016_updateEstado(cadena, idEstado)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub ReiniciarEstadosxId(id As Integer)
            Try
                taCotizaciones.sp_tc016_estadosoriginales(id)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub ActualizarAprobacionCliente(idcotizacion As Integer, aprobacion_cliente As Integer)
            Try
                taCotizaciones.sp_tc016_updateAprobacionCliente(idcotizacion, aprobacion_cliente)
                If aprobacion_cliente = ClsEnums.Estados.APROBADO Then
                    taCotizaciones.sp_tc016_updateEstado(idcotizacion.ToString(), ClsEnums.Estados.PENDIENTE_CONTRATAR)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub ModificarInfoBasica(nit As String, cliente As String, tel_cliente As String,
                                       dir_cliente As String, mail_cliente As String,
                                       contacto_cliente As String, obra As String, contacto_obra As String,
                                       tel_obra As String, mail_obra As String, cadena As String)
            Try
                taCotizaciones.sp_tc016_updateInfoBasica(nit, cliente, tel_cliente, dir_cliente,
                                                         mail_cliente, contacto_cliente, obra, contacto_obra,
                                                         tel_obra, mail_obra, cadena)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        '''' <summary>
        '''' Duplica la cotización correspondiente al id indicado
        '''' </summary>
        '''' <param name="idCotizacion"></param>
        Public Function Duplicar(idCotizacion As Integer, usuario As String, accion As String, idacabado As Integer) As Integer
            Try
                'Dim tiempo = Stopwatch.StartNew()
                Dim tacot As New dsAlcoCotizacionesTableAdapters.sp_tc016_duplicarTableAdapter
                Dim t As dsAlcoCotizaciones.sp_tc016_duplicarDataTable = tacot.GetData(idCotizacion, usuario, accion, idacabado)

                Dim id_nueva_cotiza As Integer = 0
                'Console.WriteLine("Duplicación Cotiza :=>" & tiempo.Elapsed.ToString())

                If t.Rows.Count > 0 Then
                    id_nueva_cotiza = DirectCast(t.Rows(0), dsAlcoCotizaciones.sp_tc016_duplicarRow).id_cotiza
                    Dim mvdibujo As New ClsDibujosItemsCotiza
                    'tiempo.Restart()
#Region "Dibujos Padre"
                    Dim ids_reemplazos_contenedores As New Dictionary(Of Integer, Integer)
                    Dim l_dibujos As List(Of DibujoPadreCotiza) = mvdibujo.TraerxIdCotiza(idCotizacion)
                    l_dibujos.ForEach(Sub(d)
                                          Dim n_id_padre As Integer = t.FirstOrDefault(Function(p) p.id_padre_viejo = d.IdPadre).id_padre_nuevo
                                          Dim id_n_hijo As Integer = If(d.IdHijo > 0, t.FirstOrDefault(Function(h) h.id_hijo_viejo = d.IdHijo).id_hijo_nuevo, 0)
                                          Dim id_n_contenedor As Integer = 0
                                          If d.IdContendor > 0 Then
                                              ids_reemplazos_contenedores.TryGetValue(d.IdContendor, id_n_contenedor)
                                          End If
                                          ids_reemplazos_contenedores.Add(d.Id, mvdibujo.Duplicar(d.Id, n_id_padre, id_n_hijo,
                                                                                                  id_n_contenedor, usuario))
                                      End Sub)
#End Region
                    'Console.WriteLine("Duplicación Dibujos Padres :=>" & tiempo.Elapsed.ToString())
                End If
                Return id_nueva_cotiza
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        ''' <summary>
        ''' Actualiza las versiones de los costos a la versión actual.
        ''' </summary>
        ''' <param name="idCotiza"></param>
        Public Sub ActualizarVersiones(idCotiza As Integer)
            Try
                taCotizaciones.sp_tc016_updateVersiones(idCotiza)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        ''' <summary>
        ''' Devuelve verdadero 
        ''' </summary>
        ''' <param name="idCotiza"></param>
        ''' <returns></returns>
        Public Function TieneTemporales(idCotiza As Integer) As Boolean
            Try
                Dim conteo As Integer = Convert.ToInt32(taCotizaciones.sp_tc016_selectNumeroTemporales(idCotiza))
                If conteo > 0 Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#Region "Llenado textbox"
        ''' <summary>
        ''' Obtiene los número de documento de los clientes registrados en MRP y Unoee
        ''' </summary>
        ''' <param name="tipoDocumento">Servirá como filtro para identificar si es está buscando una cádula o un NIT</param>
        ''' <returns></returns>
        Public Function TraerNumeroDocumento(tipoDocumento As Integer) As List(Of cotizacion)
            Try
                TraerNumeroDocumento = New List(Of cotizacion)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectNumeroDocumentoTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_selectNumeroDocumentoDataTable = taAll.GetData(tipoDocumento)
                For Each ti As dsAlcoCotizaciones.sp_tc016_selectNumeroDocumentoRow In txAll
                    TraerNumeroDocumento.Add(New cotizacion(0, ti.documento, "", "", "", "", ""))
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene el nombre del cliente para completar el textbox
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerNombreCliente() As List(Of cotizacion)
            Try
                TraerNombreCliente = New List(Of cotizacion)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectNombreClienteTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_selectNombreClienteDataTable = taAll.GetData()
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc016_selectNombreClienteRow In txAll
                        TraerNombreCliente.Add(New cotizacion(0, "", ti.ItemArray(0).ToString(), "", "", "", ""))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerNombreCotizacion() As List(Of cotizacion)
            Try
                TraerNombreCotizacion = New List(Of cotizacion)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectNombreCotizaTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_selectNombreCotizaDataTable = taAll.GetData()
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc016_selectNombreCotizaRow In txAll.Rows
                        TraerNombreCotizacion.Add(New cotizacion(ti.nombreCotiza))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene los nombres de las obras que pertenecen el cliente indicado
        ''' </summary>
        ''' <param name="nombreCliente"></param>
        ''' <returns></returns>
        Public Function TraerNombreObra(nombreCliente As String) As List(Of cotizacion)
            TraerNombreObra = New List(Of cotizacion)
            Try
                If nombreCliente <> Nothing Then
                    Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectNombreObraTableAdapter
                    Dim txAll As dsAlcoCotizaciones.sp_tc016_selectNombreObraDataTable = taAll.GetData(nombreCliente)
                    If txAll.Rows.Count > 0 Then
                        For Each ti As dsAlcoCotizaciones.sp_tc016_selectNombreObraRow In txAll.Rows
                            TraerNombreObra.Add(New cotizacion(ti.ItemArray(0).ToString(), "", "", ""))
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene los la información del cliente con el número de documento indicado
        ''' </summary>
        ''' <param name="numeroDocumento"></param>
        ''' <returns></returns>
        Public Function TraerxNumeroDocumento(numeroDocumento As String) As List(Of cotizacion)
            Try
                TraerxNumeroDocumento = New List(Of cotizacion)
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByNumeroDocumentoTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_selectByNumeroDocumentoDataTable = taAll.GetData(numeroDocumento)
                For Each ti As dsAlcoCotizaciones.sp_tc016_selectByNumeroDocumentoRow In txAll
                    TraerxNumeroDocumento.Add(New cotizacion(ti.tipoDocumento, ti.documento, ti.cliente, ti.telefono,
                                                             ti.direccion, ti.correo, ti.nombreContacto))
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Función que devuelve la información de la cotización según el nombre personalizado de la cotización
        ''' </summary>
        ''' <param name="nomCotiza"></param>
        ''' <returns></returns>
        Public Function TraerxNombreCotiza(nomCotiza As String) As cotizacion
            Try
                TraerxNombreCotiza = New cotizacion
                Try
                    Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByNombreCotizaTableAdapter
                    Dim txid As dsAlcoCotizaciones.sp_tc016_selectByNombreCotizaDataTable = taAll.GetData(nomCotiza)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoCotizaciones.sp_tc016_selectByNombreCotizaRow In txid.Rows
                            TraerxNombreCotiza = (New cotizacion(ti.id, ti.nombreCotiza, ti.fechaCreacion, ti.fechaCotiza, ti.usuarioCreacion, ti.cliente, ti.idTipoDocumento,
                                                  ti.numIdentificacion, ti.digitoVerificacion, ti.telCliente, ti.dirCliente, ti.mailCliente,
                                                  ti.contactoCliente, ti.nombreObra, ti.contactoObra, ti.telObra, ti.mailObra, ti.idCiudad,
                                                  ti.NombreCiudad, ti.descuentoGlobal, ti.idFormaPago, ti.idAcabado, ti.nombreAcabado, ti.idTiempoEntrega, ti.idTasaImpuesto, ti.idFactor,
                                                  ti.verCostoVidrio, ti.verCostoAcabado, ti.verCostoNivel, ti.verCostoKiloAluminio, ti.verCostoAccesorios, ti.verCostoOtros,
                                                  ti.idEstado, ti.estado, ti.numeroImpresiones, ti.idHistoriaModi,
                                                  ti.idTipoEdificacion, ti.idGrupoUso, ti.idCategExposicion, ti.altoCaballete, ti.altoAlero, ti.anchoEdificio,
                                                  ti.altoEdificio, ti.tipoCubierta, ti.idPresion, ti.conInstalacion, ti.idManoObra, ti.idComponente, ti.idVendedor, ti.prefijoVendedor,
                                                  ti.tipoCotiza, ti.idVigencia, ti.AIU_Administracion, ti.AIU_Improvistos, ti.AIU_Utilidad, ti.altoEntreLosas,
                                                  ti.decuentoInstalacion, ti.cobroMtReales, ti.IndicadorAIU))
                        Next
                    Else
                        TraerxNombreCotiza = New cotizacion()
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene los registros asociados al nombre de cliente seleccionado
        ''' </summary>
        ''' <param name="nombreCliente"></param>
        ''' <returns></returns>
        Public Function TraerxNombreCliente(nombreCliente As String) As List(Of cotizacion)
            TraerxNombreCliente = New List(Of cotizacion)
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_SelectByNombreClienteTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_SelectByNombreClienteDataTable = taAll.GetData(nombreCliente)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc016_SelectByNombreClienteRow In txAll.Rows
                        TraerxNombreCliente.Add(New cotizacion(ti.tipoDocumento, ti.documento, ti.cliente, ti.telefono,
                                                               ti.direccion, ti.correo, ti.nombreContacto))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene los reguistros correspondientes al nombre de obra
        ''' </summary>
        ''' <param name="nombreObra"></param>
        ''' <returns></returns>
        Public Function TraerxNombreObra(nombreObra As String) As cotizacion
            TraerxNombreObra = New cotizacion
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByNombreObraTableAdapter
                Dim txAll As dsAlcoCotizaciones.sp_tc016_selectByNombreObraDataTable = taAll.GetData(nombreObra)
                If txAll.Rows.Count > 0 Then
                    For Each ti As dsAlcoCotizaciones.sp_tc016_selectByNombreObraRow In txAll.Rows
                        TraerxNombreObra = New cotizacion(ti.nombreObra, ti.nomContacto, ti.telefono, ti.correo)
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
#End Region


        ''' <summary>
        ''' Obtiene el id de la última cotización ingresada
        ''' </summary>
        ''' <returns></returns>
        Public Function TraerMaxIdCotiza() As Integer
            Try
                TraerMaxIdCotiza = Convert.ToInt32(taCotizaciones.sp_tc016_selectMaxIdCotiza())
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerTodosTabla(Optional ByRef tabla As DataTable = Nothing) As DataTable
            TraerTodosTabla = Nothing
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectAllTableAdapter
                TraerTodosTabla = taAll.GetData().Copy()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Función que devuelve toda la información de las cotizaciones
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodos(Optional ByRef tabla As DataTable = Nothing) As List(Of cotizacion)
            traerTodos = New List(Of cotizacion)
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectAllTableAdapter
                Dim txall As dsAlcoCotizaciones.sp_tc016_selectAllDataTable = taAll.GetData()
                For Each ti As dsAlcoCotizaciones.sp_tc016_selectAllRow In txall.Rows
                    traerTodos.Add(New cotizacion(ti.id, ti.nombreCotiza, ti.fechaCreacion, ti.fechaCotiza, ti.usuarioCreacion, ti.cliente, ti.idTipoDocumento,
                                                  ti.numIdentificacion, ti.digitoVerificacion, ti.telCliente, ti.dirCliente, ti.mailCliente,
                                                  ti.contactoCliente, ti.nombreObra, ti.contactoObra, ti.telObra, ti.mailObra, ti.idCiudad,
                                                  ti.NombreCiudad, ti.descuentoGlobal, ti.idFormaPago, ti.idAcabado, ti.nombreAcabado, ti.idTiempoEntrega, ti.idTasaImpuesto, ti.idFactor,
                                                  ti.verCostoVidrio, ti.verCostoAcabado, ti.verCostoNivel, ti.verCostoKiloAluminio, ti.verCostoAccesorios, ti.verCostoOtros,
                                                  ti.idEstado, ti.estado, ti.numeroImpresiones, ti.idHistoriaModi,
                                                  ti.idTipoEdificacion, ti.idGrupoUso, ti.idCategExposicion, ti.altoCaballete, ti.altoAlero, ti.anchoEdificio,
                                                  ti.altoEdificio, ti.tipoCubierta, ti.idPresion, ti.conInstalacion, ti.idManoObra, ti.idComponente, ti.idVendedor, ti.prefijoVendedor,
                                                  ti.tipoCotiza, ti.idVigencia, ti.AIU_Administracion, ti.AIU_Improvistos, ti.AIU_Utilidad, ti.altoEntreLosas,
                                                  ti.DescuentoInstalacion, ti.cobroMtReales, ti.IndicadorAIU))
                Next
                If txall.Rows.Count > 0 Then
                    tabla = txall.Where(Function(a) a.idEstado <> ClsEnums.Estados.ARCHIVADO).CopyToDataTable
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        ''' <summary>
        ''' Función que devuelve toda la información de las cotizaciones
        ''' </summary>
        ''' <returns></returns>
        Public Function traerTodosParaContratos() As DataTable
            traerTodosParaContratos = Nothing
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectAllforContractTableAdapter
                traerTodosParaContratos = taAll.GetData().CopyToDataTable
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        ''' <summary>
        ''' Función que devuelve la información de la cotización según el id recibido
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        Public Function TraerxId(id As Integer) As cotizacion
            Try
                TraerxId = New cotizacion
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByIdTableAdapter
                Dim txid As dsAlcoCotizaciones.sp_tc016_selectByIdDataTable = taAll.GetData(id)
                If txid.Rows.Count > 0 Then
                    Dim ti As dsAlcoCotizaciones.sp_tc016_selectByIdRow = DirectCast(txid.Rows(0), dsAlcoCotizaciones.sp_tc016_selectByIdRow)
                    TraerxId = New cotizacion(ti.id, ti.nombreCotiza, ti.fechaCreacion, ti.fechaCotiza, ti.usuarioCreacion, ti.cliente, ti.idTipoDocumento,
                                                  ti.numIdentificacion, ti.digitoVerificacion, ti.telCliente, ti.dirCliente, ti.mailCliente,
                                                  ti.contactoCliente, ti.nombreObra, ti.contactoObra, ti.telObra, ti.mailObra, ti.idCiudad,
                                                  ti.NombreCiudad, ti.descuentoGlobal, ti.idFormaPago, ti.idAcabado, ti.nombreAcabado, ti.idTiempoEntrega, ti.idTasaImpuesto, ti.idFactor,
                                                  ti.verCostoVidrio, ti.verCostoAcabado, ti.verCostoNivel, ti.verCostoKiloAluminio, ti.verCostoAccesorios, ti.verCostoOtros,
                                                  ti.idEstado, ti.estado, ti.numeroImpresiones, ti.idHistoriaModi,
                                                  ti.idTipoEdificacion, ti.idGrupoUso, ti.idCategExposicion, ti.altoCaballete, ti.altoAlero, ti.anchoEdificio,
                                                  ti.altoEdificio, ti.tipoCubierta, ti.idPresion, ti.conInstalacion, ti.idManoObra, ti.idComponente, ti.idVendedor, ti.prefijoVendedor,
                                                  ti.tipoCotiza, ti.idVigencia, ti.AIU_Administracion, ti.AIU_Improvistos, ti.AIU_Utilidad, ti.altoEntreLosas,
                                                  ti.descuentoInstalacion, ti.cobroMtReales, ti.IndicadorAIU)
                    TraerxId.Estado_Aprobacion = ti.aprobacion_cliente
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function TraerxId_TablaDatos(id As Integer) As DataTable
            Try
                Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByIdTableAdapter
                Return taAll.GetData(id).Copy()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Función que devuelve la información entre un rango de fechas
        ''' </summary>
        ''' <param name="fechaInicial"></param>
        ''' <param name="fechaFin"></param>
        ''' <returns></returns>
        Public Function TraerBetweenFecha(fechaInicial As DateTime, fechaFin As DateTime) As cotizacion
            Try
                TraerBetweenFecha = New cotizacion
                Try
                    Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectBetweenFechaCreacionTableAdapter
                    Dim txid As dsAlcoCotizaciones.sp_tc016_selectBetweenFechaCreacionDataTable = taAll.GetData(fechaInicial, fechaFin)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoCotizaciones.sp_tc016_selectBetweenFechaCreacionRow In txid.Rows
                            traerTodos.Add(New cotizacion(ti.id, ti.nombreCotiza, ti.fechaCreacion, ti.fechaCotiza, ti.usuarioCreacion, ti.cliente, ti.idTipoDocumento,
                                                  ti.numIdentificacion, ti.digitoVerificacion, ti.telCliente, ti.dirCliente, ti.mailCliente,
                                                  ti.contactoCliente, ti.nombreObra, ti.contactoObra, ti.telObra, ti.mailObra, ti.idCiudad,
                                                  ti.NombreCiudad, ti.descuentoGlobal, ti.idFormaPago, ti.idAcabado, ti.nombreAcabado, ti.idTiempoEntrega, ti.idTasaImpuesto, ti.idFactor,
                                                  ti.verCostoVidrio, ti.verCostoAcabado, ti.verCostoNivel, ti.verCostoKiloAluminio, ti.verCostoAccesorios, ti.verCostoOtros,
                                                  ti.idEstado, ti.estado, ti.numeroImpresiones, ti.idHistoriaModi,
                                                  ti.idTipoEdificacion, ti.idGrupoUso, ti.idCategExposicion, ti.altoCaballete, ti.altoAlero, ti.anchoEdificio,
                                                  ti.altoEdificio, ti.tipoCubierta, ti.idPresion, ti.conInstalacion, ti.idManoObra, ti.idComponente, ti.idVendedor, ti.prefijoVendedor,
                                                  ti.tipoCotiza, ti.idVigencia, ti.AIU_Administracion, ti.AIU_Improvistos, ti.AIU_Utilidad, ti.altoEntreLosas,
                                                  ti.descuentoInstalacion, ti.cobroMtReales, ti.IndicadorAIU))
                        Next
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        ''' <summary>
        ''' Obtiene los registros de cotizacion de acuerdo a su estado
        ''' </summary>
        ''' <param name="idEstado"></param>
        ''' <returns></returns>
        Public Function TraerxEstado(idEstado As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of cotizacion)
            Try
                TraerxEstado = New List(Of cotizacion)
                Try
                    Dim taAll As New dsAlcoCotizacionesTableAdapters.sp_tc016_selectByEstadoTableAdapter
                    Dim txid As dsAlcoCotizaciones.sp_tc016_selectByEstadoDataTable = taAll.GetData(idEstado)
                    If txid.Rows.Count > 0 Then
                        For Each ti As dsAlcoCotizaciones.sp_tc016_selectByEstadoRow In txid.Rows
                            traerTodos.Add(New cotizacion(ti.id, ti.nombreCotiza, ti.fechaCreacion, ti.fechaCotiza, ti.usuarioCreacion, ti.cliente, ti.idTipoDocumento,
                                                  ti.numIdentificacion, ti.digitoVerificacion, ti.telCliente, ti.dirCliente, ti.mailCliente,
                                                  ti.contactoCliente, ti.nombreObra, ti.contactoObra, ti.telObra, ti.mailObra, ti.idCiudad, ti.NombreCiudad, ti.descuentoGlobal,
                                                  ti.idFormaPago, ti.idAcabado, ti.nombreAcabado, ti.idTiempoEntrega, ti.idTasaImpuesto, ti.idFactor,
                                                  ti.verCostoVidrio, ti.verCostoAcabado, ti.verCostoNivel, ti.verCostoKiloAluminio, ti.verCostoAccesorios, ti.verCostoOtros,
                                                  ti.idEstado, ti.estado, ti.numeroImpresiones, ti.idHistoriaModi,
                                                  ti.idTipoEdificacion, ti.idGrupoUso, ti.idCategExposicion, ti.altoCaballete, ti.altoAlero, ti.anchoEdificio,
                                                  ti.altoEdificio, ti.tipoCubierta, ti.idPresion, ti.conInstalacion, ti.idManoObra, ti.idComponente, ti.idVendedor, ti.prefijoVendedor,
                                                  ti.tipoCotiza, ti.idVigencia, ti.AIU_Administracion, ti.AIU_Improvistos, ti.AIU_Utilidad, ti.altoEntreLosas,
                                                  ti.descuentoInstalacion, ti.cobroMtReales, ti.IndicadorAIU))
                        Next
                        dt = txid.CopyToDataTable
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message, ex.InnerException)
                End Try
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

#End Region

    End Class

    Public Class cotizacion
        Inherits ClsBaseParametros
#Region "Variables"
        Private _nombreCotizacion As String
        Private _fechaCotizacion As DateTime
        Private _cliente As String
        Private _idTipoIdentificacion As Integer
        Private _numIdentificacion As String
        Private _digitoVerificacion As String
        Private _telCliente As String
        Private _dirCliente As String
        Private _mailCliente As String
        Private _nomContacCliente As String
        Private _nomObra As String
        Private _nomContcObra As String
        Private _telObra As String
        Private _mailObra As String
        Private _idCiudad As Integer
        Private _Ciudad As String
        Private _descuentoGlobal As Decimal
        Private _idFormaPago As Integer
        Private _idAcabado As Integer
        Private _Acabado As String
        Private _idTiempoEntrega As Integer
        Private _idTasaImpuesto As Integer
        Private _idFactor As Integer
        Private _versionCostoVidrio As Integer
        Private _versionCostoAcabado As Integer
        Private _versionCostoNivel As Integer
        Private _versionCostoKiloAluminio As Integer
        Private _versionCostoAccesorio As Integer
        Private _versionCostoOtrosArticulos As Integer
        Private _numImpresiones As Integer
        Private _idHistorialUsuMod As Integer
        Private _idTipoEdificacion As Integer
        Private _idGrupoUso As Integer
        Private _idCateExposicion As Integer
        Private _alturaCaballerte As Decimal
        Private _alturaAlero As Decimal
        Private _anchoEdificio As Decimal
        Private _altoEdificio As Decimal
        Private _idTipoCubierta As Integer
        Private _idpresion As Integer
        Private _idManoObraInstalacion As Integer
        Private _conInstalacion As Integer
        Private _idComponente As Integer
        Private _idVendedor As Integer
        Private _prefijoVendedor As String
        Private _idTipoCotiza As Integer
        Private _tipoCotizacion As String
        Private _tipo As Integer
        Private _idVigencia As Integer
        Private _porcAdministracion As Decimal
        Private _porcImprovistos As Decimal
        Private _porcUtilidad As Decimal
        Private _alturaEntreLosas As Decimal
        Private _descuentoInstalacion As Decimal
        Private _cobraMtReales As Boolean
        Private _ind_AIU As Boolean
        Private _estado_aprobacion As Integer
#End Region

#Region "Propiedades"
        Public Property nombreCotizacion() As String
            Get
                Return _nombreCotizacion
            End Get
            Set(ByVal value As String)
                _nombreCotizacion = value
            End Set
        End Property
        Public Property fechaCotizacion() As DateTime
            Get
                Return _fechaCotizacion
            End Get
            Set(ByVal value As DateTime)
                _fechaCotizacion = value
            End Set
        End Property
        Public Property cliente() As String
            Get
                Return _cliente
            End Get
            Set(ByVal value As String)
                _cliente = value
            End Set
        End Property
        Public Property idIdentificacion() As Integer
            Get
                Return _idTipoIdentificacion
            End Get
            Set(ByVal value As Integer)
                _idTipoIdentificacion = value
            End Set
        End Property
        Public Property numIdentificacion() As String
            Get
                Return _numIdentificacion
            End Get
            Set(ByVal value As String)
                _numIdentificacion = value
            End Set
        End Property
        Public Property digitoVerificacion() As String
            Get
                Return _digitoVerificacion
            End Get
            Set(ByVal value As String)
                _digitoVerificacion = value
            End Set
        End Property
        Public Property telCliente() As String
            Get
                Return _telCliente
            End Get
            Set(ByVal value As String)
                _telCliente = value
            End Set
        End Property
        Public Property dirCliente() As String
            Get
                Return _dirCliente
            End Get
            Set(ByVal value As String)
                _dirCliente = value
            End Set
        End Property
        Public Property mailCliente() As String
            Get
                Return _mailCliente
            End Get
            Set(ByVal value As String)
                _mailCliente = value
            End Set
        End Property
        Public Property nomContacCliente() As String
            Get
                Return _nomContacCliente
            End Get
            Set(ByVal value As String)
                _nomContacCliente = value
            End Set
        End Property
        Public Property nomObra() As String
            Get
                Return _nomObra
            End Get
            Set(ByVal value As String)
                _nomObra = value
            End Set
        End Property
        Public Property nomContacObra() As String
            Get
                Return _nomContcObra
            End Get
            Set(ByVal value As String)
                _nomContcObra = value
            End Set
        End Property
        Public Property telObra() As String
            Get
                Return _telObra
            End Get
            Set(ByVal value As String)
                _telObra = value
            End Set
        End Property
        Public Property mailObra() As String
            Get
                Return _mailObra
            End Get
            Set(ByVal value As String)
                _mailObra = value
            End Set
        End Property
        Public Property idCiudad() As Integer
            Get
                Return _idCiudad
            End Get
            Set(ByVal value As Integer)
                _idCiudad = value
            End Set
        End Property
        Public Property Ciudad() As String
            Get
                Return _Ciudad
            End Get
            Set(ByVal value As String)
                _Ciudad = value
            End Set
        End Property
        Public Property descuentoGlobal() As Decimal
            Get
                Return _descuentoGlobal
            End Get
            Set(ByVal value As Decimal)
                _descuentoGlobal = value
            End Set
        End Property
        Public Property idFormaPago() As Integer
            Get
                Return _idFormaPago
            End Get
            Set(ByVal value As Integer)
                _idFormaPago = value
            End Set
        End Property
        Public Property idAcabado() As Integer
            Get
                Return _idAcabado
            End Get
            Set(ByVal value As Integer)
                _idAcabado = value
            End Set
        End Property
        Public Property Acabado() As String
            Get
                Return _Acabado
            End Get
            Set(ByVal value As String)
                _Acabado = value
            End Set
        End Property
        Public Property idTiempoEntrega() As Integer
            Get
                Return _idTiempoEntrega
            End Get
            Set(ByVal value As Integer)
                _idTiempoEntrega = value
            End Set
        End Property
        Public Property idTasaImpuesto() As Integer
            Get
                Return _idTasaImpuesto
            End Get
            Set(ByVal value As Integer)
                _idTasaImpuesto = value
            End Set
        End Property
        Public Property idFactor() As Integer
            Get
                Return _idFactor
            End Get
            Set(ByVal value As Integer)
                _idFactor = value
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
        Public Property versionCostoAcabado() As Integer
            Get
                Return _versionCostoAcabado
            End Get
            Set(ByVal value As Integer)
                _versionCostoAcabado = value
            End Set
        End Property
        Public Property versionCostoNivel() As Integer
            Get
                Return _versionCostoNivel
            End Get
            Set(ByVal value As Integer)
                _versionCostoNivel = value
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
        Public Property versionCostoAccesorio() As Integer
            Get
                Return _versionCostoAccesorio
            End Get
            Set(ByVal value As Integer)
                _versionCostoAccesorio = value
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
        Public Property numImpresiones() As Integer
            Get
                Return _numImpresiones
            End Get
            Set(ByVal value As Integer)
                _numImpresiones = value
            End Set
        End Property
        Public Property idHistorialUsuMod() As Integer
            Get
                Return _idHistorialUsuMod
            End Get
            Set(ByVal value As Integer)
                _idHistorialUsuMod = value
            End Set
        End Property
        Public Property idTipoEdificacion() As Integer
            Get
                Return _idTipoEdificacion
            End Get
            Set(ByVal value As Integer)
                _idTipoEdificacion = value
            End Set
        End Property
        Public Property idGrupoUso() As Integer
            Get
                Return _idGrupoUso
            End Get
            Set(ByVal value As Integer)
                _idGrupoUso = value
            End Set
        End Property
        Public Property idCateExposicion() As Integer
            Get
                Return _idCateExposicion
            End Get
            Set(ByVal value As Integer)
                _idCateExposicion = value
            End Set
        End Property
        Public Property alturaCaballete() As Decimal
            Get
                Return _alturaCaballerte
            End Get
            Set(ByVal value As Decimal)
                _alturaCaballerte = value
            End Set
        End Property
        Public Property alturaAlero() As Decimal
            Get
                Return _alturaAlero
            End Get
            Set(ByVal value As Decimal)
                _alturaAlero = value
            End Set
        End Property
        Public Property anchoEdificio() As Decimal
            Get
                Return _anchoEdificio
            End Get
            Set(ByVal value As Decimal)
                _anchoEdificio = value
            End Set
        End Property
        Public Property altoEdificio() As Decimal
            Get
                Return _altoEdificio
            End Get
            Set(ByVal value As Decimal)
                _altoEdificio = value
            End Set
        End Property
        Public Property idTipoCubierta() As Integer
            Get
                Return _idTipoCubierta
            End Get
            Set(ByVal value As Integer)
                _idTipoCubierta = value
            End Set
        End Property
        Public Property IdPresion As Integer
            Get
                Return _idpresion
            End Get
            Set(value As Integer)
                _idpresion = value
            End Set
        End Property
        Public Property conInstalacion() As Integer
            Get
                Return _conInstalacion
            End Get
            Set(ByVal value As Integer)
                _conInstalacion = value
            End Set
        End Property
        Public Property idManoObraInstalacion() As Integer
            Get
                Return _idManoObraInstalacion
            End Get
            Set(ByVal value As Integer)
                _idManoObraInstalacion = value
            End Set
        End Property
        Public Property idComponente() As Integer
            Get
                Return _idComponente
            End Get
            Set(ByVal value As Integer)
                _idComponente = value
            End Set
        End Property

        Public Property idVendedor() As Integer
            Get
                Return _idVendedor
            End Get
            Set(ByVal value As Integer)
                _idVendedor = value
            End Set
        End Property
        Public Property prefijoVendedor() As String
            Get
                Return _prefijoVendedor
            End Get
            Set(ByVal value As String)
                _prefijoVendedor = value
            End Set
        End Property
        Public Property idTipoCotiza() As Integer
            Get
                Return _idTipoCotiza
            End Get
            Set(ByVal value As Integer)
                _idTipoCotiza = value
            End Set
        End Property
        Public Property tipoCotizacion() As String
            Get
                Return _tipoCotizacion
            End Get
            Set(ByVal value As String)
                _tipoCotizacion = value
            End Set
        End Property
        Public Property tipo() As Integer
            Get
                Return _tipo
            End Get
            Set(ByVal value As Integer)
                _tipo = value
            End Set
        End Property
        Public Property idVigencia() As Integer
            Get
                Return _idVigencia
            End Get
            Set(ByVal value As Integer)
                _idVigencia = value
            End Set
        End Property
        Public Property porcAdministracion() As Decimal
            Get
                Return _porcAdministracion
            End Get
            Set(ByVal value As Decimal)
                _porcAdministracion = value
            End Set
        End Property
        Public Property porcImprovistos() As Decimal
            Get
                Return _porcImprovistos
            End Get
            Set(ByVal value As Decimal)
                _porcImprovistos = value
            End Set
        End Property
        Public Property porcUtilidad() As Decimal
            Get
                Return _porcUtilidad
            End Get
            Set(ByVal value As Decimal)
                _porcUtilidad = value
            End Set
        End Property
        Public Property alturaEntreLosas() As Decimal
            Get
                Return _alturaEntreLosas
            End Get
            Set(ByVal value As Decimal)
                _alturaEntreLosas = value
            End Set
        End Property
        Public Property descuentoInstalacion() As Decimal
            Get
                Return _descuentoInstalacion
            End Get
            Set(ByVal value As Decimal)
                _descuentoInstalacion = value
            End Set
        End Property
        Public Property CobraMtReales() As Boolean
            Get
                Return _cobraMtReales
            End Get
            Set(ByVal value As Boolean)
                _cobraMtReales = value
            End Set
        End Property
        Public Property ind_AIU() As Boolean
            Get
                Return _ind_AIU
            End Get
            Set(ByVal value As Boolean)
                _ind_AIU = value
            End Set
        End Property
        Public Property Estado_Aprobacion As Integer
            Get
                Return _estado_aprobacion
            End Get
            Set(value As Integer)
                _estado_aprobacion = value
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
        ''' <summary>
        ''' Información de toda la cotización
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="nombreCotizacion"></param>
        ''' <param name="fechaCreacion"></param>
        ''' <param name="fechaCotizacion"></param>
        ''' <param name="usuarioCreacion"></param>
        ''' <param name="cliente"></param>
        ''' <param name="idTipoIdentificacion"></param>
        ''' <param name="numeroIdentificacion"></param>
        ''' <param name="digitoVerificacion"></param>
        ''' <param name="telefonoCliente"></param>
        ''' <param name="direccionCliente"></param>
        ''' <param name="mailCliente"></param>
        ''' <param name="nombreContactoCliente"></param>
        ''' <param name="nombreObra"></param>
        ''' <param name="nombreContactoObra"></param>
        ''' <param name="telefonoObra"></param>
        ''' <param name="mailObra"></param>
        ''' <param name="idCiudad"></param>
        ''' <param name="nombreCiudad"></param>
        ''' <param name="descuentoGlobal"></param>
        ''' <param name="idFormaPago"></param>
        ''' <param name="idAcabado"></param>
        ''' <param name="nombreAcabado"></param>
        ''' <param name="idTiempoEntrega"></param>
        ''' <param name="idTasaImpuesto"></param>
        ''' <param name="idFactor"></param>
        ''' <param name="versionCostoVidrio"></param>
        ''' <param name="versionCostoAcabado"></param>
        ''' <param name="versionCostoNivel"></param>
        ''' <param name="versionCostoKiloAluminio"></param>
        ''' <param name="versionCostoAccesorio"></param>
        ''' <param name="versionCostoOtrosArticulos"></param>
        ''' <param name="idEstado"></param>
        ''' <param name="estado"></param>
        ''' <param name="numeroImpresiones"></param>
        ''' <param name="idHistoriaModificaciones"></param>
        ''' <param name="idTipoEdificacion"></param>
        ''' <param name="idGrupoUso"></param>
        ''' <param name="idCategoriaExposicion"></param>
        ''' <param name="alturaCaballete"></param>
        ''' <param name="alturaAlero"></param>
        ''' <param name="anchoEdificio"></param>
        ''' <param name="altoEdificio"></param>
        ''' <param name="idTipoCubierta"></param>
        ''' <param name="conInstalacion"></param>
        ''' <param name="idManoObraInstalacion"></param>
        ''' <param name="idComponente"></param>
        ''' <param name="idVendedorSiesa"></param>
        ''' <param name="prefijoVendedor"></param>
        ''' <param name="idTipoCotizacion"></param>
        ''' <param name="idVigencia"></param>
        ''' <param name="porcAdministracion"></param>
        ''' <param name="porcImprovistos"></param>
        ''' <param name="porcUtilidad"></param>
        ''' <param name="alturaEntreLosas"></param>
        ''' <param name="descuentoInstalacion"></param>
        Public Sub New(id As Integer, nombreCotizacion As String, fechaCreacion As DateTime, fechaCotizacion As DateTime, usuarioCreacion As String,
                       cliente As String, idTipoIdentificacion As Integer, numeroIdentificacion As String, digitoVerificacion As String,
                       telefonoCliente As String, direccionCliente As String, mailCliente As String, nombreContactoCliente As String, nombreObra As String,
                       nombreContactoObra As String, telefonoObra As String, mailObra As String, idCiudad As Integer, nombreCiudad As String, descuentoGlobal As Decimal,
                       idFormaPago As Integer, idAcabado As Integer, nombreAcabado As String, idTiempoEntrega As Integer, idTasaImpuesto As Integer,
                       idFactor As Integer, versionCostoVidrio As Integer, versionCostoAcabado As Integer, versionCostoNivel As Integer,
                       versionCostoKiloAluminio As Integer, versionCostoAccesorio As Integer, versionCostoOtrosArticulos As Integer, idEstado As Integer,
                       estado As String, numeroImpresiones As Integer, idHistoriaModificaciones As Integer, idTipoEdificacion As Integer,
                       idGrupoUso As Integer, idCategoriaExposicion As Integer, alturaCaballete As Decimal, alturaAlero As Decimal, anchoEdificio As Decimal,
                       altoEdificio As Decimal, idTipoCubierta As Integer, idpresion As Integer, conInstalacion As Integer, idManoObraInstalacion As Integer, idComponente As Integer,
                       idVendedorSiesa As Integer, prefijoVendedor As String, idTipoCotizacion As Integer, idVigencia As Integer, porcAdministracion As Decimal,
                       porcImprovistos As Decimal, porcUtilidad As Decimal, alturaEntreLosas As Decimal, descuentoInstalacion As Decimal, cobraMtReales As Boolean,
                       ind_AIU As Boolean)
            Try
                Me.Id = id
                _nombreCotizacion = Trim(nombreCotizacion)
                Me.FechaCreacion = fechaCreacion
                _fechaCotizacion = fechaCotizacion
                Me.UsuarioCreacion = Trim(usuarioCreacion)
                _cliente = Trim(cliente)
                _idTipoIdentificacion = idTipoIdentificacion
                _numIdentificacion = Trim(numeroIdentificacion)
                _digitoVerificacion = Trim(digitoVerificacion)
                _telCliente = Trim(telefonoCliente)
                _dirCliente = Trim(direccionCliente)
                _mailCliente = Trim(mailCliente)
                _nomContacCliente = Trim(nombreContactoCliente)
                _nomObra = Trim(nombreObra)
                _nomContcObra = Trim(nombreContactoObra)
                _telObra = Trim(telefonoObra)
                _mailObra = Trim(mailObra)
                _idCiudad = idCiudad
                _Ciudad = Trim(nombreCiudad)
                _descuentoGlobal = descuentoGlobal
                _idFormaPago = idFormaPago
                _idAcabado = idAcabado
                _Acabado = Trim(nombreAcabado)
                _idTiempoEntrega = idTiempoEntrega
                _idTasaImpuesto = idTasaImpuesto
                _idFactor = idFactor
                _versionCostoVidrio = versionCostoVidrio
                _versionCostoAcabado = versionCostoAcabado
                _versionCostoNivel = versionCostoNivel
                _versionCostoKiloAluminio = versionCostoKiloAluminio
                _versionCostoAccesorio = versionCostoAccesorio
                _versionCostoOtrosArticulos = versionCostoOtrosArticulos
                Me.IdEstado = idEstado
                Me.Estado = Trim(estado)
                _numImpresiones = numeroImpresiones
                _idHistorialUsuMod = idHistoriaModificaciones
                _idTipoEdificacion = idTipoEdificacion
                _idGrupoUso = idGrupoUso
                _idCateExposicion = idCategoriaExposicion
                _alturaCaballerte = alturaCaballete
                _alturaAlero = alturaAlero
                _anchoEdificio = anchoEdificio
                _altoEdificio = altoEdificio
                _alturaEntreLosas = alturaEntreLosas
                _idTipoCubierta = idTipoCubierta
                _idpresion = idpresion
                _conInstalacion = conInstalacion
                _idManoObraInstalacion = idManoObraInstalacion
                _idComponente = idComponente
                _idVendedor = idVendedorSiesa
                _prefijoVendedor = Trim(prefijoVendedor)
                _idTipoCotiza = idTipoCotizacion
                _tipoCotizacion = Trim(tipoCotizacion)
                _idVigencia = idVigencia
                _porcAdministracion = porcAdministracion
                _porcImprovistos = porcImprovistos
                _porcUtilidad = porcUtilidad
                _descuentoInstalacion = descuentoInstalacion
                _cobraMtReales = cobraMtReales
                _ind_AIU = ind_AIU
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Información del cliente
        ''' </summary>
        ''' <param name="idTipoDocumento"></param>
        ''' <param name="numDocumento"></param>
        ''' <param name="cliente"></param>
        ''' <param name="telefono"></param>
        ''' <param name="direccion"></param>
        ''' <param name="correo"></param>
        ''' <param name="nombreContacto"></param>
        Public Sub New(idTipoDocumento As Integer, numDocumento As String, cliente As String, telefono As String,
                       direccion As String, correo As String, nombreContacto As String)
            Try
                _idTipoIdentificacion = idTipoDocumento
                _numIdentificacion = numDocumento
                _cliente = Trim(cliente)
                _telCliente = Trim(telefono)
                _dirCliente = Trim(direccion)
                _mailCliente = Trim(correo)
                _nomContacCliente = Trim(nombreContacto)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub

        ''' <summary>
        ''' Información de la obra
        ''' </summary>
        ''' <param name="nombreObra"></param>
        ''' <param name="contactoObra"></param>
        ''' <param name="telefonoObra"></param>
        ''' <param name="mailObra"></param>
        Public Sub New(nombreObra As String, contactoObra As String, telefonoObra As String, mailObra As String)
            Try
                _nomObra = Trim(nombreObra)
                _nomContcObra = Trim(contactoObra)
                _telObra = Trim(telefonoObra)
                _mailObra = Trim(mailObra)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
        Public Sub New(nombreCotiza As String)
            Try
                _nombreCotizacion = Trim(nombreCotiza)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region
    End Class
End Namespace

