namespace EcommerceCleanArchitecture.Application.DTOs.Pedidos;

public record PedidoItemRequestDto(
    int ProdutoId,
    int Quantidade);
