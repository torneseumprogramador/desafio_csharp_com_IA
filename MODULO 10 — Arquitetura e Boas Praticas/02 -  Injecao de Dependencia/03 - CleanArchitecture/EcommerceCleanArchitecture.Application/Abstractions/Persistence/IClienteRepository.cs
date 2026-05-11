using EcommerceCleanArchitecture.Domain.Entities;

namespace EcommerceCleanArchitecture.Application.Abstractions.Persistence;

public interface IClienteRepository
{
    Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Cliente> AddAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
