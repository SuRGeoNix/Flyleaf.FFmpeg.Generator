using System;
using CppSharp.AST;
using Type = CppSharp.AST.Type;

namespace Flyleaf.FFmpeg.Generator.Processors;

internal static class TypeHelper
{
    public static string GetTypeName(Type type)
    {
        return type switch
        {
            PointerType x => $"{GetTypeName(x.QualifiedPointee.Type)}*",
            BuiltinType x => GetTypeName(x.Type),
            TypedefType x => GetTypeName(x),
            TagType x => x.Declaration.Name,
            ArrayType x => $"{GetTypeName(x.Type)}[]",
            AttributedType => GetTypeName(PrimitiveType.Void),
            _ => throw new NotSupportedException()
        };
    }

    private static string GetTypeName(TypedefType type)
    {
        if (type.Declaration.Name == "size_t")
            return "nuint";
        else if (type.Declaration.Name == "ptrdiff_t")
            return "nint";

        return type.Declaration.Type switch
        {
            BuiltinType x => GetTypeName(x),
            PointerType x => GetTypeName(x),
            _ => type.Declaration.Name
        };
    }

    private static string GetTypeName(PrimitiveType type)
    {
        return type switch
        {
            PrimitiveType.Void => "void",
            PrimitiveType.Bool => "bool",
            PrimitiveType.Char => "byte",
            PrimitiveType.SChar => "sbyte",
            PrimitiveType.UChar => "byte",
            PrimitiveType.Short => "short",
            PrimitiveType.UShort => "ushort",
            PrimitiveType.Int => "int",
            PrimitiveType.UInt => "uint",

            // https://github.com/dotnet/runtime/issues/13788 TBR: Apple CGFloat
            PrimitiveType.Long => "CLong",
            PrimitiveType.ULong => "CULong",
            
            PrimitiveType.LongLong => "long",
            PrimitiveType.ULongLong => "ulong",
            PrimitiveType.Float => "float",
            PrimitiveType.Double => "double",
            PrimitiveType.Decimal => "decimal",
            PrimitiveType.IntPtr => "IntPtr",
            PrimitiveType.UIntPtr => "UIntPtr",
            
            _ => throw new NotSupportedException()
        };
    }

    public static int CalculatePrecedence(string type)
    {
        return type switch
        {
            "bool" => 0,
            "double" => 1,
            "float" => 2,
            "ulong" => 3,
            "long" => 4,
            "uint" => 5,
            "int" => 6,
            "char" => 7,
            "string" => 8,
            _ => int.MaxValue,
        };
    }

    public static bool IsKnownType(string type)
    {
        return type switch
        {
            "bool" => true,
            "double" => true,
            "float" => true,
            "ulong" => true,
            "long" => true,
            "uint" => true,
            "int" => true,
            "char" => true,
            "string" => true,
            _ => false,
        };
    }
}
