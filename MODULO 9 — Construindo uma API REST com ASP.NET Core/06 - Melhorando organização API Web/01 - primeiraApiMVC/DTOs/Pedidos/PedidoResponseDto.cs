namespace primeiraApi.DTOs;

public class PedidoResponseDto
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNome { get; set; } = string.Empty;
    public DateTime CriadoEm { get; set; }
    public string? Observacao { get; set; }
    public decimal Total { get; set; }
    public List<PedidoItemResponseDto> Itens { get; set; } = [];
}
