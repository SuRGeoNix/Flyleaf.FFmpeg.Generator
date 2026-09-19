using System;
using System.CodeDom.Compiler;
using System.Linq;
using System.Security;
using System.Text;

using Flyleaf.FFmpeg.Generator.Definitions;

namespace Flyleaf.FFmpeg.Generator;

internal class Writer
{
    private readonly IndentedTextWriter _writer;

    public Writer(IndentedTextWriter writer) => _writer = writer;

    public void WriteMacro(MacroDefinitionBase macro)
    {
        if (macro is MacroDefinitionGood good)
        {
            WriteSummary(macro);
            var constOrStatic = good.IsConst ? "const" : "static readonly";
            
            WriteLine($"public {constOrStatic} {good.TypeName} {macro.Name} = {good.ExpressionText};");
        }
        else
        {
            WriteLine($"// public static {macro.Name} = {macro.RawExpressionText};");
        }   
    }

    public void WriteEnumeration(EnumerationDefinition enumeration)
    {
        WriteSummary(enumeration);
        WriteObsoletion(enumeration);
        if (enumeration.IsFlags) WriteLine("[Flags]");
        WriteLine($"public enum {enumeration.Name} : {enumeration.TypeName}");

        using (BeginBlock())
        {
            foreach (var item in enumeration.Items)
            {
                WriteSummary(item);
                WriteLine($"{item.Name} = {item.Value},");
            }
        }
    }        

    public void WriteStructure(StructureDefinition structure)
    {
        WriteSummary(structure);
        if (!structure.IsComplete && Program.Options.XMLDocumentation) WriteLine("/// <remarks>This struct is incomplete.</remarks>");
        WriteObsoletion(structure);
        if (structure.IsUnion) WriteLine("[StructLayout(LayoutKind.Explicit)]");

        if (!structure.IsComplete && structure.Fields.Length == 0)
        {
            WriteLine($"public unsafe struct {structure.Name} {{}}");
            return;
        }

        WriteLine($"public unsafe struct {structure.Name}");
        
        using (BeginBlock())
            foreach (var field in structure.Fields)
            {
                WriteSummary(field);
                WriteObsoletion(field);
                if (structure.IsUnion) WriteLine("[FieldOffset(0)]");
                WriteLine($"public {field.FieldType.Name} {StringExtensions.CSharpKeywordTransform(field.Name)};");
            }
    }

    public void WriteFixedArray(FixedArrayDefinition array)
    {
        WriteLine($$"""
[InlineArray({{array.Size}})]
public struct {{array.Name}}<T> where T : unmanaged
{
    public readonly int Length => {{array.Size}};
    T _;
}
""");
    }

    public void WriteFunction(ExportFunctionDefinition function)
    {
        if (function.Obsoletion.IsObsolete && !Program.Options.UsingObsoleteFunctions)
            return;

        WriteSummary(function);
        function.Parameters.ForEach((x, i) => WriteParam(x, x.Name));
        WriteObsoletion(function);
        WriteLine($"[DllImport({function.LibraryName.ToUpper()}, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true), SuppressUnmanagedCodeSecurity]");

        function.ReturnType.Attributes.ToList().ForEach(WriteLine);

        var exclude = function.Name.StartsWith("av_log_");
        var parameters = GetParameters(function.Parameters, !exclude); // TBR: exclude hot paths

        WriteLine($"public static extern {function.ReturnType.Name} {function.Name}({parameters});");
    }

