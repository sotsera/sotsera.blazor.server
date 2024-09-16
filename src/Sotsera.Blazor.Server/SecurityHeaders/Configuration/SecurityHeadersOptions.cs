// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

namespace Sotsera.Blazor.Server.SecurityHeaders.Configuration;

public class SecurityHeadersOptions
{
    public bool DisableKestrelServerHeader { get; set; } = true;
    public string? AntiforgeryTokenPrefix { get; set; }

}
