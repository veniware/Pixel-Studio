<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BasicTool
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnlinkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ValueToolStripMenuItem, Me.UnlinkToolStripMenuItem, Me.ToolStripMenuItem1, Me.DeleteToolStripMenuItem})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(153, 98)
        '
        'ValueToolStripMenuItem
        '
        Me.ValueToolStripMenuItem.Name = "ValueToolStripMenuItem"
        Me.ValueToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ValueToolStripMenuItem.Text = "Value"
        '
        'UnlinkToolStripMenuItem
        '
        Me.UnlinkToolStripMenuItem.Name = "UnlinkToolStripMenuItem"
        Me.UnlinkToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UnlinkToolStripMenuItem.Text = "Unlink"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'BasicTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.Pixel_Studio_2.My.Resources.Resources.ToolBG
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ContextMenuStrip = Me.cmsMenu
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Name = "BasicTool"
        Me.Size = New System.Drawing.Size(150, 75)
        Me.cmsMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ValueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnlinkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
