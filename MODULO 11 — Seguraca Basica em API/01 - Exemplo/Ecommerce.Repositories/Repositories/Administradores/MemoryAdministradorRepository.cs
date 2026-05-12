using primeiraApi.Enums;
using primeiraApi.Models;

namespace primeiraApi.Repositories;

public class MemoryAdministradorRepository : IAdministradorRepository
{
    private readonly List<Administrador> _administradores =
    [
        new Administrador
        {
            Id = 1,
            Nome = "Administrador",
            Email = "admin@ecommerce.com",
            Rule = AdministradorRule.Administrador,
            Senha = "arsKZFqL7zbZu5WW4HT5In6wqWh23P401ucxeFcDnPM=",
            Salt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdGa2JXbHVJUT09In0.XhTBjWjQ4a0iU_m3lTQazJCi0KSDef_kM1wFhYD28pI"
        },
        new Administrador
        {
            Id = 2,
            Nome = "Editor",
            Email = "editor@ecommerce.com",
            Rule = AdministradorRule.Editor,
            Senha = "YIqRvjW3RdX4B5emFtgvGuyJ7lRBEghAkWOYEQMWjAo=",
            Salt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdWa2FYUnZjZz09In0.AyDxp6PGB4SQvRNCxINl9aHmDNcgVq-872nXC2e3bO4"
        }
    ];
    private readonly object _lock = new();
    private int _proximoId = 3;

    public Task<IReadOnlyList<Administrador>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            return Task.FromResult<IReadOnlyList<Administrador>>(_administradores.Select(Clone).ToList());
        }
    }

    public Task<Administrador?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var administrador = _administradores.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(administrador is null ? null : Clone(administrador));
        }
    }

    public Task<Administrador?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var administrador = _administradores
                .FirstOrDefault(a => string.Equals(a.Email, email, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(administrador is null ? null : Clone(administrador));
        }
    }

    public Task<Administrador> AddAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var novo = Clone(administrador);
            novo.Id = _proximoId++;
            _administradores.Add(novo);

            return Task.FromResult(Clone(novo));
        }
    }

    public Task<bool> UpdateAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var indice = _administradores.FindIndex(a => a.Id == administrador.Id);
            if (indice == -1)
            {
                return Task.FromResult(false);
            }

            _administradores[indice] = Clone(administrador);
            return Task.FromResult(true);
        }
    }

    public Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        lock (_lock)
        {
            var administrador = _administradores.FirstOrDefault(a => a.Id == id);
            if (administrador is null)
            {
                return Task.FromResult(false);
            }

            _administradores.Remove(administrador);
            return Task.FromResult(true);
        }
    }

    private static Administrador Clone(Administrador administrador)
    {
        return new Administrador
        {
            Id = administrador.Id,
            Nome = administrador.Nome,
            Email = administrador.Email,
            Rule = administrador.Rule,
            Senha = administrador.Senha,
            Salt = administrador.Salt
        };
    }
}
