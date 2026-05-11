namespace primeiraApi.DTOs;

public record PedidoItemRequestDto
{
    public int ProdutoId { get; init; }
    public int Quantidade { get; init; }
}
