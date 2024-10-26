using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CppSharp.AST;
using Flyleaf.FFmpeg.Generator.Definitions;
using Type = CppSharp.AST.Type;

#nullable disable

namespace Flyleaf.FFmpeg.Generator.Processors;

internal class FunctionProcessor
{
    private const string MarshalAsUtf8Macros = "[MarshalAs(UnmanagedType.LPUTF8Str)]";
    private const string MarshalAsUtf8MacrosReturn = "[return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(ConstCharPtrMarshaler))]";

    private readonly ASTProcessor _context;

    public FunctionProcessor(ASTProcessor context) => _context = context;

    public void Process(TranslationUnit translationUnit)
    {
        foreach (var function in translationUnit.Functions)
        {
            ProcessFunction(function);

            // add a duplicate/overload that uses ref-style arguments for double indirection
            if (function.Parameters.Any(v => IsTypeDoubleIndirection(v.Type)))
                ProcessFunction(function, true, false);

            // add a duplicate/overload that uses ptr-style arguments for fixed arrays
            if (function.Parameters.Any(v => IsTypeFixedArray(v.Type)))
                ProcessFunction(function, false, false);
        }
    }

    private void ProcessFunction(Function function, bool useByRefForDoubleIndirection = false, bool useWrapperForFixedArray = true)
    {
        var functionName = function.Name;

        void PopulateCommon(FunctionDefinitionBase inline)
        {
            inline.Name = functionName;
            inline.ReturnType = GetReturnTypeName(function.ReturnType.Type, functionName);
            inline.XmlDocument = function.Comment?.BriefText;
            inline.ReturnComment = GetReturnComment(function);
            inline.Parameters = function.Parameters.Select((x, i) => GetParameter(function, x, i, useByRefForDoubleIndirection, useWrapperForFixedArray)).ToArray();
            inline.Obsoletion = ObsoletionHelper.CreateObsoletion(function);
        }

        if (function.IsInline)
        {
            var inlineDefinition = new InlineFunctionDefinition();
            PopulateCommon(inlineDefinition);
            inlineDefinition.Body = function.Body;
            inlineDefinition.OriginalBodyHash = GetSha256(function.Body);
            _context.AddUnit(inlineDefinition);
            return;
        }

        if (!_context.FunctionExportMap.TryGetValue(functionName, out var export))
        {
            Console.WriteLine($"Export not found. Skipping {functionName} function.");
            return;
        }

        var exportDefinition = new ExportFunctionDefinition();
        PopulateCommon(exportDefinition);
        exportDefinition.LibraryName = export.LibraryName;
        exportDefinition.LibraryVersion = export.LibraryVersion;
        _context.AddUnit(exportDefinition);
    }

    internal TypeDefinition GetDelegateType(FunctionType functionType, string name)
    {
        var @delegate = new DelegateDefinition
        {
            Name = $"{name}_func",
            FunctionName = name,
            ReturnType = GetReturnTypeName(functionType.ReturnType.Type, name),
            Parameters = functionType.Parameters.Select((x, i) => GetParameter(name, x, i)).ToArray()
        };
        _context.AddUnit(@delegate);

        return @delegate;
    }

    private FunctionParameter GetParameter(string funcName, Parameter parameter, int position)
    {
        var name = string.IsNullOrEmpty(parameter.Name) ? $"p{position}" : parameter.Name;

        var fixFlagEnum = FixFlagTypesDelegates(funcName, parameter.Name, parameter, position);

        return new FunctionParameter
        {
            Name = name,
            Type = fixFlagEnum ?? GetParameterType(parameter.Type, name)
        };
    }

    private FunctionParameter GetParameter(Function function, Parameter parameter, int position, bool useByRefForDoubleIndirection, bool useWrapperForFixedArray = true)
    {
        // Keep an eye on those (might just be a pointer to pointer and not a pointer to unfixed struct array)
        //if (parameter.Type is PointerType ptype && ptype.Pointee is PointerType && parameter.DebugText.Contains("struct"))
        //    Console.WriteLine($"Unfixed Array: {function.Name} - {parameter.Name}");

        var name = string.IsNullOrEmpty(parameter.Name) ? $"p{position}" : parameter.Name;
        var flagType = FixFlagTypes(function.Name, parameter.Name, parameter);
        return new FunctionParameter
        {
            Name = name,
            Type = flagType ?? GetParameterType(parameter.Type, $"{function.Name}_{name}", useByRefForDoubleIndirection, useWrapperForFixedArray),
            XmlDocument = GetParamComment(function, parameter.Name)
        };
    }

    private TypeDefinition FixFlagTypesDelegates(string functionName, string parameterName, Parameter parameter, int position)
    {
        if (functionName == "av_log_set_callback_callback" && position == 1)
            return new() { Name = "LogLevel" };

        if (parameterName == "flags")
        {
            if (functionName == "AVIOContext_read_seek" || functionName.StartsWith("AVInputFormat_read_seek"))
                return new() { Name = "SeekFlags" };

            if (functionName == "AVFormatContext_io_open")
                return new() { Name = "IOFlags" };

            return null;
        }

        if (parameterName == "whence")
            return new() { Name = "IOSeekFlags" };

        return null;
    }

