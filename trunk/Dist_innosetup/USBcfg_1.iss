; ****************************************************************************
; Script di creazione pacchetti installazione
;
; Usare compilatore - Inno Setup
; Extra info su Framework .NET
; http://zerosandtheone.com/blogs/vb/archive/2008/06/23/vb-net-install-your-app-and-the-net-framework-using-inno-setup.aspx
; http://www.codeproject.com/KB/install/dotnetfx_innosetup_instal.aspx
; ****************************************************************************

; Inno Setup PreProccessor
[ISPP]
#define AppName "Usb Pump Control Box"
#define ShortAppName "USB Pump Control Box"
#define AppVersion "2.5.0"
#define AppPublisher "Electroil"
#define AppURL "http://www.electroil.it/"

#define IncludeFramework false
#define SourceFileDir "..\chiusb\bin\debug"

; Inno Setup Script Includes routines, devono essere installate.
[ISSI]
#define ISSI_IncludePath "C:\Programmi\ISSI"
#include ISSI_IncludePath+"\_issi.isi"


[Setup]
; Versione dell'installer
;VersionInfoVersion=1.0

; Nome commerciale dell'applicazione
AppName={#AppName} {#AppVersion}
AppVersion={#AppVersion}
; Nome e versione del programma (visibile nella pag di benvenuto)
AppVerName={#ShortAppName} 
AppPublisher={#AppPublisher}
AppPublisherURL={#AppUrl}
AppSupportURL={#AppUrl}
AppUpdatesURL={#AppUrl}

; Dir di default di installazione - NON usare la cartella precedentemente usata
DefaultDirName={pf}\{#ShortAppName} {#AppVersion}
UsePreviousAppDir=no

;Gruppo di programmi del menu AVVIO - NON usare il gruppo precedentemente usato
DefaultGroupName={#ShortAppName}
UsePreviousGroup=false

; Dir del programma di installazione compilato
OutputDir=.\PktInnoSetup\
; Imposer un compte administrateur pour l'installation (nécessaire pour l'enregistrement de dll et ocx)
PrivilegesRequired=admin


; Copyright
AppCopyright=Copyright© {#AppPublisher} 2010

; Immagini personalizzate
WizardImageFile=C:\Programmi\Inno Setup 5\WizModernImage-IS.bmp
WizardSmallImageFile=C:\Programmi\Inno Setup 5\WizModernSmallImage-IS.bmp
;WizardSmallImageFile=.\logo.bmp

; Nome programma di installazione
#if IncludeFramework
  OutputBaseFilename=Setup_Fw-{#ShortAppName}
#else
  OutputBaseFilename=Setup_{#ShortAppName}_{#AppVersion}
#endif

; forza visualizzazione delle lingue d'installazione (problema su PC bertoldi che andava solo in inglese)
;ShowUndisplayableLanguages = yes

; Visualuzza le lingue d'installazione
;ShowLanguageDialog = yes

; Icona del file di Setup
;SetupIconFile=xxx.ico

; Fixer les versions minimales de Windows requises pour l'installation
;MinVersion=0,5.0.2195
; Définir un répertoire source par défaut dans lequel seront recherché les fichiers de la section [Files], si le répertoire source n'est pas précisé
;SourceDir=C:\MyProgram

; Afficher un texte d'information avant l'installation
;InfoBeforeFile=.\InfosBefore.txt
; Afficher un texte d'information après l'installation
;InfoAfterFile=.\InfosAfter.txt
; Afficher une page contenant le texte de licence
;LicenseFile=.\Licence.txt




[Files]
Source: {#SourceFileDir}\USBConfig.exe; DestDir: {app}; DestName: USBConfig.exe; Flags: ignoreversion
Source: {#SourceFileDir}\ZedGraph.dll; DestDir: {app}; DestName: ZedGraph.dll; Flags: ignoreversion 
Source: .\Inf_driver\HC9S08JMxx.inf; DestDir: {app}\driver_usb\; DestName: UsbJM60.inf; Flags: ignoreversion
#if IncludeFramework
  Source: dotnetfx.exe; DestDir: {tmp}; Flags: ignoreversion ; Check: NeedsFramework
#endif


[Icons]
Name: {group}\{#AppName} {#AppVersion};                     Filename: {app}\USBConfig.exe; WorkingDir: {app}
Name: {group}\Uninstall {#AppName} {#AppVersion};           Filename: {uninstallexe}
Name: {userdesktop}\{#AppName} {#AppVersion}; Filename: {app}\USBConfig.exe; WorkingDir: {app}


[Languages]
; Ajouter ci-dessous toutes les langues que vous souhaitez rendre disponibles
Name: eng; MessagesFile: compiler:Default.isl



[Run]
#if IncludeFramework
  Filename: {tmp}\dotnetfx.exe; Parameters: "/q:a /c:""install /l /q"""; WorkingDir: {tmp}; Flags: skipifdoesntexist; StatusMsg: "Installing .NET Framework if needed"
#endif
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -remgroup ""MyApp"""; WorkingDir: {tmp}; Flags: skipifdoesntexist runhidden; StatusMsg: "Setting Program Access Permissions..."
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -addgroup 1.2 -url ""file://{app}/*"" FullTrust -name ""MyApp"""; WorkingDir: {tmp}; Flags: skipifdoesntexist runhidden; StatusMsg: "Setting Program Access Permissions..."


;Filename: {sys}\rundll32.exe; Parameters: "setupapi,InstallHinfSection DefaultInstall 128 {app}\driver_usb\UsbJM60.inf"; 
;Filename: {sys}\rundll32.exe; Parameters: "setupapi,InstallHinfSection DefaultInstall 132 .\<driver>x86.inf"; WorkingDir: {app}; Flags: 32bit; Check: IsX86;
;The normal method to install a .inf file is to right click on it and select Install from the context menu however it is also possible to install from the command line. The syntax is: 
;C:\>rundll32 syssetup,SetupInfObjectInstallAction DefaultInstall 128 .\<file>.inf

[Registry]
; Création de la clé primaire
;Root: HKCU; Subkey: Software\VB and VBA Program Settings\{code:GetNameApp}; Flags: uninsdeletekey
; Inscription des valeurs de clés secondaires
;Root: HKCU; Subkey: Software\VB and VBA Program Settings\{code:GetNameApp}\Setup; ValueType: string; ValueName: LicenseName; ValueData: {sysuserinfoorg}
;Root: HKCU; Subkey: Software\VB and VBA Program Settings\{code:GetNameApp}\Setup; ValueType: string; ValueName: Language; ValueData: 0; Languages: it
;Root: HKCU; Subkey: Software\VB and VBA Program Settings\{code:GetNameApp}\Setup; ValueType: string; ValueName: Language; ValueData: 4000; Languages: en


[UninstallDelete]
; Da completare per rimuovere tutti i file
Type: files; Name: "{userappdata}\{#ShortAppName}\*";
Type: dirifempty; Name: "{userappdata}\{#ShortAppName}";



[UninstallRun]
Filename: {win}\Microsoft.NET\Framework\v2.0.50727\CasPol.exe; Parameters: "-q -machine -remgroup ""MyApp"""; Flags: skipifdoesntexist runhidden;

[Code]

// Indicates whether .NET Framework 2.0 is installed.
function IsDotNET20Detected(): boolean;
var
    success: boolean;
    install: cardinal;
begin
    success := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727', 'Install', install);
    Result := success and (install = 1);
end;

//RETURNS OPPOSITE OF IsDotNet20Detected FUNCTION
//Remember this method from the Files section above
function NeedsFramework(): Boolean;
begin
  Result := (IsDotNET20Detected = false);
end;

//CHECKS TO SEE IF CLIENT MACHINE IS WINDOWS 95
function IsWin95 : boolean;
begin
  Result := (InstallOnThisVersion('4.0,0', '4.1.1998,0') = irInstall);
end;

//CHECKS TO SEE IF CLIENT MACHINE IS WINDOWS NT4
function IsWinNT : boolean;
begin
  Result := (InstallOnThisVersion('0,4.0.1381', '0,4.0.1381') = irInstall);
end;

//GETS VERSION OF IE INSTALLED ON CLIENT MACHINE
function GetIEVersion : String;
var
  IE_VER: String;
begin
  {First check if Internet Explorer is installed}
  if RegQueryStringValue(HKLM,'SOFTWARE\Microsoft\Internet Explorer','Version',IE_VER) then
      Result := IE_VER
else
    {No Internet Explorer at all}
    result := '';
end;

//GETS THE VERSION OF WINDOWS INSTALLER DLL
function GetMSIVersion(): String;
begin
    GetVersionNumbersString(GetSystemDir+'\msi.dll', Result);
end;

//LAUNCH DEFAULT BROWSER TO WINDOWS UPDATE WEBSITE
procedure GoToWindowsUpdate;
var
  ErrorCode: Integer;
begin
  if (MsgBox('Would you like to go to the Windows Update site now?' + chr(13) + chr(13) + '(Requires Internet Connection)'
            , mbConfirmation, MB_YESNO) = IDYES) then
      ShellExec('open', 'http://windowsupdate.microsoft.com','', '', SW_SHOW, ewNoWait, ErrorCode);
end;


//IF SETUP FINISHES WITH EXIT CODE OF 0, MEANING ALL WENT WELL
//THEN CHECK FOR THE PRESENCE OF THE REGISTRY FLAG TO INDICATE THE
//.NET FRAMEWORK WAS INSTALLED CORRECTLY
//IT CAN FAIL WHEN CUST DOESN'T HAVE CORRECT WINDOWS INSTALLER VERSION
function GetCustomSetupExitCode(): Integer;
begin
  if (IsDotNET20Detected = false) then
    begin
      MsgBox('Please check for .NET Framework 2.0 installation!',mbError, MB_OK);
      result := -1
    end
end;




//We perform the following checks
//    * If Windows 2000, require at least SP3
//    * If WIndows XP, require at least SP2
//    * If Windows 95 or NT, don't install at all
//    * If NT based (2000, XP, 2003, Vista), require MSI Installer 3 or higher
//    * If 9x based (98, ME), require MSI Installer 2 or higher
//    * If IE version is less than version 5.01, don't install
//    * If admin is not logged on, don't install (.NET Framework install requires admin rights)
function InitializeSetup: Boolean;
var
  Version: TWindowsVersion;
  IE_VER: String;
  MSI_VER: String;
  NL: Char;
  NL2: String;
begin

  NL := Chr(13);
  NL2 := NL + NL;

  // Get Version of Windows from API Call
  GetWindowsVersionEx(Version);

  // On Windows 2000, check for SP3

  if Version.NTPlatform and
     (Version.Major = 5) and
     (Version.Minor = 0) and
     (Version.ServicePackMajor < 3) then
  begin
    SuppressibleMsgBox('When running on Windows 2000, Service Pack 3 is required.' + NL +
                       'Visit' + NL2 +
                       ' *** http://windowsupdate.microsoft.com ***' + NL2 +
                       'to get the needed Windows Updates,' + NL +
                       'and then reinstall this program',
                        mbCriticalError, MB_OK, MB_OK);
    GoToWindowsUpdate;
    Result := False;
    Exit;
  end;

  // On Windows XP, check for SP2
  if Version.NTPlatform and
     (Version.Major = 5) and
     (Version.Minor = 1) and
     (Version.ServicePackMajor < 2) then
  begin
    SuppressibleMsgBox('When running on Windows XP, Service Pack 2 is required.' + NL +
                       'Visit' + NL2 + ' *** http://windowsupdate.microsoft.com ***' + NL2 +
                       'to get the needed Windows Updates,' + NL +
                       'and then reinstall this program',
                       mbCriticalError, MB_OK, MB_OK);
    GoToWindowsUpdate;
    Result := False;
    Exit;
  end;

  //IF WINDOWS 95 OR NT DON'T INSTALL
  if (IsWin95) or (IsWinNT) then
  begin
    SuppressibleMsgBox('This program can not run on Windows 95 or Windows NT.',
      mbCriticalError, MB_OK, MB_OK);
    Result := False;
    Exit;
  end; 

  //CHECK MSI VER, NEEDS TO BE 3.0 ON ALL SUPPORTED SYSTEM EXCEPT 95/ME, WHICH NEEDS 2.0)
  MSI_VER := GetMSIVersion
  if ((Version.NTPlatform) and (MSI_VER < '3')) or ((Not Version.NTPlatform) and (MSI_VER < '2')) then
    begin
      SuppressibleMsgBox('You do not have all the required Windows Updates to install this program.' + NL +
                         'Visit *** http://windowsupdate.microsoft.com *** to get the needed Windows Updates,' + NL +
                         'and then reinstall this program',
                         mbCriticalError, MB_OK, MB_OK);
      GoToWindowsUpdate;
      Result := False;
      Exit;
  end; 

//  //CHECK THE IE VERSION (NEEDS TO BE 5.01+)
//  IE_VER := GetIEVersion;
//  if IE_VER < '5.01' then
//    begin
//      if IE_VER = '' then
//        begin
//          MsgBox('Microsoft Internet Explorer 5.01 or higher is required to run this program.' + NL2 +
//                 'You do not currently have Microsoft Internet Explorer installed, or it is not working correctly.' + NL +
//                 'Obtain a newer version at www.microsoft.com and then run setup again.', mbInformation, MB_OK);
//        end
//      else
//        begin
//          MsgBox('Microsoft Internet Explorer 5.01 or higher is required to run this program.' + NL2 +
//                 'You are using version ' + IE_VER + '.' + NL2 +
//                 'Obtain a newer version at www.microsoft.com and then run setup again.', mbInformation, MB_OK);
//        end
//
//      GoToWindowsUpdate;
//      result := false;
//      exit;
//  end; 

  //MAKE SURE USER HAS ADMIN RIGHTS BEFORE INSTALLING
  if IsAdminLoggedOn then
    begin
      result := true
        exit;
    end
  else
    begin
      MsgBox('You must have admin rights to perform this installation.' + NL +
             'Please log on with an account that has administrative rights,' + NL +
            'and run this installation again.', mbInformation, MB_OK);
        result := false;
    end
  end;
end.
