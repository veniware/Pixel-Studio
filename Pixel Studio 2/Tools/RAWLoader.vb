Public Class RAWLoader
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
            frmOpen.Filter = "RAW file (*.raw)|*.raw"

            If frmOpen.ShowDialog = Windows.Forms.DialogResult.OK Then
                Filename = frmOpen.FileName

                Using frmOpt As New frmRawOptions
                    If frmOpt.ShowDialog = DialogResult.OK Then

                        Try
                            If Me.Image IsNot Nothing Then Me.Image.Dispose()
                            If Me.Preview IsNot Nothing Then Me.Preview.Dispose()

                            If frmOpt.cmbFormat.SelectedIndex = 0 Then 'Gray
                                Me.Image = RawIO.LoadGray(Filename, New Size(frmOpt.txtW.Value, frmOpt.txtH.Value))
                            ElseIf frmOpt.cmbFormat.SelectedIndex = 1 Then 'RGB
                                Me.Image = RawIO.LoadRGB(Filename, New Size(frmOpt.txtW.Value, frmOpt.txtH.Value))
                            End If


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

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'RAWLoader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "RAWLoader"
        Me.ResumeLayout(False)

    End Sub

    Private Sub RAWLoader_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
