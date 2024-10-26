using System;
using System.IO;
using System.Linq;

using Flyleaf.FFmpeg.Generator.Processors;

namespace Flyleaf.FFmpeg.Generator;

internal static class Program
{
    /* TODO
     * Re-coding and clean up
     * Don't marshal all strings by default (eg. av log overhead with format that we might not be used)
     * PixelFormat enum (big/little endian)
     * Any reason to use LibraryImport instead (possible check vectors too)?
     * BUG: av_image_fill_pointers passes ptr array without ref, others?
     * AVDXVA2FramesContext surface_type (DWORD) wrongly set to ulong instead of int (seems to work with both?)
     * Function parameters arrays (dllimport will use default marshalling eg. byte*[] or int[] don't require special treatment)
     * Needs a way to separate
         AVCodecTag**                        a pointer to AVCodecTag pointers
         const struct AVCodecTag *const *    a pointer to unfixed size AVCodecTag array

     * Requires project to allow unsafe code
	 * Required global (from the project that will use the generated code)
        global using System.Runtime.InteropServices;
        global using System.Security;
        global using static System.Runtime.InteropServices.Marshal;
        global using static Flyleaf.FFmpeg.Raw; // {namespace}.{class}
     */

    public static CliOptions Options { get; private set; } = null!;

    internal static void Main(string[] args)
    {
        Console.WriteLine($"App started using args: {string.Join(",", args)}");

        Options = CliOptions.ParseArgumentsStrict(args);

        //Options.OutputDir = @"C:\root\projects\ClassLibrary1\Raw";
        //Options.UsingObsoleteFunctions = true;

        Options.Normalize();

        Console.WriteLine($"Working dir:        {Environment.CurrentDirectory}");
        Console.WriteLine($"Output dir:         {Options.OutputDir}");
        Console.WriteLine($"FFmpeg headers dir: {Options.FFmpegIncludesDir}");
        Console.WriteLine($"FFmpeg bin dir:     {Options.FFmpegBinDir}");
        Console.WriteLine($"Namespace name:     {Options.Namespace}");
        Console.WriteLine($"Class name:         {Options.ClassName}");
        
        var existingInlineFunctions2 =
            MetricHelper.RecordTime("Loading inline functions", () => ExistingInlineFunctionsHelper.LoadInlineFunctions(Path.Combine(Options.OutputDir,
                "FFmpeg.functions.inline.cs")));

        FunctionExport[] exports = MetricHelper.RecordTime("Loading functions", () => FunctionExportHelper.LoadFunctionExports(Options.FFmpegBinDir).ToArray());

        ASTProcessor astProcessor = new (exports
                .GroupBy(x => x.Name).Select(x => x.First()) // Eliminate duplicated names
                .ToDictionary(x => x.Name));
        astProcessor.IgnoreUnitNames.Add("__NSConstantString_tag");

        var defines = new[] { "__STDC_CONSTANT_MACROS" };

        var g = new Generator(astProcessor)
        {
            IncludeDirs                     = [Options.FFmpegIncludesDir],
            Defines                         = defines,
            Exports                         = exports,
            Namespace                       = Options.Namespace,
            ClassName                       = Options.ClassName,
            ExistingInlineFunctions         = existingInlineFunctions2
        };

        g.Parse(
            "libavutil/avutil.h",
            "libavutil/audio_fifo.h",
            "libavutil/channel_layout.h",
            "libavutil/cpu.h",
            "libavutil/display.h",
            "libavutil/file.h",
            "libavutil/frame.h",
            "libavutil/opt.h",
            "libavutil/imgutils.h",
            "libavutil/time.h",
            "libavutil/timecode.h",
            "libavutil/tree.h",
            "libavutil/hwcontext.h",
            "libavutil/hwcontext_dxva2.h",
            "libavutil/hwcontext_d3d11va.h",
            "libavutil/hwcontext_d3d12va.h",
            "libavutil/hwcontext_opencl.h", // TBR: requires Cl/cl.h (AVOpenCL* structs probably faulty)
            "libavutil/hwcontext_cuda.h",
            "libavutil/hwcontext_vulkan.h",
            "libavutil/hdr_dynamic_metadata.h",
            "libavutil/mastering_display_metadata.h",

            "libswresample/swresample.h",

            "libpostproc/postprocess.h",

            "libswscale/swscale.h",

            "libavcodec/avcodec.h",
            "libavcodec/bsf.h",
            //"libavcodec/dxva2.h",
            //"libavcodec/d3d11va.h",

            "libavformat/avformat.h",

            "libavfilter/avfilter.h",
            "libavfilter/buffersrc.h",
            "libavfilter/buffersink.h",

            "libavdevice/avdevice.h");

        g.WriteMacros(              Path.Combine(Options.OutputDir, "FFmpeg.macros.g.cs"));
        g.WriteEnums(               Path.Combine(Options.OutputDir, "FFmpeg.enums.g.cs"));
        g.WriteDelegates(           Path.Combine(Options.OutputDir, "FFmpeg.delegates.g.cs"));
        g.WriteArrays(              Path.Combine(Options.OutputDir, "FFmpeg.arrays.g.cs"));
        g.WriteStructures(          Path.Combine(Options.OutputDir, "FFmpeg.structs.g.cs"));
        g.WriteIncompleteStructures(Path.Combine(Options.OutputDir, "FFmpeg.structs.incomplete.g.cs"));
        g.WriteExportFunctions(     Path.Combine(Options.OutputDir, "FFmpeg.functions.export.g.cs"));
        g.WriteInlineFunctions(     Path.Combine(Options.OutputDir, "FFmpeg.functions.inline.cs"));
    }
}
