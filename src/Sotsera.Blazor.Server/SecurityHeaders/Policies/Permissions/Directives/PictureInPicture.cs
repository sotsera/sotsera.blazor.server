// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class PictureInPicture() : PermissionsPolicyDirective("picture-in-picture")
{
    public static implicit operator PictureInPicture(string value) => new() { Value = value };
}
