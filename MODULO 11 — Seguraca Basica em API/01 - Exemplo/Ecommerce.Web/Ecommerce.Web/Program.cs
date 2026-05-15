using Ecommerce.Web.Bff;
using Ecommerce.Web.Bff.Services;
using Ecommerce.Web.Client.Services;
using Ecommerce.Web.Components;
using Ecommerce.Web.Configuration;
using Ecommerce.Web.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<ForwardRequestCookiesHandler>();

static void ConfigureBffApiHttpClient(IServiceProvider sp, HttpClient client)
{
    var accessor = sp.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
    var httpContext = accessor.HttpContext;
    if (httpContext?.Request is { } request)
    {
        client.BaseAddress = new Uri($"{request.Scheme}://{request.Host}/");
        return;
    }

    client.BaseAddress = new Uri("http://localhost:5260/");
}

builder.Services.AddHttpClient<AuthApiService>(ConfigureBffApiHttpClient)
    .AddHttpMessageHandler<ForwardRequestCookiesHandler>();
builder.Services.AddHttpClient<AdministradoresApiService>(ConfigureBffApiHttpClient)
    .AddHttpMessageHandler<ForwardRequestCookiesHandler>();
builder.Services.AddScoped<AdminBffAccessTokenHolder>();
builder.Services.AddScoped<AdminAuthState>();

builder.Services.Configure<ApiBackendOptions>(
    builder.Configuration.GetSection(ApiBackendOptions.SectionName));

builder.Services.AddHttpClient("ApiBackend", (sp, client) =>
{
    var baseUrl = sp.GetRequiredService<IOptions<ApiBackendOptions>>().Value.BaseUrl;
    if (string.IsNullOrWhiteSpace(baseUrl))
    {
        baseUrl = "http://localhost:5047/";
    }

    client.BaseAddress = new Uri(baseUrl.EndsWith('/') ? baseUrl : baseUrl + "/");
});

builder.Services.AddScoped<BffAuthProxyService>();
builder.Services.AddScoped<BffAdministradoresProxyService>();

// Add services to the container.
builder.Services.AddRazorComponents()
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
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

if (!app.Environment.IsEnvironment("Docker"))
{
    app.UseHttpsRedirection();
}

app.UseAntiforgery();

app.MapBff();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Ecommerce.Web.Client._Imports).Assembly);

app.Run();
