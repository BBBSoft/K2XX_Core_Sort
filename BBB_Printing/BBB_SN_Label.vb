Imports System.Drawing.Printing
Imports System.Drawing
Imports Gma.QrCodeNet.Encoding.Windows.Render
Imports Gma.QrCodeNet.Encoding
Imports System.IO

Public Class BBB_SN_Label
    Public Structure sBBBSNLabelInfo
        Public OffSet As Point
        Public PrinterName As String
        Public Text As List(Of sPrinterText)
        Public Variables As String(,)

        Public Bin As String
        Public BBBCorePN As String
        Public GMCorePN As String
        Public RFID As String
        Public RFIDidx As Integer
        Public Sub setVars(Vars As Object(,))
            Variables = Vars
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
        Public Sub New(Text As String, Loc As Point, BarCodeSize As Single)
            Me.Text = Text
            Me.Loc = Loc
            Me.isBarcode = True
            Me.BarCodeSize = BarCodeSize
        End Sub
        Public Sub New(EncodedString As String)
            DecodeFromString(EncodedString)
        End Sub
    End Structure

    Public Shared PrinterInfo As New sBBBSNLabelInfo

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

        If isPrinterSelected() Then
            PrtDoc.PrinterSettings.PrinterName = My.Settings.PrinterName
        End If

        Dim pkCustomSize1 As PaperSize = New PaperSize("Custom Label 2.0 x 1.0", LabelWidth, LabelHeight)
        PrtDoc.DefaultPageSettings.PaperSize = pkCustomSize1
        AddHandler PrtDoc.PrintPage, AddressOf PrintDoc_PrintPage
    End Sub

    Private Shared Sub PrintDoc_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs)
        Try
            PrinterLayout(e)
        Catch ex As Exception
        End Try
    End Sub

    Private Shared Function GetText(Text As String, variables As String(,)) As String
        GetText = Text
        For i = 0 To variables.GetUpperBound(0)
            GetText = GetText.Replace(variables(i, 0), variables(i, 1))
        Next
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
End Class
