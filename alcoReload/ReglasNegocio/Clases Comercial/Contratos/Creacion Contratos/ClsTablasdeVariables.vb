Imports Datos
Public Class ClsTablasdeVariables
#Region "Variables"
    Private _objParametrosContrato As New dsEsquemasContratosTableAdapters.sp_tc039_ParametrosContratoTableAdapter
    Private _objParametrosCotizacion As New dsEsquemasContratosTableAdapters.sp_tc016_ParametrosCotizacionTableAdapter

#End Region
#Region "Propiedades"
    Private _ConjuntoTablas As DataSet
    Public Property ConjuntoTablas() As DataSet
        Get
            Return crearDataset()
        End Get
        Set(ByVal value As DataSet)
            _ConjuntoTablas = value
        End Set
    End Property
#End Region
#Region "Funciones"
    Private Function parametrosContratos() As DataTable
        parametrosContratos = Nothing
        Try
            parametrosContratos = _objParametrosContrato.GetData().CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try

    End Function
    Private Function parametrosCotizacion() As DataTable
        parametrosCotizacion = Nothing
        Try
            parametrosCotizacion = _objParametrosCotizacion.GetData().CopyToDataTable
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Private Function crearDataset() As DataSet
        crearDataset = New DataSet
        Try
            crearDataset.Tables.Add(parametrosContratos())
            crearDataset.Tables.Add(parametrosCotizacion())
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class



