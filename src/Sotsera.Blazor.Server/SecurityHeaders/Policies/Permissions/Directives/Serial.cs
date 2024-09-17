// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the serial feature.
/// </summary>
public class Serial() : PermissionsPolicyDirective("serial")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Serial"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Serial"/> instance with the specified value.</returns>
    public static implicit operator Serial(string value) => new() { Value = value };
}
