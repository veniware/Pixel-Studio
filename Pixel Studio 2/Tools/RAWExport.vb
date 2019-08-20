Public Class RAWExport
    Inherits BasicTool

    Public Filename As String
    Public Format As Byte = 0

    Public Sub New()
        Me.HasInput = True
        frmMain.ActiveLinkers.Add(Me.Linked)
    End Sub

    Public Overrides Sub UpdatePreview()
        'MyBase.UpdatePreview()
    End Sub

    Public Sub Export_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmSave As New SaveFileDialog
            frmSave.Filter = "RAW (*.raw)|*.raw"

            frmSave.FileName = Filename
            If frmSave.ShowDialog = DialogResult.OK Then
                Dim File As New IO.FileInfo(frmSave.FileName)
                Filename = File.FullName

                Using frmOpt As New frmRawOptions
                    frmOpt.txtW.Enabled = False
                    frmOpt.txtH.Enabled = False

                    If frmOpt.ShowDialog = DialogResult.OK Then
                        Format = frmOpt.cmbFormat.SelectedIndex
                    End If
                End Using

                Me.Invalidate()
            End If
        End Using
    End Sub

    Friend Overrides Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        MyBase.BasicTool_Paint(sender, e)
        e.Graphics.DrawString(Filename, Me.Font, Brushes.WhiteSmoke, New Rectangle(16, 16, Me.Width - 32, Me.Height - 24), frmMain.sfCenterCenter)
    End Sub
End Class
