using System;
using System.Collections.Generic;
using System.Linq;
using CppSharp.AST;
using CppSharp.AST.Extensions;
using Flyleaf.FFmpeg.Generator.Definitions;

#nullable disable

namespace Flyleaf.FFmpeg.Generator.Processors;

internal class EnumerationProcessor
{
    private readonly ASTProcessor _context;

    public EnumerationProcessor(ASTProcessor context) => _context = context;

    public void Process(TranslationUnit translationUnit)
    {
        foreach (var enumeration in translationUnit.Enums)
        {
            if (!enumeration.Type.IsPrimitiveType()) throw new NotSupportedException();

            var enumerationName = enumeration.Name;
            if (string.IsNullOrEmpty(enumerationName))
                MakeDefinition(enumeration, null); // Include unamed enums based on common prefix
            else
                MakeDefinition(enumeration, enumerationName);
        }
    }

    public void MakeDefinition(Enumeration enumeration, string name)
    {
        if (name != null && _context.IsKnownUnitName(name))
            return;

        bool isflags = false;
        string commonPrefix = StringExtensions.CommonPrefixOf(enumeration.Items.Select(x => x.Name).Where(x => !x.EndsWith("_NB")));

        // Include unamed enums based on common prefix
        if (name == null)
        {
            if (commonPrefix == null)
                return;

            isflags = true; // consider all as flags?
            name = StringExtensions.EnumNameTransform(MacroEnumDef.FindName(commonPrefix));

            if (name.StartsWith("AvHw"))
                name = "AVHW" + name.Substring(4);
            else if (name.StartsWith("Av"))
                name = "AV" + name.Substring(2);

            if (_context.IsKnownUnitName(name))
                return;

            if (!enumeration.Items.Any(x => x.Value == 0 || x.Name == "None"))
                enumeration.Items = [new() { Name = "f1X",  Value = 0}, ..enumeration.Items];

            var definition = new EnumerationDefinition
            {
                Name = name,
                TypeName = TypeHelper.GetTypeName(enumeration.Type),
                IsFlags = isflags,
                XmlDocument = enumeration.Comment?.BriefText,
                Obsoletion = ObsoletionHelper.CreateObsoletion(enumeration),
                Items = enumeration.Items
                    .Select(x =>
                        new EnumerationItem
                        {
                            Name = x.Name == "f1X" ? "None" : StringExtensions.EnumNameTransform(x.Name.StartsWith(commonPrefix) ? x.Name[commonPrefix.Length..] : x.Name),
                            RawName = x.Name == "f1X" ? $"None{MacroEnumPostProcessor.t01++}" : x.Name, 
                            Value = ConvertValue(x.Value, enumeration.BuiltinType.Type).ToString(),
                            XmlDocument = x.Comment?.BriefText
                        })
                    .ToArray()
            };
        
            _context.AddUnit(definition);
        }
        else
        {
            // TBR: fix flags enums
            if (name == "AVSideDataProps")
            {
                isflags = true;
                enumeration.Items = [new() { Name = "None", Value = 0}, ..enumeration.Items];
            }

            var definition = new EnumerationDefinition
            {
                Name = name,
                TypeName = TypeHelper.GetTypeName(enumeration.Type),
                IsFlags = isflags,
                XmlDocument = enumeration.Comment?.BriefText,
                Obsoletion = ObsoletionHelper.CreateObsoletion(enumeration),
                Items = enumeration.Items
                    .Select(x =>
                        new EnumerationItem
                        {
                            Name = StringExtensions.EnumNameTransform(x.Name.StartsWith(commonPrefix) ? x.Name[commonPrefix.Length..] : x.Name),
                            RawName = x.Name, 
                            Value = ConvertValue(x.Value, enumeration.BuiltinType.Type).ToString(),
                            XmlDocument = x.Comment?.BriefText
                        })
                    .ToArray()
            };
        
            _context.AddUnit(definition);
        }
    }

    private static object ConvertValue(ulong value, PrimitiveType primitiveType)
    {
        return primitiveType switch
        {
            PrimitiveType.Int => value > int.MaxValue ? (int) value : value,
            PrimitiveType.UInt => value,
            PrimitiveType.Long => value > long.MaxValue ? (long) value : value,
            PrimitiveType.ULong => value,
            _ => throw new NotSupportedException()
        };
    }
}
