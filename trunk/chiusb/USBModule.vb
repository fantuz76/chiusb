Module USBModule
    Public Const SwVersion = "1.0"
    Public ConnectionUSB As USBClass
    'Public myIntList As InterventList
    Public ConnectionActive As Boolean

    Class OccorrenzeIntervento

        Public NumTypeInt As Byte         ' Codice
        Public StringTypeInt As String
        Public OccInt As UInt16

        Public Sub New(ByVal a As Byte, ByVal b As String, ByVal c As UInt16)
            NumTypeInt = a
            StringTypeInt = b
            OccInt = c
        End Sub

    End Class


    Public Sub CloseProgram()

    End Sub


#Region "Funzioni generiche Interventi"

    Public Function GetTypeIntStr(ByVal _typeIntnum As Byte) As String
        Dim StrToRet As String
     

        Select Case _typeIntnum
            Case 1
                StrToRet = "ON"
            Case 2
                StrToRet = "OFF"

            Case 10
                StrToRet = "Overcurrent" + " - Without Halt"
            Case 11
                StrToRet = "Overvoltage" + " - Without Halt"
            Case 12
                StrToRet = "Undervoltage" + " - Without Halt"
            Case 13
                StrToRet = "Under Load" + " - Without Halt"
            Case 14
                StrToRet = "Dry running" + " - Without Halt"
            Case 15
                StrToRet = "Over Temperature" + " - Without Halt"
            Case 16
                StrToRet = "Differential protection" + " - Without Halt"
            Case 17
                StrToRet = "Current imbalance" + " - Without Halt"
            Case 18
                StrToRet = "Asymmetry Voltages" + " - Without Halt"

            Case 10 + 10
                StrToRet = "Overcurrent" + " - System Halt"
            Case 11 + 10
                StrToRet = "Overvoltage" + " - System Halt"
            Case 12 + 10
                StrToRet = "Undervoltage" + " - System Halt"
            Case 13 + 10
                StrToRet = "Under Load" + " - System Halt"
            Case 14 + 10
                StrToRet = "Dry running" + " - System Halt"
            Case 15 + 10
                StrToRet = "Over Temperature" + " - System Halt"
            Case 16 + 10
                StrToRet = "Differential protection" + " - System Halt"
            Case 17 + 10
                StrToRet = "Current imbalance" + " - System Halt"
            Case 18 + 10
                StrToRet = "Asymmetry Voltages" + " - System Halt"

            Case Else
                StrToRet = _typeIntnum
        End Select

        Return StrToRet

    End Function
    Public Function GetHours(ByVal _totNumSec As UInt32) As UInteger
        Return _totNumSec \ 3600
    End Function

    Public Function GetMinutes(ByVal _totNumSec As UInt32) As UInteger
        Return (_totNumSec Mod 3600) \ 60
    End Function

    Public Function GetSeconds(ByVal _totNumSec As UInt32) As UInteger
        Return ((_totNumSec Mod 3600) Mod 60) \ 1
    End Function

    Public Function GetCurrent(ByVal _numToConvert As UInt16) As Double
        Return (_numToConvert / 10)
    End Function

    Public Function GetPressure(ByVal _numToConvert As UInt16) As Double
        Return (_numToConvert / 10)
    End Function

    Public Function GetCosfi(ByVal _numToConvert As Byte) As Double
        Return (_numToConvert / 100)
    End Function

#End Region
End Module
