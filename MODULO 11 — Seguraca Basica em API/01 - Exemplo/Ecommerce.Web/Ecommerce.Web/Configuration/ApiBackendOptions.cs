namespace Ecommerce.Web.Configuration;

public class ApiBackendOptions
{
    public const string SectionName = "ApiBackend";

    /// <summary>URL base da Ecommerce.API (somente servidor; o browser não acessa).</summary>
    public string BaseUrl { get; set; } = "http://localhost:5047/";
}
