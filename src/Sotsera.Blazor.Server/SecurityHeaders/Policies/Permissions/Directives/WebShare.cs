// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the web-share feature.
/// </summary>
public class WebShare() : PermissionsPolicyDirective("web-share")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="WebShare"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="WebShare"/> instance with the specified value.</returns>
    public static implicit operator WebShare(string value) => new() { Value = value };
}
