namespace EcommerceCleanArchitecture.Application.DTOs.Clientes;

public record ClienteRequestDto(
    string Nome,
    string Email,
    string Telefone,
    string Cpf);
