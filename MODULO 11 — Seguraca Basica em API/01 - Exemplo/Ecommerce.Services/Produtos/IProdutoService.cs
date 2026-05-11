using primeiraApi.Models;

namespace primeiraApi.Services;

public interface IProdutoService
{
    Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Produto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Produto> CreateAsync(Produto produto, CancellationToken cancellationToken = default);
    Task<Produto> UpdateAsync(int id, Produto produto, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
