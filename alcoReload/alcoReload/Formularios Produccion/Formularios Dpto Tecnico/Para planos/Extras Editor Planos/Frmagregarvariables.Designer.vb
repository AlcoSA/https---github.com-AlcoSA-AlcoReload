<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmagregarvariables
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.dwItem = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.selecccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_variable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_TipoDato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo_Dato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Valor_Desde_BD = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btncancelar, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnaceptar, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 338)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(469, 31)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btncancelar
        '
        Me.btncancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btncancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btncancelar.Location = New System.Drawing.Point(392, 3)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(74, 25)
        Me.btncancelar.TabIndex = 1
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnaceptar.Location = New System.Drawing.Point(312, 3)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(74, 25)
        Me.btnaceptar.TabIndex = 2
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'dwItem
        '
        Me.dwItem.AllowUserToAddRows = False
        Me.dwItem.AllowUserToDeleteRows = False
        Me.dwItem.AllowUserToResizeColumns = False
        Me.dwItem.AllowUserToResizeRows = False
        Me.dwItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItem.BackgroundColor = System.Drawing.Color.White
        Me.dwItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selecccionar, Me.id, Me.nombre_variable, Me.Id_TipoDato, Me.Tipo_Dato, Me.Valor_Desde_BD})
        Me.dwItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItem.ImageList = Nothing
        Me.dwItem.Location = New System.Drawing.Point(0, 0)
        Me.dwItem.MostrarFiltros = True
        Me.dwItem.MultiSelect = False
        Me.dwItem.Name = "dwItem"
        Me.dwItem.RowHeadersWidth = 30
        Me.dwItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dwItem.Size = New System.Drawing.Size(469, 338)
        Me.dwItem.TabIndex = 3
        Me.dwItem.TablaDatos = Nothing
        Me.dwItem.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'selecccionar
        '
        Me.selecccionar.HeaderText = "Seleccionar"
        Me.selecccionar.Name = "selecccionar"
        Me.selecccionar.Width = 69
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        Me.id.Width = 41
        '
        'nombre_variable
        '
        Me.nombre_variable.HeaderText = "Variable"
        Me.nombre_variable.Name = "nombre_variable"
        Me.nombre_variable.ReadOnly = True
        Me.nombre_variable.Width = 70
        '
        'Id_TipoDato
        '
        Me.Id_TipoDato.HeaderText = "Id Tipo Dato"
        Me.Id_TipoDato.Name = "Id_TipoDato"
        Me.Id_TipoDato.ReadOnly = True
        Me.Id_TipoDato.Visible = False
        Me.Id_TipoDato.Width = 91
        '
        'Tipo_Dato
        '
        Me.Tipo_Dato.HeaderText = "Tipo Datos"
        Me.Tipo_Dato.Name = "Tipo_Dato"
        Me.Tipo_Dato.ReadOnly = True
        Me.Tipo_Dato.Width = 84
        '
        'Valor_Desde_BD
        '
        Me.Valor_Desde_BD.HeaderText = "Multiples Valores"
        Me.Valor_Desde_BD.Name = "Valor_Desde_BD"
        Me.Valor_Desde_BD.ReadOnly = True
        Me.Valor_Desde_BD.Width = 83
        '
        'Frmagregarvariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btncancelar
        Me.ClientSize = New System.Drawing.Size(469, 369)
        Me.Controls.Add(Me.dwItem)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Frmagregarvariables"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Variable"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dwItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents btncancelar As Button
    Friend WithEvents btnaceptar As Button
    Friend WithEvents dwItem As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents selecccionar As DataGridViewCheckBoxColumn
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nombre_variable As DataGridViewTextBoxColumn
    Friend WithEvents Id_TipoDato As DataGridViewTextBoxColumn
    Friend WithEvents Tipo_Dato As DataGridViewTextBoxColumn
    Friend WithEvents Valor_Desde_BD As DataGridViewCheckBoxColumn
End Class
