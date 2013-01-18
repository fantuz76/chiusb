'Imports System.Windows.Forms.DataVisualization.Charting.Utilities
'Imports System.Windows.Forms.DataVisualization.Charting
Imports ZedGraph
Imports System.Random
Imports System.Globalization.CultureInfo
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
        lblNotify.Text = "Please Wait"
        GroupBox1.Enabled = False



        'FormWait.Cursor = Cursors.WaitCursor
        'FormWait.Show()
        'FormWait.Left = Me.Left + (Me.Width - FormWait.Width) / 2
        'FormWait.Top = Me.Top + (Me.Height - FormWait.Height) / 2
        EnableControlsInterventi(False)

        If ConnectionIsActive Then
            If Not ConnectionUSB Is Nothing Then
                ConnectionUSB.ForceClosePort()
                ConnectionUSB.LogDisplay("Disconnect")
                ConnectionUSB = Nothing
            End If
            SetConn(CONNECT_NONE)
        Else
            If Not ConnectionUSB Is Nothing Then ConnectionUSB = Nothing

            ConnectionUSB = New USBClass(ListBoxLog)
            If ConnectionUSB.ConnectDevice() Then
                LastCOMUsed = ConnectionUSB.GetCOMName
                WriteConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "LastCOMUsed", LastCOMUsed)
                SetConn(CONNECT_USB)
                Application.DoEvents()
                If ConnectionUSB.RequestInterventi(0, 0) Then
                    lblNotify.Text = "Alarms found = " & ConnectionUSB.InterventiLetti.Length
                    If ConnectionUSB.InterventiLetti.IntItems.Length > 0 Then
                        Intervents = New InterventiTypeClass(ConnectionUSB.InterventiLetti)
                        EnableControlsInterventi(True, ConnectionUSB)
                    End If

                Else
                    EnableControlsInterventi(False)
                    lblNotify.Text = "No alarms"
                    SetConn(CONNECT_NONE)
                    EnableControlsInterventi(False)
                End If
            Else
                SetConn(CONNECT_NONE)
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
            Me.Text = My.Application.Info.Title + String.Format(" - {0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.Minor.ToString, My.Application.Info.Version.Build.ToString, My.Application.Info.Version.MinorRevision.ToString)
        Else
            Me.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        ' Blocca dimensione minima finestra
        Me.MinimumSize = TabPage1.Size

        TabControl1.TabPages.Remove(TabControl1.TabPages(1))
        lblGenericTmp.Text = "Program developing " + Environment.NewLine _
                            + "Sw Version " + "" + "   " + "2010"




        lblIntVolt.Text = "Voltages [Volt]"
        lblIntVolt.TextAlign = ContentAlignment.MiddleCenter
        lblIntCurrent.Text = "Currents [Amp]"
        lblIntCurrent.TextAlign = ContentAlignment.MiddleCenter

        lblIntV1Desc.Text = "V1-2"
        lblIntV2Desc.Text = "V1-3"
        lblIntV3Desc.Text = "V2-3"
        lblIntI1Desc.Text = "I1"
        lblIntI2Desc.Text = "I2"
        lblIntI3Desc.Text = "I3"



        StatusStrip1.Items.Clear()
        ListBoxLog.Items.Clear()
        lstInterventi.Items.Clear()
        EnableControlsInterventi(False)
        SetConn(CONNECT_NONE)


        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 5000
        toolTip1.InitialDelay = 800
        toolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        toolTip1.ShowAlways = True

        ' Set up the ToolTip text for the Button and Checkbox.
        toolTip1.SetToolTip(Me.btnOpen, "Open existing csv alarms file")
        toolTip1.SetToolTip(Me.btnSaveInt, "Save all alarms on a file")
        toolTip1.SetToolTip(Me.btnConn, "Connect to Device")
        toolTip1.SetToolTip(Me.HscrollInterventi, "Scroll alarms here")
        toolTip1.SetToolTip(Me.ListBoxLog, "Program events")
        toolTip1.SetToolTip(Me.PictureLogo, "Electroil internet site")
        toolTip1.SetToolTip(Me.btnOpenGraph, "Show alarms Histogram")

        'lstInterventi.HorizontalScrollbar = True    
        lblHeaderList.Text = ""
        lblHeaderList2.Text = ""


    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)

        lblIntTypeVal.Text = Intervents.GetIntStr(intToFill._intType)
        'lblIntTypeVal.ForeColor = Intervents.returnColor(intToFill._intType)
        lblIntTypeVal.ForeColor = Intervents.GetIntColor(intToFill._intType)



        'lblIntTimeVal.Text = (2000 + GetYear(intToFill._intTime)).ToString("0000") & "/" & GetMonth(intToFill._intTime).ToString("00") & "/" & GetDay(intToFill._intTime).ToString("00") & " " & GetHours(intToFill._intTime).ToString("00") & "h" & GetMinutes(intToFill._intTime).ToString("00") & "'" & GetSeconds(intToFill._intTime).ToString("00") & "''"
        lblIntTimeVal.Text = GetHours(intToFill._intTime).ToString("00") & "h" & GetMinutes(intToFill._intTime).ToString("00") & "'" & GetSeconds(intToFill._intTime).ToString("00") & "''"

        lblIntV1Val.Text = intToFill._intV12_rms
        lblIntV2Val.Text = intToFill._intV13_rms
        lblIntV3Val.Text = intToFill._intV23_rms

        lblIntI1Val.Text = GetCurrent(intToFill._intI1_rms)
        lblIntI2Val.Text = GetCurrent(intToFill._intI2_rms)
        lblIntI3Val.Text = GetCurrent(intToFill._intI3_rms)

        
        lblIntPowVal.Text = (GetPowerKiloWatt(intToFill._intPower)).ToString("F1", GetCultureInfo("en-GB"))

        lblIntRPMVal.Text = GetRPM(intToFill._intRPM)
        lblIntTragFreqVal.Text = GetFreq(intToFill._intFreq)
        lblIntCosfiVal.Text = GetCosfi(intToFill._intCosfi)
        lblIntTempVal.Text = GetTemperature(intToFill._intTemp)

        lblIntVConVal.Text = GetVoltCond(intToFill._intVoltCond)

    End Sub

    Private Sub FillListData()
        Dim strss As String
        lblHeaderList.Text = CreateLineStringHeaderInt()
        lblHeaderList2.Text = CreateLineStringHeaderIntUnita()
        For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
            strss = CreateLineStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i, ConnectionUSB.InterventiLetti.Length - 1)
            lstInterventi.Items.Add(CreateLineStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i, ConnectionUSB.InterventiLetti.Length - 1))
        Next
    End Sub

    Private Sub EnableControlsInterventi(ByVal _EvConEn As Boolean, Optional ByVal Connection As USBClass = Nothing)
        pnlButAlarms.Enabled = _EvConEn
        Panel1.Enabled = _EvConEn
        HscrollInterventi.Enabled = _EvConEn
        lblNumInt.Visible = _EvConEn

        If Connection Is Nothing Then _EvConEn = False

        If _EvConEn Then

            HscrollInterventi.Enabled = True
            HscrollInterventi.Minimum = 1
            HscrollInterventi.Maximum = Connection.InterventiLetti.Length
            HscrollInterventi.SmallChange = 1
            HscrollInterventi.LargeChange = 1
            HscrollInterventi.Value = HscrollInterventi.Minimum
            lblNumIntTitle.Text = "Alarms number"
            lblNumInt.Text = HscrollInterventi.Maximum - HscrollInterventi.Value + 1 & "/" & HscrollInterventi.Maximum  'voleva numerazione inversa
            'lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillListData()
            FillIntData(Connection.InterventiLetti.IntItems(HscrollInterventi.Value - 1))
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
            lblIntRPMVal.Text = ""
            lblIntCosfiVal.Text = ""
            lblIntTempVal.Text = ""

            lblNumInt.Text = ""
            lblNumIntTitle.Text = ""
            lstInterventi.Items.Clear()
        End If


    End Sub


    Private Sub SetConn(ByVal _ConnEnable As Integer)
        If _ConnEnable = CONNECT_USB Then

            btnConn.Image = ApplicationUSB.My.Resources.disc
            btnConn.Text = "Disconnect"
            btnOpen.Enabled = False

            ConnectionIsActive = True
            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Serial number: " + ConnectionUSB.Matricola.ToUpper.PadRight(8))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Pn: " + (GetNomPowerKiloWatt(ConnectionUSB.PotNom)).ToString("F2", GetCultureInfo("en-GB")) + "Kw").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Vn: " + GetVoltage(ConnectionUSB.VoltNom).ToString("") + "V").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("In: " + GetCurrent(ConnectionUSB.CurrNom).ToString("") + "A").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Freq Radio: " + GetFreqRadio(ConnectionUSB.FreqRadio).ToString("") + "Hz").PadRight(17))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            'StatusStrip1.Items.Add("Fw Ver: " + ConnectionUSB.FwVer.ToString("X4"))
            'StatusStrip1.Items.Add(New ToolStripSeparator)

            'StatusStrip1.Items.Add("Hw Ver: " + ConnectionUSB.HwVer.ToString("X4"))
            'StatusStrip1.Items.Add(New ToolStripSeparator)


        ElseIf _ConnEnable = CONNECT_FILE Then


            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Serial number: " + ConnectionUSB.Matricola.ToUpper.PadRight(8))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Pn: " + (GetNomPowerKiloWatt(ConnectionUSB.PotNom)).ToString("F2", GetCultureInfo("en-GB")) + "Kw").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Vn: " + GetVoltage(ConnectionUSB.VoltNom).ToString("") + "V").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("In: " + GetCurrent(ConnectionUSB.CurrNom).ToString("") + "A").PadRight(12))
            StatusStrip1.Items.Add(New ToolStripSeparator)

            StatusStrip1.Items.Add(("Freq Radio: " + GetFreqRadio(ConnectionUSB.FreqRadio).ToString("") + "Hz").PadRight(17))
            StatusStrip1.Items.Add(New ToolStripSeparator)

        Else
            lblNotify.Text = "Connect or open file"

            btnOpen.Enabled = True
            btnConn.Image = ApplicationUSB.My.Resources.conn
            btnConn.Text = "Connect"

            ConnectionIsActive = False
            StatusStrip1.Items.Clear()
            StatusStrip1.Items.Add(Date.Now)
            StatusStrip1.Items.Add(New ToolStripSeparator)
            StatusStrip1.Items.Add("Device Not Connected")
            StatusStrip1.Items.Add(New ToolStripSeparator)
            lblHeaderList.Text = ""
            lblHeaderList2.Text = ""

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

        SaveFileDialog1.DefaultExt = ".csv"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.Filter = "Comma separated value (*.csv)|*.csv" + "|" + "Text File (*.txt)|*.txt" + "|" + "All files|*.*"
        SaveFileDialog1.InitialDirectory = FolderStr
        SaveFileDialog1.Title = "Save alarms"
        SaveFileDialog1.CheckPathExists = True
        SaveFileDialog1.OverwritePrompt = True


        FileNameToSave = "SN" + ConnectionUSB.Matricola.PadLeft(6, "0") + "_"
        FileNameToSave = FileNameToSave + Strings.Right(Date.Now.Year.ToString, 2)
        FileNameToSave = FileNameToSave + Date.Now.Month.ToString("00")
        FileNameToSave = FileNameToSave + Date.Now.Day.ToString("00")

        ' Nome file standard
        FileNameToSave = "InvAlarms" + "_" + FileNameToSave

        ' Se sto usando estensione .txt controllo se c'è già e eventualmente aggiungo h m s 
        If SaveFileDialog1.FilterIndex = 1 Then
            If System.IO.File.Exists(FolderStr + "\" + FileNameToSave + ".csv") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If
        Else
            ' Se sto usando estensione .csv controllo se c'è già e eventualmente aggiungo h m s 
            If System.IO.File.Exists(FolderStr + "\" + FileNameToSave + ".txt") Then
                SaveFileDialog1.FileName = FileNameToSave + "(" + Date.Now.Hour.ToString("00") + "h" + Date.Now.Minute.ToString("00") + "." + Date.Now.Second.ToString("00") + ")"
            Else
                SaveFileDialog1.FileName = FileNameToSave
            End If
        End If





        If Not (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then Exit Sub


        Try
            ' Salva in Config.xml nuovo valore
            WriteConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaSaveAlarms", System.IO.Path.GetDirectoryName(SaveFileDialog1.FileName))

            FileLogName = SaveFileDialog1.FileName
            file = New System.IO.StreamWriter(FileLogName, False)   ' No append

            ' Se CSV faccio in un modo altrimenti riempio come file txt
            If Strings.Right(FileLogName, 3).ToUpper = "CSV" Then
                Dim enc As New System.Text.UTF8Encoding()

                'file.Write(enc.GetString(ConnectionUSB.DatiSetHello()))
                'file.WriteLine("")
                file.WriteLine(CreateCSVStringHelloValues())
                file.WriteLine(CreateCSVStringHeaderInt())
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.WriteLine(CreateCSVStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i, ConnectionUSB.InterventiLetti.Length - 1))

                Next
            Else
                file.WriteLine(New String("*", 100))
                file.WriteLine("* Alarms recorded")
                file.WriteLine("* Date: " + Date.Now)
                file.WriteLine("* Serial number:" + ConnectionUSB.Matricola.ToUpper)

                '               + " Fw Ver:" + ConnectionUSB.FwVer.ToString("X4") _
                '               + " Hw Ver:" + ConnectionUSB.HwVer.ToString("X4"))

                file.WriteLine("* Pnom: " + (GetNomPowerKiloWatt(ConnectionUSB.PotNom)).ToString("F3", GetCultureInfo("en-GB")) + "Kw")
                file.WriteLine("* Vnom: " + GetVoltage(ConnectionUSB.VoltNom).ToString("") + "V")
                file.WriteLine("* Inom: " + GetCurrent(ConnectionUSB.CurrNom).ToString("") + "A")
                file.WriteLine("* FRadio: " + GetFreqRadio(ConnectionUSB.FreqRadio).ToString("") + "Hz")

                file.WriteLine(New String("*", 100))

                file.WriteLine(CreateLineStringHeaderInt())
                file.WriteLine(CreateLineStringHeaderIntUnita())
                file.WriteLine()
                For i = 0 To ConnectionUSB.InterventiLetti.Length - 1
                    file.WriteLine(CreateLineStringIntervento(ConnectionUSB.InterventiLetti.IntItems(i), i, ConnectionUSB.InterventiLetti.Length - 1))
                Next

            End If


            file.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub



    Private Sub PictureLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureLogo.Click
        Process.Start("http://www.electroil.it")
    End Sub



    Private Sub lstInterventi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstInterventi.SelectedIndexChanged
        HscrollInterventi.Value = lstInterventi.SelectedIndex + 1
    End Sub

    Private Sub HscrollInterventi_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HscrollInterventi.ValueChanged
        If ConnectionUSB.InterventiLetti.IntItems.Length > 0 Then
            'lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            lblNumInt.Text = HscrollInterventi.Maximum - HscrollInterventi.Value + 1 & "/" & HscrollInterventi.Maximum  'voleva numerazione inversa
            FillIntData(ConnectionUSB.InterventiLetti.IntItems(HscrollInterventi.Value - 1))

            If lstInterventi.Items.Count >= HscrollInterventi.Value Then
                lstInterventi.SelectedItem = lstInterventi.Items.Item(HscrollInterventi.Value - 1)
            End If
        End If

    End Sub



    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChartXY.Click, btnOpenGraph.Click
        If sender Is btnChartXY Then
            ZedGraphFrm.UpdateChartZ_XY()
            ZedGraphFrm.zg2.Visible = True
            ZedGraphFrm.zg1.Visible = False
        ElseIf sender Is btnOpenGraph Then
            ZedGraphFrm.UpdateChartZ_Second()
            ZedGraphFrm.zg1.Visible = True
            ZedGraphFrm.zg2.Visible = False
        End If
        ZedGraphFrm.Panel1.Visible = ZedGraphFrm.zg2.Visible
        ZedGraphFrm.HScrollIntGraph.Visible = ZedGraphFrm.zg2.Visible
        ZedGraphFrm.DrawHeader()
        ZedGraphFrm.Show()

    End Sub





    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim FileNameToOpen As String = ""
        Dim FolderStr As String

        FolderStr = System.IO.Path.GetDirectoryName(ReadConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaSaveAlarms") + "\")
        If System.IO.Directory.Exists(FolderStr) Then

        Else
            FolderStr = UsrDocData
        End If

        OpenFileDialog1.DefaultExt = ".csv"
        OpenFileDialog1.AddExtension = True
        OpenFileDialog1.Filter = "Comma separated value (*.csv)|*.csv" '+ "|" + "Text File (*.txt)|*.txt" + "|" + "All files|*.*"
        OpenFileDialog1.InitialDirectory = FolderStr
        OpenFileDialog1.Title = "Open alarms"
        OpenFileDialog1.CheckPathExists = True
        OpenFileDialog1.FileName = ""



        If Not (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then Exit Sub

        FileNameToOpen = OpenFileDialog1.FileName


        If Not ConnectionUSB Is Nothing Then ConnectionUSB = Nothing
        ConnectionUSB = New USBClass(ListBoxLog)

        Try
            ' Salva in Config.xml nuovo valore
            WriteConfigXML(UsrAppData + XMLCFG, "SistemaUtente", "CartellaSaveAlarms", System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName))
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        If ConnectionUSB.RequestHelloFromFile(FileNameToOpen) Then
            SetConn(CONNECT_FILE)
            If ConnectionUSB.RequestInterventiFromFile(FileNameToOpen) Then
                lblNotify.Text = "Alarms found = " & ConnectionUSB.InterventiLetti.Length
                EnableControlsInterventi(False)
                'ConnectionUSB.Matricola = 1
                If ConnectionUSB.InterventiLetti.IntItems.Length > 0 Then
                    Intervents = New InterventiTypeClass(ConnectionUSB.InterventiLetti)
                    EnableControlsInterventi(True, ConnectionUSB)

                End If

            Else
                EnableControlsInterventi(False)
                lblNotify.Text = "No alarms"
                SetConn(CONNECT_NONE)
                EnableControlsInterventi(False)
            End If
        Else
            SetConn(CONNECT_NONE)
        End If








    End Sub
End Class

