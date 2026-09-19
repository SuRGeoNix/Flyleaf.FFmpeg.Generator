namespace Flyleaf.FFmpeg;

public struct AVIndexEntry
{
    public long pos;
    /// <summary>Timestamp in AVStream.time_base units, preferably the time from which on correctly decoded frames are available when seeking to this entry. That means preferable PTS on keyframe based formats. But demuxers can choose to store a different timestamp, if it is more convenient for the implementation or nothing better is known</summary>
    public long timestamp;
    /// <summary>Flag is used to indicate which frame should be discarded after decoding.</summary>
    public int flags2_size30;
    /// <summary>Minimum distance between this and the previous keyframe, used to avoid unneeded searching.</summary>
    public int min_distance;

    public readonly IndexFlags Flags()
        => (IndexFlags) (flags2_size30 & 0b11);

    public readonly int Size()
       => flags2_size30 >> 2;
}

public struct AVRational(int numerator, int denominator = 1)
{
    public static readonly AVRational Zero = new(0, 1);
    
    public AVRational() : this(0, 1) { }

    public int Num = numerator;
    public int Den = denominator;

    public override readonly string ToString() => $"{Num}/{Den}";
    public override readonly bool Equals(object? obj) => obj is AVRational other && Equals(other);
    public readonly bool Equals(AVRational other) => this == other || (Num == 0 && Den == 0 && other.Num == 0 && other.Den == 0);
    public override readonly int GetHashCode()
    {
        long num = Num;
        long den = Den;

        if (den == 0)
            return HashCode.Combine(Math.Sign(num), 0L);

        if (den < 0)
        {
            num = -num;
            den = -den;
        }

        long a = Math.Abs(num);
        long b = den;

        while (b != 0)
        {
            long remainder = a % b;
            a = b;
            b = remainder;
        }

        return HashCode.Combine(num / a, den / a);
    }
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

    public static bool operator > (in AVRational a, in AVRational b) => av_cmp_q(a, b) ==  1;
    public static bool operator < (in AVRational a, in AVRational b) => av_cmp_q(a, b) == -1;
    public static bool operator ==(in AVRational a, in AVRational b) => av_cmp_q(a, b) ==  0;
    public static bool operator !=(in AVRational a, in AVRational b) => av_cmp_q(a, b) !=  0;
    public static unsafe AVRational operator *(AVRational b, in AVRational c)
    {
        _= av_reduce(&b.Num, &b.Den, b.Num * (long)c.Num, b.Den * (long)c.Den, int.MaxValue);
        return b;
    }
    public static unsafe AVRational operator *(AVRational b, long c)
    {
        long num = checked(b.Num * c);

        _ = av_reduce(&b.Num, &b.Den, num, b.Den, int.MaxValue);

        return b;
    }
    public static AVRational operator /(in AVRational b, in AVRational c) => b * new AVRational(c.Den, c.Num);
    public static unsafe AVRational operator -(AVRational b, in AVRational c)
    {
        _ = av_reduce(&b.Num, &b.Den, b.Num * (long)c.Den - c.Num * (long)b.Den, b.Den * (long)c.Den, int.MaxValue);
        return b;
    }
    public static unsafe AVRational operator +(AVRational b, in AVRational c)
    {
        long num = checked(b.Num * (long)c.Den + c.Num * (long)b.Den);

        _ = av_reduce(&b.Num, &b.Den, num, b.Den * (long)c.Den, int.MaxValue);

        return b;
    }
}
