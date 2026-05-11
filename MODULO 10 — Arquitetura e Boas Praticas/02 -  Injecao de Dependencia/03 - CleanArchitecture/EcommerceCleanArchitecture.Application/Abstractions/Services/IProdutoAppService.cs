using EcommerceCleanArchitecture.Application.DTOs.Produtos;

namespace EcommerceCleanArchitecture.Application.Abstractions.Services;

public interface IProdutoAppService
{
    Task<IReadOnlyList<ProdutoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProdutoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ProdutoResponseDto> CreateAsync(ProdutoRequestDto request, CancellationToken cancellationToken = default);
    Task<ProdutoResponseDto> UpdateAsync(int id, ProdutoRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
