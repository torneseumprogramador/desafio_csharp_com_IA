using primeiraApi.DTOs;
using primeiraApi.ModelViews;

namespace primeiraApi.Services;

public interface IPedidoService
{
    Task<IReadOnlyList<PedidoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> CreateAsync(PedidoRequestDto request, CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> UpdateAsync(int id, PedidoRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
