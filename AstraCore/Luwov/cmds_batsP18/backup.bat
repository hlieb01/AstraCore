:: backup.bat - Создание резервных копий
@echo off
set GAME_NAME=plantsvszombiesrh.exe
set SAVE_PATH=user_p18\save_data.txt
set LOG_FILE=datacoreex_18p3c\operation_Log.log
set BACKUP_DIR=user_p18
set BACKUP_PREFIX=user_Bak
set /a COUNT=1

if not exist %LOG_FILE% (
    echo Файл логов отсутствует. Создаю новый... > %LOG_FILE%
)

for %%F in (%BACKUP_DIR%\%BACKUP_PREFIX%*.dat) do (
    set /a COUNT+=1
)
set BACKUP_FILE=%BACKUP_DIR%\%BACKUP_PREFIX%%COUNT%.dat

tasklist | find /i "%GAME_NAME%" > nul
if %errorlevel%==0 (
    echo Игра запущена, создаю сохранение...
    echo Сохранение создано в %DATE% %TIME% > %SAVE_PATH%
    echo %DATE% %TIME% > %BACKUP_FILE%
) else (
    echo Игра не запущена. Запуск проверки на краш...
    call reserve.bat
)
exit
