<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAddCondicion
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
        Me.txtCondicion = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dwItems = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.gbCondicion = New System.Windows.Forms.GroupBox()
        Me.col_idGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCondicion.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCondicion
        '
        Me.txtCondicion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCondicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCondicion.Location = New System.Drawing.Point(17, 75)
        Me.txtCondicion.Multiline = True
        Me.txtCondicion.Name = "txtCondicion"
        Me.txtCondicion.Size = New System.Drawing.Size(526, 57)
        Me.txtCondicion.TabIndex = 17
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(407, 339)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 23)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DropDownWidth = 200
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(17, 35)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 21)
        Me.cmbGrupo.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Descripción Condición"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Grupo"
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_idGrupo, Me.col_grupo, Me.col_Descripción})
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.Location = New System.Drawing.Point(12, 195)
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersVisible = False
        Me.dwItems.Size = New System.Drawing.Size(557, 138)
        Me.dwItems.TabIndex = 22
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.Location = New System.Drawing.Point(465, 141)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(78, 25)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(491, 339)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 23)
        Me.btnCancelar.TabIndex = 24
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbCondicion
        '
        Me.gbCondicion.Controls.Add(Me.cmbGrupo)
        Me.gbCondicion.Controls.Add(Me.Label2)
        Me.gbCondicion.Controls.Add(Me.btnAgregar)
        Me.gbCondicion.Controls.Add(Me.Label1)
        Me.gbCondicion.Controls.Add(Me.txtCondicion)
        Me.gbCondicion.Location = New System.Drawing.Point(12, 12)
        Me.gbCondicion.Name = "gbCondicion"
        Me.gbCondicion.Size = New System.Drawing.Size(557, 177)
        Me.gbCondicion.TabIndex = 25
        Me.gbCondicion.TabStop = False
        Me.gbCondicion.Text = "Condición"
        '
        'col_idGrupo
        '
        Me.col_idGrupo.HeaderText = "Id grupo"
        Me.col_idGrupo.Name = "col_idGrupo"
        Me.col_idGrupo.ReadOnly = True
        Me.col_idGrupo.Visible = False
        Me.col_idGrupo.Width = 52
        '
        'col_grupo
        '
        Me.col_grupo.HeaderText = "Grupo"
        Me.col_grupo.Name = "col_grupo"
        Me.col_grupo.ReadOnly = True
        Me.col_grupo.Width = 61
        '
        'col_Descripción
        '
        Me.col_Descripción.HeaderText = "Descripción"
        Me.col_Descripción.Name = "col_Descripción"
        Me.col_Descripción.ReadOnly = True
        Me.col_Descripción.Width = 88
        '
        'FrmAddCondicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 374)
        Me.Controls.Add(Me.gbCondicion)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dwItems)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAddCondicion"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Adición de condiciones"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCondicion.ResumeLayout(False)
        Me.gbCondicion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtCondicion As TextBox
    Friend WithEvents btnAceptar As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbGrupo As ComboBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents dwItems As DataGridView
    Friend WithEvents gbCondicion As GroupBox
    Friend WithEvents col_idGrupo As DataGridViewTextBoxColumn
    Friend WithEvents col_grupo As DataGridViewTextBoxColumn
    Friend WithEvents col_Descripción As DataGridViewTextBoxColumn
End Class
