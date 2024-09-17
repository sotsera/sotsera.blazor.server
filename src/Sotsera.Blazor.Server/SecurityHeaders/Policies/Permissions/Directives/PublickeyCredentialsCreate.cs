// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the publickey-credentials-create feature.
/// </summary>
public class PublickeyCredentialsCreate() : PermissionsPolicyDirective("publickey-credentials-create")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="PublickeyCredentialsCreate"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="PublickeyCredentialsCreate"/> instance with the specified value.</returns>
    public static implicit operator PublickeyCredentialsCreate(string value) => new() { Value = value };
}
