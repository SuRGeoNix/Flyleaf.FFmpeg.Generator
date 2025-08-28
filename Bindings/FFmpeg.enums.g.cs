namespace Flyleaf.FFmpeg;

public enum AVActiveFormatDescription : int
{
    Same = 8,
    _4_3 = 9,
    _16_9 = 10,
    _14_9 = 11,
    _4_3Sp_14_9 = 13,
    _16_9Sp_14_9 = 14,
    Sp_4_3 = 15,
}

/// <summary>Message types used by avdevice_app_to_dev_control_message().</summary>
public enum AVAppToDevMessageType : int
{
    /// <summary>Dummy message.</summary>
    None = 1313820229,
    /// <summary>Window size change message.</summary>
    WindowSize = 1195724621,
    /// <summary>Repaint request message.</summary>
    WindowRepaint = 1380274241,
    /// <summary>Request pause/play.</summary>
    Pause = 1346458912,
    /// <summary>Request pause/play.</summary>
    Play = 1347174745,
    /// <summary>Request pause/play.</summary>
    TogglePause = 1346458964,
    /// <summary>Volume control message.</summary>
    SetVolume = 1398165324,
    /// <summary>Mute control messages.</summary>
    Mute = 541939028,
    /// <summary>Mute control messages.</summary>
    Unmute = 1431131476,
    /// <summary>Mute control messages.</summary>
    ToggleMute = 1414354260,
    /// <summary>Get volume/mute messages.</summary>
    GetVolume = 1196838732,
    /// <summary>Get volume/mute messages.</summary>
    GetMute = 1196250452,
}

public enum AVAudioServiceType : int
{
    Main = 0,
    Effects = 1,
    VisuallyImpaired = 2,
    HearingImpaired = 3,
    Dialogue = 4,
    Commentary = 5,
    Emergency = 6,
    VoiceOver = 7,
    Karaoke = 8,
    /// <summary>Not part of ABI</summary>
    Nb = 9,
}

/// <summary>@{</summary>
[Flags]
public enum AVBuffersrcFlag : int
{
    None = 0,
    /// <summary>Do not check for format changes.</summary>
    NoCheckFormat = 1,
    /// <summary>Immediately push the frame to the output.</summary>
    Push = 4,
    /// <summary>Keep a reference to the frame. If the frame if reference-counted, create a new reference; otherwise copy the frame data.</summary>
    KeepRef = 8,
}

/// <summary>Audio channel layout utility functions</summary>
public enum AVChannel : int
{
    /// <summary>Invalid channel index</summary>
    None = -1,
    /// <summary>Invalid channel index</summary>
    FrontLeft = 0,
    /// <summary>Invalid channel index</summary>
    FrontRight = 1,
    /// <summary>Invalid channel index</summary>
    FrontCenter = 2,
    /// <summary>Invalid channel index</summary>
    LowFrequency = 3,
    /// <summary>Invalid channel index</summary>
    BackLeft = 4,
    /// <summary>Invalid channel index</summary>
    BackRight = 5,
    /// <summary>Invalid channel index</summary>
    FrontLeftOfCenter = 6,
    /// <summary>Invalid channel index</summary>
    FrontRightOfCenter = 7,
    /// <summary>Invalid channel index</summary>
    BackCenter = 8,
    /// <summary>Invalid channel index</summary>
    SideLeft = 9,
    /// <summary>Invalid channel index</summary>
    SideRight = 10,
    /// <summary>Invalid channel index</summary>
    TopCenter = 11,
    /// <summary>Invalid channel index</summary>
    TopFrontLeft = 12,
    /// <summary>Invalid channel index</summary>
    TopFrontCenter = 13,
    /// <summary>Invalid channel index</summary>
    TopFrontRight = 14,
    /// <summary>Invalid channel index</summary>
    TopBackLeft = 15,
    /// <summary>Invalid channel index</summary>
    TopBackCenter = 16,
    /// <summary>Invalid channel index</summary>
    TopBackRight = 17,
    /// <summary>Stereo downmix.</summary>
    StereoLeft = 29,
    /// <summary>See above.</summary>
    StereoRight = 30,
    /// <summary>See above.</summary>
    WideLeft = 31,
    /// <summary>See above.</summary>
    WideRight = 32,
    /// <summary>See above.</summary>
    SurroundDirectLeft = 33,
    /// <summary>See above.</summary>
    SurroundDirectRight = 34,
    /// <summary>See above.</summary>
    LowFrequency_2 = 35,
    /// <summary>See above.</summary>
    TopSideLeft = 36,
    /// <summary>See above.</summary>
    TopSideRight = 37,
    /// <summary>See above.</summary>
    BottomFrontCenter = 38,
    /// <summary>See above.</summary>
    BottomFrontLeft = 39,
    /// <summary>See above.</summary>
    BottomFrontRight = 40,
    /// <summary>+90 degrees, Lss, SiL</summary>
    SideSurroundLeft = 41,
    /// <summary>-90 degrees, Rss, SiR</summary>
    SideSurroundRight = 42,
    /// <summary>+110 degrees, Lvs, TpLS</summary>
    TopSurroundLeft = 43,
    /// <summary>-110 degrees, Rvs, TpRS</summary>
    TopSurroundRight = 44,
    BinauralLeft = 61,
    BinauralRight = 62,
    /// <summary>Channel is empty can be safely skipped.</summary>
    Unused = 512,
    /// <summary>Channel contains data, but its position is unknown.</summary>
    Unknown = 768,
    /// <summary>Range of channels between AV_CHAN_AMBISONIC_BASE and AV_CHAN_AMBISONIC_END represent Ambisonic components using the ACN system.</summary>
    AmbisonicBase = 1024,
    /// <summary>Range of channels between AV_CHAN_AMBISONIC_BASE and AV_CHAN_AMBISONIC_END represent Ambisonic components using the ACN system.</summary>
    AmbisonicEnd = 2047,
}

public enum AVChannelOrder : int
{
    /// <summary>Only the channel count is specified, without any further information about the channel order.</summary>
    Unspec = 0,
    /// <summary>The native channel order, i.e. the channels are in the same order in which they are defined in the AVChannel enum. This supports up to 63 different channels.</summary>
    Native = 1,
    /// <summary>The channel order does not correspond to any other predefined order and is stored as an explicit map. For example, this could be used to support layouts with 64 or more channels, or with empty/skipped (AV_CHAN_UNUSED) channels at arbitrary positions.</summary>
    Custom = 2,
    /// <summary>The audio is represented as the decomposition of the sound field into spherical harmonics. Each channel corresponds to a single expansion component. Channels are ordered according to ACN (Ambisonic Channel Number).</summary>
    Ambisonic = 3,
    /// <summary>Number of channel orders, not part of ABI/API</summary>
    FfChannelOrderNb = 4,
}

/// <summary>Location of chroma samples.</summary>
public enum AVChromaLocation : int
{
    Unspecified = 0,
    /// <summary>MPEG-2/4 4:2:0, H.264 default for 4:2:0</summary>
    Left = 1,
    /// <summary>MPEG-1 4:2:0, JPEG 4:2:0, H.263 4:2:0</summary>
    Center = 2,
    /// <summary>ITU-R 601, SMPTE 274M 296M S314M(DV 4:1:1), mpeg2 4:2:2</summary>
    Topleft = 3,
    Top = 4,
    Bottomleft = 5,
    Bottom = 6,
    /// <summary>Not part of ABI</summary>
    Nb = 7,
}

public enum AVClassCategory : int
{
    Na = 0,
    Input = 1,
    Output = 2,
    Muxer = 3,
    Demuxer = 4,
    Encoder = 5,
    Decoder = 6,
    Filter = 7,
    BitstreamFilter = 8,
    Swscaler = 9,
    Swresampler = 10,
    Hwdevice = 11,
    DeviceVideoOutput = 40,
    DeviceVideoInput = 41,
    DeviceAudioOutput = 42,
    DeviceAudioInput = 43,
    DeviceOutput = 44,
    DeviceInput = 45,
    /// <summary>not part of ABI/API</summary>
    Nb = 46,
}

[Flags]
public enum AVClassStateFlags : int
{
    None = 0,
    /// <summary>Object initialization has finished and it is now in the &apos;runtime&apos; stage. This affects e.g. what options can be set on the object (only AV_OPT_FLAG_RUNTIME_PARAM options can be set on initialized objects).</summary>
    Initialized = 1,
}

public enum AVCodecConfig : int
{
    /// <summary>AVPixelFormat, terminated by AV_PIX_FMT_NONE</summary>
    PixFormat = 0,
    /// <summary>AVRational, terminated by {0, 0}</summary>
    FrameRate = 1,
    /// <summary>int, terminated by 0</summary>
    SampleRate = 2,
    /// <summary>AVSampleFormat, terminated by AV_SAMPLE_FMT_NONE</summary>
    SampleFormat = 3,
    /// <summary>AVChannelLayout, terminated by {0}</summary>
    ChannelLayout = 4,
    /// <summary>AVColorRange, terminated by AVCOL_RANGE_UNSPECIFIED</summary>
    ColorRange = 5,
    /// <summary>AVColorSpace, terminated by AVCOL_SPC_UNSPECIFIED</summary>
    ColorSpace = 6,
}

[Flags]
public enum AVCodecHwConfigMethod : int
{
    None = 0,
    /// <summary>The codec supports this format via the hw_device_ctx interface.</summary>
    HwDeviceCtx = 1,
    /// <summary>The codec supports this format via the hw_frames_ctx interface.</summary>
    HwFramesCtx = 2,
    /// <summary>The codec supports this format by some internal method.</summary>
    Internal = 4,
    /// <summary>The codec supports this format by some ad-hoc method.</summary>
    AdHoc = 8,
}

/// <summary>Identify the syntax and semantics of the bitstream. The principle is roughly: Two decoders with the same ID can decode the same streams. Two encoders with the same ID can encode compatible streams. There may be slight deviations from the principle due to implementation details.</summary>
public enum AVCodecID : int
{
    None = 0,
    Mpeg1video = 1,
    /// <summary>preferred ID for MPEG-1/2 video decoding</summary>
    Mpeg2video = 2,
    H261 = 3,
    H263 = 4,
    Rv10 = 5,
    Rv20 = 6,
    Mjpeg = 7,
    Mjpegb = 8,
    Ljpeg = 9,
    Sp5x = 10,
    Jpegls = 11,
    Mpeg4 = 12,
    Rawvideo = 13,
    Msmpeg4v1 = 14,
    Msmpeg4v2 = 15,
    Msmpeg4v3 = 16,
    Wmv1 = 17,
    Wmv2 = 18,
    H263p = 19,
    H263i = 20,
    Flv1 = 21,
    Svq1 = 22,
    Svq3 = 23,
    Dvvideo = 24,
    Huffyuv = 25,
    Cyuv = 26,
    H264 = 27,
    Indeo3 = 28,
    Vp3 = 29,
    Theora = 30,
    Asv1 = 31,
    Asv2 = 32,
    Ffv1 = 33,
    _4XM = 34,
    Vcr1 = 35,
    Cljr = 36,
    Mdec = 37,
    Roq = 38,
    InterplayVideo = 39,
    XanWc3 = 40,
    XanWc4 = 41,
    Rpza = 42,
    Cinepak = 43,
    WsVqa = 44,
    Msrle = 45,
    Msvideo1 = 46,
    Idcin = 47,
    _8BPS = 48,
    Smc = 49,
    Flic = 50,
    Truemotion1 = 51,
    Vmdvideo = 52,
    Mszh = 53,
    Zlib = 54,
    Qtrle = 55,
    Tscc = 56,
    Ulti = 57,
    Qdraw = 58,
    Vixl = 59,
    Qpeg = 60,
    Png = 61,
    Ppm = 62,
    Pbm = 63,
    Pgm = 64,
    Pgmyuv = 65,
    Pam = 66,
    Ffvhuff = 67,
    Rv30 = 68,
    Rv40 = 69,
    Vc1 = 70,
    Wmv3 = 71,
    Loco = 72,
    Wnv1 = 73,
    Aasc = 74,
    Indeo2 = 75,
    Fraps = 76,
    Truemotion2 = 77,
    Bmp = 78,
    Cscd = 79,
    Mmvideo = 80,
    Zmbv = 81,
    Avs = 82,
    Smackvideo = 83,
    Nuv = 84,
    Kmvc = 85,
    Flashsv = 86,
    Cavs = 87,
    Jpeg2000 = 88,
    Vmnc = 89,
    Vp5 = 90,
    Vp6 = 91,
    Vp6f = 92,
    Targa = 93,
    Dsicinvideo = 94,
    Tiertexseqvideo = 95,
    Tiff = 96,
    Gif = 97,
    Dxa = 98,
    Dnxhd = 99,
    Thp = 100,
    Sgi = 101,
    C93 = 102,
    Bethsoftvid = 103,
    Ptx = 104,
    Txd = 105,
    Vp6a = 106,
    Amv = 107,
    Vb = 108,
    Pcx = 109,
    Sunrast = 110,
    Indeo4 = 111,
    Indeo5 = 112,
    Mimic = 113,
    Rl2 = 114,
    Escape124 = 115,
    Dirac = 116,
    Bfi = 117,
    Cmv = 118,
    Motionpixels = 119,
    Tgv = 120,
    Tgq = 121,
    Tqi = 122,
    Aura = 123,
    Aura2 = 124,
    V210x = 125,
    Tmv = 126,
    V210 = 127,
    Dpx = 128,
    Mad = 129,
    Frwu = 130,
    Flashsv2 = 131,
    Cdgraphics = 132,
    R210 = 133,
    Anm = 134,
    Binkvideo = 135,
    IffIlbm = 136,
    Kgv1 = 137,
    Yop = 138,
    Vp8 = 139,
    Pictor = 140,
    Ansi = 141,
    A64Multi = 142,
    A64Multi5 = 143,
    R10k = 144,
    Mxpeg = 145,
    Lagarith = 146,
    Prores = 147,
    Jv = 148,
    Dfa = 149,
    Wmv3image = 150,
    Vc1image = 151,
    Utvideo = 152,
    BmvVideo = 153,
    Vble = 154,
    Dxtory = 155,
    V410 = 156,
    Xwd = 157,
    Cdxl = 158,
    Xbm = 159,
    Zerocodec = 160,
    Mss1 = 161,
    Msa1 = 162,
    Tscc2 = 163,
    Mts2 = 164,
    Cllc = 165,
    Mss2 = 166,
    Vp9 = 167,
    Aic = 168,
    Escape130 = 169,
    G2m = 170,
    Webp = 171,
    Hnm4Video = 172,
    Hevc = 173,
    Fic = 174,
    AliasPix = 175,
    BrenderPix = 176,
    PafVideo = 177,
    Exr = 178,
    Vp7 = 179,
    Sanm = 180,
    Sgirle = 181,
    Mvc1 = 182,
    Mvc2 = 183,
    Hqx = 184,
    Tdsc = 185,
    HqHqa = 186,
    Hap = 187,
    Dds = 188,
    Dxv = 189,
    Screenpresso = 190,
    Rscc = 191,
    Avs2 = 192,
    Pgx = 193,
    Avs3 = 194,
    Msp2 = 195,
    Vvc = 196,
    Y41p = 197,
    Avrp = 198,
    _012V = 199,
    Avui = 200,
    TargaY216 = 201,
    V308 = 202,
    V408 = 203,
    Yuv4 = 204,
    Avrn = 205,
    Cpia = 206,
    Xface = 207,
    Snow = 208,
    Smvjpeg = 209,
    Apng = 210,
    Daala = 211,
    Cfhd = 212,
    Truemotion2rt = 213,
    M101 = 214,
    Magicyuv = 215,
    Sheervideo = 216,
    Ylc = 217,
    Psd = 218,
    Pixlet = 219,
    Speedhq = 220,
    Fmvc = 221,
    Scpr = 222,
    Clearvideo = 223,
    Xpm = 224,
    Av1 = 225,
    Bitpacked = 226,
    Mscc = 227,
    Srgc = 228,
    Svg = 229,
    Gdv = 230,
    Fits = 231,
    Imm4 = 232,
    Prosumer = 233,
    Mwsc = 234,
    Wcmv = 235,
    Rasc = 236,
    Hymt = 237,
    Arbc = 238,
    Agm = 239,
    Lscr = 240,
    Vp4 = 241,
    Imm5 = 242,
    Mvdv = 243,
    Mvha = 244,
    Cdtoons = 245,
    Mv30 = 246,
    Notchlc = 247,
    Pfm = 248,
    Mobiclip = 249,
    Photocd = 250,
    Ipu = 251,
    Argo = 252,
    Cri = 253,
    SimbiosisImx = 254,
    SgaVideo = 255,
    Gem = 256,
    Vbn = 257,
    Jpegxl = 258,
    Qoi = 259,
    Phm = 260,
    RadianceHdr = 261,
    Wbmp = 262,
    Media100 = 263,
    Vqc = 264,
    Pdv = 265,
    Evc = 266,
    Rtv1 = 267,
    Vmix = 268,
    Lead = 269,
    Dnxuc = 270,
    Rv60 = 271,
    JpegxlAnim = 272,
    Apv = 273,
    ProresRaw = 274,
    /// <summary>A dummy id pointing at the start of audio codecs</summary>
    FirstAudio = 65536,
    PcmS16le = 65536,
    PcmS16be = 65537,
    PcmU16le = 65538,
    PcmU16be = 65539,
    PcmS8 = 65540,
    PcmU8 = 65541,
    PcmMulaw = 65542,
    PcmAlaw = 65543,
    PcmS32le = 65544,
    PcmS32be = 65545,
    PcmU32le = 65546,
    PcmU32be = 65547,
    PcmS24le = 65548,
    PcmS24be = 65549,
    PcmU24le = 65550,
    PcmU24be = 65551,
    PcmS24daud = 65552,
    PcmZork = 65553,
    PcmS16lePlanar = 65554,
    PcmDvd = 65555,
    PcmF32be = 65556,
    PcmF32le = 65557,
    PcmF64be = 65558,
    PcmF64le = 65559,
    PcmBluray = 65560,
    PcmLxf = 65561,
    S302m = 65562,
    PcmS8Planar = 65563,
    PcmS24lePlanar = 65564,
    PcmS32lePlanar = 65565,
    PcmS16bePlanar = 65566,
    PcmS64le = 65567,
    PcmS64be = 65568,
    PcmF16le = 65569,
    PcmF24le = 65570,
    PcmVidc = 65571,
    PcmSga = 65572,
    AdpcmImaQt = 69632,
    AdpcmImaWav = 69633,
    AdpcmImaDk3 = 69634,
    AdpcmImaDk4 = 69635,
    AdpcmImaWs = 69636,
    AdpcmImaSmjpeg = 69637,
    AdpcmMs = 69638,
    Adpcm_4XM = 69639,
    AdpcmXa = 69640,
    AdpcmAdx = 69641,
    AdpcmEa = 69642,
    AdpcmG726 = 69643,
    AdpcmCt = 69644,
    AdpcmSwf = 69645,
    AdpcmYamaha = 69646,
    AdpcmSbpro_4 = 69647,
    AdpcmSbpro_3 = 69648,
    AdpcmSbpro_2 = 69649,
    AdpcmThp = 69650,
    AdpcmImaAmv = 69651,
    AdpcmEaR1 = 69652,
    AdpcmEaR3 = 69653,
    AdpcmEaR2 = 69654,
    AdpcmImaEaSead = 69655,
    AdpcmImaEaEacs = 69656,
    AdpcmEaXas = 69657,
    AdpcmEaMaxisXa = 69658,
    AdpcmImaIss = 69659,
    AdpcmG722 = 69660,
    AdpcmImaApc = 69661,
    AdpcmVima = 69662,
    AdpcmAfc = 69663,
    AdpcmImaOki = 69664,
    AdpcmDtk = 69665,
    AdpcmImaRad = 69666,
    AdpcmG726le = 69667,
    AdpcmThpLe = 69668,
    AdpcmPsx = 69669,
    AdpcmAica = 69670,
    AdpcmImaDat4 = 69671,
    AdpcmMtaf = 69672,
    AdpcmAgm = 69673,
    AdpcmArgo = 69674,
    AdpcmImaSsi = 69675,
    AdpcmZork = 69676,
    AdpcmImaApm = 69677,
    AdpcmImaAlp = 69678,
    AdpcmImaMtf = 69679,
    AdpcmImaCunning = 69680,
    AdpcmImaMoflex = 69681,
    AdpcmImaAcorn = 69682,
    AdpcmXmd = 69683,
    AdpcmImaXbox = 69684,
    AdpcmSanyo = 69685,
    AmrNb = 73728,
    AmrWb = 73729,
    Ra_144 = 77824,
    Ra_288 = 77825,
    RoqDpcm = 81920,
    InterplayDpcm = 81921,
    XanDpcm = 81922,
    SolDpcm = 81923,
    Sdx2Dpcm = 81924,
    GremlinDpcm = 81925,
    DerfDpcm = 81926,
    WadyDpcm = 81927,
    Cbd2Dpcm = 81928,
    Mp2 = 86016,
    /// <summary>preferred ID for decoding MPEG audio layer 1, 2 or 3</summary>
    Mp3 = 86017,
    Aac = 86018,
    Ac3 = 86019,
    Dts = 86020,
    Vorbis = 86021,
    Dvaudio = 86022,
    Wmav1 = 86023,
    Wmav2 = 86024,
    Mace3 = 86025,
    Mace6 = 86026,
    Vmdaudio = 86027,
    Flac = 86028,
    Mp3adu = 86029,
    Mp3on4 = 86030,
    Shorten = 86031,
    Alac = 86032,
    WestwoodSnd1 = 86033,
    /// <summary>as in Berlin toast format</summary>
    Gsm = 86034,
    Qdm2 = 86035,
    Cook = 86036,
    Truespeech = 86037,
    Tta = 86038,
    Smackaudio = 86039,
    Qcelp = 86040,
    Wavpack = 86041,
    Dsicinaudio = 86042,
    Imc = 86043,
    Musepack7 = 86044,
    Mlp = 86045,
    GsmMs = 86046,
    Atrac3 = 86047,
    Ape = 86048,
    Nellymoser = 86049,
    Musepack8 = 86050,
    Speex = 86051,
    Wmavoice = 86052,
    Wmapro = 86053,
    Wmalossless = 86054,
    Atrac3p = 86055,
    Eac3 = 86056,
    Sipr = 86057,
    Mp1 = 86058,
    Twinvq = 86059,
    Truehd = 86060,
    Mp4als = 86061,
    Atrac1 = 86062,
    BinkaudioRdft = 86063,
    BinkaudioDct = 86064,
    AacLatm = 86065,
    Qdmc = 86066,
    Celt = 86067,
    G723_1 = 86068,
    G729 = 86069,
    _8SVXExp = 86070,
    _8SVXFib = 86071,
    BmvAudio = 86072,
    Ralf = 86073,
    Iac = 86074,
    Ilbc = 86075,
    Opus = 86076,
    ComfortNoise = 86077,
    Tak = 86078,
    Metasound = 86079,
    PafAudio = 86080,
    On2avc = 86081,
    DssSp = 86082,
    Codec2 = 86083,
    Ffwavesynth = 86084,
    Sonic = 86085,
    SonicLs = 86086,
    Evrc = 86087,
    Smv = 86088,
    DsdLsbf = 86089,
    DsdMsbf = 86090,
    DsdLsbfPlanar = 86091,
    DsdMsbfPlanar = 86092,
    _4GV = 86093,
    InterplayAcm = 86094,
    Xma1 = 86095,
    Xma2 = 86096,
    Dst = 86097,
    Atrac3al = 86098,
    Atrac3pal = 86099,
    DolbyE = 86100,
    Aptx = 86101,
    AptxHd = 86102,
    Sbc = 86103,
    Atrac9 = 86104,
    Hcom = 86105,
    AcelpKelvin = 86106,
    Mpegh_3DAudio = 86107,
    Siren = 86108,
    Hca = 86109,
    Fastaudio = 86110,
    Msnsiren = 86111,
    Dfpwm = 86112,
    Bonk = 86113,
    Misc4 = 86114,
    Apac = 86115,
    Ftr = 86116,
    Wavarc = 86117,
    Rka = 86118,
    Ac4 = 86119,
    Osq = 86120,
    Qoa = 86121,
    Lc3 = 86122,
    G728 = 86123,
    /// <summary>A dummy ID pointing at the start of subtitle codecs.</summary>
    FirstSubtitle = 94208,
    DvdSubtitle = 94208,
    DvbSubtitle = 94209,
    /// <summary>raw UTF-8 text</summary>
    Text = 94210,
    Xsub = 94211,
    Ssa = 94212,
    MovText = 94213,
    HdmvPgsSubtitle = 94214,
    DvbTeletext = 94215,
    Srt = 94216,
    Microdvd = 94217,
    Eia_608 = 94218,
    Jacosub = 94219,
    Sami = 94220,
    Realtext = 94221,
    Stl = 94222,
    Subviewer1 = 94223,
    Subviewer = 94224,
    Subrip = 94225,
    Webvtt = 94226,
    Mpl2 = 94227,
    Vplayer = 94228,
    Pjs = 94229,
    Ass = 94230,
    HdmvTextSubtitle = 94231,
    Ttml = 94232,
    AribCaption = 94233,
    IvtvVbi = 94234,
    /// <summary>A dummy ID pointing at the start of various fake codecs.</summary>
    FirstUnknown = 98304,
    Ttf = 98304,
    /// <summary>Contain timestamp estimated through PCR of program stream.</summary>
    Scte_35 = 98305,
    Epg = 98306,
    Bintext = 98307,
    Xbin = 98308,
    Idf = 98309,
    Otf = 98310,
    SmpteKlv = 98311,
    DvdNav = 98312,
    TimedId3 = 98313,
    BinData = 98314,
    Smpte_2038 = 98315,
    Lcevc = 98316,
    Smpte_436MAnc = 98317,
    /// <summary>codec_id is not known (like AV_CODEC_ID_NONE) but lavf should attempt to identify it</summary>
    Probe = 102400,
    /// <summary>_FAKE_ codec to indicate a raw MPEG-2 TS stream (only used by libavformat)</summary>
    Mpeg2ts = 131072,
    /// <summary>_FAKE_ codec to indicate a MPEG-4 Systems stream (only used by libavformat)</summary>
    Mpeg4systems = 131073,
    /// <summary>Dummy codec for streams containing only metadata information.</summary>
    Ffmetadata = 135168,
    /// <summary>Passthrough codec, AVFrames wrapped in AVPacket</summary>
    WrappedAvframe = 135169,
    /// <summary>Dummy null video codec, useful mainly for development and debugging. Null encoder/decoder discard all input and never return any output.</summary>
    Vnull = 135170,
    /// <summary>Dummy null audio codec, useful mainly for development and debugging. Null encoder/decoder discard all input and never return any output.</summary>
    Anull = 135171,
}

