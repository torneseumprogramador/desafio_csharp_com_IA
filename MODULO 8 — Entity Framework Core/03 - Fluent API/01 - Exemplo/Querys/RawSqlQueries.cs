using _01___Exemplo.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Querys;

public static class RawSqlQueries
{
    public static void Executar(BibliotecaContext context)
    {
        Console.WriteLine("=== CONSULTAS COM SQL BRUTA ===");

        var emprestimosFinalizados = context.Emprestimos
            .FromSqlInterpolated($"SELECT * FROM emprestimos WHERE status = {"Finalizado"}")
            .AsNoTracking()
            .ToList();

        Console.WriteLine("[EF CORE - FromSqlInterpolated]");
        foreach (var emprestimo in emprestimosFinalizados)
        {
            Console.WriteLine($"- Emprestimo: {emprestimo.Id} | Status: {emprestimo.Status}");
        }

        var totalUsuarios = context.Database
            .SqlQuery<int>($"SELECT COUNT(*) AS Value FROM usuarios")
            .First();
        Console.WriteLine($"[EF CORE - Database.SqlQuery] Total de usuarios: {totalUsuarios}");



        // Exemplo ADO.NET puro para quando voce precisa de controle total do SQL.
        using var conexao = new SqliteConnection("Data Source=biblioteca.db");
        conexao.Open();

        using var comando = conexao.CreateCommand();
        comando.CommandText = """
            SELECT a.nome, COUNT(l.id) AS total_livros
            FROM autores a
            LEFT JOIN livros l ON l.autorId = a.id
            GROUP BY a.nome
            ORDER BY total_livros DESC;
            """;

        using var reader = comando.ExecuteReader();
        Console.WriteLine("[ADO.NET - SQL BRUTA COM JOIN/GROUP BY]");
        while (reader.Read())
        {
            var autor = reader.GetString(0);
            var totalLivros = reader.GetInt32(1);
            Console.WriteLine($"- Autor: {autor} | Total de livros: {totalLivros}");
        }

        Console.WriteLine();


        // Mesmo exemplo acima do ADO.NET feito com LINQ to no EF Core.
        var livrosPorAutorEfCore = context.Autores
            .AsNoTracking()
            .GroupJoin(
                context.Livros.AsNoTracking(),
                autor => autor.Id,
                livro => livro.AutorId,
                (autor, livros) => new
                {
                    Autor = autor.Nome,
                    TotalLivros = livros.Count()
                })
            .OrderByDescending(x => x.TotalLivros)
            .ToList();

        Console.WriteLine("[EF CORE - LEFT JOIN/GROUP BY (via LINQ)]");
        foreach (var item in livrosPorAutorEfCore)
        {
            Console.WriteLine($"- Autor: {item.Autor} | Total de livros: {item.TotalLivros}");
        }

    }
}
