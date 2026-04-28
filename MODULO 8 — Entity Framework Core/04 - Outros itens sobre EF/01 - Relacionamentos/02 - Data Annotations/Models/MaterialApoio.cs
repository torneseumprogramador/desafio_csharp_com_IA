using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02___Data_Annotations.Models;

[Table("MateriaisApoio")]
public class MaterialApoio
{
    [Key]
    [ForeignKey(nameof(Aula))]
    public int AulaId { get; set; }

    [Required]
    [MaxLength(250)]
    public string Url { get; set; } = string.Empty;

    public Aula? Aula { get; set; }
}
