Imports Datos
Public Class ClsImagenesArticulos
#Region "Variables"
    Private taimgarticulos As New dsbAlcoIngenieriaTableAdapters.ti018_imagenesarticuloTableAdapter
#End Region

#Region "Procedimientos"
    Public Sub Insertar(usuario As String, idarticulo As Integer, dxf As String, descripcion As String, estado As Integer)
        Try
            taimgarticulos.sp_ti018_insert(usuario, idarticulo, dxf, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(id As Integer, usuario As String, idarticulo As Integer, dxf As String, descripcion As String, estado As Integer)
        Try
            taimgarticulos.sp_ti018_updateById(id, usuario, idarticulo, dxf, descripcion, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarImagenxId(id As Integer)
        Try
            taimgarticulos.sp_ti018_deletebyId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos() As List(Of ImagenArticulo)
        TraerTodos = New List(Of ImagenArticulo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti018_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti018_selectAllDataTable = taAll.GetData()
            For Each imgar As dsbAlcoIngenieria.sp_ti018_selectAllRow In txall.Rows
                TraerTodos.Add(New ImagenArticulo(imgar.Id, imgar.Usuario_Creacion, imgar.Fecha_Creacion, imgar.Id_Articulo,
                                        imgar.descripcion, imgar.dxf, imgar.Usuario_Modificacion,
                                            imgar.Fecha_Modifiacion, imgar.Id_Estado, imgar.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdArticulo(idarticulo As Integer) As List(Of ImagenArticulo)
        TraerxIdArticulo = New List(Of ImagenArticulo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti018_selectByIdArticuloTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti018_selectByIdArticuloDataTable = taAll.GetData(idarticulo)
            For Each imgar As dsbAlcoIngenieria.sp_ti018_selectByIdArticuloRow In txall.Rows
                TraerxIdArticulo.Add(New ImagenArticulo(imgar.Id, imgar.Usuario_Creacion, imgar.Fecha_Creacion, imgar.Id_Articulo,
                                        imgar.descripcion, imgar.dxf, imgar.Usuario_Modificacion,
                                            imgar.Fecha_Modifiacion, imgar.Id_Estado, imgar.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class ImagenArticulo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idarticulo As Integer = 0
    Private _descripcion As String = String.Empty
    Private _dxf As String = String.Empty

#End Region
#Region "Propiedades"
    Public Property IdArticulo As Integer
        Get
            Return _idarticulo
        End Get
        Set(value As Integer)
            _idarticulo = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property DXF As String
        Get
            Return _dxf
        End Get
        Set(value As String)
            _dxf = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date,
                   idarticulo As Integer, descripcion As String, dxf As String,
                   UsuarioModificacion As String, fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idarticulo = idarticulo
            _descripcion = Trim(descripcion)
            _dxf = dxf
            Me.UsuarioModificacion = Trim(UsuarioModificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class