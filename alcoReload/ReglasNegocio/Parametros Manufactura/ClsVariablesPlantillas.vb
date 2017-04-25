Imports Datos
Public Class ClsVariablesPlantillas
#Region "Variables"
    Private tavariablesPlantillas As New dsbAlcoIngenieriaTableAdapters.ti012_variablesplantillasTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para registrar una nueva variable de plantilla
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idplantilla"></param>
    ''' <param name="idvariable"></param>
    ''' <param name="vmaximo"></param>
    ''' <param name="vminimo"></param>
    ''' <param name="estado"></param>
    Public Function Ingresar(usuario As String, idplantilla As Integer, idvariable As Integer,
                        vmaximo As String, vminimo As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(tavariablesPlantillas.sp_ti012_insert(usuario, idplantilla,
                                                                      idvariable, vmaximo, vminimo,
                                                                      estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para actualizar una variable de plantilla registrada
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idplantilla"></param>
    ''' <param name="idvariable"></param>
    ''' <param name="vmaximo"></param>
    ''' <param name="vminimo"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idplantilla As Integer, idvariable As Integer, vmaximo As String, vminimo As String, estado As Integer)
        Try
            tavariablesPlantillas.sp_ti012_updatebyId(idplantilla, idvariable, vminimo, vmaximo, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            tavariablesPlantillas.sp_ti012_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las variables de plantilla existentes en el sistema
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos() As List(Of VariablePlantilla)
        TraerTodos = New List(Of VariablePlantilla)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti012_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti012_selectAllDataTable = taAll.GetData()
            For Each vp As dsbAlcoIngenieria.sp_ti012_selectAllRow In txall.Rows
                TraerTodos.Add(New VariablePlantilla(vp.Id, vp.Usuario_Creacion, vp.Fecha_Creacion, vp.Id_Plantilla, vp.Plantilla,
                                                     vp.Id_Variable, vp.Variable, DirectCast(vp.Tipo_Dato, ClsEnums.TiposDato), vp.Valor_Minimo, vp.Valor_Maximo, vp.descripcion,
                                                     vp.Usuario_Modificacion, vp.Fecha_Modificacion, vp.Id_Estado, vp.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener las variables de plantilla filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function TraerxId(id As Integer) As VariablePlantilla
        TraerxId = New VariablePlantilla()
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti012_selectByIdPlantillaTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti012_selectByIdPlantillaDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim vp As dsbAlcoIngenieria.sp_ti012_selectByIdPlantillaRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti012_selectByIdPlantillaRow)
                TraerxId = New VariablePlantilla(vp.Id, vp.Usuario_Creacion, vp.Fecha_Creacion, vp.Id_Plantilla, vp.Plantilla,
                                                     vp.Id_Variable, vp.Variable, DirectCast(vp.Tipo_Dato, ClsEnums.TiposDato), vp.Valor_Minimo, vp.Valor_Maximo, vp.descripcion,
                                                     vp.Usuario_Modificacion, vp.Fecha_Modificacion, vp.Id_Estado, vp.Estado)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para validar la información ingresada
    ''' </summary>
    ''' <param name="idvariables"></param>
    ''' <param name="mensaje"></param>
    ''' <returns></returns>
    Public Function ValidarDatos(idvariables As List(Of Integer), ByRef mensaje As String) As Boolean
        Try
            For i = 0 To idvariables.Count - 1
                If idvariables(i) <= 0 Then
                    mensaje += vbCrLf & "La variable, es un dato obligatorio: Variable [" & i + 1 & "]."
                End If
            Next
            Return String.IsNullOrEmpty(mensaje)

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


    Public Function TraerxIdPlantilla(idplantilla As Integer) As List(Of VariablePlantilla)
        TraerxIdPlantilla = New List(Of VariablePlantilla)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti012_selectByIdPlantillaTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti012_selectByIdPlantillaDataTable = taAll.GetData(idplantilla)
            For Each vp As dsbAlcoIngenieria.sp_ti012_selectByIdPlantillaRow In txall.Rows
                TraerxIdPlantilla.Add(New VariablePlantilla(vp.Id, vp.Usuario_Creacion, vp.Fecha_Creacion, vp.Id_Plantilla, vp.Plantilla,
                                                     vp.Id_Variable, vp.Variable, DirectCast(vp.Tipo_Dato, ClsEnums.TiposDato), vp.Valor_Minimo, vp.Valor_Maximo, vp.descripcion, vp.Base_Datos,
                                                     vp.Usuario_Modificacion, vp.Fecha_Modificacion, vp.Id_Estado, vp.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class VariablePlantilla
    Inherits ClsBaseParametros
#Region "Variables"

    Private _idplantillamodelo As Integer = 0
    Private _plantillamodelo As String = String.Empty
    Private _idvariable As Integer = 0
    Private _variable As String = String.Empty
    Private _idtipodato As ClsEnums.TiposDato
    Private _valorminimo As String = String.Empty
    Private _valormaximo As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _basedatos As Boolean = False

#End Region
#Region "Propiedades"

    Public Property IdPlantillaModelo As Integer
        Get
            Return _idplantillamodelo
        End Get
        Set(value As Integer)
            _idplantillamodelo = value
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

    Public Property IdVariable As Integer
        Get
            Return _idvariable
        End Get
        Set(value As Integer)
            _idvariable = value
        End Set
    End Property

    Public Property Variable As String
        Get
            Return _variable
        End Get
        Set(value As String)
            _variable = value
        End Set
    End Property

    Public Property TipoDato As ClsEnums.TiposDato
        Get
            Return _idtipodato
        End Get
        Set(value As ClsEnums.TiposDato)
            _idtipodato = value
        End Set
    End Property

    Public Property ValorMinimo As String
        Get
            Return _valorminimo
        End Get
        Set(value As String)
            _valorminimo = value
        End Set
    End Property

    Public Property ValorMaximo As String
        Get
            Return _valormaximo
        End Get
        Set(value As String)
            _valormaximo = value
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

    Public Property BaseDatos As Boolean
        Get
            Return _basedatos
        End Get
        Set(value As Boolean)
            _basedatos = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idplantillamodelo As Integer, plantillamodelo As String,
                   idvariable As Integer, variable As String, idtipodato As ClsEnums.TiposDato, valorminimo As String, valormaximo As String, descripcion As String,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idplantillamodelo = idplantillamodelo
            _plantillamodelo = plantillamodelo
            _idvariable = idvariable
            _variable = Trim(variable)
            _idtipodato = idtipodato
            _valorminimo = Trim(valorminimo)
            _valormaximo = Trim(valormaximo)
            _descripcion = Trim(descripcion)
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub


    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idplantillamodelo As Integer, plantillamodelo As String,
               idvariable As Integer, variable As String, idtipodato As ClsEnums.TiposDato, valorminimo As String, valormaximo As String, descripcion As String, basedatos As Boolean,
               usuariomodificacion As String, fechamodificacion As Date, idestado As Integer, estado As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idplantillamodelo = idplantillamodelo
            _plantillamodelo = plantillamodelo
            _idvariable = idvariable
            _variable = Trim(variable)
            _idtipodato = idtipodato
            _valorminimo = Trim(valorminimo)
            _valormaximo = Trim(valormaximo)
            _descripcion = Trim(descripcion)
            _basedatos = basedatos
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
