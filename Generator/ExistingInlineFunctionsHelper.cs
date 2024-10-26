﻿// Copyright 2020 Craytive Technologies BV. All rights reserved. Company proprietary and confidential.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Flyleaf.FFmpeg.Generator.Definitions;

namespace Flyleaf.FFmpeg.Generator;

internal static class ExistingInlineFunctionsHelper
{
    private static readonly Regex FunctionNameRegex = new(
        @"\s+public static .+ (?<name>[\S]+)\(.*?\)", RegexOptions.Compiled | RegexOptions.Multiline);

    private static readonly Regex FunctionHashRegex = new(
        @"\s+// original body hash: (?<hash>\S+)", RegexOptions.Compiled | RegexOptions.Multiline);

    public static InlineFunctionDefinition[] LoadInlineFunctions(string path)
    {
        if (!File.Exists(path)) return Array.Empty<InlineFunctionDefinition>();

        var text = File.ReadAllText(path);
        var functions = new List<InlineFunctionDefinition>();

        var nameMatches = FunctionNameRegex.Matches(text);
        var hashMatches = FunctionHashRegex.Matches(text);

        Debug.Assert(nameMatches.Count == hashMatches.Count);

        string prevName = "";
        for (var i = 0; i < nameMatches.Count; i++)
        {
            var nameMatch = nameMatches[i];
            var hashMatch = hashMatches[i];

            var name = nameMatch.Groups["name"].Value;
            if (prevName == name) // TBR: av_image_copy2, av_frame_side_data_get has the same name/hash and cannot be converted to dictionary (requires unique key)
                continue;
            prevName = name;
            var hash = hashMatch.Groups["hash"].Value;
            var bodyIndex = nameMatch.Index + nameMatch.Length;
            var body = text.Substring(bodyIndex, hashMatch.Index - bodyIndex);

            var function = new InlineFunctionDefinition
            {
                Name = name,
                Body = body,
                OriginalBodyHash = hash
            };
            functions.Add(function);
        }

        return functions.ToArray();
    }
}