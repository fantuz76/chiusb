Imports System.Windows.Forms.DataVisualization.Charting.Utilities

Imports System.Windows.Forms.DataVisualization.Charting

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
                    EnableControlsInterventi(True)
                    lblNotify.Text = "Faults found " & ConnectionUSB.InterventiLetti.Length

                    Intervents = New InterventiTypeClass(ConnectionUSB.InterventiLetti)
                    UpdateChart()
                Else
                    EnableControlsInterventi(False)
                    lblNotify.Text = "No Faults"
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub HscrollInterventi_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HscrollInterventi.Scroll

        lblNumInt.Text = e.NewValue & "/" & HscrollInterventi.Maximum
        FillIntData(ConnectionUSB.InterventiLetti.IntItems(e.NewValue - 1))

    End Sub


    Private Sub Draw_header()
        Dim toolTip1 As New ToolTip()
  


        ' Blocca dimensione minima finestra
        Me.MinimumSize = Me.Size

       

        UpdateChart()
        'Chart1.Series.Add("Gigione")
        'Chart1.Series.Add("Paolo")
        'Chart1.Series("Paolo").AxisLabel = "paoloin2"
        'Chart1.Series("Paolo").ResetIsValueShownAsLabel()
        'Chart1.Series("Paolo").Points.AddY(22)
        'Chart1.Series("Gigione").Points.AddY(55)
        'Chart1.Series("Series1").Points.AddY(23)

        lblGenericTmp.Text = "Program developing " + Environment.NewLine _
                            + "Sw Version " + SwVersion + "   " + "2010"

        btnRead.Visible = False
        Button2.Visible = False
        StatusStrip1.Items.Clear()
        ListBoxLog.Items.Clear()
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

    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)

        lblIntTypeVal.Text = Intervents.GetIntStr(intToFill._intType)

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



    Private Sub EnableControlsInterventi(ByVal _EvConEn As Boolean)

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
            lblNumIntTitle.Text = "Faults number"
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))
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

        SaveFileDialog1.FileName = "Faults"
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
                    file.Write("Temperature" + ConnectionUSB.InterventiLetti.IntItems(i)._intTemp.ToString + "°C   ")
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

    Private Sub UpdateChart()

        Chart1.Series.Clear()

        'Chart1.DataSource = Intervents
        Chart1.ChartAreas.Clear()
        Chart1.ChartAreas.Add(0)
        Chart1.ChartAreas(0).AxisY.IntervalAutoMode = True
        Chart1.ChartAreas(0).AxisX.IntervalAutoMode = True
        Chart1.ChartAreas(0).AxisX.Interval = 1
        Chart1.Series.Add(0)
        Chart1.Series(0).XValueMember = " XVALMEM"
        Chart1.Series(0).YValueMembers = " YVALMEM"

        'Chart1.Series(0).Points.AddY(2)
        Chart1.Series(0).YValueType = ChartValueType.Int32
        'Chart1.Series(0).Points.AddXY("FF", 35)
        'Chart1.Series(0).Points.AddY(3)

        Chart1.Series(0).XAxisType = DataVisualization.Charting.AxisType.Primary
        Chart1.Series(0).XValueType = DataVisualization.Charting.ChartValueType.String
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Column
        ''Chart1.Series("Gigione")
        For i = 0 To Intervents.TotTipiIntervento - 1
            'Chart1.Series(0).Points.AddY(CType(Intervents.GetOcc(Intervents.enumNum(i)), Double))
            Chart1.Series(0).IsXValueIndexed = True

            Chart1.Series(0).Points.AddXY(Intervents.enumStr(i), Intervents.GetOcc(Intervents.enumNum(i)))



        Next
    End Sub
    Private Sub PictureLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureLogo.Click
        Process.Start("http://www.electroil.it/inglese/index.html")
    End Sub
End Class
