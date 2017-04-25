Imports Datos
Public Class ClsFormatoOtrosi
#Region "Variables"
    Private tafo As New dsAlcoContratosTableAdapters.tc082_formatootrosiTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(idformato As Integer, idotrosi As Integer, usuario As String,
                             cuerpo As String, encabezado As String, piepagina As String,
                             altoencabezado As Decimal, altopiepagina As Decimal) As Integer
        Try
            Return Convert.ToInt32(tafo.sp_tc082_insert(idformato, idotrosi, usuario, cuerpo, encabezado, piepagina,
                                 altoencabezado, altopiepagina))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, idformato As Integer, idotrosi As Integer, usuario As String,
                             cuerpo As String, encabezado As String, piepagina As String,
                             altoencabezado As Decimal, altopiepagina As Decimal)
        Try
            tafo.sp_tc082_update(id, idformato, idotrosi, usuario, cuerpo, encabezado, piepagina,
                                 altoencabezado, altopiepagina)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdOtrosi(idotrosi As Integer) As FormatoOtrosi
        Try
            Dim tafco As New dsAlcoContratosTableAdapters.sp_tc082_selectByIdOtroSiTableAdapter
            Dim t As dsAlcoContratos.sp_tc082_selectByIdOtroSiDataTable = tafco.GetData(idotrosi)
            If t.Rows.Count > 0 Then
                Dim fc As dsAlcoContratos.sp_tc082_selectByIdOtroSiRow = DirectCast(t.Rows(0), dsAlcoContratos.sp_tc082_selectByIdOtroSiRow)
                Return New FormatoOtrosi(fc.fc082_rowid, fc.fc082_rowidformato, fc.fc082_rowidotrosi, fc.fc069_rowidtipoformato,
                                           fc.fc069_nombreArchivo, fc.fc082_cuerpo, fc.fc082_encabezado, fc.fc082_piedePagina,
                                           fc.fc082_altoEncabezado, fc.fc082_altoPiePagina, fc.fc082_usuarioCreacion,
                                           fc.fc082_fechaCreacion, fc.fc082_usuarioModi, fc.fc082_fechaModi)
            Else
                Return New FormatoOtrosi()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region
End Class
Public Class FormatoOtrosi
    Inherits Formato
#Region "Variables"
    Private _idformato As Integer = 0
    Private _idotrosi As Integer = 0
#End Region
#Region "Propiedades"
    Public Property IdFormato As Integer
        Get
            Return _idformato
        End Get
        Set(value As Integer)
            _idformato = value
        End Set
    End Property
    Public Property IdOtroSi As Integer
        Get
            Return _idotrosi
        End Get
        Set(value As Integer)
            _idotrosi = value
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
    Public Sub New(id As Integer, idformato As Integer, idotrosi As Integer, idtipoformato As Integer, nombreArchivo As String, cuerpo As String, encabezado As String,
                   piepagina As String, altoEncabe As Decimal, altoPiePagina As Decimal,
                   usuarioCreacion As String, fechaCreacion As DateTime, UsuarioModi As String,
                   fechaModi As DateTime)
        Me.Id = id
        _idformato = idformato
        _idotrosi = idotrosi
        Me.IdTipoFormato = idtipoformato
        Me.nombreArchivo = nombreArchivo
        Me.cuerpo = cuerpo
        Me.encabezado = encabezado
        Me.piepagina = piepagina
        AltoEncabezado = altoEncabe
        Me.AltoPiePagina = altoPiePagina
        Me.UsuarioCreacion = usuarioCreacion
        Me.FechaCreacion = fechaCreacion
        UsuarioModificacion = UsuarioModi
        Me.FechaCreacion = fechaCreacion
    End Sub
#End Region
End Class
