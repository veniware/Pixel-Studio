Public Class Invert
    Inherits BasicTool

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)

        Preview = Edit.InvertColors(My.Resources.oGramm48)
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Edit.InvertColors(B)
    End Function

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        If Preview IsNot Nothing Then e.Graphics.DrawImage(Preview, (Me.Width - Preview.Width) \ 2, 15 + (Me.Height - 18 - Preview.Height) \ 2)
    End Sub
End Class
