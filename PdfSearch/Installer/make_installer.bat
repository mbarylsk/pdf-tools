SET my_path="D:\Sources\Github\pdf-tools\PdfSearch"
CD %my_path%

REM Delete previous artifacts
DEL /F /Q sources.zip
DEL /F /Q ..\WebPage\download\pdfsearch.msi
DEL /F /Q ..\WebPage\download\pdfsearch64.msi
SET PATH=C:\Program Files (x86)\7-Zip;C:\Program Files (x86)\WiX Toolset v3.7\bin\;%PATH%

REM Create sources.zip
RMDIR /S /Q PdfSearch\bin\
RMDIR /S /Q PdfSearch\obj\
7z.exe a sources.zip PdfSearch

REM Create installer - 32bit
candle %my_path%\Installer\pdfsearch.wxs
light %my_path%\pdfsearch.wixobj

REM Create installer - 64bit
candle %my_path%\Installer\pdfsearch64.wxs
light %my_path%\pdfsearch64.wixobj

REM Deploy installer
MOVE pdfsearch.msi ..\WebPage\download
MOVE pdfsearch64.msi ..\WebPage\download

REM Cleanup
DEL /F /Q pdfsearch.wixobj
DEL /F /Q pdfsearch.wixpdb
DEL /F /Q pdfsearch64.wixobj
DEL /F /Q pdfsearch64.wixpdb
DEL /F /Q sources.zip