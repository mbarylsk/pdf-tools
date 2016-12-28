SET my_path="D:\Sources\Github\pdf-tools\PdfStamp"
CD %my_path%

REM Delete previous artifacts
DEL /F /Q sources.zip
DEL /F /Q ..\WebPage\download\pdfstamper.msi
DEL /F /Q ..\WebPage\download\pdfstamper64.msi
SET PATH=C:\Program Files (x86)\7-Zip;C:\Program Files (x86)\WiX Toolset v3.7\bin\;%PATH%

REM Create sources.zip
RMDIR /S /Q ..\PdfLegalStampForm\bin\
RMDIR /S /Q ..\PdfLegalStampForm\obj\
7z.exe a sources.zip PdfLegalStampForm

REM Create installer - 32bit
candle %my_path%\Installer\pdfstamper.wxs
light %my_path%\pdfstamper.wixobj

REM Create installer - 64bit
candle %my_path%\Installer\pdfstamper64.wxs
light %my_path%\pdfstamper64.wixobj

REM Deploy installer
MOVE pdfstamper.msi ..\WebPage\download
MOVE pdfstamper64.msi ..\WebPage\download

REM Cleanup
DEL /F /Q pdfstamper.wixobj
DEL /F /Q pdfstamper.wixpdb
DEL /F /Q pdfstamper64.wixobj
DEL /F /Q pdfstamper64.wixpdb
DEL /F /Q sources.zip