// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class LocalFonts() : PermissionsPolicyDirective("local-fonts")
{
    public static implicit operator LocalFonts(string value) => new() { Value = value };
}
