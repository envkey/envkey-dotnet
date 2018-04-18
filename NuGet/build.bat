@echo off

set scriptdir="%~dp0"
set nuget="%~dp0Nuget.exe"
set msbuild="C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"

cd ..
%nuget% restore EnvKeyNuget.sln
%msbuild% EnvKeyNuget.sln /t:Rebuild /p:Configuration=Release

pause
