Imports Datos
Public Class ClsDescuentosGlobales
#Region "Variables"
    Private tadescuentoGlobal As New dsbAlcoIngenieriaTableAdapters.ti028_descuentosGlobalesPlantillaTableAdapter
#End Region
    Public Function Insertar(idPlantillaModelo As Integer, iddescuento As Integer, valor As String,
                             usuario As String, estado As Integer) As Integer
        Try
            Return Convert.ToInt32(tadescuentoGlobal.sp_ti028_insert(idPlantillaModelo, iddescuento, valor, usuario, estado))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, idPlantillaModelo As Integer, iddescuento As Integer, valor As String,
                             usuario As String, estado As Integer)
        Try
            tadescuentoGlobal.sp_ti028_update(id, idPlantillaModelo, iddescuento, valor, usuario, estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxId(id As Integer)
        Try
            tadescuentoGlobal.sp_ti028_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerTodos() As List(Of descuentoGlobal)
        TraerTodos = New List(Of descuentoGlobal)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti028_selectAllTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti028_selectAllDataTable = taAll.GetData()
            For Each d As dsbAlcoIngenieria.sp_ti028_selectAllRow In txall.Rows
                TraerTodos.Add(New descuentoGlobal(d.id, d.id_plantilla, d.id_descuento, d.descuento, If(d.valor.StartsWith("="), d.valor, ""),
                                                     If(d.valor.StartsWith("="), 0, Convert.ToDecimal(d.valor)), d.usuario_creacion, d.fecha_creacion,
                                                   d.usuario_modificacion, d.fecha_modificacion, d.id_estado, d.estado))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Function TraerxIdPlantilla(idmaterial As Integer) As List(Of descuentoGlobal)
        TraerxIdPlantilla = New List(Of descuentoGlobal)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti028_selectByIdPlantillaModeloTableAdapter
            Dim txall As dsbAlcoIngenieria.sp_ti028_selectByIdPlantillaModeloDataTable = taAll.GetData(idmaterial)
            For Each d As dsbAlcoIngenieria.sp_ti028_selectByIdPlantillaModeloRow In txall.Rows
                TraerxIdPlantilla.Add(New descuentoGlobal(d.id, d.id_PlantillaModelo, d.id_descuento, d.descuento, If(d.valor.StartsWith("="), d.valor, ""),
                                                     If(d.valor.StartsWith("="), 0, Convert.ToDecimal(d.valor)), d.usuario_creacion, d.fecha_creacion, d.usuario_modificacion,
                                                     d.fecha_modificacion, d.id_estado, d.estado))
            Next
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
End Class
Public Class descuentoGlobal
    Inherits ClsBaseParametros
#Region "Variables"
    Protected _idPlantilla As Integer
    Protected _iddescuento As Integer
    Protected _descuento As String
    Protected _formula As String
    Protected _valor As Decimal

#End Region
#Region "Propiedades"
    Public Property IdModelo As Integer
        Get
            Return _idPlantilla
        End Get
        Set(value As Integer)
            _idPlantilla = value
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
    Public Sub New(id As Integer, idModelo As Integer, iddescuento As Integer, descuento As String, formula As String)
        Me.Id = id
        _idPlantilla = idModelo
        _iddescuento = iddescuento
        _descuento = descuento
        _formula = formula
    End Sub

    Public Sub New(id As Integer, idPlantilla As Integer, iddescuento As Integer, descuento As String,
                   formula As String, valor As Decimal, usuariocreacion As String, fechacreacion As DateTime,
                   usuariomodificaicon As String, fechamodificacion As DateTime,
                   idestado As Integer, estado As String)
        Me.Id = id
        _idPlantilla = idPlantilla
        _iddescuento = iddescuento
        _descuento = Trim(descuento)
        _formula = Trim(_formula)
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
