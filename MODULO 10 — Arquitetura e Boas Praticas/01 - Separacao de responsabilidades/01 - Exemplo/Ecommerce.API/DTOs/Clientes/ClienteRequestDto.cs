using System.ComponentModel.DataAnnotations;
using primeiraApi.Validation;

namespace primeiraApi.DTOs;

public record ClienteRequestDto
{
    [Required(ErrorMessage = "Nome do cliente é obrigatório.")]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 150 caracteres.")]
    public string Nome { get; init; } = string.Empty;

    [Required(ErrorMessage = "Email do cliente é obrigatório.")]
    [EmailAddress(ErrorMessage = "Email do cliente é inválido.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Telefone do cliente é obrigatório.")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "Telefone deve ter entre 8 e 30 caracteres.")]
    public string Telefone { get; init; } = string.Empty;

    [Required(ErrorMessage = "CPF do cliente é obrigatório.")]
    [ValidCpf(ErrorMessage = "CPF inválido.")]
    public string Cpf { get; init; } = string.Empty;
}
