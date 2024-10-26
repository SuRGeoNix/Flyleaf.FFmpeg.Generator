namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record IdentifierExpression(string Name) : IExpression
{
    public string Serialize() => Name;
}
