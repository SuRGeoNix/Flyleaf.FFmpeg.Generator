using System;
using System.Collections.Generic;
using System.Linq;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using Flyleaf.FFmpeg.Generator.Definitions;
using Type = CppSharp.AST.Type;

#nullable disable

namespace Flyleaf.FFmpeg.Generator.Processors;

internal class StructureProcessor
{
    private readonly ASTProcessor _context;

    public StructureProcessor(ASTProcessor context) => _context = context;

    public void Process(TranslationUnit translationUnit)
    {
        foreach (var typedef in translationUnit.Typedefs)
        {
            if (!typedef.Type.TryGetClass(out var @class))
                continue;

            if (@class.Comment == null && typedef.Comment != null)
                @class.Comment = typedef.Comment;

            var className = @class.Name;
            MakeDefinition(@class, className);
        }

        foreach (var @class in translationUnit.Classes)
        {
            MakeDefinition(@class, @class.Name);
        }
    }

    private void MakeDefinition(Class @class, string name)
    {
        name = string.IsNullOrEmpty(@class.Name) ? name : @class.Name;

        var definition = _context.Units.OfType<StructureDefinition>().FirstOrDefault(x => x.Name == name);

        if (definition == null)
        {
            definition = new StructureDefinition
            {
                Name = name,
                IsUnion = @class.IsUnion,
                Obsoletion = ObsoletionHelper.CreateObsoletion(@class)
            };
            _context.AddUnit(definition);
        }

        if (@class.Comment != null)
            definition.XmlDocument = @class.Comment?.BriefText;

        if (@class.Ignore) return; // TBR: Excludes d3d11.h structures for example*

        if (@class.IsIncomplete || definition.IsComplete) return;

        definition.IsComplete = true;

        var bitFieldNames = new List<string>();
        var bitFieldComments = new List<string>();
        long bitCounter = 0;
        var fields = new List<StructureField>();

        // IsBitField (Currently only AVIndexEntry but we should review new ones if any)
        foreach (var field in @class.Fields)
        {
            if (field.IsBitField)
            {
                bitFieldNames.Add($"{field.Name}{field.BitWidth}");
                bitFieldComments.Add(field.Comment?.BriefText ?? string.Empty);
                bitCounter += field.BitWidth;
                Console.WriteLine($"{name} -> {field.Name} ({field.BitWidth})");
                if (bitCounter % 8 == 0)
                {
                    fields.Add(GetBitField(bitFieldNames, bitCounter, bitFieldComments));
                    bitFieldNames.Clear();
                    bitFieldComments.Clear();
                    bitCounter = 0;
                }

                continue;
            }

            // Keep an eye on those (might just be a pointer to pointer and not a pointer to unfixed struct array)
            //if (field.Type is PointerType ptype && ptype.Pointee is PointerType && field.DebugText.Contains("struct"))
            //    Console.WriteLine($"Unfixed Array: {name} - {field.Name}");

            var typeName = $"{field.Class.Name}_{field.Name}";
            fields.Add(new StructureField
            {
                Name = field.Name == "GetType" ? "GetType2" : field.Name, // TBR: Changes names
                FieldType = FixFlagTypes(field.Class.Name, field.Name) ?? GetTypeDefinition(field.Type, typeName), // Changes types
                XmlDocument = field.Comment?.BriefText,
                Obsoletion = ObsoletionHelper.CreateObsoletion(field)
            });
        }

        if (bitFieldNames.Any() || bitCounter > 0) throw new InvalidOperationException();

        definition.Fields = fields.ToArray();
    }

