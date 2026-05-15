namespace primeiraApi.ModelViews;

public record ProdutoResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public decimal Preco { get; init; }
    public int Estoque { get; init; }
}
