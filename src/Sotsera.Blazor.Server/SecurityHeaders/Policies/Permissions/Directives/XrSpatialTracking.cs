// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class XrSpatialTracking() : PermissionsPolicyDirective("xr-spatial-tracking")
{
    public static implicit operator XrSpatialTracking(string value) => new() { Value = value };
}
