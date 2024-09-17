// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the encrypted-media feature.
/// </summary>
public class EncryptedMedia() : PermissionsPolicyDirective("encrypted-media")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="EncryptedMedia"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="EncryptedMedia"/> instance with the specified value.</returns>
    public static implicit operator EncryptedMedia(string value) => new() { Value = value };
}
