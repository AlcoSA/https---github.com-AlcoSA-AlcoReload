Imports Datos
Public Class ClsVariablesPlantillaCotiza
#Region "Variables"
    Private varia As New dsAlcoCotizacionesTableAdapters.tc035_ValoresVariablesPlantillaCotizaTableAdapter
#End Region
    Public Function Insertar(idhijocotiza As Integer, idvariable As Integer,
                             minimo As String, minimo_valor As String, maximo As String, maximo_valor As String,
                             valor As String, usuario As String) As Integer
        Try
            Return Convert.ToInt32(varia.sp_tc035_insert(idhijocotiza,
                                                         idvariable, usuario,
                                                         minimo, minimo_valor, maximo, maximo_valor, valor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, idhijocotiza As Integer, idvariable As Integer,
                             minimo As String, minimo_valor As String, maximo As String,
                         maximo_valor As String, valor As String, usuario As String)
        Try
            varia.sp_tc035_update(id, idhijocotiza, idvariable, usuario,
                                  minimo, minimo_valor, maximo, maximo_valor, valor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarxIdItemCotiza(idhijocotiza As Integer)
        Try
            varia.sp_tc035_deleteByItemCotiza(idhijocotiza)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerxIdItemCotiza(idhijocotiza As Integer) As List(Of VariableItemCotiza)
        TraerxIdItemCotiza = New List(Of VariableItemCotiza)
        Try
            Dim txa As New dsAlcoCotizacionesTableAdapters.sp_tc035_selectByIdItemCotizaTableAdapter
            Dim txall As dsAlcoCotizaciones.sp_tc035_selectByIdItemCotizaDataTable = txa.GetData(idhijocotiza)
            For Each vc As dsAlcoCotizaciones.sp_tc035_selectByIdItemCotizaRow In txall.Rows
                TraerxIdItemCotiza.Add(New VariableItemCotiza(vc.fc035_rowid, vc.fc035_rowidhijocotiza, vc.fc035_rowidvariable, vc.fi006_nombreVariable,
                                                              vc.fc035_minimo, vc.fc035_minimovalor, vc.fc035_maximo, vc.fc035_maximoValor, vc.fc035_valor, DirectCast(vc.fi006_rowIdtipoDeDato, ClsEnums.TiposDato),
                                                              vc.fi006_valordesdebd, vc.fi006_edicionproduccion, vc.fc035_usuariocreacion,
                                                              vc.fc035_fechacreacion, vc.fc035_usuariomodificacion, vc.fc035_fechamodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
Public Class VariableItemCotiza
    Inherits ClsBaseParametros
#Region "Variables"
    Private _iditemhijo As Integer
    Private _idvariable As Integer
    Private _nombrevariable As String
    Private _tipodato As ClsEnums.TiposDato
    Private _minimo As String
    Private _minimo_valor As String
    Private _maximo As String
    Private _maximo_valor As String
    Private _valor As String
    Private _desdebd As Boolean = False
    Private _edicion_produccion As Boolean = False
#End Region
#Region "Propiedades"
    Public Property IdItemCotiza As Integer
        Get
            Return _iditemhijo
        End Get
        Set(value As Integer)
            _iditemhijo = value
        End Set
    End Property
    Public Property IdVariable As Integer
        Get
            Return _idvariable
        End Get
        Set(value As Integer)
            _idvariable = value
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
    Public Property NombreVariable As String
        Get
            Return _nombrevariable
        End Get
        Set(value As String)
            _nombrevariable = value
        End Set
    End Property
    Public Property Minimo As String
        Get
            Return _minimo
        End Get
        Set(value As String)
            _minimo = value
        End Set
    End Property
    Public Property ValorMinimo As String
        Get
            Return _minimo_valor
        End Get
        Set(value As String)
            _minimo_valor = value
        End Set
    End Property
    Public Property Maximo As String
        Get
            Return _maximo
        End Get
        Set(value As String)
            _maximo = value
        End Set
    End Property
    Public Property ValorMaximo As String
        Get
            Return _maximo_valor
        End Get
        Set(value As String)
            _maximo_valor = value
        End Set
    End Property
    Public Property TipoDato As ClsEnums.TiposDato
        Get
            Return _tipodato
        End Get
        Set(value As ClsEnums.TiposDato)
            _tipodato = value
        End Set
    End Property
    Public Property DesdeBaseDatos As Boolean
        Get
            Return _desdebd
        End Get
        Set(value As Boolean)
            _desdebd = value
        End Set
    End Property
    Public Property EdicionProduccion As Boolean
        Get
            Return _edicion_produccion
        End Get
        Set(value As Boolean)
            _edicion_produccion = value
        End Set
    End Property
#End Region

#Region "Constructor"
    Public Sub New()
    End Sub

#End Region
    Public Sub New(id As Integer, iditemhijo As Integer, idvariable As Integer,
                   nombrevariable As String, minimo As String, minimo_valor As String,
                   maximo As String, maximo_valor As String, valor As String,
                   tipodato As ClsEnums.TiposDato, desdebd As Boolean, edicion_produccion As Boolean,
                   UsuarioCreacion As String, fechacreacion As Date,
                   usuariomodificaicon As String, fechamodificacion As Date)
        Me.Id = id
        _iditemhijo = iditemhijo
        _idvariable = idvariable
        _nombrevariable = Trim(nombrevariable)
        _minimo = Trim(minimo)
        _minimo_valor = Trim(minimo_valor)
        _maximo = Trim(maximo)
        _maximo_valor = Trim(maximo_valor)
        _valor = Trim(valor)
        _tipodato = tipodato
        _desdebd = desdebd
        _edicion_produccion = edicion_produccion
        Me.UsuarioCreacion = UsuarioCreacion
        Me.FechaCreacion = fechacreacion
        Me.UsuarioModificacion = usuariomodificaicon
        Me.FechaModificacion = fechamodificacion
    End Sub
End Class
