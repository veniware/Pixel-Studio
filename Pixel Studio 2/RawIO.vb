Module RawIO

    Sub BinaryWriter(Filename As String, B() As Byte)
        Dim Writer As New IO.FileStream(Filename, IO.FileMode.Create)
        For i As ULong = 0 To B.Length - 1
            Writer.WriteByte(B(i))
        Next
        Writer.Close()
    End Sub

    Function BinaryLoader(Filename As String) As Byte()
        Dim Reader As New IO.BinaryReader(IO.File.Open(Filename, IO.FileMode.Open))
        Dim B(Reader.BaseStream.Length) As Byte
        Dim L As ULong = Reader.BaseStream.Length

        For i As ULong = 0 To L - 1
            B(i) = Reader.ReadByte
        Next

        Reader.Close()

        Return B
    End Function

    Public Sub WriteGray(Filename As String, Image As Bitmap)
        Dim temp As New Bitmap(Image.Width, Image.Height, Imaging.PixelFormat.Format24bppRgb)
        Using G As Graphics = Graphics.FromImage(temp)
            G.DrawImage(Edit.Grayscale(Image, 100), 0, 0, temp.Width, temp.Height)
        End Using
        
        Dim DP As New DirectPixel(temp)
        DP.LockBits()

        Dim B1() As Byte = DP.Bytes
        Dim B2(B1.Length / 3) As Byte
        For i = 0 To B2.Length - 3
            B2(i) = B1(i * 3)
        Next

        DP.UnlockBits()

        BinaryWriter(Filename, B2)
    End Sub

    Public Sub WriteRGB(Filename As String, Image As Bitmap)
        Dim temp As New Bitmap(Image.Width, Image.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim r As New Rectangle(0, 0, Image.Width, Image.Height)
        Dim v As Single()() = {
            New Single() {0, 0, 1, 0, 0}, _
            New Single() {0, 1, 0, 0, 0}, _
            New Single() {1, 0, 0, 0, 0}, _
            New Single() {0, 0, 0, 1, 0}, _
            New Single() {0, 0, 0, 0, 1}}

        Dim cm As New Imaging.ColorMatrix(v)
        Dim ia As New Imaging.ImageAttributes
        ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)

        Using G As Graphics = Graphics.FromImage(temp)
            G.DrawImage(Image, r, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ia)
        End Using
        ia.Dispose()


        Dim DP As New DirectPixel(temp)
        DP.LockBits()

        Dim B() As Byte = DP.Bytes

        DP.UnlockBits()

        BinaryWriter(Filename, B)
    End Sub

    Public Sub WriteGBR(Filename As String, Image As Bitmap)
        Dim temp As New Bitmap(Image.Width, Image.Height, Imaging.PixelFormat.Format24bppRgb)
        Using G As Graphics = Graphics.FromImage(temp)
            G.DrawImage(Image, 0, 0, temp.Width, temp.Height)
        End Using

        Dim DP As New DirectPixel(temp)
        DP.LockBits()

        Dim B() As Byte = DP.Bytes

        DP.UnlockBits()

        BinaryWriter(Filename, B)
    End Sub

    Public Function LoadGray(Filename As String, Size As Size) As Image
        Dim B() As Byte = BinaryLoader(Filename)
        Dim P As New Bitmap(Size.Width, Size.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim DP As New DirectPixel(P)
        DP.LockBits()

        For i As Integer = 0 To B.Length - 3
            DP.Bytes(i * 3) = B(i)
            DP.Bytes(i * 3 + 1) = B(i)
            DP.Bytes(i * 3 + 2) = B(i)
        Next

        DP.UnlockBits()

        Return P
    End Function

    Public Function LoadRGB(Filename As String, Size As Size) As Image
        Dim B() As Byte = BinaryLoader(Filename)
        Dim P As New Bitmap(Size.Width, Size.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim DP As New DirectPixel(P)
        DP.LockBits()
        DP.Bytes = B
        DP.UnlockBits()

        Dim r As New Rectangle(0, 0, Size.Width, Size.Height)
        Dim v As Single()() = {
            New Single() {0, 0, 1, 0, 0}, _
            New Single() {0, 1, 0, 0, 0}, _
            New Single() {1, 0, 0, 0, 0}, _
            New Single() {0, 0, 0, 1, 0}, _
            New Single() {0, 0, 0, 0, 1}}

        Dim cm As New Imaging.ColorMatrix(v)
        Dim ia As New Imaging.ImageAttributes
        ia.SetColorMatrix(cm, Imaging.ColorMatrixFlag.Default, Imaging.ColorAdjustType.Bitmap)

        Using G As Graphics = Graphics.FromImage(P)
            G.DrawImage(P, r, 0, 0, Size.Width, Size.Height, GraphicsUnit.Pixel, ia)
        End Using
        ia.Dispose()

        Return P
    End Function

    Public Function LoadGBR(Filename As String, Size As Size) As Image
        Dim B() As Byte = BinaryLoader(Filename)
        Dim P As New Bitmap(Size.Width, Size.Height, Imaging.PixelFormat.Format24bppRgb)

        Dim DP As New DirectPixel(P)
        DP.LockBits()
        DP.Bytes = B
        DP.UnlockBits()

        Return P
    End Function
End Module
