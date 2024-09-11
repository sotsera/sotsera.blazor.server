using System.Net.Mime;
using System.Text;
using BlazorWebAppAutoGlobal.Client.Pages;
using BlazorWebAppAutoGlobal.Components;
using Microsoft.AspNetCore.Mvc;

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

app.MapGet("/api/text", () => "Ciao!");
app.MapGet("/api/json", () => new { Message = "Ciao!" });
app.MapGet("/api/html", () => Results.Content("<html><body><h1>Ciao!</h1></body></html>", MediaTypeNames.Text.Html, Encoding.UTF8));

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppAutoGlobal.Client._Imports).Assembly);

app.Run();

public partial class Program { }
