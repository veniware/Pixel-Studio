<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRawOptions
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
        Me.lblFormat = New System.Windows.Forms.Label()
        Me.cmbFormat = New System.Windows.Forms.ComboBox()
        Me.lblX = New System.Windows.Forms.Label()
        Me.txtH = New System.Windows.Forms.NumericUpDown()
        Me.txtW = New System.Windows.Forms.NumericUpDown()
        Me.lblSize = New System.Windows.Forms.Label()
        CType(Me.txtH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOK
        '
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdOK.Location = New System.Drawing.Point(39, 89)
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
        Me.cmdCancel.Location = New System.Drawing.Point(120, 89)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblFormat
        '
        Me.lblFormat.AutoSize = True
        Me.lblFormat.Location = New System.Drawing.Point(12, 15)
        Me.lblFormat.Name = "lblFormat"
        Me.lblFormat.Size = New System.Drawing.Size(46, 13)
        Me.lblFormat.TabIndex = 5
        Me.lblFormat.Text = "Format:"
        '
        'cmbFormat
        '
        Me.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormat.FormattingEnabled = True
        Me.cmbFormat.Items.AddRange(New Object() {"Gray", "RGB", "BGR"})
        Me.cmbFormat.Location = New System.Drawing.Point(64, 12)
        Me.cmbFormat.Name = "cmbFormat"
        Me.cmbFormat.Size = New System.Drawing.Size(158, 21)
        Me.cmbFormat.TabIndex = 6
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(137, 45)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(12, 13)
        Me.lblX.TabIndex = 8
        Me.lblX.Text = "x"
        '
        'txtH
        '
        Me.txtH.Location = New System.Drawing.Point(157, 43)
        Me.txtH.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.txtH.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtH.Name = "txtH"
        Me.txtH.Size = New System.Drawing.Size(65, 22)
        Me.txtH.TabIndex = 9
        Me.txtH.Value = New Decimal(New Integer() {256, 0, 0, 0})
        '
        'txtW
        '
        Me.txtW.Location = New System.Drawing.Point(64, 43)
        Me.txtW.Maximum = New Decimal(New Integer() {8192, 0, 0, 0})
        Me.txtW.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtW.Name = "txtW"
        Me.txtW.Size = New System.Drawing.Size(65, 22)
        Me.txtW.TabIndex = 7
        Me.txtW.Value = New Decimal(New Integer() {256, 0, 0, 0})
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Location = New System.Drawing.Point(12, 45)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(30, 13)
        Me.lblSize.TabIndex = 10
        Me.lblSize.Text = "Size:"
        '
        'frmRawOptions
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(234, 124)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.txtH)
        Me.Controls.Add(Me.txtW)
        Me.Controls.Add(Me.cmbFormat)
        Me.Controls.Add(Me.lblFormat)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRawOptions"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Size"
        CType(Me.txtH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblFormat As System.Windows.Forms.Label
    Friend WithEvents cmbFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents txtH As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtW As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSize As System.Windows.Forms.Label
End Class
