﻿Module USBModule

    Public UsrAppData As String
    Public UsrDocData As String
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
                                            New IntOccur(TYPE_NOHALT_SOVRAPRESSIONE, TYPE_NOHALT_SOVRAPRESSIONE_STR), _
                                            New IntOccur(TYPE_HALT_OVERCURR, TYPE_HALT_OVERCURR_STR), _
                                            New IntOccur(TYPE_HALT_OVERVOLT, TYPE_HALT_OVERVOLT_STR), _
                                            New IntOccur(TYPE_HALT_UNDERVOLT, TYPE_HALT_UNDERVOLT_STR), _
                                            New IntOccur(TYPE_HALT_MANDATACH, TYPE_HALT_MANDATACH_STR), _
                                            New IntOccur(TYPE_HALT_DRYFUNC, TYPE_HALT_DRYFUNC_STR), _
                                            New IntOccur(TYPE_HALT_OVERTEMP, TYPE_HALT_OVERTEMP_STR), _
                                            New IntOccur(TYPE_HALT_DIFF, TYPE_HALT_DIFF_STR), _
                                            New IntOccur(TYPE_HALT_SQUILIBRIO, TYPE_HALT_SQUILIBRIO_STR), _
                                            New IntOccur(TYPE_HALT_DISSIMETRIA, TYPE_HALT_DISSIMETRIA_STR), _
                                            New IntOccur(TYPE_HALT_PRESS_SENS, TYPE_HALT_PRESS_SENS_STR), _
                                            New IntOccur(TYPE_HALT_SOVRAPRESSIONE, TYPE_HALT_SOVRAPRESSIONE_STR), _
                                            New IntOccur(TYPE_HALT_CORTO_CIRCUITO, TYPE_HALT_CORTO_CIRCUITO_STR)}

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
                Case TYPE_NOHALT_SOVRAPRESSIONE
                    Return Color.DarkSalmon


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
                Case TYPE_HALT_PRESS_SENS
                    Return Color.RosyBrown
                Case TYPE_HALT_SOVRAPRESSIONE
                    Return Color.LightSalmon
                Case TYPE_HALT_CORTO_CIRCUITO
                    Return Color.Crimson

                Case Else
                    Return (Color.Black)
            End Select
        End Function

    End Class

    Public Function ReadConfigXML(ByVal _FileNameStr As String, ByVal _Tab1 As String, ByVal _Field1 As String) As String
        Dim ds As New Data.DataSet
        Try
            ds.ReadXml(_FileNameStr)
            Return ds.Tables(_Tab1).Rows(0).Item(_Field1)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub WriteConfigXML(ByVal _FileNameStr As String, ByVal _Tab1 As String, ByVal _Field1 As String, ByVal _ValToWrite As String)
        Dim ds As New Data.DataSet
        Try
            ds.ReadXml(_FileNameStr)
            ds.Tables(_Tab1).Rows(0).Item(_Field1) = _ValToWrite
            ds.WriteXml(_FileNameStr)

        Catch ex As Exception
        End Try
    End Sub

    Public Sub CreateNewConfigXML(ByVal _FileNameStr As String)
        Dim ds As New Data.DataSet
        Try
            ds.DataSetName = "Settings"
            ds.Tables.Add("SistemaUtente")

            ds.Tables("SistemaUtente").Columns.Add("CartellaApplicazione")
            ds.Tables("SistemaUtente").Columns.Add("CartellaSaveAlarms")
            ds.Tables("SistemaUtente").Columns.Add("LastCOMUsed")

            Dim rowVals(2) As String 'Vettore che conterrà i valori da memorizzare nella riga
            rowVals(0) = Application.StartupPath
            rowVals(1) = UsrDocData
            rowVals(2) = "COM1"

            ds.Tables("SistemaUtente").Rows.Add(rowVals)

            ds.WriteXml(_FileNameStr)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CloseProgram()

    End Sub


    Public Sub Load_Parameters()

        UsrDocData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        UsrAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\" + My.Application.Info.Title
        If IO.Directory.Exists(UsrAppData) Then
            If IO.File.Exists(UsrAppData + XMLCFG) Then
                ' Esiste già il file
            Else
                ' Esisteva cartella ma non il file
                IO.File.Create(UsrAppData + XMLCFG).Close()
            End If
        Else
            ' non esiste cartella
            IO.Directory.CreateDirectory(UsrAppData)
            IO.File.Create(UsrAppData + XMLCFG).Close()

        End If

        If ReadConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaApplicazione") = "" Then
            CreateNewConfigXML(UsrAppData + XMLCFG)
        End If

        LastCOMUsed = ReadConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "LastCOMUsed")
        
    End Sub


