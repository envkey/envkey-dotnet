@echo off

set scriptdir=%~dp0
set nuget="%~dp0Nuget.exe"

set /P VERSION=Version to Build (eg. 1.1.2): 

DEL %scriptdir%*.nupkg>NUL 2>&1

%nuget% pack "%scriptdir%EnvKey.nuspec" -version %VERSION%
pause