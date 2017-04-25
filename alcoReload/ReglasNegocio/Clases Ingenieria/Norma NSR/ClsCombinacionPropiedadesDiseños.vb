Imports Datos
Public Class ClsCombinacionPropiedadesDiseños

#Region "Variables"
    Private tacombinacion As New dsbAlcoIngenieriaTableAdapters.ti033_combinacionpropiedadesdiseñosTableAdapter
#End Region
    Public Function Insertar(usuario As String, idpropiedad As Integer, idmodelo As Integer) As Integer
        Try
            Return Convert.ToInt32(tacombinacion.Insertar(usuario, idpropiedad, idmodelo, usuario))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    Public Sub Modificar(id As Integer, usuario As String, idpropiedad As Integer, idmodelo As Integer)
        Try
            tacombinacion.Modificar(idpropiedad, idmodelo, usuario, id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Sub BorrarporId(id As Integer)
        Try
            tacombinacion.BorrarporId(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Public Function TraerTodos() As List(Of CombinacinPropiedadDiseño)
        TraerTodos = New List(Of CombinacinPropiedadDiseño)
        Try
            Dim tax As New dsbAlcoIngenieriaTableAdapters.crucemodelosypropiedadesTableAdapter
            Dim txall As dsbAlcoIngenieria.crucemodelosypropiedadesDataTable = tax.GetData()
            For Each cd As dsbAlcoIngenieria.crucemodelosypropiedadesRow In txall.Rows
                TraerTodos.Add(New CombinacinPropiedadDiseño(cd.fi033_rowid, cd.fi033_usuariocreacion,
                                                             Now, cd.fi033_rowidpropiedad, cd.fi032_nombre, cd.fi011_rowid, cd.modelo,
                                                             cd.fi033_usuariomodificacion, Now))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function


    Public Function TraerporIdModelo(idmodelo As Integer) As CombinacinPropiedadDiseño
        TraerporIdModelo = New CombinacinPropiedadDiseño()
        Try
            Dim txall As dsbAlcoIngenieria.ti033_combinacionpropiedadesdiseñosDataTable = tacombinacion.TraerporIdmodelo(idmodelo)
            If txall.Rows.Count > 0 Then
                Dim cd As dsbAlcoIngenieria.ti033_combinacionpropiedadesdiseñosRow = DirectCast(txall.Rows(0), dsbAlcoIngenieria.ti033_combinacionpropiedadesdiseñosRow)
                TraerporIdModelo = New CombinacinPropiedadDiseño(cd.fi033_rowid, cd.fi033_usuariocreacion,
                                                             cd.fi033_fechacreacion, cd.fi033_rowidpropiedad, String.Empty, cd.fi033_rowidmodelo, String.Empty,
                                                             cd.fi033_usuariomodificacion, cd.fi033_fechamodificacion)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdPropiedad(idpropiedad As Integer) As List(Of CombinacinPropiedadDiseño)
        TraerporIdPropiedad = New List(Of CombinacinPropiedadDiseño)
        Try
            Dim txall As dsbAlcoIngenieria.ti033_combinacionpropiedadesdiseñosDataTable = tacombinacion.TraerporIdPropiedad(idpropiedad)
            For Each cd As dsbAlcoIngenieria.ti033_combinacionpropiedadesdiseñosRow In txall.Rows
                TraerporIdPropiedad.Add(New CombinacinPropiedadDiseño(cd.fi033_rowid, cd.fi033_usuariocreacion,
                                                             cd.fi033_fechacreacion, cd.fi033_rowidpropiedad, String.Empty, cd.fi033_rowidmodelo, String.Empty,
                                                             cd.fi033_usuariomodificacion, cd.fi033_fechamodificacion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class
Public Class CombinacinPropiedadDiseño
    Inherits ClsBaseParametros

#Region "Variables"
    Private _idpropiedad As Integer
    Private _nombrepropiedad As String
    Private _idmodelo As Integer
    Private _nombremodelo As String
#End Region

#Region "Propiedades"
    Public Property IdPropiedadesMasica As Integer
        Get
            Return _idpropiedad
        End Get
        Set(value As Integer)
            _idpropiedad = value
        End Set
    End Property
    Public Property NombrePropiedad As String
        Get
            Return _nombrepropiedad
        End Get
        Set(value As String)
            _nombrepropiedad = value
        End Set
    End Property
    Public Property IdModelo As Integer
        Get
            Return _idmodelo
        End Get
        Set(value As Integer)
            _idmodelo = value
        End Set
    End Property
    Public Property NombreModelo As String
        Get
            Return _nombremodelo
        End Get
        Set(value As String)
            _nombremodelo = value
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As DateTime,
                   idpropiedad As Integer, nombrepropiedad As String, idmodelo As Integer, nombremodelo As String,
               usuariomodificaicon As String, fechamodificacion As DateTime)
        Me.Id = id
        _idpropiedad = idpropiedad
        _nombrepropiedad = Trim(nombrepropiedad)
        _idmodelo = idmodelo
        _nombremodelo = Trim(nombremodelo)
        Me.UsuarioCreacion = Trim(usuariocreacion)
        Me.FechaCreacion = fechacreacion
        Me.UsuarioModificacion = Trim(usuariomodificaicon)
        Me.FechaModificacion = fechamodificacion
    End Sub
#End Region

End Class
