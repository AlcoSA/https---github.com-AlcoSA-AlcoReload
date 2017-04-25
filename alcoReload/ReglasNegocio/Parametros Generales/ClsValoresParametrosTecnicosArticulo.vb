Imports Datos
Public Class ClsValoresParametrosTecnicosArticulo

#Region "Variables"
    Private tavalor As New dsbAlcoIngenieriaTableAdapters.ti030_valoresParametrosTecnicosArticuloTableAdapter
#End Region

#Region "Procedimientos"

    Public Sub Ingresar(usuario As String, idparametro As Integer, idarticulo As Integer, valor As Decimal)
        Try
            tavalor.sp_ti030_insert(usuario, idparametro, idarticulo, valor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub Modifcar(id As Integer, usuario As String, idparametro As Integer, idarticulo As Integer, valor As Decimal)
        Try
            tavalor.sp_ti030_update(id, usuario, idparametro, idarticulo, valor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of ValorParametroTecnicoArticulo)
        TraerTodos = New List(Of ValorParametroTecnicoArticulo)()
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti030_selectAllTableAdapter
            Dim txAll As dsbAlcoIngenieria.sp_ti030_selectAllDataTable = taAll.GetData()
            For Each ti As dsbAlcoIngenieria.sp_ti030_selectAllRow In txAll
                TraerTodos.Add(New ValorParametroTecnicoArticulo(ti.Id, ti.Usuario_Creacion, ti.Fecha_Creacion, ti.Id_Parametro,
                                                                 ti.Parametro, ti.Id_Articulo, ti.Artculo, ti.Valor, ti.Usuario_Modi,
                                                                 ti.Fecha_Modi))
            Next
            If txAll.Rows.Count > 0 Then
                dt = txAll.CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdArticulo(idarticulo As Integer) As List(Of ParametrosTecnicosArticulo)
        TraerxIdArticulo = New List(Of ParametrosTecnicosArticulo)()
        Try
            Dim tall As New dsbAlcoIngenieriaTableAdapters.sp_ti030_selectByIdArticuloTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti030_selectByIdArticuloDataTable = tall.GetData(idarticulo)
            For Each pta As dsbAlcoIngenieria.ti030_valoresParametrosTecnicosArticuloRow In txall.Rows
                TraerTodos.Add(New ValorParametroTecnicoArticulo(pta.fi030_rowid, pta.fi030_usuariocreacion,
                                                              pta.fi030_fechacreacion, pta.fi030_rowidparametro, pta.ti029_parametrosTecnicosArticuloRow.fi029_nombre,
                                                                 pta.fi030_rowidarticulo, pta.ti017_articulosRow.fi017_referencia, pta.fi030_valor,
                                                               pta.fi030_usuariomodificacion, pta.fi030_fechamodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class

Public Class ValorParametroTecnicoArticulo
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idparametro As Integer
    Private _parametro As String
    Private _idarticulo As Integer
    Private _articulo As String
    Private _valor As Decimal
#End Region
#Region "Propiedades"

    Public Property IdParametro As Integer
        Get
            Return _idparametro
        End Get
        Set(ByVal value As Integer)
            _idparametro = value
        End Set
    End Property

    Public Property Parametro As String
        Get
            Return _parametro
        End Get
        Set(ByVal value As String)
            _parametro = value
        End Set
    End Property

    Public Property IdArticulo As Integer
        Get
            Return _idarticulo
        End Get
        Set(ByVal value As Integer)
            _idarticulo = value
        End Set
    End Property

    Public Property Articulo As String
        Get
            Return _articulo
        End Get
        Set(ByVal value As String)
            _articulo = value
        End Set
    End Property

    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(ByVal value As Decimal)
            _valor = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, idparametro As Integer, parametro As String,
                   idarticulo As Integer, articulo As String, valor As Decimal,
                   usuariomodificacion As String, fechamodificacion As Date)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _idparametro = idparametro
            _parametro = Trim(parametro)
            _idarticulo = idarticulo
            _articulo = Trim(articulo)
            _valor = valor
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = IdEstado
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region
End Class