using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace Ecommerce.Web.Client.Services;

/// <summary>Garante envio de cookies HttpOnly nas chamadas ao BFF (mesma origem).</summary>
public class BffCredentialsHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        return base.SendAsync(request, cancellationToken);
    }
}
