Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms

Public Structure InterventSingle
    Public _intType As Byte
    Public _intTime As UInt32
    Public _intVolt1 As UInt16
    Public _intVolt2 As UInt16
    Public _intVolt3 As UInt16
    Public _intCurr1 As UInt16
    Public _intCurr2 As UInt16
    Public _intCurr3 As UInt16
    Public _intPower As UInt16
    Public _intPress As UInt16
    Public _intCosfi As Byte
    Public _intTemp As UInt16

End Structure

Public Class InterventList
    Private _SingleInt As InterventSingle()

    Public Property SingleInt As InterventSingle()
        Get
            Return _SingleInt
        End Get
        Set(ByVal value As InterventSingle())
            _SingleInt = value
        End Set
    End Property

    Public ReadOnly Property Length As UInt16
        Get
            Return _SingleInt.Length
        End Get        
    End Property


    ''' Constructor to set the properties of our    
    Public Sub New()        
        ReDim _SingleInt(-1)
    End Sub

    Public Sub ClearArrToInt()
        ReDim _SingleInt(-1)
    End Sub

    Public Function AddArrInt(ByVal _arrToParse As Byte()) As Boolean
        If _arrToParse.Length < 24 Then
            Return False
        End If

        ' Aumenta lunghezza di un campo
        ReDim Preserve _SingleInt(_SingleInt.Length)

        _SingleInt(_SingleInt.Length - 1)._intType = _arrToParse(0)
        _SingleInt(_SingleInt.Length - 1)._intTime = _arrToParse(1) * 256 ^ 3 + _arrToParse(2) * 256 ^ 2 + _arrToParse(3) * 256 ^ 1 + _arrToParse(4) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intVolt1 = _arrToParse(5) * 256 ^ 1 + _arrToParse(6) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intVolt2 = _arrToParse(7) * 256 ^ 1 + _arrToParse(8) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intVolt3 = _arrToParse(9) * 256 ^ 1 + _arrToParse(10) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intCurr1 = _arrToParse(11) * 256 ^ 1 + _arrToParse(12) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intCurr2 = _arrToParse(13) * 256 ^ 1 + _arrToParse(14) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intCurr3 = _arrToParse(15) * 256 ^ 1 + _arrToParse(16) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intPower = _arrToParse(17) * 256 ^ 1 + _arrToParse(18) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intPress = _arrToParse(19) * 256 ^ 1 + _arrToParse(20) * 256 ^ 0
        _SingleInt(_SingleInt.Length - 1)._intCosfi = _arrToParse(21)
        _SingleInt(_SingleInt.Length - 1)._intTemp = _arrToParse(22) * 256 ^ 1 + _arrToParse(23) * 256 ^ 0

        Return True
    End Function


    Private Sub SwapInterventi(ByRef _int1 As InterventSingle, ByRef _int2 As InterventSingle)
        Dim _inttmp As InterventSingle
        _inttmp = _int2
        _int2 = _int1
        _int1 = _inttmp
    End Sub

    ' Bubble Sort degli interventi in base al tempo
    Public Function SortArrIntTime() As Boolean
        Dim alto As Integer = _SingleInt.Length - 1

        While (alto > 0)
            For i As Integer = 0 To alto - 1
                If _SingleInt(i)._intTime > _SingleInt(i + 1)._intTime Then
                    SwapInterventi(_SingleInt(i), _SingleInt(i + 1))
                End If
            Next
            alto = alto - 1
        End While

        Return True
    End Function
End Class




Public Class USBClass


#Region "Manager Variables"

    Private _myint As New InterventList
    'property variables
    Private _portName As String = String.Empty
    'Private _msg As String
    Private _logWindow As Object 'Control

    'global manager variables

    Private comPort As New SerialPort()
    Private write As Boolean = True

    Private _InterventiArList()() As Byte
#End Region

#Region "Manager Properties"

    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property

    'Public Property Message() As String
    '    Get
    '        Return _msg
    '    End Get
    '    Set(ByVal value As String)
    '        DisplayLogData value
    '    End Set
    'End Property

    Public Property LogWindow() As Object
        Get
            Return _logWindow
        End Get
        Set(ByVal value As Object)
            _logWindow = value
        End Set
    End Property

    Public Property InterventiArList As Byte()()

        Get
            Return _InterventiArList
        End Get
        Set(ByVal value As Byte()())
            _InterventiArList = value
        End Set
    End Property

#End Region

#Region "Manager Constructors"
    ''' Constructor to set the properties of our Manager Class
    Public Sub New(ByVal name As String, ByVal logcontrol As Object)

        _logWindow = logcontrol
        _portName = name
        'now add an event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
        ConfigPort()
    End Sub




    ''' Constructor to set the properties of our
    ''' serial port communicator to nothing
    Public Sub New()
        _logWindow = Nothing
        _portName = "COM1"

        'add event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
        ConfigPort()
    End Sub




    Protected Overrides Sub Finalize()
        ' Destructor
        ClosePort()
    End Sub


#End Region