#Region "Funzioni generiche Interventi"



    Public Function Conv_num_Int16(ByVal _n1 As Byte, ByVal _n2 As Byte) As Int16
        Dim _ar(2) As Byte
        ' inverto l'ordine perchè non è Little-Endian
        _ar(0) = _n2
        _ar(1) = _n1
        Return BitConverter.ToInt16(_ar, 0)
    End Function

    Public Function CreateLineStringIntervento(ByVal _intv As InterventSingle, ByVal _progress As UInteger, ByVal _totaleInt As UInteger) As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = (_totaleInt - _progress + 1)  'voleva numerazione inversa
        'StToAdd2 = (_progress + 1)  '.ToString("000")

        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "[" + _intv._intType.ToString + "] "
        StToAdd = StToAdd + StToAdd2.PadLeft(6)

        StToAdd2 = Intervents.GetIntStr(_intv._intType)
        StToAdd = StToAdd + StToAdd2.PadRight(28)

        StToAdd2 = GetHours(_intv._intTime).ToString + "h "
        StToAdd2 = StToAdd2 + GetMinutes(_intv._intTime).ToString("00") + "' "
        StToAdd2 = StToAdd2 + GetSeconds(_intv._intTime).ToString("00") + "'' "

        StToAdd = StToAdd + StToAdd2.PadRight(13)

        StToAdd2 = "Volt:" + GetVoltage(_intv._intVoltAv).ToString
        StToAdd = StToAdd + StToAdd2.PadRight(11)
        'StToAdd2 = "V2:" + _intv._intVolt2.ToString + "V"
        'StToAdd = StToAdd + StToAdd2.PadRight(8)
        'StToAdd2 = "V3:" + _intv._intVolt3.ToString + "V"
        'StToAdd = StToAdd + StToAdd2.PadRight(8)

        StToAdd2 = "I1:" + GetCurrent(_intv._intI1_rms).ToString("F1")
        StToAdd = StToAdd + StToAdd2.PadRight(9)
        StToAdd2 = "I2:" + GetCurrent(_intv._intI2_rms).ToString("F1")
        StToAdd = StToAdd + StToAdd2.PadRight(9)
        StToAdd2 = "I3:" + GetCurrent(_intv._intI3_rms).ToString("F1")
        StToAdd = StToAdd + StToAdd2.PadRight(9)

        StToAdd2 = "Cosfi:" + GetCosfi(_intv._intCosfi).ToString("F2") + ""
        StToAdd = StToAdd + StToAdd2.PadRight(12)

        StToAdd2 = "Power:" + GetPower(_intv._intPower).ToString
        StToAdd = StToAdd + StToAdd2.PadRight(13)

        StToAdd2 = "Pressure:" + GetPressure(_intv._intPress).ToString("F1") + " bar"
        StToAdd = StToAdd + StToAdd2.PadRight(20)



        StToAdd2 = "Temp:" + GetTemperature(_intv._intTemp).ToString + "°C"
        StToAdd = StToAdd + StToAdd2.PadRight(11)

        Return StToAdd
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

    Public Function GetVoltage(ByVal _numToConvert As Integer) As Integer
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert)
    End Function

    Public Function GetCurrent(ByVal _numToConvert As Byte) As Double
        Return (_numToConvert / 10)
    End Function

    Public Function GetPower(ByVal _numToConvert As Integer) As Integer
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert)
    End Function

    Public Function GetPressure(ByVal _numToConvert As Integer) As Double
        If _numToConvert < 0 Then Return 0
        Return (_numToConvert / 10)
    End Function

    Public Function GetCosfi(ByVal _numToConvert As Byte) As Double
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert / 100)
    End Function

    Public Function GetTemperature(ByVal _numToConvert As Byte) As Integer
        Return (_numToConvert)
    End Function
#End Region
End Module
