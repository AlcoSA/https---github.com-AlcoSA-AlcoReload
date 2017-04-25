Imports Datos

Public Class ClsMovitoDevolucion
#Region "Variables"
    Private taMovitoDevolucion As New dsAlcoComercial2TableAdapters.tc107_movitoDevolucionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idDevolucion As Integer, idMovitoCuentaCobro As Integer, cantidadDevuelta As Decimal,
                        valorDevuelto As Decimal, idEstado As Integer)
        Try
            taMovitoDevolucion.sp_tc107_insert(usuario, idDevolucion, idMovitoCuentaCobro, cantidadDevuelta, valorDevuelto, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idDevolucion As Integer, idEstado As Integer, usuario As String)
        Try
            taMovitoDevolucion.sp_tc107_updateEstado(idDevolucion, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdDevolucion(idDevolucion As Integer) As List(Of movitoDevolucion)
        Try
            TraerxIdDevolucion = New List(Of movitoDevolucion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc107_selectByIdDevolucionTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc107_selectByIdDevolucionDataTable = taAll.GetData(idDevolucion)
            For Each mov As dsAlcoComercial2.sp_tc107_selectByIdDevolucionRow In txAll
                TraerxIdDevolucion.Add(New movitoDevolucion(mov.id, mov.fechaCreacion, mov.usuarioCreacion, mov.idDevolucion, mov.idMovitoCuentaCobro,
                                                            mov.concepto, mov.descripcion, mov.precio, mov.retenido, mov.unidadMedida, mov.cantidadDevuelta,
                                                            mov.valorDevuelto, mov.usuarioModi, mov.fechaModi, mov.idEstado, mov.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoDevolucion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idDevolucion As Integer
    Private _idMovitoCuentaCobro As Integer
    Private _concepto As String
    Private _descripcionConcepto As String
    Private _precio As Decimal
    Private _retenido As Decimal
    Private _unidadMedida As String
    Private _cantidadDevuelta As Decimal
    Private _valorDevuelto As Decimal
#End Region
#Region "Propiedades"
    Public Property IdDevolucion() As Integer
        Get
            Return _idDevolucion
        End Get
        Set(ByVal value As Integer)
            _idDevolucion = value
        End Set
    End Property
    Public Property IdMovitoCuentaCobro() As Integer
        Get
            Return _idMovitoCuentaCobro
        End Get
        Set(ByVal value As Integer)
            _idMovitoCuentaCobro = value
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
    Public Property DescripcionConcepto() As String
        Get
            Return _descripcionConcepto
        End Get
        Set(ByVal value As String)
            _descripcionConcepto = value
        End Set
    End Property
    Public Property Precio() As Decimal
        Get
            Return _precio
        End Get
        Set(ByVal value As Decimal)
            _precio = value
        End Set
    End Property
    Public Property Retenido() As Decimal
        Get
            Return _retenido
        End Get
        Set(ByVal value As Decimal)
            _retenido = value
        End Set
    End Property
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property CantidadDevuelta() As Decimal
        Get
            Return _cantidadDevuelta
        End Get
        Set(ByVal value As Decimal)
            _cantidadDevuelta = value
        End Set
    End Property
    Public Property ValorDevuelto() As Decimal
        Get
            Return _valorDevuelto
        End Get
        Set(ByVal value As Decimal)
            _valorDevuelto = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idDevolucion As Integer, idMovitoCuentaCobro As Integer,
                   concepto As String, descripcionConcepto As String, precio As Decimal, retenido As Decimal, unidadMedida As String,
                   cantidadDevuelta As Decimal, valorDevuelto As Decimal, usuarioModi As String, fechaModi As DateTime, idEstado As Integer,
                   estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idDevolucion = idDevolucion
            _idMovitoCuentaCobro = idMovitoCuentaCobro
            _concepto = concepto
            _descripcionConcepto = descripcionConcepto
            _precio = precio
            _retenido = retenido
            _unidadMedida = unidadMedida
            _cantidadDevuelta = cantidadDevuelta
            _valorDevuelto = valorDevuelto
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
