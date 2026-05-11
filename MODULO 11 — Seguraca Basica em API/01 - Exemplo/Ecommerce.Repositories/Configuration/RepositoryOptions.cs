namespace primeiraApi.Configuration;

public class RepositoryOptions
{
    public const string SectionName = "Repository";

    public string Provider { get; set; } = "Memory";
}
