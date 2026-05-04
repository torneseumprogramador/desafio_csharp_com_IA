using primeiraApi.Controllers;

namespace primeiraApi.Routes;

public static class HomeRoutes
{
    public static void MapHomeRoutes(this WebApplication app)
    {
        app.MapGet("/", HomeHandlers.BemVindo);
    }
}
