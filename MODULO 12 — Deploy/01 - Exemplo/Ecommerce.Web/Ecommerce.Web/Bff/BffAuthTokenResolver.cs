using System.Net.Http.Headers;

namespace Ecommerce.Web.Bff;

/// <summary>
/// Obtém o JWT enviado pelo browser (Authorization Bearer ou cookie HttpOnly).
/// Lê também o header Cookie bruto: em alguns cenários a coleção <see cref="HttpRequest.Cookies"/>
/// não reflete o valor esperado; o parsing manual cobre JWT com '=' no payload.
/// </summary>
public static class BffAuthTokenResolver
{
    public static string? TryGetJwt(HttpRequest request)
    {
        if (TryGetBearerFromAuthorizationHeader(request, out var fromHeader) && !string.IsNullOrWhiteSpace(fromHeader))
        {
            return TrimToken(fromHeader);
        }

        var fromRawCookie = TryReadCookieValueFromHeader(request.Headers["Cookie"].ToString(), BffAuthCookie.CookieName);
        if (!string.IsNullOrWhiteSpace(fromRawCookie))
        {
            return TrimToken(fromRawCookie);
        }

        if (request.Cookies.TryGetValue(BffAuthCookie.CookieName, out var fromCollection)
            && !string.IsNullOrWhiteSpace(fromCollection))
        {
            return TrimToken(fromCollection);
        }

        return null;
    }

    public static void ApplyBearerIfPresent(HttpRequest request, HttpRequestMessage forward)
    {
        var jwt = TryGetJwt(request);
        if (!string.IsNullOrWhiteSpace(jwt))
        {
            forward.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }
    }

    private static bool TryGetBearerFromAuthorizationHeader(HttpRequest request, out string? token)
    {
        token = null;
        var authHeader = request.Headers.Authorization.ToString();
        if (string.IsNullOrWhiteSpace(authHeader)
            || !AuthenticationHeaderValue.TryParse(authHeader, out var parsed)
            || !parsed.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        token = parsed.Parameter;
        return !string.IsNullOrWhiteSpace(token);
    }

    private static string? TryReadCookieValueFromHeader(string? cookieHeader, string cookieName)
    {
        if (string.IsNullOrEmpty(cookieHeader))
        {
            return null;
        }

        var prefix = cookieName + "=";
        foreach (var part in cookieHeader.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (part.Length > prefix.Length
                && part.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                var raw = part[prefix.Length..].Trim();
                if (raw.Length == 0)
                {
                    return null;
                }

                try
                {
                    return Uri.UnescapeDataString(raw);
                }
                catch (UriFormatException)
                {
                    return raw;
                }
            }
        }

        return null;
    }

    private static string TrimToken(string token) => token.Trim();
}
