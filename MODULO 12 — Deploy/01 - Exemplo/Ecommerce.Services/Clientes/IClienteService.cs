using primeiraApi.Models;

namespace primeiraApi.Services;

public interface IClienteService
{
    Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Cliente> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Cliente> CreateAsync(Cliente cliente, CancellationToken cancellationToken = default);
    Task<Cliente> UpdateAsync(int id, Cliente cliente, CancellationToken cancellationToken = default);
    Task<Cliente> PatchAsync(int id, string nome, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
