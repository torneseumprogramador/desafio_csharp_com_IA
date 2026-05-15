using System.ComponentModel.DataAnnotations;
using primeiraApi.Enums;

namespace primeiraApi.DTOs;

public class AdministradorUpdateRequestDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "A regra é obrigatória.")]
    public AdministradorRule? Rule { get; set; }

    [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
    public string? Senha { get; set; }
}
