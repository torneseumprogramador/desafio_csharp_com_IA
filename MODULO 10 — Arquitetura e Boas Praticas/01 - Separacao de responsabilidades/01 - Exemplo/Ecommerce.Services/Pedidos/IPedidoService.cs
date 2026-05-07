using primeiraApi.Models;

namespace primeiraApi.Services;

public interface IPedidoService
{
    Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Pedido> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Pedido> CreateAsync(Pedido pedido, CancellationToken cancellationToken = default);
    Task<Pedido> UpdateAsync(int id, Pedido pedido, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