/// <summary>Chromaticity coordinates of the source primaries. These values match the ones defined by ISO/IEC 23091-2_2019 subclause 8.1 and ITU-T H.273.</summary>
public enum AVColorPrimaries : int
{
    Reserved0 = 0,
    /// <summary>also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP 177 Annex B</summary>
    Bt709 = 1,
    Unspecified = 2,
    Reserved = 3,
    /// <summary>also FCC Title 47 Code of Federal Regulations 73.682 (a)(20)</summary>
    Bt470m = 4,
    /// <summary>also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL &amp; SECAM</summary>
    Bt470bg = 5,
    /// <summary>also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC</summary>
    Smpte170m = 6,
    /// <summary>identical to above, also called &quot;SMPTE C&quot; even though it uses D65</summary>
    Smpte240m = 7,
    /// <summary>colour filters using Illuminant C</summary>
    Film = 8,
    /// <summary>ITU-R BT2020</summary>
    Bt2020 = 9,
    /// <summary>SMPTE ST 428-1 (CIE 1931 XYZ)</summary>
    Smpte428 = 10,
    Smptest428_1 = 10,
    /// <summary>SMPTE ST 431-2 (2011) / DCI P3</summary>
    Smpte431 = 11,
    /// <summary>SMPTE ST 432-1 (2010) / P3 D65 / Display P3</summary>
    Smpte432 = 12,
    /// <summary>EBU Tech. 3213-E (nothing there) / one of JEDEC P22 group phosphors</summary>
    Ebu3213 = 22,
    JedecP22 = 22,
    /// <summary>Not part of ABI</summary>
    Nb = 23,
}

/// <summary>Visual content value range.</summary>
public enum AVColorRange : int
{
    Unspecified = 0,
    /// <summary>Narrow or limited range content.</summary>
    Mpeg = 1,
    /// <summary>Full range content.</summary>
    Jpeg = 2,
    /// <summary>Not part of ABI</summary>
    Nb = 3,
}

/// <summary>YUV colorspace type. These values match the ones defined by ISO/IEC 23091-2_2019 subclause 8.3.</summary>
public enum AVColorSpace : int
{
    /// <summary>order of coefficients is actually GBR, also IEC 61966-2-1 (sRGB), YZX and ST 428-1</summary>
    Rgb = 0,
    /// <summary>also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / derived in SMPTE RP 177 Annex B</summary>
    Bt709 = 1,
    Unspecified = 2,
    /// <summary>reserved for future use by ITU-T and ISO/IEC just like 15-255 are</summary>
    Reserved = 3,
    /// <summary>FCC Title 47 Code of Federal Regulations 73.682 (a)(20)</summary>
    Fcc = 4,
    /// <summary>also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL &amp; SECAM / IEC 61966-2-4 xvYCC601</summary>
    Bt470bg = 5,
    /// <summary>also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC / functionally identical to above</summary>
    Smpte170m = 6,
    /// <summary>derived from 170M primaries and D65 white point, 170M is derived from BT470 System M&apos;s primaries</summary>
    Smpte240m = 7,
    /// <summary>used by Dirac / VC-2 and H.264 FRext, see ITU-T SG16</summary>
    Ycgco = 8,
    Ycocg = 8,
    /// <summary>ITU-R BT2020 non-constant luminance system</summary>
    Bt2020Ncl = 9,
    /// <summary>ITU-R BT2020 constant luminance system</summary>
    Bt2020Cl = 10,
    /// <summary>SMPTE 2085, Y&apos;D&apos;zD&apos;x</summary>
    Smpte2085 = 11,
    /// <summary>Chromaticity-derived non-constant luminance system</summary>
    ChromaDerivedNcl = 12,
    /// <summary>Chromaticity-derived constant luminance system</summary>
    ChromaDerivedCl = 13,
    /// <summary>ITU-R BT.2100-0, ICtCp</summary>
    Ictcp = 14,
    /// <summary>SMPTE ST 2128, IPT-C2</summary>
    IptC2 = 15,
    /// <summary>YCgCo-R, even addition of bits</summary>
    YcgcoRe = 16,
    /// <summary>YCgCo-R, odd addition of bits</summary>
    YcgcoRo = 17,
    /// <summary>Not part of ABI</summary>
    Nb = 18,
}

/// <summary>Color Transfer Characteristic. These values match the ones defined by ISO/IEC 23091-2_2019 subclause 8.2.</summary>
public enum AVColorTransferCharacteristic : int
{
    Reserved0 = 0,
    /// <summary>also ITU-R BT1361</summary>
    Bt709 = 1,
    Unspecified = 2,
    Reserved = 3,
    /// <summary>also ITU-R BT470M / ITU-R BT1700 625 PAL &amp; SECAM</summary>
    Gamma22 = 4,
    /// <summary>also ITU-R BT470BG</summary>
    Gamma28 = 5,
    /// <summary>also ITU-R BT601-6 525 or 625 / ITU-R BT1358 525 or 625 / ITU-R BT1700 NTSC</summary>
    Smpte170m = 6,
    Smpte240m = 7,
    /// <summary>&quot;Linear transfer characteristics&quot;</summary>
    Linear = 8,
    /// <summary>&quot;Logarithmic transfer characteristic (100:1 range)&quot;</summary>
    Log = 9,
    /// <summary>&quot;Logarithmic transfer characteristic (100 * Sqrt(10) : 1 range)&quot;</summary>
    LogSqrt = 10,
    /// <summary>IEC 61966-2-4</summary>
    Iec61966_2_4 = 11,
    /// <summary>ITU-R BT1361 Extended Colour Gamut</summary>
    Bt1361Ecg = 12,
    /// <summary>IEC 61966-2-1 (sRGB or sYCC)</summary>
    Iec61966_2_1 = 13,
    /// <summary>ITU-R BT2020 for 10-bit system</summary>
    Bt2020_10 = 14,
    /// <summary>ITU-R BT2020 for 12-bit system</summary>
    Bt2020_12 = 15,
    /// <summary>SMPTE ST 2084 for 10-, 12-, 14- and 16-bit systems</summary>
    Smpte2084 = 16,
    Smptest2084 = 16,
    /// <summary>SMPTE ST 428-1</summary>
    Smpte428 = 17,
    Smptest428_1 = 17,
    /// <summary>ARIB STD-B67, known as &quot;Hybrid log-gamma&quot;</summary>
    AribStdB67 = 18,
    /// <summary>Not part of ABI</summary>
    Nb = 19,
}

/// <summary>Message types used by avdevice_dev_to_app_control_message().</summary>
public enum AVDevToAppMessageType : int
{
    /// <summary>Dummy message.</summary>
    None = 1313820229,
    /// <summary>Create window buffer message.</summary>
    CreateWindowBuffer = 1111708229,
    /// <summary>Prepare window buffer message.</summary>
    PrepareWindowBuffer = 1112560197,
    /// <summary>Display window buffer message.</summary>
    DisplayWindowBuffer = 1111771475,
    /// <summary>Destroy window buffer message.</summary>
    DestroyWindowBuffer = 1111770451,
    /// <summary>Buffer fullness status messages.</summary>
    BufferOverflow = 1112491596,
    /// <summary>Buffer fullness status messages.</summary>
    BufferUnderflow = 1112884812,
    /// <summary>Buffer readable/writable.</summary>
    BufferReadable = 1112687648,
    /// <summary>Buffer readable/writable.</summary>
    BufferWritable = 1113018912,
    /// <summary>Mute state change message.</summary>
    MuteStateChanged = 1129141588,
    /// <summary>Volume level change message.</summary>
    VolumeLevelChanged = 1129729868,
}

public enum AVDiscard : int
{
    /// <summary>discard nothing</summary>
    None = -16,
    /// <summary>discard useless packets like 0 size packets in avi</summary>
    Default = 0,
    /// <summary>discard all non reference</summary>
    Nonref = 8,
    /// <summary>discard all bidirectional frames</summary>
    Bidir = 16,
    /// <summary>discard all non intra frames</summary>
    Nonintra = 24,
    /// <summary>discard all frames except keyframes</summary>
    Nonkey = 32,
    /// <summary>discard all</summary>
    All = 48,
}

/// <summary>The duration of a video can be estimated through various ways, and this enum can be used to know how the duration was estimated.</summary>
public enum AVDurationEstimationMethod : int
{
    /// <summary>Duration accurately estimated from PTSes</summary>
    Pts = 0,
    /// <summary>Duration estimated from a stream with a known duration</summary>
    Stream = 1,
    /// <summary>Duration estimated from bitrate (less accurate)</summary>
    Bitrate = 2,
}

public enum AVFieldOrder : int
{
    Unknown = 0,
    Progressive = 1,
    /// <summary>Top coded_first, top displayed first</summary>
    Tt = 2,
    /// <summary>Bottom coded first, bottom displayed first</summary>
    Bb = 3,
    /// <summary>Top coded first, bottom displayed first</summary>
    Tb = 4,
    /// <summary>Bottom coded first, top displayed first</summary>
    Bt = 5,
}

[Flags]
public enum AVfilterAutoConvert : int
{
    /// <summary>all automatic conversions enabled</summary>
    All = 0,
    /// <summary>all automatic conversions disabled</summary>
    None = -1,
}

/// <summary>Flags for frame cropping.</summary>
[Flags]
public enum AVFrameCrop : int
{
    None = 0,
    /// <summary>Apply the maximum possible cropping, even if it requires setting the AVFrame.data[] entries to unaligned pointers. Passing unaligned data to FFmpeg API is generally not allowed, and causes undefined behavior (such as crashes). You can pass unaligned data only to FFmpeg APIs that are explicitly documented to accept it. Use this flag only if you absolutely know what you are doing.</summary>
    Unaligned = 1,
}

/// <summary>@{ AVFrame is an abstraction for reference-counted raw multimedia data.</summary>
public enum AVFrameSideDataType : int
{
    /// <summary>The data is the AVPanScan struct defined in libavcodec.</summary>
    Panscan = 0,
    /// <summary>ATSC A53 Part 4 Closed Captions. A53 CC bitstream is stored as uint8_t in AVFrameSideData.data. The number of bytes of CC data is AVFrameSideData.size.</summary>
    A53Cc = 1,
    /// <summary>Stereoscopic 3d metadata. The data is the AVStereo3D struct defined in libavutil/stereo3d.h.</summary>
    Stereo3d = 2,
    /// <summary>The data is the AVMatrixEncoding enum defined in libavutil/channel_layout.h.</summary>
    Matrixencoding = 3,
    /// <summary>Metadata relevant to a downmix procedure. The data is the AVDownmixInfo struct defined in libavutil/downmix_info.h.</summary>
    DownmixInfo = 4,
    /// <summary>ReplayGain information in the form of the AVReplayGain struct.</summary>
    Replaygain = 5,
    /// <summary>This side data contains a 3x3 transformation matrix describing an affine transformation that needs to be applied to the frame for correct presentation.</summary>
    Displaymatrix = 6,
    /// <summary>Active Format Description data consisting of a single byte as specified in ETSI TS 101 154 using AVActiveFormatDescription enum.</summary>
    Afd = 7,
    /// <summary>Motion vectors exported by some codecs (on demand through the export_mvs flag set in the libavcodec AVCodecContext flags2 option). The data is the AVMotionVector struct defined in libavutil/motion_vector.h.</summary>
    MotionVectors = 8,
    /// <summary>Recommends skipping the specified number of samples. This is exported only if the &quot;skip_manual&quot; AVOption is set in libavcodec. This has the same format as AV_PKT_DATA_SKIP_SAMPLES.</summary>
    SkipSamples = 9,
    /// <summary>This side data must be associated with an audio frame and corresponds to enum AVAudioServiceType defined in avcodec.h.</summary>
    AudioServiceType = 10,
    /// <summary>Mastering display metadata associated with a video frame. The payload is an AVMasteringDisplayMetadata type and contains information about the mastering display color volume.</summary>
    MasteringDisplayMetadata = 11,
    /// <summary>The GOP timecode in 25 bit timecode format. Data format is 64-bit integer. This is set on the first frame of a GOP that has a temporal reference of 0.</summary>
    GopTimecode = 12,
    /// <summary>The data represents the AVSphericalMapping structure defined in libavutil/spherical.h.</summary>
    Spherical = 13,
    /// <summary>Content light level (based on CTA-861.3). This payload contains data in the form of the AVContentLightMetadata struct.</summary>
    ContentLightLevel = 14,
    /// <summary>The data contains an ICC profile as an opaque octet buffer following the format described by ISO 15076-1 with an optional name defined in the metadata key entry &quot;name&quot;.</summary>
    IccProfile = 15,
    /// <summary>Timecode which conforms to SMPTE ST 12-1. The data is an array of 4 uint32_t where the first uint32_t describes how many (1-3) of the other timecodes are used. The timecode format is described in the documentation of av_timecode_get_smpte_from_framenum() function in libavutil/timecode.h.</summary>
    S12mTimecode = 16,
    /// <summary>HDR dynamic metadata associated with a video frame. The payload is an AVDynamicHDRPlus type and contains information for color volume transform - application 4 of SMPTE 2094-40:2016 standard.</summary>
    DynamicHdrPlus = 17,
    /// <summary>Regions Of Interest, the data is an array of AVRegionOfInterest type, the number of array element is implied by AVFrameSideData.size / AVRegionOfInterest.self_size.</summary>
    RegionsOfInterest = 18,
    /// <summary>Encoding parameters for a video frame, as described by AVVideoEncParams.</summary>
    VideoEncParams = 19,
    /// <summary>User data unregistered metadata associated with a video frame. This is the H.26[45] UDU SEI message, and shouldn&apos;t be used for any other purpose The data is stored as uint8_t in AVFrameSideData.data which is 16 bytes of uuid_iso_iec_11578 followed by AVFrameSideData.size - 16 bytes of user_data_payload_byte.</summary>
    SeiUnregistered = 20,
    /// <summary>Film grain parameters for a frame, described by AVFilmGrainParams. Must be present for every frame which should have film grain applied.</summary>
    FilmGrainParams = 21,
    /// <summary>Bounding boxes for object detection and classification, as described by AVDetectionBBoxHeader.</summary>
    DetectionBboxes = 22,
    /// <summary>Dolby Vision RPU raw data, suitable for passing to x265 or other libraries. Array of uint8_t, with NAL emulation bytes intact.</summary>
    DoviRpuBuffer = 23,
    /// <summary>Parsed Dolby Vision metadata, suitable for passing to a software implementation. The payload is the AVDOVIMetadata struct defined in libavutil/dovi_meta.h.</summary>
    DoviMetadata = 24,
    /// <summary>HDR Vivid dynamic metadata associated with a video frame. The payload is an AVDynamicHDRVivid type and contains information for color volume transform - CUVA 005.1-2021.</summary>
    DynamicHdrVivid = 25,
    /// <summary>Ambient viewing environment metadata, as defined by H.274.</summary>
    AmbientViewingEnvironment = 26,
    /// <summary>Provide encoder-specific hinting information about changed/unchanged portions of a frame. It can be used to pass information about which macroblocks can be skipped because they didn&apos;t change from the corresponding ones in the previous frame. This could be useful for applications which know this information in advance to speed up encoding.</summary>
    VideoHint = 27,
    /// <summary>Raw LCEVC payload data, as a uint8_t array, with NAL emulation bytes intact.</summary>
    Lcevc = 28,
    /// <summary>This side data must be associated with a video frame. The presence of this side data indicates that the video stream is composed of multiple views (e.g. stereoscopic 3D content, cf. H.264 Annex H or H.265 Annex G). The data is an int storing the view ID.</summary>
    ViewId = 29,
    /// <summary>This side data contains information about the reference display width(s) and reference viewing distance(s) as well as information about the corresponding reference stereo pair(s), i.e., the pair(s) of views to be displayed for the viewer&apos;s left and right eyes on the reference display at the reference viewing distance. The payload is the AV3DReferenceDisplaysInfo struct defined in libavutil/tdrdi.h.</summary>
    _3DReferenceDisplays = 30,
    /// <summary>Extensible image file format metadata. The payload is a buffer containing EXIF metadata, starting with either 49 49 2a 00, or 4d 4d 00 2a.</summary>
    Exif = 31,
}

