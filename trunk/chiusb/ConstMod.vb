Module ConstMod

    Public Const XMLCFG = "\Config.xml"

    Public Const NUM_MAX_TYPE_INT = 35      ' Codice tipo intervento massimo possibile (non tutti sono usati)
    Public Const NUM_INT_TYPES = 28         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)

    Public Const INTERVENTO_LENGTH = 16     ' Dimensione array USB singolo intervento


    ' Definizione Codici dei vari tipi di intervento
    Public Const TYPE_OFF = 0
    Public Const TYPE_ON = 1
    Public Const TYPE_CHANGE_PN = 2

    Public Const TYPE_REMOTE_OFF = 3
    Public Const TYPE_REMOTE_ON = 4
    Public Const TYPE_AUTO_ON = 5


    Public Const TYPE_NOHALT_OVERCURR = 10
    Public Const TYPE_NOHALT_OVERVOLT = 11
    Public Const TYPE_NOHALT_UNDERVOLT = 12
    Public Const TYPE_NOHALT_MANDATACH = 13
    Public Const TYPE_NOHALT_DRYFUNC = 14
    Public Const TYPE_NOHALT_OVERTEMP = 15
    Public Const TYPE_NOHALT_MAX_FLOW = 16
    Public Const TYPE_NOHALT_SQUILIBRIO = 17
    Public Const TYPE_NOHALT_DISSIMETRIA = 18
    Public Const TYPE_NOHALT_SOVRAPRESSIONE = 19

    Public Const TYPE_HALT_OVERCURR = 10 + 10
    Public Const TYPE_HALT_OVERVOLT = 11 + 10
    Public Const TYPE_HALT_UNDERVOLT = 12 + 10
    Public Const TYPE_HALT_MANDATACH = 13 + 10
    Public Const TYPE_HALT_DRYFUNC = 14 + 10
    Public Const TYPE_HALT_OVERTEMP = 15 + 10
    Public Const TYPE_HALT_MAX_FLOW = 16 + 10
    Public Const TYPE_HALT_SQUILIBRIO = 17 + 10
    Public Const TYPE_HALT_DISSIMETRIA = 18 + 10
    Public Const TYPE_HALT_PRESS_SENS = 19 + 10
    Public Const TYPE_HALT_SOVRAPRESSIONE = 30
    Public Const TYPE_HALT_CORTO_CIRCUITO = 31




    ' Descrizione stringa dei vari tipi di intervento
    Public Const MAXLEN_STR = 20 + 4
    Public Const TYPE_ON_STR = "ON  "
    Public Const TYPE_OFF_STR = "OFF "
    Public Const TYPE_CHANGE_PN_STR = "Nom Power Change "
    Public Const TYPE_REMOTE_OFF_STR = "Remote OFF "
    Public Const TYPE_REMOTE_ON_STR = "Remote ON "
    Public Const TYPE_AUTO_ON_STR = "Auto ON "

    Public Const TYPE_NOHALT_OVERCURR_STR = "Over Current" + " ON"
    Public Const TYPE_NOHALT_OVERVOLT_STR = "Over Voltage" + " ON"
    Public Const TYPE_NOHALT_UNDERVOLT_STR = "Under Voltage" + " ON"
    Public Const TYPE_NOHALT_MANDATACH_STR = "Min. Flow" + " ON"
    Public Const TYPE_NOHALT_DRYFUNC_STR = "Dry Working" + " ON"
    Public Const TYPE_NOHALT_OVERTEMP_STR = "Pump OverTemp" + " ON"
    Public Const TYPE_NOHALT_MAX_FLOW_STR = "Maximum flow" + " ON"
    Public Const TYPE_NOHALT_SQUILIBRIO_STR = "Unbalanced Current" + " ON"
    Public Const TYPE_NOHALT_DISSIMETRIA_STR = "Dissymmetric Voltage" + " ON"
    Public Const TYPE_NOHALT_SOVRAPRESSIONE_STR = "Over Pressure" + " ON"

    Public Const TYPE_HALT_OVERCURR_STR = "Over Current" + " OFF"
    Public Const TYPE_HALT_OVERVOLT_STR = "Over Voltage" + " OFF"
    Public Const TYPE_HALT_UNDERVOLT_STR = "Under Voltage" + " OFF"
    Public Const TYPE_HALT_MANDATACH_STR = "Min. Flow" + " OFF"
    Public Const TYPE_HALT_DRYFUNC_STR = "Dry Working" + " OFF"
    Public Const TYPE_HALT_OVERTEMP_STR = "Pump OverTemp" + " OFF"
    Public Const TYPE_MAX_FLOW_STR = "Maximum Flow" + " OFF"
    Public Const TYPE_HALT_SQUILIBRIO_STR = "Unbalanced Current" + "OFF"
    Public Const TYPE_HALT_DISSIMETRIA_STR = "Disymmetric Voltage" + " OFF"
    Public Const TYPE_HALT_PRESS_SENS_STR = "Press Sens" + " OFF"
    Public Const TYPE_HALT_SOVRAPRESSIONE_STR = "Over Pressure" + " OFF"
    Public Const TYPE_HALT_CORTO_CIRCUITO_STR = "Short Circuit" + " OFF"




    ' Struttura delle confiugurazioni in risposta a Hello
    ' Ogni numero è composto da 2 byte (sono int)
    ' A parte gli ultimi dove ci sono long e char
    '	Pos # byte	# int	int //dai di funzionamento a partire dall'indirizzo 8040  della eeprom
    '	1	1	numero_serie,//1-65535
    '	3	2	potenza_nominale,// W*10
    '	5	3	ritardo_protezione_squilibrio,//s
    '	7	4	ritardo_protezione_tensione,//minuti
    '	9	5	ritardo_riaccensione_da_emergenza_V,//s
    '	11	6	ritardo_riaccensione_da_emergenza_I,//minuti
    '	13	7	ritardo_stop_mandata_chiusa,//s
    '	15	8	ritardo_stop_funzionamento_a_secco,//s
    '	17	9	ritardo_riaccensione_mandata_chiusa,//s
    '	19	10	ritardo_riaccensione_funzionamento_a_secco,//minuti
    '	21	11	timer_ritorno_da_emergenza_sensore,//s
    '	23	12	portata_sensore_pressione,//Bar*10
    '	25	13	corrente_minima_sensore,//mA*10
    '	27	14	corrente_massima_sensore,//mA*10
    '	29	15	tipo_sonda_PT100,//numero dei fili
    '	31	16	resistenza_PT100_a_0gradi,//Ohm*10
    '	33	17	resistenza_PT100_a_100gradi,//Ohm*10
    '	35	18	limite_intervento_temper_motore,//°C
    '	37	19	pressione_emergenza,//Bar*10
    '	39	20	pressione_spegnimento,//Bar*10
    '	41	21	pressione_accensione,//Bar*10
    '	43	22	limite_minimum_flow,//litri/minuto
    '	45	23	limite_maximum_flow,//litri/minuto
    '	47	24	potenza_minima_mandata_chiusa,//%
    '	49	25	potenza_minima_funz_secco,//%
    '	51	26	K_di_tempo_riscaldamento,//s
    '	53	27	limite_sovratensione,// %
    '	55	28	limite_sottotensione,// %
    '	57	29	tensione_restart,// %
    '	59	30	limite_sovracorrente,// %
    '	61	31	limite_segnalazione_dissimmetria,// %
    '	63	32	limite_segnalazione_squilibrio,// %
    '	65	33	limite_intervento_dissimmetria,// %
    '	67	34	limite_intervento_squilibrio,// %
    '	69	35	tensione_nominale,// V
    '	71	36	corrente_nominale,// A*10
    '	73	37	abilita_sensore_pressione,//0-1
    '	75	38	abilita_sensore_flusso,//0-1
    '	77	39	abilita_sensore_temperatura,//0-1
    '	79	40	modo_start_stop,//0=remoto o 1=pressione
    '	81	41	motore_on,//45 //0-1
    '	83	42	numero_segnalazione,//46 //0-6539
    '	85	43	conta_ore[2],//47
    '	87	44	
    '	89	45	conta_ore_funzionamento[2],//49 //s
    '	91	46	
    '	93	47	energia[3],//51 //KWh
    '	95	48	
    '	97	49	
    '	99	50	totalizzatore_litri[3],//54
    '	101	51	
    '	103	52	
    '	105	53	timer_relay_avviamento;//57
    '	107	54	
    '	109	55	scala_sensore_di_flusso,//litri*100/impulso   1-100000
    '	111	56	
    '	113	57	volume_massimo,//litri   1-1000000
    '	115	58	
    '	117	59	timer_riavviamento;//58
    '	119	60	
    '	121	61	N_tabella_potenza,//trifase .37 - 5.5KW, monofase .37 - 3 KW
    '	122		calibrazione_I1,
    '	123		calibrazione_I2,    
    '	124		calibrazione_I3,    
    '	125		segnalazione_,//60
    '	126		tentativi_avviamento_a_secco,
    '	127		abilita_contatore_down,//0-1
    '	128		riserva;



End Module
