using System.Diagnostics;

namespace Flyleaf.FFmpeg.Generator;

[DebuggerDisplay("{Name}, {LibraryName}")]
internal record FunctionExport(string Name, string LibraryName, int LibraryVersion);