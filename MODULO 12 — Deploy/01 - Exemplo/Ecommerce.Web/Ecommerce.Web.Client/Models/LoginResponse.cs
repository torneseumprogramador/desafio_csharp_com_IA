namespace Ecommerce.Web.Client.Models;

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public string Tipo { get; set; } = "Bearer";
    public DateTime ExpiraEm { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public AdministradorRule Rule { get; set; }
}
