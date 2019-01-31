@ECHO OFF

SET ENVKEY=%1

ECHO ==== net35 ====
..\Tests\bin\net35\Test35.exe %ENVKEY%
ECHO.
ECHO.

ECHO ==== net46 ====
..\Tests\bin\net46\Test46.exe %ENVKEY%
ECHO.
ECHO.

ECHO ==== net471 ====
..\Tests\bin\net471\Test471.exe %ENVKEY%
ECHO.
ECHO.

ECHO ==== netcoreapp2.0 ====
dotnet ..\Tests\bin\netcoreapp2.0\TestCore20.dll %ENVKEY%
ECHO.
ECHO.

ECHO ==== netcoreapp2.2 ====
dotnet ..\Tests\bin\netcoreapp2.2\TestCore22.dll %ENVKEY%
ECHO.
ECHO.

ECHO DONE!
pause