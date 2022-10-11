@echo off

set scriptdir=%~dp0
set wget="%~dp0tools\wget.exe"
set tar="%~dp0tools\tartool.exe"

set /P VERSION=Version to Download (eg. 2.0.27): 

REM latest envkey source version: https://envkey-releases.s3.amazonaws.com/latest/envkeysource-version.txt
REM v2.0.27

echo %wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_windows_amd64.tar.gz
%wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_windows_amd64.tar.gz

echo %wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_linux_amd64.tar.gz
%wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_linux_amd64.tar.gz

echo %wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_darwin_amd64.tar.gz
%wget% https://envkey-releases.s3.amazonaws.com/envkeysource/release_artifacts/%VERSION%/envkey-source_%VERSION%_darwin_amd64.tar.gz

echo %tar% envkey-source_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\win64\
%tar% envkey-source_%VERSION%_windows_amd64.tar.gz %scriptdir%contentFiles\win64\
@REM echo move %scriptdir%contentFiles\win64\envkey-source.exe %scriptdir%contentFiles\win64\envkey-source_win64.exe
@REM move %scriptdir%contentFiles\win64\envkey-source.exe %scriptdir%contentFiles\win64\envkey-source_win64.exe

echo %tar% envkey-source_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\linux64\
%tar% envkey-source_%VERSION%_linux_amd64.tar.gz %scriptdir%contentFiles\linux64\
@REM echo move %scriptdir%contentFiles\linux64\envkey-source %scriptdir%contentFiles\linux64\envkey-source_linux64
@REM move %scriptdir%contentFiles\linux64\envkey-source %scriptdir%contentFiles\linux64\envkey-source_linux64

echo %tar% envkey-source_%VERSION%_darwin_amd64.tar.gz %scriptdir%contentFiles\darwin64\
%tar% envkey-source_%VERSION%_darwin_amd64.tar.gz %scriptdir%contentFiles\darwin64\
@REM echo move %scriptdir%contentFiles\darwin64\envkey-source %scriptdir%contentFiles\darwin64\envkey-source_darwin64
@REM move %scriptdir%contentFiles\darwin64\envkey-source %scriptdir%contentFiles\darwin64\envkey-source_darwin64

del *.tar.gz

pause
