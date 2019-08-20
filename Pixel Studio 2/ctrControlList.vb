Public Class ctrControlList

    Sub ResetScroll()
        cmdScroll.Top = 0

        If pnlMainList.Height > Me.Height Then
            pnlMainList.Top = (-pnlMainList.Height + Me.Height) * (cmdScroll.Top / (pnlScroll.Height - cmdScroll.Height))
        Else
            pnlMainList.Top = 0
        End If
    End Sub

    Public Sub ResetMainList()
        ResetScroll()
        Dim TotalHeight As Integer = 0
        For i As Integer = 0 To pnlMainList.Controls.Count - 1
            If pnlMainList.Controls(i).Visible Then TotalHeight += pnlMainList.Controls(i).Height
        Next
        pnlMainList.Height = TotalHeight
        ScrollList()
    End Sub

    Public Sub AddItem(c As Control, Optional ByVal LastOne As Boolean = False)
        c.Dock = DockStyle.Top
        pnlMainList.Controls.Add(c)
        c.BringToFront()
        If LastOne Then ScrollList()
    End Sub

    Public Sub AddControl(ByVal c As Control)
        c.Dock = DockStyle.Top
        pnlMainList.Controls.Add(c)
        c.BringToFront()
        ScrollList()
    End Sub

    Public Sub AddLabel(ByVal Label As String)
        Dim lblLabel As New Label
        lblLabel.Text = Label
        lblLabel.BackColor = Color.Transparent
        lblLabel.Height = 16
        'pnlMainList.Height += 16
        lblLabel.Dock = DockStyle.Top
        pnlMainList.Controls.Add(lblLabel)
        lblLabel.BringToFront()
        ScrollList()
    End Sub

    Public Sub AddSeparator()
        Dim pnlSeparator As New Panel
        pnlSeparator.Height = 6
        'pnlMainList.Height += pnlSeparator.Height
        pnlSeparator.BackColor = Color.Transparent
        pnlSeparator.Dock = DockStyle.Top
        pnlMainList.Controls.Add(pnlSeparator)
        pnlSeparator.BringToFront()
        ScrollList()
    End Sub

    Public Sub ClearItems()
        ResetScroll()
        Do Until pnlMainList.Controls.Count = 0
            pnlMainList.Controls(0).Dispose()
        Loop
        pnlMainList.Height = 0
        ScrollList()
    End Sub

    Dim ScrollLight As Boolean
    Private Sub cmdScroll_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScroll.MouseEnter
        ScrollLight = True
        cmdScroll.Refresh()
    End Sub
    Private Sub cmdScroll_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScroll.MouseLeave
        ScrollLight = False
        cmdScroll.Refresh()
    End Sub
    Private Sub cmdScroll_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles cmdScroll.Paint
        If ScrollLight Then e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(32, 255, 255, 255)), 2, 2, cmdScroll.Width - 4, cmdScroll.Height - 4)
    End Sub

    Dim MouseY As Integer
    Private Sub cmdScroll_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdScroll.MouseDown
        Me.Focus()
        MouseY = System.Windows.Forms.Cursor.Position.Y - cmdScroll.Top
    End Sub
    Private Sub cmdScroll_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdScroll.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim Y As Integer = System.Windows.Forms.Cursor.Position.Y - MouseY
            If Y < 0 Then Y = 0
            If Y > pnlScroll.Height - cmdScroll.Height Then Y = pnlScroll.Height - cmdScroll.Height
            cmdScroll.Top = Y

            If pnlMainList.Height > Me.Height Then
                pnlMainList.Top = (-pnlMainList.Height + Me.Height) * (cmdScroll.Top / (pnlScroll.Height - cmdScroll.Height))
            Else
                pnlMainList.Top = 0
            End If
        End If
    End Sub

    Private Sub ctrObjectsList_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        ScrollList(-e.Delta \ 3)
    End Sub
    Private Sub cmdScrollUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollUp.Click
        ScrollList(-pnlMainScroll.Height \ 10)
    End Sub
    Private Sub cmdScrollDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollDown.Click
        ScrollList(+pnlMainScroll.Height \ 10)
    End Sub

    Public Sub ScrollList(Optional ByVal Value As Short = 0)
        If pnlScroll.Height - cmdScroll.Height <= 0 Then Exit Sub
        If pnlScroll.Height <= pnlMainScroll.Height Then pnlScroll.Top = 0

        Dim y As Integer = cmdScroll.Top + Value
        If y < 0 Then y = 0
        If y > pnlScroll.Height - cmdScroll.Height Then y = pnlScroll.Height - cmdScroll.Height
        cmdScroll.Top = y

        If pnlMainList.Height > Me.Height Then
            pnlMainList.Top = (-pnlMainList.Height + Me.Height) * (cmdScroll.Top / (pnlScroll.Height - cmdScroll.Height))

            cmdScrollUp.Show()
            cmdScrollDown.Show()
            cmdScroll.Show()
        Else
            pnlMainList.Top = 0

            cmdScrollUp.Hide()
            cmdScrollDown.Hide()
            cmdScroll.Hide()
        End If
    End Sub

    Private Sub ctrObjectsList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ScrollList()
    End Sub


    Private Sub cmdScrollUp_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScrollUp.MouseEnter
        cmdScrollUp.BackgroundImage = My.Resources.SrollButtonBG
    End Sub
    Private Sub cmdScrollUp_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScrollUp.MouseLeave
        cmdScrollUp.BackgroundImage = My.Resources.ScrollBG
    End Sub
    Private Sub cmdScrollDown_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScrollDown.MouseEnter
        cmdScrollDown.BackgroundImage = My.Resources.SrollButtonBG
    End Sub
    Private Sub cmdScrollDown_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdScrollDown.MouseLeave
        cmdScrollDown.BackgroundImage = My.Resources.ScrollBG
    End Sub

    Private Sub pnlScroll_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlScroll.MouseDown
        Me.Select()
    End Sub
End Class