#Region "WriteData"
    Public Sub WriteData(ByVal msg As String)

        'first make sure the port is open
        If Not (comPort.IsOpen = True) Then
            comPort.Open()
        End If
        'send the message to the port
        comPort.Write(msg)
        'display the message

        DisplayLogData("" + Environment.NewLine + "")
    End Sub
#End Region

#Region "OtherFunctions"

    Delegate Sub LogDisplayHandler(ByVal msg As String)

    Private Sub DisplayLogData(ByVal msg As String)
        _logWindow.Invoke(New LogDisplayHandler(AddressOf LogDisplay), {msg})
    End Sub

    Private Sub LogDisplay(ByVal msg As String)
        If (TypeOf _logWindow Is TextBox) Then
            _logWindow.Text &= msg & vbCrLf
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


#Region "OpenClosePort"

    Private Function ConfigPort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'set the properties of our SerialPort Object
            comPort.BaudRate = Integer.Parse("9600")
            comPort.DataBits = Integer.Parse("8")
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), "1"), StopBits)
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), "0"), Parity)
            comPort.PortName = _portName

            comPort.WriteTimeout = 300
            comPort.ReadTimeout = 300
            'comPort.ReadBufferSize = 1

            OpenPort()
           
            'return true
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function


    Private Function OpenPort() As Boolean
        Try
            'first check if the port is already open
            If comPort.IsOpen = False Then
                comPort.Open()

                DisplayLogData("Port opened at " + DateTime.Now + "" + Environment.NewLine + "")
            End If
            Return True
        Catch ex As Exception
            DisplayLogData("Port NOT opened at " + DateTime.Now + "" + Environment.NewLine + "")

            Return False
        End Try
    End Function

    Public Sub ClosePort()
        If comPort.IsOpen Then
            'DisplayLogData "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""
            comPort.Close()
        End If
    End Sub
#End Region


#Region "comPort_DataReceived"

    ''' method that will be called when theres data waiting in the buffer
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        'read data waiting in the buffer
        'Dim msg As String = comPort.ReadExisting()
        'display the data to the user
        'DisplayLogData(msg)

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
            DisplayLogData("Send OK")

            Return True
        Catch ex As Exception
            DisplayLogData("Send FALSE " & ex.Message)

            Return False
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

            comPort.ReadTimeout = 1000
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

            If ReadOK Then
                DisplayLogData("Read OK")
            Else
                DisplayLogData("Read Error")
            End If

            Return ReadOK
        Catch ex As Exception
            DisplayLogData("Read " & CntBytes & ex.Message)


            Return False
        End Try

    End Function

    Public Function RequestError(Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As String
        Dim pkt As Byte()
        Dim ret As Byte()

        ReDim pkt(3)
        ReDim ret(0)
        pkt(0) = &H41
        pkt(1) = _typeData1
        pkt(2) = _typeData2
        If SendPkt(pkt, pkt.Length) Then
            If ReadPkt(ret) Then
                Dim strModified As String = System.Text.Encoding.ASCII.GetString(ret)
                Return strModified
            End If

        Else
            Return "ERR"
        End If

        Return "ENDING"
    End Function

    Public Function RequestHello(Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As String
        Dim pkt As Byte()
        Dim ret As Byte()

        ReDim pkt(3)
        ReDim ret(0)
        pkt(0) = &H21
        pkt(1) = _typeData1
        pkt(2) = _typeData2
        If SendPkt(pkt, pkt.Length) Then
            If ReadPkt(ret) Then
                Dim strModified As String = System.Text.Encoding.ASCII.GetString(ret)
                Return strModified
            End If

        Else
            Return "ERR"
        End If

        Return "ENDING"
    End Function



    Public Function RequestInterventi(Optional ByVal _typeData1 As Byte = 0, Optional ByVal _typeData2 As Byte = 0) As String
        Dim pkt As Byte()
        Dim ret As Byte()
        Dim cnt As Integer
        Dim LetturaOK As Boolean

        ReDim pkt(3)
        ReDim ret(0)
        pkt(0) = &H31
        pkt(1) = _typeData1
        pkt(2) = _typeData2
        cnt = 0
        LetturaOK = True
        If SendPkt(pkt, pkt.Length) Then
            _myint.ClearArrToInt()
            While LetturaOK
                LetturaOK = ReadPkt(ret)
                If LetturaOK And (ret.Length > 5) Then
                    If (ret(2) = &HFF And ret(3) = &HFF And ret(4) = &HFF) Then
                        _myint.SortArrIntTime()
                        ' fine OK                        
                        Return (" FINE numero = " & _myint.Length)


                        Exit Function
                    Else
                        _myint.AddArrInt(ret)
                    End If

                    cnt += 1
                End If
            End While

            Return "ERR"
        Else
            Return "ERR"
        End If

        Return "ENDING"
    End Function

    Private Sub ExtractPayload(ByRef _arrtoParse As Byte())

        For cnti As Integer = 0 To _arrtoParse.Length - 1

        Next

    End Sub



End Class


