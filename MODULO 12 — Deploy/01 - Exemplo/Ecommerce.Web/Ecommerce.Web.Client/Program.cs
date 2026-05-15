using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Ecommerce.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);

var apiBase = new Uri(builder.HostEnvironment.BaseAddress);

// No Blazor Web App (interatividade por componente), Scoped pode ser recriado ao mudar de rota;
// o estado de login precisa ser o mesmo em /admin e /admin/administradores.
builder.Services.AddSingleton<AdminBffAccessTokenHolder>();
builder.Services.AddSingleton<AdminAuthState>();
builder.Services.AddTransient<AdminWasmBearerHandler>();
builder.Services.AddTransient<BffCredentialsHandler>();

builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = apiBase;
}).AddHttpMessageHandler<BffCredentialsHandler>()
  .AddHttpMessageHandler<AdminWasmBearerHandler>();

builder.Services.AddHttpClient<AdministradoresApiService>(client =>
{
    client.BaseAddress = apiBase;
}).AddHttpMessageHandler<BffCredentialsHandler>()
  .AddHttpMessageHandler<AdminWasmBearerHandler>();

await builder.Build().RunAsync();
