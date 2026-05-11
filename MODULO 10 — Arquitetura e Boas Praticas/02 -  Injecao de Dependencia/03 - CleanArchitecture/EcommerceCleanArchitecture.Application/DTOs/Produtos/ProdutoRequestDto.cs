namespace EcommerceCleanArchitecture.Application.DTOs.Produtos;

public record ProdutoRequestDto(
    string Nome,
    string Descricao,
    decimal Preco);
