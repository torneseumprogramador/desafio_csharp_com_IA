using primeiraApi.DTOs;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class PedidoValidationService : IPedidoValidationService
{
    public void ValidateRequest(PedidoRequestDto request)
    {
        if (request.ClienteId <= 0)
        {
            throw new DomainValidationException("ClienteId deve ser informado.");
        }

        if (request.Itens.Count == 0)
        {
            throw new DomainValidationException("Pedido deve ter pelo menos um item.");
        }

        if (request.Itens.Any(i => i.ProdutoId <= 0))
        {
            throw new DomainValidationException("Todos os itens devem ter ProdutoId válido.");
        }

        if (request.Itens.Any(i => i.Quantidade <= 0))
        {
            throw new DomainValidationException("Todos os itens devem ter Quantidade maior que zero.");
        }
    }
}
