Public Class MainFrm
    Dim Comusb As USBClass

    Private Sub MainFrm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        CloseProgram()

    End Sub

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Inter As New InterventList

        Comusb = New USBClass("COM15", Me.ListBox1)
        ListBox1.Items.Add("")
        Dim arr As Byte() = {0, &HFF, &HFF, &HFF, &HFF, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23}
        Dim arr2 As Byte() = {&HF3, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23}

        Inter.AddArrToInt(arr)

        Inter.AddArrToInt(arr2)

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
        TextBox1.Text = Comusb.RequestError(1, 2)
    End Sub

    Private Sub btnHello_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHello.Click
        TextBox1.Text = Comusb.RequestHello(1, 2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = Comusb.RequestInterventi(1, 2)
    End Sub
End Class
