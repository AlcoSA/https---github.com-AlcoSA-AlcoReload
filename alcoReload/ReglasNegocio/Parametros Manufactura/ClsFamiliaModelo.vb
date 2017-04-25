Imports Datos
Public Class ClsFamiliaModelo
#Region "Variables"
    Private taFamilaModelo As New dsbAlcoIngenieriaTableAdapters.ti002_familiamodeloTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva familia de modelos
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="familia"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuarioCreacion As String, familia As String, prefijo As String, estado As Integer, observaciones As String)
        Try
            taFamilaModelo.sp_ti002_insert(usuarioCreacion, familia, prefijo, estado, observaciones)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar una familia de modelos registrada
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuarioModificacion"></param>
    ''' <param name="familia"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuarioModificacion As String, familia As String, prefijo As String, estado As Integer, observaciones As String)
        Try
            taFamilaModelo.sp_ti002_updateById(id, usuarioModificacion, familia, prefijo, estado, observaciones)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las familias de modelos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of FamiliaModelo)
        TraerTodos = New List(Of FamiliaModelo)
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti002_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti002_selectAllDataTable = taxId.GetData()
            For Each fm As dsbAlcoIngenieria.sp_ti002_selectAllRow In txall.Rows
                TraerTodos.Add(New FamiliaModelo(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Familia, fm.Prefijo, fm.Observaciones,
                                                 fm.Usuario_Modifiacion, fm.Fecha_Modificacion, fm.Id_Estado, fm.Estado))
            Next
            If txall.Rows.Count > 0 Then
                dt = txall.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las familias de modelos filtradas por un ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As FamiliaModelo
        TraerxId = New FamiliaModelo()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti002_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti002_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim fm As dsbAlcoIngenieria.sp_ti002_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti002_selectByIdRow)
                TraerxId = New FamiliaModelo(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Familia, fm.Prefijo, fm.Observaciones,
                                             fm.Usuario_Modifiacion, fm.Fecha_Modificacion, fm.Id_Estado, fm.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Esta funcion devuelve una lista de familias de modelo, según el valor de su estado
    ''' </summary>
    ''' <param name="estado">Valor del estado [Activo=1, Inactivo=2]</param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer, Optional ByRef tb As DataTable = Nothing) As List(Of FamiliaModelo)
        TraerxEstado = New List(Of FamiliaModelo)
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti002_selectByEstadoTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti002_selectByEstadoDataTable = taxId.GetData(estado)
            If txall.Rows.Count > 0 Then
                For Each fm As dsbAlcoIngenieria.sp_ti002_selectByEstadoRow In txall.Rows
                    TraerxEstado.Add(New FamiliaModelo(fm.Id, fm.Usuario_Creacion, fm.Fecha_Creacion, fm.Familia, fm.Prefijo, fm.Observaciones,
                                                     fm.Usuario_Modifiacion, fm.Fecha_Modificacion, fm.Id_Estado, fm.Estado))
                Next
            End If
            tb = taxId.GetData(estado).CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class FamiliaModelo
    Inherits ClsBaseParametros
#Region "Variables"

    Private _familia As String = String.Empty
    Private _prefijo As String = String.Empty
    Private _observaciones As String = String.Empty
#End Region

#Region "Propiedades"

    Public Property Familia As String
        Get
            Return _familia
        End Get
        Set(value As String)
            _familia = value
        End Set
    End Property

    Public Property Prefijo As String
        Get
            Return _prefijo
        End Get
        Set(value As String)
            _prefijo = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(value As String)
            _observaciones = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, familia As String, prefijo As String, observaciones As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _familia = Trim(familia)
            _prefijo = Trim(prefijo)
            _observaciones = Trim(observaciones)
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
