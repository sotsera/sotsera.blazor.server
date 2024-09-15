// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class PublickeyCredentialsGet() : PermissionsPolicyDirective("publickey-credentials-get")
{
    public static implicit operator PublickeyCredentialsGet(string value) => new() { Value = value };
}
