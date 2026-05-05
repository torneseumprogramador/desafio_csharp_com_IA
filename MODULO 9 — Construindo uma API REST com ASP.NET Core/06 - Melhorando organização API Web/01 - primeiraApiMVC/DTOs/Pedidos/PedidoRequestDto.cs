namespace primeiraApi.DTOs;

public class PedidoRequestDto
{
    public int ClienteId { get; set; }
    public string? Observacao { get; set; }
    public List<PedidoItemRequestDto> Itens { get; set; } = [];
}
