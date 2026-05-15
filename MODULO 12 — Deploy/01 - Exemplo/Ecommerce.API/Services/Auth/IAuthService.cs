using primeiraApi.Enums;
using primeiraApi.ModelViews;

namespace primeiraApi.Services.Auth;

public interface IAuthService
{
    LoginResponseDto GerarRespostaAutenticacao(string nome, string email, AdministradorRule rule);

    bool ObterDadosDoToken(
        string? authorizationHeader,
        out string nome,
        out string email,
        out AdministradorRule rule);
}
