Imports Datos
Public Class ClsPropiedadesMasicas

#Region "Variables"
    Private tapropiedades As New dsbAlcoIngenieriaTableAdapters.ti032_propiedadesMasicasTableAdapter
#End Region
    Public Function Insertar(usuario As String, nombre As String, descripcion As String, inercia As Decimal,
                        moduloseccion As Decimal, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(tapropiedades.Insertar(usuario, nombre, descripcion, inercia, moduloseccion, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, usuario As String, nombre As String, descripcion As String, inercia As Decimal,
                        moduloseccion As Decimal, estado As Integer)
        Try
            tapropiedades.sp_ti032_update(id, usuario, nombre, descripcion, inercia, moduloseccion, estado)
            'tapropiedades.Update(nombre, descripcion, inercia, moduloseccion, usuario, estado, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of PropiedadMasica)
        TraerTodos = New List(Of PropiedadMasica)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti032_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti032_selectAllDataTable = taAll.GetData()
            For Each pm As dsbAlcoIngenieria.sp_ti032_selectAllRow In txAll
                TraerTodos.Add(New PropiedadMasica(pm.Id, pm.Usuario_Creacion, pm.Fecha_Creacion, pm.Nombre, pm.Descripcion,
                                                   pm.Inercia, pm.Modulo_Seccion, pm.Usuario_Modi, pm.Fecha_Modi,
                                                   pm.Id_Estado, pm.Estado))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporId(id As Integer) As PropiedadMasica
        TraerporId = New PropiedadMasica
        Try
            Dim txid As dsbAlcoIngenieria.ti032_propiedadesMasicasDataTable = tapropiedades.TraerporId(id)
            If (txid.Rows.Count > 0) Then
                Dim pm As dsbAlcoIngenieria.ti032_propiedadesMasicasRow = txid(0)
                TraerporId = New PropiedadMasica(pm.fi032_rowid, pm.fi032_usuariocreacion, pm.fi032_fechacreacion, pm.fi032_nombre, pm.fi032_descripcion, pm.fi032_inercia,
                                                   pm.fi032_moduloseccion, pm.fi032_usuariomodificacion, pm.fi032_fechamodificacion, pm.fi032_estado, String.Empty)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporEstado(estado As Integer) As List(Of PropiedadMasica)
        TraerporEstado = New List(Of PropiedadMasica)
        Try
            Dim txestado As dsbAlcoIngenieria.ti032_propiedadesMasicasDataTable = tapropiedades.TraerporEstado(estado)
            For Each pm As dsbAlcoIngenieria.ti032_propiedadesMasicasRow In txestado.Rows
                TraerporEstado.Add(New PropiedadMasica(pm.fi032_rowid, pm.fi032_usuariocreacion, pm.fi032_fechacreacion, pm.fi032_nombre, pm.fi032_descripcion, pm.fi032_inercia,
                                                   pm.fi032_moduloseccion, pm.fi032_usuariomodificacion, pm.fi032_fechamodificacion, pm.fi032_estado, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class PropiedadMasica
    Inherits ClsBaseParametros

#Region "Variables"
    Private _nombre As String
    Private _descripcion As String
    Private _inercia As Decimal
    Private _moduloseccion As Decimal
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
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property
    Public Property Inercia As Decimal
        Get
            Return _inercia
        End Get
        Set(value As Decimal)
            _inercia = value
        End Set
    End Property
    Public Property ModuloSeccion As Decimal
        Get
            Return _moduloseccion
        End Get
        Set(value As Decimal)
            _moduloseccion = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As DateTime,
                   nombre As String, descripcion As String, inercia As Decimal, moduloseccion As Decimal,
               usuariomodificaicon As String, fechamodificacion As DateTime, idestado As Integer, estado As String)
        Me.Id = id
        _nombre = Trim(nombre)
        _descripcion = Trim(descripcion)
        _inercia = inercia
        _moduloseccion = moduloseccion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        Me.FechaCreacion = fechacreacion
        Me.UsuarioModificacion = Trim(usuariomodificaicon)
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = idestado
        Me.Estado = Trim(estado)
    End Sub
#End Region

End Class
