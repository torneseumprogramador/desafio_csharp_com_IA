using primeiraApi.Models;

namespace primeiraApi.Repositories;

public interface IAdministradorRepository
{
    Task<IReadOnlyList<Administrador>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Administrador?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Administrador?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<Administrador> AddAsync(Administrador administrador, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Administrador administrador, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);
}
