using System.Text.Json.Serialization;

namespace primeiraApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdministradorRule
{
    Administrador = 1,
    Editor = 2
}
