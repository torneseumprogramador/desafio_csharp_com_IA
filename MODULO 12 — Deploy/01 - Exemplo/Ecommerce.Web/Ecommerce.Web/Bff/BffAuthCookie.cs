namespace Ecommerce.Web.Bff;

internal static class BffAuthCookie
{
    internal const string CookieName = "Ecommerce.AdminAuth";

    internal static void Append(HttpResponse response, HttpRequest request, string jwt, DateTimeOffset? expiresAtUtc)
    {
        var options = new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Secure = request.IsHttps,
            Path = "/"
        };

        if (expiresAtUtc.HasValue)
        {
            options.Expires = expiresAtUtc.Value.UtcDateTime;
        }

        response.Cookies.Append(CookieName, jwt, options);
    }

    internal static void Delete(HttpResponse response, HttpRequest request)
    {
        response.Cookies.Delete(
            CookieName,
            new CookieOptions
            {
                Path = "/",
                HttpOnly = true,
                SameSite = SameSiteMode.Lax,
                Secure = request.IsHttps
            });
    }
}
