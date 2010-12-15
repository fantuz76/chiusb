Module ConstMod

    Public Const SwVersion = "1.0"


    Public Const NUM_INT_TYPES = 20

    Public Const TYPE_ON = 1
    Public Const TYPE_OFF = 2
    Public Const TYPE_NOHALT_OVERCURR = 10
    Public Const TYPE_NOHALT_OVERVOLT = 11
    Public Const TYPE_NOHALT_UNDERVOLT = 12
    Public Const TYPE_NOHALT_MANDATACH = 13
    Public Const TYPE_NOHALT_DRYFUNC = 14
    Public Const TYPE_NOHALT_OVERTEMP = 15
    Public Const TYPE_NOHALT_DIFF = 16
    Public Const TYPE_NOHALT_SQUILIBRIO = 17
    Public Const TYPE_NOHALT_DISSIMETRIA = 18
    Public Const TYPE_HALT_OVERCURR = 10 + 10
    Public Const TYPE_HALT_OVERVOLT = 11 + 10
    Public Const TYPE_HALT_UNDERVOLT = 12 + 10
    Public Const TYPE_HALT_MANDATACH = 13 + 10
    Public Const TYPE_HALT_DRYFUNC = 14 + 10
    Public Const TYPE_HALT_OVERTEMP = 15 + 10
    Public Const TYPE_HALT_DIFF = 16 + 10
    Public Const TYPE_HALT_SQUILIBRIO = 17 + 10
    Public Const TYPE_HALT_DISSIMETRIA = 18 + 10


    Public Const TYPE_ON_STR = "ON"
    Public Const TYPE_OFF_STR = "OFF"
    Public Const TYPE_NOHALT_OVERCURR_STR = "Overcurrent" + " - Without Halt"
    Public Const TYPE_NOHALT_OVERVOLT_STR = "Overvoltage" + " - Without Halt"
    Public Const TYPE_NOHALT_UNDERVOLT_STR = "Undervoltage" + " - Without Halt"
    Public Const TYPE_NOHALT_MANDATACH_STR = "Under Load" + " - Without Halt"
    Public Const TYPE_NOHALT_DRYFUNC_STR = "Dry running" + " - Without Halt"
    Public Const TYPE_NOHALT_OVERTEMP_STR = "Over Temperature" + " - Without Halt"
    Public Const TYPE_NOHALT_DIFF_STR = "Differential protection" + " - Without Halt"
    Public Const TYPE_NOHALT_SQUILIBRIO_STR = "Current imbalance" + " - Without Halt"
    Public Const TYPE_NOHALT_DISSIMETRIA_STR = "Asymmetry Voltages" + " - Without Halt"

    Public Const TYPE_HALT_OVERVOLT_STR = "Overvoltage" + " - System Halt"
    Public Const TYPE_HALT_OVERCURR_STR = "Overcurrent" + " - System Halt"
    Public Const TYPE_HALT_UNDERVOLT_STR = "Undervoltage" + " - System Halt"
    Public Const TYPE_HALT_MANDATACH_STR = "Under Load" + " - System Halt"
    Public Const TYPE_HALT_DRYFUNC_STR = "Dry running" + " - System Halt"
    Public Const TYPE_HALT_OVERTEMP_STR = "Over Temperature" + " - System Halt"
    Public Const TYPE_HALT_DIFF_STR = "Differential protection" + " - System Halt"
    Public Const TYPE_HALT_SQUILIBRIO_STR = "Current imbalance" + " - System Halt"
    Public Const TYPE_HALT_DISSIMETRIA_STR = "Asymmetry Voltages" + " - System Halt"
End Module
