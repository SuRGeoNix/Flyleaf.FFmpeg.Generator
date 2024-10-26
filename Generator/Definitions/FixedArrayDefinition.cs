﻿#nullable disable

namespace Flyleaf.FFmpeg.Generator.Definitions;

internal record FixedArrayDefinition : TypeDefinition
{
    public TypeDefinition ElementType { get; init; }
    public int Size { get; init; }
    public bool IsPrimitive { get; init; }
}