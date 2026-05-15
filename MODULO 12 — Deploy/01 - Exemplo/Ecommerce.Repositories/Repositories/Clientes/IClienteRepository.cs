using primeiraApi.Models;

namespace primeiraApi.Repositories;

public interface IClienteRepository
{
    Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Cliente> AddAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<bool> HasPedidosAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);
}
