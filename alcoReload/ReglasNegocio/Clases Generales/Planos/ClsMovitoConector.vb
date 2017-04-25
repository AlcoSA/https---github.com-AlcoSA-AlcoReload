Imports Datos
Public Class ClsMovitoConector
#Region "Variables"
    Private _objMovito As New dsGeneralesAplicacionTableAdapters.tg012_movitoConectorTableAdapter
#End Region
#Region "Procedimientos"
    Public Function insertar(idConector As Integer, nombreCampo As String, descripcion As String, idTipoDato As Integer, observaciones As String,
                        indObligatorio As Boolean, posicionInicial As Integer, posicionFinal As Integer, longitud As Integer,
                        formato As String, valorDefecto As String, decimales As Integer, autoincremento As Boolean) As Integer
        Try
            Return Convert.ToInt32(_objMovito.sp_tg012_insert(idConector, nombreCampo, descripcion, idTipoDato, observaciones,
                                               indObligatorio, posicionInicial, posicionFinal,
                                               longitud, formato, valorDefecto, decimales, autoincremento))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub update(id As Integer, valorDefecto As String, decimales As Integer, autoincremento As Boolean)
        Try
            _objMovito.sp_tg012_update(id, valorDefecto, decimales, autoincremento)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function SelectAllByIdConector(idConector As Integer) As List(Of movitoConector)
        SelectAllByIdConector = New List(Of movitoConector)
        Try
            Dim ta As New dsGeneralesAplicacionTableAdapters.sp_tg012_selectAllByIdConectorTableAdapter
            Dim dt As dsGeneralesAplicacion.sp_tg012_selectAllByIdConectorDataTable = ta.GetData(idConector)
            If dt.Rows.Count > 0 Then
                dt.Rows.Cast(Of dsGeneralesAplicacion.sp_tg012_selectAllByIdConectorRow).ToList.ForEach(Sub(r)
                                                                                                            SelectAllByIdConector.Add(New movitoConector(r.id, r.IdConector, r.NombreCampo, r.Descripcion,
                                                                                                                                                         r.IdTipoDato, r.TipoDato, r.Observaciones, r.indObligatorio,
                                                                                                                                                         r.posicionInicial, r.posicionFinal, r.Longitud, r.Formato, If(IsDBNull(r.ValorPorDefecto),
                                                                                                                                                         String.Empty, r.ValorPorDefecto), r.Decimales, r.autoincremento))
                                                                                                        End Sub)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class movitoConector : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _idConector As Integer
    Public Property idConector() As Integer
        Get
            Return _idConector
        End Get
        Set(ByVal value As Integer)
            _idConector = value
        End Set
    End Property
    Private _nombreCampo As String
    Public Property NombreCampo() As String
        Get
            Return _nombreCampo
        End Get
        Set(ByVal value As String)
            _nombreCampo = value
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
    Private _idTipoDato As Integer
    Public Property idTipoDato() As Integer
        Get
            Return _idTipoDato
        End Get
        Set(ByVal value As Integer)
            _idTipoDato = value
        End Set
    End Property
    Private _tipoDato As String
    Public Property TipoDato() As String
        Get
            Return _tipoDato
        End Get
        Set(ByVal value As String)
            _tipoDato = value
        End Set
    End Property
    Private _observaciones As String
    Public Property Observaciones() As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property
    Private _indObligatorio As Boolean
    Public Property indObligatorio() As Boolean
        Get
            Return _indObligatorio
        End Get
        Set(ByVal value As Boolean)
            _indObligatorio = value
        End Set
    End Property
    Private _posicionInicial As Integer
    Public Property PosicionInicial() As Integer
        Get
            Return _posicionInicial
        End Get
        Set(ByVal value As Integer)
            _posicionInicial = value
        End Set
    End Property
    Private _posicionFinal As Integer
    Public Property posicionFinal() As Integer
        Get
            Return _posicionFinal
        End Get
        Set(ByVal value As Integer)
            _posicionFinal = value
        End Set
    End Property
    Private _longitud As Integer
    Public Property Longitud() As Integer
        Get
            Return _longitud
        End Get
        Set(ByVal value As Integer)
            _longitud = value
        End Set
    End Property
    Private _formato As String
    Public Property Formato() As String
        Get
            Return _formato
        End Get
        Set(ByVal value As String)
            _formato = value
        End Set
    End Property
    Private _valorDefecto As String
    Public Property ValorDefecto() As String
        Get
            Return _valorDefecto
        End Get
        Set(ByVal value As String)
            _valorDefecto = value
        End Set
    End Property
    Private _decimales As Integer
    Public Property Decimales() As Integer
        Get
            Return _decimales
        End Get
        Set(ByVal value As Integer)
            _decimales = value
        End Set
    End Property
    Private _autoincremento As Boolean
    Public Property Autoincremento As Boolean
        Get
            Return _autoincremento
        End Get
        Set(value As Boolean)
            _autoincremento = value
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
    Sub New(id As Integer, idConector As Integer, nombreCampo As String, descripciona As String, idTipoDato As Integer,
            tipoDato As String, observaciones As String, indObligatorio As Boolean, posicionInicial As Integer, posicionFinal As Single,
            longitud As Integer, formato As String, valorDefecto As String, decimales As Integer, autoincremento As Boolean)
        Me.Id = id
        _idConector = idConector
        _nombreCampo = Trim(nombreCampo)
        _descripcion = Trim(descripciona)
        _idTipoDato = idTipoDato
        _tipoDato = Trim(tipoDato)
        _observaciones = Trim(observaciones)
        _indObligatorio = indObligatorio
        _posicionInicial = posicionInicial
        _posicionFinal = _posicionFinal
        _longitud = longitud
        _formato = Trim(formato)
        _valorDefecto = Trim(valorDefecto)
        _decimales = decimales
        _autoincremento = autoincremento
    End Sub
#End Region
End Class
