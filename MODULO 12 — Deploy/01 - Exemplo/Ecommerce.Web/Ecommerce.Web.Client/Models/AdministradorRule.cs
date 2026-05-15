using System.Text.Json.Serialization;

namespace Ecommerce.Web.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AdministradorRule
{
    Administrador = 1,
    Editor = 2
}
