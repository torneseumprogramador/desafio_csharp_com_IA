namespace primeiraApi.Configuration;

public class AuthOptions
{
    public const string SectionName = "Auth";

    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
