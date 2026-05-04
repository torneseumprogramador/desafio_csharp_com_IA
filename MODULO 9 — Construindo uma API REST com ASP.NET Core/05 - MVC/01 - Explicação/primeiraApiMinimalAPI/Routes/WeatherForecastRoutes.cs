using primeiraApi.Controllers;

namespace primeiraApi.Routes;

public static class WeatherForecastRoutes
{
    public static void MapWeatherForecastRoutes(this WebApplication app)
    {
        app.MapGet("/weatherforecast", WeatherForecastHandlers.ObterPrevisao)
            .WithName("GetWeatherForecast");
    }
}
