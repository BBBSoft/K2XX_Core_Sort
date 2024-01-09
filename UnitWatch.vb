Public Class UnitWatch

    Private Shared aConString As String

    Public Structure sUnitWatch
        Public Index As Integer
        Public TIC As String
        Public VIN As String
        Public Contact As String
        Public Ext As String
        Public Email As String
        Public WatchMessage As String
        Public Instructions As String
        Public Found As Boolean
        Public RFIDtag As String
        Public RFIDidx As Integer

        Public Sub New(Index As Integer, TIC As String, VIN As String, Contact As String, Ext As String, Email As String, WatchMessage As String, Instructions As String)
            Me.Index = Index
            Me.TIC = TIC
            Me.VIN = VIN
            Me.Contact = Contact
            Me.Ext = Ext
            Me.Email = Email
            Me.WatchMessage = WatchMessage
            Me.Instructions = Instructions
        End Sub

        Public Function WatchMessage1() As String
            Dim rt As String = ReplaceValue(WatchMessage.Trim)
            Return rt
        End Function
        Public Function Instructions1() As String
            Dim rt As String = ReplaceValue(Instructions.Trim)
            Return rt
        End Function
        Private Function ReplaceValue(aStr As String) As String
            aStr = aStr.Replace("<CR>", vbCr).Replace("<TIC>", TIC).Replace("<VIN>", VIN).Replace("<EXT>", Ext).Replace("<CONTACT>", Contact).Replace("<EMAIL>", Email).Replace("<RFIDTAG>", RFIDtag).Replace("<RFIDIDX>", RFIDidx)
            aStr = aStr.Replace("<cr>", vbCr).Replace("<tic>", TIC).Replace("<vin>", VIN).Replace("<ext>", Ext).Replace("<contact>", Contact).Replace("<email>", Email).Replace("<rfidtag>", RFIDtag).Replace("<rfididx>", RFIDidx)
            Return aStr
        End Function
    End Structure


    Public Shared Function UnitWatch(ConString As String, TIC1 As String, TIC2 As String, VIN As String, RFIDtag As String, RFIDidx As Integer, ByRef Contact As String, ByRef Ext As String) As Boolean
        UnitWatch = False
        'TIC1 = rack SN
        'TIC2 = Mtr SN
        'VIN = VIN

        aConString = ConString
        Dim aList As List(Of sUnitWatch) = GetListOfAlerts()
        Dim Found As sUnitWatch = Nothing

        For i = 0 To aList.Count - 1
            Dim a As sUnitWatch = aList(i)
            If TIC1.ToUpper Like "*" + a.TIC.ToUpper.Trim.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "") + "*" Then
                Found = aList(i)
                UnitWatch = True
            End If
            If TIC2.ToUpper Like "*" + a.TIC.ToUpper.Trim.Replace(vbCr, "").Replace(vbLf, "").Replace(vbCrLf, "") + "*" Then
                Found = aList(i)
                UnitWatch = True
            End If
            If VIN.ToUpper Like "*" + a.VIN.ToUpper.Trim + "*" Then
                Found = aList(i)
                UnitWatch = True
            End If

            If UnitWatch = True Then Exit For
        Next

        If UnitWatch = True Then
            Found.RFIDtag = RFIDtag
            Found.RFIDidx = RFIDidx
            Contact = Found.Contact
            Ext = Found.Ext.Trim
            UpdateAlerts(Found)
            Dim frm As New frmAlertWindow(Found)

        End If

    End Function

    Private Shared Function GetListOfAlerts() As List(Of sUnitWatch)
        GetListOfAlerts = New List(Of sUnitWatch)

        Dim ds As New BBBLib.SQL.dsDataSet(aConString, "SELECT * FROM [EPSData].[dbo].[K2XX_UnitWatch]", Nothing)
        BBBLib.SQL.RunSQLQuery(ds)

        Dim dt As DataTable = ds.rtDataSet.Tables(0)

        For r = 0 To dt.Rows.Count - 1
            Dim a As New sUnitWatch(dt.Rows(r)("Idx").ToString,
                                    dt.Rows(r)("TIC").ToString,
                                    dt.Rows(r)("VIN").ToString,
                                    dt.Rows(r)("Contact").ToString,
                                    dt.Rows(r)("Ext").ToString,
                                    dt.Rows(r)("Email").ToString,
                                    dt.Rows(r)("AlertMessage1").ToString,
                                    dt.Rows(r)("AlertInstructions").ToString)
            GetListOfAlerts.Add(a)
        Next
    End Function
    Private Shared Function UpdateAlerts(Unit As sUnitWatch) As Boolean

        Dim ds As New BBBLib.SQL.dsDataSet(aConString, "UPDATE [EPSData].[dbo].[K2XX_UnitWatch] SET FoundDate=Current_TimeStamp WHERE Idx=@Idx", {{"@Idx", Unit.Index}})
        BBBLib.SQL.RunSQLQuery(ds)

        UpdateAlerts = Not (ds.Failed)
    End Function
    Public Shared Function SetRFIDidxStatusToInactive(Idx As Integer) As Boolean
        Dim ds As BBBLib.SQL.dsDataSet = Nothing
        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            ds = New BBBLib.SQL.dsDataSet(aConString, "UPDATE [EPSData].[dbo].[K2XX_CoreSort] SET [Status]=2 WHERE Idx=@Idx AND [Status]=1;", {{"@Idx", Idx}})
        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            ds = New BBBLib.SQL.dsDataSet(aConString, "UPDATE [EPSData].[dbo].[T1XX_CoreSort] SET [Status]=2 WHERE Idx=@Idx AND [Status]=1;", {{"@Idx", Idx}})
        End If

        BBBLib.SQL.RunSQLQuery(ds)
    End Function
End Class
