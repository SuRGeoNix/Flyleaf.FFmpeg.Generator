using System;
using System.Collections.Generic;
using System.Linq;

using Flyleaf.FFmpeg.Generator.Definitions;

namespace Flyleaf.FFmpeg.Generator.Processors;

internal static class MacroEnumPostProcessor
{
    public static (IReadOnlyList<MacroDefinitionBase>, IReadOnlyList<EnumerationDefinition>) Process(IEnumerable<MacroDefinitionBase> macros)
    {
        MacroEnumDef[] knownConstEnums =
        [
            new("AV_BUFFERSINK_FLAG_", "BufferSinkFlags", IsFlags: true),

            new("AV_CH_", "ChannelFlags", IsFlags: true),// Except: HashSet("AV_CH_LAYOUT_NATIVE")), // TBR: re-uses flags as new names*
            new("AV_CODEC_FLAG_", "CodecFlags", IsFlags: true),
            new("AV_CODEC_FLAG2_", "CodecFlags2", IsFlags: true),
            new("AV_CODEC_CAP_", "CodecCapFlags", IsFlags: true),
            new("AV_CODEC_EXPORT_DATA_", "CodecExportDataFlags", IsFlags: true),
            new("AV_CODEC_PROP_", "CodecPropFlags", IsFlags: true),

            new("AV_CPU_FLAG_", "CpuFlags", IsFlags: true),

            new("AV_DICT_", "DictReadFlags", Only: HashSet("AV_DICT_MATCH_CASE", "AV_DICT_IGNORE_SUFFIX"), IsFlags: true),
            new("AV_DICT_", "DictWriteFlags", IsFlags: true),
            new("AV_DISPOSITION_", "DispositionFlags", IsFlags: true),

            new("AV_EF_", "ErrorDetectFlags", IsFlags: true),

            new("AVFILTER_FLAG_", "FilterFlags", IsFlags: true, Except: HashSet("AVFILTER_FLAG_SUPPORT_TIMELINE")), // SupportTimeline = SupportTimelineGeneric | SupportTimelineInternal
            new("AVFILTER_CMD_FLAG_", "FilterCmdFlags", IsFlags: true),
            new("AVFILTER_THREAD_", "FilterThreadFlags", IsFlags: true),
            new("AVFMT_FLAG_", "FmtFlags2", IsFlags: true),
            new("AVFMT_EVENT_FLAG_", "FmtEventFlags", IsFlags: true),
            new("AVFMT_AVOID_NEG_TS_", "AvoidNegTSFlags", IsFlags: true),
            new("AVFMTCTX_", "FmtCtxFlags", IsFlags: true),
            new("AVFMT_", "FmtFlags", IsFlags: true, Except: HashSet("AVFMT_EVENT_FLAG_METADATA_UPDATED")),
            new("AV_FRAME_FLAG_", "FrameFlags", IsFlags: true),
            new("AV_FRAME_SIDE_DATA_FLAG_", "FrameSideDataFlags", IsFlags: true),
            new("FF_THREAD_", "ThreadTypeFlags", IsFlags: true),

            new("AV_HWACCEL_FLAG_", "HWAccelFlags", IsFlags: true),
            new("AV_HWACCEL_CODEC_CAP_", "HWAccelCapFlags", IsFlags: true),
            
            new("AVINDEX_", "IndexFlags", IsFlags: true),

            new("AVIO_FLAG_", "IOFlags", IsFlags: true, Except: HashSet("AVIO_FLAG_READ_WRITE")), // ReadWrite = Read | Write
            new("AVIO_SEEKABLE_", "IOSeekableFlags", IsFlags: true),

            new("AV_LOG_", "LogFlags", Only: HashSet("AV_LOG_SKIP_REPEATED", "AV_LOG_PRINT_LEVEL")),
            new("AV_LOG_", "LogLevel", Except: HashSet("AV_LOG_C")),

            new("AV_OPT_FLAG_", "OptFlags", IsFlags: true),
            new("AV_OPT_SEARCH_", "OptSearchFlags", IsFlags: true),
            new("AV_OPT_SERIALIZE_", "OptSerializeFlags", IsFlags: true),

            new("AV_PKT_FLAG_", "PktFlags", IsFlags: true),
            new("AV_PIX_FMT_FLAG_", "PixFmtFlags", IsFlags: true, TypeHint: "ulong"), // NOTE: AVPixFmtDescriptor (currently!) uses ulong
            
            new("AVSEEK_FLAG_", "SeekFlags", IsFlags: true),
            new("AVSEEK_", "IOSeekFlags", IsFlags: true, AdditionalValues: new(true, // NOTE: SEEK_ not public for whence?
            [
                EnumerationItem.MakeFake("Begin", "SEEK_SET", 0),
                EnumerationItem.MakeFake("Current", "SEEK_CUR", 1),
                EnumerationItem.MakeFake("End", "SEEK_END", 2),
            ])),
            new("AVSTREAM_INIT_IN_", "StreamInitFlags", IsFlags: true),

            new("AVSTREAM_EVENT_FLAG_", "StreamEventFlags", IsFlags: true),

            new("PARSER_FLAG_", "ParserFlags", IsFlags: true, TypeHint: "int"),
            
            new("SLICE_FLAG_", "SliceFlags", IsFlags: true),

            new("SWS_CS_", "SwsCSFlags", IsFlags: true),
            new("SWS_", "SwsFlags", IsFlags: true, Except: HashSet("SWS_MAX_REDUCE_CUTOFF")),
            
            new("FF_COMPLIANCE_", "StrictCompliance"), // flags?

            // Has same values (should be AVCodecID_Profile)
            //new("FF_PROFILE_", "FFProfile", TypeHint: "int"),
            //new("AV_PROFILE_", "Profile", TypeHint: "int"),

            new("FF_EC_", "ErrorConcealmentFlags", IsFlags: true),

            new("FF_CMP_", "CompareFunction"),
            new("FF_DCT_", "DCTAlgo"),
            new("FF_IDCT_", "IDCTAlgo"),
            new("FF_MB_DECISION_", "MBDecision"),
            new("FF_DEBUG_", "DebugFlags", IsFlags: true),
            new("FF_BUG_", "WorkaroundBugFlags", IsFlags: true),
            new("FF_SUB_CHARENC_MODE_", "SubCharencModeFlags", IsFlags: true),
            new("FF_CODEC_PROPERTY_", "CodecPropertyFlags", IsFlags: true),

            new("FF_DECODE_ERROR_", "DecodeErrorFlags", IsFlags: true),
        ];
        Dictionary<string, MacroEnumDef> knownConstEnumMapping = knownConstEnums.ToDictionary(k => k.EnumName, v => v);

        List<MacroDefinitionBase> processedMacros = new();
        List<EnumerationDefinition> macroEnums = new();
        macros
            .GroupBy(x => knownConstEnums.FirstOrDefault(known => known.Match(x.Name)) switch
            {
                null => null,
                MacroEnumDef prefix => prefix.EnumName,
            })
            .ForEach((group, _) =>
            {
                if (group.Key == null)
                {
                    processedMacros.AddRange(group);
                }
                else
                {
                    macroEnums.Add(MakeMacroEnum(group!, knownConstEnumMapping[group.Key]));
                }
            });

        return (processedMacros, macroEnums);
    }

