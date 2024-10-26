namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record StringExpression(string Str) : IExpression
{
    public string Serialize() => $"\"{Str}\"";
}
