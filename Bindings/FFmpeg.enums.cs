namespace Flyleaf.FFmpeg;

#region Format
[Flags]
public enum DemuxerFlags : uint // TBR: CustomIO probably would be set automatically when pb != null
{
    None = FmtFlags2.None,

    /// <summary>The caller has supplied a custom AVIOContext, don't avio_close() it</summary>
    CustomIO        = FmtFlags2.CustomIo,
    /// <summary>Discard frames marked corrupted</summary>
    DiscardCorrupt  = FmtFlags2.DiscardCorrupt,
    /// <summary>Enable fast, but inaccurate seeks for some formats</summary>
    FastSeek        = FmtFlags2.FastSeek,
    /// <summary>Generate missing pts even if it requires parsing future frames</summary>
    GenPts          = FmtFlags2.Genpts,
    /// <summary>Ignore DTS on frames that contain both DTS &amp; PTS</summary>
    IgnDts          = FmtFlags2.Igndts,
    /// <summary>Ignore index.</summary>
    IgnIdx          = FmtFlags2.Ignidx,
    /// <summary>Do not block when reading packets from input</summary>
    NonBlock        = FmtFlags2.Nonblock,
    /// <summary>Do not buffer frames when possible</summary>
    NoBuffer        = FmtFlags2.Nobuffer,
    /// <summary>Do not infer any values from other values, just return what is stored in the container</summary>
    NoFillin        = FmtFlags2.Nofillin,
    /// <summary>Do not use AVParsers, you also must set AVFMT_FLAG_NOFILLIN as the fillin code works on frames and no parsing -&gt; no frames. Also seeking to frames can not work if parsing to find frame boundaries has been disabled</summary>
    NoParse         = FmtFlags2.Noparse,
    /// <summary>Try to interleave outputted packets by dts (using this flag can slow demuxing down)</summary>
    SortDts         = FmtFlags2.SortDts
}

[Flags]
public enum MuxerFlags : uint
{
    None = FmtFlags2.None,

    /// <summary>Add bitstream filters as requested by the muxer</summary>
    AutoBsf         = FmtFlags2.AutoBsf,
    /// <summary>When muxing, try to avoid writing any random/volatile data to the output. This includes any random IDs, real-time timestamps/dates, muxer version, etc. This flag is mainly intended for testing</summary>
    BitExact        = FmtFlags2.Bitexact,
    /// <summary>Flush the AVIOContext every packet</summary>
    FlushPackets    = FmtFlags2.FlushPackets,
    /// <summary>Stop muxing at the end of the shortest stream. It may be needed to increase max_interleave_delta to avoid flushing the longer streams before EOF.</summary>
    Shortest        = FmtFlags2.Shortest,
}

[Flags]
public enum DemuxerSpecFlags : uint
{
    /**
      * Can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_SHOW_IDS,
      * AVFMT_NOTIMESTAMPS, AVFMT_GENERIC_INDEX, AVFMT_TS_DISCONT, AVFMT_NOBINSEARCH,
      * AVFMT_NOGENSEARCH, AVFMT_NO_BYTE_SEEK, AVFMT_SEEK_TO_PTS.
      */
    None = FmtFlags.None,
    /// <summary>The muxer/demuxer is experimental and should be used with caution. For demuxer, will not be selected automatically by probing, must be specified explicitly</summary>
    Experimental    = FmtFlags.Experimental,
    /// <summary>Use generic index building code</summary>
    GenericIndex    = FmtFlags.GenericIndex,
    /// <summary>Needs '%d' in filename</summary>
    NeedNumber      = FmtFlags.Neednumber,
    /// <summary>Format does not allow to fall back on binary search via read_timestamp</summary>
    NoBinSearch     = FmtFlags.Nobinsearch,
    /// <summary>Format does not allow seeking by bytes</summary>
    NoByteSeek      = FmtFlags.NoByteSeek,
    /// <summary>Format does not allow to fall back on generic search</summary>
    NoGenSearch     = FmtFlags.Nogensearch,
    /// <summary>Demuxer will use avio_open, no opened file should be provided by the caller</summary>
    NoFile          = FmtFlags.Nofile,
    /// <summary>Format does not need / have any timestamps</summary>
    NoTimestamps    = FmtFlags.Notimestamps,
    /// <summary>Seeking is based on PTS</summary>
    SeekToPts       = FmtFlags.SeekToPts,
    /// <summary>Show format stream IDs numbers</summary>
    ShowIds         = FmtFlags.ShowIds,
    /// <summary>Format allows timestamp discontinuities. Note, muxers always require valid (monotone) timestamps</summary>
    TsDiscont       = FmtFlags.TsDiscont,
}

