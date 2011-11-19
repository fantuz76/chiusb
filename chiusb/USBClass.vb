Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms



'16 bytes trasmessi per un complesso di 8K 504 registrazioni
' 1 byte = tipo intervento  all'indirizzo binario xxxx xxxx xxxx 0000
' 4 bytes = ora_minuto_secondo  xxxxx.xx.xx  (viene registrata come numero totale di secondi di funzionamento)
' 2 bytes = tensione_media 0-500V
' 1 byte = I1_rms  0-25.5A
' 1 byte = I2_rms  0-25.5A
' 1 byte = I3_rms  0-25.5A
' 2 bytes = potenza  0-10000 W
' 2 bytes = pressione  -1.0 - +50.0 Bar
' 1 byte  = cosfi convenzionale =P/(P^2+Q^2) 0-.99
' 1 byte = temperatura  0-255 °C

'nuova versione settembre -2011
'20 bytes trasmessi per un complesso di 6539 registrazioni  per 129510 bytes
' 1 byte = tipo intervento 
' 4 bytes = tempo = secondo + minuto*60 + ora*3600 + giorno*24*3600 + mese*32*24*3600 + anno*13*32*24*3600   ; valido fino al 2119
'   processo inverso:
'   anno(a partire dal 2000) = tempo/(13*32*24*3600); resto_anno = tempo - anno*(13*32*24*3600);
'   mese = resto_anno/(32*24*3600); resto_mese = resto_anno - mese*(32*24*3600)
'   giorno = resto_mese/(24*3600);  resto_giorno = resto_mese - giorno*(24*3600)
'   ora = resto_giorno/3600;  resto_ora = resto_giorno - ora*3600;
'   minuto = resto_ora/60;  resto_minuto = secondo = resto_ora - minuto*60;
' 4 bytes per le 3 tensioni: tensioni = (((V12_rms<<10)+V13_rms)<<10)+V23_rms; campo 0-1023V
' 4 bytes per le 3 correnti = (((I1<<10)+I2)<<10)+I3;  I= 0-102.3A, oppure 0-1023A
' 4 bytes = potenza_pressione_cosfi = (((potenza<<10) + pressione)<<7) +cosfi; potenza 0-327.67KW, pressione 0-102.3Bar, cosfi= 0-99
' 2 bytes = flusso
' 1 byte = temperatura  0-255 °C
Public Structure InterventSingle
    Public _intType As Byte
    Public _intTime As UInt32
    Public _intVoltAv As UInt16

    Public _intV3_rms As UInt16
    Public _intV2_rms As UInt16
    Public _intV1_rms As UInt16

    Public _intI1_rms As UInt16
    Public _intI2_rms As UInt16
    Public _intI3_rms As UInt16

    Public _intPower As UInt16
    Public _intPress As Int16
    Public _intCosfi As Byte
    Public _intTemp As Byte
    Public _intFlow As UInt16

End Structure

