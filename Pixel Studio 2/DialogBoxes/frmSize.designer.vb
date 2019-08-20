<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSize
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
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtW = New System.Windows.Forms.NumericUpDown()
        Me.txtH = New System.Windows.Forms.NumericUpDown()
        Me.lblX = New System.Windows.Forms.Label()
        CType(Me.txtW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtH, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(12, 67)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCancel.Location = New System.Drawing.Point(93, 67)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtW
        '
        Me.txtW.Location = New System.Drawing.Point(12, 25)
        Me.txtW.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.txtW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtW.Name = "txtW"
        Me.txtW.Size = New System.Drawing.Size(65, 22)
        Me.txtW.TabIndex = 0
        Me.txtW.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'txtH
        '
        Me.txtH.Location = New System.Drawing.Point(103, 25)
        Me.txtH.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.txtH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtH.Name = "txtH"
        Me.txtH.Size = New System.Drawing.Size(65, 22)
        Me.txtH.TabIndex = 2
        Me.txtH.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(84, 27)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(12, 13)
        Me.lblX.TabIndex = 1
        Me.lblX.Text = "x"
        '
        'frmSize
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(180, 102)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.txtH)
        Me.Controls.Add(Me.txtW)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSize"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Size"
        CType(Me.txtW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtH, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtW As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtH As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblX As System.Windows.Forms.Label
End Class
