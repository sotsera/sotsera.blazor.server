// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Sources.Common.Extensions;

namespace Sotsera.Blazor.Server.SecurityHeaders.Metadata;

public interface ISecurityHeadersPolicyMetadata : ISecurityHeadersMetadata
{
    ISecurityHeadersPolicy Policy { get; }
}

public class SecurityHeadersPolicyMetadata(ISecurityHeadersPolicy policy) : ISecurityHeadersPolicyMetadata
{
    public ISecurityHeadersPolicy Policy { get; } = policy.ThrowIfNull();
}
