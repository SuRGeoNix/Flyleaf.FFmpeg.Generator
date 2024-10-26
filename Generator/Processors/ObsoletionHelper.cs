﻿using CppSharp.AST;
using Flyleaf.FFmpeg.Generator.Definitions;
using System.Linq;

namespace Flyleaf.FFmpeg.Generator.Processors;

internal static class ObsoletionHelper
{
    private static string GetMessage(Declaration declaration)
    {
        var lines = declaration.Comment?.FullComment?.Blocks
            .OfType<BlockCommandComment>()
            .Where(x => x.CommandKind == CommentCommandKind.Deprecated)
            .SelectMany(x =>
                x.ParagraphComment.Content.OfType<TextComment>().Select(c => c.Text.Trim())
            );
        var obsoleteMessage = lines == null ? string.Empty : string.Join(" ", lines);
        return obsoleteMessage;
    }

    public static Obsoletion CreateObsoletion(Declaration declaration)
    {
        var message = GetMessage(declaration);
        return new Obsoletion
        {
            IsObsolete = declaration.IsDeprecated || !string.IsNullOrWhiteSpace(message),
            Message = message
        };
    }
}
