namespace primeiraApi.DTOs;

public record ProdutoRequestDto
{
    public string Nome { get; init; } = string.Empty;
    public decimal Preco { get; init; }
    public int Estoque { get; init; }
}
