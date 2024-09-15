// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Sotsera.Blazor.Server.SecurityHeaders.Blazor;

namespace Sotsera.Blazor.Server.Tests.Unit;

public class BlazorImportMapDefinitionShaProviderTests
{
    private const string ImportMapDefinition = """
                                               {
                                                 "imports": {
                                                   "./_framework/dotnet.js": "./_framework/dotnet.jbddxe79k4.js",
                                                   "./_framework/dotnet.native.js": "./_framework/dotnet.native.x4kezr0d10.js",
                                                   "./_framework/dotnet.runtime.js": "./_framework/dotnet.runtime.26xtx0erx2.js",
                                                   "_framework/resource-collection.js": "./_framework/resource-collection.juU0N.js",
                                                   "_framework/resource-collection.js.gz": "./_framework/resource-collection.juU0N.js.gz"
                                                 },
                                                 "integrity": {
                                                   "./_framework/resource-collection.juU0N.js": "sha256-4VXRSAHP1mqtxfnDevDeZXGqJuBqpmMZcQijMMHqr6E=",
                                                   "./_framework/resource-collection.juU0N.js.gz": "sha256-4VXRSAHP1mqtxfnDevDeZXGqJuBqpmMZcQijMMHqr6E="
                                                 }
                                               }
                                               """;

    [Fact]
    public void Test()
    {
        var provider = new BlazorImportMapDefinitionShaProvider();

        var sha = provider.CalculateSha256(ImportMapDefinition);

        sha.Should().Be("/UDgMX5fSFf4RPPlYgObQhDUdJN5m3JzenjUXhOGf/U=");
    }
}
