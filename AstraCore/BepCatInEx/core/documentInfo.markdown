.assembly _
{
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = (
        01 00 08 00 00 00 00 00
    )
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = (
        01 00 01 00 54 02 16 57 72 61 70 4e 6f 6e 45 78
        63 65 70 74 69 6f 6e 54 68 72 6f 77 73 01
    )
    .custom instance void [System.Runtime]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [System.Runtime]System.Diagnostics.DebuggableAttribute/DebuggingModes) = (
        01 00 07 01 00 00 00 00
    )
    .permissionset reqmin = (
        2e 01 80 8a 53 79 73 74 65 6d 2e 53 65 63 75 72
        69 74 79 2e 50 65 72 6d 69 73 73 69 6f 6e 73 2e
        53 65 63 75 72 69 74 79 50 65 72 6d 69 73 73 69
        6f 6e 41 74 74 72 69 62 75 74 65 2c 20 53 79 73
        74 65 6d 2e 52 75 6e 74 69 6d 65 2c 20 56 65 72
        73 69 6f 6e 3d 39 2e 30 2e 30 2e 30 2c 20 43 75
        6c 74 75 72 65 3d 6e 65 75 74 72 61 6c 2c 20 50
        75 62 6c 69 63 4b 65 79 54 6f 6b 65 6e 3d 62 30
        33 66 35 66 37 66 31 31 64 35 30 61 33 61 15 01
        54 02 10 53 6b 69 70 56 65 72 69 66 69 63 61 74
        69 6f 6e 01
    )
    .hash algorithm 0x00008004 // SHA1
    .ver 0:0:0:0
}

.class private auto ansi '<Module>'
{
} // end of class <Module>

