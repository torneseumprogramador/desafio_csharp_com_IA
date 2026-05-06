using AutoMapper;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repository;
    private readonly IPedidoValidationService _validationService;
    private readonly IMapper _mapper;

    public PedidoService(IPedidoRepository repository, IPedidoValidationService validationService, IMapper mapper)
    {
        _repository = repository;
        _validationService = validationService;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<PedidoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var pedidos = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<PedidoResponseDto>>(pedidos);
    }

    public async Task<PedidoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var pedido = await _repository.GetByIdAsync(id, cancellationToken);
        if (pedido is null)
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }

        return _mapper.Map<PedidoResponseDto>(pedido);
    }

    public async Task<PedidoResponseDto> CreateAsync(PedidoRequestDto request, CancellationToken cancellationToken = default)
    {
        _validationService.ValidateRequest(request);

        var pedido = new Pedido
        {
            ClienteId = request.ClienteId,
            CriadoEm = DateTime.UtcNow,
            Observacao = request.Observacao,
            Itens = _mapper.Map<List<PedidoProduto>>(request.Itens)
        };

        var criado = await _repository.AddAsync(pedido, cancellationToken);
        return _mapper.Map<PedidoResponseDto>(criado);
    }

    public async Task<PedidoResponseDto> UpdateAsync(int id, PedidoRequestDto request, CancellationToken cancellationToken = default)
    {
        _validationService.ValidateRequest(request);

        var pedido = await _repository.GetByIdAsync(id, cancellationToken);
        if (pedido is null)
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }

        pedido.ClienteId = request.ClienteId;
        pedido.Observacao = request.Observacao;
        pedido.Itens = _mapper.Map<List<PedidoProduto>>(request.Itens);

        foreach (var item in pedido.Itens)
        {
            item.PedidoId = id;
        }

        await _repository.UpdateAsync(pedido, cancellationToken);
        var atualizado = await _repository.GetByIdAsync(id, cancellationToken)
            ?? throw new ResourceNotFoundException("Pedido não encontrado");

        return _mapper.Map<PedidoResponseDto>(atualizado);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Pedido não encontrado");
        }
    }
}
