; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E521569B-1D04-4E33-851C-7B96E27115C7}
AppName=CaseMaker
AppVersion=1.0
;AppVerName=CaseMaker 1.0
AppPublisher=Landix Sistemas Ltda
AppPublisherURL=http://www.landix.com.br/
AppSupportURL=http://www.landix.com.br/
AppUpdatesURL=http://www.landix.com.br/
DefaultDirName={pf}\CaseMaker
DisableProgramGroupPage=yes
OutputBaseFilename=casemaker_install
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\CaseMaker.exe"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\PdfSharp.dll"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\PdfSharp.xml"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\PdfSharp.Charting.dll"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\PdfSharp.Charting.xml"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\de\PdfSharp.Charting.resources.dll"; DestDir: "{app}\de"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\de\PdfSharp.resources.dll"; DestDir: "{app}\de"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\CaseMaker.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\CaseMaker.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\DotNetZip.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\DotNetZip.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\DotNetZip.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\Newtonsoft.Json.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\EntityFramework.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\EntityFramework.SqlServer.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\EntityFramework.SqlServer.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\EntityFramework.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\System.Data.SQLite.dll.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\System.Data.SQLite.EF6.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\System.Data.SQLite.Linq.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\System.Data.SQLite.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\Tester_Documents.exe"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\Tester_Documents.pdb"; DestDir: "{app}"; Flags:
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\tester_documents\tester_documents\CaseMaker\Instalador\Files\x86\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\CaseMaker"; Filename: "{app}\CaseMaker.exe"
Name: "{commondesktop}\CaseMaker"; Filename: "{app}\CaseMaker.exe"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\CaseMaker"; Filename: "{app}\CaseMaker.exe"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\CaseMaker.exe"; Description: "{cm:LaunchProgram,CaseMaker}"; Flags: nowait postinstall skipifsilent

