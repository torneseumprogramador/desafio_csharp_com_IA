using System.Security.Cryptography;
using primeiraApi.Models;
using primeiraApi.Repositories;
using primeiraApi.Services.Administradores.Results;
using primeiraApi.Services.Exceptions;

namespace primeiraApi.Services;

public class AdministradorService : IAdministradorService
{
    private const int Iterations = 100000;
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private readonly IAdministradorRepository _repository;
    private readonly ISaltProtector _saltProtector;

    public AdministradorService(IAdministradorRepository repository, ISaltProtector saltProtector)
    {
        _repository = repository;
        _saltProtector = saltProtector;
    }

    public Task<IReadOnlyList<Administrador>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public async Task<Administrador> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var administrador = await _repository.GetByIdAsync(id, cancellationToken);
        if (administrador is null)
        {
            throw new ResourceNotFoundException("Administrador não encontrado.");
        }

        return administrador;
    }

    public async Task<Administrador> CreateAsync(Administrador administrador, CancellationToken cancellationToken = default)
    {
        await ValidateAdministradorAsync(administrador, null, true, cancellationToken);
        AplicarHashSenha(administrador, administrador.Senha);

        return await _repository.AddAsync(administrador, cancellationToken);
    }

    public async Task<Administrador> UpdateAsync(
        int id,
        Administrador administradorAtualizado,
        CancellationToken cancellationToken = default)
    {
        var administrador = await _repository.GetByIdAsync(id, cancellationToken);
        if (administrador is null)
        {
            throw new ResourceNotFoundException("Administrador não encontrado.");
        }

        await ValidateAdministradorAsync(administradorAtualizado, id, false, cancellationToken);

        administrador.Nome = administradorAtualizado.Nome;
        administrador.Email = administradorAtualizado.Email;
        administrador.Rule = administradorAtualizado.Rule;

        if (!string.IsNullOrWhiteSpace(administradorAtualizado.Senha))
        {
            AplicarHashSenha(administrador, administradorAtualizado.Senha);
        }

        await _repository.UpdateAsync(administrador, cancellationToken);
        return administrador;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        if (!await _repository.RemoveAsync(id, cancellationToken))
        {
            throw new ResourceNotFoundException("Administrador não encontrado.");
        }
    }

    public async Task<AdministradorLoginResult?> AutenticarAsync(
        string email,
        string senha,
        CancellationToken cancellationToken = default)
    {
        var administrador = await _repository.GetByEmailAsync(email, cancellationToken);
        if (administrador is null || !SenhaValida(senha, administrador))
        {
            return null;
        }

        return new AdministradorLoginResult
        {
            Id = administrador.Id,
            Nome = administrador.Nome,
            Email = administrador.Email,
            Rule = administrador.Rule
        };
    }

    private bool SenhaValida(string senha, Administrador administrador)
    {
        var saltProtegido = _saltProtector.Unprotect(administrador.Salt);
        var salt = Convert.FromBase64String(saltProtegido);
        var hashInformado = GerarHash(senha, salt);
        var hashPersistido = Convert.FromBase64String(administrador.Senha);

        return CryptographicOperations.FixedTimeEquals(hashInformado, hashPersistido);
    }

    private async Task ValidateAdministradorAsync(
        Administrador administrador,
        int? idAtual,
        bool senhaObrigatoria,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(administrador.Nome))
        {
            throw new ServiceValidationException("Nome do administrador é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(administrador.Email) || !administrador.Email.Contains('@'))
        {
            throw new ServiceValidationException("Email do administrador é inválido.");
        }

        if (!Enum.IsDefined(administrador.Rule))
        {
            throw new ServiceValidationException("Rule deve ser Administrador ou Editor.");
        }

        if (senhaObrigatoria && string.IsNullOrWhiteSpace(administrador.Senha))
        {
            throw new ServiceValidationException("Senha do administrador é obrigatória.");
        }

        if (!string.IsNullOrWhiteSpace(administrador.Senha) && administrador.Senha.Length < 6)
        {
            throw new ServiceValidationException("Senha deve ter pelo menos 6 caracteres.");
        }

        var administradorComMesmoEmail = await _repository.GetByEmailAsync(administrador.Email, cancellationToken);
        if (administradorComMesmoEmail is not null && administradorComMesmoEmail.Id != idAtual)
        {
            throw new ServiceValidationException("Já existe um administrador com este email.");
        }
    }

    private void AplicarHashSenha(Administrador administrador, string senha)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var saltBase64 = Convert.ToBase64String(salt);

        administrador.Salt = _saltProtector.Protect(saltBase64);
        administrador.Senha = Convert.ToBase64String(GerarHash(senha, salt));
    }

    private static byte[] GerarHash(string senha, byte[] salt)
    {
        return Rfc2898DeriveBytes.Pbkdf2(
            senha,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);
    }
}
