using primeiraApi.Enums;

namespace primeiraApi.Services.Administradores.Results;

public class AdministradorLoginResult
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public AdministradorRule Rule { get; set; }
}
