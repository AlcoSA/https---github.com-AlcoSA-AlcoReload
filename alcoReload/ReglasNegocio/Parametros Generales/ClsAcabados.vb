Imports Datos
Public Class ClsAcabados

#Region "Variables"
    Private taAcabados As New dsbAlcoIngenieriaTableAdapters.ti016_acabadosTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Ingresa un nuevo acabado a la base de datos
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="imagen"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombre As String, prefijo As String, imagen() As Byte, estado As Integer,
                        idFamiliaMaterial As Integer)
        Try
            taAcabados.sp_ti016_insert(usuario, nombre, prefijo, imagen, idFamiliaMaterial, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Actualiza todos los datos de un acabado
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="prefijo"></param>
    ''' <param name="imagen"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombre As String, prefijo As String, imagen() As Byte,
                         estado As Integer, idFamiliaMaterial As Integer)
        Try
            taAcabados.sp_ti016_updateById(nombre, prefijo, imagen, usuario, estado, id, idFamiliaMaterial)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados registrados
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Acabado)
        TraerTodos = New List(Of Acabado)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti016_selectAllDataTable = taAll.GetData()
            For Each acab As dsbAlcoIngenieria.sp_ti016_selectAllRow In txAll.Rows
                TraerTodos.Add(New Acabado(acab.Id, acab.Usuario_Creacion, acab.Fecha_Creacion, acab.Prefijo, acab.Nombre,
                                           acab.Imagen, acab.Usuario_Modificacion, acab.Fecha_Modificacion, acab.Id_Estado,
                                           acab.Estado, acab.Id_familia_material, acab.familia_material))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Obtiene los registros correspondientes al id familia material indicado
    ''' </summary>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <returns></returns>
    Public Function TraerxFamiliaMaterial(idFamiliaMaterial As Integer) As List(Of Acabado)
        Try
            TraerxFamiliaMaterial = New List(Of Acabado)
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectByFamiliaMaterialTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti016_selectByFamiliaMaterialDataTable = taAll.GetData(idFamiliaMaterial)
            If txAll.Rows.Count > 0 Then
                For Each acab As dsbAlcoIngenieria.sp_ti016_selectByFamiliaMaterialRow In txAll.Rows
                    TraerxFamiliaMaterial.Add(New Acabado(acab.id, acab.usuarioCreacion, acab.fechaCreacion, acab.prefijo, acab.nombre,
                                                          acab.imagen, acab.usuarioModi, acab.fechaModi, acab.idEstado, acab.estado,
                                                          acab.idFamiliaMaterial, acab.familiaMaterial))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Retorna verdadero si existe algún acabado con el mismo nombre en la familia indicada
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <returns></returns>
    Public Function ExisteByNombreAndMaterial(nombre As String, idFamiliaMaterial As Integer) As Boolean
        Try
            If Convert.ToInt32(taAcabados.sp_ti016_selectExistByNombreAndMaterial(nombre, idFamiliaMaterial)) > 0 Then Return True
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Retorna verdadero si existe algún acabado con el mismo prefijo en la familia indicada
    ''' </summary>
    ''' <param name="prefijo"></param>
    ''' <param name="idFamiliaMaterial"></param>
    ''' <returns></returns>
    Public Function ExisteByPrefijoAndMaterial(prefijo As String, idFamiliaMaterial As Integer) As Boolean
        Try
            If Convert.ToInt32(taAcabados.sp_ti016_selectExistByPrefijoAndMaterial(prefijo, idFamiliaMaterial)) > 0 Then Return True
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados filtrados por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As Acabado
        TraerxId = New Acabado
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectByIdTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti016_selectByIdDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim acab As dsbAlcoIngenieria.sp_ti016_selectByIdRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti016_selectByIdRow)
                TraerxId = New Acabado(acab.Id, acab.Usuario_Creacion, acab.Fecha_Creacion, acab.Prefijo, acab.Nombre, acab.Imagen,
                                       acab.Usuario_Modificacion, acab.Fecha_Modificacion, acab.Id_Estado, acab.Estado,
                                       acab.Id_familia_material, acab.familia_material)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados asociados a un estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns></returns>
    Public Function TraerxEstado(estado As Integer) As List(Of Acabado)
        TraerxEstado = New List(Of Acabado)
        Try
            Dim taEstado As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectByEstadoTableAdapter
            Dim txEstado As dsbAlcoIngenieria.sp_ti016_selectByEstadoDataTable = taEstado.GetData(estado)
            For Each acab As dsbAlcoIngenieria.sp_ti016_selectByEstadoRow In txEstado.Rows
                TraerxEstado.Add(New Acabado(acab.Id, acab.Usuario_Creacion, acab.Fecha_Creacion, acab.Prefijo, acab.Nombre, acab.Imagen,
                                             acab.Usuario_Modificacion, acab.Fecha_Modificacion, acab.Id_Estado, acab.Estado,
                                             acab.Id_familia_material, acab.familia_material))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados filtrados por un prefijo
    ''' </summary>
    ''' <param name="prefijo"></param>
    ''' <returns></returns>
    Public Function TraerxPrefijo(prefijo As String) As Acabado
        TraerxPrefijo = New Acabado
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectByPrefijoTableAdapter
            For Each acab As dsbAlcoIngenieria.sp_ti016_selectByPrefijoRow In taAll.GetData(prefijo).Rows
                TraerxPrefijo = New Acabado(acab.Id, acab.Usuario_Creacion, acab.Fecha_Creacion, acab.Prefijo, acab.Nombre, acab.Imagen,
                                            acab.Usuario_Modificacion, acab.Fecha_Modificacion, acab.Id_Estado, acab.Estado,
                                            acab.Id_familia_material, acab.familia_material)

            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los acabados asociados a un nombre
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <returns></returns>
    Public Function TraerxNombre(nombre As String) As List(Of Acabado)
        TraerxNombre = New List(Of Acabado)
        Try

            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti016_selectByNombreTableAdapter
            For Each acab As dsbAlcoIngenieria.sp_ti016_selectByNombreRow In taAll.GetData(nombre).Rows
                TraerxNombre.Add(New Acabado(acab.Id, acab.Usuario_Creacion, acab.Fecha_Creacion, acab.Prefijo, acab.Nombre, acab.Imagen,
                                             acab.Usuario_Modificacion, acab.Fecha_Modificacion, acab.Id_Estado, acab.Estado,
                                             acab.Id_familia_material, acab.familia_material))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region

End Class

Public Class Acabado
    Inherits ClsBaseParametros
#Region "Variables"
    Private _prefijo As String = String.Empty
    Private _nombre As String = String.Empty
    Private _imagen() As Byte = Nothing
    Private _idFamiliaMaterial As Integer
    Private _familiaMaterial As String
#End Region

#Region "Propiedades"

    Public Property Prefijo As String
        Get
            Return _prefijo
        End Get
        Set(value As String)
            _prefijo = value
        End Set
    End Property
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property Imagen As Byte()
        Get
            Return _imagen
        End Get
        Set(value As Byte())
            _imagen = value
        End Set
    End Property
    Public Property idFamiliaMaterial() As Integer
        Get
            Return _idFamiliaMaterial
        End Get
        Set(ByVal value As Integer)
            _idFamiliaMaterial = value
        End Set
    End Property
    Public Property familiaMaterial() As String
        Get
            Return _familiaMaterial
        End Get
        Set(ByVal value As String)
            _familiaMaterial = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, prefijo As String, nombre As String,
                   imagen() As Byte, usuariomodificacion As String, fechamodificacion As Date, idestado As Integer,
                   estado As String, idTipoMaterial As Integer, familiaMaterial As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _prefijo = Trim(prefijo)
            _nombre = Trim(nombre)
            _imagen = imagen
            _idFamiliaMaterial = idTipoMaterial
            _familiaMaterial = familiaMaterial
            Me.UsuarioModificacion = usuariomodificacion
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

End Class
