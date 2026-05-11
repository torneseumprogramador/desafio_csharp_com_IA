namespace EcommerceCleanArchitecture.Application.DTOs.Pedidos;

public record PedidoResponseDto(
    int Id,
    int ClienteId,
    string ClienteNome,
    DateTime CriadoEm,
    string? Observacao,
    IReadOnlyList<PedidoItemResponseDto> Itens,
    decimal Total);
