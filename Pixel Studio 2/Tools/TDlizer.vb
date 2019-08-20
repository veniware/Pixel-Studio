Public Class TDlizer
    Inherits BasicTool

    Public Diffuse As New ToolsLink
    Public Specular As New ToolsLink
    Public Transparent As New ToolsLink
    Public Z As New ToolsLink

    Public Filename As String = ""

    Public Sub New()
        Me.Size = New Size(150, 150)

        Diffuse.Tool = Me
        Specular.Tool = Me
        Transparent.Tool = Me
        Z.Tool = Me

        frmMain.ActiveLinkers.Add(Diffuse)
        frmMain.ActiveLinkers.Add(Specular)
        frmMain.ActiveLinkers.Add(Transparent)
        frmMain.ActiveLinkers.Add(Z)

        Me.ContextMenuStrip = Nothing
    End Sub

    Public Overrides Sub UpdatePreview()
        'MyBase.UpdatePreview()
    End Sub

    Public Sub TDlixer_ActivateDefalutFunction() Handles Me.ActivateDefalutFunction
        Using frmSave As New SaveFileDialog
            frmSave.FileName = Filename
            frmSave.Filter = "OBJ File (*.obj)|*.obj"

            If frmSave.ShowDialog = DialogResult.OK Then
                Filename = frmSave.FileName
                Me.Invalidate()
            End If
        End Using
    End Sub

    Dim toLink As ToolsLink

    Friend Overrides Sub BasicTool_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Me.Focus()

        Me.BringToFront()
        MP = Cursor.Position
        PP = Me.Location

        If e.X <= 8 AndAlso e.Y >= 20 AndAlso e.Y <= 38 Then
            toLink = Diffuse
            frmMain.LinkDraw = True
        ElseIf e.X <= 8 AndAlso e.Y >= 40 AndAlso e.Y <= 58 Then
            toLink = Specular
            frmMain.LinkDraw = True
        ElseIf e.X <= 8 AndAlso e.Y >= 60 AndAlso e.Y <= 78 Then
            toLink = Transparent
            frmMain.LinkDraw = True
        ElseIf e.X <= 8 AndAlso e.Y >= 80 AndAlso e.Y <= 98 Then
            toLink = Z
            frmMain.LinkDraw = True

        Else
            toLink = Nothing
            frmMain.LinkDraw = False
        End If
    End Sub

    Friend Overrides Sub BasicTool_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        frmMain.LinkDraw = False

        If toLink IsNot Nothing Then
            Dim x As Integer = Me.Left + e.X
            Dim y As Integer = Me.Top + e.Y
            For i As Integer = 0 To frmMain.ActiveLinkers.Count - 1
                If frmMain.ActiveLinkers(i).isForLink AndAlso _
                   x > frmMain.ActiveLinkers(i).Location.X - 10 AndAlso x < frmMain.ActiveLinkers(i).Location.X + 10 AndAlso _
                   y > frmMain.ActiveLinkers(i).Location.Y - 9 AndAlso y < frmMain.ActiveLinkers(i).Location.Y + 9 Then

                    If toLink.Invert IsNot Nothing Then toLink.Invert.Unlink()

                    frmMain.ActiveLinkers(i).Link = toLink
                    toLink.Invert = frmMain.ActiveLinkers(i)

                    frmMain.pnlMain.Invalidate()
                    Exit Sub
                End If
            Next
            frmMain.pnlMain.Invalidate()
        End If

        toLink = Nothing
    End Sub

    Friend Overrides Sub BasicTool_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If e.X <= 8 AndAlso e.Y >= 20 AndAlso e.Y <= 38 Then
            Me.Cursor = Cursors.UpArrow
        ElseIf e.X <= 8 AndAlso e.Y >= 40 AndAlso e.Y <= 58 Then
            Me.Cursor = Cursors.UpArrow
        ElseIf e.X <= 8 AndAlso e.Y >= 60 AndAlso e.Y <= 78 Then
            Me.Cursor = Cursors.UpArrow
        ElseIf e.X <= 8 AndAlso e.Y >= 80 AndAlso e.Y <= 98 Then
            Me.Cursor = Cursors.UpArrow
        Else
            Me.Cursor = Cursors.Default
        End If

        If toLink Is Nothing AndAlso e.Button = MouseButtons.Left Then
            Dim P As Point = New Point(PP.X + (System.Windows.Forms.Cursor.Position.X - MP.X), PP.Y + (System.Windows.Forms.Cursor.Position.Y - MP.Y))
            If P.X < 0 Then P.X = 0
            If P.Y < 0 Then P.Y = 0
            Me.Location = P

        ElseIf toLink IsNot Nothing AndAlso e.Button = MouseButtons.Left Then
            Dim RP1 As Point
            Dim RP2 As Point

            RP1 = New Point(Math.Min(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) - 4, Math.Min(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) - 4)
            RP2 = New Point(Math.Max(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) + 4, Math.Max(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) + 4)
            frmMain.pnlMain.Invalidate(New Rectangle(RP1.X, RP1.Y, RP2.X - RP1.X, RP2.Y - RP1.Y))

            frmMain.LinkDraw1 = toLink.Location
            frmMain.LinkDraw2 = New Point(Me.Left + e.X, Me.Top + e.Y)

            RP1 = New Point(Math.Min(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) - 4, Math.Min(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) - 4)
            RP2 = New Point(Math.Max(frmMain.LinkDraw1.X, frmMain.LinkDraw2.X) + 4, Math.Max(frmMain.LinkDraw1.Y, frmMain.LinkDraw2.Y) + 4)
            frmMain.pnlMain.Invalidate(New Rectangle(RP1.X, RP1.Y, RP2.X - RP1.X, RP2.Y - RP1.Y))
        End If
    End Sub

    Friend Overridable Sub ThDlizer_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        MyBase.BasicTool_Paint(sender, e)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), 0, 20, 8, 12)
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 0, 20, 8, 12)
        e.Graphics.DrawString("Diffuse & Ambient", Me.Font, Brushes.White, 12, 20)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), 0, 40, 8, 12)
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 0, 40, 8, 12)
        e.Graphics.DrawString("Specular levels", Me.Font, Brushes.White, 12, 40)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), 0, 60, 8, 12)
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 0, 60, 8, 12)
        e.Graphics.DrawString("Transparent", Me.Font, Brushes.White, 12, 60)

        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(64, 0, 0, 0)), 0, 80, 8, 12)
        e.Graphics.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(32, 32, 32))), 0, 80, 8, 12)
        e.Graphics.DrawString("Height", Me.Font, Brushes.White, 12, 80)

        e.Graphics.DrawString("Save to:", Me.Font, Brushes.White, 12, 100)
        e.Graphics.DrawString(Filename, Me.Font, Brushes.White, New Rectangle(12, 114, Me.Width - 24, Me.Height - 114))
    End Sub

    Friend Overrides Sub BasicTool_Move(sender As Object, e As System.EventArgs)
        Diffuse.Location.X = Me.Left
        Diffuse.Location.Y = Me.Top + 18 + 9

        Specular.Location.X = Me.Left
        Specular.Location.Y = Me.Top + 38 + 9

        Transparent.Location.X = Me.Left
        Transparent.Location.Y = Me.Top + 58 + 9

        Z.Location.X = Me.Left
        Z.Location.Y = Me.Top + 78 + 9

        frmMain.pnlMain.Invalidate()
    End Sub
End Class
