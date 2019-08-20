Public Class Blur
    Inherits BasicTool

    Dim Value As Byte = 12

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)

        UpdatePreview()
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Edit.Blur(B, Value)
    End Function

    Public Overrides Sub UpdatePreview()
        If (Linked IsNot Nothing) AndAlso (Linked.Invert IsNot Nothing) AndAlso (Linked.Invert.Tool.Preview IsNot Nothing) Then
            Dim W, H As Integer
            W = Linked.Invert.Tool.Preview.Width \ Value
            H = Linked.Invert.Tool.Preview.Height \ Value
            If W = 0 Then W = 1
            If H = 0 Then H = 1

            Dim newP2 As New Bitmap(W, H, Linked.Invert.Tool.Preview.PixelFormat)
            Using G As Graphics = Graphics.FromImage(newP2)
                G.DrawImage(Linked.Invert.Tool.Preview, 0, 0, W, H)
            End Using

            Dim newP As New Bitmap(Linked.Invert.Tool.Preview.Width, Linked.Invert.Tool.Preview.Height, Linked.Invert.Tool.Preview.PixelFormat)
            Using G As Graphics = Graphics.FromImage(newP)
                G.DrawImage(newP2, 0, 0, newP.Width, newP.Width)
            End Using

            newP2.Dispose()

            Preview = newP
        End If

        If (Link IsNot Nothing) AndAlso (Link.Link IsNot Nothing) Then
            Link.Link.Tool.UpdatePreview()
        End If

        Me.Invalidate()
    End Sub

    Public Sub Resize_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmP As New frmValue
            frmP.txtValue.Minimum = 1
            frmP.txtValue.Maximum = 64
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
            If Value < 64 Then Value += 1
        ElseIf e.Delta < 0 Then
            If Value > 1 Then Value -= 1
        End If

        Me.UpdatePreview()
        Me.Invalidate()
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.DrawString(Value & " pxls", frmMain.ftBigFont, Brushes.WhiteSmoke, 108, Me.Height \ 2 + 7, frmMain.sfCenterCenter)
        If Preview IsNot Nothing Then e.Graphics.DrawImage(Preview, 24, 20, 48, 48)
    End Sub
End Class
