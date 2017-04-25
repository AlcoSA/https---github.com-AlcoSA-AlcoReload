Imports Datos
Public Class ClsPlantillasModelos

#Region "Variables"
    Private taPlantillasModelos As New dsbAlcoIngenieriaTableAdapters.ti011_plantillasmodelosTableAdapter

#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva plantilla
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idtipoModelo"></param>
    ''' <param name="idClasificacion"></param>
    ''' <param name="idFamiliaModelo"></param>
    ''' <param name="idConfiguracion"></param>
    ''' <param name="idAdicionales"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    ''' <returns>Id del ultimo parametro ingresado</returns>
    Public Function Ingresar(usuario As String, idtipoModelo As Integer, idClasificacion As Integer,
                             idFamiliaModelo As Integer, idConfiguracion As Integer, idAdicionales As Integer,
                             descripcion As String, estado As Integer, calcularNSR As Boolean) As Integer
        Try
            Return Convert.ToInt32(taPlantillasModelos.sp_ti011_insert(usuario, idtipoModelo,
                                                                       idClasificacion, idFamiliaModelo,
                                                                       idConfiguracion, idAdicionales,
                                                                       descripcion, estado, calcularNSR))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las plantillas registradas
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idtipoModelo"></param>
    ''' <param name="idClasificacion"></param>
    ''' <param name="idFamiliaModelo"></param>
    ''' <param name="idConfiguracion"></param>
    ''' <param name="idAdicionales"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idtipoModelo As Integer, idClasificacion As Integer,
                         idFamiliaModelo As Integer, idConfiguracion As Integer, idAdicionales As Integer,
                         descripcion As String, estado As Integer, calcularNSR As Boolean)
        Try
            taPlantillasModelos.sp_ti011_updateById(id, idtipoModelo, idClasificacion, idFamiliaModelo,
                                                    idConfiguracion, idAdicionales, descripcion, usuario,
                                                    estado, calcularNSR)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las plantillas de los modelos registradas en el sistema
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef tabla As DataTable = Nothing) As List(Of PlantillaModelo)
        TraerTodos = New List(Of PlantillaModelo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti011_selectAllDataTable = taAll.GetData()
            For Each pm As dsbAlcoIngenieria.sp_ti011_selectAllRow In txall.Rows
                TraerTodos.Add(New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modifiacion, pm.Fecha_Modificacion, pm.Id_Estado,
                                                   pm.Estado, pm.Materiales, pm.Aprobado, pm.Calcular_Nsr))
            Next
            tabla = txall
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener plantillas filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer, Optional ByVal dt As DataTable = Nothing) As PlantillaModelo
        TraerxId = New PlantillaModelo()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti011_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim pm As dsbAlcoIngenieria.sp_ti011_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti011_selectByIdRow)
                TraerxId = New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modifiacion,
                                               pm.Fecha_Modificacion, pm.Id_Estado, pm.Estado, 0, False, pm.Calcular_Nsr)
            End If
            dt = txid.CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las plantillas de los modelos asociadas a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer, Optional ByRef tabla As DataTable = Nothing) As List(Of PlantillaModelo)
        TraerxEstado = New List(Of PlantillaModelo)()
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti011_selectByEstadoDataTable = taEstado.GetData(estado)
            For Each pm As dsbAlcoIngenieria.sp_ti011_selectByEstadoRow In txEstado.Rows
                TraerxEstado.Add(New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modifiacion,
                                                   pm.Fecha_Modificacion, pm.Id_Estado, pm.Estado, 0, False, pm.Calcular_Nsr))
            Next
            tabla = txEstado.CopyToDataTable()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxEstado(estado As Integer) As DataTable
        TraerxEstado = Nothing
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti011_selectByEstadoDataTable = taEstado.GetData(estado)
            TraerxEstado = txEstado.Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Este procedimiento sirve para obtener las plantillas de los modelos asociadas a una familia
    ''' </summary>
    ''' <param name="idfamilia"></param>
    ''' <returns></returns>
    Public Function TraerxIdFamilia(idfamilia As Integer, Optional ByRef tb As DataTable = Nothing) As List(Of PlantillaModelo)
        TraerxIdFamilia = New List(Of PlantillaModelo)()
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectByIdFamiliaTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti011_selectByIdFamiliaDataTable = taEstado.GetData(idfamilia)
            For Each pm As dsbAlcoIngenieria.sp_ti011_selectByIdFamiliaRow In txEstado.Rows
                TraerxIdFamilia.Add(New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modifiacion, pm.Fecha_Modificacion,
                                                   pm.Id_Estado, pm.Estado, 0, False, pm.Calcular_Nsr))
            Next
            tb = taEstado.GetData(idfamilia).CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ComprobarExistencia(idmodelo As Integer, idclasificacion As Integer, idfamiliamodelo As Integer,
                                        idconfiguracion As Integer, idcaracteristicas As Integer) As Boolean
        Try
            Return Convert.ToBoolean(taPlantillasModelos.sp_ti011_comprobarExistencia(idmodelo, idclasificacion,
                                                                                      idfamiliamodelo, idconfiguracion,
                                                                                      idcaracteristicas))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdArticuloMAterial(idarticulo As String) As List(Of PlantillaModelo)
        TraerporIdArticuloMAterial = New List(Of PlantillaModelo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti011_selectByIdArticuloMaterialTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti011_selectByIdArticuloMaterialDataTable = taAll.GetData(idarticulo)
            For Each pm As dsbAlcoIngenieria.sp_ti011_selectByIdArticuloMaterialRow In txall.Rows
                TraerporIdArticuloMAterial.Add(New PlantillaModelo(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion,
                                                   pm.Id_TipoModelo, pm.Prefijo_Tipo_Modelo, pm.Tipo_Modelo,
                                                   pm.Id_ClasificacionModelo, pm.Prefijo_Clasificacion_Modelo, pm.Clasificacion_Modelo,
                                                   pm.IdFamiliaModelo, pm.Prefijo_Familia_Modelo, pm.Familia_Modelo,
                                                   pm.Id_Configuracion, pm.Configuracion,
                                                   pm.Id_CaracteristicasAd, pm.Prefijo_caracteristica_ad, pm.Caracteristica_Adicional,
                                                   pm.Nombre_Modelo, pm.Descripcion, pm.Usuario_Modifiacion,
                                                   pm.Fecha_Modificacion, pm.Id_Estado, pm.Estado, pm.Materiales, pm.Aprobado, pm.Calcular_Nsr))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ValidarEncabezado(idtipoModelo As Integer, idClasificacion As Integer, idFamiliaModelo As Integer,
                                      idConfiguracion As Integer, idAdicionales As Integer,
                                      validarExistencia As Boolean, ByRef mensaje As String) As Boolean
        Try
            If idtipoModelo <= 0 Then
                mensaje = "El tipo de modelo es un dato obligatorio, para la plantilla. Verifique la información"
                Return False
            End If
            If idClasificacion <= 0 Then
                mensaje = "La clasificación del modelo es un dato obligatorio, para la plantilla. Verifique la información"
                Return False
            End If
            If idFamiliaModelo <= 0 Then
                mensaje = "La familia del modelo es un dato obligatorio, para la plantilla. Verifique la información"
                Return False
            End If
            If idConfiguracion <= 0 Then
                mensaje = "La configuración del modelo es un dato obligatorio, para la plantilla. Verifique la información"
                Return False
            End If
            If idAdicionales <= 0 Then
                mensaje = "Adicionales del modelo es un dato obligatorio, para la plantilla. Verifique la información"
                Return False
            End If
            If validarExistencia Then
                If ComprobarExistencia(idtipoModelo, idClasificacion, idFamiliaModelo, idConfiguracion, idAdicionales) Then
                    mensaje = "La plantilla ya existe. Verifique la información"
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class PlantillaModelo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idtipomodelo As Integer = 0
    Private _prefijotipomodelo As String = String.Empty
    Private _tipomodelo As String = String.Empty
    Private _idclasificacionmodelo As Integer = 0
    Private _prefijoclasificacionmodelo As String = String.Empty
    Private _clasificacionmodelo As String = String.Empty
    Private _idfamiliamodelo As Integer = 0
    Private _prefijofamiliamodelo As String = String.Empty
    Private _familiamodelo As String = String.Empty
    Private _idconfiguracion As Integer = 0
    Private _configuracion As String = String.Empty
    Private _idcaracteristicaadd As Integer = 0
    Private _prefijocaracteristicaadd As String = String.Empty
    Private _caracteristicaadd As String = String.Empty
    Private _nombremodelo As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _materiales As Integer
    Private _aprobar As Boolean = False
    Private _calcularnsr As Boolean = False
#End Region
#Region "Propiedades"
    Public Property IdTipoModelo As Integer
        Get
            Return _idtipomodelo
        End Get
        Set(value As Integer)
            _idtipomodelo = value
        End Set
    End Property
    Public Property PrefijoTipoModelo As String
        Get
            Return _prefijotipomodelo
        End Get
        Set(value As String)
            _prefijotipomodelo = value
        End Set
    End Property
    Public Property TipoModelo As String
        Get
            Return _tipomodelo
        End Get
        Set(value As String)
            _tipomodelo = value
        End Set
    End Property
    Public Property IdClasificacionoModelo As Integer
        Get
            Return _idclasificacionmodelo
        End Get
        Set(value As Integer)
            _idclasificacionmodelo = value
        End Set
    End Property
    Public Property PrefijoClasificacionModelo As String
        Get
            Return _prefijoclasificacionmodelo
        End Get
        Set(value As String)
            _prefijoclasificacionmodelo = value
        End Set
    End Property
    Public Property ClasificacionModelo As String
        Get
            Return _clasificacionmodelo
        End Get
        Set(value As String)
            _clasificacionmodelo = value
        End Set
    End Property
    Public Property IdFamiliaModelo As Integer
        Get
            Return _idfamiliamodelo
        End Get
        Set(value As Integer)
            _idfamiliamodelo = value
        End Set
    End Property
    Public Property PrefijoFamiliaModelo As String
        Get
            Return _prefijofamiliamodelo
        End Get
        Set(value As String)
            _prefijofamiliamodelo = value
        End Set
    End Property
    Public Property FamiliaModelo As String
        Get
            Return _familiamodelo
        End Get
        Set(value As String)
            _familiamodelo = value
        End Set
    End Property
    Public Property IdConfiguracion As Integer
        Get
            Return _idconfiguracion
        End Get
        Set(value As Integer)
            _idconfiguracion = value
        End Set
    End Property
    Public Property Configuracion As String
        Get
            Return _configuracion
        End Get
        Set(value As String)
            _configuracion = value
        End Set
    End Property
    Public Property IdCaracteristicaAdicional As Integer
        Get
            Return _idcaracteristicaadd
        End Get
        Set(value As Integer)
            _idcaracteristicaadd = value
        End Set
    End Property
    Public Property PrefijoCaracteristicaAdicional As String
        Get
            Return _prefijocaracteristicaadd
        End Get
        Set(value As String)
            _prefijocaracteristicaadd = value
        End Set
    End Property
    Public Property CaracteristicaAdicional As String
        Get
            Return _caracteristicaadd
        End Get
        Set(value As String)
            _caracteristicaadd = value
        End Set
    End Property
    Public Property NombreModelo As String
        Get
            Return _nombremodelo
        End Get
        Set(value As String)
            _nombremodelo = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property materiales As Integer
        Get
            Return _materiales
        End Get
        Set(ByVal value As Integer)
            _materiales = value
        End Set
    End Property
    Public Property Aprobar As Boolean
        Get
            Return _aprobar
        End Get
        Set(value As Boolean)
            _aprobar = value
        End Set
    End Property
    Public Property Calcular_NSR As Boolean
        Get
            Return _calcularnsr
        End Get
        Set(value As Boolean)
            _calcularnsr = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date,
                   idtipomodelo As Integer, prefijotipomodelo As String, tipomodelo As String,
                   idclasificacionmodelo As Integer, prefijoclasificacionmodelo As String, clasificacionmodelo As String,
                   idfamiliamodelo As Integer, prefijofamiliamodelo As String, familiamodelo As String,
                   idconfiguracion As Integer, configuracion As String,
                   idcaracteristicaadi As Integer, prefijocaracteristicaadi As String, caracteristicaadi As String,
                   nombremodelo As String, descripcion As String,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer,
                   estado As String, materiales As Integer, aprobado As Boolean, calcular_nsr As Boolean)

        Try
            _id = id
            _usuariocreacion = usuariocreacion
            _fechacreacion = fechacreacion
            _idtipomodelo = idtipomodelo
            _prefijotipomodelo = prefijotipomodelo
            _tipomodelo = tipomodelo
            _idclasificacionmodelo = idclasificacionmodelo
            _prefijoclasificacionmodelo = prefijoclasificacionmodelo
            _clasificacionmodelo = clasificacionmodelo
            _idfamiliamodelo = idfamiliamodelo
            _prefijofamiliamodelo = prefijofamiliamodelo
            _familiamodelo = familiamodelo
            _idconfiguracion = idconfiguracion
            _configuracion = configuracion
            _idcaracteristicaadd = idcaracteristicaadi
            _prefijocaracteristicaadd = prefijocaracteristicaadi
            _caracteristicaadd = caracteristicaadi
            _nombremodelo = nombremodelo
            _descripcion = descripcion
            _usuariomodificacion = usuariomodificacion
            _fechamodificacion = fechamodificacion
            _idestado = idestado
            _estado = estado
            _materiales = materiales
            _aprobar = aprobado
            _calcularnsr = calcular_nsr
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class
