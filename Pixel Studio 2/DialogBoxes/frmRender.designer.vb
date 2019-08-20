<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRender
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
        Me.lstProgress = New System.Windows.Forms.ListBox()
        Me.prgLoad = New System.Windows.Forms.ProgressBar()
        Me.cmdCancel = New Pixel_Studio_2.ctrButton()
        Me.SuspendLayout()
        '
        'lstProgress
        '
        Me.lstProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstProgress.BackColor = System.Drawing.Color.DimGray
        Me.lstProgress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lstProgress.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.lstProgress.ForeColor = System.Drawing.Color.White
        Me.lstProgress.FormattingEnabled = True
        Me.lstProgress.ItemHeight = 24
        Me.lstProgress.Location = New System.Drawing.Point(12, 12)
        Me.lstProgress.Name = "lstProgress"
        Me.lstProgress.Size = New System.Drawing.Size(696, 347)
        Me.lstProgress.TabIndex = 1
        '
        'prgLoad
        '
        Me.prgLoad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgLoad.Location = New System.Drawing.Point(12, 370)
        Me.prgLoad.Name = "prgLoad"
        Me.prgLoad.Size = New System.Drawing.Size(696, 23)
        Me.prgLoad.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdCancel.Enable = True
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmdCancel.Label = "Cancel"
        Me.cmdCancel.Location = New System.Drawing.Point(608, 399)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 26)
        Me.cmdCancel.TabIndex = 3
        '
        'frmRender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(720, 437)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.prgLoad)
        Me.Controls.Add(Me.lstProgress)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRender"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Render"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstProgress As System.Windows.Forms.ListBox
    Friend WithEvents prgLoad As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdCancel As Pixel_Studio_2.ctrButton
End Class
