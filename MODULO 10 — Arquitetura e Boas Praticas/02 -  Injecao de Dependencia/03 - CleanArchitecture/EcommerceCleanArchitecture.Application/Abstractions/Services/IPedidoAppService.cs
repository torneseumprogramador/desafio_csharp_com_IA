using EcommerceCleanArchitecture.Application.DTOs.Pedidos;

namespace EcommerceCleanArchitecture.Application.Abstractions.Services;

public interface IPedidoAppService
{
    Task<IReadOnlyList<PedidoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> CreateAsync(PedidoRequestDto request, CancellationToken cancellationToken = default);
    Task<PedidoResponseDto> UpdateAsync(int id, PedidoRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
