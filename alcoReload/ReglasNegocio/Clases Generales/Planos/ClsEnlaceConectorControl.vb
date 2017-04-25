Imports Datos
Public Class ClsEnlaceConectorControl
#Region "Variables"
    Private _objenlace As New dsGeneralesAplicacionTableAdapters.tg014_combinacionconectoresTableAdapter
#End Region
    Public Function Insertar(usuario As String, idencabe As Integer, idmovcon As Integer, idcontrol As Integer, formulario As String,
                             nombrecontrol As String, rutacontrol As String) As Integer
        Try
            Return Convert.ToInt32(_objenlace.sp_tg014_insert(usuario, idencabe, idmovcon, idcontrol, formulario,
                                       nombrecontrol, rutacontrol))
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Sub Modificar(id As Integer, usuario As String, idencabe As Integer,
                         idmovcon As Integer, idcontrol As Integer, formulario As String,
                             nombrecontrol As String, rutacontrol As String)
        Try
            _objenlace.sp_tg014_update(id, usuario, idencabe, idmovcon,
                                       idcontrol, formulario, nombrecontrol, rutacontrol)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    Public Sub EliminarporId(id As Integer)
        Try
            _objenlace.sp_tg014_deleteById(id)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    'Public Function TraerxIdMovCon(idmovcon As Integer) As List(Of EnlaceControlConector)
    '    TraerxIdMovCon = New List(Of EnlaceControlConector)
    '    Try
    '        Dim obj As New dsGeneralesAplicacionTableAdapters.sp_tg014_selectByIdMovConTableAdapter
    '        Dim tb As dsGeneralesAplicacion.sp_tg014_selectByIdMovConDataTable = obj.GetData(idmovcon)
    '        For Each e As dsGeneralesAplicacion.sp_tg014_selectByIdMovConRow In tb.Rows
    '            TraerxIdMovCon.Add(New EnlaceControlConector(e.fg014_rowid, e.fg014_fechacreacion, e.fg014_usuariocreacion,
    '                                                         e.fg012_rowid, e.fg012_nombreCampo, e.fg012_rowidTipoDato, e.fg012_indObligatorio,
    '                                                         e.fg012_posInicio, e.fg012_posFin, e.fg012_longitud, e.fg012_formato, e.fg012_valorPorDefecto,
    '                                                         e.fg012_decimales, e.fg012_autoincremento, e.fg013_rowid, e.fg014_formulario, e.fg014_nombrecontrol,
    '                                                         e.fg014_rutacontrol, e.fg014_fechamodificacion, e.fg014_usuariomodificacion))
    '        Next
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function
    'Public Function TraerporFormulario(formulario As String) As List(Of EnlaceControlConector)
    '    TraerporFormulario = New List(Of EnlaceControlConector)
    '    Try
    '        Dim obj As New dsGeneralesAplicacionTableAdapters.sp_tg014_selectByformularioTableAdapter
    '        Dim tb As dsGeneralesAplicacion.sp_tg014_selectByformularioDataTable = obj.GetData(formulario)
    '        For Each e As dsGeneralesAplicacion.sp_tg014_selectByformularioRow In tb.Rows
    '            TraerporFormulario.Add(New EnlaceControlConector(e.fg014_rowid, e.fg014_fechacreacion, e.fg014_usuariocreacion,
    '                                                         e.fg012_rowid, e.fg012_nombreCampo, e.fg012_rowidTipoDato, e.fg012_indObligatorio,
    '                                                         e.fg012_posInicio, e.fg012_posFin, e.fg012_longitud, e.fg012_formato, e.fg012_valorPorDefecto,
    '                                                         e.fg012_decimales, e.fg012_autoincremento, e.fg013_rowid, e.fg014_formulario, e.fg014_nombrecontrol,
    '                                                         e.fg014_rutacontrol, e.fg014_fechamodificacion, e.fg014_usuariomodificacion))
    '        Next
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message, ex.InnerException)
    '    End Try
    'End Function

    Public Function TraerporIdEncabe(idconector As Integer, idencabe As Integer) As List(Of EnlaceControlConector)
        TraerporIdEncabe = New List(Of EnlaceControlConector)
        Try
            Dim obj As New dsGeneralesAplicacionTableAdapters.sp_tg014_selectByIdEncabeTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg014_selectByIdEncabeDataTable = obj.GetData(idconector, idencabe)
            For Each e As dsGeneralesAplicacion.sp_tg014_selectByIdEncabeRow In tb.Rows
                TraerporIdEncabe.Add(New EnlaceControlConector(e.id, Now, String.Empty,
                                                             e.fg012_rowid, e.fg012_nombreCampo, e.fg012_rowidTipoDato, e.fg012_indObligatorio,
                                                             e.fg012_posInicio, e.fg012_posFin, e.fg012_longitud, e.fg012_formato, e.fg012_valorPorDefecto,
                                                             e.fg012_decimales, e.fg012_autoincremento, e.fg014_rowidcontrol, e.fg014_formulario, e.fg014_nombrecontrol,
                                                             e.fg014_rutacontrol, Now, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdConectorNuevoEnlazado(idconector As Integer) As List(Of EnlaceControlConector)
        TraerporIdConectorNuevoEnlazado = New List(Of EnlaceControlConector)
        Try
            Dim obj As New dsGeneralesAplicacionTableAdapters.sp_tg012_selectbyIdConectorTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg012_selectbyIdConectorDataTable = obj.GetData(idconector)
            For Each e As dsGeneralesAplicacion.sp_tg012_selectbyIdConectorRow In tb.Rows
                TraerporIdConectorNuevoEnlazado.Add(New EnlaceControlConector(0, Now, String.Empty,
                                                             e.fg012_rowid, e.fg012_nombreCampo, e.fg012_rowidTipoDato, e.fg012_indObligatorio,
                                                             e.fg012_posInicio, e.fg012_posFin, e.fg012_longitud, e.fg012_formato, e.fg012_valorPorDefecto,
                                                             e.fg012_decimales, e.fg012_autoincremento, e.fg014_rowidcontrol, e.fg014_formulario, e.fg014_nombrecontrol,
                                                             e.fg014_rutacontrol, Now, String.Empty))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerporIdConector(idconector As Integer, idencabe As Integer) As List(Of EnlaceControlConector)
        TraerporIdConector = New List(Of EnlaceControlConector)
        Try
            Dim obj As New dsGeneralesAplicacionTableAdapters.sp_tg014_selectEnlazadoBy_idencabe_idconectorTableAdapter
            Dim tb As dsGeneralesAplicacion.sp_tg014_selectEnlazadoBy_idencabe_idconectorDataTable = obj.GetData(idconector, idencabe)
            For Each e As dsGeneralesAplicacion.sp_tg014_selectEnlazadoBy_idencabe_idconectorRow In tb.Rows
                TraerporIdConector.Add(New EnlaceControlConector(e.Id, Now, String.Empty,
                                                             e.Id_Mov_Con, e.Nombre_campo, e.Id_Control, e.Formulario, e.Nombre_Control,
                                                             e.Ruta_Control, Now, String.Empty))

                'id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                '   idmovcon As Integer, nombremovconector As String, TipoDato As Integer,
                '   indobligatorio As Boolean, posicioninicial As Integer, posicionfinal As Integer,
                '   longitud As Integer, Formato As String, valorpordefecto As String,
                '   cantidaddecimales As Integer, autoincremento As Boolean, IdControl As Integer,
                '   Formulario As String, nombrecontrol As String, rutacontrol As String,
                '   fechamodificacion As DateTime, usuariomodificacion As String
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

End Class

Public Class EnlaceControlConector
    Inherits movitoConector
#Region "Variables"
    Private _idmovcon As Integer
    Private _idcontrol As Integer
    Private _formulario As String
    Private _nombrecontrol As String
    Private _rutacontrol As String
#End Region
#Region "Propiedades"
    Public Property IdMovimientoConector As Integer
        Get
            Return _idmovcon
        End Get
        Set(value As Integer)
            _idmovcon = value
        End Set
    End Property
    Public Property IdControl As Integer
        Get
            Return _idcontrol
        End Get
        Set(value As Integer)
            _idcontrol = value
        End Set
    End Property
    Public Property Formulario As String
        Get
            Return _formulario
        End Get
        Set(value As String)
            _formulario = value
        End Set
    End Property
    Public Property NombreControl As String
        Get
            Return _nombrecontrol
        End Get
        Set(value As String)
            _nombrecontrol = value
        End Set
    End Property
    Public Property RutaControl As String
        Get
            Return _rutacontrol
        End Get
        Set(value As String)
            _rutacontrol = value
        End Set
    End Property
#End Region
#Region "Constructor"
    Public Sub New()
    End Sub
    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idmovcon As Integer, nombremovconector As String, idcontrol As Integer,
                   formulario As String, nombrecontrol As String, rutacontrol As String,
                   fechamodificacion As DateTime, usuariomodificacion As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _idmovcon = idmovcon
        Me.NombreCampo = Trim(nombremovconector)
        _idcontrol = idcontrol
        _formulario = Trim(formulario)
        _nombrecontrol = Trim(nombrecontrol)
        _rutacontrol = Trim(rutacontrol)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
    End Sub

    Public Sub New(id As Integer, fechacreacion As DateTime, usuariocreacion As String,
                   idmovcon As Integer, nombremovconector As String, tipodato As Integer,
                   indobligatorio As Boolean, posicioninicial As Integer, posicionfinal As Integer,
                   longitud As Integer, formato As String, valorpordefecto As String,
                   cantidaddecimales As Integer, autoincremento As Boolean, IdControl As Integer,
                   Formulario As String, nombrecontrol As String, rutacontrol As String,
                   fechamodificacion As DateTime, usuariomodificacion As String)
        Me.Id = id
        Me.FechaCreacion = fechacreacion
        Me.UsuarioCreacion = Trim(usuariocreacion)
        _idmovcon = idmovcon
        Me.NombreCampo = Trim(nombremovconector)
        _idcontrol = IdControl
        _formulario = Trim(Formulario)
        Me.idTipoDato = tipodato
        Me.indObligatorio = indobligatorio
        Me.PosicionInicial = posicioninicial
        Me.posicionFinal = posicionfinal
        Me.Longitud = longitud
        Me.Formato = formato.Trim
        Me.ValorDefecto = valorpordefecto.Trim
        Me.Decimales = cantidaddecimales
        Me.Autoincremento = autoincremento
        _nombrecontrol = Trim(nombrecontrol)
        _rutacontrol = Trim(rutacontrol)
        Me.FechaModificacion = fechamodificacion
        Me.UsuarioModificacion = Trim(usuariomodificacion)
    End Sub

#End Region
End Class
