using Ecommerce.Web.Bff.Dtos;
using Ecommerce.Web.Bff.Services;

namespace Ecommerce.Web.Bff;

public static class BffEndpointExtensions
{
    public static WebApplication MapBff(this WebApplication app)
    {
        var bff = app.MapGroup("/api/bff").DisableAntiforgery();

        bff.MapPost("/auth/login", async (
                HttpContext httpContext,
                BffLoginRequest body,
                BffAuthProxyService auth,
                CancellationToken cancellationToken) =>
            await auth.LoginAsync(httpContext, body, cancellationToken));

        bff.MapPost("/auth/refresh", async (
                HttpContext httpContext,
                BffAuthProxyService auth,
                CancellationToken cancellationToken) =>
            await auth.RefreshAsync(httpContext, cancellationToken));

        bff.MapMethods("/auth/status", new[] { "HEAD" }, async (
                HttpContext httpContext,
                BffAuthProxyService auth,
                CancellationToken cancellationToken) =>
            await auth.StatusAsync(httpContext, cancellationToken));

        bff.MapGet("/auth/session", async (
                HttpContext httpContext,
                BffAuthProxyService auth,
                CancellationToken cancellationToken) =>
            await auth.SessionAsync(httpContext, cancellationToken));

        bff.MapGet("/auth/access-token", async (
                HttpContext httpContext,
                BffAuthProxyService auth,
                CancellationToken cancellationToken) =>
            await auth.AccessTokenAsync(httpContext, cancellationToken));

        bff.MapPost("/auth/logout", (HttpContext httpContext, BffAuthProxyService auth) =>
            auth.Logout(httpContext));

        bff.MapGet("/administradores", async (
                HttpContext httpContext,
                BffAdministradoresProxyService administradores,
                CancellationToken cancellationToken) =>
            await administradores.GetAdministradoresAsync(httpContext, cancellationToken));

        return app;
    }
}
