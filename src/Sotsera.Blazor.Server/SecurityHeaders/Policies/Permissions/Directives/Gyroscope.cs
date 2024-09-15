// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Gyroscope() : PermissionsPolicyDirective("gyroscope")
{
    public static implicit operator Gyroscope(string value) => new() { Value = value };
}
