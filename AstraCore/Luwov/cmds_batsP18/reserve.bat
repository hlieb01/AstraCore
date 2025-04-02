:: reserve.bat - Восстанавливает последний бэкап после краша
@echo off
echo Восстановление последнего сохранения...
set BACKUP_DIR=user_p18
set BACKUP_PREFIX=user_Bak
set LOG_FILE=datacoreex_18p3c\operation_Log.log

if not exist "%LOG_FILE%" (
    echo Лог-файл не найден, создаю новый... > "%LOG_FILE%"
)

for /f "tokens=* delims=" %%F in ('dir /b /o-n %BACKUP_DIR%\%BACKUP_PREFIX%*.dat 2^>nul') do (
    set LATEST_BACKUP=%BACKUP_DIR%\%%F
    goto restore
)
:restore
if exist "%LATEST_BACKUP%" (
    echo Восстанавливаю из %LATEST_BACKUP%...
    copy /Y "%LATEST_BACKUP%" user_p18\save_data.txt > nul
    echo Восстановление завершено!
) else (
    echo Ошибка: нет доступных бэкапов для восстановления!
)
exit
