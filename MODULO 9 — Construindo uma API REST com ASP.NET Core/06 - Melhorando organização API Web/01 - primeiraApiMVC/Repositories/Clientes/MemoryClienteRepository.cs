using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MemoryClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes;
    private readonly object _lock = new();
    private int _proximoId;

    public MemoryClienteRepository()
    {
        _clientes =
        [
            new Cliente { Id = 1, Nome = "Ana Souza", Email = "ana@email.com", Telefone = "11999990001" },
            new Cliente { Id = 2, Nome = "Bruno Lima", Email = "bruno@email.com", Telefone = "11999990002" }
        ];
        _proximoId = _clientes.Max(c => c.Id) + 1;
    }

    public Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            return Task.FromResult<IReadOnlyList<Cliente>>(_clientes.Select(Clone).ToList());
        }
    }

    public Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente is null ? null : Clone(cliente));
        }
    }

    public Task<Cliente> AddAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var novo = new Cliente
            {
                Id = _proximoId++,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone
            };

            _clientes.Add(novo);
            return Task.FromResult(Clone(novo));
        }
    }

    public Task<bool> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var indice = _clientes.FindIndex(c => c.Id == cliente.Id);
            if (indice == -1)
            {
                return Task.FromResult(false);
            }

            _clientes[indice] = Clone(cliente);
            return Task.FromResult(true);
        }
    }

    public Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente is null)
            {
                return Task.FromResult(false);
            }

            _clientes.Remove(cliente);
            return Task.FromResult(true);
        }
    }

    private static Cliente Clone(Cliente cliente)
    {
        return new Cliente
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Email = cliente.Email,
            Telefone = cliente.Telefone
        };
    }
}
