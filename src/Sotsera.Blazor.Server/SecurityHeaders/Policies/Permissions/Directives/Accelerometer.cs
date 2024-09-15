// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class Accelerometer() : PermissionsPolicyDirective("accelerometer")
{
    public static implicit operator Accelerometer(string value) => new() { Value = value };
}
