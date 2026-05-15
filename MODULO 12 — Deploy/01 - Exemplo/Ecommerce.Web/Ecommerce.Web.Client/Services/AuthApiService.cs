using System.Net.Http.Json;
using System.Text.Json;
using Ecommerce.Web.Client.Models;

namespace Ecommerce.Web.Client.Services;

public class AuthApiService
{
    private readonly HttpClient _http;

    public AuthApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<(LoginResponse? Sucesso, string? ErroMensagem)> LoginAsync(
        LoginRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await _http.PostAsJsonAsync("api/bff/auth/login", request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken: cancellationToken);
            return (body, null);
        }

        var erro = await TryReadMensagemAsync(response, cancellationToken);
        return (null, erro ?? "Não foi possível entrar.");
    }

    public async Task<AuthSessionResponse?> GetSessionAsync(CancellationToken cancellationToken = default)
    {
        var response = await _http.GetAsync("api/bff/auth/session", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<AuthSessionResponse>(cancellationToken: cancellationToken);
    }

    public async Task LogoutAsync(CancellationToken cancellationToken = default)
    {
        await _http.PostAsync("api/bff/auth/logout", null, cancellationToken);
    }

    /// <summary>Devolve o JWT atual (cookie no browser); usado para repor o Bearer em memória após F5.</summary>
    public async Task<string?> FetchAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        var response = await _http.GetAsync("api/bff/auth/access-token", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken);
        return doc.RootElement.TryGetProperty("token", out var el) ? el.GetString() : null;
    }

    private static async Task<string?> TryReadMensagemAsync(HttpResponseMessage response, CancellationToken ct)
    {
        try
        {
            var msg = await response.Content.ReadFromJsonAsync<MensagemRespostaApi>(cancellationToken: ct);
            return msg?.Message;
        }
        catch
        {
            return null;
        }
    }
}
