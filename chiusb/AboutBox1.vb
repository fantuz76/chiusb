﻿Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Imposta il titolo del form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Information about {0}", ApplicationTitle)
        ' Inizializza tutto il testo visualizzato nella finestra di dialogo Informazioni su.
        ' TODO: Personalizzare le informazioni sull'assembly dell'applicazione nel riquadro "Applicazione" 
        '    della finestra delle proprietà del progetto (accessibile dal menu "Progetto").
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}.{1}.{2}", My.Application.Info.Version.Major.ToString, My.Application.Info.Version.MajorRevision.ToString, My.Application.Info.Version.Minor.ToString, My.Application.Info.Version.MinorRevision.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
