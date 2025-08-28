namespace Flyleaf.FFmpeg;

public unsafe static partial class Raw
{
    public const long                   NoTs            = long.MinValue;
    public static readonly int          TIME_BASE       = AV_TIME_BASE;
    public static readonly AVRational   TIME_BASE_Q     = new() { Num = 1, Den = TIME_BASE };

    public static readonly AVRational   TimebaseTicks   = new() { Num = 1, Den = 10_000_000 };
    public static readonly AVRational   TimebaseMcs     = new() { Num = 1, Den = TIME_BASE };
    public static readonly AVRational   TimebaseMs      = new() { Num = 1, Den = 1000 };

    #if OSX
    public const int EAGAIN = 35;
    #else
    public const int EAGAIN = 11;
    #endif
    public const int ENOMEM = 12;
    public const int EINVAL = 22;
    public const int EPIPE  = 32;

    public static readonly int AVERROR_EAGAIN = -EAGAIN;
    public static readonly int AVERROR_ENOMEM = -ENOMEM;
    public static readonly int AVERROR_EINVAL = -EINVAL;

    public const string AVCODEC    = "avcodec";
    public const string AVDEVICE   = "avdevice";
    public const string AVFILTER   = "avfilter";
    public const string AVFORMAT   = "avformat";
    public const string AVUTIL     = "avutil";
    public const string SWRESAMPLE = "swresample";
    public const string SWSCALE    = "swscale";

    public const OptFlags D     = OptFlags.DecodingParam;
    public const OptFlags E     = OptFlags.EncodingParam;
    public const OptFlags A     = OptFlags.AudioParam;
    public const OptFlags V     = OptFlags.VideoParam;
    public const OptFlags S     = OptFlags.SubtitleParam;
    public const OptFlags DE    = OptFlags.DecodingParam | OptFlags.EncodingParam;
    public const OptFlags DA    = OptFlags.DecodingParam | OptFlags.AudioParam;
    public const OptFlags DV    = OptFlags.DecodingParam | OptFlags.VideoParam;
    public const OptFlags DS    = OptFlags.DecodingParam | OptFlags.SubtitleParam;
    public const OptFlags EA    = OptFlags.EncodingParam | OptFlags.AudioParam;
    public const OptFlags EV    = OptFlags.EncodingParam | OptFlags.VideoParam;
    public const OptFlags ES    = OptFlags.EncodingParam | OptFlags.SubtitleParam;
    public const OptFlags AVS   = OptFlags.AudioParam    | OptFlags.VideoParam      | OptFlags.SubtitleParam;
}