    private static HashSet<string> HashSet(params string[] strings) => strings.ToHashSet();
    internal static int t01 = 1000;
    private static EnumerationDefinition MakeMacroEnum(IGrouping<string, MacroDefinitionBase> group, MacroEnumDef enumDef)
    {
        List<MacroDefinitionGood> macros = group.OfType<MacroDefinitionGood>().ToList();

        Dictionary<string, string> macroShortcutMapping = macros
            .OrderByDescending(k => k.Name.Length)
            .ToDictionary(k => k.Name, v => StringExtensions.EnumNameTransform(v.Name[enumDef.Prefix.Length..]));

        IEnumerable<EnumerationItem> existingItems = macros.Select(macro => new EnumerationItem
        {
            Name = macroShortcutMapping[macro.Name],
            RawName = macro.Name,
            Value = ExpressionTransform(macro.ExpressionText, macroShortcutMapping),
            XmlDocument = macro.Name,
        });
        IEnumerable<EnumerationItem> items = enumDef.AdditionalValues != null ? enumDef.AdditionalValues.CombineExistingItems(existingItems) : existingItems;
        
        var enumDefTypeHint = enumDef.TypeHint ?? DeterminBestTypeForMacroEnum(macros.Select(x => x.TypeName).ToHashSet());

        // TBR: fix flags enums
        if (enumDef.IsFlags && !items.Any(x => x.Value == "0" || x.Name == "None"))// && (enumDefTypeHint == "int" || enumDefTypeHint == "uint" || enumDefTypeHint == "long"))
            items = [new() { Name = "None", RawName = $"None{t01++}" , Value = "0"}, .. items];

        return new EnumerationDefinition
        {
            Name = enumDef.EnumName,
            XmlDocument = $"Macro enum, prefix: {enumDef.Prefix}",
            IsFlags = enumDef.IsFlags,
            TypeName = enumDefTypeHint,
            Obsoletion = new Obsoletion { IsObsolete = false },
            Items = items.ToArray(),
        };

        static string ExpressionTransform(string expression, Dictionary<string, string> mapping)
        {
            foreach (KeyValuePair<string, string> kv in mapping)
            {
                expression = expression.Replace(kv.Key, kv.Value);
            }
            return expression;
        }

        static string DeterminBestTypeForMacroEnum(HashSet<string> allTypes)
        {
            string[] priorities =
            [
                "ulong",
                "long",
                "uint", // all function parameters get int instead of uint (TBR)
                "int",
                "ushort",
                "short",
            ];

            foreach (string prior in priorities)
            {
                if (allTypes.Contains(prior))
                    return prior;
            }
            return "int";
        }
    }
}

