using primeiraApi.Models;
using primeiraApi.Services.Administradores.Results;

namespace primeiraApi.Services;

public interface IAdministradorService
{
    Task<IReadOnlyList<Administrador>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Administrador> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Administrador> CreateAsync(Administrador administrador, CancellationToken cancellationToken = default);
    Task<Administrador> UpdateAsync(int id, Administrador administrador, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<AdministradorLoginResult?> AutenticarAsync(
        string email,
        string senha,
        CancellationToken cancellationToken = default);
}