[Flags]
public enum MuxerSpecFlags : uint
{
    /**
      * can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER,
      * AVFMT_GLOBALHEADER, AVFMT_NOTIMESTAMPS, AVFMT_VARIABLE_FPS,
      * AVFMT_NODIMENSIONS, AVFMT_NOSTREAMS, AVFMT_ALLOW_FLUSH,
      * AVFMT_TS_NONSTRICT, AVFMT_TS_NEGATIVE
      */
    None = FmtFlags.None,
    /// <summary>Format allows flushing. If not set, the muxer will not receive a NULL packet in the write_packet function</summary>
    AllowFlush      = FmtFlags.AllowFlush,
    /// <summary>The muxer/demuxer is experimental and should be used with caution. For demuxer, will not be selected automatically by probing, must be specified explicitly</summary>
    Experimental    = FmtFlags.Experimental,
    /// <summary>Format wants global header</summary>
    GlobalHeader    = FmtFlags.Globalheader,
    /// <summary>Needs '%d' in filename</summary>
    NeedNumber      = FmtFlags.Neednumber,
    /// <summary>Format does not need width/height</summary>
    NoDimensions    = FmtFlags.Nodimensions,
    /// <summary>Demuxer will use avio_open, no opened file should be provided by the caller</summary>
    NoFile          = FmtFlags.Nofile,
    /// <summary>Format does not require any streams</summary>
    NoStreams       = FmtFlags.Nostreams,
    /// <summary>Format does not need / have any timestamps</summary>
    NoTimestamps    = FmtFlags.Notimestamps,
    /// <summary>Format allows muxing negative timestamps. If not set the timestamp will be shifted in av_write_frame and av_interleaved_write_frame so they start from 0. The user or muxer can override this through AVFormatContext.avoid_negative_ts</summary>
    TsNegative      = FmtFlags.TsNegative,
    /// <summary>Format does not require strictly increasing timestamps, but they must still be monotonic</summary>
    TsNonStrict     = FmtFlags.TsNonstrict,
    /// <summary>Format allows variable fps</summary>
    VariableFps     = FmtFlags.VariableFps,
}
#endregion

#region Codec
[Flags]
public enum AudioEncoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,

    // E VA (S?)
    GlobalHeader    = CodecFlags.GlobalHeader,

    // E VAS
    FrameDuration   = CodecFlags.FrameDuration,
    ReconFrame      = CodecFlags.ReconFrame,

}
[Flags]
public enum AudioDecoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,

    // D VA
    DropChanged     = CodecFlags.Dropchanged
}

[Flags]
public enum VideoEncoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,

    // E VA (S?)
    GlobalHeader    = CodecFlags.GlobalHeader,

    // E VAS
    FrameDuration   = CodecFlags.FrameDuration,
    ReconFrame      = CodecFlags.ReconFrame,

    // ED V
    Gray            = CodecFlags.Gray,
    LowDelay        = CodecFlags.LowDelay,

    ACPrediction    = CodecFlags.AcPred,
    ClosedGop       = CodecFlags.ClosedGop,
    InterlacedDct   = CodecFlags.InterlacedDct,
    InterlacedMe    = CodecFlags.InterlacedMe,
    LoopFilter      = CodecFlags.LoopFilter,
    MotionVectors4  = CodecFlags._4MV,
    PSNR            = CodecFlags.Psnr,
    QPEL            = CodecFlags.Qpel,
    Pass1           = CodecFlags.Pass1,
    Pass2           = CodecFlags.Pass2,
}

