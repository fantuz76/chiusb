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
        myIntList = ConnectionUSB.RequestInterventi(0, 0)
        If myIntList Is Nothing Then
            EnableControlsInterventi(False)
            lblNotify.Text = "No Events"
        Else
            EnableControlsInterventi(True)
            lblNotify.Text = "Events found " & myIntList.Length
        End If

    End Sub

    Private Sub btnConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConn.Click
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

                Button2.PerformClick()
            End If
        End If
    End Sub



    Private Sub HscrollInterventi_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HscrollInterventi.Scroll

        lblNumInt.Text = e.NewValue & "/" & HscrollInterventi.Maximum
        FillIntData(myIntList.IntItems(e.NewValue - 1))

    End Sub




    Private Sub Draw_header()
        ListBoxLog.Items.Clear()
        EnableControlsInterventi(False)
        SetConn(False)
        Me.Text = "USB Configuration " + SwVersion

    End Sub

    Private Sub FillIntData(ByVal intToFill As InterventSingle)
        Dim _ore, _minuti, _secondi As Integer

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


        _ore = intToFill._intTime \ 3600
        _minuti = (intToFill._intTime Mod 3600) \ 60
        _secondi = ((intToFill._intTime Mod 3600) Mod 60)
        lblIntTimeVal.Text = _ore & "h " & _minuti & "' " & _secondi & "''"

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
            HscrollInterventi.Maximum = myIntList.Length
            HscrollInterventi.SmallChange = 1
            HscrollInterventi.LargeChange = 1
            HscrollInterventi.Value = HscrollInterventi.Minimum
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillIntData(myIntList.IntItems(HscrollInterventi.Value - 1))
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
        End If


    End Sub


    Private Sub SetConn(ByVal _ConnEnable As Boolean)

        If _ConnEnable Then
            btnConn.Image = WindowsApplication1.My.Resources.disc
            btnConn.Text = "Disconnect"
            ConnectionActive = True
        Else
            lblNotify.Text = "Connect and Read Events"
            btnConn.Image = WindowsApplication1.My.Resources.conn
            btnConn.Text = "Connect"
            ConnectionActive = False
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
End Class
