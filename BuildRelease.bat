@echo off
setlocal
cd /d "%~dp0"

set "DIST_DIR=%~dp0dist\LoanManagerApp"
set "ZIP_PATH=%~dp0dist\LoanManagerApp_x64.zip"

if exist "%~dp0dist" rmdir /s /q "%~dp0dist"
mkdir "%DIST_DIR%"

where dotnet >nul 2>nul
if errorlevel 1 (
    echo [ERROR] dotnet SDK が見つかりません。
    echo Visual Studio 2022 または .NET SDK をインストールし、Developer Command Prompt から実行してください。
    pause
    exit /b 1
)

echo NuGet パッケージを復元しています...
dotnet restore "%~dp0LoanManagerApp.sln"
if errorlevel 1 goto :error

echo Release / x64 をビルドしています...
dotnet publish "%~dp0LoanManagerApp\LoanManagerApp.csproj" ^
    -c Release ^
    -p:Platform=x64 ^
    -o "%DIST_DIR%"
if errorlevel 1 goto :error

rem 実行時データ保存先。アプリ側でも存在しない場合は自動作成する。
if not exist "%DIST_DIR%\Config" mkdir "%DIST_DIR%\Config"
if not exist "%DIST_DIR%\Data" mkdir "%DIST_DIR%\Data"
if not exist "%DIST_DIR%\Logs" mkdir "%DIST_DIR%\Logs"

if exist "%ZIP_PATH%" del /q "%ZIP_PATH%"
powershell -NoProfile -ExecutionPolicy Bypass -Command ^
    "Compress-Archive -Path '%DIST_DIR%\*' -DestinationPath '%ZIP_PATH%' -Force"
if errorlevel 1 goto :error

echo.
echo ビルドが完了しました。
echo 配布フォルダ: %DIST_DIR%
echo ZIP: %ZIP_PATH%
pause
exit /b 0

:error
echo.
echo [ERROR] ビルドに失敗しました。
pause
exit /b 1
