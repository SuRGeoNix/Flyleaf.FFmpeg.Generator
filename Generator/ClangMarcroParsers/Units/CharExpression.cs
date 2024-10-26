namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record CharExpression(char C) : IExpression
{
    public string Serialize() => $"'{C}'";
}
