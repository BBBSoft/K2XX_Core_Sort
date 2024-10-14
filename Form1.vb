Imports System.ComponentModel
Imports System.Net.Security
Imports System.Windows.Forms.VisualStyles
Imports BBB_Printing.K2xxCoreSortLabel
Imports BBBLib
Imports BBBLib_Rey

Public Class Form1
    'Select GM/ACD or BBB
    '
    'Read BarCode
    'Inhale Data and DTCs
    'Store SN from Barcode
    'Store SN from inhale
    'Store Break Data
    'Store DTCs
    'Ask Questions
    '-Are connectors broken
    '-Is the housing broken

    'Determin Disposition.
    '       Good   Bad  Product
    'If Keeping Housing & Motor together then Scan one RFID for housing (ACD)
    'If Keeping Housing & Motor apart then Scan one RFID for housing and one RFID for the Motor.
    'If Keeping Housing only then Scan one RFID for housing and Scrap Motor (GM)
    'If Keeping Motor only then Scan one RFID for Motor and Scrap housing (ACD)
    '
    Private Enum eLanguage
        English = 0
        Spanish = 1
    End Enum
    ' Added by Enrique Juarez
    Private ApplyChanges As Integer = 1
    Private iSelection As Integer = -1
    ' End Added
    Private Language As eLanguage = eLanguage.Spanish
    Private Phrases As String(,) = {{"Select Product", "Seleccione el producto"},                                                                                                                                                                                                                                                                   ' 0
                                    {"Clear Product", "Limpie el producto"},                                                                                                                                                                                                                                                                        ' 1
                                    {"Scan Rack Barcode", "Escanee la etiqueta de la carcasa"},                                                                                                                                                                                                                                                     ' 2
                                    {"Run InHale program", "Corra el programa de InHale"},                                                                                                                                                                                                                                                          ' 3
                                    {"Run Inhale", "Corra el InHale"},                                                                                                                                                                                                                                                                              ' 4
                                    {"Clear Data", "Limpiar datos"},                                                                                                                                                                                                                                                                                ' 5
                                    {"Answer the questions.", "Responder las preguntas"},                                                                                                                                                                                                                                                           ' 6
                                    {"Is the housing broken?", "La carcasa esta quebrada?"},                                                                                                                                                                                                                                                        ' 7
                                    {"Are connectors broken?", "Los conectores estan quebrados?"},                                                                                                                                                                                                                                                  ' 8
                                    {"Is there water ingression?", "Tiene agua en el interior?"},                                                                                                                                                                                                                                                   ' 9
                                    {"Scan an RFID tag.", "Escanee el RFID"},                                                                                                                                                                                                                                                                       ' 10
                                    {"This RFID tag (<RFIDTag>) should have been attached to the previously processed unit.  Do you want to continue using this RFID tag on this unit?", "Este  RFID (<RFIDTag>) debería haberse adjuntado a la unidad procesada anteriormente. ¿Desea continuar utilizando esta etiqueta RFID en esta unidad?"},   ' 11
                                    {"This RFID tag (<RFIDTag>) is already married to a unit.  Do you want to continue using this RFID tag on this unit?", "Este RFID (<RFIDTag>) ya está casada con una unidad. ¿Desea continuar utilizando esta etiqueta RFID en esta unidad?"},                                                                  ' 12
                                    {"Please scan a different RFID tag.", "Por favor escane un diferente RFID"},                                                                                                                                                                                                                                    ' 13
                                    {"Place RFID tag on Rack.", "Coloque el RFID en la carcasa"},                                                                                                                                                                                                                                                   ' 14
                                    {"Place RFID tag on Rack.", "Coloque el RFID en la carcasa"},                                                                                                                                                                                                                                                   ' 15
                                    {"BIN # <Bin#>", "BIN <Bin#>"},                                                                                                                                                                                                                                                                                 ' 16
                                    {"Place Rack in Hold Bin", "Coloque la carcasa en el gaylor Hold"},                                                                                                                                                                                                                                             ' 17
                                    {"Remove MPP from Rack, Scrap Rack, and place RFID tag on MPP.", "Remover el motor de la carcasa, hacer scrap la carcasa, colocar RFID al motor"},                                                                                                                                                              ' 18
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
                                    {"Manila Tag", "Etiqueta Manila"},                                  '37
                                    {"Orange Tag", "Etiqueta Naranja"},                                 '38
                                    {"Red Tag", "Etiqueta Roja"},                                       '39
                                    {"Yellow Tag", "Etiqueta Amarillo"},                                '40
                                    {"Blue Tag", "Etiqueta Azul"},                                      '41
                                    {"White Tag", "Etiqueta Blanca"},                                   '42
                                    {"Black Tag", "Etiqueta Negra"},                                    '43
                                    {"Pinion with Corrosion??", "Piñón con Corrosion?"},                '44
                                    {"Bent Pinion?", "Piñón Pandeado?"},                                '45
                                    {"Pinion Sensor Conn Broken?", "Conector del piñón Quebrado?"}}     '46
    Private NoComCountMin As Integer = 3

    Private HideDebug As Boolean = True
    Private LastRFIDScanned As String = ""

    Private Reset_BackColor As Color = Color.WhiteSmoke
    Private HighLightBackColor As Color = Color.LightSalmon

    Private ConString As String = ""
    Private ConString_EPAS As String = ""
    Private ConString_EPAS_AM As String = ""
    Private ConString_BBB_EPS As String = ""
    Private ConString_EPSData As String = ""
    Private ConString_EHPS As String = ""
    Private ConString_EPAS_Epsilon As String = ""

    Private GMPN As New List(Of String)
    Private ACDPN As New List(Of String)
    Private BBBPN As New List(Of String)

    ' Added by Erick Medrano 2024-0110

    Private Buildsheet As String

    ' End Added by Erick Medrano 

    Private ButtonClicked As String = ""

    ' Added by Erick Medrano 2024-0110

    Dim NoTag As Boolean = False

    Dim S1 As frmSelectBushing = New frmSelectBushing()

    ' End Added by Erick medrano 

    ''ToDo: Replace these with Database versions
    'Private DTC1 As Object(,) = {{"1FB", False},
    '                            {"1FE", False},
    '                            {"1FD", False},
    '                            {"C", False},
    '                            {"E", False},
    '                            {"65", False},
    '                            {"60", False},
    '                            {"66", False},
    '                            {"67", False},
    '                            {"1FA", False},
    '                            {"68", False},
    '                            {"69", False},
    '                            {"6A", False},
    '                            {"61", False},
    '                            {"11", False},
    '                            {"18", False},
    '                            {"19", False},
    '                            {"1D", False},
    '                            {"1E", False},
    '                            {"13", False},
    '                            {"1A", False},
    '                            {"1C", False},
    '                            {"1B", False},
    '                            {"17", False},
    '                            {"21", False},
    '                            {"4", False},
    '                            {"10", False},
    '                            {"22", False},
    '                            {"23", False},
    '                            {"30", False},
    '                            {"31", False},
    '                            {"2A", False},
    '                            {"2B", False},
    '                            {"B", False},
    '                            {"F", False},
    '                            {"40", False},
    '                            {"41", False},
    '                            {"42", False},
    '                            {"45", False},
    '                            {"48", False},
    '                            {"46", False},
    '                            {"2C", False},
    '                            {"32", False},
    '                            {"4D", False},
    '                            {"36", False},
    '                            {"33", False},
    '                            {"35", False},
    '                            {"1", False},
    '                            {"3", False},
    '                            {"25", False},
    '                            {"C5", False},
    '                            {"C6", False},
    '                            {"C8", False},
    '                            {"24", False},
    '                            {"28", False},
    '                            {"20", False},
    '                            {"70", False},
    '                            {"4F", False},
    '                            {"4E", False},
    '                            {"52", False},
    '                            {"72", False},
    '                            {"1F2", False},
    '                            {"1F1", False},
    '                            {"90", False},
    '                            {"95", False},
    '                            {"BF", True},           'Changed BF from False to True(Acceptable)
    '                            {"2", False},
    '                            {"12", False},
    '                            {"E0", False},
    '                            {"168", False},
    '                            {"94", True},
    '                            {"141", True},
    '                            {"161", True},
    '                            {"1A1", True},
    '                            {"199", True},
    '                            {"179", True},
    '                            {"189", True},
    '                            {"171", True},
    '                            {"151", True},
    '                            {"1B1", True},
    '                            {"1A9", True},
    '                            {"120", True},
    '                            {"160", True},
    '                            {"178", True},
    '                            {"1A8", True},
    '                            {"1B0", True},
    '                            {"1A0", True},
    '                            {"198", True},
    '                            {"170", True},
    '                            {"180", True},
    '                            {"121", True},
    '                            {"158", True},
    '                            {"159", True},
    '                            {"131", True},
    '                            {"139", True},
    '                            {"129", True},
    '                            {"149", True},
    '                            {"148", True},
    '                            {"191", True},
    '                            {"190", True},
    '                            {"1D1", True},
    '                            {"1D0", True},
    '                            {"138", True}}
    'Private DTC2 As Object(,) = {{"65", False},
    '                             {"60", False},
    '                             {"66", False},
    '                             {"67", False},
    '                             {"68", False},
    '                             {"69", False},
    '                             {"6A", False},
    '                             {"61", False}}
    'Private DTC3 As Object(,) = {{"1FA", False},
    '                             {"1FB", False},
    '                             {"1FE", False},
    '                             {"1FD", False},
    '                             {"C", False},
    '                             {"E", False}}

    'IAM    Broken Connectors get Yellow tag.
    'IAM    Scrap get Red Tag

    '                                     BIN ,    BBB Core Number,  GM/ACD # , BBB MTR #, "C\S"
    'Private BinLookup As String(,) = {{"Bin # 3", "3825717056GNC", "19417062", "38029554C", "N", "38257170AA", "203-0154ECH"},
    '                                  {"Bin # 4", "3825717059GNC", "19417064", "38029554C", "N", "38257170AB", "203-0150ECH"},
    '                                  {"Bin # 5", "3825717064GNC", "19417066", "38029554C", "N", "38257170AC", "203-0153ECH"},
    '                                  {"Bin # 5", "3825717064GNC", "19417836", "38029554C", "N", "38257170AC", "203-0166ECH"},
    '                                  {"Bin # 6", "3825717056GCC", "19417063", "38239062C", "Y", "38257170AA", "203-0163ECH"},
    '                                  {"Bin # 7", "3825717059GCC", "19417065", "38239062C", "Y", "38257170AB", "203-0164ECH"},
    '                                  {"Bin # 8", "3825717064GCC", "19417067", "38239062C", "Y", "38257170AC", "203-0165ECH"},
    '                                  {"Bin # 8", "3825717064GCC", "19417838", "38239062C", "Y", "38257170AC", "203-0167ECH"},
    '                                  {"Bin # 9", "3825717056ANC", "19390184", "38029554C", "N", "38257170BA", "203-0154EC"},
    '                                  {"Bin # 10", "3825717059ANC", "19390186", "38029554C", "N", "38257170BB", "203-0150EC"},
    '                                  {"Bin # 11", "3825717064ANC", "19390188", "38029554C", "N", "38257170BC", "203-0153EC"},
    '                                  {"Bin # 11", "3825717064ANC", "19391403", "38029554C", "N", "38257170BC", "203-0166EC"},
    '                                  {"Bin # 12", "3825717056ACC", "19390185", "38239062C", "Y", "38257170CA", "203-0163EC"},
    '                                  {"Bin # 13", "3825717059ACC", "19390187", "38239062C", "Y", "38257170CB", "203-0164EC"},
    '                                  {"Bin # 14", "3825717064ACC", "19390189", "38239062C", "Y", "38257170CC", "203-0165EC"},
    '                                  {"Bin # 14", "3825717064ACC", "19391404", "38239062C", "Y", "38257170CC", "203-0167EC"},
    '                                  {"Bin # 15", "Hold", "Hold", "Hold", "H", "", ""},
    '                                  {"Bin # 1", "38029554C", "38029554C", "W/O CS", "-", "", "73032"},
    '                                  {"Bin # 2", "38239062C", "38239062C", "W CS", "-", "", "73033"}}

    Private BinLookup As String(,)
    'Modified by MLaClair 11-19-2019
    '
    ' Modified by Enrique Juarez change suffix in 203-0150, 203-0153, 203-0154 and 203-0166 From ECH to EC 
    ' 
    '                                     BIN ,    BBB Core Number,  GM/ACD # , BBB MTR #, "C\S"
    Private K2XXBinLookup As String(,) = {{"Bin # 3", "3825717056GNC", "19417062", "38029554C", "N", "38257170AA", "203-0154EC"},
                                      {"Bin # 4", "3825717059GNC", "19417064", "38029554C", "N", "38257170AB", "203-0150EC"},
                                      {"Bin # 5", "3825717064GNC", "19417066", "38029554C", "N", "38257170AC", "203-0153EC"},
                                      {"Bin # 16", "3825717064GND", "19417836", "38029554C", "N", "38257170AD", "203-0166EC"},  '<---Modifyied by MLaclair 11-19-2019
                                      {"Bin # 6", "3825717056GCC", "19417063", "38239062C", "Y", "38257170AA", "203-0163ECH"},
                                      {"Bin # 7", "3825717059GCC", "19417065", "38239062C", "Y", "38257170AB", "203-0164ECH"},
                                      {"Bin # 8", "3825717064GCC", "19417067", "38239062C", "Y", "38257170AC", "203-0165ECH"},
                                      {"Bin # 16", "3825717064GCD", "19417838", "38239062C", "Y", "38257170AD", "203-0167ECH"},  '<---Modifyied by MLaclair 11-19-2019
                                      {"Bin # 9", "3825717056ANC", "19390184", "38029554C", "N", "38257170BA", "203-0154EC"},
                                      {"Bin # 10", "3825717059ANC", "19390186", "38029554C", "N", "38257170BB", "203-0150EC"},
                                      {"Bin # 11", "3825717064ANC", "19390188", "38029554C", "N", "38257170BC", "203-0153EC"},
                                      {"Bin # 17", "3825717064AND", "19391403", "38029554C", "N", "38257170BD", "203-0166EC"},  '<---Modifyied by MLaclair 11-19-2019
                                      {"Bin # 12", "3825717056ACC", "19390185", "38239062C", "Y", "38257170CA", "203-0163EC"},
                                      {"Bin # 13", "3825717059ACC", "19390187", "38239062C", "Y", "38257170CB", "203-0164EC"},
                                      {"Bin # 14", "3825717064ACC", "19390189", "38239062C", "Y", "38257170CC", "203-0165EC"},
                                      {"Bin # 18", "3825717064ACD", "19391404", "38239062C", "Y", "38257170CD", "203-0167EC"},  '<---Modifyied by MLaclair 11-19-2019
                                      {"Bin # 15", "Hold", "Hold", "Hold", "H", "", ""},
                                      {"Bin # 1", "38029554C", "38029554C", "W/O CS", "-", "", "73032"},
                                      {"Bin # 2", "38239062C", "38239062C", "W CS", "-", "", "73033"}}

    '
    'Private T1XXBinLookup As String(,) = {{"Bin # 1", "", "38291940", "38284660C", "Y", "34215303AA", ""},
    '                                      {"Bin # 1", "", "38291946", "38284660C", "Y", "34215303AA", ""},
    '                                      {"Bin # 2", "", "38291941", "38284660C", "Y", "34215303AB", ""},
    '                                      {"Bin # 2", "", "38291947", "38284660C", "Y", "34215303AB", ""},
    '                                      {"Bin # 3", "", "38291942", "38284660C", "Y", "34215303AC", ""},
    '                                      {"Bin # 3", "", "38291948", "38284660C", "Y", "34215303AC", ""},
    '                                      {"Bin # 4", "", "38291943", "38284660C", "Y", "34215303AD", ""},
    '                                      {"Bin # 4", "", "38291949", "38284660C", "Y", "34215303AD", ""},
    '                                      {"Bin # 5", "", "38291944", "38284660C", "Y", "34215303AE", ""},
    '                                      {"Bin # 5", "", "38291950", "38284660C", "Y", "34215303AE", ""},
    '                                      {"Bin # 6", "", "Hold", "Hold", "H", "", ""},
    '                                      {"Bin # 7", "", "38284660C", "38284660C", "-", "38284660C", ""}}

    'Private T1XXBinLookup As String(,) = {{"Bin # 1", "", "38291940", "38284660C", "Y", "38294913AACORE", ""},
    '                                      {"Bin # 1", "", "38291946", "38284660C", "Y", "38294913AACORE", ""},
    '                                      {"Bin # 2", "", "38291941", "38284660C", "Y", "38294913ABCORE", ""},
    '                                      {"Bin # 2", "", "38291947", "38284660C", "Y", "38294913ABCORE", ""},
    '                                      {"Bin # 3", "", "38291942", "38284660C", "Y", "38294913ACCORE", ""},
    '                                      {"Bin # 3", "", "38291948", "38284660C", "Y", "38294913ACCORE", ""},
    '                                      {"Bin # 4", "", "38291943", "38284660C", "Y", "38294913ADCORE", ""},
    '                                      {"Bin # 4", "", "38291949", "38284660C", "Y", "38294913ADCORE", ""},
    '                                      {"Bin # 5", "", "38291944", "38284660C", "Y", "38294913AECORE", ""},
    '                                      {"Bin # 5", "", "38291950", "38284660C", "Y", "38294913AECORE", ""},
    '                                      {"Bin # 6", "", "Hold", "Hold", "H", "", ""},
    '                                      {"Bin # 7", "", "38284660C", "38284660C", "-", "38284660C", ""}}

    Private T1XXBinLookup As String(,) = {{"Bin # 1", "", "38291940", "38284660C", "Y", "38294913AACORE", ""},
                                          {"Bin # 1", "", "38291946", "38284660C", "Y", "38294913AACORE", ""},
                                          {"Bin # 2", "", "38291941", "38284660C", "Y", "38294913ABCORE", ""},
                                          {"Bin # 2", "", "38291947", "38284660C", "Y", "38294913ABCORE", ""},
                                          {"Bin # 3", "", "38291942", "38284660C", "Y", "38294913ACCORE", ""},
                                          {"Bin # 3", "", "38291948", "38284660C", "Y", "38294913ACCORE", ""},
                                          {"Bin # 4", "", "38291943", "38284660C", "Y", "38294913ADCORE", ""},
                                          {"Bin # 4", "", "85126460", "38284660C", "Y", "38294913ADCORE", ""},
                                          {"Bin # 5", "", "38291944", "38284660C", "Y", "38294913AECORE", ""},
                                          {"Bin # 5", "", "38291950", "38284660C", "Y", "38294913AECORE", ""},
                                          {"Bin # 6", "", "Hold", "Hold", "H", "", ""},
                                          {"Bin # 7", "", "38284660C", "38284660C", "-", "38284660C", ""}}
    Private dtOutputFile As DataTable

    Public Enum eMachineState
        Startup = 0
        SelectProduct = 10
        EnterBoL = 15
        ClearData = 20
        ScanRackBarcode = 30
        LookupPNs = 40
        RunInhalePrg = 50
        InhaleCompletedOK = 60
        TimeOutWaiting = 70
        FileFound = 80
        ProcessFile = 90
        AskQuestions = 100
        GetRFIDIdx = 110
        DisplayButton = 120
        GetDisposition = 130
        SaveData = 140
        SaveDataScrap = 150
        ClickClearToContinue = 160
    End Enum
    Private MachineState As eMachineState = eMachineState.Startup

    'Public Enum eProductType
    '    Undefined = -1
    '    K2XX_GM__AC_Delco = 0
    '    K2XX_BBB = 1
    '    T1XX_GM = 2
    'End Enum

    'Public Structure sdata
    '    Public HoldUnit As Boolean
    '    Public Contact As String
    '    Public EXT As String

    '    Public Scan_RFID As Boolean
    '    Public RFID_Acquired As Boolean
    '    Public RFID_Tag As String
    '    Public RFID_Idx As Integer

    '    Public BoL As String
    '    Public ProductType As String
    '    Public RackBarcode As String
    '    Public CorePN As String
    '    Public CoreSN As String
    '    Public RackBuildDate As Date
    '    Public ValidRackBarcode As Boolean

    '    'Inhale Data
    '    Public dtInhaleData As DataTable
    '    Public SoftwareVersion1 As String
    '    Public SoftwareVersion2 As String
    '    Public SoftwareVersion3 As String
    '    Public EPS_SN As String
    '    Public ECU_SN As String
    '    Public VIN As String
    '    Public ManufacturingTraceability As String
    '    Public SpecVersion As String
    '    Public GearSerialNumber As String
    '    Public ECUHardwarePN As String
    '    Public GM_PN As String
    '    Public DTC1 As String
    '    Public DTC2 As String
    '    Public DTC3 As String
    '    Public DTC4 As String
    '    Public DTC5 As String
    '    Public DTC6 As String
    '    Public DTC7 As String
    '    Public DTC8 As String
    '    Public DTC9 As String
    '    Public DTC10 As String
    '    Public DTC11 As String
    '    Public DTC12 As String
    '    Public DTC13 As String
    '    Public DTC14 As String
    '    Public DTC15 As String
    '    Public DTC16 As String
    '    Public DTC17 As String
    '    Public DTC18 As String
    '    Public DTC19 As String
    '    Public DTC20 As String
    '    Public ProgVer As String

    '    Public OnBlackList_Rack As Boolean
    '    Public OnBlackList_MPP As Boolean

    '    Public UnknownDTCFound As Boolean
    '    Public BadDTCFound As Boolean
    '    Public AllGoodDTCs As Boolean
    '    Public SpecialCaseDTCs As Boolean
    '    Public NoComm As Boolean
    '    Public NoCommCount As Integer

    '    Public ValidBuildSheets As String
    '    Public AcceptableDTCs As String
    '    Public UnacceptableDTCs As String

    '    'Questions
    '    Public WaterIngressionValid As Boolean
    '    Public WaterIngression As Boolean
    '    Public HousingBroken As Boolean
    '    Public HousingBrokenLocation As String
    '    Public ConnectorBroken As Boolean

    '    'Disposition
    '    Public Bin As String
    '    Public ScrapHousing As Boolean
    '    Public ScrapMotor As Boolean


    'End Structure
    'Private MyData As sdata

    'Public Structure sShellAndWait
    '    Public Timeout_mSec As Integer
    '    Public AppPath As String
    '    Public Arguments As String
    '    Public TimedOut As Boolean
    '    Public ReturnValue As Integer
    '    Public Completed As Boolean
    '    Public OutputFileLocation As String
    '    Public ErrorMsg As String
    '    Public AnError As Boolean
    'End Structure
    'Public InhalePrg As sShellAndWait

    Private frmReprint As frmReprintLabelsFromRFID

    Private Sub SetLanguage()
        lblSelectProduct.Text = Phrases(0, Language)
        btnClearProduct.Text = Phrases(1, Language)
        btnRunInhale.Text = Phrases(4, Language)
        btnClearData.Text = Phrases(5, Language)
        btnClickWhenDone.Text = Phrases(23, Language)
        lblQ1.Text = Phrases(7, Language)
        lblQ2.Text = Phrases(8, Language)
        lblQ3.Text = Phrases(9, Language)
        lblQ4.Text = Phrases(44, Language)
        lblQ5.Text = Phrases(45, Language)
        lblQ6.Text = Phrases(46, Language)
        btnChangeBoL.Text = Phrases(30, Language)
        Label1.Text = Phrases(32, Language)
        btnReclassify.Text = Phrases(35, Language)
    End Sub
    Private Sub SetupPrintLabel()

        'PrinterInfo = New sK2xxLabelInfo("PaperPort Image Printer", New Point(0, 0))

        PrinterInfo = New sK2xxLabelInfo(True)
        'If Ver = 1 Then
        '    PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 10), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 30), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 50), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%RFID% - %RFIDidx%", New Point(10, 80), "Arial", 8, FontStyle.Bold))
        'ElseIf Ver = 2 Then
        '    PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 10), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 30), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 60), "Arial", 8, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%RFID% - %RFIDidx%", New Point(10, 80), "Arial", 8, FontStyle.Bold))
        'End If

        ' Added by Enrique Juarez
        'If ApplyChanges = 0 Then
        '    ' Commented by Enrique Juarez
        '    PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 10), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 30), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 50), "Arial", 14, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 71), "Arial", 6, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%RFID% - %RFIDidx%", New Point(10, 80), "Arial", 8, FontStyle.Bold))
        'Else
        ' Added by Enrique Juarez

        'Added by Erick Medrano 2024-02-09

        'If NoTag And Gvars.MyData.DTC1 = "0" Then
        '    PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 5), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("(Remove Motor)", New Point(10, 47), "Arial", 8, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 25), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 45), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 65), "Arial", 8, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%RFID%-%RFIDidx%-" + GetDateFormat(), New Point(10, 75), "Arial", 9, FontStyle.Bold))

        'Else
        '    PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 5), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 25), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 45), "Arial", 13, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 65), "Arial", 8, FontStyle.Bold))
        '    PrinterInfo.Text.Add(New sPrinterText("%RFID%-%RFIDidx%-" + GetDateFormat(), New Point(10, 75), "Arial", 9, FontStyle.Bold))

        'End If

        'End Added by Erick Medrano 2024-02-09

        PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 5), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 25), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 45), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 65), "Arial", 8, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%RFID%-%RFIDidx%-" + GetDateFormat(), New Point(10, 75), "Arial", 9, FontStyle.Bold))

        'End If
        ' End Add
    End Sub
    Private Function GetDateFormat() As String
        GetDateFormat = Now.ToString("yyMMdd")
    End Function
    Private Sub SetupPrintLabel_HoldUnit()

        PrinterInfo = New sK2xxLabelInfo(True)
        PrinterInfo.Text.Add(New sPrinterText("%Bin%", New Point(10, 5), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%BBBCorePN%", New Point(10, 25), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%GMCorePN%", New Point(10, 45), "Arial", 13, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%PartInfo%", New Point(10, 65), "Arial", 8, FontStyle.Bold))
        'PrinterInfo.Text.Add(New sPrinterText("%RFID% - %RFIDidx%", New Point(10, 75), "Arial", 10, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText("%RFID%-%RFIDidx%-" + GetDateFormat(), New Point(10, 75), "Arial", 9, FontStyle.Bold))

        If Gvars.MyData.RFID_Tag = "Scrap" Then
            PrinterInfo.RFID = "No RFID"
        Else
            PrinterInfo.RFID = Gvars.MyData.RFID_Tag
        End If
        PrinterInfo.RFIDidx = Gvars.MyData.RFID_Idx
        PrinterInfo.Bin = "HOLD UNIT FOR"
        PrinterInfo.BBBCorePN = Gvars.MyData.Contact.Trim
        PrinterInfo.GMCorePN = "Call x" + Gvars.MyData.EXT.Trim
        PrinterInfo.PartInfo = ""

        PrinterInfo.setVars()

        Try
            setupPrtdoc()
            PrtDoc.Print()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetupPrintLabel_BOL()

        PrinterInfo = New sK2xxLabelInfo(True)
        PrinterInfo.Text.Add(New sPrinterText("BOL: ", New Point(10, 30), "Arial", 12, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText(lblBillOfLading.Text, New Point(10, 45), "Arial", 10, FontStyle.Bold))
        PrinterInfo.Text.Add(New sPrinterText(Gvars.MyData.RFID_Tag + "-" + Gvars.MyData.RFID_Idx.ToString() + "-" + GetDateFormat(), New Point(10, 75), "Arial", 9, FontStyle.Bold))


    End Sub
    Private Sub SetupPrintLabel_Scrap()

        'PrinterInfo = New sK2xxLabelInfo("PaperPort Image Printer", New Point(0, 0))

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
            PrinterInfo = New sK2xxLabelInfo(True)
            PrinterInfo.Text.Add(New sPrinterText("SCRAP", New Point(25, 30), "Arial", 28, FontStyle.Bold))
            PrinterInfo.Text.Add(New sPrinterText(GetDateFormat(), New Point(10, 75), "Arial", 10, FontStyle.Bold))
        Else
            PrinterInfo = New sK2xxLabelInfo(True)
            PrinterInfo.Text.Add(New sPrinterText("SCRAP", New Point(25, 30), "Arial", 28, FontStyle.Bold))
            PrinterInfo.Text.Add(New sPrinterText(GetDateFormat(), New Point(10, 75), "Arial", 10, FontStyle.Bold))
            PrinterInfo.Text.Add(New sPrinterText(BBBPN(0), New Point(100, 75), "Arial", 10, FontStyle.Bold))
        End If

        'PrinterInfo = New sK2xxLabelInfo(True)
        'PrinterInfo.Text.Add(New sPrinterText("SCRAP", New Point(25, 30), "Arial", 28, FontStyle.Bold))
        'PrinterInfo.Text.Add(New sPrinterText(GetDateFormat(), New Point(10, 75), "Arial", 10, FontStyle.Bold))
        'PrinterInfo.Text.Add(New sPrinterText(BBBPN(0), New Point(100, 75), "Arial", 10, FontStyle.Bold))

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If BBBLib.Func.theComputerName.ToUpper.Trim = "W10ENG" Then
            LanguageToolStripMenuItem_Click(Me, New EventArgs)
            HideDebug = False
        End If

        'Added by Enrique Juarez
        If BBBLib.Func.theComputerName.ToUpper.Trim = "LAP-LJUAREZ" Then
            LanguageToolStripMenuItem_Click(Me, New EventArgs)
            HideDebug = False
        End If
        'End Added

        SetupPrintLabel()

        PrinterInfo.Variables = {{"%Bin%", "XXXXXXX"},
                                {"%BBBCorePN%", "XXXXXXXXXXXXX"},
                                {"%GMCorePN%", "XXXXXXXXXX"},
                                {"%RFID%", "XXXXXXXXXX"},
                                {"%RFIDidx%", "XXXXX"}}
        'End

        LanguageToolStripMenuItem.Text = eLanguage.English.ToString

        SetLanguage()

        Me.Text = BBBLib.Func.theAppName + " " + BBBLib.Func.theAppVersion

        BBBLib.Log.LogMessages = True

        BBBLib.Log.LocalPath = "C:\Logs\K2XX\Master"
        BBBLib.Log.ServerPath = "C:\Logs\K2XX"
        BBBLib.Log.LogMsg("App Started - " + BBBLib.Func.theAppName + " " + BBBLib.Func.theAppVersion)

        lblRackBarcodeLen.Text = ""
        lblCorePNLen.Text = ""
        lblCoreSNLen.Text = ""

        'Replace with INI File read routine
        With Gvars.InhalePrg
            .Timeout_mSec = 60000
            .AppPath = "C:\eps\Batch Files\ReadData-K2XX.bat"
            .Arguments = "1 1 1 1"
            .TimedOut = False
            .ReturnValue = -1
            .Completed = False
            .OutputFileLocation = "C:\eps\data\output.csv"
        End With

        ClearData()
        cboxProducts.Items.Clear()
        cboxProducts.Items.Add(Gvars.eProductType.K2XX_GM__AC_Delco.ToString.Replace("__", " / ").Replace("_", " "))
        cboxProducts.Items.Add(Gvars.eProductType.K2XX_BBB.ToString.Replace("__", " / ").Replace("_", " "))
        cboxProducts.Items.Add(Gvars.eProductType.T1XX_GM.ToString.Replace("__", " / ").Replace("_", " "))

        Dim frm As New DBConString.frmDBConString("EPAS-Database#1", "\\192.168.1.32\AM-FileShare\Applications\DatabaseConnectionStrings", "DBConStrings.ini")
        frm.ShowDialog()
        If frm.TestFailed Then
            MsgBox("Error reading database info.  Please contact your supervisor.")
            End
        End If

        If Not DBConString.gVars.GetConString("EPSData", ConString) Then End
        If Not DBConString.gVars.GetConString("EPAS", ConString_EPAS) Then End
        If Not DBConString.gVars.GetConString("EPAS_AM", ConString_EPAS_AM) Then End
        If Not DBConString.gVars.GetConString("BBB_EPS", ConString_BBB_EPS) Then End
        If Not DBConString.gVars.GetConString("EPSData", ConString_EPSData) Then End
        If Not DBConString.gVars.GetConString("EPSData", Gvars.ConString_EPSData) Then End
        If Not DBConString.gVars.GetConString("EHPS", ConString_EHPS) Then End
        If Not DBConString.gVars.GetConString("EPAS_Epsilon", ConString_EPAS_Epsilon) Then End

        SerialPort.RFID.SetupComPort(True)
        AddHandler SerialPort.RFID.DataReceivedEvent, AddressOf RFIDTagNumberReceived
        'AddHandler RFIDReader.RFIDReader.RFIDDataReceived, AddressOf RFIDTagNumberReceived

        'lblBillOfLading.Text = My.Settings.BoL
        ' LoadCoreNumbers()

        ' Gvars.GetDTCsForK2XX()

    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        tt.SetToolTip(btnRunInhale, Gvars.InhalePrg.AppPath)
        tmrMain.Enabled = True

        Update_BIN_Lookup()
    End Sub

    Private Sub Update_BIN_Lookup()
        Try
            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [BIN_Number],[BBB_CoreNumber],[GM_ACD_Number],[BBB_MotorNumber],[CS],[GM_ACD_CoreNumber],[BBB_CoreTag] FROM [EPSData].[dbo].[K2XX_BINLookup];", Nothing)
            BBBLib.SQL.RunSQLQuery(ds)

            If ds.Failed Then
                MsgBox("Error getting data from K2XX BIN Lookup." + vbCrLf + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("(A) Error getting data from K2XX BIN Lookup. Ex: " + ds.ExceptionMsg)
            Else
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                ReDim K2XXBinLookup(dt.Rows.Count - 1, dt.Columns.Count - 1)
                For R = 0 To dt.Rows.Count - 1
                    For C = 0 To dt.Columns.Count - 1
                        K2XXBinLookup(R, C) = dt.Rows(R)(C)
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox("Error getting data from K2XX BIN Lookup." + vbCrLf + ex.Message)
            BBBLib.Log.LogMsg("(A) Error getting data from K2XX BIN Lookup. Ex: " + ex.Message)
        End Try

        Try
            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [BIN_Number],[BBB_CoreNumber],[GM_ACD_Number],[BBB_MotorNumber],[CS],[GM_ACD_CoreNumber],[BBB_CoreTag] FROM [EPSData].[dbo].[T1XX_BINLookup];", Nothing)
            BBBLib.SQL.RunSQLQuery(ds)

            If ds.Failed Then
                MsgBox("Error getting data from T1XX BIN Lookup." + vbCrLf + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("(A) Error getting data from T1XX BIN Lookup. Ex: " + ds.ExceptionMsg)
            Else
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                ReDim T1XXBinLookup(dt.Rows.Count, dt.Columns.Count)
                For R = 0 To dt.Rows.Count - 1
                    For C = 0 To dt.Columns.Count - 1
                        T1XXBinLookup(R, C) = ds.rtDataSet.Tables(0).Rows(R)(C)
                    Next
                Next
            End If
        Catch ex As Exception
            MsgBox("Error getting data from T1XX BIN Lookup." + vbCrLf + ex.Message)
            BBBLib.Log.LogMsg("(A) Error getting data from T1XX BIN Lookup. Ex: " + ex.Message)
        End Try
    End Sub

    Public Sub ShellandWait(ByRef Shell As Gvars.sShellAndWait)

        Dim objProcess As System.Diagnostics.Process

        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = Shell.AppPath
            objProcess.StartInfo.Arguments = Shell.Arguments
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()
            Shell.TimedOut = False

            'Wait until the process passes back an exit code 
            If Not objProcess.WaitForExit(Shell.Timeout_mSec) Then
                Shell.TimedOut = True
                objProcess.Kill()
            Else
                Shell.ReturnValue = objProcess.ExitCode.ToString
            End If

            Shell.Completed = True
            objProcess.Close()
        Catch
            MsgBox("Could Not start process " & vbLf & Shell.AppPath, vbOK)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        'B3161941558B3195
        'A1161595235A1159
        Dim str As String = "[)> 06 Y2110200000000X P<CPN> 12V053333055 T<SN>" + vbCrLf
        If ComboBox1.SelectedIndex <> -1 Then
            str = str.Replace("<CPN>", ComboBox1.Items(ComboBox1.SelectedIndex).ToString)
        Else
            str = str.Replace("<CPN>", "84101457")
        End If
        If ckboxSetBlacklist.Checked Then
            str = str.Replace("<SN>", "B3161941558B3195")
        Else
            str = str.Replace("<SN>", "A1161595235A1159")
        End If
        '84101457 
        tbRackBarcode.Text = str
    End Sub

    Private Sub cboxProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxProducts.SelectedIndexChanged
        If cboxProducts.SelectedIndex >= 0 Then
            Gvars.ProductType = cboxProducts.SelectedIndex
            cboxProducts.Enabled = False
            MachineState = eMachineState.ClearData
            LoadCoreNumbers()

            If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
                Gvars.InhalePrg.AppPath = "C:\eps\Batch Files\ReadData-K2XX.bat"
                BinLookup = K2XXBinLookup
                Gvars.GetDTCsForK2XX()

            ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                Gvars.InhalePrg.AppPath = "C:\eps\Batch Files\ReadData-T1XX.bat"
                BinLookup = T1XXBinLookup
                Gvars.GetDTCsForT1XX()

            End If

            If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then

                PanelQ4.Visible = False
                PanelQ5.Visible = False
                PanelQ6.Visible = False

            ElseIf Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then

                PanelQ4.Visible = True
                PanelQ5.Visible = True
                PanelQ6.Visible = True
            End If



            tt.SetToolTip(btnRunInhale, Gvars.InhalePrg.AppPath)
        End If
    End Sub

#Region "Private Methods"
    Private Sub ClearData()
        ClearScreen()
        'clear data

        Gvars.ClearMyData()

        'With Gvars.MyData
        '    .Scan_RFID = 0
        '    .RFID_Acquired = 0
        '    .RFID_Tag = ""
        '    .RFID_Idx = 0

        '    .ProductType = ""
        '    .RackBarcode = ""
        '    .CorePN = ""
        '    .CoreSN = ""
        '    .RackBuildDate = CDate("2011-01-01")
        '    .ValidRackBarcode = False
        '    .HousingBroken = False
        '    .HousingBrokenLocation = ""
        '    .ConnectorBroken = False
        '    .WaterIngression = False
        '    .WaterIngressionValid = True

        '    .UnknownDTCFound = False
        '    .BadDTCFound = False
        '    .AllGoodDTCs = False
        '    .SpecialCaseDTCs = False
        '    .NoComm = False
        '    .NoCommCount = 0

        '    .dtInhaleData = Nothing
        '    .SoftwareVersion2 = ""
        '    .SoftwareVersion3 = ""
        '    .EPS_SN = ""
        '    .ECU_SN = ""
        '    .VIN = ""
        '    .ManufacturingTraceability = ""
        '    .SpecVersion = ""
        '    .GearSerialNumber = ""
        '    .ECUHardwarePN = ""
        '    .GM_PN = ""
        '    .DTC1 = ""
        '    .DTC2 = ""
        '    .DTC3 = ""
        '    .DTC4 = ""
        '    .DTC5 = ""
        '    .DTC6 = ""
        '    .DTC7 = ""
        '    .DTC8 = ""
        '    .DTC9 = ""
        '    .DTC10 = ""
        '    .DTC11 = ""
        '    .DTC12 = ""
        '    .DTC13 = ""
        '    .DTC14 = ""
        '    .DTC15 = ""
        '    .DTC16 = ""
        '    .DTC17 = ""
        '    .DTC18 = ""
        '    .DTC19 = ""
        '    .DTC20 = ""
        '    .ProgVer = ""

        '    .OnBlackList_Rack = False
        '    .OnBlackList_MPP = False

        '    .ValidBuildSheets = ""
        '    .AcceptableDTCs = ""
        '    .UnacceptableDTCs = ""

        '    .Bin = ""
        '    .ScrapHousing = False
        '    .ScrapMotor = False


        'End With


    End Sub
    Private Sub ClearScreen()
        tbRackBarcode.Text = ""
        lblRackBarcodeLen.Text = ""
        tbRackBarcode.ReadOnly = False
        btnDebug.Enabled = True

        lblCorePN.Text = ""
        lblCorePNLen.Text = ""

        lblBushingInfo.Text = ""
        lblCFactorInfo.Text = ""


        lblCoreSN.Text = ""
        lblCoreSNLen.Text = ""
        lblCoreSN.BackColor = Color.White
        lblCoreSN.ForeColor = Color.FromName("ControlText")

        lblRackBuildDate.Text = ""

        lblBorkenLocation.Text = ""

        PanelQ3.Enabled = False

        btnYes6.BackColor = Color.Gainsboro
        btnNo6.BackColor = Color.Gainsboro
        btnYes5.BackColor = Color.Gainsboro
        btnNo5.BackColor = Color.Gainsboro
        btnYes4.BackColor = Color.Gainsboro
        btnNo4.BackColor = Color.Gainsboro
        btnYes3.BackColor = Color.Gainsboro
        btnNo3.BackColor = Color.Gainsboro
        btnYes1.BackColor = Color.Gainsboro
        btnNo1.BackColor = Color.Gainsboro
        btnYes2.BackColor = Color.Gainsboro
        btnNo2.BackColor = Color.Gainsboro

        lblDisposition.Text = ""
        lblDisposition.BackColor = Reset_BackColor

        btnRunInhale.Enabled = False

        lblGMPN.Text = ""
        lblACDPN.Text = ""
        lblBBBPN.Text = ""

        lblRFIDTag.Text = ""

        dgv.DataSource = Nothing

        btnClickWhenDone.Visible = False
        btnClickWhenDone.BackColor = HighLightBackColor

        PanelQ1.BackColor = Reset_BackColor
        PanelQ2.BackColor = Reset_BackColor
        PanelQ3.BackColor = Reset_BackColor
        PanelQ4.BackColor = Reset_BackColor
        PanelQ5.BackColor = Reset_BackColor
        PanelQ6.BackColor = Reset_BackColor
        PanelRFID.BackColor = Reset_BackColor
        PanelInhale.BackColor = Reset_BackColor

        'TextBox1.Text = ""

        lblDisposition.BackColor = Color.WhiteSmoke
        lblDisposition.ForeColor = Color.Black

        lblNoCommTryNumber.Visible = False
    End Sub

    Private Sub btnClearProduct_Click(sender As Object, e As EventArgs) Handles btnClearProduct.Click

        cboxProducts.SelectedIndex = -1
        cboxProducts.Enabled = True
        PanelK2XX.Enabled = False
        lblBushing.Visible = False
        btnNoTag.Visible = False
        PanelBushingInfo.Visible = False
        'btnNoTag.Enabled = True

        PanelQ4.Visible = False
        PanelQ5.Visible = False
        PanelQ5.Visible = False

        MachineState = eMachineState.SelectProduct

    End Sub

    Private Sub btnClearRackBarcode_Click(sender As Object, e As EventArgs) Handles btnClearData.Click

        If MachineState = eMachineState.ClickClearToContinue Or MachineState = eMachineState.ScanRackBarcode Then
            MachineState = eMachineState.ClearData
            btnClearData.BackColor = Color.Gainsboro
            btnClearData.Visible = False

            'Added Erick Medrano 2024-01-15

            lblBushingInfo.Text = ""
            lblCFactorInfo.Text = ""
            btnNoTag.Enabled = True
            frmSelectBushing.Enabled = True
            PanelBushingInfo.Visible = False
            'End Added Erick Medrano 2024-01-15

            'ElseIf MsgBox("Data has NOT been saved!" + vbCrLf + "Are you sure you want to clear the Data?", vbYesNo) = vbYes Then
        ElseIf MsgBox(Phrases(21, Language), vbYesNo) = vbYes Then
            BBBLib.Log.LogMsg("Clear Data: CSN: " + Gvars.MyData.CoreSN + " MSN: " + Gvars.MyData.ManufacturingTraceability + " " + Gvars.MyData.RFID_Tag + "(" + Gvars.MyData.RFID_Idx.ToString + ")")
            MachineState = eMachineState.ClearData
            btnClearData.BackColor = Color.Gainsboro
            btnClearData.Visible = False
        End If
    End Sub

    Private Sub tbRackBarcode_TextChanged(sender As Object, e As EventArgs) Handles tbRackBarcode.TextChanged
        'Display the string length
        If (tbRackBarcode.Text.Replace(vbCr, "").Replace(vbLf, "").ToUpper.Trim).Length = 0 Then
            lblRackBarcodeLen.Text = ""
        Else
            lblRackBarcodeLen.Text = tbRackBarcode.Text.Replace(vbCr, "").Replace(vbLf, "").ToUpper.Trim.Length.ToString
        End If

        Gvars.MyData.ValidRackBarcode = False

        'Exit SUb if textbox is blank
        If tbRackBarcode.Text.Trim = "" Then Exit Sub

        'Get Contents of tbRackBarcode and strip and CR and LF and any blank spaces on the ends
        Dim s As String = tbRackBarcode.Text.Replace(vbCr, "").Replace(vbLf, "").Replace(ChrW(30), "").ToUpper.Trim
        'If s.Length >= 59 And lblBillOfLading.Text.Length = 0 Then

        'End If
        'Add one space to the end for searching 
        s = s + " "

        Dim str As String = ""
        For i = 0 To s.Length - 1
            str += Asc(s.Substring(i, 1)).ToString + " "
        Next
        'TextBox1.Text = str
        Dim bol As String = lblBillOfLading.Text.Trim + Space(51)
        Gvars.MyData.BoL = bol.Substring(0, 50).Trim
        If s.Length = 64 Then
            If s.Contains(" P") And s.Contains(" T") Then
                'Both were found

                Dim i1 As Integer = -1
                Dim i2 As Integer = -1

                'Extract Core Part Number
                Try
                    i1 = s.IndexOf(" P")
                    i2 = s.Substring(i1 + 2).IndexOf(" ")
                    Gvars.MyData.CorePN = s.Substring(i1 + 2, i2)
                    lblCorePN.Text = Gvars.MyData.CorePN
                Catch ex As Exception
                    Gvars.MyData.CorePN = ""
                End Try

                'Extract Core Serial Number
                Try
                    i1 = s.IndexOf(" T")
                    i2 = s.Substring(i1 + 2).IndexOf(" ")
                    Gvars.MyData.CoreSN = s.Substring(i1 + 2, i2)
                    lblCoreSN.Text = Gvars.MyData.CoreSN
                Catch ex As Exception
                    Gvars.MyData.CoreSN = ""
                End Try


                'Extract Core Build Date form Serial Number
                Try
                    Gvars.MyData.RackBuildDate = CDate("2000-01-01")
                    Dim Year As Integer = CInt("20" + Gvars.MyData.CoreSN.Substring(2, 2))
                    Dim JulianDays As Integer = CInt(Gvars.MyData.CoreSN.Substring(4, 3))

                    Gvars.MyData.RackBuildDate = New Date(Year, 1, 1).AddDays(JulianDays - 1)
                    lblRackBuildDate.Text = Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")
                Catch ex As Exception
                    Gvars.MyData.RackBuildDate = CDate("2000-01-01")
                    lblRackBuildDate.Text = ""
                End Try

                Gvars.MyData.ValidRackBarcode = (Gvars.MyData.CorePN.Length = 8) And (Gvars.MyData.CoreSN.Length = 16)
                If Gvars.MyData.ValidRackBarcode Then Gvars.MyData.RackBarcode = s.Trim

            End If
        ElseIf s.Length = 59 Then
            If s.Substring(20, 1) = "P" And s.Substring(41, 1) = "T" Then
                'Both were found

                'Extract Core Part Number
                Try
                    Gvars.MyData.CorePN = s.Substring(21, 8)
                    lblCorePN.Text = Gvars.MyData.CorePN
                Catch ex As Exception
                    Gvars.MyData.CorePN = ""
                End Try

                'Extract Core Serial Number
                Try
                    Gvars.MyData.CoreSN = s.Substring(42, 16)
                    lblCoreSN.Text = Gvars.MyData.CoreSN
                Catch ex As Exception
                    Gvars.MyData.CoreSN = ""
                End Try


                'Extract Core Build Date form Serial Number
                Try
                    Gvars.MyData.RackBuildDate = CDate("2000-01-01")
                    Dim Year As Integer = CInt("20" + Gvars.MyData.CoreSN.Substring(2, 2))
                    Dim JulianDays As Integer = CInt(Gvars.MyData.CoreSN.Substring(4, 3))

                    Gvars.MyData.RackBuildDate = New Date(Year, 1, 1).AddDays(JulianDays - 1)
                    lblRackBuildDate.Text = Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")
                Catch ex As Exception
                    Gvars.MyData.RackBuildDate = CDate("2000-01-01")
                    lblRackBuildDate.Text = ""
                End Try

                Gvars.MyData.ValidRackBarcode = (Gvars.MyData.CorePN.Length = 8) And (Gvars.MyData.CoreSN.Length = 16)
                If Gvars.MyData.ValidRackBarcode Then Gvars.MyData.RackBarcode = s.Trim

            End If
        End If
        'look for both <Space>P and <Space>T in the string

    End Sub

    Private Sub lblCorePN_TextChanged(sender As Object, e As EventArgs) Handles lblCorePN.TextChanged
        If lblCorePN.Text.Trim.Length = 0 Then
            lblCorePNLen.Text = ""
        Else

            lblCorePNLen.Text = lblCorePN.Text.Trim.Length.ToString
            MachineState = eMachineState.LookupPNs

        End If
    End Sub

    Private Sub lblCoreSN_TextChanged(sender As Object, e As EventArgs) Handles lblCoreSN.TextChanged
        If lblCoreSN.Text.Trim.Length = 0 Then
            lblCoreSNLen.Text = ""
        Else
            lblCoreSNLen.Text = lblCoreSN.Text.Trim.Length.ToString
        End If
    End Sub

    Private Sub lblDisposition_Click(sender As Object, e As EventArgs) Handles lblDisposition.Click
        'Dim Hold As Boolean = False
        'Dim GM As Boolean = False
        'Dim ACD As Boolean = False
        'Dim SaveMtr As Boolean = False
        'Dim Scrap As Boolean = False
        'Dim Bin As String = ""

        'If Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
        '    Hold = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    ACD = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
        '    GM = True
        'ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    SaveMtr = True
        'Else
        '    Scrap = True
        'End If


        'If Hold = True Then
        '    Bin = GetLookupValue("Hold", 0)
        'ElseIf GM = True Then
        '    Bin = GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 1)
        'ElseIf ACD = True Then
        '    Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), 1)
        'ElseIf SaveMtr = True Then
        '    Bin = GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
        'ElseIf Scrap = True Then
        '    Bin = "Scrap"
        'Else
        '    Throw New Exception("Error in Desposition routine.")
        'End If




        'lblDisposition.Text = Bin
    End Sub

    Private Sub btnRunInhale_Click(sender As Object, e As EventArgs) Handles btnRunInhale.Click


        If BGW.IsBusy Then Exit Sub
        btnRunInhale.Enabled = False
        PanelInhale.BackColor = Reset_BackColor

        'Clear DGV
        dgv.DataSource = Nothing
        Me.Refresh()

        Gvars.MyData.WaterIngression = False
        Gvars.MyData.WaterIngressionValid = True 'False
        PanelQ3.Enabled = False

        'Delete existing output file
        If BBBLib.Func.theComputerName <> "LAM-LJUAREZ" Or Func.theComputerName.Equals("LAM-DEVELOPER") Then
            If Not DeleteFile(Gvars.InhalePrg.OutputFileLocation) Then
                MsgBox("error trying to delete File: " + Gvars.InhalePrg.OutputFileLocation)
                Exit Sub
            End If
        End If

        Gvars.InhalePrg.Completed = False

        'Run App
        Dialogs.Dialog(Me, "", Dialogs.MessageType.Warning, 5, 14)
        BGW.RunWorkerAsync()

        'Set wait for return Flag

        'Read Output File.




    End Sub


    Private Function DeleteFile(FileName As String) As Boolean
        Try
            My.Computer.FileSystem.DeleteFile(FileName)
        Catch ex As Exception
        End Try

        System.Threading.Thread.Sleep(50)

        Return Not (IO.File.Exists(FileName))
    End Function


#Region "BGW"

    Private Sub BGW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGW.DoWork
        Dim objProcess As System.Diagnostics.Process
        Gvars.InhalePrg.ReturnValue = 0
        Gvars.InhalePrg.ErrorMsg = ""
        Gvars.InhalePrg.AnError = False

        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = Gvars.InhalePrg.AppPath
            objProcess.StartInfo.Arguments = Gvars.InhalePrg.Arguments
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            If BBBPN.Contains("Global_B") Then
                objProcess.StartInfo.Arguments += " Global_B"
            End If
            objProcess.Start()
            If Not objProcess.WaitForExit(Gvars.InhalePrg.Timeout_mSec) Then
                'ShellandWaitTimeout = True
                objProcess.Kill()
                Gvars.InhalePrg.ReturnValue = -999
            Else
                Gvars.InhalePrg.ReturnValue = objProcess.ExitCode.ToString
            End If
            objProcess.Close()
            objProcess.Dispose()
            objProcess = Nothing
            'If InhalePrg.Timeout_mSec = 0 Then
            '    objProcess.WaitForExit()
            '    'ShellandWaitTimeout = False
            '    InhalePrg.ReturnValue = objProcess.ExitCode.ToString
            'Else
            '    'Wait until the process passes back an exit code 
            '    If Not objProcess.WaitForExit(InhalePrg.Timeout_mSec) Then
            '        'ShellandWaitTimeout = True
            '        objProcess.Kill()
            '        InhalePrg.ReturnValue = -999
            '    Else
            '        InhalePrg.ReturnValue = objProcess.ExitCode.ToString
            '    End If
            'End If

        Catch ex As Exception
            Gvars.InhalePrg.ErrorMsg = ex.ToString
            Gvars.InhalePrg.AnError = True
        End Try
    End Sub

    Private Sub BGW_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        Gvars.InhalePrg.Completed = False
        If Gvars.InhalePrg.ReturnValue = -999 Then
            MachineState = eMachineState.TimeOutWaiting
        Else
            MachineState = eMachineState.InhaleCompletedOK
        End If


    End Sub

    'Function ReadCSV(ByVal path As String) As System.Data.DataTable

    '    Dim sr As New System.IO.StreamReader(path)
    '    Dim fullFileStr As String = sr.ReadToEnd()
    '    sr.Close()
    '    sr.Dispose()
    '    Dim lines As String() = fullFileStr.Split(ControlChars.Lf)
    '    Dim recs As New DataTable()
    '    Dim sArr As String() = lines(0).Split(","c)
    '    For Each s As String In sArr
    '        recs.Columns.Add(s.Trim.Replace(" ", "_"), GetType(String))
    '    Next
    '    Dim row As DataRow
    '    Dim finalLine As String = ""

    '    Dim Line As String = lines(1)
    '    row = recs.NewRow()
    '    finalLine = Line.Replace(Convert.ToString(ControlChars.Cr), "")
    '    row.ItemArray = finalLine.Split(","c)
    '    recs.Rows.Add(row)

    '    Return recs
    'End Function

    'Private Function GetCSVFile(dtOutputFile As DataTable) As Boolean
    '    GetCSVFile = False
    '    dgv.DataSource = dtOutputFile

    '    'Hide cells
    '    HideDGVColumn("BarCode")
    '    HideDGVColumn("TYPE")
    '    HideDGVColumn("RFID")
    '    HideDGVColumn("IDX")

    '    'Hide Blank DTC 2-20 cells
    '    For i = 2 To 20
    '        HideDGVColumn("DTC " + i.ToString, "0")
    '    Next

    '    For c = 0 To dgv.Columns.Count - 1
    '        dgv.Columns(c).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        dgv.Columns(c).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
    '    Next

    '    With dgv.ColumnHeadersDefaultCellStyle
    '        .Font = New Font("Arial", 9, FontStyle.Bold)
    '    End With

    '    With dgv.DefaultCellStyle
    '        .Font = New Font("Arial", 9, FontStyle.Bold)
    '    End With

    '    For c = 0 To dgv.Columns.Count - 1
    '        dgv.Rows(0).Cells(c).Value = FilterData(dgv.Rows(0).Cells(c).Value.ToString)
    '    Next
    '    Try

    '        Gvars.MyData.SoftwareVersion1 = dgv.Rows(0).Cells("Software_Version1").Value.ToString
    '        Gvars.MyData.SoftwareVersion2 = dgv.Rows(0).Cells("Software_Version2").Value.ToString
    '        Gvars.MyData.SoftwareVersion3 = dgv.Rows(0).Cells("Software_Version3").Value.ToString
    '        Gvars.MyData.EPS_SN = dgv.Rows(0).Cells("EPS_Serial_Number").Value.ToString
    '        Gvars.MyData.ECU_SN = dgv.Rows(0).Cells("ECU_Serial_Number").Value.ToString
    '        Gvars.MyData.VIN = dgv.Rows(0).Cells("VIN").Value.ToString
    '        Gvars.MyData.ManufacturingTraceability = dgv.Rows(0).Cells("Manufacturing_Traceability").Value.ToString
    '        Gvars.MyData.SpecVersion = dgv.Rows(0).Cells("Spec_Version").Value.ToString
    '        Gvars.MyData.GearSerialNumber = dgv.Rows(0).Cells("Gear_Serial_Number").Value.ToString
    '        Gvars.MyData.ECUHardwarePN = dgv.Rows(0).Cells("ECU_Hardware_Part_Number").Value.ToString
    '        Gvars.MyData.GM_PN = dgv.Rows(0).Cells("GM_Part_Number").Value.ToString

    '        Gvars.MyData.DTC1 = dgv.Rows(0).Cells("DTC_1").Value.ToString
    '        Gvars.MyData.DTC2 = dgv.Rows(0).Cells("DTC_2").Value.ToString
    '        Gvars.MyData.DTC3 = dgv.Rows(0).Cells("DTC_3").Value.ToString
    '        Gvars.MyData.DTC4 = dgv.Rows(0).Cells("DTC_4").Value.ToString
    '        Gvars.MyData.DTC5 = dgv.Rows(0).Cells("DTC_5").Value.ToString
    '        Gvars.MyData.DTC6 = dgv.Rows(0).Cells("DTC_6").Value.ToString
    '        Gvars.MyData.DTC7 = dgv.Rows(0).Cells("DTC_7").Value.ToString
    '        Gvars.MyData.DTC8 = dgv.Rows(0).Cells("DTC_8").Value.ToString
    '        Gvars.MyData.DTC9 = dgv.Rows(0).Cells("DTC_9").Value.ToString
    '        Gvars.MyData.DTC10 = dgv.Rows(0).Cells("DTC_10").Value.ToString
    '        Gvars.MyData.DTC11 = dgv.Rows(0).Cells("DTC_11").Value.ToString
    '        Gvars.MyData.DTC12 = dgv.Rows(0).Cells("DTC_12").Value.ToString
    '        Gvars.MyData.DTC13 = dgv.Rows(0).Cells("DTC_13").Value.ToString
    '        Gvars.MyData.DTC14 = dgv.Rows(0).Cells("DTC_14").Value.ToString
    '        Gvars.MyData.DTC15 = dgv.Rows(0).Cells("DTC_15").Value.ToString
    '        Gvars.MyData.DTC16 = dgv.Rows(0).Cells("DTC_16").Value.ToString
    '        Gvars.MyData.DTC17 = dgv.Rows(0).Cells("DTC_17").Value.ToString
    '        Gvars.MyData.DTC18 = dgv.Rows(0).Cells("DTC_18").Value.ToString
    '        Gvars.MyData.DTC19 = dgv.Rows(0).Cells("DTC_19").Value.ToString
    '        Gvars.MyData.DTC20 = dgv.Rows(0).Cells("DTC_20").Value.ToString

    '        Gvars.MyData.ProgVer = dgv.Rows(0).Cells("Prog_Ver").Value.ToString

    '        Gvars.MyData.NoComm = dgv.Rows(0).Cells("DTC_1").Value.trim.toupper = "ERROR"
    '        If Gvars.MyData.NoComm Then Gvars.MyData.NoCommCount += 1


    '        Gvars.MyData.UnknownDTCFound = False
    '        Gvars.MyData.BadDTCFound = False
    '        Gvars.MyData.AllGoodDTCs = False
    '        Gvars.MyData.SpecialCaseDTCs = False

    '        Gvars.MyData.OnBlackList_MPP = CheckBlackList(Gvars.MyData.ManufacturingTraceability)
    '        If Gvars.MyData.OnBlackList_MPP Then
    '            HightlightCell("Manufacturing_Traceability", Color.Maroon, Color.Yellow)
    '        Else
    '            HightlightCell("Manufacturing_Traceability", Color.DarkGreen, Color.White)
    '        End If

    '        CheckDTCs()

    '        GetCSVFile = True
    '    Catch ex As Exception
    '        MsgBox("Error reading data from Datatable." + vbCrLf + ex.ToString)
    '        BBBLib.Log.LogMsg("Error reading data from Datatable." + vbCrLf + ex.ToString)
    '    End Try

    '    dgv.AutoResizeColumns()
    '    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    'End Function
    'Private Sub HightlightCell(Heading As String, aColorB As Color, aColorF As Color)
    '    For c = 0 To dgv.ColumnCount - 1
    '        If dgv.Columns(c).Name.ToUpper Like (Heading.ToUpper) Then
    '            dgv.Rows(0).Cells(c).Style.BackColor = aColorB
    '            dgv.Rows(0).Cells(c).Style.ForeColor = aColorF
    '        End If
    '    Next
    'End Sub
    'Private Sub HideDGVColumn(ColumnName As String, Optional IfValueIs As String = Nothing)
    '    ColumnName = ColumnName.Trim.Replace(" ", "_")

    '    If IsNothing(IfValueIs) Then
    '        dgv.Columns(ColumnName).Visible = False
    '    ElseIf dgv.Rows(0).Cells(ColumnName).Value.ToString = IfValueIs Then
    '        dgv.Columns(ColumnName).Visible = False
    '    End If
    'End Sub

    'Private Function FilterData(Input As String) As String
    '    FilterData = ""
    '    For c = 0 To Input.Length - 1
    '        If Asc(Input.Substring(c, 1)) >= 32 And Asc(Input.Substring(c, 1)) <= 255 Then
    '            FilterData += Input.Substring(c, 1)
    '        End If
    '    Next
    'End Function

    Private ButtonColorSelected As Color = Color.LightGreen
    Private ButtonColorUnselected As Color = Color.Gainsboro

    Private Sub btnYes1_Click(sender As Object, e As EventArgs) Handles btnYes1.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_1"
        Dim x As Integer = Me.Left + PanelK2XX.Left + PanelQ1.Left + btnYes1.Left + (btnYes1.Width / 2)
        Dim y As Integer = Me.Top + PanelK2XX.Top + PanelQ1.Top + btnYes1.Top + (btnYes1.Height / 2)
        Dim frm As New frmBrokenHousings(New Point(x, y), (Language = eLanguage.Spanish))
        frm.ShowDialog()
        Gvars.MyData.HousingBrokenLocation = frm.BrokenAt
        lblBorkenLocation.Text = Gvars.MyData.HousingBrokenLocation

        'If Gvars.MyData.NoComm Then
        '    PanelInhale.BackColor = Color.WhiteSmoke
        '    btnRunInhale.Enabled = False
        '    'SetMessage("Answer the question.")
        '    SetMessage(Phrases(6, Language))
        'End If

        PanelQ1.BackColor = Reset_BackColor
        PanelQ2.BackColor = HighLightBackColor

        btnYes1.BackColor = ButtonColorSelected
        btnNo1.BackColor = ButtonColorUnselected
        Gvars.MyData.HousingBroken = True
        btnRunInhale.Enabled = False
        PanelQ2.Enabled = True

        'If Gvars.MyData.NoComm And (PanelQ3.Enabled = False) Then
        '    Gvars.MyData.WaterIngression = False
        '    Gvars.MyData.WaterIngressionValid = True
        '    PanelQ3.Enabled = True
        '    PanelQ3.BackColor = HighLightBackColor
        'End If

        ClearDisposition()
    End Sub

    Private Sub btnNo1_Click(sender As Object, e As EventArgs) Handles btnNo1.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_1"
        Gvars.MyData.HousingBrokenLocation = ""
        lblBorkenLocation.Text = ""

        If Gvars.MyData.NoComm Then
            PanelInhale.BackColor = Color.WhiteSmoke
            btnRunInhale.Enabled = False
            'SetMessage("Answer the question.")
            SetMessage(Phrases(6, Language))
        End If

        PanelQ1.BackColor = Reset_BackColor
        PanelQ2.BackColor = HighLightBackColor

        btnYes1.BackColor = ButtonColorUnselected
        btnNo1.BackColor = ButtonColorSelected
        Gvars.MyData.HousingBroken = False
        btnRunInhale.Enabled = False
        PanelQ2.Enabled = True
        'If Gvars.MyData.NoComm And (PanelQ3.Enabled = False) Then
        '    Gvars.MyData.WaterIngression = False
        '    Gvars.MyData.WaterIngressionValid = True
        '    PanelQ3.Enabled = True
        '    PanelQ3.BackColor = HighLightBackColor
        'End If
        ClearDisposition()
    End Sub
    Private Sub btnYes2_Click(sender As Object, e As EventArgs) Handles btnYes2.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_2"
        PanelQ2.BackColor = Reset_BackColor

        btnYes2.BackColor = ButtonColorSelected
        btnNo2.BackColor = ButtonColorUnselected
        Gvars.MyData.ConnectorBroken = True
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        ' Added by Erick Medrano 2024-04-18

        If (cboxProducts.Text = "K2XX BBB") Then
            PanelQ4.Enabled = True
            PanelQ4.BackColor = HighLightBackColor
        Else
            PanelQ3.Enabled = True
            PanelQ3.BackColor = HighLightBackColor
        End If

        ' End Add

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnNo2_Click(sender As Object, e As EventArgs) Handles btnNo2.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_2"
        PanelQ2.BackColor = Reset_BackColor

        btnYes2.BackColor = ButtonColorUnselected
        btnNo2.BackColor = ButtonColorSelected
        Gvars.MyData.ConnectorBroken = False
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        ' Added by Erick Medrano 2024-04-18

        If (cboxProducts.Text = "K2XX BBB") Then
            PanelQ4.Enabled = True
            PanelQ4.BackColor = HighLightBackColor
        Else
            PanelQ3.Enabled = True
            PanelQ3.BackColor = HighLightBackColor
        End If

        ' End Add


        'End If

        ClearDisposition()
    End Sub
    Private Sub btnYes3_Click(sender As Object, e As EventArgs) Handles btnYes3.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_3"
        PanelQ3.BackColor = Reset_BackColor

        btnYes3.BackColor = ButtonColorSelected
        btnNo3.BackColor = ButtonColorUnselected
        Gvars.MyData.WaterIngression = True
        btnRunInhale.Enabled = False
        ClearDisposition()
    End Sub

    Private Sub btnNo3_Click(sender As Object, e As EventArgs) Handles btnNo3.Click

        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_3"
        PanelQ3.BackColor = Reset_BackColor

        btnYes3.BackColor = ButtonColorUnselected
        btnNo3.BackColor = ButtonColorSelected
        Gvars.MyData.WaterIngression = False
        btnRunInhale.Enabled = False
        ClearDisposition()
    End Sub
    Private Sub ClearDisposition()
        Dim szSection As String = ""
        lblDisposition.Text = ""
        Dim ScrapAll As Boolean
        Dim DisplayBtn As Boolean = False

        ''SetMessage("Answer the question.")
        'SetMessage(Phrases(6, Language))
        'If (btnYes1.BackColor <> Color.Gainsboro) Or (btnNo1.BackColor <> Color.Gainsboro) Then
        '    If (btnYes2.BackColor <> Color.Gainsboro) Or (btnNo2.BackColor <> Color.Gainsboro) Then
        '        If PanelQ3.Enabled = False Then
        '            DetermineDisposition(ScrapAll)
        '            If ScrapAll Or Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
        '                PanelRFID.BackColor = Reset_BackColor
        '                DisplayBtn = True
        '                Gvars.MyData.Scan_RFID = False
        '            Else
        '                PanelRFID.BackColor = HighLightBackColor
        '                'SetMessage("Scan an RFID Tag.")
        '                SetMessage(Phrases(10, Language))
        '                Gvars.MyData.Scan_RFID = True
        '            End If
        '        ElseIf ((btnYes3.BackColor <> Color.Gainsboro) Or (btnNo3.BackColor <> Color.Gainsboro)) And (PanelQ3.Enabled = True) Then
        '            DetermineDisposition(ScrapAll)
        '            If ScrapAll Or Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
        '                PanelRFID.BackColor = Reset_BackColor
        '                DisplayBtn = True
        '                Gvars.MyData.Scan_RFID = False
        '            Else
        '                PanelRFID.BackColor = HighLightBackColor
        '                'SetMessage("Scan an RFID Tag.")
        '                SetMessage(Phrases(10, Language))
        '                Gvars.MyData.Scan_RFID = True
        '            End If
        '        End If
        '    End If
        'End If
        'SetMessage("Answer the question.")

        '
        ' Added by Enrique Juarez 2023-02-23
        '
        Try
            szSection = "Set Message 1"
            SetMessage(Phrases(6, Language))

            szSection = "Check Buttons Colors"
            If (btnYes1.BackColor <> Color.Gainsboro) Or (btnNo1.BackColor <> Color.Gainsboro) Then
                If (btnYes2.BackColor <> Color.Gainsboro) Or (btnNo2.BackColor <> Color.Gainsboro) Then
                    If ((btnYes3.BackColor <> Color.Gainsboro) Or (btnNo3.BackColor <> Color.Gainsboro)) Then


                        'If PanelQ3.Enabled = False Then
                        '    DetermineDisposition(ScrapAll)
                        '    If ScrapAll Or Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
                        '        PanelRFID.BackColor = Reset_BackColor
                        '        DisplayBtn = True
                        '        Gvars.MyData.Scan_RFID = False
                        '    Else
                        '        PanelRFID.BackColor = HighLightBackColor
                        '        'SetMessage("Scan an RFID Tag.")
                        '        SetMessage(Phrases(10, Language))
                        '        Gvars.MyData.Scan_RFID = True
                        '    End If
                        'ElseIf ((btnYes3.BackColor <> Color.Gainsboro) Or (btnNo3.BackColor <> Color.Gainsboro)) And (PanelQ3.Enabled = True) Then

                        If cboxProducts.SelectedIndex = 0 Then ' K2xx OE
                            szSection = "K2XX OE - DetermineDisposition"
                            DetermineDisposition(ScrapAll)

                        ElseIf cboxProducts.SelectedIndex = 1 Then 'K2xx IAM
                            szSection = "K2XX IA - DetermineDisposition"
                            DetermineDispositionIAM(ScrapAll)

                        ElseIf cboxProducts.SelectedIndex = 2 Then 'T1xx
                            szSection = "T1XX OE - DetermineDisposition"
                            T1xxDetermineDispositionOE(ScrapAll)

                        Else
                            szSection = "Unknown Selection"
                            MsgBox("Error, Contact the developer.")
                            End
                        End If

                        szSection = "Set Panel RFID Color"
                        If ScrapAll Or Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
                            PanelRFID.BackColor = Reset_BackColor
                            DisplayBtn = True
                            Gvars.MyData.Scan_RFID = False
                            SetMessage(Phrases(19, Language))
                        Else
                            PanelRFID.BackColor = HighLightBackColor
                            'SetMessage("Scan an RFID Tag.")
                            SetMessage(Phrases(10, Language))
                            Gvars.MyData.Scan_RFID = True
                        End If
                        'End If

                    End If
                End If
            End If
        Catch ex As Exception
            BBBLib.Log.LogMsg("(ClearDisposition) Section: " + szSection + " Button " + ButtonClicked + ". Ex: " + ex.Message)
        End Try

        btnClickWhenDone.Visible = DisplayBtn
    End Sub
    'Private Function CheckBlackList(SN As String) As Boolean
    '    CheckBlackList = True
    '    Try
    '        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_is_on_the_Blacklist @SN", {{"@SN", SN}})
    '        BBBLib.SQL.RunSQLQuery(ds)

    '        If ds.Failed Then
    '            MsgBox("Error checking blacklist." + vbCrLf + ds.ExceptionMsg)
    '            BBBLib.Log.LogMsg("(A) Error checking blacklist: " + SN + " Ex: " + ds.ExceptionMsg)
    '        Else
    '            Dim dt As DataTable = ds.rtDataSet.Tables(0)
    '            CheckBlackList = CBool(dt.Rows(0)("Results"))
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error checking blacklist." + vbCrLf + ex.ToString)
    '        BBBLib.Log.LogMsg("(B) Error checking blacklist: " + SN + " Ex: " + ex.ToString)
    '    End Try

    'End Function
    'Private Sub CheckDTCs()
    '    Gvars.MyData.AcceptableDTCs = ""
    '    Gvars.MyData.UnacceptableDTCs = ""

    '    For i = 1 To 20
    '        Dim DTCValue As String = dgv.Rows(0).Cells("DTC_" + i.ToString).Value.ToString.Trim
    '        If DTCValue <> "0" Then
    '            Dim DTCState1 As Integer = isDTCValueOK(DTC1, DTCValue)
    '            If DTCState1 = -1 Then
    '                Gvars.MyData.UnknownDTCFound = True
    '                Gvars.MyData.BadDTCFound = True
    '            End If
    '            If DTCState1 = 0 Then Gvars.MyData.BadDTCFound = True

    '            Dim DTCState2 As Integer = isDTCValueOK(DTC2, DTCValue)
    '            If DTCState2 = 0 Then Gvars.MyData.SpecialCaseDTCs = True

    '            If DTCState1 = 1 Then
    '                If Gvars.MyData.AcceptableDTCs.Length > 0 Then Gvars.MyData.AcceptableDTCs += ","
    '                Gvars.MyData.AcceptableDTCs += DTCValue
    '                HightlightCell("DTC_" + i.ToString, Color.DarkGreen, Color.White)

    '            ElseIf DTCState1 <= 0 Then
    '                If Gvars.MyData.UnacceptableDTCs.Length > 0 Then Gvars.MyData.UnacceptableDTCs += ","
    '                Gvars.MyData.UnacceptableDTCs += DTCValue
    '                HightlightCell("DTC_" + i.ToString, Color.Maroon, Color.Yellow)

    '            End If
    '        End If
    '    Next
    '    Gvars.MyData.AllGoodDTCs = (Not Gvars.MyData.UnknownDTCFound) And (Not Gvars.MyData.BadDTCFound) And (Not Gvars.MyData.SpecialCaseDTCs)
    'End Sub

    'Private Function isDTCValueOK(Array As Object(,), DTCValue As String) As Integer
    '    'Return 1  DTC is Is Acceptable
    '    '       0  DTC is Not Acceptable
    '    '       -1 DTC is not found
    '    isDTCValueOK = -1
    '    For i = 0 To Array.GetUpperBound(0)
    '        If Array(i, 0) = DTCValue Then
    '            isDTCValueOK = IIf(Array(i, 1) = True, 1, 0)
    '            Exit For
    '        End If
    '    Next
    'End Function

    Private Sub SetMessage(Msg As String)
        If lblMessage.Text <> Msg Then
            lblMessage.Text = Msg
            Me.Refresh()
            FlashCounter = 4
            tmrFlash.Enabled = True
        End If
    End Sub
    Private Sub tmrMain_Tick(sender As Object, e As EventArgs) Handles tmrMain.Tick

        'PrintLabelToolStripMenuItem.Visible = BBB_Printing.K2xxCoreSortLabel.isPrinterSelected()

        Label4.Text = CtrlKeyDown.ToString

        If cboxProducts.Text = "K2XX BBB" Then
            btnNoTag.Visible = True
        End If


        If btnClearData.Visible = False And EscKeyPressed = True And MachineState <> eMachineState.ScanRackBarcode Then
            btnClearData.Visible = True
        End If
        EscKeyPressed = False

        btnClearProduct.Enabled = (MachineState = eMachineState.ScanRackBarcode)
        btnChangeBoL.Enabled = (MachineState < eMachineState.LookupPNs)
        btnReclassify.Enabled = (MachineState < eMachineState.LookupPNs)

        PanelDebug.Visible = Not HideDebug

        lblRackBarcodeLen.Visible = Not HideDebug
        lblCorePNLen.Visible = Not HideDebug
        lblCoreSNLen.Visible = Not HideDebug
        ComboBox1.Visible = Not HideDebug
        btnDebug.Visible = Not HideDebug
        ckboxSetBlacklist.Visible = Not HideDebug

        tmrMain.Enabled = False

        msMsg.Text = MachineState.ToString

        ckboxBadDTCs.Checked = (Gvars.MyData.SpecialCaseDTCs)
        ckboxBadMtr.Checked = (Gvars.MyData.BadDTCFound)
        ckboxGoodMtr.Checked = (Gvars.MyData.AllGoodDTCs) And (Not Gvars.MyData.BadDTCFound) And (Not Gvars.MyData.SpecialCaseDTCs) And (Not Gvars.MyData.NoComm)
        ckboxNoComm.Checked = (Gvars.MyData.NoComm)
        ckboxOnBlacklist.Checked = (Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP)

        If (Gvars.MyData.OnBlackList_Rack And Gvars.MyData.OnBlackList_MPP) Then
            ckboxOnBlacklist.Text = "On Blacklist - Rack & MPP"
        ElseIf (Gvars.MyData.OnBlackList_Rack) Then
            ckboxOnBlacklist.Text = "On Blacklist - Rack"
        ElseIf (Gvars.MyData.OnBlackList_MPP) Then
            ckboxOnBlacklist.Text = "On Blacklist - MPP"
        Else
            ckboxOnBlacklist.Text = "On Blacklist"
        End If

        ckboxConnectorBroken.Checked = Gvars.MyData.ConnectorBroken
        ckboxHousingBroken.Checked = Gvars.MyData.HousingBroken

        ckboxWaterIngression.Visible = Gvars.MyData.WaterIngressionValid
        ckboxWaterIngression.Checked = Gvars.MyData.WaterIngression

        If cboxProducts.SelectedIndex > -1 Then
            Gvars.MyData.ProductType = cboxProducts.Items(cboxProducts.SelectedIndex).ToString
        End If

        Select Case MachineState
            Case eMachineState.Startup
                ClearData()
                MachineState = eMachineState.SelectProduct

            Case eMachineState.SelectProduct
                'SetMessage("Select Product.")
                SetMessage(Phrases(0, Language))
                PanelK2XX.Enabled = False

            Case eMachineState.EnterBoL
                If lblBillOfLading.Text = "" Then btnChangeBoL_Click(Me, New EventArgs)

            Case eMachineState.ClearData
                ClearData()
                If Not PanelK2XX.Enabled Then PanelK2XX.Enabled = True
                If Not PanelRB1.Enabled Then PanelRB1.Enabled = True
                If PanelQ1.Enabled Then PanelQ1.Enabled = False
                If PanelQ2.Enabled Then PanelQ2.Enabled = False
                If PanelQ3.Enabled Then PanelQ3.Enabled = False
                If PanelQ4.Enabled Then PanelQ4.Enabled = False
                If PanelQ5.Enabled Then PanelQ5.Enabled = False
                If PanelQ6.Enabled Then PanelQ6.Enabled = False
                If Not tbRackBarcode.Focused Then tbRackBarcode.Focus()
                'SetMessage("Scan Rack Barcode.")
                SetMessage(Phrases(2, Language))
                MachineState = eMachineState.ScanRackBarcode

            Case eMachineState.ScanRackBarcode
                'Added by Enrique Juarez
                iSelection = -1
                'End Added
            Case eMachineState.LookupPNs
                If lblBillOfLading.Text = "" Then
                    MsgBox(Phrases(33, Language), vbOKOnly)
                    MachineState = eMachineState.ClearData
                Else
                    GMPN = New List(Of String)
                    ACDPN = New List(Of String)
                    BBBPN = New List(Of String)

                    GetValidPNs2(lblCorePN.Text.Trim, GMPN, ACDPN, BBBPN)
                    If GMPN.Count = 0 Then
                        BBBLib.Log.LogMsg("Missing-1 Core PN: " + lblCorePN.Text.Trim)
                        BBBLib.Log.LogMsg("Missing-2 RackBarCode: " + tbRackBarcode.Text.Replace(vbCr, "").Replace(vbLf, ""))
                        MsgBox("No data found for this Core PN: " + lblCorePN.Text.Trim + vbCrLf + "Please notify the supervisor.")
                        MachineState = eMachineState.ClearData
                    Else
                        tbRackBarcode.ReadOnly = True
                        btnDebug.Enabled = False
                        btnRunInhale.Enabled = True

                        lblGMPN.Text = " GM PNs:  " + String.Join(",", GMPN.ToArray())
                        lblACDPN.Text = "ACD PNs: " + String.Join(",", ACDPN.ToArray())
                        lblBBBPN.Text = "BBB PNs: " + String.Join(",", BBBPN.ToArray())
                    End If

                    If (Gvars.ProductType = Gvars.eProductType.T1XX_GM) Then
                        Gvars.Global_B = BBBPN.Contains("Global_B")
                        If Gvars.Global_B Then
                            Gvars.GetDTCsForT1XX_B()
                        Else
                            Gvars.GetDTCsForT1XX()
                        End If
                    End If

                    'SetMessage("Run Inhale program")
                    SetMessage(Phrases(3, Language))
                    btnRunInhale.Enabled = True

                    Gvars.MyData.OnBlackList_Rack = Gvars.CheckBlackList(lblCoreSN.Text.Trim)

                    If Gvars.MyData.OnBlackList_Rack Then
                        lblCoreSN.BackColor = Color.Maroon
                        lblCoreSN.ForeColor = Color.Yellow
                    Else
                        lblCoreSN.BackColor = Color.DarkGreen
                        lblCoreSN.ForeColor = Color.White
                    End If
                    MachineState = eMachineState.RunInhalePrg
                End If
            Case eMachineState.RunInhalePrg

                PanelInhale.BackColor = HighLightBackColor
                If Not tbRackBarcode.ReadOnly Then tbRackBarcode.ReadOnly = True
                If btnDebug.Enabled Then btnDebug.Enabled = False
                If Not btnRunInhale.Enabled Then btnRunInhale.Enabled = True

            Case eMachineState.InhaleCompletedOK
                btnRunInhale.Enabled = True
                If btnRunInhale.Enabled Then btnRunInhale.Enabled = False
                Try
                    Gvars.MyData.dtInhaleData = Nothing
                    Gvars.MyData.dtInhaleData = Gvars.ReadCSV(Gvars.InhalePrg.OutputFileLocation)
                    MachineState = eMachineState.FileFound
                Catch ex As Exception
                    SetMessage("Error reading Output.csv file, please try again: " + ex.ToString)
                    btnRunInhale.Enabled = True
                    MachineState = eMachineState.RunInhalePrg
                End Try

            Case eMachineState.TimeOutWaiting
                btnRunInhale.Enabled = True
                'SetMessage("Timed out running Inhale program." + vbCrLf + "Please try running the inhale program again" + vbCrLf + "Or contact your supervisor for assistance.")
                SetMessage(Phrases(27, Language))
                MachineState = eMachineState.RunInhalePrg

            Case eMachineState.FileFound
                MachineState = eMachineState.ProcessFile

            Case eMachineState.ProcessFile
                If Not btnRunInhale.Enabled Then btnRunInhale.Enabled = True

                Try
                    If Gvars.GetCSVFile(Gvars.MyData.dtInhaleData, dgv) Then

                        'Added by Erick Medrano 2024-02-09

                        'If NoTag And Gvars.MyData.DTC1 = "0" And dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12") Then
                        '    PanelQ1.Enabled = True
                        '    PanelQ1.BackColor = HighLightBackColor
                        '    PanelInhale.BackColor = Color.WhiteSmoke
                        '    btnRunInhale.Enabled = False
                        '    'SetMessage("Answer the question.")
                        '    SetMessage(Phrases(6, Language))
                        '    MachineState = eMachineState.AskQuestions
                        'End If

                        'End Added by Erick Medrano 2024-02-09

                        If Gvars.MyData.DTC1 = "0" Then
                            Gvars.HightlightCell(dgv, "DTC_1", Color.Salmon, Color.Yellow)
                            'SetMessage("Invalid data." + vbCrLf + "Please try running the inhale program again" + vbCrLf + "Or contact your supervisor for assistance.")
                            SetMessage("")
                            SetMessage(Phrases(25, Language))
                            MachineState = eMachineState.RunInhalePrg
                        Else
                            'PanelQ1.Enabled = True
                            'PanelQ1.BackColor = HighLightBackColor
                            ''PanelQ2.BackColor = HighLightBackColor
                            ''PanelQ3.BackColor = HighLightBackColor
                            'MachineState = eMachineState.AskQuestions
                            'If Gvars.MyData.NoComm Then
                            '    'PanelInhale.BackColor = Color.WhiteSmoke
                            '    'btnRunInhale.Enabled = False
                            '    'SetMessage("NoComm - Check connection and run inhale again or" + vbCrLf + "Continue Answer the question.")
                            '    SetMessage(Phrases(24, Language))
                            'Else
                            '    PanelInhale.BackColor = Color.WhiteSmoke
                            '    btnRunInhale.Enabled = False
                            '    'SetMessage("Answer the question.")
                            '    SetMessage(Phrases(6, Language))
                            'End If
                            'PanelQ1.Enabled = True
                            'PanelQ1.BackColor = HighLightBackColor
                            'PanelQ2.BackColor = HighLightBackColor
                            'PanelQ3.BackColor = HighLightBackColor
                            'MachineState = eMachineState.AskQuestions
                            If Gvars.MyData.NoComm And Gvars.MyData.NoCommCount < NoComCountMin Then
                                'PanelInhale.BackColor = Color.WhiteSmoke
                                'btnRunInhale.Enabled = False
                                'SetMessage("NoComm - Check connection and run inhale again or" + vbCrLf + "Continue Answer the question.")
                                SetMessage("")
                                SetMessage(Phrases(29, Language))
                                lblNoCommTryNumber.Visible = True
                                MachineState = eMachineState.RunInhalePrg
                            Else
                                PanelQ1.Enabled = True
                                PanelQ1.BackColor = HighLightBackColor
                                PanelInhale.BackColor = Color.WhiteSmoke
                                btnRunInhale.Enabled = False
                                'SetMessage("Answer the question.")
                                SetMessage(Phrases(6, Language))
                                MachineState = eMachineState.AskQuestions
                            End If

                        End If
                    Else
                        'SetMessage("Error reading output file." + vbCrLf + "Please try running the inhale program again" + vbCrLf + "Or contact your supervisor for assistance.")
                        SetMessage(Phrases(26, Language))
                        MachineState = eMachineState.RunInhalePrg
                    End If

                Catch ex As Exception
                    'SetMessage("Error reading output file." + vbCrLf + "Please try running the inhale program again" + vbCrLf + "Or contact your supervisor for assistance.")
                    SetMessage(Phrases(26, Language))
                    MachineState = eMachineState.RunInhalePrg
                End Try

                lblNoCommTryNumber.Text = Gvars.MyData.NoCommCount.ToString

            Case eMachineState.AskQuestions

            Case eMachineState.GetRFIDIdx
                If Gvars.MyData.RFID_Acquired = True Then
                    MachineState = eMachineState.DisplayButton
                    btnClickWhenDone_Click(Me, New EventArgs)
                    'SetMessage("Click Button to continue.")
                End If

            Case eMachineState.DisplayButton
                If Not btnClickWhenDone.Visible Then btnClickWhenDone.Visible = True
                btnClickWhenDone.BackColor = HighLightBackColor


            Case eMachineState.GetDisposition
                Dim szSection As String = ""
                Try
                    Dim Contact As String = ""
                    Dim Ext As String = ""

                    szSection = "Check for Alerts"
                    Gvars.MyData.HoldUnit = UnitWatch.UnitWatch(ConString_EPSData, Gvars.MyData.CoreSN, Gvars.MyData.ManufacturingTraceability, Gvars.MyData.VIN, Gvars.MyData.RFID_Tag, Gvars.MyData.RFID_Idx, Contact, Ext)
                    If Gvars.MyData.HoldUnit Then
                        Gvars.MyData.Contact = Contact
                        Gvars.MyData.EXT = Ext
                    End If

                    PanelQ1.BackColor = Reset_BackColor
                    PanelQ2.BackColor = Reset_BackColor
                    PanelQ3.BackColor = Reset_BackColor
                    PanelRFID.BackColor = Reset_BackColor

                    Dim PartInfo As String = ""

                    'Added by Erick Medrano 2024-04-18

                    szSection = "Check for Housing Broken"
                    If Gvars.MyData.HousingBroken Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        If Gvars.MyData.HousingBrokenLocation = "Yoke" Or Gvars.MyData.HousingBrokenLocation = "Center" Or Gvars.MyData.HousingBrokenLocation = "Both" Then
                            PartInfo += Gvars.MyData.HousingBrokenLocation + "SideBroken"
                        End If
                    End If

                    szSection = "Check for Pinion Damaged"
                    If Gvars.MyData.CorrosionPinion Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "CorrosionPin"
                    End If
                    szSection = "Check for Pinion Damaged"
                    If Gvars.MyData.BentPinion Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "BentPinion"
                    End If
                    szSection = "Check for Pinion Damaged"
                    If Gvars.MyData.ConnectorPinion Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "ConnPinion"
                    End If

                    ' End Add

                    szSection = "Check for DTCs or NoComm"
                    If Gvars.MyData.NoComm Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "NoComm"
                    ElseIf (Gvars.MyData.BadDTCFound) Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "BadDTCs"
                    End If

                    If Gvars.MyData.SpecialCaseDTCs Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "TRQSenDTCs"
                    End If

                    szSection = "Check for Connector Broken"
                    If Gvars.MyData.ConnectorBroken Then
                        If PartInfo.Length > 0 Then PartInfo += ", "
                        PartInfo += "ConnBroken"
                    End If

                    szSection = "Setup Printer Label"
                    SetupPrintLabel()

                    ' Added by Enrique Juarez 2022-05-25
                    PrinterInfo.RFID = Gvars.MyData.RFID_Tag
                    PrinterInfo.RFIDidx = Gvars.MyData.RFID_Idx
                    PrinterInfo.PartInfo = PartInfo
                    ' End Add

                    Dim ScrapAll As Boolean
                    Dim Bin As String = ""
                    If cboxProducts.SelectedIndex = 0 Then 'K2xx OE
                        szSection = "K2XX OE - BIN Desposition"
                        Bin = DetermineDisposition(ScrapAll)

                    ElseIf cboxProducts.SelectedIndex = 1 Then 'K2xx IAM
                        szSection = "K2XX IA - BIN Desposition"
                        Bin = DetermineDispositionIAM(ScrapAll)

                    ElseIf cboxProducts.SelectedIndex = 2 Then 'T1xx
                        szSection = "T1XX OE - BIN Desposition"
                        Bin = T1xxDetermineDispositionOE(ScrapAll)

                    Else
                        MsgBox("Error, Contact the developer.")
                        End
                    End If

                    ' Commented by Enrique Juarez 2022-05-25
                    'PrinterInfo.RFID = Gvars.MyData.RFID_Tag
                    'PrinterInfo.RFIDidx = Gvars.MyData.RFID_Idx
                    'PrinterInfo.PartInfo = PartInfo
                    ' End Comment

                    'If Gvars.MyData.HoldUnit Then
                    '    'MyData.Contact
                    '    PrinterInfo.Bin = "Hold UNIT for"
                    '    PrinterInfo.BBBCorePN = "Hold for"
                    '    PrinterInfo.GMCorePN = Gvars.MyData.Contact
                    '    PrinterInfo.PartInfo = ""
                    'End If

                    szSection = "Setting Label Variables"
                    PrinterInfo.setVars()

                    'If BBBLib.Func.theComputerName = "LAM-LJUAREZ" Then
                    '    setupPrtdoc()
                    '    PrtDoc.Print()
                    'End If

                    szSection = "Determine Save Data or Scrap"
                    If ScrapAll Or Gvars.MyData.OnBlackList_Rack Then
                        'lblDisposition.Text = "Scrap both the Housing and the MPP."
                        lblDisposition.Text = Phrases(22, Language)
                        MachineState = eMachineState.SaveDataScrap
                    Else
                        lblDisposition.Text = Bin
                        MachineState = eMachineState.SaveData
                    End If

                    If Gvars.MyData.HoldUnit Then lblDisposition.Text = ""


                    If cboxProducts.SelectedIndex = 0 Then 'K2xx OE
                        szSection = "K2XX OE - Tag Color"
                        SetLabelColor()

                    ElseIf cboxProducts.SelectedIndex = 1 Then 'K2xx IAM
                        szSection = "K2XX IA - Tag Color"
                        SetLabelColorIAM(PartInfo)

                    ElseIf cboxProducts.SelectedIndex = 2 Then 'T1xx
                        szSection = "T1XX OE - Tag Color"
                        SetLabelColorT1XX()
                    Else
                        MsgBox("Error, Contact the developer.")
                        End
                    End If

                    If BBB_Printing.K2xxCoreSortLabel.isPrinterSelected() Or
                       BBBLib.Func.theComputerName = "LAM-LJUAREZ" Then
                        If (Gvars.MyData.HoldUnit = True) Then

                            'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                            If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                                'Imprime el bol xd
                                SetupPrintLabel_BOL()
                                Try
                                    setupPrtdoc()
                                    PrtDoc.Print()
                                Catch ex As Exception
                                End Try
                            End If
                        ElseIf (Gvars.MyData.Bin <> "Scrap") Then
                            Try
                                'Imprime lo normal
                                setupPrtdoc()
                                PrtDoc.Print()

                                'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                                If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then

                                    'Imprime el bol xd
                                    SetupPrintLabel_BOL()
                                    Try
                                        setupPrtdoc()
                                        PrtDoc.Print()
                                    Catch ex As Exception
                                    End Try
                                End If

                            Catch ex As Exception
                            End Try
                            If Gvars.MyData.Bin.Contains("Remove MPP") Then

                                'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                                If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then

                                    'Imprime el bol xd
                                    SetupPrintLabel_BOL()
                                    Try
                                        setupPrtdoc()
                                        PrtDoc.Print()
                                    Catch ex As Exception
                                    End Try
                                End If
                                SetupPrintLabel_Scrap()
                                Try
                                    setupPrtdoc()
                                    PrtDoc.Print()
                                Catch ex As Exception
                                End Try
                            End If
                        Else
                            'Dim idx As Integer = Get_Idx_For_Scrap()
                            'Gvars.MyData.RFID_Tag = "Scrap"
                            'Gvars.MyData.RFID_Idx = idx

                            'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                            '    'Imprime el bol xd
                            '    SetupPrintLabel_BOL()
                            '    Try
                            '        setupPrtdoc()
                            '        PrtDoc.Print()
                            '    Catch ex As Exception
                            '    End Try
                            'End If

                            SetupPrintLabel_Scrap()
                            Try
                                setupPrtdoc()
                                PrtDoc.Print()
                            Catch ex As Exception
                            End Try

                        End If
                    End If
                Catch ex As Exception
                    BBBLib.Log.LogMsg("(GetDisposition) Section: " + szSection + " Button " + ButtonClicked + ". Ex: " + ex.Message)
                End Try
                'lblDisposition.BackColor = Color.Yellow
                'lblDisposition.ForeColor = Color.Black

                'If ScrapAll Or Gvars.MyData.OnBlackList_Rack Then
                '    'lblDisposition.Text = "Scrap both the Housing and the MPP."
                '    lblDisposition.Text = Phrases(22, Language)
                '    MachineState = eMachineState.SaveDataScrap
                'Else
                '    lblDisposition.Text = Bin
                '    MachineState = eMachineState.SaveData
                'End If

                'If Gvars.MyData.HoldUnit Then lblDisposition.Text = ""


                'If cboxProducts.SelectedIndex = 0 Then 'K2xx OE
                '    SetLabelColor()

                'ElseIf cboxProducts.SelectedIndex = 1 Then 'K2xx IAM
                '    SetLabelColorIAM(PartInfo)

                'ElseIf cboxProducts.SelectedIndex = 2 Then 'T1xx
                '    SetLabelColorT1XX()
                'Else
                '    MsgBox("Error, Contact the developer.")
                '    End
                'End If

            Case eMachineState.SaveData
                If Gvars.ProductType = Gvars.eProductType.K2XX_BBB Or Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                    savedata()

                ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                    save_T1XX_data()
                End If


                If Gvars.MyData.HoldUnit Then
                    lblDisposition.Text = "Hold for " + Gvars.MyData.Contact + " @ x" + Gvars.MyData.EXT
                    SetupPrintLabel_HoldUnit()

                    'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                    If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then

                        'Imprime el bol xd
                        SetupPrintLabel_BOL()
                        Try
                            setupPrtdoc()
                            PrtDoc.Print()
                        Catch ex As Exception
                        End Try
                    End If
                    UnitWatch.SetRFIDidxStatusToInactive(Gvars.MyData.RFID_Idx)
                End If

                btnClearData.Visible = True
                MachineState = eMachineState.ClickClearToContinue

            Case eMachineState.SaveDataScrap
                Dim idx As Integer = Get_Idx_For_Scrap() ' Aqui inserta el registro del scrap  y a la vez nos traemos el idx. :v
                Gvars.MyData.RFID_Tag = "Scrap"
                Gvars.MyData.RFID_Idx = idx


                If Gvars.ProductType = Gvars.eProductType.K2XX_BBB Or Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                    savedataScrap() 'Y aqui ya namas actualizamos lo que se tenga que actualizar. v: pero hay que modificarlo para que tambien se actualice el status si es scrap...
                ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                    saveScrap_T1XX_data()
                End If

                If Gvars.MyData.HoldUnit Then
                    lblDisposition.Text = "Hold for " + Gvars.MyData.Contact + " @ x" + Gvars.MyData.EXT
                    SetupPrintLabel_HoldUnit()

                    'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                    If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then

                        'Imprime el bol xd
                        SetupPrintLabel_BOL()
                        Try
                            setupPrtdoc()
                            PrtDoc.Print()
                        Catch ex As Exception
                        End Try
                    End If
                    UnitWatch.SetRFIDidxStatusToInactive(Gvars.MyData.RFID_Idx)
                Else


                    'SetupPrintLabel_Scrap()
                    setupPrtdoc()
                    PrtDoc.Print()

                    'If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Then
                    If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
                        'Imprime el bol xd
                        SetupPrintLabel_BOL()
                        Try
                            setupPrtdoc()
                            PrtDoc.Print()
                            PrtDoc.Print()
                        Catch ex As Exception
                        End Try
                    End If
                End If



                btnClearData.Visible = True
                MachineState = eMachineState.ClickClearToContinue

            Case eMachineState.ClickClearToContinue
                'SetMessage("Click Clear Data button to continue.")
                SetMessage(Phrases(20, Language))
                btnClearData.BackColor = HighLightBackColor

        End Select

        tmrMain.Enabled = True
    End Sub
    Private Sub SetLabelColor()
        'lblDisposition.BackColor = Color.Yellow
        'lblDisposition.ForeColor = Color.Black

        Dim s As String = Gvars.MyData.Bin
        If (Gvars.MyData.HoldUnit = True) Then
            lblDisposition.BackColor = Color.Bisque
            lblDisposition.ForeColor = Color.Black
        ElseIf s = "Scrap" Then
            lblDisposition.BackColor = Color.Maroon
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.Text += vbCrLf + Phrases(39, Language)
        Else
            Dim i As Integer = Gvars.MyData.Bin.IndexOf("#")
            If i > 0 Then
                s = s.Substring(i + 1, 3)
                If IsNumeric(s.Trim) Then
                    Dim ii As Integer = CInt(s.Trim)
                    If (ii = 1) Or (ii = 2) Or (ii = 15) Then
                        lblDisposition.BackColor = Color.Orange
                        lblDisposition.ForeColor = Color.Black
                        lblDisposition.Text += vbCrLf + Phrases(38, Language)
                    Else
                        lblDisposition.BackColor = Color.Bisque
                        lblDisposition.ForeColor = Color.Black
                        lblDisposition.Text += vbCrLf + Phrases(37, Language)
                    End If
                End If
            End If

        End If
    End Sub
    Private Sub SetLabelColorIAM(PartInfo As String)
        'lblDisposition.BackColor = Color.Yellow
        'lblDisposition.ForeColor = Color.Black

        Dim s As String = Gvars.MyData.Bin
        Dim l As String = ""
        Dim Loc As Integer = 6
        'If s = "Scrap" Then
        '    lblDisposition.BackColor = Color.Maroon
        '    lblDisposition.ForeColor = Color.Yellow
        '    lblDisposition.Text += vbCrLf + Phrases(39, Language)
        'Else
        '    If s.Contains("Remove MPP:") Or s.Contains("Hold") Then
        '        lblDisposition.BackColor = Color.Orange
        '        lblDisposition.ForeColor = Color.Black
        '        lblDisposition.Text += vbCrLf + Phrases(38, Language)
        '    Else
        '        lblDisposition.BackColor = Color.Bisque
        '        lblDisposition.ForeColor = Color.Black
        '        lblDisposition.Text += vbCrLf + Phrases(37, Language)
        '    End If
        'End If

        If s = "Scrap" Then
            lblDisposition.BackColor = Color.Maroon
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.Text += vbCrLf + Phrases(39, Language)
            l = "H"

        Else
            'Added Erick Medrano 2024-01-23
            'If s.Contains("Remove MPP:") Or s.Contains("Hold") Then
            '    If NoTag Then
            '        lblDisposition.BackColor = Color.Orange
            '        lblDisposition.ForeColor = Color.Black
            '        lblDisposition.Text += Phrases(18, Language)
            '        l = "H"
            '    Else
            '        lblDisposition.BackColor = Color.Orange
            '        lblDisposition.ForeColor = Color.Black
            '        lblDisposition.Text += Phrases(18, Language)
            '        l = "H"
            '    End If

            'Added Erick Medrano 2024-01-23
            If PartInfo.Equals("") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Green
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "C" + vbCrLf + Phrases(14, Language)
                    l = "C"
                Else
                    lblDisposition.BackColor = Color.Green
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + vbCrLf + Phrases(14, Language)
                    'l = "C"
                End If

            ElseIf PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)
                    lblDisposition.BackColor = Color.White
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CW" + vbCrLf + Phrases(42, Language)
                    l = "W"

                Else
                    lblDisposition.BackColor = Color.White
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "W" + vbCrLf + Phrases(42, Language)
                    l = "W"
                End If
            ElseIf PartInfo.Contains(Gvars.MyData.HousingBrokenLocation) And PartInfo.Contains("NoComm") And PartInfo.Contains("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Contains("NoComm") And PartInfo.Contains("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Bisque
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH" + vbCrLf + Phrases(37, Language)
                    l = "H"
                Else
                    lblDisposition.BackColor = Color.Bisque
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "H" + vbCrLf + Phrases(37, Language)
                    l = "H"
                End If
            ElseIf PartInfo.Equals("NoComm") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Bisque
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH" + vbCrLf + Phrases(37, Language)
                    l = "H"
                Else
                    lblDisposition.BackColor = Color.Bisque
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "H" + vbCrLf + Phrases(37, Language)
                    l = "H"
                End If
            ElseIf PartInfo.Contains(Gvars.MyData.HousingBrokenLocation) Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Contains(Gvars.MyData.HousingBrokenLocation) And PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("CorrosionPin") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("CorrosionPin") And PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("BentPinion") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("BentPinion") And PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("ConnPinion") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If
            ElseIf PartInfo.Equals("ConnPinion") And PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If

                ' End Add 

            ElseIf PartInfo.Equals("ConnBroken") And PartInfo.Equals("BadDTCs") Or PartInfo.Equals("TRQSenDTCs") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If

                'End Added by Erick Medrano 2024-01-23
            ElseIf PartInfo.Equals("ConnBroken") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)
                    lblDisposition.BackColor = Color.White
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CW" + vbCrLf + Phrases(42, Language)
                    l = "W"

                ElseIf GetLookupValue(ACDPN(0), 4) = "N" Then
                    lblDisposition.BackColor = Color.White
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "W" + vbCrLf + Phrases(42, Language)
                    l = "W"

                Else
                    lblDisposition.BackColor = Color.Yellow
                    lblDisposition.ForeColor = Color.Black
                    lblDisposition.Text += vbCrLf + Phrases(40, Language)
                    l = "Y"
                End If

                '    'Added Erick Medrano 2024-01-23
                'ElseIf s.Contains("Remove MPP:") Or s.Contains("Hold") Then
                '    If NoTag Then
                '        Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                '        lblDisposition.BackColor = Color.Orange
                '        lblDisposition.ForeColor = Color.Black
                '        lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + vbCrLf + Phrases(38, Language)
                '        l = "H"
                '    Else
                '        lblDisposition.BackColor = Color.Orange
                '        lblDisposition.ForeColor = Color.Black
                '        lblDisposition.Text += Phrases(18, Language)
                '        l = "H"
                '    End If
                '    'End Added by Erick Medrano 2024-01-23

            ElseIf PartInfo.Equals("NoComm") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Blue
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CB" + vbCrLf + Phrases(41, Language)
                    l = "B"
                Else
                    lblDisposition.BackColor = Color.Blue
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "B" + vbCrLf + Phrases(41, Language)
                    l = "B"
                End If

                'Added By Erick Medrano 2024-04-17

            ElseIf PartInfo.Equals("BadDTCs") Or PartInfo.Equals("TRQSenDTCs") Then
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                Else
                    lblDisposition.BackColor = Color.Black
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                    l = "BL"
                End If

                'ElseIf PartInfo.Contains("TRQ Sen DTCs") Then
                '    If NoTag Then
                '        Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                '        lblDisposition.BackColor = Color.Black
                '        lblDisposition.ForeColor = Color.White
                '        lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL" + vbCrLf + Phrases(43, Language)
                '        l = "BL"
                '    Else
                '        lblDisposition.BackColor = Color.Black
                '        lblDisposition.ForeColor = Color.White
                '        lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + "BL" + vbCrLf + Phrases(43, Language)
                '        l = "BL"
                '    End If
                ' End Add

                'ElseIf s.Contains("Remove MPP:") Or s.Contains("Hold") Then
                '    If NoTag Then
                '        Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                '        lblDisposition.BackColor = Color.Orange
                '        lblDisposition.ForeColor = Color.Black
                '        lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + vbCrLf + Phrases(38, Language)
                '        l = "H"
                '    Else
                '        lblDisposition.BackColor = Color.Orange
                '        lblDisposition.ForeColor = Color.Black
                '        lblDisposition.Text += vbCrLf + Phrases(18, Language)
                '        l = "H"
                '    End If

                'Else
                '    lblDisposition.BackColor = Color.Bisque
                '    lblDisposition.ForeColor = Color.Black
                '    lblDisposition.Text += vbCrLf + Phrases(37, Language)
                '    l = "H"

            Else
                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    lblDisposition.BackColor = Color.Green
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "C" + vbCrLf + Phrases(14, Language)
                    l = "C"
                Else
                    lblDisposition.BackColor = Color.Green
                    lblDisposition.ForeColor = Color.White
                    lblDisposition.Text += GetLookupValue(ACDPN(0), Loc) + vbCrLf + Phrases(14, Language)
                    'l = "C"
                End If
            End If
        End If

        If Not PrinterInfo.GMCorePN Is Nothing Then
            If PrinterInfo.GMCorePN.EndsWith("C") Then
                PrinterInfo.GMCorePN += l
                PrinterInfo.BBBCorePN += l
                Gvars.MyData.Bin += l
            End If
        End If
        ' Added Erick Medrano 2024-01-15
    End Sub

    Private Sub SetLabelColorT1XX()
        'lblDisposition.BackColor = Color.Yellow
        'lblDisposition.ForeColor = Color.Black

        Dim s As String = Gvars.MyData.Bin + "  "
        If (Gvars.MyData.HoldUnit = True) Then
            lblDisposition.BackColor = Color.Bisque
            lblDisposition.ForeColor = Color.Black
        ElseIf s = "Scrap" Then
            lblDisposition.BackColor = Color.Maroon
            lblDisposition.ForeColor = Color.Yellow
            lblDisposition.Text += vbCrLf + Phrases(39, Language)
        ElseIf s.Trim = "Hold Bin" Then
            lblDisposition.BackColor = Color.LightCyan
            lblDisposition.ForeColor = Color.Black
            lblDisposition.Text += vbCrLf + Phrases(41, Language)

        Else
            Dim i As Integer = Gvars.MyData.Bin.IndexOf("#")
            If i > 0 Then
                s = s.Substring(i + 1, 3)
                If IsNumeric(s) Then
                    Dim ii As Integer = CInt(s)
                    If (ii = 6) Or (ii = 7) Then
                        lblDisposition.BackColor = Color.Orange
                        lblDisposition.ForeColor = Color.Black
                        lblDisposition.Text += vbCrLf + Phrases(38, Language)
                    Else
                        lblDisposition.BackColor = Color.Bisque
                        lblDisposition.ForeColor = Color.Black
                        lblDisposition.Text += vbCrLf + Phrases(37, Language)
                    End If
                End If
            End If

        End If
    End Sub
#End Region
    Private Sub GetValidPNs(CorePN As String, ByRef GMPN As List(Of String), ByRef ACDPN As List(Of String), ByRef BBBPN As List(Of String))
        GMPN = New List(Of String)
        ACDPN = New List(Of String)
        BBBPN = New List(Of String)

        Dim aQuery As String = ""

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            aQuery = "SELECT [Idx],[GM_PN],[ACD_PN],[BBB_PN],[CoreNumber] FROM [EPSData].[dbo].[K2XX_AllowableCorePNs] WHERE CoreNumber =@CPN"

        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            aQuery = "SELECT [Idx],[GM_PN],[ACD_PN],[BBB_PN],[CoreNumber] FROM [EPSData].[dbo].[T1XX_AllowableCorePNs] WHERE CoreNumber =@CPN"

        Else
            MsgBox("Error reading CoreNumbers From database" + vbCrLf + "Contact developer." + vbCrLf + "Application will stop.", vbOK + vbCritical)
            End
        End If


        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, {{"@CPN", CorePN}})
        BBBLib.SQL.RunSQLQuery(ds)

        If ds.Failed Then
            MsgBox("Error reading data from database." + vbCrLf + ds.ExceptionMsg)
        Else
            Try
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                For r = 0 To dt.Rows.Count - 1
                    GMPN.Add(dt.Rows(r)("GM_PN").ToString)
                    ACDPN.Add(dt.Rows(r)("ACD_PN").ToString)
                    BBBPN.Add(dt.Rows(r)("BBB_PN").ToString)
                Next
            Catch ex As Exception
                MsgBox("Error reading data from database." + vbCrLf + ex.ToString)
            End Try

        End If
    End Sub
    Private Sub GetValidPNs2(CorePN As String, ByRef GMPN As List(Of String), ByRef ACDPN As List(Of String), ByRef BBBPN As List(Of String))
        GMPN = New List(Of String)
        ACDPN = New List(Of String)
        BBBPN = New List(Of String)

        Dim aQuery As String = ""

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            aQuery = "SELECT [GM_PN],[ACD_PN],[BBB_PN],[CoreNumber] FROM [EPSData].[dbo].[K2XX_AllowableCorePNs2] WHERE CoreNumber =@CPN"

        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            aQuery = "SELECT [GM_PN],[ACD_PN],[BBB_PN],[CoreNumber] FROM [EPSData].[dbo].[T1XX_AllowableCorePNs2] WHERE CoreNumber =@CPN"

        Else
            MsgBox("Error reading CoreNumbers From database" + vbCrLf + "Contact developer." + vbCrLf + "Application will stop.", vbOK + vbCritical)
            End
        End If

        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, {{"@CPN", CorePN}})
        BBBLib.SQL.RunSQLQuery(ds)
        If ds.Failed Then
            MsgBox("Error reading data from database." + vbCrLf + ds.ExceptionMsg)
        Else
            Try
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                For r = 0 To dt.Rows.Count - 1
                    GMPN.Add(dt.Rows(r)("GM_PN").ToString)
                    ACDPN.Add(dt.Rows(r)("ACD_PN").ToString)
                    BBBPN.Add(dt.Rows(r)("BBB_PN").ToString)
                Next
            Catch ex As Exception
                MsgBox("Error reading data from database." + vbCrLf + ex.ToString)
            End Try

        End If
    End Sub
    Private Function GetLookupValue(PN As String, ReturnColumn As Integer) As String
        '0 - BIN
        '1 - BBB Core Number
        '2 - GM / ACD #
        '3 - BBB MTR #
        '4 - C\S

        For i = 0 To BinLookup.GetUpperBound(0)
            If BinLookup(i, 2).Trim.ToUpper = PN.Trim.ToUpper Then
                Return BinLookup(i, ReturnColumn).Trim.ToUpper
            End If
        Next

        Throw New Exception("PN not found in lookup table.  PN: " + PN)
        Return ""
    End Function
    ' Added Erick Medrano 2024-01-12

    Private Function GetLookupValueBBB(CFactor As Integer, Bushing As Integer, CyberSecurity As Integer) As String

        Dim aQuery As String = ""

        aQuery = "SELECT [BuildSheet],[Bushing],[C-Factor],[CyberSecurity] [CS] FROM [EPSData].[dbo].[K2XX_PNInformation] WHERE [ProductType] = 'BBB' AND [Bushing] = @Bushing AND [C-Factor] = @CFactor AND [CyberSecurity] = @CS"

        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, {{"@Bushing", Bushing}, {"@CFactor", CFactor}, {"@CS", CyberSecurity}})
        BBBLib.SQL.RunSQLQuery(ds)
        If ds.Failed Then
            MsgBox("Error reading data from database." + vbCrLf + ds.ExceptionMsg)
        Else
            Try
                Dim dt As DataTable = ds.rtDataSet.Tables(0)
                GetLookupValueBBB = dt.Rows(0)("Buildsheet").ToString
            Catch ex As Exception
                MsgBox("Error reading data from database." + vbCrLf + ex.ToString)
            End Try

        End If

    End Function

    ' End Added Erick Medrano 2024-01-12

#End Region
    Private Sub RFIDTagNumberReceived(Data As String, RawData As String)


        Try
            If frmProcessMPPs.Visible Then
                frmProcessMPPs.RFIDScanned(Data)
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        Try
            If frmReprint.Visible Then
                frmReprint.RFIDScanned(Data)
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        Dim Sent As Boolean = False

        '
        ' Enrique Juarez
        '
        'UcRFID1.LastRFIDScanned(Data)


        If Gvars.MyData.Scan_RFID And Gvars.MyData.RFID_Acquired = False And MachineState = eMachineState.AskQuestions Then

            'If LastRFIDScanned = Data Then
            If Gvars.IsRFIDTagMarried(Data) Then
                'Dim msg As String = "This RFID tag (" + Data + ") should have been attached to the previously processed unit." + vbCrLf + vbCrLf + "Do you want to continue using this RFID tag on this unit?"
                'Dim msg As String = "This RFID tag (" + Data + ") is already married to a unit." + vbCrLf + vbCrLf + "Do you want to continue using this RFID tag on this unit?"
                Dim msg As String = Phrases(12, Language).Replace("<RFIDTag>", Data)

                If MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = vbNo Then
                    ' MessageBox.Show("Please scan a different RFID tag", "Duplicate RFID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                    msg = Phrases(13, Language)
                    MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
                    Exit Sub
                Else
                    msg = Phrases(28, Language)
                    If MessageBox.Show(msg, "Duplicate RFID", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = vbNo Then
                        Exit Sub
                    End If
                End If
                'If MsgBox(msg, vbYesNo) = vbNo Then
                '    Exit Sub
                'End If
            End If

            Dim idx As Integer = marryRFIDTag(Data)
            If idx = 0 Then Exit Sub
            Gvars.MyData.RFID_Idx = idx
            Gvars.MyData.RFID_Tag = Data
            Funcs2.UpdateCtrl(lblRFIDTag, Funcs2.eProperty.Text, Data)

            PanelRFID.BackColor = Reset_BackColor
            Gvars.MyData.RFID_Acquired = True
            LastRFIDScanned = Data
            MachineState = eMachineState.GetRFIDIdx
        End If


    End Sub
    'Private Function IsRFIDTagMarried(RFIDTag As String) As Boolean
    '    IsRFIDTagMarried = False
    '    Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "SELECT [idx] FROM [EPSData].[dbo].[K2XX_CoreSort] WHERE RFIDTag=@RFIDTag and [Status]=1", {{"@RFIDTag", RFIDTag}})
    '    BBBLib.SQL.RunSQLQuery(ds)
    '    If Not ds.Failed Then
    '        Dim dt As DataTable = ds.rtDataSet.Tables(0)
    '        IsRFIDTagMarried = (dt.Rows.Count <> 0)
    '    End If
    'End Function

    Private Function marryRFIDTag(RFIDTag As String) As Integer
        marryRFIDTag = 0
        Dim ds As BBBLib.SQL.dsDataSet

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_CoreSort_AssignRFID_w_AutoUnMarry @RFIDTag, @Product", {{"@RFIDTag", RFIDTag}, {"@Product", Gvars.MyData.ProductType}})
            'Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_CoreSort_AssignRFID @RFIDTag, @Product", {{"@RFIDTag", RFIDTag}, {"@Product", Gvars.MyData.ProductType}})

        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_T1XX_CoreSort_AssignRFID_w_AutoUnMarry @RFIDTag, @Product", {{"@RFIDTag", RFIDTag}, {"@Product", Gvars.MyData.ProductType}})

        End If


        BBBLib.SQL.RunSQLQuery(ds)
        If ds.Failed Then
            MsgBox("Error during RFID Tag Marry: " + vbCrLf + ds.ExceptionMsg)
        Else
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            If dt.Rows.Count = 1 Then
                marryRFIDTag = dt.Rows(0)("idx")
            End If
        End If

        If marryRFIDTag = 0 Then
            MsgBox("This tag is already married to a Unit.  Please pick a different tag.", vbOKOnly)
        End If
    End Function
    Private Function Get_Idx_For_Scrap() As Integer
        Get_Idx_For_Scrap = 0
        Dim ds As BBBLib.SQL.dsDataSet = Nothing

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_K2XX_CoreSort_SaveScrap @Product", {{"@Product", Gvars.MyData.ProductType}})
        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            ds = New BBBLib.SQL.dsDataSet(ConString_EPSData, "sp_T1XX_CoreSort_SaveScrap @Product", {{"@Product", Gvars.MyData.ProductType}})
        End If


        BBBLib.SQL.RunSQLQuery(ds)
        If ds.Failed Then
            MsgBox("Error getting IDX for Scrap part" + vbCrLf + ds.ExceptionMsg, vbOKOnly)
        Else
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            If dt.Rows.Count = 1 Then
                Get_Idx_For_Scrap = dt.Rows(0)("idx")
            End If
        End If

        If Get_Idx_For_Scrap = 0 Then
            MsgBox("Error getting IDX for Scrap part", vbOKOnly)
        End If
    End Function

    Private Function savedataScrap() ' Hice esta funcion para no hacer un mounstro de la funcion de savedata
        ''LITERAL CONTIENE LO MISMO NADA MAS QUE SE LE AGREGO LO DE HACERLE EL UPDATE AL STATUS PARA QUE SEA 9 

        If Gvars.MyData.HoldUnit Then
            Gvars.MyData.Bin = "Hold Unit " + Gvars.MyData.Contact + " @x" + Gvars.MyData.EXT
        End If



        Try

            Dim aQuery As String = ""
            aQuery = "UPDATE [K2XX_CoreSort] "
            aQuery += "SET [PCName]=@PCName, "
            aQuery += "[RackBarCode]=@1, "
            aQuery += "[CorePN]=@2, "
            aQuery += "[CoreSN]=@3, "
            aQuery += "[BuildDate]=@4, "
            aQuery += "[SoftwareVersion1]=@5, "
            aQuery += "[SoftwareVersion2]=@6, "
            aQuery += "[SoftwareVersion3]=@7, "
            aQuery += "[EPS_SN]=@8, "
            aQuery += "[ECU_SN]=@9, "
            aQuery += "[VIN]=@10, "
            aQuery += "[Mfg Traceability]=@11, "
            aQuery += "[SpecVersion]=@12, "
            aQuery += "[Gear SN]=@13, "
            aQuery += "[ECUHardwarePN]=@14, "
            aQuery += "[GM_PN]=@15, "
            aQuery += "[DTC_1]=@16, "
            aQuery += "[DTC_2]=@17, "
            aQuery += "[DTC_3]=@18, "
            aQuery += "[DTC_4]=@19, "
            aQuery += "[DTC_5]=@20, "
            aQuery += "[DTC_6]=@21, "
            aQuery += "[DTC_7]=@22, "
            aQuery += "[DTC_8]=@23, "
            aQuery += "[DTC_9]=@24, "
            aQuery += "[DTC_10]=@25, "
            aQuery += "[DTC_11]=@26, "
            aQuery += "[DTC_12]=@27, "
            aQuery += "[DTC_13]=@28, "
            aQuery += "[DTC_14]=@29, "
            aQuery += "[DTC_15]=@30, "
            aQuery += "[DTC_16]=@31, "
            aQuery += "[DTC_17]=@32, "
            aQuery += "[DTC_18]=@33, "
            aQuery += "[DTC_19]=@34, "
            aQuery += "[DTC_20]=@35, "
            aQuery += "[Prog Ver]=@36, "
            aQuery += "[BadDTCs]=@37, "
            aQuery += "[Torque_Sensor_DTCs]=@38, "
            aQuery += "[NoComm]=@39, "
            aQuery += "[AllGoodDTCs]=@40, "
            aQuery += "[AcceptableDTCs]=@41, "
            aQuery += "[UnacceptableDTCs]=@42, "
            aQuery += "[BrokenHousing]=@43, "
            aQuery += "[ConnectorsBroken]=@44, "
            aQuery += "[CorrosionPinion]=@45, "
            aQuery += "[BentPinion]=@46, "
            aQuery += "[ConnPinBroken]=@47, "
            aQuery += "[WaterIngressionValid]=@48, "
            aQuery += "[WaterIngression]=@49, "
            aQuery += "[GMPN]=@50, "
            aQuery += "[ACDPN]=@51, "
            aQuery += "[BBBPN]=@52, "
            aQuery += "[BIN]=@53, "
            aQuery += "[ScrapHousing]=@54, "
            aQuery += "[ScrapMotor]=@55,"
            aQuery += "[OnBlacklist_Rack]=@56,"
            aQuery += "[OnBlacklist_MPP]=@57,"
            aQuery += "[TestData]=@58,"
            aQuery += "[BillOfLading]=@59,"
            aQuery += "[BrokenHousingLoc]=@60, "
            aQuery += "[Status]=@61 "
            aQuery += "WHERE idx=@idx AND [Status]=1"

            '([RackBarCode],[CorePN],[CoreSN],[BuildDate],[SoftwareVersion1],[SoftwareVersion2],[SoftwareVersion3]"
            'aQuery += ",[EPS_SN],[ECU_SN],[VIN],[Mfg Traceability],[SpecVersion],[Gear SN],[ECUHardwarePN],[GM_PN],[DTC_1],[DTC_2],[DTC_3],[DTC_4],[DTC_5],[DTC_6],[DTC_7],[DTC_8]"
            'aQuery += ",[DTC_9],[DTC_10],[DTC_11],[DTC_12],[DTC_13],[DTC_14],[DTC_15],[DTC_16],[DTC_17],[DTC_18],[DTC_19],[DTC_20],[Prog Ver],[BadDTCs],[Torque_Sensor_DTCs],[NoComm]"
            'aQuery += ",[AllGoodDTCs],[AcceptableDTCs],[UnacceptableDTCs],[BrokenHousing],[ConnectorsBroken],[WaterIngressionValid],[WaterIngression ],[GMPN],[ACDPN],[BBBPN],[BIN])"
            'aQuery += " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,"
            'aQuery += "@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52)"

            Dim Params As Object(,) = {{"@PCName", BBBLib.Func.theComputerName},
                                       {"@1", Gvars.MyData.RackBarcode},
                                       {"@2", Gvars.MyData.CorePN},
                                       {"@3", Gvars.MyData.CoreSN},
                                       {"@4", Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")},
                                       {"@5", Gvars.MyData.SoftwareVersion1},
                                       {"@6", Gvars.MyData.SoftwareVersion2},
                                       {"@7", Gvars.MyData.SoftwareVersion3},
                                       {"@8", Gvars.MyData.EPS_SN},
                                       {"@9", Gvars.MyData.ECU_SN},
                                       {"@10", Gvars.MyData.VIN},
                                       {"@11", Gvars.MyData.ManufacturingTraceability},
                                       {"@12", Gvars.MyData.SpecVersion},
                                       {"@13", Gvars.MyData.GearSerialNumber},
                                       {"@14", Gvars.MyData.ECUHardwarePN},
                                       {"@15", Gvars.MyData.GM_PN},
                                       {"@16", Gvars.MyData.DTC1},
                                       {"@17", Gvars.MyData.DTC2},
                                       {"@18", Gvars.MyData.DTC3},
                                       {"@19", Gvars.MyData.DTC4},
                                       {"@20", Gvars.MyData.DTC5},
                                       {"@21", Gvars.MyData.DTC6},
                                       {"@22", Gvars.MyData.DTC7},
                                       {"@23", Gvars.MyData.DTC8},
                                       {"@24", Gvars.MyData.DTC9},
                                       {"@25", Gvars.MyData.DTC10},
                                       {"@26", Gvars.MyData.DTC11},
                                       {"@27", Gvars.MyData.DTC12},
                                       {"@28", Gvars.MyData.DTC13},
                                       {"@29", Gvars.MyData.DTC14},
                                       {"@30", Gvars.MyData.DTC15},
                                       {"@31", Gvars.MyData.DTC16},
                                       {"@32", Gvars.MyData.DTC17},
                                       {"@33", Gvars.MyData.DTC18},
                                       {"@34", Gvars.MyData.DTC19},
                                       {"@35", Gvars.MyData.DTC20},
                                       {"@36", Gvars.MyData.ProgVer},
                                       {"@37", Gvars.MyData.BadDTCFound.ToString},
                                       {"@38", Gvars.MyData.SpecialCaseDTCs.ToString},
                                       {"@39", Gvars.MyData.NoComm.ToString},
                                       {"@40", Gvars.MyData.AllGoodDTCs.ToString},
                                       {"@41", Gvars.MyData.AcceptableDTCs},
                                       {"@42", Gvars.MyData.UnacceptableDTCs},
                                       {"@43", Gvars.MyData.HousingBroken.ToString},
                                       {"@44", Gvars.MyData.ConnectorBroken.ToString},
                                       {"@45", Gvars.MyData.CorrosionPinion.ToString},
                                       {"@46", Gvars.MyData.BentPinion.ToString},
                                       {"@47", Gvars.MyData.ConnectorPinion.ToString},
                                       {"@48", Gvars.MyData.WaterIngressionValid.ToString},
                                       {"@49", Gvars.MyData.WaterIngression.ToString},
                                       {"@50", String.Join(",", GMPN.ToArray())},
                                       {"@51", String.Join(",", ACDPN.ToArray())},
                                       {"@52", String.Join(",", BBBPN.ToArray())},
                                       {"@53", Gvars.MyData.Bin},
                                       {"@54", Gvars.MyData.ScrapHousing.ToString},
                                       {"@55", Gvars.MyData.ScrapMotor.ToString},
                                       {"@56", Gvars.MyData.OnBlackList_Rack.ToString},
                                       {"@57", Gvars.MyData.OnBlackList_MPP.ToString},
                                       {"@58", PanelDebug.Visible},
                                       {"@59", Gvars.MyData.BoL},
                                       {"@60", Gvars.MyData.HousingBrokenLocation},
                                       {"@61", "9"},
                                       {"@idx", Gvars.MyData.RFID_Idx}}

            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Params)
            BBBLib.SQL.RunSQLQuery(ds)

            BBBLib.Log.LogMsg("Data Saved: RFID Tag (idx): BIN: " + Gvars.MyData.RFID_Tag + " (" + Gvars.MyData.RFID_Idx.ToString + ") - " + Gvars.MyData.Bin)

            If ds.Failed Then
                BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
                BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
                BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
                BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
                BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
                MsgBox("Error during save data." + vbCrLf + ds.ExceptionMsg)
            End If

        Catch ex As Exception
            BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ex.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
            BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
            BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
            BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
            MsgBox("Error Saving data Please contact Supervisor.  " + ex.ToString)
        End Try

    End Function

    Private Function savedata()

        'If (ckboxSaveDataEnabled.Checked = False) And (PanelDebug.Visible = True) Then
        'MessageBox.Show("Save Data ByPassed.", "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        'Exit Function
        'End If

        If Gvars.MyData.HoldUnit Then
            Gvars.MyData.Bin = "Hold Unit " + Gvars.MyData.Contact + " @x" + Gvars.MyData.EXT
        End If



        Try

            Dim aQuery As String = ""
            aQuery = "UPDATE [K2XX_CoreSort] "
            aQuery += "SET [PCName]=@PCName, "
            aQuery += "[RackBarCode]=@1, "
            aQuery += "[CorePN]=@2, "
            aQuery += "[CoreSN]=@3, "
            aQuery += "[BuildDate]=@4, "
            aQuery += "[SoftwareVersion1]=@5, "
            aQuery += "[SoftwareVersion2]=@6, "
            aQuery += "[SoftwareVersion3]=@7, "
            aQuery += "[EPS_SN]=@8, "
            aQuery += "[ECU_SN]=@9, "
            aQuery += "[VIN]=@10, "
            aQuery += "[Mfg Traceability]=@11, "
            aQuery += "[SpecVersion]=@12, "
            aQuery += "[Gear SN]=@13, "
            aQuery += "[ECUHardwarePN]=@14, "
            aQuery += "[GM_PN]=@15, "
            aQuery += "[DTC_1]=@16, "
            aQuery += "[DTC_2]=@17, "
            aQuery += "[DTC_3]=@18, "
            aQuery += "[DTC_4]=@19, "
            aQuery += "[DTC_5]=@20, "
            aQuery += "[DTC_6]=@21, "
            aQuery += "[DTC_7]=@22, "
            aQuery += "[DTC_8]=@23, "
            aQuery += "[DTC_9]=@24, "
            aQuery += "[DTC_10]=@25, "
            aQuery += "[DTC_11]=@26, "
            aQuery += "[DTC_12]=@27, "
            aQuery += "[DTC_13]=@28, "
            aQuery += "[DTC_14]=@29, "
            aQuery += "[DTC_15]=@30, "
            aQuery += "[DTC_16]=@31, "
            aQuery += "[DTC_17]=@32, "
            aQuery += "[DTC_18]=@33, "
            aQuery += "[DTC_19]=@34, "
            aQuery += "[DTC_20]=@35, "
            aQuery += "[Prog Ver]=@36, "
            aQuery += "[BadDTCs]=@37, "
            aQuery += "[Torque_Sensor_DTCs]=@38, "
            aQuery += "[NoComm]=@39, "
            aQuery += "[AllGoodDTCs]=@40, "
            aQuery += "[AcceptableDTCs]=@41, "
            aQuery += "[UnacceptableDTCs]=@42, "
            aQuery += "[BrokenHousing]=@43, "
            aQuery += "[ConnectorsBroken]=@44, "
            aQuery += "[CorrosionPinion]=@45, "
            aQuery += "[BentPinion]=@46, "
            aQuery += "[ConnPinBroken]=@47, "
            aQuery += "[WaterIngressionValid]=@48, "
            aQuery += "[WaterIngression]=@49, "
            aQuery += "[GMPN]=@50, "
            aQuery += "[ACDPN]=@51, "
            aQuery += "[BBBPN]=@52, "
            aQuery += "[BIN]=@53, "
            aQuery += "[ScrapHousing]=@54, "
            aQuery += "[ScrapMotor]=@55,"
            aQuery += "[OnBlacklist_Rack]=@56,"
            aQuery += "[OnBlacklist_MPP]=@57,"
            aQuery += "[TestData]=@58,"
            aQuery += "[BillOfLading]=@59,"
            aQuery += "[BrokenHousingLoc]=@60 "
            aQuery += "WHERE idx=@idx AND [Status]=1"

            '([RackBarCode],[CorePN],[CoreSN],[BuildDate],[SoftwareVersion1],[SoftwareVersion2],[SoftwareVersion3]"
            'aQuery += ",[EPS_SN],[ECU_SN],[VIN],[Mfg Traceability],[SpecVersion],[Gear SN],[ECUHardwarePN],[GM_PN],[DTC_1],[DTC_2],[DTC_3],[DTC_4],[DTC_5],[DTC_6],[DTC_7],[DTC_8]"
            'aQuery += ",[DTC_9],[DTC_10],[DTC_11],[DTC_12],[DTC_13],[DTC_14],[DTC_15],[DTC_16],[DTC_17],[DTC_18],[DTC_19],[DTC_20],[Prog Ver],[BadDTCs],[Torque_Sensor_DTCs],[NoComm]"
            'aQuery += ",[AllGoodDTCs],[AcceptableDTCs],[UnacceptableDTCs],[BrokenHousing],[ConnectorsBroken],[WaterIngressionValid],[WaterIngression ],[GMPN],[ACDPN],[BBBPN],[BIN])"
            'aQuery += " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,"
            'aQuery += "@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52)"

            Dim Params As Object(,) = {{"@PCName", BBBLib.Func.theComputerName},
                                       {"@1", Gvars.MyData.RackBarcode},
                                       {"@2", Gvars.MyData.CorePN},
                                       {"@3", Gvars.MyData.CoreSN},
                                       {"@4", Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")},
                                       {"@5", Gvars.MyData.SoftwareVersion1},
                                       {"@6", Gvars.MyData.SoftwareVersion2},
                                       {"@7", Gvars.MyData.SoftwareVersion3},
                                       {"@8", Gvars.MyData.EPS_SN},
                                       {"@9", Gvars.MyData.ECU_SN},
                                       {"@10", Gvars.MyData.VIN},
                                       {"@11", Gvars.MyData.ManufacturingTraceability},
                                       {"@12", Gvars.MyData.SpecVersion},
                                       {"@13", Gvars.MyData.GearSerialNumber},
                                       {"@14", Gvars.MyData.ECUHardwarePN},
                                       {"@15", Gvars.MyData.GM_PN},
                                       {"@16", Gvars.MyData.DTC1},
                                       {"@17", Gvars.MyData.DTC2},
                                       {"@18", Gvars.MyData.DTC3},
                                       {"@19", Gvars.MyData.DTC4},
                                       {"@20", Gvars.MyData.DTC5},
                                       {"@21", Gvars.MyData.DTC6},
                                       {"@22", Gvars.MyData.DTC7},
                                       {"@23", Gvars.MyData.DTC8},
                                       {"@24", Gvars.MyData.DTC9},
                                       {"@25", Gvars.MyData.DTC10},
                                       {"@26", Gvars.MyData.DTC11},
                                       {"@27", Gvars.MyData.DTC12},
                                       {"@28", Gvars.MyData.DTC13},
                                       {"@29", Gvars.MyData.DTC14},
                                       {"@30", Gvars.MyData.DTC15},
                                       {"@31", Gvars.MyData.DTC16},
                                       {"@32", Gvars.MyData.DTC17},
                                       {"@33", Gvars.MyData.DTC18},
                                       {"@34", Gvars.MyData.DTC19},
                                       {"@35", Gvars.MyData.DTC20},
                                       {"@36", Gvars.MyData.ProgVer},
                                       {"@37", Gvars.MyData.BadDTCFound.ToString},
                                       {"@38", Gvars.MyData.SpecialCaseDTCs.ToString},
                                       {"@39", Gvars.MyData.NoComm.ToString},
                                       {"@40", Gvars.MyData.AllGoodDTCs.ToString},
                                       {"@41", Gvars.MyData.AcceptableDTCs},
                                       {"@42", Gvars.MyData.UnacceptableDTCs},
                                       {"@43", Gvars.MyData.HousingBroken.ToString},
                                       {"@44", Gvars.MyData.ConnectorBroken.ToString},
                                       {"@45", Gvars.MyData.CorrosionPinion.ToString},
                                       {"@46", Gvars.MyData.BentPinion.ToString},
                                       {"@47", Gvars.MyData.ConnectorPinion.ToString},
                                       {"@48", Gvars.MyData.WaterIngressionValid.ToString},
                                       {"@49", Gvars.MyData.WaterIngression.ToString},
                                       {"@50", String.Join(",", GMPN.ToArray())},
                                       {"@51", String.Join(",", ACDPN.ToArray())},
                                       {"@52", String.Join(",", BBBPN.ToArray())},
                                       {"@53", Gvars.MyData.Bin},
                                       {"@54", Gvars.MyData.ScrapHousing.ToString},
                                       {"@55", Gvars.MyData.ScrapMotor.ToString},
                                       {"@56", Gvars.MyData.OnBlackList_Rack.ToString},
                                       {"@57", Gvars.MyData.OnBlackList_MPP.ToString},
                                       {"@58", PanelDebug.Visible},
                                       {"@59", Gvars.MyData.BoL},
                                       {"@60", Gvars.MyData.HousingBrokenLocation},
                                       {"@idx", Gvars.MyData.RFID_Idx}}

            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Params)
            BBBLib.SQL.RunSQLQuery(ds)

            BBBLib.Log.LogMsg("Data Saved: RFID Tag (idx): BIN: " + Gvars.MyData.RFID_Tag + " (" + Gvars.MyData.RFID_Idx.ToString + ") - " + Gvars.MyData.Bin)

            If ds.Failed Then
                BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
                BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
                BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
                BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
                BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
                MsgBox("Error during save data." + vbCrLf + ds.ExceptionMsg)
            End If

        Catch ex As Exception
            BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ex.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
            BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
            BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
            BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
            MsgBox("Error Saving data Please contact Supervisor.  " + ex.ToString)
        End Try

    End Function

    Private Function saveScrap_T1XX_data()
        If Gvars.MyData.HoldUnit Then
            Gvars.MyData.Bin = "Hold Unit " + Gvars.MyData.Contact + " @x" + Gvars.MyData.EXT
        End If

        Try

            Dim aQuery As String = ""
            aQuery = "UPDATE [T1XX_CoreSort] "
            aQuery += "SET [PCName]=@PCName, "
            aQuery += "[RackBarCode]=@1, "
            aQuery += "[CorePN]=@2, "
            aQuery += "[CoreSN]=@3, "
            aQuery += "[BuildDate]=@4, "

            aQuery += "[ECU_Software_Number]=@5, "
            aQuery += "[ECU_SN]=@6, "
            aQuery += "[SoftwareBuildDate]=@7, "
            aQuery += "[Cal0]=@8, "
            aQuery += "[Cal1]=@9, "
            aQuery += "[Cal2]=@10, "
            aQuery += "[BootloaderSoftwareID]=@11, "
            aQuery += "[BootloaderSoftwareVer]=@12, "
            aQuery += "[CCAHardwarePN]=@13, "

            aQuery += "[DTC_1]=@16, "
            aQuery += "[DTC_2]=@17, "
            aQuery += "[DTC_3]=@18, "
            aQuery += "[DTC_4]=@19, "
            aQuery += "[DTC_5]=@20, "
            aQuery += "[DTC_6]=@21, "
            aQuery += "[DTC_7]=@22, "
            aQuery += "[DTC_8]=@23, "
            aQuery += "[DTC_9]=@24, "
            aQuery += "[DTC_10]=@25, "
            aQuery += "[DTC_11]=@26, "
            aQuery += "[DTC_12]=@27, "
            aQuery += "[DTC_13]=@28, "
            aQuery += "[DTC_14]=@29, "
            aQuery += "[DTC_15]=@30, "
            aQuery += "[DTC_16]=@31, "
            aQuery += "[DTC_17]=@32, "
            aQuery += "[DTC_18]=@33, "
            aQuery += "[DTC_19]=@34, "
            aQuery += "[DTC_20]=@35, "
            aQuery += "[Prog Ver]=@36, "
            aQuery += "[BadDTCs]=@37, "
            aQuery += "[Torque_Sensor_DTCs]=@38, "
            aQuery += "[NoComm]=@39, "
            aQuery += "[AllGoodDTCs]=@40, "
            aQuery += "[AcceptableDTCs]=@41, "
            aQuery += "[UnacceptableDTCs]=@42, "
            aQuery += "[BrokenHousing]=@43, "
            aQuery += "[ConnectorsBroken]=@44, "
            aQuery += "[WaterIngressionValid]=@45, "
            aQuery += "[WaterIngression]=@46, "
            aQuery += "[GMPN]=@47, "
            aQuery += "[ACDPN]=@48, "
            aQuery += "[BBBPN]=@49, "
            aQuery += "[BIN]=@50, "
            aQuery += "[ScrapHousing]=@51, "
            aQuery += "[ScrapMotor]=@52,"
            aQuery += "[OnBlacklist_Rack]=@53,"
            aQuery += "[OnBlacklist_MPP]=@54,"
            aQuery += "[TestData]=@55,"
            aQuery += "[BillOfLading]=@56,"
            aQuery += "[BrokenHousingLoc]=@57, "
            aQuery += "[Status]=@58 "
            aQuery += "WHERE idx=@idx AND [Status]=1"

            '([RackBarCode],[CorePN],[CoreSN],[BuildDate],[SoftwareVersion1],[SoftwareVersion2],[SoftwareVersion3]"
            'aQuery += ",[EPS_SN],[ECU_SN],[VIN],[Mfg Traceability],[SpecVersion],[Gear SN],[ECUHardwarePN],[GM_PN],[DTC_1],[DTC_2],[DTC_3],[DTC_4],[DTC_5],[DTC_6],[DTC_7],[DTC_8]"
            'aQuery += ",[DTC_9],[DTC_10],[DTC_11],[DTC_12],[DTC_13],[DTC_14],[DTC_15],[DTC_16],[DTC_17],[DTC_18],[DTC_19],[DTC_20],[Prog Ver],[BadDTCs],[Torque_Sensor_DTCs],[NoComm]"
            'aQuery += ",[AllGoodDTCs],[AcceptableDTCs],[UnacceptableDTCs],[BrokenHousing],[ConnectorsBroken],[WaterIngressionValid],[WaterIngression ],[GMPN],[ACDPN],[BBBPN],[BIN])"
            'aQuery += " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,"
            'aQuery += "@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52)"

            Dim Params As Object(,) = {{"@PCName", BBBLib.Func.theComputerName},
                                       {"@1", Gvars.MyData.RackBarcode},
                                       {"@2", Gvars.MyData.CorePN},
                                       {"@3", Gvars.MyData.CoreSN},
                                       {"@4", Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")},
                                       {"@5", Gvars.MyData.ECU_Software_Number},
                                       {"@6", Gvars.MyData.ECU_SN},
                                       {"@7", Gvars.MyData.SoftwareBuildDate},
                                       {"@8", Gvars.MyData.Cal0},
                                       {"@9", Gvars.MyData.Cal1},
                                       {"@10", Gvars.MyData.Cal2},
                                       {"@11", Gvars.MyData.BootloaderSoftwareID},
                                       {"@12", Gvars.MyData.BootloaderSoftwareVer},
                                       {"@13", Gvars.MyData.CCAHardwarePN},
                                       {"@16", Gvars.MyData.DTC1},
                                       {"@17", Gvars.MyData.DTC2},
                                       {"@18", Gvars.MyData.DTC3},
                                       {"@19", Gvars.MyData.DTC4},
                                       {"@20", Gvars.MyData.DTC5},
                                       {"@21", Gvars.MyData.DTC6},
                                       {"@22", Gvars.MyData.DTC7},
                                       {"@23", Gvars.MyData.DTC8},
                                       {"@24", Gvars.MyData.DTC9},
                                       {"@25", Gvars.MyData.DTC10},
                                       {"@26", Gvars.MyData.DTC11},
                                       {"@27", Gvars.MyData.DTC12},
                                       {"@28", Gvars.MyData.DTC13},
                                       {"@29", Gvars.MyData.DTC14},
                                       {"@30", Gvars.MyData.DTC15},
                                       {"@31", Gvars.MyData.DTC16},
                                       {"@32", Gvars.MyData.DTC17},
                                       {"@33", Gvars.MyData.DTC18},
                                       {"@34", Gvars.MyData.DTC19},
                                       {"@35", Gvars.MyData.DTC20},
                                       {"@36", Gvars.MyData.ProgVer},
                                       {"@37", Gvars.MyData.BadDTCFound.ToString},
                                       {"@38", Gvars.MyData.SpecialCaseDTCs.ToString},
                                       {"@39", Gvars.MyData.NoComm.ToString},
                                       {"@40", Gvars.MyData.AllGoodDTCs.ToString},
                                       {"@41", Gvars.MyData.AcceptableDTCs},
                                       {"@42", Gvars.MyData.UnacceptableDTCs},
                                       {"@43", Gvars.MyData.HousingBroken.ToString},
                                       {"@44", Gvars.MyData.ConnectorBroken.ToString},
                                       {"@45", Gvars.MyData.WaterIngressionValid.ToString},
                                       {"@46", Gvars.MyData.WaterIngression.ToString},
                                       {"@47", String.Join(",", GMPN.ToArray())},
                                       {"@48", String.Join(",", ACDPN.ToArray())},
                                       {"@49", String.Join(",", BBBPN.ToArray())},
                                       {"@50", Gvars.MyData.Bin},
                                       {"@51", Gvars.MyData.ScrapHousing.ToString},
                                       {"@52", Gvars.MyData.ScrapMotor.ToString},
                                       {"@53", Gvars.MyData.OnBlackList_Rack.ToString},
                                       {"@54", Gvars.MyData.OnBlackList_MPP.ToString},
                                       {"@55", PanelDebug.Visible},
                                       {"@56", Gvars.MyData.BoL},
                                       {"@57", Gvars.MyData.HousingBrokenLocation},
                                       {"@58", "9"},
                                       {"@idx", Gvars.MyData.RFID_Idx}}

            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Params)
            BBBLib.SQL.RunSQLQuery(ds)
            BBBLib.Log.LogMsg("Data T1XX Saved: RFID Tag (idx): BIN: " + Gvars.MyData.RFID_Tag + " (" + Gvars.MyData.RFID_Idx.ToString + ") - " + Gvars.MyData.Bin)

            If ds.Failed Then
                BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
                BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
                BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
                BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
                BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
                MsgBox("Error during save data." + vbCrLf + ds.ExceptionMsg)

            End If
        Catch ex As Exception
            BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ex.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
            BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
            BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
            BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
            MsgBox("Error Saving data Please contact Supervisor.  " + ex.ToString)
        End Try
    End Function

    Private Function save_T1XX_data()

        If Gvars.MyData.HoldUnit Then
            Gvars.MyData.Bin = "Hold Unit " + Gvars.MyData.Contact + " @x" + Gvars.MyData.EXT
        End If

        Try

            Dim aQuery As String = ""
            aQuery = "UPDATE [T1XX_CoreSort] "
            aQuery += "SET [PCName]=@PCName, "
            aQuery += "[RackBarCode]=@1, "
            aQuery += "[CorePN]=@2, "
            aQuery += "[CoreSN]=@3, "
            aQuery += "[BuildDate]=@4, "

            aQuery += "[ECU_Software_Number]=@5, "
            aQuery += "[ECU_SN]=@6, "
            aQuery += "[SoftwareBuildDate]=@7, "
            aQuery += "[Cal0]=@8, "
            aQuery += "[Cal1]=@9, "
            aQuery += "[Cal2]=@10, "
            aQuery += "[BootloaderSoftwareID]=@11, "
            aQuery += "[BootloaderSoftwareVer]=@12, "
            aQuery += "[CCAHardwarePN]=@13, "

            aQuery += "[DTC_1]=@16, "
            aQuery += "[DTC_2]=@17, "
            aQuery += "[DTC_3]=@18, "
            aQuery += "[DTC_4]=@19, "
            aQuery += "[DTC_5]=@20, "
            aQuery += "[DTC_6]=@21, "
            aQuery += "[DTC_7]=@22, "
            aQuery += "[DTC_8]=@23, "
            aQuery += "[DTC_9]=@24, "
            aQuery += "[DTC_10]=@25, "
            aQuery += "[DTC_11]=@26, "
            aQuery += "[DTC_12]=@27, "
            aQuery += "[DTC_13]=@28, "
            aQuery += "[DTC_14]=@29, "
            aQuery += "[DTC_15]=@30, "
            aQuery += "[DTC_16]=@31, "
            aQuery += "[DTC_17]=@32, "
            aQuery += "[DTC_18]=@33, "
            aQuery += "[DTC_19]=@34, "
            aQuery += "[DTC_20]=@35, "
            aQuery += "[Prog Ver]=@36, "
            aQuery += "[BadDTCs]=@37, "
            aQuery += "[Torque_Sensor_DTCs]=@38, "
            aQuery += "[NoComm]=@39, "
            aQuery += "[AllGoodDTCs]=@40, "
            aQuery += "[AcceptableDTCs]=@41, "
            aQuery += "[UnacceptableDTCs]=@42, "
            aQuery += "[BrokenHousing]=@43, "
            aQuery += "[ConnectorsBroken]=@44, "
            aQuery += "[WaterIngressionValid]=@45, "
            aQuery += "[WaterIngression]=@46, "
            aQuery += "[GMPN]=@47, "
            aQuery += "[ACDPN]=@48, "
            aQuery += "[BBBPN]=@49, "
            aQuery += "[BIN]=@50, "
            aQuery += "[ScrapHousing]=@51, "
            aQuery += "[ScrapMotor]=@52,"
            aQuery += "[OnBlacklist_Rack]=@53,"
            aQuery += "[OnBlacklist_MPP]=@54,"
            aQuery += "[TestData]=@55,"
            aQuery += "[BillOfLading]=@56,"
            aQuery += "[BrokenHousingLoc]=@57 "
            aQuery += "WHERE idx=@idx AND [Status]=1"

            '([RackBarCode],[CorePN],[CoreSN],[BuildDate],[SoftwareVersion1],[SoftwareVersion2],[SoftwareVersion3]"
            'aQuery += ",[EPS_SN],[ECU_SN],[VIN],[Mfg Traceability],[SpecVersion],[Gear SN],[ECUHardwarePN],[GM_PN],[DTC_1],[DTC_2],[DTC_3],[DTC_4],[DTC_5],[DTC_6],[DTC_7],[DTC_8]"
            'aQuery += ",[DTC_9],[DTC_10],[DTC_11],[DTC_12],[DTC_13],[DTC_14],[DTC_15],[DTC_16],[DTC_17],[DTC_18],[DTC_19],[DTC_20],[Prog Ver],[BadDTCs],[Torque_Sensor_DTCs],[NoComm]"
            'aQuery += ",[AllGoodDTCs],[AcceptableDTCs],[UnacceptableDTCs],[BrokenHousing],[ConnectorsBroken],[WaterIngressionValid],[WaterIngression ],[GMPN],[ACDPN],[BBBPN],[BIN])"
            'aQuery += " VALUES (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,@24,@25,@26,@27,@28,@29,@30,@31,@32,@33,@34,@35,@36,@37,@38,@39,@40,"
            'aQuery += "@41,@42,@43,@44,@45,@46,@47,@48,@49,@50,@51,@52)"

            Dim Params As Object(,) = {{"@PCName", BBBLib.Func.theComputerName},
                                       {"@1", Gvars.MyData.RackBarcode},
                                       {"@2", Gvars.MyData.CorePN},
                                       {"@3", Gvars.MyData.CoreSN},
                                       {"@4", Gvars.MyData.RackBuildDate.ToString("yyyy-MM-dd")},
                                       {"@5", Gvars.MyData.ECU_Software_Number},
                                       {"@6", Gvars.MyData.ECU_SN},
                                       {"@7", Gvars.MyData.SoftwareBuildDate},
                                       {"@8", Gvars.MyData.Cal0},
                                       {"@9", Gvars.MyData.Cal1},
                                       {"@10", Gvars.MyData.Cal2},
                                       {"@11", Gvars.MyData.BootloaderSoftwareID},
                                       {"@12", Gvars.MyData.BootloaderSoftwareVer},
                                       {"@13", Gvars.MyData.CCAHardwarePN},
                                       {"@16", Gvars.MyData.DTC1},
                                       {"@17", Gvars.MyData.DTC2},
                                       {"@18", Gvars.MyData.DTC3},
                                       {"@19", Gvars.MyData.DTC4},
                                       {"@20", Gvars.MyData.DTC5},
                                       {"@21", Gvars.MyData.DTC6},
                                       {"@22", Gvars.MyData.DTC7},
                                       {"@23", Gvars.MyData.DTC8},
                                       {"@24", Gvars.MyData.DTC9},
                                       {"@25", Gvars.MyData.DTC10},
                                       {"@26", Gvars.MyData.DTC11},
                                       {"@27", Gvars.MyData.DTC12},
                                       {"@28", Gvars.MyData.DTC13},
                                       {"@29", Gvars.MyData.DTC14},
                                       {"@30", Gvars.MyData.DTC15},
                                       {"@31", Gvars.MyData.DTC16},
                                       {"@32", Gvars.MyData.DTC17},
                                       {"@33", Gvars.MyData.DTC18},
                                       {"@34", Gvars.MyData.DTC19},
                                       {"@35", Gvars.MyData.DTC20},
                                       {"@36", Gvars.MyData.ProgVer},
                                       {"@37", Gvars.MyData.BadDTCFound.ToString},
                                       {"@38", Gvars.MyData.SpecialCaseDTCs.ToString},
                                       {"@39", Gvars.MyData.NoComm.ToString},
                                       {"@40", Gvars.MyData.AllGoodDTCs.ToString},
                                       {"@41", Gvars.MyData.AcceptableDTCs},
                                       {"@42", Gvars.MyData.UnacceptableDTCs},
                                       {"@43", Gvars.MyData.HousingBroken.ToString},
                                       {"@44", Gvars.MyData.ConnectorBroken.ToString},
                                       {"@45", Gvars.MyData.WaterIngressionValid.ToString},
                                       {"@46", Gvars.MyData.WaterIngression.ToString},
                                       {"@47", String.Join(",", GMPN.ToArray())},
                                       {"@48", String.Join(",", ACDPN.ToArray())},
                                       {"@49", String.Join(",", BBBPN.ToArray())},
                                       {"@50", Gvars.MyData.Bin},
                                       {"@51", Gvars.MyData.ScrapHousing.ToString},
                                       {"@52", Gvars.MyData.ScrapMotor.ToString},
                                       {"@53", Gvars.MyData.OnBlackList_Rack.ToString},
                                       {"@54", Gvars.MyData.OnBlackList_MPP.ToString},
                                       {"@55", PanelDebug.Visible},
                                       {"@56", Gvars.MyData.BoL},
                                       {"@57", Gvars.MyData.HousingBrokenLocation},
                                       {"@idx", Gvars.MyData.RFID_Idx}}

            Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Params)
            BBBLib.SQL.RunSQLQuery(ds)
            BBBLib.Log.LogMsg("Data T1XX Saved: RFID Tag (idx): BIN: " + Gvars.MyData.RFID_Tag + " (" + Gvars.MyData.RFID_Idx.ToString + ") - " + Gvars.MyData.Bin)

            If ds.Failed Then
                BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ds.ExceptionMsg)
                BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
                BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
                BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
                BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
                BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
                BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
                MsgBox("Error during save data." + vbCrLf + ds.ExceptionMsg)

            End If
        Catch ex As Exception
            BBBLib.Log.LogMsg("Error Saving Data: (Exception) " + ex.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (Barcode) " + Gvars.MyData.RackBarcode)
            BBBLib.Log.LogMsg("Error Saving Data: (Core SN) " + Gvars.MyData.CoreSN)
            BBBLib.Log.LogMsg("Error Saving Data: (MPP SN) " + Gvars.MyData.ManufacturingTraceability)
            BBBLib.Log.LogMsg("Error Saving Data: (Acceptable DTCs) " + Gvars.MyData.AcceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (Uncceptable DTCs) " + Gvars.MyData.UnacceptableDTCs)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID) " + Gvars.MyData.RFID_Tag)
            BBBLib.Log.LogMsg("Error Saving Data: (RFID Idx) " + Gvars.MyData.RFID_Idx.ToString)
            BBBLib.Log.LogMsg("Error Saving Data: (BIN) " + Gvars.MyData.Bin)
            MsgBox("Error Saving data Please contact Supervisor.  " + ex.ToString)
        End Try
    End Function


    Private Function DetermineDisposition(ByRef ScrapAll As Boolean) As String
        DetermineDisposition = ""
        Dim Hold As Boolean = False
        Dim GM As Boolean = False
        Dim ACD As Boolean = False
        Dim SaveMtr As Boolean = False
        Dim Bin As String = ""
        Gvars.MyData.ScrapMotor = False
        Gvars.MyData.ScrapHousing = False
        ScrapAll = False

        If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True
        ElseIf (Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
            Hold = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
            GM = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
            GM = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            ACD = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
            GM = True
        ElseIf Gvars.MyData.HousingBroken And (Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
            Gvars.MyData.ScrapHousing = True
        Else
            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True
        End If

        'If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
        '    ScrapAll = True
        '    Gvars.MyData.ScrapHousing = True
        '    Gvars.MyData.ScrapMotor = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
        '    Hold = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    ACD = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
        '    GM = True
        'ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    Gvars.MyData.ScrapHousing = True
        'Else
        '    ScrapAll = True
        '    Gvars.MyData.ScrapHousing = True
        '    Gvars.MyData.ScrapMotor = True
        'End If
        Dim Loc As Integer = 1
        'If cboxProducts.SelectedIndex = 0 Then
        '    'GM/ACD
        '    Loc = 1
        'Else
        '    'BBB
        '    Loc = 6
        'End If

        If Hold = True Then
            'Bin = "Place RFID tag on Rack" + vbCrLf + "Place Rack in Hold Bin" + vbCrLf + GetLookupValue("Hold", 0)
            Bin = Phrases(15, Language) + vbCrLf + Phrases(17, Language) + vbCrLf + GetLookupValue("Hold", 0)
            PrinterInfo.Bin = GetLookupValue("Hold", 0)
            PrinterInfo.BBBCorePN = "Hold Bin"
            PrinterInfo.GMCorePN = ""
            Gvars.MyData.Bin = GetLookupValue("Hold", 0) + " - Hold Bin"
        ElseIf GM = True Then
            'Bin = "Place RFID tag on Rack" + vbCrLf + GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 1)
            Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 1)
            PrinterInfo.Bin = GetLookupValue(GMPN(0), 0)
            PrinterInfo.BBBCorePN = GetLookupValue(GMPN(0), 1)
            PrinterInfo.GMCorePN = GetLookupValue(GMPN(0), 5)
            Gvars.MyData.Bin = GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 1)

        ElseIf ACD = True Then
            'Bin = "Place RFID tag on MPP" + vbCrLf + GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), 1)
            Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
            PrinterInfo.Bin = GetLookupValue(ACDPN(0), 0)
            PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc)
            PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), 5)
            Gvars.MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)

        ElseIf (Gvars.MyData.ScrapHousing = True) And (Gvars.MyData.ScrapMotor = False) Then

            Dim BBBCorePN As String = GetLookupValue(GetLookupValue(ACDPN(0), 3), Loc)
            If Gvars.MyData.BadDTCFound Or Gvars.MyData.ConnectorBroken Then BBBCorePN += "H"
            'Bin = "Remove MPP from Rack, Scrap Rack" + vbCrLf + "and place RFID tag on MPP" + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            Bin = Phrases(18, Language) + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + BBBCorePN
            PrinterInfo.Bin = GetLookupValue(GetLookupValue(ACDPN(0), 3), 0)
            PrinterInfo.BBBCorePN = BBBCorePN
            'PrinterInfo.BBBCorePN = GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            'If Gvars.MyData.BadDTCFound Or Gvars.MyData.ConnectorBroken Then PrinterInfo.BBBCorePN += "H"
            PrinterInfo.GMCorePN = ""
            'MyData.Bin = "Remove MPP: " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            Gvars.MyData.Bin = "Remove MPP: " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + BBBCorePN
        ElseIf ScrapAll = True Then
            Gvars.MyData.Bin = "Scrap"
            Bin = Phrases(19, Language)
        Else
            MsgBox("Error in Desposition routine.")
            End
        End If

        DetermineDisposition = Bin
        Label7.Text = Gvars.MyData.Bin
    End Function

    Private Function DetermineDispositionIAM(ByRef ScrapAll As Boolean) As String
        DetermineDispositionIAM = ""
        Dim Hold As Boolean = False
        Dim BadDTCFound As Boolean = False
        Dim PinionBad As Boolean = False
        Dim GM As Boolean = False
        Dim ACD As Boolean = False
        Dim SaveMtr As Boolean = False
        Dim Bin As String = ""
        Gvars.MyData.ScrapMotor = False
        Gvars.MyData.ScrapHousing = False
        ScrapAll = False

        If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then

            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True
        ElseIf (Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True

            'Added by Erick Medrano 2024-01-23
            'ElseIf cboxProducts.Text = "K2XX BBB" And Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            '    GM = True
            'End Added by Erick Medrano 2024-01-23
            'Added by Erick Medrano 2024-01-23
        ElseIf cboxProducts.Text = "K2XX BBB" And Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
            BadDTCFound = True
            'End Added by Erick Medrano 2024-01-23

            'Added by Erick Medrano 2024-04-18
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.CorrosionPinion And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.CorrosionPinion And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.CorrosionPinion And Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.BentPinion And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.BentPinion And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.BentPinion And Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.ConnectorPinion And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.ConnectorPinion And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            PinionBad = True
        ElseIf cboxProducts.Text = "K2XX BBB" And Gvars.MyData.ConnectorPinion And Gvars.MyData.ConnectorBroken Then
            PinionBad = True

            'End Add
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm Then
            BadDTCFound = True

        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
            Hold = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
            BadDTCFound = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
            '    GM = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
            GM = True
            'ACD = True
            'Added by Erick Medrano 2024-01-23
            'ElseIf cboxProducts.Text = "K2XX BBB" And Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            '    GM = True
            'End Added by Erick Medrano 2024-01-23

            'Added by Erick Medrano 2024-04-18

        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            BadDTCFound = True
        ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            BadDTCFound = True
        ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs And Gvars.MyData.ConnectorBroken Then
            BadDTCFound = True



            'End Add

        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            ACD = True
        ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
            GM = True
            'ElseIf Gvars.MyData.HousingBroken And (Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
            '    Gvars.MyData.ScrapHousing = True

            'Added by Erick Medrano

        ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.SpecialCaseDTCs Then
            BadDTCFound = True
        ElseIf Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
            Gvars.MyData.ScrapHousing = True




        Else
            ScrapAll = True
            Gvars.MyData.ScrapHousing = True
            Gvars.MyData.ScrapMotor = True
        End If

        'If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
        '    ScrapAll = True
        '    Gvars.MyData.ScrapHousing = True
        '    Gvars.MyData.ScrapMotor = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
        '    Hold = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
        '    GM = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    ACD = True
        'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
        '    GM = True
        'ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
        '    Gvars.MyData.ScrapHousing = True
        'Else
        '    ScrapAll = True
        '    Gvars.MyData.ScrapHousing = True
        '    Gvars.MyData.ScrapMotor = True
        'End If
        Dim Loc As Integer = 6
        'If cboxProducts.SelectedIndex = 0 Then
        '    'GM/ACD
        '    Loc = 1
        'Else
        '    'BBB
        '    Loc = 6
        'End If

        If Hold = True Then

            If NoTag Then
                Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)

                Bin = Phrases(15, Language) + vbCrLf + "Hold Bin" + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                PrinterInfo.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH"
                PrinterInfo.BBBCorePN = "Hold Bin"
                PrinterInfo.GMCorePN = ""

                Gvars.MyData.Bin = "Hold Bin"
            Else
                'Bin = "Place RFID tag on Rack" + vbCrLf + "Place Rack in Hold Bin" + vbCrLf + GetLookupValue("Hold", 0)
                'Bin = Phrases(15, Language) + vbCrLf + Phrases(17, Language) + vbCrLf + GetLookupValue("Hold", 0)
                'Bin = Phrases(15, Language) + vbCrLf + GetLookupValue("Hold", 0)
                Bin = Phrases(15, Language) + vbCrLf + "Hold Bin" + vbCrLf + GetLookupValue(GMPN(0), Loc)

                PrinterInfo.Bin = GetLookupValue("Hold", 0)
                PrinterInfo.Bin = ""

                ' Added by Enrique Juarez
                ' Change not approved by Hiram Alanis (Convert 203-0153E to 203-0166E)
                'If GMPN.Count > 1 Then
                '    If GetLookupValue(GMPN(1), Loc).StartsWith("203-0166E") Then
                '        If iSelection = -1 Then
                '            Dim strValues As String = ""

                '            For iIdx = 0 To GMPN.Count - 1
                '                strValues += (iIdx + 1) & " - " & GetLookupValue(GMPN(iIdx), Loc) & vbCrLf
                '            Next
                '            Do
                '                iSelection = Integer.Parse(InputBox(strValues, "Select an option", "1"))
                '            Loop Until iSelection > 0 And iSelection < (GMPN.Count + 1)
                '        End If
                '        PrinterInfo.Bin = GetLookupValue(GMPN(iSelection - 1), Loc)
                '        Bin = Phrases(15, Language) + vbCrLf + "Hold Bin" + vbCrLf + GetLookupValue(GMPN(iSelection - 1), Loc)
                '    Else
                '        PrinterInfo.Bin = GetLookupValue(GMPN(0), Loc)
                '    End If
                'End If
                PrinterInfo.Bin = GetLookupValue(GMPN(0), Loc)
                ' End Added
                PrinterInfo.BBBCorePN = "Hold Bin"
                PrinterInfo.GMCorePN = ""
                'MyData.Bin = GetLookupValue("Hold", 0) + " - Hold Bin"
                Gvars.MyData.Bin = "Hold Bin"
            End If
            'End If

            'If Gvars.MyData.BadDTCFound Or Gvars.MyData.NoComm Then

            '    If NoTag Then
            '        Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
            '        Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

            '        PrinterInfo.Bin = ""
            '        PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CB"
            '        PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CB"
            '        Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)
            '        ' End Added by Erick medrano 2024-01-15

            '    Else
            '        Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc)
            '        PrinterInfo.Bin = ""
            '        PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc)
            '        PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc)
            '        'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
            '        Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc)
            '    End If

        ElseIf GM = True Then

            If NoTag Then

                Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)

                Bin = Phrases(15, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                PrinterInfo.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CW"
                PrinterInfo.BBBCorePN = ""
                PrinterInfo.GMCorePN = ""
                Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CW"
            Else
                'Bin = "Place RFID tag on Rack" + vbCrLf + GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 1)
                'Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), Loc)
                'Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(GMPN(0), Loc) + "W"
                Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc) + "W"
                'PrinterInfo.Bin = GetLookupValue(GMPN(0), 0)
                PrinterInfo.Bin = ""
                'PrinterInfo.BBBCorePN = GetLookupValue(GMPN(0), Loc) + "W"
                PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc) + "W"
                'PrinterInfo.GMCorePN = GetLookupValue(GMPN(0), Loc) + "W"
                PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc) + "W"
                'MyData.Bin = GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), Loc)
                'Gvars.MyData.Bin = GetLookupValue(GMPN(0), Loc) + "W"
                Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc) + "W"
            End If

        ElseIf ACD = True Then
            'Bin = "Place RFID tag on MPP" + vbCrLf + GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), 1)
            'Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)

            ' Added by Erick medrano 2024-01-15

            If NoTag Then
                Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "C"
                PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "C"
                Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)
                ' End Added by Erick medrano 2024-01-15

            Else
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc)
                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc)
                PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc)
                'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
                Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc)
            End If

        ElseIf PinionBad = True Then

            If NoTag Then
                Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                ' End Added by Erick medrano 2024-01-15

            Else
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc) + "BL"
                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
                Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc) + "BL"
            End If

        ElseIf BadDTCFound = True Then
            If Gvars.MyData.NoComm Then

                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                    PrinterInfo.Bin = ""
                    PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH"
                    PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH"
                    Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CH"
                    ' End Added by Erick medrano 2024-01-15

                Else
                    Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc) + "H"
                    PrinterInfo.Bin = ""
                    PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc) + "H"
                    PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc) + "H"
                    'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
                    Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc) + "H"
                End If

                'Added by Erick Medrano 2024-04-18

            ElseIf Gvars.MyData.BadDTCFound Or Gvars.MyData.SpecialCaseDTCs Then

                If NoTag Then
                    Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                    Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                    PrinterInfo.Bin = ""
                    PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                    PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                    Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                    ' End Added by Erick medrano 2024-01-15

                Else
                    Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc) + "BL"
                    PrinterInfo.Bin = ""
                    PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                    PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                    'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
                    Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc) + "BL"
                End If
            End If



            'ElseIf Gvars.MyData.SpecialCaseDTCs Then
            '    If NoTag Then
            '        Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
            '        Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

            '        PrinterInfo.Bin = ""
            '        PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
            '        PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
            '        Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
            '        ' End Added by Erick medrano 2024-01-15

            '    Else
            '        Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc)
            '        PrinterInfo.Bin = ""
            '        PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc)
            '        PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc)
            '        'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
            '        Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc)
            '    End If
            ' Added by Erick Medrano 2024-04-17

            ' End Add

            'PrinterInfo.Bin = GetLookupValue(ACDPN(0), 0)


        ElseIf (Gvars.MyData.ScrapHousing = True) And (Gvars.MyData.ScrapMotor = False) Then

            ' Added by Erick Medrano 2024-04-18

            If NoTag Then
                Dim CS As Integer = IIf(dgv.Rows(0).Cells("Software_Version1").Value.ToString.StartsWith("K2xx_12"), 1, 0)
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS)

                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                PrinterInfo.GMCorePN = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                Gvars.MyData.Bin = GetLookupValueBBB(Integer.Parse(lblCFactorInfo.Text), Integer.Parse(lblBushingInfo.Text), CS) + "CBL"
                ' End Added by Erick medrano 2024-01-15

            Else
                Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc) + "BL"
                PrinterInfo.Bin = ""
                PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc) + "BL"
                'MyData.Bin = GetLookupValue(ACDPN(0), 0) + " - " + GetLookupValue(ACDPN(0), Loc)
                Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc) + "BL"
            End If

            ' End Add

            'Dim BBBCorePN As String = GetLookupValue(GetLookupValue(ACDPN(0), 3), Loc) + "C" + IIf((Gvars.MyData.BadDTCFound) Or (Gvars.MyData.ConnectorBroken), "H", "")
            ''If Gvars.MyData.BadDTCFound Or Gvars.MyData.ConnectorBroken Then BBBCorePN += "H"
            ''Bin = "Remove MPP from Rack, Scrap Rack" + vbCrLf + "and place RFID tag on MPP" + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            ''If Gvars.MyData.BadDTCFound Then BBBCorePN += "H"
            'Bin = Phrases(18, Language) + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + BBBCorePN
            'PrinterInfo.Bin = GetLookupValue(GetLookupValue(ACDPN(0), 3), 0)
            'PrinterInfo.BBBCorePN = BBBCorePN
            ''PrinterInfo.BBBCorePN = GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            ''If Gvars.MyData.BadDTCFound Or Gvars.MyData.ConnectorBroken Then PrinterInfo.BBBCorePN += "H"
            'PrinterInfo.GMCorePN = ""
            ''MyData.Bin = "Remove MPP: " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 1)
            'Gvars.MyData.Bin = "Remove MPP: " + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + BBBCorePN

        ElseIf ScrapAll = True Then
            Gvars.MyData.Bin = "Scrap"
            Bin = Phrases(19, Language)
        Else
            MsgBox("Error in Desposition routine.")
            End
        End If

        'If PrinterInfo.PartInfo <> "" Then SetLabelColorIAM(PrinterInfo.PartInfo)
        'If Bin.IndexOf("203-0") >= 0 And Not NoTag And Not Gvars.MyData.BadDTCFound Or Gvars.MyData.NoComm And Not Gvars.MyData.AcceptableDTCs Then
        '    DetermineDispositionIAM = Bin.Replace(PrinterInfo.BBBCorePN.Substring(1, 10), PrinterInfo.BBBCorePN)
        'End If

        Label7.Text = Gvars.MyData.Bin
    End Function

    Private Function GetValidPN_CS(v As String, loc As Integer) As String
        Throw New NotImplementedException()
    End Function

    Private Function T1xxDetermineDispositionOE(ByRef ScrapAll As Boolean) As String
        T1xxDetermineDispositionOE = ""
        Dim szSection As String = ""
        Dim Hold As Boolean = False
        Dim GM As Boolean = False
        Dim ACD As Boolean = False
        Dim SaveMtr As Boolean = False
        Dim Bin As String = ""
        Gvars.MyData.ScrapMotor = False
        Gvars.MyData.ScrapHousing = False
        ScrapAll = False

        Try
            szSection = "Check Unit Conditions"
            If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
                ScrapAll = True
                Gvars.MyData.ScrapHousing = True
                Gvars.MyData.ScrapMotor = True
            ElseIf (Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
                ScrapAll = True
                Gvars.MyData.ScrapHousing = True
                Gvars.MyData.ScrapMotor = True
            ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
                Hold = True
            ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
                Hold = True
            ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
                GM = True
                'ACD = True
            ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
                GM = True
                'ACD = True
            ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
                GM = True
            ElseIf Gvars.MyData.HousingBroken And (Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid) Then
                Gvars.MyData.ScrapHousing = True
            Else
                ScrapAll = True
                Gvars.MyData.ScrapHousing = True
                Gvars.MyData.ScrapMotor = True
            End If

            'If Gvars.MyData.OnBlackList_Rack Or Gvars.MyData.OnBlackList_MPP Then
            '    ScrapAll = True
            '    Gvars.MyData.ScrapHousing = True
            '    Gvars.MyData.ScrapMotor = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound And Gvars.MyData.SpecialCaseDTCs Then
            '    Hold = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.BadDTCFound Then
            '    GM = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Gvars.MyData.ConnectorBroken Then
            '    GM = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            '    ACD = True
            'ElseIf Not Gvars.MyData.HousingBroken And Gvars.MyData.NoComm And Not Gvars.MyData.WaterIngression And Gvars.MyData.WaterIngressionValid Then
            '    GM = True
            'ElseIf Gvars.MyData.HousingBroken And Gvars.MyData.AllGoodDTCs And Not Gvars.MyData.ConnectorBroken Then
            '    Gvars.MyData.ScrapHousing = True
            'Else
            '    ScrapAll = True
            '    Gvars.MyData.ScrapHousing = True
            '    Gvars.MyData.ScrapMotor = True
            'End If
            Dim Loc As Integer = 6
            'If cboxProducts.SelectedIndex = 0 Then
            '    'GM/ACD
            '    Loc = 1
            'Else
            '    'BBB
            '    Loc = 6
            'End If

            If Hold = True Then
                szSection = "Hold Unit"

                'Bin = "Place RFID tag on Rack" + vbCrLf + "Place Rack in Hold Bin" + vbCrLf + GetLookupValue("Hold", 0)
                'Bin = Phrases(15, Language) + vbCrLf + Phrases(17, Language) + vbCrLf + GetLookupValue("Hold", 0)
                'Bin = Phrases(15, Language) + vbCrLf + GetLookupValue("Hold", 0)
                'Bin = Phrases(15, Language) + vbCrLf + "Hold Bin" + vbCrLf + GetLookupValue(GMPN(0), Loc)
                Bin = Phrases(15, Language) + vbCrLf + GetLookupValue("Hold", 0) + " - Hold Bin"

                PrinterInfo.Bin = GetLookupValue("Hold", 0)
                'PrinterInfo.Bin = ""
                'PrinterInfo.Bin = GetLookupValue(GMPN(0), Loc)
                ' End Added
                PrinterInfo.BBBCorePN = "Hold Bin"
                PrinterInfo.GMCorePN = "Hold Bin"
                Gvars.MyData.Bin = "Hold Bin"
            ElseIf GM = True Then
                szSection = "GM Unit"
                'Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(GMPN(0), 0)
                'PrinterInfo.Bin = GetLookupValue(GMPN(0), 0)
                'PrinterInfo.BBBCorePN = GetLookupValue(GMPN(0), 1)
                'PrinterInfo.GMCorePN = GetLookupValue(GMPN(0), 5)
                'Gvars.MyData.Bin = GetLookupValue(GMPN(0), 0)


                Bin = Phrases(15, Language) + vbCrLf + GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 5)
                PrinterInfo.Bin = GetLookupValue(GMPN(0), 0)
                PrinterInfo.BBBCorePN = GetLookupValue(GMPN(0), 2)
                PrinterInfo.GMCorePN = GetLookupValue(GMPN(0), 5)
                Gvars.MyData.Bin = GetLookupValue(GMPN(0), 0) + " - " + GetLookupValue(GMPN(0), 5)


                'ElseIf ACD = True Then
                '    Bin = Phrases(14, Language) + vbCrLf + GetLookupValue(ACDPN(0), Loc)
                '    PrinterInfo.Bin = ""
                '    PrinterInfo.BBBCorePN = GetLookupValue(ACDPN(0), Loc)
                '    PrinterInfo.GMCorePN = GetLookupValue(ACDPN(0), Loc)
                '    Gvars.MyData.Bin = GetLookupValue(ACDPN(0), Loc)
            ElseIf (Gvars.MyData.ScrapHousing = True) And (Gvars.MyData.ScrapMotor = False) Then
                szSection = "Scrap Housing Unit"

                'Dim BBBCorePN As String = GetLookupValue(GetLookupValue(ACDPN(0), 3), Loc) + "C" + IIf((Gvars.MyData.BadDTCFound) Or (Gvars.MyData.ConnectorBroken), "H", "")
                ' Bin = Phrases(18, Language) + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0) + " - " + BBBCorePN
                'Bin = Phrases(18, Language) + vbCrLf + GetLookupValue(GetLookupValue(ACDPN(0), 3), 0)
                Bin = Phrases(18, Language) + vbCrLf + GetLookupValue(GetLookupValue("38284660C", 3), 0)
                'PrinterInfo.Bin = GetLookupValue(GetLookupValue(ACDPN(0), 3), 0)
                PrinterInfo.Bin = GetLookupValue(GetLookupValue("38284660C", 3), 0)
                'PrinterInfo.BBBCorePN = BBBCorePN
                PrinterInfo.GMCorePN = GetLookupValue("38284660C", 5)
                Gvars.MyData.Bin = "Remove MPP: " + GetLookupValue(GetLookupValue("38284660C", 3), 0) '+ " - " + BBBCorePN
            ElseIf ScrapAll = True Then
                szSection = "Scrap Unit"
                Gvars.MyData.Bin = "Scrap"
                Bin = Phrases(19, Language)
            Else
                MsgBox("Error in Desposition routine.")
                End
            End If
        Catch ex As Exception
            BBBLib.Log.LogMsg("(T1xxDetermineDispositionOE) Section: " + szSection + ". Ex: " + ex.Message)

        End Try

        T1xxDetermineDispositionOE = Bin
        Label7.Text = Gvars.MyData.Bin
    End Function

    Private Sub setPrinterVars(BinName As String, BBBCorePN As String, GMCorePN As String, RFID As String, RFIDidx As Integer)
        PrinterInfo.Variables = {{"%Bin%", BinName},
                              {"%BBBCorePN%", BBBCorePN},
                              {"%GMCorePN%", GMCorePN},
                              {"%RFID%", RFID},
                              {"%RFIDidx%", RFIDidx.ToString}}
    End Sub
    Private Sub btnClickWhenDone_Click(sender As Object, e As EventArgs) Handles btnClickWhenDone.Click
        'btnClickWhenDone.BackColor = Color.Gainsboro
        btnClickWhenDone.Visible = False
        MachineState = eMachineState.GetDisposition
    End Sub

    Private Sub PanelRFID_BackColorChanged(sender As Object, e As EventArgs) Handles PanelRFID.BackColorChanged
        PanelQ1.BackColor = Reset_BackColor
        PanelQ2.BackColor = Reset_BackColor
        PanelQ3.BackColor = Reset_BackColor
    End Sub

    Private Sub ToggleDebugModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleDebugModeToolStripMenuItem.Click
        'Dim ans As String = InputBox("Enter Password")
        'If ans = "BBBind" Then HideDebug = Not HideDebug
        If HideDebug = True Then
            Dim frm As New BBBLib.frmPassword("K2CSortDB")
            If frm.ShowDialog() = vbOK Then
                HideDebug = False
                BBBLib.Log.LogMsg("HideDebug = False")
            End If
        Else
            HideDebug = True
        End If


    End Sub

    Private FlashCounter As Integer = 0
    Private Sub tmrFlash_Tick(sender As Object, e As EventArgs) Handles tmrFlash.Tick
        If lblMessage.BackColor = Color.LightCyan Then
            lblMessage.BackColor = Color.DarkTurquoise
        Else
            lblMessage.BackColor = Color.LightCyan
        End If

        FlashCounter = FlashCounter - 1
        If FlashCounter <= 0 Then
            FlashCounter = 0
            tmrFlash.Enabled = False
        End If
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        BBBLib.Log.LogMsg("App Closing")
    End Sub

    Private Sub LanguageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LanguageToolStripMenuItem.Click
        If Language = eLanguage.English Then
            Language = eLanguage.Spanish
            LanguageToolStripMenuItem.Text = eLanguage.English.ToString
        Else
            Language = eLanguage.English
            LanguageToolStripMenuItem.Text = eLanguage.Spanish.ToString
        End If

        SetLanguage()

    End Sub

    Private EscKeyPressed As Boolean = False
    Private CtrlKeyDown As Boolean = False

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        CtrlKeyDown = (e.KeyCode = Keys.ControlKey)
        If e.KeyCode = Keys.Escape And AllowEscKeyToolStripMenuItem.Checked Then
            BBBLib.Log.LogMsg("Esc Key Pressed")
            EscKeyPressed = True
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        CtrlKeyDown = (e.KeyCode = Keys.Control)
    End Sub
    'Private AllowEscKey As Boolean = False

    Private Sub AllowEscKeyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllowEscKeyToolStripMenuItem.Click
        If AllowEscKeyToolStripMenuItem.Checked = False Then
            Dim frm As New BBBLib.frmPassword("K2CSortEsc")
            If frm.ShowDialog() = vbOK Then
                AllowEscKeyToolStripMenuItem.Checked = True
                BBBLib.Log.LogMsg("AllowEscKeyToolStripMenuItem.Checked=True")
            Else
                AllowEscKeyToolStripMenuItem.Checked = False
            End If
        Else
            AllowEscKeyToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub lblRFIDTag_MouseClick(sender As Object, e As MouseEventArgs) Handles lblRFIDTag.MouseClick

    End Sub

    Private Sub lblRFIDTag_MouseDown(sender As Object, e As MouseEventArgs) Handles lblRFIDTag.MouseDown
        If e.Button = MouseButtons.Right And CtrlKeyDown And MachineState = eMachineState.AskQuestions Then
            Dim ans As String = InputBox("Enter RFID tag#", "", "")
            ' Added by Enrique Juarez
            If BBBLib.Func.theComputerName.ToUpper.Trim = "LAP-LJUAREZ" Or
               BBBLib.Func.theComputerName.ToUpper.Trim = "LAM-LJUAREZ" Or
               BBBLib.Func.theComputerName.ToUpper.Trim = "LAM-LJUAREZ" Or
               BBBLib.Func.theComputerName.ToUpper.Trim = "LAM-DEVELOPER" Or
               BBBLib.Func.theComputerName.ToUpper.Trim = "W10ENG" Then
                RFIDTagNumberReceived(ans, ans)
            End If
        End If
    End Sub

    Private Sub btnChangeBoL_Click(sender As Object, e As EventArgs) Handles btnChangeBoL.Click
        Dim ans1 As MsgBoxResult = vbYes
        If lblBillOfLading.Text <> "" Then
            ans1 = MsgBox(Phrases(31, Language), vbYesNo)
        End If

        If ans1 = vbYes Then
            Dim msg As String = Phrases(34, Language)
            lblBillOfLading.Text = InputBox(msg, Phrases(32, Language), "")
            My.Settings.BoL = lblBillOfLading.Text
            My.Settings.Save()
        End If

        tbRackBarcode.Focus()

    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        'Try
        '    setupPrtdoc()
        '    PrtDoc.Print()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub PrintLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintLabelToolStripMenuItem.Click
        Try
            setupPrtdoc()
            PrtDoc.Print()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetupLabelPrinterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupLabelPrinterToolStripMenuItem.Click
        Dim frm As New BBB_Printing.frmSelectPrinter
        frm.ShowDialog()
    End Sub

    Private Sub lblNoCommTryNumber_Click(sender As Object, e As EventArgs) Handles lblNoCommTryNumber.Click
        If (CInt(lblNoCommTryNumber.Text) >= 1) And (MachineState = eMachineState.RunInhalePrg) Then
            Gvars.MyData.NoCommCount = (NoComCountMin - 1).ToString
            MachineState = eMachineState.ProcessFile
        End If
    End Sub

    Private Sub btnReclassify_Click(sender As Object, e As EventArgs) Handles btnReclassify.Click
        If MsgBox(Phrases(36, Language), vbYesNo) = vbYes Then
            lblBillOfLading.Text = "Reclassify"
            My.Settings.BoL = lblBillOfLading.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub ReprintLabelFromRFIDTagToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReprintLabelFromRFIDTagToolStripMenuItem.Click
        frmReprint = New frmReprintLabelsFromRFID(BinLookup, ConString)
        AddHandler frmReprint.RePrintLabel, AddressOf RePrintLabel
        frmReprint.ShowDialog()
        RemoveHandler frmReprint.RePrintLabel, AddressOf RePrintLabel
    End Sub

    Public Sub RePrintLabel(Bin As String, BBBCorePN As String, GMCorePN As String, RFID As String, RFIDidx As Integer, HasBadDTCs As String, BrokenConnector As String)

        Dim PartInfo As String = ""

        'If Bin.ToUpper.Contains("BIN # 1") Or Bin.ToUpper.Contains("BIN # 2") Then
        If HasBadDTCs.Trim.ToUpper = "TRUE" Then
            If PartInfo.Length > 0 Then PartInfo += ", "
            PartInfo += "BadDTCs"
        End If

        If BrokenConnector.Trim.ToUpper = "TRUE" Then
            If PartInfo.Length > 0 Then PartInfo += ", "
            PartInfo += "ConnBroken"
        End If

        'End If
        SetupPrintLabel()

        PrinterInfo.Bin = Bin
        If (Not BBBCorePN.Contains("H")) And (Bin.ToUpper.Contains("BIN # 1") Or Bin.ToUpper.Contains("BIN # 2")) And PartInfo.Length > 0 Then
            BBBCorePN += "H"
        End If

        PrinterInfo.BBBCorePN = BBBCorePN
        PrinterInfo.GMCorePN = GMCorePN
        PrinterInfo.RFID = RFID
        PrinterInfo.RFIDidx = RFIDidx
        PrinterInfo.PartInfo = PartInfo
        PrinterInfo.setVars()

        If BBB_Printing.K2xxCoreSortLabel.isPrinterSelected() And (Bin <> "Scrap") Then
            setupPrtdoc()
            PrtDoc.Print()
        End If
    End Sub

    Private Sub PrintScrapLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintScrapLabelToolStripMenuItem.Click

        Dim frm As New BBBLib.frmPassword("CSScrapLbl")
        If frm.ShowDialog() = vbOK Then

            SetupPrintLabel_Scrap()

            Try
                setupPrtdoc()
                PrtDoc.Print()
            Catch ex As Exception
            End Try

            SetupPrintLabel()
        End If
    End Sub

    Private Function LookupPreviousInfo(idx As Integer, Field As String) As String
        LookupPreviousInfo = ""
        Dim aQuery As String = "SELECT * FROM [EPSData].[dbo].[K2XX_CoreSort] Where [idx]=@Idx"
        Dim Params As Object(,) = {{"@Idx", idx}}
        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Params)
        BBBLib.SQL.RunSQLQuery(ds)
        If ds.rtDataSet.Tables.Count = 1 Then
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            If dt.Rows.Count = 1 Then
                Try
                    LookupPreviousInfo = dt.Rows(0)(Field).ToString()
                Catch ex As Exception
                End Try
            End If
        End If
    End Function

    Private Sub LoadCoreNumbers()
        Dim aQuery As String = ""

        If Gvars.ProductType = Gvars.eProductType.K2XX_GM__AC_Delco Or Gvars.ProductType = Gvars.eProductType.K2XX_BBB Then
            aQuery = "SELECT [CoreNumber] FROM [EPSData].[dbo].[K2XX_AllowableCorePNs2] Order by CoreNumber"

        ElseIf Gvars.ProductType = Gvars.eProductType.T1XX_GM Then
            aQuery = "SELECT [CoreNumber] FROM [EPSData].[dbo].[T1XX_AllowableCorePNs2] Order by CoreNumber"

        Else
            MsgBox("Error reading CoreNumbers From database" + vbCrLf + "Contact developer." + vbCrLf + "Application will stop.", vbOK + vbCritical)
            End
        End If

        Dim ds As New BBBLib.SQL.dsDataSet(ConString_EPSData, aQuery, Nothing)
        BBBLib.SQL.RunSQLQuery(ds)
        If ds.rtDataSet.Tables.Count = 1 Then
            Dim dt As DataTable = ds.rtDataSet.Tables(0)
            ComboBox1.Items.Clear()
            Try
                For r = 0 To dt.Rows.Count - 1
                    ComboBox1.Items.Add(dt.Rows(r)("CoreNumber").ToString())
                Next
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private frmProcessMPPs As frmProcessMPPs
    Private Sub ReProcessMPPsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReProcessMPPsToolStripMenuItem.Click
        Me.Visible = False

        frmProcessMPPs = New frmProcessMPPs
        frmProcessMPPs.Constring = ConString
        frmProcessMPPs.ShowDialog()
        frmProcessMPPs.Dispose()
        frmProcessMPPs = Nothing


        Gvars.GetDTCsForK2XX()

        Me.Visible = True


    End Sub

    Private Sub btnNoTag_Click(sender As Object, e As EventArgs) Handles btnNoTag.Click

        NoTag = True

        If lblBillOfLading.Text = "" Then
            MsgBox(Phrases(33, Language), vbOKOnly)
            MachineState = eMachineState.ClearData
        Else
            S1.ShowDialog()
            S1.Enabled = True
            PanelRB1.Enabled = False
            MachineState = eMachineState.RunInhalePrg
            PanelBushingInfo.Visible = True
            btnNoTag.Enabled = False
            Dim bol As String = lblBillOfLading.Text.Trim + Space(51)
            Gvars.MyData.BoL = bol.Substring(0, 50).Trim


        End If

    End Sub
    ' Added by Erick Medrano 2024-04-18
    Private Sub btnYes4_Click(sender As Object, e As EventArgs) Handles btnYes4.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_4"
        PanelQ4.BackColor = Reset_BackColor

        btnYes4.BackColor = ButtonColorSelected
        btnNo4.BackColor = ButtonColorUnselected
        Gvars.MyData.CorrosionPinion = True
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ5.Enabled = True
        PanelQ5.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnNo4_Click(sender As Object, e As EventArgs) Handles btnNo4.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_4"
        PanelQ4.BackColor = Reset_BackColor

        btnYes4.BackColor = ButtonColorUnselected
        btnNo4.BackColor = ButtonColorSelected
        Gvars.MyData.CorrosionPinion = False
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ5.Enabled = True
        PanelQ5.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnYes5_Click(sender As Object, e As EventArgs) Handles btnYes5.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_5"
        PanelQ5.BackColor = Reset_BackColor

        btnYes5.BackColor = ButtonColorSelected
        btnNo5.BackColor = ButtonColorUnselected
        Gvars.MyData.BentPinion = True
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ6.Enabled = True
        PanelQ6.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnNo5_Click(sender As Object, e As EventArgs) Handles btnNo5.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_5"
        PanelQ5.BackColor = Reset_BackColor

        btnYes5.BackColor = ButtonColorUnselected
        btnNo5.BackColor = ButtonColorSelected
        Gvars.MyData.BentPinion = False
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ6.Enabled = True
        PanelQ6.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnYes6_Click(sender As Object, e As EventArgs) Handles btnYes6.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "Yes_6"
        PanelQ6.BackColor = Reset_BackColor

        btnYes6.BackColor = ButtonColorSelected
        btnNo6.BackColor = ButtonColorUnselected
        Gvars.MyData.ConnectorPinion = True
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ3.Enabled = True
        PanelQ3.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub

    Private Sub btnNo6_Click(sender As Object, e As EventArgs) Handles btnNo6.Click
        If MachineState >= eMachineState.GetRFIDIdx Then Exit Sub

        ButtonClicked = "No_6"
        PanelQ6.BackColor = Reset_BackColor

        btnYes6.BackColor = ButtonColorUnselected
        btnNo6.BackColor = ButtonColorSelected
        Gvars.MyData.ConnectorPinion = False
        btnRunInhale.Enabled = False

        'If (MyData.NoComm Or Gvars.MyData.HousingBroken) And (PanelQ3.Enabled = False) Then
        'MyData.WaterIngression = False
        'MyData.WaterIngressionValid = True

        PanelQ3.Enabled = True
        PanelQ3.BackColor = HighLightBackColor

        'End If

        ClearDisposition()
    End Sub
End Class