    private TypeDefinition FixFlagTypes(string className, string fieldName)
    {
        if (fieldName == "flags")
        {
            if (className == "AVOption")
                return new() { Name = "OptFlags" };

            if (className == "AVFrame")
                return new() { Name = "FrameFlags" };

            if (className == "AVPixFmtDescriptor")
                return new() { Name = "PixFmtFlags" };

            if (className == "AVCodecContext")
                return new() { Name = "CodecFlags" };

            if (className == "AVFilterPad")
                return new() { Name = "FilterPadFlags" };

            if (className == "AVFormatContext")
                return new() { Name = "FmtFlags2" };

            if (className == "AVInputFormat")
                return new() { Name = "FmtFlags" };

            if (className == "AVOutputFormat")
                return new() { Name = "FmtFlags" };

            //if (className == "AVInputFormat")
            //    return new() { Name = "DemuxerSpecFlags" };

            //if (className == "AVOutputFormat")
            //    return new() { Name = "MuxerSpecFlags" };

            if (className == "AVPacket")
                return new() { Name = "PktFlags" };

            if (className == "AVFilter")
                return new() { Name = "FilterFlags" };

            return null;
        }

        if (fieldName == "error_recognition" || fieldName == "err_recognition")
            return new() { Name = "ErrorDetectFlags" };

        if (fieldName == "strict_std_compliance")
            return new() { Name = "StrictCompliance" };

        if (fieldName == "flags2")
        {
            if (className == "AVCodecContext")
                return new() { Name = "CodecFlags2" };
        }

        if (fieldName == "hwaccel_flags")
            return new() { Name = "HWAccelFlags" };

        if (fieldName == "slice_flags")
            return new() { Name = "SliceFlags" };

        if (fieldName == "export_side_data")
            return new() { Name = "CodecExportDataFlags" };

        if (fieldName == "props" && className == "AVCodecDescriptor")
            return new() { Name = "CodecPropFlags" };

        if (fieldName == "methods" && className == "AVCodecHWConfig")
            return new() { Name = "AVCodecHwConfigMethod" }; // from unamed enums

        if (fieldName == "event_flags")
        {
            if (className == "AVStream")
                return new() { Name = "StreamEventFlags" };

            if (className == "AVFormatContext")
                return new() { Name = "FmtEventFlags" };
        }

        if (fieldName == "ctx_flags")
            return new() { Name = "FmtCtxFlags" };

        if (fieldName == "disposition" && (className == "AVStream" || className == "AVStreamGroup"))
            return new() { Name = "DispositionFlags" };

        if (fieldName == "avio_flags")
            return new() { Name = "IOFlags" };

        if (fieldName == "seekable" && className == "AVIOContext")
            return new() { Name = "IOSeekableFlags" };

        if (fieldName == "thread_type")
        {
            if (className == "AVFilterContext" || className == "AVFilterGraph")
                return new() { Name = "FilterThreadFlags" };

            if (className == "AVCodecContext")
                return new() { Name = "ThreadTypeFlags" };
        }

        if (className == "AVSideDataDescriptor" && fieldName == "props")
            return new() { Name = "AVSideDataProps" }; // orginally an enum

        // libavfilter/filters.h (extra)
        if (className == "AVFilter" && fieldName == "formats_state")
            return new() { Name = "FilterFormatsState" };

        if (className == "AVCodecContext")
        {
            if (fieldName == "error_concealment")
                return new() { Name = "ErrorConcealmentFlags" };

            if (fieldName == "active_thread_type")
                return new() { Name = "ThreadTypeFlags" };

            if (fieldName == "me_cmp" || fieldName == "me_sub_cmp" || fieldName == "mb_cmp" || fieldName == "ildct_cmp" || fieldName == "me_pre_cmp")
                return new() { Name = "CompareFunction" };

            if (fieldName == "dct_algo")
                return new() { Name = "DCTAlgo" };

            if (fieldName == "idct_algo")
                return new() { Name = "IDCTAlgo" };

            if (fieldName == "mb_decision")
                return new() { Name = "MBDecision" };

            if (fieldName == "debug")
                return new() { Name = "DebugFlags" };

            if (fieldName == "workaround_bugs")
                return new() { Name = "WorkaroundBugFlags" };

            if (fieldName == "sub_charenc_mode")
                return new() { Name = "SubCharencModeFlags" };

            if (fieldName == "properties")
                return new() { Name = "CodecPropertyFlags" };
        }

        if (className == "AVFrame")
        {
            if (fieldName == "decode_error_flags")
                return new() { Name = "DecodeErrorFlags" };
        }

        if (fieldName == "capabilities")
        {
            if (className == "AVCodec")
                return new() { Name = "CodecCapFlags" };

            if (className == "AVHWAccel")
                return new() { Name = "HWAccelCapFlags" };
        }

        if (fieldName == "avoid_negative_ts")
            return new() { Name = "AvoidNegTSFlags" };

        return null;
    }