    private TypeDefinition FixFlagTypes(string functionName, string parameterName, Parameter parameter)
    {
        if (parameterName == "level" && parameter.Type is BuiltinType bt && bt.Type == PrimitiveType.Int) // maybe also log_offset
            return new() { Name = "LogLevel" };

        if (parameterName == "flags")
        {
            if (functionName.StartsWith("av_dict_"))
            {
                if (functionName == "av_dict_get")
                    return new() { Name = "DictReadFlags" };

                if (functionName == "av_dict_set" || functionName == "av_dict_set_int" ||  functionName == "av_dict_parse_string" || functionName == "av_dict_copy")
                    return new() { Name = "DictWriteFlags" };

                return null;
            }

            if (functionName == "av_seek_frame" ||  functionName == "avformat_seek_file" ||  functionName == "avio_seek_time" || functionName == "av_index_search_timestamp" || functionName == "avformat_index_get_entry_from_timestamp")
                return new() { Name = "SeekFlags" };

            if (functionName.StartsWith("avio_open") || functionName == "avio_check")
                return new() { Name = "IOFlags" };

            if (functionName == "av_add_index_entry")
                return new() { Name = "IndexFlags" };

            if (functionName == "sws_getContext" || functionName == "sws_getCachedContext")
                return new() { Name = "SwsFlags" };

            if (functionName == "av_opt_get_key_value" || functionName == "av_opt_set_defaults2")
                return new() { Name = "OptFlags" };

            if (functionName == "av_opt_serialize")
                return new() { Name = "OptSerializeFlags" };

            if (functionName.StartsWith("av_buffersrc_"))
                return new() { Name = "AVBuffersrcFlag" }; // unamed enum

            if (functionName.StartsWith("av_buffersink_"))
                return new() { Name = "BufferSinkFlags" };

            if (functionName == "avfilter_graph_queue_command")
                return new() { Name = "FilterCmdFlags" };

            if (functionName == "av_hwframe_map")
                return new() { Name = "AVHWframeMap" }; // unamed enum

            return null;
        }
        
        if (parameterName == "opt_flags" && functionName.StartsWith("av_opt_"))
            return new() { Name = "OptFlags" };

        if (parameterName == "mask" && functionName == "av_opt_set_defaults2")
            return new() { Name = "OptFlags" };

        if (parameterName == "search_flags" && functionName.StartsWith("av_opt_"))
            return new() { Name = "OptSearchFlags" };

        if (parameterName == "whence")
            return new() { Name = "IOSeekFlags" };

        return null;
    }

    private TypeDefinition GetReturnTypeName(Type type, string name)
    {
        if (name == "av_log_get_level")
            return new() {  Name = "LogLevel" };

        if (type is PointerType pointerType &&
            pointerType.QualifiedPointee.Qualifiers.IsConst &&
            pointerType.Pointee is BuiltinType builtinType)
        {
            return builtinType.Type switch
            {
                PrimitiveType.Char => new TypeDefinition
                {
                    Name = "string",
                    Attributes = [MarshalAsUtf8MacrosReturn]
                },
                PrimitiveType.Void => new TypeDefinition
                {
                    Name = "void*"
                },
                _ => new TypeDefinition
                {
                    Name = TypeHelper.GetTypeName(type)
                }
            };
        }

        return GetParameterType(type, name);
    }

    private TypeDefinition GetParameterType(Type type, string name, bool useByRefForDoubleIndirection = false, bool useWrapperForFixedArray = true)
    {
        // if argument is double indirection (void** ptr), rewrite to use "ref void* ptr"
        if (useByRefForDoubleIndirection && type is PointerType { Pointee: PointerType t })
        {
            return new TypeDefinition
            {
                Name = TypeHelper.GetTypeName(t),
                ByReference = true,
            };
        }

        if (type is PointerType pointerType &&
            pointerType.QualifiedPointee.Qualifiers.IsConst &&
            pointerType.Pointee is BuiltinType builtinType)
        {
            return builtinType.Type switch
            {
                PrimitiveType.Char => new TypeDefinition
                {
                    Name = "string",
                    Attributes = [ MarshalAsUtf8Macros ]
                },
                PrimitiveType.Void => new TypeDefinition
                {
                    Name = "void*"
                },
                _ => new TypeDefinition
                {
                    Name = TypeHelper.GetTypeName(type)
                }
            };
        }

        // edge case when type is array of pointers to none builtin type (type[]* -> type**)
        if (useWrapperForFixedArray && type is ArrayType arrayType &&
            arrayType.SizeType == ArrayType.ArraySize.Incomplete &&
            arrayType.Type is PointerType arrayPointerType &&
            !(arrayPointerType.Pointee is BuiltinType || arrayPointerType.Pointee is TypedefType typedefType &&
                typedefType.Declaration.Type is BuiltinType))
            return new TypeDefinition { Name = $"{TypeHelper.GetTypeName(arrayPointerType)}*" };

        return _context.StructureProcessor.GetTypeDefinition(type, name, useWrapperForFixedArray);
    }

    private static bool IsTypeDoubleIndirection(Type type) => type is PointerType { Pointee: PointerType };

    private static bool IsTypeFixedArray(Type type) =>
        type is ArrayType { SizeType: ArrayType.ArraySize.Constant } or
            ArrayType { SizeType: ArrayType.ArraySize.Incomplete };

    private static string GetParamComment(Function function, string parameterName)
    {
        var comment = function?.Comment?.FullComment.Blocks
            .OfType<ParamCommandComment>()
            .FirstOrDefault(x => x.Arguments.Count == 1 && x.Arguments[0].Text == parameterName);
        return GetCommentString(comment);
    }

    private string GetReturnComment(Function function)
    {
        var comment = function?.Comment?.FullComment.Blocks
            .OfType<BlockCommandComment>()
            .FirstOrDefault(x => x.CommandKind == CommentCommandKind.Return);
        return GetCommentString(comment);
    }

    private static string GetCommentString(BlockCommandComment comment)
    {
        return comment == null
            ? null
            : string.Join(" ", comment.ParagraphComment.Content.OfType<TextComment>().Select(x => x.Text.Trim()));
    }

    private static string GetSha256(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        byte[] hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}