#nullable disable

namespace Flyleaf.FFmpeg.Generator.Definitions;

internal record StructureField : ICanGenerateXmlDoc, IObsoletionAware
{
    public string Name { get; init; }
    public TypeDefinition FieldType { get; init; }
    public string XmlDocument { get; init; }
    public Obsoletion Obsoletion { get; init; }
}