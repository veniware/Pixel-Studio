Public Class SolidBitmap
    Inherits BasicTool

    Public Color As Color = Drawing.Color.Black
    Dim Brush As New SolidBrush(Drawing.Color.Black)
    'Dim ResultSize As New Size(128, 128)

    Public Sub New()
        Me.HasOutput = True
        frmMain.ActiveLinkers.Add(Me.Link)

        Preview = New Bitmap(40, 40, Imaging.PixelFormat.Format24bppRgb)
        Using G As Graphics = Graphics.FromImage(Preview)
            G.Clear(Color)
        End Using
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Dim newB As Image = New Bitmap(40, 40, Imaging.PixelFormat.Format24bppRgb)
        Using G As Graphics = Graphics.FromImage(newB)
            G.Clear(Color)
        End Using
        Return newB
    End Function

    Public Sub SolidColor_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Dim frmColor As New ColorDialog
        frmColor.Color = Me.Color
        If frmColor.ShowDialog = DialogResult.OK Then

            Color = frmColor.Color
            Brush = New SolidBrush(Me.Color)

            If Preview IsNot Nothing Then Preview.Dispose()
            Preview = New Bitmap(40, 40, Imaging.PixelFormat.Format24bppRgb)
            Using G As Graphics = Graphics.FromImage(Preview)
                G.Clear(Color)
            End Using

            Me.UpdatePreview()

            Me.Invalidate()
        End If
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.FillRectangle(Brush, 24, 20, 48, 48)

        e.Graphics.DrawString("R: " & Color.R, Me.Font, Brushes.White, 84, 20)
        e.Graphics.DrawString("G: " & Color.G, Me.Font, Brushes.White, 84, 36)
        e.Graphics.DrawString("B: " & Color.B, Me.Font, Brushes.White, 84, 52)
    End Sub
End Class
