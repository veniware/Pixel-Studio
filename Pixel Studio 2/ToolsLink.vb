Public Class ToolsLink
    Public Event LinkChanged()

    Public Location As Point
    Public Link As ToolsLink
    Public Invert As ToolsLink
    Public isForLink As Boolean
    Public Tool As BasicTool

    Public Sub Unlink()
        If Invert IsNot Nothing Then Invert.Unlink()

        Link = Nothing
        Invert = Nothing

        RaiseEvent LinkChanged()
    End Sub

    Public Sub RaiseLinkChanged()
        RaiseEvent LinkChanged()
    End Sub
End Class