/// <summary>Option for overlapping elliptical pixel selectors in an image.</summary>
public enum AVHDRPlusOverlapProcessOption : int
{
    WeightedAveraging = 0,
    Layering = 1,
}

public enum AVHWDeviceType : int
{
    None = 0,
    Vdpau = 1,
    Cuda = 2,
    Vaapi = 3,
    Dxva2 = 4,
    Qsv = 5,
    Videotoolbox = 6,
    D3d11va = 7,
    Drm = 8,
    Opencl = 9,
    Mediacodec = 10,
    Vulkan = 11,
    D3d12va = 12,
    Amf = 13,
    Ohcodec = 14,
}

/// <summary>Flags to apply to frame mappings.</summary>
[Flags]
public enum AVHWframeMap : int
{
    None = 0,
    /// <summary>The mapping must be readable.</summary>
    Read = 1,
    /// <summary>The mapping must be writeable.</summary>
    Write = 2,
    /// <summary>The mapped frame will be overwritten completely in subsequent operations, so the current frame data need not be loaded. Any values which are not overwritten are unspecified.</summary>
    Overwrite = 4,
    /// <summary>The mapping must be direct. That is, there must not be any copying in the map or unmap steps. Note that performance of direct mappings may be much lower than normal memory.</summary>
    Direct = 8,
}

public enum AVHWFrameTransferDirection : int
{
    /// <summary>Transfer the data from the queried hw frame.</summary>
    From = 0,
    /// <summary>Transfer the data to the queried hw frame.</summary>
    To = 1,
}

/// <summary>Different data types that can be returned via the AVIO write_data_type callback.</summary>
public enum AVIODataMarkerType : int
{
    /// <summary>Header data; this needs to be present for the stream to be decodeable.</summary>
    Header = 0,
    /// <summary>A point in the output bytestream where a decoder can start decoding (i.e. a keyframe). A demuxer/decoder given the data flagged with AVIO_DATA_MARKER_HEADER, followed by any AVIO_DATA_MARKER_SYNC_POINT, should give decodeable results.</summary>
    SyncPoint = 1,
    /// <summary>A point in the output bytestream where a demuxer can start parsing (for non self synchronizing bytestream formats). That is, any non-keyframe packet start point.</summary>
    BoundaryPoint = 2,
    /// <summary>This is any, unlabelled data. It can either be a muxer not marking any positions at all, it can be an actual boundary/sync point that the muxer chooses not to mark, or a later part of a packet/fragment that is cut into multiple write callbacks due to limited IO buffer size.</summary>
    Unknown = 3,
    /// <summary>Trailer data, which doesn&apos;t contain actual content, but only for finalizing the output file.</summary>
    Trailer = 4,
    /// <summary>A point in the output bytestream where the underlying AVIOContext might flush the buffer depending on latency or buffering requirements. Typically means the end of a packet.</summary>
    FlushPoint = 5,
}

/// <summary>Directory entry types.</summary>
public enum AVIODirEntryType : int
{
    Unknown = 0,
    BlockDevice = 1,
    CharacterDevice = 2,
    Directory = 3,
    NamedPipe = 4,
    SymbolicLink = 5,
    Socket = 6,
    File = 7,
    Server = 8,
    Share = 9,
    Workgroup = 10,
}

public enum AVMatrixEncoding : int
{
    None = 0,
    Dolby = 1,
    Dplii = 2,
    Dpliix = 3,
    Dpliiz = 4,
    Dolbyex = 5,
    Dolbyheadphone = 6,
    Nb = 7,
}

/// <summary>Media Type</summary>
public enum AVMediaType : int
{
    /// <summary>Usually treated as AVMEDIA_TYPE_DATA</summary>
    Unknown = -1,
    Video = 0,
    Audio = 1,
    /// <summary>Opaque data information usually continuous</summary>
    Data = 2,
    Subtitle = 3,
    /// <summary>Opaque data information usually sparse</summary>
    Attachment = 4,
    Nb = 5,
}

/// <summary>Macro enum, prefix: AVFMT_AVOID_NEG_TS_</summary>
[Flags]
public enum AvoidNegTSFlags : int
{
    /// <summary>AVFMT_AVOID_NEG_TS_AUTO</summary>
    Auto = -1,
    /// <summary>AVFMT_AVOID_NEG_TS_DISABLED</summary>
    Disabled = 0,
    /// <summary>AVFMT_AVOID_NEG_TS_MAKE_NON_NEGATIVE</summary>
    MakeNonNegative = 1,
    /// <summary>AVFMT_AVOID_NEG_TS_MAKE_ZERO</summary>
    MakeZero = 2,
}

[Flags]
public enum AVOptFlagImplicit : int
{
    None = 0,
    /// <summary>Accept to parse a value without a key; the key will then be returned as NULL.</summary>
    Key = 1,
}

/// <summary>An option type determines: - for native access, the underlying C type of the field that an AVOption refers to; - for foreign access, the semantics of accessing the option through this API, e.g. which av_opt_get_*() and av_opt_set_*() functions can be called, or what format will av_opt_get()/av_opt_set() expect/produce.</summary>
public enum AVOptionType : int
{
    /// <summary>Underlying C type is unsigned int.</summary>
    Flags = 1,
    /// <summary>Underlying C type is int.</summary>
    Int = 2,
    /// <summary>Underlying C type is int64_t.</summary>
    Int64 = 3,
    /// <summary>Underlying C type is double.</summary>
    Double = 4,
    /// <summary>Underlying C type is float.</summary>
    Float = 5,
    /// <summary>Underlying C type is a uint8_t* that is either NULL or points to a C string allocated with the av_malloc() family of functions.</summary>
    String = 6,
    /// <summary>Underlying C type is AVRational.</summary>
    Rational = 7,
    /// <summary>Underlying C type is a uint8_t* that is either NULL or points to an array allocated with the av_malloc() family of functions. The pointer is immediately followed by an int containing the array length in bytes.</summary>
    Binary = 8,
    /// <summary>Underlying C type is AVDictionary*.</summary>
    Dict = 9,
    /// <summary>Underlying C type is uint64_t.</summary>
    Uint64 = 10,
    /// <summary>Special option type for declaring named constants. Does not correspond to an actual field in the object, offset must be 0.</summary>
    Const = 11,
    /// <summary>Underlying C type is two consecutive integers.</summary>
    ImageSize = 12,
    /// <summary>Underlying C type is enum AVPixelFormat.</summary>
    PixelFmt = 13,
    /// <summary>Underlying C type is enum AVSampleFormat.</summary>
    SampleFmt = 14,
    /// <summary>Underlying C type is AVRational.</summary>
    VideoRate = 15,
    /// <summary>Underlying C type is int64_t.</summary>
    Duration = 16,
    /// <summary>Underlying C type is uint8_t[4].</summary>
    Color = 17,
    /// <summary>Underlying C type is int.</summary>
    Bool = 18,
    /// <summary>Underlying C type is AVChannelLayout.</summary>
    Chlayout = 19,
    /// <summary>Underlying C type is unsigned int.</summary>
    Uint = 20,
    /// <summary>May be combined with another regular option type to declare an array option.</summary>
    FlagArray = 65536,
}

/// <summary>Types and functions for working with AVPacketSideData. @{</summary>
public enum AVPacketSideDataType : int
{
    /// <summary>An AV_PKT_DATA_PALETTE side data packet contains exactly AVPALETTE_SIZE bytes worth of palette. This side data signals that a new palette is present.</summary>
    Palette = 0,
    /// <summary>The AV_PKT_DATA_NEW_EXTRADATA is used to notify the codec or the format that the extradata buffer was changed and the receiving side should act upon it appropriately. The new extradata is embedded in the side data buffer and should be immediately used for processing the current frame or packet.</summary>
    NewExtradata = 1,
    /// <summary>An AV_PKT_DATA_PARAM_CHANGE side data packet is laid out as follows:</summary>
    ParamChange = 2,
    /// <summary>An AV_PKT_DATA_H263_MB_INFO side data packet contains a number of structures with info about macroblocks relevant to splitting the packet into smaller packets on macroblock edges (e.g. as for RFC 2190). That is, it does not necessarily contain info about all macroblocks, as long as the distance between macroblocks in the info is smaller than the target payload size. Each MB info structure is 12 bytes, and is laid out as follows:</summary>
    H263MbInfo = 3,
    /// <summary>This side data should be associated with an audio stream and contains ReplayGain information in form of the AVReplayGain struct.</summary>
    Replaygain = 4,
    /// <summary>This side data contains a 3x3 transformation matrix describing an affine transformation that needs to be applied to the decoded video frames for correct presentation.</summary>
    Displaymatrix = 5,
    /// <summary>This side data should be associated with a video stream and contains Stereoscopic 3D information in form of the AVStereo3D struct.</summary>
    Stereo3d = 6,
    /// <summary>This side data should be associated with an audio stream and corresponds to enum AVAudioServiceType.</summary>
    AudioServiceType = 7,
    /// <summary>This side data contains quality related information from the encoder.</summary>
    QualityStats = 8,
    /// <summary>This side data contains an integer value representing the stream index of a &quot;fallback&quot; track. A fallback track indicates an alternate track to use when the current track can not be decoded for some reason. e.g. no decoder available for codec.</summary>
    FallbackTrack = 9,
    /// <summary>This side data corresponds to the AVCPBProperties struct.</summary>
    CpbProperties = 10,
    /// <summary>Recommends skipping the specified number of samples</summary>
    SkipSamples = 11,
    /// <summary>An AV_PKT_DATA_JP_DUALMONO side data packet indicates that the packet may contain &quot;dual mono&quot; audio specific to Japanese DTV and if it is true, recommends only the selected channel to be used.</summary>
    JpDualmono = 12,
    /// <summary>A list of zero terminated key/value strings. There is no end marker for the list, so it is required to rely on the side data size to stop.</summary>
    StringsMetadata = 13,
    /// <summary>Subtitle event position</summary>
    SubtitlePosition = 14,
    /// <summary>Data found in BlockAdditional element of matroska container. There is no end marker for the data, so it is required to rely on the side data size to recognize the end. 8 byte id (as found in BlockAddId) followed by data.</summary>
    MatroskaBlockadditional = 15,
    /// <summary>The optional first identifier line of a WebVTT cue.</summary>
    WebvttIdentifier = 16,
    /// <summary>The optional settings (rendering instructions) that immediately follow the timestamp specifier of a WebVTT cue.</summary>
    WebvttSettings = 17,
    /// <summary>A list of zero terminated key/value strings. There is no end marker for the list, so it is required to rely on the side data size to stop. This side data includes updated metadata which appeared in the stream.</summary>
    MetadataUpdate = 18,
    /// <summary>MPEGTS stream ID as uint8_t, this is required to pass the stream ID information from the demuxer to the corresponding muxer.</summary>
    MpegtsStreamId = 19,
    /// <summary>Mastering display metadata (based on SMPTE-2086:2014). This metadata should be associated with a video stream and contains data in the form of the AVMasteringDisplayMetadata struct.</summary>
    MasteringDisplayMetadata = 20,
    /// <summary>This side data should be associated with a video stream and corresponds to the AVSphericalMapping structure.</summary>
    Spherical = 21,
    /// <summary>Content light level (based on CTA-861.3). This metadata should be associated with a video stream and contains data in the form of the AVContentLightMetadata struct.</summary>
    ContentLightLevel = 22,
    /// <summary>ATSC A53 Part 4 Closed Captions. This metadata should be associated with a video stream. A53 CC bitstream is stored as uint8_t in AVPacketSideData.data. The number of bytes of CC data is AVPacketSideData.size.</summary>
    A53Cc = 23,
    /// <summary>This side data is encryption initialization data. The format is not part of ABI, use av_encryption_init_info_* methods to access.</summary>
    EncryptionInitInfo = 24,
    /// <summary>This side data contains encryption info for how to decrypt the packet. The format is not part of ABI, use av_encryption_info_* methods to access.</summary>
    EncryptionInfo = 25,
    /// <summary>Active Format Description data consisting of a single byte as specified in ETSI TS 101 154 using AVActiveFormatDescription enum.</summary>
    Afd = 26,
    /// <summary>Producer Reference Time data corresponding to the AVProducerReferenceTime struct, usually exported by some encoders (on demand through the prft flag set in the AVCodecContext export_side_data field).</summary>
    Prft = 27,
    /// <summary>ICC profile data consisting of an opaque octet buffer following the format described by ISO 15076-1.</summary>
    IccProfile = 28,
    /// <summary>DOVI configuration ref: dolby-vision-bitstreams-within-the-iso-base-media-file-format-v2.1.2, section 2.2 dolby-vision-bitstreams-in-mpeg-2-transport-stream-multiplex-v1.2, section 3.3 Tags are stored in struct AVDOVIDecoderConfigurationRecord.</summary>
    DoviConf = 29,
    /// <summary>Timecode which conforms to SMPTE ST 12-1:2014. The data is an array of 4 uint32_t where the first uint32_t describes how many (1-3) of the other timecodes are used. The timecode format is described in the documentation of av_timecode_get_smpte_from_framenum() function in libavutil/timecode.h.</summary>
    S12mTimecode = 30,
    /// <summary>HDR10+ dynamic metadata associated with a video frame. The metadata is in the form of the AVDynamicHDRPlus struct and contains information for color volume transform - application 4 of SMPTE 2094-40:2016 standard.</summary>
    DynamicHdr10Plus = 31,
    /// <summary>IAMF Mix Gain Parameter Data associated with the audio frame. This metadata is in the form of the AVIAMFParamDefinition struct and contains information defined in sections 3.6.1 and 3.8.1 of the Immersive Audio Model and Formats standard.</summary>
    IamfMixGainParam = 32,
    /// <summary>IAMF Demixing Info Parameter Data associated with the audio frame. This metadata is in the form of the AVIAMFParamDefinition struct and contains information defined in sections 3.6.1 and 3.8.2 of the Immersive Audio Model and Formats standard.</summary>
    IamfDemixingInfoParam = 33,
    /// <summary>IAMF Recon Gain Info Parameter Data associated with the audio frame. This metadata is in the form of the AVIAMFParamDefinition struct and contains information defined in sections 3.6.1 and 3.8.3 of the Immersive Audio Model and Formats standard.</summary>
    IamfReconGainInfoParam = 34,
    /// <summary>Ambient viewing environment metadata, as defined by H.274. This metadata should be associated with a video stream and contains data in the form of the AVAmbientViewingEnvironment struct.</summary>
    AmbientViewingEnvironment = 35,
    /// <summary>The number of pixels to discard from the top/bottom/left/right border of the decoded frame to obtain the sub-rectangle intended for presentation.</summary>
    FrameCropping = 36,
    /// <summary>Raw LCEVC payload data, as a uint8_t array, with NAL emulation bytes intact.</summary>
    Lcevc = 37,
    /// <summary>This side data contains information about the reference display width(s) and reference viewing distance(s) as well as information about the corresponding reference stereo pair(s), i.e., the pair(s) of views to be displayed for the viewer&apos;s left and right eyes on the reference display at the reference viewing distance. The payload is the AV3DReferenceDisplaysInfo struct defined in libavutil/tdrdi.h.</summary>
    _3DReferenceDisplays = 38,
    /// <summary>Contains the last received RTCP SR (Sender Report) information in the form of the AVRTCPSenderReport struct.</summary>
    RtcpSr = 39,
    /// <summary>The number of side data types. This is not part of the public API/ABI in the sense that it may change when new side data types are added. This must stay the last enum value. If its value becomes huge, some code using it needs to be updated as it assumes it to be smaller than other limits.</summary>
    Nb = 40,
}

/// <summary>@{</summary>
public enum AVPictureStructure : int
{
    /// <summary>unknown</summary>
    Unknown = 0,
    /// <summary>coded as top field</summary>
    TopField = 1,
    /// <summary>coded as bottom field</summary>
    BottomField = 2,
    /// <summary>coded as frame</summary>
    Frame = 3,
}

/// <summary>@} @}</summary>
public enum AVPictureType : int
{
    /// <summary>Undefined</summary>
    None = 0,
    /// <summary>Intra</summary>
    I = 1,
    /// <summary>Predicted</summary>
    P = 2,
    /// <summary>Bi-dir predicted</summary>
    B = 3,
    /// <summary>S(GMC)-VOP MPEG-4</summary>
    S = 4,
    /// <summary>Switching Intra</summary>
    Si = 5,
    /// <summary>Switching Predicted</summary>
    Sp = 6,
    /// <summary>BI type</summary>
    Bi = 7,
}

