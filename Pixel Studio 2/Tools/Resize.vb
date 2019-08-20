Public Class Resize
    Inherits BasicTool

    Dim Value As Byte = 100

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Edit.Resize(B, Value)
    End Function

    Public Overrides Sub UpdatePreview()
        If (Linked IsNot Nothing) AndAlso (Linked.Invert IsNot Nothing) AndAlso (Linked.Invert.Tool.Preview IsNot Nothing) Then
            Preview = Linked.Invert.Tool.Preview
        End If

        If (Link IsNot Nothing) AndAlso (Link.Link IsNot Nothing) Then
            Link.Link.Tool.UpdatePreview()
        End If

        Me.Invalidate()
    End Sub

    Public Sub Resize_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmP As New frmValue
            frmP.txtValue.Minimum = 1
            frmP.txtValue.Maximum = 200
            frmP.txtValue.Value = Value
            If frmP.ShowDialog = DialogResult.OK Then
                Value = frmP.txtValue.Value
                Me.UpdatePreview()
                Me.Invalidate()
            End If
        End Using
    End Sub

    Private Sub Resize_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta > 0 Then
            If Value < 200 Then Value += 1
        ElseIf e.Delta < 0 Then
            If Value > 1 Then Value -= 1
        End If

        Me.UpdatePreview()
        Me.Invalidate()
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)
        e.Graphics.DrawString(Value & " %", frmMain.ftBigFont, Brushes.WhiteSmoke, Me.Width \ 2, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
    End Sub
End Class
