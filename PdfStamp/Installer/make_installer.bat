REM Delete previous artifacts
DEL /F /Q ..\sources.zip
DEL /F /Q pdfstamper.msi
DEL /F /Q pdfstamper64.msi
SET PATH=C:\Program Files (x86)\7-Zip;C:\Program Files (x86)\WiX Toolset v3.7\bin\;%PATH%

REM Create sources.zip
RMDIR /S /Q ..\PdfLegalStampForm\bin\
RMDIR /S /Q ..\PdfLegalStampForm\obj\
7z.exe a ..\sources.zip ..\PdfLegalStampForm

REM Create installer - 32bit
candle pdfstamper.wxs
light pdfstamper.wixobj

REM Create installer - 64bit
candle pdfstamper64.wxs
light pdfstamper64.wixobj

PAUSE