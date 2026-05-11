using primeiraApi.DTOs;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class ProdutoValidationService : IProdutoValidationService
{
    public void ValidateRequest(ProdutoRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new DomainValidationException("Nome do produto é obrigatório.");
        }

        if (request.Preco <= 0)
        {
            throw new DomainValidationException("Preço do produto deve ser maior que zero.");
        }

        if (request.Estoque < 0)
        {
            throw new DomainValidationException("Estoque do produto não pode ser negativo.");
        }
    }
}
