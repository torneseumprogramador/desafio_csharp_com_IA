using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MySqlClienteRepository : IClienteRepository
{
    private readonly AppDbContext _dbContext;

    public MySqlClienteRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Clientes
            .AsNoTracking()
            .OrderBy(c => c.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<Cliente> AddAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        _dbContext.Clientes.Add(cliente);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return cliente;
    }

    public async Task<bool> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id, cancellationToken);
        if (existente is null)
        {
            return false;
        }

        existente.Nome = cliente.Nome;
        existente.Email = cliente.Email;
        existente.Telefone = cliente.Telefone;
        existente.Cpf = cliente.Cpf;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var cliente = await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (cliente is null)
        {
            return false;
        }

        _dbContext.Clientes.Remove(cliente);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
