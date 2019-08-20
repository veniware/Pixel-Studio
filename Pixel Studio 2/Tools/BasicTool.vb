Public Class BasicTool
    Implements IDisposable

    Event ActivateDefalutFunction()

    Property Title As String
    Property TitleColor As Color

    Property HasInput As Boolean
    Property HasOutput As Boolean

    Public WithEvents Link As New ToolsLink
    Public WithEvents Linked As New ToolsLink

    Friend Preview As Image

    Dim MoveOn As Boolean
    Dim LinkOn As Boolean
    Dim LinkedOn As Boolean

    Public Sub New()
        InitializeComponent()

        Link.isForLink = True
        Linked.isForLink = False

        Link.Tool = Me
        Linked.Tool = Me
    End Sub

    Public Overridable Function ApplyEffect(B As Image) As Image
        Return B
    End Function

    Public Overridable Sub UpdatePreview()
        If (Linked IsNot Nothing) AndAlso (Linked.Invert IsNot Nothing) AndAlso (Linked.Invert.Tool.Preview IsNot Nothing) Then
            Preview = ApplyEffect(Linked.Invert.Tool.Preview)
        Else
            Preview = ApplyEffect(My.Resources.oGramm48)
        End If

        If (Link IsNot Nothing) AndAlso (Link.Link IsNot Nothing) Then
            Link.Link.Tool.UpdatePreview()
        End If

        Me.Invalidate()
    End Sub

    Sub Link_LinkChanged() Handles Link.LinkChanged
        UpdatePreview()
    End Sub
    Sub Linked_LinkChanged() Handles Linked.LinkChanged
        UpdatePreview()
    End Sub

    Friend MP, PP As New Point
    Friend Overridable Sub BasicTool_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Me.BringToFront()
        MP = Cursor.Position
        PP = Me.Location

        If (HasInput AndAlso e.X <= 8) Then
            LinkedOn = True
            frmMain.LinkDraw = True
        ElseIf (HasOutput AndAlso e.X >= Me.Width - 8) Then
            LinkOn = True
            frmMain.LinkDraw = True
        Else
            MoveOn = True
        End If
    End Sub

    Friend Overridable Sub BasicTool_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        frmMain.LinkDraw = False

        If LinkOn Then
            Dim x As Integer = Me.Left + e.X
            Dim y As Integer = Me.Top + e.Y
            For i As Integer = 0 To frmMain.ActiveLinkers.Count - 1
                If Not frmMain.ActiveLinkers(i).isForLink AndAlso _
                   x > frmMain.ActiveLinkers(i).Location.X - 10 AndAlso x < frmMain.ActiveLinkers(i).Location.X + 10 AndAlso _
                   y > frmMain.ActiveLinkers(i).Location.Y - 9 AndAlso y < frmMain.ActiveLinkers(i).Location.Y + 9 Then

                    If frmMain.ActiveLinkers(i).Invert IsNot Nothing Then frmMain.ActiveLinkers(i).Invert.Unlink()

                    Me.Link.Link = frmMain.ActiveLinkers(i)
                    frmMain.ActiveLinkers(i).Invert = Me.Link

                    Link.Link.RaiseLinkChanged()

                    frmMain.pnlMain.Invalidate()
                    Exit Sub
                End If
            Next
            frmMain.pnlMain.Invalidate()

        ElseIf LinkedOn Then
            Dim x As Integer = Me.Left + e.X
            Dim y As Integer = Me.Top + e.Y
            For i As Integer = 0 To frmMain.ActiveLinkers.Count - 1
                If frmMain.ActiveLinkers(i).isForLink AndAlso _
                   x > frmMain.ActiveLinkers(i).Location.X - 10 AndAlso x < frmMain.ActiveLinkers(i).Location.X + 10 AndAlso _
                   y > frmMain.ActiveLinkers(i).Location.Y - 9 AndAlso y < frmMain.ActiveLinkers(i).Location.Y + 9 Then

                    If Linked.Invert IsNot Nothing Then Linked.Invert.Unlink()

                    frmMain.ActiveLinkers(i).Link = Linked
                    Linked.Invert = frmMain.ActiveLinkers(i)

                    Linked.RaiseLinkChanged()

                    frmMain.pnlMain.Invalidate()
                    Exit Sub
                End If
            Next
            frmMain.pnlMain.Invalidate()

        End If

        MoveOn = False
        LinkOn = False
        LinkedOn = False
    End Sub

    Friend Overridable Sub BasicTool_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.X <= 8 AndAlso HasInput Then
            Me.Cursor = Cursors.UpArrow
        ElseIf e.X >= Me.Width - 8 AndAlso HasOutput Then
            Me.Cursor = Cursors.UpArrow
        Else
            Me.Cursor = Cursors.Default
        End If

        If MoveOn AndAlso e.Button = MouseButtons.Left Then
            Dim P As Point = New Point(PP.X + (System.Windows.Forms.Cursor.Position.X - MP.X), PP.Y + (System.Windows.Forms.Cursor.Position.Y - MP.Y))
            If P.X < 0 Then P.X = 0
            If P.Y < 0 Then P.Y = 0
            Me.Location = P

        ElseIf (LinkOn OrElse LinkedOn) AndAlso e.Button = MouseButtons.Left Then
            Dim RP1 As Point
            Dim RP2 As Point

            RP1 = New Point(Math.Min(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) - 4, Math.Min(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) - 4)
            RP2 = New Point(Math.Max(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) + 4, Math.Max(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) + 4)
            frmMain.pnlMain.Invalidate(New Rectangle(RP1.X, RP1.Y, RP2.X - RP1.X, RP2.Y - RP1.Y))

            If LinkOn Then frmMain.LinkDraw1 = Link.Location Else If LinkedOn Then frmMain.LinkDraw1 = Linked.Location
            frmMain.LinkDraw2 = New Point(Me.Left + e.X, Me.Top + e.Y)

            RP1 = New Point(Math.Min(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) - 4, Math.Min(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) - 4)
            RP2 = New Point(Math.Max(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) + 4, Math.Max(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) + 4)
            frmMain.pnlMain.Invalidate(New Rectangle(RP1.X, RP1.Y, RP2.X - RP1.X, RP2.Y - RP1.Y))
        End If
    End Sub

    Friend Overridable Sub BasicTool_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, TitleColor)), 0, 0, Me.Width, 14)
        e.Graphics.DrawString(Title, Me.Font, New SolidBrush(Me.ForeColor), New Rectangle(0, 0, Me.Width, 14), frmMain.sfCenter)

        If Me.Focused Then
            e.Graphics.DrawRectangle(frmMain.p, 1, 1, Me.Width - 3, Me.Height - 3)
        End If

        If HasInput Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), 0, 35, 8, Me.Height - 58)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 0, 35, 8, Me.Height - 58)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 8, 36, 1, Me.Height - 60)
        End If

        If HasOutput Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), Me.Width - 8, 35, 8, Me.Height - 58)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), Me.Width - 8, 35, 8, Me.Height - 58)
            e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), Me.Width - 9, 36, 1, Me.Height - 60)
        End If
    End Sub

    Private Sub BasicTool_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        Me.Invalidate()
    End Sub
    Private Sub BasicTool_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Friend Overridable Sub BasicTool_Move(sender As Object, e As System.EventArgs) Handles Me.Move
        Linked.Location.X = Me.Left
        Linked.Location.Y = Me.Top + 44

        Link.Location.X = Me.Left + Me.Width
        Link.Location.Y = Me.Top + 44

        frmMain.pnlMain.Invalidate()
    End Sub

    Private Sub BasicTool_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
        RaiseEvent ActivateDefalutFunction()
    End Sub
    Private Sub BasicTool_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = 13 Then RaiseEvent ActivateDefalutFunction()
    End Sub

    Private Sub BasicTool_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        If Preview IsNot Nothing Then Preview.Dispose()
    End Sub


    Private Sub ValueToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ValueToolStripMenuItem.Click
        RaiseEvent ActivateDefalutFunction()
    End Sub

    Private Sub UnlinkToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UnlinkToolStripMenuItem.Click
        Link.Unlink()
        Linked.Unlink()
        frmMain.pnlMain.Invalidate()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Link.Unlink()
        Linked.Unlink()
        frmMain.pnlMain.Invalidate()

        Me.Dispose()
    End Sub
End Class
