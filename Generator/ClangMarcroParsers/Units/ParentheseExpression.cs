namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record ParentheseExpression(IExpression Content) : IExpression
{
    public string Serialize() => $"({Content.Serialize()})";
}
