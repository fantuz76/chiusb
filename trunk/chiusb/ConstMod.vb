Module ConstMod

    Public Const XMLCFG = "\Config.xml"

    Public Const NUM_MAX_TYPE_INT = 35      ' Codice tipo intervento massimo possibile (non tutti sono usati)
    Public Const NUM_INT_TYPES = 21         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)

    Public Const INTERVENTO_LENGTH = 16     ' Dimensione array USB singolo intervento


    ' Definizione Codici dei vari tipi di intervento
    Public Const TYPE_OFF = 0
    Public Const TYPE_ON = 1

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
    Public Const TYPE_HALT_PRESS_SENS = 19 + 10



    ' Descrizione stringa dei vari tipi di intervento
    Public Const TYPE_ON_STR = "ON  "
    Public Const TYPE_OFF_STR = "OFF "
    Public Const TYPE_NOHALT_OVERCURR_STR = "OverCurrent" + "   ON"
    Public Const TYPE_NOHALT_OVERVOLT_STR = "OverVoltage" + "   ON"
    Public Const TYPE_NOHALT_UNDERVOLT_STR = "UnderVoltage" + "  ON"
    Public Const TYPE_NOHALT_MANDATACH_STR = "Minimum Flow" + "   ON"
    Public Const TYPE_NOHALT_DRYFUNC_STR = "Dry Operating" + "  ON"
    Public Const TYPE_NOHALT_OVERTEMP_STR = "Pump OverTemperature" + " ON"
    Public Const TYPE_NOHALT_DIFF_STR = "Isolation Fault" + "  ON"
    Public Const TYPE_NOHALT_SQUILIBRIO_STR = "Current Diff." + "  ON"
    Public Const TYPE_NOHALT_DISSIMETRIA_STR = "Voltage Diff." + "  ON"

    Public Const TYPE_HALT_OVERCURR_STR = "Overcurrent" + "  OFF"
    Public Const TYPE_HALT_OVERVOLT_STR = "Overvoltage" + "  OFF"
    Public Const TYPE_HALT_UNDERVOLT_STR = "Undervoltage" + "  OFF"
    Public Const TYPE_HALT_MANDATACH_STR = "MinimumFlow" + "  OFF"
    Public Const TYPE_HALT_DRYFUNC_STR = "Dry Operating" + "  OFF"
    Public Const TYPE_HALT_OVERTEMP_STR = "Pump OverTemperature" + "  OFF"
    Public Const TYPE_HALT_DIFF_STR = "Isolation Fault" + "  OFF"
    Public Const TYPE_HALT_SQUILIBRIO_STR = "Current Diff." + "  OFF"
    Public Const TYPE_HALT_DISSIMETRIA_STR = "Voltage Diff." + "  OFF"
    Public Const TYPE_HALT_PRESS_SENS_STR = "Pressure Sensor alarm" + "  OFF"




    ' Struttura delle confiugurazioni in risposta a Hello
    ' Ogni numero è composto da 2 byte (sono int)
    ' Sono 48 posizioni da 2 byte

    '	Pos # byte	# int	int //dai di funzionamento a partire dall'indirizzo 8040  della eeprom
    '	1	1	numero_serie, //0
    '	3	2	monofase_trifase,//0-1
    '	5	3	potenza_nominale,// W*10
    '	7	4	tensione_nominale,//V
    '	9	5	limite_sovratensione,//%
    '	11	6	limite_sottotensione,//%
    '	13	7	tensione_restart,// %
    '	15	8	limite_segnalazione_dissimmetria,//%
    '	17	9	limite_intervento_dissimmetria,//%
    '	19	10	timeout_protezione_tensione,//s
    '	21	11	corrente_nominale,//A*10
    '	23	12	limite_sovracorrente,//%
    '	25	13	limite_segnalazione_squilibrio,//%
    '	27	14	limite_intervento_squilibrio,//%
    '	29	15	ritardo_protezione_squilibrio,//s
    '	31	16	costante_tau_salita_temperatura,//s
    '	33	17	taratura_temperatura_ambiente,//da modificare per la taratura
    '	35	18	scala_temperatura_motore,//mV/°C
    '	37	19	limite_intervento_temper_motore,//°C
    '	39	20	scala_corrente_differenziale, //mA in /mA out
    '	41	21	limite_corrente_differenziale,//mA
    '	43	22	ritardo_intervento_differenziale,//ms
    '	45	23	ritardo_funzionamento_dopo_emergenza,//min
    '	47	24	portata_sensore_pressione,//Bar*10
    '	49	25	pressione_emergenza,//Bar*10
    '	51	26	potenza_minima_mandata_chiusa,//%
    '	53	27	ritardo_stop_mandata_chiusa, //s
    '	55	28	potenza_minima_funz_secco, //%
    '	57	29	ritardo_stop_funzionemento_a_secco, //s
    '	59	30	ritardo_riaccensione_mandata_chiusa,//s
    '	61	31	modo_start_stop,//remoto o pressione
    '	63	32	pressione_accensione,//Bar*10
    '	65	33	pressione_spegnimento,//Bar*10
    '	67	34	lingua,//0-1
    '	69	35	temperatura_ambiente,//°C
    '	71	36	abilita_sensore_pressione,//0-1
    '	73	37	calibrazione_I1,    
    '	75	38	calibrazione_I2,    
    '	77	39	calibrazione_I3,    
    '	79	40	motore_on,//0-1         
    '	81	41	numero_segnalazione,//0-503
    '	83	42	conta_ore[2],
    '	85	43	
    '	87	44	riserva[5];
    '	89	45	
    '	91	46	
    '	93	47	
    '	95	48	



End Module
