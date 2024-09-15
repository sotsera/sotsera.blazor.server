using System.Net.Mime;
using System.Text;
using BlazorWebAppAutoGlobal;
using BlazorWebAppAutoGlobal.Components;
using Sotsera.Blazor.Server;
using Sotsera.Blazor.Server.SecurityHeaders.Policies;
using Sotsera.Blazor.Server.SecurityHeaders.Policies.DefaultPolicies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurityHeaders(true);

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
    .Map(group =>
    {
        group.MapGet("/text", () => "Ciao!");
        group.MapGet("/json", () => TypedResults.Ok(new { Message = "Ciao!" }));
        group.MapGet("/html", () =>
        {
            const string content = "<html><body><h1>Ciao!</h1></body></html>";
            return TypedResults.Content(content, MediaTypeNames.Text.Html, Encoding.UTF8);
        });
    })
    .RequireSecurityHeaders(new DefaultApiSecurityHeadersPolicy());

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly)
    .RequireSecurityHeaders(new DefaultBlazorSecurityHeadersPolicy());


app.UseSecurityHeaders(new DefaultSecurityHeadersPolicy());

app.Run();

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Program { }
