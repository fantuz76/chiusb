Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms




Public Class USBClass

#Region "Manager Variables"
    'property variables
    Private _baudRate As String = String.Empty
    Private _parity As String = String.Empty
    Private _stopBits As String = String.Empty
    Private _dataBits As String = String.Empty
    Private _portName As String = String.Empty
    Private _msg As String

    'global manager variables

    Private comPort As New SerialPort()
    Private write As Boolean = True
#End Region

#Region "Manager Properties"
    ''' property to hold the PortName
    ''' of our manager class
    Public Property PortName() As String
        Get
            Return _portName
        End Get
        Set(ByVal value As String)
            _portName = value
        End Set
    End Property


    ''' Property to hold the message being sent
    ''' through the serial port
    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property



#End Region

#Region "Manager Constructors"
    ''' Constructor to set the properties of our Manager Class
    Public Sub New(ByVal name As String)
        _baudRate = "9600"
        _parity = "0"
        _stopBits = "1"
        _dataBits = "8"
        _portName = name
        'now add an event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub


    Public Sub New(ByVal baud As String, ByVal par As String, ByVal sBits As String, ByVal dBits As String, ByVal name As String)
        _baudRate = baud
        _parity = par
        _stopBits = sBits
        _dataBits = dBits
        _portName = name
        'now add an event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
    End Sub


    ''' Constructor to set the properties of our
    ''' serial port communicator to nothing
    Public Sub New()
        _baudRate = "9600"
        _parity = "0"
        _stopBits = "1"
        _dataBits = "8"
        _portName = "COM1"

        'add event handler
        AddHandler comPort.DataReceived, AddressOf comPort_DataReceived
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

        _msg = msg + "" + Environment.NewLine + ""
    End Sub
#End Region

#Region "HexByteConversion"

    ''' method to convert hex string into a byte array
    Private Function HexToByte(ByVal msg As String) As Byte()
        If msg.Length Mod 2 = 0 Then
            'remove any spaces from the string
            _msg = msg
            _msg = msg.Replace(" ", "")
            'create a byte array the length of the
            'divided by 2 (Hex is 2 characters in length)
            Dim comBuffer As Byte() = New Byte(_msg.Length / 2 - 1) {}
            For i As Integer = 0 To _msg.Length - 1 Step 2
                comBuffer(i / 2) = CByte(Convert.ToByte(_msg.Substring(i, 2), 16))
            Next
            write = True
            'loop through the length of the provided string
            'convert each set of 2 characters to a byte
            'and add to the array
            'return the array
            Return comBuffer
        Else
            _msg = "Invalid format"

            write = False
            Return Nothing
        End If
    End Function

    ''' method to convert a byte array into a hex string
    Private Function ByteToHex(ByVal comByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As New StringBuilder(comByte.Length * 3)
        'loop through each byte in the array
        For Each data As Byte In comByte
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
            'convert the byte to a string and add to the stringbuilder
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function
#End Region


#Region "OpenClosePort"
    Private Function OpenPort() As Boolean
        Try
            'first check if the port is already open
            'if its open then close it
            If comPort.IsOpen = True Then
                comPort.Close()
            End If

            'set the properties of our SerialPort Object
            comPort.BaudRate = Integer.Parse(_baudRate)
            comPort.DataBits = Integer.Parse(_dataBits)
            comPort.StopBits = DirectCast([Enum].Parse(GetType(StopBits), _stopBits), StopBits)
            comPort.Parity = DirectCast([Enum].Parse(GetType(Parity), _parity), Parity)
            comPort.PortName = _portName

            'now open the port
            comPort.Open()
            'display message
            _msg = "Port opened at " + DateTime.Now + "" + Environment.NewLine + ""

            'return true
            Return True
        Catch ex As Exception

            Return False
        End Try
    End Function

    Public Sub ClosePort()
        If comPort.IsOpen Then
            _msg = "Port closed at " + DateTime.Now + "" + Environment.NewLine + ""

            comPort.Close()
        End If
    End Sub
#End Region


#Region "comPort_DataReceived"

    ''' method that will be called when theres data waiting in the buffer
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        'read data waiting in the buffer
        Dim msg As String = comPort.ReadExisting()
        'display the data to the user
        _msg = msg

    End Sub
#End Region


#Region "CmdSend"
    Public Sub SendSimpleCmd(ByVal _cmdtosend As String)


    End Sub


#End Region

End Class


