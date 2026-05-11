using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MySqlProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _dbContext;

    public MySqlProdutoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Produtos
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Produto> AddAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        _dbContext.Produtos.Add(produto);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return produto;
    }

    public async Task<bool> UpdateAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == produto.Id, cancellationToken);
        if (existente is null)
        {
            return false;
        }

        existente.Nome = produto.Nome;
        existente.Preco = produto.Preco;
        existente.Estoque = produto.Estoque;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (existente is null)
        {
            return false;
        }

        _dbContext.Produtos.Remove(existente);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
