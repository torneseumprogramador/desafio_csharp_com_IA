namespace primeiraApi.DTOs;

public record ClientePatchRequestDto
{
    public string Nome { get; init; } = string.Empty;
}
