using System.Text.Json.Serialization;

namespace Ecommerce.Web.Client.Models;

public class MensagemRespostaApi
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
