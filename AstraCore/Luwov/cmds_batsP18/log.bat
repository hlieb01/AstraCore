:: log.bat - Очистка логов вручную
@echo off
echo Очистка логов...
del /Q datacoreex_18p3c\operation_Log.log
echo Логи очищены!
echo Новый файл логов создан. > datacoreex_18p3c\operation_Log.log
exit
