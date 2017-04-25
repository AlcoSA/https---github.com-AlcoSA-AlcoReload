<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionPropiedadMasica
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
        Me.dwitems = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inercia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.modulo_seccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.tlpbotones = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtbusqueda = New System.Windows.Forms.TextBox()
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpbotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwitems
        '
        Me.dwitems.AllowUserToAddRows = False
        Me.dwitems.AllowUserToDeleteRows = False
        Me.dwitems.BackgroundColor = System.Drawing.Color.White
        Me.dwitems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwitems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.descripcion, Me.inercia, Me.modulo_seccion})
        Me.dwitems.Location = New System.Drawing.Point(13, 53)
        Me.dwitems.MultiSelect = False
        Me.dwitems.Name = "dwitems"
        Me.dwitems.ReadOnly = True
        Me.dwitems.RowHeadersVisible = False
        Me.dwitems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dwitems.Size = New System.Drawing.Size(331, 250)
        Me.dwitems.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        '
        'inercia
        '
        Me.inercia.HeaderText = "Inercia"
        Me.inercia.Name = "inercia"
        Me.inercia.ReadOnly = True
        '
        'modulo_seccion
        '
        Me.modulo_seccion.HeaderText = "Modulo Seccion"
        Me.modulo_seccion.Name = "modulo_seccion"
        Me.modulo_seccion.ReadOnly = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAceptar.Location = New System.Drawing.Point(3, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 22)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancelar.Location = New System.Drawing.Point(88, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 22)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'tlpbotones
        '
        Me.tlpbotones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpbotones.ColumnCount = 2
        Me.tlpbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.Controls.Add(Me.btnCancelar, 1, 0)
        Me.tlpbotones.Controls.Add(Me.btnAceptar, 0, 0)
        Me.tlpbotones.Location = New System.Drawing.Point(173, 309)
        Me.tlpbotones.Name = "tlpbotones"
        Me.tlpbotones.RowCount = 1
        Me.tlpbotones.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpbotones.Size = New System.Drawing.Size(171, 28)
        Me.tlpbotones.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Nombre o Descripción"
        '
        'txtbusqueda
        '
        Me.txtbusqueda.Location = New System.Drawing.Point(15, 25)
        Me.txtbusqueda.Name = "txtbusqueda"
        Me.txtbusqueda.Size = New System.Drawing.Size(301, 20)
        Me.txtbusqueda.TabIndex = 17
        '
        'FrmSeleccionPropiedadMasica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(356, 349)
        Me.Controls.Add(Me.txtbusqueda)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tlpbotones)
        Me.Controls.Add(Me.dwitems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmSeleccionPropiedadMasica"
        Me.Text = "Seleccion Propiedad"
        CType(Me.dwitems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpbotones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dwitems As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents descripcion As DataGridViewTextBoxColumn
    Friend WithEvents inercia As DataGridViewTextBoxColumn
    Friend WithEvents modulo_seccion As DataGridViewTextBoxColumn
    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents tlpbotones As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtbusqueda As TextBox
End Class
