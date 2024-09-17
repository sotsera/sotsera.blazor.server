// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the storage-access feature.
/// </summary>
public class StorageAccess() : PermissionsPolicyDirective("storage-access")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="StorageAccess"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="StorageAccess"/> instance with the specified value.</returns>
    public static implicit operator StorageAccess(string value) => new() { Value = value };
}
