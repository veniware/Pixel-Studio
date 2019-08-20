Public Class frmRender
    Public T As Threading.Thread

    Shared ActiveBrush As New SolidBrush(Color.FromArgb(128, 128, 128))
    Shared LightBrush As New SolidBrush(Color.FromArgb(72, 72, 72))
    Shared DarkBrush As New SolidBrush(Color.FromArgb(96, 96, 96))

    Enum ShitType
        none = 0
        err = 1
        warning = 2
        apply = 3
    End Enum

    Structure ShitItem
        Dim Label As String
        Dim Type As ShitType
    End Structure

    Dim ListOfShit As New List(Of ShitItem)

    Public Sub AddShit(Label As String, Type As Byte)
        Dim newShit As New ShitItem
        newShit.Label = Label
        newShit.Type = Type
        ListOfShit.Add(newShit)
        lstProgress.Items.Add(Label)

        lstProgress.SelectedIndex = lstProgress.Items.Count - 1
    End Sub

    Private Sub lstProgress_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles lstProgress.DrawItem
        If e.Index = -1 Then Exit Sub

        If e.Index Mod 2 = 0 Then
            e.Graphics.FillRectangle(LightBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        Else
            e.Graphics.FillRectangle(DarkBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        End If

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then e.Graphics.FillRectangle(ActiveBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)

        Select Case ListOfShit(e.Index).Type
            Case ShitType.err
                e.Graphics.DrawImage(My.Resources._Error, e.Bounds.X + 2, e.Bounds.Y + 2, 20, 20)

            Case ShitType.warning
                e.Graphics.DrawImage(My.Resources.Warning, e.Bounds.X + 2, e.Bounds.Y + 2, 20, 20)

            Case ShitType.apply
                e.Graphics.DrawImage(My.Resources.Apply, e.Bounds.X + 2, e.Bounds.Y + 2, 20, 20)
        End Select

        e.Graphics.DrawString(ListOfShit(e.Index).Label, Me.Font, Brushes.White, e.Bounds.X + 24, e.Bounds.Y + 4)
    End Sub

    Sub cmdCancel_Press() Handles cmdCancel.Press
        If T IsNot Nothing Then If T.IsAlive Then T.Abort()
        Me.DialogResult = DialogResult.OK
    End Sub
End Class