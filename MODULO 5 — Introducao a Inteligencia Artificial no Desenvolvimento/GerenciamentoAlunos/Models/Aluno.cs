namespace GerenciamentoAlunos.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Idade { get; set; }
    public List<double> Notas { get; set; } = [];

    public double Media => Notas.Count > 0 ? Notas.Average() : 0;

    public string Situacao => Media switch
    {
        >= 7 => "Aprovado",
        >= 5 => "Recuperação",
        _ => "Reprovado"
    };

    public override string ToString() =>
        $"[{Id}] {Nome} | Idade: {Idade} | Email: {Email} | Média: {Media:F1} | {Situacao}";
}
