Imports Datos
Public Class ClsConfiguraciones
#Region "Variables"
    Private taconfiguraciones As New dsbAlcoIngenieriaTableAdapters.ti019_configuracionesTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar configuraciones en el sistema
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="configuracion"></param>
    ''' <param name="numerocuerpos"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, configuracion As String, numerocuerpos As Integer, estado As Integer, numeronaves As Integer, numerofijos As Integer)
        Try
            taconfiguraciones.sp_ti019_insert(usuario, configuracion, numerocuerpos, estado, numeronaves, numerofijos)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las configuraciones registradas
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="configuracion"></param>
    ''' <param name="numerocuerpos"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, configuracion As String, numerocuerpos As Integer, estado As Integer, numeronaves As Integer, numerofijos As Integer)
        Try
            taconfiguraciones.sp_ti019_updateById(configuracion, numerocuerpos, usuario, estado, id, numeronaves, numerofijos)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las configuraciones registradas
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Configuracion)
        TraerTodos = New List(Of Configuracion)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti019_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti019_selectAllDataTable = taAll.GetData()
            For Each cf As dsbAlcoIngenieria.sp_ti019_selectAllRow In txall.Rows
                TraerTodos.Add(New Configuracion(cf.Id, cf.Usuario_Creacion, cf.Fecha_Creacion, cf.Configuracion, cf.Numero_Cuerpos, cf.Numero_Naves, cf.Numero_Fijos,
                                                 cf.Usuario_Modificacion, cf.Fecha_Modificacion, cf.Id_Estado, cf.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para traer las configuraciones filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As Configuracion
        TraerxId = New Configuracion
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti019_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti019_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim cf As dsbAlcoIngenieria.sp_ti019_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti019_selectByIdRow)
                TraerxId = New Configuracion(cf.Id, cf.Usuario_Creacion, cf.Fecha_Creacion, cf.Configuracion, cf.Numero_Cuerpos, cf.Numero_Naves, cf.Numero_Fijos,
                                             cf.Usuario_Modificacion, cf.Fecha_Modificacion, cf.Id_Estado, cf.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Esta funcion devuelve una lista con las configuraciones posibles, según el estado de estado
    ''' </summary>
    ''' <param name="estado">Valor del estado [Activo=1, Inactivo=2]</param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of Configuracion)
        TraerxEstado = New List(Of Configuracion)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti019_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti019_selectByEstadoDataTable = taAll.GetData(estado)
            For Each cf As dsbAlcoIngenieria.sp_ti019_selectByEstadoRow In txall.Rows
                TraerxEstado.Add(New Configuracion(cf.Id, cf.Usuario_Creacion, cf.Fecha_Creacion, cf.Configuracion, cf.Numero_Cuerpos, cf.Numero_Naves, cf.Numero_Fijos,
                                                   cf.Usuario_Modificacion, cf.Fecha_Modificacion, cf.Id_Estado, cf.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class Configuracion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _configuracion As String = String.Empty
    Private _numerocuerpos As Integer = 0
    Private _numeronaves As Integer = 0
    Private _numerofijos As Integer = 0
#End Region
#Region "Propiedades"
    Public Property Configuracion As String
        Get
            Return _configuracion
        End Get
        Set(value As String)
            _configuracion = value
        End Set
    End Property
    Public Property NumeroCuerpos As Integer
        Get
            Return _numerocuerpos
        End Get
        Set(value As Integer)
            _numerocuerpos = value
        End Set
    End Property
    Public Property NumeroNaves As Integer
        Get
            Return _numeronaves
        End Get
        Set(value As Integer)
            _numeronaves = value
        End Set
    End Property
    Public Property NumeroFijos As Integer
        Get
            Return _numerofijos
        End Get
        Set(value As Integer)
            _numerofijos = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, configuracion As String, numerocuerpos As Integer, numeronaves As Integer, numerofijos As Integer,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _configuracion = Trim(configuracion)
            _numerocuerpos = numerocuerpos
            _numerofijos = numerofijos
            _numeronaves = numeronaves
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class
