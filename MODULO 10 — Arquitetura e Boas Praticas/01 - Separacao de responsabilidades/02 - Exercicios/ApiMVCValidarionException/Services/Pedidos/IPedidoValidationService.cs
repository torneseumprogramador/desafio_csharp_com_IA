using primeiraApi.DTOs;

namespace primeiraApi.Services;

public interface IPedidoValidationService
{
    void ValidateRequest(PedidoRequestDto request);
}
