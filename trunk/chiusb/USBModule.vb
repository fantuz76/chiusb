Module USBModule


    Public Intervents As New InterventiTypeClass
    Public ConnectionUSB As USBClass

    Public ConnectionActive As Boolean
    Public LastCOMUsed As String

  

    Class InterventiTypeClass
        Private Structure IntOccur
            Public TypeNum As UInt16
            Public TypeOcc As UInt16
            Public TypeStr As String
            Public Sub New(ByVal a As UInt16, ByVal _st As String)
                TypeNum = a
                TypeOcc = 0
                TypeStr = _st
            End Sub
        End Structure
        ' array di struttura con 2 elementi uno è il tipo e l'altro è il numero occorrenze inizializzate a 0
        Private _ArrIntOccur() As IntOccur = {New IntOccur(TYPE_ON, TYPE_ON_STR), _
                                            New IntOccur(TYPE_OFF, TYPE_OFF_STR), _
                                            New IntOccur(TYPE_NOHALT_OVERCURR, TYPE_NOHALT_OVERCURR_STR), _
                                            New IntOccur(TYPE_NOHALT_OVERVOLT, TYPE_NOHALT_OVERVOLT_STR), _
                                            New IntOccur(TYPE_NOHALT_UNDERVOLT, TYPE_NOHALT_UNDERVOLT_STR), _
                                            New IntOccur(TYPE_NOHALT_MANDATACH, TYPE_NOHALT_MANDATACH_STR), _
                                            New IntOccur(TYPE_NOHALT_DRYFUNC, TYPE_NOHALT_DRYFUNC_STR), _
                                            New IntOccur(TYPE_NOHALT_OVERTEMP, TYPE_NOHALT_OVERTEMP_STR), _
                                            New IntOccur(TYPE_NOHALT_DIFF, TYPE_NOHALT_DIFF_STR), _
                                            New IntOccur(TYPE_NOHALT_SQUILIBRIO, TYPE_NOHALT_SQUILIBRIO_STR), _
                                            New IntOccur(TYPE_NOHALT_DISSIMETRIA, TYPE_NOHALT_DISSIMETRIA_STR), _
                                            New IntOccur(TYPE_HALT_OVERCURR, TYPE_HALT_OVERCURR_STR), _
                                            New IntOccur(TYPE_HALT_OVERVOLT, TYPE_HALT_OVERVOLT_STR), _
                                            New IntOccur(TYPE_HALT_UNDERVOLT, TYPE_HALT_UNDERVOLT_STR), _
                                            New IntOccur(TYPE_HALT_MANDATACH, TYPE_HALT_MANDATACH_STR), _
                                            New IntOccur(TYPE_HALT_DRYFUNC, TYPE_HALT_DRYFUNC_STR), _
                                            New IntOccur(TYPE_HALT_OVERTEMP, TYPE_HALT_OVERTEMP_STR), _
                                            New IntOccur(TYPE_HALT_DIFF, TYPE_HALT_DIFF_STR), _
                                            New IntOccur(TYPE_HALT_SQUILIBRIO, TYPE_HALT_SQUILIBRIO_STR), _
                                            New IntOccur(TYPE_HALT_DISSIMETRIA, TYPE_HALT_DISSIMETRIA_STR)}

        Public Sub New()
            ' Solo per controllo verifico che costante e init array siano OK
            If _ArrIntOccur.Length <> NUM_INT_TYPES Then
                MsgBox("Warning: Incopatible alarms number")
            End If
        End Sub

        Public Sub New(ByVal _ListInt As InterventiList)
            ' Solo per controllo verifico che costante e init array siano OK
            If _ArrIntOccur.Length <> NUM_INT_TYPES Then
                MsgBox("Warning: Incopatible alarms number")
            End If

            ' Imposto occorrenze interventi
            For i = 0 To _ListInt.Length - 1
                IncOcc(_ListInt.IntItems(i)._intType)
            Next
        End Sub
        Public Function GetOcc(ByVal _typeToRead As UInt16) As UInt16
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToRead Then
                    Return _ArrIntOccur(i).TypeOcc
                End If
            Next
            ' errore non trovato
            Return UInt16.MaxValue
        End Function

        Public Sub SetOcc(ByVal _typeToSet As UInt16, ByVal _valToSet As UInt16)
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToSet Then
                    _ArrIntOccur(i).TypeOcc = _valToSet
                End If
            Next
        End Sub

        Public Sub IncOcc(ByVal _typeToInc)
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToInc Then
                    _ArrIntOccur(i).TypeOcc = _ArrIntOccur(i).TypeOcc + 1
                End If
            Next
        End Sub

        Public Function GetIntStr(ByVal _typeToGetStr) As String
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToGetStr Then
                    Return _ArrIntOccur(i).TypeStr
                End If
            Next
            ' errore non trovato
            Return ""
        End Function

        Public Function TypeExist(ByVal _typeToFind) As Boolean
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToFind Then
                    Return True
                End If
            Next
            ' errore non trovato
            Return False
        End Function

        Public Function TotTipiIntervento() As UInt16
            Return _ArrIntOccur.Length
        End Function

        Public Function enumStr(ByVal _pos As Byte) As String
            Return _ArrIntOccur(_pos).TypeStr
        End Function

        Public Function enumNum(ByVal _pos As Byte) As Byte
            Return _ArrIntOccur(_pos).TypeNum
        End Function

        Public Function returnColor(ByVal _typeToFindColor) As Color
            Select Case _typeToFindColor
                Case TYPE_ON
                    Return Color.Green
                Case TYPE_OFF
                    Return Color.Red

                Case TYPE_NOHALT_OVERCURR
                    Return Color.Violet
                Case TYPE_NOHALT_OVERVOLT
                    Return Color.Brown
                Case TYPE_NOHALT_UNDERVOLT
                    Return Color.Turquoise
                Case TYPE_NOHALT_MANDATACH
                    Return Color.Pink
                Case TYPE_NOHALT_DRYFUNC
                    Return Color.SeaGreen
                Case TYPE_NOHALT_OVERTEMP
                    Return Color.Olive
                Case TYPE_NOHALT_DIFF
                    Return Color.Orange
                Case TYPE_NOHALT_SQUILIBRIO
                    Return Color.Gray
                Case TYPE_NOHALT_DISSIMETRIA
                    Return Color.Blue

                Case TYPE_HALT_OVERCURR
                    Return Color.DarkViolet
                Case TYPE_HALT_OVERVOLT
                    Return Color.SaddleBrown
                Case TYPE_HALT_UNDERVOLT
                    Return Color.DarkTurquoise
                Case TYPE_HALT_MANDATACH
                    Return Color.DeepPink
                Case TYPE_HALT_DRYFUNC
                    Return Color.DarkSeaGreen
                Case TYPE_HALT_OVERTEMP
                    Return Color.DarkOliveGreen
                Case TYPE_HALT_DIFF
                    Return Color.DarkOrange
                Case TYPE_HALT_SQUILIBRIO
                    Return Color.Black
                Case TYPE_HALT_DISSIMETRIA
                    Return Color.DarkBlue

                Case Else
                    Return (Color.Black)
            End Select
        End Function

    End Class

    Public Function ReadConfigXML(ByVal _Tab1 As String, ByVal _Field1 As String) As String
        Dim ds As New Data.DataSet
        ds.ReadXml(Application.StartupPath + "\config.xml")
        Return ds.Tables(_Tab1).Rows(0).Item(_Field1)
    End Function

    Public Sub WriteConfigXML(ByVal _Tab1 As String, ByVal _Field1 As String, ByVal _ValToWrite As String)
        Dim ds As New Data.DataSet

        ds.ReadXml(Application.StartupPath + "\config.xml")
        ds.Tables(_Tab1).Rows(0).Item(_Field1) = _ValToWrite
        ds.WriteXml(Application.StartupPath + "\config.xml")
    End Sub

    Public Sub CloseProgram()

    End Sub


