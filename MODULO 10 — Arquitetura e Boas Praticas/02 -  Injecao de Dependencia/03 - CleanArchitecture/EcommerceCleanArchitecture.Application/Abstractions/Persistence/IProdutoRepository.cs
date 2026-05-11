using EcommerceCleanArchitecture.Domain.Entities;

namespace EcommerceCleanArchitecture.Application.Abstractions.Persistence;

public interface IProdutoRepository
{
    Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Produto> AddAsync(Produto produto, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(Produto produto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
