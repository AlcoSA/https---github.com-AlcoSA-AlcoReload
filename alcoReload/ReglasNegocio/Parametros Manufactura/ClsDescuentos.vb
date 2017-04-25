Imports Datos
Public Class ClsDescuentos
#Region "Variables"
    Private tadescuento As New dsbAlcoIngenieriaTableAdapters.ti026_descuentosTableAdapter
#End Region

    Public Sub Insertar(descuento As String, descripcion As String,
                        usuario As String, estado As Integer)
        Try
            tadescuento.sp_ti026_insert(descuento, descripcion, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modificar(id As Integer, descuento As String, descripcion As String,
                    usuario As String, estado As Integer)
        Try
            tadescuento.sp_ti026_update(id, descuento, descripcion, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Descuento)
        TraerTodos = New List(Of Descuento)
        Try
            Dim tax As New dsbAlcoIngenieriaTableAdapters.sp_ti026_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti026_selectAllDataTable = tax.GetData()
            For Each d As dsbAlcoIngenieria.sp_ti026_selectAllRow In txAll.Rows
                TraerTodos.Add(New Descuento(d.Id, d.Descuento, d.Descripcion, d.Usuario_Creacion,
                                             d.Fecha_Creacion, d.Usuario_Modificacion,
                                             d.Fecha_Modificacion, d.Id_estado, d.Estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxEstado(estado As Integer) As List(Of Descuento)
        TraerxEstado = New List(Of Descuento)
        Try
            Dim tax As New dsbAlcoIngenieriaTableAdapters.sp_ti026_selectByEstadoTableAdapter
            Dim txestado As dsbAlcoIngenieria.sp_ti026_selectByEstadoDataTable = tax.GetData(estado)
            For Each d As dsbAlcoIngenieria.sp_ti026_selectByEstadoRow In txestado.Rows
                TraerxEstado.Add(New Descuento(d.Id, d.Descuento, d.Descripcion, d.Usuario_Creacion,
                                             d.Fecha_Creacion, d.Usuario_Modificacion,
                                             d.Fecha_Modificacion, d.Id_estado, d.Estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function ValidarDatos(descuento As String, descripcion As String, ByRef mensaje As String) As Boolean
        Try
            If String.IsNullOrEmpty(descuento) Then
                mensaje = "El dato descuento es obligatorio. Verifique la información" & vbCrLf
            End If
            If String.IsNullOrEmpty(descripcion) Then
                mensaje = "El descuento debe tener una descripción. Verifique la información" & vbCrLf
            End If
            Return String.IsNullOrEmpty(mensaje)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class Descuento
    Inherits ClsBaseParametros
#Region "Variables"
    Private _descuento As String = String.Empty
    Private _descripcion As String = String.Empty
#End Region
#Region "Propiedades"
    Public Property Descuento As String
        Get
            Return _descuento
        End Get
        Set(value As String)
            _descuento = value
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
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, descuento As String, descripcion As String,
                   usuariocreacion As String, fechacreacion As DateTime,
                   usuariomodificacion As String, fechamodificacion As DateTime,
                   idestado As Integer, estado As String)
        Me.Id = id
        _descuento = descuento
        _descripcion = descripcion
        Me.UsuarioCreacion = usuariocreacion
        Me.FechaCreacion = fechacreacion
        Me.UsuarioModificacion = usuariomodificacion
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = idestado
        Me.Estado = estado
    End Sub
#End Region
End Class
