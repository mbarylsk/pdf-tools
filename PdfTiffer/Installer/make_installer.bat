REM Delete previous artifacts
DEL /F /Q ..\sources.zip
DEL /F /Q ..\..\pdftiffer.msi
SET PATH=C:\Program Files (x86)\7-Zip;C:\Program Files (x86)\WiX Toolset v3.7\bin\;%PATH%

REM Create sources.zip
RMDIR /S /Q ..\PdfTiffer\bin\
RMDIR /S /Q ..\PdfTiffer\obj\
7z.exe a ..\sources.zip ..\PdfTiffer

REM Create installer
candle pdftiffer.wxs
light pdftiffer.wixobj

REM Deploy installer
MOVE pdftiffer.msi ..\..\WebPage\pobierz

PAUSE