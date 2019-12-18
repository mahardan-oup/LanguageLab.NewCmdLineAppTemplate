@echo off
if defined DOTNET_HOST_PATH (
    set HOST_PATH=%DOTNET_HOST_PATH%
) else (
    set HOST_PATH=dotnet
)
"%HOST_PATH%" "%~dp0\src\LanguageLab.NewCmdLineAppTemplate\bin\Debug\netcoreapp3.1\LanguageLab.NewCmdLineAppTemplate.dll" %*