Imports BBB_Printing

Public Class frmReprintLabelsFromRFID
    Private ConString As String = ""

    Public BinLookup As String(,)
    Public RFIDs As New List(Of String)
    Public LastRFID As String = ""
    Public LastDateTime As Date = Now

    Public Bin As String
    Public BBBCorePN As String
    Public GMCorePN As String
    Public RFID As String
    Public RFIDidx As Integer
    Public HasBadDTCs As String
    Public BrokenConnector As String
    Public Event RePrintLabel(Bin As String, BBBCorePN As String, GMCorePN As String, RFID As String, RFIDidx As Integer, HasBadDTCs As String, BrokenConnector As String)


    Public Sub New(BinLookup As String(,), ConString As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.BinLookup = BinLookup
        Me.ConString = ConString
    End Sub

    Public Sub RFIDScanned(RFID As String)
        'RFID = "2800A2F2DD"
        If RFIDs.Count = 0 Then
            Dim sec As Integer = Now.Subtract(LastDateTime).TotalSeconds
            If (RFID = LastRFID) And (sec < 12) Then Exit Sub
            RFIDs.Add(RFID)
            LastRFID = RFID
            LastDateTime = Now
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Visible = False
        Me.Close()
    End Sub

    Private Sub frmReprintLabelsFromRFID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tmr.Enabled = True

    End Sub

    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        tmr.Enabled = False
        If RFIDs.Count <> 0 Then
            'PrintLabel
            Dim dt As DataTable = lookupInfo(RFIDs(0))
            Try
                Dim BinInfo As String = ""
                If dt.Rows.Count = 1 Then
                    If dt.Rows(0)("Product") = "K2XX BBB" Then
                        BinInfo = dt.Rows(0)("Bin")
                        RFID = dt.Rows(0)("RFIDtag")
                        RFIDidx = dt.Rows(0)("idx")
                        HasBadDTCs = dt.Rows(0)("BadDTCs")
                        BrokenConnector = dt.Rows(0)("ConnectorsBroken")
                         Bin = ""
                        GMCorePN = ""
                        If BinInfo.Contains("203-") Then
                            BBBCorePN = BinInfo
                        ElseIf BinInfo.Contains("Hold") Then
                            BBBCorePN = BinInfo
                        ElseIf BinInfo.Contains("Remove MPP:") Then
                            BinInfo = BinInfo.Replace("Remove MPP: ", "")
                            Dim s As String() = BinInfo.Split("-")
                            Bin = s(0).Trim
                            BBBCorePN = s(1).Trim
                        End If
                        ListBox1.Items.Insert(0, RFID + " - " + RFIDidx.ToString + " : " + BBBCorePN + " : " + Bin)
                        RaiseEvent RePrintLabel(Bin, BBBCorePN, GMCorePN, RFID, RFIDidx, HasBadDTCs, BrokenConnector)

                    Else
                        BinInfo = dt.Rows(0)("Bin")
                        BinInfo = BinInfo.Replace("Remove MPP: ", "")
                        If BinInfo.Contains("-") Then
                            Dim s As String() = BinInfo.Split("-")
                            's(1) = s(1).Replace(" Bin", "")
                            Bin = s(0).Trim
                            BBBCorePN = s(1).Trim
                            GMCorePN = GetLookupValue(s(1).Replace(" Bin", ""), 5)
                            RFID = dt.Rows(0)("RFIDtag")
                            RFIDidx = dt.Rows(0)("idx")
                            HasBadDTCs = dt.Rows(0)("BadDTCs")
                            BrokenConnector = dt.Rows(0)("ConnectorsBroken")

                            ListBox1.Items.Insert(0, RFID + " - " + RFIDidx.ToString + " : " + Bin + " : " + BBBCorePN + " : " + GMCorePN)
                            RaiseEvent RePrintLabel(Bin, BBBCorePN, GMCorePN, RFID, RFIDidx, HasBadDTCs, BrokenConnector)
                        End If
                    End If
                Else
                    ListBox1.Items.Insert(0, "RFID Tag (" + RFIDs(0) + ") not found")
                End If
            Catch ex As Exception

            End Try
            RFIDs.RemoveAt(0)
        End If
        tmr.Enabled = True
    End Sub

    Private Function lookupInfo(RFID As String) As DataTable
        lookupInfo = Nothing
        'Select Case [RFIDtag],[BIN] FROM [EPSData].[dbo].[K2XX_CoreSort] 
        '--where RFIDTag='04003F381C' and [Status]=1
        '--where RFIDTag='04004002AD' and [Status]=1
        '--where RFIDTag='02006811CF' and [Status]=1

        Try
            Dim sqlCmd As String = "SELECT [idx],[Product],[RFIDtag],[BIN],[BadDTCs],[ConnectorsBroken] FROM [EPSData].[dbo].[K2XX_CoreSort] WHERE RFIDTag=@RFID and [Status]=1;"
            If Gvars.ProductType = 2 Then
                sqlCmd = sqlCmd.Replace("[K2XX_CoreSort]", "[T1XX_CoreSort]")
            End If
            Dim ds As New BBBLib.SQL.dsDataSet(ConString, sqlCmd, {{"@RFID", RFID}})
            BBBLib.SQL.RunSQLQuery(ds)
            lookupInfo = ds.rtDataSet.Tables(0)


        Catch ex As Exception
            lookupInfo = Nothing
        End Try

    End Function

    Private Function GetLookupValue(PN As String, ReturnColumn As Integer) As String
        '0 - BIN
        '1 - BBB Core Number
        '2 - GM / ACD #
        '3 - BBB MTR #
        '4 - C\S
        Dim PNHasH As Boolean = ((PN.Contains("H")) And (Not PN.Contains("Hold")))
        If PNHasH Then PN = PN.Replace("H", "")
        For i = 0 To BinLookup.GetUpperBound(0)
            If BinLookup(i, 1).Trim.ToUpper = PN.Trim.ToUpper Then
                Return BinLookup(i, ReturnColumn).Trim.ToUpper
            End If
        Next

        Throw New Exception("PN not found in lookup table.  PN: " + PN)
        Return ""
    End Function
End Class