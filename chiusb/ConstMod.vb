Module ConstMod

    Public Const XMLCFG = "\Config.xml"

    Public Const NUM_MAX_TYPE_INT = 15      ' Codice tipo intervento massimo possibile (non tutti sono usati)

    ' Modifiche richiesta da Chiussi via mail il 21/10/2013
    Public Const TEXT_NEO_3KW = "NEO 3.0 kW"
    Public Const TEXT_NEO_11KW = "NEO 11 kW"

    'Public Const NUM_INT_TYPES = 35         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)
    Public Const NUM_INT_TYPES = 25         ' Dimensione array tipo-interventi / occorrenze (è il numero effettivo di interventi)

    Public Const INTERVENTO_LENGTH = 20     ' Dimensione array USB singolo intervento


    ' Definizione Codici dei vari tipi di intervento
    Public Const TYPE_CURRENT_PEAK = 1
    Public Const TYPE_OVERVOLTAGE = 2
    Public Const TYPE_INVERTER_TEMPER = 3
    Public Const TYPE_THERMAL_PROTECT = 4
    Public Const TYPE_ENCODER_ERROR = 5
    Public Const TYPE_ENABLE_OFF = 6
    Public Const TYPE_OVERCURRENT = 7
    Public Const TYPE_INOUT_INVERTED = 8
    Public Const TYPE_UNDERVOLTAGE = 9
    Public Const TYPE_COMUNICAT_ERROR = 10

    Public Const TYPE_OVERCURRENT_B = 11
    Public Const TYPE_uP_TEMPERATURE = 12
    Public Const TYPE_OVER_CURRENT_U = 13
    Public Const TYPE_OVER_CURRENT_V = 14
    Public Const TYPE_OVER_CURRENT_W = 15
    Public Const TYPE_BREAKING_I_PEAK = 16
    Public Const TYPE_ERROR_READING_I1 = 17
    Public Const TYPE_ERROR_READING_I2 = 18
    Public Const TYPE_ERROR_READING_I3 = 19
    Public Const TYPE_UNBALANCED_CURR = 20
    Public Const TYPE_CURRENT_PEAK_U = 21
    Public Const TYPE_CURRENT_PEAK_V = 22
    Public Const TYPE_CURRENT_PEAK_W = 23
    Public Const TYPE_LEAKAGE_CURRENT = 24
    'Public Const TYPE_CURRENT_FAN_2 = 25
    'Public Const TYPE_CURRENT_FAN_1 = 26
    Public Const TYPE_OVER_CURRENT_FAN = 27



    ' Descrizione stringa dei vari tipi di intervento
    Public Const MAXLEN_STR = 19 + 4
    Public Const TYPE_CURRENT_PEAK_STR = "Current Peak "
    Public Const TYPE_OVERVOLTAGE_STR = "Over-Voltage "
    Public Const TYPE_INVERTER_TEMPER_STR = "Inverter Temper. "
    Public Const TYPE_THERMAL_PROTECT_STR = "Thermal Protect. "
    Public Const TYPE_ENCODER_ERROR_STR = "Encoder error "
    Public Const TYPE_ENABLE_OFF_STR = "Enable OFF "
    Public Const TYPE_OVERCURRENT_STR = "Over-Current "
    Public Const TYPE_INOUT_INVERTED_STR = "IN-OUT Inverted "
    Public Const TYPE_UNDERVOLTAGE_STR = "Under-Voltage "
    Public Const TYPE_COMUNICAT_ERROR_STR = "Comunicat. Error "

    Public Const TYPE_OVERCURRENT_B_STR = "Over-Current "
    Public Const TYPE_uP_TEMPERATURE_STR = "uP Temperature "
    Public Const TYPE_OVER_CURRENT_U_STR = "Over-Current U "
    Public Const TYPE_OVER_CURRENT_V_STR = "Over-Current V "
    Public Const TYPE_OVER_CURRENT_W_STR = "Over-Current W "
    Public Const TYPE_BREAKING_I_PEAK_STR = "Breaking I Peak "
    Public Const TYPE_ERROR_READING_I1_STR = "Error Reading I1 "
    Public Const TYPE_ERROR_READING_I2_STR = "Error Reading I2 "
    Public Const TYPE_ERROR_READING_I3_STR = "Error Reading I3 "
    Public Const TYPE_UNBALANCED_CURR_STR = "Unbalanced current "
    Public Const TYPE_CURRENT_PEAK_U_STR = "Current Peak U "
    Public Const TYPE_CURRENT_PEAK_V_STR = "Current Peak V "
    Public Const TYPE_CURRENT_PEAK_W_STR = "Current Peak W "
    Public Const TYPE_LEAKAGE_CURRENT_STR = "Leakage Current "
    Public Const TYPE_CURRENT_FAN_2_STR = "Current Fan 2 "
    Public Const TYPE_CURRENT_FAN_1_STR = "Current Fan 1 "
    Public Const TYPE_OVER_CURRENT_FAN_STR = "Over-Current Fan "



    '	Pos # byte	# int	int //dai di funzionamento a partire dall'indirizzo 8040  della eeprom
    '	1	1	lingua,//0
    '	3	2	codice_macchina,//1 0-127
    '	5	3	potenza_nominale,//2 kW*100
    '	7	4	tensione_nominale,//3 V_rms
    '	9	5	corrente_nominale,//4 A*10
    '	11	6	frequenza_nominale,//5 Hz
    '	13	7	rpm_nominali,//6 
    '	15	8	cosfi_nominale,//7   *100
    '	17	9	scorrimento_Coppia_Max,//8 %
    '	19	10	velocita_massima,//9 %
    '	21	11	velocita_minima,//10 %
    '	23	12	accelerazione,  //11 s*10
    '	25	13	decelerazione,  //12 s*10
    '	27	14	limite_assorbimento,//13 %
    '	29	15	senso_rotazione,//14 W
    '	31	16	velocita_interna,//15 rpm
    '	33	17	abilita_freno_elettromagnetico,//16
    '	35	18	tensione_frenatura,//17 A*10
    '	37	19	comunicazione_seriale_RS485,//18  0=master, 1-7=slave
    '	39	20	abilita_restart,//19 0,1
    '	41	21	attesa_riavviamento,//20 s*10
    '	43	22	origine_comandi,//21, 0:tastiera e commutatore su tastiera, 1=tastiera e senso rotazione fisso, 2=remoti
    '	45	23	origine_segnale_velocita,//22   0:velocità interna, 1:da tastierino, 2:potenziometro AN1,  3:riferimento 0-10V AN2
    '	47	24	parte_alta_rapporto_sensore,//23
    '	49	25	parte_bassa_rapporto_sensore,//24
    '	51	26	retroazione,//25
    '	53	27	fattore_proporzionale,//26
    '	55	28	fattore_integrale,//27
    '	57	29	rampa_rif_velocita,//28 s
    '	59	30	frequenza_radio,//29 MHz
    '	61	31	modifica_codice,//30
    '	63	32	numero_segnalazione;//31
    '	65	33	unsigned long       orologio;//32
    '	67	34	
    '	69	35	Int  riserva[14];




End Module
