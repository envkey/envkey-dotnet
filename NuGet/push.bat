@echo off

@echo off

set scriptdir=%~dp0
set nuget="%~dp0Nuget.exe"

set /P APIKEY=Enter your Api Key from https://www.nuget.org/account/ApiKeys: 

if "%APIKEY%"=="" GOTO ERROR

rem echo %nuget% push "%scriptdir%*.nupkg" %APIKEY% -Source https://nuget.org
%nuget% push "%scriptdir%*.nupkg" %APIKEY% -Source https://nuget.org
GOTO END

:ERROR
echo EXIT: No api key was entered

:END