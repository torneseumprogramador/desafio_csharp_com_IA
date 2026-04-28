namespace _01___Relacionamentos.Models;

public class MaterialApoio
{
    public int AulaId { get; set; }
    public string Url { get; set; } = string.Empty;

    public Aula? Aula { get; set; }
}
