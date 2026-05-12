using primeiraApi.Enums;

namespace primeiraApi.ModelViews;

public class AdministradorResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public AdministradorRule Rule { get; set; }
}
