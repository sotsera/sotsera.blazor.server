// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.Extensions.Logging;

namespace Sotsera.Blazor.Server.SecurityHeaders;

internal static partial class SecurityHeadersLoggerExtensions
{
    [LoggerMessage(1, LogLevel.Warning, "Failed to apply SecurityHeaders Response headers.", EventName = "FailedToSetHeaders")]
    public static partial void FailedToSetHeaders(this ILogger logger, Exception? exception);
}

