// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives.Base;

namespace Sotsera.Blazor.Server.SecurityHeaders.Policies.Permissions.Directives;

public class OtpCredentials() : PermissionsPolicyDirective("otp-credentials")
{
    public static implicit operator OtpCredentials(string value) => new() { Value = value };
}