[Flags]
public enum VideoDecoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,

    // D VA
    DropChanged     = CodecFlags.Dropchanged,

    // ED V
    Gray            = CodecFlags.Gray,
    LowDelay        = CodecFlags.LowDelay,

    OutputCorrupt   = CodecFlags.OutputCorrupt,
    Unaligned       = CodecFlags.Unaligned,
}

[Flags]
public enum SubtitleEncoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,

    // E VAS
    FrameDuration   = CodecFlags.FrameDuration,
    ReconFrame      = CodecFlags.ReconFrame,

    // E VA (S?)
    GlobalHeader    = CodecFlags.GlobalHeader,
}

[Flags]
public enum SubtitleDecoderFlags : uint
{
    None = CodecFlags.None,

    // ED VAS
    BitExtract      = CodecFlags.Bitexact,
    CopyOpaque      = CodecFlags.CopyOpaque,
}

[Flags]
public enum AudioDecoderFlags2 : uint
{
    None = CodecFlags2.None,

    SkipManual      = CodecFlags2.SkipManual
}

[Flags]
public enum VideoEncoderFlags2 : uint
{
    None = CodecFlags2.None,

    Fast            = CodecFlags2.Fast,
    NoOutput        = CodecFlags2.NoOutput,
    LocalHeader     = CodecFlags2.LocalHeader
}

[Flags]
public enum VideoDecoderFlags2 : uint
{
    None = CodecFlags2.None,

    IgnoreCrop      = CodecFlags2.IgnoreCrop,
    Chunks          = CodecFlags2.Chunks,
    ShowAll         = CodecFlags2.ShowAll,
    ExportMvs       = CodecFlags2.ExportMvs,
}

[Flags]
public enum SubtitleDecoderFlags2 : uint
{
    None = CodecFlags2.None,

    AssROFlushNoop  = CodecFlags2.RoFlushNoop,
    ICCProfiles     = CodecFlags2.IccProfiles
}

[Flags]
public enum VASEncoderExportDataFlags
{
    None = CodecExportDataFlags.None,

    Prft            = CodecExportDataFlags.Prft
}

[Flags]
public enum VideoDecoderExportDataFlags
{
    None = CodecExportDataFlags.None,

    Mvs             = CodecExportDataFlags.Mvs,
    FilmGrain       = CodecExportDataFlags.FilmGrain,
    VideoEncParams  = CodecExportDataFlags.VideoEncParams,
    Enhancements    = CodecExportDataFlags.Enhancements
}

public enum SubtitleFormat : ushort
{
    Bitmap  = 0,
    Text    = 1
}
#endregion

// TBR: might use this as result from send/read packet/frame (format/codec/filter)
// Better a structure with helpers
//public enum FFmpegError
//{
//    None = 0,
//    BsfNotFound = -1179861752,
//    Bug = -558323010,
//    BufferTooSmall = -1397118274,
//    DecoderNotFound = -1128613112,
//    DemuxerNotFound = -1296385272,
//    EncoderNotFound = -1129203192,
//    Eof = -541478725,
//    Exit = -1414092869,
//    External = -542398533,
//    FilterNotFound = -1279870712,
//    Invaliddata = -1094995529,
//    MuxerNotFound = -1481985528,
//    OptionNotFound = -1414549496,
//    Patchwelcome = -1163346256,
//    ProtocolNotFound = -1330794744,
//    StreamNotFound = -1381258232,
//    Bug2 = -541545794,
//    Unknown = -1313558101,
//    Experimental = -0x2bb2afa8,
//    InputChanged = -0x636e6701,
//    OutputChanged = -0x636e6702,
//    HttpBadRequest = -808465656,
//    HttpUnauthorized = -825242872,
//    HttpForbidden = -858797304,
//    HttpNotFound = -875574520,
//    HttpTooManyRequests = -959591672,
//    HttpOther_4XX = -1482175736,
//    HttpServerError = -1482175992,

//    // + AVERROR<X> errno.h is os dependent (eg. for EAGAIN for win/linux is 11 while for MacOS is 35)
//    // Can use here NeedsMoreInput = _NOT_USED_ERROR_CODE_ {dynamic return EAGAIN}
//}