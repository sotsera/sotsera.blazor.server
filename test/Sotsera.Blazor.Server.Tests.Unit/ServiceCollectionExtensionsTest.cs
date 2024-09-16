// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using Microsoft.Extensions.DependencyInjection;

namespace Sotsera.Blazor.Server.Tests.Unit;

public class ServiceCollectionExtensionsTest
{
    [Fact]
    public void AddSecurityHeaders_ShouldNotRaiseExceptions()
    {
        var serviceCollection = new ServiceCollection();

        Action act = () => serviceCollection.AddSecurityHeaders();

        act.Should().NotThrow<ArgumentNullException>();
    }
}
