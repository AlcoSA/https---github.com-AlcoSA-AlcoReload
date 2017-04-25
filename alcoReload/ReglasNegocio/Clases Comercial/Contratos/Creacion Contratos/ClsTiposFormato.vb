Imports Datos
Public Class ClsTiposFormato
#Region "Variables"
    Private tatformato As New dsAlcoContratosTableAdapters.tc080_tiposformatoTableAdapter
#End Region
#Region "Procedimientos"
    Public Sub Insertar(usuario As String, tipoformato As String, descripcion As String, idestado As Integer)
        Try
            tatformato.Insert(usuario, tipoformato, descripcion, idestado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub Modificar(id As Integer, usuario As String, tipoformato As String, descripcion As String, idestado As Integer)
        Try
            tatformato.Update(tipoformato, descripcion, usuario, idestado, id, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region

#Region "Funciones"
    Public Function TraerTodosTabla() As DataTable
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc080_selectAllTableAdapter
            Return ta.GetData()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerTodosLista() As List(Of TipoFormato)
        TraerTodosLista = New List(Of TipoFormato)()
        Try
            Dim ttf As dsAlcoContratos.tc080_tiposformatoDataTable = tatformato.GetData()
            For Each tf As dsAlcoContratos.tc080_tiposformatoRow In ttf.Rows
                TraerTodosLista.Add(New TipoFormato(tf.fc080_rowid, tf.fc080_fechacreacion, tf.fc080_usuariocreacion,
                                                    tf.fc080_tipoformato, tf.fc080_descripcion, tf.fc080_usuariomodificacion,
                                                    tf.fc080_fechamodificacion, tf.fc080_rowidestado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of TipoFormato)
        Try
            Return TraerTodosLista().Where(Function(x) x.IdEstado = estado).ToList()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class

Public Class TipoFormato : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set

    End Property
    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Sub New()
        Try
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Sub New(Id As Integer, FechaCreacion As DateTime, UsuarioCreacion As String, tipo As String,
           descripcion As String, UsuarioModi As String, FechaModi As DateTime, idEstado As Integer)
        Try
            Me.Id = Id
            Me.FechaCreacion = FechaCreacion
            Me.UsuarioCreacion = UsuarioCreacion
            _tipo = RTrim(tipo)
            _descripcion = RTrim(descripcion)
            Me.UsuarioModificacion = RTrim(UsuarioModi)
            Me.FechaModificacion = FechaModi
            Me.IdEstado = idEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
#End Region
End Class
