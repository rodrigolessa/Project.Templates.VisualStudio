ECHO DEL /f /s /q DefaultReport

ECHO DEL /f /s /q LDSoft.APOL.UI.Tests\bin\Debug\DefaultReport

packages\NUnit2Report.Console.Runner.1.0.0.0\NUnit2Report.Console.exe --fileset=TestResult.xml

START DefaultReport\index.htm