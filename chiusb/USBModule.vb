﻿Imports System.Globalization.CultureInfo

Module USBModule
    Public Const CONNECT_NONE = 0
    Public Const CONNECT_USB = 1
    Public Const CONNECT_FILE = 2


    Public UsrAppData As String
    Public UsrDocData As String
    Public Intervents As New InterventiTypeClass
    Public ConnectionUSB As USBClass

    Public ConnectionIsActive As Boolean
    Public LastCOMUsed As String



    Class InterventiTypeClass
        Private Structure IntOccur
            Public TypeNum As UInt16
            Public TypeOcc As UInt16
            Public TypeStr As String
            Public TypeColor As Color
            Public Sub New(ByVal a As UInt16, ByVal _st As String, ByVal _col As Color)
                TypeNum = a
                TypeOcc = 0
                TypeStr = _st
                TypeColor = _col
            End Sub
        End Structure




        ' array di struttura con 2 elementi uno è il tipo e l'altro è il numero occorrenze inizializzate a 0
        Private _ArrIntOccur() As IntOccur = {New IntOccur(TYPE_CURRENT_PEAK, TYPE_CURRENT_PEAK_STR, Color.Red), _
                                            New IntOccur(TYPE_OVERVOLTAGE, TYPE_OVERVOLTAGE_STR, Color.Green), _
                                            New IntOccur(TYPE_INVERTER_TEMPER, TYPE_INVERTER_TEMPER_STR, Color.Bisque), _
                                            New IntOccur(TYPE_THERMAL_PROTECT, TYPE_THERMAL_PROTECT_STR, Color.DarkRed), _
                                            New IntOccur(TYPE_ENCODER_ERROR, TYPE_ENCODER_ERROR_STR, Color.DarkGreen), _
                                            New IntOccur(TYPE_ENABLE_OFF, TYPE_ENABLE_OFF_STR, Color.LightGreen), _
                                            New IntOccur(TYPE_OVERCURRENT, TYPE_OVERCURRENT_STR, Color.LightCoral), _
                                            New IntOccur(TYPE_INOUT_INVERTED, TYPE_INOUT_INVERTED_STR, Color.DarkOrange), _
                                            New IntOccur(TYPE_UNDERVOLTAGE, TYPE_UNDERVOLTAGE_STR, Color.LightSalmon), _
                                            New IntOccur(TYPE_COMUNICAT_ERROR, TYPE_COMUNICAT_ERROR_STR, Color.Violet)}

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

        Public Function GetIntColor(ByVal _typeToGetColor) As Color
            For i = 0 To _ArrIntOccur.Length - 1
                If _ArrIntOccur(i).TypeNum = _typeToGetColor Then
                    Return _ArrIntOccur(i).TypeColor
                End If
            Next
            ' errore non trovato
            Return (Color.Black)
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

        'Public Function returnColor(ByVal _typeToFindColor) As Color
        '    Select Case _typeToFindColor
        '        Case TYPE_ON
        '            Return Color.Green
        '        Case TYPE_OFF
        '            Return Color.Red

        '        Case TYPE_CHANGE_PN
        '            Return Color.Bisque
        '            'Case TYPE_CHANGE_CN
        '            '    Return Color.LightCoral

        '        Case TYPE_REMOTE_OFF
        '            Return Color.DarkRed
        '        Case TYPE_REMOTE_ON
        '            Return Color.DarkGreen

        '        Case TYPE_AUTO_ON
        '            Return Color.LightGreen


        '        Case TYPE_NOHALT_OVERCURR
        '            Return Color.Violet
        '        Case TYPE_NOHALT_OVERVOLT
        '            Return Color.Brown
        '        Case TYPE_NOHALT_UNDERVOLT
        '            Return Color.Turquoise
        '        Case TYPE_NOHALT_MANDATACH
        '            Return Color.Pink
        '        Case TYPE_NOHALT_DRYFUNC
        '            Return Color.SeaGreen
        '        Case TYPE_NOHALT_OVERTEMP
        '            Return Color.Olive
        '        Case TYPE_NOHALT_MAX_FLOW
        '            Return Color.Orange
        '        Case TYPE_NOHALT_SQUILIBRIO
        '            Return Color.Gray
        '        Case TYPE_NOHALT_DISSIMETRIA
        '            Return Color.Blue
        '        Case TYPE_NOHALT_SOVRAPRESSIONE
        '            Return Color.DarkSalmon


        '        Case TYPE_HALT_OVERCURR
        '            Return Color.DarkViolet
        '        Case TYPE_HALT_OVERVOLT
        '            Return Color.SaddleBrown
        '        Case TYPE_HALT_UNDERVOLT
        '            Return Color.DarkTurquoise
        '        Case TYPE_HALT_MANDATACH
        '            Return Color.DeepPink
        '        Case TYPE_HALT_DRYFUNC
        '            Return Color.DarkSeaGreen
        '        Case TYPE_HALT_OVERTEMP
        '            Return Color.DarkOliveGreen
        '        Case TYPE_HALT_MAX_FLOW
        '            Return Color.DarkOrange
        '        Case TYPE_HALT_SQUILIBRIO
        '            Return Color.Black
        '        Case TYPE_HALT_DISSIMETRIA
        '            Return Color.DarkBlue
        '        Case TYPE_HALT_PRESS_SENS
        '            Return Color.RosyBrown
        '        Case TYPE_HALT_SOVRAPRESSIONE
        '            Return Color.LightSalmon
        '        Case TYPE_HALT_CORTO_CIRCUITO
        '            Return Color.Crimson

        '        Case Else
        '            Return (Color.Black)
        '    End Select
        'End Function

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

    Public Function CreateCSVStringHelloValues() As String
        Dim StToAdd, StToAdd2 As String


        StToAdd = ""
        StToAdd2 = ConnectionUSB.Matricola.ToUpper
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = ConnectionUSB.PotNom
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = ConnectionUSB.VoltNom
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = ConnectionUSB.CurrNom
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = ConnectionUSB.FreqRadio
        StToAdd = StToAdd + StToAdd2


        Return StToAdd
    End Function


    Public Function CreateCSVStringHeaderInt() As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = "Num"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "Ev. "
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "Description"
        StToAdd = StToAdd + StToAdd2 + ","

        'StToAdd2 = "Date"
        'StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "Time"
        StToAdd = StToAdd + StToAdd2 + ","


        StToAdd2 = "V1-2[V]"
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = "V1-3[V]"
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = "V2-3[V]"
        StToAdd = StToAdd + StToAdd2 + ","


        StToAdd2 = "I1[A]"
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = "I2[A]"
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = "I3[A]"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "Cosφ"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "P[Kw]"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "RPM[rpm]"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "Freq[Hz]"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "T[°C]"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = "CVolt[V]"
        StToAdd = StToAdd + StToAdd2 + ","

        Return StToAdd
    End Function

    Public Function CreateCSVStringIntervento(ByVal _intv As InterventSingle, ByVal _progress As UInteger, ByVal _totaleInt As UInteger) As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = (_totaleInt - _progress + 1)   'voleva numerazione inversa che parte da 1
        'StToAdd2 = (_progress + 1)  '.ToString("000")

        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = _intv._intType.ToString
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = Intervents.GetIntStr(_intv._intType)
        StToAdd = StToAdd + StToAdd2 + ","


        'StToAdd2 = (2000 + GetYear(_intv._intTime)).ToString("0000") & "/" & GetMonth(_intv._intTime).ToString("00") & "/" & GetDay(_intv._intTime).ToString("00") & " "
        'StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = GetHours(_intv._intTime).ToString("00") & "h" & GetMinutes(_intv._intTime).ToString("00") & "'" & GetSeconds(_intv._intTime).ToString("00") & "''"
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = _intv._intV12_rms.ToString
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = _intv._intV13_rms.ToString
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = _intv._intV23_rms.ToString
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetCurrent(_intv._intI1_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = GetCurrent(_intv._intI2_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2 + ","
        StToAdd2 = GetCurrent(_intv._intI3_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetCosfi(_intv._intCosfi).ToString("F2", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = (GetPowerKiloWatt(_intv._intPower)).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetRPM(_intv._intRPM).ToString()
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetFreq(_intv._intFreq).ToString
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetTemperature(_intv._intTemp).ToString
        StToAdd = StToAdd + StToAdd2 + ","

        StToAdd2 = GetVoltCond(_intv._intVoltCond).ToString
        StToAdd = StToAdd + StToAdd2 + ","

        Return StToAdd
    End Function




    Public Function CreateLineStringHeaderInt() As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = "Num"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "Ev. "
        StToAdd = StToAdd + StToAdd2.PadLeft(5)

        StToAdd2 = "Description"
        StToAdd = StToAdd + StToAdd2.PadRight(MAXLEN_STR + 1)

        'StToAdd2 = "Date"
        'StToAdd = StToAdd + StToAdd2.PadRight(11)

        StToAdd2 = "Time"
        StToAdd = StToAdd + StToAdd2.PadRight(15)

        StToAdd2 = "V1-2"
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = "V1-3"
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = "V2-3"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "I1"
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = "I2"
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = "I3"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = "Cosφ"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "P"
        StToAdd = StToAdd + StToAdd2.PadRight(8)

        StToAdd2 = "RPM"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = "Freq"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = "T"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "C Volt."
        StToAdd = StToAdd + StToAdd2.PadRight(7)


        Return StToAdd
    End Function


    Public Function CreateLineStringHeaderIntUnita() As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = " "
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = " "
        StToAdd = StToAdd + StToAdd2.PadLeft(5)

        StToAdd2 = " "
        StToAdd = StToAdd + StToAdd2.PadRight(MAXLEN_STR + 1)



        StToAdd2 = "[h/min/sec]"
        StToAdd = StToAdd + StToAdd2.PadRight(15)

        StToAdd2 = "[V]"
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = "[V]"
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = "[V]"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "[A]"
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = "[A]"
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = "[A]"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = ""  ' cosfi
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "[Kw]"
        StToAdd = StToAdd + StToAdd2.PadRight(8)

        StToAdd2 = "[rpm]"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = "[Hz]"
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = "[°C]"
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "[V]"
        StToAdd = StToAdd + StToAdd2.PadRight(7)

        Return StToAdd
    End Function

    Public Function CreateLineStringIntervento(ByVal _intv As InterventSingle, ByVal _progress As UInteger, ByVal _totaleInt As UInteger) As String
        Dim StToAdd, StToAdd2 As String
        StToAdd = ""
        StToAdd2 = (_totaleInt - _progress + 1)  'voleva numerazione inversa che parte da 1
        'StToAdd2 = (_progress + 1)  '.ToString("000")

        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = "[" + _intv._intType.ToString + "] "
        StToAdd = StToAdd + StToAdd2.PadLeft(5)

        StToAdd2 = Intervents.GetIntStr(_intv._intType)
        StToAdd = StToAdd + StToAdd2.PadRight(MAXLEN_STR + 1)


        'StToAdd2 = (2000 + GetYear(_intv._intTime)).ToString("0000") & "/" & GetMonth(_intv._intTime).ToString("00") & "/" & GetDay(_intv._intTime).ToString("00") & " "
        'StToAdd = StToAdd + StToAdd2.PadRight(11)
        StToAdd2 = GetHours(_intv._intTime).ToString("00") & "h" & GetMinutes(_intv._intTime).ToString("00") & "'" & GetSeconds(_intv._intTime).ToString("00") & "''"
        StToAdd = StToAdd + StToAdd2.PadRight(15)

        StToAdd2 = _intv._intV12_rms.ToString
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = _intv._intV13_rms.ToString
        StToAdd = StToAdd + StToAdd2.PadRight(5)
        StToAdd2 = _intv._intV23_rms.ToString
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = GetCurrent(_intv._intI1_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = GetCurrent(_intv._intI2_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2.PadRight(6)
        StToAdd2 = GetCurrent(_intv._intI3_rms).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = GetCosfi(_intv._intCosfi).ToString("F2", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = (GetPowerKiloWatt(_intv._intPower)).ToString("F1", GetCultureInfo("en-GB"))
        StToAdd = StToAdd + StToAdd2.PadRight(8)

        StToAdd2 = GetRPM(_intv._intRPM).ToString()
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = GetFreq(_intv._intFreq).ToString
        StToAdd = StToAdd + StToAdd2.PadRight(6)

        StToAdd2 = GetTemperature(_intv._intTemp).ToString
        StToAdd = StToAdd + StToAdd2.PadRight(5)

        StToAdd2 = GetVoltCond(_intv._intVoltCond).ToString
        StToAdd = StToAdd + StToAdd2.PadRight(7)

        Return StToAdd
    End Function



    Public Function ToGBString(ByVal value As Double)
        Return value.ToString(Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Private Function restoAnno(ByVal _num As UInt32) As UInt32
        Return (_num - GetYear(_num) * (13 * 32 * 24 * 3600))
    End Function

    Private Function restoMese(ByVal _num As UInt32) As Integer
        Return restoAnno(_num) - GetMonth(_num) * (32 * 24 * 3600)
    End Function

    Private Function restoGiorno(ByVal _num As UInt32) As Integer
        Return restoMese(_num) - GetDay(_num) * (24 * 3600)
    End Function

    Private Function restoOra(ByVal _num As UInt32) As Integer
        Try
            Return restoGiorno(_num) - GetHours(_num) * 3600
        Catch ex As Exception
        End Try

    End Function

    Private Function restoMinuto(ByVal _num As UInt32) As Integer
        Return restoOra(_num) - GetMinutes(_num) * 60
    End Function

    Public Function GetYear(ByVal _totNumSec As UInt32) As UInteger
        Return (_totNumSec \ (13 * 32 * 24 * 3600))
    End Function

    Public Function GetMonth(ByVal _totNumSec As UInt32) As UInteger
        Return restoAnno(_totNumSec) \ (32 * 24 * 3600)
    End Function

    Public Function GetDay(ByVal _totNumSec As UInt32) As UInteger
        Return restoMese(_totNumSec) \ (24 * 3600)
    End Function

    Public Function GetHours(ByVal _totNumSec As UInt32) As UInteger
        Return _totNumSec \ 3600
    End Function

    Public Function GetMinutes(ByVal _totNumSec As UInt32) As UInteger
        Return restoOra(_totNumSec) \ 60
    End Function

    Public Function GetSeconds(ByVal _totNumSec As UInt32) As UInteger
        Return restoMinuto(_totNumSec)
    End Function

    Public Function GetVoltage(ByVal _numToConvert As UInt16) As Integer
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert)
    End Function

    Public Function GetCurrent(ByVal _numToConvert As UInt16) As Double
        Return Convert.ToDouble(_numToConvert / 10, Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Public Function GetPowerKiloWatt(ByVal _numToConvert As Byte) As Double
        'If _numToConvert < 0 Then Return 0
        Return Convert.ToDouble(_numToConvert / 10, Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Public Function GetNomPowerKiloWatt(ByVal _numToConvert As UInt16) As Double
        'If _numToConvert < 0 Then Return 0
        Return Convert.ToDouble((_numToConvert * 10) / 1000, Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Public Function GetRPM(ByVal _numToConvert As UInt16) As UInt16
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert)
    End Function

    Public Function GetCosfi(ByVal _numToConvert As Byte) As Double
        'If _numToConvert < 0 Then Return 0
        Return Convert.ToDouble(_numToConvert / 100, Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Public Function GetFreq(ByVal _numToConvert As Byte) As Double
        Return Convert.ToDouble(_numToConvert / 2.5, Globalization.CultureInfo.GetCultureInfo("en-GB"))
    End Function

    Public Function GetTemperature(ByVal _numToConvert As Byte) As Integer
        Return (_numToConvert)
    End Function

    Public Function GetVoltCond(ByVal _numToConvert As Byte) As UInt16
        Return Convert.ToUInt16(_numToConvert * 4)
    End Function

    Public Function GetFreqRadio(ByVal _numToConvert As Byte) As UInt16
        Return Convert.ToUInt16(_numToConvert + 860)
    End Function

    Public Function tempoFromDataOra(ByVal _data As String, ByVal _orario As String) As UInt32
        Dim _anno, _mese, _giorno As UInt16
        Dim _ora, _minuto, _secondo As UInt32
        '4 bytes = tempo = secondo + minuto*60 + ora*3600 + giorno*24*3600 + mese*32*24*3600 + anno*13*32*24*3600

        '_anno = Convert.ToUInt16(Convert.ToUInt16(_data.Split("/")(0)) - 2000)
        '_mese = Convert.ToUInt16(_data.Split("/")(1))
        '_giorno = Convert.ToUInt16(_data.Split("/")(2))
        _anno = 0
        _mese = 0
        _giorno = 0
        _ora = Convert.ToUInt32(_orario.Split("h")(0))
        _minuto = Convert.ToUInt32(_orario.Split("h")(1).Split("'")(0))
        _secondo = Convert.ToUInt32(_orario.Split("'")(1).Split("''")(0))

        Return Convert.ToUInt32(_secondo + _minuto * 60 + _ora * 3600 + _giorno * 24 * 3600 + _mese * 32 * 24 * 3600 + _anno * 13 * 32 * 24 * 3600)
    End Function

    Public Function GetVoltageInv(ByVal _numToConvert As Integer) As UInt16
        'If _numToConvert < 0 Then Return 0
        Return (Convert.ToUInt16(_numToConvert))
    End Function

    Public Function GetCurrentInv(ByVal _numToConvert As Double) As UInt16
        Return (Convert.ToUInt16(_numToConvert * 10))
    End Function

    Public Function GetPowerKiloWattInv(ByVal _numToConvert As Double) As Byte
        'If _numToConvert < 0 Then Return 0
        Return (Convert.ToByte(_numToConvert * 10))
    End Function
    Public Function GetNomPowerKiloWattInv(ByVal _numToConvert As Double) As UInt16
        'If _numToConvert < 0 Then Return 0
        Return (Convert.ToUInt16(_numToConvert * 1000 / 10))
    End Function
    Public Function GetRPMInv(ByVal _numToConvert As UInt16) As UInt16
        'If _numToConvert < 0 Then Return 0
        Return (_numToConvert)
    End Function

    Public Function GetCosfiInv(ByVal _numToConvert As Double) As Byte
        'If _numToConvert < 0 Then Return 0
        Return (Convert.ToByte(_numToConvert * 100))
    End Function

    Public Function GetFreqInv(ByVal _numToConvert As Double) As Byte
        Return (Convert.ToByte(_numToConvert * 2.5))
    End Function

    Public Function GetVoltCondInv(ByVal _numToConvert As UInt16) As Byte
        Return (Convert.ToByte(_numToConvert / 4))
    End Function

    Public Function GetFreqRadioInv(ByVal _numToConvert As UInt16) As Byte
        Return Convert.ToByte(_numToConvert - 860)
    End Function


    Public Function GetTemperatureInv(ByVal _numToConvert As Integer) As Byte
        Return (Convert.ToByte(_numToConvert))
    End Function

#End Region
End Module