/// <summary>Pixel format.</summary>
public enum AVPixelFormat : int
{
    None = -1,
    /// <summary>planar YUV 4:2:0, 12bpp, (1 Cr &amp; Cb sample per 2x2 Y samples)</summary>
    Yuv420p = 0,
    /// <summary>packed YUV 4:2:2, 16bpp, Y0 Cb Y1 Cr</summary>
    Yuyv422 = 1,
    /// <summary>packed RGB 8:8:8, 24bpp, RGBRGB...</summary>
    Rgb24 = 2,
    /// <summary>packed RGB 8:8:8, 24bpp, BGRBGR...</summary>
    Bgr24 = 3,
    /// <summary>planar YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)</summary>
    Yuv422p = 4,
    /// <summary>planar YUV 4:4:4, 24bpp, (1 Cr &amp; Cb sample per 1x1 Y samples)</summary>
    Yuv444p = 5,
    /// <summary>planar YUV 4:1:0, 9bpp, (1 Cr &amp; Cb sample per 4x4 Y samples)</summary>
    Yuv410p = 6,
    /// <summary>planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples)</summary>
    Yuv411p = 7,
    /// <summary>Y , 8bpp</summary>
    Gray8 = 8,
    /// <summary>Y , 1bpp, 0 is white, 1 is black, in each byte pixels are ordered from the msb to the lsb</summary>
    Monowhite = 9,
    /// <summary>Y , 1bpp, 0 is black, 1 is white, in each byte pixels are ordered from the msb to the lsb</summary>
    Monoblack = 10,
    /// <summary>8 bits with AV_PIX_FMT_RGB32 palette</summary>
    Pal8 = 11,
    /// <summary>planar YUV 4:2:0, 12bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV420P and setting color_range</summary>
    Yuvj420p = 12,
    /// <summary>planar YUV 4:2:2, 16bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV422P and setting color_range</summary>
    Yuvj422p = 13,
    /// <summary>planar YUV 4:4:4, 24bpp, full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV444P and setting color_range</summary>
    Yuvj444p = 14,
    /// <summary>packed YUV 4:2:2, 16bpp, Cb Y0 Cr Y1</summary>
    Uyvy422 = 15,
    /// <summary>packed YUV 4:1:1, 12bpp, Cb Y0 Y1 Cr Y2 Y3</summary>
    Uyyvyy411 = 16,
    /// <summary>packed RGB 3:3:2, 8bpp, (msb)2B 3G 3R(lsb)</summary>
    Bgr8 = 17,
    /// <summary>packed RGB 1:2:1 bitstream, 4bpp, (msb)1B 2G 1R(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits</summary>
    Bgr4 = 18,
    /// <summary>packed RGB 1:2:1, 8bpp, (msb)1B 2G 1R(lsb)</summary>
    Bgr4Byte = 19,
    /// <summary>packed RGB 3:3:2, 8bpp, (msb)3R 3G 2B(lsb)</summary>
    Rgb8 = 20,
    /// <summary>packed RGB 1:2:1 bitstream, 4bpp, (msb)1R 2G 1B(lsb), a byte contains two pixels, the first pixel in the byte is the one composed by the 4 msb bits</summary>
    Rgb4 = 21,
    /// <summary>packed RGB 1:2:1, 8bpp, (msb)1R 2G 1B(lsb)</summary>
    Rgb4Byte = 22,
    /// <summary>planar YUV 4:2:0, 12bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)</summary>
    Nv12 = 23,
    /// <summary>as above, but U and V bytes are swapped</summary>
    Nv21 = 24,
    /// <summary>packed ARGB 8:8:8:8, 32bpp, ARGBARGB...</summary>
    Argb = 25,
    /// <summary>packed RGBA 8:8:8:8, 32bpp, RGBARGBA...</summary>
    Rgba = 26,
    /// <summary>packed ABGR 8:8:8:8, 32bpp, ABGRABGR...</summary>
    Abgr = 27,
    /// <summary>packed BGRA 8:8:8:8, 32bpp, BGRABGRA...</summary>
    Bgra = 28,
    /// <summary>Y , 16bpp, big-endian</summary>
    Gray16be = 29,
    /// <summary>Y , 16bpp, little-endian</summary>
    Gray16le = 30,
    /// <summary>planar YUV 4:4:0 (1 Cr &amp; Cb sample per 1x2 Y samples)</summary>
    Yuv440p = 31,
    /// <summary>planar YUV 4:4:0 full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV440P and setting color_range</summary>
    Yuvj440p = 32,
    /// <summary>planar YUV 4:2:0, 20bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples)</summary>
    Yuva420p = 33,
    /// <summary>packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as big-endian</summary>
    Rgb48be = 34,
    /// <summary>packed RGB 16:16:16, 48bpp, 16R, 16G, 16B, the 2-byte value for each R/G/B component is stored as little-endian</summary>
    Rgb48le = 35,
    /// <summary>packed RGB 5:6:5, 16bpp, (msb) 5R 6G 5B(lsb), big-endian</summary>
    Rgb565be = 36,
    /// <summary>packed RGB 5:6:5, 16bpp, (msb) 5R 6G 5B(lsb), little-endian</summary>
    Rgb565le = 37,
    /// <summary>packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), big-endian , X=unused/undefined</summary>
    Rgb555be = 38,
    /// <summary>packed RGB 5:5:5, 16bpp, (msb)1X 5R 5G 5B(lsb), little-endian, X=unused/undefined</summary>
    Rgb555le = 39,
    /// <summary>packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), big-endian</summary>
    Bgr565be = 40,
    /// <summary>packed BGR 5:6:5, 16bpp, (msb) 5B 6G 5R(lsb), little-endian</summary>
    Bgr565le = 41,
    /// <summary>packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), big-endian , X=unused/undefined</summary>
    Bgr555be = 42,
    /// <summary>packed BGR 5:5:5, 16bpp, (msb)1X 5B 5G 5R(lsb), little-endian, X=unused/undefined</summary>
    Bgr555le = 43,
    /// <summary>Hardware acceleration through VA-API, data[3] contains a VASurfaceID.</summary>
    Vaapi = 44,
    /// <summary>planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian</summary>
    Yuv420p16le = 45,
    /// <summary>planar YUV 4:2:0, 24bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian</summary>
    Yuv420p16be = 46,
    /// <summary>planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Yuv422p16le = 47,
    /// <summary>planar YUV 4:2:2, 32bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Yuv422p16be = 48,
    /// <summary>planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian</summary>
    Yuv444p16le = 49,
    /// <summary>planar YUV 4:4:4, 48bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian</summary>
    Yuv444p16be = 50,
    /// <summary>HW decoding through DXVA2, Picture.data[3] contains a LPDIRECT3DSURFACE9 pointer</summary>
    Dxva2Vld = 51,
    /// <summary>packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), little-endian, X=unused/undefined</summary>
    Rgb444le = 52,
    /// <summary>packed RGB 4:4:4, 16bpp, (msb)4X 4R 4G 4B(lsb), big-endian, X=unused/undefined</summary>
    Rgb444be = 53,
    /// <summary>packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), little-endian, X=unused/undefined</summary>
    Bgr444le = 54,
    /// <summary>packed BGR 4:4:4, 16bpp, (msb)4X 4B 4G 4R(lsb), big-endian, X=unused/undefined</summary>
    Bgr444be = 55,
    /// <summary>8 bits gray, 8 bits alpha</summary>
    Ya8 = 56,
    /// <summary>alias for AV_PIX_FMT_YA8</summary>
    Y400a = 56,
    /// <summary>alias for AV_PIX_FMT_YA8</summary>
    Gray8a = 56,
    /// <summary>packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as big-endian</summary>
    Bgr48be = 57,
    /// <summary>packed RGB 16:16:16, 48bpp, 16B, 16G, 16R, the 2-byte value for each R/G/B component is stored as little-endian</summary>
    Bgr48le = 58,
    /// <summary>planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian</summary>
    Yuv420p9be = 59,
    /// <summary>planar YUV 4:2:0, 13.5bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian</summary>
    Yuv420p9le = 60,
    /// <summary>planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian</summary>
    Yuv420p10be = 61,
    /// <summary>planar YUV 4:2:0, 15bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian</summary>
    Yuv420p10le = 62,
    /// <summary>planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Yuv422p10be = 63,
    /// <summary>planar YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Yuv422p10le = 64,
    /// <summary>planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian</summary>
    Yuv444p9be = 65,
    /// <summary>planar YUV 4:4:4, 27bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian</summary>
    Yuv444p9le = 66,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian</summary>
    Yuv444p10be = 67,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian</summary>
    Yuv444p10le = 68,
    /// <summary>planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Yuv422p9be = 69,
    /// <summary>planar YUV 4:2:2, 18bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Yuv422p9le = 70,
    /// <summary>planar GBR 4:4:4 24bpp</summary>
    Gbrp = 71,
    Gbr24p = 71,
    /// <summary>planar GBR 4:4:4 27bpp, big-endian</summary>
    Gbrp9be = 72,
    /// <summary>planar GBR 4:4:4 27bpp, little-endian</summary>
    Gbrp9le = 73,
    /// <summary>planar GBR 4:4:4 30bpp, big-endian</summary>
    Gbrp10be = 74,
    /// <summary>planar GBR 4:4:4 30bpp, little-endian</summary>
    Gbrp10le = 75,
    /// <summary>planar GBR 4:4:4 48bpp, big-endian</summary>
    Gbrp16be = 76,
    /// <summary>planar GBR 4:4:4 48bpp, little-endian</summary>
    Gbrp16le = 77,
    /// <summary>planar YUV 4:2:2 24bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples)</summary>
    Yuva422p = 78,
    /// <summary>planar YUV 4:4:4 32bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples)</summary>
    Yuva444p = 79,
    /// <summary>planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), big-endian</summary>
    Yuva420p9be = 80,
    /// <summary>planar YUV 4:2:0 22.5bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples), little-endian</summary>
    Yuva420p9le = 81,
    /// <summary>planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), big-endian</summary>
    Yuva422p9be = 82,
    /// <summary>planar YUV 4:2:2 27bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples), little-endian</summary>
    Yuva422p9le = 83,
    /// <summary>planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian</summary>
    Yuva444p9be = 84,
    /// <summary>planar YUV 4:4:4 36bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian</summary>
    Yuva444p9le = 85,
    /// <summary>planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)</summary>
    Yuva420p10be = 86,
    /// <summary>planar YUV 4:2:0 25bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)</summary>
    Yuva420p10le = 87,
    /// <summary>planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)</summary>
    Yuva422p10be = 88,
    /// <summary>planar YUV 4:2:2 30bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)</summary>
    Yuva422p10le = 89,
    /// <summary>planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)</summary>
    Yuva444p10be = 90,
    /// <summary>planar YUV 4:4:4 40bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)</summary>
    Yuva444p10le = 91,
    /// <summary>planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, big-endian)</summary>
    Yuva420p16be = 92,
    /// <summary>planar YUV 4:2:0 40bpp, (1 Cr &amp; Cb sample per 2x2 Y &amp; A samples, little-endian)</summary>
    Yuva420p16le = 93,
    /// <summary>planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, big-endian)</summary>
    Yuva422p16be = 94,
    /// <summary>planar YUV 4:2:2 48bpp, (1 Cr &amp; Cb sample per 2x1 Y &amp; A samples, little-endian)</summary>
    Yuva422p16le = 95,
    /// <summary>planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, big-endian)</summary>
    Yuva444p16be = 96,
    /// <summary>planar YUV 4:4:4 64bpp, (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples, little-endian)</summary>
    Yuva444p16le = 97,
    /// <summary>HW acceleration through VDPAU, Picture.data[3] contains a VdpVideoSurface</summary>
    Vdpau = 98,
    /// <summary>packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as little-endian, the 4 lower bits are set to 0</summary>
    Xyz12le = 99,
    /// <summary>packed XYZ 4:4:4, 36 bpp, (msb) 12X, 12Y, 12Z (lsb), the 2-byte value for each X/Y/Z is stored as big-endian, the 4 lower bits are set to 0</summary>
    Xyz12be = 100,
    /// <summary>interleaved chroma YUV 4:2:2, 16bpp, (1 Cr &amp; Cb sample per 2x1 Y samples)</summary>
    Nv16 = 101,
    /// <summary>interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Nv20le = 102,
    /// <summary>interleaved chroma YUV 4:2:2, 20bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Nv20be = 103,
    /// <summary>packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian</summary>
    Rgba64be = 104,
    /// <summary>packed RGBA 16:16:16:16, 64bpp, 16R, 16G, 16B, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian</summary>
    Rgba64le = 105,
    /// <summary>packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as big-endian</summary>
    Bgra64be = 106,
    /// <summary>packed RGBA 16:16:16:16, 64bpp, 16B, 16G, 16R, 16A, the 2-byte value for each R/G/B/A component is stored as little-endian</summary>
    Bgra64le = 107,
    /// <summary>packed YUV 4:2:2, 16bpp, Y0 Cr Y1 Cb</summary>
    Yvyu422 = 108,
    /// <summary>16 bits gray, 16 bits alpha (big-endian)</summary>
    Ya16be = 109,
    /// <summary>16 bits gray, 16 bits alpha (little-endian)</summary>
    Ya16le = 110,
    /// <summary>planar GBRA 4:4:4:4 32bpp</summary>
    Gbrap = 111,
    /// <summary>planar GBRA 4:4:4:4 64bpp, big-endian</summary>
    Gbrap16be = 112,
    /// <summary>planar GBRA 4:4:4:4 64bpp, little-endian</summary>
    Gbrap16le = 113,
    /// <summary>HW acceleration through QSV, data[3] contains a pointer to the mfxFrameSurface1 structure.</summary>
    Qsv = 114,
    /// <summary>HW acceleration though MMAL, data[3] contains a pointer to the MMAL_BUFFER_HEADER_T structure.</summary>
    Mmal = 115,
    /// <summary>HW decoding through Direct3D11 via old API, Picture.data[3] contains a ID3D11VideoDecoderOutputView pointer</summary>
    D3d11vaVld = 116,
    /// <summary>HW acceleration through CUDA. data[i] contain CUdeviceptr pointers exactly as for system memory frames.</summary>
    Cuda = 117,
    /// <summary>packed RGB 8:8:8, 32bpp, XRGBXRGB... X=unused/undefined</summary>
    _0RGB = 118,
    /// <summary>packed RGB 8:8:8, 32bpp, RGBXRGBX... X=unused/undefined</summary>
    Rgb0 = 119,
    /// <summary>packed BGR 8:8:8, 32bpp, XBGRXBGR... X=unused/undefined</summary>
    _0BGR = 120,
    /// <summary>packed BGR 8:8:8, 32bpp, BGRXBGRX... X=unused/undefined</summary>
    Bgr0 = 121,
    /// <summary>planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian</summary>
    Yuv420p12be = 122,
    /// <summary>planar YUV 4:2:0,18bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian</summary>
    Yuv420p12le = 123,
    /// <summary>planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), big-endian</summary>
    Yuv420p14be = 124,
    /// <summary>planar YUV 4:2:0,21bpp, (1 Cr &amp; Cb sample per 2x2 Y samples), little-endian</summary>
    Yuv420p14le = 125,
    /// <summary>planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Yuv422p12be = 126,
    /// <summary>planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Yuv422p12le = 127,
    /// <summary>planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), big-endian</summary>
    Yuv422p14be = 128,
    /// <summary>planar YUV 4:2:2,28bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), little-endian</summary>
    Yuv422p14le = 129,
    /// <summary>planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian</summary>
    Yuv444p12be = 130,
    /// <summary>planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian</summary>
    Yuv444p12le = 131,
    /// <summary>planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), big-endian</summary>
    Yuv444p14be = 132,
    /// <summary>planar YUV 4:4:4,42bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), little-endian</summary>
    Yuv444p14le = 133,
    /// <summary>planar GBR 4:4:4 36bpp, big-endian</summary>
    Gbrp12be = 134,
    /// <summary>planar GBR 4:4:4 36bpp, little-endian</summary>
    Gbrp12le = 135,
    /// <summary>planar GBR 4:4:4 42bpp, big-endian</summary>
    Gbrp14be = 136,
    /// <summary>planar GBR 4:4:4 42bpp, little-endian</summary>
    Gbrp14le = 137,
    /// <summary>planar YUV 4:1:1, 12bpp, (1 Cr &amp; Cb sample per 4x1 Y samples) full scale (JPEG), deprecated in favor of AV_PIX_FMT_YUV411P and setting color_range</summary>
    Yuvj411p = 138,
    /// <summary>bayer, BGBG..(odd line), GRGR..(even line), 8-bit samples</summary>
    BayerBggr8 = 139,
    /// <summary>bayer, RGRG..(odd line), GBGB..(even line), 8-bit samples</summary>
    BayerRggb8 = 140,
    /// <summary>bayer, GBGB..(odd line), RGRG..(even line), 8-bit samples</summary>
    BayerGbrg8 = 141,
    /// <summary>bayer, GRGR..(odd line), BGBG..(even line), 8-bit samples</summary>
    BayerGrbg8 = 142,
    /// <summary>bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, little-endian</summary>
    BayerBggr16le = 143,
    /// <summary>bayer, BGBG..(odd line), GRGR..(even line), 16-bit samples, big-endian</summary>
    BayerBggr16be = 144,
    /// <summary>bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, little-endian</summary>
    BayerRggb16le = 145,
    /// <summary>bayer, RGRG..(odd line), GBGB..(even line), 16-bit samples, big-endian</summary>
    BayerRggb16be = 146,
    /// <summary>bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, little-endian</summary>
    BayerGbrg16le = 147,
    /// <summary>bayer, GBGB..(odd line), RGRG..(even line), 16-bit samples, big-endian</summary>
    BayerGbrg16be = 148,
    /// <summary>bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, little-endian</summary>
    BayerGrbg16le = 149,
    /// <summary>bayer, GRGR..(odd line), BGBG..(even line), 16-bit samples, big-endian</summary>
    BayerGrbg16be = 150,
    /// <summary>planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian</summary>
    Yuv440p10le = 151,
    /// <summary>planar YUV 4:4:0,20bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian</summary>
    Yuv440p10be = 152,
    /// <summary>planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), little-endian</summary>
    Yuv440p12le = 153,
    /// <summary>planar YUV 4:4:0,24bpp, (1 Cr &amp; Cb sample per 1x2 Y samples), big-endian</summary>
    Yuv440p12be = 154,
    /// <summary>packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), little-endian</summary>
    Ayuv64le = 155,
    /// <summary>packed AYUV 4:4:4,64bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), big-endian</summary>
    Ayuv64be = 156,
    /// <summary>hardware decoding through Videotoolbox</summary>
    Videotoolbox = 157,
    /// <summary>like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, little-endian</summary>
    P010le = 158,
    /// <summary>like NV12, with 10bpp per component, data in the high bits, zeros in the low bits, big-endian</summary>
    P010be = 159,
    /// <summary>planar GBR 4:4:4:4 48bpp, big-endian</summary>
    Gbrap12be = 160,
    /// <summary>planar GBR 4:4:4:4 48bpp, little-endian</summary>
    Gbrap12le = 161,
    /// <summary>planar GBR 4:4:4:4 40bpp, big-endian</summary>
    Gbrap10be = 162,
    /// <summary>planar GBR 4:4:4:4 40bpp, little-endian</summary>
    Gbrap10le = 163,
    /// <summary>hardware decoding through MediaCodec</summary>
    Mediacodec = 164,
    /// <summary>Y , 12bpp, big-endian</summary>
    Gray12be = 165,
    /// <summary>Y , 12bpp, little-endian</summary>
    Gray12le = 166,
    /// <summary>Y , 10bpp, big-endian</summary>
    Gray10be = 167,
    /// <summary>Y , 10bpp, little-endian</summary>
    Gray10le = 168,
    /// <summary>like NV12, with 16bpp per component, little-endian</summary>
    P016le = 169,
    /// <summary>like NV12, with 16bpp per component, big-endian</summary>
    P016be = 170,
    /// <summary>Hardware surfaces for Direct3D11.</summary>
    D3d11 = 171,
    /// <summary>Y , 9bpp, big-endian</summary>
    Gray9be = 172,
    /// <summary>Y , 9bpp, little-endian</summary>
    Gray9le = 173,
    /// <summary>IEEE-754 single precision planar GBR 4:4:4, 96bpp, big-endian</summary>
    Gbrpf32be = 174,
    /// <summary>IEEE-754 single precision planar GBR 4:4:4, 96bpp, little-endian</summary>
    Gbrpf32le = 175,
    /// <summary>IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, big-endian</summary>
    Gbrapf32be = 176,
    /// <summary>IEEE-754 single precision planar GBRA 4:4:4:4, 128bpp, little-endian</summary>
    Gbrapf32le = 177,
    /// <summary>DRM-managed buffers exposed through PRIME buffer sharing.</summary>
    DrmPrime = 178,
    /// <summary>Hardware surfaces for OpenCL.</summary>
    Opencl = 179,
    /// <summary>Y , 14bpp, big-endian</summary>
    Gray14be = 180,
    /// <summary>Y , 14bpp, little-endian</summary>
    Gray14le = 181,
    /// <summary>IEEE-754 single precision Y, 32bpp, big-endian</summary>
    Grayf32be = 182,
    /// <summary>IEEE-754 single precision Y, 32bpp, little-endian</summary>
    Grayf32le = 183,
    /// <summary>planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), 12b alpha, big-endian</summary>
    Yuva422p12be = 184,
    /// <summary>planar YUV 4:2:2,24bpp, (1 Cr &amp; Cb sample per 2x1 Y samples), 12b alpha, little-endian</summary>
    Yuva422p12le = 185,
    /// <summary>planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), 12b alpha, big-endian</summary>
    Yuva444p12be = 186,
    /// <summary>planar YUV 4:4:4,36bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), 12b alpha, little-endian</summary>
    Yuva444p12le = 187,
    /// <summary>planar YUV 4:4:4, 24bpp, 1 plane for Y and 1 plane for the UV components, which are interleaved (first byte U and the following byte V)</summary>
    Nv24 = 188,
    /// <summary>as above, but U and V bytes are swapped</summary>
    Nv42 = 189,
    /// <summary>Vulkan hardware images.</summary>
    Vulkan = 190,
    /// <summary>packed YUV 4:2:2 like YUYV422, 20bpp, data in the high bits, big-endian</summary>
    Y210be = 191,
    /// <summary>packed YUV 4:2:2 like YUYV422, 20bpp, data in the high bits, little-endian</summary>
    Y210le = 192,
    /// <summary>packed RGB 10:10:10, 30bpp, (msb)2X 10R 10G 10B(lsb), little-endian, X=unused/undefined</summary>
    X2rgb10le = 193,
    /// <summary>packed RGB 10:10:10, 30bpp, (msb)2X 10R 10G 10B(lsb), big-endian, X=unused/undefined</summary>
    X2rgb10be = 194,
    /// <summary>packed BGR 10:10:10, 30bpp, (msb)2X 10B 10G 10R(lsb), little-endian, X=unused/undefined</summary>
    X2bgr10le = 195,
    /// <summary>packed BGR 10:10:10, 30bpp, (msb)2X 10B 10G 10R(lsb), big-endian, X=unused/undefined</summary>
    X2bgr10be = 196,
    /// <summary>interleaved chroma YUV 4:2:2, 20bpp, data in the high bits, big-endian</summary>
    P210be = 197,
    /// <summary>interleaved chroma YUV 4:2:2, 20bpp, data in the high bits, little-endian</summary>
    P210le = 198,
    /// <summary>interleaved chroma YUV 4:4:4, 30bpp, data in the high bits, big-endian</summary>
    P410be = 199,
    /// <summary>interleaved chroma YUV 4:4:4, 30bpp, data in the high bits, little-endian</summary>
    P410le = 200,
    /// <summary>interleaved chroma YUV 4:2:2, 32bpp, big-endian</summary>
    P216be = 201,
    /// <summary>interleaved chroma YUV 4:2:2, 32bpp, little-endian</summary>
    P216le = 202,
    /// <summary>interleaved chroma YUV 4:4:4, 48bpp, big-endian</summary>
    P416be = 203,
    /// <summary>interleaved chroma YUV 4:4:4, 48bpp, little-endian</summary>
    P416le = 204,
    /// <summary>packed VUYA 4:4:4:4, 32bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), VUYAVUYA...</summary>
    Vuya = 205,
    /// <summary>IEEE-754 half precision packed RGBA 16:16:16:16, 64bpp, RGBARGBA..., big-endian</summary>
    Rgbaf16be = 206,
    /// <summary>IEEE-754 half precision packed RGBA 16:16:16:16, 64bpp, RGBARGBA..., little-endian</summary>
    Rgbaf16le = 207,
    /// <summary>packed VUYX 4:4:4:4, 32bpp, Variant of VUYA where alpha channel is left undefined</summary>
    Vuyx = 208,
    /// <summary>like NV12, with 12bpp per component, data in the high bits, zeros in the low bits, little-endian</summary>
    P012le = 209,
    /// <summary>like NV12, with 12bpp per component, data in the high bits, zeros in the low bits, big-endian</summary>
    P012be = 210,
    /// <summary>packed YUV 4:2:2 like YUYV422, 24bpp, data in the high bits, zeros in the low bits, big-endian</summary>
    Y212be = 211,
    /// <summary>packed YUV 4:2:2 like YUYV422, 24bpp, data in the high bits, zeros in the low bits, little-endian</summary>
    Y212le = 212,
    /// <summary>packed XVYU 4:4:4, 32bpp, (msb)2X 10V 10Y 10U(lsb), big-endian, variant of Y410 where alpha channel is left undefined</summary>
    Xv30be = 213,
    /// <summary>packed XVYU 4:4:4, 32bpp, (msb)2X 10V 10Y 10U(lsb), little-endian, variant of Y410 where alpha channel is left undefined</summary>
    Xv30le = 214,
    /// <summary>packed XVYU 4:4:4, 48bpp, data in the high bits, zeros in the low bits, big-endian, variant of Y412 where alpha channel is left undefined</summary>
    Xv36be = 215,
    /// <summary>packed XVYU 4:4:4, 48bpp, data in the high bits, zeros in the low bits, little-endian, variant of Y412 where alpha channel is left undefined</summary>
    Xv36le = 216,
    /// <summary>IEEE-754 single precision packed RGB 32:32:32, 96bpp, RGBRGB..., big-endian</summary>
    Rgbf32be = 217,
    /// <summary>IEEE-754 single precision packed RGB 32:32:32, 96bpp, RGBRGB..., little-endian</summary>
    Rgbf32le = 218,
    /// <summary>IEEE-754 single precision packed RGBA 32:32:32:32, 128bpp, RGBARGBA..., big-endian</summary>
    Rgbaf32be = 219,
    /// <summary>IEEE-754 single precision packed RGBA 32:32:32:32, 128bpp, RGBARGBA..., little-endian</summary>
    Rgbaf32le = 220,
    /// <summary>interleaved chroma YUV 4:2:2, 24bpp, data in the high bits, big-endian</summary>
    P212be = 221,
    /// <summary>interleaved chroma YUV 4:2:2, 24bpp, data in the high bits, little-endian</summary>
    P212le = 222,
    /// <summary>interleaved chroma YUV 4:4:4, 36bpp, data in the high bits, big-endian</summary>
    P412be = 223,
    /// <summary>interleaved chroma YUV 4:4:4, 36bpp, data in the high bits, little-endian</summary>
    P412le = 224,
    /// <summary>planar GBR 4:4:4:4 56bpp, big-endian</summary>
    Gbrap14be = 225,
    /// <summary>planar GBR 4:4:4:4 56bpp, little-endian</summary>
    Gbrap14le = 226,
    /// <summary>Hardware surfaces for Direct3D 12.</summary>
    D3d12 = 227,
    /// <summary>packed AYUV 4:4:4:4, 32bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), AYUVAYUV...</summary>
    Ayuv = 228,
    /// <summary>packed UYVA 4:4:4:4, 32bpp (1 Cr &amp; Cb sample per 1x1 Y &amp; A samples), UYVAUYVA...</summary>
    Uyva = 229,
    /// <summary>packed VYU 4:4:4, 24bpp (1 Cr &amp; Cb sample per 1x1 Y), VYUVYU...</summary>
    Vyu444 = 230,
    /// <summary>packed VYUX 4:4:4 like XV30, 32bpp, (msb)10V 10Y 10U 2X(lsb), big-endian</summary>
    V30xbe = 231,
    /// <summary>packed VYUX 4:4:4 like XV30, 32bpp, (msb)10V 10Y 10U 2X(lsb), little-endian</summary>
    V30xle = 232,
    /// <summary>IEEE-754 half precision packed RGB 16:16:16, 48bpp, RGBRGB..., big-endian</summary>
    Rgbf16be = 233,
    /// <summary>IEEE-754 half precision packed RGB 16:16:16, 48bpp, RGBRGB..., little-endian</summary>
    Rgbf16le = 234,
    /// <summary>packed RGBA 32:32:32:32, 128bpp, RGBARGBA..., big-endian</summary>
    Rgba128be = 235,
    /// <summary>packed RGBA 32:32:32:32, 128bpp, RGBARGBA..., little-endian</summary>
    Rgba128le = 236,
    /// <summary>packed RGBA 32:32:32, 96bpp, RGBRGB..., big-endian</summary>
    Rgb96be = 237,
    /// <summary>packed RGBA 32:32:32, 96bpp, RGBRGB..., little-endian</summary>
    Rgb96le = 238,
    /// <summary>packed YUV 4:2:2 like YUYV422, 32bpp, big-endian</summary>
    Y216be = 239,
    /// <summary>packed YUV 4:2:2 like YUYV422, 32bpp, little-endian</summary>
    Y216le = 240,
    /// <summary>packed XVYU 4:4:4, 64bpp, big-endian, variant of Y416 where alpha channel is left undefined</summary>
    Xv48be = 241,
    /// <summary>packed XVYU 4:4:4, 64bpp, little-endian, variant of Y416 where alpha channel is left undefined</summary>
    Xv48le = 242,
    /// <summary>IEEE-754 half precision planer GBR 4:4:4, 48bpp, big-endian</summary>
    Gbrpf16be = 243,
    /// <summary>IEEE-754 half precision planer GBR 4:4:4, 48bpp, little-endian</summary>
    Gbrpf16le = 244,
    /// <summary>IEEE-754 half precision planar GBRA 4:4:4:4, 64bpp, big-endian</summary>
    Gbrapf16be = 245,
    /// <summary>IEEE-754 half precision planar GBRA 4:4:4:4, 64bpp, little-endian</summary>
    Gbrapf16le = 246,
    /// <summary>IEEE-754 half precision Y, 16bpp, big-endian</summary>
    Grayf16be = 247,
    /// <summary>IEEE-754 half precision Y, 16bpp, little-endian</summary>
    Grayf16le = 248,
    /// <summary>HW acceleration through AMF. data[0] contain AMFSurface pointer</summary>
    AmfSurface = 249,
    /// <summary>Y , 32bpp, big-endian</summary>
    Gray32be = 250,
    /// <summary>Y , 32bpp, little-endian</summary>
    Gray32le = 251,
    /// <summary>IEEE-754 single precision packed YA, 32 bits gray, 32 bits alpha, 64bpp, big-endian</summary>
    Yaf32be = 252,
    /// <summary>IEEE-754 single precision packed YA, 32 bits gray, 32 bits alpha, 64bpp, little-endian</summary>
    Yaf32le = 253,
    /// <summary>IEEE-754 half precision packed YA, 16 bits gray, 16 bits alpha, 32bpp, big-endian</summary>
    Yaf16be = 254,
    /// <summary>IEEE-754 half precision packed YA, 16 bits gray, 16 bits alpha, 32bpp, little-endian</summary>
    Yaf16le = 255,
    /// <summary>planar GBRA 4:4:4:4 128bpp, big-endian</summary>
    Gbrap32be = 256,
    /// <summary>planar GBRA 4:4:4:4 128bpp, little-endian</summary>
    Gbrap32le = 257,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), lowest bits zero, big-endian</summary>
    Yuv444p10msbbe = 258,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), lowest bits zero, little-endian</summary>
    Yuv444p10msble = 259,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), lowest bits zero, big-endian</summary>
    Yuv444p12msbbe = 260,
    /// <summary>planar YUV 4:4:4, 30bpp, (1 Cr &amp; Cb sample per 1x1 Y samples), lowest bits zero, little-endian</summary>
    Yuv444p12msble = 261,
    /// <summary>planar GBR 4:4:4 30bpp, lowest bits zero, big-endian</summary>
    Gbrp10msbbe = 262,
    /// <summary>planar GBR 4:4:4 30bpp, lowest bits zero, little-endian</summary>
    Gbrp10msble = 263,
    /// <summary>planar GBR 4:4:4 36bpp, lowest bits zero, big-endian</summary>
    Gbrp12msbbe = 264,
    /// <summary>planar GBR 4:4:4 36bpp, lowest bits zero, little-endian</summary>
    Gbrp12msble = 265,
    Ohcodec = 266,
    /// <summary>number of pixel formats, DO NOT USE THIS if you want to link with shared libav* because the number of formats might differ between versions</summary>
    Nb = 267,
}

