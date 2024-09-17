// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the microphone feature.
/// </summary>
public class Microphone() : PermissionsPolicyDirective("microphone")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Microphone"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Microphone"/> instance with the specified value.</returns>
    public static implicit operator Microphone(string value) => new() { Value = value };
}
