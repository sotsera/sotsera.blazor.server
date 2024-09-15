// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Geolocation() : PermissionsPolicyDirective("geolocation")
{
    public static implicit operator Geolocation(string value) => new() { Value = value };
}
