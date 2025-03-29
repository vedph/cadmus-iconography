@echo off
echo PUSH PACKAGES TO NUGET
prompt
set nu=C:\Exe\nuget.exe
set src=-Source https://api.nuget.org/v3/index.json

%nu% push .\Cadmus.Iconography.Parts\bin\Debug\*.nupkg %src% -SkipDuplicate
%nu% push .\Cadmus.Iconography.Services\bin\Debug\*.nupkg %src% -SkipDuplicate
%nu% push .\Cadmus.Seed.Iconography.Parts\bin\Debug\*.nupkg %src% -SkipDuplicate
echo COMPLETED
pause
echo on
