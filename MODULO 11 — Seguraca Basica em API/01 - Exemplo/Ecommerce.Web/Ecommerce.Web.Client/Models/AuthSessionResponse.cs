using System.Text.Json.Serialization;

namespace Ecommerce.Web.Client.Models;

/// <summary>Resposta do BFF para restaurar sessão (sem token).</summary>
public class AuthSessionResponse
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AdministradorRule Rule { get; set; }
}
