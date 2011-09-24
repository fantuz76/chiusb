<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrm))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lblHeaderList = New System.Windows.Forms.Label
        Me.pnlButAlarms = New System.Windows.Forms.Panel
        Me.btnSaveInt = New System.Windows.Forms.Button
        Me.btnOpenGraph = New System.Windows.Forms.Button
        Me.btnChartXY = New System.Windows.Forms.Button
        Me.lstInterventi = New System.Windows.Forms.ListBox
        Me.lblNumIntTitle = New System.Windows.Forms.Label
        Me.lblNumInt = New System.Windows.Forms.Label
        Me.HscrollInterventi = New System.Windows.Forms.HScrollBar
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblIntV3Val = New System.Windows.Forms.Label
        Me.lblIntV3Desc = New System.Windows.Forms.Label
        Me.lblIntV2Val = New System.Windows.Forms.Label
        Me.lblIntV2Desc = New System.Windows.Forms.Label
        Me.lblIntV1Val = New System.Windows.Forms.Label
        Me.lblIntV1Desc = New System.Windows.Forms.Label
        Me.lblIntVolt = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.lblIntCurrent = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.lblIntI3Val = New System.Windows.Forms.Label
        Me.lblIntI3Desc = New System.Windows.Forms.Label
        Me.lblIntI2Val = New System.Windows.Forms.Label
        Me.lblIntI2Desc = New System.Windows.Forms.Label
        Me.lblIntI1Val = New System.Windows.Forms.Label
        Me.lblIntI1Desc = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.lblIntTempVal = New System.Windows.Forms.Label
        Me.lblIntTempDesc = New System.Windows.Forms.Label
        Me.lblIntCosfiVal = New System.Windows.Forms.Label
        Me.lblIntCosfiDesc = New System.Windows.Forms.Label
        Me.lblIntPressVal = New System.Windows.Forms.Label
        Me.lblIntPressDesc = New System.Windows.Forms.Label
        Me.lblIntPowVal = New System.Windows.Forms.Label
        Me.lblIntPowDesc = New System.Windows.Forms.Label
        Me.lblIntTimeVal = New System.Windows.Forms.Label
        Me.lblIntTimeDesc = New System.Windows.Forms.Label
        Me.lblIntTypeVal = New System.Windows.Forms.Label
        Me.lblIntTypeDesc = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lblGenericTmp = New System.Windows.Forms.Label
        Me.ListBoxLog = New System.Windows.Forms.ListBox
        Me.ContextMenuLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearLogToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNotify = New System.Windows.Forms.Label
        Me.btnConn = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.ClearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureLogo = New System.Windows.Forms.PictureBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.lblIntFluxVal = New System.Windows.Forms.Label
        Me.lblIntFluxDesc = New System.Windows.Forms.Label
        Me.lblHeaderList2 = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlButAlarms.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.ContextMenuLog.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(5, 84)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(740, 328)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lblHeaderList2)
        Me.TabPage1.Controls.Add(Me.lblHeaderList)
        Me.TabPage1.Controls.Add(Me.pnlButAlarms)
        Me.TabPage1.Controls.Add(Me.lstInterventi)
        Me.TabPage1.Controls.Add(Me.lblNumIntTitle)
        Me.TabPage1.Controls.Add(Me.lblNumInt)
        Me.TabPage1.Controls.Add(Me.HscrollInterventi)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(732, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Alarms"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblHeaderList
        '
        Me.lblHeaderList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeaderList.BackColor = System.Drawing.SystemColors.Window
        Me.lblHeaderList.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderList.Location = New System.Drawing.Point(3, 157)
        Me.lblHeaderList.Name = "lblHeaderList"
        Me.lblHeaderList.Size = New System.Drawing.Size(723, 14)
        Me.lblHeaderList.TabIndex = 12
        Me.lblHeaderList.Text = "xx"
        '
        'pnlButAlarms
        '
        Me.pnlButAlarms.Controls.Add(Me.btnSaveInt)
        Me.pnlButAlarms.Controls.Add(Me.btnOpenGraph)
        Me.pnlButAlarms.Controls.Add(Me.btnChartXY)
        Me.pnlButAlarms.Location = New System.Drawing.Point(639, 38)
        Me.pnlButAlarms.Name = "pnlButAlarms"
        Me.pnlButAlarms.Size = New System.Drawing.Size(87, 115)
        Me.pnlButAlarms.TabIndex = 11
        '
        'btnSaveInt
        '
        Me.btnSaveInt.Image = Global.ApplicationUSB.My.Resources.Resources.SaveAs
        Me.btnSaveInt.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveInt.Name = "btnSaveInt"
        Me.btnSaveInt.Size = New System.Drawing.Size(79, 39)
        Me.btnSaveInt.TabIndex = 9
        Me.btnSaveInt.Text = "Save"
        Me.btnSaveInt.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnSaveInt.UseVisualStyleBackColor = True
        '
        'btnOpenGraph
        '
        Me.btnOpenGraph.Image = Global.ApplicationUSB.My.Resources.Resources.chart1
        Me.btnOpenGraph.Location = New System.Drawing.Point(3, 43)
        Me.btnOpenGraph.Name = "btnOpenGraph"
        Me.btnOpenGraph.Size = New System.Drawing.Size(79, 37)
        Me.btnOpenGraph.TabIndex = 10
        Me.btnOpenGraph.Text = "Graph"
        Me.btnOpenGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnOpenGraph.UseVisualStyleBackColor = True
        '
        'btnChartXY
        '
        Me.btnChartXY.Image = Global.ApplicationUSB.My.Resources.Resources.GraphXY
        Me.btnChartXY.Location = New System.Drawing.Point(3, 81)
        Me.btnChartXY.Name = "btnChartXY"
        Me.btnChartXY.Size = New System.Drawing.Size(78, 35)
        Me.btnChartXY.TabIndex = 11
        Me.btnChartXY.Text = "VI Graph"
        Me.btnChartXY.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnChartXY.UseVisualStyleBackColor = True
        '
        'lstInterventi
        '
        Me.lstInterventi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstInterventi.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstInterventi.FormattingEnabled = True
        Me.lstInterventi.ItemHeight = 14
        Me.lstInterventi.Location = New System.Drawing.Point(3, 186)
        Me.lstInterventi.Name = "lstInterventi"
        Me.lstInterventi.Size = New System.Drawing.Size(723, 116)
        Me.lstInterventi.TabIndex = 4
        '
        'lblNumIntTitle
        '
        Me.lblNumIntTitle.AutoSize = True
        Me.lblNumIntTitle.Location = New System.Drawing.Point(639, 3)
        Me.lblNumIntTitle.Name = "lblNumIntTitle"
        Me.lblNumIntTitle.Size = New System.Drawing.Size(76, 13)
        Me.lblNumIntTitle.TabIndex = 3
        Me.lblNumIntTitle.Text = "Alarms number"
        '
        'lblNumInt
        '
        Me.lblNumInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumInt.Location = New System.Drawing.Point(645, 16)
        Me.lblNumInt.Name = "lblNumInt"
        Me.lblNumInt.Size = New System.Drawing.Size(69, 20)
        Me.lblNumInt.TabIndex = 2
        Me.lblNumInt.Text = "504/504"
        Me.lblNumInt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'HscrollInterventi
        '
        Me.HscrollInterventi.Location = New System.Drawing.Point(9, 9)
        Me.HscrollInterventi.Maximum = 505
        Me.HscrollInterventi.Minimum = 1
        Me.HscrollInterventi.Name = "HscrollInterventi"
        Me.HscrollInterventi.Size = New System.Drawing.Size(630, 27)
        Me.HscrollInterventi.TabIndex = 1
        Me.HscrollInterventi.Value = 1
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.lblIntTimeVal)
        Me.Panel1.Controls.Add(Me.lblIntTimeDesc)
        Me.Panel1.Controls.Add(Me.lblIntTypeVal)
        Me.Panel1.Controls.Add(Me.lblIntTypeDesc)
        Me.Panel1.Location = New System.Drawing.Point(9, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(630, 114)
        Me.Panel1.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Controls.Add(Me.lblIntVolt)
        Me.Panel6.Location = New System.Drawing.Point(7, 34)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(145, 71)
        Me.Panel6.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblIntV3Val)
        Me.Panel2.Controls.Add(Me.lblIntV3Desc)
        Me.Panel2.Controls.Add(Me.lblIntV2Val)
        Me.Panel2.Controls.Add(Me.lblIntV2Desc)
        Me.Panel2.Controls.Add(Me.lblIntV1Val)
        Me.Panel2.Controls.Add(Me.lblIntV1Desc)
        Me.Panel2.Location = New System.Drawing.Point(70, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(72, 63)
        Me.Panel2.TabIndex = 4
        '
        'lblIntV3Val
        '
        Me.lblIntV3Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV3Val.Location = New System.Drawing.Point(30, 39)
        Me.lblIntV3Val.Name = "lblIntV3Val"
        Me.lblIntV3Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntV3Val.TabIndex = 9
        Me.lblIntV3Val.Text = "299"
        Me.lblIntV3Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV3Desc
        '
        Me.lblIntV3Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV3Desc.Location = New System.Drawing.Point(0, 39)
        Me.lblIntV3Desc.Name = "lblIntV3Desc"
        Me.lblIntV3Desc.Size = New System.Drawing.Size(32, 17)
        Me.lblIntV3Desc.TabIndex = 8
        Me.lblIntV3Desc.Text = "V23"
        Me.lblIntV3Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntV2Val
        '
        Me.lblIntV2Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV2Val.Location = New System.Drawing.Point(30, 22)
        Me.lblIntV2Val.Name = "lblIntV2Val"
        Me.lblIntV2Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntV2Val.TabIndex = 7
        Me.lblIntV2Val.Text = "299"
        Me.lblIntV2Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV2Desc
        '
        Me.lblIntV2Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV2Desc.Location = New System.Drawing.Point(0, 22)
        Me.lblIntV2Desc.Name = "lblIntV2Desc"
        Me.lblIntV2Desc.Size = New System.Drawing.Size(32, 17)
        Me.lblIntV2Desc.TabIndex = 6
        Me.lblIntV2Desc.Text = "V13"
        Me.lblIntV2Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntV1Val
        '
        Me.lblIntV1Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntV1Val.Location = New System.Drawing.Point(30, 6)
        Me.lblIntV1Val.Name = "lblIntV1Val"
        Me.lblIntV1Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntV1Val.TabIndex = 5
        Me.lblIntV1Val.Text = "1023"
        Me.lblIntV1Val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntV1Desc
        '
        Me.lblIntV1Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntV1Desc.Location = New System.Drawing.Point(1, 6)
        Me.lblIntV1Desc.Name = "lblIntV1Desc"
        Me.lblIntV1Desc.Size = New System.Drawing.Size(32, 17)
        Me.lblIntV1Desc.TabIndex = 4
        Me.lblIntV1Desc.Text = "V12"
        Me.lblIntV1Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntVolt
        '
        Me.lblIntVolt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntVolt.Location = New System.Drawing.Point(3, 3)
        Me.lblIntVolt.Name = "lblIntVolt"
        Me.lblIntVolt.Size = New System.Drawing.Size(61, 64)
        Me.lblIntVolt.TabIndex = 7
        Me.lblIntVolt.Text = "Voltages [Volt]"
        Me.lblIntVolt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblIntCurrent)
        Me.Panel5.Controls.Add(Me.Panel3)
        Me.Panel5.Location = New System.Drawing.Point(151, 34)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(137, 71)
        Me.Panel5.TabIndex = 9
        '
        'lblIntCurrent
        '
        Me.lblIntCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntCurrent.Location = New System.Drawing.Point(2, 3)
        Me.lblIntCurrent.Name = "lblIntCurrent"
        Me.lblIntCurrent.Size = New System.Drawing.Size(71, 63)
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
        Me.Panel3.Location = New System.Drawing.Point(75, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(57, 63)
        Me.Panel3.TabIndex = 5
        '
        'lblIntI3Val
        '
        Me.lblIntI3Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntI3Val.Location = New System.Drawing.Point(20, 41)
        Me.lblIntI3Val.Name = "lblIntI3Val"
        Me.lblIntI3Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntI3Val.TabIndex = 9
        Me.lblIntI3Val.Text = "25.5"
        Me.lblIntI3Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntI3Desc
        '
        Me.lblIntI3Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntI3Desc.Location = New System.Drawing.Point(-1, 41)
        Me.lblIntI3Desc.Name = "lblIntI3Desc"
        Me.lblIntI3Desc.Size = New System.Drawing.Size(22, 17)
        Me.lblIntI3Desc.TabIndex = 8
        Me.lblIntI3Desc.Text = "V3"
        Me.lblIntI3Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntI2Val
        '
        Me.lblIntI2Val.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntI2Val.Location = New System.Drawing.Point(20, 24)
        Me.lblIntI2Val.Name = "lblIntI2Val"
        Me.lblIntI2Val.Size = New System.Drawing.Size(34, 17)
        Me.lblIntI2Val.TabIndex = 7
        Me.lblIntI2Val.Text = "25.5"
        Me.lblIntI2Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntI2Desc
        '
        Me.lblIntI2Desc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntI2Desc.Location = New System.Drawing.Point(0, 24)
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
        Me.lblIntI1Val.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblIntFluxVal)
        Me.Panel4.Controls.Add(Me.lblIntFluxDesc)
        Me.Panel4.Controls.Add(Me.lblIntTempVal)
        Me.Panel4.Controls.Add(Me.lblIntTempDesc)
        Me.Panel4.Controls.Add(Me.lblIntCosfiVal)
        Me.Panel4.Controls.Add(Me.lblIntCosfiDesc)
        Me.Panel4.Controls.Add(Me.lblIntPressVal)
        Me.Panel4.Controls.Add(Me.lblIntPressDesc)
        Me.Panel4.Controls.Add(Me.lblIntPowVal)
        Me.Panel4.Controls.Add(Me.lblIntPowDesc)
        Me.Panel4.Location = New System.Drawing.Point(287, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(338, 71)
        Me.Panel4.TabIndex = 6
        '
        'lblIntTempVal
        '
        Me.lblIntTempVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntTempVal.Location = New System.Drawing.Point(290, 14)
        Me.lblIntTempVal.Name = "lblIntTempVal"
        Me.lblIntTempVal.Size = New System.Drawing.Size(43, 17)
        Me.lblIntTempVal.TabIndex = 11
        Me.lblIntTempVal.Text = "65535"
        Me.lblIntTempVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntTempDesc
        '
        Me.lblIntTempDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntTempDesc.Location = New System.Drawing.Point(251, 3)
        Me.lblIntTempDesc.Name = "lblIntTempDesc"
        Me.lblIntTempDesc.Size = New System.Drawing.Size(38, 36)
        Me.lblIntTempDesc.TabIndex = 10
        Me.lblIntTempDesc.Text = "Temp [°C]"
        Me.lblIntTempDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntCosfiVal
        '
        Me.lblIntCosfiVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntCosfiVal.Location = New System.Drawing.Point(106, 43)
        Me.lblIntCosfiVal.Name = "lblIntCosfiVal"
        Me.lblIntCosfiVal.Size = New System.Drawing.Size(43, 17)
        Me.lblIntCosfiVal.TabIndex = 9
        Me.lblIntCosfiVal.Text = "0.99"
        Me.lblIntCosfiVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntCosfiDesc
        '
        Me.lblIntCosfiDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntCosfiDesc.Location = New System.Drawing.Point(58, 41)
        Me.lblIntCosfiDesc.Name = "lblIntCosfiDesc"
        Me.lblIntCosfiDesc.Size = New System.Drawing.Size(46, 16)
        Me.lblIntCosfiDesc.TabIndex = 8
        Me.lblIntCosfiDesc.Text = "cosφ"
        Me.lblIntCosfiDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntPressVal
        '
        Me.lblIntPressVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntPressVal.Location = New System.Drawing.Point(181, 14)
        Me.lblIntPressVal.Name = "lblIntPressVal"
        Me.lblIntPressVal.Size = New System.Drawing.Size(43, 17)
        Me.lblIntPressVal.TabIndex = 7
        Me.lblIntPressVal.Text = "65535"
        Me.lblIntPressVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntPressDesc
        '
        Me.lblIntPressDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntPressDesc.Location = New System.Drawing.Point(118, 3)
        Me.lblIntPressDesc.Name = "lblIntPressDesc"
        Me.lblIntPressDesc.Size = New System.Drawing.Size(61, 38)
        Me.lblIntPressDesc.TabIndex = 6
        Me.lblIntPressDesc.Text = "Pressure [Bar]"
        Me.lblIntPressDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntPowVal
        '
        Me.lblIntPowVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntPowVal.Location = New System.Drawing.Point(48, 14)
        Me.lblIntPowVal.Name = "lblIntPowVal"
        Me.lblIntPowVal.Size = New System.Drawing.Size(43, 17)
        Me.lblIntPowVal.TabIndex = 5
        Me.lblIntPowVal.Text = "65535"
        Me.lblIntPowVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntPowDesc
        '
        Me.lblIntPowDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntPowDesc.Location = New System.Drawing.Point(-1, 5)
        Me.lblIntPowDesc.Name = "lblIntPowDesc"
        Me.lblIntPowDesc.Size = New System.Drawing.Size(46, 36)
        Me.lblIntPowDesc.TabIndex = 4
        Me.lblIntPowDesc.Text = "Power [Watt]"
        Me.lblIntPowDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntTimeVal
        '
        Me.lblIntTimeVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntTimeVal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntTimeVal.ForeColor = System.Drawing.Color.Green
        Me.lblIntTimeVal.Location = New System.Drawing.Point(469, 6)
        Me.lblIntTimeVal.Name = "lblIntTimeVal"
        Me.lblIntTimeVal.Size = New System.Drawing.Size(156, 25)
        Me.lblIntTimeVal.TabIndex = 3
        Me.lblIntTimeVal.Text = "1234000h 59' 60"""
        Me.lblIntTimeVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntTimeDesc
        '
        Me.lblIntTimeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntTimeDesc.Location = New System.Drawing.Point(336, 0)
        Me.lblIntTimeDesc.Name = "lblIntTimeDesc"
        Me.lblIntTimeDesc.Size = New System.Drawing.Size(130, 32)
        Me.lblIntTimeDesc.TabIndex = 2
        Me.lblIntTimeDesc.Text = "Alarm date and time"
        Me.lblIntTimeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIntTypeVal
        '
        Me.lblIntTypeVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntTypeVal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntTypeVal.ForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblIntTypeVal.Location = New System.Drawing.Point(104, 5)
        Me.lblIntTypeVal.Name = "lblIntTypeVal"
        Me.lblIntTypeVal.Size = New System.Drawing.Size(222, 25)
        Me.lblIntTypeVal.TabIndex = 1
        Me.lblIntTypeVal.Text = "Label1"
        Me.lblIntTypeVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblIntTypeDesc
        '
        Me.lblIntTypeDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntTypeDesc.Location = New System.Drawing.Point(23, 0)
        Me.lblIntTypeDesc.Name = "lblIntTypeDesc"
        Me.lblIntTypeDesc.Size = New System.Drawing.Size(75, 34)
        Me.lblIntTypeDesc.TabIndex = 0
        Me.lblIntTypeDesc.Text = "Alarm type"
        Me.lblIntTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblGenericTmp)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(691, 280)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Other"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblGenericTmp
        '
        Me.lblGenericTmp.AutoSize = True
        Me.lblGenericTmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenericTmp.Location = New System.Drawing.Point(18, 20)
        Me.lblGenericTmp.Name = "lblGenericTmp"
        Me.lblGenericTmp.Size = New System.Drawing.Size(232, 25)
        Me.lblGenericTmp.TabIndex = 0
        Me.lblGenericTmp.Text = "Under construction..."
        '
        'ListBoxLog
        '
        Me.ListBoxLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBoxLog.BackColor = System.Drawing.SystemColors.GrayText
        Me.ListBoxLog.ContextMenuStrip = Me.ContextMenuLog
        Me.ListBoxLog.FormattingEnabled = True
        Me.ListBoxLog.Location = New System.Drawing.Point(5, 418)
        Me.ListBoxLog.Name = "ListBoxLog"
        Me.ListBoxLog.Size = New System.Drawing.Size(740, 56)
        Me.ListBoxLog.TabIndex = 7
        '
        'ContextMenuLog
        '
        Me.ContextMenuLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyLogToolStripMenuItem, Me.ClearLogToolStripMenuItem1})
        Me.ContextMenuLog.Name = "ContextMenuStrip1"
        Me.ContextMenuLog.Size = New System.Drawing.Size(131, 48)
        '
        'CopyLogToolStripMenuItem
        '
        Me.CopyLogToolStripMenuItem.Name = "CopyLogToolStripMenuItem"
        Me.CopyLogToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
        Me.CopyLogToolStripMenuItem.Text = "Copy Log"
        '
        'ClearLogToolStripMenuItem1
        '
        Me.ClearLogToolStripMenuItem1.Name = "ClearLogToolStripMenuItem1"
        Me.ClearLogToolStripMenuItem1.Size = New System.Drawing.Size(130, 22)
        Me.ClearLogToolStripMenuItem1.Text = "Clear Log"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(165, 22)
        Me.ToolStripMenuItem1.Text = "Copy all"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(165, 22)
        Me.ToolStripMenuItem2.Text = "Export to log.txt"
        Me.ToolStripMenuItem2.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 482)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(815, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.ToolStripMenuItem3})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(815, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(24, 20)
        Me.ToolStripMenuItem3.Text = "?"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNotify)
        Me.GroupBox1.Controls.Add(Me.btnConn)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 57)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'lblNotify
        '
        Me.lblNotify.Location = New System.Drawing.Point(113, 16)
        Me.lblNotify.Name = "lblNotify"
        Me.lblNotify.Size = New System.Drawing.Size(156, 28)
        Me.lblNotify.TabIndex = 2
        Me.lblNotify.Text = "Connect and Read alarms"
        Me.lblNotify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnConn
        '
        Me.btnConn.Image = Global.ApplicationUSB.My.Resources.Resources.conn
        Me.btnConn.Location = New System.Drawing.Point(4, 9)
        Me.btnConn.Name = "btnConn"
        Me.btnConn.Size = New System.Drawing.Size(107, 43)
        Me.btnConn.TabIndex = 1
        Me.btnConn.Text = "Connect"
        Me.btnConn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConn.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'ClearLogToolStripMenuItem
        '
        Me.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem"
        Me.ClearLogToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.ClearLogToolStripMenuItem.Text = "Clear Log"
        '
        'PictureLogo
        '
        Me.PictureLogo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureLogo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureLogo.Image = Global.ApplicationUSB.My.Resources.Resources.logo
        Me.PictureLogo.Location = New System.Drawing.Point(575, 27)
        Me.PictureLogo.Name = "PictureLogo"
        Me.PictureLogo.Size = New System.Drawing.Size(162, 57)
        Me.PictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLogo.TabIndex = 10
        Me.PictureLogo.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExit.Image = Global.ApplicationUSB.My.Resources.Resources.Spegni
        Me.btnExit.Location = New System.Drawing.Point(751, 391)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(60, 83)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'lblIntFluxVal
        '
        Me.lblIntFluxVal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIntFluxVal.Location = New System.Drawing.Point(233, 42)
        Me.lblIntFluxVal.Name = "lblIntFluxVal"
        Me.lblIntFluxVal.Size = New System.Drawing.Size(43, 17)
        Me.lblIntFluxVal.TabIndex = 13
        Me.lblIntFluxVal.Text = "65535"
        Me.lblIntFluxVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIntFluxDesc
        '
        Me.lblIntFluxDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntFluxDesc.Location = New System.Drawing.Point(201, 42)
        Me.lblIntFluxDesc.Name = "lblIntFluxDesc"
        Me.lblIntFluxDesc.Size = New System.Drawing.Size(30, 16)
        Me.lblIntFluxDesc.TabIndex = 12
        Me.lblIntFluxDesc.Text = "Flux"
        Me.lblIntFluxDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHeaderList2
        '
        Me.lblHeaderList2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeaderList2.BackColor = System.Drawing.SystemColors.Window
        Me.lblHeaderList2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblHeaderList2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderList2.Location = New System.Drawing.Point(3, 171)
        Me.lblHeaderList2.Name = "lblHeaderList2"
        Me.lblHeaderList2.Size = New System.Drawing.Size(723, 14)
        Me.lblHeaderList2.TabIndex = 13
        Me.lblHeaderList2.Text = "xx"
        '
        'MainFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 504)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ListBoxLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureLogo)
        Me.Controls.Add(Me.btnExit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainFrm"
        Me.Text = "USB Configuration"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.pnlButAlarms.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ContextMenuLog.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBoxLog As System.Windows.Forms.ListBox
    Friend WithEvents btnConn As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblNumInt As System.Windows.Forms.Label
    Friend WithEvents HscrollInterventi As System.Windows.Forms.HScrollBar
    Friend WithEvents lblIntTimeVal As System.Windows.Forms.Label
    Friend WithEvents lblIntTimeDesc As System.Windows.Forms.Label
    Friend WithEvents lblIntTypeVal As System.Windows.Forms.Label
    Friend WithEvents lblIntTypeDesc As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblIntI1Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI1Desc As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblIntV1Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV1Desc As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblIntTempVal As System.Windows.Forms.Label
    Friend WithEvents lblIntTempDesc As System.Windows.Forms.Label
    Friend WithEvents lblIntCosfiVal As System.Windows.Forms.Label
    Private WithEvents lblIntCosfiDesc As System.Windows.Forms.Label
    Friend WithEvents lblIntPressVal As System.Windows.Forms.Label
    Friend WithEvents lblIntPressDesc As System.Windows.Forms.Label
    Friend WithEvents lblIntPowVal As System.Windows.Forms.Label
    Friend WithEvents lblIntPowDesc As System.Windows.Forms.Label
    Friend WithEvents lblIntCurrent As System.Windows.Forms.Label
    Friend WithEvents lblIntVolt As System.Windows.Forms.Label
    Friend WithEvents ContextMenuLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblNotify As System.Windows.Forms.Label
    Friend WithEvents ClearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearLogToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureLogo As System.Windows.Forms.PictureBox
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSaveInt As System.Windows.Forms.Button
    Friend WithEvents lblNumIntTitle As System.Windows.Forms.Label
    Friend WithEvents lblGenericTmp As System.Windows.Forms.Label
    'Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lstInterventi As System.Windows.Forms.ListBox
    Friend WithEvents btnOpenGraph As System.Windows.Forms.Button
    Friend WithEvents pnlButAlarms As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblIntI3Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI3Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntI2Val As System.Windows.Forms.Label
    Friend WithEvents lblIntI2Desc As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnChartXY As System.Windows.Forms.Button
    Friend WithEvents lblHeaderList As System.Windows.Forms.Label
    Friend WithEvents lblIntV2Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV2Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntV3Val As System.Windows.Forms.Label
    Friend WithEvents lblIntV3Desc As System.Windows.Forms.Label
    Friend WithEvents lblIntFluxVal As System.Windows.Forms.Label
    Friend WithEvents lblIntFluxDesc As System.Windows.Forms.Label
    Friend WithEvents lblHeaderList2 As System.Windows.Forms.Label

End Class
