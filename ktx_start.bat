@echo  off
if not exist  "%ProgramFiles%\dotnet\dotnet.exe" (echo 请先安装.NET 7.0：https://dot.net 
pause
start  https://dot.net 
pause
)
@echo  on

dotnet ktx.dll
pause

