Public Class MainFrm

    Private Sub MainFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Comusb As New USBClass("COM15")
        Dim arr As Byte()

        Comusb.PortName = "Com15"





        TextBox1.Text = arr(0) & arr(1)
    End Sub
End Class
