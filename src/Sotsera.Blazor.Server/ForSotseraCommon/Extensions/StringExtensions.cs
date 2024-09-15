// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

namespace Sotsera.Blazor.Server.ForSotseraCommon.Extensions;

public static class StringExtensions
{
    public static string Trimmed(this string? value) => string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
}
