namespace Ecommerce.Web.Client.Services;

/// <summary>
/// JWT em memória para o Blazor WASM enviar <c>Authorization: Bearer</c> ao BFF
/// (o cookie HttpOnly nem sempre acompanha o <see cref="HttpClient"/> no browser).
/// </summary>
public sealed class AdminBffAccessTokenHolder
{
    private string? _token;

    public string? Token => _token;

    public void SetToken(string? token) =>
        _token = string.IsNullOrWhiteSpace(token) ? null : token.Trim();

    public void Clear() => _token = null;
}
