<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCargadorInformesDinamicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCargadorInformesDinamicos))
        Me.dwItems = New ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros()
        Me.fddFiltros = New ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop()
        Me.tsherramientas = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbinformes = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbinformespersonalizados = New System.Windows.Forms.ToolStripComboBox()
        Me.btnusuario_s = New System.Windows.Forms.ToolStripButton()
        Me.lbnombreinforme = New System.Windows.Forms.ToolStripLabel()
        Me.flpfiltros = New System.Windows.Forms.FlowLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.imimagenes = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsherramientas.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dwItems
        '
        Me.dwItems.AllowUserToAddRows = False
        Me.dwItems.AllowUserToDeleteRows = False
        Me.dwItems.AllowUserToResizeRows = False
        Me.dwItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dwItems.BackgroundColor = System.Drawing.Color.White
        Me.dwItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dwItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dwItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dwItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dwItems.ImageList = Nothing
        Me.dwItems.Location = New System.Drawing.Point(3, 88)
        Me.dwItems.MostrarFiltros = True
        Me.dwItems.MultiSelect = False
        Me.dwItems.Name = "dwItems"
        Me.dwItems.ReadOnly = True
        Me.dwItems.RowHeadersWidth = 25
        Me.dwItems.Size = New System.Drawing.Size(705, 209)
        Me.dwItems.TabIndex = 3
        Me.dwItems.TablaDatos = Nothing
        Me.dwItems.Total = ControlesPersonalizados.GridFiltrado.Elementos_Grid.TOTAL.NINGUNA
        '
        'fddFiltros
        '
        Me.fddFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fddFiltros.Grid = Nothing
        Me.fddFiltros.Location = New System.Drawing.Point(3, 3)
        Me.fddFiltros.Name = "fddFiltros"
        Me.fddFiltros.Size = New System.Drawing.Size(705, 79)
        Me.fddFiltros.TabIndex = 2
        '
        'tsherramientas
        '
        Me.tsherramientas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsherramientas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbinformes, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.cmbinformespersonalizados, Me.btnusuario_s, Me.lbnombreinforme})
        Me.tsherramientas.Location = New System.Drawing.Point(0, 0)
        Me.tsherramientas.Name = "tsherramientas"
        Me.tsherramientas.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tsherramientas.Size = New System.Drawing.Size(711, 25)
        Me.tsherramientas.TabIndex = 4
        Me.tsherramientas.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripLabel1.Text = "Informe"
        '
        'cmbinformes
        '
        Me.cmbinformes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinformes.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbinformes.Name = "cmbinformes"
        Me.cmbinformes.Size = New System.Drawing.Size(150, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(85, 22)
        Me.ToolStripLabel2.Text = "Personalizados"
        '
        'cmbinformespersonalizados
        '
        Me.cmbinformespersonalizados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbinformespersonalizados.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbinformespersonalizados.Name = "cmbinformespersonalizados"
        Me.cmbinformespersonalizados.Size = New System.Drawing.Size(150, 25)
        '
        'btnusuario_s
        '
        Me.btnusuario_s.Checked = True
        Me.btnusuario_s.CheckOnClick = True
        Me.btnusuario_s.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnusuario_s.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnusuario_s.Image = CType(resources.GetObject("btnusuario_s.Image"), System.Drawing.Image)
        Me.btnusuario_s.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnusuario_s.Name = "btnusuario_s"
        Me.btnusuario_s.Size = New System.Drawing.Size(23, 22)
        Me.btnusuario_s.Text = "ToolStripButton1"
        '
        'lbnombreinforme
        '
        Me.lbnombreinforme.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbnombreinforme.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lbnombreinforme.Name = "lbnombreinforme"
        Me.lbnombreinforme.Size = New System.Drawing.Size(21, 22)
        Me.lbnombreinforme.Text = "--"
        '
        'flpfiltros
        '
        Me.flpfiltros.BackColor = System.Drawing.SystemColors.Control
        Me.flpfiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpfiltros.Location = New System.Drawing.Point(3, 303)
        Me.flpfiltros.Name = "flpfiltros"
        Me.flpfiltros.Size = New System.Drawing.Size(705, 79)
        Me.flpfiltros.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.fddFiltros, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.flpfiltros, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.dwItems, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(711, 385)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'imimagenes
        '
        Me.imimagenes.ImageStream = CType(resources.GetObject("imimagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imimagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.imimagenes.Images.SetKeyName(0, "Usuario 24x24.png")
        Me.imimagenes.Images.SetKeyName(1, "Multiusuarios 24x24.png")
        '
        'FrmCargadorInformesDinamicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 410)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.tsherramientas)
        Me.Name = "FrmCargadorInformesDinamicos"
        Me.ShowIcon = False
        Me.Text = "Cargador Informes Dinamicos"
        CType(Me.dwItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsherramientas.ResumeLayout(False)
        Me.tsherramientas.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dwItems As ControlesPersonalizados.GridFiltrado.GridMultiGruposFiltros
    Friend WithEvents fddFiltros As ControlesPersonalizados.Filtro_DragDrop.FiltroDragDrop
    Friend WithEvents tsherramientas As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents cmbinformes As ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents flpfiltros As FlowLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cmbinformespersonalizados As ToolStripComboBox
    Friend WithEvents btnusuario_s As ToolStripButton
    Friend WithEvents lbnombreinforme As ToolStripLabel
    Friend WithEvents imimagenes As ImageList
End Class
