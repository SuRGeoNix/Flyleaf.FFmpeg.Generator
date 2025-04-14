using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CppSharp;
using CppSharp.AST;
using CppSharp.Parser;
using Flyleaf.FFmpeg.Generator.Definitions;
using Flyleaf.FFmpeg.Generator.Processors;
using ClangParser = CppSharp.ClangParser;

#nullable disable

namespace Flyleaf.FFmpeg.Generator;

internal class Generator
{
    private readonly ASTProcessor _astProcessor;
    private bool _hasParsingErrors;

    public Generator(ASTProcessor astProcessor) => _astProcessor = astProcessor;

    public string[] Defines { get; init; } = Array.Empty<string>();
    public string[] IncludeDirs { get; init; } = Array.Empty<string>();
    public FunctionExport[] Exports { get; init; }

    public string Namespace { get; init; }
    public string ClassName { get; init; }

    public bool SuppressUnmanagedCodeSecurity { get; init; }

    public InlineFunctionDefinition[] ExistingInlineFunctions { get; init; }

    public void Parse(string[] sourceFiles)
    {
        _hasParsingErrors = false;
        ASTContext context = MetricHelper.RecordTime("Parse header files", () => ParseInternal(sourceFiles));
        if (_hasParsingErrors)
            throw new InvalidOperationException();

        // Excludes units coming from system headers (eg. d3d11.h)
        for (int i = 0; i < context.TranslationUnits.Count; i++)
            if (context.TranslationUnits[i].IsSystemHeader)
                context.TranslationUnits[i].Ignore = true;

        Process(context);
    }


    //public void WriteLibraries(string combine)
    //{
    //    WriteInternal(combine,
    //        (units, writer) =>
    //        {
    //            writer.WriteLine("using System.Collections.Generic;");
    //            writer.WriteLine();

    //            writer.WriteLine($"public unsafe static partial class {ClassName}");

    //            using (writer.BeginBlock())
    //            {
    //                writer.WriteLine(
    //                    "public static Dictionary<string, int> LibraryVersionMap =  new ()");

    //                using (writer.BeginBlock(true))
    //                {
    //                    var libraryVersionMap = Exports.Select(x => new { x.LibraryName, x.LibraryVersion })
    //                        .Distinct()
    //                        .ToDictionary(x => x.LibraryName, x => x.LibraryVersion);
    //                    foreach (var pair in libraryVersionMap)
    //                        writer.WriteLine($"[\"{pair.Key}\"] = {pair.Value},");
    //                }

    //                writer.WriteLine(";");
    //            }
    //        });
    //}

