using primeiraApi.DTOs;

namespace primeiraApi.Services;

public interface IProdutoValidationService
{
    void ValidateRequest(ProdutoRequestDto request);
}
