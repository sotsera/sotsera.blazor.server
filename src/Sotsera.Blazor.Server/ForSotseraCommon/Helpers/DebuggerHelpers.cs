#pragma warning disable IDE0073 // The file header does not match the required text
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// https://github.com/dotnet/aspnetcore/blob/ab50c4e79a11380447fe554682faba29d7b24f5d/src/Shared/Debugger/DebuggerHelpers.cs
#pragma warning restore IDE0073

using System.Collections;
using System.Text;
// The file header does not match the required text

namespace Sotsera.Blazor.Server.ForSotseraCommon.Helpers;

internal static class DebuggerHelpers
{
    public static string GetDebugText(string key1, object? value1, bool includeNullValues = true, string? prefix = null)
    {
        return GetDebugText([Create(key1, value1)], includeNullValues, prefix);
    }

    public static string GetDebugText(string key1, object? value1, string key2, object? value2, bool includeNullValues = true, string? prefix = null)
    {
        return GetDebugText([Create(key1, value1), Create(key2, value2)], includeNullValues, prefix);
    }

    public static string GetDebugText(string key1, object? value1, string key2, object? value2, string key3, object? value3, bool includeNullValues = true, string? prefix = null)
    {
        return GetDebugText([Create(key1, value1), Create(key2, value2), Create(key3, value3)], includeNullValues, prefix);
    }

    private static string GetDebugText(ReadOnlySpan<KeyValuePair<string, object?>> values, bool includeNullValues = true, string? prefix = null)
    {
        if (values.Length == 0)
        {
            return prefix ?? string.Empty;
        }

        var sb = new StringBuilder();

        if (prefix != null)
        {
            sb.Append(prefix);
        }

        var first = true;

        foreach (var kvp in values)
        {
            switch (kvp.Value)
            {
                case null when !includeNullValues:
                    continue;
                case null:
                    Append(kvp);
                    sb.Append("(null)");
                    break;
                case string s:
                    Append(kvp);
                    sb.Append(s);
                    break;
                case IEnumerable enumerable:
                    {
                        var firstItem = true;
                        foreach (var item in enumerable)
                        {
                            if (item is null && !includeNullValues)
                            {
                                continue;
                            }

                            if (firstItem)
                            {
                                Append(kvp);
                                firstItem = false;
                            }
                            else
                            {
                                sb.Append(',');
                            }

                            sb.Append(item ?? "(null)");
                        }

                        break;
                    }
                default:
                    sb.Append(kvp.Value);
                    break;
            }
        }

        return sb.ToString();

        void Append(KeyValuePair<string, object?> value)
        {
            if (first)
            {
                if (prefix != null)
                {
                    sb.Append(' ');
                }

                first = false;
            }
            else
            {
                sb.Append(", ");
            }

            sb.Append(value.Key);
            sb.Append(": ");
        }
    }

    private static KeyValuePair<string, object?> Create(string key, object? value) => new(key, value);
}
