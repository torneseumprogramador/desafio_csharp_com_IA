namespace _01___Relacionamentos.Models;

public class Aula
{
    public int Id { get; set; }
    public string Tema { get; set; } = string.Empty;
    public int CursoId { get; set; }

    public Curso? Curso { get; set; }
    public MaterialApoio? MaterialApoio { get; set; }
}
