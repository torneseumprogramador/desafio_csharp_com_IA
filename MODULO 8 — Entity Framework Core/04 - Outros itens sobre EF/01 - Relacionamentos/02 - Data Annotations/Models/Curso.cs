using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02___Data_Annotations.Models;

[Table("Cursos")]
public class Curso
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Titulo { get; set; } = string.Empty;

    public int DepartamentoId { get; set; }

    [ForeignKey(nameof(DepartamentoId))]
    public Departamento? Departamento { get; set; }

    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
}
