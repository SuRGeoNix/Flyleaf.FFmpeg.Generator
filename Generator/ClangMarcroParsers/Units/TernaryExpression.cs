namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record TernaryExpression(IExpression conditional, IExpression trueResult, IExpression falseResult) : IExpression
{
    public string Serialize() => $"{conditional.Serialize()} ? {trueResult.Serialize()} : {falseResult.Serialize()}";
}
