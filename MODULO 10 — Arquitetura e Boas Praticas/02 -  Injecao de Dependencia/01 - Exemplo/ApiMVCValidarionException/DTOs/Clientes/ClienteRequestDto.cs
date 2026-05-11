namespace primeiraApi.DTOs;

public record ClienteRequestDto
{
    public string Nome { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Telefone { get; init; } = string.Empty;
    public string Cpf { get; init; } = string.Empty;
}
