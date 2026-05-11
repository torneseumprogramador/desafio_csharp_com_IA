using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Application.Abstractions.Services;
using EcommerceCleanArchitecture.Application.DTOs.Pedidos;
using EcommerceCleanArchitecture.Application.Exceptions;
using EcommerceCleanArchitecture.Domain.Entities;

namespace EcommerceCleanArchitecture.Application.Services;

public class PedidoAppService : IPedidoAppService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;

    public PedidoAppService(
        IPedidoRepository pedidoRepository,
        IClienteRepository clienteRepository,
        IProdutoRepository produtoRepository)
    {
        _pedidoRepository = pedidoRepository;
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<IReadOnlyList<PedidoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var pedidos = await _pedidoRepository.GetAllAsync(cancellationToken);
        return pedidos.Select(p => p.ToResponse()).ToList();
    }

    public async Task<PedidoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pedido = await _pedidoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Pedido não encontrado.");

        return pedido.ToResponse();
    }

    public async Task<PedidoResponseDto> CreateAsync(PedidoRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        await EnsureClienteExists(request.ClienteId, cancellationToken);

        var pedido = new Pedido
        {
            ClienteId = request.ClienteId,
            Observacao = request.Observacao?.Trim()
        };

        foreach (var item in request.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId, cancellationToken)
                ?? throw new ValidationException($"Produto {item.ProdutoId} não encontrado.");

            pedido.Itens.Add(new PedidoProduto
            {
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade,
                PrecoUnitario = produto.Preco
            });
        }

        var salvo = await _pedidoRepository.AddAsync(pedido, cancellationToken);
        return salvo.ToResponse();
    }

    public async Task<PedidoResponseDto> UpdateAsync(int id, PedidoRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);
        await EnsureClienteExists(request.ClienteId, cancellationToken);

        var existente = await _pedidoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Pedido não encontrado.");

        existente.ClienteId = request.ClienteId;
        existente.Observacao = request.Observacao?.Trim();
        existente.Itens.Clear();

        foreach (var item in request.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId, cancellationToken)
                ?? throw new ValidationException($"Produto {item.ProdutoId} não encontrado.");

            existente.Itens.Add(new PedidoProduto
            {
                PedidoId = id,
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade,
                PrecoUnitario = produto.Preco
            });
        }

        await _pedidoRepository.UpdateAsync(existente, cancellationToken);
        var atualizado = await _pedidoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Pedido não encontrado.");

        return atualizado.ToResponse();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var removido = await _pedidoRepository.DeleteAsync(id, cancellationToken);
        if (!removido)
        {
            throw new NotFoundException("Pedido não encontrado.");
        }
    }

    private async Task EnsureClienteExists(int clienteId, CancellationToken cancellationToken)
    {
        if (clienteId <= 0)
        {
            throw new ValidationException("ClienteId deve ser maior que zero.");
        }

        var cliente = await _clienteRepository.GetByIdAsync(clienteId, cancellationToken);
        if (cliente is null)
        {
            throw new ValidationException($"Cliente {clienteId} não encontrado.");
        }
    }

    private static void ValidateRequest(PedidoRequestDto request)
    {
        if (request.ClienteId <= 0)
        {
            throw new ValidationException("ClienteId deve ser maior que zero.");
        }

        if (request.Itens.Count == 0)
        {
            throw new ValidationException("Pedido deve ter ao menos um item.");
        }

        if (request.Itens.Count > 100)
        {
            throw new ValidationException("Pedido não pode ter mais de 100 itens.");
        }

        if (request.Itens.Any(i => i.ProdutoId <= 0))
        {
            throw new ValidationException("Todos os itens devem possuir ProdutoId válido.");
        }

        if (request.Itens.Any(i => i.Quantidade <= 0))
        {
            throw new ValidationException("Quantidade deve ser maior que zero.");
        }

        if (request.Itens.Any(i => i.Quantidade > 1000))
        {
            throw new ValidationException("Quantidade por item não pode ultrapassar 1000 unidades.");
        }

        if (request.Itens.GroupBy(i => i.ProdutoId).Any(g => g.Count() > 1))
        {
            throw new ValidationException("Pedido não pode conter produtos repetidos.");
        }

        if (!string.IsNullOrWhiteSpace(request.Observacao) && request.Observacao.Trim().Length > 500)
        {
            throw new ValidationException("Observação do pedido pode ter no máximo 500 caracteres.");
        }
    }
}
