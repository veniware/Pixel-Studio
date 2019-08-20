Public Class getYellow
    Inherits BasicTool

    Public Sub New()
        Me.HasInput = True
        Me.HasOutput = True

        frmMain.ActiveLinkers.Add(Me.Link)
        frmMain.ActiveLinkers.Add(Me.Linked)

        Preview = Edit.getYellow(My.Resources.oGramm48)
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Edit.getYellow(B)
    End Function

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.DrawImage(Preview, 24, 20, 48, 48)
    End Sub

End Class