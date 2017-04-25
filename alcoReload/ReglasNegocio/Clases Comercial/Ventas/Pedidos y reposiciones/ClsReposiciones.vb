Imports Datos

Public Class ClsReposiciones
#Region "Variables"
    Private taReposiciones As New dsAlcoComercial2TableAdapters.tc074_reposicionesTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(tipoDocumentoUnoee As Integer, idDocumentoUnoee As Integer, ind_Documento As Integer, centroOperaciones As String,
                        fechaDocumento As DateTime, idEstado As Integer, nitFacturar As String, razonSocialFacturar As String,
                        sucursalFacturar As String, nitDespachar As String, sucursalDespachar As String, idMoneda As String, ind_tasa As Boolean,
                        entregarEn As Integer, fechaEntrega As DateTime, centroCostos As Integer, unidadNegocio As String, ordenCompra As String,
                        listaPrecio As String, proyecto As Integer, usuarioCreacion As String, usuarioModi As String, fechaModi As DateTime) As Integer
        Try
            Return Convert.ToInt32(taReposiciones.sp_tc074_Insert(tipoDocumentoUnoee, idDocumentoUnoee, ind_Documento, centroOperaciones,
                                                                  fechaDocumento, idEstado, nitFacturar, razonSocialFacturar, sucursalFacturar,
                                                                  nitDespachar, sucursalDespachar, idMoneda, ind_tasa, entregarEn, fechaEntrega,
                                                                  centroCostos, unidadNegocio, ordenCompra, listaPrecio, proyecto, usuarioCreacion,
                                                                  usuarioModi, fechaModi))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of reposicion)
        Try
            TraerTodos = New List(Of reposicion)
            Dim taAll As New dsAlcoComercial2TableAdapters.sp_tc074_selectAllTableAdapter
            Dim txAll As dsAlcoComercial2.sp_tc074_selectAllDataTable = taAll.GetData()
            For Each rep As dsAlcoComercial2.sp_tc074_selectAllRow In txAll
                TraerTodos.Add(New reposicion(rep.id, rep.tipoDocumentoUnoee, rep.idDocumentoUnoee, rep.ind_documento, rep.centroOperaciones,
                                              rep.fechaDocumento, rep.idEstado, rep.nitFacturar, rep.razonSocialFacturar, rep.sucursalFacturar,
                                              rep.nitDespachar, rep.sucursalDespachar, rep.idMoneda, rep.ind_tasa, rep.entregarEn,
                                              rep.fechaEntrega, rep.centroCostos, rep.unidadNegocio, rep.ordenCompra, rep.listaPrecio,
                                              rep.proyecto, rep.usuarioCreacion, rep.usuarioModi, rep.fechaModi))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class reposicion
#Region "Variables"
    Private _id As Integer
    Private _tipoDocumentoUnoee As String
    Private _idDocumentoUnoee As Integer
    Private _ind_Documento As Integer
    Private _centroOperaciones As String
    Private _fechaDocumento As DateTime
    Private _idEstado As Integer
    Private _nitFacturar As String
    Private _razonSocialFacturar As String
    Private _sucursalFacturar As String
    Private _nitDespachar As String
    Private _sucursalDespachar As String
    Private _idMoneda As String
    Private _indTasa As Boolean
    Private _entregarEn As Integer
    Private _fechaEntrega As DateTime
    Private _centroCostos As Integer
    Private _unidadNegocio As String
    Private _ordenCompra As String
    Private _listaPrecio As String
    Private _proyecto As Integer
    Private _usuarioCreacion As String
    Private _usuarioModi As String
    Private _fechaModi As DateTime
