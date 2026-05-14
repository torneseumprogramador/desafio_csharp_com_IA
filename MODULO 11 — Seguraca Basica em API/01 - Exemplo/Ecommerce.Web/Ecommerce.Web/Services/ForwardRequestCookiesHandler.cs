using Microsoft.AspNetCore.Http;

namespace Ecommerce.Web.Services;

/// <summary>
/// No SSR, repassa o header Cookie da requisição HTTP atual para o HttpClient que chama o BFF
/// (o cookie HttpOnly não está disponível via JS, mas o servidor recebe no request).
/// </summary>
public sealed class ForwardRequestCookiesHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ForwardRequestCookiesHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext?.Request.Headers.TryGetValue("Cookie", out var cookies) == true)
        {
            request.Headers.TryAddWithoutValidation("Cookie", cookies.ToString());
        }

        return base.SendAsync(request, cancellationToken);
    }
}