/// <summary>Rounding methods.</summary>
public enum AVRounding : int
{
    /// <summary>Round toward zero.</summary>
    Zero = 0,
    /// <summary>Round away from zero.</summary>
    Inf = 1,
    /// <summary>Round toward -infinity.</summary>
    Down = 2,
    /// <summary>Round toward +infinity.</summary>
    Up = 3,
    /// <summary>Round to nearest and halfway cases away from zero.</summary>
    NearInf = 5,
    /// <summary>Flag telling rescaling functions to pass `INT64_MIN`/`MAX` through unchanged, avoiding special cases for #AV_NOPTS_VALUE.</summary>
    PassMinmax = 8192,
}

/// <summary>Audio sample formats</summary>
public enum AVSampleFormat : int
{
    None = -1,
    /// <summary>unsigned 8 bits</summary>
    U8 = 0,
    /// <summary>signed 16 bits</summary>
    S16 = 1,
    /// <summary>signed 32 bits</summary>
    S32 = 2,
    /// <summary>float</summary>
    Flt = 3,
    /// <summary>double</summary>
    Dbl = 4,
    /// <summary>unsigned 8 bits, planar</summary>
    U8p = 5,
    /// <summary>signed 16 bits, planar</summary>
    S16p = 6,
    /// <summary>signed 32 bits, planar</summary>
    S32p = 7,
    /// <summary>float, planar</summary>
    Fltp = 8,
    /// <summary>double, planar</summary>
    Dblp = 9,
    /// <summary>signed 64 bits</summary>
    S64 = 10,
    /// <summary>signed 64 bits, planar</summary>
    S64p = 11,
    /// <summary>Number of sample formats. DO NOT USE if linking dynamically</summary>
    Nb = 12,
}

public enum AVSideDataParamChangeFlags : int
{
    SampleRate = 4,
    Dimensions = 8,
}

[Flags]
public enum AVSideDataProps : int
{
    None = 0,
    /// <summary>The side data type can be used in stream-global structures. Side data types without this property are only meaningful on per-frame basis.</summary>
    Global = 1,
    /// <summary>Multiple instances of this side data type can be meaningfully present in a single side data array.</summary>
    Multi = 2,
    /// <summary>Side data depends on the video dimensions. Side data with this property loses its meaning when rescaling or cropping the image, unless either recomputed or adjusted to the new resolution.</summary>
    SizeDependent = 4,
    /// <summary>Side data depends on the video color space. Side data with this property loses its meaning when changing the video color encoding, e.g. by adapting to a different set of primaries or transfer characteristics.</summary>
    ColorDependent = 8,
    /// <summary>Side data depends on the channel layout. Side data with this property loses its meaning when downmixing or upmixing, unless either recomputed or adjusted to the new layout.</summary>
    ChannelDependent = 16,
}

public enum AVStreamGroupParamsType : int
{
    None = 0,
    IamfAudioElement = 1,
    IamfMixPresentation = 2,
    TileGrid = 3,
    Lcevc = 4,
}

/// <summary>@}</summary>
public enum AVStreamParseType : int
{
    None = 0,
    /// <summary>full parsing and repack</summary>
    Full = 1,
    /// <summary>Only parse headers, do not repack.</summary>
    Headers = 2,
    /// <summary>full parsing and interpolation of timestamps for frames not starting on a packet boundary</summary>
    Timestamps = 3,
    /// <summary>full parsing and repack of the first frame only, only implemented for H.264 currently</summary>
    FullOnce = 4,
    /// <summary>full parsing and repack with timestamp and position generation by parser for raw this assumes that each packet in the file contains no demuxer level headers and just codec level data, otherwise position generation would fail</summary>
    FullRaw = 5,
}

/// <summary>@}</summary>
public enum AVSubtitleType : int
{
    None = 0,
    /// <summary>A bitmap, pict will be set</summary>
    Bitmap = 1,
    /// <summary>Plain text, the text field must be set by the decoder and is authoritative. ass and pict fields may contain approximations.</summary>
    Text = 2,
    /// <summary>Formatted text, the ass field must be set by the decoder and is authoritative. pict and text fields may contain approximations.</summary>
    Ass = 3,
}

public enum AVTimebaseSource : int
{
    Auto = -1,
    Decoder = 0,
    Demuxer = 1,
    RFramerate = 2,
}

public enum AVTimecodeFlag : int
{
    /// <summary>timecode is drop frame</summary>
    Dropframe = 1,
    /// <summary>timecode wraps after 24 hours</summary>
    _24HOURSMAX = 2,
    /// <summary>negative time values are allowed</summary>
    Allownegative = 4,
}

/// <summary>Defines the behaviour of frame allocation.</summary>
public enum AVVkFrameFlags : int
{
    None = 1,
    DisableMultiplane = 4,
}

/// <summary>Macro enum, prefix: AV_BUFFERSINK_FLAG_</summary>
[Flags]
public enum BufferSinkFlags : int
{
    None = 0,
    /// <summary>AV_BUFFERSINK_FLAG_PEEK</summary>
    Peek = 1,
    /// <summary>AV_BUFFERSINK_FLAG_NO_REQUEST</summary>
    NoRequest = 2,
}

/// <summary>Macro enum, prefix: AV_CH_</summary>
[Flags]
public enum ChannelFlags : ulong
{
    None = 0,
    /// <summary>AV_CH_FRONT_LEFT</summary>
    FrontLeft = 1UL << (int)AVChannel.FrontLeft,
    /// <summary>AV_CH_FRONT_RIGHT</summary>
    FrontRight = 1UL << (int)AVChannel.FrontRight,
    /// <summary>AV_CH_FRONT_CENTER</summary>
    FrontCenter = 1UL << (int)AVChannel.FrontCenter,
    /// <summary>AV_CH_LOW_FREQUENCY</summary>
    LowFrequency = 1UL << (int)AVChannel.LowFrequency,
    /// <summary>AV_CH_BACK_LEFT</summary>
    BackLeft = 1UL << (int)AVChannel.BackLeft,
    /// <summary>AV_CH_BACK_RIGHT</summary>
    BackRight = 1UL << (int)AVChannel.BackRight,
    /// <summary>AV_CH_FRONT_LEFT_OF_CENTER</summary>
    FrontLeftOfCenter = 1UL << (int)AVChannel.FrontLeftOfCenter,
    /// <summary>AV_CH_FRONT_RIGHT_OF_CENTER</summary>
    FrontRightOfCenter = 1UL << (int)AVChannel.FrontRightOfCenter,
    /// <summary>AV_CH_BACK_CENTER</summary>
    BackCenter = 1UL << (int)AVChannel.BackCenter,
    /// <summary>AV_CH_SIDE_LEFT</summary>
    SideLeft = 1UL << (int)AVChannel.SideLeft,
    /// <summary>AV_CH_SIDE_RIGHT</summary>
    SideRight = 1UL << (int)AVChannel.SideRight,
    /// <summary>AV_CH_TOP_CENTER</summary>
    TopCenter = 1UL << (int)AVChannel.TopCenter,
    /// <summary>AV_CH_TOP_FRONT_LEFT</summary>
    TopFrontLeft = 1UL << (int)AVChannel.TopFrontLeft,
    /// <summary>AV_CH_TOP_FRONT_CENTER</summary>
    TopFrontCenter = 1UL << (int)AVChannel.TopFrontCenter,
    /// <summary>AV_CH_TOP_FRONT_RIGHT</summary>
    TopFrontRight = 1UL << (int)AVChannel.TopFrontRight,
    /// <summary>AV_CH_TOP_BACK_LEFT</summary>
    TopBackLeft = 1UL << (int)AVChannel.TopBackLeft,
    /// <summary>AV_CH_TOP_BACK_CENTER</summary>
    TopBackCenter = 1UL << (int)AVChannel.TopBackCenter,
    /// <summary>AV_CH_TOP_BACK_RIGHT</summary>
    TopBackRight = 1UL << (int)AVChannel.TopBackRight,
    /// <summary>AV_CH_STEREO_LEFT</summary>
    StereoLeft = 1UL << (int)AVChannel.StereoLeft,
    /// <summary>AV_CH_STEREO_RIGHT</summary>
    StereoRight = 1UL << (int)AVChannel.StereoRight,
    /// <summary>AV_CH_WIDE_LEFT</summary>
    WideLeft = 1UL << (int)AVChannel.WideLeft,
    /// <summary>AV_CH_WIDE_RIGHT</summary>
    WideRight = 1UL << (int)AVChannel.WideRight,
    /// <summary>AV_CH_SURROUND_DIRECT_LEFT</summary>
    SurroundDirectLeft = 1UL << (int)AVChannel.SurroundDirectLeft,
    /// <summary>AV_CH_SURROUND_DIRECT_RIGHT</summary>
    SurroundDirectRight = 1UL << (int)AVChannel.SurroundDirectRight,
    /// <summary>AV_CH_LOW_FREQUENCY_2</summary>
    LowFrequency_2 = 1UL << (int)AVChannel.LowFrequency_2,
    /// <summary>AV_CH_TOP_SIDE_LEFT</summary>
    TopSideLeft = 1UL << (int)AVChannel.TopSideLeft,
    /// <summary>AV_CH_TOP_SIDE_RIGHT</summary>
    TopSideRight = 1UL << (int)AVChannel.TopSideRight,
    /// <summary>AV_CH_BOTTOM_FRONT_CENTER</summary>
    BottomFrontCenter = 1UL << (int)AVChannel.BottomFrontCenter,
    /// <summary>AV_CH_BOTTOM_FRONT_LEFT</summary>
    BottomFrontLeft = 1UL << (int)AVChannel.BottomFrontLeft,
    /// <summary>AV_CH_BOTTOM_FRONT_RIGHT</summary>
    BottomFrontRight = 1UL << (int)AVChannel.BottomFrontRight,
    /// <summary>AV_CH_SIDE_SURROUND_LEFT</summary>
    SideSurroundLeft = 1UL << (int)AVChannel.SideSurroundLeft,
    /// <summary>AV_CH_SIDE_SURROUND_RIGHT</summary>
    SideSurroundRight = 1UL << (int)AVChannel.SideSurroundRight,
    /// <summary>AV_CH_TOP_SURROUND_LEFT</summary>
    TopSurroundLeft = 1UL << (int)AVChannel.TopSurroundLeft,
    /// <summary>AV_CH_TOP_SURROUND_RIGHT</summary>
    TopSurroundRight = 1UL << (int)AVChannel.TopSurroundRight,
    /// <summary>AV_CH_BINAURAL_LEFT</summary>
    BinauralLeft = 1UL << (int)AVChannel.BinauralLeft,
    /// <summary>AV_CH_BINAURAL_RIGHT</summary>
    BinauralRight = 1UL << (int)AVChannel.BinauralRight,
    /// <summary>AV_CH_LAYOUT_MONO</summary>
    LayoutMono = FrontCenter,
    /// <summary>AV_CH_LAYOUT_STEREO</summary>
    LayoutStereo = FrontLeft | FrontRight,
    /// <summary>AV_CH_LAYOUT_2POINT1</summary>
    Layout_2POINT1 = LayoutStereo | LowFrequency,
    /// <summary>AV_CH_LAYOUT_2_1</summary>
    Layout_2_1 = LayoutStereo | BackCenter,
    /// <summary>AV_CH_LAYOUT_SURROUND</summary>
    LayoutSurround = LayoutStereo | FrontCenter,
    /// <summary>AV_CH_LAYOUT_3POINT1</summary>
    Layout_3POINT1 = LayoutSurround | LowFrequency,
    /// <summary>AV_CH_LAYOUT_4POINT0</summary>
    Layout_4POINT0 = LayoutSurround | BackCenter,
    /// <summary>AV_CH_LAYOUT_4POINT1</summary>
    Layout_4POINT1 = Layout_4POINT0 | LowFrequency,
    /// <summary>AV_CH_LAYOUT_2_2</summary>
    Layout_2_2 = LayoutStereo | SideLeft | SideRight,
    /// <summary>AV_CH_LAYOUT_QUAD</summary>
    LayoutQuad = LayoutStereo | BackLeft | BackRight,
    /// <summary>AV_CH_LAYOUT_5POINT0</summary>
    Layout_5POINT0 = LayoutSurround | SideLeft | SideRight,
    /// <summary>AV_CH_LAYOUT_5POINT1</summary>
    Layout_5POINT1 = Layout_5POINT0 | LowFrequency,
    /// <summary>AV_CH_LAYOUT_5POINT0_BACK</summary>
    Layout_5POINT0Back = LayoutSurround | BackLeft | BackRight,
    /// <summary>AV_CH_LAYOUT_5POINT1_BACK</summary>
    Layout_5POINT1Back = Layout_5POINT0Back | LowFrequency,
    /// <summary>AV_CH_LAYOUT_6POINT0</summary>
    Layout_6POINT0 = Layout_5POINT0 | BackCenter,
    /// <summary>AV_CH_LAYOUT_6POINT0_FRONT</summary>
    Layout_6POINT0Front = Layout_2_2 | FrontLeftOfCenter | FrontRightOfCenter,
    /// <summary>AV_CH_LAYOUT_HEXAGONAL</summary>
    LayoutHexagonal = Layout_5POINT0Back | BackCenter,
    /// <summary>AV_CH_LAYOUT_3POINT1POINT2</summary>
    Layout_3POINT1POINT2 = Layout_3POINT1 | TopFrontLeft | TopFrontRight,
    /// <summary>AV_CH_LAYOUT_6POINT1</summary>
    Layout_6POINT1 = Layout_5POINT1 | BackCenter,
    /// <summary>AV_CH_LAYOUT_6POINT1_BACK</summary>
    Layout_6POINT1Back = Layout_5POINT1Back | BackCenter,
    /// <summary>AV_CH_LAYOUT_6POINT1_FRONT</summary>
    Layout_6POINT1Front = Layout_6POINT0Front | LowFrequency,
    /// <summary>AV_CH_LAYOUT_7POINT0</summary>
    Layout_7POINT0 = Layout_5POINT0 | BackLeft | BackRight,
    /// <summary>AV_CH_LAYOUT_7POINT0_FRONT</summary>
    Layout_7POINT0Front = Layout_5POINT0 | FrontLeftOfCenter | FrontRightOfCenter,
    /// <summary>AV_CH_LAYOUT_7POINT1</summary>
    Layout_7POINT1 = Layout_5POINT1 | BackLeft | BackRight,
    /// <summary>AV_CH_LAYOUT_7POINT1_WIDE</summary>
    Layout_7POINT1Wide = Layout_5POINT1 | FrontLeftOfCenter | FrontRightOfCenter,
    /// <summary>AV_CH_LAYOUT_7POINT1_WIDE_BACK</summary>
    Layout_7POINT1WideBack = Layout_5POINT1Back | FrontLeftOfCenter | FrontRightOfCenter,
    /// <summary>AV_CH_LAYOUT_5POINT1POINT2</summary>
    Layout_5POINT1POINT2 = Layout_5POINT1 | TopFrontLeft | TopFrontRight,
    /// <summary>AV_CH_LAYOUT_5POINT1POINT2_BACK</summary>
    Layout_5POINT1POINT2Back = Layout_5POINT1Back | TopFrontLeft | TopFrontRight,
    /// <summary>AV_CH_LAYOUT_OCTAGONAL</summary>
    LayoutOctagonal = Layout_5POINT0 | BackLeft | BackCenter | BackRight,
    /// <summary>AV_CH_LAYOUT_CUBE</summary>
    LayoutCube = LayoutQuad | TopFrontLeft | TopFrontRight | TopBackLeft | TopBackRight,
    /// <summary>AV_CH_LAYOUT_5POINT1POINT4_BACK</summary>
    Layout_5POINT1POINT4Back = Layout_5POINT1POINT2 | TopBackLeft | TopBackRight,
    /// <summary>AV_CH_LAYOUT_7POINT1POINT2</summary>
    Layout_7POINT1POINT2 = Layout_7POINT1 | TopFrontLeft | TopFrontRight,
    /// <summary>AV_CH_LAYOUT_7POINT1POINT4_BACK</summary>
    Layout_7POINT1POINT4Back = Layout_7POINT1POINT2 | TopBackLeft | TopBackRight,
    /// <summary>AV_CH_LAYOUT_7POINT2POINT3</summary>
    Layout_7POINT2POINT3 = Layout_7POINT1POINT2 | TopBackCenter | LowFrequency_2,
    /// <summary>AV_CH_LAYOUT_9POINT1POINT4_BACK</summary>
    Layout_9POINT1POINT4Back = Layout_7POINT1POINT4Back | FrontLeftOfCenter | FrontRightOfCenter,
    /// <summary>AV_CH_LAYOUT_9POINT1POINT6</summary>
    Layout_9POINT1POINT6 = Layout_9POINT1POINT4Back | TopSideLeft | TopSideRight,
    /// <summary>AV_CH_LAYOUT_HEXADECAGONAL</summary>
    LayoutHexadecagonal = LayoutOctagonal | WideLeft | WideRight | TopBackLeft | TopBackRight | TopBackCenter | TopFrontCenter | TopFrontLeft | TopFrontRight,
    /// <summary>AV_CH_LAYOUT_BINAURAL</summary>
    LayoutBinaural = BinauralLeft | BinauralRight,
    /// <summary>AV_CH_LAYOUT_STEREO_DOWNMIX</summary>
    LayoutStereoDownmix = StereoLeft | StereoRight,
    /// <summary>AV_CH_LAYOUT_22POINT2</summary>
    Layout_22POINT2 = Layout_9POINT1POINT6 | BackCenter | LowFrequency_2 | TopFrontCenter | TopCenter | TopBackCenter | BottomFrontCenter | BottomFrontLeft | BottomFrontRight,
    /// <summary>AV_CH_LAYOUT_7POINT1_TOP_BACK</summary>
    Layout_7POINT1TopBack = Layout_5POINT1POINT2Back,
}

