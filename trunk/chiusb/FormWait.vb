Public Class FormWait

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()
    End Sub

    Private Sub FormWait_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.ShowInTaskbar = False
        Me.TopMost = True
        btnWaitOK.Visible = False
        PictureBox1.Left = Me.Width / 2 - PictureBox1.Width / 2
        lblWait1.Left = Me.Width / 2 - lblWait1.Width / 2
    End Sub
End Class