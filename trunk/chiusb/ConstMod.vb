Module ConstMod

    Public Const SwVersion = "1.0"

    Public Const NUM_MAX_TYPE_INT = 35      ' Codice tipo intervento massimo possibile (non tutti sono usati)
    Public Const NUM_INT_TYPES = 20         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)

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



    ' Descrizione stringa dei vari tipi di intervento
    Public Const TYPE_ON_STR = "ON  "
    Public Const TYPE_OFF_STR = "OFF "
    Public Const TYPE_NOHALT_OVERCURR_STR = "OverCurrent" + "   ON"
    Public Const TYPE_NOHALT_OVERVOLT_STR = "OverVoltage" + "   ON"
    Public Const TYPE_NOHALT_UNDERVOLT_STR = "UnderVoltage" + "  ON"
    Public Const TYPE_NOHALT_MANDATACH_STR = "Minimum Flow" + "   ON"
    Public Const TYPE_NOHALT_DRYFUNC_STR = "Dry Operating" + "  ON"
    Public Const TYPE_NOHALT_OVERTEMP_STR = "OverTemperature" + " ON"
    Public Const TYPE_NOHALT_DIFF_STR = "Isolation Fault" + "  ON"
    Public Const TYPE_NOHALT_SQUILIBRIO_STR = "Current Diff." + "  ON"
    Public Const TYPE_NOHALT_DISSIMETRIA_STR = "Voltage Diff." + "  ON"

    Public Const TYPE_HALT_OVERCURR_STR = "Overcurrent" + "  OFF"
    Public Const TYPE_HALT_OVERVOLT_STR = "Overvoltage" + "  OFF"
    Public Const TYPE_HALT_UNDERVOLT_STR = "Undervoltage" + "  OFF"
    Public Const TYPE_HALT_MANDATACH_STR = "MinimumFlow" + "  OFF"
    Public Const TYPE_HALT_DRYFUNC_STR = "Dry Operating" + "  OFF"
    Public Const TYPE_HALT_OVERTEMP_STR = "OverTemperature" + "  OFF"
    Public Const TYPE_HALT_DIFF_STR = "Isolation Fault" + "  OFF"
    Public Const TYPE_HALT_SQUILIBRIO_STR = "Current Diff." + "  OFF"
    Public Const TYPE_HALT_DISSIMETRIA_STR = "Voltage Diff." + "  OFF"




    ' Struttura delle confiugurazioni in risposta a Hello
    ' Ogni numero è composto da 2 byte (sono int)
    ' Sono 48 posizioni da 2 byte

    ' int //dai di funzionamento a partire dall'indirizzo 8040  della eeprom		
    '1	1	numero_serie, //0	
    '3	2	monofase_trifase,//0-1	
    '5	3	tensione_nominale,//V	
    '7	4	limite_sovratensione,//%	
    '9	5	limite_sottotensione,//%	
    '11	6	limite_segnalazione_dissimmetria,//%	
    '13	7	limite_intervento_dissimmetria,//%	
    '15	8	timeout_protezione_tensione,//s	
    '17	9	corrente_nominale,//A*10	
    '19	10	limite_sovracorrente,//%	
    '21	11	limite_segnalazione_squilibrio,//%	
    '23	12	limite_intervento_squilibrio,//%	
    '25	13	timeout_protezione_squilibrio,//s	
    '27	14	costante_tau_salita_temperatura,//s	
    '29	15	taratura_temperatura_ambiente,//da modificare per la taratura	
    '31	16	scala_temperatura_motore,//mV/°C	
    '33	17	limite_intervento_temper_motore,//°C	
    '35	18	scala_corrente_differenziale, //mA in /mA out	
    '37	19	limite_corrente_differenziale,//mA	
    '39	20	ritardo_intervento_differenziale,//ms	
    '41	21	ritardo_funzionamento_dopo_emergenza,//s	
    '43	22	portata_sensore_pressione,//Bar*10	
    '45	23	limite_intervento_pressione,//Bar*10	
    '47	24	potenza_minima_mandata_chiusa,//W	
    '49	25	ritardo_stop_mandata_chiusa, //s	
    '51	26	potenza_minima_funz_secco, //W	
    '53	27	ritardo_stop_funzionemento_a_secco, //s	
    '55	28	ritardo_riaccensione_a_secco,//s	
    '57	29	modo_start_stop,//remoto o pressione	
    '59	30	pressione_accensione,//Bar*10	
    '61	31	pressione_spegnimento,//Bar*10	
    '63	32	lingua,//0-1	
    '65	33	temperatura_ambiente,//°C	
    '67	34	motore_on,//0-1         	
    '69	35	numero_segnalazione,//0-503	
    '71	36	conta_ore[2],	
    '73	37	conta_ore[2],	
    '75	38	riserva[11];	
    '77	39	riserva[11];	
    '79	40	riserva[11];	
    '81	41	riserva[11];	
    '83	42	riserva[11];	
    '85	43	riserva[11];	
    '87	44	riserva[11];	
    '89	45	riserva[11];	
    '91	46	riserva[11];	
    '93	47	riserva[11];	
    '95	48	riserva[11];	




End Module
