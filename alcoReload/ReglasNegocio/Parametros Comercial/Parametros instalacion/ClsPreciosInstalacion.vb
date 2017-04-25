Imports Datos

Public Class ClsPreciosInstalacion
#Region "Variables"
    Private taPreciosInstalacion As New dsAlcoComercial2TableAdapters.tc089_preciosInstalacionTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idProveedor As Integer, idConcepto As Integer, precio As Decimal,
                        porcRetenido As Decimal, idEstado As Integer)
        Try
            taPreciosInstalacion.Insert(DateTime.Now, usuario, idProveedor, idConcepto, precio, porcRetenido,
                                        usuario, DateTime.Now, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, precio As Decimal, porcRet As Decimal, idEstado As Integer, usuario As String)
        Try
            taPreciosInstalacion.sp_tc089_update(id, precio, porcRet, idEstado, usuario)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of precioInstalacion)
        Try
            TraerTodos = New List(Of precioInstalacion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc089_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc089_selectAllDataTable = taAll.GetData()
            For Each prec As dsAlcoComercial2.sp_tc089_selectAllRow In txAll
                TraerTodos.Add(New precioInstalacion(prec.id, prec.fechaCreacion, prec.usuarioCreacion, prec.idProveedor,
                                                     prec.proveedor, prec.idConcepto, prec.concepto, prec.unidadMedida,
                                                     prec.precio, prec.porcRetenido, prec.usuarioModi, prec.fechaModi,
                                                     prec.idEstado, prec.estado))
            Next
            If txAll.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdProveedor(idProveedor As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of precioInstalacion)
        Try
            TraerxIdProveedor = New List(Of precioInstalacion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc089_selectByIdProveedorTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc089_selectByIdProveedorDataTable = taAll.GetData(idProveedor)
            For Each prec As dsAlcoComercial2.sp_tc089_selectByIdProveedorRow In txAll
                TraerxIdProveedor.Add(New precioInstalacion(prec.id, prec.fechaCreacion, prec.usuarioCreacion, prec.idProveedor,
                                                     prec.proveedor, prec.idConcepto, prec.concepto, prec.unidadMedida,
                                                     prec.precio, prec.porcRetenido, prec.usuarioModi, prec.fechaModi,
                                                     prec.idEstado, prec.estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            Else
                dt = Nothing
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerEspecifico(idProveedor As Integer, idConcepto As Integer) As precioInstalacion
        Try
            TraerEspecifico = TraerTodos().FirstOrDefault(Function(a) a.IdProveedor = idProveedor And
                                                              a.IdConcepto = idConcepto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExistePrecio(idProveedor As Integer, idConcepto As Integer) As Boolean
        Try
            Dim lista As List(Of precioInstalacion) = TraerTodos().Where(Function(a) a.IdProveedor = idProveedor And
                                                                             a.IdConcepto = idConcepto).ToList
            If lista.Count > 0 Then
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
Public Class precioInstalacion
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idProveedor As Integer
    Private _proveedor As String
    Private _idConcepto As Integer
    Private _concepto As String
    Private _unidadMedida As String
    Private _precio As Decimal
    Private _porcentajeRetenido As Decimal
#End Region
#Region "Propiedades"
    Public Property IdProveedor() As Integer
        Get
            Return _idProveedor
        End Get
        Set(ByVal value As Integer)
            _idProveedor = value
        End Set
    End Property
    Public Property Proveedor() As String
        Get
            Return _proveedor
        End Get
        Set(ByVal value As String)
            _proveedor = value
        End Set
    End Property
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
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
    Public Property PorcRetenido() As Decimal
        Get
            Return _porcentajeRetenido
        End Get
        Set(ByVal value As Decimal)
            _porcentajeRetenido = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, idProveedor As Integer,
                   proveedor As String, idConcepto As Integer, concepto As String, unidadMedida As String,
                   precio As Decimal, porcRetenido As Decimal, usuarioModi As String, fechaModi As DateTime,
                   idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _idProveedor = idProveedor
            _proveedor = proveedor
            _idConcepto = idConcepto
            _concepto = concepto
            _unidadMedida = unidadMedida
            _precio = precio
            _porcentajeRetenido = porcRetenido
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
