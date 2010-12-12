Public Class MainFrm


    Private Sub MainFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseProgram()

    End Sub

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'TextBox1.Text = arr(0) & arr(1)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        CloseProgram()
        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        CloseProgram()
        Me.Close()
    End Sub

    Private Sub btnRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        TextBox1.Text = ConnectionUSB.RequestError(1, 2)
    End Sub

    Private Sub btnHello_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHello.Click
        TextBox1.Text = ConnectionUSB.RequestHello()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        myIntList = ConnectionUSB.RequestInterventi(0, 0)
        If myIntList Is Nothing Then
            TextBox1.Text = "NO LIST"
        Else

            HscrollInterventi.Enabled = True
            HscrollInterventi.Minimum = 1
            HscrollInterventi.Maximum = myIntList.Length
            HscrollInterventi.SmallChange = 1
            HscrollInterventi.LargeChange = 10
            HscrollInterventi.Value = HscrollInterventi.Minimum
            lblNumInt.Text = HscrollInterventi.Value & "/" & HscrollInterventi.Maximum
            FillIntData(myIntList.IntItems(HscrollInterventi.Value))

            TextBox1.Text = "OK LIST #" & myIntList.Length
        End If

    End Sub

    Private Sub btnConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConn.Click
        If Not ConnectionUSB Is Nothing Then
            ConnectionUSB = Nothing
        End If

        ConnectionUSB = New USBClass(ListBox1)
        ConnectionUSB.ConnectDevice()
    End Sub



    Private Sub HscrollInterventi_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HscrollInterventi.Scroll

        lblNumInt.Text = e.NewValue & "/" & HscrollInterventi.Maximum
        FillIntData(myIntList.IntItems(e.NewValue - 1))

    End Sub



End Class
