'Imports System.Windows.Forms.DataVisualization.Charting.Utilities
'Imports System.Windows.Forms.DataVisualization.Charting
Imports ZedGraph
Imports System.Random

Public Class MainFrm    

    Private Sub MainFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseProgram()
    End Sub

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Load_Parameters()

        Draw_header()
    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        CloseProgram()
        Me.Close()
    End Sub



   

    Private Sub btnConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConn.Click
        Me.Cursor = Cursors.WaitCursor
        'lblNotify.Text = "Please Wait"
        GroupBox1.Enabled = False



        FormWait.Cursor = Cursors.WaitCursor
        FormWait.Show()
        FormWait.Left = Me.Left + (Me.Width - FormWait.Width) / 2
        FormWait.Top = Me.Top + (Me.Height - FormWait.Height) / 2

        If ConnectionActive Then
            If Not ConnectionUSB Is Nothing Then
                ConnectionUSB.ForceClosePort()
                ConnectionUSB.LogDisplay("Disconnect")
                ConnectionUSB = Nothing
            End If
            SetConn(False)
            EnableControlsInterventi(False)
        Else
            If Not ConnectionUSB Is Nothing Then ConnectionUSB = Nothing

            ConnectionUSB = New USBClass(ListBoxLog)
            If ConnectionUSB.ConnectDevice() Then
                LastCOMUsed = ConnectionUSB.GetCOMName
                WriteConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "LastCOMUsed", LastCOMUsed)
                SetConn(True)
                Application.DoEvents()
                If ConnectionUSB.RequestInterventi(0, 0) Then
                    lblNotify.Text = "Alarms found = " & ConnectionUSB.InterventiLetti.Length
                    If ConnectionUSB.InterventiLetti.IntItems.Length = 0 Then
                        EnableControlsInterventi(False)
                    Else
                        Intervents = New InterventiTypeClass(ConnectionUSB.InterventiLetti)
                        UpdateChartZ_Second()
                        EnableControlsInterventi(True)
                    End If

                Else
                    EnableControlsInterventi(False)
                    lblNotify.Text = "No alarms"
                    SetConn(False)
                    EnableControlsInterventi(False)
                End If
            Else
                SetConn(False)
            End If
        End If
        GroupBox1.Enabled = True
        btnConn.Enabled = True
        Me.Cursor = Cursors.Default

        FormWait.Close()
    End Sub



    Private Sub Draw_header()
        Dim toolTip1 As New ToolTip()


        If My.Application.Info.Title <> "" Then
            Me.Text = My.Application.Info.Title
        Else
            Me.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ' Blocca dimensione minima finestra
        Me.MinimumSize = Me.Size

        TabControl1.TabPages.Remove(TabControl1.TabPages(1))
        lblGenericTmp.Text = "Program developing " + Environment.NewLine _
                            + "Sw Version " + "" + "   " + "2010"




        lblIntVolt.Text = "Average Voltage [Volt]"
        lblIntVolt.TextAlign = ContentAlignment.MiddleCenter
        lblIntCurrent.Text = "Currents [Amp]"
        lblIntCurrent.TextAlign = ContentAlignment.MiddleCenter

        lblIntVDesc.Text = ""
        lblIntI1Desc.Text = "I1"
        lblIntI2Desc.Text = "I2"
        lblIntI3Desc.Text = "I3"



        StatusStrip1.Items.Clear()
        ListBoxLog.Items.Clear()
        lstInterventi.Items.Clear()
        EnableControlsInterventi(False)
        SetConn(False)


        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 800
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        toolTip1.SetToolTip(Me.btnSaveInt, "Save all alarms on a file")
        toolTip1.SetToolTip(Me.btnConn, "Connect to Device")
        toolTip1.SetToolTip(Me.HscrollInterventi, "Scroll alarms here")
        toolTip1.SetToolTip(Me.ListBoxLog, "Program events")
        toolTip1.SetToolTip(Me.PictureLogo, "Electroil internet site")
        toolTip1.SetToolTip(Me.btnOpenGraph, "Show alarms Histogram")

        lstInterventi.HorizontalScrollbar = True        

    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)

        lblIntTypeVal.Text = Intervents.GetIntStr(intToFill._intType)
        lblIntTypeVal.ForeColor = Intervents.returnColor(intToFill._intType)

        lblIntTimeVal.Text = GetHours(intToFill._intTime).ToString & "h " & GetMinutes(intToFill._intTime).ToString("00") & "' " & GetSeconds(intToFill._intTime).ToString("00") & "''"

        lblIntV1Val.Text = GetVoltage(intToFill._intVoltAv)
        'lblIntV2Val.Text = intToFill._intVolt2
        'lblIntV3Val.Text = intToFill._intVolt3

        lblIntI1Val.Text = GetCurrent(intToFill._intI1_rms)
        lblIntI2Val.Text = GetCurrent(intToFill._intI2_rms)
        lblIntI3Val.Text = GetCurrent(intToFill._intI3_rms)

        lblIntPowVal.Text = GetPower(intToFill._intPower)
        lblIntPressVal.Text = GetPressure(intToFill._intPress)
        lblIntCosfiVal.Text = GetCosfi(intToFill._intCosfi)
        lblIntTempVal.Text = GetTemperature(intToFill._intTemp)

    End Sub

    Private Sub FillListData()

        'Dim StToAdd As String = ""
        'Dim StToAdd2 As String = ""

        For i = 0 To ConnectionUSB.InterventiLetti.Length - 1


            'StToAdd = ""
            'StToAdd2 = (i + 1)  '.ToString("000")

            'StToAdd = StToAdd + StToAdd2.PadRight(5)

            'StToAdd2 = Intervents.GetIntStr(ConnectionUSB.InterventiLetti.IntItems(i)._intType)

            'StToAdd = StToAdd + StToAdd2.PadRight(28)

            'StToAdd2 = GetHours(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString + "h "
            'StToAdd2 = StToAdd2 + GetMinutes(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "' "
            'StToAdd2 = StToAdd2 + GetSeconds(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "'' "

            'StToAdd = StToAdd + StToAdd2.PadRight(13)

            'StToAdd2 = "Volt:" + GetVoltage(ConnectionUSB.InterventiLetti.IntItems(i)._intVoltAv).ToString + "V"
            'StToAdd = StToAdd + StToAdd2.PadRight(11)
            ''StToAdd2 = "V2:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt2.ToString + "V"
            ''StToAdd = StToAdd + StToAdd2.PadRight(8)
            ''StToAdd2 = "V3:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt3.ToString + "V"
            ''StToAdd = StToAdd + StToAdd2.PadRight(8)

            'StToAdd2 = "I1:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI1_rms).ToString + "A"
            'StToAdd = StToAdd + StToAdd2.PadRight(13)
            'StToAdd2 = "I2:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI2_rms).ToString + "A"
            'StToAdd = StToAdd + StToAdd2.PadRight(10)
            'StToAdd2 = "I3:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI3_rms).ToString + "A"
            'StToAdd = StToAdd + StToAdd2.PadRight(10)

            'StToAdd2 = "Power:" + GetPower(ConnectionUSB.InterventiLetti.IntItems(i)._intPower).ToString + "W"
            'StToAdd = StToAdd + StToAdd2.PadRight(13)

            'StToAdd2 = "Pressure:" + GetPressure(ConnectionUSB.InterventiLetti.IntItems(i)._intPress).ToString + " bar"
            'StToAdd = StToAdd + StToAdd2.PadRight(20)


            'StToAdd2 = "Cosfi:" + GetCosfi(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi).ToString + ""
            'StToAdd = StToAdd + StToAdd2.PadRight(12)

            'StToAdd2 = "Temp:" + GetTemperature(ConnectionUSB.InterventiLetti.IntItems(i)._intTemp).ToString + "°C"
            'StToAdd = StToAdd + StToAdd2.PadRight(11)

            lstInterventi.Items.Add(CreateLineStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i))
        Next
    End Sub

    Private Sub EnableControlsInterventi(ByVal _EvConEn As Boolean)
        pnlButAlarms.Enabled = _EvConEn
        Panel1.Enabled = _EvConEn
        HscrollInterventi.Enabled = _EvConEn
        lblNumInt.Visible = _EvConEn

        If _EvConEn Then

            HscrollInterventi.Enabled = True
            HscrollInterventi.Minimum = 1
            HscrollInterventi.Maximum = ConnectionUSB.InterventiLetti.Length
            HscrollInterventi.SmallChange = 1
            HscrollInterventi.LargeChange = 1
            HscrollInterventi.Value = HscrollInterventi.Minimum
            lblNumIntTitle.Text = "alarms number"
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillListData()
            FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))
            lstInterventi.SelectedItem = lstInterventi.Items.Item(HscrollInterventi.Value - 1)
        Else

            lblIntTypeVal.Text = ""
            lblIntTimeVal.Text = ""
            lblIntV1Val.Text = ""
            
            lblIntI1Val.Text = ""
            lblIntI2Val.Text = ""
            lblIntI3Val.Text = ""
            
            lblIntPowVal.Text = ""
            lblIntPressVal.Text = ""
            lblIntCosfiVal.Text = ""
            lblIntTempVal.Text = ""

            lblNumInt.Text = ""
            lblNumIntTitle.Text = ""
            lstInterventi.Items.Clear()
        End If


    End Sub


    Private Sub SetConn(ByVal _ConnEnable As Boolean)
        If _ConnEnable Then
            btnConn.Image = ApplicationUSB.My.Resources.disc
            btnConn.Text = "Disconnect"
            ConnectionActive = True
            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Serial number: " + ConnectionUSB.Matricola.ToUpper)
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add("Worked hours: " + GetHours(ConnectionUSB.OreLav).ToString("") + "h " + GetMinutes(ConnectionUSB.OreLav).ToString("00") + "' " + GetSeconds(ConnectionUSB.OreLav).ToString("00") + "''")
            StatusStrip1.Items.Add(New ToolStripSeparator)


            'StatusStrip1.Items.Add("Fw Ver: " + ConnectionUSB.FwVer.ToString("X4"))
            'StatusStrip1.Items.Add(New ToolStripSeparator)

            'StatusStrip1.Items.Add("Hw Ver: " + ConnectionUSB.HwVer.ToString("X4"))
            'StatusStrip1.Items.Add(New ToolStripSeparator)


        Else
            lblNotify.Text = "Connect and Read alarms"
            btnConn.Image = ApplicationUSB.My.Resources.conn
            btnConn.Text = "Connect"
            ConnectionActive = False
            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Device Not Connected")
            StatusStrip1.Items.Add(New ToolStripSeparator)
        End If


    End Sub



    Private Sub CopyLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyLogToolStripMenuItem.Click
        Dim strt As String = ""
        For i = 0 To ListBoxLog.Items.Count - 1
            strt = strt + ListBoxLog.Items.Item(i) + Environment.NewLine
        Next
        If strt.Length > 0 Then Clipboard.SetText(strt)

    End Sub

    Private Sub ClearLogToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearLogToolStripMenuItem1.Click
        ListBoxLog.Items.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        CloseProgram()
        Me.Close()
    End Sub

    Private Sub btnSaveInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveInt.Click
        Dim file As System.IO.StreamWriter
        Dim FileLogName As String
        Dim i As Integer
        Dim FileNameToSave As String = ""
        Dim FolderStr As String


        FolderStr = System.IO.Path.GetDirectoryName(ReadConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaSaveAlarms") + "\")
        If System.IO.Directory.Exists(FolderStr) Then

        Else
            FolderStr = UsrDocData
        End If


        FileNameToSave = Strings.Right(Date.Now.Year.ToString, 2)
        FileNameToSave = FileNameToSave + Date.Now.Month.ToString("00")
        FileNameToSave = FileNameToSave + Date.Now.Day.ToString("00")

        ' Nome file standard
        FileNameToSave = "alarms" + "_" + FileNameToSave

        ' Se sto usando estensione .txt controllo se c'è già e eventualmente aggiungo h m s 
        If SaveFileDialog1.FilterIndex = 1 Then
            If System.IO.File.Exists(FolderStr + "\" + FileNameToSave + ".txt") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If
        Else
            ' Se sto usando estensione .csv controllo se c'è già e eventualmente aggiungo h m s 
            If System.IO.File.Exists(FolderStr + "\" + FileNameToSave + ".csv") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If
        End If


        SaveFileDialog1.DefaultExt = ".txt"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.Filter = "Text File (*.txt)|*.txt" + "|" + "Comma separated value (*.csv)|*.csv" + "|" + "All files|*.*"
        SaveFileDialog1.InitialDirectory = FolderStr
        SaveFileDialog1.Title = "Save alarms"
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.OverwritePrompt = True


        If Not (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then Exit Sub


        Try
            ' Salva in Config.xml nuovo valore
            WriteConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaSaveAlarms", System.IO.Path.GetDirectoryName(SaveFileDialog1.FileName))

            FileLogName = SaveFileDialog1.FileName
            file = New System.IO.StreamWriter(FileLogName, False)   ' No append

            ' Se CSV faccio in un modo altrimenti riempio come file txt
            If Strings.Right(FileLogName, 3).ToUpper = "CSV" Then
                Dim enc As New System.Text.UTF8Encoding()

                file.Write(enc.GetString(ConnectionUSB.DatiSetHello()))
                file.WriteLine("")
                file.WriteLine("")
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intType.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intTime.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVoltAv.ToString + ",")
                    'file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVolt2.ToString + ",")
                    'file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVolt3.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intI1_rms.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intI2_rms.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intI3_rms.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intPower.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intPress.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intTemp.ToString)
                    file.Write(Environment.NewLine)
                Next
            Else
                file.WriteLine(New String("*", 90))
                file.WriteLine("* Alarms recorded")
                file.WriteLine("* Date: " + Date.Now)
                file.WriteLine("* Serial number:" + ConnectionUSB.Matricola.ToUpper)

                '               + " Fw Ver:" + ConnectionUSB.FwVer.ToString("X4") _
                '               + " Hw Ver:" + ConnectionUSB.HwVer.ToString("X4"))
                file.WriteLine("* Worked hours:" + GetHours(ConnectionUSB.OreLav).ToString + "h" + GetMinutes(ConnectionUSB.OreLav).ToString("00") + "' " + GetSeconds(ConnectionUSB.OreLav).ToString("00") + "''")
                file.WriteLine(New String("*", 90))

                file.WriteLine()
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.WriteLine(CreateLineStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i))
                    'file.WriteLine()
                    'file.WriteLine(New String("-", 68))

                    'file.WriteLine((i + 1).ToString + ")")

                    'file.Write("Alarm Type: ")
                    'file.Write(("[" + ConnectionUSB.InterventiLetti.IntItems(i)._intType.ToString + "]").PadLeft(4))
                    'file.Write(Intervents.GetIntStr(ConnectionUSB.InterventiLetti.IntItems(i)._intType).PadRight(28))
                    ''file.Write(New String(" ", 5))

                    'file.Write("Alarm Time: ")
                    'file.Write(GetHours(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString + "h ")
                    'file.Write(GetMinutes(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "' ")
                    'file.Write(GetSeconds(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "'' ")
                    ''file.Write(New String(" ", 5))
                    'file.WriteLine()


                    'file.Write(("Volt:" + GetVoltage(ConnectionUSB.InterventiLetti.IntItems(i)._intVoltAv).ToString + "V").PadRight(16))

                    ''file.Write(("Curr:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurrAv).ToString + "A").PadRight(13))
                    'file.Write("I1:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI1_rms).ToString + "A   ")
                    'file.Write("I2:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI2_rms).ToString + "A   ")
                    'file.Write("I3:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intI3_rms).ToString + "A   ")
                    'file.WriteLine()

                    'file.Write(("Power:" + GetPower(ConnectionUSB.InterventiLetti.IntItems(i)._intPower).ToString + "W").PadRight(16))
                    'file.Write(("Pressure:" + GetPressure(ConnectionUSB.InterventiLetti.IntItems(i)._intPress).ToString + " bar").PadRight(20))
                    'file.WriteLine()

                    'file.Write(("Cosfi:" + GetCosfi(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi).ToString).PadRight(16))
                    'file.Write(("Temp:" + GetTemperature(ConnectionUSB.InterventiLetti.IntItems(i)._intTemp).ToString + "°C").PadRight(11))

                Next

            End If


            file.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub


    'Private Sub UpdateChartZ()
    '    Dim x(Intervents.TotTipiIntervento - 1) As String
    '    Dim y(Intervents.TotTipiIntervento - 1) As Double
    '    Dim myPane As GraphPane = zg1.GraphPane
    '    Dim myZList As New PointPairList
    '    Dim i As Integer

    '    zg1.GraphPane.CurveList.Clear()
    '    zg1.GraphPane.Title.Text = "Alarms"

    '    For i = 0 To Intervents.TotTipiIntervento - 1
    '        myZList = New PointPairList
    '        myZList.Clear()
    '        myZList.Add(Intervents.enumNum(i), Intervents.GetOcc(Intervents.enumNum(i)), 111)
    '        'x(i) = Intervents.GetIntStr(Intervents.enumNum(i))
    '        x(i) = (Intervents.enumNum(i))
    '        ' y(i) = Intervents.GetOcc(Intervents.enumNum(i))
    '        Dim myCurve As CurveItem = myPane.AddBar(Intervents.enumNum(i).ToString + " " + Intervents.GetIntStr(Intervents.enumNum(i)), myZList, Intervents.returnColor(Intervents.enumNum(i)))
    '        'Dim myCurve As CurveItem = myPane.AddBar("", .ToString, Nothing, y, Color.Yellow)
    '    Next i

    '    'Dim myCurve As CurveItem = myPane.AddBar("Gigione", Nothing, y, Color.Green)

    '    ' Fill the pane background with a color gradient
    '    myPane.Fill = New Fill(Color.White, Color.LightGray, 45.0F)
    '    ' No fill for the chart background
    '    myPane.Chart.Fill.Type = FillType.None

    '    ' Set the legend to an arbitrary location
    '    myPane.Legend.Position = LegendPos.Right
    '    myPane.Legend.Location = New Location(0.95F, 0.15F, CoordType.PaneFraction, _
    '                AlignH.Right, AlignV.Top)
    '    myPane.Legend.FontSpec.Size = 10.0F
    '    myPane.Legend.IsHStack = False


    '    myPane.XAxis.Type = ZedGraph.AxisType.Text
    '    myPane.XAxis.Title.Text = "Alarms type"
    '    myPane.XAxis.Title.FontSpec.Size = 10.0F

    '    myPane.XAxis.Scale.FormatAuto = True
    '    'myPane.XAxis.Scale.TextLabels = x
    '    myPane.XAxis.Scale.FontSpec.Size = 10.0F
    '    myPane.XAxis.Scale.FontSpec.IsBold = True
    '    myPane.XAxis.MinorGrid.IsVisible = True
    '    myPane.XAxis.MinSpace = 1
    '    myPane.XAxis.Scale.FormatAuto = True


    '    myPane.YAxis.Type = ZedGraph.AxisType.Linear
    '    myPane.YAxis.Title.Text = "Occurences"
    '    myPane.YAxis.Title.FontSpec.Size = 10.0F
    '    myPane.YAxis.Scale.FontSpec.Size = 10.0F
    '    myPane.YAxis.Scale.Align = AlignP.Inside
    '    myPane.YAxis.Scale.Min = 0
    '    myPane.YAxis.Scale.MaxAuto = True

    '    Dim colors As Color() = {Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple}


    '    '' Tell ZedGraph to calculate the axis ranges
    '    zg1.AxisChange()
    '    ' Make sure the Graph gets redrawn
    '    zg1.Invalidate()

    '    zg1.Refresh()




    'End Sub

    Private Sub UpdateChartZ_Second()
        Dim x(Intervents.TotTipiIntervento - 1) As String
        Dim y(Intervents.TotTipiIntervento - 1) As Double
        Dim myPane As GraphPane = ZedGraphFrm.zg1.GraphPane
        Dim myZList As New PointPairList
        Dim i As Integer

        ZedGraphFrm.zg1.GraphPane.CurveList.Clear()
        ZedGraphFrm.zg1.GraphPane.Title.Text = "Alarms"

        For i = 0 To Intervents.TotTipiIntervento - 1
            myZList = New PointPairList
            myZList.Clear()
            myZList.Add(Intervents.enumNum(i), Intervents.GetOcc(Intervents.enumNum(i)), 111)
            x(i) = (Intervents.enumNum(i))
            Dim myCurve As CurveItem = myPane.AddBar(Intervents.enumNum(i).ToString + " " + Intervents.GetIntStr(Intervents.enumNum(i)), myZList, Intervents.returnColor(Intervents.enumNum(i)))

            ' Dim label As TextObj = New TextObj(Intervents.GetOcc(Intervents.enumNum(i)), myCurve.Points.Item(0).X, myCurve.Points.Item(0).Y)
            ' myPane.GraphObjList.Add(label)
        Next i



        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.LightGray, 45.0F)
        ' No fill for the chart background
        myPane.Chart.Fill.Type = FillType.None

        ' Set the legend to an arbitrary location
        myPane.Legend.Position = LegendPos.Right
        myPane.Legend.Location = New Location(0.95F, 0.15F, CoordType.PaneFraction, _
                    AlignH.Right, AlignV.Top)
        myPane.Legend.FontSpec.Size = 10.0F
        myPane.Legend.IsHStack = False

        myPane.XAxis.Type = ZedGraph.AxisType.Text
        myPane.XAxis.Title.Text = "Alarms type"
        myPane.XAxis.Title.FontSpec.Size = 10.0F

        myPane.XAxis.Scale.FormatAuto = True
        'myPane.XAxis.Scale.TextLabels = x
        myPane.XAxis.Scale.FontSpec.Size = 10.0F
        myPane.XAxis.Scale.FontSpec.IsBold = True
        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinSpace = 1
        myPane.XAxis.Scale.FormatAuto = True

        myPane.YAxis.Type = ZedGraph.AxisType.Linear
        myPane.YAxis.Title.Text = "Occurences"
        myPane.YAxis.Title.FontSpec.Size = 10.0F
        myPane.YAxis.Scale.FontSpec.Size = 10.0F
        myPane.YAxis.Scale.Align = AlignP.Inside
        myPane.YAxis.Scale.Min = 0
        myPane.YAxis.Scale.MaxAuto = True

        CreateBarLabels(myPane, False, "00")


        '' Tell ZedGraph to calculate the axis ranges
        ZedGraphFrm.zg1.AxisChange()
        ' Make sure the Graph gets redrawn
        ZedGraphFrm.zg1.Invalidate()

        ZedGraphFrm.zg1.Refresh()


        
    End Sub



    Private Sub CreateBarLabels(ByVal pane As GraphPane, ByVal isBarCenter As Boolean, ByVal valueFormat As String)
        Dim isVertical As Boolean = True

        pane.GraphObjList.Clear()

        '' Make the gap between the bars and the labels = 2% of the axis range
        Dim labelOffset As Single
        If isVertical Then
            labelOffset = 1 ' CSng(pane.YAxis.Max - pane.YAxis.Min) * 0.02F
        Else
            labelOffset = 1 'CSng(pane.XAxis.Max - pane.XAxis.Min) * 0.02F
        End If

        ' keep a count of the number of BarItems
        Dim curveIndex As Integer = 0

        ' Get a valuehandler to do some calculations for us
        Dim valueHandler As New ValueHandler(pane, True)

        ' Loop through each curve in the list
        For Each curve As CurveItem In pane.CurveList
            ' work with BarItems only
            Dim bar As BarItem = TryCast(curve, BarItem)
            If bar IsNot Nothing Then
                Dim points As IPointList = curve.Points

                ' Loop through each point in the BarItem
                For i = 0 To points.Count - 1
                    ' Get the high, low and base values for the current bar
                    ' note that this method will automatically calculate the "effective"
                    ' values if the bar is stacked
                    Dim baseVal As Double, lowVal As Double, hiVal As Double
                    valueHandler.GetValues(curve, i, baseVal, lowVal, hiVal)
                    If hiVal <> lowVal Then


                        ' Get the value that corresponds to the center of the bar base
                        ' This method figures out how the bars are positioned within a cluster
                        Dim centerVal As Single = CSng(valueHandler.BarCenterValue(bar, bar.GetBarWidth(pane), i, baseVal, curveIndex))

                        ' Create a text label -- note that we have to go back to the original point
                        ' data for this, since hiVal and lowVal could be "effective" values from a bar stack
                        'Dim barLabelText As String = (If(isVertical, points(i).Y, points(i).X)).ToString(valueFormat)
                        Dim barLabelText As String = Intervents.enumNum(curveIndex)

                        ' Calculate the position of the label -- this is either the X or the Y coordinate
                        ' depending on whether they are horizontal or vertical bars, respectively
                        Dim position As Single
                        If isBarCenter Then
                            position = CSng(hiVal + lowVal) / 2.0F
                        Else
                            position = CSng(hiVal) + labelOffset
                        End If
                        ' position = lowVal - 3

                        ' Create the new TextItem
                        Dim label As TextObj
                        If isVertical Then
                            label = New TextObj(barLabelText, centerVal, position)
                        Else
                            label = New TextObj(barLabelText, position, centerVal)
                        End If

                        ' Configure the TextItem
                        label.Location.CoordinateFrame = CoordType.AxisXYScale
                        label.FontSpec.Size = 12
                        label.FontSpec.FontColor = Color.Black
                        label.FontSpec.Angle = If(isVertical, 90, 0)
                        label.Location.AlignH = If(isBarCenter, AlignH.Center, AlignH.Left)
                        label.Location.AlignV = AlignV.Center
                        label.FontSpec.Border.IsVisible = False
                        label.FontSpec.Fill.IsVisible = False

                        ' Add the TextItem to the GraphPane
                        pane.GraphObjList.Add(label)
                    End If
                Next
            End If
            curveIndex += 1
        Next
    End Sub


    Private Sub UpdateChart()

        'Chart1.Series.Clear()

        ''Chart1.DataSource = Intervents
        'Chart1.ChartAreas.Clear()
        'Chart1.ChartAreas.Add(0)
        'Chart1.ChartAreas(0).AxisY.IntervalAutoMode = True
        'Chart1.ChartAreas(0).AxisX.IntervalAutoMode = True
        'Chart1.ChartAreas(0).AxisX.Interval = 1
        'Chart1.Series.Add(0)
        ''Chart1.Series(0).XValueMember = " XVALMEM"
        ''Chart1.Series(0).YValueMembers = " YVALMEM"

        ''Chart1.Series(0).Points.AddY(2)
        'Chart1.Series(0).YValueType = ChartValueType.Int32
        ''Chart1.Series(0).Points.AddXY("FF", 35)
        ''Chart1.Series(0).Points.AddY(3)

        'Chart1.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        'Chart1.Series(0).XValueType = DataVisualization.Charting.ChartValueType.String
        'Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column

        'For i = 0 To Intervents.TotTipiIntervento - 1
        '    'Chart1.Series(0).Points.AddY(CType(Intervents.GetOcc(Intervents.enumNum(i)), Double))
        '    Chart1.Series(0).IsXValueIndexed = True

        '    Chart1.Series(0).Points.AddXY(Intervents.enumStr(i), Intervents.GetOcc(Intervents.enumNum(i)))
        '    Chart1.Series(0).Points(i).Color = Color.FromArgb(i * 10, 255 - i * 10, i * 10)

        '    Chart1.Series(0).Points(i).LegendText = Intervents.enumStr(i)

        'Next


        'Chart1.Series.Clear()
        'Chart1.ChartAreas.Clear()
        'Chart1.Titles.Clear()

        'Chart1.ChartAreas.Add("HistoInterventi")        
        ''Chart1.ChartAreas("HistoInterventi").AxisY.IntervalAutoMode = True
        ''Chart1.ChartAreas("HistoInterventi").AxisX.IntervalAutoMode = True

        'Chart1.Titles.Add("Alarm graph")
        ''Chart1.ChartAreas("").


        ''Chart1.Series(0).YValueType = ChartValueType.Int32
        ''Chart1.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        ''Chart1.Series(0).XValueType = DataVisualization.Charting.ChartValueType.String
        ''Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
        'For i = 0 To Intervents.TotTipiIntervento - 1
        '    Chart1.Series.Add(Intervents.enumStr(i))
        '    Chart1.Series(Intervents.enumStr(i)).IsXValueIndexed = True
        '    'Chart1.Series(Intervents.enumStr(i)).Points
        '    Chart1.Series(Intervents.enumStr(i)).Points.AddY(Intervents.GetOcc(Intervents.enumNum(i)))
        '    Chart1.Series(Intervents.enumStr(i)).Points(0).Label = i.ToString
        '    Chart1.Series(Intervents.enumStr(i)).AxisLabel = "DDIIS"
        '    Chart1.Series(Intervents.enumStr(i)).YValueMembers = "YY"

        '    'Chart1.Series(0).IsXValueIndexed = True

        '    'Chart1.Series(0).Points.AddXY(Intervents.enumStr(i), Intervents.GetOcc(Intervents.enumNum(i)))

        'Next









        'Chart1.ChartAreas.Clear()
        'Chart1.Series.Clear()

        'Chart1.ChartAreas.Add("Default")
        'Chart1.Series.Add("Series1")


        '' Populate series data
        'Dim random As New Random()
        'Dim [date] As DateTime = DateTime.Now.Date
        'Dim pointIndex As Integer
        'For pointIndex = 0 To 7
        '    Chart1.Series("Series1").Points.AddXY([date], random.Next(5, 95))
        '    [date] = [date].AddDays(random.Next(1, 5))
        'Next

        ''Use point index instead of the X value
        'If CheckBox1.Checked Then
        '    Chart1.Series("Series1").IsXValueIndexed = True

        '    ' Show labels every day
        '    Chart1.ChartAreas("Default").AxisX.LabelStyle.Interval = 1
        '    Chart1.ChartAreas("Default").AxisX.MajorGrid.Interval = 1
        '    Chart1.ChartAreas("Default").AxisX.MajorTickMark.Interval = 1
        'End If



    End Sub
    Private Sub PictureLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureLogo.Click
        Process.Start("http://www.electroil.it/inglese/index.html")
    End Sub

    Private Sub lstInterventi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInterventi.SelectedIndexChanged
        HscrollInterventi.Value = lstInterventi.SelectedIndex + 1
    End Sub

    Private Sub HscrollInterventi_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HscrollInterventi.ValueChanged
        If ConnectionUSB.InterventiLetti.IntItems.Length > 0 Then
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))

            If lstInterventi.Items.Count >= HscrollInterventi.Value Then
                lstInterventi.SelectedItem = lstInterventi.Items.Item(HscrollInterventi.Value - 1)
            End If
        End If

    End Sub

    Private Sub btnOpenGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenGraph.Click
        ZedGraphFrm.Show()
        UpdateChartZ_Second()
    End Sub



    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
End Class
