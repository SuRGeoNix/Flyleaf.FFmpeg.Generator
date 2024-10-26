global using System.Runtime.InteropServices;
global using System.Security;
global using static System.Runtime.InteropServices.Marshal;
global using static Flyleaf.FFmpeg.Raw;

namespace Flyleaf.FFmpeg;

public unsafe static partial class Raw
{
    public static void LoadLibraries(string path, LoadProfile profile = LoadProfile.All, bool validateVersion = true)
    {
        LoadLibrary(path, AVUTIL, validateVersion);
        if (profile != LoadProfile.Main)
            LoadLibrary(path, SWSCALE, validateVersion);
        LoadLibrary(path, SWRESAMPLE, validateVersion);
        if (profile != LoadProfile.Main)
            LoadLibrary(path, POSTPROC, validateVersion);
        LoadLibrary(path, AVCODEC, validateVersion);
        LoadLibrary(path, AVFORMAT, validateVersion);
        if (profile != LoadProfile.Main)
            LoadLibrary(path, AVFILTER, validateVersion);
        if (profile == LoadProfile.All)
            LoadLibrary(path, AVDEVICE, validateVersion);

        NativeLibrary.SetDllImportResolver(typeof(Raw).Assembly, DllImportResolver);

        if (profile == LoadProfile.All)
            avdevice_register_all();
    }

    static void LoadLibrary(string path, string name, bool validateVersion = true)
    {
        //                L             W|M
        // eg.  *avutil*(.so*)(51*)(.dll|.dylib) | TBR: issue with version, ver 1 matches with version x1x

        var so      = !OperatingSystem.IsWindows() && !OperatingSystem.IsMacOS() ? ".so*" : "*"; // middle (.so for linux)
        var ver     = validateVersion ? libToVer[name].ToString() + "*" : "*";
        var ext     = OperatingSystem.IsWindows() ? ".dll" : (OperatingSystem.IsMacOS() ? ".dylib" : "");

        var files   = Directory.GetFiles(path, $"*{name}*{so}{ver}{ext}");
        if (files.Length == 0)
            throw new($"Library {name}.{ver} not found");
        
        nint ptr = OperatingSystem.IsWindows() ? LoadLibraryW(files[0]) : (OperatingSystem.IsMacOS() ? dlopenMac(files[0], 0x002) : dlopen(files[0], 0x002));
        if (ptr == 0)
        {
            var errNum = GetLastPInvokeError();
            var errMsg = GetLastPInvokeErrorMessage();
            throw new($"Failed to load {name}.{ver} | {errMsg} (0x{errNum:X8})");

            /*  TODO: possible check machine type matching process architecture
                FileStream fs = new(x, FileMode.Open, FileAccess.Read);
                System.Reflection.PortableExecutable.PEHeaders pe = new(fs);
                pe.CoffHeader.Machine == Environment.Is64BitProcess
            */
        }

        libToPtr[name] = ptr;
    }

    private static IntPtr DllImportResolver(string libraryName, System.Reflection.Assembly assembly, DllImportSearchPath? searchPath)
    {
        libToPtr.TryGetValue(libraryName, out var ptr);
        
        return ptr;
    }

    static Dictionary<string, nint> libToPtr = [];
    static Dictionary<string, uint> libToVer = new()
    {
        [AVCODEC]   = LIBAVCODEC_VERSION_MAJOR,
        [AVDEVICE]  = LIBAVDEVICE_VERSION_MAJOR,
        [AVFILTER]  = LIBAVFILTER_VERSION_MAJOR,
        [AVFORMAT]  = LIBAVFORMAT_VERSION_MAJOR,
        [AVUTIL]    = LIBAVUTIL_VERSION_MAJOR,
        [POSTPROC]  = LIBPOSTPROC_VERSION_MAJOR,
        [SWRESAMPLE]= LIBSWRESAMPLE_VERSION_MAJOR,
        [SWSCALE]   = LIBSWSCALE_VERSION_MAJOR,
    };

    // TBR: Dependencies are not accurate anyways, for now is better to initially-preload (as far we know) the required libraries (possibly allow only filters/devices to manually load later on)
    //static Dictionary<string, string[]> libΤοDependencies = new()
    //{
    //    [AVUTIL]        = [],
    //    [POSTPROC]      = [AVUTIL],
    //    [SWRESAMPLE]    = [AVUTIL],
    //    [SWSCALE]       = [AVUTIL],
    //    [AVCODEC]       = [AVUTIL, SWRESAMPLE],
    //    [AVFORMAT]      = [AVUTIL, SWRESAMPLE, AVCODEC],
    //    [AVFILTER]      = [AVUTIL, SWSCALE, SWRESAMPLE, POSTPROC, AVCODEC, AVFORMAT],
    //    [AVDEVICE]      = [AVUTIL, SWSCALE, SWRESAMPLE, POSTPROC, AVCODEC, AVFORMAT, AVFILTER]
    //};

    public static readonly av_buffer_create_free DefaultBufferFreeDlgt  = new(DefaultBufferFree);
    private static void DefaultBufferFree(void* opaque, byte* data)     => av_free(data); // same as av_buffer_default_free (can be used also to free managed data)

    // windows
    [DllImport("kernel32", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true), SuppressUnmanagedCodeSecurity]
    private static extern IntPtr LoadLibraryW(string dllToLoad);

    // linux
    [LibraryImport("libdl.so.2", StringMarshalling = StringMarshalling.Utf8, SetLastError = true), SuppressUnmanagedCodeSecurity]
    private static partial IntPtr dlopen(string fileName, int flag);

    // Mac
    [LibraryImport("libdl", StringMarshalling = StringMarshalling.Utf8, SetLastError = true), SuppressUnmanagedCodeSecurity]
    private static partial IntPtr dlopenMac(string fileName, int flag);
}

public enum LoadProfile
{
    All,        // filters + avdevice
    Filters,    // main + swscale/postproc/avfilter
    Main,       // avutil/swresample/avcodec/avformat
}

internal class ConstCharPtrMarshaler : ICustomMarshaler
{
    public object MarshalNativeToManaged(IntPtr pNativeData) => PtrToStringUTF8(pNativeData)!;
    public IntPtr MarshalManagedToNative(object managedObj) => throw new NotImplementedException();
    public void CleanUpNativeData(IntPtr pNativeData) { }
    public void CleanUpManagedData(object managedObj) { }
    public int GetNativeDataSize() => IntPtr.Size;
    private static readonly ConstCharPtrMarshaler Instance = new();
    public static ICustomMarshaler GetInstance(string cookie) => Instance;
}