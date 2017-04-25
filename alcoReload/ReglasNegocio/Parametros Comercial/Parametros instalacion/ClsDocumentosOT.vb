Imports Datos

Public Class ClsDocumentosOT
#Region "Variables"
    Private taDocumentosOT As New dsAlcoComercial2TableAdapters.tc096_documentosOTTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, prefijo As String, descripcion As String, idEstado As Integer)
        Try
            taDocumentosOT.Insert(usuario, prefijo, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(prefijo As String, descripcion As String, Usuario As String,
                         idEstado As Integer, id As Integer)
        Try
            taDocumentosOT.Update(prefijo, descripcion, Usuario, idEstado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarConsecutivo(consecutivo As Integer, id As Integer)
        Try
            taDocumentosOT.sp_tc096_updateConsecutivo(consecutivo, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of documentoOT)
        Try
            TraerTodos = New List(Of documentoOT)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc096_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc096_selectAllDataTable = taAll.GetData()
            For Each doc As dsAlcoComercial2.sp_tc096_selectAllRow In txAll
                TraerTodos.Add(New documentoOT(doc.id, doc.fechaCreacion, doc.usuarioCreacion, doc.prefijo,
                                               doc.descripcion, doc.consecutivoInicial, doc.consecutivoProximo,
                                               doc.usuarioModi, doc.fechaModi, doc.idEstado, doc.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteRegistro(prefijo As String) As Boolean
        Try
            Dim list As List(Of documentoOT) = TraerTodos.Where(Function(a) a.Prefijo = prefijo).ToList
            If list.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idDocumento As Integer) As documentoOT
        Try
            TraerxId = TraerTodos().FirstOrDefault(Function(a) a.Id = idDocumento)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class documentoOT
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String
    Private _descripcion As String
    Private _consecutivoInicial As Integer
    Private _consecutivoProximo As Integer
#End Region
#Region "Propiedades"
    Public Property Prefijo() As String
        Get
            Return _prefijo
        End Get
        Set(ByVal value As String)
            _prefijo = value
        End Set
    End Property
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public Property ConsecutivoInicial() As Integer
        Get
            Return _consecutivoInicial
        End Get
        Set(ByVal value As Integer)
            _consecutivoInicial = value
        End Set
    End Property
    Public Property ConsecutivoProximo() As Integer
        Get
            Return _consecutivoProximo
        End Get
        Set(ByVal value As Integer)
            _consecutivoProximo = value
        End Set
    End Property
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, prefijo As String,
                   descripcion As String, consecutivoInicial As Integer, consecutivoProximo As Integer,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _prefijo = prefijo
            _descripcion = descripcion
            _consecutivoInicial = consecutivoInicial
            _consecutivoProximo = consecutivoProximo
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
            Me.IdEstado = idEstado
            Me.Estado = estado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class