#End Region
#Region "Propiedades"
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property TipoDocumentoUnoee() As String
        Get
            Return _tipoDocumentoUnoee
        End Get
        Set(ByVal value As String)
            _tipoDocumentoUnoee = value
        End Set
    End Property
    Public Property IdDocumentoUnoee() As Integer
        Get
            Return _idDocumentoUnoee
        End Get
        Set(ByVal value As Integer)
            _idDocumentoUnoee = value
        End Set
    End Property
    Public Property Ind_Docuemnto() As Integer
        Get
            Return _ind_Documento
        End Get
        Set(ByVal value As Integer)
            _ind_Documento = value
        End Set
    End Property
    Public Property CentroOperaciones() As String
        Get
            Return _centroOperaciones
        End Get
        Set(ByVal value As String)
            _centroOperaciones = value
        End Set
    End Property
    Public Property FechaDocumento() As DateTime
        Get
            Return _fechaDocumento
        End Get
        Set(ByVal value As DateTime)
            _fechaDocumento = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
    Public Property NitFacturar() As String
        Get
            Return _nitFacturar
        End Get
        Set(ByVal value As String)
            _nitFacturar = value
        End Set
    End Property
    Public Property RazonSocialFacturar() As String
        Get
            Return _razonSocialFacturar
        End Get
        Set(ByVal value As String)
            _razonSocialFacturar = value
        End Set
    End Property
    Public Property SucursalFacturar() As String
        Get
            Return _sucursalFacturar
        End Get
        Set(ByVal value As String)
            _sucursalFacturar = value
        End Set
    End Property
    Public Property NitDespachar() As String
        Get
            Return _nitDespachar
        End Get
        Set(ByVal value As String)
            _nitDespachar = value
        End Set
    End Property
    Public Property SucursalDespachar() As String
        Get
            Return _sucursalDespachar
        End Get
        Set(ByVal value As String)
            _sucursalDespachar = value
        End Set
    End Property
    Public Property IdMoneda() As String
        Get
            Return _idMoneda
        End Get
        Set(ByVal value As String)
            _idMoneda = value
        End Set
    End Property
    Public Property IndTasa() As Boolean
        Get
            Return _indTasa
        End Get
        Set(ByVal value As Boolean)
            _indTasa = value
        End Set
    End Property
    Public Property EntregarEn() As Integer
        Get
            Return _entregarEn
        End Get
        Set(ByVal value As Integer)
            _entregarEn = value
        End Set
    End Property
    Public Property FechaEntrega() As DateTime
        Get
            Return _fechaEntrega
        End Get
        Set(ByVal value As DateTime)
            _fechaEntrega = value
        End Set
    End Property
    Public Property CentroCostos() As Integer
        Get
            Return _centroCostos
        End Get
        Set(ByVal value As Integer)
            _centroCostos = value
        End Set
    End Property
    Public Property UnidadNegocio() As String
        Get
            Return _unidadNegocio
        End Get
        Set(ByVal value As String)
            _unidadNegocio = value
        End Set
    End Property
    Public Property OrdenCompra() As String
        Get
            Return _ordenCompra
        End Get
        Set(ByVal value As String)
            _ordenCompra = value
        End Set
    End Property
    Public Property ListaPrecio() As String
        Get
            Return _listaPrecio
        End Get
        Set(ByVal value As String)
            _listaPrecio = value
        End Set
    End Property
    Public Property Proyecto() As Integer
        Get
            Return _proyecto
        End Get
        Set(ByVal value As Integer)
            _proyecto = value
        End Set
    End Property
    Public Property UsuarioCreacion() As String
        Get
            Return _usuarioCreacion
        End Get
        Set(ByVal value As String)
            _usuarioCreacion = value
        End Set
    End Property
    Public Property UsuarioModi() As String
        Get
            Return _usuarioModi
        End Get
        Set(ByVal value As String)
            _usuarioModi = value
        End Set
    End Property
    Public Property FechaModi() As DateTime
        Get
            Return _fechaModi
        End Get
        Set(ByVal value As DateTime)
            _fechaModi = value
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
    Public Sub New(id As Integer, tipoDocumentoUnoee As String, idDocumentoUnoee As Integer, ind_Documento As Integer,
                   centroOperaciones As String, fechaDocumento As DateTime, idEstado As Integer, nitFacturar As String,
                   razonSocialFacturar As String, sucursalFacturar As String, nitDespachar As String, sucursalDespachar As String,
                   idMoneda As String, indTasa As Boolean, entregarEn As Integer, fechaEntrega As DateTime, centroCostos As Integer,
                   unidadNegocio As String, ordenCompra As String, listaPrecio As String, proyecto As Integer,
                   usuarioCreacion As String, usuarioModi As String, fechaModi As DateTime)
        Try
            _id = id
            _tipoDocumentoUnoee = Trim(tipoDocumentoUnoee)
            _idDocumentoUnoee = idDocumentoUnoee
            _ind_Documento = ind_Documento
            _centroOperaciones = Trim(centroOperaciones)
            _fechaDocumento = fechaDocumento
            _idEstado = idEstado
            _nitFacturar = Trim(nitFacturar)
            _razonSocialFacturar = Trim(razonSocialFacturar)
            _sucursalFacturar = Trim(sucursalFacturar)
            _nitDespachar = Trim(nitDespachar)
            _sucursalDespachar = Trim(sucursalDespachar)
            _idMoneda = Trim(idMoneda)
            _indTasa = indTasa
            _entregarEn = entregarEn
            _fechaEntrega = fechaEntrega
            _centroCostos = centroCostos
            _unidadNegocio = Trim(unidadNegocio)
            _ordenCompra = Trim(ordenCompra)
            _listaPrecio = Trim(listaPrecio)
            _proyecto = proyecto
            _usuarioCreacion = Trim(usuarioCreacion)
            _usuarioModi = Trim(usuarioModi)
            _fechaModi = fechaModi
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class