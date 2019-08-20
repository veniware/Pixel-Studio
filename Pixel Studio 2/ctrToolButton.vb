Public Class ctrToolButton
    Property Enable As Boolean = True
    Property Label As String
    Event Press()

    Dim FillBrush As TextureBrush
    Dim o As Byte = 64
    Dim d As Boolean = False

    Public Sub New()
        FillBrush = New TextureBrush(My.Resources.cmdC)
        FillBrush.TranslateTransform(0, 3)

        InitializeComponent()

        Me.BackColor = Color.Transparent
    End Sub

    Public Sub New(Label As String)
        Me.Label = Label

        FillBrush = New TextureBrush(My.Resources.cmdC)
        FillBrush.TranslateTransform(0, 3)

        InitializeComponent()

        Me.BackColor = Color.Transparent
    End Sub

    Private Sub ctrButton_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillBrush.ScaleTransform(1, 0.85 * (Me.Height - 6) / 20)
    End Sub

    Private Sub ctrButton_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(o * 1.5, 0, 0, 0)), 0, 0, Me.Width, Me.Height)

        For i As Short = 1 To 2
            Using b As New SolidBrush(Color.FromArgb(48 / i, 0, 0, 0))
                e.Graphics.DrawString(Label, Me.Font, b, 4 + i, Me.Height \ 2 + 1, frmMain.sfLeft)
                e.Graphics.DrawString(Label, Me.Font, b, 4 - i, Me.Height \ 2 + 1, frmMain.sfLeft)
                e.Graphics.DrawString(Label, Me.Font, b, 4 + i, Me.Height \ 2 - 1, frmMain.sfLeft)
                e.Graphics.DrawString(Label, Me.Font, b, 4 - i, Me.Height \ 2 - 1, frmMain.sfLeft)
            End Using
        Next
        e.Graphics.DrawString(Label, Me.Font, Brushes.WhiteSmoke, 4, Me.Height \ 2, frmMain.sfLeft)

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

        If e.Button = MouseButtons.Left Then
            frmMain.frmGhost.Text = Label
            frmMain.frmGhost.Show()
            frmMain.Select()
            frmMain.frmGhost.Size = Me.Size
        End If
    End Sub
    Private Sub ctrButton_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        d = False
        Me.Invalidate()

        If e.Button = MouseButtons.Left AndAlso (Not e.X - frmMain.lstTools.Width < 0) Then
            frmMain.frmGhost.Hide()

            Select Case Label
                Case "Export"
                    Dim newTool As New Export
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(64, 172, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Export RAW"
                    Dim newTool As New RAWExport
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(64, 172, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "3Dlize"
                    Dim newTool As New TDlizer
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(64, 172, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Bitmap"
                    Dim newTool As New BitmapLoader
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 64, 172)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "RAW Bitmap"
                    Dim newTool As New RAWLoader
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 64, 172)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Solid bitmap"
                    Dim newTool As New SolidBitmap
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 64, 172)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Resize"
                    Dim newTool As New Resize
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Opacity"
                    Dim newTool As New Opacity
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Grayscale"
                    Dim newTool As New Grayscale
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Invert colors"
                    Dim newTool As New Invert
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Scale colors"
                    Dim newTool As New ScaleColor
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Brightness"
                    Dim newTool As New Brightness
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Contrast"
                    Dim newTool As New Contrast
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Gamma"
                    Dim newTool As New Gamma
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Normalize"
                    Dim newTool As New Normalize
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(0, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Blur"
                    Dim newTool As New Blur
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 128, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Box blur"
                    Dim newTool As New BoxBlur
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 128, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Alpha"
                    Dim newTool As New getAlpha
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Red"
                    Dim newTool As New getRed
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Green"
                    Dim newTool As New getGreen
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Blue"
                    Dim newTool As New getBlue
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Cyan"
                    Dim newTool As New getCyan
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Magenta"
                    Dim newTool As New getMagenta
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Yellow"
                    Dim newTool As New getYellow
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

                Case "Black (Key)"
                    Dim newTool As New getBlack
                    newTool.Title = Label
                    newTool.TitleColor = Color.FromArgb(255, 0, 0)
                    newTool.Left = e.X - frmMain.lstTools.Width - frmMain.pnlMain.Left
                    newTool.Top = e.Y + Me.Top + frmMain.lstTools.pnlMainList.Top - frmMain.pnlMain.Top
                    frmMain.pnlMain.Controls.Add(newTool)
                    newTool.BringToFront()

            End Select

        Else
            frmMain.frmGhost.Hide()
        End If
    End Sub

    Private Sub ctrToolButton_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            If e.X - frmMain.lstTools.Width < 0 Then
                Dim o As Decimal = 0.666 + (e.X - frmMain.lstTools.Width) / 64
                If o < 0.08 Then o = 0.08
                frmMain.frmGhost.Opacity = o
            Else
                frmMain.frmGhost.Opacity = 0.666
            End If

            frmMain.frmGhost.Location = New Point(System.Windows.Forms.Cursor.Position.X + 16, System.Windows.Forms.Cursor.Position.Y + 16)

        End If
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
