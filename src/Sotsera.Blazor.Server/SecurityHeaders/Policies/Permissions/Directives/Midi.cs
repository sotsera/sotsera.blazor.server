// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the midi feature.
/// </summary>
public class Midi() : PermissionsPolicyDirective("midi")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="Midi"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="Midi"/> instance with the specified value.</returns>
    public static implicit operator Midi(string value) => new() { Value = value };
}
