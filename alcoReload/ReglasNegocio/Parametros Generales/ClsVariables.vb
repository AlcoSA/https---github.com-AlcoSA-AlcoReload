Imports Datos
Public Class ClsVariables
#Region "Variables"
    Private taVariables As New dsbAlcoIngenieriaTableAdapters.ti006_variablesTableAdapter
#End Region

#Region "Procedimientos Y Funciones"
    ''' <summary>
    ''' Este procedimiento sirve para ingresar una nueva variable
    ''' </summary>
    ''' <param name="usuario"></param>
    ''' <param name="nombrevariable"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idtipoDato"></param>
    ''' <param name="estado"></param>
    Public Sub Ingresar(usuario As String, nombrevariable As String, descripcion As String,
                        idtipoDato As Integer, estado As Integer, desdebd As Boolean, edicion_produccion As Boolean,
                        usopredeterminado As Boolean, orden As Integer, imprimir As Boolean)
        Try
            taVariables.sp_ti006_insert(usuario, nombrevariable, descripcion, idtipoDato,
                                        estado, desdebd, edicion_produccion, usopredeterminado, orden, imprimir)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para actualizar una variable registrada en el sistema
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="usuario"></param>
    ''' <param name="nombrevariable"></param>
    ''' <param name="descripcion"></param>
    ''' <param name="idtipoDato"></param>
    ''' <param name="estado"></param>
    Public Sub Modificar(id As Integer, usuario As String, nombrevariable As String,
                         descripcion As String, idtipoDato As Integer, estado As Integer,
                         desdebd As Boolean, ediccion_produccion As Boolean, usopredeterminado As Boolean, orden As Integer, imprimir As Boolean)
        Try
            taVariables.sp_ti006_updateById(id, nombrevariable, descripcion,
                                            usuario, idtipoDato, estado, desdebd, ediccion_produccion, usopredeterminado, orden, imprimir)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
    ''' <summary>
    ''' Este procedimiento sirve para obtener todas las variables registradas en el sistema
    ''' </summary>
    ''' <returns>List(Of Variables)</returns>
    Public Function TraerTodos(Optional ByRef dt As DataTable = Nothing) As List(Of Variables)
        TraerTodos = New List(Of Variables)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti006_selectAllTableAdapter
            For Each var As dsbAlcoIngenieria.sp_ti006_selectAllRow In taAll.GetData().Rows
                TraerTodos.Add(New Variables(var.Id, var.Usuario_Creacion, var.Fecha_Creacion,
                                             var.Nombre_Variable, var.Descripcion, var.Id_TipoDato,
                                             var.Tipo_Dato, var.Valor_Desde_BD, var.Edicion_Produccion, var.Uso_Predeterminado,
                                             var.Usuario_Modifiacion, var.Fecha_Creacion, var.Id_Estado, var.Estado, var.Orden, var.Imprimir))
            Next
            If taAll.GetData().Rows.Count > 0 Then
                dt = taAll.GetData().CopyToDataTable
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener variables filtradas por ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns>Variables</returns>
    Public Function TraerxId(id As Integer) As Variables
        TraerxId = New Variables
        Try
            Dim taxId As New dsbAlcoIngenieriaTableAdapters.sp_ti006_selectByIDTableAdapter
            Dim txid As dsbAlcoIngenieria.sp_ti006_selectByIDDataTable = taxId.GetData(id)
            If txid.Rows.Count > 0 Then
                Dim var As dsbAlcoIngenieria.sp_ti006_selectByIDRow = DirectCast(txid.Rows(0), dsbAlcoIngenieria.sp_ti006_selectByIDRow)
                TraerxId = New Variables(var.Id, var.Usuario_Creacion, var.Fecha_Creacion,
                                             var.Nombre_Variable, var.Descripcion, var.Id_TipoDato,
                                             var.Tipo_Dato, var.Valor_Desde_BD, var.Edicion_Produccion, var.Uso_Predeterminado,
                                             var.Usuario_Modifiacion, var.Fecha_Creacion, var.Id_Estado, var.Estado, var.Orden, var.Imprimir)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Este procedimiento sirve para obtener variables filtradas por estado
    ''' </summary>
    ''' <param name="estado"></param>
    ''' <returns>List(Of Variables)</returns>
    Public Function TraerxEstado(estado As Integer) As List(Of Variables)
        TraerxEstado = New List(Of Variables)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti006_selectByEstadoTableAdapter
            Dim txestado As dsbAlcoIngenieria.sp_ti006_selectByEstadoDataTable = taAll.GetData(estado)
            For Each var As dsbAlcoIngenieria.sp_ti006_selectByEstadoRow In txestado.Rows
                TraerxEstado.Add(New Variables(var.Id, var.Usuario_Creacion, var.Fecha_Creacion,
                                             var.Nombre_Variable, var.Descripcion, var.Id_TipoDato,
                                             var.Tipo_Dato, var.Valor_Desde_BD, var.Edicion_Produccion, var.Uso_Predeterminado,
                                             var.Usuario_Modifiacion, var.Fecha_Creacion, var.Id_Estado, var.Estado, var.Orden, var.Imprimir))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Function TraerxEstado_Tabla(estado As Integer) As DataTable
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti006_selectByEstadoTableAdapter
            Dim txestado As dsbAlcoIngenieria.sp_ti006_selectByEstadoDataTable = taAll.GetData(estado)
            Return txestado.Copy()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
    ''' <summary>
    ''' Funcion que devuelve los valores de la tabla de variables, verificando el estado 
    ''' y si sus valores vienen desde la base de datos
    ''' </summary>
    ''' <param name="estado">Estado de la variable</param>
    ''' <param name="valordesdebd">Valores desde la base de datos = 1, Valores implícitos en plantilla = 0</param>
    ''' <returns>List(Of Variables)</returns>
    Public Function TraerxEstadoyValorDesdeBd(estado As Integer, valordesdebd As Boolean) As List(Of Variables)
        TraerxEstadoyValorDesdeBd = New List(Of Variables)
        Try
            Dim taAll As New dsbAlcoIngenieriaTableAdapters.sp_ti006_selectByEstadoyVariableDesdeTableAdapter
            Dim txestado As dsbAlcoIngenieria.sp_ti006_selectByEstadoyVariableDesdeDataTable = taAll.GetData(estado, valordesdebd)
            For Each var As dsbAlcoIngenieria.sp_ti006_selectByEstadoyVariableDesdeRow In txestado.Rows
                TraerxEstadoyValorDesdeBd.Add(New Variables(var.Id, var.Usuario_Creacion, var.Fecha_Creacion,
                                             var.Nombre_Variable, var.Descripcion, var.Id_TipoDato,
                                             var.Tipo_Dato, var.Valor_Desde_BD, var.Edicion_Produccion, var.Uso_Predeterminado,
                                             var.Usuario_Modifiacion, var.Fecha_Creacion, var.Id_Estado, var.Estado, var.Orden, var.Imprimir))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function
