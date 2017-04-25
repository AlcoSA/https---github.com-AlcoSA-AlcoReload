Imports Datos
Public Class ClsCreacionVariablesEsquemas

#Region "Variables"
    Private _objVariables As New dsAlcoContratosTableAdapters.tc070_variablesesquemasTableAdapter

#End Region

#Region "Procedimientos"

    Public Sub Ingresar(nombreV As String, valorv As String, valors As String, idestado As Integer, usuarioCreacion As String)
        Try
            _objVariables.sp_tc070_insert(nombreV, valorv, valors, idestado, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(id As Integer, nombre As String, valor As String, valors As String, idestado As Integer, usuarioModi As String)
        Try
            _objVariables.sp_tc070_update(id, nombre, valor, valors, idestado, usuarioModi)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos() As List(Of variableEsquema)
        Try
            TraerTodos = New List(Of variableEsquema)
            Dim tb As dsAlcoContratos.tc070_variablesesquemasDataTable = _objVariables.GetData()
            For Each var As dsAlcoContratos.tc070_variablesesquemasRow In tb.Rows
                TraerTodos.Add(New variableEsquema(var.fc070_rowid, var.fc070_nombreVariable, var.fc070_valorVariable,
                                                   var.fc070_valorVarSistema, var.fc070_rowidestado, var.fc070_usuarioCreacion,
                                                   var.fc070_fechaCreacion, var.fc070_usuarioModi, var.fc070_fechaModi))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of variableEsquema)
        Try
            TraerporEstado = New List(Of variableEsquema)
            Dim tablaEstado = _objVariables.GetData().Where(Function(x) x.fc070_rowidestado = estado)
            For Each var As dsAlcoContratos.tc070_variablesesquemasRow In tablaEstado
                TraerTodos.Add(New variableEsquema(var.fc070_rowid, var.fc070_nombreVariable, var.fc070_valorVariable,
                                                   var.fc070_valorVarSistema, var.fc070_rowidestado, var.fc070_usuarioCreacion,
                                                   var.fc070_fechaCreacion, var.fc070_usuarioModi, var.fc070_fechaModi))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

#Region "Funciones"
    ''' <summary>
    ''' Funcion que devuelve todas las variables disponibles
    ''' </summary>
    ''' <returns></returns>
    Public Function selectAllVariables(Optional ByRef data As DataTable = Nothing) As List(Of variableEsquema)
        selectAllVariables = New List(Of variableEsquema)
        Try
            Dim tadp As New dsAlcoContratosTableAdapters.sp_tc070_selectAllTableAdapter
            Dim dt As dsAlcoContratos.sp_tc070_selectAllDataTable = tadp.GetData()
            If dt.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc070_selectAllRow In dt.Rows
                    selectAllVariables.Add(New variableEsquema(fila.Id, Trim(fila.NombreVariable), Trim(fila.ValorVariable), Trim(fila.ValorVarSistemas), fila.IdEstado,
                                                      Trim(fila.UsuarioCreacion), fila.FechaCreacion, Trim(fila.usuarioModi), fila.FechaModi))
                Next
                data = dt.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function selectByEstado(estado As Integer, Optional ByRef dt As DataTable = Nothing) As List(Of variableEsquema)
        selectByEstado = New List(Of variableEsquema)
        Try
            Dim tadp As New dsAlcoContratosTableAdapters.sp_tc070_selectByEstadoTableAdapter
            Dim te As dsAlcoContratos.sp_tc070_selectByEstadoDataTable = tadp.GetData(estado)
            If te.Rows.Count > 0 Then
                For Each fila As dsAlcoContratos.sp_tc070_selectByEstadoRow In te.Rows
                    selectByEstado.Add(New variableEsquema(fila.Id, Trim(fila.NombreVariable), Trim(fila.ValorVariable), Trim(fila.ValorVarSistemas), fila.IdEstado,
                                                      Trim(fila.UsuarioCreacion), fila.FechaCreacion, Trim(fila.usuarioModi), fila.FechaModi))
                Next
                dt = te.CopyToDataTable()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


#End Region

End Class
Public Class variableEsquema : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _nombreVariable As String
    Public Property nombreVariable() As String
        Get
            Return _nombreVariable
        End Get
        Set(ByVal value As String)
            _nombreVariable = value
        End Set
    End Property
    Private _valorVariable As String
    Public Property valorVariable() As String
        Get
            Return _valorVariable
        End Get
        Set(ByVal value As String)
            _valorVariable = value
        End Set
    End Property
    Private _valorSistema As String
    Public Property valorSistema() As String
        Get
            Return _valorSistema
        End Get
        Set(ByVal value As String)
            _valorSistema = value
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
    Public Sub New(id As Integer, nombreV As String, valorv As String, valors As String, idestado As Integer, usuarioCreacion As String,
                   fechaCreacion As DateTime, usuarioModi As String, fechaModi As DateTime)
        Try
            Me.Id = id
            _nombreVariable = nombreV
            _valorVariable = valorv
            _valorSistema = valors
            Me.IdEstado = idestado
            Me.UsuarioCreacion = usuarioCreacion
            Me.FechaCreacion = fechaCreacion
            Me.UsuarioModificacion = usuarioModi
            Me.FechaModificacion = fechaModi
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
