namespace EcommerceCleanArchitecture.Application.DTOs.Produtos;

public record ProdutoResponseDto(
    int Id,
    string Nome,
    string Descricao,
    decimal Preco);
