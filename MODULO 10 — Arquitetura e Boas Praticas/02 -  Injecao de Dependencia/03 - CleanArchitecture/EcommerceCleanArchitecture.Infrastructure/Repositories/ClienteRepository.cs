using EcommerceCleanArchitecture.Application.Abstractions.Persistence;
using EcommerceCleanArchitecture.Domain.Entities;
using EcommerceCleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EcommerceCleanArchitecture.Infrastructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Cliente>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Clientes
            .AsNoTracking()
            .OrderBy(x => x.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Cliente?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _context.Clientes
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<Cliente> AddAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync(cancellationToken);
        return cliente;
    }

    public async Task<bool> UpdateAsync(Cliente cliente, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == cliente.Id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        entity.Nome = cliente.Nome;
        entity.Email = cliente.Email;
        entity.Telefone = cliente.Telefone;
        entity.Cpf = cliente.Cpf;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        if (entity is null)
        {
            return false;
        }

        _context.Clientes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
