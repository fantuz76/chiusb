<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZedGraphFrm
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ZedGraphFrm))
        Me.zg1 = New ZedGraph.ZedGraphControl
        Me.zg2 = New ZedGraph.ZedGraphControl
        Me.lblXPos = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSpan = New System.Windows.Forms.Label
        Me.lblXPosName = New System.Windows.Forms.Label
        Me.numSpan = New System.Windows.Forms.NumericUpDown
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblIntV3Val = New System.Windows.Forms.Label
        Me.lblIntV3Desc = New System.Windows.Forms.Label
        Me.lblIntV2Val = New System.Windows.Forms.Label
        Me.lblIntV2Desc = New System.Windows.Forms.Label
        Me.lblIntV1Val = New System.Windows.Forms.Label
        Me.lblIntV1Desc = New System.Windows.Forms.Label
        Me.lblIntVolt = New System.Windows.Forms.Label
        Me.btnCenter = New System.Windows.Forms.Button
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblIntCurrent = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblIntI3Val = New System.Windows.Forms.Label
        Me.lblIntI3Desc = New System.Windows.Forms.Label
        Me.lblIntI2Val = New System.Windows.Forms.Label
        Me.lblIntI2Desc = New System.Windows.Forms.Label
        Me.lblIntI1Val = New System.Windows.Forms.Label
        Me.lblIntI1Desc = New System.Windows.Forms.Label
        Me.HScrollIntGraph = New System.Windows.Forms.HScrollBar
        Me.btnSaveAs = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.numSpan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'zg1
        '
        Me.zg1.AutoSize = True
        Me.zg1.Location = New System.Drawing.Point(12, 12)
        Me.zg1.Name = "zg1"
        Me.zg1.ScrollGrace = 0
        Me.zg1.ScrollMaxX = 0
        Me.zg1.ScrollMaxY = 335
        Me.zg1.ScrollMaxY2 = 0
        Me.zg1.ScrollMinX = 0
        Me.zg1.ScrollMinY = 0
        Me.zg1.ScrollMinY2 = 0
        Me.zg1.Size = New System.Drawing.Size(655, 367)
        Me.zg1.TabIndex = 15
        '
        'zg2
        '
        Me.zg2.AutoSize = True
        Me.zg2.Location = New System.Drawing.Point(123, 132)
        Me.zg2.Name = "zg2"
        Me.zg2.ScrollGrace = 0
        Me.zg2.ScrollMaxX = 0
        Me.zg2.ScrollMaxY = 335
        Me.zg2.ScrollMaxY2 = 0
        Me.zg2.ScrollMinX = 0
        Me.zg2.ScrollMinY = 0
        Me.zg2.ScrollMinY2 = 0
        Me.zg2.Size = New System.Drawing.Size(570, 276)
        Me.zg2.TabIndex = 16
        '
        'lblXPos
        '
        Me.lblXPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblXPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXPos.Location = New System.Drawing.Point(7, 23)
        Me.lblXPos.Name = "lblXPos"
        Me.lblXPos.Size = New System.Drawing.Size(39, 15)
        Me.lblXPos.TabIndex = 20
        Me.lblXPos.Text = "0"
        Me.lblXPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.lblSpan)
        Me.Panel1.Controls.Add(Me.lblXPosName)
        Me.Panel1.Controls.Add(Me.numSpan)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.btnCenter)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.lblXPos)
        Me.Panel1.Location = New System.Drawing.Point(9, 454)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(684, 79)
        Me.Panel1.TabIndex = 23
        '
        'lblSpan
        '
        Me.lblSpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpan.Location = New System.Drawing.Point(593, 56)
        Me.lblSpan.Name = "lblSpan"
        Me.lblSpan.Size = New System.Drawing.Size(39, 15)
        Me.lblSpan.TabIndex = 27
        Me.lblSpan.Text = "Span:"
        Me.lblSpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblXPosName
        '
        Me.lblXPosName.Location = New System.Drawing.Point(6, 6)
        Me.lblXPosName.Name = "lblXPosName"
        Me.lblXPosName.Size = New System.Drawing.Size(44, 17)
        Me.lblXPosName.TabIndex = 25
        Me.lblXPosName.Text = "Label1"
        '
        'numSpan
        '
        Me.numSpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numSpan.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numSpan.Location = New System.Drawing.Point(638, 51)
        Me.numSpan.Name = "numSpan"
        Me.numSpan.ReadOnly = True
        Me.numSpan.Size = New System.Drawing.Size(43, 20)
        Me.numSpan.TabIndex = 26
        Me.numSpan.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Controls.Add(Me.lblIntVolt)
        Me.Panel6.Location = New System.Drawing.Point(52, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(180, 71)
        Me.Panel6.TabIndex = 24
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblIntV3Val)
        Me.Panel2.Controls.Add(Me.lblIntV3Desc)
        Me.Panel2.Controls.Add(Me.lblIntV2Val)
        Me.Panel2.Controls.Add(Me.lblIntV2Desc)
        Me.Panel2.Controls.Add(Me.lblIntV1Val)
        Me.Panel2.Controls.Add(Me.lblIntV1Desc)
        Me.Panel2.Location = New System.Drawing.Point(-1, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(176, 30)
        Me.Panel2.TabIndex = 4
        '
        'lblIntV3Val
        '
        Me.lblIntV3Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV3Val.Location = New System.Drawing.Point(140, 6)
        Me.lblIntV3Val.Name = "lblIntV3Val"
        Me.lblIntV3Val.Size = New System.Drawing.Size(35, 17)
        Me.lblIntV3Val.TabIndex = 9
        Me.lblIntV3Val.Text = "299"
        Me.lblIntV3Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV3Desc
        '
        Me.lblIntV3Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV3Desc.Location = New System.Drawing.Point(119, 6)
        Me.lblIntV3Desc.Name = "lblIntV3Desc"
        Me.lblIntV3Desc.Size = New System.Drawing.Size(22, 17)
        Me.lblIntV3Desc.TabIndex = 8
        Me.lblIntV3Desc.Text = "V3"
        Me.lblIntV3Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntV2Val
        '
        Me.lblIntV2Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV2Val.Location = New System.Drawing.Point(79, 6)
        Me.lblIntV2Val.Name = "lblIntV2Val"
        Me.lblIntV2Val.Size = New System.Drawing.Size(35, 17)
        Me.lblIntV2Val.TabIndex = 7
        Me.lblIntV2Val.Text = "299"
        Me.lblIntV2Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV2Desc
        '
        Me.lblIntV2Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV2Desc.Location = New System.Drawing.Point(59, 6)
        Me.lblIntV2Desc.Name = "lblIntV2Desc"
        Me.lblIntV2Desc.Size = New System.Drawing.Size(22, 17)
        Me.lblIntV2Desc.TabIndex = 6
        Me.lblIntV2Desc.Text = "V12"
        Me.lblIntV2Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntV1Val
        '
        Me.lblIntV1Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV1Val.Location = New System.Drawing.Point(20, 6)
        Me.lblIntV1Val.Name = "lblIntV1Val"
        Me.lblIntV1Val.Size = New System.Drawing.Size(35, 17)
        Me.lblIntV1Val.TabIndex = 5
        Me.lblIntV1Val.Text = "299"
        Me.lblIntV1Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV1Desc
        '
        Me.lblIntV1Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV1Desc.Location = New System.Drawing.Point(1, 6)
        Me.lblIntV1Desc.Name = "lblIntV1Desc"
        Me.lblIntV1Desc.Size = New System.Drawing.Size(22, 17)
        Me.lblIntV1Desc.TabIndex = 4
        Me.lblIntV1Desc.Text = "V12"
        Me.lblIntV1Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntVolt
        '
        Me.lblIntVolt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntVolt.Location = New System.Drawing.Point(3, 12)
        Me.lblIntVolt.Name = "lblIntVolt"
        Me.lblIntVolt.Size = New System.Drawing.Size(173, 18)
        Me.lblIntVolt.TabIndex = 7
        Me.lblIntVolt.Text = "Voltages [Volt]"
        Me.lblIntVolt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCenter
        '
        Me.btnCenter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCenter.Image = Global.ApplicationUSB.My.Resources.Resources.Actions_zoom_fit_icon
        Me.btnCenter.Location = New System.Drawing.Point(603, 6)
        Me.btnCenter.Name = "btnCenter"
        Me.btnCenter.Size = New System.Drawing.Size(78, 40)
        Me.btnCenter.TabIndex = 25
        Me.btnCenter.Text = "Center"
        Me.btnCenter.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnCenter.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblIntCurrent)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Location = New System.Drawing.Point(231, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(180, 71)
        Me.Panel5.TabIndex = 23
        '
        'lblIntCurrent
        '
        Me.lblIntCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntCurrent.Location = New System.Drawing.Point(2, 8)
        Me.lblIntCurrent.Name = "lblIntCurrent"
        Me.lblIntCurrent.Size = New System.Drawing.Size(176, 26)
        Me.lblIntCurrent.TabIndex = 8
        Me.lblIntCurrent.Text = "Currents [Amp]"
        Me.lblIntCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblIntI3Val)
        Me.Panel3.Controls.Add(Me.lblIntI3Desc)
        Me.Panel3.Controls.Add(Me.lblIntI2Val)
        Me.Panel3.Controls.Add(Me.lblIntI2Desc)
        Me.Panel3.Controls.Add(Me.lblIntI1Val)
        Me.Panel3.Controls.Add(Me.lblIntI1Desc)
        Me.Panel3.Location = New System.Drawing.Point(0, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(187, 30)
        Me.Panel3.TabIndex = 5
        '
        'lblIntI3Val
        '
        Me.lblIntI3Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntI3Val.Location = New System.Drawing.Point(140, 6)
        Me.lblIntI3Val.Name = "lblIntI3Val"
        Me.lblIntI3Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntI3Val.TabIndex = 9
        Me.lblIntI3Val.Text = "25.5"
        Me.lblIntI3Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntI3Desc
        '
        Me.lblIntI3Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntI3Desc.Location = New System.Drawing.Point(119, 6)
        Me.lblIntI3Desc.Name = "lblIntI3Desc"
        Me.lblIntI3Desc.Size = New System.Drawing.Size(22, 17)
        Me.lblIntI3Desc.TabIndex = 8
        Me.lblIntI3Desc.Text = "I3"
        Me.lblIntI3Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntI2Val
        '
        Me.lblIntI2Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntI2Val.Location = New System.Drawing.Point(79, 6)
        Me.lblIntI2Val.Name = "lblIntI2Val"
        Me.lblIntI2Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntI2Val.TabIndex = 7
        Me.lblIntI2Val.Text = "25.5"
        Me.lblIntI2Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntI2Desc
        '
        Me.lblIntI2Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntI2Desc.Location = New System.Drawing.Point(59, 6)
        Me.lblIntI2Desc.Name = "lblIntI2Desc"
        Me.lblIntI2Desc.Size = New System.Drawing.Size(18, 17)
        Me.lblIntI2Desc.TabIndex = 6
        Me.lblIntI2Desc.Text = "I2"
        Me.lblIntI2Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntI1Val
        '
        Me.lblIntI1Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntI1Val.Location = New System.Drawing.Point(20, 6)
        Me.lblIntI1Val.Name = "lblIntI1Val"
        Me.lblIntI1Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntI1Val.TabIndex = 5
        Me.lblIntI1Val.Text = "25.5"
        Me.lblIntI1Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntI1Desc
        '
        Me.lblIntI1Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntI1Desc.Location = New System.Drawing.Point(1, 6)
        Me.lblIntI1Desc.Name = "lblIntI1Desc"
        Me.lblIntI1Desc.Size = New System.Drawing.Size(18, 17)
        Me.lblIntI1Desc.TabIndex = 4
        Me.lblIntI1Desc.Text = "I1"
        Me.lblIntI1Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HScrollIntGraph
        '
        Me.HScrollIntGraph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollIntGraph.Location = New System.Drawing.Point(9, 429)
        Me.HScrollIntGraph.Name = "HScrollIntGraph"
        Me.HScrollIntGraph.Size = New System.Drawing.Size(844, 22)
        Me.HScrollIntGraph.TabIndex = 24
        '
        'btnSaveAs
        '
        Me.btnSaveAs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveAs.Image = Global.ApplicationUSB.My.Resources.Resources.SaveAs
        Me.btnSaveAs.Location = New System.Drawing.Point(805, 477)
        Me.btnSaveAs.Name = "btnSaveAs"
        Me.btnSaveAs.Size = New System.Drawing.Size(45, 45)
        Me.btnSaveAs.TabIndex = 17
        Me.btnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSaveAs.UseVisualStyleBackColor = True
        '
        'ZedGraphFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 534)
        Me.Controls.Add(Me.HScrollIntGraph)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSaveAs)
        Me.Controls.Add(Me.zg2)
        Me.Controls.Add(Me.zg1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ZedGraphFrm"
        Me.Text = "Chart"
        Me.Panel1.ResumeLayout(False)
        CType(Me.numSpan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents zg1 As ZedGraph.ZedGraphControl
    Friend WithEvents zg2 As ZedGraph.ZedGraphControl
    Friend WithEvents btnSaveAs As System.Windows.Forms.Button
    Friend WithEvents lblXPos As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblIntV3Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV3Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntV2Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV2Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntV1Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV1Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntVolt As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblIntCurrent As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblIntI3Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI3Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntI2Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI2Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntI1Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI1Desc As System.Windows.Forms.Label
    Friend WithEvents HScrollIntGraph As System.Windows.Forms.HScrollBar
    Friend WithEvents lblXPosName As System.Windows.Forms.Label
    Friend WithEvents btnCenter As System.Windows.Forms.Button
    Friend WithEvents numSpan As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSpan As System.Windows.Forms.Label
End Class
