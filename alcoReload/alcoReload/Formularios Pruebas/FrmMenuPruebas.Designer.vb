<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPruebas
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
        Me.mnpruebas = New System.Windows.Forms.MenuStrip()
        Me.PruebasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnedatagrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnasDatagridviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LibreriasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ParseadorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RTFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnpruebas.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnpruebas
        '
        Me.mnpruebas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PruebasToolStripMenuItem, Me.LibreriasToolStripMenuItem, Me.RTFToolStripMenuItem})
        Me.mnpruebas.Location = New System.Drawing.Point(0, 0)
        Me.mnpruebas.Name = "mnpruebas"
        Me.mnpruebas.Size = New System.Drawing.Size(478, 24)
        Me.mnpruebas.TabIndex = 1
        '
        'PruebasToolStripMenuItem
        '
        Me.PruebasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnedatagrid, Me.ColumnasDatagridviewToolStripMenuItem})
        Me.PruebasToolStripMenuItem.Name = "PruebasToolStripMenuItem"
        Me.PruebasToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.PruebasToolStripMenuItem.Text = "Controles"
        '
        'btnedatagrid
        '
        Me.btnedatagrid.Name = "btnedatagrid"
        Me.btnedatagrid.Size = New System.Drawing.Size(200, 22)
        Me.btnedatagrid.Text = "Extension Datagrid"
        '
        'ColumnasDatagridviewToolStripMenuItem
        '
        Me.ColumnasDatagridviewToolStripMenuItem.Name = "ColumnasDatagridviewToolStripMenuItem"
        Me.ColumnasDatagridviewToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ColumnasDatagridviewToolStripMenuItem.Text = "Columnas Datagridview"
        '
        'LibreriasToolStripMenuItem
        '
        Me.LibreriasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ParseadorToolStripMenuItem})
        Me.LibreriasToolStripMenuItem.Name = "LibreriasToolStripMenuItem"
        Me.LibreriasToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.LibreriasToolStripMenuItem.Text = "Librerias"
        '
        'ParseadorToolStripMenuItem
        '
        Me.ParseadorToolStripMenuItem.Name = "ParseadorToolStripMenuItem"
        Me.ParseadorToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.ParseadorToolStripMenuItem.Text = "Parseador"
        '
        'RTFToolStripMenuItem
        '
        Me.RTFToolStripMenuItem.Name = "RTFToolStripMenuItem"
        Me.RTFToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
        Me.RTFToolStripMenuItem.Text = "RTF"
        '
        'FrmMenuPruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 361)
        Me.Controls.Add(Me.mnpruebas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnpruebas
        Me.Name = "FrmMenuPruebas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Pruebas"
        Me.mnpruebas.ResumeLayout(False)
        Me.mnpruebas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnpruebas As MenuStrip
    Friend WithEvents PruebasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnedatagrid As ToolStripMenuItem
    Friend WithEvents LibreriasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ParseadorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColumnasDatagridviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RTFToolStripMenuItem As ToolStripMenuItem
End Class
