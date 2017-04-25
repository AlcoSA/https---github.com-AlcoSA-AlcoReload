Imports Datos
Public Class ClsValoresParametrosInforme
#Region "vars"
    Private tapar As New dsGeneralesAplicacionTableAdapters.tg021_valorparametrosinformeTableAdapter
#End Region
    Public Function Insertar(idparametro As Integer, idinformepersonalizado As Integer, valor As String) As Integer
        Try
            Return Convert.ToInt32(tapar.sp_tg021_insert(idparametro, idinformepersonalizado, valor))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, idparametro As Integer, idinformepersonalizado As Integer, valor As String)
        Try
            tapar.sp_tg021_update(id, idparametro, idinformepersonalizado, valor)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Function TraerxIdInformeBase(idinformebase As Integer) As List(Of ValorParametroInforme)
        TraerxIdInformeBase = New List(Of ValorParametroInforme)
        Try
            Dim tap As New dsGeneralesAplicacionTableAdapters.sp_tg021_selectByIdInformeTableAdapter
            Dim tp As dsGeneralesAplicacion.sp_tg021_selectByIdInformeDataTable = tap.GetData(idinformebase)
            For Each p As dsGeneralesAplicacion.sp_tg021_selectByIdInformeRow In tp.Rows
                TraerxIdInformeBase.Add(New ValorParametroInforme(p.fg021_rowid, p.fg021_rowidparametro, p.fg021_rowidinformepersonalizado,
                                                                  p.fg017_tipodato, p.fg017_nombrebd, p.fg017_nombre, p.fg021_valor))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
End Class
Public Class ValorParametroInforme
    Inherits ParametroInforme
#Region "vars"
    Protected _idparametro As Integer = 0
    Protected _valor As String = String.Empty
#End Region
#Region "props"
    Public Property IdParametro As Integer
        Get
            Return _idparametro
        End Get
        Set(value As Integer)
            _idparametro = value
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
#End Region
#Region "ctor"
    Public Sub New()

    End Sub
    Public Sub New(id As Integer, idparametro As Integer, idinforme As Integer, tipodato As Integer,
                   nombrebd As String, nombre As String, valor As String)
        Me.Id = id
        _idparametro = idparametro
        _idinforme = idinforme
        _tipodato = DirectCast(tipodato, ClsEnums.TiposDato)
        _nombrebd = Trim(nombrebd)
        _nombre = Trim(nombre)
        _valor = Trim(valor)
    End Sub
#End Region
End Class
