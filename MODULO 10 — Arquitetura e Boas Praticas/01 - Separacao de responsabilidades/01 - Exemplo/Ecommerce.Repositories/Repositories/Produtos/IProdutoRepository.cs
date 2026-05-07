using primeiraApi.Models;

namespace primeiraApi.Repositories;

public interface IProdutoRepository
{
    Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Produto> AddAsync(Produto produto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Produto produto, CancellationToken cancellationToken = default);
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);
}