Public Class InterventiList
    Private _List As InterventSingle()

    Public Property IntItems As InterventSingle()
        Get
            Return _List
        End Get
        Set(ByVal value As InterventSingle())
            _List = value
        End Set
    End Property

    Public ReadOnly Property Length As UInt16
        Get
            Return _List.Length
        End Get
    End Property




    ''' Constructor to set the properties of our    
    Public Sub New()
        ReDim _List(-1)
    End Sub

    Public Sub ClearArrToInt()
        ReDim _List(-1)
    End Sub

    Public Function AddArrInt(ByVal _arrToParse As Byte()) As Boolean
        Dim numTmp As UInt32

        If _arrToParse.Length < INTERVENTO_LENGTH Then
            Return False
        End If

        ' Aumenta lunghezza di un campo
        ReDim Preserve _List(_List.Length)

        If _arrToParse(0) = 23 Then
            _arrToParse(0) = _arrToParse(0)
        End If

        If _arrToParse(0) = 22 Then
            _arrToParse(0) = _arrToParse(0)
        End If
        _List(_List.Length - 1)._intType = _arrToParse(0)
        _List(_List.Length - 1)._intTime = _arrToParse(1) * 256 ^ 3 + _arrToParse(2) * 256 ^ 2 + _arrToParse(3) * 256 ^ 1 + _arrToParse(4) * 256 ^ 0

        ''_List(_List.Length - 1)._intVoltAv = Conv_num_Int16(_arrToParse(5), _arrToParse(6))
        numTmp = _arrToParse(5) * 256 ^ 3 + _arrToParse(6) * 256 ^ 2 + _arrToParse(7) * 256 ^ 1 + _arrToParse(8) * 256 ^ 0
        _List(_List.Length - 1)._intV1_rms = (numTmp >> 20) And &H3FF   ' 10 bit
        _List(_List.Length - 1)._intV2_rms = (numTmp >> 10) And &H3FF   ' 10 bit
        _List(_List.Length - 1)._intV3_rms = numTmp And &H3FF           ' 10 bit

        numTmp = _arrToParse(9) * 256 ^ 3 + _arrToParse(10) * 256 ^ 2 + _arrToParse(11) * 256 ^ 1 + _arrToParse(12) * 256 ^ 0
        _List(_List.Length - 1)._intI1_rms = (numTmp >> 20) And &H3FF   ' 10 bit
        _List(_List.Length - 1)._intI2_rms = (numTmp >> 10) And &H3FF   ' 10 bit
        _List(_List.Length - 1)._intI3_rms = numTmp And &H3FF           ' 10 bit

        numTmp = _arrToParse(13) * 256 ^ 3 + _arrToParse(14) * 256 ^ 2 + _arrToParse(15) * 256 ^ 1 + _arrToParse(16) * 256 ^ 0
        _List(_List.Length - 1)._intPower = (numTmp >> 17) And &H7FFF   ' 15 bit
        _List(_List.Length - 1)._intPress = (numTmp >> 7) And &H3FF     ' 10 bit
        _List(_List.Length - 1)._intCosfi = numTmp And &H7F             ' 7 bit

        numTmp = _arrToParse(17) * 256 ^ 1 + _arrToParse(18) * 256 ^ 0
        _List(_List.Length - 1)._intFlow = numTmp

        _List(_List.Length - 1)._intTemp = _arrToParse(19)

        Return True
    End Function

    Public Function AddArrIntFromFile(ByVal _arrToParse As String()) As Boolean
        Dim tmpInt As Integer

        If _arrToParse.Length < INTERVENTO_LENGTH Then
            Return False
        End If

        ' Controllo che almeno i campi che interessano siano numerici, altrimenti è un file fasullo
        If Not Integer.TryParse(_arrToParse(0), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(1), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(5), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(6), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(7), tmpInt) Then Return False


        ' Aumenta lunghezza di un campo
        ReDim Preserve _List(_List.Length)

        'Public _intType As Byte
        'Public _intTime As UInt32
        'Public _intVoltAv As UInt16

        'Public _intV3_rms As UInt16
        'Public _intV2_rms As UInt16
        'Public _intV1_rms As UInt16

        'Public _intI1_rms As UInt16
        'Public _intI2_rms As UInt16
        'Public _intI3_rms As UInt16

        'Public _intPower As UInt16
        'Public _intPress As Int16
        'Public _intCosfi As Byte
        'Public _intTemp As Byte
        'Public _intFlow As UInt16

        _List(_List.Length - 1)._intType = Convert.ToByte(_arrToParse(1))
        _List(_List.Length - 1)._intTime = tempoFromDataOra(_arrToParse(3), _arrToParse(4))

        _List(_List.Length - 1)._intV1_rms = GetVoltageInv(Convert.ToInt16(_arrToParse(5)))
        _List(_List.Length - 1)._intV2_rms = GetVoltageInv(Convert.ToInt16(_arrToParse(6)))
        _List(_List.Length - 1)._intV3_rms = GetVoltageInv(Convert.ToInt16(_arrToParse(7)))

        _List(_List.Length - 1)._intI1_rms = GetCurrentInv(Convert.ToDouble(_arrToParse(8), Globalization.CultureInfo.GetCultureInfo("en-GB")))
        _List(_List.Length - 1)._intI2_rms = GetCurrentInv(Convert.ToDouble(_arrToParse(9), Globalization.CultureInfo.GetCultureInfo("en-GB")))
        _List(_List.Length - 1)._intI3_rms = GetCurrentInv(Convert.ToDouble(_arrToParse(10), Globalization.CultureInfo.GetCultureInfo("en-GB")))


        _List(_List.Length - 1)._intCosfi = GetCosfiInv(Convert.ToDouble(_arrToParse(11), Globalization.CultureInfo.GetCultureInfo("en-GB")))

        _List(_List.Length - 1)._intPower = GetPowerInv(Convert.ToDouble(_arrToParse(12), Globalization.CultureInfo.GetCultureInfo("en-GB")))

        _List(_List.Length - 1)._intPress = GetPressureInv(Convert.ToDouble(_arrToParse(13), Globalization.CultureInfo.GetCultureInfo("en-GB")))

        _List(_List.Length - 1)._intFlow = GetFlowInv(Convert.ToUInt16(_arrToParse(14)))

        _List(_List.Length - 1)._intTemp = GetTemperatureInv(Convert.ToInt32(_arrToParse(15)))


        Return True
    End Function


    Private Sub SwapInterventi(ByRef _int1 As InterventSingle, ByRef _int2 As InterventSingle)
        Dim _inttmp As InterventSingle
        _inttmp = _int2
        _int2 = _int1
        _int1 = _inttmp
    End Sub

    ' Bubble Sort degli interventi in base al tempo
    ' Se Crescente=TRUE -> ordina dal più vecchio al più recente
    Public Function SortArrIntTime(ByVal Crescente As Boolean) As Boolean
        Dim alto As Integer = _List.Length - 1

        While (alto > 0)
            For i As Integer = 0 To alto - 1
                If Crescente Then
                    If _List(i)._intTime > _List(i + 1)._intTime Then
                        SwapInterventi(_List(i), _List(i + 1))
                    End If
                Else
                    If _List(i)._intTime < _List(i + 1)._intTime Then
                        SwapInterventi(_List(i), _List(i + 1))
                    End If
                End If
            Next
            alto = alto - 1
        End While

        Return True
    End Function
End Class



Public Class USBClass
    Private Const CODE_HELLO = &H21
    Private Const CODE_REQ_INTERVENTI = &H31

#Region "Manager Variables"
    ' Property VAR    
    Private _logWindow As Object 'Control
    Private _DatiSetHello As Byte()
    Private _Matricola As UInt16
    Private _TotalTime As UInt32
    Private _OreLav As UInt32
    Private _PotNom As UInt32
    Private _CurrNom As UInt32
    Private _VoltNom As UInt32
    Private _myIntArr As New InterventiList
    Private _FwVer As UInt16
    Private _HwVer As UInt16

    'global manager variables    
    Private comPort As New SerialPort()

#End Region

#Region "Manager Properties"

    Public ReadOnly Property GetCOMName() As String
        Get            
            Return comPort.PortName
        End Get
    End Property

    Public ReadOnly Property DatiSetHello() As Byte()
        Get
            Return _DatiSetHello
        End Get
    End Property

    Public Property LogWindow() As Object
        Get
            Return _logWindow
        End Get
        Set(ByVal value As Object)
            _logWindow = value
        End Set
    End Property

    Public ReadOnly Property Matricola() As String
        Get
            Return _Matricola
        End Get
    End Property

    Public ReadOnly Property OreLav() As UInt32
        Get
            Return _OreLav
        End Get
    End Property

    Public ReadOnly Property TotalTime() As UInt32
        Get
            Return _TotalTime
        End Get
    End Property

    Public ReadOnly Property PotNom() As String
        Get
            Return _PotNom
        End Get
    End Property

    Public ReadOnly Property CurrNom() As String
        Get
            Return _CurrNom
        End Get
    End Property

    Public ReadOnly Property VoltNom() As String
        Get
            Return _VoltNom
        End Get
    End Property

    Public ReadOnly Property InterventiLetti() As InterventiList
        Get
            Return _myIntArr
        End Get
    End Property

    Public ReadOnly Property FwVer() As UInt16
        Get
            Return _FwVer
        End Get
    End Property

    Public ReadOnly Property HwVer() As UInt16
        Get
            Return _HwVer
        End Get
    End Property
#End Region

#Region "Manager Constructors"
    ''' Constructor to set the properties of our Manager Class
    Public Sub New(ByVal logcontrol As Object)
        _logWindow = logcontrol

        _OreLav = 0
        _FwVer = 0
        _HwVer = 0
        _Matricola = 0
        _PotNom = _CurrNom = _VoltNom = 0

        'now add an event handler
        'AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub

    ''' Constructor to set the properties of our serial port communicator to nothing
    Public Sub New()
        _logWindow = Nothing

        _OreLav = 0
        _FwVer = 0
        _HwVer = 0
        _Matricola = 0
        _PotNom = _CurrNom = _VoltNom = 0

        'add event handler
        'AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub

    ' Destructor
    Protected Overrides Sub Finalize()
        ForceClosePort()
    End Sub
#End Region



#Region "OtherFunctions"

    Delegate Sub LogDisplayHandler(ByVal msg As String)

    Private Sub DisplayLogData(ByVal msg As String)
        Try
            _logWindow.Invoke(New LogDisplayHandler(AddressOf LogDisplay), msg)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LogDisplay(ByVal msg As String)
        msg = DateTime.Now + " - " + msg
        If _logWindow Is Nothing Then

        ElseIf (TypeOf _logWindow Is TextBox) Then
            _logWindow.Text = _logWindow.Text + msg + Environment.NewLine
            _logWindow.SelectionStart = _logWindow.Text.Length
            _logWindow.ScrollToCaret()

        ElseIf (TypeOf _logWindow Is ListBox) Then
            _logWindow.items.add(msg)
            If _logWindow.Items.Count <> 0 Then
                _logWindow.SetSelected(_logWindow.Items.Count - 1, True)
                'This unhighlights the last line
                _logWindow.SetSelected(_logWindow.Items.Count - 1, False)
            End If
        End If

    End Sub

#End Region


#Region "OpenCloseConnect"


    Public Function ConnectDevice() As Boolean
        Dim i As Integer = 0
        Dim rep As Integer = 0
        Dim ActualPort As String
        Try

            If System.IO.Ports.SerialPort.GetPortNames.Length = 0 Then
                DisplayLogData("Impossible to Connect - No COM available")
                Return False
            End If

            If ConfigAndOpenPort(LastCOMUsed) Then
                ' HELLO
                If RequestHello() Then
                    DisplayLogData("Connection established on " + LastCOMUsed)
                    ForceClosePort()
                    Return True
                Else
                    DisplayLogData("Hello not received from " + LastCOMUsed)
                End If
            Else
                DisplayLogData("Connection not possible on " + LastCOMUsed)
            End If

            For rep = 0 To 1


                For i = 0 To System.IO.Ports.SerialPort.GetPortNames.Length - 1
                    ActualPort = System.IO.Ports.SerialPort.GetPortNames(i)
                    If ConfigAndOpenPort(ActualPort) Then
                        ' HELLO
                        If RequestHello() Then
                            DisplayLogData("Connection established on " + ActualPort)
                            ForceClosePort()
                            Return True
                        Else
                            DisplayLogData("Hello not received from " + ActualPort)
                        End If
                    Else
                        DisplayLogData("Connection not possible on " + ActualPort)
                    End If

                Next
            Next

            DisplayLogData("Impossible to Connect Device")
            ForceClosePort()
            Return False
        Catch ex As Exception
            DisplayLogData("ConnectDevice Exception= " + ex.Message)
            ForceClosePort()
            Return False

        End Try

    End Function


    Private Function ConfigAndOpenPort(ByVal _portName As String) As Boolean
        Try
            ' Se la COM non esiste esce subito
            If Not My.Computer.Ports.SerialPortNames.Contains(_portName) Then
                Return False
            End If

            ' Se comPort è aperta lo chiude
            ForceClosePort()

            'set properties
            comPort.BaudRate = Integer.Parse("9600")
            comPort.DataBits = Integer.Parse("8")
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), "1"), StopBits)
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), "0"), Parity)
            comPort.PortName = _portName

            comPort.WriteTimeout = 300
            comPort.ReadTimeout = 300


            ForceClosePort()
            Return True


        Catch ex As Exception
            DisplayLogData("Config&OpenPort Exception= " + ex.Message)
            ForceClosePort()
            Return False
        End Try
    End Function


    Public Sub ForceOpenPort()
        Try
            comPort.Open()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ForceClosePort()
        Try
            If comPort.IsOpen Then comPort.Close()
        Catch ex As Exception
        End Try
    End Sub
#End Region



    Private Function SendPkt(ByVal _arrbytes As Byte(), ByVal _lenar As Byte) As Boolean
        Dim FirstbyteToSend As Byte
        Dim ChkSum As Byte
        Dim arrSendComplete As Byte()
        Dim cntar As Byte

        Try

            ' Cancella tutto nei buffer
            comPort.DiscardInBuffer()
            comPort.DiscardOutBuffer()
            ChkSum = 0
            cntar = 0
            FirstbyteToSend = &H80
            If _lenar > 0 Then
                cntar = 2
                ReDim Preserve arrSendComplete(cntar - 1)
                FirstbyteToSend = FirstbyteToSend Or &H1
                arrSendComplete(0) = FirstbyteToSend
                arrSendComplete(1) = _lenar
                ChkSum += arrSendComplete(0)
                ChkSum += arrSendComplete(1)
            Else
                cntar = 1
                ReDim Preserve arrSendComplete(cntar - 1)
                arrSendComplete(0) = FirstbyteToSend
                ChkSum += arrSendComplete(0)
            End If



            'comPort.Write(_arrbytes, 0, _lenar)
            ReDim Preserve arrSendComplete(arrSendComplete.Length + _lenar - 1)
            For cnt = 0 To _lenar - 1
                arrSendComplete(cntar + cnt) = _arrbytes(cnt)
                ChkSum += _arrbytes(cnt)
            Next

            ReDim Preserve arrSendComplete(arrSendComplete.Length)
            arrSendComplete(cntar + _lenar) = ChkSum

            comPort.Write(arrSendComplete, 0, arrSendComplete.Length)
            'ReDim arrSendComplete(_lenar + 3)
            'comPort.Write(ChkSum)


            Return True
        Catch ex As Exception
            DisplayLogData("Send Pkt Exception= " & ex.Message)

            Return False
        Finally

        End Try

    End Function



    ' Legge il pkt ricevuto 
    Private Function ReadPkt(ByRef _arrbytes As Byte(), Optional ByVal OnlyPayload As Boolean = True) As Boolean
        Dim _arrRead As Byte()
        Dim ReadingInProgress, ReadOK As Boolean
        Dim CntBytes, cnti, cks, CntReadArray As Integer
        Dim NumBytesLen As Byte
        Dim payloadLen As Byte

        Dim byteRead As Byte

        Try
            ReDim _arrRead(-1)

            comPort.ReadTimeout = 500
            ReadingInProgress = True
            ReadOK = False
            CntReadArray = 0
            CntBytes = 0
            Do While ReadingInProgress

                byteRead = comPort.ReadByte

                ' Tutto il pkt ricevuto byte per byte viene incapsulato in _arrRead
                ReDim Preserve _arrRead(CntBytes)
                _arrRead(CntBytes) = byteRead
                If CntBytes = 0 Then
                    ' Primo byte letto
                    If (_arrRead(CntBytes) And &HF0) <> &H80 Then
                        ReadingInProgress = False
                    Else
                        NumBytesLen = _arrRead(CntBytes) And &H1
                    End If
                ElseIf (CntBytes = 1) And (NumBytesLen = 1) Then
                    ' Se sono qui c'è byte Length
                    payloadLen = _arrRead(CntBytes)

                ElseIf ((CntBytes >= NumBytesLen + 1) And (CntBytes < payloadLen + NumBytesLen + 1)) Then
                    ' Payload
                    If OnlyPayload Then
                        ' Se voglio ritornare solo il payload carico qua l'array
                        ReDim Preserve _arrbytes(CntReadArray)
                        _arrbytes(CntReadArray) = byteRead
                        CntReadArray += 1
                    End If
                ElseIf (CntBytes = payloadLen + NumBytesLen + 1) Then
                    ' CheckSum
                    cks = 0
                    For cnti = 0 To CntBytes - 1
                        cks = &HFF And (cks + _arrRead(cnti))

                    Next

                    If cks <> _arrRead(cnti) Then
                        ReadingInProgress = False
                    Else
                        ReadOK = True
                        ReadingInProgress = False
                    End If

                End If

                CntBytes += 1

            Loop

            ' Se voglio ritornare tutto il pkr ricevuto lo faccio qua
            If Not OnlyPayload Then _arrbytes = _arrRead

            'If ReadOK Then
            '    DisplayLogData("Read OK")
            'Else
            '    DisplayLogData("Read Error")
            'End If

            Return ReadOK
        Catch ex As Exception
            DisplayLogData("Read Exception=" & ex.Message)

            Return False
        Finally

        End Try

    End Function



    Public Function RequestHello() As Boolean
        Dim pkt As Byte()
        Dim ret As Byte()
        Try
            ForceOpenPort()
            ReDim pkt(0)
            ReDim ret(0)
            pkt(0) = &H21
            If SendPkt(pkt, pkt.Length) Then
                Application.DoEvents()
                If ReadPkt(ret) Then
                    If ret(0) = &H21 Then
                        _DatiSetHello = ret

                        ' Versione precedente a Settembre 2011  
                        '_Matricola = ret(1) * 256 ^ 1 + ret(2) * 256 ^ 0
                        '_TotalTime = ret(83) * 256 ^ 3 + ret(84) * 256 ^ 2 + ret(85) * 256 ^ 1 + ret(86) * 256 ^ 0
                        '_OreLav = ret(87) * 256 ^ 3 + ret(88) * 256 ^ 2 + ret(89) * 256 ^ 1 + ret(90) * 256 ^ 0

                        ' Prima versione Settembre 2011
                        '_Matricola = ret(1) * 256 ^ 1 + ret(2) * 256 ^ 0
                        '_TotalTime = ret(95) * 256 ^ 3 + ret(96) * 256 ^ 2 + ret(97) * 256 ^ 1 + ret(98) * 256 ^ 0
                        '_OreLav = ret(111) * 256 ^ 3 + ret(112) * 256 ^ 2 + ret(113) * 256 ^ 1 + ret(114) * 256 ^ 0
                        '_PotNom = ret(5) * 256 ^ 1 + ret(6) * 256 ^ 0
                        '_CurrNom = ret(51) * 256 ^ 1 + ret(52) * 256 ^ 0
                        '_VoltNom = ret(49) * 256 ^ 1 + ret(50) * 256 ^ 0

                        _Matricola = ret(1) * 256 ^ 1 + ret(2) * 256 ^ 0
                        _TotalTime = ret(95) * 256 ^ 3 + ret(96) * 256 ^ 2 + ret(97) * 256 ^ 1 + ret(98) * 256 ^ 0
                        _OreLav = ret(99) * 256 ^ 3 + ret(100) * 256 ^ 2 + ret(101) * 256 ^ 1 + ret(102) * 256 ^ 0
                        _PotNom = ret(11) * 256 ^ 1 + ret(12) * 256 ^ 0
                        _CurrNom = ret(81) * 256 ^ 1 + ret(82) * 256 ^ 0
                        _VoltNom = ret(79) * 256 ^ 1 + ret(80) * 256 ^ 0
                        ForceClosePort()
                        Return True
                    Else
                        'Return False
                    End If
                Else
                    'Return False
                End If

            Else
                'Return False
            End If
            ForceClosePort()
            Return False
        Catch ex As Exception
            DisplayLogData("RequestHello Exception= " + ex.Message)
            ForceClosePort()
            Return False
        End Try

    End Function


    Public Function CreateParHelloFromFile(ByVal _arrToParse As String()) As Boolean
        Dim tmpInt As Integer

        If _arrToParse.Length < 6 Then
            Return False
        End If

        'StToAdd = ""
        'StToAdd2 = ConnectionUSB.Matricola.ToUpper
        'StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = ConnectionUSB.TotalTime
        'StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = ConnectionUSB.OreLav
        'StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = ConnectionUSB.PotNom
        'StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = ConnectionUSB.VoltNom
        'StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = ConnectionUSB.CurrNom
        'StToAdd = StToAdd + StToAdd2


        ' Controllo che almeno i campi che interessano siano numerici, altrimenti è un file fasullo
        If Not Integer.TryParse(_arrToParse(0), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(1), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(2), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(3), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(4), tmpInt) Then Return False
        If Not Integer.TryParse(_arrToParse(5), tmpInt) Then Return False


        _Matricola = _arrToParse(0)
        _TotalTime = _arrToParse(1)
        _OreLav = _arrToParse(2)
        _PotNom = _arrToParse(3)
        _VoltNom = _arrToParse(4)
        _CurrNom = _arrToParse(5)

        Return True
    End Function





    Public Function RequestInterventi(Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As Boolean
        Dim pkt As Byte()
        Dim ret As Byte()
        Dim cnt As Integer
        Dim LetturaOK As Boolean

        Try
            ForceOpenPort()

            ReDim pkt(3)
            ReDim ret(0)
            pkt(0) = CODE_REQ_INTERVENTI
            pkt(1) = _typeData1
            pkt(2) = _typeData2
            cnt = 0
            LetturaOK = True
            If SendPkt(pkt, pkt.Length) Then
                _myIntArr.ClearArrToInt()
                While LetturaOK
                    Application.DoEvents()
                    LetturaOK = ReadPkt(ret)
                    If LetturaOK And (ret.Length > 5) Then
                        'If ret(0) >= NUM_MAX_TYPE_INT Then
                        If ret(0) = &HFF Then
                            'if ret(2) = &HFF And ret(3) = &HFF And ret(4) = &HFF And ret(5) = &HFF) Then
                            _myIntArr.SortArrIntTime(False)
                            ' fine OK

                            DisplayLogData("Read OK alarms #" + _myIntArr.Length.ToString)
                            ForceClosePort()
                            Return True

                        Else
                            _myIntArr.AddArrInt(ret)
                        End If

                        cnt += 1
                    End If
                End While

                DisplayLogData("Can't Read alarms")

            Else


            End If

            ForceClosePort()
            Return False

        Catch ex As Exception
            DisplayLogData("RequestAlarms Exception= " + ex.Message)
            ForceClosePort()
            Return False
        End Try

    End Function




    Public Function RequestInterventiFromFile(ByVal fileNameStr As String, Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As Boolean
        Dim file As System.IO.StreamReader
        Dim lineIN As String
        Dim arrReadFromFile As String()


        Try
            _myIntArr.ClearArrToInt()

            file = New System.IO.StreamReader(fileNameStr)   ' No append
            lineIN = file.ReadLine()
            Do While Not file.EndOfStream
                lineIN = file.ReadLine()
                arrReadFromFile = lineIN.Split(",")
                _myIntArr.AddArrIntFromFile(arrReadFromFile)
            Loop

            _myIntArr.SortArrIntTime(False)

            Return True

        Catch ex As Exception
            DisplayLogData("RequestAlarmsFromFile Exception= " + ex.Message)
            Return False
        End Try

    End Function


    Public Function RequestHelloFromFile(ByVal fileNameStr As String, Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As Boolean
        Dim file As System.IO.StreamReader
        Dim lineIN As String
        Dim arrReadFromFile As String()


        Try
            _myIntArr.ClearArrToInt()

            file = New System.IO.StreamReader(fileNameStr)   ' No append
            lineIN = file.ReadLine()
            arrReadFromFile = lineIN.Split(",")
            CreateParHelloFromFile(arrReadFromFile)            

            Return True

        Catch ex As Exception
            DisplayLogData("RequestHelloFromFile Exception= " + ex.Message)
            Return False
        End Try

    End Function
End Class


