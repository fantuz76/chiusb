Public Class FormWait

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.DoEvents()
    End Sub
End Class