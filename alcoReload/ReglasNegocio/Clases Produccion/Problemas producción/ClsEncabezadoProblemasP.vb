Imports Datos

Public Class ClsEncabezadoProblemasP
#Region "Variables"
    Private taEncabezado As New dsAlcoProblemasProduccionTableAdapters.tpp001_encabezadoTableAdapter
    Private taDescripcion As New dsAlcoProblemasProduccionTableAdapters.tpp002_descripcionPpTableAdapter
    Private taHistorial As New dsAlcoProblemasProduccionTableAdapters.tpp007_historialCambioSeccionTableAdapter
#End Region
#Region "Procedimientos"
    Public Function InsertarEncabezado(usuario As String, consecutivo As Integer, idOp As Integer, fechaRegistro As DateTime,
                                       nit As String, cliente As String, codigoObra As String, obra As String, contacto As String,
                                       idPais As String, idDepartamento As String, idCiudad As String, telefono As String, fax As String,
                                       direccion As String, idSeccion As Integer, idVendedor As String, idEstado As Integer,
                                       idEstadoSolucion As Integer) As Integer
        Try
            Return Convert.ToInt32(taEncabezado.sp_tpp001_insert(usuario, consecutivo, idOp, fechaRegistro, nit, cliente, codigoObra,
                                                                 obra, contacto, idPais, idDepartamento, idCiudad, telefono, fax, direccion,
                                                                 idSeccion, idVendedor, idEstado, idEstadoSolucion))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function traerConsecutivo() As Integer
        Try
            traerConsecutivo = Convert.ToInt32(taEncabezado.sp_tpp001_selectConsecutivo())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub ActualizarEncabezado(idOp As Integer, fechaRegistro As DateTime, nit As String, cliente As String, codigoObra As String, obra As String,
                                    contacto As String, idPais As String, idDepto As String, idCiudad As String, telefono As String, fax As String,
                                    direccion As String, idSeccion As Integer, idVendedor As String, idEstado As Integer, idEstadoSolucion As Integer,
                                    Usuario As String, idEncabezado As Integer)
        Try
            taEncabezado.sp_tpp001_update(idOp, fechaRegistro, nit, cliente, codigoObra, obra, contacto, idPais, idDepto, idCiudad, telefono,
                                          fax, direccion, idSeccion, idVendedor, idEstado, idEstadoSolucion, Usuario, idEncabezado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarSeccionResponsable(idEncabezado As Integer, idSeccion As Integer)
        Try
            taEncabezado.sp_tpp001_updateSeccion(idEncabezado, idSeccion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstado(idEncabezado As Integer, idestado As Integer)
        Try
            taEncabezado.sp_tpp001_updateEstado(idEncabezado, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarEstadoProblemaProduccion(idEncabezado As Integer, idEstado As Integer)
        Try
            taEncabezado.sp_tpp001_updateEstadoSolucion(idEncabezado, idEstado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of encabezadoPP)
        Try
            TraerTodos = New List(Of encabezadoPP)
            Dim ta As New dsAlcoProblemasProduccionTableAdapters.sp_tpp001_selectAllTableAdapter
            Dim tx As dsAlcoProblemasProduccion.sp_tpp001_selectAllDataTable = ta.GetData()
            For Each e As dsAlcoProblemasProduccion.sp_tpp001_selectAllRow In tx.Rows
                TraerTodos.Add(New encabezadoPP(e.id, e.fechaCreacion, e.usuarioCreacion, e.consecutivo, e.idOp, e.fechaRegistro, e.nit,
                                                e.cliente, e.codigoObra, e.obra, e.contacto, e.idPais, e.idDepartamento, e.idCiudad, e.ciudad,
                                                e.telefono, e.fax, e.direccion, e.idSeccion, e.seccion, e.idVendedor, e.vendedor,
                                                e.idEstado, e.estado, e.idEstadoSolucion, e.estadoSolucion, e.fechaModi, e.usuarioModi,
                                                e.fechaAnulacion, e.usuarioAnulacion, e.descripcionProblema))
            Next
            If tx.Rows.Count > 0 Then
                dt = tx.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxEstados(estados As String, Optional ByRef dt As DataTable = Nothing) As List(Of encabezadoPP)
        Try
            TraerxEstados = New List(Of encabezadoPP)
            Dim ta As New dsAlcoProblemasProduccionTableAdapters.sp_tpp001_selectByEstadosTableAdapter
            Dim tx As dsAlcoProblemasProduccion.sp_tpp001_selectByEstadosDataTable = ta.GetData(estados)
            For Each e As dsAlcoProblemasProduccion.sp_tpp001_selectByEstadosRow In tx.Rows
                TraerxEstados.Add(New encabezadoPP(CInt(e.Item("id")), CDate(e.Item("fechaCreacion")), e.Item("usuarioCreacion").ToString(), CInt(e.Item("consecutivo")),
                                                CInt(e.Item("idOp")), CDate(e.Item("fechaRegistro")), e.Item("nit").ToString(), e.Item("cliente").ToString(),
                                                e.Item("codigoObra").ToString(), e.Item("obra").ToString(), e.Item("contacto").ToString(), e.Item("idPais").ToString(),
                                                e.Item("idDepartamento").ToString(), e.Item("idCiudad").ToString(), e.Item("ciudad").ToString(), e.Item("telefono").ToString(),
                                                e.Item("fax").ToString(), e.Item("direccion").ToString(), CInt(e.Item("idSeccion")), e.Item("seccion").ToString(),
                                                e.Item("idVendedor").ToString(), e.Item("vendedor").ToString(), CInt(e.Item("idEstado")), e.Item("estado").ToString(),
                                                CInt(e.Item("idEstadoSolucion")), e.Item("estadoSolucion").ToString(), CDate(e.Item("fechaModi")), e.Item("usuarioModi").ToString(),
                                                CDate(e.Item("fechaAnulacion")), e.Item("usuarioAnulacion").ToString(), e.Item("descripcionProblema").ToString()))
            Next
            If tx.Rows.Count > 0 Then
                dt = tx.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxId(id As Integer) As encabezadoPP
        Try
            Dim list As List(Of encabezadoPP) = TraerTodos()
            TraerxId = list.FirstOrDefault(Function(a) a.Id = id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub InsertarDescripcion(usuario As String, idEncabezado As Integer, descripcion As String)
        Try
            taDescripcion.sp_tpp002_insert(usuario, idEncabezado, descripcion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub ActualizarDescripcion(descripcion As String, usuario As String, idEncabezado As Integer)
        Try
            taDescripcion.sp_tpp002_update(descripcion, usuario, idEncabezado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub InsertarCambioSeccion(usuario As String, idEncabezado As Integer, idSeccionOriginal As Integer,
                                     idSeccionCambio As Integer, motivoCambio As String)
        Try
            taHistorial.sp_tpp007_insert(usuario, idEncabezado, idSeccionOriginal, idSeccionCambio, motivoCambio)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
Public Class encabezadoPP
#Region "Variables"
    Private _id As Integer
    Private _fechaCreacion As DateTime
    Private _usuarioCreacion As String
    Private _consecutivo As Integer
    Private _idOp As Integer
    Private _fechaRegistro As DateTime
    Private _nit As String
    Private _cliente As String
    Private _codigoObra As String
    Private _obra As String
    Private _contacto As String
    Private _idPais As String
    Private _idDeparttamento As String
    Private _idCiudad As String
    Private _ciudad As String
    Private _telefono As String
    Private _fax As String
    Private _direccion As String
    Private _idSeccion As Integer
    Private _seccion As String
    Private _idVendedor As String
    Private _vendedor As String
    Private _idEstado As Integer
    Private _estado As String
    Private _idEstadoSolucion As Integer
    Private _estadoSolucion As String
    Private _fechaModi As DateTime
    Private _usuarioModi As String
    Private _fechaAnulacion As DateTime
    Private _usuarioAnulacion As String
    Private _descripcionProblema As String
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
    Public Property FechaCreacion() As DateTime
        Get
            Return _fechaCreacion
        End Get
        Set(ByVal value As DateTime)
            _fechaCreacion = value
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
    Public Property Consecutivo() As Integer
        Get
            Return _consecutivo
        End Get
        Set(ByVal value As Integer)
            _consecutivo = value
        End Set
    End Property
    Public Property IdOp() As Integer
        Get
            Return _idOp
        End Get
        Set(ByVal value As Integer)
            _idOp = value
        End Set
    End Property
    Public Property FechaRegistro() As DateTime
        Get
            Return _fechaRegistro
        End Get
        Set(ByVal value As DateTime)
            _fechaRegistro = value
        End Set
    End Property
    Public Property Nit() As String
        Get
            Return _nit
        End Get
        Set(ByVal value As String)
            _nit = value
        End Set
    End Property
    Public Property Cliente() As String
        Get
            Return _cliente
        End Get
        Set(ByVal value As String)
            _cliente = value
        End Set
    End Property
    Public Property CodigoObra() As String
        Get
            Return _codigoObra
        End Get
        Set(ByVal value As String)
            _codigoObra = value
        End Set
    End Property
    Public Property Obra() As String
        Get
            Return _obra
        End Get
        Set(ByVal value As String)
            _obra = value
        End Set
    End Property
    Public Property Contacto() As String
        Get
            Return _contacto
        End Get
        Set(ByVal value As String)
            _contacto = value
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
            Return _idDeparttamento
        End Get
        Set(ByVal value As String)
            _idDeparttamento = value
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
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
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
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property IdSeccion() As Integer
        Get
            Return _idSeccion
        End Get
        Set(ByVal value As Integer)
            _idSeccion = value
        End Set
    End Property
    Public Property Seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value
        End Set
    End Property
    Public Property IdVendedor() As String
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
    Public Property IdEstado() As Integer
        Get
            Return _idEstado
        End Get
        Set(ByVal value As Integer)
            _idEstado = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Public Property IdEstadoSolucion() As Integer
        Get
            Return _idEstadoSolucion
        End Get
        Set(ByVal value As Integer)
            _idEstadoSolucion = value
        End Set
    End Property
    Public Property EstadoSolucion() As String
        Get
            Return _estadoSolucion
        End Get
        Set(ByVal value As String)
            _estadoSolucion = value
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
    Public Property UsuarioModi() As String
        Get
            Return _usuarioModi
        End Get
        Set(ByVal value As String)
            _usuarioModi = value
        End Set
    End Property
    Public Property FechaAnulacion() As DateTime
        Get
            Return _fechaAnulacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAnulacion = value
        End Set
    End Property
    Public Property UsuarioAnulacion() As String
        Get
            Return _usuarioAnulacion
        End Get
        Set(ByVal value As String)
            _usuarioAnulacion = value
        End Set
    End Property
    Public Property DescripcionProblema() As String
        Get
            Return _descripcionProblema
        End Get
        Set(ByVal value As String)
            _descripcionProblema = value
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
    Public Sub New(id As Integer, fechaCreacion As DateTime, usuarioCreacion As String, consecutivo As Integer, idOp As Integer,
                   fechaRegistro As DateTime, nit As String, cliente As String, codigoObra As String, obra As String, contacto As String,
                   idPais As String, idDepartamento As String, idCiudad As String, ciudad As String, telefono As String, fax As String,
                   direccion As String, idSeccion As Integer, seccion As String, idVendedor As String, vendedor As String,
                   idEstado As Integer, estado As String, idEstadoSolucion As Integer, estadoSolucion As String, fechaModi As DateTime,
                   usuarioModi As String, fechaAnulacion As DateTime, usuarioAnulacion As String, descripcionProblema As String)
        Try
            _id = id
            _fechaCreacion = fechaCreacion
            _usuarioCreacion = usuarioCreacion
            _consecutivo = consecutivo
            _idOp = idOp
            _fechaRegistro = fechaRegistro
            _nit = nit
            _cliente = cliente
            _codigoObra = codigoObra
            _obra = obra
            _contacto = contacto
            _idPais = idPais
            _idDeparttamento = idDepartamento
            _idCiudad = idCiudad
            _ciudad = ciudad
            _telefono = telefono
            _fax = fax
            _direccion = direccion
            _idSeccion = idSeccion
            _seccion = seccion
            _idVendedor = idVendedor
            _vendedor = vendedor
            _idEstado = idEstado
            _estado = estado
            _idEstadoSolucion = idEstadoSolucion
            _estadoSolucion = estadoSolucion
            _fechaModi = fechaModi
            _usuarioModi = usuarioModi
            _fechaAnulacion = fechaAnulacion
            _usuarioAnulacion = usuarioAnulacion
            _descripcionProblema = descripcionProblema
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class

