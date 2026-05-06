using primeiraApi.DTOs;
using primeiraApi.ModelViews;

namespace primeiraApi.Services;

public interface IClienteService
{
    Task<IReadOnlyList<ClienteResponseDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request, CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> UpdateAsync(int id, ClienteRequestDto request, CancellationToken cancellationToken = default);
    Task<ClienteResponseDto> PatchAsync(int id, ClientePatchRequestDto request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
