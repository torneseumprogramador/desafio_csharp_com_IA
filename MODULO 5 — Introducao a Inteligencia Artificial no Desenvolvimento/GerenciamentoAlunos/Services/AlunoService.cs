using GerenciamentoAlunos.Models;
using GerenciamentoAlunos.Repositories;

namespace GerenciamentoAlunos.Services;

public class AlunoService(AlunoRepository repository)
{
    private readonly AlunoRepository _repo = repository;

    public (bool sucesso, string mensagem, Aluno? aluno) Cadastrar(string nome, string email, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            return (false, "Nome não pode ser vazio.", null);

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            return (false, "Email inválido.", null);

        if (idade < 5 || idade > 120)
            return (false, "Idade inválida.", null);

        var aluno = _repo.Adicionar(new Aluno { Nome = nome.Trim(), Email = email.Trim(), Idade = idade });
        return (true, "Aluno cadastrado com sucesso.", aluno);
    }

    public (bool sucesso, string mensagem) AdicionarNota(int id, double nota)
    {
        if (nota < 0 || nota > 10)
            return (false, "Nota deve estar entre 0 e 10.");

        var aluno = _repo.BuscarPorId(id);
        if (aluno is null)
            return (false, $"Aluno com ID {id} não encontrado.");

        aluno.Notas.Add(nota);
        _repo.Atualizar(aluno);
        return (true, $"Nota {nota:F1} adicionada. Média atual: {aluno.Media:F1}");
    }

    public (bool sucesso, string mensagem) Remover(int id)
    {
        if (!_repo.Remover(id))
            return (false, $"Aluno com ID {id} não encontrado.");
        return (true, "Aluno removido com sucesso.");
    }

    public List<Aluno> ListarTodos() => _repo.ListarTodos();

    public Aluno? BuscarPorId(int id) => _repo.BuscarPorId(id);

    public List<Aluno> BuscarPorNome(string nome) => _repo.BuscarPorNome(nome);

    public (bool sucesso, string mensagem) AtualizarDados(int id, string nome, string email, int idade)
    {
        var aluno = _repo.BuscarPorId(id);
        if (aluno is null)
            return (false, $"Aluno com ID {id} não encontrado.");

        if (string.IsNullOrWhiteSpace(nome))
            return (false, "Nome não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            return (false, "Email inválido.");

        if (idade < 5 || idade > 120)
            return (false, "Idade inválida.");

        aluno.Nome = nome.Trim();
        aluno.Email = email.Trim();
        aluno.Idade = idade;
        _repo.Atualizar(aluno);
        return (true, "Dados atualizados com sucesso.");
    }

    public string GerarRelatorio()
    {
        var alunos = _repo.ListarTodos();
        if (alunos.Count == 0)
            return "Nenhum aluno cadastrado.";

        var aprovados = alunos.Count(a => a.Situacao == "Aprovado");
        var recuperacao = alunos.Count(a => a.Situacao == "Recuperação");
        var reprovados = alunos.Count(a => a.Situacao == "Reprovado");
        var mediaTurma = alunos.Where(a => a.Notas.Count > 0).Select(a => a.Media).DefaultIfEmpty(0).Average();

        return $"""
            ═══════════════════ RELATÓRIO DA TURMA ═══════════════════
            Total de alunos  : {alunos.Count}
            Aprovados        : {aprovados}
            Em recuperação   : {recuperacao}
            Reprovados       : {reprovados}
            Média da turma   : {mediaTurma:F1}
            ══════════════════════════════════════════════════════════
            """;
    }
}
