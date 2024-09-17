// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the publickey-credentials-get feature.
/// </summary>
public class PublickeyCredentialsGet() : PermissionsPolicyDirective("publickey-credentials-get")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="PublickeyCredentialsGet"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="PublickeyCredentialsGet"/> instance with the specified value.</returns>
    public static implicit operator PublickeyCredentialsGet(string value) => new() { Value = value };
}
