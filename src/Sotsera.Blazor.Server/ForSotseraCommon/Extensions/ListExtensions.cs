// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Sotsera.Blazor.Server.ForSotseraCommon.Extensions;

public static class ListExtensions
{
    public static List<T> ThrowIfEmpty<T>([NotNull] this List<T>? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);

        if (argument.Count == 0)
        {
            throw new ArgumentException($"The {typeof(List<T>)} cannot be empty.", paramName);
        }

        return argument;
    }

    public static bool IsEmpty<T>([NotNullWhen(false)] this List<T>? value) => value is null || value.Count == 0;

    public static bool IsNonEmpty<T>([NotNullWhen(true)] this List<T>? value) => value is not null && value.Count != 0;
}
