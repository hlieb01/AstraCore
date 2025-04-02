using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue | DebuggableAttribute.DebuggingModes.DisableOptimizations)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]

[NullableContext(1)]
[Nullable(0)]
internal class Program
{
    private static string LOG_FILE = "datacoreex_18p3c/operation_Log.log";

    private static string MOD_DLL = "BepCatInEx/core/mod.dll";

    private static void Main()
    {
        Log("AstraCore запускается...");
        if (!File.Exists(MOD_DLL))
        {
            Log("Ошибка: mod.dll не найден!");
            return;
        }
        try
        {
            Assembly assembly = Assembly.LoadFile(Path.GetFullPath(MOD_DLL));
            Type type = assembly.GetType("ModEntryPoint");
            MethodInfo methodInfo = (((object)type != null) ? type.GetMethod("Start") : null);
            if (methodInfo != null)
            {
                methodInfo.Invoke(null, null);
                Log("mod.dll успешно загружен и запущен.");
            }
            else
            {
                Log("Ошибка: Метод Start() в mod.dll не найден.");
            }
        }
        catch (Exception ex)
        {
            Log(string.Concat("Ошибка при загрузке mod.dll: ", ex.Message));
        }
    }

    private static void Log(string message)
    {
        DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        defaultInterpolatedStringHandler.AppendLiteral("[");
        defaultInterpolatedStringHandler.AppendFormatted(DateTime.Now);
        defaultInterpolatedStringHandler.AppendLiteral("] ");
        defaultInterpolatedStringHandler.AppendFormatted(message);
        defaultInterpolatedStringHandler.AppendLiteral("\n");
        string contents = defaultInterpolatedStringHandler.ToStringAndClear();
        File.AppendAllText(LOG_FILE, contents);
        Console.WriteLine(message);
    }
}
