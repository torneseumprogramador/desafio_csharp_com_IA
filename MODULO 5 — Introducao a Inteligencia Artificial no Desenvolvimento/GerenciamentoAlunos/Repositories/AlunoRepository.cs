using GerenciamentoAlunos.Models;

namespace GerenciamentoAlunos.Repositories;

public class AlunoRepository
{
    private readonly List<Aluno> _alunos = [];
    private int _proximoId = 1;

    public Aluno Adicionar(Aluno aluno)
    {
        aluno.Id = _proximoId++;
        _alunos.Add(aluno);
        return aluno;
    }

    public List<Aluno> ListarTodos() => [.. _alunos];

    public Aluno? BuscarPorId(int id) =>
        _alunos.FirstOrDefault(a => a.Id == id);

    public List<Aluno> BuscarPorNome(string nome) =>
        _alunos.Where(a => a.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();

    public bool Atualizar(Aluno aluno)
    {
        var index = _alunos.FindIndex(a => a.Id == aluno.Id);
        if (index < 0) return false;
        _alunos[index] = aluno;
        return true;
    }

    public bool Remover(int id)
    {
        var aluno = BuscarPorId(id);
        if (aluno is null) return false;
        _alunos.Remove(aluno);
        return true;
    }

    public bool Existe(int id) => _alunos.Any(a => a.Id == id);
}
