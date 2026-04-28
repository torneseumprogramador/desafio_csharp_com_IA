using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02___Data_Annotations.Models;

[Table("Aulas")]
public class Aula
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Tema { get; set; } = string.Empty;

    public int CursoId { get; set; }

    [ForeignKey(nameof(CursoId))]
    public Curso? Curso { get; set; }

    public MaterialApoio? MaterialApoio { get; set; }
}
