Imports Datos

Public Class ClsConceptosEspeciales
#Region "Variables"
    Private taConceptoEspecial As New dsAlcoComercial2TableAdapters.tc102_conceptosEspecialesTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(Usuario As String, idConcepto As Integer, descripcion As String, idEstado As Integer)
        Try
            taConceptoEspecial.sp_tc102_insert(Usuario, idConcepto, descripcion, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(idConceptoLinea As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of conceptoEspecial)
        Try
            TraerTodos = New List(Of conceptoEspecial)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc102_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc102_selectAllDataTable = taAll.GetData(idConceptoLinea)
            For Each con As dsAlcoComercial2.sp_tc102_selectAllRow In txAll
                TraerTodos.Add(New conceptoEspecial(con.id, con.fechaCreacion, con.usuarioCreacion, con.idConcepto, con.concepto,
                                                    con.descripcion, con.usuarioModi, con.fechaModi, con.idEstado, con.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idConceptoLinea As Integer, id As Integer) As conceptoEspecial
        Try
            TraerxId = TraerTodos(idConceptoLinea).FirstOrDefault(Function(a) a.Id = id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteDesripcion(idConceptoLinea As Integer, descripcion As String) As Boolean
        Try
            Dim list As List(Of conceptoEspecial) = TraerTodos(idConceptoLinea).Where(Function(a) a.Descripcion = descripcion).ToList
            If list.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class conceptoEspecial
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idConcepto As Integer
    Private _concepto As String
    Private _descripcion As String
#End Region
#Region "Propiedades"
    Public Property IdConcepto() As Integer
        Get
            Return _idConcepto
        End Get
        Set(ByVal value As Integer)
            _idConcepto = value
        End Set
    End Property
    Public Property Concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
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
#End Region
#Region "Procedimientos"
    Public Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idConcepto As Integer,
                   concepto As String, descripcion As String, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idConcepto = idConcepto
            _concepto = concepto
            _descripcion = descripcion
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
