Imports Zedgraph

'Imports System.Windows.Forms.DataVisualization.Charting.Utilities

'Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Random

Public Class MainFrm    

    Private Sub MainFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseProgram()

    End Sub

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Draw_header()

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        CloseProgram()
        Me.Close()
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ConnectionUSB.RequestInterventi(0, 0) Then
            EnableControlsInterventi(True)
            lblNotify.Text = "Faults found " & ConnectionUSB.InterventiLetti.Length
        Else
            EnableControlsInterventi(False)
            lblNotify.Text = "No Faults"
        End If

    End Sub

    Private Sub btnConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConn.Click
        Me.Cursor = Cursors.WaitCursor
        If ConnectionActive Then
            If Not ConnectionUSB Is Nothing Then
                ConnectionUSB.ClosePort()
                ConnectionUSB = Nothing
            End If
            SetConn(False)
            EnableControlsInterventi(False)
        Else
            If Not ConnectionUSB Is Nothing Then ConnectionUSB = Nothing

            ConnectionUSB = New USBClass(ListBoxLog)
            If ConnectionUSB.ConnectDevice() Then
                SetConn(True)

                If ConnectionUSB.RequestInterventi(0, 0) Then                    
                    lblNotify.Text = "Faults found " & ConnectionUSB.InterventiLetti.Length

                    Intervents = New InterventiTypeClass(ConnectionUSB.InterventiLetti)
                    UpdateChart()
                    UpdateChartZ()
                    UpdateChartZ_second()
                    EnableControlsInterventi(True)
                Else
                    EnableControlsInterventi(False)
                    lblNotify.Text = "No Faults"
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub HscrollInterventi_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HscrollInterventi.Scroll

     

    End Sub


    Private Sub Draw_header()
        Dim toolTip1 As New ToolTip()
  

        ' Blocca dimensione minima finestra
        Me.MinimumSize = Me.Size

       
        UpdateChart()
        UpdateChartZ()
        UpdateChartZ_second()

        TabControl1.TabPages.Remove(TabControl1.TabPages(1))
        lblGenericTmp.Text = "Program developing " + Environment.NewLine _
                            + "Sw Version " + SwVersion + "   " + "2010"

        btnRead.Visible = False
        Button2.Visible = False
        StatusStrip1.Items.Clear()
        ListBoxLog.Items.Clear()
        lstInterventi.Items.Clear()
        EnableControlsInterventi(False)
        SetConn(False)
        Me.Text = "USB Configuration " + SwVersion



        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 800
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        toolTip1.SetToolTip(Me.btnSaveInt, "Save all Faults on a file")
        toolTip1.SetToolTip(Me.btnConn, "Connect to Device")
        toolTip1.SetToolTip(Me.HscrollInterventi, "Scroll Faults here")
        toolTip1.SetToolTip(Me.ListBoxLog, "Program events")
        toolTip1.SetToolTip(Me.PictureLogo, "Electroil internet site")
        toolTip1.SetToolTip(Me.btnOpenGraph, "Show Faults Histogram")

        lstInterventi.HorizontalScrollbar = True        

    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)

        lblIntTypeVal.Text = Intervents.GetIntStr(intToFill._intType)
        lblIntTypeVal.ForeColor = Intervents.returnColor(intToFill._intType)

        lblIntTimeVal.Text = GetHours(intToFill._intTime).ToString & "h " & GetMinutes(intToFill._intTime).ToString("00") & "' " & GetSeconds(intToFill._intTime).ToString("00") & "''"

        lblIntV1Val.Text = intToFill._intVolt1
        lblIntV2Val.Text = intToFill._intVolt2
        lblIntV3Val.Text = intToFill._intVolt3

        lblIntI1Val.Text = GetCurrent(intToFill._intCurr1)
        lblIntI2Val.Text = GetCurrent(intToFill._intCurr2)
        lblIntI3Val.Text = GetCurrent(intToFill._intCurr3)

        lblIntPowVal.Text = intToFill._intPower
        lblIntPressVal.Text = GetPressure(intToFill._intPress)
        lblIntCosfiVal.Text = GetCosfi(intToFill._intCosfi)
        lblIntTempVal.Text = intToFill._intTemp




    End Sub

    Private Sub FillListData()

        Dim StToAdd As String = ""
        Dim StToAdd2 As String = ""

        For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
            StToAdd = ""
            StToAdd2 = Intervents.GetIntStr(ConnectionUSB.InterventiLetti.IntItems(i)._intType)

            StToAdd = StToAdd + StToAdd2.PadRight(38)

            StToAdd2 = GetHours(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString + "h "
            StToAdd2 = StToAdd2 + GetMinutes(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "' "
            StToAdd2 = StToAdd2 + GetSeconds(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "'' "

            StToAdd = StToAdd + StToAdd2.PadRight(11)

            StToAdd2 = "V1:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt1.ToString + "V"
            StToAdd = StToAdd + StToAdd2.PadRight(8)
            StToAdd2 = "V2:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt2.ToString + "V"
            StToAdd = StToAdd + StToAdd2.PadRight(8)
            StToAdd2 = "V3:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt3.ToString + "V"
            StToAdd = StToAdd + StToAdd2.PadRight(8)

            StToAdd2 = "I1:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr1).ToString + "A"
            StToAdd = StToAdd + StToAdd2.PadRight(10)
            StToAdd2 = "I2:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr2).ToString + "A"
            StToAdd = StToAdd + StToAdd2.PadRight(10)
            StToAdd2 = "I3:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr3).ToString + "A"
            StToAdd = StToAdd + StToAdd2.PadRight(10)

            StToAdd2 = "Power:" + ConnectionUSB.InterventiLetti.IntItems(i)._intPower.ToString + "W"
            StToAdd = StToAdd + StToAdd2.PadRight(13)

            StToAdd2 = "Press:" + GetPressure(ConnectionUSB.InterventiLetti.IntItems(i)._intPress).ToString + "bar"
            StToAdd = StToAdd + StToAdd2.PadRight(15)


            StToAdd2 = "Cosfi:" + GetCosfi(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi).ToString + ""
            StToAdd = StToAdd + StToAdd2.PadRight(12)

            StToAdd2 = "Temp:" + ConnectionUSB.InterventiLetti.IntItems(i)._intTemp.ToString + "°C"
            StToAdd = StToAdd + StToAdd2.PadRight(11)

            lstInterventi.Items.Add(StToAdd)
        Next
    End Sub

    Private Sub EnableControlsInterventi(ByVal _EvConEn As Boolean)

        'Panel1.Enabled = _EvConEn
        HscrollInterventi.Enabled = _EvConEn
        lblNumInt.Visible = _EvConEn

        If _EvConEn Then

            HscrollInterventi.Enabled = True
            HscrollInterventi.Minimum = 1
            HscrollInterventi.Maximum = ConnectionUSB.InterventiLetti.Length
            HscrollInterventi.SmallChange = 1
            HscrollInterventi.LargeChange = 1
            HscrollInterventi.Value = HscrollInterventi.Minimum
            lblNumIntTitle.Text = "Faults number"
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillListData()
            FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))
            lstInterventi.SelectedItem = lstInterventi.Items.Item(HscrollInterventi.Value - 1)
        Else

            lblIntTypeVal.Text = ""
            lblIntTimeVal.Text = ""
            lblIntV1Val.Text = ""
            lblIntV2Val.Text = ""
            lblIntV3Val.Text = ""

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
            btnConn.Image = ApplicationChiUSB.My.Resources.disc
            btnConn.Text = "Disconnect"
            ConnectionActive = True
            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Serial number: " + ConnectionUSB.Matricola.ToUpper)
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add("Fw Ver: " + ConnectionUSB.FwVer.ToString("X4"))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add("Hw Ver: " + ConnectionUSB.HwVer.ToString("X4"))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add("Worked hours: " + GetHours(ConnectionUSB.OreLav).ToString("") + "h " + GetMinutes(ConnectionUSB.OreLav).ToString("00") + "' " + GetSeconds(ConnectionUSB.OreLav).ToString("00") + "''")
            StatusStrip1.Items.Add(New ToolStripSeparator)

        Else
            lblNotify.Text = "Connect and Read Faults"
            btnConn.Image = ApplicationChiUSB.My.Resources.conn
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
        Clipboard.SetText(strt)
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


        FileNameToSave = Strings.Right(Date.Now.Year.ToString, 2)
        FileNameToSave = FileNameToSave + Date.Now.Month.ToString("00")
        FileNameToSave = FileNameToSave + Date.Now.Day.ToString("00")

        ' Nome file standard
        FileNameToSave = "Faults" + "_" + FileNameToSave

        ' Se sto usando estensione .txt controllo se c'è già e eventualmente aggiungo h m s 
        If SaveFileDialog1.FilterIndex = 1 Then
            If System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\" + FileNameToSave + ".txt") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If        
        Else
            ' Se sto usando estensione .csv controllo se c'è già e eventualmente aggiungo h m s 
            If System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + "\" + FileNameToSave + ".csv") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If
        End If


        SaveFileDialog1.DefaultExt = ".txt"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.Filter = "Text File (*.txt)|*.txt" + "|" + "Comma separated value (*.csv)|*.csv" + "|" + "All files|*.*"
        SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
        SaveFileDialog1.Title = "Save Faults"
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.OverwritePrompt = True



        If Not (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then Exit Sub


        Try
            FileLogName = SaveFileDialog1.FileName
            file = New System.IO.StreamWriter(FileLogName, False)   ' No append

            ' Se CSV faccio in un modo altrimenti riempio come file txt
            If Strings.Right(FileLogName, 3).ToUpper = "CSV" Then
                file.WriteLine("")
                file.WriteLine("")
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intType.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intTime.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVolt1.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVolt2.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intVolt3.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr1.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr2.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr3.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intPower.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intPress.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi.ToString + ",")
                    file.Write(ConnectionUSB.InterventiLetti.IntItems(i)._intTemp.ToString)
                    file.Write(Environment.NewLine)
                Next
            Else
                file.WriteLine(New String("*", 80))
                file.WriteLine("* Faults recorded")
                file.WriteLine("* Date: " + Date.Now)
                file.WriteLine("* Serial number:" + ConnectionUSB.Matricola.ToUpper _
                               + " Fw Ver:" + ConnectionUSB.FwVer.ToString("X4") _
                               + " Hw Ver:" + ConnectionUSB.HwVer.ToString("X4"))
                file.WriteLine("* Worked hours:" + GetHours(ConnectionUSB.OreLav).ToString + "h" + GetMinutes(ConnectionUSB.OreLav).ToString("00") + "' " + GetSeconds(ConnectionUSB.OreLav).ToString("00") + "''")
                file.WriteLine(New String("*", 80))

                file.WriteLine()
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.WriteLine()
                    file.WriteLine(New String("-", 50))
                    file.WriteLine("-------------------------------------------------------------------------")
                    file.Write("Fault Type: ")
                    file.Write(Intervents.GetIntStr(ConnectionUSB.InterventiLetti.IntItems(i)._intType))
                    file.Write(New String(" ", 5))

                    file.Write("Fault Time: ")
                    file.Write(GetHours(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString + "h ")
                    file.Write(GetMinutes(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "' ")
                    file.Write(GetSeconds(ConnectionUSB.InterventiLetti.IntItems(i)._intTime).ToString("00") + "'' ")
                    file.Write(New String(" ", 5))
                    file.WriteLine()


                    file.Write("V1:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt1.ToString + "V   ")
                    file.Write("V2:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt2.ToString + "V   ")
                    file.Write("V3:" + ConnectionUSB.InterventiLetti.IntItems(i)._intVolt3.ToString + "V   ")
                    file.WriteLine()

                    file.Write("I1:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr1).ToString + "A   ")
                    file.Write("I2:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr2).ToString + "A   ")
                    file.Write("I3:" + GetCurrent(ConnectionUSB.InterventiLetti.IntItems(i)._intCurr3).ToString + "A   ")
                    file.WriteLine()

                    file.Write("Power:" + ConnectionUSB.InterventiLetti.IntItems(i)._intPower.ToString + "W   ")
                    file.Write("Pressure:" + GetPressure(ConnectionUSB.InterventiLetti.IntItems(i)._intPress).ToString + "bar   ")
                    file.WriteLine()

                    file.Write("Cosfi:" + GetCosfi(ConnectionUSB.InterventiLetti.IntItems(i)._intCosfi).ToString + "    ")
                    file.Write("Temp:" + ConnectionUSB.InterventiLetti.IntItems(i)._intTemp.ToString + "°C   ")
                    file.WriteLine()
                    file.WriteLine()
                Next

            End If


            file.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub


    Private Sub UpdateChartZ()


        Dim x(Intervents.TotTipiIntervento - 1) As String
        Dim y(Intervents.TotTipiIntervento - 1) As Double
        Dim myPane As GraphPane = zg1.GraphPane
        Dim myZList As New PointPairList
        Dim i As Integer

        zg1.GraphPane.CurveList.Clear()
        zg1.GraphPane.Title.Text = "Faults"

        For i = 0 To Intervents.TotTipiIntervento - 1
            myZList = New PointPairList
            myZList.Clear()
            myZList.Add(Intervents.enumNum(i), Intervents.GetOcc(Intervents.enumNum(i)), 111)
            'x(i) = Intervents.GetIntStr(Intervents.enumNum(i))
            x(i) = (Intervents.enumNum(i))
            ' y(i) = Intervents.GetOcc(Intervents.enumNum(i))
            Dim myCurve As CurveItem = myPane.AddBar(Intervents.enumNum(i).ToString + " " + Intervents.GetIntStr(Intervents.enumNum(i)), myZList, Intervents.returnColor(Intervents.enumNum(i)))
            'Dim myCurve As CurveItem = myPane.AddBar("", .ToString, Nothing, y, Color.Yellow)
        Next i




        'Dim myCurve As CurveItem = myPane.AddBar("Gigione", Nothing, y, Color.Green)

     


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
        myPane.XAxis.Title.Text = "Faults type"
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






        Dim colors As Color() = {Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple}
        'myCurve.Bar.Fill = New Fill(colors)
        'myCurve.Bar.Fill.Type = FillType.GradientByZ

        'myCurve.Bar.Fill.RangeMin = 0
        'myCurve.Bar.Fill.RangeMax = 4

        'myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45)
        'myPane.Fill = New Fill(Color.White, Color.FromArgb(255, 255, 225), 45)
        '' Tell ZedGraph to calculate the axis ranges
        zg1.AxisChange()
        ' Make sure the Graph gets redrawn
        zg1.Invalidate()

        zg1.Refresh()



    End Sub

    Private Sub UpdateChartZ_Second()


        Dim x(Intervents.TotTipiIntervento - 1) As String
        Dim y(Intervents.TotTipiIntervento - 1) As Double
        Dim myPane As GraphPane = ZedGraphFrm.zg1.GraphPane
        Dim myZList As New PointPairList
        Dim i As Integer

        ZedGraphFrm.zg1.GraphPane.CurveList.Clear()
        ZedGraphFrm.zg1.GraphPane.Title.Text = "Faults"

        For i = 0 To Intervents.TotTipiIntervento - 1
            myZList = New PointPairList
            myZList.Clear()
            myZList.Add(Intervents.enumNum(i), Intervents.GetOcc(Intervents.enumNum(i)), 111)
            'x(i) = Intervents.GetIntStr(Intervents.enumNum(i))
            x(i) = (Intervents.enumNum(i))
            ' y(i) = Intervents.GetOcc(Intervents.enumNum(i))
            Dim myCurve As CurveItem = myPane.AddBar(Intervents.enumNum(i).ToString + " " + Intervents.GetIntStr(Intervents.enumNum(i)), myZList, Intervents.returnColor(Intervents.enumNum(i)))
            'Dim myCurve As CurveItem = myPane.AddBar("", .ToString, Nothing, y, Color.Yellow)
        Next i




        'Dim myCurve As CurveItem = myPane.AddBar("Gigione", Nothing, y, Color.Green)




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
        myPane.XAxis.Title.Text = "Faults type"
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






        Dim colors As Color() = {Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple}
        'myCurve.Bar.Fill = New Fill(colors)
        'myCurve.Bar.Fill.Type = FillType.GradientByZ

        'myCurve.Bar.Fill.RangeMin = 0
        'myCurve.Bar.Fill.RangeMax = 4

        'myPane.Chart.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45)
        'myPane.Fill = New Fill(Color.White, Color.FromArgb(255, 255, 225), 45)
        '' Tell ZedGraph to calculate the axis ranges
        ZedGraphFrm.zg1.AxisChange()
        ' Make sure the Graph gets redrawn
        ZedGraphFrm.zg1.Invalidate()

        ZedGraphFrm.zg1.Refresh()



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

        'Chart1.Titles.Add("Fault graph")
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
        'lblNumInt.Text = (lstInterventi.SelectedIndex + 1).ToString & "/" & HscrollInterventi.Maximum
        'FillIntData(ConnectionUSB.InterventiLetti.IntItems(lstInterventi.SelectedIndex))
        'lstInterventi.SelectedItem = lstInterventi.Items.Item(lstInterventi.SelectedIndex)
    End Sub

    Private Sub HscrollInterventi_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HscrollInterventi.ValueChanged
        lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
        FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))
        lstInterventi.SelectedItem = lstInterventi.Items.Item(HscrollInterventi.Value - 1)
    End Sub

    Private Sub btnOpenGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenGraph.Click
        ZedGraphFrm.Show()
        UpdateChartZ_Second()

    End Sub
End Class
