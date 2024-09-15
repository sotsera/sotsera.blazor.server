// Copyright (c) Alessandro Ghidini. All rights reserved.
// SPDX-License-Identifier: MIT.

using System.Net.Mime;
using System.Text;
using BlazorWebAppAutoGlobal.Client.Pages;
using BlazorWebAppAutoGlobal.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();

app.MapGroup("api")
    .AddTestApi();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly);

app.Run();

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Program { }

public static class TestApi
{
    public static RouteGroupBuilder AddTestApi(this RouteGroupBuilder builder)
    {
        builder.MapGet("/text", () => "Ciao!");

        builder.MapGet("/json", () => TypedResults.Ok(new { Message = "Ciao!" }));

        builder.MapGet("/html", () =>
        {
            const string content = "<html><body><h1>Ciao!</h1></body></html>";
            return TypedResults.Content(content, MediaTypeNames.Text.Html, Encoding.UTF8);
        });

        return builder;
    }
}
