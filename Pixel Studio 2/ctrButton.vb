Public Class ctrButton
    Property Enable As Boolean = True
    Property Label As String
    Event Press()

    Dim FillBrush As TextureBrush
    Dim StringFormatCenter As New StringFormat
    Dim o As Byte = 64
    Dim d As Boolean = False

    Public Sub New()
        FillBrush = New TextureBrush(My.Resources.cmdC)
        FillBrush.TranslateTransform(0, 3)

        StringFormatCenter.Alignment = StringAlignment.Center
        StringFormatCenter.LineAlignment = StringAlignment.Center

        InitializeComponent()

        Me.BackColor = Color.Transparent
    End Sub

    Public Sub New(Label As String)
        Me.Label = Label

        FillBrush = New TextureBrush(My.Resources.cmdC)
        FillBrush.TranslateTransform(0, 3)

        StringFormatCenter.Alignment = StringAlignment.Center
        StringFormatCenter.LineAlignment = StringAlignment.Center

        InitializeComponent()

        Me.BackColor = Color.Transparent
    End Sub

    Private Sub ctrButton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillBrush.ScaleTransform(1, 0.85 * (Me.Height - 6) / 20)
    End Sub

    Private Sub ctrButton_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(Brushes.White, 3, 3, Me.Width - 6, Me.Height - 6)
        e.Graphics.FillRectangle(FillBrush, 9, 3, Me.Width - 18, Me.Height - 6)
        e.Graphics.DrawImage(My.Resources.cmdL, 3, 3, 6, Me.Height - 6)
        e.Graphics.DrawImage(My.Resources.cmdR, Me.Width - 9, 3, 6, Me.Height - 6)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(o, 0, 0, 0)), 3, 3, Me.Width - 6, Me.Height - 6)

        If Me.Focused AndAlso Enable Then
            Dim P As New Drawing2D.GraphicsPath
            P.AddRectangle(New Rectangle(0, 0, Me.Width, Me.Height))
            P.AddRectangle(New Rectangle(3, 3, Me.Width - 6, Me.Height - 6))

            Dim B As Drawing2D.PathGradientBrush = New Drawing2D.PathGradientBrush(P)
            B.SurroundColors = New Color() {Color.FromArgb(0, 255, 255, 255)}
            B.CenterColor = Color.FromArgb(255, 255, 255, 255)
            e.Graphics.FillPath(B, P)
            e.Graphics.FillPath(B, P)
        End If

        If d AndAlso Enable Then
            Dim P As New Drawing2D.GraphicsPath
            P.AddRectangle(New Rectangle(3, 3, Me.Width - 6, Me.Height - 6))

            Dim B As Drawing2D.PathGradientBrush = New Drawing2D.PathGradientBrush(P)
            B.SurroundColors = New Color() {Color.FromArgb(0, 0, 0, 0)}
            B.CenterColor = Color.FromArgb(96, 0, 0, 0)
            e.Graphics.FillPath(B, P)
        End If

        For i As Short = 1 To 2
            Using b As New SolidBrush(Color.FromArgb(48 / i, 255, 255, 255))
                e.Graphics.DrawString(Label, Me.Font, b, Me.Width \ 2 + i, Me.Height \ 2 + 1, StringFormatCenter)
                e.Graphics.DrawString(Label, Me.Font, b, Me.Width \ 2 - i, Me.Height \ 2 + 1, StringFormatCenter)
                e.Graphics.DrawString(Label, Me.Font, b, Me.Width \ 2 + i, Me.Height \ 2 - 1, StringFormatCenter)
                e.Graphics.DrawString(Label, Me.Font, b, Me.Width \ 2 - i, Me.Height \ 2 - 1, StringFormatCenter)
            End Using
        Next
        e.Graphics.DrawString(Label, Me.Font, Brushes.Black, Me.Width \ 2, Me.Height \ 2, StringFormatCenter)

        If Not Enable Then e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(128, 0, 0, 0)), 3, 3, Me.Width - 6, Me.Height - 6)
    End Sub

    Private Sub ctrButton_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space OrElse e.KeyCode = Keys.Enter Then
            If Not Enable Then Exit Sub
            RaiseEvent Press()
            d = True
            Me.Invalidate()
        End If
    End Sub
    Private Sub ctrButton_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        d = False
        Me.Invalidate()
    End Sub

    Private Sub ctrButton_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If Not Enable Then Exit Sub
        d = True
        Me.Invalidate()
    End Sub
    Private Sub ctrButton_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        d = False
        Me.Invalidate()
    End Sub

    Private Sub ctrButton_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Not Enable Then Exit Sub
        RaiseEvent Press()
    End Sub

    Private Sub ctrButton_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus
        If Not Enable Then Exit Sub
        Me.Invalidate()
    End Sub
    Private Sub ctrButton_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        Me.Invalidate()
    End Sub

    Private Sub ctrButton_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        If Not Enable Then Exit Sub
        tmrOFF.Stop()
        tmrON.Start()
    End Sub
    Private Sub ctrButton_MouseLeave(sender As Object, e As System.EventArgs) Handles Me.MouseLeave
        tmrON.Stop()
        tmrOFF.Start()
    End Sub

    Private Sub tmrON_Tick(sender As System.Object, e As System.EventArgs) Handles tmrON.Tick
        If o = 0 Then
            tmrON.Stop()
        Else
            o -= 4
            Me.Invalidate()
        End If
    End Sub

    Private Sub tmrOFF_Tick(sender As System.Object, e As System.EventArgs) Handles tmrOFF.Tick
        o += 4
        Me.Refresh()
        If o >= 64 Then tmrOFF.Stop()
    End Sub

    Private Sub PressGlow() Handles Me.Press
        o = 0
        tmrON.Stop()
        tmrOFF.Start()
    End Sub
End Class
