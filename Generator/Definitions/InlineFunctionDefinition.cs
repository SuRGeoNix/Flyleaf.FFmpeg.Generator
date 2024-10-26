#nullable disable

namespace Flyleaf.FFmpeg.Generator.Definitions;

internal record InlineFunctionDefinition : FunctionDefinitionBase
{
    public string Body { get; set; }
    public string OriginalBodyHash { get; set; }
}