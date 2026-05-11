using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Domain.Entities;
using EcommerceCleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCleanArchitecture.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Pedidos
            .AsNoTracking()
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .OrderByDescending(p => p.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Pedido?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _context.Pedidos
            .AsNoTracking()
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Pedido> AddAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync(cancellationToken);

        return await GetByIdAsync(pedido.Id, cancellationToken) ?? pedido;
    }

    public async Task<bool> UpdateAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == pedido.Id, cancellationToken);

        if (entity is null)
        {
            return false;
        }

        entity.ClienteId = pedido.ClienteId;
        entity.Observacao = pedido.Observacao;

        _context.PedidoProdutos.RemoveRange(entity.Itens);
        entity.Itens.Clear();

        foreach (var item in pedido.Itens)
        {
            entity.Itens.Add(new PedidoProduto
            {
                PedidoId = pedido.Id,
                ProdutoId = item.ProdutoId,
                Quantidade = item.Quantidade,
                PrecoUnitario = item.PrecoUnitario
            });
        }

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        _context.Pedidos.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
