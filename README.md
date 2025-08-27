# Flyleaf FFmpeg Generator & Bindings for C#/.NET

---

## [Overview]

Flyleaf.FFmpeg.Generator Generates FFmpeg C#/.NET bindings by using [CppSharp](https://github.com/mono/CppSharp)</br>
It is based on [FFmpeg.AutoGen](https://github.com/Ruslan-B/FFmpeg.AutoGen) and [Sdcb.FFmpeg](https://github.com/sdcb/Sdcb.FFmpeg) (mainly for macro support).

The main purpose is to support ***Flyleaf Suite*** projects and possible access to even FFmpeg's private (instead of public only) API.

## [Features]

>✅ *Resolves type size issues for different operating systems*<br/>
>✅ *Reduces package size*<br/>
>✅ *Creates enums (w/o flags) from macros*<br/>
>✅ *Maps variables/parameters to enums*<br/>
>✅ *Customizes names for variables/parameters/functions/delegates/structs/enums*<br/>
>✅ *Impoves performance with DllImport and avoids marshaling in some cases*<br/>
>✅ *Plans to access private structs to extend the functionality (eg. HLS live seeking, Develop custom demuxer/muxers/codecs/filters etc.)*

## [Requirements]

***Windows 10 SDK*** is required (for CppSharp) to successfully compile the bindings and can be install from Visual Studio Installer.

Otherwise, it will fail with the following error:

```
fatal: 'errno.h' file not found
```

## [Releases]

[Flyleaf.FFmpeg.Bindings](https://www.nuget.org/packages/Flyleaf.FFmpeg.Bindings) NuGet package <sub>(major/minor versioning is based on FFmpeg releases versioning)</sub>

For more advanced/extended functionality check [Flyleaf.FFmpeg](https://github.com/SuRGeoNix/Flyleaf.FFmpeg)