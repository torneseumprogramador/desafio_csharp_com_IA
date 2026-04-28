using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02___Data_Annotations.Models;

[Table("Departamentos")]
public class Departamento
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string Nome { get; set; } = string.Empty;

    public ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
