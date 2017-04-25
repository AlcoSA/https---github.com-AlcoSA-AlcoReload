Public MustInherit Class ClsBaseParametros
#Region "Variables"
    Protected _id As Integer = 0
    Protected _idestado As Integer = 0
    Protected _fechacreacion As Date = Date.Now
    Protected _usuariocreacion As String = String.Empty
    Protected _fechamodificacion As Date
    Protected _usuariomodificacion As String = String.Empty
    Protected _estado As String = String.Empty
    Protected _usuarioAprobacion As String = String.Empty
    Protected _fechaAprobacion As DateTime = Date.Now
    Protected _usuarioAnulacion As String = String.Empty
    Protected _fechaAnulacion As DateTime = Date.Now

#End Region

#Region "Propiedades"

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property FechaCreacion As Date
        Get
            Return _fechacreacion
        End Get
        Set(value As Date)
            _fechacreacion = value
        End Set
    End Property

    Public Property UsuarioCreacion As String
        Get
            Return _usuariocreacion
        End Get
        Set(value As String)
            _usuariocreacion = value
        End Set
    End Property


    Public Property FechaModificacion As Date
        Get
            Return _fechamodificacion
        End Get
        Set(value As Date)
            _fechamodificacion = value
        End Set
    End Property

    Public Property UsuarioModificacion As String
        Get
            Return _usuariomodificacion
        End Get
        Set(value As String)
            _usuariomodificacion = value
        End Set
    End Property

    Public Property IdEstado As Integer
        Get
            Return _idestado
        End Get
        Set(value As Integer)
            _idestado = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property usuarioAprobacion() As String
        Get
            Return _usuarioAprobacion
        End Get
        Set(ByVal value As String)
            _usuarioAprobacion = value
        End Set
    End Property

    Public Property fechaAprobacion() As DateTime
        Get
            Return _fechaAprobacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAprobacion = value
        End Set
    End Property

    Public Property usuarioAnulacion() As String
        Get
            Return _usuarioAnulacion
        End Get
        Set(ByVal value As String)
            _usuarioAnulacion = value
        End Set
    End Property

    Public Property fechaAnulacion() As DateTime
        Get
            Return _fechaAnulacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAnulacion = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, usuariomodificacion As String, _
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            _id = id
            _usuariocreacion = usuariocreacion
            _fechacreacion = fechacreacion
            _usuariomodificacion = usuariomodificacion
            _fechamodificacion = fechamodificacion
            _idestado = idestado
            _estado = estado

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region


End Class
