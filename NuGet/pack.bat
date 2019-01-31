@echo off

set scriptdir=%~dp0
set nuget="%~dp0Nuget.exe"

set /P VERSION=Version to Build (eg. 1.2.4): 

DEL %scriptdir%*.nupkg>NUL 2>&1

%nuget% pack "%scriptdir%EnvKey.Sdk.nuspec" -version %VERSION%
%nuget% pack "%scriptdir%EnvKey.Platform.Windows64.nuspec" -version %VERSION%
%nuget% pack "%scriptdir%EnvKey.Platform.Linux64.nuspec" -version %VERSION%
%nuget% pack "%scriptdir%EnvKey.Platform.Osx64.nuspec" -version %VERSION%
%nuget% pack "%scriptdir%EnvKey.nuspec" -version %VERSION%
pause