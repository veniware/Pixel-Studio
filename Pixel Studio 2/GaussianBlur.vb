Public Module GaussianBlur

    Public Function Calculate1DSampleKernel(d As Double, size As Integer) As Double(,)
        Dim R(size, 1) As Double
        Dim sum As Double = 0

        Dim half As Integer = size / 2

        For i As Integer = 0 To size - 1
            R(i, 0) = 1 / (Math.Sqrt(2 * Math.PI) * d) * Math.Exp(-(i - half) * (i - half) / (2 * d * d))
        Next

        Return R
    End Function

    Public Function Calculate1DSampleKernel(d As Double) As Double(,)
        Dim Size As Integer = CInt(Math.Ceiling(d * 3) * 2 + 1)
        Return Calculate1DSampleKernel(d, Size)
    End Function

    Public Function CalculateNormalized1DSampleKernel(d As Double)
        Return NormalizeMatrix(Calculate1DSampleKernel(d))
    End Function

    Public Function NormalizeMatrix(matrix(,) As Double) As Double(,)
        Dim R(matrix.GetLength(0), matrix.GetLength(1)) As Double
        Dim sum As Integer = 0

        For i As Integer = 0 To R.GetLength(0)
            For j As Integer = 0 To R.GetLength(1)
                sum += matrix(i, j)
            Next
        Next

        If Not sum = 0 Then
            For i As Integer = 0 To R.GetLength(0)
                For j As Integer = 0 To R.GetLength(1)
                    R(i, j) = matrix(i, j) / sum
                Next
            Next
        End If

        Return R
    End Function

    Public Function GaussianConvolution(matrix(,) As Color, d As Double) As Double(,)
        Dim kernal(,) As Double
        Dim R1(matrix.GetLength(0), matrix.GetLength(1)) As Double
        Dim R2(matrix.GetLength(0), matrix.GetLength(1)) As Double

        'x-direction
        For i As Integer = 0 To matrix.GetLength(0) - 1
            For j As Integer = 0 To matrix.GetLength(1) - 1
                R1(i, j) = 0
            Next
        Next

        'y-direction
        For i As Integer = 0 To matrix.GetLength(0) - 1
            For j As Integer = 0 To matrix.GetLength(1) - 1
                R2(i, j) = 0
            Next
        Next

        Return R2
    End Function


    Public Function GaussianBlur(B As Bitmap, d As Double) As Image
        Dim R As New Bitmap(B.Width, B.Height, B.PixelFormat)

        Dim matrix(B.Width, B.Height) As Color

        For i As Integer = 0 To B.Width - 1
            For j As Integer = 0 To B.Height - 1
                matrix(i, j) = R.GetPixel(i, j)
            Next
        Next

        'matrix = GaussianConvolution(matrix, d)

        Return R
    End Function

End Module
