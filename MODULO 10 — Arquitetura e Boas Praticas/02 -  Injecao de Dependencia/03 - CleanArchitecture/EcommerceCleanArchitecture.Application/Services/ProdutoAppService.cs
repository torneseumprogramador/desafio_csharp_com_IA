using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Application.Abstractions.Services;
using EcommerceCleanArchitecture.Application.DTOs.Produtos;
using EcommerceCleanArchitecture.Application.Exceptions;
using EcommerceCleanArchitecture.Domain.Entities;

namespace EcommerceCleanArchitecture.Application.Services;

public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoAppService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IReadOnlyList<ProdutoResponseDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepository.GetAllAsync(cancellationToken);
        return produtos.Select(p => p.ToResponse()).ToList();
    }

    public async Task<ProdutoResponseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var produto = await _produtoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Produto não encontrado.");

        return produto.ToResponse();
    }

    public async Task<ProdutoResponseDto> CreateAsync(ProdutoRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);

        var novoProduto = new Produto
        {
            Nome = request.Nome.Trim(),
            Descricao = request.Descricao.Trim(),
            Preco = request.Preco
        };

        var salvo = await _produtoRepository.AddAsync(novoProduto, cancellationToken);
        return salvo.ToResponse();
    }

    public async Task<ProdutoResponseDto> UpdateAsync(int id, ProdutoRequestDto request, CancellationToken cancellationToken = default)
    {
        ValidateRequest(request);

        var existente = await _produtoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Produto não encontrado.");

        existente.Nome = request.Nome.Trim();
        existente.Descricao = request.Descricao.Trim();
        existente.Preco = request.Preco;

        await _produtoRepository.UpdateAsync(existente, cancellationToken);
        return existente.ToResponse();
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var removido = await _produtoRepository.DeleteAsync(id, cancellationToken);
        if (!removido)
        {
            throw new NotFoundException("Produto não encontrado.");
        }
    }

    private static void ValidateRequest(ProdutoRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new ValidationException("Nome do produto é obrigatório.");
        }

        var nome = request.Nome.Trim();
        if (nome.Length < 3 || nome.Length > 120)
        {
            throw new ValidationException("Nome do produto deve ter entre 3 e 120 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Descricao))
        {
            throw new ValidationException("Descrição do produto é obrigatória.");
        }

        var descricao = request.Descricao.Trim();
        if (descricao.Length is < 10 or > 500)
        {
            throw new ValidationException("Descrição do produto deve ter entre 10 e 500 caracteres.");
        }

        if (request.Preco <= 0)
        {
            throw new ValidationException("Preço do produto deve ser maior que zero.");
        }

        if (request.Preco > 1_000_000m)
        {
            throw new ValidationException("Preço do produto excede o valor máximo permitido.");
        }
    }
}
