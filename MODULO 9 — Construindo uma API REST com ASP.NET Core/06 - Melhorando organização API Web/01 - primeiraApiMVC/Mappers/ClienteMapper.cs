using primeiraApi.DTOs;
using primeiraApi.Models;

namespace primeiraApi.Mappers;

public static class ClienteMapper
{
    public static ClienteResponseDto ToResponseDto(this Cliente cliente)
    {
        return new ClienteResponseDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone
        };
    }

    public static Cliente ToEntity(this ClienteRequestDto dto)
    {
        return new Cliente
        {
            Nome = dto.Nome,
            Email = dto.Email,
            Telefone = dto.Telefone
        };
    }
}
