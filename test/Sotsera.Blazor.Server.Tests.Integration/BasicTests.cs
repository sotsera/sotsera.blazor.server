// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

//using Microsoft.AspNetCore.Mvc.Testing;

//namespace Sotsera.Blazor.Server.Tests.Integration;

//public class BasicTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
//{
//    [Theory]
//    [InlineData("/", "text/html; charset=utf-8")]
//    [InlineData("/counter", "text/html; charset=utf-8")]
//    [InlineData("/weather", "text/html; charset=utf-8")]
//    [InlineData("/appsettings.json", "application/json")]
//    [InlineData("/_framework/blazor.web.js", "text/javascript")]
//    [InlineData("/api/text", "text/plain; charset=utf-8")]
//    [InlineData("/api/json", "application/json; charset=utf-8")]
//    [InlineData("/api/html", "text/html; charset=utf-8")]
//    public async Task GetEndpoints_ShouldReturnSuccessAndCorrectContentType(string url, string encoding)
//    {
//        var client = factory.CreateClient();

//        var response = await client.GetAsync(url);

//        response.EnsureSuccessStatusCode();
//        Assert.Equal(encoding, response.Content.Headers.ContentType?.ToString());
//    }
//}
