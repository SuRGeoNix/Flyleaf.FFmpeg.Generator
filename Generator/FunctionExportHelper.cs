using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Flyleaf.FFmpeg.Generator;

internal static class FunctionExportHelper
{
    public static IEnumerable<FunctionExport> LoadFunctionExports(string path)
    {
        var libraries = Directory.EnumerateFiles(path, "*.dll");

        foreach (var libraryPath in libraries)
        {
            var libraryFullName = Path.GetFileNameWithoutExtension(libraryPath);
            var libraryNameParts = libraryFullName.Split('-');
            string? libraryName = null;
            int libraryVersion = 0;

            switch (libraryNameParts.Length)
            {
                // if 3 parts, the library is suffixed (see ffmpeg configure)
                case 3:
                    libraryName = $"{libraryNameParts[0]}-{libraryNameParts[1]}";
                    libraryVersion = int.Parse(libraryNameParts[2]);
                    break;
                // no suffix (normal naming pattern)
                case 2:
                    libraryName = libraryNameParts[0];
                    libraryVersion = int.Parse(libraryNameParts[1]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(libraryNameParts.Length));
            }

            var exports = GetExports(libraryPath);
            foreach (var export in exports) yield return new FunctionExport(export, libraryName, libraryVersion);
        }
    }

    private static IEnumerable<string> GetExports(string library)
    {
        var hCurrentProcess = Process.GetCurrentProcess().Handle;

        if (!SymInitialize(hCurrentProcess, null, false)) throw new Exception("SymInitialize failed.");

        try
        {
            var baseOfDll = SymLoadModuleEx(hCurrentProcess, IntPtr.Zero, library, null, 0, 0, IntPtr.Zero, 0);
            if (baseOfDll == 0) throw new Exception($"SymLoadModuleEx failed for {library}.");

            var exports = new List<string>();

            bool EnumSyms(string name, ulong address, uint size, IntPtr context)
            {
                exports.Add(name);
                return true;
            }

            if (!SymEnumerateSymbols64(hCurrentProcess, baseOfDll, EnumSyms, IntPtr.Zero)) throw new Exception("SymEnumerateSymbols64 failed.");

            return exports;
        }
        finally
        {
            SymCleanup(hCurrentProcess);
        }
    }

    [DllImport("dbghelp", SetLastError = true, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SymInitialize(IntPtr hProcess, string? userSearchPath, [MarshalAs(UnmanagedType.Bool)] bool fInvadeProcess);

    [DllImport("dbghelp", SetLastError = true, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SymCleanup(IntPtr hProcess);

    [DllImport("dbghelp", SetLastError = true, CharSet = CharSet.Unicode)]
    private static extern ulong SymLoadModuleEx(IntPtr hProcess, IntPtr hFile, string imageName, string? moduleName, long baseOfDll, int dllSize, IntPtr data, int flags);

    [DllImport("dbghelp", SetLastError = true, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SymEnumerateSymbols64(IntPtr hProcess, ulong baseOfDll, SymEnumerateSymbolsProc64 enumSymbolsCallback, IntPtr userContext);

    private delegate bool SymEnumerateSymbolsProc64(string symbolName, ulong symbolAddress, uint symbolSize, IntPtr userContext);
}