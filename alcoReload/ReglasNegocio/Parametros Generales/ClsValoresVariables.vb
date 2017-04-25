Imports Datos
Public Class ClsValoresVariables
#Region "Variables"
    Private tavaloresvariables As New dsbAlcoIngenieriaTableAdapters.ti024_valoresVariableTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar una nueva unidad de medida 
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="idvariable"></param>
    ''' <param name="valor"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, idvariable As Integer, valor As String,
                        valordefecto As Boolean, imprimir As Boolean, estado As Integer, descTecnica As String)
        Try

            tavaloresvariables.sp_ti024_insert(usuario, idvariable, valor, estado,
                                               valordefecto, imprimir, descTecnica)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar las unidades de medida existentes en el sistema
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="idvariable"></param>
    ''' <param name="valor"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, idvariable As Integer,
                         valor As String, valordefecto As Boolean, imprimir As Boolean, estado As Integer,
                         descTecnica As String)
        Try
            tavaloresvariables.sp_ti024_update(idvariable, valor, usuario,
                                               estado, valordefecto, imprimir, descTecnica, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las unidades de medida registradas en el sistema
    ''' </summary>
    ''' <returns></returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of ValorVariable)
        TraerTodos = New List(Of ValorVariable)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti024_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti024_selectAllDataTable = taAll.GetData()
            For Each vv As dsbAlcoIngenieria.sp_ti024_selectAllRow In txAll
                TraerTodos.Add(New ValorVariable(vv.Id, vv.Usuario_Creacion, vv.Fecha_Creacion, vv.Id_Variable, vv.Variable,
                                                 vv.Valor, vv.Valor_Predet, vv.imprimir, vv.Usuario_Modi, vv.Fecha_Modi, vv.Id_Estado, vv.Estado, vv.Desc_Tecnica))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    ''' <summary>
    ''' Este procedimiento sirve para obtener unidades de medida filtradas por ID
    ''' </summary>
    ''' <param name="idvariable"></param>
    ''' <returns></returns>
    Public Function TraerxIdVariable(idvariable As Integer) As List(Of ValorVariable)
        TraerxIdVariable = New List(Of ValorVariable)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti024_selectbyIdVariableTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti024_selectbyIdVariableDataTable = taAll.GetData(idvariable)
            For Each vv As dsbAlcoIngenieria.sp_ti024_selectbyIdVariableRow In txAll
                TraerxIdVariable.Add(New ValorVariable(vv.fi024_rowid, vv.fi024_usuarioCreacion,
                                                 vv.fi024_fechaCreacion, vv.fi024_rowidVariable,
                                                 vv.fi006_nombreVariable, vv.fi024_valorVariable,
                                                 vv.fì024_valordefecto, vv.fi024_imprimir,
                                                 vv.fi024_usuarioModificacion, vv.fi024_fechaModificacion,
                                                 vv.fi024_rowidEstado, vv.fi001_Descripcion, vv.fi024_DescTecnica))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class

Public Class ValorVariable
    Inherits ClsBaseParametros

#Region "Variables"

    Private _idvariable As Integer = 0
    Private _variable As String = String.Empty
    Private _valor As String = String.Empty
    Private _valorxdefecto As Boolean = False
    Private _imprimir As Boolean = False
#End Region

#Region "Propiedades"

    Public Property Idvariable As Integer
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

    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(value As String)
            _valor = value
        End Set
    End Property

    Public Property ValorporDefecto As Boolean
        Get
            Return _valorxdefecto
        End Get
        Set(value As Boolean)
            _valorxdefecto = value
        End Set
    End Property

    Public Property Imprimir As Boolean
        Get
            Return _imprimir
        End Get
        Set(value As Boolean)
            _imprimir = value
        End Set
    End Property
    Private _descTecnica As String
    Public Property DescTecnica() As String
        Get
            Return _descTecnica
        End Get
        Set(ByVal value As String)
            _descTecnica = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idvariable As Integer,
                   variable As String, valor As String, valordefecto As Boolean, imprimir As Boolean,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer, estado As String, descTecnica As String)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idvariable = idvariable
            _variable = Trim(variable)
            _valor = Trim(valor)
            _valorxdefecto = valordefecto
            _imprimir = imprimir
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
            _descTecnica = descTecnica.Trim
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

End Class
