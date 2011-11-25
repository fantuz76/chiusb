Module ConstMod

    Public Const XMLCFG = "\Config.xml"

    Public Const NUM_MAX_TYPE_INT = 35      ' Codice tipo intervento massimo possibile (non tutti sono usati)
    Public Const NUM_INT_TYPES = 25         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)

    Public Const INTERVENTO_LENGTH = 16     ' Dimensione array USB singolo intervento


    ' Definizione Codici dei vari tipi di intervento
    Public Const TYPE_OFF = 0
    Public Const TYPE_ON = 1
    Public Const TYPE_CHANGE_PN = 2

    Public Const TYPE_NOHALT_OVERCURR = 10
    Public Const TYPE_NOHALT_OVERVOLT = 11
    Public Const TYPE_NOHALT_UNDERVOLT = 12
    Public Const TYPE_NOHALT_MANDATACH = 13
    Public Const TYPE_NOHALT_DRYFUNC = 14
    Public Const TYPE_NOHALT_OVERTEMP = 15
    Public Const TYPE_NOHALT_MIN_FLOW = 16
    Public Const TYPE_NOHALT_SQUILIBRIO = 17
    Public Const TYPE_NOHALT_DISSIMETRIA = 18
    Public Const TYPE_NOHALT_SOVRAPRESSIONE = 19

    Public Const TYPE_HALT_OVERCURR = 10 + 10
    Public Const TYPE_HALT_OVERVOLT = 11 + 10
    Public Const TYPE_HALT_UNDERVOLT = 12 + 10
    Public Const TYPE_HALT_MANDATACH = 13 + 10
    Public Const TYPE_HALT_DRYFUNC = 14 + 10
    Public Const TYPE_HALT_OVERTEMP = 15 + 10
    Public Const TYPE_HALT_MIN_FLOW = 16 + 10
    Public Const TYPE_HALT_SQUILIBRIO = 17 + 10
    Public Const TYPE_HALT_DISSIMETRIA = 18 + 10
    Public Const TYPE_HALT_PRESS_SENS = 19 + 10
    Public Const TYPE_HALT_SOVRAPRESSIONE = 30
    Public Const TYPE_HALT_CORTO_CIRCUITO = 31




    ' Descrizione stringa dei vari tipi di intervento
    Public Const TYPE_ON_STR = "ON  "
    Public Const TYPE_OFF_STR = "OFF "
    Public Const TYPE_CHANGE_PN_STR = "Nom Power Change "

    Public Const TYPE_NOHALT_OVERCURR_STR = "Over Current" + " ON"
    Public Const TYPE_NOHALT_OVERVOLT_STR = "Over Voltage" + " ON"
    Public Const TYPE_NOHALT_UNDERVOLT_STR = "Under Voltage" + " ON"
    Public Const TYPE_NOHALT_MANDATACH_STR = "Min. Flow" + " ON"
    Public Const TYPE_NOHALT_DRYFUNC_STR = "Dry Operating" + " ON"
    Public Const TYPE_NOHALT_OVERTEMP_STR = "Pump OverTemp" + " ON"
    Public Const TYPE_NOHALT_MIN_FLOW_STR = "Minimum flow" + " ON"
    Public Const TYPE_NOHALT_SQUILIBRIO_STR = "Current Diff" + " ON"
    Public Const TYPE_NOHALT_DISSIMETRIA_STR = "Voltage Diff" + " ON"
    Public Const TYPE_NOHALT_SOVRAPRESSIONE_STR = "Over Pressure" + " ON"

    Public Const TYPE_HALT_OVERCURR_STR = "Over Current" + " OFF"
    Public Const TYPE_HALT_OVERVOLT_STR = "Over Voltage" + " OFF"
    Public Const TYPE_HALT_UNDERVOLT_STR = "Under Voltage" + " OFF"
    Public Const TYPE_HALT_MANDATACH_STR = "Min. Flow" + " OFF"
    Public Const TYPE_HALT_DRYFUNC_STR = "Dry Operating" + " OFF"
    Public Const TYPE_HALT_OVERTEMP_STR = "Pump OverTemp" + " OFF"
    Public Const TYPE_MIN_FLOW_STR = "Minimum Flow" + " OFF"
    Public Const TYPE_HALT_SQUILIBRIO_STR = "Current Diff" + "OFF"
    Public Const TYPE_HALT_DISSIMETRIA_STR = "Voltage Diff" + " OFF"
    Public Const TYPE_HALT_PRESS_SENS_STR = "Press Sens" + " OFF"
    Public Const TYPE_HALT_SOVRAPRESSIONE_STR = "Over Pressure" + " OFF"
    Public Const TYPE_HALT_CORTO_CIRCUITO_STR = "Short Circuit" + " OFF"




    ' Struttura delle confiugurazioni in risposta a Hello
    ' Ogni numero è composto da 2 byte (sono int)
    ' Sono 48 posizioni da 2 byte
    '	1	1	numero_serie,//1-65535
    '	3	2	calibrazione_I1,
    '	5	3	calibrazione_I2,    
    '	7	4	calibrazione_I3,    
    '	9	5	N_tabella_potenza,//trifase .37 - 5.5KW, monofase .37 - 3 KW
    '	11	6	potenza_nominale,// W*10
    '	13	7	ritardo_protezione_squilibrio,//s
    '	15	8	ritardo_protezione_tensione,//minuti
    '	17	9	ritardo_riaccensione_da_emergenza_V,//s
    '	19	10	ritardo_riaccensione_da_emergenza_I,//minuti
    '	21	11	ritardo_stop_mandata_chiusa,//s
    '	23	12	ritardo_stop_funzionamento_a_secco,//s
    '	25	13	ritardo_riaccensione_mandata_chiusa,//s
    '	27	14	ritardo_riaccensione_funzionamento_a_secco,//minuti
    '	29	15	timer_ritorno_da_emergenza_sensore,//s
    '	31	16	portata_sensore_pressione,//Bar*10
    '	33	17	corrente_minima_sensore,//mA*10
    '	35	18	corrente_massima_sensore,//mA*10
    '	37	19	scala_sensore_di_flusso,//litri*1000/impulso
    '	39	20	tipo_sonda_PT100,//numero dei fili
    '	41	21	resistenza_PT100_a_0gradi,//Ohm*10
    '	43	22	resistenza_PT100_a_100gradi,//Ohm*10
    '	45	23	limite_intervento_temper_motore,//°C
    '	47	24	pressione_emergenza,//Bar*10
    '	49	25	pressione_spegnimento,//Bar*10
    '	51	26	pressione_accensione,//Bar*10
    '	53	27	limite_minimum_flow,//litri/minuto
    '	55	28	limite_maximum_flow,//litri/minuto
    '	57	29	potenza_minima_mandata_chiusa,//%
    '	59	30	potenza_minima_funz_secco,//%
    '	61	31	K_di_tempo_riscaldamento,//s
    '	63	32	limite_sovratensione,// %
    '	65	33	limite_sottotensione,// %
    '	67	34	tensione_restart,// %
    '	69	35	limite_sovracorrente,// %
    '	71	36	limite_segnalazione_dissimmetria,// %
    '	73	37	limite_intervento_dissimmetria,// %
    '	75	38	limite_segnalazione_squilibrio,// %
    '	77	39	limite_intervento_squilibrio,// %
    '	79	40	tensione_nominale,// V
    '	81	41	corrente_nominale,// A*10
    '	83	42	abilita_sensore_pressione,//0-1
    '	85	43	abilita_sensore_flusso,//0-1
    '	87	44	abilita_sensore_temperatura,//0-1
    '	89	45	modo_start_stop,//0=remoto o 1=pressione
    '	91	46	motore_on,//45 //0-1
    '	93	47	numero_segnalazione,//46 //0-6539
    '	95	48	conta_ore[2],//47
    '	97	49	
    '	99	50	conta_ore_funzionamento[2],//49 //s
    '	101	51	
    '	103	52	energia[2],//51 //KWh
    '	105	53	
    '	107	54	totalizzatore_litri[2],//53
    '	109	55	
    '	111	56	riserva[8];//55
    '	113	57	
    '	115	58	
    '	117	59	
    '	119	60	
    '	121	61	
    '	123	62	
    '	125	63	


End Module
