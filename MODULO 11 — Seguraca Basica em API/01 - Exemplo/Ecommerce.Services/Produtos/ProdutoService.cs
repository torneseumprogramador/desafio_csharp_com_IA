using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Produto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var produto = await _repository.GetByIdAsync(id, cancellationToken);
        if (produto is null)
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }

        return produto;
    }

    public Task<Produto> CreateAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        ValidateProduto(produto);
        return _repository.AddAsync(produto, cancellationToken);
    }

    public async Task<Produto> UpdateAsync(int id, Produto produtoAtualizado, CancellationToken cancellationToken = default)
    {
        ValidateProduto(produtoAtualizado);

        var produto = await _repository.GetByIdAsync(id, cancellationToken);
        if (produto is null)
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;
        await _repository.UpdateAsync(produto, cancellationToken);

        return produto;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Produto não encontrado");
        }
    }

    private static void ValidateProduto(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new ServiceValidationException("Nome do produto é obrigatório.");
        }

        if (produto.Preco <= 0)
        {
            throw new ServiceValidationException("Preço do produto deve ser maior que zero.");
        }

        if (produto.Estoque < 0)
        {
            throw new ServiceValidationException("Estoque do produto não pode ser negativo.");
        }
    }
}
