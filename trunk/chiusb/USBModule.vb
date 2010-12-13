Module USBModule
    Public Const SwVersion = "1.0"
    Public ConnectionUSB As USBClass
    'Public myIntList As InterventList
    Public ConnectionActive As Boolean

    Public Sub CloseProgram()

    End Sub

    Public Function GetHours(ByVal _totNumSec As UInt32) As UInteger
        Return _totNumSec \ 3600
    End Function

    Public Function GetMinutes(ByVal _totNumSec As UInt32) As UInteger
        Return (_totNumSec Mod 3600) \ 60
    End Function

    Public Function GetSeconds(ByVal _totNumSec As UInt32) As UInteger
        Return ((_totNumSec Mod 3600) Mod 60)
    End Function
End Module
