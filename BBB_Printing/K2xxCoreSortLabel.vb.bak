Imports System.Drawing.Printing
Imports System.Drawing
Imports Gma.QrCodeNet.Encoding.Windows.Render
Imports Gma.QrCodeNet.Encoding
Imports System.IO
Imports BBBLib

Public Class K2xxCoreSortLabel

    Public Structure sK2xxLabelInfo
        Public OffSet As Point
        Public PrinterName As String
        Public Text As List(Of sPrinterText)
        Public Variables As String(,)

        Public Bin As String
        Public BBBCorePN As String
        Public GMCorePN As String
        Public RFID As String
        Public RFIDidx As Integer
        Public PartInfo As String
        Public Sub setVars()
            Variables = {{"%Bin%", Bin},
                         {"%BBBCorePN%", BBBCorePN},
                         {"%GMCorePN%", IIf(BBBCorePN = GMCorePN, "", GMCorePN)},
                         {"%RFID%", RFID},
                         {"%RFIDidx%", RFIDidx.ToString},
                         {"%PartInfo%", PartInfo}}
        End Sub
        Public Sub New(Bool As Boolean)
            Me.PrinterName = My.Settings.PrinterName
            Me.OffSet = New Point(My.Settings.OffsetX, My.Settings.OffsetY)
            Text = New List(Of sPrinterText)
        End Sub
        Public Sub New(PrinterName As String, Offset As Point)
            Me.PrinterName = PrinterName
            Me.OffSet = Offset
            Text = New List(Of sPrinterText)
        End Sub

    End Structure

    Public Structure sPrinterText
        Public Text As String
        Public Loc As Point
        Public isBarcode As Boolean
        Public BarCodeSize As Single    '2.5
        Public FontName As String
        Public FontSize As Integer
        Public FontStyle As FontStyle
        Public Function EncodeToString() As String
            EncodeToString = Text + "~" + Loc.ToString + "~" + isBarcode.ToString + "~" + BarCodeSize.ToString + "~" + FontName + "~" + FontSize.ToString + "~" + CInt(FontStyle).ToString
        End Function
        Public Sub DecodeFromString(LabelString As String)
            Dim s As String() = LabelString.Split("~")
            Text = s(0)
            Dim ss As String() = s(1).Replace("{X=", "").Replace("Y=", "").Replace("}", "").Split(",")
            Loc = New Point(ss(0), ss(1))
            isBarcode = IIf(s(2) = "True", True, False)
            BarCodeSize = CSng(s(3))
            FontName = s(4)
            FontSize = CInt(s(5))
            FontStyle = CInt(s(6))
        End Sub
        Public Sub New(Text As String, Loc As Point, FontName As String, FontSize As Integer, FontStyle As FontStyle)
            Me.Text = Text
            Me.Loc = Loc
            Me.isBarcode = False
            Me.FontName = FontName
            Me.FontSize = FontSize
            Me.FontStyle = FontStyle
        End Sub
        Public Sub New(Text As String, Loc As Point)
            Me.Text = Text
            Me.Loc = Loc
            Me.isBarcode = True
        End Sub
        Public Sub New(EncodedString As String)
            DecodeFromString(EncodedString)
        End Sub
    End Structure

    Public Shared PrinterInfo As New sK2xxLabelInfo

    Public Shared Property PrinterName As String = ""
    Public Shared Property LabelWidth As Integer = 200
    Public Shared Property LabelHeight As Integer = 100

    Public Shared PrtDoc As PrintDocument
    Public Shared Function isPrinterSelected() As Boolean
        Return (My.Settings.PrinterName.ToString.ToUpper.Trim <> "NO PRINTER SELECTED") And (My.Settings.PrinterName.ToString.ToUpper.Trim <> "")
    End Function

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

    'Public Shared Sub setupPrtdoc(lblType As eLabelType, Optional SuppressRecordingInfo As Boolean = False)
    '    SuppressRecordingLabelInfo = SuppressRecordingInfo

    '    Labeltype = lblType
    '    SetPrinterValues(lblType)

    '    Try
    '        RemoveHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
    '    Catch ex As Exception
    '    End Try

    '    PrtDoc = New PrintDocument
    '    Dim pkCustomSize1 As PaperSize = New PaperSize("Custom Label 2.0 x 1.0", LabelWidth, LabelHeight)
    '    PrtDoc.DefaultPageSettings.PaperSize = pkCustomSize1

    '    PrtDoc.PrinterSettings.PrinterName = CurrentPrinterValues.PrinterName

    '    Font = CurrentPrinterValues.Font
    '    FontSize = CurrentPrinterValues.FontSize
    '    Line1Loc = CurrentPrinterValues.Line1Loc
    '    Line2Loc = CurrentPrinterValues.Line2Loc
    '    Line3Loc = CurrentPrinterValues.Line3Loc
    '    Barcode4Loc = CurrentPrinterValues.Barcode4Loc

    '    AddHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
    'End Sub
    Private Shared Sub PrintDoc_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs)
        Try
            PrinterLayout(e)
        Catch ex As Exception
        End Try
    End Sub



    'Public Shared Sub SetPrinterValues(lblType As eLabelType)
    '    CurrentPrinterValues = New sPrinterValues
    '    CurrentPrinterValues.isValid = False
    '    For i = 0 To PrinterValues.Count - 1
    '        If PrinterValues(i).PrinterType = lblType Then
    '            CurrentPrinterValues.PrinterType = PrinterValues(i).PrinterType
    '            CurrentPrinterValues.PrinterName = PrinterValues(i).PrinterName
    '            CurrentPrinterValues.Font = PrinterValues(i).Font
    '            CurrentPrinterValues.FontSize = PrinterValues(i).FontSize
    '            CurrentPrinterValues.Line1Loc = PrinterValues(i).Line1Loc
    '            CurrentPrinterValues.Line2Loc = PrinterValues(i).Line2Loc
    '            CurrentPrinterValues.Line3Loc = PrinterValues(i).Line3Loc
    '            CurrentPrinterValues.Barcode4Loc = PrinterValues(i).Barcode4Loc
    '            CurrentPrinterValues.isValid = True
    '            Exit For
    '        End If
    '    Next
    'End Sub
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
    'Public Shared Sub SetLabelData(Line1 As String, Line2 As String, Line3 As String, Line4 As String)
    '    'SN = SerialNumber
    '    'PN = PartNumber
    '    'LC = LotCode
    '    Line1Val = Line1 'PartNumber
    '    Line2Val = Line2 'SerialNumber
    '    Line3Val = Line3 'LotCode
    '    Line4Val = Line4 'BarCode
    'End Sub
    'Public Shared Sub SetLabelData(Data As Object())
    '    Line1Val = ""  'PartNumber
    '    Line2Val = ""  'SerialNumber
    '    Line3Val = ""  'LotCode
    '    Line4Val = ""  'BarCode

    '    Try
    '        Line1Val = Data(0)  'PartNumber
    '        Line2Val = Data(1)  'SerialNumber
    '        Line3Val = Data(2)  'LotCode
    '        Line4Val = Data(3)  'BarCode
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Shared Function GetText(Text As String, variables As String(,)) As String
        GetText = Text
        If IsNothing(variables) Then Return Text
        Try
            For i = 0 To variables.GetUpperBound(0)
                GetText = GetText.Replace(variables(i, 0), variables(i, 1))
            Next
        Catch ex As Exception
        End Try
    End Function
    Public Shared Sub PrinterLayout(e As PrintPageEventArgs)
        Dim sText As List(Of sPrinterText) = PrinterInfo.Text

        For i = 0 To sText.Count - 1
            Dim pt As Point = New Point(sText(i).Loc.X + My.Settings.OffsetX, sText(i).Loc.Y + My.Settings.OffsetY)
            Dim text As String = GetText(sText(i).Text, PrinterInfo.Variables)
            If sText(i).isBarcode Then
                Dim aColor As Brush = Brushes.Black
                Using bmp As Bitmap = GenerateQRCode(text, sText(i).BarCodeSize, aColor, Brushes.White)
                    e.Graphics.DrawImage(bmp, pt)
                End Using
            Else
                Dim aBrush As New SolidBrush(Color.Black)
                Dim aFont As New Font(sText(i).FontName, sText(i).FontSize, sText(i).FontStyle)
                e.Graphics.DrawString(text, aFont, aBrush, pt)
                aBrush.Dispose()
                aFont.Dispose()
                aFont = Nothing
            End If
        Next
        ' Added by Enrique Juarez
        If BBBLib.Func.theComputerName = "LAP-LJUAREZ" Then
            e.Graphics.DrawRectangle(New Pen(Color.Black), New Rectangle(0, 0, 200, 100))
        End If

    End Sub

    'Private Shared Sub PrinterLayout_SNOnly(e As PrintPageEventArgs)
    '    ''Dim Line1 As String = PN
    '    'Dim Line2 As String = SN
    '    ''Dim Line3 As String = "Remanufactured"

    '    Dim aBrush As New SolidBrush(Color.Black)
    '    Dim aFont As New Font(Font, FontSize, FontStyle.Bold)

    '    e.Graphics.DrawString(Line2Val, aFont, aBrush, Line2Loc)

    '    Dim aColor As Brush = Brushes.Black
    '    'Using bmp As Bitmap = GenerateQRCode(SN, 2.5, aColor, Brushes.White)
    '    Using bmp As Bitmap = GenerateQRCode(Line4Val, 2.5, aColor, Brushes.White)
    '        e.Graphics.DrawImage(bmp, Barcode4Loc)
    '    End Using

    '    aBrush.Dispose()
    '    aFont.Dispose()
    '    aFont = Nothing
    'End Sub

    'Private Shared Sub PrinterLayout_Mopar(e As PrintPageEventArgs)
    '    'Dim Line1 As String = PN
    '    'Dim Line2 As String = SN
    '    'Dim Line3 As String = LC
    '    'Dim Line3 As String = GenerateMoparDateCode()

    '    Dim aBrush As New SolidBrush(Color.Black)
    '    Dim aFont As New Font(Font, FontSize, FontStyle.Bold)

    '    e.Graphics.DrawString(Line1Val, aFont, aBrush, Line1Loc)
    '    e.Graphics.DrawString(Line2Val, aFont, aBrush, Line2Loc)
    '    e.Graphics.DrawString(Line3Val, aFont, aBrush, Line3Loc)

    '    aBrush.Dispose()
    '    aFont.Dispose()
    '    aFont = Nothing
    'End Sub

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
    'Public Shared Function GenerateOEDateCode(Shift As String, ID As String) As String
    '    Dim jDate As String = Now.DayOfYear.ToString.PadLeft(3, "0")
    '    GenerateOEDateCode = Shift.Trim + jDate + Now.Year.ToString.Substring(3, 1) + ID.Trim
    'End Function
    'Public Shared Function GenerateMoparDateCodeJJJ_YY() As String
    '    Dim aDate As Date = Now
    '    GenerateMoparDateCodeJJJ_YY = aDate.DayOfYear.ToString.PadLeft(3, "0") + " / " + aDate.ToString("yy")
    '    LastLotCode = GenerateMoparDateCodeJJJ_YY
    'End Function
End Class
