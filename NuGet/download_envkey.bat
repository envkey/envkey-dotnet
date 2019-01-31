@echo off

set scriptdir=%~dp0
set wget="%~dp0tools\wget.exe"
set tar="%~dp0tools\tartool.exe"

set /P VERSION=Version to Download (eg. 1.2.4): 

echo %wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_windows_amd64.tar.gz
%wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_windows_amd64.tar.gz
echo %wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_linux_amd64.tar.gz
%wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_linux_amd64.tar.gz
echo %wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_darwin_amd64.tar.gz
%wget% https://github.com/envkey/envkey-fetch/releases/download/v%VERSION%/envkey-fetch_%VERSION%_darwin_amd64.tar.gz

echo %tar% envkey-fetch_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\win64\
%tar% envkey-fetch_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\win64\
echo %tar% envkey-fetch_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\linux64\
%tar% envkey-fetch_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\linux64\
echo %tar% envkey-fetch_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\darwin64\
%tar% envkey-fetch_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\darwin64\

del *.tar.gz

pause
