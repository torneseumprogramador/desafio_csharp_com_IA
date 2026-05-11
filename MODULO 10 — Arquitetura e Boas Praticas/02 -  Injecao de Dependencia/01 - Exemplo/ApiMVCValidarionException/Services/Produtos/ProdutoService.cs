using AutoMapper;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;
    private readonly IProdutoValidationService _validationService;
    private readonly IMapper _mapper;

    public ProdutoService(IProdutoRepository repository, IProdutoValidationService validationService, IMapper mapper)
    {
        _repository = repository;
        _validationService = validationService;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ProdutoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProdutoResponseDto>>(produtos);
    }

    public async Task<ProdutoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var produto = await _repository.GetByIdAsync(id, cancellationToken);
        if (produto is null)
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }

        return _mapper.Map<ProdutoResponseDto>(produto);
    }

    public async Task<ProdutoResponseDto> CreateAsync(ProdutoRequestDto request, CancellationToken cancellationToken = default)
    {
        _validationService.ValidateRequest(request);
        var entity = _mapper.Map<Produto>(request);
        var criado = await _repository.AddAsync(entity, cancellationToken);
        return _mapper.Map<ProdutoResponseDto>(criado);
    }

    public async Task<ProdutoResponseDto> UpdateAsync(int id, ProdutoRequestDto request, CancellationToken cancellationToken = default)
    {
        _validationService.ValidateRequest(request);

        var produto = await _repository.GetByIdAsync(id, cancellationToken);
        if (produto is null)
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }

        _mapper.Map(request, produto);
        await _repository.UpdateAsync(produto, cancellationToken);

        return _mapper.Map<ProdutoResponseDto>(produto);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }
    }
}