internal record MacroEnumDef(string Prefix, string EnumName, string? TypeHint = null, HashSet<string>? Only = default, HashSet<string>? Except = default, AdditionalMacroDef? AdditionalValues = null, bool IsFlags = false)
{
    public bool Match(string name) =>
        name.StartsWith(Prefix) &&
        (Except == null || !Except.Contains(name)) &&
        (Only == null || Only.Contains(name));

    internal static MacroEnumDef Make(string prefix) => new(prefix, FindName(prefix));

    internal static MacroEnumDef MakeFlags(string prefix) => new(prefix, FindName(prefix), IsFlags: true);

    internal static MacroEnumDef MakeFlagsAdditional(string prefix, EnumerationItem[] additionalValues, bool IsBegin) => new(prefix, FindName(prefix), AdditionalValues: new (IsBegin, additionalValues), IsFlags: true);

    internal static MacroEnumDef MakeFlagsExcept(string prefix, HashSet<string> except) => new MacroEnumDef(prefix, FindName(prefix), Except: except, IsFlags: true);

    internal static string FindName(string prefix) => prefix.EndsWith('_') ? prefix.Substring(0, prefix.Length - 1) : throw new NotSupportedException("Prefix must ends with _");
}

internal record AdditionalMacroDef(bool IsBegin, EnumerationItem[] Items)
{
    public IEnumerable<EnumerationItem> CombineExistingItems(IEnumerable<EnumerationItem> existingItems)
    {
        if (IsBegin)
        {
            foreach (EnumerationItem item in Items)
            {
                yield return item;
            }
        }

        foreach (EnumerationItem item in existingItems)
        {
            yield return item;
        }

        if (!IsBegin)
        {
            foreach (EnumerationItem item in Items)
            {
                yield return item;
            }
        }
    }
}