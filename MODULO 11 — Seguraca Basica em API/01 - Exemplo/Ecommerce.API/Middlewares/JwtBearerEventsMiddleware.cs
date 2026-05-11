using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using primeiraApi.ModelViews;

namespace primeiraApi.Middlewares;

public static class JwtBearerEventsMiddleware
{
    public static JwtBearerEvents CriarEventos()
    {
        return new JwtBearerEvents
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();

                var mensagem = context.AuthenticateFailure is SecurityTokenExpiredException
                    ? "Token expirado. Faça login novamente."
                    : "Acesso negado. Informe um token JWT válido.";

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new MensagemResposta { Message = mensagem });
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsJsonAsync(new MensagemResposta
                {
                    Message = "Acesso negado. Você não tem permissão para acessar este recurso."
                });
            }
        };
    }
}
