Public Class frmValue
    Private Sub frmValue_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtValue.Select(0, txtValue.Value.ToString.Length)
    End Sub
End Class