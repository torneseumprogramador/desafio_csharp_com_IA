using System.ComponentModel.DataAnnotations;

namespace primeiraApi.DTOs;

public record ProdutoRequestDto
{
    [Required(ErrorMessage = "Nome do produto é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 150 caracteres.")]
    public string Nome { get; init; } = string.Empty;

    [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "Preço do produto deve ser maior que zero.")]
    public decimal Preco { get; init; }

    [Range(0, int.MaxValue, ErrorMessage = "Estoque do produto não pode ser negativo.")]
    public int Estoque { get; init; }
}
