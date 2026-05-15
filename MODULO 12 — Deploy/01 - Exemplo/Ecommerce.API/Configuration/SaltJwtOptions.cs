namespace primeiraApi.Configuration;

public class SaltJwtOptions
{
    public const string SectionName = "SaltJwt";

    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
}