#End Region
End Class
Public Class Variables
    Inherits ClsBaseParametros
#Region "Variables"
    Private _nombre As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _idtipodato As Integer = 0
    Private _tipodato As String = String.Empty
    Private _valoresdesdebd As Boolean = False
    Private _usopredeterminado As Boolean = False
    Private _edicionproduccion As Boolean = False
    Private _orden As Integer = 0
    Private _imprimir As Boolean = False
#End Region

#Region "Propiedades"

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property IdTipoDato As Integer
        Get
            Return _idtipodato
        End Get
        Set(value As Integer)
            _idtipodato = value
        End Set
    End Property

    Public Property TipoDato As String
        Get
            Return _tipodato
        End Get
        Set(value As String)
            _tipodato = value
        End Set
    End Property

    Public Property ValoresDesdeBasedeDatos As Boolean
        Get
            Return _valoresdesdebd
        End Get
        Set(value As Boolean)
            _valoresdesdebd = True
        End Set
    End Property

    Public Property EdicionProduccion As Boolean
        Get
            Return _edicionproduccion
        End Get
        Set(value As Boolean)
            _edicionproduccion = value
        End Set
    End Property

    Public Property UsoPredeterminado As Boolean
        Get
            Return _usopredeterminado
        End Get
        Set(value As Boolean)
            _usopredeterminado = value
        End Set
    End Property

    Public Property Orden As Integer
        Get
            Return _orden
        End Get
        Set(value As Integer)
            _orden = value
        End Set
    End Property

    Public Property Imprimir As Boolean
        Get
            Return _imprimir
        End Get
        Set(value As Boolean)
            _imprimir = value
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

    Public Sub New(id As Integer, usuariocreacion As String, fechacreacion As Date, nombre As String,
                   descripcion As String, idtipodato As Integer, tipodato As String,
                   valoresdesdebd As Boolean, edicionproduccion As Boolean, usopredeterminado As Boolean,
                   usuariomodificacion As String, fechamodificacion As Date, idestado As Integer,
                   estado As String, orden As Integer, imprimir As Boolean)
        Try
            Me.Id = id
            Me.UsuarioCreacion = Trim(usuariocreacion)
            Me.FechaCreacion = fechacreacion
            _nombre = Trim(nombre)
            _descripcion = Trim(descripcion)
            _idtipodato = idtipodato
            _tipodato = Trim(tipodato)
            _usopredeterminado = usopredeterminado
            _valoresdesdebd = valoresdesdebd
            _edicionproduccion = edicionproduccion
            _orden = orden
            _imprimir = imprimir
            Me.UsuarioModificacion = Trim(usuariomodificacion)
            Me.FechaModificacion = fechamodificacion
            Me.IdEstado = idestado
            Me.Estado = Trim(estado)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

#End Region

End Class
