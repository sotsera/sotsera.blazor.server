// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Magnetometer() : PermissionsPolicyDirective("magnetometer")
{
    public static implicit operator Magnetometer(string value) => new() { Value = value };
}