/// <summary>Macro enum, prefix: AV_CODEC_CAP_</summary>
[Flags]
public enum CodecCapFlags : int
{
    None = 0,
    /// <summary>AV_CODEC_CAP_DRAW_HORIZ_BAND</summary>
    DrawHorizBand = 1 << 0,
    /// <summary>AV_CODEC_CAP_DR1</summary>
    Dr1 = 1 << 1,
    /// <summary>AV_CODEC_CAP_DELAY</summary>
    Delay = 1 << 5,
    /// <summary>AV_CODEC_CAP_SMALL_LAST_FRAME</summary>
    SmallLastFrame = 1 << 6,
    /// <summary>AV_CODEC_CAP_EXPERIMENTAL</summary>
    Experimental = 1 << 9,
    /// <summary>AV_CODEC_CAP_CHANNEL_CONF</summary>
    ChannelConf = 1 << 10,
    /// <summary>AV_CODEC_CAP_FRAME_THREADS</summary>
    FrameThreads = 1 << 12,
    /// <summary>AV_CODEC_CAP_SLICE_THREADS</summary>
    SliceThreads = 1 << 13,
    /// <summary>AV_CODEC_CAP_PARAM_CHANGE</summary>
    ParamChange = 1 << 14,
    /// <summary>AV_CODEC_CAP_OTHER_THREADS</summary>
    OtherThreads = 1 << 15,
    /// <summary>AV_CODEC_CAP_VARIABLE_FRAME_SIZE</summary>
    VariableFrameSize = 1 << 16,
    /// <summary>AV_CODEC_CAP_AVOID_PROBING</summary>
    AvoidProbing = 1 << 17,
    /// <summary>AV_CODEC_CAP_HARDWARE</summary>
    Hardware = 1 << 18,
    /// <summary>AV_CODEC_CAP_HYBRID</summary>
    Hybrid = 1 << 19,
    /// <summary>AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE</summary>
    EncoderReorderedOpaque = 1 << 20,
    /// <summary>AV_CODEC_CAP_ENCODER_FLUSH</summary>
    EncoderFlush = 1 << 21,
    /// <summary>AV_CODEC_CAP_ENCODER_RECON_FRAME</summary>
    EncoderReconFrame = 1 << 22,
}

/// <summary>Macro enum, prefix: AV_CODEC_EXPORT_DATA_</summary>
[Flags]
public enum CodecExportDataFlags : int
{
    None = 0,
    /// <summary>AV_CODEC_EXPORT_DATA_MVS</summary>
    Mvs = 1 << 0,
    /// <summary>AV_CODEC_EXPORT_DATA_PRFT</summary>
    Prft = 1 << 1,
    /// <summary>AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS</summary>
    VideoEncParams = 1 << 2,
    /// <summary>AV_CODEC_EXPORT_DATA_FILM_GRAIN</summary>
    FilmGrain = 1 << 3,
    /// <summary>AV_CODEC_EXPORT_DATA_ENHANCEMENTS</summary>
    Enhancements = 1 << 4,
}

/// <summary>Macro enum, prefix: AV_CODEC_FLAG_</summary>
[Flags]
public enum CodecFlags : uint
{
    None = 0,
    /// <summary>AV_CODEC_FLAG_UNALIGNED</summary>
    Unaligned = 1 << 0,
    /// <summary>AV_CODEC_FLAG_QSCALE</summary>
    Qscale = 1 << 1,
    /// <summary>AV_CODEC_FLAG_4MV</summary>
    _4MV = 1 << 2,
    /// <summary>AV_CODEC_FLAG_OUTPUT_CORRUPT</summary>
    OutputCorrupt = 1 << 3,
    /// <summary>AV_CODEC_FLAG_QPEL</summary>
    Qpel = 1 << 4,
    /// <summary>AV_CODEC_FLAG_RECON_FRAME</summary>
    ReconFrame = 1 << 6,
    /// <summary>AV_CODEC_FLAG_COPY_OPAQUE</summary>
    CopyOpaque = 1 << 7,
    /// <summary>AV_CODEC_FLAG_FRAME_DURATION</summary>
    FrameDuration = 1 << 8,
    /// <summary>AV_CODEC_FLAG_PASS1</summary>
    Pass1 = 1 << 9,
    /// <summary>AV_CODEC_FLAG_PASS2</summary>
    Pass2 = 1 << 10,
    /// <summary>AV_CODEC_FLAG_LOOP_FILTER</summary>
    LoopFilter = 1 << 11,
    /// <summary>AV_CODEC_FLAG_GRAY</summary>
    Gray = 1 << 13,
    /// <summary>AV_CODEC_FLAG_PSNR</summary>
    Psnr = 1 << 15,
    /// <summary>AV_CODEC_FLAG_INTERLACED_DCT</summary>
    InterlacedDct = 1 << 18,
    /// <summary>AV_CODEC_FLAG_LOW_DELAY</summary>
    LowDelay = 1 << 19,
    /// <summary>AV_CODEC_FLAG_GLOBAL_HEADER</summary>
    GlobalHeader = 1 << 22,
    /// <summary>AV_CODEC_FLAG_BITEXACT</summary>
    Bitexact = 1 << 23,
    /// <summary>AV_CODEC_FLAG_AC_PRED</summary>
    AcPred = 1 << 24,
    /// <summary>AV_CODEC_FLAG_INTERLACED_ME</summary>
    InterlacedMe = 1 << 29,
    /// <summary>AV_CODEC_FLAG_CLOSED_GOP</summary>
    ClosedGop = 1U << 31,
}

/// <summary>Macro enum, prefix: AV_CODEC_FLAG2_</summary>
[Flags]
public enum CodecFlags2 : uint
{
    None = 0,
    /// <summary>AV_CODEC_FLAG2_FAST</summary>
    Fast = 1 << 0,
    /// <summary>AV_CODEC_FLAG2_NO_OUTPUT</summary>
    NoOutput = 1 << 2,
    /// <summary>AV_CODEC_FLAG2_LOCAL_HEADER</summary>
    LocalHeader = 1 << 3,
    /// <summary>AV_CODEC_FLAG2_CHUNKS</summary>
    Chunks = 1 << 15,
    /// <summary>AV_CODEC_FLAG2_IGNORE_CROP</summary>
    IgnoreCrop = 1 << 16,
    /// <summary>AV_CODEC_FLAG2_SHOW_ALL</summary>
    ShowAll = 1 << 22,
    /// <summary>AV_CODEC_FLAG2_EXPORT_MVS</summary>
    ExportMvs = 1 << 28,
    /// <summary>AV_CODEC_FLAG2_SKIP_MANUAL</summary>
    SkipManual = 1 << 29,
    /// <summary>AV_CODEC_FLAG2_RO_FLUSH_NOOP</summary>
    RoFlushNoop = 1 << 30,
    /// <summary>AV_CODEC_FLAG2_ICC_PROFILES</summary>
    IccProfiles = 1U << 31,
}

/// <summary>Macro enum, prefix: FF_CODEC_PROPERTY_</summary>
[Flags]
public enum CodecPropertyFlags : uint
{
    None = 0,
    /// <summary>FF_CODEC_PROPERTY_LOSSLESS</summary>
    Lossless = 0x00000001,
    /// <summary>FF_CODEC_PROPERTY_CLOSED_CAPTIONS</summary>
    ClosedCaptions = 0x00000002,
    /// <summary>FF_CODEC_PROPERTY_FILM_GRAIN</summary>
    FilmGrain = 0x00000004,
}

/// <summary>Macro enum, prefix: AV_CODEC_PROP_</summary>
[Flags]
public enum CodecPropFlags : int
{
    None = 0,
    /// <summary>AV_CODEC_PROP_INTRA_ONLY</summary>
    IntraOnly = 1 << 0,
    /// <summary>AV_CODEC_PROP_LOSSY</summary>
    Lossy = 1 << 1,
    /// <summary>AV_CODEC_PROP_LOSSLESS</summary>
    Lossless = 1 << 2,
    /// <summary>AV_CODEC_PROP_REORDER</summary>
    Reorder = 1 << 3,
    /// <summary>AV_CODEC_PROP_FIELDS</summary>
    Fields = 1 << 4,
    /// <summary>AV_CODEC_PROP_BITMAP_SUB</summary>
    BitmapSub = 1 << 16,
    /// <summary>AV_CODEC_PROP_TEXT_SUB</summary>
    TextSub = 1 << 17,
}

/// <summary>Macro enum, prefix: FF_CMP_</summary>
public enum CompareFunction : int
{
    /// <summary>FF_CMP_SAD</summary>
    Sad = 0,
    /// <summary>FF_CMP_SSE</summary>
    Sse = 1,
    /// <summary>FF_CMP_SATD</summary>
    Satd = 2,
    /// <summary>FF_CMP_DCT</summary>
    Dct = 3,
    /// <summary>FF_CMP_PSNR</summary>
    Psnr = 4,
    /// <summary>FF_CMP_BIT</summary>
    Bit = 5,
    /// <summary>FF_CMP_RD</summary>
    Rd = 6,
    /// <summary>FF_CMP_ZERO</summary>
    Zero = 7,
    /// <summary>FF_CMP_VSAD</summary>
    Vsad = 8,
    /// <summary>FF_CMP_VSSE</summary>
    Vsse = 9,
    /// <summary>FF_CMP_NSSE</summary>
    Nsse = 10,
    /// <summary>FF_CMP_W53</summary>
    W53 = 11,
    /// <summary>FF_CMP_W97</summary>
    W97 = 12,
    /// <summary>FF_CMP_DCTMAX</summary>
    Dctmax = 13,
    /// <summary>FF_CMP_DCT264</summary>
    Dct264 = 14,
    /// <summary>FF_CMP_MEDIAN_SAD</summary>
    MedianSad = 15,
    /// <summary>FF_CMP_CHROMA</summary>
    Chroma = 256,
}

/// <summary>Macro enum, prefix: AV_CPU_FLAG_</summary>
[Flags]
public enum CpuFlags : uint
{
    None = 0,
    /// <summary>AV_CPU_FLAG_FORCE</summary>
    Force = 0x80000000,
    /// <summary>AV_CPU_FLAG_MMX</summary>
    Mmx = 0x0001,
    /// <summary>AV_CPU_FLAG_MMXEXT</summary>
    Mmxext = 0x0002,
    /// <summary>AV_CPU_FLAG_MMX2</summary>
    Mmx2 = 0x0002,
    /// <summary>AV_CPU_FLAG_3DNOW</summary>
    _3DNOW = 0x0004,
    /// <summary>AV_CPU_FLAG_SSE</summary>
    Sse = 0x0008,
    /// <summary>AV_CPU_FLAG_SSE2</summary>
    Sse2 = 0x0010,
    /// <summary>AV_CPU_FLAG_SSE2SLOW</summary>
    Sse2slow = 0x40000000,
    /// <summary>AV_CPU_FLAG_3DNOWEXT</summary>
    _3DNOWEXT = 0x0020,
    /// <summary>AV_CPU_FLAG_SSE3</summary>
    Sse3 = 0x0040,
    /// <summary>AV_CPU_FLAG_SSE3SLOW</summary>
    Sse3slow = 0x20000000,
    /// <summary>AV_CPU_FLAG_SSSE3</summary>
    Ssse3 = 0x0080,
    /// <summary>AV_CPU_FLAG_SSSE3SLOW</summary>
    Ssse3slow = 0x4000000,
    /// <summary>AV_CPU_FLAG_ATOM</summary>
    Atom = 0x10000000,
    /// <summary>AV_CPU_FLAG_SSE4</summary>
    Sse4 = 0x0100,
    /// <summary>AV_CPU_FLAG_SSE42</summary>
    Sse42 = 0x0200,
    /// <summary>AV_CPU_FLAG_AESNI</summary>
    Aesni = 0x80000,
    /// <summary>AV_CPU_FLAG_AVX</summary>
    Avx = 0x4000,
    /// <summary>AV_CPU_FLAG_AVXSLOW</summary>
    Avxslow = 0x8000000,
    /// <summary>AV_CPU_FLAG_XOP</summary>
    Xop = 0x0400,
    /// <summary>AV_CPU_FLAG_FMA4</summary>
    Fma4 = 0x0800,
    /// <summary>AV_CPU_FLAG_CMOV</summary>
    Cmov = 0x1000,
    /// <summary>AV_CPU_FLAG_AVX2</summary>
    Avx2 = 0x8000,
    /// <summary>AV_CPU_FLAG_FMA3</summary>
    Fma3 = 0x10000,
    /// <summary>AV_CPU_FLAG_BMI1</summary>
    Bmi1 = 0x20000,
    /// <summary>AV_CPU_FLAG_BMI2</summary>
    Bmi2 = 0x40000,
    /// <summary>AV_CPU_FLAG_AVX512</summary>
    Avx512 = 0x100000,
    /// <summary>AV_CPU_FLAG_AVX512ICL</summary>
    Avx512icl = 0x200000,
    /// <summary>AV_CPU_FLAG_SLOW_GATHER</summary>
    SlowGather = 0x2000000,
    /// <summary>AV_CPU_FLAG_ALTIVEC</summary>
    Altivec = 0x0001,
    /// <summary>AV_CPU_FLAG_VSX</summary>
    Vsx = 0x0002,
    /// <summary>AV_CPU_FLAG_POWER8</summary>
    Power8 = 0x0004,
    /// <summary>AV_CPU_FLAG_ARMV5TE</summary>
    Armv5te = 1 << 0,
    /// <summary>AV_CPU_FLAG_ARMV6</summary>
    Armv6 = 1 << 1,
    /// <summary>AV_CPU_FLAG_ARMV6T2</summary>
    Armv6t2 = 1 << 2,
    /// <summary>AV_CPU_FLAG_VFP</summary>
    Vfp = 1 << 3,
    /// <summary>AV_CPU_FLAG_VFPV3</summary>
    Vfpv3 = 1 << 4,
    /// <summary>AV_CPU_FLAG_NEON</summary>
    Neon = 1 << 5,
    /// <summary>AV_CPU_FLAG_ARMV8</summary>
    Armv8 = 1 << 6,
    /// <summary>AV_CPU_FLAG_VFP_VM</summary>
    VfpVm = 1 << 7,
    /// <summary>AV_CPU_FLAG_DOTPROD</summary>
    Dotprod = 1 << 8,
    /// <summary>AV_CPU_FLAG_I8MM</summary>
    I8mm = 1 << 9,
    /// <summary>AV_CPU_FLAG_SVE</summary>
    Sve = 1 << 10,
    /// <summary>AV_CPU_FLAG_SVE2</summary>
    Sve2 = 1 << 11,
    /// <summary>AV_CPU_FLAG_SETEND</summary>
    Setend = 1 << 16,
    /// <summary>AV_CPU_FLAG_MMI</summary>
    Mmi = 1 << 0,
    /// <summary>AV_CPU_FLAG_MSA</summary>
    Msa = 1 << 1,
    /// <summary>AV_CPU_FLAG_LSX</summary>
    Lsx = 1 << 0,
    /// <summary>AV_CPU_FLAG_LASX</summary>
    Lasx = 1 << 1,
    /// <summary>AV_CPU_FLAG_RVI</summary>
    Rvi = 1 << 0,
    /// <summary>AV_CPU_FLAG_RVF</summary>
    Rvf = 1 << 1,
    /// <summary>AV_CPU_FLAG_RVD</summary>
    Rvd = 1 << 2,
    /// <summary>AV_CPU_FLAG_RVV_I32</summary>
    RvvI32 = 1 << 3,
    /// <summary>AV_CPU_FLAG_RVV_F32</summary>
    RvvF32 = 1 << 4,
    /// <summary>AV_CPU_FLAG_RVV_I64</summary>
    RvvI64 = 1 << 5,
    /// <summary>AV_CPU_FLAG_RVV_F64</summary>
    RvvF64 = 1 << 6,
    /// <summary>AV_CPU_FLAG_RVB_BASIC</summary>
    RvbBasic = 1 << 7,
    /// <summary>AV_CPU_FLAG_RVB_ADDR</summary>
    RvbAddr = 1 << 8,
    /// <summary>AV_CPU_FLAG_RV_ZVBB</summary>
    RvZvbb = 1 << 9,
    /// <summary>AV_CPU_FLAG_RV_MISALIGNED</summary>
    RvMisaligned = 1 << 10,
    /// <summary>AV_CPU_FLAG_RVB</summary>
    Rvb = 1 << 11,
    /// <summary>AV_CPU_FLAG_SIMD128</summary>
    Simd128 = 1 << 0,
}

