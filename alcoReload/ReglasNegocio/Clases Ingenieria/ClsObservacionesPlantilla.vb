Imports Datos
Public Class ClsObservacionesPlantilla
#Region "Variables"
    Private taObservaciones As New dsbAlcoIngenieriaTableAdapters.ti014_observacionesplantillaTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva observación
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="visibiilidad"></param>
    ''' <param name="estado"></param>
    ''' <returns>Id del ultimo registro ingresado</returns>
    Public Function Ingresar(usuario As String, idplantillamodelo As Integer,
                        visibiilidad As Short, observacion As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(taObservaciones.sp_ti014_insert(usuario, idplantillamodelo,
                                                                   visibiilidad, observacion, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las observaciones registradas
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="visibilidad"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idplantillamodelo As Integer,
                        visibilidad As Short, observacion As String, estado As Integer)
        Try
            taObservaciones.sp_ti014_updateById(idplantillamodelo, visibilidad, observacion, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            taObservaciones.sp_ti014_deletebyId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las observaciones registradas
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos() As List(Of ObservacionPlantilla)
        TraerTodos = New List(Of ObservacionPlantilla)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti014_selecAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti014_selecAllDataTable = taAll.GetData()
            For Each op As dsbAlcoIngenieria.sp_ti014_selecAllRow In txall.Rows
                TraerTodos.Add(New ObservacionPlantilla(op.Id, op.Usuario_Creacion, op.Fecha_Creacion,
                                                        op.Id_Plantilla, op.Plantilla, Convert.ToBoolean(op.Visibilidad), op.Observacion, op.Usuario_Modificacion,
                                                        op.Fecha_Modificacion, op.Id_Estado, op.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las observaciones filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As ObservacionPlantilla
        TraerxId = New ObservacionPlantilla()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti014_selecByIdPlantillaTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti014_selecByIdPlantillaDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim op As dsbAlcoIngenieria.sp_ti014_selecByIdPlantillaRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti014_selecByIdPlantillaRow)
                TraerxId = New ObservacionPlantilla(op.Id, op.Usuario_Creacion, op.Fecha_Creacion,
                                                        op.Id_Plantilla, op.Plantilla, Convert.ToBoolean(op.Visibilidad), op.Observacion, op.Usuario_Modificacion,
                                                        op.Fecha_Modificacion, op.Id_Estado, op.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ValidarOvservaciones(listaobservaciones As List(Of String), ByRef mensaje As String) As Boolean
        Try
            For i = 0 To listaobservaciones.Count - 1
                If String.IsNullOrEmpty(listaobservaciones(i)) Then
                    mensaje &= vbCrLf & "Hay observaciones en blanco: Observación [" &
                    (i + 1).ToString() & "."
                End If
            Next
            Return String.IsNullOrEmpty(mensaje)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdPlantilla(idplantilla As Integer) As List(Of ObservacionPlantilla)
        TraerxIdPlantilla = New List(Of ObservacionPlantilla)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti014_selecByIdPlantillaTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti014_selecByIdPlantillaDataTable = taAll.GetData(idplantilla)
            For Each op As dsbAlcoIngenieria.sp_ti014_selecByIdPlantillaRow In txall.Rows
                TraerxIdPlantilla.Add(New ObservacionPlantilla(op.Id, op.Usuario_Creacion, op.Fecha_Creacion,
                                                        op.Id_Plantilla, op.Plantilla, Convert.ToBoolean(op.Visibilidad), op.Observacion, op.Usuario_Modificacion,
                                                        op.Fecha_Modificacion, op.Id_Estado, op.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class ObservacionPlantilla
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idplantillamodelo As Integer = 0
    Private _plantillamodelo As String = String.Empty
    Private _visibilidad As Boolean = False
    Private _observacion As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property IdPlantillaModelo As Integer
        Get
            Return _idplantillamodelo
        End Get
        Set(value As Integer)
            _idplantillamodelo = value
        End Set
    End Property
    Public Property PlantillaModelo As String
        Get
            Return _plantillamodelo
        End Get
        Set(value As String)
            _plantillamodelo = value
        End Set
    End Property

    Public Property Visibilidad As Boolean
        Get
            Return _visibilidad
        End Get
        Set(value As Boolean)
            _visibilidad = value
        End Set
    End Property
    Public Property Observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idplantillamodelo As Integer,
                   plantillamodelo As String, visibilidad As Boolean, observacion As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idplantillamodelo = idplantillamodelo
            _plantillamodelo = Trim(plantillamodelo)
            _visibilidad = visibilidad
            _observacion = observacion
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