    public void WriteFunction(InlineFunctionDefinition function)
    {
        function.ReturnType.Attributes.ToList().ForEach(WriteLine);
        var parameters = GetParameters(function.Parameters);

        WriteSummary(function);
        function.Parameters.ToList().ForEach(x => WriteParam(x, x.Name));
        WriteReturnComment(function.ReturnComment);

        WriteObsoletion(function);
        WriteLine($"public static {function.ReturnType.Name} {function.Name}({parameters})");

        var lines = function.Body.Split(['\n','\r'], StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.ForEach(WriteLineWithoutIntent);
        WriteLine($"// original body hash: {function.OriginalBodyHash}");
        WriteLine();
    }

    public void WriteDelegate(DelegateDefinition @delegate)
    {
        WriteSummary(@delegate);
        @delegate.Parameters.ToList().ForEach(x => WriteParam(x, x.Name));
        
        var parameters = GetParameters(@delegate.Parameters, false);//, false, true);
        WriteLine("[UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
        @delegate.ReturnType.Attributes.ToList().ForEach(WriteLine); // TBR: Added
        //WriteLine($"public unsafe delegate {(@delegate.ReturnType.Name == "string" ? "byte*" : @delegate.ReturnType.Name)} {@delegate.FunctionName} ({parameters});");
        WriteLine($"public unsafe delegate {@delegate.ReturnType.Name} {@delegate.FunctionName} ({parameters});");

        WriteLine($"public unsafe record struct {@delegate.Name}(IntPtr Pointer)");
        using (BeginBlock())
        {
            WriteLine($"public static implicit operator {@delegate.Name}({@delegate.FunctionName} func) => new(func switch");
            using (BeginBlock(inline: true))
            {
                WriteLine("null => IntPtr.Zero,");
                WriteLine("_ => GetFunctionPointerForDelegate(func)");
            }
            WriteLine(");");
        }
    }

    public void Write(string value)                 => _writer.Write(value);
    public void WriteLine()                         => _writer.WriteLine();
    public void WriteLine(string line)              => _writer.WriteLine(line);
    public void WriteLineWithoutIntent(string line) => _writer.WriteLineNoTabs(line);

    public IDisposable BeginBlock(bool inline = false)
    {
        WriteLine("{");
        _writer.Indent++;
        return new End(() =>
        {
            _writer.Indent--;

            if (inline)
                _writer.Write("}");
            else
                _writer.WriteLine("}");
        });
    }

    private static string GetParameters(FunctionParameter[] parameters, bool withAttributes = true)
    {
        return string.Join(", ",
            parameters.Select(x =>
            {
                var sb = new StringBuilder();
                if (withAttributes && x.Type.Attributes.Any()) sb.Append($"{string.Join("", x.Type.Attributes)} ");
                if (x.Type.ByReference) sb.Append("ref ");
                if (!withAttributes && x.Type.Name == "string")
                    sb.Append($"byte* {StringExtensions.CSharpKeywordTransform(x.Name)}");
                else
                    sb.Append($"{x.Type.Name} {StringExtensions.CSharpKeywordTransform(x.Name)}");
                return sb.ToString();
            }));
    }

    private void WriteSummary(ICanGenerateXmlDoc value)
    {
        if (Program.Options.XMLDocumentation && !string.IsNullOrWhiteSpace(value.XmlDocument))
            WriteLine($"/// <summary>{SecurityElement.Escape(value.XmlDocument.Trim())}</summary>");
    }

    private void WriteParam(ICanGenerateXmlDoc value, string name)
    {
        if (Program.Options.XMLDocumentation &&!string.IsNullOrWhiteSpace(value.XmlDocument))
            WriteLine($"/// <param name=\"{name}\">{SecurityElement.Escape(value.XmlDocument.Trim())}</param>");
    }

    private void WriteReturnComment(string content)
    {
        if (Program.Options.XMLDocumentation &&!string.IsNullOrWhiteSpace(content))
            WriteLine($"/// <returns>{SecurityElement.Escape(content.Trim())}</returns>");
    }

    private void WriteObsoletion(IObsoletionAware obsoletionAware)
    {
        var obsoletion = obsoletionAware.Obsoletion;
        if (obsoletion.IsObsolete) WriteLine($"[Obsolete(\"{StringExtensions.DoubleQuoteEscape(obsoletion.Message)}\")]");
    }

    private class End : IDisposable
    {
        private readonly Action _action;

        public End(Action action) => _action = action;

        public void Dispose() => _action();
    }
}