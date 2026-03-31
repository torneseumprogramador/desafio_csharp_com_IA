using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using AcademiaApp.Domain.Interfaces;
using AcademiaApp.Domain.Models;

namespace AcademiaApp.Infrastructure.Repositories;

public class AlunoRepository : IAlunoRepository
{
    private readonly string _filePath = "alunos.json";
    private readonly List<Aluno> _alunos;

    public AlunoRepository()
    {
        if (File.Exists(_filePath))
        {
            var json = File.ReadAllText(_filePath);
            _alunos = JsonSerializer.Deserialize<List<Aluno>>(json) ?? new List<Aluno>();
        }
        else
        {
            _alunos = new List<Aluno>();
        }
    }

    private void Salvar()
    {
        var json = JsonSerializer.Serialize(_alunos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }

    public void Adicionar(Aluno aluno)
    {
        aluno.Id = _alunos.Any() ? _alunos.Max(a => a.Id) + 1 : 1;
        _alunos.Add(aluno);
        Salvar();
    }

    public Aluno ObterPorId(int id)
    {
        return _alunos.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Aluno> ObterTodos()
    {
        return _alunos;
    }

    public void Atualizar(Aluno aluno)
    {
        var existente = ObterPorId(aluno.Id);
        if (existente != null)
        {
            existente.Nome = aluno.Nome;
            existente.DataNascimento = aluno.DataNascimento;
            existente.Peso = aluno.Peso;
            existente.Altura = aluno.Altura;
            existente.Status = aluno.Status;
            Salvar();
        }
    }

    public void Remover(int id)
    {
        var aluno = ObterPorId(id);
        if (aluno != null)
        {
            _alunos.Remove(aluno);
            Salvar();
        }
    }
}
