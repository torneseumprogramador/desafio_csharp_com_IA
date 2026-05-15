using primeiraApi.Enums;

namespace primeiraApi.Models;

public class Administrador
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public AdministradorRule Rule { get; set; }
    public string Senha { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;
}
