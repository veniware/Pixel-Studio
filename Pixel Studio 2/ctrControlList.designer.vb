<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrControlList
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrControlList))
        Me.pnlMainList = New System.Windows.Forms.Panel()
        Me.pnlMainScroll = New System.Windows.Forms.Panel()
        Me.pnlScroll = New System.Windows.Forms.Panel()
        Me.cmdScroll = New System.Windows.Forms.Panel()
        Me.cmdScrollDown = New System.Windows.Forms.PictureBox()
        Me.cmdScrollUp = New System.Windows.Forms.PictureBox()
        Me.pnlMainScroll.SuspendLayout()
        Me.pnlScroll.SuspendLayout()
        CType(Me.cmdScrollDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdScrollUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMainList
        '
        Me.pnlMainList.AutoSize = True
        Me.pnlMainList.BackColor = System.Drawing.Color.Transparent
        Me.pnlMainList.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainList.MaximumSize = New System.Drawing.Size(182, 0)
        Me.pnlMainList.MinimumSize = New System.Drawing.Size(182, 0)
        Me.pnlMainList.Name = "pnlMainList"
        Me.pnlMainList.Size = New System.Drawing.Size(182, 0)
        Me.pnlMainList.TabIndex = 1
        '
        'pnlMainScroll
        '
        Me.pnlMainScroll.Controls.Add(Me.pnlScroll)
        Me.pnlMainScroll.Controls.Add(Me.cmdScrollDown)
        Me.pnlMainScroll.Controls.Add(Me.cmdScrollUp)
        Me.pnlMainScroll.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMainScroll.Location = New System.Drawing.Point(182, 0)
        Me.pnlMainScroll.Name = "pnlMainScroll"
        Me.pnlMainScroll.Size = New System.Drawing.Size(18, 275)
        Me.pnlMainScroll.TabIndex = 2
        '
        'pnlScroll
        '
        Me.pnlScroll.BackgroundImage = My.Resources.Resources.ScrollBG
        Me.pnlScroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlScroll.Controls.Add(Me.cmdScroll)
        Me.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlScroll.Location = New System.Drawing.Point(0, 18)
        Me.pnlScroll.Name = "pnlScroll"
        Me.pnlScroll.Size = New System.Drawing.Size(18, 239)
        Me.pnlScroll.TabIndex = 0
        '
        'cmdScroll
        '
        Me.cmdScroll.BackgroundImage = My.Resources.Resources.Scroll
        Me.cmdScroll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScroll.Location = New System.Drawing.Point(0, 0)
        Me.cmdScroll.Name = "cmdScroll"
        Me.cmdScroll.Size = New System.Drawing.Size(18, 40)
        Me.cmdScroll.TabIndex = 0
        '
        'cmdScrollDown
        '
        Me.cmdScrollDown.BackgroundImage = CType(resources.GetObject("cmdScrollDown.BackgroundImage"), System.Drawing.Image)
        Me.cmdScrollDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScrollDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdScrollDown.Image = My.Resources.Resources.ScrollDown
        Me.cmdScrollDown.Location = New System.Drawing.Point(0, 257)
        Me.cmdScrollDown.Name = "cmdScrollDown"
        Me.cmdScrollDown.Size = New System.Drawing.Size(18, 18)
        Me.cmdScrollDown.TabIndex = 2
        Me.cmdScrollDown.TabStop = False
        '
        'cmdScrollUp
        '
        Me.cmdScrollUp.BackgroundImage = My.Resources.Resources.ScrollBG
        Me.cmdScrollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmdScrollUp.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmdScrollUp.Image = My.Resources.Resources.ScrollUp
        Me.cmdScrollUp.Location = New System.Drawing.Point(0, 0)
        Me.cmdScrollUp.Name = "cmdScrollUp"
        Me.cmdScrollUp.Size = New System.Drawing.Size(18, 18)
        Me.cmdScrollUp.TabIndex = 1
        Me.cmdScrollUp.TabStop = False
        '
        'ctrControlList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.Controls.Add(Me.pnlMainScroll)
        Me.Controls.Add(Me.pnlMainList)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Name = "ctrControlList"
        Me.Size = New System.Drawing.Size(200, 275)
        Me.pnlMainScroll.ResumeLayout(False)
        Me.pnlScroll.ResumeLayout(False)
        CType(Me.cmdScrollDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdScrollUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlScroll As System.Windows.Forms.Panel
    Friend WithEvents cmdScroll As System.Windows.Forms.Panel
    Friend WithEvents pnlMainList As System.Windows.Forms.Panel
    Friend WithEvents pnlMainScroll As System.Windows.Forms.Panel
    Friend WithEvents cmdScrollDown As System.Windows.Forms.PictureBox
    Friend WithEvents cmdScrollUp As System.Windows.Forms.PictureBox

End Class
