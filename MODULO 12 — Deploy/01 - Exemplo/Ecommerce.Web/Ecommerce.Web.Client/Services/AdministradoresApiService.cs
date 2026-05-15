using System.Net.Http.Json;
using Ecommerce.Web.Client.Models;

namespace Ecommerce.Web.Client.Services;

public class AdministradoresApiService
{
    private readonly HttpClient _http;

    public AdministradoresApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<(IReadOnlyList<AdministradorResponse>? Lista, string? ErroMensagem)> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _http.GetAsync("api/bff/administradores", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var lista = await response.Content.ReadFromJsonAsync<List<AdministradorResponse>>(cancellationToken: cancellationToken);
            return (lista ?? new List<AdministradorResponse>(), null);
        }

        var erro = await TryReadMensagemAsync(response, cancellationToken);
        return (null, erro ?? "Não foi possível carregar os administradores.");
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
