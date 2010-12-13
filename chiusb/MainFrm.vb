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
        lblNotify.Text = ConnectionUSB.RequestError(1, 2)
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

    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)


        Select Case intToFill._intType
            Case 1
                lblIntTypeVal.Text = "ON"
            Case 2
                lblIntTypeVal.Text = "OFF"

            Case 10
                lblIntTypeVal.Text = "Overcurrent" + " - Without Halt"
            Case 11
                lblIntTypeVal.Text = "Overvoltage" + " - Without Halt"
            Case 12
                lblIntTypeVal.Text = "Undervoltage" + " - Without Halt"
            Case 13
                lblIntTypeVal.Text = "Under Load" + " - Without Halt"
            Case 14
                lblIntTypeVal.Text = "Dry running" + " - Without Halt"
            Case 15
                lblIntTypeVal.Text = "Over Temperature" + " - Without Halt"
            Case 16
                lblIntTypeVal.Text = "Differential protection" + " - Without Halt"
            Case 17
                lblIntTypeVal.Text = "Current imbalance" + " - Without Halt"
            Case 18
                lblIntTypeVal.Text = "Asymmetry Voltages" + " - Without Halt"

            Case 10 + 10
                lblIntTypeVal.Text = "Overcurrent" + " - System Halt"
            Case 11 + 10
                lblIntTypeVal.Text = "Overvoltage" + " - System Halt"
            Case 12 + 10
                lblIntTypeVal.Text = "Undervoltage" + " - System Halt"
            Case 13 + 10
                lblIntTypeVal.Text = "Under Load" + " - System Halt"
            Case 14 + 10
                lblIntTypeVal.Text = "Dry running" + " - System Halt"
            Case 15 + 10
                lblIntTypeVal.Text = "Over Temperature" + " - System Halt"
            Case 16 + 10
                lblIntTypeVal.Text = "Differential protection" + " - System Halt"
            Case 17 + 10
                lblIntTypeVal.Text = "Current imbalance" + " - System Halt"
            Case 18 + 10
                lblIntTypeVal.Text = "Asymmetry Voltages" + " - System Halt"

            Case Else
                lblIntTypeVal.Text = intToFill._intType
        End Select


        lblIntTimeVal.Text = GetHours(intToFill._intTime) & "h " & GetMinutes(intToFill._intTime) & "' " & GetSeconds(intToFill._intTime) & "''"

        lblIntV1Val.Text = intToFill._intVolt1
        lblIntV2Val.Text = intToFill._intVolt2
        lblIntV3Val.Text = intToFill._intVolt3

        lblIntI1Val.Text = intToFill._intCurr1 / 10
        lblIntI2Val.Text = intToFill._intCurr2 / 10
        lblIntI3Val.Text = intToFill._intCurr3 / 10

        lblIntPowVal.Text = intToFill._intPower
        lblIntPressVal.Text = intToFill._intPress / 10
        lblIntCosfiVal.Text = intToFill._intCosfi / 100
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
            btnConn.Image = WindowsApplication1.My.Resources.disc
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
            btnConn.Image = WindowsApplication1.My.Resources.conn
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
        Dim i As UInteger

        SaveFileDialog1.FileName = ".txt"
        SaveFileDialog1.DefaultExt = ".txt"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.Filter = "All files|*.*" + "|" + "Text File (*.txt)|*.txt" + "|" + "Comma separated value (*.csv)|*.csv"
        SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
        SaveFileDialog1.Title = "Save Faults"



        If Not (SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then Exit Sub
        Try
            FileLogName = SaveFileDialog1.FileName
            file = New System.IO.StreamWriter(FileLogName, False)   ' No append

            file.WriteLine("*************************************************************************")
            file.WriteLine("* Faults recorded")
            file.WriteLine("* Date: " + Date.Now)
            file.WriteLine("* Serial number:" + ConnectionUSB.Matricola.ToUpper _
                           + " Fw Ver:" + ConnectionUSB.FwVer.ToString("X4") _
                           + " Hw Ver:" + ConnectionUSB.HwVer.ToString("X4") _
                           + Environment.NewLine _
                           + " Worked hours:" + GetHours(ConnectionUSB.OreLav).ToString + "h" + GetMinutes(ConnectionUSB.OreLav).ToString("00") + "' " + GetSeconds(ConnectionUSB.OreLav).ToString("00") + "''")
            file.WriteLine("*************************************************************************")

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

            file.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


    End Sub

  
    Private Sub PictureLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureLogo.Click
        Process.Start("http://www.electroil.it/inglese/index.html")
    End Sub
End Class
