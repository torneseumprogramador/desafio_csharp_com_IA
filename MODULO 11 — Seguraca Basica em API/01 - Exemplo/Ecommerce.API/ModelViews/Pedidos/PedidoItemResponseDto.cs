namespace primeiraApi.ModelViews;

public record PedidoItemResponseDto
{
    public int ProdutoId { get; init; }
    public string ProdutoNome { get; init; } = string.Empty;
    public int Quantidade { get; init; }
    public decimal PrecoUnitario { get; init; }
}
