using System.ComponentModel.DataAnnotations;

namespace primeiraApi.DTOs;

public record ClientePatchRequestDto
{
    [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 150 caracteres.")]
    public string Nome { get; init; } = string.Empty;
}
