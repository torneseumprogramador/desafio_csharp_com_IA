using primeiraApi.DTOs;
using primeiraApi.Models;

namespace primeiraApi.Mappers;

public static class ProdutoMapper
{
    public static ProdutoResponseDto ToResponseDto(this Produto produto)
    {
        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }

    public static Produto ToEntity(this ProdutoRequestDto dto)
    {
        return new Produto
        {
            Nome = dto.Nome,
            Preco = dto.Preco,
            Estoque = dto.Estoque
        };
    }
}
