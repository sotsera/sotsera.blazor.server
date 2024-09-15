// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

namespace Sotsera.Blazor.Server.SecurityHeaders.Blazor;

public interface IBlazorImportMapDefinitionShaProvider
{
    string? GetSha256(HttpContext context);
}

public class BlazorImportMapDefinitionShaProvider : IBlazorImportMapDefinitionShaProvider
{
    private string? _lastMapDefinition;
    private string? _lastSha;

    private static readonly Lock _lock = new();

    public string? GetSha256(HttpContext context)
    {
        var importMapDefinition = context.GetEndpoint()?.Metadata.GetMetadata<ImportMapDefinition>()?.ToString();

        if (importMapDefinition == null)
        {
            return null;
        }

        if (importMapDefinition == _lastMapDefinition)
        {
            return _lastSha;
        }

        var sha = CalculateSha256(importMapDefinition);

        lock (_lock)
        {
            _lastMapDefinition = importMapDefinition;
            _lastSha = sha;
        }

        return _lastSha;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Global
    public string CalculateSha256(string importMapDefinition)
    {
        var sanitized = importMapDefinition.Replace("\r\n", "\n");
        var bytes = Encoding.UTF8.GetBytes(sanitized);
        var sha = SHA256.HashData(bytes);
        return Convert.ToBase64String(sha);
    }
}
