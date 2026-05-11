using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Domain.Entities;
using EcommerceCleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCleanArchitecture.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Produto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Produtos
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Produto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _context.Produtos
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Produto> AddAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync(cancellationToken);
        return produto;
    }

    public async Task<bool> UpdateAsync(Produto produto, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == produto.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        entity.Nome = produto.Nome;
        entity.Descricao = produto.Descricao;
        entity.Preco = produto.Preco;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        _context.Produtos.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
