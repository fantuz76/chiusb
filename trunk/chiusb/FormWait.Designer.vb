<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWait
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblWait1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnWaitOK = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblWait1
        '
        Me.lblWait1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWait1.ForeColor = System.Drawing.Color.Black
        Me.lblWait1.Location = New System.Drawing.Point(93, 46)
        Me.lblWait1.Name = "lblWait1"
        Me.lblWait1.Size = New System.Drawing.Size(149, 41)
        Me.lblWait1.TabIndex = 1
        Me.lblWait1.Text = "Please Wait..."
        Me.lblWait1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ApplicationChiUSB.My.Resources.Resources.ajax_loader
        Me.PictureBox1.Location = New System.Drawing.Point(45, 90)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(229, 32)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnWaitOK
        '
        Me.btnWaitOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnWaitOK.Location = New System.Drawing.Point(110, 140)
        Me.btnWaitOK.Name = "btnWaitOK"
        Me.btnWaitOK.Size = New System.Drawing.Size(100, 32)
        Me.btnWaitOK.TabIndex = 2
        Me.btnWaitOK.Text = "OK"
        Me.btnWaitOK.UseVisualStyleBackColor = True
        '
        'FormWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 184)
        Me.Controls.Add(Me.btnWaitOK)
        Me.Controls.Add(Me.lblWait1)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormWait"
        Me.ShowInTaskbar = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblWait1 As System.Windows.Forms.Label
    Friend WithEvents btnWaitOK As System.Windows.Forms.Button
End Class
