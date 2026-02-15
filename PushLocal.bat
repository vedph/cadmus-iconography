@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
c:\exe\nuget add .\Cadmus.Iconography.Parts\bin\Debug\Cadmus.Iconography.Parts.1.0.2.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.Iconography.Parts\bin\Debug\Cadmus.Seed.Iconography.Parts.1.0.2.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Iconography.Services\bin\Debug\Cadmus.Iconography.Services.1.0.2.nupkg -source C:\Projects\_NuGet
pause
