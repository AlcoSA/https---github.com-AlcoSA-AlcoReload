Imports Datos
Public Class ClsEsquemaNota
#Region "Variables"
    Private mEsquemaNota As New dsAlcoContratosTableAdapters.tc067_esquemaNotaTableAdapter
#End Region
#Region "Procedimientos"
    ''' <summary>
    ''' Inserta la descripción y el pie de página de la nota indicada
    ''' </summary>
    ''' <param name="usuarioCreacion"></param>
    ''' <param name="idNotaCobro"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="pieDePagina"></param>
    Public Sub Insertar(usuarioCreacion As String, idNotaCobro As Integer, descripcion As String, pieDePagina As String)
        Try
            mEsquemaNota.sp_tc067_insert(usuarioCreacion, idNotaCobro, descripcion, pieDePagina)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class esquemaNota
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idNotaCobro As Integer
    Private _descripcion As String
    Private _pieDePagina As String
#End Region
#Region "Propiedades"
    Public Property IdNotaCobro() As Integer
        Get
            Return _idNotaCobro
        End Get
        Set(ByVal value As Integer)
            _idNotaCobro = value
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
    Public Property PiedePagina() As String
        Get
            Return _pieDePagina
        End Get
        Set(ByVal value As String)
            _pieDePagina = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String,
                   idNotaCobro As Integer, descripcion As String, pieDePagina As String)
        Me.Id = id
        Me.FechaCreacion = fechaCreacion
        Me.UsuarioCreacion = usuarioCreacion
        _idNotaCobro = idNotaCobro
        _descripcion = descripcion
        _pieDePagina = pieDePagina
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
