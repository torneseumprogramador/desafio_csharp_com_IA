using primeiraApi.Models;

namespace primeiraApi.Repositories;

public interface IPedidoRepository
{
    Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Pedido?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Pedido> AddAsync(Pedido pedido, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Pedido pedido, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);
}
