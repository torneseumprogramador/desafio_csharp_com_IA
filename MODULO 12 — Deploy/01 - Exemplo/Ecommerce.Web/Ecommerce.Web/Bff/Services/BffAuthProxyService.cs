using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;
using Ecommerce.Web.Bff;
using Ecommerce.Web.Bff.Dtos;

namespace Ecommerce.Web.Bff.Services;

public sealed class BffAuthProxyService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BffAuthProxyService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IResult> LoginAsync(
        HttpContext httpContext,
        BffLoginRequest body,
        CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("ApiBackend");
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.PostAsJsonAsync("auth/login", body, cancellationToken),
            async response =>
            {
                var payload = await response.Content.ReadAsStringAsync(cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    TryPromoverTokenDoJsonParaCookie(httpContext, ref payload);
                }

                return TypedResults.Content(payload, "application/json", statusCode: (int)response.StatusCode);
            });
    }

    public async Task<IResult> RefreshAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("ApiBackend");
        using var forward = new HttpRequestMessage(HttpMethod.Post, "auth/refresh");
        BffAuthTokenResolver.ApplyBearerIfPresent(httpContext.Request, forward);
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.SendAsync(forward, HttpCompletionOption.ResponseHeadersRead, cancellationToken),
            async response =>
            {
                var payload = await response.Content.ReadAsStringAsync(cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    TryPromoverTokenDoJsonParaCookie(httpContext, ref payload);
                }

                return TypedResults.Content(payload, "application/json", statusCode: (int)response.StatusCode);
            });
    }

    public async Task<IResult> StatusAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("ApiBackend");
        using var forward = new HttpRequestMessage(HttpMethod.Head, "auth/status");
        BffAuthTokenResolver.ApplyBearerIfPresent(httpContext.Request, forward);
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.SendAsync(forward, HttpCompletionOption.ResponseHeadersRead, cancellationToken),
            response => Task.FromResult<IResult>(TypedResults.StatusCode((int)response.StatusCode)));
    }

    public async Task<IResult> SessionAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var jwt = BffAuthTokenResolver.TryGetJwt(httpContext.Request);
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return TypedResults.Unauthorized();
        }

        var client = _httpClientFactory.CreateClient("ApiBackend");
        using var forward = new HttpRequestMessage(HttpMethod.Head, "auth/status");
        forward.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.SendAsync(forward, HttpCompletionOption.ResponseHeadersRead, cancellationToken),
            statusResponse =>
            {
                if (!statusResponse.IsSuccessStatusCode)
                {
                    return Task.FromResult<IResult>(TypedResults.Unauthorized());
                }

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(jwt);
                var nome = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Name)?.Value ?? string.Empty;
                var email = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value
                    ?? jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value
                    ?? string.Empty;
                var rule = jwtToken.Claims.FirstOrDefault(c => c.Type == "rule")?.Value
                    ?? jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
                    ?? string.Empty;

                return Task.FromResult<IResult>(TypedResults.Json(new { nome, email, rule }));
            });
    }

    public async Task<IResult> AccessTokenAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var jwt = BffAuthTokenResolver.TryGetJwt(httpContext.Request);
        if (string.IsNullOrWhiteSpace(jwt))
        {
            return TypedResults.Unauthorized();
        }

        var client = _httpClientFactory.CreateClient("ApiBackend");
        using var forward = new HttpRequestMessage(HttpMethod.Head, "auth/status");
        forward.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        return await BffApiHttp.SendOrServiceUnavailableAsync(
            () => client.SendAsync(forward, HttpCompletionOption.ResponseHeadersRead, cancellationToken),
            statusResponse =>
            {
                if (!statusResponse.IsSuccessStatusCode)
                {
                    return Task.FromResult<IResult>(TypedResults.Unauthorized());
                }

                return Task.FromResult<IResult>(TypedResults.Json(new { token = jwt }));
            });
    }

    public IResult Logout(HttpContext httpContext)
    {
        BffAuthCookie.Delete(httpContext.Response, httpContext.Request);
        return TypedResults.NoContent();
    }

    /// <summary>
    /// Se o JSON tiver <c>token</c>, grava no cookie HttpOnly. O <c>token</c> permanece no JSON para o WASM
    /// repor o Bearer em memória; o BFF prioriza o header Authorization.
    /// </summary>
    private static void TryPromoverTokenDoJsonParaCookie(HttpContext httpContext, ref string payload)
    {
        JsonNode? node;
        try
        {
            node = JsonNode.Parse(payload);
        }
        catch (JsonException)
        {
            return;
        }

        if (node is not JsonObject obj || !obj.TryGetPropertyValue("token", out var tokenNode))
        {
            return;
        }

        var token = tokenNode?.GetValue<string>();
        if (string.IsNullOrWhiteSpace(token))
        {
            return;
        }

        DateTimeOffset? expira = null;
        if (obj.TryGetPropertyValue("expiraEm", out var expNode) && expNode is not null
            && expNode.GetValueKind() == JsonValueKind.String
            && DateTime.TryParse(expNode.GetValue<string>(), out var dt))
        {
            expira = new DateTimeOffset(DateTime.SpecifyKind(dt, DateTimeKind.Utc), TimeSpan.Zero);
        }

        BffAuthCookie.Append(httpContext.Response, httpContext.Request, token, expira);
        payload = node.ToJsonString();
    }
}
