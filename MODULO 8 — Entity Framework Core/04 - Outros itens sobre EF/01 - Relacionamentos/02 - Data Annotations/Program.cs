using _02___Data_Annotations.Data;
using _02___Data_Annotations.Models;
using Microsoft.EntityFrameworkCore;

using var context = new EscolaContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

if (!context.Departamentos.Any())
{
    var deptTi = new Departamento { Nome = "Tecnologia" };
    var deptDesign = new Departamento { Nome = "Design" };

    var cursoCSharp = new Curso { Titulo = "C# Avancado", Departamento = deptTi };
    var cursoEf = new Curso { Titulo = "Entity Framework Core", Departamento = deptTi };
    var cursoUx = new Curso { Titulo = "UX para Produtos Digitais", Departamento = deptDesign };

    var ana = new Aluno { Nome = "Ana" };
    var bruno = new Aluno { Nome = "Bruno", Mentor = ana };
    var carla = new Aluno { Nome = "Carla", Mentor = ana };

    var matriculas = new List<Matricula>
    {
        new() { Aluno = ana, Curso = cursoCSharp, DataMatricula = DateTime.Today.AddDays(-12), NotaFinal = 9.50m },
        new() { Aluno = ana, Curso = cursoEf, DataMatricula = DateTime.Today.AddDays(-9), NotaFinal = 8.75m },
        new() { Aluno = bruno, Curso = cursoEf, DataMatricula = DateTime.Today.AddDays(-10), NotaFinal = 7.90m },
        new() { Aluno = carla, Curso = cursoUx, DataMatricula = DateTime.Today.AddDays(-8), NotaFinal = 9.10m },
        new() { Aluno = carla, Curso = cursoCSharp, DataMatricula = DateTime.Today.AddDays(-5), NotaFinal = 8.20m }
    };

    var aulas = new List<Aula>
    {
        new() { Tema = "LINQ em cenarios reais", Curso = cursoEf },
        new() { Tema = "Mapeamentos avancados no EF Core", Curso = cursoEf },
        new() { Tema = "Delegates e expressoes lambda", Curso = cursoCSharp }
    };

    context.AddRange(deptTi, deptDesign, cursoCSharp, cursoEf, cursoUx, ana, bruno, carla);
    context.AddRange(matriculas);
    context.AddRange(aulas);
    context.SaveChanges();

    var materiais = new List<MaterialApoio>
    {
        new() { AulaId = aulas[0].Id, Url = "https://exemplo.dev/linq-avancado" },
        new() { AulaId = aulas[1].Id, Url = "https://exemplo.dev/data-annotations-efcore" },
        new() { AulaId = aulas[2].Id, Url = "https://exemplo.dev/lambda-delegates" }
    };

    context.AddRange(materiais);
    context.SaveChanges();
}

var alunosComCursos = context.Alunos
    .Include(a => a.Matriculas)
        .ThenInclude(m => m.Curso)
    .Include(a => a.Mentor)
    .AsNoTracking()
    .ToList();

Console.WriteLine("=== Alunos, mentor e cursos (N:N com entidade associativa) ===");
foreach (var aluno in alunosComCursos)
{
    Console.WriteLine($"\nAluno: {aluno.Nome}");
    Console.WriteLine($"Mentor: {aluno.Mentor?.Nome ?? "Sem mentor"}");

    foreach (var matricula in aluno.Matriculas)
    {
        Console.WriteLine(
            $"- Curso: {matricula.Curso?.Titulo} | Data: {matricula.DataMatricula:dd/MM/yyyy} | Nota: {matricula.NotaFinal:F2}");
    }
}

var aulasComMaterial = context.Aulas
    .Include(a => a.MaterialApoio)
    .Include(a => a.Curso)
    .AsNoTracking()
    .ToList();

Console.WriteLine("\n=== Aulas e material de apoio (1:1) ===");
foreach (var aula in aulasComMaterial)
{
    Console.WriteLine($"Aula: {aula.Tema} | Curso: {aula.Curso?.Titulo}");
    Console.WriteLine($"Material: {aula.MaterialApoio?.Url}");
}
