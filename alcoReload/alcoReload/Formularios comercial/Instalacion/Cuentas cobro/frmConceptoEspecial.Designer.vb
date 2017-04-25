<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptoEspecial
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
        Me.components = New System.ComponentModel.Container()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbUnidadMedida = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudCantidad = New System.Windows.Forms.NumericUpDown()
        Me.nudValorUnitario = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudPorcRetenido = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.itDescripcion = New ControlesPersonalizados.Intellisens.intellises()
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudValorUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcRetenido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Unidad medida"
        '
        'cmbUnidadMedida
        '
        Me.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUnidadMedida.FormattingEnabled = True
        Me.cmbUnidadMedida.Location = New System.Drawing.Point(28, 93)
        Me.cmbUnidadMedida.Name = "cmbUnidadMedida"
        Me.cmbUnidadMedida.Size = New System.Drawing.Size(86, 21)
        Me.cmbUnidadMedida.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(154, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cantidad"
        '
        'nudCantidad
        '
        Me.nudCantidad.Location = New System.Drawing.Point(157, 93)
        Me.nudCantidad.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudCantidad.Name = "nudCantidad"
        Me.nudCantidad.Size = New System.Drawing.Size(100, 20)
        Me.nudCantidad.TabIndex = 7
        '
        'nudValorUnitario
        '
        Me.nudValorUnitario.Location = New System.Drawing.Point(28, 139)
        Me.nudValorUnitario.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudValorUnitario.Name = "nudValorUnitario"
        Me.nudValorUnitario.Size = New System.Drawing.Size(100, 20)
        Me.nudValorUnitario.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Valor unitario"
        '
        'nudPorcRetenido
        '
        Me.nudPorcRetenido.Location = New System.Drawing.Point(157, 139)
        Me.nudPorcRetenido.Name = "nudPorcRetenido"
        Me.nudPorcRetenido.Size = New System.Drawing.Size(100, 20)
        Me.nudPorcRetenido.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(154, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Retenido (%)"
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(101, 187)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(182, 187)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 13
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'itDescripcion
        '
        Me.itDescripcion.AlternativeColumn = ""
        Me.itDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.itDescripcion.ColToReturn = "descripcion"
        Me.itDescripcion.ColumnsToFilter = New String() {"descripcion"}
        Me.itDescripcion.ColumnsToShow = New String() {"descripcion"}
        Me.itDescripcion.Dropdown_Width = 150
        Me.itDescripcion.Id_Column_Name = "id"
        Me.itDescripcion.Location = New System.Drawing.Point(28, 43)
        Me.itDescripcion.Maximo_Items_DropDown = 5
        Me.itDescripcion.MaxLength = 100
        Me.itDescripcion.Name = "itDescripcion"
        Me.itDescripcion.selected_item = Nothing
        Me.itDescripcion.Seleted_rowid = Nothing
        Me.itDescripcion.Size = New System.Drawing.Size(229, 20)
        Me.itDescripcion.TabIndex = 14
        Me.itDescripcion.TablaFuente = Nothing
        Me.itDescripcion.Value2 = Nothing
        '
        'frmConceptoEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 228)
        Me.Controls.Add(Me.itDescripcion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.nudPorcRetenido)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.nudValorUnitario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudCantidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbUnidadMedida)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConceptoEspecial"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otros"
        CType(Me.nudCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudValorUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcRetenido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbUnidadMedida As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents nudCantidad As NumericUpDown
    Friend WithEvents nudValorUnitario As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents nudPorcRetenido As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents ErrorProvider As ErrorProvider
    Friend WithEvents itDescripcion As ControlesPersonalizados.Intellisens.intellises
End Class
