DEL /f /s /q DefaultReport

DEL /f /s /q LDSoft.APOL.UI.Tests\bin\Debug\DefaultReport

DEL /f /q TestResult.xml

DEL /f /q LDSoft.APOL.UI.Tests\bin\Debug\TestResult.xml

REM PATH=%PATH%;C:\Program Files (x86)\NUnit 2.6.2\bin\

"C:\Program Files (x86)\NUnit 2.6.2\bin\nunit-console.exe" LDSoft.APOL.UI.Tests\bin\Debug\LDSoft.APOL.UI.Tests.dll

packages\NUnit2Report.Console.Runner.1.0.0.0\NUnit2Report.Console.exe --fileset=TestResult.xml

START DefaultReport\index.htm