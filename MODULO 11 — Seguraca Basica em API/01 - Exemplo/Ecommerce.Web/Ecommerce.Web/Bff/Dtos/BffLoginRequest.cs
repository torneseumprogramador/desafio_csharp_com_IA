namespace Ecommerce.Web.Bff.Dtos;

/// <summary>Corpo JSON do POST /api/bff/auth/login (camelCase no wire).</summary>
public sealed class BffLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
