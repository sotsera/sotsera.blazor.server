// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Text;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.ForSotseraCommon.Extensions;

public static class StringBuilderExtensions
{
    public static StringBuilder AppendIf<T>(this StringBuilder builder, bool condition, T? value)
    {
        builder.ThrowIfNull();

        if (condition)
        {
            builder.Append(value);
        }

        return builder;
    }
}