.class private auto ansi beforefieldinit Program
    extends [System.Runtime]System.Object
{
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableContextAttribute::.ctor(uint8) = (
        01 00 01 00 00
    )
    .custom instance void [System.Runtime]System.Runtime.CompilerServices.NullableAttribute::.ctor(uint8) = (
        01 00 00 00 00
    )
    // Fields
    .field private static string LOG_FILE
    .field private static string MOD_DLL

    // Methods
    .method private hidebysig static 
        void Main () cil managed 
    {
        // Method begins at RVA 0x2050
        // Code size 177 (0xb1)
        .maxstack 3
        .locals init (
            [0] bool,
            [1] class [System.Runtime]System.Reflection.Assembly modAssembly,
            [2] class [System.Runtime]System.Type modType,
            [3] class [System.Runtime]System.Reflection.MethodInfo startMethod,
            [4] bool,
            [5] class [System.Runtime]System.Exception ex
        )

        IL_0000: nop
        IL_0001: ldstr "AstraCore запускается..."
        IL_0006: call void Program::Log(string)
        IL_000b: nop
        IL_000c: ldsfld string Program::MOD_DLL
        IL_0011: call bool [System.Runtime]System.IO.File::Exists(string)
        IL_0016: ldc.i4.0
        IL_0017: ceq
        IL_0019: stloc.0
        // sequence point: hidden
        IL_001a: ldloc.0
        IL_001b: brfalse.s IL_002e

        IL_001d: nop
        IL_001e: ldstr "Ошибка: mod.dll не найден!"
        IL_0023: call void Program::Log(string)
        IL_0028: nop
        IL_0029: br IL_00b0

        // sequence point: hidden
        IL_002e: nop
        .try
        {
            IL_002f: nop
            IL_0030: ldsfld string Program::MOD_DLL
            IL_0035: call string [System.Runtime]System.IO.Path::GetFullPath(string)
            IL_003a: call class [System.Runtime]System.Reflection.Assembly [System.Runtime]System.Reflection.Assembly::LoadFile(string)
            IL_003f: stloc.1
            IL_0040: ldloc.1
            IL_0041: ldstr "ModEntryPoint"
            IL_0046: callvirt instance class [System.Runtime]System.Type [System.Runtime]System.Reflection.Assembly::GetType(string)
            IL_004b: stloc.2
            IL_004c: ldloc.2
            IL_004d: brtrue.s IL_0052

            IL_004f: ldnull
            IL_0050: br.s IL_005d

            IL_0052: ldloc.2
            IL_0053: ldstr "Start"
            IL_0058: call instance class [System.Runtime]System.Reflection.MethodInfo [System.Runtime]System.Type::GetMethod(string)

            IL_005d: stloc.3
            IL_005e: ldloc.3
            IL_005f: ldnull
            IL_0060: call bool [System.Runtime]System.Reflection.MethodInfo::op_Inequality(class [System.Runtime]System.Reflection.MethodInfo, class [System.Runtime]System.Reflection.MethodInfo)
            IL_0065: stloc.s 4
            // sequence point: hidden
            IL_0067: ldloc.s 4
            IL_0069: brfalse.s IL_0083

            IL_006b: nop
            IL_006c: ldloc.3
            IL_006d: ldnull
            IL_006e: ldnull
            IL_006f: callvirt instance object [System.Runtime]System.Reflection.MethodBase::Invoke(object, object[])
            IL_0074: pop
            IL_0075: ldstr "mod.dll успешно загружен и запущен."
            IL_007a: call void Program::Log(string)
            IL_007f: nop
            IL_0080: nop
            // sequence point: hidden
            IL_0081: br.s IL_0090

            IL_0083: nop
            IL_0084: ldstr "Ошибка: Метод Start() в mod.dll не найден."
            IL_0089: call void Program::Log(string)
            IL_008e: nop
            IL_008f: nop

            IL_0090: nop
            IL_0091: leave.s IL_00b0
        } // end .try
        catch [System.Runtime]System.Exception
        {
            IL_0093: stloc.s 5
            IL_0095: nop
            IL_0096: ldstr "Ошибка при загрузке mod.dll: "
            IL_009b: ldloc.s 5
            IL_009d: callvirt instance string [System.Runtime]System.Exception::get_Message()
            IL_00a2: call string [System.Runtime]System.String::Concat(string, string)
            IL_00a7: call void Program::Log(string)
            IL_00ac: nop
            IL_00ad: nop
            IL_00ae: leave.s IL_00b0
        } // end handler

        IL_00b0: ret
    } // end of method Program::Main

    .method private hidebysig static 
        void Log (
            string message
        ) cil managed 
    {
        // Method begins at RVA 0x2120
        // Code size 99 (0x63)
        .maxstack 3
        .locals init (
            [0] string logEntry,
            [1] valuetype [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler
        )

        IL_0000: nop
        IL_0001: ldloca.s 1
        IL_0003: ldc.i4.4
        IL_0004: ldc.i4.2
        IL_0005: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::.ctor(int32, int32)
        IL_000a: ldloca.s 1
        IL_000c: ldstr "["
        IL_0011: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral(string)
        IL_0016: nop
        IL_0017: ldloca.s 1
        IL_0019: call valuetype [System.Runtime]System.DateTime [System.Runtime]System.DateTime::get_Now()
        IL_001e: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted<valuetype [System.Runtime]System.DateTime>(!!0)
        IL_0023: nop
        IL_0024: ldloca.s 1
        IL_0026: ldstr "] "
        IL_002b: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral(string)
        IL_0030: nop
        IL_0031: ldloca.s 1
        IL_0033: ldarg.0
        IL_0034: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendFormatted(string)
        IL_0039: nop
        IL_003a: ldloca.s 1
        IL_003c: ldstr "\n"
        IL_0041: call instance void [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::AppendLiteral(string)
        IL_0046: nop
        IL_0047: ldloca.s 1
        IL_0049: call instance string [System.Runtime]System.Runtime.CompilerServices.DefaultInterpolatedStringHandler::ToStringAndClear()
        IL_004e: stloc.0
        IL_004f: ldsfld string Program::LOG_FILE
        IL_0054: ldloc.0
        IL_0055: call void [System.Runtime]System.IO.File::AppendAllText(string, string)
        IL_005a: nop
        IL_005b: ldarg.0
        IL_005c: call void [System.Console]System.Console::WriteLine(string)
        IL_0061: nop
        IL_0062: ret
    } // end of method Program::Log

    .method public hidebysig specialname rtspecialname 
        instance void .ctor () cil managed 
    {
        // Method begins at RVA 0x218f
        // Code size 8 (0x8)
        .maxstack 8

        IL_0000: ldarg.0
        IL_0001: call instance void [System.Runtime]System.Object::.ctor()
        IL_0006: nop
        IL_0007: ret
    } // end of method Program::.ctor

    .method private hidebysig specialname rtspecialname static 
        void .cctor () cil managed 
    {
        // Method begins at RVA 0x2198
        // Code size 21 (0x15)
        .maxstack 8

        IL_0000: ldstr "datacoreex_18p3c/operation_Log.log"
        IL_0005: stsfld string Program::LOG_FILE
        IL_000a: ldstr "BepCatInEx/core/mod.dll"
        IL_000f: stsfld string Program::MOD_DLL
        IL_0014: ret
    } // end of method Program::.cctor

} // end of class Program

