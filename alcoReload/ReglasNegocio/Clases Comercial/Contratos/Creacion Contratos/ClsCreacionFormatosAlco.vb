Imports Datos
Public Class ClsCreacionFormatosAlco
#Region "Variables"
    Private objContrato As New dsAlcoContratosTableAdapters.tc069_formcontratosTableAdapter
#End Region
#Region "Procedimientos"
    Public Function insertar(tipoformato As Integer, nombreArchivo As String, cuerpo As String, encabezado As String,
                        piedepagina As String, altoEncabe As Decimal, altopiepagina As Decimal,
                        usuarioCreacion As String) As Object
        Try
            insertar = objContrato.sp_tc069_insert(tipoformato, nombreArchivo, cuerpo, encabezado, piedepagina, altoEncabe, altopiepagina, usuarioCreacion)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub update(id As Integer, idtipoformato As Integer, nombreArchivo As String, cuerpo As String,
                      encabezado As String, piedepagina As String, altoEncabe As Decimal,
                      altopiepagina As Decimal, usuarioModi As String)
        Try
            objContrato.sp_tc069_update(id, idtipoformato, nombreArchivo, cuerpo, encabezado, piedepagina, altoEncabe,
                                        altopiepagina, usuarioModi)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub


#End Region
#Region "Funciones"

    Public Function traerTodos() As List(Of Formato)
        traerTodos = New List(Of Formato)
        Try
            Dim ta As New dsAlcoContratosTableAdapters.sp_tc069_selectAllTableAdapter
            Dim td As dsAlcoContratos.sp_tc069_selectAllDataTable = ta.GetData()
            If td.Rows.Count > 0 Then
                For Each f As dsAlcoContratos.sp_tc069_selectAllRow In td.Rows
                    traerTodos.Add(New Formato(f.id, f.IdTipoFormato, f.TipoFormato, f.NombreArchivo, f.Cuerpo, f.Encabezado,
                                                       f.PiePagina, f.altoEncabezado, f.altoPiePagina, f.UsuarioCreacion, f.FechaCreacion,
                                                       f.UsuarioModi, f.FechaModi))
                Next
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerXId(id As Integer) As Formato
        TraerXId = New Formato
        Try
            TraerXId = DirectCast(traerTodos().FirstOrDefault(Function(a) a.Id = id), Formato)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporTipoFormato(idtipoformato As Integer) As List(Of Formato)
        Try
            Return traerTodos().Where(Function(x) x.IdTipoFormato = idtipoformato).ToList()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
Public Class Formato : Inherits ClsBaseParametros
#Region "Propiedades"
    Private _idtipoformato As Integer
    Public Property IdTipoFormato As Integer
        Get
            Return _idtipoformato
        End Get
        Set(value As Integer)
            _idtipoformato = value
        End Set
    End Property
    Private _tipoformato As String
    Public Property TipoFormato As String
        Get
            Return _tipoformato
        End Get
        Set(value As String)
            _tipoformato = value
        End Set
    End Property
    Private _nombreArchivo As String
    Public Property nombreArchivo() As String
        Get
            Return _nombreArchivo
        End Get
        Set(ByVal value As String)
            _nombreArchivo = value
        End Set
    End Property
    Private _cuerpo As String
    Public Property cuerpo() As String
        Get
            Return _cuerpo
        End Get
        Set(ByVal value As String)
            _cuerpo = value
        End Set
    End Property
    Private _encabezado As String
    Public Property encabezado() As String
        Get
            Return _encabezado
        End Get
        Set(ByVal value As String)
            _encabezado = value
        End Set
    End Property
    Private _piePagina As String
    Public Property piepagina() As String
        Get
            Return _piePagina
        End Get
        Set(ByVal value As String)
            _piePagina = value
        End Set
    End Property
    Private _altoEncabezado As Decimal
    Public Property AltoEncabezado() As Decimal
        Get
            Return _altoEncabezado
        End Get
        Set(ByVal value As Decimal)
            _altoEncabezado = value
        End Set
    End Property
    Private _altoPiePagina As Decimal
    Public Property AltoPiePagina() As Decimal
        Get
            Return _altoPiePagina
        End Get
        Set(ByVal value As Decimal)
            _altoPiePagina = value
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
    Public Sub New(id As Integer, idtipoformato As Integer, tipoformato As String, nombreArchivo As String, cuerpo As String, encabezado As String,
                   piepagina As String, altoEncabe As Decimal, altoPiePagina As Decimal,
                   usuarioCreacion As String, fechaCreacion As DateTime, UsuarioModi As String,
                   fechaModi As DateTime)
        Me.Id = id
        _idtipoformato = idtipoformato
        _tipoformato = tipoformato
        _nombreArchivo = nombreArchivo
        _cuerpo = cuerpo
        _encabezado = encabezado
        _piePagina = piepagina
        _altoEncabezado = altoEncabe
        _altoPiePagina = altoPiePagina
        Me.UsuarioCreacion = usuarioCreacion
        Me.FechaCreacion = fechaCreacion
        Me.UsuarioModificacion = UsuarioModi
        Me.FechaCreacion = fechaCreacion
    End Sub
#End Region
End Class
