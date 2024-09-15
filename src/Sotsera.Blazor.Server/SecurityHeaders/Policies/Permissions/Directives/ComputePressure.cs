// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class ComputePressure() : PermissionsPolicyDirective("compute-pressure")
{
    public static implicit operator ComputePressure(string value) => new() { Value = value };
}
