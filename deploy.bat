@echo off

rmdir /s /q %1dist
mkdir %1dist

copy /y %1fxmanifest.lua %1dist
xcopy /y /e %1Client\bin\Release\net452\publish %1dist\Client\
xcopy /y /e %1Server\bin\Release\netstandard2.0\publish %1dist\Server\

rmdir /s /q "C:\FXServer\server-data\resources\FiveMenu"
mkdir "C:\FXServer\server-data\resources\FiveMenu"
xcopy /y /e %1dist "C:\FXServer\server-data\resources\FiveMenu"

If errorlevel 1 @exit 0