    public void WriteEnums(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                units.OfType<EnumerationDefinition>()
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x =>
                    {
                        writer.WriteEnumeration(x);
                        writer.WriteLine();
                    });
            });
    }

    public void WriteDelegates(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                units.OfType<DelegateDefinition>().ForEach((x, i) =>
                {
                    writer.WriteDelegate(x);
                    if (!i.IsLast) writer.WriteLine();
                });
            });
    }

    public void WriteMacros(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                writer.WriteLine($"public unsafe static partial class {ClassName}");
                using (writer.BeginBlock())
                {
                    units.OfType<MacroDefinitionBase>()
                        .OrderBy(x => x.Name)
                        .ForEach((macro, i) =>
                        {
                            writer.WriteMacro(macro);
                        });
                }   
            });
    }

    public void WriteExportFunctions(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                writer.WriteLine($"public unsafe static partial class {ClassName}");
                using var _ = writer.BeginBlock();
                //writer.WriteLine("private const string PlatformNotSupportedMessageFormat = \"{0} is not supported on this platform.\";");
                writer.WriteLine();
                units.OfType<ExportFunctionDefinition>()
                    .OrderBy(x => x.LibraryName)
                    .ThenBy(x => x.Name)
                    .ForEach((x, i) =>
                    {
                        writer.WriteFunction(x);
                        if (!i.IsLast) writer.WriteLine();
                    });
            });
    }

    public void WriteInlineFunctions(string outputFile)
    {
        var existingInlineFunctionMap = ExistingInlineFunctions
            .GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, v => v.First());
        WriteInternal(outputFile,
            (units, writer) =>
            {
                writer.WriteLine($"public unsafe static partial class {ClassName}");
                using (writer.BeginBlock())
                    units.OfType<InlineFunctionDefinition>()
                        //.Where(x => x.Name != "av_image_copy2") // TODO: currently not supports same function name (diff params) and same body
                        .OrderBy(x => x.Name)
                        .Select(RewriteFunctionBody)
                        .ToList()
                        .ForEach(x =>
                        {
                            writer.WriteFunction(x);
                            writer.WriteLine();
                        });
            });

        InlineFunctionDefinition RewriteFunctionBody(InlineFunctionDefinition function)
        {
            if (existingInlineFunctionMap.TryGetValue(function.Name, out var existing) && function.OriginalBodyHash == existing.OriginalBodyHash)
            {
                if (function.Name == "av_frame_side_data_get" && function.Parameters[0].Type.ByReference)
                    function.Body = existing.Body.Replace("(sd", "(ref sd"); // ExistingInlineFunctions dictionary holds only first existing body for functions with the same name
                else
                    function.Body = existing.Body;
            }

            return function;
        }
    }

    public void WriteArrays(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                units.OfType<FixedArrayDefinition>()
                    .OrderBy(x => x.Size)
                    .ThenBy(x => x.Name)
                    .ToList().ForEach(x =>
                    {
                        writer.WriteFixedArray(x);
                        writer.WriteLine();
                    });
            });
    }

    public void WriteStructures(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                units.OfType<StructureDefinition>()
                    .Where(x => x.IsComplete && x.Name != "AVRational")// && !RawStructureTransformDef.IgnoredStructures.Contains(x.Name))
                    .OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(x =>
                    {
                        writer.WriteStructure(x);
                        writer.WriteLine();
                    });
            });
    }

    public void WriteIncompleteStructures(string outputFile)
    {
        WriteInternal(outputFile,
            (units, writer) =>
            {
                units.OfType<StructureDefinition>()
                    .Where(x => !x.IsComplete && x.Name != "AVCodecTag")
                    .ToList()
                    .ForEach(x =>
                    {
                        writer.WriteStructure(x);
                        writer.WriteLine();
                    });
            });
    }

    private ASTContext ParseInternal(string[] sourceFiles)
    {
        var parserOptions = new ParserOptions
        {
            Verbose         = false,
            ASTContext      = new CppSharp.Parser.AST.ASTContext(),
            LanguageVersion = LanguageVersion.C99_GNU
        };

        parserOptions.SetupMSVC(VisualStudioVersion.VS2022);

        foreach (var includeDir in IncludeDirs) parserOptions.AddIncludeDirs(includeDir);

        foreach (var define in Defines) parserOptions.AddDefines(define);
        var result = ClangParser.ParseSourceFiles(sourceFiles, parserOptions);
        OnSourceFileParsed(sourceFiles, result);
        return ClangParser.ConvertASTContext(parserOptions.ASTContext);
    }

    private void OnSourceFileParsed(IEnumerable<string> files, ParserResult result)
    {
        switch (result.Kind)
        {
            case ParserResultKind.Success:
                Diagnostics.Message($"Parsed {files.Count()} headers.");
                break;
            case ParserResultKind.Error:
                Diagnostics.Error("Error parsing '{0}'", string.Join(", ", files));
                _hasParsingErrors = true;
                break;
            case ParserResultKind.FileNotFound:
                Diagnostics.Error("A file from '{0}' was not found", string.Join(",", files));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        for (uint i = 0; i < result.DiagnosticsCount; ++i)
        {
            var diagnostics = result.GetDiagnostics(i);

            var message =
                $"{diagnostics.FileName}({diagnostics.LineNumber},{diagnostics.ColumnNumber}): {diagnostics.Level.ToString().ToLower()}: {diagnostics.Message}";
            Diagnostics.Message(message);
        }
    }

    private void Process(ASTContext context) =>
        _astProcessor.Process(context.TranslationUnits.Where(x => !x.IsSystemHeader));

    private void WriteInternal(string outputFile, Action<IReadOnlyList<IDefinition>, Writer> execute)
    {
        using var streamWriter = File.CreateText(outputFile);
        using var textWriter = new IndentedTextWriter(streamWriter);
        var writer = new Writer(textWriter);
        writer.WriteLine($"namespace {Namespace};");
        writer.WriteLine();
        execute(_astProcessor.Units, writer);
    }
}