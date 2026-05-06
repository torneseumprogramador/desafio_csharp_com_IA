using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MySqlPedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _dbContext;

    public MySqlPedidoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Pedido>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Pedidos
            .AsNoTracking()
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .OrderByDescending(p => p.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Pedido?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Pedidos
            .AsNoTracking()
            .Include(p => p.Cliente)
            .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    public async Task<Pedido> AddAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        pedido.CriadoEm = pedido.CriadoEm == default ? DateTime.UtcNow : pedido.CriadoEm;
        var clienteExiste = await _dbContext.Clientes.AsNoTracking()
            .AnyAsync(c => c.Id == pedido.ClienteId, cancellationToken);
        if (!clienteExiste)
        {
            throw new InvalidOperationException($"Cliente {pedido.ClienteId} não encontrado.");
        }

        foreach (var item in pedido.Itens)
        {
            var produto = await _dbContext.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == item.ProdutoId, cancellationToken)
                ?? throw new InvalidOperationException($"Produto {item.ProdutoId} não encontrado.");

            item.PrecoUnitario = produto.Preco;
        }

        _dbContext.Pedidos.Add(pedido);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return await GetByIdAsync(pedido.Id, cancellationToken) ?? pedido;
    }

    public async Task<bool> UpdateAsync(Pedido pedido, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Pedidos
            .Include(p => p.Itens)
            .FirstOrDefaultAsync(p => p.Id == pedido.Id, cancellationToken);

        if (existente is null)
        {
            return false;
        }

        var clienteExiste = await _dbContext.Clientes.AsNoTracking()
            .AnyAsync(c => c.Id == pedido.ClienteId, cancellationToken);
        if (!clienteExiste)
        {
            throw new InvalidOperationException($"Cliente {pedido.ClienteId} não encontrado.");
        }

        existente.ClienteId = pedido.ClienteId;
        existente.Observacao = pedido.Observacao;

        _dbContext.RemoveRange(existente.Itens);
        existente.Itens.Clear();

        foreach (var item in pedido.Itens)
        {
            var produto = await _dbContext.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == item.ProdutoId, cancellationToken)
                ?? throw new InvalidOperationException($"Produto {item.ProdutoId} não encontrado.");

            existente.Itens.Add(new PedidoProduto
            {
                ProdutoId = produto.Id,
                Quantidade = item.Quantidade,
                PrecoUnitario = produto.Preco
            });
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Pedidos
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (existente is null)
        {
            return false;
        }

        _dbContext.Pedidos.Remove(existente);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
