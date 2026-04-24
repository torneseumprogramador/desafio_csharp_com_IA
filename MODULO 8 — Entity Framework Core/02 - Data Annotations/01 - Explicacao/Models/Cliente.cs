using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01___Explicacao.Models;

[Table("clientes")]
public sealed class Cliente
{
    [Key]
    [Column("id", TypeName = "int")]
    public int Id { get; set; }

    [Required]
    [Column("nome", TypeName = "varchar(120)")]
    [StringLength(120)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [Column("documento", TypeName = "varchar(20)")]
    [StringLength(20)]
    public string Documento { get; set; } = string.Empty;

    [Required]
    [Column("telefone", TypeName = "varchar(20)")]
    [StringLength(20)]
    public string Telefone { get; set; } = string.Empty;

    [Column("email", TypeName = "varchar(120)")]
    [StringLength(120)]
    [EmailAddress]
    public string? Email { get; set; }

    public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
