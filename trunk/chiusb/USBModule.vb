Module USBModule
    Public ConnectionUSB As USBClass
    Public myIntList As InterventList

    Public Sub CloseProgram()

    End Sub

    Public Sub FillIntData(ByVal intToFill As InterventSingle)
        Dim _ore, _minuti, _secondi As Integer
        MainFrm.lblIntTypeVal.Text = intToFill._intType

        _ore = intToFill._intTime \ 3600
        _minuti = (intToFill._intTime Mod 3600) \ 60
        _secondi = ((intToFill._intTime Mod 3600) Mod 60)
        MainFrm.lblIntTimeVal.Text = _ore & "h " & _minuti & "' " & _secondi & "''"

        MainFrm.lblIntV1Val.Text = intToFill._intVolt1
        MainFrm.lblIntV2Val.Text = intToFill._intVolt2
        MainFrm.lblIntV3Val.Text = intToFill._intVolt3

        MainFrm.lblIntI1Val.Text = intToFill._intCurr1 / 10
        MainFrm.lblIntI2Val.Text = intToFill._intCurr2 / 10
        MainFrm.lblIntI3Val.Text = intToFill._intCurr3 / 10

        MainFrm.lblIntPowVal.Text = intToFill._intPower
        MainFrm.lblIntPressVal.Text = intToFill._intPress / 10
        MainFrm.lblIntCosfiVal.Text = intToFill._intCosfi / 100
        MainFrm.lblIntTempVal.Text = intToFill._intTemp

    End Sub

End Module
