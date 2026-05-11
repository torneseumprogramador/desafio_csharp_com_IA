using EcommerceCleanArchitecture.Application.DTOs.Clientes;
using EcommerceCleanArchitecture.Application.DTOs.Pedidos;
using EcommerceCleanArchitecture.Application.DTOs.Produtos;
using EcommerceCleanArchitecture.Domain.Entities;

namespace EcommerceCleanArchitecture.Application.Services;

internal static class MappingExtensions
{
    public static ClienteResponseDto ToResponse(this Cliente cliente) =>
        new(cliente.Id, cliente.Nome, cliente.Email, cliente.Telefone, cliente.Cpf);

    public static ProdutoResponseDto ToResponse(this Produto produto) =>
        new(produto.Id, produto.Nome, produto.Descricao, produto.Preco);

    public static PedidoResponseDto ToResponse(this Pedido pedido)
    {
        var itens = pedido.Itens
            .Select(i => new PedidoItemResponseDto(
                i.ProdutoId,
                i.Produto?.Nome ?? string.Empty,
                i.Quantidade,
                i.PrecoUnitario,
                i.Quantidade * i.PrecoUnitario))
            .ToList();

        return new PedidoResponseDto(
            pedido.Id,
            pedido.ClienteId,
            pedido.Cliente?.Nome ?? string.Empty,
            pedido.CriadoEm,
            pedido.Observacao,
            itens,
            itens.Sum(i => i.Subtotal));
    }
}
