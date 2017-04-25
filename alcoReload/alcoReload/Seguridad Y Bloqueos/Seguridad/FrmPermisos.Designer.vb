<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPermisos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermisos))
        Me.twPermisos = New System.Windows.Forms.TreeView()
        Me.imnodos = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Usuarios = New System.Windows.Forms.GroupBox()
        Me.twGrupos = New System.Windows.Forms.TreeView()
        Me.Grupos = New System.Windows.Forms.GroupBox()
        Me.twusuarios = New System.Windows.Forms.TreeView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbGenerales = New System.Windows.Forms.TabPage()
        Me.permisosBar = New System.Windows.Forms.ToolStrip()
        Me.txtBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.btonBuscar = New System.Windows.Forms.ToolStripButton()
        Me.btncontraer = New System.Windows.Forms.ToolStripButton()
        Me.btnexpandir = New System.Windows.Forms.ToolStripButton()
        Me.lbtipoSeguridad = New System.Windows.Forms.ToolStripLabel()
        Me.tbEspeciales = New System.Windows.Forms.TabPage()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Usuarios.SuspendLayout()
        Me.Grupos.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbGenerales.SuspendLayout()
        Me.permisosBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'twPermisos
        '
        Me.twPermisos.CheckBoxes = True
        Me.twPermisos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.twPermisos.Location = New System.Drawing.Point(3, 28)
        Me.twPermisos.Name = "twPermisos"
        Me.twPermisos.ShowNodeToolTips = True
        Me.twPermisos.Size = New System.Drawing.Size(371, 363)
        Me.twPermisos.TabIndex = 0
        '
        'imnodos
        '
        Me.imnodos.ImageStream = CType(resources.GetObject("imnodos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imnodos.TransparentColor = System.Drawing.Color.Transparent
        Me.imnodos.Images.SetKeyName(0, "vacio 8x8.png")
        Me.imnodos.Images.SetKeyName(1, "Flecha derecha 8x8.png")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(582, 420)
        Me.SplitContainer1.SplitterDistance = 193
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Usuarios)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Grupos)
        Me.SplitContainer2.Size = New System.Drawing.Size(193, 420)
        Me.SplitContainer2.SplitterDistance = 229
        Me.SplitContainer2.TabIndex = 3
        '
        'Usuarios
        '
        Me.Usuarios.Controls.Add(Me.twGrupos)
        Me.Usuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Usuarios.Location = New System.Drawing.Point(0, 0)
        Me.Usuarios.Name = "Usuarios"
        Me.Usuarios.Size = New System.Drawing.Size(193, 229)
        Me.Usuarios.TabIndex = 1
        Me.Usuarios.TabStop = False
        Me.Usuarios.Text = "Perfiles"
        '
        'twGrupos
        '
        Me.twGrupos.CheckBoxes = True
        Me.twGrupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.twGrupos.FullRowSelect = True
        Me.twGrupos.Location = New System.Drawing.Point(3, 16)
        Me.twGrupos.Name = "twGrupos"
        Me.twGrupos.Size = New System.Drawing.Size(187, 210)
        Me.twGrupos.TabIndex = 0
        '
        'Grupos
        '
        Me.Grupos.Controls.Add(Me.twusuarios)
        Me.Grupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grupos.Location = New System.Drawing.Point(0, 0)
        Me.Grupos.Name = "Grupos"
        Me.Grupos.Size = New System.Drawing.Size(193, 187)
        Me.Grupos.TabIndex = 2
        Me.Grupos.TabStop = False
        Me.Grupos.Text = "Usuarios"
        '
        'twusuarios
        '
        Me.twusuarios.CheckBoxes = True
        Me.twusuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.twusuarios.Location = New System.Drawing.Point(3, 16)
        Me.twusuarios.Name = "twusuarios"
        Me.twusuarios.Size = New System.Drawing.Size(187, 168)
        Me.twusuarios.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbGenerales)
        Me.TabControl1.Controls.Add(Me.tbEspeciales)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(385, 420)
        Me.TabControl1.TabIndex = 2
        '
        'tbGenerales
        '
        Me.tbGenerales.Controls.Add(Me.twPermisos)
        Me.tbGenerales.Controls.Add(Me.permisosBar)
        Me.tbGenerales.Location = New System.Drawing.Point(4, 22)
        Me.tbGenerales.Name = "tbGenerales"
        Me.tbGenerales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbGenerales.Size = New System.Drawing.Size(377, 394)
        Me.tbGenerales.TabIndex = 0
        Me.tbGenerales.Text = "Permisos generales"
        Me.tbGenerales.UseVisualStyleBackColor = True
        '
        'permisosBar
        '
        Me.permisosBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.permisosBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.txtBuscar, Me.btonBuscar, Me.btncontraer, Me.btnexpandir, Me.lbtipoSeguridad})
        Me.permisosBar.Location = New System.Drawing.Point(3, 3)
        Me.permisosBar.Name = "permisosBar"
        Me.permisosBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.permisosBar.Size = New System.Drawing.Size(371, 25)
        Me.permisosBar.TabIndex = 1
        Me.permisosBar.Text = "ToolStrip1"
        '
        'txtBuscar
        '
        Me.txtBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(250, 25)
        Me.txtBuscar.ToolTipText = "Busqueda de permisos"
        '
        'btonBuscar
        '
        Me.btonBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btonBuscar.Image = CType(resources.GetObject("btonBuscar.Image"), System.Drawing.Image)
        Me.btonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btonBuscar.Name = "btonBuscar"
        Me.btonBuscar.Size = New System.Drawing.Size(23, 22)
        Me.btonBuscar.Text = "ToolStripButton1"
        '
        'btncontraer
        '
        Me.btncontraer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btncontraer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btncontraer.Image = CType(resources.GetObject("btncontraer.Image"), System.Drawing.Image)
        Me.btncontraer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncontraer.Name = "btncontraer"
        Me.btncontraer.Size = New System.Drawing.Size(23, 22)
        Me.btncontraer.Text = "Contraer"
        '
        'btnexpandir
        '
        Me.btnexpandir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnexpandir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnexpandir.Image = CType(resources.GetObject("btnexpandir.Image"), System.Drawing.Image)
        Me.btnexpandir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnexpandir.Name = "btnexpandir"
        Me.btnexpandir.Size = New System.Drawing.Size(23, 22)
        Me.btnexpandir.Text = "Expandir"
        '
        'lbtipoSeguridad
        '
        Me.lbtipoSeguridad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbtipoSeguridad.Name = "lbtipoSeguridad"
        Me.lbtipoSeguridad.Size = New System.Drawing.Size(17, 22)
        Me.lbtipoSeguridad.Text = "--"
        '
        'tbEspeciales
        '
        Me.tbEspeciales.Location = New System.Drawing.Point(4, 22)
        Me.tbEspeciales.Name = "tbEspeciales"
        Me.tbEspeciales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbEspeciales.Size = New System.Drawing.Size(377, 394)
        Me.tbEspeciales.TabIndex = 1
        Me.tbEspeciales.Text = "Permisos especiales"
        Me.tbEspeciales.UseVisualStyleBackColor = True
        '
        'FrmPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 420)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmPermisos"
        Me.ShowIcon = False
        Me.Text = "Asignación Permisos"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Usuarios.ResumeLayout(False)
        Me.Grupos.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbGenerales.ResumeLayout(False)
        Me.tbGenerales.PerformLayout()
        Me.permisosBar.ResumeLayout(False)
        Me.permisosBar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents twPermisos As TreeView
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents twusuarios As TreeView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Usuarios As GroupBox
    Friend WithEvents Grupos As GroupBox
    Friend WithEvents twGrupos As TreeView
    Friend WithEvents permisosBar As ToolStrip
    Friend WithEvents txtBuscar As ToolStripTextBox
    Friend WithEvents btonBuscar As ToolStripButton
    Friend WithEvents btncontraer As ToolStripButton
    Friend WithEvents btnexpandir As ToolStripButton
    Friend WithEvents lbtipoSeguridad As ToolStripLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbGenerales As TabPage
    Friend WithEvents tbEspeciales As TabPage
    Friend WithEvents imnodos As ImageList
End Class
