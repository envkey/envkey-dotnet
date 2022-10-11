@echo off

set scriptdir="%~dp0"
set nuget="%~dp0Nuget.exe"
set msbuild="C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\amd64\MSBuild.exe"

cd ..
%nuget% restore EnvKeyNuget.sln
%msbuild% EnvKeyNuget.sln /t:Rebuild /p:Configuration=Release

pause
