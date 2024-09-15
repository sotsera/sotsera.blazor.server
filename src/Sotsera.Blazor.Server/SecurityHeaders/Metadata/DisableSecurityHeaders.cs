// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

namespace Sotsera.Blazor.Server.SecurityHeaders.Metadata;

public interface IDisableSecurityHeadersAttribute : ISecurityHeadersMetadata;

public class DisableSecurityHeaders : IDisableSecurityHeadersAttribute;
