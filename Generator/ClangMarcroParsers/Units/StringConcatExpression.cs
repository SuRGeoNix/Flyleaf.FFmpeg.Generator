namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record StringConcatExpression(StringExpression Str, IExpression Exp) : IExpression
{
    public string Serialize() => $"{Str.Serialize()} + {Exp.Serialize()}";
}
