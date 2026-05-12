using primeiraApi.Enums;

namespace primeiraApi.Services.Auth;

public interface ITokenService
{
    string GerarToken(string email, AdministradorRule rule, DateTime expiraEm);
}
