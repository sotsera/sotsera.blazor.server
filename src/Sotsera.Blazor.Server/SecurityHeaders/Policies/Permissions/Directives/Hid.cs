// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the hid feature.
/// </summary>
public class Hid() : PermissionsPolicyDirective("hid")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Hid"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Hid"/> instance with the specified value.</returns>
    public static implicit operator Hid(string value) => new() { Value = value };
}
