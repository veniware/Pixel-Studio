Public Class Gamma
    Inherits BasicTool

    Dim Value As UShort = 100

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)

        Preview = My.Resources.oGramm48
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Edit.Gamma(B, Value)
    End Function

    Public Sub Brightness_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmP As New frmValue
            frmP.txtValue.Minimum = 1
            frmP.txtValue.Maximum = 500
            frmP.txtValue.Value = Value
            If frmP.ShowDialog = DialogResult.OK Then
                Value = frmP.txtValue.Value

                UpdatePreview()
                Me.Invalidate()
            End If
        End Using
    End Sub

    Private Sub Brightness_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            If Value < 500 Then Value += 1
        ElseIf e.Delta < 0 Then
            If Value > 1 Then Value -= 1
        End If

        UpdatePreview()
        Me.Invalidate()
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.DrawImage(Preview, 24, 20, 48, 48)

        If Value > 0 Then
            e.Graphics.DrawString("+" & Value & " %", frmMain.ftBigFont, Brushes.WhiteSmoke, 108, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
        ElseIf Value < 0 Then
            e.Graphics.DrawString(Value & " %", frmMain.ftBigFont, Brushes.WhiteSmoke, 108, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
        Else
            e.Graphics.DrawString("0 %", frmMain.ftBigFont, Brushes.WhiteSmoke, 108, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
        End If
    End Sub

End Class
