Imports System.Runtime.InteropServices

Public Class DirectPixel
    Dim Bitmap As Bitmap
    Dim BitmapData As Imaging.BitmapData
    Dim PixelFormat As Imaging.PixelFormat
    Dim BitLength As Byte

    Public Bytes() As Byte

    Dim Locked As Boolean = False

    Public Sub New(B As Bitmap)
        Me.Bitmap = B
        PixelFormat = B.PixelFormat

        If PixelFormat = Imaging.PixelFormat.Format16bppArgb1555 OrElse _
           PixelFormat = Imaging.PixelFormat.Format32bppArgb OrElse _
           PixelFormat = Imaging.PixelFormat.Format32bppPArgb OrElse _
           PixelFormat = Imaging.PixelFormat.Format64bppArgb OrElse _
           PixelFormat = Imaging.PixelFormat.Format64bppPArgb Then
            BitLength = 4
        Else
            BitLength = 3
        End If

    End Sub

    Public Sub LockBits()
        If Locked Then Exit Sub

        BitmapData = Bitmap.LockBits(New Rectangle(0, 0, Bitmap.Width, Bitmap.Height), Imaging.ImageLockMode.ReadWrite, PixelFormat)

        ReDim Bytes(Bitmap.Width * Bitmap.Height * BitLength - 1)
        Marshal.Copy(BitmapData.Scan0, Bytes, 0, Bytes.Length)

        Locked = True
    End Sub

    Public Sub UnlockBits()
        If Not Locked Then Exit Sub

        Marshal.Copy(Bytes, 0, BitmapData.Scan0, Bytes.Length)
        Bitmap.UnlockBits(BitmapData)
        Locked = False
    End Sub

    Public Function GetPixel(ByVal location As Point) As Color
        Return Me.GetPixel(location.X, location.Y)
    End Function
    Public Function GetPixel(ByVal x As Integer, ByVal y As Integer) As Color
        If Not Locked Then Exit Function

        Dim index As Integer = (y * Bitmap.Width + x) * BitLength

        Dim A As Byte = 255
        Dim R As Byte
        Dim G As Byte
        Dim B As Byte

        B = Bytes(index)
        G = Bytes(index + 1)
        R = Bytes(index + 2)
        If BitLength = 4 Then A = Bytes(index + 3)

        Return Color.FromArgb(A, R, G, B)
    End Function

    Public Sub SetPixel(ByVal location As Point, ByVal colour As Color)
        Me.SetPixel(location.X, location.Y, colour)
    End Sub
    Public Sub SetPixel(ByVal x As Integer, ByVal y As Integer, ByVal color As Color)
        If Not Locked Then Exit Sub

        Dim index As Integer = (y * Bitmap.Width + x) * BitLength

        Bytes(index) = color.B
        Bytes(index + 1) = color.G
        Bytes(index + 2) = color.R
        If BitLength = 4 Then Bytes(index + 3) = color.A
    End Sub
End Class
