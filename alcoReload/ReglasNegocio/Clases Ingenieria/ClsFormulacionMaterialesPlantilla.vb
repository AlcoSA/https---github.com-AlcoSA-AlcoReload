Imports Datos
Public Class ClsFormulacionMaterialesPlantilla
#Region "Variables"
    Private taformulacionmateriales As New dsbAlcoIngenieriaTableAdapters.ti015_formulacionmaterialesplantillaTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva formulación asociada a las variables y los materiales
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="idmaterialmodelo"></param>
    ''' <param name="formula"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, idplantillamodelo As Integer, idmaterialmodelo As Integer, formula As Integer, estado As Integer)
        Try
            taformulacionmateriales.sp_ti015_insert(usuario, idplantillamodelo, idmaterialmodelo, formula, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las formulaciones de materiales registradas
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idplantillamodelo"></param>
    ''' <param name="idmaterialmodelo"></param>
    ''' <param name="formula"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idplantillamodelo As Integer, idmaterialmodelo As Integer, formula As Integer, estado As Integer)
        Try
            taformulacionmateriales.sp_ti015_updateById(idplantillamodelo, idmaterialmodelo, formula, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las formulaciones de materiales 
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos() As List(Of FormulacionPlantilla)
        Try
            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener formulaciones de materiales filtradas por un ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As FormulacionPlantilla
        Try

            Return Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class FormulacionPlantilla
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String = String.Empty
    Private _idplantilla As Integer = 0
    Private _plantillamodelo As String = String.Empty
    Private _idmaterial As Integer = 0
    Private _material As String = String.Empty
    Private _formula As String = String.Empty
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
    Public Property IdPlantilla As Integer
        Get
            Return _idplantilla
        End Get
        Set(value As Integer)
            _idplantilla = value
        End Set
    End Property
    Public Property PlantillaModelo As String
        Get
            Return _plantillamodelo
        End Get
        Set(value As String)
            _plantillamodelo = value
        End Set
    End Property
    Public Property IdMaterial As Integer
        Get
            Return _idmaterial
        End Get
        Set(value As Integer)
            _idmaterial = value
        End Set
    End Property
    Public Property Material As String
        Get
            Return _material
        End Get
        Set(value As String)
            _material = value
        End Set
    End Property

    Public Property Formula As String
        Get
            Return _formula
        End Get
        Set(value As String)
            _formula = value
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
                   plantilla As String, idvariable As Integer, variable As String, formula As String, usuariomodificacion As String,
                   fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _idplantilla = idplantilla
            _plantillamodelo = Trim(plantilla)
            _idmaterial = idvariable
            _formula = Trim(formula)
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
