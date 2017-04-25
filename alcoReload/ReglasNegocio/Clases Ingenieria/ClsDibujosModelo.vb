Imports Datos

Public Class ClsDibujosModelo
#Region "Variables"
        Private tadibujosmodelo As New dsbAlcoIngenieriaTableAdapters.ti010_dibujosmodeloTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar un nuevo dibujo
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombre"></param>
    ''' <param name="idplantilla"></param>
    ''' <param name="dxf"></param>
    ''' <param name="estado"></param>
    ''' <returns>Id del ultimo registro ingresado</returns>
    Public Function Ingresar(usuario As String, idplantilla As Integer,
                             nombre As String, predeterminado As String, dxf As String,
                             estado As Integer, plantillavidrio As Boolean) As Integer
        Try
            Return Convert.ToInt32(tadibujosmodelo.Insertar(usuario, idplantilla, nombre,
                                                            predeterminado, dxf, estado, plantillavidrio))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para modificar un dibujo existente
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idplantilla"></param>
    ''' <param name="nombre"></param>
    ''' <param name="dxf"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idplantilla As Integer,
                         nombre As String, predeterminado As String, dxf As String,
                         estado As Integer, plantillavidrio As Boolean)
        Try
            tadibujosmodelo.Modificar(id, idplantilla, nombre, predeterminado, dxf,
                                      usuario, estado, plantillavidrio)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            tadibujosmodelo.EliminarporId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Este procedimiento sirve para obtener todos los dibujos
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos() As List(Of DibujoModelo)
            TraerTodos = New List(Of DibujoModelo)
        Try
            Dim txall As dsbAlcoIngenieria.ti010_dibujosmodeloDataTable = tadibujosmodelo.GetData()
            For Each dm As dsbAlcoIngenieria.ti010_dibujosmodeloRow In txall.Rows
                TraerTodos.Add(New DibujoModelo(dm.fi010_rowid, dm.fi010_usuarioCreacion, dm.fi010_fechaCreacion,
                                                dm.fi010_nombre, dm.fi010_rowidPlantillaModelo, dm.fi010_customdxf, dm.fi010_predeterminado,
                                                dm.fi010_plantillavidrio, dm.fi010_usuarioModificacion, dm.fi010_fechaModificacion, dm.fi010_rowidEstado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
        End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener dibujos asociados a una plantilla
    ''' </summary>
    ''' <param name="idplantilla"></param>
    ''' <returns></returns>
    Public Function TraerxIdPlantilla(idplantilla As Integer) As List(Of DibujoModelo)
        TraerxIdPlantilla = New List(Of DibujoModelo)
        Try
            Dim txall As dsbAlcoIngenieria.ti010_dibujosmodeloDataTable = tadibujosmodelo.TraerporIdPlantilla(idplantilla)
            For Each dm As dsbAlcoIngenieria.ti010_dibujosmodeloRow In txall.Rows
                TraerxIdPlantilla.Add(New DibujoModelo(dm.fi010_rowid, dm.fi010_usuarioCreacion, dm.fi010_fechaCreacion,
                                                dm.fi010_nombre, dm.fi010_rowidPlantillaModelo, dm.fi010_customdxf, dm.fi010_predeterminado,
                                                dm.fi010_plantillavidrio, dm.fi010_usuarioModificacion, dm.fi010_fechaModificacion, dm.fi010_rowidEstado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ValidarListaImagenes(listanombre As List(Of String), listadxf As List(Of String), ByRef mensaje As String) As Boolean
        Try
            For i = 0 To listanombre.Count - 1
                If String.IsNullOrEmpty(Trim(listanombre(i))) Then
                    mensaje = "La imagen [" & i.ToString() & "], no tiene un nombre asignado."
                    Return False
                End If
            Next
            For i = 0 To listadxf.Count - 1
                If String.IsNullOrEmpty(Trim(listadxf(i))) Then
                    mensaje = "La imagen [" & i.ToString() & "], esta vacía y es un dato obligatorio."
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class DibujoModelo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idplantilla As Integer = 0
    Private _nombre As String = String.Empty
    Private _dxf As String = String.Empty
    Private _predeterminado As String = String.Empty
    Private _plantillavidrio As Boolean = False
#End Region
#Region "Propiedades"
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property Predeterminado As String
        Get
            Return _predeterminado
        End Get
        Set(value As String)
            _predeterminado = value
        End Set
    End Property

    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla
        End Get
        Set(value As Integer)
            _idplantilla = value
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
    Public Property PlantillaVidrio As Boolean
        Get
            Return _plantillavidrio
        End Get
        Set(value As Boolean)
            _plantillavidrio = value
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
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String, idplantilla As Integer,
                       dxf As String, predeterminado As String, plantillavidrio As Boolean, usuariomodificacion As String,
                       fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _idplantilla = idplantilla
            _dxf = Trim(dxf)
            _predeterminado = predeterminado
            _plantillavidrio = plantillavidrio
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class

