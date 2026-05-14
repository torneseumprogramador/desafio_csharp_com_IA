using Ecommerce.Web.Bff;

namespace Ecommerce.Web.Bff.Services;

public sealed class BffAdministradoresProxyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BffAdministradoresProxyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IResult> GetAdministradoresAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("ApiBackend");
        using var forward = new HttpRequestMessage(HttpMethod.Get, "administradores");
        BffAuthTokenResolver.ApplyBearerIfPresent(httpContext.Request, forward);
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.SendAsync(forward, HttpCompletionOption.ResponseHeadersRead, cancellationToken),
            async response =>
            {
                var payload = await response.Content.ReadAsStringAsync(cancellationToken);
                var mediaType = response.Content.Headers.ContentType?.MediaType ?? "application/json";
                return TypedResults.Content(payload, mediaType, statusCode: (int)response.StatusCode);
            });
    }
}