public enum D3D12_RESOURCE_FLAGS : int
{
    None = 0,
    AllowRenderTarget = 1,
    AllowDepthStencil = 2,
    AllowUnorderedAccess = 4,
    DenyShaderResource = 8,
    AllowCrossAdapter = 16,
    AllowSimultaneousAccess = 32,
    VideoDecodeReferenceOnly = 64,
    VideoEncodeReferenceOnly = 128,
    RaytracingAccelerationStructure = 256,
}

/// <summary>Macro enum, prefix: FF_DCT_</summary>
public enum DCTAlgo : int
{
    /// <summary>FF_DCT_AUTO</summary>
    Auto = 0,
    /// <summary>FF_DCT_FASTINT</summary>
    Fastint = 1,
    /// <summary>FF_DCT_INT</summary>
    Int = 2,
    /// <summary>FF_DCT_MMX</summary>
    Mmx = 3,
    /// <summary>FF_DCT_ALTIVEC</summary>
    Altivec = 5,
    /// <summary>FF_DCT_FAAN</summary>
    Faan = 6,
    /// <summary>FF_DCT_NEON</summary>
    Neon = 7,
}

/// <summary>Macro enum, prefix: FF_DEBUG_</summary>
[Flags]
public enum DebugFlags : uint
{
    None = 0,
    /// <summary>FF_DEBUG_PICT_INFO</summary>
    PictInfo = 1,
    /// <summary>FF_DEBUG_RC</summary>
    Rc = 2,
    /// <summary>FF_DEBUG_BITSTREAM</summary>
    Bitstream = 4,
    /// <summary>FF_DEBUG_MB_TYPE</summary>
    MbType = 8,
    /// <summary>FF_DEBUG_QP</summary>
    Qp = 16,
    /// <summary>FF_DEBUG_DCT_COEFF</summary>
    DctCoeff = 0x00000040,
    /// <summary>FF_DEBUG_SKIP</summary>
    Skip = 0x00000080,
    /// <summary>FF_DEBUG_STARTCODE</summary>
    Startcode = 0x00000100,
    /// <summary>FF_DEBUG_ER</summary>
    Er = 0x00000400,
    /// <summary>FF_DEBUG_MMCO</summary>
    Mmco = 0x00000800,
    /// <summary>FF_DEBUG_BUGS</summary>
    Bugs = 0x00001000,
    /// <summary>FF_DEBUG_BUFFERS</summary>
    Buffers = 0x00008000,
    /// <summary>FF_DEBUG_THREADS</summary>
    Threads = 0x00010000,
    /// <summary>FF_DEBUG_GREEN_MD</summary>
    GreenMd = 0x00800000,
    /// <summary>FF_DEBUG_NOMC</summary>
    Nomc = 0x01000000,
}

/// <summary>Macro enum, prefix: FF_DECODE_ERROR_</summary>
[Flags]
public enum DecodeErrorFlags : int
{
    None = 0,
    /// <summary>FF_DECODE_ERROR_INVALID_BITSTREAM</summary>
    InvalidBitstream = 1,
    /// <summary>FF_DECODE_ERROR_MISSING_REFERENCE</summary>
    MissingReference = 2,
    /// <summary>FF_DECODE_ERROR_CONCEALMENT_ACTIVE</summary>
    ConcealmentActive = 4,
    /// <summary>FF_DECODE_ERROR_DECODE_SLICES</summary>
    DecodeSlices = 8,
}

/// <summary>Macro enum, prefix: AV_DICT_</summary>
[Flags]
public enum DictReadFlags : int
{
    None = 0,
    /// <summary>AV_DICT_MATCH_CASE</summary>
    MatchCase = 1,
    /// <summary>AV_DICT_IGNORE_SUFFIX</summary>
    IgnoreSuffix = 2,
}

/// <summary>Macro enum, prefix: AV_DICT_</summary>
[Flags]
public enum DictWriteFlags : int
{
    None = 0,
    /// <summary>AV_DICT_DONT_STRDUP_KEY</summary>
    DontStrdupKey = 4,
    /// <summary>AV_DICT_DONT_STRDUP_VAL</summary>
    DontStrdupVal = 8,
    /// <summary>AV_DICT_DONT_OVERWRITE</summary>
    DontOverwrite = 16,
    /// <summary>AV_DICT_APPEND</summary>
    Append = 32,
    /// <summary>AV_DICT_MULTIKEY</summary>
    Multikey = 64,
    /// <summary>AV_DICT_DEDUP</summary>
    Dedup = 128,
}

/// <summary>Macro enum, prefix: AV_DISPOSITION_</summary>
[Flags]
public enum DispositionFlags : int
{
    None = 0,
    /// <summary>AV_DISPOSITION_DEFAULT</summary>
    Default = 1 << 0,
    /// <summary>AV_DISPOSITION_DUB</summary>
    Dub = 1 << 1,
    /// <summary>AV_DISPOSITION_ORIGINAL</summary>
    Original = 1 << 2,
    /// <summary>AV_DISPOSITION_COMMENT</summary>
    Comment = 1 << 3,
    /// <summary>AV_DISPOSITION_LYRICS</summary>
    Lyrics = 1 << 4,
    /// <summary>AV_DISPOSITION_KARAOKE</summary>
    Karaoke = 1 << 5,
    /// <summary>AV_DISPOSITION_FORCED</summary>
    Forced = 1 << 6,
    /// <summary>AV_DISPOSITION_HEARING_IMPAIRED</summary>
    HearingImpaired = 1 << 7,
    /// <summary>AV_DISPOSITION_VISUAL_IMPAIRED</summary>
    VisualImpaired = 1 << 8,
    /// <summary>AV_DISPOSITION_CLEAN_EFFECTS</summary>
    CleanEffects = 1 << 9,
    /// <summary>AV_DISPOSITION_ATTACHED_PIC</summary>
    AttachedPic = 1 << 10,
    /// <summary>AV_DISPOSITION_TIMED_THUMBNAILS</summary>
    TimedThumbnails = 1 << 11,
    /// <summary>AV_DISPOSITION_NON_DIEGETIC</summary>
    NonDiegetic = 1 << 12,
    /// <summary>AV_DISPOSITION_CAPTIONS</summary>
    Captions = 1 << 16,
    /// <summary>AV_DISPOSITION_DESCRIPTIONS</summary>
    Descriptions = 1 << 17,
    /// <summary>AV_DISPOSITION_METADATA</summary>
    Metadata = 1 << 18,
    /// <summary>AV_DISPOSITION_DEPENDENT</summary>
    Dependent = 1 << 19,
    /// <summary>AV_DISPOSITION_STILL_IMAGE</summary>
    StillImage = 1 << 20,
    /// <summary>AV_DISPOSITION_MULTILAYER</summary>
    Multilayer = 1 << 21,
}

public enum DXGI_FORMAT : int
{
    Unknown = 0,
    R32g32b32a32Typeless = 1,
    R32g32b32a32Float = 2,
    R32g32b32a32Uint = 3,
    R32g32b32a32Sint = 4,
    R32g32b32Typeless = 5,
    R32g32b32Float = 6,
    R32g32b32Uint = 7,
    R32g32b32Sint = 8,
    R16g16b16a16Typeless = 9,
    R16g16b16a16Float = 10,
    R16g16b16a16Unorm = 11,
    R16g16b16a16Uint = 12,
    R16g16b16a16Snorm = 13,
    R16g16b16a16Sint = 14,
    R32g32Typeless = 15,
    R32g32Float = 16,
    R32g32Uint = 17,
    R32g32Sint = 18,
    R32g8x24Typeless = 19,
    D32FloatS8x24Uint = 20,
    R32FloatX8x24Typeless = 21,
    X32TypelessG8x24Uint = 22,
    R10g10b10a2Typeless = 23,
    R10g10b10a2Unorm = 24,
    R10g10b10a2Uint = 25,
    R11g11b10Float = 26,
    R8g8b8a8Typeless = 27,
    R8g8b8a8Unorm = 28,
    R8g8b8a8UnormSrgb = 29,
    R8g8b8a8Uint = 30,
    R8g8b8a8Snorm = 31,
    R8g8b8a8Sint = 32,
    R16g16Typeless = 33,
    R16g16Float = 34,
    R16g16Unorm = 35,
    R16g16Uint = 36,
    R16g16Snorm = 37,
    R16g16Sint = 38,
    R32Typeless = 39,
    D32Float = 40,
    R32Float = 41,
    R32Uint = 42,
    R32Sint = 43,
    R24g8Typeless = 44,
    D24UnormS8Uint = 45,
    R24UnormX8Typeless = 46,
    X24TypelessG8Uint = 47,
    R8g8Typeless = 48,
    R8g8Unorm = 49,
    R8g8Uint = 50,
    R8g8Snorm = 51,
    R8g8Sint = 52,
    R16Typeless = 53,
    R16Float = 54,
    D16Unorm = 55,
    R16Unorm = 56,
    R16Uint = 57,
    R16Snorm = 58,
    R16Sint = 59,
    R8Typeless = 60,
    R8Unorm = 61,
    R8Uint = 62,
    R8Snorm = 63,
    R8Sint = 64,
    A8Unorm = 65,
    R1Unorm = 66,
    R9g9b9e5Sharedexp = 67,
    R8g8B8g8Unorm = 68,
    G8r8G8b8Unorm = 69,
    Bc1Typeless = 70,
    Bc1Unorm = 71,
    Bc1UnormSrgb = 72,
    Bc2Typeless = 73,
    Bc2Unorm = 74,
    Bc2UnormSrgb = 75,
    Bc3Typeless = 76,
    Bc3Unorm = 77,
    Bc3UnormSrgb = 78,
    Bc4Typeless = 79,
    Bc4Unorm = 80,
    Bc4Snorm = 81,
    Bc5Typeless = 82,
    Bc5Unorm = 83,
    Bc5Snorm = 84,
    B5g6r5Unorm = 85,
    B5g5r5a1Unorm = 86,
    B8g8r8a8Unorm = 87,
    B8g8r8x8Unorm = 88,
    R10g10b10XrBiasA2Unorm = 89,
    B8g8r8a8Typeless = 90,
    B8g8r8a8UnormSrgb = 91,
    B8g8r8x8Typeless = 92,
    B8g8r8x8UnormSrgb = 93,
    Bc6hTypeless = 94,
    Bc6hUf16 = 95,
    Bc6hSf16 = 96,
    Bc7Typeless = 97,
    Bc7Unorm = 98,
    Bc7UnormSrgb = 99,
    Ayuv = 100,
    Y410 = 101,
    Y416 = 102,
    Nv12 = 103,
    P010 = 104,
    P016 = 105,
    _420Opaque = 106,
    Yuy2 = 107,
    Y210 = 108,
    Y216 = 109,
    Nv11 = 110,
    Ai44 = 111,
    Ia44 = 112,
    P8 = 113,
    A8p8 = 114,
    B4g4r4a4Unorm = 115,
    P208 = 130,
    V208 = 131,
    V408 = 132,
    SamplerFeedbackMinMipOpaque = 189,
    SamplerFeedbackMipRegionUsedOpaque = 190,
    A4b4g4r4Unorm = 191,
    ForceUint = -1,
}

/// <summary>Macro enum, prefix: FF_EC_</summary>
[Flags]
public enum ErrorConcealmentFlags : int
{
    None = 0,
    /// <summary>FF_EC_GUESS_MVS</summary>
    GuessMvs = 1,
    /// <summary>FF_EC_DEBLOCK</summary>
    Deblock = 2,
    /// <summary>FF_EC_FAVOR_INTER</summary>
    FavorInter = 256,
}

/// <summary>Macro enum, prefix: AV_EF_</summary>
[Flags]
public enum ErrorDetectFlags : int
{
    None = 0,
    /// <summary>AV_EF_CRCCHECK</summary>
    Crccheck = 1 << 0,
    /// <summary>AV_EF_BITSTREAM</summary>
    Bitstream = 1 << 1,
    /// <summary>AV_EF_BUFFER</summary>
    Buffer = 1 << 2,
    /// <summary>AV_EF_EXPLODE</summary>
    Explode = 1 << 3,
    /// <summary>AV_EF_IGNORE_ERR</summary>
    IgnoreErr = 1 << 15,
    /// <summary>AV_EF_CAREFUL</summary>
    Careful = 1 << 16,
    /// <summary>AV_EF_COMPLIANT</summary>
    Compliant = 1 << 17,
    /// <summary>AV_EF_AGGRESSIVE</summary>
    Aggressive = 1 << 18,
}

/// <summary>Whether the timestamp shift offset has already been determined. -1: disabled, 0: not yet determined, 1: determined.</summary>
public enum FFFormatContext_avoid_negative_ts_status : int
{
    Disabled = -1,
    Unknown = 0,
    Known = 1,
}

/// <summary>Macro enum, prefix: AVFILTER_CMD_FLAG_</summary>
[Flags]
public enum FilterCmdFlags : int
{
    None = 0,
    /// <summary>AVFILTER_CMD_FLAG_ONE</summary>
    One = 1,
    /// <summary>AVFILTER_CMD_FLAG_FAST</summary>
    Fast = 2,
}

/// <summary>Macro enum, prefix: AVFILTER_FLAG_</summary>
[Flags]
public enum FilterFlags : int
{
    None = 0,
    /// <summary>AVFILTER_FLAG_DYNAMIC_INPUTS</summary>
    DynamicInputs = 1 << 0,
    /// <summary>AVFILTER_FLAG_DYNAMIC_OUTPUTS</summary>
    DynamicOutputs = 1 << 1,
    /// <summary>AVFILTER_FLAG_SLICE_THREADS</summary>
    SliceThreads = 1 << 2,
    /// <summary>AVFILTER_FLAG_METADATA_ONLY</summary>
    MetadataOnly = 1 << 3,
    /// <summary>AVFILTER_FLAG_HWDEVICE</summary>
    Hwdevice = 1 << 4,
    /// <summary>AVFILTER_FLAG_SUPPORT_TIMELINE_GENERIC</summary>
    SupportTimelineGeneric = 1 << 16,
    /// <summary>AVFILTER_FLAG_SUPPORT_TIMELINE_INTERNAL</summary>
    SupportTimelineInternal = 1 << 17,
}

public enum FilterFormatsState : byte
{
    /// <summary>The default value meaning that this filter supports all formats and (for audio) sample rates and channel layouts/counts as long as these properties agree for all inputs and outputs. This state is only allowed in case all inputs and outputs actually have the same type. The union is unused in this state.</summary>
    Passthrough = 0,
    /// <summary>formats.query active.</summary>
    QueryFunc = 1,
    /// <summary>formats.query_func2 active.</summary>
    QueryFunc2 = 2,
    /// <summary>formats.pixels_list active.</summary>
    PixfmtList = 3,
    /// <summary>formats.samples_list active.</summary>
    SamplefmtsList = 4,
    /// <summary>formats.pix_fmt active</summary>
    SinglePixfmt = 5,
    /// <summary>formats.sample_fmt active.</summary>
    SingleSamplefmt = 6,
}

/// <summary>Macro enum, prefix: AVFILTERPAD_FLAG_</summary>
[Flags]
public enum FilterPadFlags : int
{
    None = 0,
    /// <summary>AVFILTERPAD_FLAG_NEEDS_WRITABLE</summary>
    NeedsWritable = 1 << 0,
    /// <summary>AVFILTERPAD_FLAG_FREE_NAME</summary>
    FreeName = 1 << 1,
}

/// <summary>Macro enum, prefix: AVFILTER_THREAD_</summary>
[Flags]
public enum FilterThreadFlags : int
{
    None = 0,
    /// <summary>AVFILTER_THREAD_SLICE</summary>
    Slice = 1 << 0,
}

/// <summary>Macro enum, prefix: AVFMTCTX_</summary>
[Flags]
public enum FmtCtxFlags : uint
{
    None = 0,
    /// <summary>AVFMTCTX_NOHEADER</summary>
    Noheader = 0x0001,
    /// <summary>AVFMTCTX_UNSEEKABLE</summary>
    Unseekable = 0x0002,
}

/// <summary>Macro enum, prefix: AVFMT_EVENT_FLAG_</summary>
[Flags]
public enum FmtEventFlags : uint
{
    None = 0,
    /// <summary>AVFMT_EVENT_FLAG_METADATA_UPDATED</summary>
    MetadataUpdated = 0x0001,
}

/// <summary>Macro enum, prefix: AVFMT_</summary>
[Flags]
public enum FmtFlags : uint
{
    None = 0,
    /// <summary>AVFMT_NOFILE</summary>
    Nofile = 0x0001,
    /// <summary>AVFMT_NEEDNUMBER</summary>
    Neednumber = 0x0002,
    /// <summary>AVFMT_EXPERIMENTAL</summary>
    Experimental = 0x0004,
    /// <summary>AVFMT_SHOW_IDS</summary>
    ShowIds = 0x0008,
    /// <summary>AVFMT_GLOBALHEADER</summary>
    Globalheader = 0x0040,
    /// <summary>AVFMT_NOTIMESTAMPS</summary>
    Notimestamps = 0x0080,
    /// <summary>AVFMT_GENERIC_INDEX</summary>
    GenericIndex = 0x0100,
    /// <summary>AVFMT_TS_DISCONT</summary>
    TsDiscont = 0x0200,
    /// <summary>AVFMT_VARIABLE_FPS</summary>
    VariableFps = 0x0400,
    /// <summary>AVFMT_NODIMENSIONS</summary>
    Nodimensions = 0x0800,
    /// <summary>AVFMT_NOSTREAMS</summary>
    Nostreams = 0x1000,
    /// <summary>AVFMT_NOBINSEARCH</summary>
    Nobinsearch = 0x2000,
    /// <summary>AVFMT_NOGENSEARCH</summary>
    Nogensearch = 0x4000,
    /// <summary>AVFMT_NO_BYTE_SEEK</summary>
    NoByteSeek = 0x8000,
    /// <summary>AVFMT_TS_NONSTRICT</summary>
    TsNonstrict = 0x20000,
    /// <summary>AVFMT_TS_NEGATIVE</summary>
    TsNegative = 0x40000,
    /// <summary>AVFMT_SEEK_TO_PTS</summary>
    SeekToPts = 0x4000000,
}

/// <summary>Macro enum, prefix: AVFMT_FLAG_</summary>
[Flags]
public enum FmtFlags2 : uint
{
    None = 0,
    /// <summary>AVFMT_FLAG_GENPTS</summary>
    Genpts = 0x0001,
    /// <summary>AVFMT_FLAG_IGNIDX</summary>
    Ignidx = 0x0002,
    /// <summary>AVFMT_FLAG_NONBLOCK</summary>
    Nonblock = 0x0004,
    /// <summary>AVFMT_FLAG_IGNDTS</summary>
    Igndts = 0x0008,
    /// <summary>AVFMT_FLAG_NOFILLIN</summary>
    Nofillin = 0x0010,
    /// <summary>AVFMT_FLAG_NOPARSE</summary>
    Noparse = 0x0020,
    /// <summary>AVFMT_FLAG_NOBUFFER</summary>
    Nobuffer = 0x0040,
    /// <summary>AVFMT_FLAG_CUSTOM_IO</summary>
    CustomIo = 0x0080,
    /// <summary>AVFMT_FLAG_DISCARD_CORRUPT</summary>
    DiscardCorrupt = 0x0100,
    /// <summary>AVFMT_FLAG_FLUSH_PACKETS</summary>
    FlushPackets = 0x0200,
    /// <summary>AVFMT_FLAG_BITEXACT</summary>
    Bitexact = 0x0400,
    /// <summary>AVFMT_FLAG_SORT_DTS</summary>
    SortDts = 0x10000,
    /// <summary>AVFMT_FLAG_FAST_SEEK</summary>
    FastSeek = 0x80000,
    /// <summary>AVFMT_FLAG_AUTO_BSF</summary>
    AutoBsf = 0x200000,
}

