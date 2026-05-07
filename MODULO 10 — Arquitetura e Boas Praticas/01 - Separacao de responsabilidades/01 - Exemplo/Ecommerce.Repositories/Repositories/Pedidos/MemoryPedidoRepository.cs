using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MemoryPedidoRepository : IPedidoRepository
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly List<Pedido> _pedidos = [];
    private readonly object _lock = new();
    private int _proximoId = 1;

    public MemoryPedidoRepository(IClienteRepository clienteRepository, IProdutoRepository produtoRepository)
    {
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
    }

    public Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            return Task.FromResult<IReadOnlyList<Pedido>>(_pedidos.Select(Clone).ToList());
        }
    }

    public Task<Pedido?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pedido is null ? null : Clone(pedido));
        }
    }

    public async Task<Pedido> AddAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        var novo = await MaterializeWithPricesAsync(pedido, cancellationToken);

        lock (_lock)
        {
            novo.Id = _proximoId++;
            _pedidos.Add(novo);
            return Clone(novo);
        }
    }

    public async Task<bool> UpdateAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        var atualizado = await MaterializeWithPricesAsync(pedido, cancellationToken);

        lock (_lock)
        {
            var indice = _pedidos.FindIndex(p => p.Id == pedido.Id);
            if (indice == -1)
            {
                return false;
            }

            atualizado.Id = pedido.Id;
            _pedidos[indice] = atualizado;
            return true;
        }
    }

    public Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
            if (pedido is null)
            {
                return Task.FromResult(false);
            }

            _pedidos.Remove(pedido);
            return Task.FromResult(true);
        }
    }

    private async Task<Pedido> MaterializeWithPricesAsync(Pedido pedido, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetByIdAsync(pedido.ClienteId, cancellationToken)
            ?? throw new InvalidOperationException($"Cliente {pedido.ClienteId} não encontrado.");

        var itens = new List<PedidoProduto>();

        foreach (var item in pedido.Itens)
        {
            var produto = await _produtoRepository.GetByIdAsync(item.ProdutoId, cancellationToken)
                ?? throw new InvalidOperationException($"Produto {item.ProdutoId} não encontrado.");

            itens.Add(new PedidoProduto
            {
                ProdutoId = produto.Id,
                Produto = produto,
                Quantidade = item.Quantidade,
                PrecoUnitario = produto.Preco
            });
        }

        return new Pedido
        {
            ClienteId = cliente.Id,
            Cliente = cliente,
            CriadoEm = pedido.CriadoEm,
            Observacao = pedido.Observacao,
            Itens = itens
        };
    }

    private static Pedido Clone(Pedido pedido)
    {
        return new Pedido
        {
            Id = pedido.Id,
            ClienteId = pedido.ClienteId,
            Cliente = pedido.Cliente is null
                ? new Cliente { Id = pedido.ClienteId, Nome = string.Empty }
                : new Cliente
                {
                    Id = pedido.Cliente.Id,
                    Nome = pedido.Cliente.Nome,
                    Email = pedido.Cliente.Email,
                    Telefone = pedido.Cliente.Telefone
                },
            CriadoEm = pedido.CriadoEm,
            Observacao = pedido.Observacao,
            Itens = pedido.Itens.Select(i => new PedidoProduto
            {
                PedidoId = pedido.Id,
                ProdutoId = i.ProdutoId,
                Produto = i.Produto is null
                    ? new Produto { Id = i.ProdutoId, Nome = string.Empty }
                    : new Produto
                    {
                        Id = i.Produto.Id,
                        Nome = i.Produto.Nome,
                        Preco = i.Produto.Preco,
                        Estoque = i.Produto.Estoque
                    },
                Quantidade = i.Quantidade,
                PrecoUnitario = i.PrecoUnitario
            }).ToList()
        };
    }
}
