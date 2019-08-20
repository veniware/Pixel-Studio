Module Render
    Public Sub Render(o() As Object)
        Dim L As List(Of BasicTool) = o(0)
        Dim frmR As frmRender = o(1)
        Dim T As Threading.Thread = o(2)

        Dim Exporters As New List(Of Export)
        Dim RAWExporters As New List(Of RAWExport)
        Dim TDlizers As New List(Of TDlizer)

        For i As Integer = 0 To L.Count - 1
            If TypeOf L(i) Is Export Then Exporters.Add(L(i))
            If TypeOf L(i) Is RAWExport Then RAWExporters.Add(L(i))
            If TypeOf L(i) Is TDlizer Then TDlizers.Add(L(i))
        Next

        If Exporters.Count = 0 AndAlso RAWExporters.Count = 0 AndAlso TDlizers.Count = 0 Then
            frmR.AddShit("No exporters found", 1)
            'Exit Sub
        End If

        frmR.prgLoad.Maximum = Exporters.Count + RAWExporters.Count + TDlizers.Count

        'exporters
        For i As Integer = 0 To Exporters.Count - 1
            frmR.prgLoad.Value = i
            RenderExporter(Exporters(i), frmR)
        Next

        'RAW
        For i As Integer = 0 To RAWExporters.Count - 1
            frmR.prgLoad.Value = Exporters.Count + i
            RenderRAW(RAWExporters(i), frmR)
        Next

        '3DL
        For i As Integer = 0 To TDlizers.Count - 1
            frmR.prgLoad.Value = Exporters.Count + RAWExporters.Count + i
            Render3Dlizer(TDlizers(i), frmR)
        Next

        frmR.AddShit("Done", 0)

        frmR.prgLoad.Value = frmR.prgLoad.Maximum

        frmR.cmdCancel.Label = "Close"
        frmR.cmdCancel.Invalidate 
    End Sub

    Public Sub RenderExporter(exporter As Export, frmR As frmRender)
        Dim s As New List(Of BasicTool)
        Dim e As BasicTool

        e = exporter
        Do Until e Is Nothing
            If e.Linked.Invert Is Nothing Then
                e = Nothing
            Else
                e = e.Linked.Invert.Tool
                s.Add(e)
            End If
        Loop

        Dim p As Image = Nothing
        For j As Integer = s.Count - 1 To 0 Step -1
            frmR.AddShit(s(j).Title, 3)
            p = s(j).ApplyEffect(p)
        Next

        frmR.AddShit("Export", 3)

        If p IsNot Nothing Then
            Try
                p.Save(exporter.Filename, exporter.Format)
            Catch
                frmR.AddShit("Export" & vbTab & "the path is not of a legal form", 1)
            End Try
        Else
            frmR.AddShit("Export" & vbTab & "bitmap is not specified", 1)
        End If

    End Sub

    Public Sub RenderRAW(Exporter As RAWExport, frmR As frmRender)
        Dim s As New List(Of BasicTool)
        Dim e As BasicTool

        e = Exporter
        Do Until e Is Nothing
            If e.Linked.Invert Is Nothing Then
                e = Nothing
            Else
                e = e.Linked.Invert.Tool
                s.Add(e)
            End If
        Loop

        Dim p As Image = Nothing
        For j As Integer = s.Count - 1 To 0 Step -1
            frmR.AddShit(s(j).Title, 3)
            p = s(j).ApplyEffect(p)
        Next

        frmR.AddShit("Export", 3)

        If p IsNot Nothing Then
            Try
                If Exporter.Format = 0 Then 'Gray
                    RawIO.WriteGray(Exporter.Filename, p)

                ElseIf Exporter.Format = 1 Then 'RGB
                    RawIO.WriteRGB(Exporter.Filename, p)

                ElseIf Exporter.Format = 2 Then 'BGR
                    RawIO.WriteGBR(Exporter.Filename, p)
                End If
            Catch
                frmR.AddShit("Export" & vbTab & "the path is not of a legal form", 1)
            End Try
        Else
            frmR.AddShit("Export" & vbTab & "bitmap is not specified", 1)
        End If
    End Sub

    Public Sub Render3Dlizer(TDL As TDlizer, frmR As frmRender)
        Dim s As New List(Of BasicTool)
        Dim e As BasicTool

        Dim dif As Image = Nothing
        Dim spe As Image = Nothing
        Dim tra As Image = Nothing
        Dim hei As Image = Nothing

        s.Clear()
        If TDL.Diffuse.Invert IsNot Nothing Then
            e = TDL.Diffuse.Invert.Tool
            Do Until e Is Nothing
                s.Add(e)
                If e.Linked.Invert Is Nothing Then
                    e = Nothing
                Else
                    e = e.Linked.Invert.Tool
                End If
            Loop

            For j As Integer = s.Count - 1 To 0 Step -1
                frmR.AddShit(s(j).Title, 3)
                dif = s(j).ApplyEffect(dif)
            Next
        End If


        s.Clear()
        If TDL.Specular.Invert IsNot Nothing Then
            e = TDL.Specular.Invert.Tool
            Do Until e Is Nothing
                s.Add(e)
                If e.Linked.Invert Is Nothing Then
                    e = Nothing
                Else
                    e = e.Linked.Invert.Tool
                End If
            Loop

            For j As Integer = s.Count - 1 To 0 Step -1
                frmR.AddShit(s(j).Title, 3)
                spe = s(j).ApplyEffect(spe)
            Next
        End If


        s.Clear()
        If TDL.Transparent.Invert IsNot Nothing Then
            e = TDL.Transparent.Invert.Tool
            Do Until e Is Nothing
                s.Add(e)
                If e.Linked.Invert Is Nothing Then
                    e = Nothing
                Else
                    e = e.Linked.Invert.Tool
                End If
            Loop

            For j As Integer = s.Count - 1 To 0 Step -1
                frmR.AddShit(s(j).Title, 3)
                tra = s(j).ApplyEffect(tra)
            Next
        End If

        s.Clear()
        If TDL.Z.Invert IsNot Nothing Then
            e = TDL.Z.Invert.Tool
            Do Until e Is Nothing
                s.Add(e)
                If e.Linked.Invert Is Nothing Then
                    e = Nothing
                Else
                    e = e.Linked.Invert.Tool
                End If
            Loop

            For j As Integer = s.Count - 1 To 0 Step -1
                frmR.AddShit(s(j).Title, 3)
                hei = s(j).ApplyEffect(hei)
            Next
        End If

        frmR.AddShit("3Dlizer", 3)

        If dif Is Nothing Then
            frmR.AddShit("3Dlizer" & vbTab & "diffuse bitmap is not specified", 1)
            Exit Sub
        End If

        If spe Is Nothing Then
            spe = New Bitmap(dif.Width, dif.Height, Imaging.PixelFormat.Format24bppRgb)
            frmR.AddShit("3Dlizer" & vbTab & "specular levels bitmap is not specified", 2)
        End If

        If tra Is Nothing Then
            tra = New Bitmap(dif.Width, dif.Height, Imaging.PixelFormat.Format24bppRgb)
            frmR.AddShit("3Dlizer" & vbTab & "transparent bitmap is not specified", 2)
        End If

        If hei Is Nothing Then
            hei = New Bitmap(dif.Width, dif.Height, Imaging.PixelFormat.Format24bppRgb)
            frmR.AddShit("3Dlizer" & vbTab & "height bitmap is not specified", 2)
        End If


        If spe.Size.Width <> dif.Size.Width OrElse spe.Size.Height <> dif.Size.Height Then
            Dim temp As Image = spe
            spe = New Bitmap(dif.Width, dif.Height, temp.PixelFormat)
            Using G As Graphics = Graphics.FromImage(spe)
                G.DrawImage(temp, 0, 0, dif.Width, dif.Height)
            End Using
            temp.Dispose()
        End If

        If tra.Size.Width <> dif.Size.Width OrElse tra.Size.Height <> dif.Size.Height Then
            Dim temp As Image = tra
            tra = New Bitmap(dif.Width, dif.Height, temp.PixelFormat)
            Using G As Graphics = Graphics.FromImage(tra)
                G.DrawImage(temp, 0, 0, dif.Width, dif.Height)
            End Using
            temp.Dispose()
        End If

        If hei.Size.Width <> dif.Size.Width OrElse hei.Size.Height <> dif.Size.Height Then
            Dim temp As Image = hei
            hei = New Bitmap(dif.Width, dif.Height, temp.PixelFormat)
            Using G As Graphics = Graphics.FromImage(hei)
                G.DrawImage(temp, 0, 0, dif.Width, dif.Height)
            End Using
            temp.Dispose()
        End If

        ExportTDlized(dif, spe, tra, hei, TDL.Filename, frmR)
    End Sub

    Public Sub ExportTDlized(dif As Bitmap, spe As Bitmap, tra As Bitmap, hei As Bitmap, filename As String, frmR As frmRender)
        Const Zlim As UShort = 10

        Dim file As IO.FileInfo
        Try
            file = New IO.FileInfo(filename)
        Catch
            frmR.AddShit("3Dlizer" & vbTab & "the path is not of a legal form", 1)
            Exit Sub
        End Try

        Dim name As String = Microsoft.VisualBasic.Left(file.Name, file.Name.Length - file.Extension.Length)

        Dim OBJ As String = ""
        Dim MTL As String = ""

        Dim Vs As String = ""
        Dim VsCount As UInteger = 0
        Dim Gs As String = ""

        Dim Ms As New Collections.Hashtable

        Vs &= "mtllib " & name & ".mtl" & vbNewLine

        Dim size As Byte = 1

        Dim DPdif As New DirectPixel(dif)
        Dim DPspe As New DirectPixel(spe)
        Dim DPtra As New DirectPixel(tra)
        Dim DPhei As New DirectPixel(hei)

        DPdif.LockBits()
        DPspe.LockBits()
        DPtra.LockBits()
        DPhei.LockBits()

        For j As Integer = 0 To dif.Height - 1
            For i As Integer = 0 To dif.Width - 1

                If DPtra.GetPixel(i, j).GetBrightness = 0 Then Continue For

                Dim gName As String = ColorToString(DPdif.GetPixel(i, j))

                Vs &= "v " & i & vbTab & -j & vbTab & Zlim * DPhei.GetPixel(i, j).GetBrightness & vbNewLine
                Vs &= "v " & i + size & vbTab & -j & vbTab & Zlim * DPhei.GetPixel(i, j).GetBrightness & vbNewLine
                Vs &= "v " & i + size & vbTab & -j + size & vbTab & Zlim * DPhei.GetPixel(i, j).GetBrightness & vbNewLine
                Vs &= "v " & i & vbTab & -j + size & vbTab & Zlim * DPhei.GetPixel(i, j).GetBrightness & vbNewLine
                Vs &= "v " & i & vbTab & -j & vbTab & "0" & vbNewLine
                Vs &= "v " & i + size & vbTab & -j & vbTab & "0" & vbNewLine
                Vs &= "v " & i + size & vbTab & -j + size & vbTab & "0" & vbNewLine
                Vs &= "v " & i & vbTab & -j + size & vbTab & "0" & vbNewLine

                Gs &= "g " & i & "_" & j & vbNewLine
                Gs &= "usemtl m" & gName & vbNewLine
                Gs &= "f " & VsCount + 1 & vbTab & VsCount + 2 & vbTab & VsCount + 3 & vbTab & VsCount + 4 & vbNewLine
                Gs &= "f " & VsCount + 8 & vbTab & VsCount + 7 & vbTab & VsCount + 6 & vbTab & VsCount + 5 & vbNewLine
                Gs &= "f " & VsCount + 4 & vbTab & VsCount + 3 & vbTab & VsCount + 7 & vbTab & VsCount + 8 & vbNewLine
                Gs &= "f " & VsCount + 5 & vbTab & VsCount + 1 & vbTab & VsCount + 4 & vbTab & VsCount + 8 & vbNewLine
                Gs &= "f " & VsCount + 5 & vbTab & VsCount + 6 & vbTab & VsCount + 2 & vbTab & VsCount + 1 & vbNewLine
                Gs &= "f " & VsCount + 2 & vbTab & VsCount + 6 & vbTab & VsCount + 7 & vbTab & VsCount + 3 & vbNewLine

                VsCount += 8

                If Not Ms.ContainsKey(gName) Then
                    Ms.Add(gName, "")

                    MTL &= "newmtl m" & gName & vbNewLine
                    'MTL &= "Ns 32" & vbNewLine
                    'MTL &= "d 1" & vbNewLine
                    MTL &= "Tr " & Math.Round(1 - DPtra.GetPixel(i, j).GetBrightness, 4) & vbNewLine
                    'MTL &= "Tf 1 1 1" & vbNewLine
                    'MTL &= "illum 2" & vbNewLine

                    MTL &= "Ka " & Math.Round(DPdif.GetPixel(i, j).R / 255, 4) & " " & Math.Round(DPdif.GetPixel(i, j).G / 255, 4) & " " & Math.Round(DPdif.GetPixel(i, j).B / 255, 4) & vbNewLine
                    MTL &= "Kd " & Math.Round(DPdif.GetPixel(i, j).R / 255, 4) & " " & Math.Round(DPdif.GetPixel(i, j).G / 255, 4) & " " & Math.Round(DPdif.GetPixel(i, j).B / 255, 4) & vbNewLine
                    MTL &= "Ks " & Math.Round(DPspe.GetPixel(i, j).R / 255, 4) & " " & Math.Round(DPspe.GetPixel(i, j).G / 255, 4) & " " & Math.Round(DPspe.GetPixel(i, j).B / 255, 4) & vbNewLine
                    MTL &= vbNewLine
                End If

            Next
        Next

        DPdif.UnlockBits()
        DPspe.UnlockBits()
        DPtra.UnlockBits()
        DPhei.UnlockBits()

        OBJ &= Vs
        OBJ &= "s off" & vbNewLine
        OBJ &= Gs

        My.Computer.FileSystem.WriteAllText("C:\Users\Andreas\Desktop\" & name & ".obj", OBJ, False, System.Text.Encoding.ASCII)
        My.Computer.FileSystem.WriteAllText("C:\Users\Andreas\Desktop\" & name & ".mtl", MTL, False, System.Text.Encoding.ASCII)
    End Sub

    Function ColorToString(c As Color) As String
        Dim R, G, B As String
        R = Convert.ToString(c.R, 16)
        G = Convert.ToString(c.G, 16)
        B = Convert.ToString(c.B, 16)

        If R.Length = 1 Then R = "0" & R
        If G.Length = 1 Then R = "0" & G
        If B.Length = 1 Then R = "0" & B

        Return R & G & B
    End Function
End Module
