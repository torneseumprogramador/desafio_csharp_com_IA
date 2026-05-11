namespace EcommerceCleanArchitecture.Application.DTOs.Clientes;

public record ClienteResponseDto(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    string Cpf);
