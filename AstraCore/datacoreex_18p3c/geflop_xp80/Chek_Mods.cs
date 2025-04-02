using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ModDisabler
{
    private static string MODS_FOLDER = "BepInEx/plugins/";
    private static string DISABLED_FOLDER = "datacoreex_18p3c/geflop_xp80/mods/";
    private static string MOD_LIST_FILE = "datacoreex_18p3c/geflop_xp80/mod_list.json";
    private static string MODS_FOLDER = "BepCatInEx/plugins/"; // Вместо BepInEx
    private static string LOG_FILE = "datacoreex_18p3c/operation_Log.log";



    public static void CheckAndDisableMods()
    {
        if (!File.Exists(MOD_LIST_FILE))
        {
            Console.WriteLine("Файл со списком актуальных модов не найден.");
            return;
        }

        // Загружаем список актуальных версий модов
        Dictionary<string, string> actualMods = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(MOD_LIST_FILE));

        if (!Directory.Exists(MODS_FOLDER)) return;
        Directory.CreateDirectory(DISABLED_FOLDER);

        foreach (string modFile in Directory.GetFiles(MODS_FOLDER, "*.dll"))
        {
            string modName = Path.GetFileNameWithoutExtension(modFile);
            string modVersion = "1.0.0"; // Тут можно дописать код, который читает версию из мода

            if (!actualMods.ContainsKey(modName) || modVersion != actualMods[modName])
            {
                string disabledPath = Path.Combine(DISABLED_FOLDER, Path.GetFileName(modFile));
                File.Move(modFile, disabledPath);

                File.AppendAllText(LOG_FILE, $"Отключен мод: {modName} (версия {modVersion})\n");
                Console.WriteLine($"Мод {modName} отключен!");
            }
        }
    }
}
