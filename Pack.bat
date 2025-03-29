@echo off
echo BUILD Cadmus Iconography Packages
del .\Cadmus.Iconography.Parts\bin\Debug\*.*nupkg
del .\Cadmus.Seed.Iconography.Parts\bin\Debug\*.*nupkg
del .\Cadmus.Iconography.Services\bin\Debug\*.*nupkg

cd .\Cadmus.Iconography.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.Iconography.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Iconography.Services
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
