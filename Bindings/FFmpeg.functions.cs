namespace Flyleaf.FFmpeg;

public unsafe static partial class Raw
{
    public static int AVERROR<T1>(T1 a)
        => -Convert.ToInt32(a);

    public static uint AV_VERSION_INT(uint a, uint b, uint c) => (a << 16) | (b << 8) | c;

    public static string AV_VERSION_DOT<T1, T2, T3>(T1 a, T2 b, T3 c) => $"{a}.{b}.{c}";

    public static string AV_VERSION<T1, T2, T3>(T1 a, T2 b, T3 c) => AV_VERSION_DOT(a, b, c);

    public static AVChannelLayout AV_CHANNEL_LAYOUT_MASK(int nb, ulong channel) => new()
    {
        order = AVChannelOrder.Native,
        nb_channels = nb,
        u = new AVChannelLayout_u
        {
            mask = channel
        }
    };

    public static int FFERRTAG<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d)
        => -(int)MKTAG(a, b, c, d);

    public static uint MKTAG<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d)
        => Convert.ToUInt32(a) | (Convert.ToUInt32(b) << 8) | (Convert.ToUInt32(c) << 16) | (Convert.ToUInt32(d) << 24);

    public static ulong UINT64_C<T>(T a)
        => Convert.ToUInt64(a);
}