#Region "Funzioni generiche Interventi"

    'Public Function GetTypeIntStr(ByVal _typeIntnum As Byte) As String
    '    Dim StrToRet As String


    '    Select Case _typeIntnum
    '        Case 1
    '            StrToRet = "ON"
    '        Case 2
    '            StrToRet = "OFF"

    '        Case 10
    '            StrToRet = "Overcurrent" + " - Without Halt"
    '        Case 11
    '            StrToRet = "Overvoltage" + " - Without Halt"
    '        Case 12
    '            StrToRet = "Undervoltage" + " - Without Halt"
    '        Case 13
    '            StrToRet = "Under Load" + " - Without Halt"
    '        Case 14
    '            StrToRet = "Dry running" + " - Without Halt"
    '        Case 15
    '            StrToRet = "Over Temperature" + " - Without Halt"
    '        Case 16
    '            StrToRet = "Differential protection" + " - Without Halt"
    '        Case 17
    '            StrToRet = "Current imbalance" + " - Without Halt"
    '        Case 18
    '            StrToRet = "Asymmetry Voltages" + " - Without Halt"

    '        Case 10 + 10
    '            StrToRet = "Overcurrent" + " - System Halt"
    '        Case 11 + 10
    '            StrToRet = "Overvoltage" + " - System Halt"
    '        Case 12 + 10
    '            StrToRet = "Undervoltage" + " - System Halt"
    '        Case 13 + 10
    '            StrToRet = "Under Load" + " - System Halt"
    '        Case 14 + 10
    '            StrToRet = "Dry running" + " - System Halt"
    '        Case 15 + 10
    '            StrToRet = "Over Temperature" + " - System Halt"
    '        Case 16 + 10
    '            StrToRet = "Differential protection" + " - System Halt"
    '        Case 17 + 10
    '            StrToRet = "Current imbalance" + " - System Halt"
    '        Case 18 + 10
    '            StrToRet = "Asymmetry Voltages" + " - System Halt"

    '        Case Else
    '            StrToRet = _typeIntnum
    '    End Select

    '    Return StrToRet

    'End Function
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
