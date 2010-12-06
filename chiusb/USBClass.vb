Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms




Public Class USBClass

#Region "Manager Variables"
    'property variables
    Private _portName As String = String.Empty
    'Private _msg As String
    Private _logWindow As Object 'Control

    'global manager variables

    Private comPort As New SerialPort()
    Private write As Boolean = True
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


    Private Function ReadPkt(ByRef _arrbytes As Byte()) As Boolean
        Dim _arrRead As Byte()
        Dim ReadingInProgress, ReadOK As Boolean
        Dim CntBytes, cnti, cks As Integer
        Dim NumBytesLen As Byte
        Dim payloadLen As Byte
        Try

            ReDim _arrRead(1)

            comPort.ReadTimeout = 1000
            ReadingInProgress = True
            ReadOK = False
            CntBytes = 0
            Do While ReadingInProgress
                _arrRead(CntBytes) = comPort.ReadByte
                If CntBytes = 0 Then
                    If (_arrRead(CntBytes) And &HF0) <> &H80 Then
                        ReadingInProgress = False
                    Else
                        NumBytesLen = _arrRead(CntBytes) And &H1
                    End If
                ElseIf (CntBytes = 1) And (NumBytesLen = 1) Then
                    payloadLen = _arrRead(CntBytes)

                ElseIf ((CntBytes >= NumBytesLen + 1) And (CntBytes < payloadLen + NumBytesLen + 1)) Then
                    ' Payload
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
                ReDim Preserve _arrRead(CntBytes + 1)
            Loop
            _arrbytes = _arrRead

            DisplayLogData("Read OK")
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

            While LetturaOK
                LetturaOK = ReadPkt(ret)
                If LetturaOK And (ret.Length > 5) Then
                    If (ret(2) = &HFF And ret(3) = &HFF And ret(4) = &HFF) Then
                        ' fine OK
                        Return " FINE numero = " & cnt
                        Exit Function
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

#Region "CmdSend"
    Public Sub SendSimpleCmd(ByVal _cmdtosend As String)


    End Sub


#End Region

End Class


