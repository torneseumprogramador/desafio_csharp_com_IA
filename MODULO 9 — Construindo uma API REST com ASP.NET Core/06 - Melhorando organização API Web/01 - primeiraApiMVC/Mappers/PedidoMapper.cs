using primeiraApi.DTOs;
using primeiraApi.Models;

namespace primeiraApi.Mappers;

public static class PedidoMapper
{
    public static PedidoResponseDto ToResponseDto(this Pedido pedido)
    {
        var itens = pedido.Itens.Select(i => new PedidoItemResponseDto
        {
            ProdutoId = i.ProdutoId,
            ProdutoNome = i.Produto?.Nome ?? string.Empty,
            Quantidade = i.Quantidade,
            PrecoUnitario = i.PrecoUnitario
        }).ToList();

        return new PedidoResponseDto
        {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            ClienteNome = pedido.Cliente?.Nome ?? string.Empty,
            CriadoEm = pedido.CriadoEm,
            Observacao = pedido.Observacao,
            Total = itens.Sum(i => i.Quantidade * i.PrecoUnitario),
            Itens = itens
        };
    }
}
