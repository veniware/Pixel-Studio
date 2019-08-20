<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlMainScroll = New System.Windows.Forms.Panel()
        Me.pnlMain = New Pixel_Studio_2.pnlDoubleBufferd()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstTools = New Pixel_Studio_2.ctrControlList()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.pnlMainScroll.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMainScroll
        '
        Me.pnlMainScroll.Controls.Add(Me.pnlMain)
        Me.pnlMainScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMainScroll.Location = New System.Drawing.Point(200, 63)
        Me.pnlMainScroll.Name = "pnlMainScroll"
        Me.pnlMainScroll.Size = New System.Drawing.Size(520, 417)
        Me.pnlMainScroll.TabIndex = 1
        '
        'pnlMain
        '
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(8192, 8192)
        Me.pnlMain.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MenuStrip1.BackgroundImage = Global.Pixel_Studio_2.My.Resources.Resources.MainMenuhigh
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ViewToolStripMenuItem, Me.RenderToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(720, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'RenderToolStripMenuItem
        '
        Me.RenderToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckToolStripMenuItem, Me.RenderToolStripMenuItem1})
        Me.RenderToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RenderToolStripMenuItem.Name = "RenderToolStripMenuItem"
        Me.RenderToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.RenderToolStripMenuItem.Text = "Render"
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.CheckToolStripMenuItem.Text = "Check"
        '
        'RenderToolStripMenuItem1
        '
        Me.RenderToolStripMenuItem1.Name = "RenderToolStripMenuItem1"
        Me.RenderToolStripMenuItem1.Size = New System.Drawing.Size(111, 22)
        Me.RenderToolStripMenuItem1.Text = "Render"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'lstTools
        '
        Me.lstTools.BackColor = System.Drawing.Color.DimGray
        Me.lstTools.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstTools.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lstTools.Location = New System.Drawing.Point(0, 63)
        Me.lstTools.Name = "lstTools"
        Me.lstTools.Size = New System.Drawing.Size(200, 417)
        Me.lstTools.TabIndex = 0
        '
        'pnlMenu
        '
        Me.pnlMenu.BackgroundImage = Global.Pixel_Studio_2.My.Resources.Resources.MainMenuLow
        Me.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMenu.Location = New System.Drawing.Point(0, 24)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(720, 39)
        Me.pnlMenu.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(720, 480)
        Me.Controls.Add(Me.pnlMainScroll)
        Me.Controls.Add(Me.lstTools)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(480, 320)
        Me.Name = "frmMain"
        Me.Text = "Pixel Studio 2.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMainScroll.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstTools As ctrControlList
    Friend WithEvents pnlMain As pnlDoubleBufferd
    Friend WithEvents pnlMainScroll As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenderToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlMenu As System.Windows.Forms.Panel
End Class
