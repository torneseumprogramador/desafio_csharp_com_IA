namespace _01___Relacionamentos.Models;

public class Departamento
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
