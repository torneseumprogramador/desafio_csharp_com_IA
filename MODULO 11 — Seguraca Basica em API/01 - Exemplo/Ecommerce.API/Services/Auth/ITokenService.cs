namespace primeiraApi.Services.Auth;

public interface ITokenService
{
    string GerarToken(string email, DateTime expiraEm);
}
