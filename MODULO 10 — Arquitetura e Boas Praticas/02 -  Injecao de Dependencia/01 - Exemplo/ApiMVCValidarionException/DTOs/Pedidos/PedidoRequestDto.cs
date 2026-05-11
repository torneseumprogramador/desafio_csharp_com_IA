namespace primeiraApi.DTOs;

public record PedidoRequestDto
{
    public int ClienteId { get; init; }
    public string? Observacao { get; init; }
    public List<PedidoItemRequestDto> Itens { get; init; } = [];
}
