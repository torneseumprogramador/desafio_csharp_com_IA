using primeiraApi.DTOs;

namespace primeiraApi.Services;

public interface IClienteValidationService
{
    void ValidateRequest(ClienteRequestDto request);
    void ValidatePatchRequest(ClientePatchRequestDto request);
}
