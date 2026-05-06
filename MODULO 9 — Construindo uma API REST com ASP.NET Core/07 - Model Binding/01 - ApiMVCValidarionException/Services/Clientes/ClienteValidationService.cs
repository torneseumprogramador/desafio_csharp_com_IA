using primeiraApi.DTOs;
using primeiraApi.Services.Exceptions;
using primeiraApi.ValueObjects;

namespace primeiraApi.Services;

public class ClienteValidationService : IClienteValidationService
{
    public void ValidateRequest(ClienteRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new DomainValidationException("Nome do cliente é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains('@'))
        {
            throw new DomainValidationException("Email do cliente é inválido.");
        }

        if (string.IsNullOrWhiteSpace(request.Telefone))
        {
            throw new DomainValidationException("Telefone do cliente é obrigatório.");
        }

        try
        {
            _ = new Cpf(request.Cpf);
        }
        catch (ArgumentException ex)
        {
            throw new DomainValidationException(ex.Message);
        }
    }

    public void ValidatePatchRequest(ClientePatchRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new DomainValidationException("Nome do cliente é obrigatório.");
        }
    }
}
