namespace Flyleaf.FFmpeg.Generator.ClangMarcroParsers.Units;

public record BinaryExpression(IExpression Left, string Op, IExpression Right) : IExpression
{
    public string Serialize() => $"{Left.Serialize()} {Op} {Right.Serialize()}";

    public bool IsBitwise => Op == "|" || Op == "&";
}
