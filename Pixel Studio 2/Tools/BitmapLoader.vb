Public Class BitmapLoader
    Inherits BasicTool

    Public Filename As String
    Dim Image As Image

    Public Sub New()
        Me.HasOutput = True
        frmMain.ActiveLinkers.Add(Me.Link)
    End Sub

    Public Overrides Function ApplyEffect(B As System.Drawing.Image) As System.Drawing.Image
        Return Image.Clone
    End Function

    Public Overrides Sub UpdatePreview()
        'Preview = Preview

        If (Link IsNot Nothing) AndAlso (Link.Link IsNot Nothing) Then
            Link.Link.Tool.UpdatePreview()
        End If

        Me.Invalidate()
    End Sub

    Public Sub BitmapLoader_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmOpen As New OpenFileDialog
            frmOpen.Filter = "All Picture Files(*.bmp;*.dib;*.gif;*.jpg;*.jpe;*.jpeg;*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf)|*.bmp;*.dib;*.gif;*.jpg;*.jpe;*.jpeg;*.jfif;*.png;*.tif;*.tiff;*.wmf;*.emf|" & _
                             "Bitmap (*.bmp;*.dib)|*.bmp;*.dib|" & _
                             "PNG (*.png)|*.png|" & _
                             "GIF (*.gif)|*.gif|" & _
                             "JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" & _
                             "TIFF (*.tif;*.tiff)|*.tif;*.tiff|" & _
                             "WMF (*.wmf)|*.wmf|" & _
                             "EMF (*.emf)|*.emf"

            If frmOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
                Filename = frmOpen.FileName

                Try
                    If Me.Image IsNot Nothing Then Me.Image.Dispose()
                    If Me.Preview IsNot Nothing Then Me.Preview.Dispose()

                    Me.Image = Image.FromFile(Filename)

                    If Image.Width / (Me.Width - 6) < Image.Height / (Me.Height - 18) Then
                        Preview = New Bitmap((Me.Height - 18) * Image.Width \ Image.Height, Me.Height - 18)
                    Else
                        Preview = New Bitmap(Me.Width - 6, (Me.Width - 6) * Image.Height \ Image.Width)
                    End If

                    Using G As Graphics = Graphics.FromImage(Preview)
                        G.DrawImage(Image, 0, 0, Preview.Width, Preview.Height)
                    End Using

                    Me.UpdatePreview()

                    Me.Invalidate()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End Using
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)

        If Preview IsNot Nothing Then e.Graphics.DrawImage(Preview, (Me.Width - Preview.Width) \ 2, 15 + (Me.Height - 18 - Preview.Height) \ 2)
    End Sub

    Private Sub BitmapLoader_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Image IsNot Nothing Then Image.Dispose()
    End Sub
End Class
