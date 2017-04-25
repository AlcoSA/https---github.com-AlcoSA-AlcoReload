Imports Datos
Public Class ClsFormatoContrato
#Region "Variables"
    Private tafc As New dsAlcoContratosTableAdapters.tc081_formatocontratoTableAdapter
#End Region
#Region "Procedimientos"
    Public Function Insertar(idformato As Integer, idcontrato As Integer, usuario As String,
                             cuerpo As String, encabezado As String, piepagina As String,
                             altoencabezado As Decimal, altopiepagina As Decimal) As Integer
        Try
            Return Convert.ToInt32(tafc.sp_tc081_insert(idformato, idcontrato, usuario, cuerpo, encabezado, piepagina,
                                 altoencabezado, altopiepagina))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, idformato As Integer, idcontrato As Integer, usuario As String,
                             cuerpo As String, encabezado As String, piepagina As String,
                             altoencabezado As Decimal, altopiepagina As Decimal)
        Try
            tafc.sp_tc081_update(id, idformato, idcontrato, usuario, cuerpo, encabezado, piepagina,
                                 altoencabezado, altopiepagina)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerporIdContrato(idcontrato As Integer) As FormatoContrato
        Try
            Dim tafco As New dsAlcoContratosTableAdapters.sp_tc081_selectByIdContratoTableAdapter
            Dim t As dsAlcoContratos.sp_tc081_selectByIdContratoDataTable = tafco.GetData(idcontrato)
            If t.Rows.Count > 0 Then
                Dim fc As dsAlcoContratos.sp_tc081_selectByIdContratoRow = DirectCast(t.Rows(0), dsAlcoContratos.sp_tc081_selectByIdContratoRow)
                Return New FormatoContrato(fc.fc081_rowid, fc.fc081_rowidformato, fc.fc081_rowidcontrato, fc.fc069_rowidtipoformato,
                                           fc.fc069_nombreArchivo, fc.fc081_cuerpo, fc.fc081_encabezado, fc.fc081_piedePagina,
                                           fc.fc081_altoEncabezado, fc.fc081_altoPiePagina, fc.fc081_usuarioCreacion,
                                           fc.fc081_fechaCreacion, fc.fc081_usuarioModi, fc.fc081_fechaModi)
            Else
                Return New FormatoContrato()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

#End Region

End Class

Public Class FormatoContrato
    Inherits Formato

#Region "Variables"
    Private _idformato As Integer = 0
    Private _idcontrato As Integer = 0
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
    Public Property IdContrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
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
    Public Sub New(id As Integer, idformato As Integer, idcontrato As Integer, idtipoformato As Integer, nombreArchivo As String, cuerpo As String, encabezado As String,
                   piepagina As String, altoEncabe As Decimal, altoPiePagina As Decimal,
                   usuarioCreacion As String, fechaCreacion As DateTime, UsuarioModi As String,
                   fechaModi As DateTime)
        Me.Id = id
        _idformato = idformato
        _idcontrato = idcontrato
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
