#nullable disable

namespace Flyleaf.FFmpeg.Generator.Definitions;

internal record NamedDefinition : ICanGenerateXmlDoc, IObsoletionAware
{
    public string Name { get; init; }
    public string TypeName { get; init; }
    public string XmlDocument { get; set; }
    public Obsoletion Obsoletion { get; init; }
}