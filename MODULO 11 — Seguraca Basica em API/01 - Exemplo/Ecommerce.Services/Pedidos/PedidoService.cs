using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;

    public PedidoService(IPedidoRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Pedido> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pedido = await _repository.GetByIdAsync(id, cancellationToken);
        if (pedido is null)
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }

        return pedido;
    }

    public async Task<Pedido> CreateAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        ValidatePedido(pedido);
        return await _repository.AddAsync(pedido, cancellationToken);
    }

    public async Task<Pedido> UpdateAsync(int id, Pedido pedidoAtualizado, CancellationToken cancellationToken = default)
    {
        ValidatePedido(pedidoAtualizado);

        var pedido = await _repository.GetByIdAsync(id, cancellationToken);
        if (pedido is null)
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }

        pedido.ClienteId = pedidoAtualizado.ClienteId;
        pedido.Observacao = pedidoAtualizado.Observacao;
        pedido.Itens = pedidoAtualizado.Itens;

        foreach (var item in pedido.Itens)
        {
            item.PedidoId = id;
        }

        await _repository.UpdateAsync(pedido, cancellationToken);
        var atualizado = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new ResourceNotFoundException("Pedido não encontrado");

        return atualizado;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }
    }

    private static void ValidatePedido(Pedido pedido)
    {
        if (pedido.ClienteId <= 0)
        {
            throw new ServiceValidationException("ClienteId deve ser informado.");
        }

        if (pedido.Itens is null || pedido.Itens.Count == 0)
        {
            throw new ServiceValidationException("Pedido deve ter pelo menos um item.");
        }

        if (pedido.Itens.Any(i => i.ProdutoId <= 0))
        {
            throw new ServiceValidationException("Todos os itens devem ter ProdutoId válido.");
        }

        if (pedido.Itens.Any(i => i.Quantidade <= 0))
        {
            throw new ServiceValidationException("Todos os itens devem ter Quantidade maior que zero.");
        }
    }
}
