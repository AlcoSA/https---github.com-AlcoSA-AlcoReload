Imports Datos
Public Class ClsComplementos
#Region "vars"
    Private comple As New dsAlcoOrdenesProduccionTableAdapters.top013_complementosTableAdapter
#End Region
#Region "procs"
    Public Sub Insertar(usuario As String, idbase As Integer, idcomplemento As Integer)
        Try
            comple.sp_top013_insert(usuario, idbase, idcomplemento)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporIdBase(idbase As Integer)
        Try
            comple.sp_top013_deletebyIdBase(idbase)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporIdComplento(idbase As Integer)
        Try
            comple.sp_top013_deletebyIdcomplemento(idbase)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerPorIdBase(idbase As Integer) As List(Of Complemento)
        TraerPorIdBase = New List(Of Complemento)
        Try
            Dim tcomp As dsAlcoOrdenesProduccion.top013_complementosDataTable = comple.TraerporIdBase(idbase)
            tcomp.ToList().ForEach(Sub(c)
                                       TraerPorIdBase.Add(New Complemento(c.fop013_rowid, c.fop013_usuariocreacion, c.fop013_fechacreacion,
                                                                          c.fop013_rowidbase, c.fop013_rowidcomplemento))
                                   End Sub)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class Complemento
    Inherits ClsBaseParametros
#Region "vars"
    Private _idbase As Integer
    Private _idcomplemento As Integer
#End Region
#Region "props"
    Public Property IdBase As Integer
        Get
            Return _idbase
        End Get
        Set(value As Integer)
            _idbase = value
        End Set
    End Property
    Public Property IdComplemento As Integer
        Get
            Return _idcomplemento
        End Get
        Set(value As Integer)
            _idcomplemento = value
        End Set
    End Property
#End Region
#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As DateTime,
                   idbase As Integer, idcomplemento As Integer)
        _id = id
        _usuariocreacion = usuariocreacion
        _fechacreacion = fechacreacion
        _idbase = idbase
        _idcomplemento = idcomplemento
    End Sub
#End Region
End Class