/// <summary>Macro enum, prefix: AV_FRAME_FLAG_</summary>
[Flags]
public enum FrameFlags : int
{
    None = 0,
    /// <summary>AV_FRAME_FLAG_CORRUPT</summary>
    Corrupt = 1 << 0,
    /// <summary>AV_FRAME_FLAG_KEY</summary>
    Key = 1 << 1,
    /// <summary>AV_FRAME_FLAG_DISCARD</summary>
    Discard = 1 << 2,
    /// <summary>AV_FRAME_FLAG_INTERLACED</summary>
    Interlaced = 1 << 3,
    /// <summary>AV_FRAME_FLAG_TOP_FIELD_FIRST</summary>
    TopFieldFirst = 1 << 4,
    /// <summary>AV_FRAME_FLAG_LOSSLESS</summary>
    Lossless = 1 << 5,
}

/// <summary>Macro enum, prefix: AV_FRAME_SIDE_DATA_FLAG_</summary>
[Flags]
public enum FrameSideDataFlags : int
{
    None = 0,
    /// <summary>AV_FRAME_SIDE_DATA_FLAG_UNIQUE</summary>
    Unique = 1 << 0,
    /// <summary>AV_FRAME_SIDE_DATA_FLAG_REPLACE</summary>
    Replace = 1 << 1,
    /// <summary>AV_FRAME_SIDE_DATA_FLAG_NEW_REF</summary>
    NewRef = 1 << 2,
}

/// <summary>Macro enum, prefix: AV_HWACCEL_CODEC_CAP_</summary>
[Flags]
public enum HWAccelCapFlags : uint
{
    None = 0,
    /// <summary>AV_HWACCEL_CODEC_CAP_EXPERIMENTAL</summary>
    Experimental = 0x0200,
}

/// <summary>Macro enum, prefix: AV_HWACCEL_FLAG_</summary>
[Flags]
public enum HWAccelFlags : int
{
    None = 0,
    /// <summary>AV_HWACCEL_FLAG_IGNORE_LEVEL</summary>
    IgnoreLevel = 1 << 0,
    /// <summary>AV_HWACCEL_FLAG_ALLOW_HIGH_DEPTH</summary>
    AllowHighDepth = 1 << 1,
    /// <summary>AV_HWACCEL_FLAG_ALLOW_PROFILE_MISMATCH</summary>
    AllowProfileMismatch = 1 << 2,
    /// <summary>AV_HWACCEL_FLAG_UNSAFE_OUTPUT</summary>
    UnsafeOutput = 1 << 3,
}

public enum ID3v2Encoding : int
{
    Iso8859 = 0,
    Utf16bom = 1,
    Utf16be = 2,
    Utf8 = 3,
}

/// <summary>Macro enum, prefix: FF_IDCT_</summary>
public enum IDCTAlgo : int
{
    /// <summary>FF_IDCT_AUTO</summary>
    Auto = 0,
    /// <summary>FF_IDCT_INT</summary>
    Int = 1,
    /// <summary>FF_IDCT_SIMPLE</summary>
    Simple = 2,
    /// <summary>FF_IDCT_SIMPLEMMX</summary>
    Simplemmx = 3,
    /// <summary>FF_IDCT_ARM</summary>
    Arm = 7,
    /// <summary>FF_IDCT_ALTIVEC</summary>
    Altivec = 8,
    /// <summary>FF_IDCT_SIMPLEARM</summary>
    Simplearm = 10,
    /// <summary>FF_IDCT_XVID</summary>
    Xvid = 14,
    /// <summary>FF_IDCT_SIMPLEARMV5TE</summary>
    Simplearmv5te = 16,
    /// <summary>FF_IDCT_SIMPLEARMV6</summary>
    Simplearmv6 = 17,
    /// <summary>FF_IDCT_FAAN</summary>
    Faan = 20,
    /// <summary>FF_IDCT_SIMPLENEON</summary>
    Simpleneon = 22,
    /// <summary>FF_IDCT_SIMPLEAUTO</summary>
    Simpleauto = 128,
}

/// <summary>Macro enum, prefix: AVINDEX_</summary>
[Flags]
public enum IndexFlags : uint
{
    None = 0,
    /// <summary>AVINDEX_KEYFRAME</summary>
    Keyframe = 0x0001,
    /// <summary>AVINDEX_DISCARD_FRAME</summary>
    DiscardFrame = 0x0002,
}

/// <summary>Macro enum, prefix: AVIO_FLAG_</summary>
[Flags]
public enum IOFlags : uint
{
    None = 0,
    /// <summary>AVIO_FLAG_READ</summary>
    Read = 1,
    /// <summary>AVIO_FLAG_WRITE</summary>
    Write = 2,
    /// <summary>AVIO_FLAG_NONBLOCK</summary>
    Nonblock = 8,
    /// <summary>AVIO_FLAG_DIRECT</summary>
    Direct = 0x8000,
}

/// <summary>Macro enum, prefix: AVIO_SEEKABLE_</summary>
[Flags]
public enum IOSeekableFlags : int
{
    None = 0,
    /// <summary>AVIO_SEEKABLE_NORMAL</summary>
    Normal = 1 << 0,
    /// <summary>AVIO_SEEKABLE_TIME</summary>
    Time = 1 << 1,
}

/// <summary>Macro enum, prefix: AVSEEK_</summary>
[Flags]
public enum IOSeekFlags : uint
{
    /// <summary>SEEK_SET</summary>
    Begin = 0,
    /// <summary>SEEK_CUR</summary>
    Current = 1,
    /// <summary>SEEK_END</summary>
    End = 2,
    /// <summary>AVSEEK_SIZE</summary>
    Size = 0x10000,
    /// <summary>AVSEEK_FORCE</summary>
    Force = 0x20000,
}

public enum KeyType : int
{
    None = 0,
    Aes_128 = 1,
    SampleAes = 2,
}

/// <summary>Macro enum, prefix: AV_LOG_</summary>
public enum LogFlags : int
{
    /// <summary>AV_LOG_SKIP_REPEATED</summary>
    SkipRepeated = 1,
    /// <summary>AV_LOG_PRINT_LEVEL</summary>
    PrintLevel = 2,
    /// <summary>AV_LOG_PRINT_TIME</summary>
    PrintTime = 4,
    /// <summary>AV_LOG_PRINT_DATETIME</summary>
    PrintDatetime = 8,
}

/// <summary>Macro enum, prefix: AV_LOG_</summary>
public enum LogLevel : int
{
    /// <summary>AV_LOG_QUIET</summary>
    Quiet = -8,
    /// <summary>AV_LOG_PANIC</summary>
    Panic = 0,
    /// <summary>AV_LOG_FATAL</summary>
    Fatal = 8,
    /// <summary>AV_LOG_ERROR</summary>
    Error = 16,
    /// <summary>AV_LOG_WARNING</summary>
    Warn = 24,
    /// <summary>AV_LOG_INFO</summary>
    Info = 32,
    /// <summary>AV_LOG_VERBOSE</summary>
    Verb = 40,
    /// <summary>AV_LOG_DEBUG</summary>
    Debug = 48,
    /// <summary>AV_LOG_TRACE</summary>
    Trace = 56,
    /// <summary>AV_LOG_MAX_OFFSET</summary>
    Max = Trace - Quiet,
}

/// <summary>Macro enum, prefix: FF_MB_DECISION_</summary>
public enum MBDecision : int
{
    /// <summary>FF_MB_DECISION_SIMPLE</summary>
    Simple = 0,
    /// <summary>FF_MB_DECISION_BITS</summary>
    Bits = 1,
    /// <summary>FF_MB_DECISION_RD</summary>
    Rd = 2,
}

/// <summary>Macro enum, prefix: AV_OPT_FLAG_</summary>
[Flags]
public enum OptFlags : int
{
    None = 0,
    /// <summary>AV_OPT_FLAG_ENCODING_PARAM</summary>
    EncodingParam = 1 << 0,
    /// <summary>AV_OPT_FLAG_DECODING_PARAM</summary>
    DecodingParam = 1 << 1,
    /// <summary>AV_OPT_FLAG_AUDIO_PARAM</summary>
    AudioParam = 1 << 3,
    /// <summary>AV_OPT_FLAG_VIDEO_PARAM</summary>
    VideoParam = 1 << 4,
    /// <summary>AV_OPT_FLAG_SUBTITLE_PARAM</summary>
    SubtitleParam = 1 << 5,
    /// <summary>AV_OPT_FLAG_EXPORT</summary>
    Export = 1 << 6,
    /// <summary>AV_OPT_FLAG_READONLY</summary>
    Readonly = 1 << 7,
    /// <summary>AV_OPT_FLAG_BSF_PARAM</summary>
    BsfParam = 1 << 8,
    /// <summary>AV_OPT_FLAG_RUNTIME_PARAM</summary>
    RuntimeParam = 1 << 15,
    /// <summary>AV_OPT_FLAG_FILTERING_PARAM</summary>
    FilteringParam = 1 << 16,
    /// <summary>AV_OPT_FLAG_DEPRECATED</summary>
    Deprecated = 1 << 17,
    /// <summary>AV_OPT_FLAG_CHILD_CONSTS</summary>
    ChildConsts = 1 << 18,
}

/// <summary>Macro enum, prefix: AV_OPT_SEARCH_</summary>
[Flags]
public enum OptSearchFlags : int
{
    None = 0,
    /// <summary>AV_OPT_SEARCH_CHILDREN</summary>
    Children = 1 << 0,
    /// <summary>AV_OPT_SEARCH_FAKE_OBJ</summary>
    FakeObj = 1 << 1,
}

/// <summary>Macro enum, prefix: AV_OPT_SERIALIZE_</summary>
[Flags]
public enum OptSerializeFlags : uint
{
    None = 0,
    /// <summary>AV_OPT_SERIALIZE_SKIP_DEFAULTS</summary>
    SkipDefaults = 0x00000001,
    /// <summary>AV_OPT_SERIALIZE_OPT_FLAGS_EXACT</summary>
    OptFlagsExact = 0x00000002,
    /// <summary>AV_OPT_SERIALIZE_SEARCH_CHILDREN</summary>
    SearchChildren = 0x00000004,
}

/// <summary>Macro enum, prefix: PARSER_FLAG_</summary>
[Flags]
public enum ParserFlags : int
{
    None = 0,
    /// <summary>PARSER_FLAG_COMPLETE_FRAMES</summary>
    CompleteFrames = 0x0001,
    /// <summary>PARSER_FLAG_ONCE</summary>
    Once = 0x0002,
    /// <summary>PARSER_FLAG_FETCHED_OFFSET</summary>
    FetchedOffset = 0x0004,
    /// <summary>PARSER_FLAG_USE_CODEC_TS</summary>
    UseCodecTs = 0x1000,
}

/// <summary>Macro enum, prefix: AV_PIX_FMT_FLAG_</summary>
[Flags]
public enum PixFmtFlags : ulong
{
    None = 0,
    /// <summary>AV_PIX_FMT_FLAG_BE</summary>
    Be = 1 << 0,
    /// <summary>AV_PIX_FMT_FLAG_PAL</summary>
    Pal = 1 << 1,
    /// <summary>AV_PIX_FMT_FLAG_BITSTREAM</summary>
    Bitstream = 1 << 2,
    /// <summary>AV_PIX_FMT_FLAG_HWACCEL</summary>
    Hwaccel = 1 << 3,
    /// <summary>AV_PIX_FMT_FLAG_PLANAR</summary>
    Planar = 1 << 4,
    /// <summary>AV_PIX_FMT_FLAG_RGB</summary>
    Rgb = 1 << 5,
    /// <summary>AV_PIX_FMT_FLAG_ALPHA</summary>
    Alpha = 1 << 7,
    /// <summary>AV_PIX_FMT_FLAG_BAYER</summary>
    Bayer = 1 << 8,
    /// <summary>AV_PIX_FMT_FLAG_FLOAT</summary>
    Float = 1 << 9,
    /// <summary>AV_PIX_FMT_FLAG_XYZ</summary>
    Xyz = 1 << 10,
}

/// <summary>Macro enum, prefix: AV_PKT_FLAG_</summary>
[Flags]
public enum PktFlags : uint
{
    None = 0,
    /// <summary>AV_PKT_FLAG_KEY</summary>
    Key = 0x0001,
    /// <summary>AV_PKT_FLAG_CORRUPT</summary>
    Corrupt = 0x0002,
    /// <summary>AV_PKT_FLAG_DISCARD</summary>
    Discard = 0x0004,
    /// <summary>AV_PKT_FLAG_TRUSTED</summary>
    Trusted = 0x0008,
    /// <summary>AV_PKT_FLAG_DISPOSABLE</summary>
    Disposable = 0x0010,
}

public enum PlaylistType : int
{
    Unspecified = 0,
    Event = 1,
    Vod = 2,
}

/// <summary>Macro enum, prefix: AVSEEK_FLAG_</summary>
[Flags]
public enum SeekFlags : int
{
    None = 0,
    /// <summary>AVSEEK_FLAG_BACKWARD</summary>
    Backward = 1,
    /// <summary>AVSEEK_FLAG_BYTE</summary>
    Byte = 2,
    /// <summary>AVSEEK_FLAG_ANY</summary>
    Any = 4,
    /// <summary>AVSEEK_FLAG_FRAME</summary>
    Frame = 8,
}

/// <summary>Macro enum, prefix: SLICE_FLAG_</summary>
[Flags]
public enum SliceFlags : uint
{
    None = 0,
    /// <summary>SLICE_FLAG_CODED_ORDER</summary>
    CodedOrder = 0x0001,
    /// <summary>SLICE_FLAG_ALLOW_FIELD</summary>
    AllowField = 0x0002,
    /// <summary>SLICE_FLAG_ALLOW_PLANE</summary>
    AllowPlane = 0x0004,
}

/// <summary>Macro enum, prefix: AVSTREAM_EVENT_FLAG_</summary>
[Flags]
public enum StreamEventFlags : uint
{
    None = 0,
    /// <summary>AVSTREAM_EVENT_FLAG_METADATA_UPDATED</summary>
    MetadataUpdated = 0x0001,
    /// <summary>AVSTREAM_EVENT_FLAG_NEW_PACKETS</summary>
    NewPackets = 1 << 1,
}

/// <summary>Macro enum, prefix: AVSTREAM_INIT_IN_</summary>
[Flags]
public enum StreamInitFlags : int
{
    /// <summary>AVSTREAM_INIT_IN_WRITE_HEADER</summary>
    WriteHeader = 0,
    /// <summary>AVSTREAM_INIT_IN_INIT_OUTPUT</summary>
    InitOutput = 1,
}

/// <summary>Macro enum, prefix: FF_COMPLIANCE_</summary>
public enum StrictCompliance : int
{
    /// <summary>FF_COMPLIANCE_VERY_STRICT</summary>
    VeryStrict = 2,
    /// <summary>FF_COMPLIANCE_STRICT</summary>
    Strict = 1,
    /// <summary>FF_COMPLIANCE_NORMAL</summary>
    Normal = 0,
    /// <summary>FF_COMPLIANCE_UNOFFICIAL</summary>
    Unofficial = -1,
    /// <summary>FF_COMPLIANCE_EXPERIMENTAL</summary>
    Experimental = -2,
}

/// <summary>Macro enum, prefix: FF_SUB_CHARENC_MODE_</summary>
[Flags]
public enum SubCharencModeFlags : int
{
    /// <summary>FF_SUB_CHARENC_MODE_DO_NOTHING</summary>
    DoNothing = -1,
    /// <summary>FF_SUB_CHARENC_MODE_AUTOMATIC</summary>
    Automatic = 0,
    /// <summary>FF_SUB_CHARENC_MODE_PRE_DECODER</summary>
    PreDecoder = 1,
    /// <summary>FF_SUB_CHARENC_MODE_IGNORE</summary>
    Ignore = 2,
}

/// <summary>Dithering algorithms</summary>
public enum SwrDitherType : int
{
    None = 0,
    Rectangular = 1,
    Triangular = 2,
    TriangularHighpass = 3,
    /// <summary>not part of API/ABI</summary>
    Ns = 64,
    NsLipshitz = 65,
    NsFWeighted = 66,
    NsModifiedEWeighted = 67,
    NsImprovedEWeighted = 68,
    NsShibata = 69,
    NsLowShibata = 70,
    NsHighShibata = 71,
    /// <summary>not part of API/ABI</summary>
    Nb = 72,
}

/// <summary>Resampling Engines</summary>
public enum SwrEngine : int
{
    /// <summary>SW Resampler</summary>
    Swr = 0,
    /// <summary>SoX Resampler</summary>
    Soxr = 1,
    /// <summary>not part of API/ABI</summary>
    Nb = 2,
}

/// <summary>Resampling Filter Types</summary>
public enum SwrFilterType : int
{
    /// <summary>Cubic</summary>
    Cubic = 0,
    /// <summary>Blackman Nuttall windowed sinc</summary>
    BlackmanNuttall = 1,
    /// <summary>Kaiser windowed sinc</summary>
    Kaiser = 2,
}

public enum SwsAlphaBlend : int
{
    None = 0,
    Uniform = 1,
    Checkerboard = 2,
    Nb = 3,
}

/// <summary>Macro enum, prefix: SWS_CS_</summary>
[Flags]
public enum SwsCSFlags : int
{
    None = 0,
    /// <summary>SWS_CS_ITU709</summary>
    Itu709 = 1,
    /// <summary>SWS_CS_FCC</summary>
    Fcc = 4,
    /// <summary>SWS_CS_ITU601</summary>
    Itu601 = 5,
    /// <summary>SWS_CS_ITU624</summary>
    Itu624 = 5,
    /// <summary>SWS_CS_SMPTE170M</summary>
    Smpte170m = 5,
    /// <summary>SWS_CS_SMPTE240M</summary>
    Smpte240m = 7,
    /// <summary>SWS_CS_DEFAULT</summary>
    Default = 5,
    /// <summary>SWS_CS_BT2020</summary>
    Bt2020 = 9,
}

/// <summary>**************************** Flags and quality settings * ****************************</summary>
public enum SwsDither : int
{
    None = 0,
    Auto = 1,
    Bayer = 2,
    Ed = 3,
    ADither = 4,
    XDither = 5,
    Nb = 6,
}

/// <summary>Macro enum, prefix: SWS_</summary>
[Flags]
public enum SwsFlags : uint
{
    None = 0,
    /// <summary>SWS_SRC_V_CHR_DROP_MASK</summary>
    SrcVChrDropMask = 0x30000,
    /// <summary>SWS_SRC_V_CHR_DROP_SHIFT</summary>
    SrcVChrDropShift = 16,
    /// <summary>SWS_PARAM_DEFAULT</summary>
    ParamDefault = 123456,
}

public enum SwsIntent : int
{
    /// <summary>Perceptual tone mapping</summary>
    Perceptual = 0,
    /// <summary>Relative colorimetric clipping</summary>
    RelativeColorimetric = 1,
    /// <summary>Saturation mapping</summary>
    Saturation = 2,
    /// <summary>Absolute colorimetric clipping</summary>
    AbsoluteColorimetric = 3,
    /// <summary>not part of the ABI</summary>
    Nb = 4,
}

/// <summary>Macro enum, prefix: FF_THREAD_</summary>
[Flags]
public enum ThreadTypeFlags : int
{
    None = 0,
    /// <summary>FF_THREAD_FRAME</summary>
    Frame = 1,
    /// <summary>FF_THREAD_SLICE</summary>
    Slice = 2,
}

/// <summary>Macro enum, prefix: FF_BUG_</summary>
[Flags]
public enum WorkaroundBugFlags : int
{
    None = 0,
    /// <summary>FF_BUG_AUTODETECT</summary>
    Autodetect = 1,
    /// <summary>FF_BUG_XVID_ILACE</summary>
    XvidIlace = 4,
    /// <summary>FF_BUG_UMP4</summary>
    Ump4 = 8,
    /// <summary>FF_BUG_NO_PADDING</summary>
    NoPadding = 16,
    /// <summary>FF_BUG_AMV</summary>
    Amv = 32,
    /// <summary>FF_BUG_QPEL_CHROMA</summary>
    QpelChroma = 64,
    /// <summary>FF_BUG_STD_QPEL</summary>
    StdQpel = 128,
    /// <summary>FF_BUG_QPEL_CHROMA2</summary>
    QpelChroma2 = 256,
    /// <summary>FF_BUG_DIRECT_BLOCKSIZE</summary>
    DirectBlocksize = 512,
    /// <summary>FF_BUG_EDGE</summary>
    Edge = 1024,
    /// <summary>FF_BUG_HPEL_CHROMA</summary>
    HpelChroma = 2048,
    /// <summary>FF_BUG_DC_CLIP</summary>
    DcClip = 4096,
    /// <summary>FF_BUG_MS</summary>
    Ms = 8192,
    /// <summary>FF_BUG_TRUNCATED</summary>
    Truncated = 16384,
    /// <summary>FF_BUG_IEDGE</summary>
    Iedge = 32768,
}

