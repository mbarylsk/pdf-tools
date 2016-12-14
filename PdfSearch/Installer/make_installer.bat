REM Delete previous artifacts
DEL /F /Q ..\sources.zip
DEL /F /Q pdfsearch.msi
DEL /F /Q pdfsearch64.msi
SET PATH=C:\Program Files (x86)\7-Zip;C:\Program Files (x86)\WiX Toolset v3.7\bin\;%PATH%

REM Create sources.zip
RMDIR /S /Q ..\PdfSearch\bin\
RMDIR /S /Q ..\PdfSearch\obj\
7z.exe a ..\sources.zip ..\PdfSearch

REM Create installer - 32bit
candle pdfsearch.wxs
light pdfsearch.wixobj

REM Create installer - 64bit
candle pdfsearch64.wxs
light pdfsearch64.wixobj

PAUSE