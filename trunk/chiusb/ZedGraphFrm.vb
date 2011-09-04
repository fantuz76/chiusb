Imports ZedGraph

Public Class ZedGraphFrm

    Private Sub ZedGraphFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    
    End Sub

    Private Sub SetSize()
        zg1.Location = New Point(10, 10)
        ' Leave a small margin around the outside of the control
        zg1.Size = New Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20)

        zg2.Location = New Point(10, 10)
        ' Leave a small margin around the outside of the control
        zg2.Size = New Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20)
    End Sub

    Private Sub ZedGraphFrm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SetSize()
    End Sub

   
End Class