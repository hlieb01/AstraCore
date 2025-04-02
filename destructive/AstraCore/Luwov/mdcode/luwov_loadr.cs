using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

public class LuwovLoader
{
    private static string MODS_FOLDER = "luwov/mdcode";
    private static string LOG_FILE = "datacoreex_18p3c/operation_Log.log";
    private static List<Assembly> loadedMods = new List<Assembly>();

    public static void LoadMods()
    {
        Log("LuwovLoader: Запуск загрузки модов...");
        if (!Directory.Exists(MODS_FOLDER))
        {
            Log("Ошибка: Папка с модами не найдена!");
            return;
        }

        foreach (string modFile in Directory.GetFiles(MODS_FOLDER, "*.dll"))
        {
            try
            {
                Assembly modAssembly = Assembly.LoadFile(Path.GetFullPath(modFile));
                loadedMods.Add(modAssembly);
                Log($"Мод {Path.GetFileName(modFile)} загружен.");
                
                Type entryType = modAssembly.GetType("ModEntryPoint");
                MethodInfo startMethod = entryType?.GetMethod("Start");
                
                if (startMethod != null)
                {
                    startMethod.Invoke(null, null);
                    Log($"Мод {Path.GetFileName(modFile)} запущен.");
                }
                else
                {
                    Log($"Ошибка: Метод Start() не найден в {Path.GetFileName(modFile)}.");
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка загрузки {Path.GetFileName(modFile)}: {ex.Message}");
            }
        }
    }

    public static void UnloadMods()
    {
        Log("LuwovLoader: Выгрузка всех модов...");
        loadedMods.Clear();
        Log("Все загруженные моды выгружены.");
    }

    private static void Log(string message)
    {
        string logEntry = $"[{DateTime.Now}] {message}\n";
        File.AppendAllText(LOG_FILE, logEntry);
        Console.WriteLine(message);
    }
}

// Файл: luwov/mdcode/luwov_loadr.cs
