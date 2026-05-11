namespace EcommerceCleanArchitecture.Application.DTOs.Pedidos;

public record PedidoItemResponseDto(
    int ProdutoId,
    string ProdutoNome,
    int Quantidade,
    decimal PrecoUnitario,
    decimal Subtotal);