    internal TypeDefinition GetTypeDefinition(Type type, string name = null, bool useWrapperForFixedArray = true)
    {
        return type switch
        {
            TypedefType declaration => declaration.Declaration.Name == "ptrdiff_t" ? new() { Name = "nint" } : (declaration.Declaration.Name == "size_t" ? new() { Name = "nuint" } : GetTypeDefinition(declaration.Declaration.Type, name)),
            ArrayType { SizeType: ArrayType.ArraySize.Constant } arrayType => useWrapperForFixedArray
                ? GetFieldTypeForFixedArray(arrayType)
                : new TypeDefinition() { Name = TypeHelper.GetTypeName(new PointerType(arrayType.QualifiedType)) },
            TagType tagType => GetFieldTypeForNestedDeclaration(tagType.Declaration, name),
            PointerType pointerType => GetTypeDefinition(pointerType, name),
            _ => new TypeDefinition
            {
                Name = TypeHelper.GetTypeName(type)
            }
        };
    }

    private static StructureField GetBitField(IEnumerable<string> names, long bitCounter, List<string> comments)
    {
        var fieldName = string.Join("_", names);

        var fieldType = bitCounter switch
        {
            8 => "byte",
            16 => "short",
            32 => "int",
            64 => "long",
            _ => throw new NotSupportedException()
        };

        return new StructureField
        {
            Name = fieldName,
            FieldType = new TypeDefinition { Name = fieldType },
            XmlDocument = string.Join(" ", comments.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Trim()))
        };
    }

    private TypeDefinition GetTypeDefinition(PointerType pointerType, string name)
    {
        var pointee = pointerType.Pointee;

        if (pointee is TypedefType typedefType)
            pointee = typedefType.Declaration.Type;

        if (pointee is FunctionType functionType)
            return _context.FunctionProcessor.GetDelegateType(functionType, name);

        var pointerTypeDefinition = GetTypeDefinition(pointee, name);
        return new TypeDefinition { Name = $"{pointerTypeDefinition.Name}*" };
    }

    private TypeDefinition GetFieldTypeForNestedDeclaration(Declaration declaration, string name)
    {
        var typeName = string.IsNullOrEmpty(declaration.Name) ? name : declaration.Name;

        switch (declaration)
        {
            case Class @class:
                MakeDefinition(@class, typeName);
                return new TypeDefinition { Name = typeName };
            case Enumeration @enum:
                _context.EnumerationProcessor.MakeDefinition(@enum, typeName);
                return new TypeDefinition { Name = typeName };
            default:
                throw new NotSupportedException();
        }
    }


    private TypeDefinition GetFieldTypeForFixedArray(ArrayType arrayType)
    {
        var elementType = arrayType.Type;
        var elementTypeDefinition = GetTypeDefinition(elementType);

        var fixedSize = (int) arrayType.Size;

        var name = $"{elementTypeDefinition.Name}_array{fixedSize}";

        if (elementType.IsPointer())
            name = $"{TypeHelper.GetTypeName(elementType.GetPointee())}_ptrArray{fixedSize}";

        if (elementType is ArrayType elementArrayType)
        {
            if (elementArrayType.SizeType == ArrayType.ArraySize.Constant)
            {
                fixedSize /= (int) elementArrayType.Size;
                name = $"{TypeHelper.GetTypeName(elementArrayType.Type)}_array{fixedSize}x{elementArrayType.Size}";
            }
            else
                name = $"{TypeHelper.GetTypeName(elementArrayType.Type)}_arrayOfArray{fixedSize}";
        }

        if (_context.IsKnownUnitName(name))
            return new TypeDefinition { Name = name, ByReference = !arrayType.QualifiedType.Qualifiers.IsConst };

        var fixedArray = new FixedArrayDefinition
        {
            Name = name,
            Size = fixedSize,
            ElementType = elementTypeDefinition,
            IsPrimitive = elementType.IsPrimitiveType() && !name.StartsWith("nint") && !name.StartsWith("nuint"), // TBR: nint changed with ptrdiff_t / size_t
            ByReference = !arrayType.QualifiedType.Qualifiers.IsConst
        };
        _context.AddUnit(fixedArray);

        return fixedArray;
    }
}