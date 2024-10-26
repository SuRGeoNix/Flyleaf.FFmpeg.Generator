namespace Flyleaf.FFmpeg;

public struct AVCodecTag // libavformat/internal.h?
{
    public AVCodecID id;
    public uint tag;
}

public struct AVRational(int numerator, int denominator = 1)
{
    public static readonly AVRational Default = new(0, 1);
    
    public int Num = numerator;
    public int Den = denominator;

    public override readonly string ToString() => $"{Num}/{Den}";
    public override readonly bool Equals(object? obj) => obj is AVRational r && Equals(r);
    public readonly bool Equals(AVRational other) => this == other;
    public override readonly int GetHashCode() => HashCode.Combine(Num, Den);
    public readonly double ToDouble() => Num / (double)Den; // repeated in inline funcs
    public readonly uint ToIEEEFloat32() => av_q2intfloat(this);
    public unsafe readonly AVRational Reduce()
    {
        AVRational result = this;
        _ = av_reduce(&result.Num, &result.Den, Num, Den, int.MaxValue);
        return result;
    }
    public readonly AVRational Inverse() => new(Den, Num);

    public static AVRational FromDouble(double d, int max) => av_d2q(d, max);

    public static int Nearer(in AVRational q, in AVRational q1, in AVRational q2) => av_nearer_q(q, q1, q2);
    public static unsafe int FindNearestIndex(in AVRational q, AVRational* list) => av_find_nearest_q_idx(q, list);
    public static AVRational Gcd(in AVRational a, in AVRational b, int maxDenominator, AVRational def = default) => av_gcd_q(a, b, maxDenominator, def);

    public static bool operator > (in AVRational a, in AVRational b) => av_cmp_q(a, b)  > 0;
    public static bool operator < (in AVRational a, in AVRational b) => av_cmp_q(a, b)  < 0;
    public static bool operator ==(in AVRational a, in AVRational b) => av_cmp_q(a, b) == 0;
    public static bool operator !=(in AVRational a, in AVRational b) => av_cmp_q(a, b) != 0;
    public static unsafe AVRational operator *(AVRational b, in AVRational c)
    {
        _= av_reduce(&b.Num, &b.Den, b.Num * (long)c.Num, b.Den * (long)c.Den, int.MaxValue);
        return b;
    }
    public static unsafe AVRational operator *(AVRational b, long c)
    {
        _ = av_reduce(&b.Num, &b.Den, b.Num * c, b.Den * (long)1, int.MaxValue);
        return b;
    }
    public static AVRational operator /(in AVRational b, in AVRational c) => b * new AVRational(c.Den, c.Num);
    public static AVRational operator -(in AVRational b, in AVRational c) => b + new AVRational(-c.Num, c.Den);
    public static unsafe AVRational operator +(AVRational b, in AVRational c)
    {
        _ = av_reduce(&b.Num, &b.Den, b.Num * (long)c.Den + c.Num * (long)b.Den, b.Den * (long)c.Den, int.MaxValue);
        return b;
    }
}
