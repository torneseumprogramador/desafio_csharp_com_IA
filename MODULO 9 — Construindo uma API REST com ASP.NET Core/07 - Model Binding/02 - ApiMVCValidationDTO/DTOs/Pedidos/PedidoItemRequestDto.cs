using System.ComponentModel.DataAnnotations;

namespace primeiraApi.DTOs;

public record PedidoItemRequestDto
{
    [Range(1, int.MaxValue, ErrorMessage = "ProdutoId deve ser informado.")]
    public int ProdutoId { get; init; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero.")]
    public int Quantidade { get; init; }
}
