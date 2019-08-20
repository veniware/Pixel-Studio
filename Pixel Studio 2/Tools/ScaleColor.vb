Public Class ScaleColor
    Inherits BasicTool

    Dim Value As Byte = 15

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)

        Preview = Edit.ScaleColors(My.Resources.oGramm48, Value)
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return ScaleColors(B, Value)
    End Function

    Public Sub Scale_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmP As New frmValue
            frmP.txtValue.Minimum = 2
            frmP.txtValue.Maximum = 256
            frmP.txtValue.Value = Value + 1
            If frmP.ShowDialog = DialogResult.OK Then
                Value = frmP.txtValue.Value - 1

                UpdatePreview()
                Me.Invalidate()
            End If
        End Using
    End Sub

    Private Sub Scale_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            If Value < 255 Then Value += 1
        ElseIf e.Delta < 0 Then
            If Value > 1 Then Value -= 1
        End If

        UpdatePreview()
        Me.Invalidate()
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.DrawImage(Preview, 24, 20, 48, 48)
        e.Graphics.DrawString(Value + 1 & " Lev.", frmMain.ftBigFont, Brushes.WhiteSmoke, 108, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
    End Sub
End Class
