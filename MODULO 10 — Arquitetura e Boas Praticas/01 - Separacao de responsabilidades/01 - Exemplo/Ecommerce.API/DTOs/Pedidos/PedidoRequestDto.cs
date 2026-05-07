using System.ComponentModel.DataAnnotations;

namespace primeiraApi.DTOs;

public record PedidoRequestDto
{
    [Range(1, int.MaxValue, ErrorMessage = "ClienteId deve ser informado.")]
    public int ClienteId { get; init; }

    [StringLength(500, ErrorMessage = "Observação deve ter no máximo 500 caracteres.")]
    public string? Observacao { get; init; }

    [Required(ErrorMessage = "Pedido deve ter pelo menos um item.")]
    [MinLength(1, ErrorMessage = "Pedido deve ter pelo menos um item.")]
    public List<PedidoItemRequestDto> Itens { get; init; } = [];
}
