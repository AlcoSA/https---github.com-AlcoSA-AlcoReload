Imports Datos

Public Class ClsConceptos
#Region "Variables"
    Private taConceptos As New dsAlcoComercial2TableAdapters.tc088_conceptosTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, concepto As String, descripcion As String, unMedida As String,
                        idTipoObra As Integer, cContrato As Boolean, cAdicional As Boolean, cEspecial As Boolean,
                        cruzaConOP As Boolean, idEstado As Integer)
        Try
            taConceptos.Insert(DateTime.Now, usuario, concepto, descripcion, unMedida, idTipoObra, cContrato,
                               cAdicional, cEspecial, cruzaConOP, usuario, DateTime.Now, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(idConcepto As Integer, concepto As String, descripcion As String, unMedida As String,
                         idTipoObra As Integer, cContrato As Boolean, cAdicional As Boolean, cEspecial As Boolean,
                         cruzaConOP As Boolean, usuario As String, idEstado As Integer)
        Try
            taConceptos.sp_tc088_update(idConcepto, concepto, descripcion, unMedida, idTipoObra, cContrato,
                                        cAdicional, cEspecial, cruzaConOP, usuario, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of concepto)
        Try
            TraerTodos = New List(Of concepto)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc088_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc088_selectAllDataTable = taAll.GetData()
            For Each con As dsAlcoComercial2.sp_tc088_selectAllRow In txAll
                TraerTodos.Add(New concepto(con.id, con.fechaCreacion, con.usuarioCreacion, con.concepto, con.descripcion,
                                            con.undMedida, con.idTipoObra, con.tipoObra, con.cContrato, con.cAdicional,
                                            con.cEspecial, con.cruzaConOP, con.usuarioModi, con.fechaModi, con.idEstado, con.estado))
            Next
            If txAll.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerDisponiblesxProveedor(idProveedor As Integer) As List(Of concepto)
        Try
            TraerDisponiblesxProveedor = New List(Of concepto)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc088_selectDisponiblesByProveedorTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc088_selectDisponiblesByProveedorDataTable = taAll.GetData(idProveedor)
            For Each con As dsAlcoComercial2.sp_tc088_selectDisponiblesByProveedorRow In txAll
                TraerDisponiblesxProveedor.Add(New concepto(con.id, con.fechaCreacion, con.usuarioCreacion, con.concepto, con.descripcion,
                                            con.undMedida, con.idTipoObra, con.tipoObra, con.cContrato, con.cAdicional,
                                            con.cEspecial, con.cruzaConOP, con.usuarioModi, con.fechaModi, con.idEstado, con.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(idConcepto As Integer) As concepto
        Try
            TraerxId = TraerTodos().FirstOrDefault(Function(a) a.Id = idConcepto)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function ExisteConcepto(concepto As String) As Boolean
        Try
            Dim lista As List(Of concepto) = TraerTodos().Where(Function(a) a.Concepto = concepto).ToList
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
Public Class concepto
    Inherits ClsBaseParametros
#Region "Variables"
    Private _concepto As String
    Private _descripcion As String
    Private _unidadMedida As String
    Private _idTipoObra As Integer
    Private _tipoObra As String
    Private _conceptoContrato As Boolean
    Private _conceptoAdicional As Boolean
    Private _conceptoEspecial As Boolean
    Private _cruzaConOP As Boolean
#End Region
#Region "Propiedades"
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
    Public Property UnidadMedida() As String
        Get
            Return _unidadMedida
        End Get
        Set(ByVal value As String)
            _unidadMedida = value
        End Set
    End Property
    Public Property IdTipoObra() As Integer
        Get
            Return _idTipoObra
        End Get
        Set(ByVal value As Integer)
            _idTipoObra = value
        End Set
    End Property
    Public Property TipoObra() As String
        Get
            Return _tipoObra
        End Get
        Set(ByVal value As String)
            _tipoObra = value
        End Set
    End Property
    Public Property ConceptoContrato() As Boolean
        Get
            Return _conceptoContrato
        End Get
        Set(ByVal value As Boolean)
            _conceptoContrato = value
        End Set
    End Property
    Public Property ConceptoAdicional() As Boolean
        Get
            Return _conceptoAdicional
        End Get
        Set(ByVal value As Boolean)
            _conceptoAdicional = value
        End Set
    End Property
    Public Property ConceptoEspecial() As Boolean
        Get
            Return _conceptoEspecial
        End Get
        Set(ByVal value As Boolean)
            _conceptoEspecial = value
        End Set
    End Property
    Public Property CruzaConOP() As Boolean
        Get
            Return _cruzaConOP
        End Get
        Set(ByVal value As Boolean)
            _cruzaConOP = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, concepto As String,
                   descripcion As String, unidadMedida As String, idTipoObra As Integer, tipoObra As String,
                   cContrato As Boolean, cAdicional As Boolean, cEspecial As Boolean, cruzaConOP As Boolean,
                   usuarioModi As String, fechaModi As DateTime, idEstado As Integer, estado As String)
        Try
            Me.Id = id
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioCreacion = usuarioCreacion
            _concepto = concepto
            _descripcion = descripcion
            _unidadMedida = unidadMedida
            _idTipoObra = idTipoObra
            _tipoObra = tipoObra
            _conceptoContrato = cContrato
            _conceptoAdicional = cAdicional
            _conceptoEspecial = cEspecial
            _cruzaConOP = cruzaConOP
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
