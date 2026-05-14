using System.Net.Http.Headers;

namespace Ecommerce.Web.Client.Services;

/// <summary>Adiciona Bearer a partir do holder nas chamadas ao BFF (cookie continua incluído pelo <see cref="BffCredentialsHandler"/>).</summary>
public sealed class AdminWasmBearerHandler : DelegatingHandler
{
    private readonly AdminBffAccessTokenHolder _tokens;

    public AdminWasmBearerHandler(AdminBffAccessTokenHolder tokens)
    {
        _tokens = tokens;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var path = request.RequestUri?.AbsolutePath ?? string.Empty;
        if (path.Contains("/api/bff/", StringComparison.OrdinalIgnoreCase)
            && request.Headers.Authorization is null
            && !string.IsNullOrWhiteSpace(_tokens.Token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokens.Token);
        }

        return base.SendAsync(request, cancellationToken);
    }
}
