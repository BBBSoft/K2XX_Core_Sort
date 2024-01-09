Imports System.Drawing.Printing
Imports System.Drawing
Imports Gma.QrCodeNet.Encoding.Windows.Render
Imports Gma.QrCodeNet.Encoding
Imports System.IO
Imports BBBLib


Public Class Labels
    Private Sub labelPrinting()

        '*** SNOnly ***
        '    Labels.setupPrtdoc(Labels.eLabelType.SNOnly)
        '    Dim LabelData As Object() = {"",
        '                                 SN,
        '                                 "",
        '                                 SN}
        '    Labels.SetLabelData(LabelData)
        '    Labels.PrtDoc.Print()



        '*** Mopar ***
        '    Labels.setupPrtdoc(Labels.eLabelType.Mopar)
        '    Dim LotCode As String = Labels.GenerateMoparDateCodeJJJ_YY
        '    Dim LabelData As Object() = {PN,
        '                                 SN,
        '                                 LotCode,
        '                                 ""}
        '    Labels.SetLabelData(LabelData)
        '    Labels.PrtDoc.Print()


        '*** AMAM ***
        '    Labels.setupPrtdoc(Labels.eLabelType.AMAM)
        '    Dim LabelData As Object() = {PN,
        '                                 SN,
        '                                 "Remanufactured",
        '                                 "#" + PN + "#" + SN}
        '    Labels.SetLabelData(LabelData)
        '    Labels.PrtDoc.Print()
    End Sub
    Public Enum eLabelType
        UnAssigned = 0
        AMAM = 100
        Mopar = 200
        SNOnly = 300
    End Enum

    ' Public Shared LastUpdated As Date = Now.AddDays(-1)
    'Private Shared LabelConfigINIFileName As String = ""
    Public Structure sPrinterValues
        Public PrinterType As eLabelType
        Public PrinterName As String
        Public Font As String
        Public FontSize As String
        Public OffSet As Point
        Public Line1Loc As Point
        Public Line2Loc As Point
        Public Line3Loc As Point
        Public Barcode4Loc As Point
        Public isValid As Boolean
    End Structure
    Public Shared PrinterValues As New List(Of sPrinterValues)
    Public Shared CurrentPrinterValues As sPrinterValues

    Public Shared Property PrinterName As String = ""
    Public Shared Property LabelWidth As Integer = 200
    Public Shared Property LabelHeight As Integer = 100
    Public Shared Property Labeltype As eLabelType = eLabelType.AMAM
    Public Shared Property LastLabelType As eLabelType = eLabelType.UnAssigned
    Public Shared Property LastLotCode As String = ""


    Public Shared Property Font As String = "Arial"
    Public Shared Property FontSize As Integer = 12
    Public Shared Property Line1Loc As Point = New Point(20, 55)
    Public Shared Property Line2Loc As Point = New Point(20, 75)
    Public Shared Property Line3Loc As Point = New Point(20, 75)
    Public Shared Property Barcode4Loc As Point = New Point(20, 5)
    Public Shared Property SuppressRecordingLabelInfo As Boolean = False


    Public Shared Property PN As String
    Public Shared SN As String
    Public Shared LC As String

    Public Shared Line1Val As String = ""
    Public Shared Line2Val As String = ""
    Public Shared Line3Val As String = ""
    Public Shared Line4Val As String = ""

    Public Shared PrtDoc As PrintDocument

    Public Shared Sub setupPrtdoc()


        Try
            RemoveHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
        Catch ex As Exception
        End Try

        PrtDoc = New PrintDocument
        Dim pkCustomSize1 As PaperSize = New PaperSize("Custom Label 2.0 x 1.0", LabelWidth, LabelHeight)
        PrtDoc.DefaultPageSettings.PaperSize = pkCustomSize1
        AddHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
    End Sub

    Public Shared Sub setupPrtdoc(lblType As eLabelType, Optional SuppressRecordingInfo As Boolean = False)
        SuppressRecordingLabelInfo = SuppressRecordingInfo

        Labeltype = lblType
        SetPrinterValues(lblType)

        Try
            RemoveHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
        Catch ex As Exception
        End Try

        PrtDoc = New PrintDocument
        Dim pkCustomSize1 As PaperSize = New PaperSize("Custom Label 2.0 x 1.0", LabelWidth, LabelHeight)
        PrtDoc.DefaultPageSettings.PaperSize = pkCustomSize1

        PrtDoc.PrinterSettings.PrinterName = CurrentPrinterValues.PrinterName

        Font = CurrentPrinterValues.Font
        FontSize = CurrentPrinterValues.FontSize
        Line1Loc = CurrentPrinterValues.Line1Loc
        Line2Loc = CurrentPrinterValues.Line2Loc
        Line3Loc = CurrentPrinterValues.Line3Loc
        Barcode4Loc = CurrentPrinterValues.Barcode4Loc

        AddHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
    End Sub
    Private Shared Sub PrintDoc_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs)
        Try
            Select Case Labeltype
                Case eLabelType.AMAM
                    PrinterLayout_AMAM(e)
                Case eLabelType.Mopar
                    PrinterLayout_Mopar(e)
                Case eLabelType.SNOnly
                    PrinterLayout_SNOnly(e)
                Case Else
                    PrinterLayout_AMAM(e)
            End Select

            'If Not SuppressRecordingLabelInfo Then BBB_EPS.saveLabelPrintedInfo(Labeltype.ToString, Line1Val, Line2Val, Line3Val, Line4Val)
            SuppressRecordingLabelInfo = False

        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub InitPrinterValuesFromINIFile()
        PrinterValues = New List(Of sPrinterValues)
        ReadINIValues2(eLabelType.SNOnly)
        ReadINIValues2(eLabelType.AMAM)
        ReadINIValues2(eLabelType.Mopar)
    End Sub

    Public Shared Sub ReadINIValues2(LblType As eLabelType)

        Dim PrtValues As New sPrinterValues
        PrtValues.PrinterType = LblType

        Dim Pt As String = ""
        Dim s As String()

        INI.ReadINI2(LblType.ToString, "PrinterName", PrtValues.PrinterName, "")
        INI.ReadINI2(LblType.ToString, "Font", PrtValues.Font, "Arial")
        INI.ReadINI2(LblType.ToString, "FontSize", PrtValues.FontSize, "11")

        INI.ReadINI2(LblType.ToString, "Offset", Pt, "0,0")
        s = Pt.Split(",")
        PrtValues.OffSet = New Point(Integer.Parse(s(0)), Integer.Parse(s(1)))

        INI.ReadINI2(LblType.ToString, "Line1Loc", Pt, "1,25")
        s = Pt.Split(",")
        PrtValues.Line1Loc = New Point(Integer.Parse(s(0)) + PrtValues.OffSet.X, Integer.Parse(s(1)) + PrtValues.OffSet.Y)

        INI.ReadINI2(LblType.ToString, "Line2Loc", Pt, "1,50")
        s = Pt.Split(",")
        PrtValues.Line2Loc = New Point(Integer.Parse(s(0)) + PrtValues.OffSet.X, Integer.Parse(s(1)) + PrtValues.OffSet.Y)

        INI.ReadINI2(LblType.ToString, "Line3Loc", Pt, "1,75")
        s = Pt.Split(",")
        PrtValues.Line3Loc = New Point(Integer.Parse(s(0)) + PrtValues.OffSet.X, Integer.Parse(s(1)) + PrtValues.OffSet.Y)

        INI.ReadINI2(LblType.ToString, "Barcode4Loc", Pt, "135,15")
        s = Pt.Split(",")
        PrtValues.Barcode4Loc = New Point(Integer.Parse(s(0)) + PrtValues.OffSet.X, Integer.Parse(s(1)) + PrtValues.OffSet.Y)

        PrtValues.isValid = True

        PrinterValues.Add(PrtValues)
    End Sub

    Public Shared Sub SetPrinterValues(lblType As eLabelType)
        CurrentPrinterValues = New sPrinterValues
        CurrentPrinterValues.isValid = False
        For i = 0 To PrinterValues.Count - 1
            If PrinterValues(i).PrinterType = lblType Then
                CurrentPrinterValues.PrinterType = PrinterValues(i).PrinterType
                CurrentPrinterValues.PrinterName = PrinterValues(i).PrinterName
                CurrentPrinterValues.Font = PrinterValues(i).Font
                CurrentPrinterValues.FontSize = PrinterValues(i).FontSize
                CurrentPrinterValues.Line1Loc = PrinterValues(i).Line1Loc
                CurrentPrinterValues.Line2Loc = PrinterValues(i).Line2Loc
                CurrentPrinterValues.Line3Loc = PrinterValues(i).Line3Loc
                CurrentPrinterValues.Barcode4Loc = PrinterValues(i).Barcode4Loc
                CurrentPrinterValues.isValid = True
                Exit For
            End If
        Next
    End Sub
    'Public Shared Sub ReadINIValues()
    '    If LastLabelType = Labeltype Then Exit Sub
    '    LastLabelType = Labeltype

    '    Dim OriginalINIFile As String = INI.INIFileName
    '    Try
    '        INI.INIFileName = "LabelConfig_" + Func.theComputerName + ".ini"

    '        'MsgBox(INI.INIFilePath)
    '        'MsgBox(INI.INIFileName)

    '        Dim Pt As String = ""
    '        Dim s As String()

    '        INI.ReadINI2(Labeltype.ToString, "PrinterName", PrinterName, PrinterName)
    '        INI.ReadINI2(Labeltype.ToString, "Font", Font, Font)
    '        INI.ReadINI2(Labeltype.ToString, "FontSize", FontSize, FontSize.ToString)
    '        'MsgBox(PrinterName)


    '        INI.ReadINI2(Labeltype.ToString, "Line1", Pt, System.Text.RegularExpressions.Regex.Replace(Line1Loc.ToString, "[\{\}a-zA-Z=]", ""))
    '        s = Pt.Split(",")
    '        Line1Loc = New Point(Integer.Parse(s(0)), Integer.Parse(s(1)))

    '        INI.ReadINI2(Labeltype.ToString, "Line2", Pt, System.Text.RegularExpressions.Regex.Replace(Line2Loc.ToString, "[\{\}a-zA-Z=]", ""))
    '        s = Pt.Split(",")
    '        Line2Loc = New Point(Integer.Parse(s(0)), Integer.Parse(s(1)))

    '        INI.ReadINI2(Labeltype.ToString, "Line3", Pt, System.Text.RegularExpressions.Regex.Replace(Line3Loc.ToString, "[\{\}a-zA-Z=]", ""))
    '        s = Pt.Split(",")
    '        Line3Loc = New Point(Integer.Parse(s(0)), Integer.Parse(s(1)))

    '        INI.ReadINI2(Labeltype.ToString, "Barcode", Pt, System.Text.RegularExpressions.Regex.Replace(Barcode4Loc.ToString, "[\{\}a-zA-Z=]", ""))
    '        s = Pt.Split(",")
    '        Barcode4Loc = New Point(Integer.Parse(s(0)), Integer.Parse(s(1)))
    '    Catch ex As Exception

    '    Finally
    '        INI.INIFileName = OriginalINIFile
    '    End Try


    'End Sub

    'Public Shared Sub SetSN(SerialNumber As String, PartNumber As String, Optional LotCode As String = "")
    '    SN = SerialNumber
    '    PN = PartNumber
    '    LC = LotCode
    'End Sub
    Public Shared Sub SetLabelData(Line1 As String, Line2 As String, Line3 As String, Line4 As String)
        'SN = SerialNumber
        'PN = PartNumber
        'LC = LotCode
        Line1Val = Line1 'PartNumber
        Line2Val = Line2 'SerialNumber
        Line3Val = Line3 'LotCode
        Line4Val = Line4 'BarCode
    End Sub
    Public Shared Sub SetLabelData(Data As Object())
        Line1Val = ""  'PartNumber
        Line2Val = ""  'SerialNumber
        Line3Val = ""  'LotCode
        Line4Val = ""  'BarCode

        Try
            Line1Val = Data(0)  'PartNumber
            Line2Val = Data(1)  'SerialNumber
            Line3Val = Data(2)  'LotCode
            Line4Val = Data(3)  'BarCode
        Catch ex As Exception

        End Try
    End Sub
    Private Shared Sub PrinterLayout_AMAM(e As PrintPageEventArgs)
        'Dim Line1 As String = PN
        'Dim Line2 As String = SN
        'Dim Line3 As String = "Remanufactured"
        'Dim BC As String = "#" + PN + "#" + SN
        If Line4Val = "" Then Line4Val = "#" + Line1Val + "#" + Line2Val

        Dim aBrush As New SolidBrush(Color.Black)
        Dim aFont As New Font(Font, FontSize, FontStyle.Bold)

        e.Graphics.DrawString(Line1Val, aFont, aBrush, Line1Loc)
        e.Graphics.DrawString(Line2Val, aFont, aBrush, Line2Loc)
        e.Graphics.DrawString(Line3Val, aFont, aBrush, Line3Loc)

        Dim aColor As Brush = Brushes.Black
        'Using bmp As Bitmap = GenerateQRCode("#" + PN + "#" + SN, 2.5, aColor, Brushes.White)
        Using bmp As Bitmap = GenerateQRCode(Line4Val, 2.5, aColor, Brushes.White)
            e.Graphics.DrawImage(bmp, Barcode4Loc)
        End Using

        aBrush.Dispose()
        aFont.Dispose()
        aFont = Nothing
    End Sub

    Private Shared Sub PrinterLayout_SNOnly(e As PrintPageEventArgs)
        ''Dim Line1 As String = PN
        'Dim Line2 As String = SN
        ''Dim Line3 As String = "Remanufactured"

        Dim aBrush As New SolidBrush(Color.Black)
        Dim aFont As New Font(Font, FontSize, FontStyle.Bold)

        e.Graphics.DrawString(Line2Val, aFont, aBrush, Line2Loc)

        Dim aColor As Brush = Brushes.Black
        'Using bmp As Bitmap = GenerateQRCode(SN, 2.5, aColor, Brushes.White)
        Using bmp As Bitmap = GenerateQRCode(Line4Val, 2.5, aColor, Brushes.White)
            e.Graphics.DrawImage(bmp, Barcode4Loc)
        End Using

        aBrush.Dispose()
        aFont.Dispose()
        aFont = Nothing
    End Sub

    Private Shared Sub PrinterLayout_Mopar(e As PrintPageEventArgs)
        'Dim Line1 As String = PN
        'Dim Line2 As String = SN
        'Dim Line3 As String = LC
        'Dim Line3 As String = GenerateMoparDateCode()

        Dim aBrush As New SolidBrush(Color.Black)
        Dim aFont As New Font(Font, FontSize, FontStyle.Bold)

        e.Graphics.DrawString(Line1Val, aFont, aBrush, Line1Loc)
        e.Graphics.DrawString(Line2Val, aFont, aBrush, Line2Loc)
        e.Graphics.DrawString(Line3Val, aFont, aBrush, Line3Loc)

        aBrush.Dispose()
        aFont.Dispose()
        aFont = Nothing
    End Sub

    Private Shared Function GenerateQRCode(Text As String, ModuleSize As Integer, ForeColor As Brush, BackColor As Brush) As Image

        Dim QREncoder As Gma.QrCodeNet.Encoding.QrEncoder = New Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M)
        Dim QRCode As Gma.QrCodeNet.Encoding.QrCode = QREncoder.Encode(Text)
        'Dim ModuleSizeInPixels As Integer = 3

        Dim gRenderer As GraphicsRenderer = New GraphicsRenderer(
                                                New FixedModuleSize(ModuleSize, QuietZoneModules.Two), ForeColor, BackColor)
        Dim ms As MemoryStream = New MemoryStream()
        gRenderer.WriteToStream(QRCode.Matrix, System.Drawing.Imaging.ImageFormat.Bmp, ms)
        GenerateQRCode = Image.FromStream(ms)

    End Function
    Public Shared Function GenerateOEDateCode(Shift As String, ID As String) As String
        Dim jDate As String = Now.DayOfYear.ToString.PadLeft(3, "0")
        GenerateOEDateCode = Shift.Trim + jDate + Now.Year.ToString.Substring(3, 1) + ID.Trim
    End Function
    Public Shared Function GenerateMoparDateCodeJJJ_YY() As String
        Dim aDate As Date = Now
        GenerateMoparDateCodeJJJ_YY = aDate.DayOfYear.ToString.PadLeft(3, "0") + " / " + aDate.ToString("yy")
        LastLotCode = GenerateMoparDateCodeJJJ_YY
    End Function
End Class

