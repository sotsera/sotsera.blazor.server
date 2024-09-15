// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Sotsera.Blazor.Server.ForSotseraCommon.Extensions;

public static class ArrayExtensions
{
    public static T[] ThrowIfEmpty<T>([NotNull] this T[]? argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);

        if (argument.Length == 0)
        {
            throw new ArgumentException($"The {typeof(T[])} cannot be empty.", paramName);
        }

        return argument;
    }

    public static bool IsEmpty<T>([NotNullWhen(false)] this T[]? value) => value is null || value.Length == 0;

    public static bool IsNonEmpty<T>([NotNullWhen(true)] this T[]? value) => value is not null && value.Length != 0;
}
