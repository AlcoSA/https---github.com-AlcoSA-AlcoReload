Imports Datos
Public Class ClsTercerosUnoee

    Public Function TraerInfoTerceroxNit(nit As String) As TerceroUnoee
        Try
            Dim tainfo As New dsBUnoeeTableAdapters.alco_direccionTelefonoTerceroxNitTableAdapter
            Dim txTipo As dsBUnoee.alco_direccionTelefonoTerceroxNitDataTable = tainfo.GetData(nit)
            Dim inft As dsBUnoee.alco_direccionTelefonoTerceroxNitRow = tainfo.GetData(nit).FirstOrDefault()
            If inft IsNot Nothing Then
                Return New TerceroUnoee(inft.f015_telefono, inft.f015_direccion1)
            Else
                Return New TerceroUnoee()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerInfoTerceroxNit(nit As String, sucursal As String) As String
        Try
            Dim tainfo As New dsBUnoeeTableAdapters.sp_t200_Unoee_select_IdcondpagoTableAdapter
            Return Convert.ToString(tainfo.Fill(nit, sucursal))

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class

Public Class TerceroUnoee
#Region "Variables"
    Private _telefono As String
    Private _direccion As String
#End Region
#Region "Propiedades"
    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property
    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(telefono As String, direccion As String)
        _telefono = RTrim(telefono)
        _direccion = RTrim(direccion)
    End Sub
#End Region
End Class
