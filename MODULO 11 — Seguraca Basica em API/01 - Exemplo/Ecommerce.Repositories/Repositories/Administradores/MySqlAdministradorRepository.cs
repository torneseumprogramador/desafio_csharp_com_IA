using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MySqlAdministradorRepository : IAdministradorRepository
{
    private readonly AppDbContext _dbContext;

    public MySqlAdministradorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Administrador>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Administradores
            .AsNoTracking()
            .OrderBy(a => a.Id)
            .ToListAsync(cancellationToken);
    }

    public Task<Administrador?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return _dbContext.Administradores
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public Task<Administrador?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return _dbContext.Administradores
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public async Task<Administrador> AddAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        _dbContext.Administradores.Add(administrador);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return administrador;
    }

    public async Task<bool> UpdateAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        var existente = await _dbContext.Administradores
            .FirstOrDefaultAsync(a => a.Id == administrador.Id, cancellationToken);

        if (existente is null)
        {
            return false;
        }

        existente.Nome = administrador.Nome;
        existente.Email = administrador.Email;
        existente.Rule = administrador.Rule;
        existente.Senha = administrador.Senha;
        existente.Salt = administrador.Salt;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var administrador = await _dbContext.Administradores
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (administrador is null)
        {
            return false;
        }

        _dbContext.Administradores.Remove(administrador);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
