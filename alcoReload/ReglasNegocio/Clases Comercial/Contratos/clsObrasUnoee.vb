Imports Datos
Public Class clsObrasUnoee
#Region "Variables"
    Private _obras As dsBUnoeeTableAdapters.sp_t201_UnoeeObrasTableAdapter
    Private _obrasById As dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdTableAdapter
    Private _obrasByIdAndSuc As dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdAndSucTableAdapter
    Private _obrasByIdAndNombre As dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdAndNombreTableAdapter

#End Region
#Region "Propiedades"
#End Region
#Region "Procedimientos"
    Public Function traerObras(Optional ByRef tb As DataTable = Nothing) As List(Of obrasUnoee)
        traerObras = New List(Of obrasUnoee)
        Try
            _obras = New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasTableAdapter
            For Each obras As dsBUnoee.sp_t201_UnoeeObrasRow In _obras.GetData().Rows
                traerObras.Add(New obrasUnoee(obras.idCliente, obras.idObra, obras.nombreObra, obras.idVendedor, obras.idContacto, If(obras.IsnitYoNull(), String.Empty, obras.nitYo),
                                              If(obras.IsNombreYoNull(), String.Empty, obras.NombreYo), obras.nomContacto, obras.direccion, obras.telefono, obras.correo))
            Next
            tb = _obras.GetData().CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerObrasByID(idCliente As Integer, Optional ByRef tb As DataTable = Nothing) As List(Of obrasUnoee)
        traerObrasByID = New List(Of obrasUnoee)
        Try
            _obrasById = New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdTableAdapter
            For Each obras As dsBUnoee.sp_t201_UnoeeObrasByIdRow In _obrasById.GetData(idCliente).Rows
                traerObrasByID.Add(New obrasUnoee(obras.idCliente, obras.idObra, obras.nombreObra, If(obras.IsidVendedorNull(), String.Empty, obras.idVendedor),
                                                  obras.idContacto, If(obras.IsnitYoNull(), String.Empty, obras.nitYo), If(obras.IsNombreYoNull(), String.Empty, obras.NombreYo),
                                                  obras.nomContacto, obras.direccion, obras.telefono, obras.correo))
            Next
            tb = If(traerObrasByID.Count = 0, Nothing, _obrasById.GetData(idCliente).CopyToDataTable)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerObrasByIDAndSuc(idCliente As Integer, sucursal As String) As List(Of obrasUnoee)
        traerObrasByIDAndSuc = New List(Of obrasUnoee)
        Try
            _obrasByIdAndSuc = New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdAndSucTableAdapter
            For Each obras As dsBUnoee.sp_t201_UnoeeObrasByIdAndSucRow In _obrasByIdAndSuc.GetData(idCliente, sucursal).Rows
                traerObrasByIDAndSuc.Add(New obrasUnoee(obras.idCliente, obras.idObra, obras.nombreObra, If(obras.IsidVendedorNull(), String.Empty, obras.idVendedor),
                                                        obras.idContacto, If(obras.IsnitYoNull(), String.Empty, obras.nitYo), If(obras.IsNombreYoNull(), String.Empty, obras.NombreYo),
                                                        obras.nomContacto, obras.direccion, obras.telefono, obras.correo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerObraByNitClienteAndSuc(nit As String, idObra As String) As obrasUnoee
        Try
            Dim taAll As New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByNitAndIdObraTableAdapter
            Dim txAll As dsBUnoee.sp_t201_UnoeeObrasByNitAndIdObraDataTable = taAll.GetData(nit, idObra)
            Dim obra As dsBUnoee.sp_t201_UnoeeObrasByNitAndIdObraRow = DirectCast(txAll.Rows(0), dsBUnoee.sp_t201_UnoeeObrasByNitAndIdObraRow)

            traerObraByNitClienteAndSuc = New obrasUnoee(obra.idCliente, obra.idObra, obra.nombreObra, If(obra.IsidVendedorNull(), String.Empty, obra.idVendedor),
                                                         obra.vendedor, obra.idContacto, If(obra.IsnitYoNull(), String.Empty, obra.nitYo), If(obra.IsNombreYoNull(),
                                                         String.Empty, obra.NombreYo), obra.nomContacto, obra.direccion, obra.telefono, obra.correo, obra.idPais,
                                                         obra.idDepartamento, obra.idCiudad, obra.ciudad, obra.fax)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerObrasByIDAndNombre(idCliente As Integer, nombre As String) As List(Of obrasUnoee)
        traerObrasByIDAndNombre = New List(Of obrasUnoee)
        Try
            _obrasByIdAndNombre = New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdAndNombreTableAdapter
            For Each obras As dsBUnoee.sp_t201_UnoeeObrasByIdAndNombreRow In _obrasByIdAndNombre.GetData(idCliente, nombre).Rows
                traerObrasByIDAndNombre.Add(New obrasUnoee(obras.idCliente, obras.idObra, obras.nombreObra, If(obras.IsidVendedorNull(), String.Empty, obras.idVendedor),
                                                           obras.idContacto, If(obras.IsnitYoNull(), String.Empty, obras.nitYo), If(obras.IsNombreYoNull(), String.Empty, obras.NombreYo),
                                                           obras.nomContacto, obras.direccion, obras.telefono, obras.correo))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerObraByIdClienteAndIdObra(idCliente As Integer, idObra As Integer) As obrasUnoee
        Try
            traerObraByIdClienteAndIdObra = Nothing
            Dim taAll As New dsBUnoeeTableAdapters.sp_t201_UnoeeObrasByIdClienteAndIdObraTableAdapter
            Dim txAll As dsBUnoee.sp_t201_UnoeeObrasByIdClienteAndIdObraDataTable = taAll.GetData(idCliente, idObra)
            If txAll.Rows.Count > 0 Then
                Dim obra As dsBUnoee.sp_t201_UnoeeObrasByIdClienteAndIdObraRow = DirectCast(txAll.Rows(0), dsBUnoee.sp_t201_UnoeeObrasByIdClienteAndIdObraRow)
                traerObraByIdClienteAndIdObra = New obrasUnoee(obra.idCliente, obra.idObra, obra.nombreObra, If(obra.IsidVendedorNull(), String.Empty, obra.idVendedor),
                                                               obra.idContacto, String.Empty, String.Empty, obra.nomContacto, obra.direccion, obra.telefono, obra.correo)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerYo(nit As String, codObra As String, Dato As String) As String
        traerYo = String.Empty
        Try
            Dim taAll As New dsBUnoeeTableAdapters.alco_entidadYOTableAdapter
            Dim txall As dsBUnoee.alco_entidadYODataTable = taAll.GetData(nit, codObra, Dato)
            If txall.Rows.Count > 0 Then
                traerYo = txall.Last.Item("dato").ToString
            Else
                traerYo = "--"
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class obrasUnoee
#Region "Variables"
    Private _idCliente As Integer
    Private _idObra As String
    Private _nombreObra As String
    Private _idVendedor As String
    Private _vendedor As String
    Private _idContacto As Integer
    Private _nitYo As String
    Private _nombreYo As String
    Private _nomContacto As String
    Private _direccion As String
    Private _telefono As String
    Private _correo As String
    Private _idPais As String
    Private _idDepartamento As String
    Private _idCiudad As String
    Private _ciudad As String
    Private _fax As String
#End Region
#Region "Propiedades"
    Public Property idCliente() As Integer
        Get
            Return _idCliente
        End Get

        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Public Property idObra() As String
        Get
            Return _idObra
        End Get
        Set(ByVal value As String)
            _idObra = value
        End Set
    End Property
    Public Property nombreObra() As String
        Get
            Return _nombreObra
        End Get
        Set(ByVal value As String)
            _nombreObra = value
        End Set
    End Property
    Public Property idVendedor() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property
    Public Property Vendedor() As String
        Get
            Return _vendedor
        End Get
        Set(ByVal value As String)
            _vendedor = value
        End Set
    End Property
    Public Property idContacto() As Integer
        Get
            Return idContacto
        End Get
        Set(ByVal value As Integer)
            _idContacto = value
        End Set
    End Property
    Public Property nitYo() As String
        Get
            Return _nitYo
        End Get
        Set(ByVal value As String)
            _nitYo = value
        End Set
    End Property
    Public Property nombreYo() As String
        Get
            Return _nombreYo
        End Get
        Set(ByVal value As String)
            _nombreYo = value
        End Set
    End Property
    Public Property nomContacto() As String
        Get
            Return _nomContacto
        End Get
        Set(ByVal value As String)
            _nomContacto = value
        End Set
    End Property
    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property
    Public Property correo() As String
        Get
            Return _correo
        End Get
        Set(ByVal value As String)
            _correo = value
        End Set
    End Property
    Public Property IdPais() As String
        Get
            Return _idPais
        End Get
        Set(ByVal value As String)
            _idPais = value
        End Set
    End Property
    Public Property IdDepartamento() As String
        Get
            Return _idDepartamento
        End Get
        Set(ByVal value As String)
            _idDepartamento = value
        End Set
    End Property
    Public Property IdCiudad() As String
        Get
            Return _idCiudad
        End Get
        Set(ByVal value As String)
            _idCiudad = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return _ciudad
        End Get
        Set(ByVal value As String)
            _ciudad = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return _fax
        End Get
        Set(ByVal value As String)
            _fax = value
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
    Public Sub New(idCliente As Integer, idObra As String, nombreObra As String, idVendedor As String,
            idContacto As Integer, nitYo As String, NombreYo As String, nomContacto As String, direccion As String,
            telefono As String, correo_ As String)
        Try
            _idCliente = idCliente
            _idObra = RTrim(idObra)
            _nombreObra = RTrim(nombreObra)
            _idVendedor = RTrim(idVendedor)
            _idContacto = idContacto
            _nitYo = RTrim(If(IsDBNull(nitYo), "", nitYo))
            _nombreYo = RTrim(If(IsDBNull(NombreYo), "", NombreYo))
            _nomContacto = RTrim(nomContacto)
            _direccion = RTrim(direccion)
            _telefono = RTrim(telefono)
            _correo = RTrim(correo)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub New(idCliente As Integer, idObra As String, nombreObra As String, idVendedor As String, vendedor As String,
            idContacto As Integer, nitYo As String, NombreYo As String, nomContacto As String, direccion As String,
            telefono As String, correo As String, idPais As String, idDepartamento As String, idCiudad As String, ciudad As String, fax As String)
        Try
            _idCliente = idCliente
            _idObra = RTrim(idObra)
            _nombreObra = RTrim(nombreObra)
            _idVendedor = RTrim(idVendedor)
            _vendedor = RTrim(vendedor)
            _idContacto = idContacto
            _nitYo = RTrim(If(IsDBNull(nitYo), "", nitYo))
            _nombreYo = RTrim(If(IsDBNull(NombreYo), "", NombreYo))
            _nomContacto = RTrim(nomContacto)
            _direccion = RTrim(direccion)
            _telefono = RTrim(telefono)
            _correo = RTrim(correo)
            _idPais = RTrim(idPais)
            _idDepartamento = RTrim(idDepartamento)
            _idCiudad = RTrim(idCiudad)
            _ciudad = RTrim(ciudad)
            _fax = RTrim(fax)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
