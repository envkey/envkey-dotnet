@echo off

set scriptdir=%~dp0
set wget="%~dp0tools\wget.exe"
set tar="%~dp0tools\tartool.exe"

set /P VERSION=Version to Download (eg. 1.1.1): 

mkdir %scriptdir%contentFiles\any\any>NUL 2>&1

echo %wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_windows_amd64.tar.gz
%wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_windows_amd64.tar.gz

echo %tar% envkey-fetch_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\any\any\
%tar% envkey-fetch_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\any\any\

del envkey-fetch_%VERSION%_windows_amd64.tar.gz

pause