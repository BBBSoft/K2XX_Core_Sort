Public Class Gvars

    Public Shared ConString_EPSData As String


    Public Enum eTagColor
        NotAssigned = 0
        Manila = 1
        Blue = 2
        Orange = 3
        Red = 4
    End Enum


    Public Enum eLanguage
        English = 0
        Spanish = 1
    End Enum

    Public Shared Language As eLanguage = eLanguage.Spanish

    Public Shared Phrases As String(,) = {{"Select Product", "Seleccione el producto"},
                                    {"Clear Product", "Limpie el producto"},
                                    {"Scan Rack Barcode", "Escanee la etiqueta de la carcasa"},
                                    {"Run InHale program", "Corra el programa de InHale"},
                                    {"Run Inhale", "Corra el InHale"},
                                    {"Clear Data", "Limpiar datos"},
                                    {"Answer the questions.", "Responder las preguntas"},
                                    {"Is the housing broken?", "La carcasa esta quebrada?"},
                                    {"Are connectors broken?", "Los conectores estan quebrados?"},
                                    {"Is there water ingression?", "Tiene agua en el interior?"},
                                    {"Scan an RFID tag.", "Escanee el RFID"},
                                    {"This RFID tag (<RFIDTag>) should have been attached to the previously processed unit.  Do you want to continue using this RFID tag on this unit?", "Este  RFID (<RFIDTag>) debería haberse adjuntado a la unidad procesada anteriormente. ¿Desea continuar utilizando esta etiqueta RFID en esta unidad?"},
                                    {"This RFID tag (<RFIDTag>) is already married to a unit.  Do you want to continue using this RFID tag on this unit?", "Este RFID (<RFIDTag>) ya está casada con una unidad. ¿Desea continuar utilizando esta etiqueta RFID en esta unidad?"},
                                    {"Please scan a different RFID tag.", "Por favor escane un diferente RFID"},
                                    {"Place RFID tag on Rack.", "Coloque el RFID en la carcasa"},
                                    {"Place RFID tag on Rack.", "Coloque el RFID en la carcasa"},
                                    {"BIN # <Bin#>", "BIN <Bin#>"},
                                    {"Place Rack in Hold Bin", "Coloque la carcasa en el gaylor Hold"},
                                    {"Remove MPP from Rack, Scrap Rack, and place RFID tag on MPP.", "Remover el motor de la carcasa, hacer scrap la carcasa, colocar RFID al motor"},
                                    {"Scrap", "Basura"},
                                    {"Click Clear Data button to continue.", "Seleccione el boton limpiar para continuar"},
                                    {"Data has NOT been saved!" + vbCrLf + "Are you sure you want to clear the Data?", "Los datos no se guardaron!" + vbCrLf + "Estas seguro que quieres continuar los datos?"},
                                    {"Discard both the housing and the MPP.", "Deseche tanto la carcasa como el MPP."},
                                    {"Click here when done.", "Haga clic aquí cuando haya terminado."},
                                    {"NoComm - Check connection and run inhale again or Continue Answering the questions.", "NoComm: verifique la conexión y vuelva a ejecutar el programa de inhalación o continúe respondiendo las preguntas."},
                                    {"Invalid data.  Please try running the inhale program again or contact your supervisor for assistance.", "Datos no válidos Intente ejecutar el programa de inhalación nuevamente o comuníquese con su supervisor para obtener ayuda."},
                                    {"Error reading output file. Please try running the inhale program again or contact your supervisor for assistance.", "Error al leer el archivo de salida. Intente ejecutar el programa de inhalación nuevamente o comuníquese con su supervisor para obtener ayuda."},
                                    {"Timed out running Inhale program.  Please try running the inhale program again or contact your supervisor for assistance.", "Se acabó el tiempo ejecutando el programa Inhale. Intente ejecutar el programa de inhalación nuevamente o comuníquese con su supervisor para obtener ayuda."},
                                    {"This will remove any previous data attached to this RFID and assign it to the data on this screen! Are you sure you want to do this?", "¡Esto eliminará cualquier dato anterior adjunto a este RFID y lo asignará a los datos en esta pantalla! ¿Seguro que quieres hacer esto?"},
                                    {"NoComm: disconnects the MPP power. Verify all connections to the MPP. Turn on the power again. Click on the Run inhale button again.", "NoComm: Apague la alimentación. Verifique todas las conexiones al MPP. Encienda la alimentación de nuevo. Haga click en el botón Ejecutar inhalación de nuevo."},
                                    {"Change Bill of Lading #", "Cambiar el número de BOL de embarque."},
                                    {"Are you sure you want to change the bill of lading number?", "¿Estás seguro de que quieres cambiar el número de BOL de embarque?"},
                                    {"Bill of Lading #:", "Numero de BOL de embarque:"},
                                    {"You mush enter a bill of lading number to begin.", "Para empezar debes introducir un número de BOL de embarque."},
                                    {"Enter Bill of lading number.", "Ingres número de BOL de embarque."},
                                    {"Reclassify parts", "Reclasificar unidad"},
                                    {"Are you sure you want to reclassifiy parts?", "¿Seguro que quieres reclasificar unidades?"},
                                    {"Manila Tag", "Etiqueta Manila"},
                                    {"Orange Tag", "Etiqueta Naranja"},
                                    {"Red Tag", "Etiqueta Roja"},
                                    {"Yellow Tag", "Etiqueta Amarillo"},
                                    {"Blue Tag", "Etiqueta Azul"}}

    'ToDo: Replace these with Database versions
    Private Shared DTC1 As Object(,)
    'Private Shared DTC1 As Object(,) = {{"1FB", False},
    '                                    {"1FE", False},
    '                                    {"1FD", False},
    '                                    {"C", False},
    '                                    {"E", False},
    '                                    {"65", False},
    '                                    {"60", False},
    '                                    {"66", False},
    '                                    {"67", False},
    '                                    {"1FA", False},
    '                                    {"68", False},
    '                                    {"69", False},
    '                                    {"6A", False},
    '                                    {"61", False},
    '                                    {"11", False},
    '                                    {"18", False},
    '                                    {"19", False},
    '                                    {"1D", False},
    '                                    {"1E", False},
    '                                    {"13", False},
    '                                    {"1A", False},
    '                                    {"1C", False},
    '                                    {"1B", False},
    '                                    {"17", False},
    '                                    {"21", False},
    '                                    {"4", False},
    '                                    {"10", False},
    '                                    {"22", False},
    '                                    {"23", False},
    '                                    {"30", False},
    '                                    {"31", False},
    '                                    {"2A", False},
    '                                    {"2B", False},
    '                                    {"B", False},
    '                                    {"F", False},
    '                                    {"40", False},
    '                                    {"41", False},
    '                                    {"42", False},
    '                                    {"45", False},
    '                                    {"48", False},
    '                                    {"46", False},
    '                                    {"2C", False},
    '                                    {"32", False},
    '                                    {"4D", False},
    '                                    {"36", False},
    '                                    {"33", False},
    '                                    {"35", False},
    '                                    {"1", False},
    '                                    {"3", False},
    '                                    {"25", False},
    '                                    {"C5", False},
    '                                    {"C6", False},
    '                                    {"C8", False},
    '                                    {"24", False},
    '                                    {"28", False},
    '                                    {"20", False},
    '                                    {"70", False},
    '                                    {"4F", False},
    '                                    {"4E", False},
    '                                    {"52", False},
    '                                    {"72", False},
    '                                    {"1F2", False},
    '                                    {"1F1", False},
    '                                    {"90", False},
    '                                    {"95", False},
    '                                    {"BF", True},           'Changed BF from False to True(Acceptable)
    '                                    {"2", False},
    '                                    {"12", False},
    '                                    {"E0", False},
    '                                    {"168", False},
    '                                    {"94", True},
    '                                    {"141", True},
    '                                    {"161", True},
    '                                    {"1A1", True},
    '                                    {"199", True},
    '                                    {"179", True},
    '                                    {"189", True},
    '                                    {"171", True},
    '                                    {"151", True},
    '                                    {"1B1", True},
    '                                    {"1A9", True},
    '                                    {"120", True},
    '                                    {"160", True},
    '                                    {"178", True},
    '                                    {"1A8", True},
    '                                    {"1B0", True},
    '                                    {"1A0", True},
    '                                    {"198", True},
    '                                    {"170", True},
    '                                    {"180", True},
    '                                    {"121", True},
    '                                    {"158", True},
    '                                    {"159", True},
    '                                    {"131", True},
    '                                    {"139", True},
    '                                    {"129", True},
    '                                    {"149", True},
    '                                    {"148", True},
    '                                    {"191", True},
    '                                    {"190", True},
    '                                    {"1D1", True},
    '                                    {"1D0", True},
    '                                    {"138", True}}

    Private Shared DTC2 As Object(,)
    'Private Shared DTC2 As Object(,) = {{"65", False},
    '                                    {"60", False},
    '                                    {"66", False},
    '                                    {"67", False},
    '                                    {"68", False},
    '                                    {"69", False},
    '                                    {"6A", False},
    '                                    {"61", False}}

    ' Private Shared DTC3 As Object(,)
    'Private Shared DTC3 As Object(,) = {{"1FA", False},
    '                                    {"1FB", False},
    '                                    {"1FE", False},
    '                                    {"1FD", False},
    '                                    {"C", False},
    '                                    {"E", False}}

    Public Structure sShellAndWait
        Public Timeout_mSec As Integer
        Public AppPath As String
        Public Arguments As String
        Public TimedOut As Boolean
        Public ReturnValue As Integer
        Public Completed As Boolean
        Public OutputFileLocation As String
        Public ErrorMsg As String
        Public AnError As Boolean
    End Structure
    Public Shared InhalePrg As sShellAndWait

    Public Structure sdata
        Public HoldUnit As Boolean
        Public Contact As String
        Public EXT As String

        Public Scan_RFID As Boolean
        Public RFID_Acquired As Boolean
        Public RFID_Tag As String
        Public RFID_Idx As Integer

        Public BoL As String
        Public ProductType As String
        Public RackBarcode As String
        Public CorePN As String
        Public CoreSN As String
        Public RackBuildDate As Date
        Public ValidRackBarcode As Boolean

        'Inhale Data
        Public dtInhaleData As DataTable
        Public SoftwareVersion1 As String
        Public SoftwareVersion2 As String
        Public SoftwareVersion3 As String
        Public EPS_SN As String
        Public ECU_SN As String
        Public VIN As String
        Public ManufacturingTraceability As String
        Public SpecVersion As String
        Public GearSerialNumber As String
        Public ECUHardwarePN As String
        Public GM_PN As String

        'T1xx Vars
        Public ECU_Software_Number As String
        '.EPS_SN is used from above for T1XX
        Public SoftwareBuildDate As String
        Public Cal0 As String
        Public Cal1 As String
        Public Cal2 As String
        Public BootloaderSoftwareID As String
        Public BootloaderSoftwareVer As String
        Public CCAHardwarePN As String
        'T1xx Vars End

        Public DTC1 As String
        Public DTC2 As String
        Public DTC3 As String
        Public DTC4 As String
        Public DTC5 As String
        Public DTC6 As String
        Public DTC7 As String
        Public DTC8 As String
        Public DTC9 As String
        Public DTC10 As String
        Public DTC11 As String
        Public DTC12 As String
        Public DTC13 As String
        Public DTC14 As String
        Public DTC15 As String
        Public DTC16 As String
        Public DTC17 As String
        Public DTC18 As String
        Public DTC19 As String
        Public DTC20 As String
        Public ProgVer As String

        Public OnBlackList_Rack As Boolean
        Public OnBlackList_MPP As Boolean

        Public UnknownDTCFound As Boolean
        Public BadDTCFound As Boolean
        Public AllGoodDTCs As Boolean
        Public SpecialCaseDTCs As Boolean
        Public NoComm As Boolean
        Public NoCommCount As Integer

        Public ValidBuildSheets As String
        Public AcceptableDTCs As String
        Public UnacceptableDTCs As String

        'Questions
        Public WaterIngressionValid As Boolean
        Public WaterIngression As Boolean
        Public HousingBroken As Boolean
        Public HousingBrokenLocation As String
        Public ConnectorBroken As Boolean

        ' Added by Erick Medrano 2024-04-18

        Public CorrosionPinion As Boolean
        Public BentPinion As Boolean
        Public ConnectorPinion As Boolean
        ' End Add

        'Disposition
        Public Bin As String
        Public ScrapHousing As Boolean
        Public ScrapMotor As Boolean


        Public TagColor As eTagColor
        Public CreviceCorrosionPresent As Integer
        Public CreviceCorrosionAcceptable As Integer

        Public BadUnit As Boolean

    End Structure
    Public Shared MyData As sdata
    Public Shared Global_B As Boolean

    Public Enum eProductType
        Undefined = -1
        K2XX_GM__AC_Delco = 0
        K2XX_BBB = 1

        T1XX_GM = 2
    End Enum

    Public Shared ProductType As eProductType = eProductType.Undefined

    Public Shared Sub GetDTCsForK2XX()
        DTC1 = Nothing
        DTC2 = Nothing

        DTC1 = GetDTCList("K2XX", "CSSet1")
        DTC2 = GetDTCList("K2XX", "CSSet2")
    End Sub

    Public Shared Sub GetDTCsForT1XX()
        DTC1 = Nothing
        DTC2 = Nothing

        DTC1 = GetDTCList("T1XX", "CSSet1")
        DTC2 = GetDTCList("T1XX", "CSSet2")
    End Sub

    Public Shared Sub GetDTCsForT1XX_B()
        DTC1 = Nothing

        DTC1 = GetDTCList("T1XX-B", "CSSet1")
    End Sub

    Public Shared Sub GetDTCsForK2XXMPPReman()
        DTC1 = Nothing
        DTC2 = Nothing

        DTC1 = GetDTCList("K2XXMPPRE", "CSSet1")
        DTC2 = GetDTCList("K2XXMPPRE", "CSSet2")
    End Sub

    Public Shared Function GetDTCList(Application As String, Station As String) As Object(,)
        Dim DTCList As Object(,) = Nothing

        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [DTC],[Acceptable] FROM [EPSData].[dbo].[DTCList] WHERE ([Application] = @App) AND ([Station] = @Station) ORDER BY DTC;", {{"@App", Application}, {"@Station", Station}})
        BBBLib.SQL.RunSQLQuery(ds)

        Try
            If ds.Failed Then
                MsgBox("Failed to retrieve Acceptable DTC list from database.")
            Else
                Dim x As Integer = ds.rtDataSet.Tables(0).Rows.Count - 1

                ReDim DTCList(x, 1)
                For r = 0 To x
                    DTCList(r, 0) = ds.rtDataSet.Tables(0).Rows(r)("DTC")
                    DTCList(r, 1) = ds.rtDataSet.Tables(0).Rows(r)("Acceptable")
                Next

            End If
        Catch ex As Exception
            MsgBox("Failed to retrieve Acceptable DTC list from database.")
        End Try

        Return DTCList
    End Function
    Public Shared Function GetDTC2List() As Object(,)

    End Function

    Public Shared Sub ClearMyData()

        With MyData
            .Scan_RFID = 0
            .RFID_Acquired = 0
            .RFID_Tag = ""
            .RFID_Idx = 0

            .ProductType = ""
            .RackBarcode = ""
            .CorePN = ""
            .CoreSN = ""
            .RackBuildDate = CDate("2011-01-01")
            .ValidRackBarcode = False
            .HousingBroken = False
            .HousingBrokenLocation = ""
            .ConnectorBroken = False
            .WaterIngression = False
            .WaterIngressionValid = True

            'Added by Erick Medrano 2024-04-18

            .CorrosionPinion = False
            .BentPinion = False
            .ConnectorPinion = False

            'End Add

            .UnknownDTCFound = False
            .BadDTCFound = False
            .AllGoodDTCs = False
            .SpecialCaseDTCs = False
            .NoComm = False
            .NoCommCount = 0

            .dtInhaleData = Nothing

            .SoftwareVersion2 = ""
            .SoftwareVersion3 = ""
            .EPS_SN = ""
            .ECU_SN = ""
            .VIN = ""
            .ManufacturingTraceability = ""
            .SpecVersion = ""
            .GearSerialNumber = ""
            .ECUHardwarePN = ""
            .GM_PN = ""

            'T1XX Vars
            .ECU_Software_Number = ""
            '.EPS_SN is used from above for T1XX
            .SoftwareBuildDate = ""
            .Cal0 = ""
            .Cal1 = ""
            .Cal2 = ""
            .BootloaderSoftwareID = ""
            .BootloaderSoftwareVer = ""
            .CCAHardwarePN = ""
            'T1XX Vars

            .DTC1 = ""
            .DTC2 = ""
            .DTC3 = ""
            .DTC4 = ""
            .DTC5 = ""
            .DTC6 = ""
            .DTC7 = ""
            .DTC8 = ""
            .DTC9 = ""
            .DTC10 = ""
            .DTC11 = ""
            .DTC12 = ""
            .DTC13 = ""
            .DTC14 = ""
            .DTC15 = ""
            .DTC16 = ""
            .DTC17 = ""
            .DTC18 = ""
            .DTC19 = ""
            .DTC20 = ""
            .ProgVer = ""

            .OnBlackList_Rack = False
            .OnBlackList_MPP = False

            .ValidBuildSheets = ""
            .AcceptableDTCs = ""
            .UnacceptableDTCs = ""

            .Bin = ""
            .ScrapHousing = False
            .ScrapMotor = False

            .TagColor = eTagColor.NotAssigned
            .CreviceCorrosionPresent = -1
            .CreviceCorrosionAcceptable = -1

            .BadUnit = False        'This var is set to trun if the RFID Tag's BIN was original set to a CH bin.

        End With

    End Sub
    Public Shared Function DeleteOutputFile(FileToDelete As String) As Boolean
        DeleteOutputFile = True

        System.IO.File.Delete(FileToDelete)

        If IO.File.Exists(FileToDelete) Then
            MsgBox("error trying to delete File: " + Gvars.InhalePrg.OutputFileLocation)
            DeleteOutputFile = False
        End If
    End Function


    Public Shared Function ReadCSV(ByVal path As String) As System.Data.DataTable

        Dim sr As New System.IO.StreamReader(path)
        Dim fullFileStr As String = sr.ReadToEnd()
        sr.Close()
        sr.Dispose()
        Dim lines As String() = fullFileStr.Split(ControlChars.Lf)
        Dim recs As New DataTable()
        Dim sArr As String() = lines(0).Split(","c)
        For Each s As String In sArr
            recs.Columns.Add(s.Trim.Replace(" ", "_"), GetType(String))
        Next
        Dim row As DataRow
        Dim finalLine As String = ""

        Dim Line As String = lines(1)
        row = recs.NewRow()
        finalLine = Line.Replace(Convert.ToString(ControlChars.Cr), "")
        row.ItemArray = finalLine.Split(","c)
        recs.Rows.Add(row)

        Return recs
    End Function

    Public Shared Function GetCSVFile(ByVal dtOutputFile As DataTable, ByRef dgv As DataGridView) As Boolean
        GetCSVFile = False
        dgv.DataSource = dtOutputFile

        'Hide cells
        HideDGVColumn(dgv, "BarCode")
        HideDGVColumn(dgv, "TYPE")
        HideDGVColumn(dgv, "RFID")
        HideDGVColumn(dgv, "IDX")

        'Hide Blank DTC 2-20 cells
        For i = 2 To 20
            HideDGVColumn(dgv, "DTC " + i.ToString, "0")
        Next

        If (Gvars.Global_B) Then
            For c = 0 To dgv.Columns.Count - 1
                dgv.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(c).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                If Not dgv.Columns(c).Name.StartsWith("DTC") Then
                    HideDGVColumn(dgv, dgv.Columns(c).Name)
                End If
            Next
        Else
            For c = 0 To dgv.Columns.Count - 1
                dgv.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(c).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
            Next
        End If

        With dgv.ColumnHeadersDefaultCellStyle
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With

        With dgv.DefaultCellStyle
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With

        For c = 0 To dgv.Columns.Count - 1
            dgv.Rows(0).Cells(c).Value = FilterData(dgv.Rows(0).Cells(c).Value.ToString)
        Next
        Try

            If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
                'K2xx
                Gvars.MyData.SoftwareVersion1 = dgv.Rows(0).Cells("Software_Version1").Value.ToString
                Gvars.MyData.SoftwareVersion2 = dgv.Rows(0).Cells("Software_Version2").Value.ToString
                Gvars.MyData.SoftwareVersion3 = dgv.Rows(0).Cells("Software_Version3").Value.ToString
                Gvars.MyData.EPS_SN = dgv.Rows(0).Cells("EPS_Serial_Number").Value.ToString
                Gvars.MyData.ECU_SN = dgv.Rows(0).Cells("ECU_Serial_Number").Value.ToString
                Gvars.MyData.VIN = dgv.Rows(0).Cells("VIN").Value.ToString
                Gvars.MyData.ManufacturingTraceability = dgv.Rows(0).Cells("Manufacturing_Traceability").Value.ToString
                Gvars.MyData.SpecVersion = dgv.Rows(0).Cells("Spec_Version").Value.ToString
                Gvars.MyData.GearSerialNumber = dgv.Rows(0).Cells("Gear_Serial_Number").Value.ToString
                Gvars.MyData.ECUHardwarePN = dgv.Rows(0).Cells("ECU_Hardware_Part_Number").Value.ToString
                Gvars.MyData.GM_PN = dgv.Rows(0).Cells("GM_Part_Number").Value.ToString

            ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                'T1xx 
                If Gvars.Global_B Then
                    Gvars.MyData.ECU_Software_Number = dgv.Rows(0).Cells("ECU__Software_Number").Value.ToString
                Else
                    Gvars.MyData.ECU_Software_Number = dgv.Rows(0).Cells("ECU_Software_Number").Value.ToString
                    Gvars.MyData.ECU_SN = dgv.Rows(0).Cells("ECU_Serial_Number").Value.ToString
                    Gvars.MyData.SoftwareBuildDate = dgv.Rows(0).Cells("Software_Build_Date").Value.ToString
                    Gvars.MyData.Cal0 = dgv.Rows(0).Cells("Calibration_0").Value.ToString
                    Gvars.MyData.Cal1 = dgv.Rows(0).Cells("Calibration_1").Value.ToString
                    Gvars.MyData.Cal2 = dgv.Rows(0).Cells("Calibration_2").Value.ToString
                    Gvars.MyData.BootloaderSoftwareID = dgv.Rows(0).Cells("Bootloader_Software_Identifier").Value.ToString
                    Gvars.MyData.BootloaderSoftwareVer = dgv.Rows(0).Cells("Bootloader_Software_Version").Value.ToString
                    Gvars.MyData.CCAHardwarePN = dgv.Rows(0).Cells("CCA_Hardware_Part_Number").Value.ToString
                End If

            End If


            Gvars.MyData.DTC1 = dgv.Rows(0).Cells("DTC_1").Value.ToString
            Gvars.MyData.DTC2 = dgv.Rows(0).Cells("DTC_2").Value.ToString
            Gvars.MyData.DTC3 = dgv.Rows(0).Cells("DTC_3").Value.ToString
            Gvars.MyData.DTC4 = dgv.Rows(0).Cells("DTC_4").Value.ToString
            Gvars.MyData.DTC5 = dgv.Rows(0).Cells("DTC_5").Value.ToString
            Gvars.MyData.DTC6 = dgv.Rows(0).Cells("DTC_6").Value.ToString
            Gvars.MyData.DTC7 = dgv.Rows(0).Cells("DTC_7").Value.ToString
            Gvars.MyData.DTC8 = dgv.Rows(0).Cells("DTC_8").Value.ToString
            Gvars.MyData.DTC9 = dgv.Rows(0).Cells("DTC_9").Value.ToString
            Gvars.MyData.DTC10 = dgv.Rows(0).Cells("DTC_10").Value.ToString
            Gvars.MyData.DTC11 = dgv.Rows(0).Cells("DTC_11").Value.ToString
            Gvars.MyData.DTC12 = dgv.Rows(0).Cells("DTC_12").Value.ToString
            Gvars.MyData.DTC13 = dgv.Rows(0).Cells("DTC_13").Value.ToString
            Gvars.MyData.DTC14 = dgv.Rows(0).Cells("DTC_14").Value.ToString
            Gvars.MyData.DTC15 = dgv.Rows(0).Cells("DTC_15").Value.ToString
            Gvars.MyData.DTC16 = dgv.Rows(0).Cells("DTC_16").Value.ToString
            Gvars.MyData.DTC17 = dgv.Rows(0).Cells("DTC_17").Value.ToString
            Gvars.MyData.DTC18 = dgv.Rows(0).Cells("DTC_18").Value.ToString
            Gvars.MyData.DTC19 = dgv.Rows(0).Cells("DTC_19").Value.ToString
            Gvars.MyData.DTC20 = dgv.Rows(0).Cells("DTC_20").Value.ToString

            Gvars.MyData.ProgVer = dgv.Rows(0).Cells("Prog_Ver").Value.ToString

            Gvars.MyData.NoComm = dgv.Rows(0).Cells("DTC_1").Value.trim.toupper = "ERROR"
            If Gvars.MyData.NoComm Then Gvars.MyData.NoCommCount += 1


            Gvars.MyData.UnknownDTCFound = False
            Gvars.MyData.BadDTCFound = False
            Gvars.MyData.AllGoodDTCs = False
            Gvars.MyData.SpecialCaseDTCs = False

            Gvars.MyData.OnBlackList_MPP = CheckBlackList(Gvars.MyData.ManufacturingTraceability)
            If Gvars.MyData.OnBlackList_MPP Then
                HightlightCell(dgv, "Manufacturing_Traceability", Color.Maroon, Color.Yellow)
            Else
                HightlightCell(dgv, "Manufacturing_Traceability", Color.DarkGreen, Color.White)
            End If

            CheckDTCs(dgv)

            GetCSVFile = True
        Catch ex As Exception
            MsgBox("Error reading data from Datatable." + vbCrLf + ex.ToString)
            BBBLib.Log.LogMsg("Error reading data from Datatable." + vbCrLf + ex.ToString)
        End Try

        dgv.AutoResizeColumns()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Function

    Public Shared Function GetCSVFile2(ByVal dtOutputFile As DataTable, ByRef dgv As DataGridView) As Boolean
        GetCSVFile2 = False
        dgv.DataSource = dtOutputFile

        'Hide cells
        HideDGVColumn(dgv, "BarCode")
        HideDGVColumn(dgv, "TYPE")
        HideDGVColumn(dgv, "RFID")
        HideDGVColumn(dgv, "IDX")

        'Hide Blank DTC 2-20 cells
        For i = 2 To 20
            HideDGVColumn(dgv, "DTC " + i.ToString, "0")
        Next

        For c = 0 To dgv.Columns.Count - 1
            dgv.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns(c).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
        Next

        With dgv.ColumnHeadersDefaultCellStyle
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With

        With dgv.DefaultCellStyle
            .Font = New Font("Arial", 9, FontStyle.Bold)
        End With

        For c = 0 To dgv.Columns.Count - 1
            dgv.Rows(0).Cells(c).Value = FilterData(dgv.Rows(0).Cells(c).Value.ToString)
        Next
        Try

            Gvars.MyData.SoftwareVersion1 = dgv.Rows(0).Cells("Software_Version1").Value.ToString
            Gvars.MyData.SoftwareVersion2 = dgv.Rows(0).Cells("Software_Version2").Value.ToString
            Gvars.MyData.SoftwareVersion3 = dgv.Rows(0).Cells("Software_Version3").Value.ToString
            Gvars.MyData.EPS_SN = dgv.Rows(0).Cells("EPS_Serial_Number").Value.ToString
            Gvars.MyData.ECU_SN = dgv.Rows(0).Cells("ECU_Serial_Number").Value.ToString
            Gvars.MyData.VIN = dgv.Rows(0).Cells("VIN").Value.ToString
            Gvars.MyData.ManufacturingTraceability = dgv.Rows(0).Cells("Manufacturing_Traceability").Value.ToString
            Gvars.MyData.SpecVersion = dgv.Rows(0).Cells("Spec_Version").Value.ToString
            Gvars.MyData.GearSerialNumber = dgv.Rows(0).Cells("Gear_Serial_Number").Value.ToString
            Gvars.MyData.ECUHardwarePN = dgv.Rows(0).Cells("ECU_Hardware_Part_Number").Value.ToString
            Gvars.MyData.GM_PN = dgv.Rows(0).Cells("GM_Part_Number").Value.ToString

            Gvars.MyData.DTC1 = dgv.Rows(0).Cells("DTC_1").Value.ToString
            Gvars.MyData.DTC2 = dgv.Rows(0).Cells("DTC_2").Value.ToString
            Gvars.MyData.DTC3 = dgv.Rows(0).Cells("DTC_3").Value.ToString
            Gvars.MyData.DTC4 = dgv.Rows(0).Cells("DTC_4").Value.ToString
            Gvars.MyData.DTC5 = dgv.Rows(0).Cells("DTC_5").Value.ToString
            Gvars.MyData.DTC6 = dgv.Rows(0).Cells("DTC_6").Value.ToString
            Gvars.MyData.DTC7 = dgv.Rows(0).Cells("DTC_7").Value.ToString
            Gvars.MyData.DTC8 = dgv.Rows(0).Cells("DTC_8").Value.ToString
            Gvars.MyData.DTC9 = dgv.Rows(0).Cells("DTC_9").Value.ToString
            Gvars.MyData.DTC10 = dgv.Rows(0).Cells("DTC_10").Value.ToString
            Gvars.MyData.DTC11 = dgv.Rows(0).Cells("DTC_11").Value.ToString
            Gvars.MyData.DTC12 = dgv.Rows(0).Cells("DTC_12").Value.ToString
            Gvars.MyData.DTC13 = dgv.Rows(0).Cells("DTC_13").Value.ToString
            Gvars.MyData.DTC14 = dgv.Rows(0).Cells("DTC_14").Value.ToString
            Gvars.MyData.DTC15 = dgv.Rows(0).Cells("DTC_15").Value.ToString
            Gvars.MyData.DTC16 = dgv.Rows(0).Cells("DTC_16").Value.ToString
            Gvars.MyData.DTC17 = dgv.Rows(0).Cells("DTC_17").Value.ToString
            Gvars.MyData.DTC18 = dgv.Rows(0).Cells("DTC_18").Value.ToString
            Gvars.MyData.DTC19 = dgv.Rows(0).Cells("DTC_19").Value.ToString
            Gvars.MyData.DTC20 = dgv.Rows(0).Cells("DTC_20").Value.ToString

            Gvars.MyData.ProgVer = dgv.Rows(0).Cells("Prog_Ver").Value.ToString

            Gvars.MyData.NoComm = dgv.Rows(0).Cells("DTC_1").Value.trim.toupper = "ERROR"
            If Gvars.MyData.NoComm Then Gvars.MyData.NoCommCount += 1


            Gvars.MyData.UnknownDTCFound = False
            Gvars.MyData.BadDTCFound = False
            Gvars.MyData.AllGoodDTCs = False
            Gvars.MyData.SpecialCaseDTCs = False

            Gvars.MyData.OnBlackList_MPP = CheckBlackList(Gvars.MyData.ManufacturingTraceability)
            If Gvars.MyData.OnBlackList_MPP Then
                HightlightCell(dgv, "Manufacturing_Traceability", Color.Maroon, Color.Yellow)
            Else
                HightlightCell(dgv, "Manufacturing_Traceability", Color.DarkGreen, Color.White)
            End If

            CheckDTCs(dgv)

            GetCSVFile2 = True
        Catch ex As Exception
            MsgBox("Error reading data from Datatable." + vbCrLf + ex.ToString)
            BBBLib.Log.LogMsg("Error reading data from Datatable." + vbCrLf + ex.ToString)
        End Try

        dgv.AutoResizeColumns()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Function

    Public Shared Sub HideDGVColumn(ByRef dgv As DataGridView, ColumnName As String, Optional IfValueIs As String = Nothing)
        ColumnName = ColumnName.Trim.Replace(" ", "_")

        If IsNothing(IfValueIs) Then
            dgv.Columns(ColumnName).Visible = False
        ElseIf dgv.Rows(0).Cells(ColumnName).Value.ToString = IfValueIs Then
            dgv.Columns(ColumnName).Visible = False
        End If
    End Sub

    Private Shared Function FilterData(Input As String) As String
        FilterData = ""
        For c = 0 To Input.Length - 1
            If Asc(Input.Substring(c, 1)) >= 32 And Asc(Input.Substring(c, 1)) <= 255 Then
                FilterData += Input.Substring(c, 1)
            End If
        Next
    End Function

    Public Shared Function CheckBlackList(SN As String) As Boolean
        CheckBlackList = True
        Try
            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_is_on_the_Blacklist @SN", {{"@SN", SN}})
            BBBLib.SQL.RunSQLQuery(ds)

            If ds.Failed Then
                MsgBox("Error checking blacklist." + vbCrLf + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("(A) Error checking blacklist: " + SN + " Ex: " + ds.ExceptionMsg)
            Else
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                CheckBlackList = CBool(dt.Rows(0)("Results"))
            End If
        Catch ex As Exception
            MsgBox("Error checking blacklist." + vbCrLf + ex.ToString)
            BBBLib.Log.LogMsg("(B) Error checking blacklist: " + SN + " Ex: " + ex.ToString)
        End Try

    End Function

    Public Shared Sub HightlightCell(ByRef dgv As DataGridView, Heading As String, aColorB As Color, aColorF As Color)
        For c = 0 To dgv.ColumnCount - 1
            If dgv.Columns(c).Name.ToUpper Like (Heading.ToUpper) Then
                dgv.Rows(0).Cells(c).Style.BackColor = aColorB
                dgv.Rows(0).Cells(c).Style.ForeColor = aColorF
            End If
        Next
    End Sub

    Private Shared Sub CheckDTCs(ByRef dgv As DataGridView)
        Gvars.MyData.AcceptableDTCs = ""
        Gvars.MyData.UnacceptableDTCs = ""

        For i = 1 To 20
            Dim DTCValue As String = dgv.Rows(0).Cells("DTC_" + i.ToString).Value.ToString.Trim
            If DTCValue <> "0" Then
                Dim DTCState1 As Integer = isDTCValueOK(DTC1, DTCValue)
                If DTCState1 = -1 Then
                    Gvars.MyData.UnknownDTCFound = True
                    Gvars.MyData.BadDTCFound = True
                End If
                If DTCState1 = 0 Then Gvars.MyData.BadDTCFound = True

                Dim DTCState2 As Integer = isDTCValueOK(DTC2, DTCValue)
                If DTCState2 = 0 Then Gvars.MyData.SpecialCaseDTCs = True

                If DTCState1 = 1 Then
                    If Gvars.MyData.AcceptableDTCs.Length > 0 Then Gvars.MyData.AcceptableDTCs += ","
                    Gvars.MyData.AcceptableDTCs += DTCValue
                    HightlightCell(dgv, "DTC_" + i.ToString, Color.DarkGreen, Color.White)

                ElseIf DTCState1 <= 0 Then
                    If Gvars.MyData.UnacceptableDTCs.Length > 0 Then Gvars.MyData.UnacceptableDTCs += ","
                    Gvars.MyData.UnacceptableDTCs += DTCValue
                    HightlightCell(dgv, "DTC_" + i.ToString, Color.Maroon, Color.Yellow)

                End If
            End If
        Next
        Gvars.MyData.AllGoodDTCs = (Not Gvars.MyData.UnknownDTCFound) And (Not Gvars.MyData.BadDTCFound) And (Not Gvars.MyData.SpecialCaseDTCs)
    End Sub
    Private Shared Function isDTCValueOK(Array As Object(,), DTCValue As String) As Integer
        'Return 1  DTC is Is Acceptable
        '       0  DTC is Not Acceptable
        '       -1 DTC is not found
        isDTCValueOK = -1
        For i = 0 To Array.GetUpperBound(0)
            If Array(i, 0) = DTCValue Then
                isDTCValueOK = IIf(Array(i, 1) = True, 1, 0)
                Exit For
            End If
        Next
    End Function

    Public Shared Function IsRFIDTagMarried(RFIDTag As String) As Boolean
        IsRFIDTagMarried = False
        Dim ds As BBBLib.SQL.dsDataSet

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [idx] FROM [EPSData].[dbo].[K2XX_CoreSort] WHERE RFIDTag=@RFIDTag and [Status]=1", {{"@RFIDTag", RFIDTag}})

        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [idx] FROM [EPSData].[dbo].[T1XX_CoreSort] WHERE RFIDTag=@RFIDTag and [Status]=1", {{"@RFIDTag", RFIDTag}})

        End If

        BBBLib.SQL.RunSQLQuery(ds)
        If Not ds.Failed Then
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            IsRFIDTagMarried = (dt.Rows.Count <> 0)
        End If
    End Function

End Class
