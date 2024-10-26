using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable CS8509

namespace Flyleaf.FFmpeg.Generator;

internal class StringExtensions
{
    public static string DoubleQuoteEscape(string val) => val.Replace("\"", "\\\"");

    public static string EnumNameTransform(string name)
    {
        var res = string.Concat(name
            .Split('_')
            .Select(x => x switch
            {
                [var c, ..] when char.IsDigit(c) => $"_{x}",
                [var c, .. var rest] => char.ToUpper(c) + rest.ToLowerInvariant(),
            }));

        if (res == "Warning")
            return "Warn";
        
        if (res == "Verbose")
            return "Verb";

        if (res == "MaxOffset")
            return "Max";

        return res;
    }

    public static string CSharpKeywordTransform(string syntax) => syntax switch
    {
        _ when IsCSharpKeyword(syntax) => "@" + syntax,
        _ => syntax
    };

    public static bool IsCSharpKeyword(string key) => _csharpKeywords.Contains(key);

    private static readonly HashSet<string> _csharpKeywords = ("abstract,as,base,bool,break,byte,case," +
                "catch,char,checked,class,const,continue,decimal,default,delegate,do," +
                "double,else,enum,event,explicit,extern,false,finally,fixed,float,for," +
                "foreach,goto,if,implicit,in,int,interface,internal,is,lock,long,namespace," +
                "new,null,object,operator,out,override,params,private,protected,public," +
                "readonly,ref,return,sbyte,sealed,short,sizeof,stackalloc,static,string," +
                "struct,switch,this,throw,true,try,typeof,uint,ulong,unchecked,unsafe," +
                "ushort,using,virtual,void,volatile,while").Split(',').ToHashSet();

    public static string CommonPrefixOf(IEnumerable<string> strings)
    {
        string commonPrefix = strings.FirstOrDefault() ?? "";

        foreach (var s in strings)
        {
            var potentialMatchLength = Math.Min(s.Length, commonPrefix.Length);

            if (potentialMatchLength < commonPrefix.Length)
                commonPrefix = commonPrefix[..potentialMatchLength];

            for (var i = 0; i < potentialMatchLength; i++)
            {
                if (s[i] != commonPrefix[i])
                {
                    commonPrefix = commonPrefix[..i];
                    break;
                }
            }
        }

        // 确保不在单词中间截断
        if (!string.IsNullOrEmpty(commonPrefix))
        {
            var lastIndex = commonPrefix.Length - 1;

            // 如果最后一个字符不是下划线，我们需要找到最近的下划线（如果有）
            if (commonPrefix[lastIndex] != '_')
            {
                var lastUnderscoreIndex = commonPrefix.LastIndexOf('_', lastIndex);

                if (lastUnderscoreIndex != -1)
                {
                    // 截取到最近的下划线位置
                    commonPrefix = commonPrefix[..(lastUnderscoreIndex + 1)];
                }
                else
                {
                    // 如果没有下划线，表示我们不能简单截断，可能需要清除所有内容
                    // 这依赖于你想要如何处理这种没找到合适下划线的情况
                    // 这里的决定是将前缀清空
                    commonPrefix = "";
                }
            }
        }

        return commonPrefix;
    }
}
