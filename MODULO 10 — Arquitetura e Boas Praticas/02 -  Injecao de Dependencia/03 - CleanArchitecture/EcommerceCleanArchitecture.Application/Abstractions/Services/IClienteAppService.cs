using EcommerceCleanArchitecture.Application.DTOs.Clientes;

namespace EcommerceCleanArchitecture.Application.Abstractions.Services;

public interface IClienteAppService
{
    Task<IReadOnlyList<ClienteResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request, CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> UpdateAsync(int id, ClienteRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
