using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ModDisabler
{
    private static string MODS_FOLDER = "BepCatInEx/plugins/";
    private static string SPC_MODS_FOLDER = "Bep_core/paths/spc_mods2/";
    private static string DISABLED_MODS_FOLDER = "datacoreex_18p3c/geflop_xp80/mods/";
    private static string DISABLED_SPC_FOLDER = "datacoreex_18p3c/geflop_xp80/spc_plugins/";
    private static string MOD_LIST_FILE = "datacoreex_18p3c/geflop_xp80/mod_list.json";
    private static string LOG_FILE = "datacoreex_18p3c/operation_Log.log";

    public static void CheckAndDisableMods()
    {
        if (!File.Exists(MOD_LIST_FILE))
        {
            Console.WriteLine("Файл со списком актуальных модов не найден.");
            return;
        }

        Dictionary<string, string> actualMods = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(MOD_LIST_FILE));

        Directory.CreateDirectory(DISABLED_MODS_FOLDER);
        Directory.CreateDirectory(DISABLED_SPC_FOLDER);

        CheckFolder(MODS_FOLDER, DISABLED_MODS_FOLDER, actualMods);
        CheckFolder(SPC_MODS_FOLDER, DISABLED_SPC_FOLDER, actualMods);
    }

    private static void CheckFolder(string sourceFolder, string targetFolder, Dictionary<string, string> actualMods)
    {
        if (!Directory.Exists(sourceFolder)) return;

        foreach (string modFile in Directory.GetFiles(sourceFolder, "*.dll"))
        {
            string modName = Path.GetFileNameWithoutExtension(modFile);
            string modVersion = "1.0.0"; // Здесь можно дописать код для чтения версии

            if (!actualMods.ContainsKey(modName) || modVersion != actualMods[modName])
            {
                string disabledPath = Path.Combine(targetFolder, Path.GetFileName(modFile));
                File.Move(modFile, disabledPath);

                File.AppendAllText(LOG_FILE, $"[{DateTime.Now}] Отключен мод: {modName} (версия {modVersion})\n");
                Console.WriteLine($"Мод {modName} перемещён в {targetFolder}");
            }
        }
    }
}
