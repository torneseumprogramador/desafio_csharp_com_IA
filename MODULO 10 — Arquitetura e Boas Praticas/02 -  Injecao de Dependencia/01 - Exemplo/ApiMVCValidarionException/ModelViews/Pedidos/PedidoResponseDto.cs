namespace primeiraApi.ModelViews;

public record PedidoResponseDto
{
    public int Id { get; init; }
    public int ClienteId { get; init; }
    public string ClienteNome { get; init; } = string.Empty;
    public DateTime CriadoEm { get; init; }
    public string? Observacao { get; init; }
    public decimal Total { get; init; }
    public List<PedidoItemResponseDto> Itens { get; init; } = [];
}
