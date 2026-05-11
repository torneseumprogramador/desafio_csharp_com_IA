namespace EcommerceCleanArchitecture.Application.DTOs.Pedidos;

public record PedidoRequestDto(
    int ClienteId,
    string? Observacao,
    IReadOnlyList<PedidoItemRequestDto> Itens);
