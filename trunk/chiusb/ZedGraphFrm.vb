Imports ZedGraph


Public Class ZedGraphFrm
    Private m_id As Guid
    Private m_name As String
    Private m_description As String
    Private m_timeStamp As DateTime

    Private markerLineItem As LineItem
    Private markerColor As Color

    Private m_isVisible As Boolean
    Private m_power As Double

    Private Sub ZedGraphFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MinimumSize = MainFrm.MinimumSize

        DrawHeader()
    End Sub

    Private Sub SetSize()
        zg1.Location = New Point(10, 10)
        ' Leave a small margin around the outside of the control
        zg1.Size = New Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20)

        zg2.Location = New Point(10, 10)
        ' Leave a small margin around the outside of the control
        zg2.Size = New Size(ClientRectangle.Width - 20, ClientRectangle.Height - 20 - 90)
    End Sub

    Private Sub ZedGraphFrm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        SetSize()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAs.Click
        If zg2.Visible Then
            zg2.SaveAs()
        ElseIf zg1.Visible Then
            zg1.SaveAs()
        End If


    End Sub



    Private Sub MakeLineItem(ByVal punto As Int64)

        Dim _cursorX As Double() = New Double(100) {}
        Dim _cursorY As Double() = New Double(100) {}
        Dim ax As Axis

        ax = zg2.GraphPane.CurveList.Item(0).ValueAxis(zg2.GraphPane)


        For _i As Integer = 0 To 100
            _cursorX(_i) = punto
            _cursorY(_i) = _i * ((ax.Scale.Max - ax.Scale.Min - 1) / 100) + 1
        Next

        Dim _markerPoints As New PointPairList(_cursorX, _cursorY)


        If markerLineItem Is Nothing Then
            markerLineItem = New LineItem(m_name, _markerPoints, Color.FromArgb(128, markerColor), SymbolType.None)
            markerLineItem.Line.Style = Drawing2D.DashStyle.DashDot
            markerLineItem.IsSelectable = True
            markerLineItem.Tag = Me
        Else
            markerLineItem.Points = _markerPoints
            markerLineItem.Color = Color.FromArgb(128, markerColor)
            markerLineItem.Line.Style = Drawing2D.DashStyle.Dot
        End If

        markerLineItem.Line.Width = 1.5F

    End Sub


    Public Sub FillDataGraphVI(ByVal _Xval As Int64)
        

        If (_Xval > 0) And (_Xval <= ConnectionUSB.InterventiLetti.Length) Then
            If zg2.GraphPane.CurveList.Contains(markerLineItem) Then zg2.GraphPane.CurveList.Remove(markerLineItem)
            MakeLineItem(_Xval)
            zg2.GraphPane.CurveList.Add(markerLineItem)
            zg2.Refresh()


            lblXPos.Text = _Xval
            lblIntI1Val.Text = GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intI1_rms)
            lblIntI2Val.Text = GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intI2_rms)
            lblIntI3Val.Text = GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intI3_rms)

            'lblIntV1Val.Text = GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intVoltAv)
            lblIntV1Val.Text = GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intV1_rms)
            lblIntV2Val.Text = GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intV2_rms)
            lblIntV3Val.Text = GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intV3_rms)

            lblIntTimeVal.Text = (2000 + GetYear(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime)).ToString("0000") & "/" & GetMonth(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime).ToString("00") & "/" & GetDay(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime).ToString("00") & " " & GetHours(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime).ToString("00") & "h" & GetMinutes(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime).ToString("00") & "'" & GetSeconds(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - _Xval)._intTime).ToString("00") & "''"
        End If
    End Sub



    Private Sub HScrollIntGraph_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScrollIntGraph.ValueChanged
        If ConnectionUSB.InterventiLetti.IntItems.Length > 0 Then
            lblXPos.Text = HScrollIntGraph.Value & "/" & HScrollIntGraph.Maximum
            'lblXPos.Text = HScrollIntGraph.Maximum - HScrollIntGraph.Value + 1 & "/" & HScrollIntGraph.Maximum  'voleva numerazione inversa
            FillDataGraphVI(HScrollIntGraph.Value)

        End If
    End Sub

    Public Sub DrawHeader()
        If zg2.Visible Then
            lblIntI1Val.BackColor = Color.Blue
            lblIntI2Val.BackColor = Color.Green
            lblIntI3Val.BackColor = Color.Red
            lblIntV1Val.BackColor = Color.DarkBlue
            lblIntV2Val.BackColor = Color.DarkGreen
            lblIntV3Val.BackColor = Color.DarkRed

            lblIntI1Val.ForeColor = Color.LightGray
            lblIntI2Val.ForeColor = Color.LightGray
            lblIntI3Val.ForeColor = Color.LightGray
            lblIntV1Val.ForeColor = Color.LightGray
            lblIntV2Val.ForeColor = Color.LightGray
            lblIntV3Val.ForeColor = Color.LightGray

            HScrollIntGraph.Minimum = 1
            HScrollIntGraph.Maximum = ConnectionUSB.InterventiLetti.Length
            HScrollIntGraph.SmallChange = 1
            HScrollIntGraph.LargeChange = 1
            HScrollIntGraph.Value = HScrollIntGraph.Minimum

            lblXPosName.Text = "alarms number"
            lblXPos.Text = HScrollIntGraph.Maximum - HScrollIntGraph.Value + 1 & "/" & HScrollIntGraph.Maximum  'voleva numerazione inversa



            zg2.ScrollMinX = 0
            zg2.ScrollMaxX = ConnectionUSB.InterventiLetti.Length - 1
            zg2.ScrollMinY = 0

            zg2.ScrollMaxY = 1024
            zg2.ScrollMaxY = 30


            numSpan.Minimum = 10
            numSpan.Increment = 10
            numSpan.Maximum = ConnectionUSB.InterventiLetti.Length - 1
            If numSpan.Maximum < 200 Then
                numSpan.Value = numSpan.Maximum
            Else
                numSpan.Value = 200
            End If


            Panel1.Visible = zg2.Visible
            HScrollIntGraph.Visible = zg2.Visible

            'zg2.GraphPane.XAxis.Scale.MinorStep = 1
            zg2.GraphPane.XAxis.MinorTic.Size = 1

            zg2.GraphPane.YAxis.Scale.MinAuto = True
            zg2.GraphPane.Y2Axis.Scale.MinAuto = True

            ' Calculate the Axis Scale Ranges
            zg2.AxisChange()
            ' Make sure the Graph gets redrawn
            zg2.Invalidate()
            FillDataGraphVI(HScrollIntGraph.Value)
            zg2.Refresh()

        ElseIf zg1.Visible = True Then
            ' Calculate the Axis Scale Ranges
            zg1.AxisChange()

            ' Make sure the Graph gets redrawn
            zg1.Invalidate()
            zg1.Refresh()

        End If
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCenter.Click
        zg2.GraphPane.XAxis.Scale.Min = HScrollIntGraph.Value - numSpan.Value / 2
        zg2.GraphPane.XAxis.Scale.Max = HScrollIntGraph.Value + numSpan.Value / 2

        If zg2.GraphPane.XAxis.Scale.Min < 0 Then
            zg2.GraphPane.XAxis.Scale.Min = 0
            zg2.GraphPane.XAxis.Scale.Max = HScrollIntGraph.Value + numSpan.Value
        End If

        If zg2.GraphPane.XAxis.Scale.Max > ConnectionUSB.InterventiLetti.IntItems.Length Then
            zg2.GraphPane.XAxis.Scale.Max = ConnectionUSB.InterventiLetti.IntItems.Length
            zg2.GraphPane.XAxis.Scale.Min = HScrollIntGraph.Value - numSpan.Value
        End If

        zg2.Refresh()
    End Sub




    Public Sub UpdateChartZ_XY()
        'Dim x(Intervents.TotTipiIntervento - 1) As String
        'Dim y(Intervents.TotTipiIntervento - 1) As Double
        Dim myPane As GraphPane = zg2.GraphPane
        Dim myZList As New PointPairList

        'Dim myPane As GraphPane = zgc.GraphPane
        zg2.AutoSize = True

        zg2.GraphPane.CurveList.Clear()
        zg2.GraphPane.Title.Text = "Alarms"

        ' Set the titles and axis labels
        myPane.Title.Text = "Measures"
        myPane.XAxis.Title.Text = "Events number"
        myPane.YAxis.Title.Text = "Ampere"
        myPane.YAxis.IsVisible = True

        myPane.Y2Axis.Title.Text = "Volt"
        myPane.Y2Axis.IsVisible = True


        ' Make up some data points from the Sine function
        Dim listI1 = New PointPairList()
        Dim listI2 As New PointPairList
        Dim listI3 As New PointPairList

        Dim listV1 As New PointPairList
        Dim listV2 As New PointPairList
        Dim listV3 As New PointPairList
        For x = 0 To ConnectionUSB.InterventiLetti.Length - 1
            listI1.Add(x + 1, GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intI1_rms), "I1")
            listI2.Add(x + 1, GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intI2_rms), "I2")
            listI3.Add(x + 1, GetCurrent(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intI3_rms), "I3")

            listV1.Add(x + 1, GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intV1_rms), "V12")
            listV2.Add(x + 1, GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intV2_rms), "V13")
            listV3.Add(x + 1, GetVoltage(ConnectionUSB.InterventiLetti.IntItems(ConnectionUSB.InterventiLetti.Length - 1 - x)._intV3_rms), "V23")
        Next


        ' Generate a blue curve with circle symbols, and "My Curve 2" in the legend
        Dim myCurveI1, myCurveI2, myCurveI3 As LineItem
        Dim myCurveV1, myCurveV2, myCurveV3 As LineItem
        myCurveI1 = myPane.AddCurve("I1", listI1, Color.Blue, SymbolType.None)
        myCurveI2 = myPane.AddCurve("I2", listI2, Color.Green, SymbolType.None)
        myCurveI3 = myPane.AddCurve("I3", listI3, Color.Red, SymbolType.None)
        myCurveV1 = myPane.AddCurve("V12", listV1, Color.DarkBlue, SymbolType.None)
        myCurveV2 = myPane.AddCurve("V13", listV2, Color.DarkGreen, SymbolType.None)
        myCurveV3 = myPane.AddCurve("V23", listV3, Color.DarkRed, SymbolType.None)
        myCurveI1.IsY2Axis = False
        myCurveI2.IsY2Axis = False
        myCurveI3.IsY2Axis = False

        myCurveV1.Line.Width = 2
        myCurveV2.Line.Width = 2
        myCurveV3.Line.Width = 2
        myCurveV1.IsY2Axis = True
        myCurveV2.IsY2Axis = True
        myCurveV3.IsY2Axis = True

        ' Fill the area under the curve with a white-red gradient at 45 degrees
        'myCurve.Line.Fill = New Fill(Color.White, Color.Red, 45.0F)

        ' Make the symbols opaque by filling them with white
        'myCurve.Symbol.Fill = New Fill(Color.White)

        ' Fill the axis background with a color gradient
        'myPane.Chart.Fill = New Fill(Color.White, Color.LightGoldenrodYellow, 45.0F)

        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0F)



        zg2.IsEnableHZoom = True
        zg2.IsEnableVZoom = False
        zg2.ZoomOutAll(myPane)


        zg2.GraphPane.XAxis.Scale.Min = 0
        If ConnectionUSB.InterventiLetti.Length - 1 < 200 Then
            zg2.GraphPane.XAxis.Scale.Max = ConnectionUSB.InterventiLetti.Length
        Else
            zg2.GraphPane.XAxis.Scale.Max = 200
        End If

    End Sub



    Public Sub UpdateChartZ_Second()
        Dim x(Intervents.TotTipiIntervento - 1) As String
        Dim y(Intervents.TotTipiIntervento - 1) As Double
        Dim myPane As GraphPane = zg1.GraphPane
        Dim myZList As New PointPairList
        Dim i As Integer


        zg1.AutoSize = True
        zg1.GraphPane.CurveList.Clear()
        zg1.GraphPane.Title.Text = "Alarms"

        For i = 0 To Intervents.TotTipiIntervento - 1
            myZList = New PointPairList
            myZList.Clear()
            myZList.Add(Intervents.enumNum(i), Intervents.GetOcc(Intervents.enumNum(i)), 111)
            x(i) = (Intervents.enumNum(i))
            Dim myCurve As CurveItem = myPane.AddBar(Intervents.enumNum(i).ToString + " " + Intervents.GetIntStr(Intervents.enumNum(i)), myZList, Intervents.returnColor(Intervents.enumNum(i)))

            ' Dim label As TextObj = New TextObj(Intervents.GetOcc(Intervents.enumNum(i)), myCurve.Points.Item(0).X, myCurve.Points.Item(0).Y)
            ' myPane.GraphObjList.Add(label)
        Next i



        ' Fill the pane background with a color gradient
        myPane.Fill = New Fill(Color.White, Color.LightGray, 45.0F)
        ' No fill for the chart background
        myPane.Chart.Fill.Type = FillType.None

        ' Set the legend to an arbitrary location
        myPane.Legend.Position = LegendPos.Right
        myPane.Legend.Location = New Location(0.95F, 0.15F, CoordType.PaneFraction, _
                    AlignH.Right, AlignV.Top)
        myPane.Legend.FontSpec.Size = 10.0F
        myPane.Legend.IsHStack = False

        myPane.XAxis.Type = ZedGraph.AxisType.Text
        myPane.XAxis.Title.Text = "Alarms type"
        myPane.XAxis.Title.FontSpec.Size = 10.0F

        myPane.XAxis.Scale.FormatAuto = True
        'myPane.XAxis.Scale.TextLabels = x
        myPane.XAxis.Scale.FontSpec.Size = 10.0F
        myPane.XAxis.Scale.FontSpec.IsBold = True
        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinSpace = 1
        myPane.XAxis.Scale.FormatAuto = True

        myPane.YAxis.Type = ZedGraph.AxisType.Linear
        myPane.YAxis.Title.Text = "Occurences"
        myPane.YAxis.Title.FontSpec.Size = 10.0F
        myPane.YAxis.Scale.FontSpec.Size = 10.0F
        myPane.YAxis.Scale.Align = AlignP.Inside
        myPane.YAxis.Scale.Min = 0
        myPane.YAxis.Scale.MaxAuto = True

        CreateBarLabels(myPane, False, "00")


        ' '' Tell ZedGraph to calculate the axis ranges
        'zg1.AxisChange()
        '' Make sure the Graph gets redrawn
        'zg1.Invalidate()

        'zg1.Refresh()

        zg1.IsEnableHZoom = True
        zg1.IsEnableVZoom = False

    End Sub


    Private Sub CreateLineLabels(ByVal pane As GraphPane, ByVal isBarCenter As Boolean, ByVal valueFormat As String)
        Dim isVertical As Boolean = True

        pane.GraphObjList.Clear()

        '' Make the gap between the bars and the labels = 2% of the axis range
        Dim labelOffset As Single
        If isVertical Then
            labelOffset = 1 ' CSng(pane.YAxis.Max - pane.YAxis.Min) * 0.02F
        Else
            labelOffset = 1 'CSng(pane.XAxis.Max - pane.XAxis.Min) * 0.02F
        End If

        ' keep a count of the number of BarItems
        Dim curveIndex As Integer = 0

        ' Get a valuehandler to do some calculations for us
        Dim valueHandler As New ValueHandler(pane, True)

        ' Loop through each curve in the list
        For Each curve As CurveItem In pane.CurveList
            ' work with BarItems only
            Dim line As LineItem = TryCast(curve, LineItem)
            If line IsNot Nothing Then
                Dim points As IPointList = curve.Points

                ' Loop through each point in the BarItem
                For i = 0 To points.Count - 1
                    ' Get the high, low and base values for the current bar
                    ' note that this method will automatically calculate the "effective"
                    ' values if the bar is stacked
                    Dim baseVal As Double, lowVal As Double, hiVal As Double
                    valueHandler.GetValues(curve, i, baseVal, lowVal, hiVal)
                    If hiVal <> lowVal Then


                        ' Get the value that corresponds to the center of the bar base
                        ' This method figures out how the bars are positioned within a cluster
                        Dim centerVal As Single = CSng(valueHandler.BarCenterValue(line, line.GetBarWidth(pane), i, baseVal, curveIndex))

                        ' Create a text label -- note that we have to go back to the original point
                        ' data for this, since hiVal and lowVal could be "effective" values from a bar stack
                        Dim barLabelText As String = points(i).X.ToString(valueFormat)
                        'Dim barLabelText As String = Intervents.enumNum(curveIndex)

                        ' Calculate the position of the label -- this is either the X or the Y coordinate
                        ' depending on whether they are horizontal or vertical bars, respectively
                        Dim position As Single
                        If isBarCenter Then
                            position = CSng(hiVal + lowVal) / 2.0F
                        Else
                            position = CSng(hiVal) + labelOffset
                        End If
                        ' position = lowVal - 3

                        ' Create the new TextItem
                        Dim label As TextObj
                        If isVertical Then
                            label = New TextObj(barLabelText, centerVal, position)
                        Else
                            label = New TextObj(barLabelText, position, centerVal)
                        End If

                        ' Configure the TextItem
                        label.Location.CoordinateFrame = CoordType.AxisXYScale
                        label.FontSpec.Size = 12
                        label.FontSpec.FontColor = Color.Black
                        label.FontSpec.Angle = If(isVertical, 90, 0)
                        label.Location.AlignH = If(isBarCenter, AlignH.Center, AlignH.Left)
                        label.Location.AlignV = AlignV.Center
                        label.FontSpec.Border.IsVisible = False
                        label.FontSpec.Fill.IsVisible = False

                        ' Add the TextItem to the GraphPane
                        pane.GraphObjList.Add(label)
                    End If
                Next
            End If
            curveIndex += 1
        Next
    End Sub

    Private Sub CreateBarLabels(ByVal pane As GraphPane, ByVal isBarCenter As Boolean, ByVal valueFormat As String)
        Dim isVertical As Boolean = True
        Try
            pane.GraphObjList.Clear()

            '' Make the gap between the bars and the labels = 2% of the axis range
            Dim labelOffset As Single
            If isVertical Then
                labelOffset = 1 ' CSng(pane.YAxis.Max - pane.YAxis.Min) * 0.02F
            Else
                labelOffset = 1 'CSng(pane.XAxis.Max - pane.XAxis.Min) * 0.02F
            End If

            ' keep a count of the number of BarItems
            Dim curveIndex As Integer = 0

            ' Get a valuehandler to do some calculations for us
            Dim valueHandler As New ValueHandler(pane, True)

            ' Loop through each curve in the list
            For Each curve As CurveItem In pane.CurveList
                ' work with BarItems only
                Dim bar As BarItem = TryCast(curve, BarItem)
                If bar IsNot Nothing Then
                    Dim points As IPointList = curve.Points

                    ' Loop through each point in the BarItem
                    For i = 0 To points.Count - 1
                        ' Get the high, low and base values for the current bar
                        ' note that this method will automatically calculate the "effective"
                        ' values if the bar is stacked
                        Dim baseVal As Double, lowVal As Double, hiVal As Double
                        valueHandler.GetValues(curve, i, baseVal, lowVal, hiVal)
                        If hiVal <> lowVal Then


                            ' Get the value that corresponds to the center of the bar base
                            ' This method figures out how the bars are positioned within a cluster
                            Dim centerVal As Single = CSng(valueHandler.BarCenterValue(bar, bar.GetBarWidth(pane), i, baseVal, curveIndex))

                            ' Create a text label -- note that we have to go back to the original point
                            ' data for this, since hiVal and lowVal could be "effective" values from a bar stack
                            'Dim barLabelText As String = (If(isVertical, points(i).Y, points(i).X)).ToString(valueFormat)
                            Dim barLabelText As String = Intervents.enumNum(curveIndex)

                            ' Calculate the position of the label -- this is either the X or the Y coordinate
                            ' depending on whether they are horizontal or vertical bars, respectively
                            Dim position As Single
                            If isBarCenter Then
                                position = CSng(hiVal + lowVal) / 2.0F
                            Else
                                position = CSng(hiVal) + labelOffset
                            End If
                            ' position = lowVal - 3

                            ' Create the new TextItem
                            Dim label As TextObj
                            If isVertical Then
                                label = New TextObj(barLabelText, centerVal, position)
                            Else
                                label = New TextObj(barLabelText, position, centerVal)
                            End If

                            ' Configure the TextItem
                            label.Location.CoordinateFrame = CoordType.AxisXYScale
                            label.FontSpec.Size = 12
                            label.FontSpec.FontColor = Color.Black
                            label.FontSpec.Angle = If(isVertical, 90, 0)
                            label.Location.AlignH = If(isBarCenter, AlignH.Center, AlignH.Left)
                            label.Location.AlignV = AlignV.Center
                            label.FontSpec.Border.IsVisible = False
                            label.FontSpec.Fill.IsVisible = False

                            ' Add the TextItem to the GraphPane
                            pane.GraphObjList.Add(label)
                        End If
                    Next
                End If
                curveIndex += 1
            Next
        Catch ex As ArgumentException

            'MsgBox(ex.Message)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub HScrollIntGraph_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollIntGraph.Scroll

    End Sub

   
End Class



