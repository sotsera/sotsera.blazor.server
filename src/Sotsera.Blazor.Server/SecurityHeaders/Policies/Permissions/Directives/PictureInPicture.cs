// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

/// <summary>
/// Represents the permissions policy directive for the picture-in-picture feature.
/// </summary>
public class PictureInPicture() : PermissionsPolicyDirective("picture-in-picture")
{
    /// <summary>
    /// Implicitly converts a string value to an <see cref="PictureInPicture"/> instance.
    /// </summary>
    /// <param name="value">The string value to convert.</param>
    /// <returns>An <see cref="PictureInPicture"/> instance with the specified value.</returns>
    public static implicit operator PictureInPicture(string value) => new() { Value = value };
}
