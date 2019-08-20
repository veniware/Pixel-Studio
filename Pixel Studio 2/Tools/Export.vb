Public Class Export
    Inherits BasicTool

    Public Filename As String
    Public Format As Imaging.ImageFormat

    Public Sub New()
        Me.HasInput = True
        frmMain.ActiveLinkers.Add(Me.Linked)
    End Sub

    Public Overrides Sub UpdatePreview()
        'MyBase.UpdatePreview()
    End Sub

    Public Sub Export_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmSave As New SaveFileDialog
            frmSave.Filter = "Bitmap (*.bmp;*.dib)|*.bmp;*.dib|" & _
                  "PNG (*.png)|*.png|" & _
                  "GIF (*.gif)|*.gif|" & _
                  "JPEG (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" & _
                  "TIFF (*.tif;*.tiff)|*.tif;*.tiff|" & _
                  "WMF (*.wmf)|*.wmf|" & _
                  "EMF (*.emf)|*.emf"
            frmSave.FilterIndex = 2

            frmSave.FileName = Filename
            If frmSave.ShowDialog = DialogResult.OK Then
                Dim File As New IO.FileInfo(frmSave.FileName)
                Filename = File.FullName

                Select Case File.Extension.ToLower
                    Case ".bmp", ".dib" : Format = Imaging.ImageFormat.Bmp
                    Case ".png" : Format = Imaging.ImageFormat.Png
                    Case ".gif" : Format = Imaging.ImageFormat.Gif
                    Case ".jpg", ".jpeg", ".jpe", ".jfif" : Format = Imaging.ImageFormat.Jpeg
                    Case ".tif", ".tiff" : Format = Imaging.ImageFormat.Tiff
                    Case ".wmf" : Format = Imaging.ImageFormat.Wmf
                    Case ".emf" : Format = Imaging.ImageFormat.Emf
                End Select

                Me.Invalidate()
            End If
        End Using
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)
        e.Graphics.DrawString(Filename, Me.Font, Brushes.WhiteSmoke, New Rectangle(16, 16, Me.Width - 32, Me.Height - 24), frmMain.sfCenterCenter)
    End Sub
End Class
