namespace Ecommerce.Web.Bff;

/// <summary>Resposta quando o HttpClient não consegue contactar a API (serviço parado, rede, timeout).</summary>
internal static class BffBackendUnavailableResult
{
    internal static IResult Create() =>
        TypedResults.Json(
            new
            {
                message =
                    "Não foi possível contactar a API. Inicie o projeto Ecommerce.API (ex.: perfil \"http\" na porta 5047) e confira ApiBackend:BaseUrl no appsettings do Ecommerce.Web."
            },
            statusCode: StatusCodes.Status503ServiceUnavailable);
}
