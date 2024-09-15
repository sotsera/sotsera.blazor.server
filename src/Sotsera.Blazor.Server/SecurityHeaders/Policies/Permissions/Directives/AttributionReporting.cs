// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class AttributionReporting() : PermissionsPolicyDirective("attribution-reporting")
{
    public static implicit operator AttributionReporting(string value) => new() { Value = value };
}
