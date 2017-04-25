Imports Datos
Public Class ClsDescuentosMaterial
#Region "Variables"
    Private tadescuentomaterial As New dsbAlcoIngenieriaTableAdapters.ti027_descuentosmaterialesplantillaTableAdapter
#End Region

    Public Function Insertar(idmaterial As Integer, iddescuento As Integer, valor As String,
                             usuario As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(tadescuentomaterial.sp_ti027_insert(idmaterial, iddescuento, valor, usuario, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, idmaterial As Integer, iddescuento As Integer, valor As String,
                             usuario As String, estado As Integer)
        Try
            tadescuentomaterial.sp_ti027_update(id, idmaterial, iddescuento, valor, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxIdMaterial(idmaterial As Integer)
        Try
            tadescuentomaterial.BorrarporIdmaterial(idmaterial)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub EliminarxId(id As Integer)
        Try
            tadescuentomaterial.sp_ti027_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos() As List(Of DescuentoMaterial)
        TraerTodos = New List(Of DescuentoMaterial)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti027_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti027_selectAllDataTable = taAll.GetData()
            For Each d As dsbAlcoIngenieria.sp_ti027_selectAllRow In txall.Rows
                TraerTodos.Add(New DescuentoMaterial(d.id, d.id_material, d.id_descuento, d.descuento,
                                                     If(d.valor.StartsWith("="), d.valor, String.Empty),
                                                     If(d.valor.StartsWith("="), 0, CDec(d.valor)),
                                                     d.usuario_creacion, d.fecha_creacion, d.usuario_modificacion,
                                                     d.fecha_modificacion, d.id_estado, d.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxIdmaterial(idmaterial As Integer) As List(Of DescuentoMaterial)
        TraerxIdmaterial = New List(Of DescuentoMaterial)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti027_selectByIdMaterialTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti027_selectByIdMaterialDataTable = taAll.GetData(idmaterial)
            For Each d As dsbAlcoIngenieria.sp_ti027_selectByIdMaterialRow In txall.Rows
                TraerxIdmaterial.Add(New DescuentoMaterial(d.id, d.id_material, d.id_descuento, d.descuento,
                                                            If(d.valor.StartsWith("="), d.valor, String.Empty),
                                                            If(d.valor.StartsWith("="), 0, CDec(d.valor)),
                                                            d.usuario_creacion, d.fecha_creacion, d.usuario_modificacion,
                                                            d.fecha_modificacion, d.id_estado, d.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class

Public Class DescuentoMaterial
    Inherits ClsBaseParametros
#Region "Variables"
    Private _idmaterial As Integer
    Private _iddescuento As Integer
    Private _descuento As String
    Private _valor As Decimal
    Private _formula As String
#End Region
#Region "Propiedades"
    Public Property IdMaterial As Integer
        Get
            Return _idmaterial
        End Get
        Set(value As Integer)
            _idmaterial = value
        End Set
    End Property
    Public Property IdDescuento As Integer
        Get
            Return _iddescuento
        End Get
        Set(value As Integer)
            _iddescuento = value
        End Set
    End Property
    Public Property Descuento As String
        Get
            Return _descuento
        End Get
        Set(value As String)
            _descuento = value
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
    Public Property Valor As Decimal
        Get
            Return _valor
        End Get
        Set(value As Decimal)
            _valor = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, iddescuento As Integer, descuento As String, formula As String, valor As Decimal)
        Me.Id = id
        _iddescuento = iddescuento
        _descuento = descuento
        _valor = valor
    End Sub
    Public Sub New(id As Integer, idmaterial As Integer, iddescuento As Integer, descuento As String,
                   formula As String, valor As Decimal,
                   usuariocreacion As String, fechacreacion As DateTime,
                   usuariomodificaicon As String, fechamodificacion As DateTime,
                   idestado As Integer, estado As String)
        Me.Id = id
        _iddescuento = iddescuento
        _descuento = Trim(descuento)
        _formula = Trim(formula)
        _valor = valor
        Me.UsuarioCreacion = Trim(usuariocreacion)
        Me.FechaCreacion = fechacreacion
        Me.UsuarioModificacion = Trim(usuariomodificaicon)
        Me.FechaModificacion = fechamodificacion
        Me.IdEstado = idestado
        Me.Estado = estado
    End Sub
#End Region
End Class
