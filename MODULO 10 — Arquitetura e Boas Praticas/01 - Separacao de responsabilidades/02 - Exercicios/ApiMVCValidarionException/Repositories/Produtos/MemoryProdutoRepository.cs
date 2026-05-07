using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MemoryProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos;
    private readonly object _lock = new();
    private int _proximoId;

    public MemoryProdutoRepository()
    {
        _produtos =
        [
            new Produto { Id = 1, Nome = "Teclado", Preco = 199.90m, Estoque = 20 },
            new Produto { Id = 2, Nome = "Mouse", Preco = 99.90m, Estoque = 50 }
        ];
        _proximoId = _produtos.Max(p => p.Id) + 1;
    }

    public Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            return Task.FromResult<IReadOnlyList<Produto>>(_produtos.Select(Clone).ToList());
        }
    }

    public Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(produto is null ? null : Clone(produto));
        }
    }

    public Task<Produto> AddAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var novo = new Produto
            {
                Id = _proximoId++,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Estoque = produto.Estoque
            };

            _produtos.Add(novo);
            return Task.FromResult(Clone(novo));
        }
    }

    public Task<bool> UpdateAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var indice = _produtos.FindIndex(p => p.Id == produto.Id);
            if (indice == -1)
            {
                return Task.FromResult(false);
            }

            _produtos[indice] = Clone(produto);
            return Task.FromResult(true);
        }
    }

    public Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var produto = _produtos.FirstOrDefault(p => p.Id == id);
            if (produto is null)
            {
                return Task.FromResult(false);
            }

            _produtos.Remove(produto);
            return Task.FromResult(true);
        }
    }

    private static Produto Clone(Produto produto)
    {
        return new Produto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Estoque = produto.Estoque
        };
    }
}
