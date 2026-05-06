using AutoMapper;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ClienteResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var clientes = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ClienteResponseDto>>(clientes);
    }

    public async Task<ClienteResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto> CreateAsync(ClienteRequestDto request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Cliente>(request);
        var criado = await _repository.AddAsync(entity, cancellationToken);
        return _mapper.Map<ClienteResponseDto>(criado);
    }

    public async Task<ClienteResponseDto> UpdateAsync(int id, ClienteRequestDto request, CancellationToken cancellationToken = default)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        _mapper.Map(request, cliente);

        await _repository.UpdateAsync(cliente, cancellationToken);
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task<ClienteResponseDto> PatchAsync(int id, ClientePatchRequestDto request, CancellationToken cancellationToken = default)
    {
        var cliente = await _repository.GetByIdAsync(id, cancellationToken);
        if (cliente is null)
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }

        cliente.Nome = request.Nome;
        await _repository.UpdateAsync(cliente, cancellationToken);
        return _mapper.Map<ClienteResponseDto>(cliente);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Cliente não encontrado");
        }
    }
}
