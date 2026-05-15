using primeiraApi.Enums;

namespace primeiraApi.Services.Auth;

public interface ITokenService
{
    string GerarToken(string nome, string email, AdministradorRule rule, DateTime expiraEm);
}
