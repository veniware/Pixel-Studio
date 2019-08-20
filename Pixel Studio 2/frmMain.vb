Public Class frmMain
    Public Shared p As Pen = New Pen(Color.FromArgb(128, 255, 255, 255), 1)

    Public Shared sfCenterCenter As New StringFormat
    Public Shared sfCenter As New StringFormat
    Public Shared sfLeft As New StringFormat

    Public Shared ftBigFont As New Font("Segoe UI", 12, FontStyle.Regular)

    Public Shared ActiveLinkers As New List(Of ToolsLink)

    Public Shared LinePen As New Pen(Brushes.Black, 3)
    Public Shared LinePenLight As New Pen(New SolidBrush(Color.FromArgb(255, 64, 64, 64)), 3)

    Public WithEvents frmGhost As New Form
    Sub frmGhost_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles frmGhost.Paint
        e.Graphics.DrawString(frmGhost.Text, New Font("Segoe UI", 8.25!), Brushes.White, frmGhost.Width \ 2, 12, sfCenterCenter)
    End Sub

    Public Sub New()
        Control.CheckForIllegalCrossThreadCalls = False

        p.DashStyle = Drawing2D.DashStyle.Dash

        sfCenterCenter.Alignment = StringAlignment.Center
        sfCenterCenter.LineAlignment = StringAlignment.Center

        sfCenter.Alignment = StringAlignment.Center

        sfLeft.Alignment = StringAlignment.Near
        sfLeft.LineAlignment = StringAlignment.Center

        LinePen.StartCap = Drawing2D.LineCap.RoundAnchor
        LinePen.EndCap = Drawing2D.LineCap.RoundAnchor

        frmGhost.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        frmGhost.BackColor = Color.DimGray
        frmGhost.TopMost = True
        frmGhost.ShowIcon = False
        frmGhost.ShowInTaskbar = False
        frmGhost.BackgroundImage = My.Resources.ToolBG
        frmGhost.BackgroundImageLayout = ImageLayout.Stretch

        InitializeComponent()

        lstTools.AddItem(New ctrToolButton("Bitmap"))
        lstTools.AddItem(New ctrToolButton("RAW Bitmap"))
        lstTools.AddItem(New ctrToolButton("Solid bitmap"))

        lstTools.AddSeparator()
        lstTools.AddItem(New ctrToolButton("Export"))
        lstTools.AddItem(New ctrToolButton("Export RAW"))
        lstTools.AddItem(New ctrToolButton("3Dlize"))

        lstTools.AddSeparator()
        lstTools.AddItem(New ctrToolButton("Resize"))
        lstTools.AddItem(New ctrToolButton("Opacity"))
        lstTools.AddItem(New ctrToolButton("Grayscale"))
        lstTools.AddItem(New ctrToolButton("Invert colors"))
        lstTools.AddItem(New ctrToolButton("Scale colors"))
        lstTools.AddItem(New ctrToolButton("Brightness"))
        lstTools.AddItem(New ctrToolButton("Contrast"))
        lstTools.AddItem(New ctrToolButton("Gamma"))
        lstTools.AddItem(New ctrToolButton("Normalize"))

        lstTools.AddSeparator()
        'lstTools.AddItem(New ctrToolButton("Average"))
        lstTools.AddItem(New ctrToolButton("Blur"))
        lstTools.AddItem(New ctrToolButton("Box blur"))
        'lstTools.AddItem(New ctrToolButton("Veni blur"))
        'lstTools.AddItem(New ctrToolButton("Sharpen"))
        'lstTools.AddItem(New ctrToolButton("Noise"))

        lstTools.AddSeparator()
        lstTools.AddItem(New ctrToolButton("Alpha"))
        lstTools.AddItem(New ctrToolButton("Red"))
        lstTools.AddItem(New ctrToolButton("Green"))
        lstTools.AddItem(New ctrToolButton("Blue"))
        lstTools.AddItem(New ctrToolButton("Cyan"))
        lstTools.AddItem(New ctrToolButton("Magenta"))
        lstTools.AddItem(New ctrToolButton("Yellow"))
        lstTools.AddItem(New ctrToolButton("Black (Key)"), True)

    End Sub

    Public LinkDraw As Boolean
    Public LinkDraw1 As Point
    Public LinkDraw2 As Point

    Private Sub pnlMain_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlMain.Paint, pnlMain.Paint
        Try
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            If LinkDraw Then
                Dim pt1, pt2, pt3, pt4 As New Point
                Dim d As Integer = (LinkDraw2.X - LinkDraw1.X) \ 5
                Dim d2 As Integer = (LinkDraw1.Y - LinkDraw2.Y) \ 10

                pt1 = LinkDraw1
                pt4 = LinkDraw2
                pt2 = New Point((pt1.X + pt4.X) \ 2 - d, pt1.Y - d2)
                pt3 = New Point((pt1.X + pt4.X) \ 2 + d, pt4.Y + d2)

                Dim points() As Point = {pt1, pt2, pt3, pt4}

                e.Graphics.DrawCurve(LinePenLight, points, 0.5)
            End If

            For i As Integer = 0 To ActiveLinkers.Count - 1
                If ActiveLinkers(i).Link IsNot Nothing Then
                    Dim pt1, pt2, pt3, pt4 As New Point
                    Dim d As Integer = (ActiveLinkers(i).Link.Location.X - ActiveLinkers(i).Location.X) \ 5
                    Dim d2 As Integer = (ActiveLinkers(i).Location.Y - ActiveLinkers(i).Link.Location.Y) \ 10

                    pt1 = ActiveLinkers(i).Location
                    pt4 = ActiveLinkers(i).Link.Location
                    pt2 = New Point((pt1.X + pt4.X) \ 2 - d, pt1.Y - d2)
                    pt3 = New Point((pt1.X + pt4.X) \ 2 + d, pt4.Y + d2)

                    Dim points() As Point = {pt1, pt2, pt3, pt4}

                    e.Graphics.DrawCurve(LinePen, points, 0.5)
                End If
            Next

        Catch ex As Exception
            Me.Text = ex.Message
        End Try
    End Sub

    Dim MP As Point
    Dim PP As Point
    Private Sub pnlMain_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseDown
        MP = Windows.Forms.Cursor.Position
        PP = pnlMain.Location
    End Sub
    Private Sub pnlMain_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseMove
        If e.Button = MouseButtons.Middle Then
            Dim newX As Integer = PP.X + (Windows.Forms.Cursor.Position.X - MP.X)
            Dim newY As Integer = PP.Y + (Windows.Forms.Cursor.Position.Y - MP.Y)
            If newX > 0 Then newX = 0
            If newY > 0 Then newY = 0
            pnlMain.Location = New Point(newX, newY)
        End If
    End Sub

    Private Sub RenderToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles RenderToolStripMenuItem1.Click
        Dim L As New List(Of BasicTool)
        For i As Integer = 0 To pnlMain.Controls.Count - 1
            L.Add(pnlMain.Controls(i))
        Next

        Dim T As New Threading.Thread(AddressOf Render.Render)

        Using frmR As New frmRender
            frmR.T = T
            T.Start({L, frmR, T})
            frmR.ShowDialog()
        End Using
    End Sub
End Class
